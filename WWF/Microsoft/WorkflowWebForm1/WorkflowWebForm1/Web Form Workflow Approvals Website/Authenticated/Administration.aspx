<%@ Page Language="C#" MasterPageFile="~/MasterPages/MasterPage.master" AutoEventWireup="true"
	CodeFile="Administration.aspx.cs" Inherits="Authenticated_Administration" Title="City Power &amp; Light - Administration" %>

<%@ Register Src="../Controls/Workflows.ascx" TagName="Workflows" TagPrefix="uc2" %>
<%@ Register Src="../Controls/AssignUsersToRoles.ascx" TagName="AssignUsersToRoles"
	TagPrefix="uc1" %>
<asp:Content ID="content" ContentPlaceHolderID="bodyContentPlaceHolder" runat="Server">
	<table width="100%" cellpadding="5" cellspacing="5" border="0">
		<tr>
			<td>
				<uc2:Workflows ID="workflows" runat="server" />
			</td>
			<td style="width: 250px;">
				<uc1:AssignUsersToRoles ID="assignUsersToRoles" runat="server" />
			</td>
		</tr>
	</table>
</asp:Content>
