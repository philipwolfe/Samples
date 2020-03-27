<%@ Page Language="VB" MasterPageFile="~/SiteMaster.master" CodeFile="Login.aspx.vb" Inherits="Login_aspx" Title="Login" %>
<asp:content contentplaceholderid="PageContent" runat="Server">
<h2>Login</h2>

<asp:label id="MessageLabel" runat="Server" forecolor="Red" Font-Size=".9em" />

<p>This login page does not use the <strong>Login </strong>control. Instead, it uses a regular HTML table to display
the form and then calls the <strong>ValidateUser </strong>
    method of the <strong>Membership </strong>class to perform the actual logging
in of the user.</p>
    <p>
        This sample site comes with several users already created: AdminUser, ContractorUser,
        EmployeeUser and ManagerUser. They are members of one role, respectively: Administrator,
        Contractor, Employee and Manager. For the sake of simplicty all share the same password:
        <strong>123$rt56</strong>.</p>

<div align="center">
    <table border="0" cellpadding="2" cellspacing="3" width="300" style="border-right: navy 2px solid; border-top: navy 2px solid; border-left: navy 2px solid; border-bottom: navy 2px solid">
        <tr><td align="left">&nbsp;</td></tr>
        <tr>
            <td align="left">User Name:</td>
            <td align="left">
                <asp:textbox id="UserNameTextbox" runat="Server" width="150px" />
                <asp:requiredfieldvalidator id="RequiredFieldValidator1" runat="server" controltovalidate="UserNameTextbox">*</asp:requiredfieldvalidator>
            </td>
        </tr>
        <tr>
            <td align="left">Password:</td>
            <td align="left">
                <asp:textbox id="PasswordTextbox" runat="Server" width="150px" textmode="Password" />
                <asp:requiredfieldvalidator id="RequiredFieldValidator2" runat="server" controltovalidate="PasswordTextbox">*</asp:requiredfieldvalidator></td>
        </tr>
        <tr>
            <td>&nbsp;</td>
            <td align="left"><asp:button id="LoginButton" runat="Server" text="Login" onclick="LoginButton_Click" /></td>
        </tr>
    </table>
</div>

</asp:content>