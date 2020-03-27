<%@ Page Language="C#" MasterPageFile="~/SiteMaster.master" CodeFile="CreateUser.aspx.cs" Inherits="CreateUser_aspx" Title="Create User" %>
<asp:content contentplaceholderid="PageContent" runat="Server">
<h2>Create User</h2>

<asp:label id="MessageLabel" runat="Server" forecolor="Red" Font-Size=".9em" />

<p>If you can see this page, then you must belong to the Administrator role.</p>

<p>This page does not use the CreateUserWizard control. It uses a regular HTML table for the form
and then makes calls to the Membership API to create the user and add the user to the specified
role.</p>

<asp:Panel ID="NewUserPanel" runat="server">
<h3>New User Information</h3>
<table border="0" cellpadding="2" cellspacing="3" width="400" style="border-right: navy 2px solid; border-top: navy 2px solid; border-left: navy 2px solid; border-bottom: navy 2px solid"><tr>
    </tr>
    <tr>
        <td align="left">User Name:</td>
        <td align="left">
            <asp:textbox id="UserNameTextbox" runat="Server" width="125px" />
            <asp:requiredfieldvalidator id="RequiredFieldValidator1" runat="server" controltovalidate="UserNameTextbox">*</asp:requiredfieldvalidator>
        </td>
    </tr>
    <tr>
        <td align="left">Password:</td>
        <td align="left">
            <asp:textbox id="PasswordTextbox" runat="Server" width="125px" textmode="Password" />
            <asp:requiredfieldvalidator id="RequiredFieldValidator2" runat="server" controltovalidate="PasswordTextbox">*</asp:requiredfieldvalidator>
        </td>
    </tr>
    <tr>
        <td align="left">Confirm Password:</td>
        <td align="left">
            <asp:textbox id="ConfirmPasswordTextbox" runat="Server" width="125px" textmode="Password" />
            <asp:requiredfieldvalidator id="RequiredFieldValidator3" runat="server" controltovalidate="ConfirmPasswordTextbox">*</asp:requiredfieldvalidator>
            <asp:comparevalidator id="CompareValidator1" runat="server" errormessage=" Must match password." controltovalidate="ConfirmPasswordTextbox" display="Dynamic" controltocompare="PasswordTextbox" />
        </td>
    </tr>
    <tr>
        <td align="left">Email:</td>
        <td align="left">
            <asp:textbox id="EmailTextbox" runat="Server" width="125px" />
            <asp:requiredfieldvalidator id="RequiredFieldValidator4" runat="server" controltovalidate="EmailTextbox">*</asp:requiredfieldvalidator>
        </td>
    </tr>
    <tr>
        <td align="left">Security Question:</td>
        <td align="left">
            <asp:textbox id="SecurityQuestionTextbox" runat="Server" width="125px" />
            <asp:requiredfieldvalidator id="RequiredFieldValidator5" runat="server" controltovalidate="SecurityQuestionTextbox">*</asp:requiredfieldvalidator>
        </td>
    </tr>
    <tr>
        <td align="left">Security Answer</td>
        <td align="left">
            <asp:textbox id="SecurityAnswerTextbox" runat="Server" width="125px" />
            <asp:requiredfieldvalidator id="RequiredFieldValidator6" runat="server" controltovalidate="SecurityAnswerTextbox">*</asp:requiredfieldvalidator>
        </td>
    </tr>
    <tr>
        <td align="left">Role:</td>
        <td align="left"><asp:dropdownlist id="RolesDropDownList" runat="Server" /></td>
    </tr>
    <tr>
        <td>&nbsp;</td>
        <td align="left"><asp:button id="CreateUserButton" runat="Server" text="Create User" onclick="CreateUserButton_Click" /></td>
    </tr></table>
</asp:Panel>
</asp:content>
