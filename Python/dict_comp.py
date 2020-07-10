keys = [1, 'a', 2, 'b', 3, 'c']
print('List keys:\n', keys)
values = [100, 'apple', 200, 'berry', 300, 'cherry']
print('List values:\n', values)
bundle = dict(zip(keys, values))
print('Dictionary bundle:\n', bundle)
box = {k:v for (k,v) in zip(keys, values)}
print('Dictionary box:\n', box)
alpha = {k.upper():v for (k,v) in zip(keys,values) if isinstance(k,str)}
print('Dictionary alpha:\n', alpha)
numer = {k:(v*100) for (k,v) in zip(keys,values) if isinstance(k,int)}
print('Dictionary numer:\n', numer)
cond = [True if isinstance(test, str) else False for test in keys]
print('Conditional list:\n', cond)
cond_zip = zip(keys,values,cond)
print('Conditional zipped list:\n', list(cond_zip))
fruit = {key:value.upper() for (value, key,test) in zip(keys,values,cond) if test}
print('Dictionary fruit:\n', fruit)
