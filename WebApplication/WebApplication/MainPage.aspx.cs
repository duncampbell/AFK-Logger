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
        DataTable dt;
        //List<DataBaseEntry> Entries;
        Dictionary<string, int> months = new Dictionary<string, int>() { { "Jan", 1 }, { "Feb", 2 }, { "Mar", 3 }, { "Apr", 4 }, { "May", 5 }, { "Jun", 6 }, { "Jul", 7 }, { "Aug", 8 }, { "Sep", 9 }, { "Oct", 10 }, { "Nov", 11 }, { "Dec", 12 } };
        List<Employee> employees;

        protected void Page_Load(object sender, EventArgs e)
        {
            // MainPage test = new MainPage();
            InstanceContext context = new InstanceContext(this);
            Proxy = new ServiceReference1.ServiceClient(context);
            
            CreateEmployeeTable();
            
            if (!IsPostBack)
            {
                ViewState["Index"] = 0;
                this.StatusMenu.Items[0].Selected = true;
                ViewState["SortOn"] = "TimeOfEvent";
                ViewState["TypeSort"] = "Descending";
                ViewState["Entries"] = Proxy.GetAllEntries((int)ViewState["Index"], (string)ViewState["SortOn"], (string)ViewState["TypeSort"]);
            }
            if ((int)ViewState["Index"] == 0)
            {
                prevBtn.Enabled = false;
            }else
            {
                prevBtn.Enabled = true;
            }
            List<DataBaseEntry> Entries = (List<DataBaseEntry>)ViewState["Entries"];
            if (Entries.Count < 20)
            {
                prevBtn.Enabled = false;
                nextBtn.Enabled = false;
            }
            tableSetUp();
        }

        public void CreateEmployeeTable()
        {
            employees = Proxy.GetEntriesForAlice();
            DataTable emp = new DataTable();
            emp.Columns.Add("Name");
            emp.Columns.Add("Status");
            emp.Columns.Add("Time of Event", typeof(System.DateTime));
            emp.Columns.Add("ETA", typeof(System.TimeSpan));
           

            for (int i = 0; i < employees.Count; i++)
            {
                DataRow oItem = emp.NewRow();
                oItem[0] = employees.ElementAt(i).Name;
                if (employees.ElementAt(i).AtDesk)
                {
                    oItem[1] = "At Desk";
                }
                else
                {
                    oItem[1] = "Not At Desk";
                }
                
                oItem[2] = employees.ElementAt(i).Time;
                oItem[3] = employees.ElementAt(i).Eta;
                emp.Rows.Add(oItem);
            }
            employeeGrid.DataSource = emp;
            employeeGrid.DataBind();
        }

        public void tableSetUp()
        {
            if ((int)ViewState["Index"] == 0)
            {
                prevBtn.Enabled = false;
            }
            else
            {
                prevBtn.Enabled = true;
            }
            List<DataBaseEntry> Entries = (List<DataBaseEntry>)ViewState["Entries"];
            if (Entries.Count < 20)
            {
                prevBtn.Enabled = false;
                nextBtn.Enabled = false;
                prevBtn.Visible = false;
                nextBtn.Visible = false;
            }
            else
            {
                nextBtn.Enabled = true;
                prevBtn.Visible = true;
                nextBtn.Visible = true;
            }
            CreatingGrid();
            FillGrid();
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
            List<DataBaseEntry> Entries = (List<DataBaseEntry>)ViewState["Entries"];
            for (int i = 0; i < Entries.Count && i < 20; i++)
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
        
        public void SendResult(string test)
        {
            //Ignore
        }

        protected void SearchUser_Click(object sender, EventArgs e)
        {
            ViewState["Index"] = 0;
            startTimeLabel.Text = "";
            endTimeLabel.Text = "";
            string startInput = txtStartTime.Text;
            string endInput = txtEndTime.Text;
            string userName = txtUser.Text;
            DateTime start = new DateTime();
            DateTime end = new DateTime();

            if (userName == "" && startInput == "" && endInput == "")//Search Blank
            {
                ViewState["Entries"] = Proxy.GetAllEntries((int)ViewState["Index"], (string)ViewState["SortOn"], (string)ViewState["TypeSort"]);
                tableSetUp();
            }else if (userName != "" && startInput == "" && endInput == "")//Search Only UserName
            {
                ViewState["Entries"] = Proxy.GetEntriesOfUser(userName, (int)ViewState["Index"], (string)ViewState["SortOn"], (string)ViewState["TypeSort"]);
                tableSetUp();
            }else if (userName == "" && (startInput != "" || endInput != ""))//Search Only Time
            {
                bool searchable = true;
                try
                {
                    string[] tokens = startInput.Split(' ');
                    int day = Int32.Parse(tokens[2]);
                    int month = months[tokens[1]];
                    int year = Int32.Parse(tokens[3]);
                    start = new DateTime(year, month, day, Int32.Parse(startTimeHour.Text), Int32.Parse(startTimeMin.Text), Int32.Parse(startTimeSec.Text));
                }
                catch
                {
                    searchable = false;
                    startTimeLabel.Text = "Incorrect Format";
                }
                try
                {
                    string[] tokens = endInput.Split(' ');
                    int day = Int32.Parse(tokens[2]);
                    int month = months[tokens[1]];
                    int year = Int32.Parse(tokens[3]);
                    end = new DateTime(year, month, day, Int32.Parse(startTimeHour.Text), Int32.Parse(startTimeMin.Text), Int32.Parse(startTimeSec.Text));
                }
                catch{
                    searchable = false;
                    endTimeLabel.Text = "Incorrect Format";
                }
                if (searchable == true)
                {
                    ViewState["Entries"] = Proxy.GetEntriesBetween(start,end, (int)ViewState["Index"], (string)ViewState["SortOn"], (string)ViewState["TypeSort"]);
                    tableSetUp();
                }
            }
            else if (userName != "" && (startInput != "" || endInput != ""))//Search Time and UserName
            {
                bool searchable = true;
                try
                {
                    string[] tokens = startInput.Split(' ');
                    int day = Int32.Parse(tokens[2]);
                    int month = months[tokens[1]];
                    int year = Int32.Parse(tokens[3]);
                    start = new DateTime(year, month, day, Int32.Parse(startTimeHour.Text), Int32.Parse(startTimeMin.Text), Int32.Parse(startTimeSec.Text));
                } catch
                {
                    searchable = false;
                    startTimeLabel.Text = "Incorrect Format";
                }

                try
                {
                    string[] tokens = endInput.Split(' ');
                    int day = Int32.Parse(tokens[2]);
                    int month = months[tokens[1]];
                    int year = Int32.Parse(tokens[3]);
                    end = new DateTime(year, month, day, Int32.Parse(endTimeHour.Text), Int32.Parse(endTimeMin.Text), Int32.Parse(endTimeSec.Text));
                }catch
                {
                    searchable = false;
                    endTimeLabel.Text = "Incorrect Format";
                }
                if (searchable == true)
                {
                    ViewState["Entries"] = Proxy.GetEntriesBetweenForUser(userName, start, end, (int)ViewState["Index"], (string)ViewState["SortOn"], (string)ViewState["TypeSort"]);
                    tableSetUp();
                }
            }


        }
        
        protected void gridView_Sorting(object sender, GridViewSortEventArgs e)
        {
            if(ViewState["TypeSort"].ToString().Equals("Ascending"))
            {
                ViewState["TypeSort"] = "Descending";
            }else { 
                ViewState["TypeSort"] = "Ascending";
            }

            if(e.SortExpression.Equals("Event Type")){
                ViewState["SortOn"] = "EventType";
            }

            if (e.SortExpression.Equals("User ID"))
            {
                ViewState["SortOn"] = "UserID";
            }

            if (e.SortExpression.Equals("Device ID"))
            {
                ViewState["SortOn"] = "DeviceID";
            }

            if (e.SortExpression.Equals("Time of Event"))
            {
                ViewState["SortOn"] = "TimeOfEvent";
            }

            if (e.SortExpression.Equals("Automatic"))
            {
                ViewState["SortOn"] = "AutomaticLock";
            }

            if (e.SortExpression.Equals("Remote"))
            {
                ViewState["SortOn"] = "RemoteAccess";
            }

            if (e.SortExpression.Equals("ETA"))
            {
                ViewState["SortOn"] = "ETA";
            }
            
            tableSetUp();
        }

        protected void StatusMenu_MenuItemClick(object sender, MenuEventArgs e)
        {
            
            int index = Int32.Parse(e.Item.Value);
            PageNavigation.ActiveViewIndex = index;
        }

        public void FinishDataBaseEntry(DataBaseEntry entry)
        {
            //Ignore
        }

        protected void UpdateTimer_Tick(object sender, EventArgs e)
        {
            CreateEmployeeTable();
        }

        protected void nextBtn_Click(object sender, EventArgs e)
        {
            ViewState["Index"] = (int)ViewState["Index"] + 20;
            tableSetUp();
        }

        protected void prevBtn_Click(object sender, EventArgs e)
        {
            ViewState["Index"] = (int)ViewState["Index"] - 20;
            tableSetUp();
        }
    }
}