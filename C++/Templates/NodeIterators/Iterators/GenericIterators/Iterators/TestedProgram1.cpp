#include "stdafx.h"
#include "line_iterator.h"

int main1_1()
{
	line_iterator iter(cin);
	line_iterator end_of_file;
	vector<string> V(iter, end_of_file);

	sort(V.begin(), V.end());
	cout << "Sorted List:" <<endl;
	copy(V.begin(), V.end(), ostream_iterator<string>(cout, "\n"));
	return getchar();	
}
