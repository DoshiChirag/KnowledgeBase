#pragma once
#include "pch.h"
#include <collection.h>
using namespace Windows::Foundation::Collections;
using namespace Platform::Collections;

namespace MyFirstApp
{
	[Windows::UI::Xaml::Data::Bindable]
	public ref class Person sealed
	{
	public:
		Person(){}
		Person(Platform::String^ name){FullName = name;}
		Person(Platform::String^ name, Platform::String^ photo){FullName = name; Photo=photo; }
		property Platform::String^ FullName;
		property Platform::String^ Photo;

	};

	[Windows::UI::Xaml::Data::Bindable]
	public ref class Biz sealed
	{
	public:
		Biz(){}
		virtual ~Biz(){}
		IVector<Person^>^ GetPeople()
		{
			Vector<Person^>^ vec = ref new Vector<Person^>();

			vec->Append(ref new Person("Urmila Doshi", "Photos/img_4002.jpg"));
			vec->Append(ref new Person("Kishor Doshi", "Photos/img_4003.jpg"));
			vec->Append(ref new Person("Chirag Doshi","Photos/img_4004.jpg"));
			vec->Append(ref new Person("Jay Doshi","Photos/img_4005.jpg"));
			vec->Append(ref new Person("Raj Doshi","Photos/img_4006.jpg" ));
			vec->Append(ref new Person("Anant Doshi","Photos/img_4007.jpg"));
			vec->Append(ref new Person("Falguni Doshi","Photos/img_4008.jpg"));
			vec->Append(ref new Person("Nipa Doshi","Photos/img_4009.jpg"));
			vec->Append(ref new Person("Bhautik Doshi","Photos/img_4002.jpg"));
			vec->Append(ref new Person("Unnati Doshi","Photos/img_4003.jpg"));

			return vec;
		
		};


		IVector<Person^>^ GetPeople(Platform::String^ search)
		{
			Vector<Person^>^ vec = ref new Vector<Person^>();
			std::wstring _search=std::wstring (search ->Data() );
			for each(Person^ p in GetPeople()){
				std::wstring name = std::wstring(p ->FullName->Data());
				int pos = name.find(_search);
				if(pos > 0){
					vec->Append(p);
				}

			}

			return vec;

		};

	};
	
}