import warnings
import sys
sys.path.append("../")



warnings.filterwarnings("ignore")

from google.auth.transport.requests import Request
from google.oauth2.service_account import Credentials
from dotenv import load_dotenv
import os
import pickle


load_dotenv()

key_path = '../vertext-ai-course-2.json'

credentials = Credentials.from_service_account_file(
    key_path,
    scopes = ['https://www.googleapis.com/auth/cloud-platform']
    )

if credentials.expired:
    credentials.refresh(Request())

PROJECT_ID = "vertext-ai-course-493321"
REGION = 'us-central1'

import vertexai
vertexai.init(project=PROJECT_ID, location=REGION, credentials=credentials)

from vertexai.language_models import TextEmbeddingModel

# Initialize the model
model = TextEmbeddingModel.from_pretrained("gemini-embedding-001")

import time
import numpy as np
import faiss

from utils_project import *
import pandas as pd

so_database = pd.read_csv("./stackoverflow_data.csv")
print("Shape: "+ str(so_database.shape))
#print(so_database)

#==Load Questions embedding===
so_questions = so_database.input_text.tolist()
questions_embeddings = encode_text_to_embedding_batched(model = model, sentences = so_questions, api_calls_per_second=0.33, batch_size=5)   

with open("questions_embeddings_app.pkl", "wb") as file:
    pickle.dump(questions_embeddings, file)  



with open("questions_embeddings_app.pkl", "rb") as file:
    questions_embeddings = pickle.load(file)

so_database["embeddings"] = questions_embeddings.tolist()
#print(so_database)

#== Semantic Search==
import numpy as np
from sklearn.metrics.pairwise import cosine_similarity
from sklearn.metrics import pairwise_distances_argmin as distances_argmin

query = ["How to parse a simple JSON file in Python?"]
#query = ["How to concat dataframes in pandas?"]
query_embedding = model.get_embeddings(query)[0].values

cos_sim_array = cosine_similarity([query_embedding], list(so_database.embeddings.values))
#print(cos_sim_array)

index_doc_cosine = np.argmax(cos_sim_array)
index_doc_distances = distances_argmin([query_embedding], list(so_database.embeddings.values))

print("\n ---> *** Index of most similar question *** \n")

#print(so_database.input_text[index_doc_cosine])
#print(so_database.output_text[index_doc_cosine])

#== Question and answer with RAG ===
REGION = 'global'
vertexai.init(project=PROJECT_ID, location=REGION, credentials=credentials)
from vertexai.generative_models import  GenerativeModel
model_id = "gemma-4-26b-a4b-it-maas"
model_gpt = GenerativeModel(model_id)

context = (
    "Question: "
    + so_database.input_text[index_doc_cosine]
    + "\n Answer: "  
    + so_database.output_text[index_doc_cosine]
)

prompt = f"""Here is the context: {context}
             Using the relevant information from the context,
             provide an answer to the query: {query}."
             If the context doesn't provide \
             any relevant information, \
             answer with \
             [I couldn't find a good match in the \
             document database for your query] \
                 make sure to provide the code snippet if necessary.
             
             """

t_value = 0.2
response = model_gpt.generate_content(
    prompt,
    generation_config=vertexai.generative_models.GenerationConfig(
        temperature=t_value,
        max_output_tokens=1024
    )
)

print(response)

# ==== Scale with appropriate nearest neighbor search ====
# We will be using the HNSW algorithm for nearest neighbor search.
# through FAISS library 

questions_embeddings = np.array(list(so_database.embeddings.values)).astype("float32")


#Step1 - Create a Faiss index
embedding_dim = questions_embeddings.shape[1]
index = faiss.IndexFlatL2(embedding_dim)  # 32 is the number of neighbors in the HNSW graph
index.add(questions_embeddings)

#Step 2 - perform the search
query_embedding = model.get_embeddings(query)[0].values
#query embedding needs to be in the same format as the embeddings in the index
start = time.time()
#Find the nearest neighbour
D, I = index.search(np.array([query_embedding]),1)  # k is the number of nearest neighbors to retrieve
end = time.time()

#Display results from Faiss
for id, dist in zip(I[0], D[0]):
    print("\n ==>> *** Faiss Results: *** \n")
    print(f"[docid:{id}] [{dist}] -- {so_database.input_text[int(id)][:125]}...")

print("\n ==>>> Faiss Latency (ms):", 1000 * (end - start))


# Step 3: Perform Cosine Similarity for Comparison
start = time.time()
cos_sim_array = cosine_similarity([query_embedding], questions_embeddings)
index_doc = np.argmax(cos_sim_array)
end = time.time()


# Display results from Cosine Similarity
print(
    f"\n ==>> [docid:{index_doc}] [{np.max(cos_sim_array)}] -- {so_database.input_text[int(index_doc)][:125]}..."
)
print(" \n ==> Cosine Similarity Latency (ms):", 1000 * (end - start))




