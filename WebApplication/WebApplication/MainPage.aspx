<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MainPage.aspx.cs" Inherits="WebApplication.MainPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        Historical Data<br />
        <br />
        <asp:TextBox ID="txtUser" runat="server" style="margin-left: 47px" Width="187px"></asp:TextBox>
        <asp:Button ID="SearchUser" runat="server" OnClick="SearchUser_Click" style="margin-left: 59px" Text="Search User" Width="193px" />
        <br />
        <br />
        <br />
        <br />
        <asp:GridView ID="dataGridView" runat="server" HorizontalAlign="Center" Width="1564px">
        </asp:GridView>
        <br />
        <br />
        <br />
        <br />
        <asp:TextBox ID="txtNewEntry" runat="server" style="margin-left: 104px"></asp:TextBox>
        <br />
    
        <asp:Button ID="btnNewEntry" runat="server" OnClick="btnNewEntry_Click" style="margin-left: 89px" Text="New Entry" Width="166px" />
    
    </div>
        <p>
            <asp:Button ID="PreviousPage" runat="server" OnClick="PreviousPage_Click" style="margin-left: 501px" Text="Previous Page" Width="155px" />
            <asp:Button ID="NextPage" runat="server" Height="24px" OnClick="NextPage_Click" style="margin-left: 124px" Text="Next Page" Width="159px" />
        </p>
    </form>
</body>
</html>
