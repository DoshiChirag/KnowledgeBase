from flask import Flask, jsonify
import requests

app = Flask(__name__)

@app.route('/crypto-prices', methods=['GET'])
def get_crypto_prices():
    url = 'https://api.coingecko.com/api/v3/coins/markets'
    params = {
        'vs_currency': 'usd',
        'order': 'market_cap_desc',
        'per_page': 100,
        'page': 1,
        'sparkline': 'false'
    }
    response = requests.get(url, params=params)
    if response.status_code == 200:
        data = response.json()
        prices = [
            {'ticker': coin['symbol'], 'price': coin['current_price']}
            for coin in data
        ]
        csv_output = "ticker,price\n"
        for item in prices:
            csv_output += f"{item['ticker']},{item['price']}\n"
        file_path = "crypto_prices.csv"
        with open(file_path, 'w') as f:
            f.write(csv_output)
        return jsonify({"message": "CSV saved to crypto_prices.csv"})
    else:
        return jsonify({'error': 'Failed to fetch cryptocurrency prices'}), 500

if __name__ == '__main__':
    app.run(debug=True)