using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using WebApplication.ServiceReference1;
using System.ServiceModel;

namespace WebApplication
{
    public partial class MainPage : System.Web.UI.Page, IServiceCallback
    {
        ServiceReference1.ServiceClient Proxy;
        public DataTable dt;
        public List<DataBaseEntry> Entries;
        public int startPoint = 0;

        protected void Page_Load(object sender, EventArgs e)
        {
           // MainPage test = new MainPage();
            InstanceContext context = new InstanceContext(this);
            CreatingGrid();
            Proxy = new ServiceReference1.ServiceClient(context);
            Entries = Proxy.GetAllEntries();
            FillGrid();
            PreviousPage.Enabled = false;
        }

        public void CreatingGrid()
        {
            dt = new DataTable();

            dt.Columns.Add("Event Type");
            dt.Columns.Add("User ID");
            dt.Columns.Add("Device ID");
            dt.Columns.Add("Time of Event", typeof(System.DateTime));
            dt.Columns.Add("Automatic");
            dt.Columns.Add("Remote");
            dt.Columns.Add("ETA", typeof(System.TimeSpan));

        }

        public void FillGrid()
        {
            
            for (int i = startPoint; (i < Entries.Count) && (i < (startPoint + 20)); i++)
            {
                DataRow oItem = dt.NewRow();
                oItem[0] = Entries.ElementAt(i).EventType;
                oItem[1] = Entries.ElementAt(i).UserID;
                oItem[2] = Entries.ElementAt(i).DeviceID;
                oItem[3] = Entries.ElementAt(i).TimeOfEvent;
                oItem[4] = Entries.ElementAt(i).AutomaticLock;
                oItem[5] = Entries.ElementAt(i).RemoteAccess;
                oItem[6] = Entries.ElementAt(i).ETA;
                dt.Rows.Add(oItem);
            }
            
            dataGridView.DataSource = dt;
            dataGridView.DataBind();
        }
        
        protected void SearchUser_Click(object sender, EventArgs e)
        {
           /* string UserID = txtUser.Text;
            CreatingGrid();
            ServiceReference1.ServiceClient client = new ServiceReference1.ServiceClient();
            Entries = client.GetEntriesOfUser(UserID);
            FillGrid();*/
        }

        protected void PreviousPage_Click(object sender, EventArgs e)
        {
            if (startPoint > 0)
            {
                startPoint -= 20;
            }
            CreatingGrid();
            FillGrid();
        }

        protected void NextPage_Click(object sender, EventArgs e)
        {
            if (startPoint < Entries.Count)
            {
                startPoint += 20;
            }
            PreviousPage.Enabled = true;
            CreatingGrid();
            FillGrid();
        }

        public void SendResult(string test)
        {
            txtNewEntry.Text = test;
        }

        protected void btnNewEntry_Click(object sender, EventArgs e)
        {
            DataBaseEntry x = new DataBaseEntry();
            x.EventType = "EventType";
            x.UserID = "BensonJ";
            x.DeviceID = "DeviceID";
            x.TimeOfEvent = DateTime.Now;
            x.AutomaticLock = false;
            x.RemoteAccess = false;
            x.ETA = new TimeSpan(1, 20, 0);
            Proxy.AddEntry(x);
           
                //txtNewEntry.Text = Proxy.AddEntry(x);
            
        }
    }
}