#include "stdafx.h"
#include "node_wrapper_iterator.h"

int main()
{

	node_wrapper_iterator iter(cin);
	node_wrapper_iterator lastelement;
	vector<node_wrapper<intnode>> V(iter, lastelement);

	/**
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

			V.push_back(node);
		}
	}

	**/

	if (V.size() == 0)
	{
		cout << "No elements added to search list";
		return getchar();
	}

	int search = 3;
	cout << "Enter search value" << endl;
	cin >> search;
	intnode* node = new intnode();
	node->val = search;
	node->next = NULL;
	node_wrapper<intnode>* searchnode = new node_wrapper<intnode>(node);

	node_wrapper<intnode> firstnode = *V.begin();
	node_wrapper<intnode> last = node_wrapper<intnode>();

	node_wrapper<intnode> nodefound = find(firstnode, last, node);
	cout << "Search value = " << nodefound.ptr->val << endl;
	
	int x = getchar();
	cout << x <<endl;
	return (x);
}