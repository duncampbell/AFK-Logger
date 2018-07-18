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
using System.Diagnostics;

namespace CustomActions
{
    public class CustomActions
    {
        [CustomAction]
        public static ActionResult AddDeviceCA(Session session)
        {
            Trace.WriteLine("Device Add Entered");
            session.Log("Begin AddDevice");
            AddDeviceClass tempClass = new AddDeviceClass();
            tempClass.AddDevice();
            return ActionResult.Success;
        }

        [CustomAction]
        public static ActionResult StartServiceCA(Session session)
        {
            return ActionResult.Success;
        }

        [CustomAction]
        public static ActionResult StartAppletCA(Session session)
        { 
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
            Trace.WriteLine("Device Add Entered 2");
            Device d = new Device();

            d.DeviceID = new SecurityIdentifier((byte[])new DirectoryEntry(string.Format("WinNT://{0},Computer", Environment.MachineName)).Children.Cast<DirectoryEntry>().First().InvokeGet("objectSID"), 0).AccountDomainSid.ToString();
            Trace.WriteLine(d.DeviceID);
            d.DeviceName = Environment.MachineName;
            Trace.WriteLine(d.DeviceName);
            d.UserID = WindowsIdentity.GetCurrent().User.Value;
            Trace.WriteLine(d.UserID);
            d.UserName = UserPrincipal.FindByIdentity(new PrincipalContext(ContextType.Domain), IdentityType.Sid, d.UserID).DisplayName;
            Trace.WriteLine(d.UserName);
            //d.VM = (Context.Parameters["IsVM"] == "1");

            Binding binding = new WSDualHttpBinding();
            Trace.WriteLine(binding.ToString());
            EndpointAddress address = new EndpointAddress("http://192.168.10.153:8081/AFKAPI/AFKHostedService.svc");
            Trace.WriteLine(address.ToString());
            try
            {
                Trace.WriteLine("Device Add Entered 2");
                using (ServiceClient c = new ServiceClient(new InstanceContext(this), binding, address))
                {
                    Trace.WriteLine("Device Add Entered 2");
                    try
                    {
                        Trace.WriteLine("Device Add Entered 2");
                        c.AddDevice(d);

                    }
                    catch
                    {
                        //Ignore
                    }
                }
            }
            catch(Exception e)
            {
                Trace.WriteLine(e.Message);
            }

        }
    }
}
