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

embedding = embedding_model.get_embeddings(["Hello!"])

#print(embedding)

vector = embedding[0].values

print(f"Vector length: {len(vector)}")
