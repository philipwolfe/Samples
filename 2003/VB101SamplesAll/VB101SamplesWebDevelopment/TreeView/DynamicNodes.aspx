<%@ Page Language="VB" CodeFile="DynamicNodes.aspx.vb" Inherits="DynamicNodes_aspx" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.1//EN" "http://www.w3.org/TR/xhtml11/DTD/xhtml11.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Dynamically Adding Nodes at Runtime</title>
	<LINK rel="stylesheet" type="text/css" href="styles.css">
</head>
<body>
    <form id="form1" runat="server">
    <table border="0" cellpadding="5" cellspacing="0">
        <tr>
            <td valign="top">
                <asp:treeview id="TreeView1" runat="server" imageset="Msdn" nodeindent="10">
                    <selectednodestyle backcolor="White" verticalpadding="1" bordercolor="#888888" borderstyle="Solid" borderwidth="1px" horizontalpadding="3"></selectednodestyle>
                    <nodestyle verticalpadding="2" font-names="Verdana" font-size="8pt" nodespacing="1" horizontalpadding="5" forecolor="Black"></nodestyle>
                    <hovernodestyle backcolor="#CCCCCC" bordercolor="#888888" borderstyle="Solid" borderwidth="1px" font-underline="True"></hovernodestyle>
                </asp:treeview>
            </td>
            <td valign="top">
		<h1>Dynamically Adding Nodes at Runtime</h1>

                <p>This page demonstrates how to build a TreeView control dynamically at runtime. For example,
                the nodes in this tree were built during the page's OnLoad event.</p>
                <p><strong>Note: </strong>These nodes do not link to any real pages.</p>
                <p><a href="Start.aspx">Return to Start Page</a></p>
            </td>
        </tr>
    </table>
    </form>
</body>
</html>
