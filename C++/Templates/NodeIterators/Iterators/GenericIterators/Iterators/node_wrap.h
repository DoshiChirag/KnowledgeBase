#include "stdafx.h"

class intnode {
public:
	int val;
	intnode* next;
	bool operator==(int n) { return val == n; }	
	bool operator==(intnode* n) { return val == n->val; }
	bool operator==(intnode n) { return val == n.val; }
};


template <class Node>
struct node_wrap {
	Node* ptr;

	node_wrap(Node* p = 0) : ptr(p) {}

	Node& operator*() const { return *ptr; }
	Node* operator->() const { return ptr; }

	node_wrap& operator++() { ptr = ptr->next; return *this; }
	node_wrap operator++(int) { node_wrap tmp = *this; ++* this; return tmp; }

	bool operator==(const node_wrap& i)const { return ptr == i.ptr; }
	bool operator!=(const node_wrap& i) const { return ptr != i.ptr; }

public:
	typedef input_iterator_tag iterator_category;	
	typedef ptrdiff_t difference_type;
	typedef const Node* pointer;
	typedef const Node& reference;
	typedef Node value_type;

};


