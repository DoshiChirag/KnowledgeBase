import warnings
import sys

sys.path.append("../")

#from utils_project import plot_2D

warnings.filterwarnings("ignore")

from google.auth.transport.requests import Request
from google.oauth2.service_account import Credentials
from dotenv import load_dotenv
import os

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
text_generation_model = TextEmbeddingModel.from_pretrained("gemini-embedding-001")

# load the BQ Table into a Pandas DataFrame
from google.cloud import bigquery
import pandas as pd
def run_bq_query(query):
    bq_client = bigquery.Client(credentials=credentials, project=PROJECT_ID)
    job_config = bigquery.QueryJobConfig(dry_run=True, use_query_cache=False)
    query_job = bq_client.query(query, job_config=job_config)

    job_config = bigquery.QueryJobConfig()
    client_result = bq_client.query(query, job_config=job_config)

    job_id = client_result.job_id    
    results = client_result.result().to_arrow().to_pandas()
    print(f"Finsihed running query with job ID: {job_id}")
    return results

LIMIT = 500
language_list = ["Python",  "Java", "dart"] 

so_df = pd.DataFrame()

for language in language_list:
    print(f"generating {language} dataframe")

    query_raw = f"""
    SELECT 
        CONCAT(q.title, q.body) AS input_text,
        a.body AS output_text
    FROM 
        `bigquery-public-data.stackoverflow.posts_questions` q
    JOIN
        `bigquery-public-data.stackoverflow.posts_answers` a
    ON
        q.accepted_answer_id = a.id
    WHERE
        q.accepted_answer_id IS NOT NULL AND
        REGEXP_CONTAINS(q.tags, r'{language}') AND
        a.creation_date >= "2020-01-01"
    LIMIT
        {LIMIT}
    """

    query = query_raw.format(limit=LIMIT)
    language_df = run_bq_query(query)
    language_df['category'] = language
    so_df = pd.concat([so_df, language_df], ignore_index=True)

#so_df.to_csv("stackoverflow_data.csv", index=False)
#print("All the data has been saved to stackoverflow_data.csv")

#print(so_df.head())

# == Next Generate Embeddings for the data ==
import time
import numpy as np

from utils_project import *

#open the saved data

print("\n --> Generating embeddings for a batch of data from stackoverflow_data.csv")
so_df = pd.read_csv("stackoverflow_data.csv")
so_questions = so_df[0:200].input_text.tolist()
batches = batch_generator(so_questions)
batch = next(batches)
print(f"\n\n ==> Batch of sentences: {len(batch)} \n\n")


batch_embeddings = encode_texts_to_embeddings(text_generation_model, batch)

print(f"\n ==> Embeddings for the batch of sentences: {len(batch_embeddings)}  embeddings of size  \
      {len(batch_embeddings[0]) if batch_embeddings else 0} \n\n")

print(f"\n ==> *** Generating embeddings for the entire dataset *** \n\n")
so_questions = so_df.input_text.tolist()
question_embeddings = encode_text_to_embedding_batched(model = text_generation_model,sentences = so_questions, api_calls_per_second=20/60, batch_size=5)

print ("\n *** Shape of Question Embeddings: *** \n ",str(question_embeddings.shape), "\n")
# print(question_embeddings)

# == Cluster the embeddings of the Stack Overflow questions ==
from sklearn.cluster import KMeans
from sklearn.decomposition import PCA

clustering_dataset = question_embeddings[:100]  # change to 100

print("\n --> *** Cluster the Embeddings of the SO Questions *** \n")
n_clusters = 2
kmeans = KMeans(n_clusters=n_clusters, random_state=0, n_init="auto").fit(
    clustering_dataset
)

kmeans_labels = kmeans.labels_

PCA_model = PCA(n_components=2)
PCA_model.fit(clustering_dataset)
new_values = PCA_model.transform(clustering_dataset)


print("\n --> *** Generating Clusters *** \n")
clusters_2D(
    x_values=new_values[:, 0],
    y_values=new_values[:, 1],
    labels=so_df[:1000],
    kmeans_labels=kmeans_labels,
)










