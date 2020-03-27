<%@ Page Language="VB" CodeFile="RespondToNodeClick.aspx.vb" Inherits="RespondToNodeClick_aspx" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.1//EN" "http://www.w3.org/TR/xhtml11/DTD/xhtml11.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Responding to a Node Click Event</title>
	<LINK rel="stylesheet" type="text/css" href="styles.css">
</head>
<body>
    <form id="form1" runat="server">
    <table border="0" cellpadding="5" cellspacing="0">
        <tr>
            <td valign="top">
                <asp:treeview id="TreeView1" runat="server" imageset="Faq" onselectednodechanged="TreeView1_SelectedNodeChanged" enableviewstate="True">
                    <selectednodestyle font-underline="True"></selectednodestyle>
                    <nodestyle font-names="Tahoma" font-size="8pt" horizontalpadding="5" forecolor="DarkBlue"></nodestyle>
                    <hovernodestyle font-underline="True" forecolor="Purple"></hovernodestyle>
                </asp:treeview>
            </td>
            <td valign="top">
	        <h1>Responding to a Node Click Event</h1>

                <p>This page demonstrates how to handle a node click event (SelectedNodeChanged). You
                can handle this event to perform actions specific to the node that was clicked.
                For instance, a node might link to another page in your site that requires data sent
                via a query string. You can handle this event so that you can build the
                required query string data before making the page request.</p>
                
                <p>The SelectedNodeChanged event handler has been coded to place the selected node's text 
                and value in the appropriate textboxes below.</p>
                
                <p><a href="Start.aspx">Return to Start Page</a></p>
                
                <p>
                Selected node text: <asp:textbox id="NodeText" runat="server"></asp:textbox>
                <br />
                Selected node value: <asp:textbox id="NodeUrl" runat="server"></asp:textbox>
                </p>
            </td>
        </tr>
    </table>
    </form>
</body>
</html>
