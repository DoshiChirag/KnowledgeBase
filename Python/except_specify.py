
def specific_handler(x, y):
	z = None
	try:
		print('Calculating %s/%s' % (x, y))
		z = x / y
	except ZeroDivisionError as exception:
		print('Handled Zero Division->', str(exception))
		print('Handled Zero Division->', repr(exception))
	except TypeError as exception:
		print('Handled Type Error->', str(exception))
		print('Handler Type Error->', repr(exception))
	except BaseException as exception:
		print('Handled Base->', str(exception))
		print('Unexpected error->', repr(exception))
	else:
		print('No Exception occurred')
		return z
	finally:
		print('Finished either way')

if __name__ == '__main__':
	print('speicif_handler(5,2)->', specific_handler(5,2))
	print()
	print('speicif_handler(2,0)->', specific_handler(2,0))
	print()
	print('speicif_handler(2,"z")->', specific_handler(2,"z"))


