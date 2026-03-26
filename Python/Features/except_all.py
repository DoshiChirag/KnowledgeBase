def all_far(x, y):
	z = x / y
	return z

def all_close(x, y):
	try:
		print('Calculating %s/%s' % (x, y))
		z = x / y
	except BaseException as exception:
		print('Unexpected errorr->', str(exception))
		print('Unexpected errorr->', repr(exception))
	else:
		print('No Eception occurred')
		return z
	finally:
		print('Finished all_close either way')

if __name__ == '__main__':
	print('all_close(5,2)->', all_close(5,2))
	print()
	print('all_close(2,0)->', all_close(2,0))
	print()

	print('all_far(5,2):')
	z = None
	try:
		z = all_far(5,2)
	except:
		print('Unexpected error!')
	else:
		print('No error!')
	finally:
		print('Finished block')
	print('all_far(5,2 returned',z)


	
	



