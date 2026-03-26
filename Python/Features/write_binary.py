'''Demonstrate writing binary data'''

from string import ascii_letters

data = bytes(ascii_letters, 'utf-8')

with open('letters.bin', mode='wb') as out_file:
	out_file.write(data)

with open('letters.bin', mode='rb') as in_file:
	data = in_file.read()

print('Bytes data:', data)
print('String data:', data.decode('utf-8'))
