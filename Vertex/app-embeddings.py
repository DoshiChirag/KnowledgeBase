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

#embedding = embedding_model.get_embeddings(["Hello!"])
#print(embedding)

# ===compare the embeddings of different sentences
# -install scikit-learn
from sklearn.metrics.pairwise import  cosine_similarity

embedding_alpha = embedding_model.get_embeddings(["How do airplanes stay in the sky?"])

embedding_beta = embedding_model.get_embeddings(["What's the secret to make perfect coffee?"])

embedding_gamma = embedding_model.get_embeddings(["Can you recommend a good book?"])

vector_alpha = embedding_alpha[0].values
vector_beta = embedding_beta[0].values  
vector_gamma = embedding_gamma[0].values   

print(cosine_similarity([vector_alpha], [vector_beta]))
print(cosine_similarity([vector_beta], [vector_gamma]))
print(cosine_similarity([vector_alpha], [vector_gamma]))
