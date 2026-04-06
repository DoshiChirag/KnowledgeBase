using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.ServiceModel.Activation;
using System.Web.Script.Services;
using WCFDataContract;
namespace WCFServiceApp
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerCall)]
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    [ScriptService]
    public class Service : IService
    {
      
        public string GetData(int value)
        {
            
            return string.Format("You entered: {0} Session ID = {1}", value, OperationContext.Current.SessionId);
        }

         [OperationBehavior(ReleaseInstanceMode = ReleaseInstanceMode.AfterCall)]
        public CompositeType GetDataUsingDataContract(CompositeType composite)
        {
            
            if (composite == null)
            {
                
                throw new FaultException<ExceptionFault>(new ExceptionFault("Composite"));
            }
            if (composite.BoolValue)
            {
                composite.StringValue += "Suffix";
            }
            return composite;
        }
    }
}
