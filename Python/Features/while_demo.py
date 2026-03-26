counter = 3
while counter > 0:
	print("counting down:", counter)
	counter -= 1

while counter > 0:
	print("Never executes suite")
	print("when condition is false")

while 1:
	print("Executes atleast once")
	if not counter:
		break;

names = ['Tom', 'Ellen']
while names:
	print(names.pop(), ' is going')

results = [1, 0, 1]
processed = 0
passed = 0
while results:
	processed += 1
	result = results.pop()
	if not result:
		continue
	passed += 1
else:
	print('processed:', processed, 'Passed:', passed)

