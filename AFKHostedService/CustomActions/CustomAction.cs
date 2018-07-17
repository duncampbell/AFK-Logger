using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Deployment.WindowsInstaller;
using CustomActions.ServiceReference1;
using System.Security.Principal;
using System.DirectoryServices.AccountManagement;
using System.DirectoryServices;
using System.ServiceModel;
using System.Linq;
using System.ServiceModel.Channels;

namespace CustomActions
{
    public class CustomActions
    {
        [CustomAction]
        public static ActionResult AddDeviceCA(Session session)
        {
            session.Log("Begin AddDevice");
            AddDeviceClass tempClass = new AddDeviceClass();
            tempClass.AddDevice();
            return ActionResult.Success;
        }

    }

    public class AddDeviceClass
    {
        public AddDeviceClass()
        {

        }

        public void AddDevice()
        {
            Device d = new Device();

            d.DeviceID = new SecurityIdentifier((byte[])new DirectoryEntry(string.Format("WinNT://{0},Computer", Environment.MachineName)).Children.Cast<DirectoryEntry>().First().InvokeGet("objectSID"), 0).AccountDomainSid.ToString();
            d.DeviceName = Environment.MachineName;
            d.UserID = WindowsIdentity.GetCurrent().User.Value;
            d.UserName = UserPrincipal.FindByIdentity(new PrincipalContext(ContextType.Domain), IdentityType.Sid, d.UserID).DisplayName;
            //d.VM = (Context.Parameters["IsVM"] == "1");

            Binding binding = new WSDualHttpBinding();
            EndpointAddress address = new EndpointAddress("http://192.168.10.153:8081/AFKAPI/AFKHostedService.svc");

            using (ServiceClient c = new ServiceClient(new InstanceContext(this), binding, address))
            {
                try
                {
                    c.AddDevice(d);

                }
                catch
                {
                    //Ignore
                }
            }
        }
    }
}
