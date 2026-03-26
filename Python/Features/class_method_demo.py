import locale
import sys

class Base_Model():
	'''Represent the base model of a car'''
	trim = 'normal'
	engine_liters = 1.5
	miles_range = 450
	tank_capacity = 45
	color = 'white'
	transmission = 'automatic'

	@classmethod
	def miles_per_liter(cls):
		return cls.miles_range / cls.tank_capacity

	@classmethod
	def miles_per_gallon(cls):
		return cls.miles_per_liter() * 3.78541


	def __init__(self, price, transmission = 'automatic', color='white'):
		self.price = price
		self.transmission = transmission
		self.color = color

	def info(self):
		if sys.platform.startswith('win'):
			locale.setlocale(locale.LC_ALL, 'us')
		else:
			locale.setlocale(locale.LC_ALL, 'en_US.utf8')
		print('The price of %s was %s.' %
			(self, locale.currency(self.price)))

	def __str__(self):
		return 'a %s base model with %s transmission' % (self.color, self.transmission)


coop = Base_Model(color = 'green', price = 26300, transmission = 'Automatic')
coop.info()

print('The %s gets %4.1f miles per gallon' %(coop, coop.miles_per_gallon()))
print('The %s gets %4.1f miles per gallon' %(Base_Model, Base_Model.miles_per_gallon()))

class Sport_Model(Base_Model):
	engine_liters = 2.0
	miles_range = 400

coop = Sport_Model(color = 'red', price = 26300, transmission = 'manual')
coop.info()

print('The %s gets %4.1f miles per gallon' %(coop, coop.miles_per_gallon()))
print('The %s gets %4.1f miles per gallon' %(Sport_Model, Sport_Model.miles_per_gallon()))
