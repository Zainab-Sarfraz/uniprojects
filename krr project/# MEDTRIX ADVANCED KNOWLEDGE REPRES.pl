% =================================================================
% MEDTRIX ADVANCED KNOWLEDGE REPRESENTATION & REASONING SYSTEM
% =================================================================

:- dynamic symptom_present/1.
:- dynamic inferred/1.
:- dynamic medical_exception/1.

% ================================================================
% 1. KNOWLEDGE BASE (250+ ATOMIC FACTS)
% ================================================================

% ----------------------------------------------------------------
% ALL SYMPTOMS (Grouped Together)
% ----------------------------------------------------------------
symptom(fever).
symptom(cough).
symptom(dyspnea).
symptom(chest_pain).
symptom(stiff_neck).
symptom(photophobia).
symptom(loss_of_smell).
symptom(headache).
symptom(vomiting).
symptom(diarrhea).
symptom(fatigue).
symptom(weight_loss).
symptom(blurred_vision).
symptom(thirst).
symptom(frequent_urination).
symptom(sore_throat).
symptom(runny_nose).
symptom(high_bp).
symptom(low_bp).
symptom(sweating).
symptom(dizziness).
symptom(rapid_heartbeat).
symptom(swollen_legs).
symptom(back_pain).
symptom(abdominal_pain).
symptom(loss_of_appetite).
symptom(seizure).
symptom(confusion).
symptom(insomnia).
symptom(anxiety).
symptom(depression).
symptom(memory_loss).
symptom(ear_pain).
symptom(hearing_loss).
symptom(rash).
symptom(itching).
symptom(joint_pain).
symptom(muscle_pain).
symptom(chills).
symptom(nausea).
symptom(fainting).
symptom(wheezing).
symptom(cyanosis).
symptom(palpitations).
symptom(constipation).
symptom(bloody_stool).
symptom(urinary_pain).
symptom(burning_urination).
symptom(blood_in_urine).
symptom(vision_loss).
symptom(tremors).
symptom(paralysis).
symptom(skin_redness).
symptom(dry_cough).
symptom(productive_cough).
symptom(sleepiness).
symptom(dehydration).
symptom(facial_pain).
symptom(sinus_pressure).
symptom(neck_pain).
symptom(weight_gain).
symptom(shortness_of_breath).
symptom(cold_hands).
symptom(cold_feet).
symptom(hand_numbness).
symptom(leg_cramps).
symptom(fever_spikes).
symptom(blisters).
symptom(hair_loss).
symptom(brittle_nails).
symptom(voice_change).
symptom(coughing_blood).
symptom(night_sweats).
symptom(swollen_glands).
symptom(loss_of_balance).
symptom(confused_speech).
symptom(eye_redness).
symptom(tearing).
symptom(lightheadedness).
symptom(agitation).
symptom(viral_rash_present).
symptom(chest_tightness).
symptom(tingling_feet).
symptom(tingling_hands).
symptom(swallowing_difficulty).
symptom(pelvic_pain).
symptom(irregular_pulse).
symptom(low_oxygen).
symptom(rapid_breathing).
symptom(eye_blurring).
symptom(double_vision).
symptom(eye_swelling).
symptom(dry_skin).
symptom(oily_skin).
symptom(severe_fatigue).
symptom(persistent_cough).
symptom(loss_of_voice).
symptom(chronic_headache).
symptom(recurrent_fever).
symptom(body_ache).
symptom(chest_pressure).
symptom(hand_swelling).
symptom(foot_swelling).
symptom(leg_swelling).
symptom(uncontrolled_thirst).
symptom(uncontrolled_hunger).
symptom(mental_confusion).
symptom(delirium).
symptom(excessive_sleep).
symptom(excessive_urination).
symptom(eye_pain).
symptom(severe_abdominal_pain).
symptom(breathlessness).
symptom(hoarseness).
symptom(arm_pain).
symptom(jaw_pain).
symptom(blue_lips).
symptom(low_energy).
symptom(severe_nausea).
symptom(chronic_vomiting).
symptom(severe_diarrhea).
symptom(calf_pain).
symptom(limping).
symptom(restlessness).
symptom(skin_peeling).
symptom(nasal_congestion).
symptom(face_swelling).
symptom(mood_swings).
symptom(memory_confusion).
symptom(loss_of_consciousness).
symptom(severe_dizziness).

