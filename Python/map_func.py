vehicles = ['sedan','coupe', 'hatchback', 'wagon']
cars = map(str.capitalize, vehicles)
print('Map object cars:', cars)
cars = list(map(str.capitalize, vehicles))
print('List object cars:', cars)
cars = [car.capitalize() for car in vehicles]
print('List object cars:', cars)
def quad(val):
	return val ** 4
nums = range(4)
print('List of nums', list(nums))
quads =list(map(quad, nums))
print('List of quads', quads)
quads = list(map(lambda val: val ** 4, nums))
print('List of quads', quads)

def mult(x,y):
	return x * y
num_quads = list(map(mult, nums, quads))
print('List of num_quads', num_quads)
num_quads = list(map(lambda x,y: x *y, nums, quads))
print('List of num_quads', num_quads)
