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
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single,ConcurrencyMode =ConcurrencyMode.Multiple)]
    [CallbackBehavior(ConcurrencyMode = ConcurrencyMode.Multiple)]
    public partial class MainPage : System.Web.UI.Page, IServiceCallback
    {
        ServiceReference1.ServiceClient Proxy;
        DataTable dt;
        InstanceContext iC;
        List<DataBaseEntry> Entries;
        Dictionary<string, int> months = new Dictionary<string, int>() { { "Jan", 1 }, { "Feb", 2 }, { "Mar", 3 }, { "Apr", 4 }, { "May", 5 }, { "Jun", 6 }, { "Jul", 7 }, { "Aug", 8 }, { "Sep", 9 }, { "Oct", 10 }, { "Nov", 11 }, { "Dec", 12 } };
        List<Employee> employees;

        protected void Page_Load(object sender, EventArgs e)
        {
            
            // MainPage test = new MainPage();
            iC = new InstanceContext(this);
            Proxy = new ServiceReference1.ServiceClient(iC);
            CreateEmployeeTable(new List<Employee>());

            if (!IsPostBack)
            {
                
                this.StatusMenu.Items[0].Selected = true;
                ViewState["State"] = "Normal";
                ViewState["SearchName"] = "";
                ViewState["TimeStart"] = new DateTime();
                ViewState["TimeEnd"] = new DateTime();
                ViewState["SortOn"] = "Time of Event";
                ViewState["TypeSort"] = "Descending";

                Proxy.RegisterClient("web", false);
            }
            //tableSetUp();
            // PreviousPage.Enabled = false;
        }

        public void CreateEmployeeTable(List<Employee> employees)
        {
            this.employees = employees;
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
            //TODO: Refresh table
        }

        public void tableSetUp()
        {
            if ((string)(ViewState["State"]) == ("Normal"))
            {
                Entries = Proxy.GetAllEntries();
            }
            else if ((string)(ViewState["State"]) == "SearchName")
            {
                Entries = Proxy.GetEntriesOfUser((string)ViewState["SearchName"]);
            }
            else if ((string)(ViewState["State"]) == "SearchTime")
            {
                Entries = Proxy.GetEntriesBetween((DateTime)ViewState["TimeStart"], (DateTime)ViewState["TimeEnd"]);
            }
            else if ((string)(ViewState["State"]) == "SearchNameTime")
            {
                Entries = Proxy.GetEntriesBetweenForUser((string)(ViewState["SearchName"]), (DateTime)ViewState["TimeStart"], (DateTime)ViewState["TimeEnd"]);
            }
            checkOrdering();
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

            for (int i = 0; i < Entries.Count; i++)
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
           // dataGridView.Columns[0].ItemStyle.Width = 50;
        }

        public void checkOrdering()
        {
            switch (ViewState["SortOn"].ToString())
                {
                    case "Time of Event":
                       
                        if (ViewState["TypeSort"].ToString().Equals("Descending"))
                            {
                                Entries = Entries.OrderByDescending(o => o.TimeOfEvent.Ticks).ToList();
                        }else{
                                Entries = Entries.OrderBy(o => o.TimeOfEvent.Ticks).ToList();
                        }
                        break;
                    case "Event Type":
                        if (ViewState["TypeSort"].ToString().Equals("Descending"))
                        {
                            Entries = Entries.OrderByDescending(o => o.EventType).ToList();
                        }
                        else
                        {
                            Entries = Entries.OrderBy(o => o.EventType).ToList();
                        }
                        break;
                    case "User ID":
                        if (ViewState["TypeSort"].ToString().Equals("Descending"))
                        {
                            Entries = Entries.OrderByDescending(o => o.UserID).ToList();
                        }
                        else
                        {
                            Entries = Entries.OrderBy(o => o.UserID).ToList();
                        }
                        break;
                    case "Device ID":
                        if (ViewState["TypeSort"].ToString().Equals("Descending"))
                        {
                            Entries = Entries.OrderByDescending(o => o.DeviceID).ToList();
                        }
                        else
                        {
                            Entries = Entries.OrderBy(o => o.DeviceID).ToList();
                        }
                        break;
                    case "Automatic":
                        if (ViewState["TypeSort"].ToString().Equals("Descending"))
                        {
                            Entries = Entries.OrderByDescending(o => o.AutomaticLock).ToList();
                        }
                        else
                        {
                            Entries = Entries.OrderBy(o => o.AutomaticLock).ToList();
                        }
                        break;
                    case "Remote":
                        if (ViewState["TypeSort"].ToString().Equals("Descending"))
                        {
                            Entries = Entries.OrderByDescending(o => o.RemoteAccess).ToList();
                        }
                        else
                        {
                            Entries = Entries.OrderBy(o => o.RemoteAccess).ToList();
                        }
                        break;
                    case "ETA":
                        if (ViewState["TypeSort"].ToString().Equals("Descending"))
                        {
                            Entries = Entries.OrderByDescending(o => o.ETA).ToList();
                        }else
                        {
                            Entries = Entries.OrderBy(o => o.ETA).ToList();
                        }
                        break;

            }
            
        }

        //Causes Alice's page to reload data
        public void SendResult(string test)
        {
            Proxy.GetEntriesForAliceAsync();
        }

        protected void SearchUser_Click(object sender, EventArgs e)
        {
            startTimeLabel.Text = "";
            endTimeLabel.Text = "";
            string startInput = txtStartTime.Text;
            string endInput = txtEndTime.Text;
            string userName = txtUser.Text;
            
            if (userName == "" && startInput == "" && endInput == "")//Search Blank
            {
                ViewState["State"] = "Normal";
                ViewState["SearchName"] = "";
                ViewState["TimeStart"] = new DateTime();
                ViewState["TimeEnd"] = new DateTime();
                tableSetUp();
            }else if (userName != "" && startInput == "" && endInput == "")//Search Only UserName
            {
                ViewState["State"] = "SearchName";
                ViewState["SearchName"] = userName;
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
                    ViewState["TimeStart"] = new DateTime(year, month, day, Int32.Parse(startTimeHour.Text), Int32.Parse(startTimeMin.Text), Int32.Parse(startTimeSec.Text));
                }catch
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
                    ViewState["TimeEnd"] = new DateTime(year, month, day, Int32.Parse(endTimeHour.Text), Int32.Parse(endTimeMin.Text), Int32.Parse(endTimeSec.Text));
                }catch{
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
                    ViewState["TimeStart"] = new DateTime(year, month, day, Int32.Parse(startTimeHour.Text), Int32.Parse(startTimeMin.Text), Int32.Parse(startTimeSec.Text));
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
                    ViewState["TimeEnd"] = new DateTime(year, month, day, Int32.Parse(endTimeHour.Text), Int32.Parse(endTimeMin.Text), Int32.Parse(endTimeSec.Text));
                }catch
                {
                    searchable = false;
                    endTimeLabel.Text = "Incorrect Format";
                }
                if (searchable == true)
                {
                    ViewState["SearchName"] = userName;
                    ViewState["State"] = "SearchNameTime";
                    tableSetUp();
                }
            }


        }
        
        protected void dataGridView_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            this.dataGridView.PageIndex = e.NewPageIndex;
            dataGridView.DataBind();
        }

        protected void employeeGridView_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            this.employeeGrid.PageIndex = e.NewPageIndex;
            employeeGrid.DataBind();
        }
 
        protected void gridView_Sorting(object sender, GridViewSortEventArgs e)
        {
            if(ViewState["TypeSort"].ToString().Equals("Ascending"))
            {
                ViewState["TypeSort"] = "Descending";
            }else { 
                ViewState["TypeSort"] = "Ascending";
            }

            ViewState["SortOn"] = e.SortExpression;
            
            tableSetUp();
        }

        protected void StatusMenu_MenuItemClick(object sender, MenuEventArgs e)
        {
            Proxy.GetEntriesForAliceAsync();
            int index = Int32.Parse(e.Item.Value);
            PageNavigation.ActiveViewIndex = index;
        }

        public void FinishDataBaseEntry(DataBaseEntry entry)
        {
            //Ignore
        }
    }
}