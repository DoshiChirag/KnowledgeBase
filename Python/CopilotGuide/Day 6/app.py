import re

from flask import Flask, render_template, request

app = Flask(__name__)


def evaluate_expression(expression: str):
    """Evaluate a simple expression like 12.5+3 or 9/4."""
    normalized = expression.replace(" ", "")
    pattern = r"^(-?\d+(?:\.\d+)?)([+\-*/])(-?\d+(?:\.\d+)?)$"
    match = re.match(pattern, normalized)

    if not match:
        return None, "Enter an expression like 12+5"

    left, operator, right = match.groups()
    num1 = float(left)
    num2 = float(right)

    if operator == "+":
        return num1 + num2, None
    if operator == "-":
        return num1 - num2, None
    if operator == "*":
        return num1 * num2, None
    if operator == "/":
        if num2 == 0:
            return None, "Error: Division by zero"
        return num1 / num2, None

    return None, "Invalid operation"

@app.route('/')
def calculator():
    return render_template('calculator.html')


@app.route('/calculate', methods=['POST'])
def calculate():
    expression = request.form.get('expression', '')
    result, error = evaluate_expression(expression)
    return render_template('calculator.html', expression=expression, result=result, error=error)

if __name__ == '__main__':
    app.run(debug=True)