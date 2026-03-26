def abc_generator():
	yield 'a'
	yield 'b'
	yield 'c'


for char in abc_generator():
	print(char)

def num_generator(num=1):
	while num:
		yield num
		num += 1

for num in num_generator():
	print(num)
	if num == 5:
		break


def doubles(stop=10):
	return (2 * n for n in range(stop))

d_gen = doubles(5)
print('d_gen type', type(d_gen))
print('first d_gen ', next(d_gen))
print('second d_gen ', d_gen.__next__())

triples = (3 * n for n in range(10))

t_gen = triples
print('t_gen type', type(t_gen))
print('first t_gen ', next(t_gen))
print('second t_gen ', t_gen.__next__())


