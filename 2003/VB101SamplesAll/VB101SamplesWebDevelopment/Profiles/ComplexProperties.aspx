<%@ Page Language="VB" AutoEventWireup="true" CodeFile="ComplexProperties.aspx.vb" Inherits="ComplexProperties_aspx" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.1//EN" "http://www.w3.org/TR/xhtml11/DTD/xhtml11.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Using Complex Profile Properties</title>
    <LINK rel="stylesheet" type="text/css" href="styles.css">
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <h1>Using Complex Profile Properties</h1>
    <p><a href="start.aspx">Return to Start Page</a></p>
 
       <p>This part of the sample allows you to set more complex profile properties, in this case a
        collection of names (a buddy list) and a custom Address object. Again, this is all being done
        without the need to log in.</p>
       
       <p><b>Note: </b>Keep in mind a limitation of this sample. If you have not yet <a href=MigratingProperties.aspx>logged in</a> 
       and you make changes here as an anonymous user, when you do log in the changes will automatically 
       migrate to your authenticated user profile.</p> 
        
        <h3>Manage My Buddy List</h3>
        <p><asp:Literal ID="NoBuddiesMsg" runat="server" text="You have no buddies in your list." /><asp:dropdownlist id="BuddyDropDownList" runat="server" />&nbsp;<asp:button id="DeleteButton" runat="server" text="Delete" onclick="DeleteButton_Click" /></p>
        <p>
            New Buddy Name:<br />
            <asp:textbox id="BuddyNameTextBox" runat="server" />&nbsp;<asp:button id="AddButton" runat="server" text="  Add  " onclick="AddButton_Click" />&nbsp;
        </p>

        <h3>Add/Update My Address</h3>        
        <table border="0" cellpadding="2" cellspacing="3">
            <tr>
                <td width="150px">Street:</td>
                <td><asp:textbox id="StreetTextBox" runat="server" /></td>
            </tr>
            <tr>
                <td>City:</td>
                <td><asp:textbox id="CityTextBox" runat="server" /></td>
            </tr>
            <tr>
                <td>State:</td>
                <td><asp:textbox id="StateTextBox" runat="server" /></td>
            </tr>
            <tr>
                <td>Zip Code:</td>
                <td><asp:textbox id="ZipCodeTextBox" runat="server" /></td>
            </tr>
            <tr>
                <td>&nbsp;</td>
                <td><asp:button id="SaveButton" runat="server" text="Save" onclick="SaveButton_Click" /></td>
            </tr>
        </table>
    </div>
    </form>
</body>
</html>
