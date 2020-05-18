class Grades():
	def __init__(self, score = 0):
		self._score = score

	@property
	def score(self):
		return self._score

	@score.setter
	def score(self, value):
		if value > 100 or value < 0:
			raise ValueError('Invalid score')
		self._score = value


math = Grades(90)
print('The math score was %s.' % math.score)
try:
	math.score = 101
except ValueError:
	print('The score is not allowed')

class Grader(Grades):
	@property
	def score(self):
		return self._score

	@score.setter
	def score(self, value):
		if value > 200 or value < 0:
			raise ValueError('Invalid score')
		self._score = value

g = Grader(99)
print('The math score was %s.' % g.score)
g.score = 199
print('The math score was %s.' % g.score)

class ReadOnly():
	def __init__(self):
		self._constant = 24

	@property
	def constant(self):
		return self._constant

only_read = ReadOnly()
print('The constant has the value %s.' % only_read.constant)
try:
	only_read.constant = 25
except AttributeError:
	print('Properties cannot be changed without a setter')

class ReadWrite(ReadOnly):
	@property
	def constant(self):
		return self._constant

	@constant.setter
	def constant(self,value):
		self._constant = value

rw = ReadWrite()
print(rw.constant)
rw.constant = 33
print(rw.constant)
	
	


	

	