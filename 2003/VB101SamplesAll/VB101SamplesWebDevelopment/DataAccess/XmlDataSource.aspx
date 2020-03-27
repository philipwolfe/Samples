<%@ Page Language="VB" AutoEventWireup="true" CodeFile="XmlDataSource.aspx.vb" Inherits="XmlDataSource_aspx" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.1//EN" "http://www.w3.org/TR/xhtml11/DTD/xhtml11.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Using the XmlDataSource control</title>
    <LINK rel="stylesheet" type="text/css" href="styles.css">
    <style>TABLE, TR, TD {border: 2px double #DEBA84}</style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
    <h1>
        Using the XmlDataSource Control</h1>
        <p>
            <a href="start.aspx">Return to Start Page</a></p>
        <p>
            This example uses an <strong>XmlDataSource </strong>control to display product data, which is stored
    in an XML file. The data is displayed using a <strong>Repeater </strong>
            control.</p>
    
    <table cellpadding="3" cellspacing="0">
    <asp:Repeater DataSourceID="ProductsXmlDataSource" ID="ProductsRepeater" runat="server">
        <HeaderTemplate>
            <tr style="background-color: #A55129; font-weight:bold; color: Blue;">
                <td>ProductID</td>
                <td>Name</td>
                <td>ProductNumber</td>
                <td>ReorderPoint</td>
                <td>StandardCost</td>
                <td>ListPrice</td>
            </tr>
        </HeaderTemplate>
        <ItemTemplate>
            <tr style="background-color: #FFF7E7; color: #8C4510">
                <td><%# XPath("ProductID")%></td>
                <td><%# XPath("Name") %></td>
                <td><%# XPath("ProductNumber") %></td>
                <td><%# XPath("ReorderPoint") %></td>
                <td><%# XPath("StandardCost") %></td>
                <td><%# XPath("ListPrice") %></td>
            </tr>
        </ItemTemplate>
    </asp:Repeater>
    </table>
    
    <asp:XmlDataSource
        DataFile="Products.xml"
        ID="ProductsXmlDataSource"
        runat="server"
        EnableCaching="False"
        XPath="/Products/Product">
    </asp:XmlDataSource>
</div>
    </form>

</body>
</html>
