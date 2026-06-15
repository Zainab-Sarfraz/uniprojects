# Cell 2: Custom Modular Data Script File
import numpy as np
import pandas as pd
import os

def create_mock_csv():
    """Generates a random dataset mimicking real clinic complaints and metrics."""
    np.random.seed(42)
    num_records = 200
    
    complaints = [
        "My knee hurts when I try to squat down", "Sharp pain in my knee joint after running",
        "Stiff knee caps and swelling", "I twisted my knee playing sports",
        "My neck is completely locked up and stiff", "Sore neck muscles from sleeping wrong",
        "Sharp shooting pain down my neck area", "I can't turn my head left because of neck tension",
        "Lower back ache from sitting too long", "Sharp muscle spasm in my lower back",
        "Stiff back spine when standing up", "Dull throbbing lower back irritation"
    ]
    
    labels = [0, 0, 0, 0, 1, 1, 1, 1, 2, 2, 2, 2] # 0: Knee, 1: Neck, 2: Back
    
    # Generate random features using NumPy broadcasting and random scaling
    chosen_indices = np.random.randint(0, len(complaints), size=num_records)
    
    # Feature engineering simulation using array broadcasting
    pain_intensity = np.random.uniform(2.0, 10.0, size=num_records)
    mobility_restriction = pain_intensity * 0.85 + np.random.normal(0, 1, size=num_records)
    
    data = {
        'Complaint': [complaints[i] for i in chosen_indices],
        'Pain_Scale': np.round(pain_intensity, 1),
        'Mobility_Loss': np.round(mobility_restriction, 1),
        'Target_Label': [labels[i] for i in chosen_indices]
    }
    
    df = pd.DataFrame(data)
    
    # Introduce some artificial missing values to demonstrate data cleaning routines
    df.loc[np.random.choice(df.index, size=10), 'Pain_Scale'] = np.nan
    
    df.to_csv('dataset.csv', index=False)
    print("📂 Synthetic CSV Dataset generated successfully as 'dataset.csv'!")

def process_and_clean_data():
    """Loads, cleans, preprocesses, filters, and prepares datasets for modeling."""
    try:
        if not os.path.exists('dataset.csv'):
            create_mock_csv()
            
        df = pd.read_csv('dataset.csv')
        
        # Data Cleaning: Handle missing values by replacing them with the column mean
        if df['Pain_Scale'].isnull().sum() > 0:
            df['Pain_Scale'] = df['Pain_Scale'].fillna(df['Pain_Scale'].mean())
            
        # Data Preprocessing: Filtering outliers out using boolean masking
        df = df[df['Pain_Scale'] <= 10.0]
        
        return df
    except FileNotFoundError as e:
        print(f"❌ Critical File Error: {e}")
    except Exception as e:
        print(f"⚠️ Unexpected Data Exception: {e}")

def append_to_clinical_logs(text_report):
    """Demonstrates reading and writing standard text files safely with exceptions."""
    try:
        with open("clinical_logs.txt", "a") as f:
            f.write(text_report + "\n")
    except IOError as e:
        print(f"❌ Disk I/O Log Failure: {e}")
