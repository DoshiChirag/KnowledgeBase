using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.ServiceModel;
using WCFTest.WCFServiceReference;
namespace WCFTest
{
    [TestClass]
    public class ServiceTest
    {
        [TestMethod]
        [ExpectedException(typeof(FaultException<ExceptionFault>))]
        public void GetDataUsingDataContract()
        {
            IService Service = new ServiceClient();
            Service.GetDataUsingDataContract(null);
        }

        [TestMethod]
        public void GetDataUsingDataContractComposite()
        {
            CompositeType NewObj = new CompositeType();
            NewObj.StringValue = "Test Failed";
            IService Service = new ServiceClient();
            Service.GetDataUsingDataContract(NewObj);
        }



    }
}
