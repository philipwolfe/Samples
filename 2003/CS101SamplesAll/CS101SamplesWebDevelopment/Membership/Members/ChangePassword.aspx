<%@ Page Language="C#" MasterPageFile="~/SiteMaster.master" CodeFile="ChangePassword.aspx.cs" Inherits="ChangePassword_aspx" Title="Change Password" %>
<asp:content contentplaceholderid="PageContent" runat="Server">
<h2>Change Password</h2>

<asp:changepassword id="ChangePassword1" runat="server" canceldestinationpageurl="~/members/securepage.aspx" continuedestinationpageurl="~/members/securepage.aspx" ChangePasswordTitleText="" ConfirmPasswordCompareErrorMessage="The New and Confirm New passwords must match." SuccessTitleText="">
</asp:changepassword>

</asp:content>
