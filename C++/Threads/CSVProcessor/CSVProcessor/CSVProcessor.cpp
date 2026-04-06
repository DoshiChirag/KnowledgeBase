// CSVProcessor.cpp : This file contains the 'main' function. Program execution begins and ends there.
//

#include "CSVProcessor.h"

extern mutex lockm;
CSVProcessor::CSVProcessor(string aggregateFunction, int columnIndex)
{
	aggregationFunction = aggregateFunction;
	recordColumnIndexToAggregate = columnIndex;
}

void CSVProcessor::ProcessFile(string fileName)
{	
	const int MaxRecordSize = 1024;
	string record;
	ifstream inputData(fileName);

	double sum = 0;
	int valueCount = 0;

	char linestr[MaxRecordSize + 1];
	while (inputData.getline(linestr, MaxRecordSize, RecordDelimiter[0]))
	{
		string record = linestr;		
		char* next_token;
		char * fieldtoken = strtok_s(linestr, (const char*)FieldDelimiter.c_str(), &next_token);
		int columCount = 0;
		double fieldValue = 0;
				
		bool valuefound = false;
		while (fieldtoken != NULL)
		{
			if (columCount == recordColumnIndexToAggregate)
			{
				fieldValue = atof(fieldtoken);
				valueCount++;
				sum += fieldValue;
				valuefound = true;
				break;
			}

			fieldtoken = strtok_s(NULL, (const char*)FieldDelimiter.c_str(), &next_token);
			columCount++;
		}

		if (valuefound == false)
		{
			cout << "Invalid record found with no field at index " << columCount <<  "::" << record << endl;
		}
		
	}

	if (aggregationFunction == "SUM")
	{
		lockm.lock();
		cout << fileName << " " << sum << endl;
		lockm.unlock();
	}
	else if (aggregationFunction == "AVERAGE")
	{
		lockm.lock();
		if (valueCount > 0)
		{
			cout << fileName << " " << (double)sum / valueCount << endl;
		}
		else
		{
			cout << fileName << " Invalid file" << endl;
		}
		lockm.unlock();
	}
}


