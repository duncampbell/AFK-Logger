using AppletTesting.ServiceReference1;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.ServiceModel;
using System.Security.Principal;
using System.DirectoryServices;
using AFKWindowsService.ServiceReference1;

namespace AppletTesting
{
    public partial class AFKApplet : Form, ServiceReference1.IServiceCallback
    {
        string deviceID;
        string userID;

        TimeSpan ETA;
        TimeSpan ETA1;
        TimeSpan ETA2;
        TimeSpan ETA3;
        
        public AFKApplet()
        {
            InitializeComponent();
            deviceID = new SecurityIdentifier((byte[])new DirectoryEntry(string.Format("WinNT://{0},Computer", Environment.MachineName)).Children.Cast<DirectoryEntry>().First().InvokeGet("objectSID"), 0).AccountDomainSid.ToString();
            userID = WindowsIdentity.GetCurrent().User.AccountDomainSid.ToString();

            ETA1 = new TimeSpan(1,0,0);
            ETA2 = new TimeSpan(2,0,0);
            ETA3 = new TimeSpan(3,0,0);
        }

        private void btnETA1_Click(object sender, EventArgs e)
        {
            ETA = ETA1;
            InstanceContext iC = new InstanceContext(this);
            using (ServiceReference1.ServiceClient c = new ServiceReference1.ServiceClient(iC))
            {
                try
                {
                    DataBaseEntry dBE = new DataBaseEntry();
                    dBE.EventType = "SessionLock";
                    dBE.UserID = userID;
                    dBE.DeviceID = deviceID;
                    dBE.TimeOfEvent = DateTime.Now;
                    dBE.AutomaticLock = false;
                    dBE.RemoteAccess = false;
                    dBE.ETA = ETA1;

                    c.AddEntry(dBE);
                }
                catch (Exception)
                {

                    throw;
                }
            }

        }

        private void btnETA2_Click(object sender, EventArgs e)
        {
            ETA = ETA2;
            //try
            //{
            //    InstanceContext iC = new InstanceContext(this);
            //    using (ServiceClient c = new ServiceClient(iC))
            //    {
            //        DataBaseEntry dBE = new DataBaseEntry();
            //        dBE.EventType = "SessionLock";
            //        dBE.UserID = userID;
            //        dBE.DeviceID = deviceID;
            //        dBE.TimeOfEvent = DateTime.Now;
            //        dBE.AutomaticLock = false;
            //        dBE.RemoteAccess = false;
            //        dBE.ETA = ETA2;

            //        await c.AddEntryAsync(dBE);
            //    }

            //}
            //catch (Exception)
            //{

            //    throw;
            //}
        }

        private void btnETA3_Click(object sender, EventArgs e)
        {
            ETA = ETA3;

            //InstanceContext iC = new InstanceContext(this);
            //using (ServiceClient c = new ServiceClient(iC))
            //    try
            //    {
            //        {
            //            DataBaseEntry dBE = new DataBaseEntry();
            //            dBE.EventType = "SessionLock";
            //            dBE.UserID = userID;
            //            dBE.DeviceID = deviceID;
            //            dBE.TimeOfEvent = DateTime.Now;
            //            dBE.AutomaticLock = false;
            //            dBE.RemoteAccess = false;
            //            dBE.ETA = ETA3;

            //            await c.AddEntryAsync(dBE);
            //        }
            //    }
            //    catch (Exception)
            //    {

            //        throw;
            //    }

        }

        //Assigns ETA and UserID to DataBaseEntry and returns it
        public DataBaseEntry FinishDataBaseEntry(DataBaseEntry entry)
        {
            
            if (this.deviceID == entry.DeviceID)
            {
                entry.UserID = this.userID;
                entry.ETA = (ETA != null)? ETA : TimeSpan.Zero;
            }
            return entry;
        }

        void ServiceReference1.IServiceCallback.SendResult(string test)
        {
            throw new NotImplementedException();
        }

        private void btnAddDevice_Click(object sender, EventArgs e)
        {
            Device d = new Device();
            d.DeviceID = deviceID;
            d.DeviceName = Environment.MachineName;
            d.UserID = userID;
            d.UserName = Environment.UserName;
            d.VM = chkVM.Checked;

            InstanceContext iC = new InstanceContext(this);
            using (ServiceReference1.ServiceClient c = new ServiceReference1.ServiceClient(iC))
            {
                MessageBox.Show(c.AddDevice(d).ToString());
            }
        }
    }
}
