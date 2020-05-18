import random
faces = ('heads','tails')

def subproc():
	print('I do something')
	print('But return nothing')

subproc()
print(subproc())

def funcproc():
	return random.choice(faces)

for flipcoin in range(5):
	print(funcproc(), end = ' ')
print()

def iadd(arg1, arg2):
	'''Perform inline + operations'''
	return arg1 + arg2

print('iadd(3,5) ->', iadd(3,5))
print('iadd("dy", "namic") ->', iadd("dy","namic"))

def isum(*args):
	'''Return a total of numeric args'''
	print('args ->', args)
	total = 0
	for arg in args:
		total += arg
	return total

print('isum(1,2,3,4,5) ->', isum(1,2,3,4,5))
params = (5,4,3,2,1)
print('isum(*params) ->', isum(*params))

def ilist(alpha, beta='default', gamma='assumed'):
	return alpha, beta, gamma

print("ilist('required') ->", ilist('required'))
print("ilist('pos1', 'pos2', 'pos3') ->", ilist('pos1', 'pos2', 'pos3'))
print("ilist(gamma = 'pos1', alpha = 'pos2', beta = 'pos3') ->", ilist(gamma = 'pos1', alpha = 'pos2', beta = 'pos3'))

alphabet = {'alpha':'a', 'beta' :'b', 'gamma':'g'}
print('ilist(**alphabet) ->',  ilist(**alphabet))

def iflex(**kwargs):
	print('kwargs ->', kwargs)
	for key in kwargs:
		print(key, '->', kwargs[key])
	return tuple(kwargs.values())

alphabet = {}
print('iflex(**alphabet) ->', iflex(**alphabet))
alphabet ={'delta':'d', 'sigma':'E', 'pi':'p'}
print('iflex(**alphabet) ->', iflex(**alphabet))



	