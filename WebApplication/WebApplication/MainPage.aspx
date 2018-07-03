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
<body>
    <form id="form1" runat="server"  >
    <div style="margin-left:auto; margin-right:auto; width:1400px;">
    
        <asp:Panel ID="Panel1" runat="server" BackColor="#6699FF" Height="40px" style="margin-left: 0px" Width="1400px">
            <asp:Menu ID="StatusMenu" runat="server" Orientation="Horizontal" RenderingMode="Table" style="margin-left: 450px" Width="500px" OnMenuItemClick="StatusMenu_MenuItemClick" Font-Bold="True" ForeColor="White" Height="0px">
                <DynamicHoverStyle Font-Bold="True" Font-Italic="False" />
                <Items>
                    <asp:MenuItem Text="Employee Status" Value="0"></asp:MenuItem>
                    <asp:MenuItem Text="Historical Data" Value="1"></asp:MenuItem>
                </Items>
                <StaticHoverStyle BackColor="Blue" ForeColor="White" />
                <StaticMenuItemStyle Font-Bold="False" ForeColor="White" Height="40px" HorizontalPadding="60px" />
                <StaticSelectedStyle BackColor="Blue" ForeColor="White" />
            </asp:Menu>
        </asp:Panel>
        
        
        <asp:MultiView ID="PageNavigation" runat="server" ActiveViewIndex="0">
                <asp:View ID="View2" runat="server">
                    <br />
                    <br />
                    <asp:GridView ID="employeeGrid" runat="server" AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False" AutoPostBack="False" Height="50px"  PageSize="20" style="margin-top: 0px" Width="1400px">
                        <Columns>
                            <asp:BoundField DataField="Name" HeaderText="Name" ReadOnly="True" SortExpression="Name">
                            <ControlStyle Width="0px" />
                            </asp:BoundField>
                            <asp:BoundField DataField="Status" HeaderText="Status" ReadOnly="True" SortExpression="Status"></asp:BoundField>
                            <asp:BoundField DataField="Time of Event" HeaderText="Time of Event" SortExpression="Time of Event">
                            <HeaderStyle Width="200px" />
                            </asp:BoundField>
                            <asp:BoundField DataField="ETA" HeaderText="ETA" ReadOnly="True" SortExpression="ETA"></asp:BoundField>
                        </Columns>
                        <SortedAscendingHeaderStyle BackColor="#66FF33" />
                        <SortedDescendingHeaderStyle BackColor="#993366" />
                    </asp:GridView>
                    <br />
                    <br />
                    <br />
                    <br />
                    <br />
                    <br />
                    <br />
                    <br />
                    <br />
                    <br />
                    <br />
                    <br />
                    <br />
                </asp:View>
                <asp:View ID="View1" runat="server">
                    
        <br />
            <asp:TextBox ID="txtStartTime" runat="server" Height="20px" style="margin-left: 420px; margin-bottom: 0px" Width="225px" AutoCompleteType="Disabled" EnableTheming="True"></asp:TextBox>
            &nbsp;
            <asp:DropDownList ID="startTimeHour" runat="server" Height="40px" style="margin-left: 0px; margin-top: 0px; margin-bottom: 0px" Width="50px">
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
            &nbsp;<asp:DropDownList ID="startTimeMin" runat="server" Height="40px" style="margin-left: 0px; margin-top: 0px; margin-bottom: 0px" Width="50px">
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
            &nbsp;<asp:DropDownList ID="startTimeSec" runat="server" Height="40px" style="margin-left: 0px; margin-top: 0px; margin-bottom: 0px" Width="50px">
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
                    <asp:TextBox ID="txtEndTime" runat="server" Height="20px" style="margin-left: 420px" Width="225px" autocomplete="off" AutoCompleteType="Disabled"></asp:TextBox>
            &nbsp;
            <asp:DropDownList ID="endTimeHour" runat="server" Height="40px" style="margin-left: 0px; margin-top: 0px; margin-bottom: 0px" Width="50px">
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
            &nbsp;<asp:DropDownList ID="endTimeMin" runat="server" Height="40px" style="margin-left: 0px; margin-top: 0px; margin-bottom: 0px" Width="50px">
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
            &nbsp;<asp:DropDownList ID="endTimeSec" runat="server" Height="40px" style="margin-left: 0px; margin-top: 0px; margin-bottom: 0px" Width="50px">
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
            <br />
            <asp:TextBox ID="txtUser" runat="server" style="margin-left: 506px" Width="240px" Height="17px"></asp:TextBox>
            <br />
            <br />
            <asp:Button ID="Button1" runat="server" OnClick="SearchUser_Click" style="margin-left: 507px; margin-top: 0px;" Text="Search" Width="260px" Height="36px" />
        <br />
        
        <br />
        <asp:GridView ID="dataGridView" runat="server" Height="90px" Width="1400px" AutoPostBack="False" OnSorting="gridView_Sorting" OnPageIndexChanging="dataGridView_PageIndexChanging" AllowPaging="True" AllowSorting="True" PageSize="20" AutoGenerateColumns="False" style="margin-top: 0px">
            <Columns>
                <asp:BoundField DataField="Event Type" HeaderText="Event Type" ReadOnly="True" SortExpression="Event Type">
                <ControlStyle Width="0px" />
                <ItemStyle Width="100px" />
                </asp:BoundField>
                <asp:BoundField DataField="User ID" HeaderText="User ID" ReadOnly="True" SortExpression="User ID">
                <ItemStyle Width="400px" />
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
            <SortedAscendingHeaderStyle BackColor="#66FF33" />
            <SortedDescendingHeaderStyle BackColor="#993366" />
        </asp:GridView>
                    <asp:LinqDataSource ID="LinqDataSource1" runat="server" EntityTypeName="">
                    </asp:LinqDataSource>
        <br />
        <br />
        <br />
        <br />
                </asp:View>
            </asp:MultiView>

            
        
    </div>
        <p>
            &nbsp;</p>
    </form>
</body>
</html>
