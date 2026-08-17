from google.auth.transport.requests import Request
from google.oauth2.service_account import Credentials

key_path = './vertext-ai-course-2.json'

credentials = Credentials.from_service_account_file(
    key_path,
    scopes = ['https://www.googleapis.com/auth/cloud-platform']
    )

if credentials.expired:
    credentials.refresh(Request())

print('Access token:', credentials.token)

PROJECT_ID = "vertext-ai-course-493321"
REGION = "us-central1"

import vertexai
vertexai.init(project=PROJECT_ID, location=REGION, credentials=credentials)

from vertexai.language_models import TextEmbeddingModel

embedding_model = TextEmbeddingModel.from_pretrained("gemini-embedding-001")

# == Visualize the embeddings in a 2D space ==

input_1 = "Japan High GDP withone of the oldest populations, challenges in main"
input_2 = "Germany Strong economy with an aging population, balancing innovation and tradition"
input_3 = "Italy Economic struggles in recent years,aging population adds pressure on social services"
input_4 = "South Korea Rapid economic growth, facing challenges due to low birth rates and aging population" 
input_5 = "Spain Moderate GDP with significant portion of population over 65, healthcare and pension systems under strain"
input_6 = (
    "Canada High standard of living, facing a future with a growing elderly demographics"
)
input_7 = "France Stable economy, dealing with pension reforms as population ages"

import numpy as np

text_list = [input_1, input_2, input_3, input_4, input_5, input_6, input_7]

embeddings = []

for input_text in text_list:
    emb_aux = embedding_model.get_embeddings([input_text])[0].values
    embeddings.append(emb_aux)
embeddings_array = np.array(embeddings)
print("Shape: "+ str(embeddings_array.shape))

from sklearn.decomposition import PCA  

PCA_model = PCA(n_components=2)
PCA_model.fit(embeddings_array)

new_embeddings = PCA_model.transform(embeddings_array)  
print("Shape: "+ str(new_embeddings.shape))
print(new_embeddings)

import utils_project
utils_project.plot_2D(new_embeddings[:,0], new_embeddings[:,1], text_list)