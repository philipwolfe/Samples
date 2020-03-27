<%@ Page Language="VB" AutoEventWireup="true" CodeFile="MigratingProperties.aspx.vb" Inherits="MigratingProperties_aspx" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.1//EN" "http://www.w3.org/TR/xhtml11/DTD/xhtml11.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Migrating Anonymous Profile Properties to Your Authenticated User</title>
    <LINK rel="stylesheet" type="text/css" href="styles.css">
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <h1>Migrating Anonymous Profile Properties to Your Authenticated User</h1>
    <p><a href="start.aspx">Return to Start Page</a></p>

        <p>This part of the sample shows how an anonymous profile is migrated to a logged in user
        account. Using the link below, login to the site (be sure to create a user first). Upon
        logging in, all your anonymous profile properties that you set in the first two examples 
        will be migrated to your logged in account. This occurs by handling the MigrateAnonymous event in
        the Global.asax file.</p>
        
        <p>
        <asp:loginview id="LoginView1" runat="server">
            <loggedintemplate>
             Hello, <b><asp:loginname id="LoginName1" runat="server" /></b>. <asp:loginstatus id="LoginStatus1" runat="server" logoutpageurl="~/migratingproperties.aspx" logoutaction="Redirect" />
            </loggedintemplate>
            <anonymoustemplate>
                Please log in or create a new user account to migrate the existing anonymous profile to a specific user account.
                <table cellpadding="5">
                <tr><td valign="top">
                <asp:login backcolor="#EFF3FB" bordercolor="#B5C7DE" borderstyle="Solid" borderwidth="1px" font-names="Verdana" font-size="Small" id="Login1" runat="server" destinationpageurl="~/MigratingProperties.aspx" BorderPadding="0" ForeColor="#333333" VisibleWhenLoggedIn="False">
                    <titletextstyle backcolor="#507CD1" font-bold="True" forecolor="White" Font-Size="0.9em" />
                    <LoginButtonStyle BackColor="White" BorderColor="#507CD1" BorderStyle="Solid" BorderWidth="1px"
                        Font-Names="Verdana" Font-Size="1em" ForeColor="#284E98" />
                    <TextBoxStyle Font-Size="0.8em" />
                    <InstructionTextStyle Font-Italic="True" ForeColor="Black" />
                </asp:login>
                </td><td valign="top">
                <asp:createuserwizard backcolor="#EFF3FB" bordercolor="#B5C7DE" borderstyle="Solid" borderwidth="1px" continuedestinationpageurl="~/MigratingProperties.aspx" font-names="Verdana" font-size="Large" id="CreateUserWizard1" runat="server" ConfirmPasswordCompareErrorMessage="The passwords must match.">
                    <wizardsteps>
                        <asp:createuserwizardstep ID="Createuserwizardstep1" runat="server">
                        </asp:createuserwizardstep>
                        <asp:completewizardstep ID="Completewizardstep1" runat="server">
                        </asp:completewizardstep>
                    </wizardsteps>
                    <sidebarstyle backcolor="#507CD1" font-size="0.9em" verticalalign="Top" />
                    <sidebarbuttonstyle font-names="Verdana" forecolor="White" BackColor="#507CD1" />
                    <navigationbuttonstyle backcolor="White" bordercolor="#507CD1" borderstyle="Solid" borderwidth="1px" font-names="Verdana" forecolor="#284E98" />
                    <headerstyle backcolor="#284E98" borderstyle="Solid" font-bold="True" font-size="0.9em" forecolor="White" horizontalalign="Center" BorderColor="#EFF3FB" BorderWidth="2px" />
                    <createuserbuttonstyle backcolor="White" bordercolor="#507CD1" borderstyle="Solid" borderwidth="1px" font-names="Verdana" forecolor="#284E98" Font-Size="Small" />
                    <continuebuttonstyle backcolor="White" bordercolor="#507CD1" borderstyle="Solid" borderwidth="1px" font-names="Verdana" forecolor="#284E98" Font-Size="Small" />
                    <stepstyle Font-Size="0.8em" />
                    <titletextstyle backcolor="#507CD1" font-bold="True" forecolor="White" />
                </asp:createuserwizard>
                </td></tr></table>
            </anonymoustemplate>
        </asp:loginview>
        </p>

        <h3>Current User Information</h3>
        <p>
            <b>Name</b>: <%= Profile.UserName %><br />
            <b>Anonymous</b>: <%= Profile.IsAnonymous.ToString() %>
        </p>

        <asp:Literal ID="AnonUserMsg" runat="server" Text="<p>The authenticated user profile is not visible until you log in.</p>" />

        <asp:Panel ID="ProfilePanel" runat="server" Visible="false">
        <table border="0" cellpadding="2" cellspacing="3">
            <tr>
                <td width="100px">Buddy List:</td>
                <td><asp:dropdownlist id="BuddyDropDownList" runat="server"></asp:dropdownlist><asp:Literal ID="NoBuddiesMsg" runat="server" text="You have no buddies in your list." /></td>
            </tr>
            <tr>
                <td>First Name:</td>
                <td><%= Profile.FirstName %></td>
            </tr>
            <tr>
                <td>Last Name:</td>
                <td><%= Profile.LastName%></td>
            </tr>
            <tr>
                <td>Street:</td>
                <td><%= Street %></td>
            </tr>
            <tr>
                <td>City:</td>
                <td><%= City %></td>
            </tr>
            <tr>
                <td>State:</td>
                <td><%= State %></td>
            </tr>
            <tr>
                <td>Zip Code:</td>
                <td><%= ZipCode %></td>
            </tr>
        </table>
  </asp:Panel>
    </div>
    </form>
</body>
</html>
