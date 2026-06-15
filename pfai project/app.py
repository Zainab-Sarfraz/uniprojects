# app.py
from flask import Flask, render_template, request, jsonify # pyright: ignore[reportMissingImports]
import pickle
import numpy as np # pyright: ignore[reportMissingImports]
import urllib.parse

app = Flask(__name__)

# 1. Load your manually trained model brain during startup
try:
    with open('physio_models.pkl', 'rb') as f:
        chatbot_pipeline = pickle.load(f)
    print("🧠 Chatbot ML Brain loaded successfully into web server!")
except FileNotFoundError:
    print("❌ Error: 'physio_models.pkl' missing from project directory.")

# 2. Define clinical response maps with embedded exercise search links
RESPONSES = {
    0: {
        "text": "It sounds like you are experiencing knee discomfort. Ensure you avoid deep squatting or heavy impact activities until assessed. I recommend tracking your Pain Scale and considering a light cold compress to manage any local swelling.",
        "search_term": "physiotherapy exercises for knee pain"
    },
    1: {
        "text": "Your symptoms point toward neck or cervical muscle strain. Please check your posture during screen use, avoid turning your head sharply against tension, and try gentle stretching if safe.",
        "search_term": "physiotherapy exercises for neck pain relief"
    },
    2: {
        "text": "This pattern closely matches a lower back or lumbar muscle irritation. Try to avoid prolonged sitting or heavy bending. A short walk or changing positions frequently can help manage acute spasms.",
        "search_term": "physiotherapy exercises for lower back pain"
    }
}

@app.route('/')
def index():
    return render_template('index.html')

@app.route('/chat', methods=['POST'])
def chat_api():
    try:
        user_data = request.get_json()
        user_message = user_data.get('message', '').strip()
        
        if not user_message:
            return jsonify({'text': "I'm here to assist. Could you describe where you are feeling discomfort?"})
        
        msg_lower = user_message.lower()

        # --- GUARDRAIL 1: HANDLES THE CLOSING / THANK YOU PHRASE ---
        if "made sure you to do these" in msg_lower or "take medicaines" in msg_lower or "thanks" in msg_lower:
            return jsonify({'text': "You are very welcome! Remember to perform the movements slowly, never push through sharp pain, and rest when needed. Wishing you a swift and healthy recovery!"})

        # --- GUARDRAIL 2: KEYWORD DETECTION FOR MEDICATION QUESTION ---
        if "medication" in msg_lower or "medicine" in msg_lower or "pill" in msg_lower:
            return jsonify({'text': "As an AI Physiotherapist Assistant, I cannot prescribe specific pharmacological drugs or medications. For pain management, standard over-the-counter anti-inflammatories may help reduce acute swelling, but please consult a licensed pharmacist or physician to ensure safe usage."})

        # --- GUARDRAIL 3: KEYWORD DETECTION FOR YOUTUBE VIDEOS QUESTION ---
        if "youtube" in msg_lower or "video" in msg_lower or "watch" in msg_lower:
            # We look at the user's past interaction or force a fallback to check what body part they mean
            search_query = "physiotherapy home rehabilitation exercises"
            body_part = "your condition"
            
            if "knee" in msg_lower:
                search_query = RESPONSES[0]["search_term"]
                body_part = "Knee Recovery"
            elif "neck" in msg_lower:
                search_query = RESPONSES[1]["search_term"]
                body_part = "Neck Strain"
            elif "back" in msg_lower:
                search_query = RESPONSES[2]["search_term"]
                body_part = "Lower Back"
            
            # Generate a secure, safe URL-encoded link to YouTube search results
            encoded_query = urllib.parse.quote(search_query)
            youtube_url = f"https://www.youtube.com/results?search_query={encoded_query}"
            
            return jsonify({'text': f"To help you visualize the correct form, here is a collection of certified routines: <a href='{youtube_url}' target='_blank'>Watch {body_part} Exercise Videos on YouTube</a>. Please watch carefully and maintain a steady breathing rhythm."})

        # --- GUARDRAIL 4: GENERAL GREETING PHRASES ---
        greetings = ['hi', 'hello', 'hey', 'asalam', 'hy', 'hii', 'hi!']
        if any(msg_lower == g for g in greetings) or msg_lower.startswith(('hi ', 'hello ')):
            if len(msg_lower.split()) <= 2 and not any(body in msg_lower for body in ['knee', 'neck', 'back', 'pain', 'hurt']):
                return jsonify({'text': "Hello! I am your specialized AI Physiotherapist Assistant. Please describe your musculoskeletal symptoms regarding your knee, neck, or lower back so I can guide you safely."})

        # --- 5. RUN THE TRAINED ML PIPELINE CLASS PREDICTION ---
        probabilities = chatbot_pipeline.predict_proba([user_message])[0]
        max_confidence = np.max(probabilities)
        predicted_class = chatbot_pipeline.predict([user_message])[0]
        
        print(f"📊 Live Eval -> Text: '{user_message}' | Guess Class: {predicted_class} | Conf: {max_confidence:.4f}")

        # Out-of-bounds check if confidence is too low
        if max_confidence < 0.55:
            return jsonify({'text': "I noticed your concern might be outside my area of expertise. As an AI Physiotherapist Assistant, I am specialized in analyzing and advising on issues related to the **Knee**, **Neck**, or **Lower Back**."})
        
        # Return standard symptom matching text
        reply = RESPONSES.get(predicted_class, {"text": "Could you provide a bit more detail?"})["text"]
        return jsonify({'text': reply})
        
    except Exception as e:
        return jsonify({'text': f"An unexpected system exception occurred: {str(e)}"})

if __name__ == '__main__':
    app.run(debug=True)