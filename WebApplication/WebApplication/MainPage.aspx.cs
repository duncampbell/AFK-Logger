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

            InstanceContext context = new InstanceContext(this);
            Proxy = new ServiceReference1.ServiceClient(context);
            if (!IsPostBack)
            {
                CreateEmployeeTable();
            }
            
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
                    TimeSpan sinceEvent = (DateTime.Now - employees.ElementAt(i).Time);
                    if (sinceEvent < employees.ElementAt(i).Eta)
                    {
                        oItem[1] = "Expected Back";
                    }else if (sinceEvent < (- new TimeSpan(1,0,0)))
                    {
                        oItem[1] = "Out of Office";
                    }else
                    {
                        oItem[1] = "Expected back, but late";
                    }
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
            Tuple<List<DataBaseEntry>, int> ent;
            switch ((string)ViewState["State"])
            {
                
                case "Normal":
                    ent = Proxy.GetAllEntries((int)ViewState["Index"], (string)ViewState["SortOn"], (string)ViewState["TypeSort"]);
                    ViewState["Entries"] = ent.Item1;
                    int numEntries = ent.Item2;
                    int numPages = (int)Math.Ceiling((double)numEntries / 20);
                    ViewState["PageTotal"] = numPages;
                    populatePageMenu();
                    break;
                case "SearchName":
                    ent = Proxy.GetEntriesOfUser((string)ViewState["UserName"], (int)ViewState["Index"], (string)ViewState["SortOn"], (string)ViewState["TypeSort"]);
                    ViewState["Entries"] = ent.Item1;
                    numEntries = ent.Item2;
                    numPages = (int)Math.Ceiling((double)numEntries / 20);
                    ViewState["PageTotal"] = numPages;
                    populatePageMenu();
                    break;
                case "SearchTime":
                    ent = Proxy.GetEntriesBetween((DateTime)ViewState["StartTime"], (DateTime)ViewState["EndTime"], (int)ViewState["Index"], (string)ViewState["SortOn"], (string)ViewState["TypeSort"]);
                    ViewState["Entries"] = ent.Item1;
                    numEntries = ent.Item2;
                    numPages = (int)Math.Ceiling((double)numEntries / 20);
                    ViewState["PageTotal"] = numPages;
                    populatePageMenu();
                    break;
                case "SearchNameTime":
                    ent = Proxy.GetEntriesBetweenForUser((string)ViewState["UserName"], (DateTime)ViewState["StartTime"], (DateTime)ViewState["EndTime"], (int)ViewState["Index"], (string)ViewState["SortOn"], (string)ViewState["TypeSort"]);
                    ViewState["Entries"] = ent.Item1;
                    numEntries = ent.Item2;
                    numPages = (int)Math.Ceiling((double)numEntries / 20);
                    ViewState["PageTotal"] = numPages;
                    populatePageMenu();
                    break;
            }
            int index = (int)ViewState["Index"];
            int pageNum = (int)((index / 20) + 1);
            CreatingGrid();
            FillGrid();
        }

        public void populatePageMenu()
        {
            ViewState["PageStart"] = (((int)ViewState["Index"] / 100) *5) + 1;
            pageMenu.Items.Clear();
            MenuItem childItm = new MenuItem("<<");
            pageMenu.Items.Add(childItm);
            childItm = new MenuItem("<");
            pageMenu.Items.Add(childItm);
            for (int i = (int)ViewState["PageStart"]; i <= (int)ViewState["PageTotal"] && i < ((int)ViewState["PageStart"] + 5); i++)
            {
                childItm = new MenuItem(i.ToString());
                pageMenu.Items.Add(childItm);
            }
            childItm = new MenuItem(">");
            pageMenu.Items.Add(childItm);
            childItm = new MenuItem(">>");
            pageMenu.Items.Add(childItm);
            if ((int)ViewState["Index"] == 0)
            {
                pageMenu.Items[1].Selectable = false;
            }
            else
            {
                pageMenu.Items[1].Selectable = true;
            }

            List<DataBaseEntry> Entries = (List<DataBaseEntry>)ViewState["Entries"];
            if (Entries.Count < 20)
            {
                int nextMenuItemNum = pageMenu.Items.Count;
                pageMenu.Items[nextMenuItemNum-2].Selectable = false;
            }
            else
            {
                int nextMenuItemNum = pageMenu.Items.Count;
                pageMenu.Items[nextMenuItemNum-2].Selectable = true;
            }
            if (Entries.Count != 0)
            {
                int selected = ((int)ViewState["Index"] / 20) % 5;
               pageMenu.Items[selected + 2].Selected = true;
            }
            if ((int)ViewState["Index"] < 100)
            {
                pageMenu.Items[0].Selectable = false;
            }else
            {
                pageMenu.Items[0].Selectable = true;
            }

            if (((int)ViewState["PageTotal"] - (int)ViewState["PageStart"]+1) < 5 )
            {
                pageMenu.Items[pageMenu.Items.Count-1].Selectable = false;
            }
            else
            {
                pageMenu.Items[pageMenu.Items.Count - 1].Selectable = true;
            }

        }

        public void CreatingGrid()
        {
            dt = new DataTable();
            dt.Columns.Add("User Name");
            dt.Columns.Add("Event Type");
            dt.Columns.Add("Device ID");
            dt.Columns.Add("Time of Event", typeof(System.DateTime));
            dt.Columns.Add("Automatic");
            dt.Columns.Add("Remote");
            dt.Columns.Add("ETA", typeof(System.TimeSpan));

        }

        public void FillGrid()
        {
            List<DataBaseEntry> Entries = (List<DataBaseEntry>)ViewState["Entries"];
            string X = Entries.ElementAt(0).UserName;
            for (int i = 0; i < Entries.Count && i < 20; i++)
            {
                    DataRow oItem = dt.NewRow();
                    oItem[0] = Entries.ElementAt(i).UserName;
                    oItem[1] = Entries.ElementAt(i).EventType;
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
                ViewState["TypeSort"] = "Descending";
                ViewState["SortOn"] = "TimeOfEvent";
                ViewState["State"] = "Normal";
                tableSetUp();
            }else if (userName != "" && startInput == "" && endInput == "")//Search Only UserName
            {
                ViewState["State"] = "SearchName";
                ViewState["UserName"] = userName;
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
                    int hour = Int32.Parse(startTimeHour.Text);
                    start = new DateTime(year, month, day, Int32.Parse(startTimeHour.Text), Int32.Parse(startTimeMin.Text), Int32.Parse(startTimeSec.Text));
                    ViewState["StartTime"] = start;
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
                    int hour = Int32.Parse(startTimeHour.Text);
                    end = new DateTime(year, month, day, Int32.Parse(endTimeHour.Text), Int32.Parse(endTimeMin.Text), Int32.Parse(endTimeSec.Text));
                    ViewState["EndTime"] = end;
                }
                catch{
                    searchable = false;
                    endTimeLabel.Text = "Incorrect Format";
                }
                if (searchable == true)
                {
                    ViewState["State"] = "SearchTime";
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
                    ViewState["StartTime"] = start;
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
                    ViewState["EndTime"] = end;
                }
                catch
                {
                    searchable = false;
                    endTimeLabel.Text = "Incorrect Format";
                }
                if (searchable == true)
                {
                    ViewState["UserName"] = userName;
                    ViewState["State"] = "SearchNameTime";
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

            if (e.SortExpression.Equals("User Name"))
            {
                ViewState["SortOn"] = "UserName";
            }

            if (e.SortExpression.Equals("Event Type")){
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
            if (e.Item.Value == "1")
            {
                ViewState["State"] = "Normal";
                ViewState["Index"] = 0;
                this.StatusMenu.Items[0].Selected = true;
                ViewState["SortOn"] = "TimeOfEvent";
                ViewState["TypeSort"] = "Descending";
                Tuple<List<DataBaseEntry>, int> ent = Proxy.GetAllEntries((int)ViewState["Index"], (string)ViewState["SortOn"], (string)ViewState["TypeSort"]);
                ViewState["Entries"] = ent.Item1;
                int numEntries = ent.Item2;
                int numPages = (int)Math.Ceiling((double)numEntries / 20);
                ViewState["PageTotal"] = numPages;
                ViewState["PageStart"] = 1;
                tableSetUp();
            }

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
        
        protected void pageMenu_MenuItemClick(object sender, MenuEventArgs e)
        {
            if (e.Item.Value == "<")
            {
                if ((int)ViewState["Index"] != 0)
                {
                    ViewState["Index"] = (int)ViewState["Index"] - 20;
                }

            }else if (e.Item.Value == ">")
            {
                ViewState["Index"] = (int)ViewState["Index"] + 20;
            }
            else if (e.Item.Value == ">>")
            {
                ViewState["PageStart"] = (int)ViewState["PageStart"] + 5;
                int ind = ((int)ViewState["PageStart"] - 1) * 20;
                ViewState["Index"] = ind;
            }
            else if (e.Item.Value == "<<")
            {
                    ViewState["PageStart"] = (int)ViewState["PageStart"] - 5;
                    ViewState["Index"] = ((int)ViewState["PageStart"] - 1) * 20;
            }
            else
            {
                int pageNum = Int32.Parse(e.Item.Value);
                ViewState["Index"] = (pageNum-1) * 20;
            }
            tableSetUp();
        }
    }
}