from time import strftime, localtime

class ProjectBaseError(Exception):
	def __init__(self, *args, **kwargs):
		if len(args) > 2 and args[2]:
			logfile = args[2]
		else:
			logfile = __file__ + '.log'
		print(logfile)
		with open(logfile, mode = 'a') as logout:
			logout.write(str(strftime('%Y%m%d%H%M%S', localtime()) + '\t'))
			logout.write(str(self.__class__) + '\t')
			logout.write(str(args) + '\n')

try:
	raise ProjectBaseError("Demonstration", 'DemoError' ,r'C:\Root\Training\Python\ExceptionLog.log')
except ProjectBaseError as exception:
	print('Handling ProjectBaseError', exception)

class ProjectRequiredValueError(ProjectBaseError):
	def __init__(self, message, request_value, *args):
		self.requested_value = request_value
		self.message = message
		ProjectBaseError.__init__(self,message, request_value, *args)

try:
	raise ProjectRequiredValueError("Missing value for first name", 'DemoError' ,r'C:\Root\Training\Python\FirstName.log')
except ProjectRequiredValueError as exception:
	print('Handling ProjectError', exception.message)
	print('Handling ProjectError', exception.requested_value)


try:
	raise ProjectRequiredValueError("Missing Valuefor Last Name", 'LastName Error' ,r'C:\Root\Training\Python\LastName.log')
except ProjectRequiredValueError as exception:
	print('Handling ProjectError', exception.message)
	print('Handling ProjectError', exception.requested_value)




