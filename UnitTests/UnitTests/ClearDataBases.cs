using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using AFKHostedService;
using UnitTests.ServiceReference1;
using System.ServiceModel;

namespace UnitTests
{
    [TestClass]
    public class ClearDataBases:IServiceCallback
    {
        [TestMethod]
        public void ClearDatabaseTest()
        {
            InstanceContext context = new InstanceContext(this);
            ServiceReference1.ServiceClient Proxy = new ServiceReference1.ServiceClient(context);
            Proxy.ClearAllDatabases();
        }

        public void FinishDataBaseEntry(DataBaseEntry entry)
        {
           // throw new NotImplementedException();
        }

        public void SendResult(string test)
        {
            //throw new NotImplementedException();
        }
    }
}
