print('For loop:')
seq = 'abcde'
for char in seq:
	print(char, end=' ')

print('\nWhile loop:')
index = 0
while index < len(seq):
	print(seq[index], end=' ')
	index += 1
seq_upper = [c.upper() for c in seq]
tup_pairs = zip(seq, seq_upper)
print('\n Is tup_pairs iterable?', hasattr(tup_pairs, '__iter__'))
print('For loop:')
for pair in tup_pairs:
	print(pair, end= ' ')
	break
print('\n Is tup_pairs iterable?', hasattr(tup_pairs, '__next__'))
print('\n Iteration #1', tup_pairs.__next__()) #Python 2

print('\n Is seq iterable?', hasattr(seq, '__iter__'))
print('\n Is seq an iterator?', hasattr(seq, '__next__'))

it = iter(seq)
print('\n Is it iterable?', hasattr(it, '__iter__'))
print('\n Is it an iterator?', hasattr(it, '__next__'))

print('Iteration #1',it.__next__())
print('Iteration #2',it.__next__())
print('Iteration #3',it.__next__())
print('Iteration #4',it.__next__())
print('Iteration #5',it.__next__())
print('Iteration #6',it.__next__())






