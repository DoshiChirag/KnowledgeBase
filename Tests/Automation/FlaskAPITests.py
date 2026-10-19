import subprocess
import requests

#Generate the file collection.json once by uncommenting this block
#api_key = "PostMan Account API Key"
#collection_id = "Postman Collection ID"

#response = requests.get(
#    f"https://api.getpostman.com/collections/{collection_id}",
#    headers={"X-Api-Key": api_key}
#)


#with open("collection.json", "w") as f:
#    data = (response.json()["collection"])
#    print(str(data))
#    f.write(str(data).replace("'", "\""))  # Convert single quotes to double quotes for valid JSON


subprocess.run(["C:\\Users\\UserID\\AppData\\Roaming\\npm\\newman.cmd", "run", "collection.json"])
