using AppletTesting.ServiceReference1;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.DirectoryServices;
using System.Drawing;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace AppletTesting
{
    public partial class AFKApplet : Form
    {
        string deviceID;
        string userID;

        TimeSpan ETA1;
        TimeSpan ETA2;
        TimeSpan ETA3;
        
        public AFKApplet()
        {
            InitializeComponent();
            deviceID = new SecurityIdentifier((byte[])new DirectoryEntry(string.Format("WinNT://{0},Computer", Environment.MachineName)).Children.Cast<DirectoryEntry>().First().InvokeGet("objectSID"), 0).AccountDomainSid.ToString();
            userID = WindowsIdentity.GetCurrent().User.AccountDomainSid.ToString();

            ETA1 = new TimeSpan();
            ETA2 = new TimeSpan();
            ETA3 = new TimeSpan();
        }

        private async void btnETA1_Click(object sender, EventArgs e)
        {
            using(ServiceClient c = new ServiceClient())
            {
                try
                {
                    DataBaseEntry dBE = new DataBaseEntry();
                    dBE.EventType = "EventType";
                    dBE.UserID = userID;
                    dBE.DeviceID = deviceID;
                    dBE.TimeOfEvent = DateTime.Now;
                    dBE.AutomaticLock = false;
                    dBE.RemoteAccess = false;
                    dBE.ETA = ETA1;

                    await c.AddEntryAsync(dBE);
                }
                catch (Exception)
                {

                    throw;
                }
            }

        }

        private async void btnETA2_Click(object sender, EventArgs e)
        {
            try
            {
                using (ServiceClient c = new ServiceClient())
                {
                    DataBaseEntry dBE = new DataBaseEntry();
                    dBE.EventType = "EventType";
                    dBE.UserID = userID;
                    dBE.DeviceID = deviceID;
                    dBE.TimeOfEvent = DateTime.Now;
                    dBE.AutomaticLock = false;
                    dBE.RemoteAccess = false;
                    dBE.ETA = ETA2;

                    await c.AddEntryAsync(dBE);
                }

            }
            catch (Exception)
            {

                throw;
            }
        }

        private async void btnETA3_Click(object sender, EventArgs e)
        {
            using (ServiceClient c = new ServiceClient())
                try
                {
                    {
                        DataBaseEntry dBE = new DataBaseEntry();
                        dBE.EventType = "EventType";
                        dBE.UserID = userID;
                        dBE.DeviceID = deviceID;
                        dBE.TimeOfEvent = DateTime.Now;
                        dBE.AutomaticLock = false;
                        dBE.RemoteAccess = false;
                        dBE.ETA = ETA3;

                        await c.AddEntryAsync(dBE);
                    }
                }
                catch (Exception)
                {

                    throw;
                }

        }

        private async void btnAddDevice_Click(object sender, EventArgs e)
        {
            using (ServiceClient c = new ServiceClient())
            {
                Device device = new Device();
                device.DeviceID = deviceID;
                device.DeviceName = Environment.MachineName;
                device.UserID = userID;
                device.UserName = Environment.UserName;
                device.VM = chkVM.Checked;

                await c.AddDeviceAsync(device);
            }
        }
    }
}
