#include "stdafx.h"

struct strtab_cmp
{
	typedef vector<char>::iterator strtab_iterator;

	bool operator()(const pair<strtab_iterator, strtab_iterator>& x, const pair<strtab_iterator, strtab_iterator>& y) const{
		return lexicographical_compare(x.first, x.second, y.first, y.second);
	}
};

struct strtab_print
{
	ostream& out;
	strtab_print(ostream& os) : out(os){}

	typedef vector<char>::iterator strtab_iterator;

	void operator()(const pair<strtab_iterator, strtab_iterator>& s) const {
		copy(s.first, s.second, ostream_iterator<char>(out));
	}
};