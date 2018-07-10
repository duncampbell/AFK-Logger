using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using WebApplication.ServiceReference1;
using System.ServiceModel;
using System.Text;
using System.IO;
using System.Security;
namespace WebApplication
{
    public partial class MainPage : System.Web.UI.Page, IServiceCallback
    {
        ServiceReference1.ServiceClient Proxy;
        DataTable dt;
        DataTable emp;
        //List<DataBaseEntry> Entries;
        Dictionary<string, int> months = new Dictionary<string, int>() { { "Jan", 1 }, { "Feb", 2 }, { "Mar", 3 }, { "Apr", 4 }, { "May", 5 }, { "Jun", 6 }, { "Jul", 7 }, { "Aug", 8 }, { "Sep", 9 }, { "Oct", 10 }, { "Nov", 11 }, { "Dec", 12 } };
        List<Employee> employees;

        protected void Page_Load(object sender, EventArgs e)
        {
            InstanceContext context = new InstanceContext(this);
            Proxy = new ServiceReference1.ServiceClient(context);
            if (!IsPostBack)
            {
                ViewState["Employees"] = Proxy.GetEntriesForAlice();
                CreateEmployeeTable();
            }

        }

        public void CreateEmployeeTable()
        {
            emp = new DataTable();
            emp.Columns.Add("Name");
            emp.Columns.Add("Status");
            emp.Columns.Add("Time of Event", typeof(System.DateTime));
            emp.Columns.Add("ETA");
            TimeSpan remaining;
            employees = (List<Employee>)ViewState["Employees"];
            for (int i = 0; i < employees.Count; i++)
            {
                DataRow oItem = emp.NewRow();
                remaining = remainingTime(employees.ElementAt(i));
                oItem[0] = employees.ElementAt(i).Name;
                if (employees.ElementAt(i).AtDesk)
                {
                    oItem[1] = "At Desk";
                    remaining = new TimeSpan(0, 0, 0);
                }
                else
                {
                    if (remaining > new TimeSpan(0, 0, 0))
                    {
                        oItem[1] = "Expected Back";
                    }
                    else if (remaining < (-new TimeSpan(1, 0, 0)))
                    {
                        oItem[1] = "Out of Office";
                        remaining = new TimeSpan(0, 0, 0);
                    }
                    else
                    {
                        oItem[1] = "Expected back, but late";
                        remaining = new TimeSpan(0, 0, 0);
                    }
                }

                oItem[2] = employees.ElementAt(i).Time;
                oItem[3] = string.Format("{0:00}:{1:00}:{2:00}", (int)remaining.TotalHours,remaining.Minutes,remaining.Seconds); 
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
            if (((List<DataBaseEntry>)ViewState["Entries"]).Count != 0)
            {
                pageMenu.Visible = true;
                exportAllBtn.Visible = true;
                exportPageBtn.Visible = true;
                ViewState["PageStart"] = (((int)ViewState["Index"] / 100) * 5) + 1;
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
                if (Entries.Count < 20 || ((int)ViewState["PageTotal"] == ((int)ViewState["Index"] / 20)+1))
                {
                    int nextMenuItemNum = pageMenu.Items.Count;
                    pageMenu.Items[nextMenuItemNum - 2].Selectable = false;
                }
                else
                {
                    int nextMenuItemNum = pageMenu.Items.Count;
                    pageMenu.Items[nextMenuItemNum - 2].Selectable = true;
                }
                if (Entries.Count != 0)
                {
                    int selected = ((int)ViewState["Index"] / 20) % 5;
                    pageMenu.Items[selected + 2].Selected = true;
                }
                if ((int)ViewState["Index"] < 100)
                {
                    pageMenu.Items[0].Selectable = false;
                }
                else
                {
                    pageMenu.Items[0].Selectable = true;
                }

                if (((int)ViewState["PageTotal"] - (int)ViewState["PageStart"] + 1) <= 5)
                {
                    pageMenu.Items[pageMenu.Items.Count - 1].Selectable = false;
                }
                else
                {
                    pageMenu.Items[pageMenu.Items.Count - 1].Selectable = true;
                }

            }else
            {
                pageMenu.Visible = false;
                exportAllBtn.Visible = false;
                exportPageBtn.Visible = false;
            }
        }

        public void CreatingGrid()
        {
            dt = new DataTable();
            dt.Columns.Add("User Name");
            dt.Columns.Add("Event Type");
            dt.Columns.Add("Machine Name");
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
                    oItem[0] = Entries.ElementAt(i).UserName;
                    oItem[1] = Entries.ElementAt(i).EventType;
                    oItem[2] = Entries.ElementAt(i).MachineName;
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
            ViewState["Employees"] = Proxy.GetEntriesForAlice();
            CreateEmployeeTable();
        }

        protected void etaTimer_Tick(object sender, EventArgs e)
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

        public TimeSpan remainingTime(Employee em)
        {
            TimeSpan remaining = em.Eta - (DateTime.Now - em.Time);
            return remaining;
        }
        
        protected void ExportPage_Click(object sender, EventArgs e)
        {
            List<DataBaseEntry> ent = new List<DataBaseEntry>();
            switch ((string)ViewState["State"])
            {

                case "Normal":
                    ent = Proxy.GetAllEntries((int)ViewState["Index"], (string)ViewState["SortOn"], (string)ViewState["TypeSort"]).Item1;
                    break;
                case "SearchName":
                    ent = Proxy.GetEntriesOfUser((string)ViewState["UserName"], (int)ViewState["Index"], (string)ViewState["SortOn"], (string)ViewState["TypeSort"]).Item1;
                    break;
                case "SearchTime":
                    ent = Proxy.GetEntriesBetween((DateTime)ViewState["StartTime"], (DateTime)ViewState["EndTime"], (int)ViewState["Index"], (string)ViewState["SortOn"], (string)ViewState["TypeSort"]).Item1;
                    break;
                case "SearchNameTime":
                    ent = Proxy.GetEntriesBetweenForUser((string)ViewState["UserName"], (DateTime)ViewState["StartTime"], (DateTime)ViewState["EndTime"], (int)ViewState["Index"], (string)ViewState["SortOn"], (string)ViewState["TypeSort"]).Item1;
                    break;
            }
            
            var sb = new StringBuilder();
            foreach (var data in ent)
            {
                sb.AppendLine(data.UserName + "," + data.EventType + "," +data.UserID+ ", "  +data.DeviceID + ", " + data.TimeOfEvent + ", " + data.AutomaticLock + ", " + data.RemoteAccess + ", " + data.ETA);
            }
            //File.WriteAllText("C:/Users/Public/Documents", sb.ToString());
            string FilePath = Server.MapPath("~/");
            string FileName = "SessionLocks.csv";

            // Creates the file on server
            File.WriteAllText(FilePath + FileName, sb.ToString());
            Response.ContentType = "application/octet-stream";
            Response.AppendHeader("content-disposition", "attachment;filename=" + FileName);
            Response.TransmitFile(FilePath + FileName);
            Response.End();
        }

        protected void ExportAll_Click(object sender, EventArgs e)
        {
            if ((int)ViewState["PageTotal"] < 100)
            {
                List<DataBaseEntry> ent = new List<DataBaseEntry>();
                switch ((string)ViewState["State"])
                {

                    case "Normal":
                        for (int i = 0; i < (int)ViewState["PageTotal"]; i++)
                        {
                            ent.AddRange(Proxy.GetAllEntries((i * 20), (string)ViewState["SortOn"], (string)ViewState["TypeSort"]).Item1);
                        }
                        break;
                    case "SearchName":
                        for (int i = 0; i < (int)ViewState["PageTotal"]; i++)
                        {
                            ent = Proxy.GetEntriesOfUser((string)ViewState["UserName"], (i * 20), (string)ViewState["SortOn"], (string)ViewState["TypeSort"]).Item1;
                        }
                        break;
                    case "SearchTime":
                        for (int i = 0; i < (int)ViewState["PageTotal"]; i++)
                        {
                            ent = Proxy.GetEntriesBetween((DateTime)ViewState["StartTime"], (DateTime)ViewState["EndTime"], (i * 20), (string)ViewState["SortOn"], (string)ViewState["TypeSort"]).Item1;
                        }
                        break;
                    case "SearchNameTime":
                        for (int i = 0; i < (int)ViewState["PageTotal"]; i++)
                        {
                            ent = Proxy.GetEntriesBetweenForUser((string)ViewState["UserName"], (DateTime)ViewState["StartTime"], (DateTime)ViewState["EndTime"], (i * 20), (string)ViewState["SortOn"], (string)ViewState["TypeSort"]).Item1;
                        }
                        break;
                }

                var sb = new StringBuilder();
                foreach (var data in ent)
                {
                    sb.AppendLine(data.UserName + "," + data.EventType + "," + data.UserID + ", " + data.DeviceID + ", " + data.TimeOfEvent + ", " + data.AutomaticLock + ", " + data.RemoteAccess + ", " + data.ETA);
                }
                //File.WriteAllText("C:/Users/Public/Documents", sb.ToString());
                string FilePath = Server.MapPath("~/");
                string FileName = "SessionLocks.csv";

                // Creates the file on server
                File.WriteAllText(FilePath + FileName, sb.ToString());
                Response.ContentType = "application/octet-stream";
                Response.AppendHeader("content-disposition", "attachment;filename=" + FileName);
                Response.TransmitFile(FilePath + FileName);
                Response.End();
            }else{
                ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('The amount of data is too much to export.');", true);
            }
        }
    }
}