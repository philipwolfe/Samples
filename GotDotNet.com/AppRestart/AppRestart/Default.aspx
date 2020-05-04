<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="AppRestart._Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Untitled Page</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Restart App" />
        <asp:Button ID="Button2" runat="server" OnClick="Button2_Click" Text="Test Exception" />&nbsp;<asp:Button
            ID="Button3" runat="server" OnClick="Button3_Click" Text="Install Sql Event Provider" /><br />
        <br />
        <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/Report.aspx">Reports</asp:HyperLink></div>
    </form>
</body>
</html>