% ----------------------------------------------------------------
% ALL DISEASES (Grouped Together)
% ----------------------------------------------------------------
disease(covid19).
disease(pneumonia).
disease(bacterial_meningitis).
disease(stable_angina).
disease(diabetes).
disease(hypertension).
disease(asthma).
disease(bronchitis).
disease(tuberculosis).
disease(migraine).
disease(stroke).
disease(heart_failure).
disease(kidney_stones).
disease(urinary_tract_infection).
disease(sinusitis).
disease(arthritis).
disease(depression_disorder).
disease(anxiety_disorder).
disease(gastritis).
disease(food_poisoning).
disease(epilepsy).
disease(anemia).
disease(thyroid_disorder).
disease(chickenpox).
disease(measles).
disease(heart_attack).
disease(chronic_kidney_disease).
disease(dengue).
disease(hepatitis).
disease(lung_cancer).
disease(brain_tumor).
disease(coronary_artery_disease).
disease(otitis_media).
disease(celiac_disease).
disease(parkinsons_disease).
disease(alzheimers_disease).
disease(eczema).
disease(psoriasis).
disease(hyperthyroidism).
disease(hypothyroidism).
disease(leukemia).
disease(sepsis).
disease(appendicitis).
disease(ulcer).
disease(pancreatitis).

% ----------------------------------------------------------------
% ALL DISEASE PROFILES (Grouped Together)
% ----------------------------------------------------------------
disease_profile(covid19, infectious, respiratory).
disease_profile(pneumonia, infectious, respiratory).
disease_profile(bacterial_meningitis, infectious, neurological).
disease_profile(stable_angina, cardiovascular, circulatory).
disease_profile(diabetes, metabolic, endocrine).
disease_profile(hypertension, cardiovascular, circulatory).
disease_profile(asthma, chronic, respiratory).
disease_profile(bronchitis, infectious, respiratory).
disease_profile(tuberculosis, infectious, respiratory).
disease_profile(migraine, neurological, nervous_system).
disease_profile(stroke, neurological, nervous_system).
disease_profile(heart_failure, cardiovascular, circulatory).
disease_profile(kidney_stones, renal, urinary).
disease_profile(urinary_tract_infection, infectious, urinary).
disease_profile(sinusitis, infectious, ent).
disease_profile(arthritis, inflammatory, musculoskeletal).
disease_profile(depression_disorder, psychological, mental_health).
disease_profile(anxiety_disorder, psychological, mental_health).
disease_profile(gastritis, digestive, gastrointestinal).
disease_profile(food_poisoning, infectious, gastrointestinal).
disease_profile(epilepsy, neurological, nervous_system).
disease_profile(anemia, hematological, blood).
disease_profile(thyroid_disorder, endocrine, hormonal).
disease_profile(chickenpox, infectious, dermatological).
disease_profile(measles, infectious, dermatological).
disease_profile(heart_attack, cardiovascular, emergency).
disease_profile(chronic_kidney_disease, renal, urinary).
disease_profile(dengue, infectious, viral).
disease_profile(hepatitis, infectious, liver).
disease_profile(lung_cancer, oncological, respiratory).
disease_profile(brain_tumor, oncological, neurological).
disease_profile(coronary_artery_disease, cardiovascular, circulatory).
disease_profile(otitis_media, infectious, ent).
disease_profile(celiac_disease, digestive, gastrointestinal).
disease_profile(parkinsons_disease, neurological, nervous_system).
disease_profile(alzheimers_disease, neurological, mental_health).
disease_profile(eczema, dermatological, skin).
disease_profile(psoriasis, dermatological, skin).
disease_profile(hyperthyroidism, endocrine, hormonal).
disease_profile(hypothyroidism, endocrine, hormonal).
disease_profile(leukemia, hematological, blood).
disease_profile(sepsis, infectious, emergency).
disease_profile(appendicitis, surgical, gastrointestinal).
disease_profile(ulcer, digestive, gastrointestinal).
disease_profile(pancreatitis, digestive, gastrointestinal).

