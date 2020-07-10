'''The module docstring

Long description

PEP 257 definethe technical details of docstrings
'''

class DocumentMe():
	'''The class docstring rules.'''

	def __init__(self):
		'''Method docstrings'''
		self.text = ''' Triple quoted string displays as is'''

	def funk():
		'''Normal functions'''
		pass

''' Inline comment'''
print ('The module docstring:', __doc__)
print ('The class docstring:', DocumentMe.__doc__)
print ('The  class __init__ docstring:', DocumentMe.__init__.__doc__)
print ('The function docstring:', DocumentMe.funk.__doc__)

help(__name__)
help(DocumentMe)
help(DocumentMe.funk)