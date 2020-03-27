<%@ Page Language="VB" AutoEventWireup="true" CodeFile="SimpleProperties.aspx.vb" Inherits="SimpleProperties_aspx" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.1//EN" "http://www.w3.org/TR/xhtml11/DTD/xhtml11.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Using Simple Profile Properties</title>
    <LINK rel="stylesheet" type="text/css" href="styles.css">
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <h1>Using Simple Profile Properties</h1>
    <p><a href="start.aspx">Return to Start Page</a></p>

        <p>This part of the sample uses two simple properties in the profile: FirstName and LastName. These
        properties are used to display a welcome message when you see this page. The message won't display
        unless both properties are set, which you can do by entering the data in the textboxes and clicking
        the "Set Profile" button. Then each time you come back to this page, you'll see the welcome message.
        Also note that this is done without your having to login.</p>

        <h3><asp:Label ID="WelcomeMsgLabel" runat="server"></asp:Label></h3>

        <table border="0" cellpadding="2" cellspacing="1">
            <tr>
                <td>First Name:</td>
                <td>Last Name:</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td>
                    <asp:TextBox ID="FirstNameTextBox" runat="server" />
                    <asp:requiredfieldvalidator controltovalidate="FirstNameTextBox" errormessage="*" id="RequiredFieldValidator1" runat="server" />
                </td>
                <td>
                    <asp:TextBox ID="LastNameTextBox" runat="server" />
                    <asp:requiredfieldvalidator controltovalidate="LastNameTextBox" errormessage="*" id="RequiredFieldValidator2" runat="server" />
                </td>
                <td>
                    <asp:Button ID="SetProfileButton" runat="server" Text="Set Profile" onclick="SetProfileButton_Click" />
                </td>
            </tr>
        </table>
    </div>
    </form>
</body>
</html>
