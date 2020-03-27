<%@ Page Language="VB" AutoEventWireup="true" CodeFile="ObjectDataSource.aspx.vb" Inherits="ObjectDataSource_aspx" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.1//EN" "http://www.w3.org/TR/xhtml11/DTD/xhtml11.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Using the ObjectDataSource control</title>
    <LINK rel="stylesheet" type="text/css" href="styles.css">
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
    <h1>
        Using the ObjectDataSource Control</h1>
        <p>
            <a href="start.aspx">Return to Start Page</a></p>
        <p>
            This example shows how to use an <strong>ObjectDataSource</strong> control to create an instance of
    a business object that retrieves product data from the AdventureWorks database. A <strong>GridView</strong> control
    displays the product data by using the <strong>ObjectDataSource</strong> control as its data source.</p>
    
    <asp:Label ID="ProductCountLabel" runat="server" />
    <br />
    
    <asp:GridView ID="ProductsGridView" runat="server" DataSourceID="ProductsObjectDataSource" BackColor="#DEBA84" BorderColor="#DEBA84" BorderStyle="None" BorderWidth="1px" CellPadding="3" CellSpacing="2">
        <FooterStyle BackColor="#F7DFB5" ForeColor="#8C4510" />
        <RowStyle BackColor="#FFF7E7" ForeColor="#8C4510" />
        <PagerStyle ForeColor="#8C4510" HorizontalAlign="Center" />
        <SelectedRowStyle BackColor="#738A9C" Font-Bold="True" ForeColor="White" />
        <HeaderStyle BackColor="#A55129" Font-Bold="True" ForeColor="White" />
    </asp:GridView>
    
    <asp:ObjectDataSource
        ID="ProductsObjectDataSource"
        runat="server"
        SelectMethod="GetAllProducts"
        TypeName="Microsoft.Samples.Web.DataAccess.ProductLogic">
    </asp:ObjectDataSource>
    
    </div>
    </form>
</body>
</html>
