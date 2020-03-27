<%@ Page Language="C#" MasterPageFile="~/SiteMaster.master" CodeFile="Home.aspx.cs" Inherits="Home_aspx" Title="Start Page" %>
<asp:content contentplaceholderid="PageContent" runat="Server">
<h2>Sample Site Home</h2>

<p>This is an unsecure home page, accessible to all users.</p>

<asp:loginview id="LoginView1" runat="server">
    <anonymoustemplate>
        <p>The secure navigation menu is not visible until you <a href=login.aspx>log in</a>. 
        <a href="admin/admin.aspx">Click here</a> to see what happens when you try to access a secure page without being logged in or a member of the page's associated role(s).</p>
    </anonymoustemplate>   
</asp:loginview>
<br />
<br />
<br />
<br />
</asp:content>