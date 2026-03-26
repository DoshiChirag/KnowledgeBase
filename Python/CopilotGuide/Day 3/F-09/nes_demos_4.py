class Product:
  """Represents a product with an ID and name."""
  def __init__(self, product_id, name, price, category):
    self.product_id = product_id
    self.name = name
    self.price = price
    self.category = category

# --- Usage Example ---
item1 = Product("A100", "Laptop", 999.99, "Electronics") # Instantiation 1
item2 = Product("B250", "Keyboard", 49.99, "Electronics") # Instantiation 2
item3 = Product("C250", "Burger", 9.99, "Food") # Instantiation 3