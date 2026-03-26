class Calc():
	def __init__(self, value):
		if not isinstance(value,int):
			raise ValueError("Must be instantiated with an integer value")	
		self.value = value

	def __str__(self):
		return str(self.value)

	def __repr__(self):
		return str(self.value)

	def __add__(self, other):
		return self.value + other.value

	def __iadd__(self, value):
		return self.value + value

first = Calc(5)
print(str(first))
print('Repr = ', repr(first))
print('__add__ = ', first + first)
first += 1
print('__iadd__ = ', first)
attrs = dir(first)
for attr in attrs:
	if attr.startswith('__') and attr.endswith('__'):
		print(attr,end=' ')


	