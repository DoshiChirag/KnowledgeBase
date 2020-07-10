def odd(val):
	return val % 2
num = range(10)
print('Listof nums:', list(num))
odds = filter(odd, num)
print('filter object of odd nums:', odds)
odds = list(filter(odd,num))
print('filter object of list odd nums:', odds)
odds = list(filter(lambda val: val %2, num))
print('filter object of list odd nums:', odds)
odds = [val for val in num if val % 2]
print('object of list odd nums:', odds)

def ncar(val):
	return val.endswith('n')

vehicles = ['sedan', 'coupe', 'hatchback', 'wagon']
ncars = list(filter(ncar, vehicles))
print('List of ncars:', ncars)
ncars = list(filter(lambda val: val.endswith('n'),  vehicles))
print('List of ncars:', ncars)
ncars = [car for car in vehicles if car.endswith('n')]
print('List of ncars', ncars)


