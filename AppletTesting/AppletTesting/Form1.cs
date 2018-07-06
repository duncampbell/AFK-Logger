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
using System.Diagnostics;

namespace AppletTesting
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single, ConcurrencyMode = ConcurrencyMode.Multiple)]
    public partial class AFKApplet : Form, ServiceReference1.IServiceCallback
    {
        string deviceID;
        string userID;
        InstanceContext iC;
        ServiceReference1.ServiceClient c;

        bool recentEntry = false;

        TimeSpan ETA;
        TimeSpan ETA1;
        TimeSpan ETA2;
        TimeSpan ETA3;
        
        public AFKApplet()
        {
            InitializeComponent();
            deviceID = new SecurityIdentifier((byte[])new DirectoryEntry(string.Format("WinNT://{0},Computer", Environment.MachineName)).Children.Cast<DirectoryEntry>().First().InvokeGet("objectSID"), 0).AccountDomainSid.ToString();
            userID = WindowsIdentity.GetCurrent().User.AccountDomainSid.ToString();

            iC = new InstanceContext(this);
            c = new ServiceReference1.ServiceClient(iC);
            c.RegisterClient(deviceID, false);



            ETA1 = new TimeSpan(1,0,0);
            ETA2 = new TimeSpan(2,0,0);
            ETA3 = new TimeSpan(3,0,0);
        }

        //Assigns ETA and UserID to DataBaseEntry and returns it
        public  void FinishDataBaseEntry(DataBaseEntry entry)
        {
            //Confirms deviceID is correct and prevents duplicate entry
            if (this.deviceID == entry.DeviceID && !recentEntry)
            {
                entry.UserID = this.userID;
                entry.ETA = (ETA != null) ? ETA : TimeSpan.Zero;
                recentEntry = false;
            }
            c.AddAppletEntryAsync(entry);

        }

        void ServiceReference1.IServiceCallback.SendResult(string test)
        {
            
        }

        private async void allETABtn_Click(object sender, EventArgs e)
        {
            //Determine ETA
            switch (((Button)sender).Text)
            {
                case "ETA 1":
                    ETA = ETA1;
                    break;
                case "ETA 2":
                    ETA = ETA2;
                    break;
                case "ETA 3":
                    ETA = ETA3;
                    break;
                default:
                    //TO DO: Think of best default
                    break;
            }


            //Create device and send to API
            try
            {
                //Create device
                DataBaseEntry dBE = new DataBaseEntry();
                dBE.EventType = "SessionLock";
                dBE.UserID = userID;
                dBE.DeviceID = deviceID;
                dBE.TimeOfEvent = DateTime.Now;
                dBE.AutomaticLock = false;
                dBE.RemoteAccess = false;
                dBE.ETA = ETA;


                //Send to API
                await c.AddAppletEntryAsync(dBE);
                //recentEntry = true;
            }
            catch (Exception ex)
            {

                MessageBox.Show("Program encountered the following error: " + ex.Message,"Progam Error", MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
            //TODO: add lock method
        }

        private void btnAddDevice_Click(object sender, EventArgs e)
        {
            Device d = new Device();
            d.DeviceID = deviceID;
            d.DeviceName = Environment.MachineName;
            d.UserID = userID;
            d.UserName = Environment.UserName;
            d.VM = chkVM.Checked;

            using (ServiceReference1.ServiceClient c = new ServiceReference1.ServiceClient(iC))
            {
                if (c.AddDevice(d))
                {
                    MessageBox.Show("Device Added Succesfully" + "\nDevice ID: " + deviceID + "\nUserID: " + userID,"Device Successfully Added", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Device not added, either due to an error or because it already exists","Device Not Added",MessageBoxButtons.OK,MessageBoxIcon.Error);
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            splitContainer1.Panel1Collapsed = true;
        }

        public void RefreshTable(List<Employee> employees)
        {
            //Ignore
        }
    }
}