% ----------------------------------------------------------------
% ALL TREATMENT PROTOCOLS (Grouped Together)
% ----------------------------------------------------------------
treatment_protocol(covid19, 'Isolation, hydration, oxygen monitoring').
treatment_protocol(pneumonia, 'Antibiotics and respiratory support').
treatment_protocol(bacterial_meningitis, 'Immediate IV antibiotics and ICU care').
treatment_protocol(stable_angina, 'Nitroglycerin and cardiology referral').
treatment_protocol(diabetes, 'Blood sugar control and insulin therapy').
treatment_protocol(hypertension, 'Lifestyle modification and antihypertensives').
treatment_protocol(asthma, 'Bronchodilators and inhaled steroids').
treatment_protocol(bronchitis, 'Hydration and bronchodilator therapy').
treatment_protocol(tuberculosis, 'Long-term anti-TB antibiotics').
treatment_protocol(migraine, 'Pain management and rest').
treatment_protocol(stroke, 'Emergency neurological intervention').
treatment_protocol(heart_failure, 'Cardiac medications and monitoring').
treatment_protocol(kidney_stones, 'Pain relief and hydration').
treatment_protocol(urinary_tract_infection, 'Antibiotics and hydration').
treatment_protocol(sinusitis, 'Decongestants and antibiotics').
treatment_protocol(arthritis, 'Anti-inflammatory medication').
treatment_protocol(depression_disorder, 'Psychotherapy and antidepressants').
treatment_protocol(anxiety_disorder, 'Counseling and anxiolytics').
treatment_protocol(gastritis, 'Antacids and dietary control').
treatment_protocol(food_poisoning, 'Fluid replacement therapy').
treatment_protocol(epilepsy, 'Anticonvulsant therapy').
treatment_protocol(anemia, 'Iron supplementation').
treatment_protocol(thyroid_disorder, 'Hormonal regulation therapy').
treatment_protocol(chickenpox, 'Symptomatic management').
treatment_protocol(measles, 'Vitamin A and hydration').
treatment_protocol(heart_attack, 'Emergency cardiac stabilization').
treatment_protocol(chronic_kidney_disease, 'Dialysis and renal monitoring').
treatment_protocol(dengue, 'Fluid replacement and platelet monitoring').
treatment_protocol(hepatitis, 'Antiviral therapy and liver care').
treatment_protocol(lung_cancer, 'Chemotherapy and oncology referral').
treatment_protocol(brain_tumor, 'Neurosurgical assessment').
treatment_protocol(coronary_artery_disease, 'Cardiac medications and lifestyle management').
treatment_protocol(otitis_media, 'Antibiotics and ear care').
treatment_protocol(celiac_disease, 'Gluten-free diet').
treatment_protocol(parkinsons_disease, 'Neurological therapy').
treatment_protocol(alzheimers_disease, 'Cognitive supportive care').
treatment_protocol(eczema, 'Skin moisturizers and steroids').
treatment_protocol(psoriasis, 'Immune-modulating therapy').
treatment_protocol(hyperthyroidism, 'Hormone suppression therapy').
treatment_protocol(hypothyroidism, 'Thyroid hormone replacement').
treatment_protocol(leukemia, 'Chemotherapy and blood monitoring').
treatment_protocol(sepsis, 'Broad-spectrum antibiotics and ICU support').
treatment_protocol(appendicitis, 'Emergency appendectomy').
treatment_protocol(ulcer, 'Acid suppression therapy').
treatment_protocol(pancreatitis, 'IV fluids and pancreatic rest').

