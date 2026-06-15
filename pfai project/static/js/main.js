document.addEventListener('DOMContentLoaded', () => {
    const chatWindow = document.getElementById('chat-window');
    const userInput = document.getElementById('user-input');
    const sendBtn = document.getElementById('send-btn');
    const micBtn = document.getElementById('mic-btn');
    const voiceToggleBtn = document.getElementById('voice-toggle-btn');

    let voiceOutputEnabled = true; // AI talks back by default

    // Toggle Voice Output
    voiceToggleBtn.addEventListener('click', () => {
        voiceOutputEnabled = !voiceOutputEnabled;
        if (voiceOutputEnabled) {
            voiceToggleBtn.classList.remove('muted');
            voiceToggleBtn.innerHTML = '<i class="fas fa-volume-up"></i>';
        } else {
            voiceToggleBtn.classList.add('muted');
            voiceToggleBtn.innerHTML = '<i class="fas fa-volume-mute"></i>';
            window.speechSynthesis.cancel(); // Stop talking if muted
        }
    });

    // --- TYPEWRITER EFFECT ---
    function typeWriter(text, elementId, speed = 40) {
        let i = 0;
        const element = document.getElementById(elementId);
        element.innerHTML = ''; // Start empty
        
        function type() {
            if (i < text.length) {
                element.innerHTML += text.charAt(i);
                i++;
                chatWindow.scrollTop = chatWindow.scrollHeight; // Keep scrolling down automatically
                setTimeout(type, speed); 
            }
        }
        type();
    }

    // --- SYNCED TEXT TO SPEECH & TYPING ---
    function speakAndType(text, elementId) {
        // If muted or browser doesn't support speech, just type it immediately
        if (!voiceOutputEnabled || !('speechSynthesis' in window)) {
            typeWriter(text, elementId, 45);
            return;
        }
        
        // Strip out HTML tags for the screen reader
        const cleanText = text.replace(/<[^>]*>?/gm, ''); 
        
        const utterance = new SpeechSynthesisUtterance(cleanText);
        utterance.rate = 1.0; 
        utterance.pitch = 1.0;
        
        const voices = window.speechSynthesis.getVoices();
        const preferredVoice = voices.find(voice => voice.name.includes('Female') || voice.name.includes('Google UK'));
        if (preferredVoice) utterance.voice = preferredVoice;

        // THE FIX: Wait until the exact millisecond the audio actually starts before typing
        utterance.onstart = () => {
            typeWriter(text, elementId, 45);
        };

        // Safety fallback: if audio fails to play, still show the text
        utterance.onerror = () => {
            typeWriter(text, elementId, 45);
        };

        window.speechSynthesis.speak(utterance);
    }

    // --- SPEECH TO TEXT (USER MICROPHONE) ---
    const SpeechRecognition = window.SpeechRecognition || window.webkitSpeechRecognition;
    let recognition;

    if (SpeechRecognition) {
        recognition = new SpeechRecognition();
        recognition.continuous = true; 
        recognition.interimResults = true; 
        recognition.lang = 'en-US';

        let finalTranscript = '';

        recognition.onstart = () => {
            micBtn.classList.add('recording');
            userInput.placeholder = "Listening... (Click mic again to send)";
            finalTranscript = '';
            userInput.value = '';
        };

        recognition.onresult = (event) => {
            let interimTranscript = '';
            for (let i = event.resultIndex; i < event.results.length; ++i) {
                if (event.results[i].isFinal) {
                    finalTranscript += event.results[i][0].transcript;
                } else {
                    interimTranscript += event.results[i][0].transcript;
                }
            }
            userInput.value = finalTranscript + interimTranscript;
        };

        recognition.onerror = (event) => {
            console.error("Speech Recognition Error:", event.error);
        };

        recognition.onend = () => {
            micBtn.classList.remove('recording');
            userInput.placeholder = "Describe your symptoms...";
            
            if (userInput.value.trim() !== '') {
                sendMessage();
            }
        };

        micBtn.addEventListener('click', () => {
            if (micBtn.classList.contains('recording')) {
                recognition.stop(); 
            } else {
                recognition.start(); 
            }
        });
    } else {
        micBtn.style.display = 'none'; 
        console.warn("Speech Recognition API not supported in this browser.");
    }

    // --- CHAT LOGIC ---
    async function sendMessage() {
        const text = userInput.value.trim();
        if (!text) return;

        // 1. Show User Message
        const userMsgDiv = document.createElement('div');
        userMsgDiv.classList.add('message', 'user-msg');
        userMsgDiv.textContent = text;
        chatWindow.appendChild(userMsgDiv);
        userInput.value = '';
        chatWindow.scrollTop = chatWindow.scrollHeight;
        
        // 2. Show "Thinking..."
        const typingId = "typing-" + Date.now();
        const typingDiv = document.createElement('div');
        typingDiv.id = typingId;
        typingDiv.classList.add('message', 'system-msg');
        typingDiv.textContent = "Thinking...";
        chatWindow.appendChild(typingDiv);
        chatWindow.scrollTop = chatWindow.scrollHeight;

        try {
            const response = await fetch('/chat', {
                method: 'POST',
                headers: { 'Content-Type': 'application/json' },
                body: JSON.stringify({ message: text })
            });
            const data = await response.json(); 
            
            // 3. Remove "Thinking..." indicator
            const thinkElement = document.getElementById(typingId);
            if (thinkElement) thinkElement.remove();
            
            // 4. Create an empty chat bubble
            const msgId = "msg-" + Date.now();
            const sysMsgDiv = document.createElement('div');
            sysMsgDiv.id = msgId;
            sysMsgDiv.classList.add('message', 'system-msg');
            chatWindow.appendChild(sysMsgDiv);

            // 5. Speak and Type perfectly in sync!
            speakAndType(data.text, msgId);

        } catch (error) {
            const thinkElement = document.getElementById(typingId);
            if (thinkElement) thinkElement.remove();
            
            const errorDiv = document.createElement('div');
            errorDiv.classList.add('message', 'system-msg');
            errorDiv.textContent = "Connection error. Cannot reach the server.";
            chatWindow.appendChild(errorDiv);
            chatWindow.scrollTop = chatWindow.scrollHeight;
        }
    }

    sendBtn.addEventListener('click', sendMessage);
    userInput.addEventListener('keypress', (e) => {
        if (e.key === 'Enter') sendMessage();
    });
});