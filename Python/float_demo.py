x = 5.0
y = float.fromhex('A')
print('x=', x , ',', 'y=', y)
print('x.as_integer_ratio() =', x.as_integer_ratio())
print('y.hex() =', y.hex())
print('x == y = ', x == y)
print('x != y = ', x != y)
print('x >= y = ', x >= y)
print('x > y = ', x > y)
print('x <= y = ', x <= y)
print('x < y = ', x < y)
print('x + y = ', x + y)
print('x - y = ', x - y)
print('x / y = ', x / y)
print('x // y = ', x // y)
print('x % y = ', x % y)
print('x ** y = ', x ** y)
print('divmod(x,y) = ', divmod(x,y))
print('pow(x,y) = ', pow(x,y))
print('abs(-x) = ', abs(-x))
print('int(x) = ', int(x))
print('float(10) = ', float(10))
print('x = x + y =', end = ' ')
x += y
print(x)
print('x = x - y =', end = ' ')
x -= y
print(x)
print('x = x * y =', end = ' ')
x *= y
print(x)
print('x = x / y =', end = ' ')
x /= y
print(x)
x, y = 4.0, 2.0
print('x=', x , ',', 'y=', y)


