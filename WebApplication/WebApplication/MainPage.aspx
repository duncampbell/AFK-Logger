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
        .centralDiv{
            margin-left:auto; 
            margin-right:auto; 
            width:1400px;
        }
        .headerPanel{
            background:#FAFEFF;
            Height:85px;
            Width:1400px;
        }
        .quinetessenceImage {
            margin-left: 575px;
            width:250px;
            height:75px;
        }
        .menuPanel{
            height:40px;
            background:#174669;
            margin-left:0px;
            width:1400px;
        }
        .menuHover{
            background:#5A788E;
            color:white;
            font-weight:bold
        }
        .menuItem{
            height:40px;
            padding-left:60px;
            padding-right:60px;
            color:white;
            font-weight:bold
        }
        .gridView{
            font-weight:normal;
            width:1300px;
            margin: 0;
            margin-bottom:0;
            margin-top:0px;
            margin-left:0px;
            margin-right:0px;
            padding:0px;
            padding-bottom: 0px;
            padding-left: 0px;
            padding-right: 0px;
            padding-top: 0px;
            border:0;
            border-width:0;
            border-left-width:0;
            border-right-width:0;
            border-bottom-width:0;
            border-top-width:0;
            display: inline-block;
        }
        .elementStyle {
            margin: 0px;
            margin-bottom:0px;
            margin-top:0px;
            margin-left:0px;
            margin-right:0px;
            padding:0px;
            padding-bottom: 0px;
            padding-left: 0px;
            padding-right: 0px;
            padding-top: 0px;
            border:0;
            border-width:0;
            border-left-width:0;
            border-right-width:0;
            border-bottom-width:0;
            border-top-width:0;
        }
        .imageStyle {
            width: 100px;
            height: 100px;
            display: inline-block;
            margin: 0px;
            margin-bottom:0px;
            margin-top:0px;
            margin-left:0px;
            margin-right:0px;
            padding:0px;
            padding-bottom: 0px;
            padding-left: 0px;
            padding-right: 0px;
            padding-top: 0px;
            border:0;
            border-width:0;
            border-left-width:0;
            border-right-width:0;
            border-bottom-width:0;
            border-top-width:0;
        }
        .tableStyle{
            margin: 0;
            margin-bottom:0;
            margin-top:0px;
            margin-left:0px;
            margin-right:0px;
            padding:0px;
            padding-bottom: 0px;
            padding-left: 0px;
            padding-right: 0px;
            padding-top: 0px;
            border:0;
            border-width:0;
            border-left-width:0;
            border-right-width:0;
            border-bottom-width:0;
            border-top-width:0;
        }
        .employeeImageStyle {
            width: 400px;
            height: 400px;
            display: inline-block;
            margin: 0px;
            margin-bottom:0px;
            margin-top:0px;
            margin-left:100px;
            margin-right:0px;
            padding:0px;
            padding-bottom: 0px;
            padding-left: 0px;
            padding-right: 0px;
            padding-top: 0px;
            border:0;
            border-width:0;
            border-left-width:0;
            border-right-width:0;
            border-bottom-width:0;
            border-top-width:0;
        }
        .textField{
            Height:10px;
            width:240px;
            margin-bottom: 7px;
        }
        .button {
            margin-left: 0px;
            border: none;
            background:#174669;
            font-weight:bold;
            font-size:medium;
            height:25px;
            color:white;
            margin-top: 5px; 
            margin-bottom: 7px;
            width:200px;
            font-family:Lato;
        }
        input.button:hover{
            margin-left: 0px;
            border: none;
            font-weight:bold;
            font-size:medium;
            height:25px;
            color:white;
            margin-top: 5px; 
            margin-bottom: 7px;
            background:#5A788E;
            font-family:Lato;
        }
        .searchBtn {
            margin-left: 0px;
            border: none;
            background:#174669;
            font-weight:bold;
            font-size:medium;
            height:25px;
            color:white;
            margin-top: 5px; 
            margin-bottom: 7px;
            width:260px;
            font-family:Lato;
        }
        input.searchBtn:hover{
            margin-left: 0px;
            border: none;
            font-weight:bold;
            font-size:medium;
            height:25px;
            color:white;
            margin-top: 5px; 
            margin-bottom: 7px;
            background:#5A788E;
            font-family:Lato;
        }
        .noExcess{
            display: inline-block;
            margin: 0px;
            margin-bottom:0px;
            margin-top:0px;
            margin-left:0px;
            margin-right:0px;
            border:0;
            border-width:0;
            border-left-width:0;
            border-right-width:0;
            border-bottom-width:0;
            border-top-width:0;
            padding:0px;
            padding-bottom: 0px;
            padding-left: 0px;
            padding-right: 0px;
            padding-top: 0px;
        }
        </style>
