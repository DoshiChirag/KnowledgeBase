#include "stdafx.h"

template <class Node, class Reference, class Pointer>
class node_wrapper_base : public iterator<input_iterator_tag, Node,
	ptrdiff_t, Pointer, Reference>
{
public:
	typedef node_wrapper_base<Node, Node&, Node*> iterator;
	typedef node_wrapper_base<Node, const Node&, const Node*> const_iterator;
	Pointer ptr;
	node_wrapper_base(Node* p = 0) : ptr(p) {}
	node_wrapper_base(const iterator& x) : ptr(x.ptr) {}

	Reference operator*() const { return *ptr; }
	Pointer operator->() const { return ptr; }

	void incr() { ptr = ptr->next; }

	bool operator==(const node_wrapper_base& x) const { return ptr == x.ptr; }
	bool operator!=(const node_wrapper_base& x) const { return ptr != x.ptr; }

};

template <class Node>
class node_wrapper :public node_wrapper_base<Node, Node&, Node*>
{
public:
	typedef node_wrapper_base<Node, Node&, Node*> Base;
	node_wrapper(Node* p = 0) : Base(p) {}
	node_wrapper(const node_wrapper<Node>& x):Base(x) {}

	node_wrapper& operator++() { this->incr(); return *this; }
	node_wrapper operator++(int) { node_wrapper tmp = *this; this->incr(); return tmp; }	
};

template <class Node>
class const_node_wrapper :public node_wrapper_base<Node, const Node&, const Node*>
{
public:
	typedef node_wrapper_base<Node, const Node&,const Node*> Base;
	const_node_wrapper(const Node* p = 0) : Base(p) {}
	const_node_wrapper(const node_wrapper<Node>& x) :Base(x) {}

	const_node_wrapper& operator++() { this->incr(); return *this; }
	const_node_wrapper operator++(int) { const_node_wrapper tmp = *this; this->incr(); return tmp; }
};