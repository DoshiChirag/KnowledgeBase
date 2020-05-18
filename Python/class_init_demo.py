import locale
import sys

class Base_Model():
	'''Represent the base model of a car'''
	trim = 'normal'
	engine_liters = 1.5

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

coop = Base_Model(25000)
coop.info()

coop = Base_Model(25500, color = 'blue')
coop.info()


coop = Base_Model(26000, 'manual', 'red')
coop.info()

coop = Base_Model(color = 'green', price = 26300, transmission = 'Automatic')
coop.info()

