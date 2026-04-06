#ifndef __CSVProcessor_H
#define __CSVProcessor_H

#include "stdafx.h"

#pragma once
class CSVProcessor
{			
	private:		
		string aggregationFunction;
		int recordColumnIndexToAggregate;
	public:
		const string FieldDelimiter = ",";
		const string RecordDelimiter = "\n";		
		CSVProcessor(string aggregateFunction, int columnIndex);
		void ProcessFile(string fileName);
};

#endif