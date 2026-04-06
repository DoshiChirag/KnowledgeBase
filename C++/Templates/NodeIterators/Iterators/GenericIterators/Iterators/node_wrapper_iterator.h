#include "stdafx.h"
#include "node_wrap.h"
#include "node_wrapper.h"

class node_wrapper_iterator
{
	istream* in;
	node_wrapper<intnode>* first;
	node_wrapper<intnode>* node;	
	void read() {
		string line;
		getline(cin, line);
		if (line.length() == 0)
		{
			if (node)
				++node = NULL;

			node = first;
			return;
		}
		int val = atoi(line.c_str());
		if (val >= 0)
		{

			intnode* newnode = new intnode();
			newnode->val = val;
			newnode->next = NULL;
			if (!node)
			{
				node = new node_wrapper<intnode>(newnode);
				first = node;
			}
			else
			{
				node->ptr->next = newnode;
				++node = new node_wrapper<intnode>(newnode);
			}
		}
		else
		{	if(node)
				++node = NULL;
			node = first;
		}
	}

public:
	typedef input_iterator_tag iterator_category;
	typedef node_wrapper<intnode> value_type;
	typedef ptrdiff_t difference_type;
	typedef const node_wrapper<intnode>* pointer;
	typedef const node_wrapper<intnode>& reference;

	node_wrapper_iterator() : in(&cin), first(0) {}
	node_wrapper_iterator(istream& s) :in(&s) { read(); }
	reference operator*() const {
		return *node;
	}
	pointer operator->() const { return node; }
	node_wrapper_iterator operator++() {
		read();
		return *this;
	}

	node_wrapper_iterator operator++(int) {
		node_wrapper_iterator tmp = *this;
		read();
		return tmp;
	}

	bool operator==(const node_wrapper_iterator& i) const {
		return (in == i.in);
	}

	bool operator!=(const node_wrapper_iterator& i) const {
		return !(*this == i);
	}

};