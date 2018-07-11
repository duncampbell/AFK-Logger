<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MainPage.aspx.cs" Inherits="WebApplication.MainPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
   
<head runat="server" >
    <title></title>
    <script src="Scripts/pikaday.js"></script>
    <link href="css/theme.css" rel="stylesheet" />
    <link href="css/site.css" rel="stylesheet" />
    <link href="css/pikaday.css" rel="stylesheet" />
    <style type="text/css">
        @font-face {
            font-family: "Lato";
            src: url('698242188-Lato-Bla.eot');
            src: url('698242188-Lato-Bla.eot?#iefix') format('embedded-opentype'),
            url('698242188-Lato-Bla.svg#Lato Black') format('svg'),
            url('698242188-Lato-Bla.woff') format('woff'),
            url('698242188-Lato-Bla.ttf') format('truetype');
            font-weight: normal;
            font-style: normal;
        }
        .auto-style6 {
            width: 185px;
            height: 36px;
        }
        .auto-style7 {
            width: 1565px;
            height: 36px;
        }
        .auto-style8 {
            height: 36px;
            width: 168px;
        }
        .auto-style9 {
            margin-left: 0px;
        }
        .auto-style10 {
            width: 1400px;
        }
        .auto-style11 {
            margin-left: 575px;
        }
        .auto-style12 {
            margin-top: 0px;
        }
        </style>
