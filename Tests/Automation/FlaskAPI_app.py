from flask import Flask, request, jsonify
app = Flask(__name__)
@app.route('/test', methods=['GET', 'POST'])
def test():
    if request.method == 'GET':
        return jsonify({"response": "Received Get request"})
    elif request.method == 'POST':
        data = request.get_json()
        name = data['LastName'] + " " + data['FirstName']
        return jsonify({"response": "Hello, " + name + "!"})

if __name__ == '__main__':
    app.run(debug=True, port=9090)
