print('type type of 1 is:', type(1))
print('type type of [] is:', type([]))

A_class = type('A_class', (), {})
print('type of A_class is:', type(A_class))
an_inst = A_class()
print('type of A_inst is:', type(an_inst))

A_type = type('A_type', (), {'start':1, 'a_method':
				lambda self: 'This is an instance of ' + 
				str(self.__class__)})

type_inst = A_type()
print('type of A_type is:', type(A_type))
print('type of type_inst is:', type(type_inst))
print('Calling a_method returns:', type_inst.a_method())

class Basic():
	start = 1
	def a_method(self):
		return 'This is an instqance of '+ str(self.__class__)

basic_inst = Basic()
print('type of basci is:', type(Basic))
print('type of basic_inst is:', type(basic_inst))
print('Calling a_method returns:', basic_inst.a_method())


