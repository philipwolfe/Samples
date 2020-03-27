<%@ Page Language="VB" MasterPageFile="~/SiteMaster.master" CodeFile="ViewUsers.aspx.vb" Inherits="ViewUsers_aspx" Title="View Users" %>
<asp:content contentplaceholderid="PageContent" runat="Server">
<h2>View Users</h2>

<asp:label id="MessageLabel" runat="Server" forecolor="Red" Font-Size=".9em" />

<p>If you can see this page, then you must belong to the Administrator role.</p>
<p>
    The GridView binds to a <strong>SqlDataSource </strong>component configured to use
    a custom JOIN statement to pull data from the MDF file in the <strong>app_data </strong>
    folder. You could also bind to the <strong>MembershipUserCollection</strong> returned
    by a call to <strong>Membership.GetAllUsers()</strong>.</p>

<asp:gridview id="GridView1" runat="server" cellpadding="4" GridLines="None" AutoGenerateColumns="False" DataSourceID="SqlDataSource1" ForeColor="#333333">
    <footerstyle forecolor="White" backcolor="#1C5E55" Font-Bold="True"></footerstyle>
    <pagerstyle forecolor="White" horizontalalign="Center" backcolor="#666666"></pagerstyle>
    <headerstyle forecolor="White" font-bold="True" backcolor="#1C5E55"></headerstyle>
    <selectedrowstyle forecolor="#333333" font-bold="True" backcolor="#C5BBAF"></selectedrowstyle>
    <rowstyle backcolor="#E3EAEB"></rowstyle>
    <AlternatingRowStyle BackColor="White" />
    <Columns>
        <asp:BoundField DataField="UserName" HeaderText="UserName" SortExpression="UserName" />
        <asp:BoundField DataField="UserId" HeaderText="UserId" SortExpression="UserId" />
        <asp:BoundField DataField="RoleName" HeaderText="RoleName" SortExpression="RoleName" />
        <asp:BoundField DataField="RoleId" HeaderText="RoleId" SortExpression="RoleId" />
        <asp:BoundField DataField="LastActivityDate" HeaderText="LastActivityDate" SortExpression="LastActivityDate" />
    </Columns>
    <EditRowStyle BackColor="#7C6F57" />
</asp:gridview>
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:App_DataConnectionString %>"
        SelectCommand="SELECT DISTINCT aspnet_Users.UserName, aspnet_Users.UserId, aspnet_Roles.RoleName, aspnet_Roles.RoleId, aspnet_Users.LastActivityDate FROM aspnet_Roles INNER JOIN aspnet_UsersInRoles ON aspnet_Roles.RoleId = aspnet_UsersInRoles.RoleId INNER JOIN aspnet_Users ON aspnet_UsersInRoles.UserId = aspnet_Users.UserId">
    </asp:SqlDataSource>
    
</asp:content>
