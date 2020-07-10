import errno
import os

def check_file(filepath):
	if not os.path.isfile(filepath):
		raise FileNotFoundError

try:
	check_file('invalid path')
except FileNotFoundError as exception:
	print('#1 Handled FileNotFoundError:', exception)

def check_file_message(filepath):
	if not os.path.isfile(filepath):
		raise FileNotFoundError('"%s" not found' % filepath)

try:
	check_file_message('invalid path')
except FileNotFoundError as exception:
	print('#2 Handled FileNotFoundError:', exception)

def check_file_args(filepath):
	if not os.path.isfile(filepath):
		raise FileNotFoundError(errno.ENOENT,
					os.strerror(errno.ENOENT),
					filepath,
					2,
					'filename2')

try:
	check_file_args('invalid path')
except FileNotFoundError as exception:
	print('#3 Handled FileNotFoundError:', exception)
	print('#3 Args FileNotFoundError:', exception.args)

def check_file_real(filepath):
	f = open(filepath)
	return f

try:
	f = check_file_real('invalid path')
except FileNotFoundError as exception:
	print('#4 Handled FileNotFoundError:', exception)
	print('#4 Args FileNotFoundError:', exception.args)


help(FileNotFoundError)






