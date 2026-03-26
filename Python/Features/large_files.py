'''Demonstrate workign with large files'''

from timeit import timeit

def file_iter():
	with open('games.txt', mode ='r') as text_file:
		with open('out.txt', mode ='w') as out_File:
			for line in text_file:
				out_File.write(line)

def file_readlines():
	with open('games.txt', mode ='r') as text_file:
		with open('out.txt', mode ='w') as out_File:
			lines = text_file.readlines()
			out_File.writelines(lines)

def file_readline():
	with open('games.txt', mode ='r') as text_file:
		with open('out.txt', mode ='w') as out_File:
			while 1:
				line = text_file.readline()
				if not line:
					break
				else:
					out_File.write(line)

def file_read():
	with open('games.txt', mode ='r') as text_file:
		with open('out.txt', mode ='w') as out_File:
			out_File.write(text_file.read())

if __name__ == '__main__':
	print('iterator %5.3f seconds' %timeit(stmt='file_iter()',
			setup = 'from __main__ import file_iter', number=10))
			
	print('readlines() %5.3f seconds' %timeit(stmt='file_readlines()',
			setup = 'from __main__ import file_readlines', number=10))

	print('readline() and writeline() %5.3f seconds' %timeit(stmt='file_readline()',
			setup = 'from __main__ import file_readline', number=10))

	print('read() and write() %5.3f seconds' %timeit(stmt='file_read()',
			setup = 'from __main__ import file_read', number=10))



	

	
	