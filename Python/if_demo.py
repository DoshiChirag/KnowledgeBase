age = 0
if age:
	print('False')

age = 1
if age:
	print('True')

age = 17
if age >= 18 :
	print('vote')

score = 91
print ('The grade was:', end=' ')
if score < 60:
	print('F')
elif 60 <= score <= 70:
	print('D')
elif 70 <= score <= 79:
	print('C')
elif 80 <= score <= 90:
	print('B')
elif 90 <= score <= 100:
	print('A')
else:
	print('Impossible')

debug = True
if debug: print('Score was:', score)

if score > 59:
	result = 'pass'
else:
	result = 'fail'
if debug: print('Result was:', result)

score = 40
if debug: print('Score was:', score)
result = 'pass' if score > 59 else 'fail'
if debug: print('Result was:', result)