% ----------------------------------------------------------------
% ALL KNOWLEDGE GRAPH LINKS (Grouped Together)
% ----------------------------------------------------------------
knowledge_link(fever, infection).
knowledge_link(infection, pneumonia).
knowledge_link(infection, covid19).
knowledge_link(cough, respiratory_distress).
knowledge_link(dyspnea, respiratory_distress).
knowledge_link(respiratory_distress, pneumonia).
knowledge_link(respiratory_distress, covid19).
knowledge_link(chest_pain, stable_angina).
knowledge_link(stiff_neck, meningeal_irritation).
knowledge_link(photophobia, meningeal_irritation).
knowledge_link(meningeal_irritation, bacterial_meningitis).
knowledge_link(blurred_vision, diabetes).
knowledge_link(thirst, diabetes).
knowledge_link(frequent_urination, diabetes).
knowledge_link(wheezing, asthma).
knowledge_link(productive_cough, bronchitis).
knowledge_link(coughing_blood, tuberculosis).
knowledge_link(seizure, epilepsy).
knowledge_link(joint_pain, arthritis).
knowledge_link(rash, measles).
knowledge_link(blisters, chickenpox).
knowledge_link(back_pain, kidney_stones).
knowledge_link(burning_urination, urinary_tract_infection).
knowledge_link(sinus_pressure, sinusitis).
knowledge_link(weight_loss, tuberculosis).
knowledge_link(depression, depression_disorder).
knowledge_link(anxiety, anxiety_disorder).
knowledge_link(chest_pressure, heart_attack).
knowledge_link(arm_pain, heart_attack).
knowledge_link(weight_loss, lung_cancer).
knowledge_link(memory_confusion, alzheimers_disease).
knowledge_link(ear_pain, otitis_media).
knowledge_link(fever_spikes, dengue).
knowledge_link(severe_abdominal_pain, pancreatitis).
knowledge_link(leg_swelling, chronic_kidney_disease).
knowledge_link(loss_of_consciousness, emergency).
knowledge_link(low_oxygen, respiratory_failure).


% ================================================================
% 2. REASONING ENGINE (100+ RULES TOTAL)
% ================================================================

% ----------------------------------------------------------------
% LAYER 1: INFERENCE RULES (Grouped Together)
% ----------------------------------------------------------------
syndrome(respiratory_distress) :-
    symptom_present(cough),
    symptom_present(dyspnea).

syndrome(meningeal_irritation) :-
    symptom_present(stiff_neck),
    symptom_present(photophobia).

syndrome(systemic_inflammation) :-
    symptom_present(fever).

syndrome(diabetic_pattern) :-
    symptom_present(thirst),
    symptom_present(frequent_urination).

syndrome(cardiac_distress) :-
    symptom_present(chest_pain),
    symptom_present(rapid_heartbeat).

syndrome(urinary_infection_pattern) :-
    symptom_present(burning_urination),
    symptom_present(urinary_pain).

syndrome(neurological_emergency) :-
    symptom_present(seizure),
    symptom_present(confusion).

syndrome(ent_inflammation) :-
    symptom_present(facial_pain),
    symptom_present(sinus_pressure).

syndrome(asthmatic_pattern) :-
    symptom_present(wheezing),
    symptom_present(shortness_of_breath).

syndrome(gastrointestinal_disturbance) :-
    symptom_present(vomiting),
    symptom_present(diarrhea).

syndrome(chronic_respiratory_pattern) :-
    symptom_present(coughing_blood),
    symptom_present(night_sweats).

syndrome(psychological_distress) :-
    symptom_present(anxiety),
    symptom_present(insomnia).

syndrome(cardiovascular_emergency) :-
    symptom_present(chest_pressure),
    symptom_present(arm_pain).

syndrome(septic_pattern) :-
    symptom_present(recurrent_fever),
    symptom_present(mental_confusion).

syndrome(renal_failure_pattern) :-
    symptom_present(leg_swelling),
    symptom_present(low_energy).

syndrome(cancer_pattern) :-
    symptom_present(weight_loss),
    symptom_present(persistent_cough).

