def assign_category(age, income, membership_years, purchase_history):
    """
    Assigns a category based on age, income, membership years, and purchase history.

    Parameters:
        age (int): The age of the individual.
        income (float): The income of the individual.
        membership_years (int): Number of years the individual has been a member.
        purchase_history (list): A list of purchase amounts.

    Returns:
        str: The assigned category.
    """
    # Calculate metrics once for efficiency
    total_purchases = sum(purchase_history)
    purchase_count = len(purchase_history)
    recent_purchases = sum(purchase_history[-5:]) if purchase_count >= 5 else 0
    
    # Young customers (under 25)
    if age < 25:
        if income > 50000 and membership_years > 2:
            return "VIP"
        elif total_purchases > 1000:
            return "Preferred"
        else:
            return "Entry"
    
    # Mid-career customers (25-40)
    elif age <= 40:
        if income > 75000 or membership_years > 5:
            return "VIP"
        elif purchase_count > 10 and recent_purchases > 2000:
            return "Loyal"
        else:
            return "Standard"
    
    # Mature customers (40+)
    else:
        if income > 100000 and membership_years > 10:
            return "Elite"
        elif total_purchases > 5000:
            return "Premium"
        else:
            return "Basic"

# Example usage
details = {
    "age": 30,
    "income": 80000,
    "membership_years": 6,
    "purchase_history": [200, 300, 150, 400, 500, 600, 700, 800, 900, 1000]
}

category = assign_category(**details)
print(f"Assigned Category: {category}")