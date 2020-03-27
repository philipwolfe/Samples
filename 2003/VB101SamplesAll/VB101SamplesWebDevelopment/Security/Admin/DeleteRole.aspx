<%@ Page Language="VB" MasterPageFile="~/SiteMaster.master" CodeFile="DeleteRole.aspx.vb" Inherits="DeleteRole_aspx" Title="Delete Role" %>
<asp:content contentplaceholderid="PageContent" runat="Server">
<h2>Delete Role</h2>

<asp:label id="MessageLabel" runat="Server" forecolor="Red" Font-Size=".9em" />

<p>If you can see this page, then you must belong to the Administrator role.</p>
<p>This page is used to delete an existing role using code.</p>

<p>Role Name:
    <asp:textbox id="RoleTextbox" runat="Server" width="125px" />
    <asp:button id="DeleteButton" runat="Server" text="Delete Role" onclick="DeleteButton_Click" />
</p> 

<br />
<br />
</asp:content>
