def link3():
	print('link3 in the chain')
	raise RuntimeError('link3 problem')

def link2():
	print('link2 in the chain')
	try:
		link3()
	except RuntimeError as exception:
		raise RuntimeError('link2 problem') from exception


def link1():
	print('link1 in the chain')
	try:
		link2()
	except RuntimeError as exception:
		raise RuntimeError('link1 problem')

link1()


