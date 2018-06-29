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

namespace AppletTesting
{
    public partial class Form1 : Form
    {
        string deviceID;
        string userID;

        TimeSpan ETA1;
        TimeSpan ETA2;
        TimeSpan ETA3;
        
        public Form1()
        {
            InitializeComponent();
            deviceID = System.Environment.MachineName;
            userID = System.Environment.UserName;

            ETA1 = new TimeSpan(1);
            ETA2 = new TimeSpan(2);
            ETA2 = new TimeSpan(3);
        }

        private async void btnETA1_Click(object sender, EventArgs e)
        {
            using(ServiceClient c = new ServiceClient())
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

        }

        private async void btnETA2_Click(object sender, EventArgs e)
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

        private async void btnETA3_Click(object sender, EventArgs e)
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
                dBE.ETA = ETA3;

                await c.AddEntryAsync(dBE);
            }

        }
    }
}
