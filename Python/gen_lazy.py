pi = 3.141592653589793
print('Create values in memory instead of lazy evaluation')

def numbers(stop=10):
	num_list = []
	for n in range(1, stop +1):
		print('Adding %s to the num_list' % n)
		num_list.append(n)
	return num_list


def area_circle(radius):
	area = pi * radius ** 2
	print('Circle area with radius %s is : %s' %(radius, area))
	return area

num_list = numbers()
area_list = [area_circle(n) for n in num_list]
print('Thje list of areas is ', area_list)
num_list = numbers(100)
area_list = [area_circle(n) for n in num_list]
print('Thje list of areas is ', area_list)

def numbers_gen(stop=10):
	n = 1
	while n < stop +1 :
		print('Yielding  n as :%s' % n)
		yield n
		n += 1


def area_circle_gen(radius):
	area = pi * radius ** 2
	print('Circle area with radius %s is : %s' %(radius, area))
	yield area



area_list_gen = [area_circle_gen(n) for n in numbers_gen()]
print('The area list type is ', type(area_list_gen))
print('values are generated on demand')
for area in area_list_gen:
	print(next(area))

a_list = list(area_list_gen)
print('Once used generators no longer produce results:', a_list)
print('Prior to first generatation of generator')
area_list_gen = (area_circle_gen(n) for n in numbers_gen())
print('Prior to generaation list of generators')
area_list_gen2 = [n for n in area_list_gen]
print('Type of area_list_gen2:', type(area_list_gen2))
print('The contents of area_list_gen2', area_list_gen2)
print('Prior to generation of list of areas')
area_list_gen3 = [next(area) for area in area_list_gen2]
print('The contents of area_list_gen3', area_list_gen3)



