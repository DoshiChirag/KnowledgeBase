x = 1
print('bool(x) =', bool(x))
y = 0
print('bool(y) =', bool(y))

if not None: print('None is false')
if not False: print('False is false')
if not (0 or 0.0 or 0j): print('Zero is False')
if not ('' or [] or ()): print('Empty sequences are false')
if not ({} or set([])): print('Empty mappings are false')
print('True or False returns', True or False)
print('1 or 0 returns', 1 or 0)
print('None or 0 returns', None or 0)
print('True and False returns', True and False)
print('1 and 0 returns', 1 and 0)
print('None and 0 returns', None and 0)
print('Not True returns', not True)
print('Not 1 returns', not 1)
print('Not "text" returns', not "text")
print('Not False returns', not False)
print('Not 0 returns', not 0)
print('Not "" returns', not "")

