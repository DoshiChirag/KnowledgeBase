import doctest


def fib(n):
    a, b = 0, 1
    for I in range(n):
        a, b = b, a+b
    return a

fib_0  = fib(0)
fib_10 = fib(10)
fib_15 = fib(15)

assert  fib_0 == 0
assert  fib_10 == 55
assert fib_15 == 600


