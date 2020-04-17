<%@ Page Language="C#" AutoEventWireup="true" CodeFile="OrderCompleted.aspx.cs" Inherits="OrderCompleted" %>

 

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">

<head id="Head1" runat="server">

    <title>Order Completed</title>

</head>

<body>

    <form id="form1" runat="server">

        <div>

            Order

            <asp:Label ID="lblOrderNumber" runat="server" ForeColor="Navy"></asp:Label>

            Completed<br />

            <br />

            Workflow InstanceId -

            <asp:Label ID="lblWorkflowInstanceId" runat="server" ForeColor="Green"></asp:Label><br />

            <br />

            <asp:Button ID="btnNewOrder" runat="server" OnClick="btnNewOrder_Click" Text="New Order" /></div>

    </form>

</body>

</html>

