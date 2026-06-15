import os
import sys
import json
import subprocess
from flask import Flask, render_template, request, jsonify

app = Flask(__name__)

# Base folder discovery helper paths
BASE_DIR = os.path.dirname(os.path.abspath(__file__))
KB_PATH = os.path.join(BASE_DIR, "medtrix_kb.pl").replace("\\", "/")
SWIPL_EXECUTABLE = r"C:\Program Files\swipl\bin\swipl.exe"

@app.route('/')
def home():
    symptom_groups = {
        "General Signs": ["fever", "fatigue", "weight_loss", "sweating", "dizziness", "chills", "dehydration", "weight_gain"],
        "Respiratory": ["cough", "dyspnea", "loss_of_smell", "sore_throat", "runny_nose", "wheezing", "cyanosis", "productive_cough", "shortness_of_breath", "coughing_blood"],
        "Cardiovascular": ["chest_pain", "high_bp", "low_bp", "rapid_heartbeat", "swollen_legs", "palpitations", "chest_pressure", "arm_pain", "jaw_pain"],
        "Neurological": ["stiff_neck", "photophobia", "headache", "seizure", "confusion", "memory_loss", "paralysis", "loss_of_balance", "loss_of_consciousness"],
        "Gastrointestinal": ["vomiting", "diarrhea", "abdominal_pain", "loss_of_appetite", "nausea", "constipation", "bloody_stool", "severe_abdominal_pain"]
    }
    return render_template('index.html', groups=symptom_groups)

@app.route('/diagnose', methods=['POST'])
def run_diagnosis():
    selected_symptoms = request.json.get('symptoms', [])
    
    if not selected_symptoms:
        return jsonify({"status": "error", "message": "No clinical parameters passed."})

    # Build inline patient assertion statements systematically
    assertion_commands = "".join([f"assert(symptom_present({sym})), " for sym in selected_symptoms])

    # Craft a safe output delivery mechanism using distinct tokens to isolate variables cleanly
    prolog_query = (
        f"consult('{KB_PATH}'), clear, {assertion_commands}"
        f"tentative_diagnosis(Disease), triage_priority(Disease, Priority), treatment_protocol(Disease, Treatment), "
        f"findall(S, symptom_present(S), Evidences), findall(Syn, syndrome(Syn), Syndromes), "
        f"format('MEDTRIX_DATA|~w|~w|~w|~q|~q|~n', [Disease, Priority, Treatment, Evidences, Syndromes]), halt."
    )

    try:
        # Call standalone swipl executable
        process = subprocess.Popen(
            [SWIPL_EXECUTABLE, "-g", prolog_query, "halt."],
            stdout=subprocess.PIPE,
            stderr=subprocess.PIPE,
            text=True
        )
        stdout, stderr = process.communicate(timeout=5)

        # Parse data using split tokens to bypass json parsing anomalies completely
        if "MEDTRIX_DATA|" in stdout:
            data_line = [line for line in stdout.splitlines() if line.startswith("MEDTRIX_DATA|")][0]
            parts = data_line.split("|")
            
            disease = parts[1].strip()
            priority = parts[2].strip()
            treatment = parts[3].strip().strip("'\"") # Strip any trailing quotes
            
            # Safe clean up for the lists - using manual strip translation to prevent column 2 issues
            evidences_str = parts[4].strip("[] ").replace("'", "")
            evidences = [x.strip() for x in evidences_str.split(",") if x.strip()]
            
            syndromes_str = parts[5].strip("[] ").replace("'", "")
            syndromes = [x.strip() for x in syndromes_str.split(",") if x.strip()]
            
            # Safe text-based parser formulation for graph links dependencies
            graph_links = []
            for item in evidences:
                link_check_query = f"consult('{KB_PATH}'), knowledge_link({item}, Target), format('LINK:~w,~w~n', [{item}, Target]), fail; halt."
                link_process = subprocess.Popen([SWIPL_EXECUTABLE, "-g", link_check_query], stdout=subprocess.PIPE, text=True)
                link_out, _ = link_process.communicate()
                for line in link_out.splitlines():
                    if line.startswith("LINK:"):
                        lnk_parts = line.replace("LINK:", "").split(",")
                        if len(lnk_parts) >= 2:
                            graph_links.append({"source": lnk_parts[0].strip(), "target": lnk_parts[1].strip()})

            return jsonify({
                "status": "success",
                "disease": disease.replace('_', ' ').upper(),
                "priority": priority.upper(),
                "treatment": treatment,
                "explanation": {
                    "evidences": evidences,
                    "syndromes": syndromes,
                    "graph_links": graph_links
                }
            })
        else:
            return jsonify({
                "status": "no_match",
                "message": "Clinical indicators processed successfully. No definitive diagnosis found matching rule constraints."
            })

    except subprocess.TimeoutExpired:
        return jsonify({"status": "error", "message": "The inference engine loop exceeded processing time constraints."})
    except Exception as e:
        return jsonify({"status": "error", "message": f"Execution pipeline error: {str(e)}"})

if __name__ == '__main__':
    app.run(debug=True, port=5000)