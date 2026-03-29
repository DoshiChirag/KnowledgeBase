from flask import Flask, jsonify
import requests

app = Flask(__name__)

MOCK_GOLD_API = "https://example.com/mock-gold-price"  # Replace with your mock endpoint

@app.get("/gold")
def get_gold_price():
    try:
        response = requests.get(MOCK_GOLD_API, timeout=5)
        response.raise_for_status()
        data = response.json()

        # Expecting: { "price": 1234.56 }
        gold_price = data.get("price")

        return jsonify({
            "gold_price_usd": gold_price,
            "source": "mock-api"
        })

    except Exception as e:
        return jsonify({
            "error": "Failed to fetch gold price",
            "details": str(e)
        }), 500
    


{
  "prices": [
    {"date": "2026-03-09", "price": 1922.55},
    {"date": "2026-03-10", "price": 1930.12},
    ...
  ]
}
MOCK_GOLD_API = "https://example.com/mock-gold-history"  # Replace with your mock endpoint

@app.get("/gold/history")
def get_gold_history():
    try:
        response = requests.get(MOCK_GOLD_API, timeout=5)
        response.raise_for_status()
        data = response.json()

        # Expecting: { "prices": [ { "date": "...", "price": ... }, ... ] }
        prices = data.get("prices", [])

        # Ensure only last 20 days are returned (in case API returns more)
        last_20 = prices[-20:]

        return jsonify({
            "days": len(last_20),
            "gold_price_history": last_20,
            "source": "mock-api"
        })

    except Exception as e:
        return jsonify({
            "error": "Failed to fetch gold price history",
            "details": str(e)
        }), 500


if __name__ == "__main__":
    app.run(port=5001)