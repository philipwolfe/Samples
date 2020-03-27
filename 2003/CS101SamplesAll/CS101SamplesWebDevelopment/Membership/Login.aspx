<%@ Page Language="C#" MasterPageFile="~/SiteMaster.master" CodeFile="Login.aspx.cs" Inherits="Login_aspx" Title="Login" %>
<asp:content contentplaceholderid="PageContent" runat="Server">
<h2>Login</h2>

<asp:label id="MessageLabel" runat="Server" forecolor="Red" Font-Size=".9em" />

<asp:login id="Login1" runat="server" passwordrecoverytext="I forgot my password" passwordrecoveryurl="~/RecoverPassword.aspx" CreateUserText="Register as New User" CreateUserUrl="~/register.aspx" DestinationPageUrl="~/home.aspx" TitleText="">
</asp:login>

</asp:content>