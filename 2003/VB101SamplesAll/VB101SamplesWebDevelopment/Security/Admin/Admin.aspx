<%@ Page Language="VB" MasterPageFile="~/SiteMaster.master" CodeFile="Admin.aspx.vb" Inherits="Admin_aspx" Title="Administration" %>
<asp:content contentplaceholderid="PageContent" runat="Server">
<h2>Administration</h2>
<p>If you can see this page, then you must belong to the Administrator role.</p>

<table border="1" cellpadding="5" cellspacing="0">
    <tr>
        <td valign="top">
            <h3>Manage Users</h3>
            <asp:hyperlink id="Hyperlink1" navigateurl="~/Admin/CreateUser.aspx" runat="Server">Create User</asp:hyperlink><br />
            <asp:hyperlink id="Hyperlink2" navigateurl="~/Admin/DeleteUser.aspx" runat="Server">Delete User</asp:hyperlink><br />
            <asp:hyperlink id="Hyperlink3" navigateurl="~/Admin/ViewUsers.aspx" runat="Server">View Users</asp:hyperlink>
        </td>
        <td valign="top">
            <h3>Manage Roles</h3>
            <asp:hyperlink id="Hyperlink4" navigateurl="~/Admin/CreateRole.aspx" runat="Server">Create Role</asp:hyperlink><br />
            <asp:hyperlink id="Hyperlink5" navigateurl="~/Admin/DeleteRole.aspx" runat="Server">Delete Role</asp:hyperlink>
        </td>
    </tr>
</table>
</asp:content>
