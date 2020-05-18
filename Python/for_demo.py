for elem in range(5):
	print(elem, end=' ')
print()

for elem in range(1, 6):
	print(elem, end=' ')
print()

for elem in range(5, -1, -1):
	print('Countdown:' ,elem)
print()

for char in 'string':
	print(char, end= ' ')
print()

for tup in (1, 3, 5):
	print(tup)

for val in ['hey', 'hi', 'whoa']:
	print(val)

greek = {'alpha': 1, 'beta': 2, 'gamma' : 3}
for key in greek:
	if key == 'beta':
		continue
	print(key, greek[key])

for outer in range(2,10):
	for inner in range (2, outer):
		if not outer % inner:
			print(outer, '=', inner, '*', int(outer/inner))
			break
	else:
		print(outer , ' is prime')

