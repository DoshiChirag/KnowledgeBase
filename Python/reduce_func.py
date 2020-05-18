from functools import reduce

def mult(x,y):
	return x * y

nums = range(1,5)
print('List of nums:', list(nums))
product = reduce(mult, nums)
print('Total product:', product)
print('Calculation: (((1*2)*3)*4)')

product = reduce(lambda x,y: x * y,nums)
print('Total product:', product)
product = reduce(lambda x,y: x * y,nums,2)
print('Total product:', product)
print('Calculation: (((2*1*2)*3)*4)')

total = reduce(lambda x,y: x +y, nums)
print('Total sum:', total)
total = sum(nums)
print('Total sum:', total)
total = reduce(lambda x,y: x + y,nums,2)
print('Total sum plus 2:', total)
total = sum(nums,2)
print('Total sum plus 2:', total)



