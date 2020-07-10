from random import randint
from pprint import PrettyPrinter

keys = range(1, 5)
values = range(10, 41, 10)
print('keys:',[key for key in keys])
print('values:',[value for value in values])
tuple_list = zip(keys, values)
print('List of tuples:', [pair for pair in tuple_list])

zip_keys, zip_values = zip(*zip(keys, values))
print('keys from zip:',[key for key in zip_keys])
print('values from zip:',[value for value in zip_values])

dict_zip = dict(zip(keys, values))
print('Dictionary of keys and values:',dict_zip)

matrix3x3 = [
	[4,2,1],
	[10, 3, 1],
	[10, 10,10]
	    ]

print('3x3 matrix:')
pp = PrettyPrinter(indent=4, width=30)
pp.pprint(matrix3x3)

matrix3x4 = [
	[9,5,7,8],
	[8, 4, 3, 3],
	[8,1,9,5]
	]

print('3x4 matrix:')
pp = PrettyPrinter(indent=4, width=30)
pp.pprint(matrix3x4)

matrix_mult = [
	[0,0,0,0],
	[0,0,0,0],
	[0,0,0,0],
	]


for x in range(len(matrix3x3)):
	for y in range(len(matrix3x4[0])):
		for z in range(len(matrix3x4)):
			matrix_mult[x][y] += matrix3x3[x][z] * matrix3x4[z][y]

print('Multiplication matrix')
pp.pprint(matrix_mult)

matrix_mult = [[sum( x * y for x, y in zip(rows,cols)) for cols in zip(*matrix3x4)] for rows in matrix3x3]
print('Multiplication matrix')
pp.pprint(matrix_mult)


print('3x4 matrix:')
pp.pprint(matrix3x4)
cols = zip(*matrix3x4)
print('cols:')
pp.pprint([col for col in cols])
print('3x3 matrix:')
pp.pprint(matrix3x3)
rows = [row for row in matrix3x3]
print('rows:')
pp.pprint(rows)








