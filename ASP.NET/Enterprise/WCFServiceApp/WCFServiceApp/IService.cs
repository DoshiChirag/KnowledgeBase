using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.Text;
using System.Web.Script.Services;
using WCFDataContract;

namespace WCFServiceApp
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract(SessionMode = SessionMode.Allowed)]
    public interface IService
    {
        [OperationContract]
        [FaultContract(typeof(ExceptionFault))]
        string GetData(int value);

        [OperationContract(IsInitiating = true)]
        [FaultContract(typeof(ExceptionFault))]
        CompositeType GetDataUsingDataContract(CompositeType composite);

        // TODO: Add your service operations here
    }

   
}
