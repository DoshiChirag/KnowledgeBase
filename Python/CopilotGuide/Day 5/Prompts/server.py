from flask import Flask, request, jsonify
import logging

app = Flask(__name__)

# -------------------------
# Logging Configuration
# -------------------------
logging.basicConfig(
    level=logging.INFO,
    format="%(asctime)s [%(levelname)s] %(message)s"
)

# -------------------------
# Simple Bearer Token Auth
# -------------------------
VALID_TOKEN = "my-secret-token"

def require_auth():
    auth_header = request.headers.get("Authorization", "")
    if not auth_header.startswith("Bearer "):
        return False
    token = auth_header.split("Bearer ")[1]
    return token == VALID_TOKEN

# -------------------------
# Routes
# -------------------------

@app.route("/hello", methods=["GET"])
def hello_world():
    app.logger.info("GET /hello called")
    return jsonify({"message": "Hello World"}), 200


@app.route("/submit", methods=["POST"])
def submit_data():
    app.logger.info("POST /submit called")

    if not require_auth():
        app.logger.warning("Unauthorized access attempt")
        return jsonify({"error": "Unauthorized"}), 401

    data = request.json
    app.logger.info(f"Received data: {data}")

    return jsonify({"status": "success", "received": data}), 200


# -------------------------
# Run Server
# -------------------------
if __name__ == "__main__":
    app.run(host="0.0.0.0", port=5000)