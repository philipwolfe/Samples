<%@ Page Language="C#" MasterPageFile="~/SiteMaster.master" CodeFile="CreateRole.aspx.cs" Inherits="CreateRole_aspx" Title="Create Role" %>
<asp:content contentplaceholderid="PageContent" runat="Server">
<h2>Create Role</h2>

<asp:label id="MessageLabel" runat="Server" forecolor="Red" Font-Size=".9em" />

<p>If you can see this page, then you must belong to the Administrator role.</p>
<p>This page is used to programmatically create new roles. Keep in mind that this merely adds a new role to the 
application's database. It does not secure a folder based on this new role. You still have to modify the web.config 
file or add code to call the User.IsInRole method to secure a folder based on this new role.</p>

<p>
    New Role Name: <asp:textbox id="RoleTextbox" runat="Server" width="125px" />
    <asp:button id="CreateButton" runat="Server" text="Create Role" onclick="CreateButton_Click" />
</p>


<br />
<br />
</asp:content>
