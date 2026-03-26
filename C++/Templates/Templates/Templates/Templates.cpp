// Templates.cpp : This file contains the 'main' function. Program execution begins and ends there.
//

#include "CustomTemplates.h"
#include "MyStack.h"


using namespace std;

template <typename T>
const T maxNum(const T& x, const T& y)
{
	return ((x > y) ? (x) : (y));
}

template <typename T, typename U>
void mySwap(T& x, U& y)
{
	T temp = x;
	x = y;
	y = (U)temp;
}

template <typename T, typename U>
const T mySum(const T& x, const U& y)
{
	return (T)(x + y);
}



int main()
{
	MyStack<int> s(2);

	s.push(10);
	s.push(20);
	s.push(30);

	cout << s.top() << endl;
	s.pop();
	cout << s.top() << endl;

	return 0;
}

// Run program: Ctrl + F5 or Debug > Start Without Debugging menu
// Debug program: F5 or Debug > Start Debugging menu

// Tips for Getting Started: 
//   1. Use the Solution Explorer window to add/manage files
//   2. Use the Team Explorer window to connect to source control
//   3. Use the Output window to see build output and other messages
//   4. Use the Error List window to view errors
//   5. Go to Project > Add New Item to create new code files, or Project > Add Existing Item to add existing code files to the project
//   6. In the future, to open this project again, go to File > Open > Project and select the .sln file
