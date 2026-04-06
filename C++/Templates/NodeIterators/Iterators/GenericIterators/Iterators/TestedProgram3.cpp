#include "stdafx.h"
#include "node_wrap.h"

int main1_3()
{
	intnode* first = NULL;
	intnode* node = NULL;

	while (cin)
	{
		string line;
		getline(cin, line);
		if (line.length() == 0)
			break;
		int val = atoi(line.c_str());
		if (val >= 0)
		{

			intnode* newnode = new intnode();
			newnode->val = val;
			newnode->next = NULL;
			if (!node)
			{
				node = newnode;
				first = node;
			}
			else
			{
				node->next = newnode;
				node = newnode;
			}
		}
	}

	int search = 3;
	cout << "Enter search value" << endl;
	cin >> search;
	node_wrap<intnode> nodesearch = find(node_wrap<intnode>(first), node_wrap<intnode>(), search);
	cout << "Search value = " << ((nodesearch != NULL) ? nodesearch->val : -1) << endl;

	int x = getchar();
	cout << x << endl;
	return (x);
}