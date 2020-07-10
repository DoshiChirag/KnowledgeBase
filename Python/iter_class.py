
class ByTen():

	def _validate(self):
		error_type = 'The start and stop parameters must be integers'
		error_value = 'Unable to iterate if start is greater than or equal to stop parameter'
		if not(isinstance(self.start,int) and isinstance(self.stop, int)):
			raise TypeError(error_type)
		if self.start >= self.stop:
			raise ValueError(error_value)

	def __init__(self, start=0, stop = 100):
		self.start = start
		self.stop = stop
		self._validate()
		self.current = start

	def __iter__(self):
		return self

	def __next__(self):
		if self.current >= self.stop:
			raise StopIteration
		else:
			next_value = self.current
			self.current += 10
			return next_value

if __name__ == '__main__':
	by_ten = ByTen()
	for value in by_ten:
		print('current by_ten value:', value)


	by_ten = ByTen(1000, 1030)
	for value in by_ten:
		print('current by_ten value:', value)

	try:
		by_ten = ByTen(10, 10)		
	except ValueError as err:
		print('Handled value error:', err)


	try:
		by_ten = ByTen('a', 'z')		
	except TypeError as err:
		print('Handled value error:', err)




	