</head>
<body style ="background: #fafeff">
    
    <meta http-equiv="Page-Enter" content="blendTrans(Duration=0.2)" />
    <meta http-equiv="Page-Exit" content="blendTrans(Duration=0.2)" />
    <form id="WebsiteForm" runat="server">
    <asp:HiddenField runat="server" ID="RowSelected" />
    <asp:HiddenField ID="FileName" runat="server" />
    <div class ="centralDiv">
    <asp:ScriptManager  ID="ScriptManager" runat="server"></asp:ScriptManager>
        
    <script type="text/javascript" >
            function CellClick(rowNum){
                document.getElementById('<%=RowSelected.ClientID %>').value = rowNum;
                document.getElementById('btn').click();
            }
        </script>
       
    <script>
            function showBrowseDialog() {
                var fileuploadctrl = document.getElementById('ImageUpload');
                fileuploadctrl.click();
            }
        </script>

    <script type="text/javascript">
            Sys.WebForms.PageRequestManager.getInstance().add_beginRequest(BeginRequestHandler);
            function BeginRequestHandler(sender, args) { var oControl = args.get_postBackElement(); oControl.disabled = true; }
        </script>

    <asp:Panel ID="HeaderPanel" runat="server" CSSClass ="headerPanel">
            <asp:Image ID="QiuntessenceImage" runat="server" CSSClass = "quinetessenceImage" ImageUrl="~/Content/Capture.PNG"/>
            <br />
        </asp:Panel>

    <asp:Panel ID="MenuPanel" runat="server" CSSClass="menuPanel">
            <asp:Menu ID="StatusMenu" runat="server" CSSClass="statusMenu" style="margin-left:350px" Font-Names="Lato" Orientation="Horizontal" RenderingMode="Table" OnMenuItemClick="StatusMenu_MenuItemClick">
                <DynamicHoverStyle Font-Bold="True" Font-Italic="False" />
                <Items>
                    <asp:MenuItem Text="Employee Status" Value="0"></asp:MenuItem>
                    <asp:MenuItem Text="Historical Data" Value="1"></asp:MenuItem>
                </Items>
                <StaticHoverStyle CSSClass="menuHover"/>
                <StaticMenuItemStyle CSSClass="menuItem"/>
            </asp:Menu>
        </asp:Panel>

    <asp:MultiView ID="PageNavigation" runat="server" ActiveViewIndex="0">
        <asp:View ID="AliceView" runat="server">
            <asp:Timer ID="updateTimer" runat="server" Interval ="10000" OnTick="refreshUsersTimer_Tick" Enabled="False"></asp:Timer>
            <asp:Timer ID="etaTimer" runat="server" Interval ="1000" OnTick="etaTimer_Tick" Enabled="False"></asp:Timer>
            <asp:UpdatePanel ID="employeeUpdatePanel" runat="server">
                <Triggers>
                    <asp:AsyncPostBackTrigger ControlID = "updateTimer" />
                    <asp:AsyncPostBackTrigger ControlID = "etaTimer" />
                </Triggers>
                <ContentTemplate>
                    <asp:MultiView ID="EmployeeView" runat="server" ActiveViewIndex="0">
                        <asp:View ID="AllEmployees" runat="server">
                            <table>
                                <tr>
                                    <td class="tableStyle">
                                        <asp:GridView ID="pictureGrid" runat="server" CSSClass="tableStyle" AutoGenerateColumns="False" DataSource="<%# CreateEmployeePictureTable() %>" GridLines="None" OnRowDataBound="PictureGridView_RowDataBound" PageSize="100" Width="100px">
                                            <Columns>
                                                <asp:ImageField DataImageUrlField="PictureURL">
                                                    <ControlStyle CssClass="imageStyle" />
                                                    <ItemStyle CssClass="imageStyle" />
                                                </asp:ImageField>
                                            </Columns>
                                        </asp:GridView>
                                    </td>
                                    <td class="tableStyle">
                                        <asp:GridView ID="employeeGrid" runat="server" OnRowDataBound="DataGridView_RowDataBound" AutoGenerateColumns="False" DataSource="<%# CreateEmployeesTable() %>" Font-Names="Lato" GridLines="None" PageSize="100">
                                            <Columns>
                                                <asp:BoundField DataField="Name" ReadOnly="True" SortExpression="Name">
                                                <ControlStyle Width="200px" Height="100px" CssClass="elementStyle"/>
                                                <ItemStyle Width="200px" Height="100px" HorizontalAlign="Center" VerticalAlign ="Middle" CssClass= "elementStyle"/>
                                                </asp:BoundField>
                                                <asp:BoundField DataField="Status" ReadOnly="True" SortExpression="Status">
                                                <ControlStyle Width="400px" Height="100px" CssClass="elementStyle"/>
                                                <ItemStyle Width="400px" Height="100px" HorizontalAlign="Center" VerticalAlign ="Middle" CssClass="elementStyle"/>
                                                </asp:BoundField>
                                                <asp:ImageField DataImageUrlField="StatusPicture">
                                                <ControlStyle Height="100px" Width="100px" CssClass="imageStyle" />
                                                <ItemStyle CssClass="imageStyle" />
                                                </asp:ImageField>
                                                <asp:BoundField DataField="Time of Event" SortExpression="Time of Event" >
                                                <ControlStyle Width="300px" Height="100px" CssClass="elementStyle"/>
                                                <ItemStyle Width="300px" Height="100px" HorizontalAlign="Center" VerticalAlign ="Middle" CssClass="elementStyle"/>
                                                </asp:BoundField>
                                                <asp:BoundField DataField="ETA" ReadOnly="True" SortExpression="ETA">
                                                <ControlStyle Width="300px" Height="100px"  CssClass="elementStyle"/>
                                                <ItemStyle Width="300px" Height="100px" HorizontalAlign="Center" VerticalAlign ="Middle" CssClass="elementStyle"/>
                                                </asp:BoundField>
                                            </Columns>
                                        </asp:GridView>
                                    </td>
                                </tr>
                            </table>
                            <asp:Button ID="btn" runat="server" Style ="visibility:hidden" ClientIDMode="Static" onClick="imageCellButton_Click" Width="150px"/>
                            <br />
                        </asp:View>
                        <asp:View ID="SelectedEmployee" runat="server">
                            <br />
                            <asp:panel ID="divEmployee" runat="server" Style="margin-left:200px" Height="600px" Width="940px">
                                <br />
                                <br />
                                <br />
                                <asp:Label ID="NameLbl" runat="server" Text="Label" style="text-align:center; margin-left: 250px" Font-Names="Lato" Font-Bold="True" Font-Size="X-Large" ForeColor="Black" Width="440px" ></asp:Label>
                                <br />
                                <br />
                                <table>
                                    <tr>
                                        <td class=" tableStyle">
                                            <asp:Image ID="employeeImage" runat="server" CssClass="employeeImageStyle" />
                                        </td>
                                        <td class=" tableStyle">
                                            <asp:GridView ID="personProfileGrid" runat="server" AutoGenerateColumns="False" DataSource="<%# CreateEmployeeGrid() %>" Font-Bold="False" Font-Names="Lato" GridLines="None" Height="60px" OnRowDataBound="EmployeeGridView_RowDataBound" PageSize="3" ShowHeader="False"  Width="340px" CellPadding="4" ForeColor="#333333">
                                                <AlternatingRowStyle BackColor="White" />
                                                <Columns>
                                                    <asp:BoundField DataField="Header">
                                                    <ItemStyle Height="30px" CSSClass="elementStyle" HorizontalAlign="Left" VerticalAlign="Top" Width="100px" Font-Bold="True" />
                                                    </asp:BoundField>
                                                    <asp:BoundField DataField="Employee">
                                                    <ItemStyle Height="30px" CSSClass="elementStyle" HorizontalAlign="Left" VerticalAlign="Top" Width="240px" />
                                                    </asp:BoundField>
                                                </Columns>
                                                <EditRowStyle BackColor="#2461BF" />
                                                <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                                                <HeaderStyle Font-Names="Lato" Font-Size="Medium" Wrap="True" BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                                                <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                                                <RowStyle BackColor="#EFF3FB" />
                                                <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                                                <SortedAscendingCellStyle BackColor="#F5F7FB" />
                                                <SortedAscendingHeaderStyle BackColor="#6D95E1" />
                                                <SortedDescendingCellStyle BackColor="#E9EBEF" />
                                                <SortedDescendingHeaderStyle BackColor="#4870BE" />
                                            </asp:GridView>
                                            <asp:Image ID="statusImage" runat="server" CSSClass="noExcess" Height="340px" Width="340px" />
                                        </td>
                                    </tr>
                                </table>
                                <asp:Button ID="SaveBtn" runat="server" CssClass="button" style="margin-left: 100px;" OnClick="uplodUserImageBtn_Click" Text="Upload"/>
                                <asp:Button ID="browse" runat="server" Text="Browse" OnClientClick="javascript:showBrowseDialog()" CSSClass="button" />
                            </asp:panel>
                        </asp:View>
                    </asp:MultiView>
                </ContentTemplate>
            </asp:UpdatePanel>
            <asp:Button ID="imageUploadingBtn" runat="server" OnClick="imageUploadingBtn_Click" Style="visibility:hidden" Text="Button" /> 
            <asp:FileUpload ID="ImageUpload" runat="server" onchange ="document.getElementById('imageUploadingBtn').click();" Style="visibility:hidden"/>
        </asp:View>
        <asp:View ID="HistoricalView" runat="server">
            <br />
            <table>
                    <tr>
                        <td>
                            <asp:TextBox ID="txtStartTime" runat="server" CSSClass="textField" style="margin-left: 465px;" AutoCompleteType="Disabled" EnableTheming="True"></asp:TextBox>
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
                            <br />
                            <asp:TextBox ID="txtEndTime" runat="server" CSSClass="textField" style="margin-left: 465px" AutoCompleteType="Disabled"></asp:TextBox>
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
                        </td>
                        <td>
                            <asp:UpdatePanel ID="errorMessageUpdatePanel" runat="server">
                                <ContentTemplate>
                                    <asp:Label ID="startTimeLabel" runat="server" ForeColor ="Red"></asp:Label>
                                    <br />
                                    <br />
                                    <asp:Label ID="endTimeLabel" runat="server" ForeColor ="Red"></asp:Label>
                                </ContentTemplate>
                            </asp:UpdatePanel>
                        </td>
                    </tr>
                </table>
            <asp:TextBox ID="txtUser" runat="server" CSSClass="textField" style="margin-left: 565px"></asp:TextBox>
            <br />
            <asp:UpdatePanel ID="SearchButtonUpdate" runat="server">
                    <ContentTemplate>
                            <asp:Button ID="searchBtn" runat="server" CssClass="searchBtn" style="margin-left: 565px" OnClick="SearchUser_Click" Text="Search"/>
                    </ContentTemplate>
                </asp:UpdatePanel>
            <asp:UpdatePanel ID="dataUpdatePanel" runat="server">
                        <ContentTemplate>
                            <asp:GridView ID="dataGridView" DataSource='<%# CreateHistoricalGrid() %>' runat="server" AllowSorting="True" AutoGenerateColumns="False" Height="90px" OnSorting="gridView_Sorting" PageSize="20" style="margin-top: 0px" Width="1400px" CellPadding="4" Font-Names="Lato" ForeColor="#333333" GridLines="None">
                                <AlternatingRowStyle BackColor="White" />
                                <Columns>
                                    <asp:BoundField DataField="User Name" HeaderText="User Name" SortExpression="UserName" ReadOnly="true">
                                    <ControlStyle Width="300px"/>
                                    <ItemStyle Width="300px" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="Event Type" HeaderText="Event Type" ReadOnly="True" SortExpression="EventType">
                                        <ControlStyle Width="200px"/>
                                    <ItemStyle Width="200px" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="Machine Name" HeaderText="Machine Name" SortExpression="MachineName">
                                    <ControlStyle Width="200px"/>
                                    <ItemStyle Width="200px" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="Time of Event" HeaderText="Time of Event" SortExpression="TimeOfEvent">
                                    <ControlStyle Width="300px"/>
                                    <ItemStyle Width="300px" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="Automatic" HeaderText="Automatic" ReadOnly="True" SortExpression="AutomaticLock">
                                    <ControlStyle Width="100px"/>
                                    <ItemStyle Width="100px" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="Remote" HeaderText="Remote" ReadOnly="True" SortExpression="RemoteAccess">
                                    <ControlStyle Width="100px"/>
                                    <ItemStyle Width="100px" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="ETA" HeaderText="ETA" ReadOnly="True" SortExpression="ETA">
                                    <ControlStyle Width="200px"/>
                                    <ItemStyle Width="200px" />
                                    </asp:BoundField>
                                </Columns>
                                <HeaderStyle BackColor="#174669" Font-Bold="False" ForeColor="White" Font-Underline="False" />
                                <RowStyle BackColor="#EFF3FB" />
                            </asp:GridView>
                            <table>
                                <tr>
                                    <td style="width: 1565px; height: 36px;">
                                        <asp:Menu ID="pageMenu" runat="server" ForeColor="White" OnMenuItemClick="pageMenu_MenuItemClick" Orientation="Horizontal" Font-Bold="True" Font-Names="Lato">
                                            <StaticMenuItemStyle BackColor="#174669" BorderStyle="Solid" HorizontalPadding="10px" />
                                            <StaticMenuStyle BackColor="#174669" />
                                            <StaticSelectedStyle BackColor="#5A788E" ForeColor="White" />
                                        </asp:Menu>
                                    </td>
                                    <td>
                                        <asp:Button ID="updateUsers" runat="server" CssClass="button" OnClick="updateUserNames" Text="Update Users"/>
                                    </td>
                                    <td>
                                        <asp:Button ID="exportPageBtn" runat="server" CssClass="button" OnClick="ExportPage_Click" Text="Export Page"/>
                                    </td>
                                    <td>
                                        <asp:Button ID="exportAllBtn" runat="server" CssClass="button" OnClick="ExportAll_Click" Text="Export All"/>

                                    </td>
                                </tr>
                            </table>
                            </ContentTemplate>
                        <Triggers>
                            <asp:PostBackTrigger ControlID="exportPageBtn" />
                            <asp:PostBackTrigger ControlID="exportAllBtn" />
                        </Triggers>

                    </asp:UpdatePanel>
                    
            <script type="text/javascript">
                        var picker = new Pikaday({
                            field: document.getElementById('txtStartTime'),
                            firstDay: 1,
                            minDate: new Date('2017-01-01'),
                            maxDate: new Date('2030-12-31'),
                            yearRange: [2017, 2030],
                            numberOfMonths: 1,
                        });
                    </script>

            <script type="text/javascript">
                        var picker = new Pikaday({
                            field: document.getElementById('txtEndTime'),
                            firstDay: 1,
                            minDate: new Date('2017-01-01'),
                            maxDate: new Date('2030-12-31'),
                            yearRange: [2017, 2030],
                            numberOfMonths: 1,
                        });
                    </script>

        </asp:View>
    </asp:MultiView>
</div>
</form>
</body>
</html>