odds = []
for num in range(10):
	if num % 2:
		odds.append(num)
print('Odd numbers:', odds)

odds = [num for num in range(10) if num % 2]
print('Odd Numbers:', odds)


nums = [num for num in range(10) if num % 2]
print('Number strings:', nums)

evens = [num for num in range(10) if not int(num) % 2]
print('Even numbers:', evens)

alphabet = [chr(ordinal) for ordinal in range(ord('A'), ord('Z') + 1) if chr(ordinal).isalpha()]
print('Alphabet:', alphabet)