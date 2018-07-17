using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration.Install;
using System.DirectoryServices;
using System.DirectoryServices.AccountManagement;
using System.Linq;
using System.Security.Principal;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.ServiceModel.Channels;
using PostInstallClasses.ServiceReference1;
using System.Diagnostics;

namespace PostInstallClasses
{
    [RunInstaller(true)]
    public class Install : Installer, PostInstallClasses.ServiceReference1.IServiceCallback
    {
        public Install()
        {

        }

        public void FinishDataBaseEntry(PostInstallClasses.ServiceReference1.DataBaseEntry entry)
        {
            //Ignore
        }

        public void SendResult(string test)
        {
            //Ignore
        }

        protected override void OnAfterInstall(IDictionary savedState)
        {
            base.OnAfterInstall(savedState);
            //Starts process after install
            Process.Start(new ProcessStartInfo(Context.Parameters["targetdir"]+"AFKApplet.exe"));


        }

        //private void AddDevice()
        //{

        //    Device d = new Device();

        //    d.DeviceID = new SecurityIdentifier((byte[])new DirectoryEntry(string.Format("WinNT://{0},Computer", Environment.MachineName)).Children.Cast<DirectoryEntry>().First().InvokeGet("objectSID"), 0).AccountDomainSid.ToString();
        //    d.DeviceName = Environment.MachineName;
        //    d.UserID = WindowsIdentity.GetCurrent().User.Value;
        //    d.UserName = UserPrincipal.FindByIdentity(new PrincipalContext(ContextType.Domain), IdentityType.Sid, d.UserID).DisplayName;
        //    d.VM = (Context.Parameters["IsVM"] == "1");

        //    Binding binding = new WSDualHttpBinding();
        //    EndpointAddress address = new EndpointAddress("http://192.168.10.153:8081/AFKAPI/AFKHostedService.svc");

        //    using (ServiceClient c = new ServiceClient(new InstanceContext(this), binding, address))
        //    {
        //        if (c.AddDevice(d))
        //        {
        //        }
        //        else
        //        {
        //        }
        //    }
        //}



    }
}
