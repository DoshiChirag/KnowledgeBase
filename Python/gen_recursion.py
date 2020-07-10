def fib_func(n):
	if n < 2:
		return n
	return fib_func(n-2) + fib_func(n-1)

func_list = [fib_func(n) for n in range(10)]
print('Fib sequence', func_list)
func_gen = (fib_func(n) for n in range(10))
print('Fib sequence gen', func_gen)
for n in range(10):
	print(next(func_gen))

def fib_gen(n):

	element = 0
	f1, f2 = 0, 1
	while element < n:
		yield f1
		f1, f2 = f2, f1 + f2
		element += 1

gen_fib =fib_gen(10)
print('The genfib values', gen_fib)
for n in range(10):
	print(next(gen_fib))


def fib_inf():

	f1, f2 = 0, 1
	while True:
		yield f1
		f1, f2 = f2, f1 + f2


inf_fib = fib_inf()
print('The gen inf values', inf_fib)
for n in range(10):
	print(next(inf_fib))




	