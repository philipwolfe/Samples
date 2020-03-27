<%@ Page Language="VB" MasterPageFile="~/SiteMaster.master" CodeFile="DeleteUser.aspx.vb" Inherits="DeleteUser_aspx" Title="Delete User" %>
<asp:content contentplaceholderid="PageContent" runat="Server">
<h2>Delete User</h2>

<asp:label id="MessageLabel" runat="Server" forecolor="Red" Font-Size=".9em" />

<p>If you can see this page, then you must belong to the Administrator role.</p>

<p>This page simply takes in a username and deletes it from the database and removes it from its role,
all using the Membership API programmatically.</p>

<p>User name:
    <asp:textbox id="UserNameTextbox" runat="Server" width="125px" />
    <asp:button id="DeleteButton" runat="Server" text="Delete" onclick="DeleteButton_Click" />
</p>    

<br />
<br />

</asp:content>
