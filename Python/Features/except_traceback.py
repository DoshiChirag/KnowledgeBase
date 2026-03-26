import sys
import traceback
import pprint

def raise_exception():
	raise RuntimeError('The root cause of the problem')

def call_raise_exception():
	raise_exception()

def trace_call_raise_exception():
	global extracted_traceback, extracted_stack
	try:
		call_raise_exception()
	except RuntimeError as exception:
		exc_type, exc_value, exc_traceback = sys.exc_info()
		print('Handling %s: %s' % (exc_type, exc_value))
		print('\nUsing traceback.print_exception()')
		traceback.print_exception(exc_type, exc_value, exc_traceback)
		print('\nUsing traceback.print_exc()')
		traceback.print_exc(file = sys.stdout)
		print('\nUsing traceback.format_exception()')
		tb_text = traceback.format_exception(exc_type, exc_value, exc_traceback)
		for tb_line in tb_text:
			print(tb_line, end = '', file=sys.stdout)
		print('\nUsing traceback.print_stack()')
		traceback.print_stack(file=sys.stdout)
		extracted_traceback = traceback.extract_tb(exc_traceback)
		extracted_stack = traceback.extract_stack()
			
trace_call_raise_exception()
printer = pprint.PrettyPrinter()
print('\n Extracted Traceback:')
printer.pprint(extracted_traceback)
print('\n Extracted Stack:')
printer.pprint(extracted_stack)
