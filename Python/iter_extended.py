a,b,c = 1,2,3
print('Value of a:',a)
print('Value of b:',b)
print('Value of c:',c)

try:
	a,b,c = 1,2,3,4
except ValueError as err:
	print('Handled ValueError:', err)
a,b,*c=1,2,3,4
print('Value of a:',a)
print('Value of b:',b)
print('Value of c:',c)
a,*b,c=1,2,3,4,5
print('Value of a:',a)
print('Value of b:',b)
print('Value of c:',c)

*a,b,c=1,2,3,4,5
print('Value of a:',a)
print('Value of b:',b)
print('Value of c:',c)

a,b,*c='hello'
print('Value of a:',a)
print('Value of b:',b)
print('Value of c:',c)

first, *last = {1:'a', 2:'b', 3:'c', 4:'d'}
print('value of first', first)
print('value of last', last)


