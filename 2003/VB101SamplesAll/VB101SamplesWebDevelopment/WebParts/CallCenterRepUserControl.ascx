<%@ Control Language="VB" AutoEventWireup="true" CodeFile="CallCenterRepUserControl.ascx.vb" Inherits="CallCenterRepUserControl_ascx" %>
<table border="0" cellpadding="3" cellspacing="2">
    <tr>
        <td>Name:</td>
        <td><asp:textbox id="NameTextbox" runat="server" /></td>
    </tr>
    <tr>
        <td>Employee ID:</td>
        <td><asp:textbox id="EmployeeIdTextbox" runat="server" /></td>
    </tr>
    <tr>
        <td>Extension:</td>
        <td><asp:textbox id="ExtensionTextbox" runat="server" /></td>
    </tr>
    <tr>
        <td>Department #:</td>
        <td><asp:textbox id="DepartmentNumberTextbox" runat="server" /></td>
    </tr>
    <tr>
        <td>&nbsp;</td>
        <td><asp:button id="SaveButton" runat="server" text="Save" /></td>
    </tr>
</table>
