from pymongo import MongoClient
from pymongo.errors import ConnectionFailure

connectionString = "mongodb://localhost:27017/"
dbName = "myDatabase"

mongoClient = MongoClient(connectionString)

try:
    mongoClient.admin.command("ping")
    print("Connected to MongoDB successfully.")

    myDb = mongoClient[dbName]
    collectionNames = myDb.list_collection_names()
    print(f"Collections in '{dbName}': {collectionNames}")

except ConnectionFailure as e:
    print(f"Could not connect to MongoDB: {e}")

finally:
    mongoClient.close()
    print("MongoDB connection closed.")
