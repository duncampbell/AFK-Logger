<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MainPage.aspx.cs" Inherits="WebApplication.MainPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server" >
    <title></title>
    <script src="Scripts/pikaday.js"></script>
    <link href="css/theme.css" rel="stylesheet" />
    <link href="css/site.css" rel="stylesheet" />
    <link href="css/pikaday.css" rel="stylesheet" />
</head>
<body style ="background-color:#174669">
    <form id="form1" runat="server" >
    <div style="margin-left:auto; margin-right:auto; width:1400px;">
    
        <asp:Panel ID="Panel1" runat="server" BackColor="#174669" Height="40px" style="margin-left: 0px; width:100%;" >
            <asp:Menu ID="StatusMenu" runat="server" Orientation="Horizontal" RenderingMode="Table" style="margin-left: 450px" Width="500px" OnMenuItemClick="StatusMenu_MenuItemClick" Font-Bold="True" ForeColor="White" Height="0px" Font-Names="Arial" BackColor="#6699FF">
                <DynamicHoverStyle Font-Bold="True" Font-Italic="False" />
                <Items>
                    <asp:MenuItem Text="Employee Status" Value="0"></asp:MenuItem>
                    <asp:MenuItem Text="Historical Data" Value="1"></asp:MenuItem>
                </Items>
                <StaticHoverStyle BackColor="#99CCFF" ForeColor="White" />
                <StaticMenuItemStyle Font-Bold="False" ForeColor="White" Height="40px" HorizontalPadding="60px" />
                <StaticSelectedStyle BackColor="#6699FF" ForeColor="White" />
            </asp:Menu>
        </asp:Panel>
        
        
        <asp:MultiView ID="PageNavigation" runat="server" ActiveViewIndex="0">
                <asp:View ID="View2" runat="server">
                    <asp:ScriptManager ID="ScriptManager1" runat="server">
                    </asp:ScriptManager>
                    <asp:Timer ID="updateTimer" runat="server" Interval ="3000" OnTick="UpdateTimer_Tick">
                    </asp:Timer>
                    <br />
                    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                        <Triggers>
                            <asp:AsyncPostBackTrigger ControlID = "updateTimer" />
                        </Triggers>
                        <ContentTemplate>
                            <asp:GridView ID="employeeGrid" runat="server" AllowSorting="True" AutoGenerateColumns="False" AutoPostBack="False" Height="50px" PageSize="100" style="margin-top: 0px" Width="1400px" CellPadding="4" ForeColor="#333333" GridLines="None" Font-Names="Arial">
                                <AlternatingRowStyle BackColor="White" />
                                <Columns>
                                    <asp:BoundField DataField="Name" HeaderText="Name" ReadOnly="True" SortExpression="Name">
                                    <ControlStyle Width="0px" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="Status" HeaderText="Status" ReadOnly="True" SortExpression="Status" />
                                    <asp:BoundField DataField="Time of Event" HeaderText="Time of Event" SortExpression="Time of Event">
                                    <HeaderStyle Width="200px" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="ETA" HeaderText="ETA" ReadOnly="True" SortExpression="ETA" />
                                </Columns>
                                <EditRowStyle BackColor="#2461BF" />
                                <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                                <HeaderStyle BackColor="#6699FF" Font-Bold="True" ForeColor="White" />
                                <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                                <RowStyle BackColor="#EFF3FB" />
                                <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                                <SortedAscendingCellStyle BackColor="#F5F7FB" />
                                <SortedAscendingHeaderStyle BackColor="#6D95E1" />
                                <SortedDescendingCellStyle BackColor="#E9EBEF" />
                                <SortedDescendingHeaderStyle BackColor="#4870BE" />
                            </asp:GridView>
                            <br />
                        </ContentTemplate>
                    </asp:UpdatePanel>
                    <br />
                    <br />
                    <br />
                </asp:View>
                <asp:View ID="View1" runat="server">
                    
        <br />
            <asp:TextBox ID="txtStartTime" runat="server" Height="20px" style="margin-left: 450px; margin-bottom: 7px" Width="300px" AutoCompleteType="Disabled" EnableTheming="True"></asp:TextBox>
            &nbsp;
            <asp:DropDownList ID="startTimeHour" runat="server" Height="40px" style="margin-left: 0px; margin-top: 0px; margin-bottom: 7px" Width="50px">
            <asp:ListItem>00</asp:ListItem>
            <asp:ListItem>01</asp:ListItem>
            <asp:ListItem>02</asp:ListItem>
            <asp:ListItem>03</asp:ListItem>
            <asp:ListItem>04</asp:ListItem>
            <asp:ListItem>05</asp:ListItem>
            <asp:ListItem>06</asp:ListItem>
            <asp:ListItem>07</asp:ListItem>
            <asp:ListItem>08</asp:ListItem>
            <asp:ListItem>09</asp:ListItem>
            <asp:ListItem>10</asp:ListItem>
            <asp:ListItem>11</asp:ListItem>
            <asp:ListItem>12</asp:ListItem>
            <asp:ListItem>13</asp:ListItem>
            <asp:ListItem>14</asp:ListItem>
            <asp:ListItem>15</asp:ListItem>
            <asp:ListItem>16</asp:ListItem>
            <asp:ListItem>17</asp:ListItem>
            <asp:ListItem>18</asp:ListItem>
            <asp:ListItem>19</asp:ListItem>
            <asp:ListItem>20</asp:ListItem>
            <asp:ListItem>21</asp:ListItem>
            <asp:ListItem>22</asp:ListItem>
            <asp:ListItem>23</asp:ListItem>
            <asp:ListItem>24</asp:ListItem>
        </asp:DropDownList>
            &nbsp;<asp:DropDownList ID="startTimeMin" runat="server" Height="40px" style="margin-left: 0px; margin-top: 0px; margin-bottom: 7px" Width="50px">
            <asp:ListItem>00</asp:ListItem>
            <asp:ListItem>01</asp:ListItem>
            <asp:ListItem>02</asp:ListItem>
            <asp:ListItem>03</asp:ListItem>
            <asp:ListItem>04</asp:ListItem>
            <asp:ListItem>05</asp:ListItem>
            <asp:ListItem>06</asp:ListItem>
            <asp:ListItem>07</asp:ListItem>
            <asp:ListItem>08</asp:ListItem>
            <asp:ListItem>09</asp:ListItem>
            <asp:ListItem>10</asp:ListItem>
            <asp:ListItem>11</asp:ListItem>
            <asp:ListItem>12</asp:ListItem>
            <asp:ListItem>13</asp:ListItem>
            <asp:ListItem>14</asp:ListItem>
            <asp:ListItem>15</asp:ListItem>
            <asp:ListItem>16</asp:ListItem>
            <asp:ListItem>17</asp:ListItem>
            <asp:ListItem>18</asp:ListItem>
            <asp:ListItem>19</asp:ListItem>
            <asp:ListItem>20</asp:ListItem>
            <asp:ListItem>21</asp:ListItem>
            <asp:ListItem>22</asp:ListItem>
            <asp:ListItem>23</asp:ListItem>
            <asp:ListItem>24</asp:ListItem>
            <asp:ListItem>25</asp:ListItem>
            <asp:ListItem>26</asp:ListItem>
            <asp:ListItem>27</asp:ListItem>
            <asp:ListItem>28</asp:ListItem>
            <asp:ListItem>29</asp:ListItem>
            <asp:ListItem>30</asp:ListItem>
            <asp:ListItem>31</asp:ListItem>
            <asp:ListItem>32</asp:ListItem>
            <asp:ListItem>33</asp:ListItem>
            <asp:ListItem>34</asp:ListItem>
            <asp:ListItem>35</asp:ListItem>
            <asp:ListItem>36</asp:ListItem>
            <asp:ListItem>37</asp:ListItem>
            <asp:ListItem>38</asp:ListItem>
            <asp:ListItem>39</asp:ListItem>
            <asp:ListItem>40</asp:ListItem>
            <asp:ListItem>41</asp:ListItem>
            <asp:ListItem>42</asp:ListItem>
            <asp:ListItem>43</asp:ListItem>
            <asp:ListItem>44</asp:ListItem>
            <asp:ListItem>45</asp:ListItem>
            <asp:ListItem>46</asp:ListItem>
            <asp:ListItem>47</asp:ListItem>
            <asp:ListItem>48</asp:ListItem>
            <asp:ListItem>49</asp:ListItem>
            <asp:ListItem>50</asp:ListItem>
            <asp:ListItem>51</asp:ListItem>
            <asp:ListItem>52</asp:ListItem>
            <asp:ListItem>53</asp:ListItem>
            <asp:ListItem>54</asp:ListItem>
            <asp:ListItem>55</asp:ListItem>
            <asp:ListItem>56</asp:ListItem>
            <asp:ListItem>57</asp:ListItem>
            <asp:ListItem>58</asp:ListItem>
            <asp:ListItem>59</asp:ListItem>
            <asp:ListItem>60</asp:ListItem>
        </asp:DropDownList>
            &nbsp;<asp:DropDownList ID="startTimeSec" runat="server" Height="40px" style="margin-left: 0px; margin-top: 0px; margin-bottom: 7px" Width="50px">
            <asp:ListItem>00</asp:ListItem>
            <asp:ListItem>01</asp:ListItem>
            <asp:ListItem>02</asp:ListItem>
            <asp:ListItem>03</asp:ListItem>
            <asp:ListItem>04</asp:ListItem>
            <asp:ListItem>05</asp:ListItem>
            <asp:ListItem>06</asp:ListItem>
            <asp:ListItem>07</asp:ListItem>
            <asp:ListItem>08</asp:ListItem>
            <asp:ListItem>09</asp:ListItem>
            <asp:ListItem>10</asp:ListItem>
            <asp:ListItem>11</asp:ListItem>
            <asp:ListItem>12</asp:ListItem>
            <asp:ListItem>13</asp:ListItem>
            <asp:ListItem>14</asp:ListItem>
            <asp:ListItem>15</asp:ListItem>
            <asp:ListItem>16</asp:ListItem>
            <asp:ListItem>17</asp:ListItem>
            <asp:ListItem>18</asp:ListItem>
            <asp:ListItem>19</asp:ListItem>
            <asp:ListItem>20</asp:ListItem>
            <asp:ListItem>21</asp:ListItem>
            <asp:ListItem>22</asp:ListItem>
            <asp:ListItem>23</asp:ListItem>
            <asp:ListItem>24</asp:ListItem>
            <asp:ListItem>25</asp:ListItem>
            <asp:ListItem>26</asp:ListItem>
            <asp:ListItem>27</asp:ListItem>
            <asp:ListItem>28</asp:ListItem>
            <asp:ListItem>29</asp:ListItem>
            <asp:ListItem>30</asp:ListItem>
            <asp:ListItem>31</asp:ListItem>
            <asp:ListItem>32</asp:ListItem>
            <asp:ListItem>33</asp:ListItem>
            <asp:ListItem>34</asp:ListItem>
            <asp:ListItem>35</asp:ListItem>
            <asp:ListItem>36</asp:ListItem>
            <asp:ListItem>37</asp:ListItem>
            <asp:ListItem>38</asp:ListItem>
            <asp:ListItem>39</asp:ListItem>
            <asp:ListItem>40</asp:ListItem>
            <asp:ListItem>41</asp:ListItem>
            <asp:ListItem>42</asp:ListItem>
            <asp:ListItem>43</asp:ListItem>
            <asp:ListItem>44</asp:ListItem>
            <asp:ListItem>45</asp:ListItem>
            <asp:ListItem>46</asp:ListItem>
            <asp:ListItem>47</asp:ListItem>
            <asp:ListItem>48</asp:ListItem>
            <asp:ListItem>49</asp:ListItem>
            <asp:ListItem>50</asp:ListItem>
            <asp:ListItem>51</asp:ListItem>
            <asp:ListItem>52</asp:ListItem>
            <asp:ListItem>53</asp:ListItem>
            <asp:ListItem>54</asp:ListItem>
            <asp:ListItem>55</asp:ListItem>
            <asp:ListItem>56</asp:ListItem>
            <asp:ListItem>57</asp:ListItem>
            <asp:ListItem>58</asp:ListItem>
            <asp:ListItem>59</asp:ListItem>
            <asp:ListItem>60</asp:ListItem>
        </asp:DropDownList>
            &nbsp;
        <asp:Label ID="startTimeLabel" runat="server"></asp:Label>
            <br />
            <script type="text/javascript">
                var picker = new Pikaday(
                {
                    field: document.getElementById('txtStartTime'),
                    firstDay: 1,
                    minDate: new Date('2017-01-01'),
                    maxDate: new Date('2030-12-31'),
                    yearRange: [2017, 2030],
                    numberOfMonths: 1,
                });
            </script>
                    <asp:TextBox ID="txtEndTime" runat="server" Height="20px" style="margin-left: 450px" Width="300px" autocomplete="off" AutoCompleteType="Disabled"></asp:TextBox>
                    <script type="text/javascript">
                var picker = new Pikaday(
                {
                    field: document.getElementById('txtEndTime'),
                    firstDay: 1,
                    minDate: new Date('2017-01-01'),
                    maxDate: new Date('2030-12-31'),
                    yearRange: [2017, 2030],
                    numberOfMonths: 1,
                });
            </script>
            &nbsp;
            <asp:DropDownList ID="endTimeHour" runat="server" Height="40px" style="margin-left: 0px; margin-top: 0px; margin-bottom: 7px" Width="50px">
            <asp:ListItem>00</asp:ListItem>
            <asp:ListItem>01</asp:ListItem>
            <asp:ListItem>02</asp:ListItem>
            <asp:ListItem>03</asp:ListItem>
            <asp:ListItem>04</asp:ListItem>
            <asp:ListItem>05</asp:ListItem>
            <asp:ListItem>06</asp:ListItem>
            <asp:ListItem>07</asp:ListItem>
            <asp:ListItem>08</asp:ListItem>
            <asp:ListItem>09</asp:ListItem>
            <asp:ListItem>10</asp:ListItem>
            <asp:ListItem>11</asp:ListItem>
            <asp:ListItem>12</asp:ListItem>
            <asp:ListItem>13</asp:ListItem>
            <asp:ListItem>14</asp:ListItem>
            <asp:ListItem>15</asp:ListItem>
            <asp:ListItem>16</asp:ListItem>
            <asp:ListItem>17</asp:ListItem>
            <asp:ListItem>18</asp:ListItem>
            <asp:ListItem>19</asp:ListItem>
            <asp:ListItem>20</asp:ListItem>
            <asp:ListItem>21</asp:ListItem>
            <asp:ListItem>22</asp:ListItem>
            <asp:ListItem>23</asp:ListItem>
            <asp:ListItem>24</asp:ListItem>
        </asp:DropDownList>
            &nbsp;<asp:DropDownList ID="endTimeMin" runat="server" Height="40px" style="margin-left: 0px; margin-top: 0px; margin-bottom: 7px" Width="50px">
            <asp:ListItem>00</asp:ListItem>
            <asp:ListItem>01</asp:ListItem>
            <asp:ListItem>02</asp:ListItem>
            <asp:ListItem>03</asp:ListItem>
            <asp:ListItem>04</asp:ListItem>
            <asp:ListItem>05</asp:ListItem>
            <asp:ListItem>06</asp:ListItem>
            <asp:ListItem>07</asp:ListItem>
            <asp:ListItem>08</asp:ListItem>
            <asp:ListItem>09</asp:ListItem>
            <asp:ListItem>10</asp:ListItem>
            <asp:ListItem>11</asp:ListItem>
            <asp:ListItem>12</asp:ListItem>
            <asp:ListItem>13</asp:ListItem>
            <asp:ListItem>14</asp:ListItem>
            <asp:ListItem>15</asp:ListItem>
            <asp:ListItem>16</asp:ListItem>
            <asp:ListItem>17</asp:ListItem>
            <asp:ListItem>18</asp:ListItem>
            <asp:ListItem>19</asp:ListItem>
            <asp:ListItem>20</asp:ListItem>
            <asp:ListItem>21</asp:ListItem>
            <asp:ListItem>22</asp:ListItem>
            <asp:ListItem>23</asp:ListItem>
            <asp:ListItem>24</asp:ListItem>
            <asp:ListItem>25</asp:ListItem>
            <asp:ListItem>26</asp:ListItem>
            <asp:ListItem>27</asp:ListItem>
            <asp:ListItem>28</asp:ListItem>
            <asp:ListItem>29</asp:ListItem>
            <asp:ListItem>30</asp:ListItem>
            <asp:ListItem>31</asp:ListItem>
            <asp:ListItem>32</asp:ListItem>
            <asp:ListItem>33</asp:ListItem>
            <asp:ListItem>34</asp:ListItem>
            <asp:ListItem>35</asp:ListItem>
            <asp:ListItem>36</asp:ListItem>
            <asp:ListItem>37</asp:ListItem>
            <asp:ListItem>38</asp:ListItem>
            <asp:ListItem>39</asp:ListItem>
            <asp:ListItem>40</asp:ListItem>
            <asp:ListItem>41</asp:ListItem>
            <asp:ListItem>42</asp:ListItem>
            <asp:ListItem>43</asp:ListItem>
            <asp:ListItem>44</asp:ListItem>
            <asp:ListItem>45</asp:ListItem>
            <asp:ListItem>46</asp:ListItem>
            <asp:ListItem>47</asp:ListItem>
            <asp:ListItem>48</asp:ListItem>
            <asp:ListItem>49</asp:ListItem>
            <asp:ListItem>50</asp:ListItem>
            <asp:ListItem>51</asp:ListItem>
            <asp:ListItem>52</asp:ListItem>
            <asp:ListItem>53</asp:ListItem>
            <asp:ListItem>54</asp:ListItem>
            <asp:ListItem>55</asp:ListItem>
            <asp:ListItem>56</asp:ListItem>
            <asp:ListItem>57</asp:ListItem>
            <asp:ListItem>58</asp:ListItem>
            <asp:ListItem>59</asp:ListItem>
            <asp:ListItem>60</asp:ListItem>
        </asp:DropDownList>
            &nbsp;<asp:DropDownList ID="endTimeSec" runat="server" Height="40px" style="margin-left: 0px; margin-top: 0px; margin-bottom: 7px" Width="50px">
            <asp:ListItem>00</asp:ListItem>
            <asp:ListItem>01</asp:ListItem>
            <asp:ListItem>02</asp:ListItem>
            <asp:ListItem>03</asp:ListItem>
            <asp:ListItem>04</asp:ListItem>
            <asp:ListItem>05</asp:ListItem>
            <asp:ListItem>06</asp:ListItem>
            <asp:ListItem>07</asp:ListItem>
            <asp:ListItem>08</asp:ListItem>
            <asp:ListItem>09</asp:ListItem>
            <asp:ListItem>10</asp:ListItem>
            <asp:ListItem>11</asp:ListItem>
            <asp:ListItem>12</asp:ListItem>
            <asp:ListItem>13</asp:ListItem>
            <asp:ListItem>14</asp:ListItem>
            <asp:ListItem>15</asp:ListItem>
            <asp:ListItem>16</asp:ListItem>
            <asp:ListItem>17</asp:ListItem>
            <asp:ListItem>18</asp:ListItem>
            <asp:ListItem>19</asp:ListItem>
            <asp:ListItem>20</asp:ListItem>
            <asp:ListItem>21</asp:ListItem>
            <asp:ListItem>22</asp:ListItem>
            <asp:ListItem>23</asp:ListItem>
            <asp:ListItem>24</asp:ListItem>
            <asp:ListItem>25</asp:ListItem>
            <asp:ListItem>26</asp:ListItem>
            <asp:ListItem>27</asp:ListItem>
            <asp:ListItem>28</asp:ListItem>
            <asp:ListItem>29</asp:ListItem>
            <asp:ListItem>30</asp:ListItem>
            <asp:ListItem>31</asp:ListItem>
            <asp:ListItem>32</asp:ListItem>
            <asp:ListItem>33</asp:ListItem>
            <asp:ListItem>34</asp:ListItem>
            <asp:ListItem>35</asp:ListItem>
            <asp:ListItem>36</asp:ListItem>
            <asp:ListItem>37</asp:ListItem>
            <asp:ListItem>38</asp:ListItem>
            <asp:ListItem>39</asp:ListItem>
            <asp:ListItem>40</asp:ListItem>
            <asp:ListItem>41</asp:ListItem>
            <asp:ListItem>42</asp:ListItem>
            <asp:ListItem>43</asp:ListItem>
            <asp:ListItem>44</asp:ListItem>
            <asp:ListItem>45</asp:ListItem>
            <asp:ListItem>46</asp:ListItem>
            <asp:ListItem>47</asp:ListItem>
            <asp:ListItem>48</asp:ListItem>
            <asp:ListItem>49</asp:ListItem>
            <asp:ListItem>50</asp:ListItem>
            <asp:ListItem>51</asp:ListItem>
            <asp:ListItem>52</asp:ListItem>
            <asp:ListItem>53</asp:ListItem>
            <asp:ListItem>54</asp:ListItem>
            <asp:ListItem>55</asp:ListItem>
            <asp:ListItem>56</asp:ListItem>
            <asp:ListItem>57</asp:ListItem>
            <asp:ListItem>58</asp:ListItem>
            <asp:ListItem>59</asp:ListItem>
            <asp:ListItem>60</asp:ListItem>
        </asp:DropDownList>
            &nbsp;
        <asp:Label ID="endTimeLabel" runat="server"></asp:Label>
            <br />
            <asp:TextBox ID="txtUser" runat="server" style="margin-left: 550px" Width="300px" Height="17px"></asp:TextBox>
            <br />
            <asp:Button ID="Button1" runat="server" OnClick="SearchUser_Click" style="margin-left: 550px; margin-top: 5px; margin-bottom: 7px;" Text="Search" Width="320px" Height="36px" BackColor="#6699FF" Font-Bold="True" Font-Names="Arial" Font-Size="Medium" ForeColor="White" />
        <br />
        
                    <asp:UpdatePanel ID="dataUpdatePanel" runat="server">
                        <ContentTemplate>
                            <asp:GridView ID="dataGridView" runat="server" AllowSorting="True" AutoGenerateColumns="False" AutoPostBack="False" Height="90px" OnSorting="gridView_Sorting" PageSize="20" style="margin-top: 0px" Width="1400px" CellPadding="4" ForeColor="#333333" GridLines="None">
                                <AlternatingRowStyle BackColor="White" />
                                <Columns>
                                    <asp:BoundField DataField="Event Type" HeaderText="Event Type" ReadOnly="True" SortExpression="Event Type">
                                    <ItemStyle Width="400px" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="User ID" HeaderText="User ID" ReadOnly="True" SortExpression="User ID">
                                    <ControlStyle Width="0px" />
                                    <ItemStyle Width="100px" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="Device ID" HeaderText="Device ID" SortExpression="Device ID">
                                    <HeaderStyle Width="300px" />
                                    <ItemStyle Width="400px" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="Time of Event" HeaderText="Time of Event" SortExpression="Time of Event">
                                    <HeaderStyle Width="200px" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="Automatic" HeaderText="Automatic" ReadOnly="True" SortExpression="Automatic">
                                    <ItemStyle Width="50px" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="Remote" HeaderText="Remote" ReadOnly="True" SortExpression="Remote">
                                    <ItemStyle Width="50px" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="ETA" HeaderText="ETA" ReadOnly="True" SortExpression="ETA">
                                    <ItemStyle Width="100px" />
                                    </asp:BoundField>
                                </Columns>
                                <EditRowStyle BackColor="#2461BF" />
                                <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                                <HeaderStyle BackColor="#6699FF" Font-Bold="True" ForeColor="White" />
                                <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                                <RowStyle BackColor="#EFF3FB" />
                                <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                                <SortedAscendingCellStyle BackColor="#F5F7FB" />
                                <SortedAscendingHeaderStyle BackColor="#6D95E1" />
                                <SortedDescendingCellStyle BackColor="#E9EBEF" />
                                <SortedDescendingHeaderStyle BackColor="#4870BE" />
                            </asp:GridView>
                            <br />
                            <asp:Button ID="prevBtn" runat="server" OnClick="prevBtn_Click" style="margin-left: 520px" Text="Previous" Width="130px" />
                            <asp:Button ID="nextBtn" runat="server" OnClick="nextBtn_Click" style="margin-left: 4px" Text="Next" Width="130px" />
                            <br />
                            <br />
                        </ContentTemplate>
                    </asp:UpdatePanel>
        
        <br />
                    <br />
        <br />
                </asp:View>
            </asp:MultiView>

            
        
    </div>
    </form>
</body>
</html>
