<%@ Page Language="VB" AutoEventWireup="true" CodeFile="SqlDataSource.aspx.vb" Inherits="SqlDataSource_aspx" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.1//EN" "http://www.w3.org/TR/xhtml11/DTD/xhtml11.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Using the SqlDataSource control</title>
    <LINK rel="stylesheet" type="text/css" href="styles.css">
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
    <h1>
        Using the SqlDataSource Control</h1>
        <p>
            <a href="start.aspx">Return to Start Page</a></p>
        <p>
            This part of the sample uses a <strong>SqlDataSource</strong> control to get product data from the
    AdventureWorks database. The <strong>SqlDataSource </strong>control is then used by a <strong>GridView</strong> control for
    displaying the data.</p>

    <asp:Button ID="GetProductsButton" runat="server" Text="Get Products" OnClick="GetProductsButton_Click" />
    <br />
    <br />
    <asp:GridView CellPadding="3" DataSourceID="ProductsSqlDataSource" EmptyDataText="There are no data records to display." ID="ProductsGridView" runat="server" AllowSorting="True" Visible="False" BackColor="#DEBA84" BorderColor="#DEBA84" BorderWidth="1px" BorderStyle="None" CellSpacing="2">
        <FooterStyle BackColor="#F7DFB5" ForeColor="#8C4510" />
        <PagerStyle ForeColor="#8C4510" HorizontalAlign="Center" />
        <SelectedRowStyle BackColor="#738A9C" ForeColor="White" Font-Bold="True" />
        <HeaderStyle BackColor="#A55129" Font-Bold="True" ForeColor="White" />
        <RowStyle BackColor="#FFF7E7" ForeColor="#8C4510" />
    </asp:GridView>
        &nbsp;
        <asp:SqlDataSource 
            ID="ProductsSqlDataSource" runat="server" 
            ConnectionString="<%$ ConnectionStrings:AppConnectionString1 %>" 
            SelectCommand="SELECT [ProductID], [Name], [ProductNumber], [ReorderPoint], [StandardCost], [ListPrice] FROM [Production].[Product]" 
            ProviderName="<%$ ConnectionStrings:AppConnectionString1.ProviderName %>">
        </asp:SqlDataSource>
    </div>
    </form>
</body>
</html>
