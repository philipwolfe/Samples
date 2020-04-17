<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Default.aspx.vb" Inherits="_Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Orders that need to be processed</title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
        Click on link below to work on an order that has already been created but has not finished being processed yet.<br/><br/>
            <asp:Table ID="workflowTable" runat="server">
            </asp:Table>
            <br />
            &nbsp;<asp:Button ID="btnCreateNewOrder" runat="server" OnClick="btnCreateNewOrder_Click"
                Text="Create New Order" /></div>
    </form>
</body>
</html>
