import locale
import sys

class Base_Model():
	'''Represent the base model of a car'''
	trim = 'normal'
	engine_liters = 1.5

	def engine_sound(self):
		return 'putt, putt'

	def horn_sound(self):
		return 'beep, beep'

	def __str__(self):
		return 'Base Model'

coop = Base_Model()
print('%s has %s trim level.' % (coop, coop.trim))
print('%s has a %s liter engine.' % (coop, coop.engine_liters))
print('%s engine sounds like  %s' % (coop, coop.engine_sound()))
print('%s horn sounds like  %s' % (coop, coop.horn_sound()))


class Sport_Model(Base_Model):
	'''Represent the base model of a car'''
	engine_liters = 2.0

	def engine_sound(self):
		return 'VROOM, VROOM'

	def horn_sound(self):
		return 'BEEP, BEEP'

	def __str__(self):
		return 'Sport Model'

coop = Sport_Model()
print('%s has %s trim level.' % (coop, coop.trim))
print('%s has a %s liter engine.' % (coop, coop.engine_liters))
print('%s engine sounds like  %s' % (coop, coop.engine_sound()))
print('%s horn sounds like  %s' % (coop, coop.horn_sound()))

class Luxury_Model(Base_Model):
	'''Represent the base model of a car'''
	trim = 'luxury'

	def engine_sound(self):
		return 'vroom, vroom'

	def horn_sound(self):
		return 'honk, honk'

	def __str__(self):
		return 'Luxury Model'

class Luxury_Sport_Model(Luxury_Model, Sport_Model):
	def __str__(self):
		return 'Luxury Sport Model'
coop = Luxury_Sport_Model()
print('%s has %s trim level.' % (coop, coop.trim))
print('%s has a %s liter engine.' % (coop, coop.engine_liters))
print('%s engine sounds like  %s' % (coop, coop.engine_sound()))
print('%s horn sounds like  %s' % (coop, coop.horn_sound()))

class Sport_Luxury_Model(Sport_Model, Luxury_Model):
	def __str__(self):
		return 'Sport Luxury Model'
coop = Sport_Luxury_Model()
print('%s has %s trim level.' % (coop, coop.trim))
print('%s has a %s liter engine.' % (coop, coop.engine_liters))
print('%s engine sounds like  %s' % (coop, coop.engine_sound()))
print('%s horn sounds like  %s' % (coop, coop.horn_sound()))

coop.brakes = 'racing'
Base_Model.brakes = 'standard'
print('%s has %s brakes' % (coop, coop.brakes))
print('%s has %s brakes' % (Sport_Luxury_Model, Sport_Luxury_Model.brakes))


