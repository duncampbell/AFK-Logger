using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.ServiceModel;
using System.Security.Principal;
using System.DirectoryServices;
using Microsoft.Win32;
using System.Runtime.InteropServices;
using AFKApplet.ServiceReference1;
using System.DirectoryServices.AccountManagement;

namespace AFKApplet
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single, ConcurrencyMode = ConcurrencyMode.Multiple)]
    public partial class AFKAppletForm : Form, IServiceCallback
    {
        #region Variable Declaration

        KeyboardHook hook = new KeyboardHook();

        string deviceID;
        string machineName;
        string userID;
        string userName;
        string sessionID;
        InstanceContext iC;
        ServiceClient c;

        [DllImport("user32")]
        public static extern void LockWorkStation();

        TimeSpan ETA;
        #endregion

        public AFKAppletForm()
        {
            InitializeComponent();
            deviceID = new SecurityIdentifier((byte[])new DirectoryEntry(string.Format("WinNT://{0},Computer", Environment.MachineName)).Children.Cast<DirectoryEntry>().First().InvokeGet("objectSID"), 0).AccountDomainSid.ToString();
            machineName = Environment.MachineName;
            userID = WindowsIdentity.GetCurrent().User.Value;
            userName = UserPrincipal.FindByIdentity(new PrincipalContext(ContextType.Domain), IdentityType.Sid, userID).DisplayName;
            sessionID = System.Diagnostics.Process.GetCurrentProcess().SessionId.ToString();


            iC = new InstanceContext(this);
            c = new ServiceReference1.ServiceClient(iC);
            c.RegisterClient(deviceID, false);

            LoadETAPrefs();

            hook.KeyPressed += new EventHandler<KeyPressedEventArgs>(hook_KeyPressed);
            hook.RegisterHotKey(global::AFKApplet.ModifierKeys.Win, Keys.NumPad1);
            hook.RegisterHotKey(global::AFKApplet.ModifierKeys.Win, Keys.NumPad2);
            hook.RegisterHotKey(global::AFKApplet.ModifierKeys.Win, Keys.NumPad3);

            //List<Employee> testList = c.GetEntriesForAlice();
        }

        #region Button Methods
        //Basically converts hotkey to button press
        void hook_KeyPressed(object sender, KeyPressedEventArgs e)
        {
            allETABtn_Click(new Button() { Text = "ETA " + e.Key.ToString().Substring(e.Key.ToString().Length-1)}, new EventArgs());
        }

        //Called when any of the ETA buttons are clicked or when hotkeys are used (terrible, I know)
        private async void allETABtn_Click(object sender, EventArgs e)
        {
            //Determine ETA
            switch (((Button)sender).Text)
            {
                case "ETA 1":
                    ETA = new TimeSpan(0, int.Parse(txtETA1.Text), 0);
                    break;
                case "ETA 2":
                    ETA = new TimeSpan(0, int.Parse(txtETA2.Text), 0);
                    break;
                case "ETA 3":
                    ETA = new TimeSpan(0, int.Parse(txtETA3.Text), 0);
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
                dBE.UserName = userName;
                dBE.DeviceID = deviceID;
                dBE.MachineName = machineName;
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

                MessageBox.Show("Program encountered the following error: " + ex.Message, "Progam Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            //Lock machine
            LockWorkStation();
        }

        //Add device manually
        //TODO: remove from form and place in installer
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
                    MessageBox.Show("Device Added Succesfully" + "\nDevice ID: " + deviceID + "\nUserID: " + userID, "Device Successfully Added", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Device not added, either due to an error or because it already exists", "Device Not Added", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        //Display ETA time textboxes
        private void btnSet_Click(object sender, EventArgs e)
        {
            if (!splitContainer1.Panel2Collapsed) { SaveETAPrefs(); }
            splitContainer1.Panel2Collapsed = splitContainer1.Panel2Collapsed ? false : true;
            Size = splitContainer1.Panel2Collapsed ? new Size(278, 111) : new Size(278, 170);
        }

        //TODO: remove for release
        private void button1_Click(object sender, EventArgs e)
        {
            c.UpdateADUsernames();
            //    try
            //    {
            //        //Create device
            //        DataBaseEntry dBE = new DataBaseEntry();
            //        dBE.EventType = "SessionUnlock";
            //        dBE.UserID = userID;
            //        dBE.DeviceID = deviceID;
            //        dBE.TimeOfEvent = DateTime.Now;
            //        dBE.AutomaticLock = false;
            //        dBE.RemoteAccess = false;
            //        dBE.ETA = TimeSpan.Zero;


            //        //Send to API
            //        await c.AddAppletEntryAsync(dBE);
            //        //recentEntry = true;
            //    }
            //    catch (Exception ex)
            //    {

            //        MessageBox.Show("Program encountered the following error: " + ex.Message, "Progam Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    }
        }


        #endregion

        #region Notification Icon Stuf

        //Hides and shows form based on system tray icon click
        private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            this.Show();
            this.WindowState = FormWindowState.Normal;
            this.Visible = true;

        }

        private void AFKApplet_Resize(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Minimized) { this.Hide(); }
        }

        private void AFKAppletForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            Hide();
            notifyIcon1.ShowBalloonTip(3);
        }
               private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            //TODO: add website url once finalised
            System.Diagnostics.Process.Start("http://Google.com");
        }
        #endregion

        #region Registry Methods
        //Adds applet to startup registry key
        //TODO: remove from form, add to installer
        /*
        private void SetStartup()
        {
            RegistryKey rk = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);
            rk.SetValue("AFKApplet", Application.ExecutablePath);
        }*/

        //Saves ETA preferences
        private bool SaveETAPrefs()
        {
            bool success = false;

            try
            {
                RegistryKey k = Registry.CurrentUser.CreateSubKey(@"Software\AFKLogger");
                k.SetValue("ETA1",txtETA1.Text);
                k.SetValue("ETA2", txtETA2.Text);
                k.SetValue("ETA3", txtETA3.Text);
                success = true;
            }
            catch
            {
                MessageBox.Show("Failed to store ETA preferences in registry.", "Save Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return success;
            }


            return success;
        }

        //Attempts to load ETA preferences from registry. On failure, inserts default values
        private bool LoadETAPrefs()
        {
            bool success = false;
            try
            {
                RegistryKey k = Registry.CurrentUser.OpenSubKey(@"SOFTWARE\\AFKLogger");
                txtETA1.Text = k.GetValue("ETA1").ToString();
                txtETA2.Text = k.GetValue("ETA2").ToString();
                txtETA3.Text = k.GetValue("ETA3").ToString();
                success = true;
            }
            catch
            {
                txtETA1.Text = "15";
                txtETA2.Text = "45";
                txtETA3.Text = "90";
                MessageBox.Show("Failed to load ETA preferences from registry.", "Save Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return success;
        }
        #endregion

        #region Service Callback methods
        //Assigns ETA and UserID to DataBaseEntry and returns it
        public void FinishDataBaseEntry(DataBaseEntry entry)
        {
            //Confirms deviceID is correct and prevents duplicate entry
            if (this.deviceID == entry.DeviceID && sessionID == entry.SessionID)
            {
                entry.UserID = this.userID;
                entry.UserName = userName;
            }
            c.AddAppletEntryAsync(entry);

        }

        //Ignored, used by web app
        public void SendResult(string test)
        {

        }

        //Ignored, used by web app callback
        public void RefreshTable(List<Employee> employees)
        {
            //Ignore
        }


        #endregion


    }

    #region Keyboard Hook Classes
    public sealed class KeyboardHook : IDisposable
    {

        [DllImport("user32.dll")]
        private static extern bool RegisterHotKey(IntPtr hWnd, int id, uint fsModifiers, uint vk);
        [DllImport("user32.dll")]
        private static extern bool UnregisterHotkey(IntPtr hWnd, int id);

        private class Window : NativeWindow, IDisposable
        {
            private static int WM_HOTKEY = 0x0312;

            public Window()
            {
                this.CreateHandle(new CreateParams());
            }

            protected override void WndProc(ref Message m)
            {
                base.WndProc(ref m);

                if (m.Msg == WM_HOTKEY)
                {
                    Keys key = (Keys)(((int)m.LParam >> 16) & 0xFFFF);
                    ModifierKeys modifier = (ModifierKeys)((int)m.LParam & 0xFFFF);

                    KeyPressed?.Invoke(this, new KeyPressedEventArgs(modifier, key));
                }
            }
            public event EventHandler<KeyPressedEventArgs> KeyPressed;
            public void Dispose()
            {
                this.DestroyHandle();
            }

        }

        private Window _window = new Window();
        private int _currentId;

        public KeyboardHook()
        {
            _window.KeyPressed += delegate (object sender, KeyPressedEventArgs args)
            {
                KeyPressed?.Invoke(this, args);
            };
        }
        public void RegisterHotKey(ModifierKeys modifier, Keys key)
        {
            _currentId++;
            //var test = (uint)key;
            if (!RegisterHotKey(_window.Handle, _currentId, (uint)modifier, (uint)key))
            {
                throw new InvalidOperationException("Couldn't register the hot key.");
            }
        }
        public event EventHandler<KeyPressedEventArgs> KeyPressed;

        public void Dispose()
        {
            for (int i = _currentId; i > 0; i--)
            {
                UnregisterHotkey(_window.Handle, i);
            }
            _window.Dispose();
        }
    }

    public class KeyPressedEventArgs : EventArgs
    {
        private ModifierKeys _modifier;
        private Keys _key;

        internal KeyPressedEventArgs(ModifierKeys modifier, Keys key)
        {
            _modifier = modifier;
            _key = key;
        }

        public ModifierKeys Modifier
        {
            get { return _modifier; }
        }
        public Keys Key
        {
            get { return _key; }
        }
    }

    [Flags]
    public enum ModifierKeys : uint
    {
        Alt=1,
        Control = 2,
        Shift = 4,
        Win = 8
    }

    #endregion
}
