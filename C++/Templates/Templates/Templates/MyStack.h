#ifndef MY_STACK_H
#define MY_STACK_H

#include <string>

class MyStackException : public std::exception {
		std::string msg;
	public:
		MyStackException(const std::string& m) : msg(m) {}
		const char* what() const noexcept override {
			return msg.c_str();
		}
	};



template<typename T>
class MyStack {
	public:
		T* data;
		size_t size;
		size_t current;

	public:
		MyStack(size_t s) : size{ s }, current{ 0 }, data{ new T[s] } {}
		~MyStack(){ delete[] data; }

		
		T top() {
			if (current == 0)
				throw MyStackException("Empty Stack");
			return data[current - 1];
		}

		
		void pop() {
			if (current == 0)
				throw MyStackException("Empty Stack");
			current--;

		}

		
		void push(const T& n) {
			if (current == size)
				throw MyStackException("Stack Overflow");
			data[current++] = n;
		}

};
#endif