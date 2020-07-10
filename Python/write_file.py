'''Demonstrate writing text to a file'''

from io import UnsupportedOperation

print('Default Windows 10 encoding "cp1252".')
with open("written.text", mode='w') as out_file:
	out_file.write('This is the first line of text. \n')

with open("written.text", mode='a') as out_file:
	out_file.write('This is the text line appended. \n')

with open("written.text", mode='r') as in_file:
	print(in_file.read())

lines = (
	'Line 1\n', 'Line2\n',
	'Line 3\n', 'Line4\n'
	)

try:
	out_file = open('without.txt', mode='w', buffering=1, encoding='us')
	out_file.writelines(lines)
	out_file.flush()
finally:
	out_file.close()

try:
	in_file = open('without.txt',encoding='us')
	print(in_file.tell(), end='<-File position')
	print(in_file.read(7))
	print(in_file.tell(), end='<-File position')
	print(in_file.read(7))
	print(in_file.tell(), end='<-File position')
	in_file.seek(0,0)
	print(in_file.tell(), end='<-File position from BOF')
	in_file.seek(0,2)
	print(in_file.tell(), end='<-File position from EOF')
	print(in_file.read())
	in_file.seek(7,1)	
except UnsupportedOperation:
	print('Text files do not support relative seeks')
finally:
	in_file.close()
	

