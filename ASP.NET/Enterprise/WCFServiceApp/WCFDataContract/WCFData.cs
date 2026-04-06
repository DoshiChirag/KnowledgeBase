using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
namespace WCFDataContract
{
    
    // Use a data contract as illustrated in the sample below to add composite types to service operations.
    // You can add XSD files into the project. After building the project, you can directly use the data types defined there, with the namespace "WCFServiceApp.ContractType".
    [DataContract]
    public class CompositeType
    {
        bool boolValue = true;
        string stringValue = "Hello ";

        [DataMember]
        public bool BoolValue
        {
            get { return boolValue; }
            set { boolValue = value; }
        }

        [DataMember]
        public string StringValue
        {
            get { return stringValue; }
            set { stringValue = value; }
        }
    }


    [DataContract]
    public class ExceptionFault
    {

        string stringValue = "Hello ";

        public ExceptionFault(string message)
        {

            stringValue = message;
        }

        [DataMember]
        public string Message
        {
            get { return stringValue; }
            set { stringValue = value; }
        }
    }


}


