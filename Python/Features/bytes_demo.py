bytes_literal = b'Copyright \xc2\xa9'
print('bytes_literal =', bytes_literal)
print('bytes_decode() ->', bytes_literal.decode())
print('bytes_decode("utf-8") ->', bytes_literal.decode("utf-8"))
print('bytes_decode("utf-16") ->', bytes_literal.decode("utf-16"))
str_literal = 'Trademark ©'
bytes_encoded = str_literal.encode()
print('bytes_encoded =', bytes_encoded)
print('bytes_encoded.decode() ->', bytes_encoded.decode())
print('bytes(str_literal) ->', bytes(str_literal, 'utf-8'))
bytes_construct = bytes(str_literal, 'utf-8')
print('bytes_construct.decode() ->', bytes_construct.decode())
bytes_from_hex = bytes.fromhex('54 72 61 64 65 6d 61 72 6b 20 c2 ae')
print('bytes_from_hex.decode() ->', bytes_from_hex.decode())
print('str_literal.count("T") ->', str_literal.count('T'))
print('str_literal.index("T") ->', str_literal.index('T'))
print('bytes_encoded.count(0x54) ->', bytes_encoded.count(0x54))
print('bytes_encoded.index(0x54) ->', bytes_encoded.index(0x54))

