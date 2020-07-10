import random
sayings = ('Hello', 'Hi', 'Hey', 'Aloha')

def greet():
	return random.choice(sayings)

def test_greet():
	for loop in range(8):
		print(greet(), end=' ')
	print('\n greetings test completed')

if __name__ == '__main__':
	print(test_greet())
