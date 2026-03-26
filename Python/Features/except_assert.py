from math import floor
import py_compile

assert 1 == 1.0 , 'float 1 must be equal to 1.0'

def round_down(num):
	return floor(num)

assert 6 == round_down(6.999), 'round down should alwas round a float down'

try:
	assert -5 == round_down(-5.999), 'round down should alwas round a float down'
except AssertionError as exception:
	print('Handled AssertionError:', exception)

try:
	if __debug__:
		if -5 != round_down(-5.999):
			raise AssertionError('round_down should always round a float down')
except AssertionError as exception:
	print('Handled AssertionError:', exception)

print('Assertions are evaluated if __debug__ is True')
print('The value of __debug__ is:', __debug__)
print('Modules executed normally have debug set to True')
print('Modules executed with "python -O" have debug set to False')

if __name__ == '__main__':
	if __file__.endswith('py'):
		try:
			py_compile.compile(__file__, __file__ + 'c')
			py_compile.compile(__file__, __file__ + 'o', optimize=1)
		except Exception as exception:
			print(repr(exception))



		