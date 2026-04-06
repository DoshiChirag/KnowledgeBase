#include "stdafx.h"
#include "CSVProcessor.h"

mutex lockm;
void ProcessFile(string file, CSVProcessor p)
{
    p.ProcessFile(file);
}


int main(int argc, char* argv[])
{
    if (argc < 9)
    {
        cout << "Usage : CSVProcessor.exe --concurrency 1 --cvsglob filepath  --aggregation_function SUM or AVERAGE --column ColumnIndex - in the order of occurrence"<< endl;
        exit(1);
    }

    int n = 1;
    if (strcmp(argv[n++],"--concurrency") != 0)
    {
        cout << "Usage : CSVProcessor.exe --concurrency 1 --cvsglob filepath  --aggregation_function SUM or AVERAGE --column ColumnIndex - in the order of occurrence" << endl;
        exit(1);
    }

    int concurrency = atoi(argv[n++]);
    if (concurrency < 1 || concurrency > 10)
    {
        cout << "concurrency must be a valid integer between 1 and 10" << endl;
        exit(2);
    }

    if (strcmp(argv[n++], "--csvglob") != 0)
    {
        cout << "Usage : CSVProcessor.exe --concurrency 1 --cvsglob filepath  --aggregation_function SUM or AVERAGE --column ColumnIndex - in the order of occurrence" << endl;
        exit(1);
    }

    string filepath = argv[n++];

    if (strcmp(argv[n++], "--aggregation_function") != 0)
    {
        cout << "Usage : CSVProcessor.exe --concurrency 1 --cvsglob filepath  --aggregation_function SUM or AVERAGE --column ColumnIndex - in the order of occurrence" << endl;
        exit(1);
    }

    string aggregation = argv[n++];
    if (aggregation != "SUM" && aggregation != "AVERAGE")
    {
        cout << "Aggregation value must be specified as SUM or AVERAGE" << endl;
        exit(2);
    }

    if (strcmp(argv[n++], "--column") != 0)
    {
        cout << "Usage : CSVProcessor.exe --concurrency 1 --cvsglob filepath  --aggregation_function SUM or AVERAGE --column ColumnIndex - in the order of occurrence" << endl;
        exit(1);
    }

    int column = atoi(argv[n]);
    if (column <= 0)
    {
        cout << "column index  value must be a zero based an index into csv record" << endl;
        exit(2);
    }
    
    string folderpath = filepath.substr(0, filepath.find_last_of('\\')+1);

    _finddata_t data;   
    int ff = _findfirst(filepath.c_str(), &data);    
    int concurrentCount = 0;

    vector<string> vFiles(0);
    CSVProcessor processor(aggregation, column);

    if (ff != -1)
    {
        int res = 0;
        while (res != -1)
        {
            string file = folderpath + data.name;
            vFiles.push_back(file);
            if (++concurrentCount == concurrency)
            {
                vector<thread*> processors(0);
                // spawn a concurrent thread for each file upto concurrency value
                for (vector<int>::size_type i = 0 ; i < vFiles.size(); i++)
                {                    
                    thread* t = new thread(&ProcessFile, vFiles[i], processor);
                    processors.push_back(t);
                }

                // wait for all files to finish
                // A more sophisticated algorithm would use waithandles to signal from child thread to main thread 
                // allow processing one more file if a thread finished - not waiting for all threads to finish
                // if one thread finished we would exit the WaitHandleAny and provision one more thread and pass the new array of handles
                // to WaitHandleAny and wait. 
                for (vector<int>::size_type i = 0; i < vFiles.size(); i++)
                {
                    if (processors[i]->joinable())
                    {
                        processors[i]->join();
                    }

                    delete processors[i];
                }

                concurrentCount = 0;
                vFiles.clear();
                processors.clear();
                //now process the next batch of concurrency number of files
            }
            
            res = _findnext(ff, &data);                        
        }
        _findclose(ff);    
    }

    //check if there is any left over batch of files less than concurrency number of files
    vector<thread*> processors(0);    
    for (vector<int>::size_type i = 0; i < vFiles.size(); i++)
    {
        thread* t = new thread(&ProcessFile, vFiles[i], processor);
        processors.push_back(t);
    }

    // wait for all files to finish
    for (vector<int>::size_type i = 0; i < vFiles.size(); i++)
    {
        if (processors[i]->joinable())
        {
            processors[i]->join();
        }

        delete processors[i];
    }

    int i;
    cin >> i;
    
}