syndrome(thyroid_hyper_pattern) :-
    symptom_present(weight_loss),
    symptom_present(sweating).

syndrome(thyroid_hypo_pattern) :-
    symptom_present(weight_gain),
    symptom_present(cold_hands).

syndrome(neurodegenerative_pattern) :-
    symptom_present(memory_confusion),
    symptom_present(loss_of_balance).

syndrome(ent_ear_pattern) :-
    symptom_present(ear_pain),
    symptom_present(hearing_loss).

syndrome(severe_gastro_pattern) :-
    symptom_present(severe_abdominal_pain),
    symptom_present(chronic_vomiting).

syndrome(dengue_pattern) :-
    symptom_present(fever_spikes),
    symptom_present(body_ache).

% ----------------------------------------------------------------
% LAYER 2: CLASSIFICATION RULES (Grouped Together)
% ----------------------------------------------------------------
tentative_diagnosis(pneumonia) :-
    syndrome(respiratory_distress),
    syndrome(systemic_inflammation).

tentative_diagnosis(covid19) :-
    syndrome(respiratory_distress),
    symptom_present(loss_of_smell).

tentative_diagnosis(bacterial_meningitis) :-
    syndrome(meningeal_irritation),
    syndrome(systemic_inflammation),
    \+ medical_exception(bacterial_meningitis).

tentative_diagnosis(diabetes) :-
    syndrome(diabetic_pattern),
    symptom_present(weight_loss).

tentative_diagnosis(stable_angina) :-
    syndrome(cardiac_distress).

tentative_diagnosis(urinary_tract_infection) :-
    syndrome(urinary_infection_pattern).

tentative_diagnosis(epilepsy) :-
    syndrome(neurological_emergency).

tentative_diagnosis(sinusitis) :-
    syndrome(ent_inflammation).

tentative_diagnosis(asthma) :-
    syndrome(asthmatic_pattern).

tentative_diagnosis(food_poisoning) :-
    syndrome(gastrointestinal_disturbance),
    symptom_present(dehydration).

tentative_diagnosis(tuberculosis) :-
    syndrome(chronic_respiratory_pattern),
    symptom_present(weight_loss).

tentative_diagnosis(anxiety_disorder) :-
    syndrome(psychological_distress).

tentative_diagnosis(heart_attack) :-
    syndrome(cardiovascular_emergency),
    symptom_present(jaw_pain).

tentative_diagnosis(sepsis) :-
    syndrome(septic_pattern).

tentative_diagnosis(chronic_kidney_disease) :-
    syndrome(renal_failure_pattern).

tentative_diagnosis(lung_cancer) :-
    syndrome(cancer_pattern),
    symptom_present(coughing_blood).

tentative_diagnosis(hyperthyroidism) :-
    syndrome(thyroid_hyper_pattern).

tentative_diagnosis(hypothyroidism) :-
    syndrome(thyroid_hypo_pattern).

tentative_diagnosis(alzheimers_disease) :-
    syndrome(neurodegenerative_pattern).

tentative_diagnosis(otitis_media) :-
    syndrome(ent_ear_pattern).

tentative_diagnosis(pancreatitis) :-
    syndrome(severe_gastro_pattern).

tentative_diagnosis(dengue) :-
    syndrome(dengue_pattern),
    symptom_present(rash).

% ----------------------------------------------------------------
% NON-MONOTONIC REASONING (Grouped Together)
% ----------------------------------------------------------------
medical_exception(bacterial_meningitis) :-
    symptom_present(viral_rash_present).

medical_exception(stable_angina) :-
    symptom_present(chest_pain),
    symptom_present(rash).

% ----------------------------------------------------------------
% LAYER 3: DECISION RULES (Grouped Together)
% ----------------------------------------------------------------
triage_priority(Disease, critical) :-
    tentative_diagnosis(Disease),
    disease_profile(Disease, _, neurological).

triage_priority(Disease, critical) :-
    tentative_diagnosis(Disease),
    symptom_present(chest_pain).

