import unittest
import io
from unittest.mock import patch
from Day2.prime2 import get_primes

class TestGetPrimes(unittest.TestCase):
    def test_primes_1_to_10(self):
        """Test primes from 1 to 10: should print 2, 3, 5, 7."""
        with patch('sys.stdout', new_callable=io.StringIO) as mock_stdout:
            get_primes(1, 10)
            self.assertEqual(mock_stdout.getvalue(), '2\n3\n5\n7\n')

    def test_primes_10_to_20(self):
        """Test primes from 10 to 20: should print 11, 13, 17, 19."""
        with patch('sys.stdout', new_callable=io.StringIO) as mock_stdout:
            get_primes(10, 20)
            self.assertEqual(mock_stdout.getvalue(), '11\n13\n17\n19\n')

    def test_primes_2_to_2(self):
        """Test primes from 2 to 2: should print 2."""
        with patch('sys.stdout', new_callable=io.StringIO) as mock_stdout:
            get_primes(2, 2)
            self.assertEqual(mock_stdout.getvalue(), '2\n')

    def test_primes_4_to_4(self):
        """Test primes from 4 to 4: should print nothing (4 is not prime)."""
        with patch('sys.stdout', new_callable=io.StringIO) as mock_stdout:
            get_primes(4, 4)
            self.assertEqual(mock_stdout.getvalue(), '')

    def test_primes_1_to_1(self):
        """Test primes from 1 to 1: should print nothing (1 is not prime)."""
        with patch('sys.stdout', new_callable=io.StringIO) as mock_stdout:
            get_primes(1, 1)
            self.assertEqual(mock_stdout.getvalue(), '')

    def test_primes_25_to_30(self):
        """Test primes from 25 to 30: should print 29."""
        with patch('sys.stdout', new_callable=io.StringIO) as mock_stdout:
            get_primes(25, 30)
            self.assertEqual(mock_stdout.getvalue(), '29\n')

if __name__ == '__main__':
    unittest.main()