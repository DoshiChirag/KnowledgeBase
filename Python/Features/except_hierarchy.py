from math import exp

def class_hierarchy(class_,space = 0):
	print(space * ' ', class_.__name__)
	if not class_ is type:
		for subclass in class_.__subclasses__():
			class_hierarchy(subclass, space  + 4)


def math_hierarchy(class_ = ArithmeticError, space = 8):
	print(space * ' ', class_.__name__)
	if not class_ is type:
		for subclass in class_.__subclasses__():
			class_hierarchy(subclass, space  + 4)

def overflow_most_specific():
	try:
		z = exp(100000000)
	except OverflowError as exception:
		print(repr(exception))
	else:
		print('No Exception')
	finally:
		print('Finally')

def overflow_med_specific():
	try:
		z = exp(100000000)
	except ArithmeticError as exception:
		print('Handling Arithmetic Error->', repr(exception))
	else:
		print('No Exception')
	finally:
		print('Finally')

def overflow_least_specific():
	try:
		z = exp(100000000)
	except BaseException as exception:
		print('Handling Base Error->', repr(exception))
	else:
		print('No Exception')
	finally:
		print('Finally')


if __name__ == '__main__':
	class_hierarchy(BaseException)
	print()
	math_hierarchy()
	print()
	overflow_most_specific()
	print()
	overflow_med_specific()
	print
	overflow_least_specific()
	print()
	
	