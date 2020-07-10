a_tuple = ('a', 1, 2, (3, 4))
a_string = 'immutable'
a_bytes = b'sequence'
a_list = [5, 6, 7, 8, (4, 5)]
a_byte_array = bytearray(b'mutable')
print('a_tuple[0] ->', a_tuple[0])
print('a_string[1] ->', a_string[1])
print('a_bytes[2] ->', a_bytes[2])
print('a_list[3] ->', a_list[3])
print('a_byte_array[4] ->', a_byte_array[4])
print('a_tuple[-1] ->', a_tuple[-1])
print('a_string[-2] ->', a_string[-2])
print('a_bytes[-3] ->', a_bytes[-3])
print('a_list[-4] ->', a_list[-4])
print('a_bytearray[-5] ->', a_byte_array[-5])
print('a_list[0:2] ->', a_list[0:2])
print('a_list[:2] ->', a_list[:2])
print('a_list[2:5] ->', a_list[2:5])
print('a_list[2:] ->', a_list[2:])
print('a_list[:] ->', a_list[:])
list_ref = a_list
print('a_list is list_ref ->', a_list is list_ref)
list_copy = a_list[:]
print('a_list is list_copy ->', a_list is list_copy)
print('a_list[::2] ->', a_list[::2])
print('a_list[1:4:2] ->', a_list[1:4:2])
print('a_list[::-1] ->', a_list[::-1])
print('a_list ->', a_list)
print('a_list[4] ->', a_list[4])
print('a_list[4][0] ->', a_list[4][0])
print('a_list[4][1] ->', a_list[4][1])
print('a_list ->', a_list)
a_list[0] ='five'
print('a_list ->', a_list)
a_list[1:4] = [10, 11, 12]
print('a_list ->', a_list)
a_slice = slice(4)
print('a_slice ->', a_slice)
print('a_list[a_slice] ->', a_list[a_slice])
a_slice = slice(1,5)
print('a_slice ->', a_slice)
print('a_list[a_slice] ->', a_list[a_slice])
a_slice = slice(1,5,2)
print('a_slice ->', a_slice)
print('a_list[a_slice] ->', a_list[a_slice])