</head>
<body style ="background: #fafeff">
     <meta http-equiv="Page-Enter" content="blendTrans(Duration=0.2)" />
    <meta http-equiv="Page-Exit" content="blendTrans(Duration=0.2)" />
    <form id="form1" runat="server" >
    <div style="margin-left:auto; margin-right:auto; " class="auto-style10">
        <asp:Panel ID="Panel2" runat="server" BackColor="#FAFEFF" Height="85px" Width="1400px">
            <asp:Image ID="Image1" runat="server" CssClass="auto-style11" Height="75px" ImageUrl="~/Content/Capture.PNG" Width="250px" />
            <br />
        </asp:Panel>
        <asp:Panel ID="Panel1" runat="server" BackColor="#174669" Height="40px" style="margin-left: 0px; width:100%;" >
            <asp:Menu ID="StatusMenu" runat="server" Orientation="Horizontal" RenderingMode="Table" style="margin-left: 450px" Width="500px" OnMenuItemClick="StatusMenu_MenuItemClick" Font-Bold="True" ForeColor="White" Height="0px" Font-Names="Lato" BackColor="#174669">
                <DynamicHoverStyle Font-Bold="True" Font-Italic="False" />
                <Items>
                    <asp:MenuItem Text="Employee Status" Value="0"></asp:MenuItem>
                    <asp:MenuItem Text="Historical Data" Value="1"></asp:MenuItem>
                </Items>
                <StaticHoverStyle BackColor="#5A788E" ForeColor="White" Font-Bold="True" />
                <StaticMenuItemStyle Font-Bold="True" ForeColor="White" Height="40px" HorizontalPadding="60px" />
                <StaticSelectedStyle BackColor="#174669" ForeColor="White" Font-Bold="True" />
            </asp:Menu>
        </asp:Panel>
        <asp:ScriptManager  EnablePartialRendering="true" ID="ScriptManager1" runat="server">
                    </asp:ScriptManager>
        <asp:MultiView ID="PageNavigation" runat="server" ActiveViewIndex="0">
                <asp:View ID="View2" runat="server">
                    <asp:Timer ID="updateTimer" runat="server" Interval ="3000" OnTick="UpdateTimer_Tick">
                    </asp:Timer>
                    <asp:Timer ID="etaTimer" runat="server" Interval ="1000" OnTick="etaTimer_Tick">
                    </asp:Timer>
                    <br />
                    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                        <Triggers>
                            <asp:AsyncPostBackTrigger ControlID = "updateTimer" />
                            <asp:AsyncPostBackTrigger ControlID = "etaTimer" />
                        </Triggers>
                        <ContentTemplate>
                            <asp:GridView ID="employeeGrid" runat="server" AutoGenerateColumns="False" AutoPostBack="False" Height="50px" PageSize="100" style="margin-top: 0px" Width="1400px" CellPadding="4" ForeColor="#333333" GridLines="None" Font-Names="Lato" Font-Bold="False">
                                <AlternatingRowStyle BackColor="White" />
                                <Columns>
                                    <asp:BoundField DataField="Name" HeaderText="Name" ReadOnly="True" SortExpression="Name">
                                    <ItemStyle Width="400px" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="Status" HeaderText="Status" ReadOnly="True" SortExpression="Status" >
                                    <ControlStyle Width="0px" />
                                    <ItemStyle Width="300px" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="Time of Event" HeaderText="Time of Event" SortExpression="Time of Event">
                                    <HeaderStyle Width="200px" />
                                    <ItemStyle Width="400px" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="ETA" HeaderText="ETA" ReadOnly="True" SortExpression="ETA" >
                                    <ItemStyle Width="300px" />
                                    </asp:BoundField>
                                </Columns>
                                <EditRowStyle BackColor="#2461BF" />
                                <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                                <HeaderStyle BackColor="#174669" Font-Bold="False" ForeColor="White" Font-Italic="False" Font-Names="Lato" Font-Overline="False" Font-Size="Medium" Font-Strikeout="False" Font-Underline="False" Wrap="True" />
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
            <asp:TextBox ID="txtStartTime" runat="server" Height="10px" style="margin-left: 465px; margin-bottom: 7px" Width="240px" AutoCompleteType="Disabled" EnableTheming="True"></asp:TextBox>
            &nbsp;
            <asp:DropDownList ID="startTimeHour" runat="server" Height="30px" style="margin-left: 0px; margin-top: 0px; margin-bottom: 7px" Width="60px">
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
        </asp:DropDownList>
            &nbsp;<asp:DropDownList ID="startTimeMin" runat="server" Height="30px" style="margin-left: 0px; margin-top: 0px; margin-bottom: 7px" Width="60px">
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
        </asp:DropDownList>
            &nbsp;<asp:DropDownList ID="startTimeSec" runat="server" Height="30px" style="margin-left: 0px; margin-top: 0px; margin-bottom: 7px" Width="60px">
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
                    <asp:TextBox ID="txtEndTime" runat="server" Height="10px" style="margin-left: 465px" Width="240px" autocomplete="off" AutoCompleteType="Disabled"></asp:TextBox>
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
            <asp:DropDownList ID="endTimeHour" runat="server" Height="30px" style="margin-left: 0px; margin-top: 0px; margin-bottom: 7px" Width="60px">
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
        </asp:DropDownList>
            &nbsp;<asp:DropDownList ID="endTimeMin" runat="server" Height="30px" style="margin-left: 0px; margin-top: 0px; margin-bottom: 7px" Width="60px">
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
        </asp:DropDownList>
            &nbsp;<asp:DropDownList ID="endTimeSec" runat="server" Height="30px" style="margin-left: 0px; margin-top: 0px; margin-bottom: 7px" Width="60px">
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
        </asp:DropDownList>
            &nbsp;
        <asp:Label ID="endTimeLabel" runat="server"></asp:Label>
            <br />
            <asp:TextBox ID="txtUser" runat="server" style="margin-left: 565px" Width="240px" Height="10px"></asp:TextBox>
            <br />
            <asp:Button ID="searchBtn" runat="server" OnClick="SearchUser_Click" style="margin-left: 565px; margin-bottom: 7px;" Text="Search" Width="260px" Height="30px" BackColor="#174669" Font-Bold="True" Font-Names="Lato" Font-Size="Medium" ForeColor="White" CssClass="auto-style12" />
        <br />
                    <asp:UpdatePanel ID="dataUpdatePanel" runat="server">
                        <ContentTemplate>
                            <asp:GridView ID="dataGridView" runat="server" AllowSorting="True" AutoGenerateColumns="False" AutoPostBack="False" Height="90px" OnSorting="gridView_Sorting" PageSize="20" style="margin-top: 0px" Width="1400px" CellPadding="4" Font-Names="Lato" ForeColor="#333333" GridLines="None">
                                <AlternatingRowStyle BackColor="White" />
                                <Columns>
                                    <asp:BoundField DataField="User Name" HeaderText="User Name" SortExpression="UserName" ReadOnly="true">
                                    <ItemStyle Width="150px" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="Event Type" HeaderText="Event Type" ReadOnly="True" SortExpression="EventType">
                                    <ItemStyle Width="100px" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="Machine Name" HeaderText="Machine Name" SortExpression="MachineName">
                                    <HeaderStyle Width="300px" />
                                    <ItemStyle Width="300px" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="Time of Event" HeaderText="Time of Event" SortExpression="TimeOfEvent">
                                    <HeaderStyle Width="200px" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="Automatic" HeaderText="Automatic" ReadOnly="True" SortExpression="AutomaticLock">
                                    <ItemStyle Width="150px" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="Remote" HeaderText="Remote" ReadOnly="True" SortExpression="RemoteAccess">
                                    <ItemStyle Width="100px" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="ETA" HeaderText="ETA" ReadOnly="True" SortExpression="ETA">
                                    <ItemStyle Width="100px" />
                                    </asp:BoundField>
                                </Columns>
                                <EditRowStyle BackColor="#2461BF" />
                                <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                                <HeaderStyle BackColor="#174669" Font-Bold="False" ForeColor="White" Font-Underline="False" />
                                <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                                <RowStyle BackColor="#EFF3FB" />
                                <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                                <SortedAscendingCellStyle BackColor="#F5F7FB" />
                                <SortedAscendingHeaderStyle BackColor="#6D95E1" />
                                <SortedDescendingCellStyle BackColor="#E9EBEF" />
                                <SortedDescendingHeaderStyle BackColor="#4870BE" />
                            </asp:GridView>
                            <table>
                                <tr>
                                    <td class="auto-style7">
                                        <asp:Menu ID="pageMenu" runat="server" ForeColor="White" OnMenuItemClick="pageMenu_MenuItemClick" Orientation="Horizontal" Font-Bold="True" Font-Names="Lato">
                                            <StaticMenuItemStyle BackColor="#174669" BorderStyle="Solid" HorizontalPadding="10px" />
                                            <StaticMenuStyle BackColor="#174669" />
                                            <StaticSelectedStyle BackColor="#5A788E" ForeColor="White" />
                                        </asp:Menu>
                                    </td>
                                    <td>
                                        <asp:Button ID="updateUsers" runat="server" BackColor="#174669" CssClass="auto-style9" Font-Bold="True" Font-Names="Lato" Font-Size="Medium" ForeColor="White" Height="25px" OnClick="updateUserNames" style="margin-top: 5px; margin-bottom: 7px;" Text="Update Users" Width="200px" />

                                    </td>
                                    <td class="auto-style8">

                                        <asp:Button ID="exportPageBtn" runat="server" BackColor="#174669" Font-Bold="True" Font-Names="Lato" Font-Size="Medium" ForeColor="White" Height="25px" OnClick="ExportPage_Click" style="margin-top: 5px; margin-bottom: 7px;" Text="Export Page" Width="200px" CssClass="auto-style9" />

                                    </td>
                                    <td class="auto-style6">

                                        <asp:Button ID="exportAllBtn" runat="server" BackColor="#174669" CssClass="auto-style9" Font-Bold="True" Font-Names="Lato" Font-Size="Medium" ForeColor="White" Height="25px" OnClick="ExportAll_Click" style="margin-top: 5px; margin-bottom: 7px;" Text="Export All" Width="200px" />

                                    </td>
                                </tr>
                            </table>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </asp:View>
            </asp:MultiView>

            
        
    </div>
    </form>
</body>
</html>
