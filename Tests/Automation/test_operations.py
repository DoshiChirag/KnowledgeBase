import  operations
import pytest
@pytest.mark.parametrize("x,y,result", [
    (7, 3, 10),
    (7, 2, 9),
    ("Hello", " World", "Hello World")     
])

def test_add(x,y, result):
    assert operations.add(x,y) == result
    

def test_product():
    assert operations.product(5,3) == 15
            