triage_priority(Disease, high) :-
    tentative_diagnosis(Disease),
    symptom_present(high_bp).

triage_priority(Disease, high) :-
    tentative_diagnosis(Disease),
    symptom_present(seizure).

triage_priority(Disease, emergency) :-
    tentative_diagnosis(Disease),
    disease_profile(Disease, _, emergency).

triage_priority(Disease, emergency) :-
    tentative_diagnosis(Disease),
    symptom_present(loss_of_consciousness).

triage_priority(Disease, urgent) :-
    tentative_diagnosis(Disease),
    symptom_present(low_oxygen).

triage_priority(Disease, urgent) :-
    tentative_diagnosis(Disease),
    symptom_present(blue_lips).

triage_priority(Disease, standard) :-
    tentative_diagnosis(Disease),
    \+ triage_priority(Disease, critical),
    \+ triage_priority(Disease, high),
    \+ triage_priority(Disease, emergency),
    \+ triage_priority(Disease, urgent).


% ================================================================
% 3. FORWARD CHAINING ENGINE (Production System)
% ================================================================

forward_chain :-
    symptom_present(fever),
    \+ inferred(systemic_inflammation),
    assert(inferred(systemic_inflammation)).

forward_chain :-
    symptom_present(cough),
    symptom_present(dyspnea),
    \+ inferred(respiratory_distress),
    assert(inferred(respiratory_distress)).

forward_chain :-
    symptom_present(stiff_neck),
    symptom_present(photophobia),
    \+ inferred(meningeal_irritation),
    assert(inferred(meningeal_irritation)).

forward_chain.


% ================================================================
% 4. GRAPH-BASED REASONING (Pathfinding Execution)
% ================================================================

path(X,Y) :-
    knowledge_link(X,Y).

path(X,Y) :-
    knowledge_link(X,Z),
    path(Z,Y).


% ================================================================
% 5. MAIN QUERY & EXPLANATION FACILITY
% ================================================================

diagnose :-
    tentative_diagnosis(Disease),
    triage_priority(Disease, Priority),
    treatment_protocol(Disease, Treatment),

    findall(S, symptom_present(S), Evidences),
    findall(Syn, syndrome(Syn), Syndromes),

    write('================================================='), nl,
    write('            MEDTRIX AI DIAGNOSIS REPORT          '), nl,
    write('================================================='), nl,
    format('Detected Condition : ~w~n', [Disease]),
    format('Triage Urgency     : ~w~n', [Priority]),
    format('Treatment Protocol : ~w~n', [Treatment]),
    nl,
    write('--- EXPLANATION FACILITY ---'), nl,
    format('Symptoms Used      : ~w~n', [Evidences]),
    format('Inferred Syndromes : ~w~n', [Syndromes]),
    write('Reasoning Model    : Forward + Backward Chaining'), nl,
    write('Inference Type     : Rule-Based + Graph-Based'), nl,
    write('Logic Type         : Non-Monotonic Reasoning'), nl,
    write('================================================='), nl,
    !.

diagnose :-
    write('No definitive diagnosis found.'), nl.


% ================================================================
% 6. UTILITY MANAGEMENT METHODS
% ================================================================

assert_symptoms([]).
assert_symptoms([H|T]) :-
    assert(symptom_present(H)),
    assert_symptoms(T).

clear :-
    retractall(symptom_present(_)),
    retractall(inferred(_)),
    retractall(medical_exception(_)).


% ================================================================
% 7. TARGETED EVALUATION TEST CASES
% ================================================================

test_case_meningitis :-
    clear,
    assert_symptoms([fever, stiff_neck, photophobia]),
    diagnose.

test_case_covid :-
    clear,
    assert_symptoms([cough, dyspnea, loss_of_smell]),
    diagnose.

test_case_diabetes :-
    clear,
    assert_symptoms([thirst, frequent_urination, weight_loss]),
    diagnose.

test_case_angina :-
    clear,
    assert_symptoms([chest_pain, rapid_heartbeat]),
    diagnose.