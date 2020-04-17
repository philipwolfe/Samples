<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Order.aspx.vb" Inherits="Order" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>Order Service Sample</title>
</head>
<body>
    <form id="form2" runat="server">
    <div>
        <br />
        Order Number &nbsp; &nbsp;
        <asp:TextBox ID="txtOrderNumber" runat="server" TabIndex="1">12345</asp:TextBox><br />
        <br />
        Workflow InstanceId -
        <%--<asp:TextBox ID="txtWorkflowInstanceId" runat="server" Enabled="False" Width="279px"></asp:TextBox>--%>
        <asp:Label ID="lblWorkflowInstanceId" runat="server" Width="462px" ForeColor="#00C000"></asp:Label><br />
        <br />
        Workflow Status -
        <%--<asp:TextBox ID="txtOrderStatus" runat="server" Enabled="False" Width="243px"></asp:TextBox><br />--%>
        <asp:Label ID="lblOrderStatus" runat="server" Width="245px" ForeColor="Blue"></asp:Label><br />
        <br />
        &nbsp;<asp:Button ID="btnCreateOrder" runat="server" Text="Create Order" OnClick="btn_Click" TabIndex="2" Enabled="False" />
        &nbsp; &nbsp;
        <asp:Button ID="btnProcessOrder" runat="server" OnClick="btn_Click" TabIndex="3"
            Text="Process Order" Enabled="False" />
        &nbsp; &nbsp;
        <asp:Button ID="btnShipOrder" runat="server" OnClick="btn_Click" Text="Ship Order" Enabled="False" /></div>
    </form>
</body>
</html>
