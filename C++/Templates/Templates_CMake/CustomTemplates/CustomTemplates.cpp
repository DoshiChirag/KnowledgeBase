// CustomTemplates.cpp : Defines the entry point for the application.
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
void mySwap( T& x, U& y)
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

	MyStack<int> s(10);

	s.push(10);
	s.push(20);
	s.push(30);

	cout << s.top() << endl;
	s.pop();
	cout << s.top() << endl;
	
	return 0;
}


