from pprint import PrettyPrinter

matrix_a = [
	[1, 2, 3],
	[4, 5, 6],
	[7, 8, 9]
	]

matrix_b = [
	[2, 4, 6],
	[12, 15, 18],
	[28 , 32, 26]
	]

matrix_add = [
	[0, 0, 0],
	[0, 0, 0],
	[0, 0, 0]
	]

rows = range(len(matrix_a))
cols = range(len(matrix_a[0]))

for row in rows:
	for col in cols:
		matrix_add[row][col] = matrix_a[row][col] + matrix_b[row][col]

print(matrix_add)

matrix_add = [[matrix_a[row][col] + matrix_b[row][col] for col in cols] for row in rows]
print(matrix_add)

rows = cols = range(1, 10)
mult_table = [[row * col for col in cols] for row in rows]

pp = PrettyPrinter()
pp.pprint(mult_table)

print(mult_table)

