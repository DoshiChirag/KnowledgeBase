print('\n****Iterating ovr lines****')
with open('pep20.txt') as text_file:
	for line in text_file:
		print(line, end='')

print('\n****Iterating over lines with read method****')
with open('pep20.txt', encoding='us') as text_file:
	text = text_file.read()
print(text)

print('\n****using read lines method****')
with open('pep20.txt', encoding='utf-8') as text_file:
	lines = text_file.readlines()
print(lines)

with open('pep20.txt') as text_file:
	while 1:
		line = text_file.readline()
		if not line:
			break
		print(line, end = '')

try:
	with open('pep20.txt', encoding = 'utf-16') as text_file:
		for line in text_file:
			print(line, end='')
except UnicodeError:
	print('Problem with unicode encoding')

	

