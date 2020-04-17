<%@ Page Language="C#" MasterPageFile="~/MasterPages/MasterPage.master" AutoEventWireup="true"
	CodeFile="WorkflowInstance.aspx.cs" Inherits="Authenticated_WorkflowInstance" Title="City Power &amp; Light - Workflow Instance Details" %>

<%@ Register Src="../Controls/AssignAnotherUser.ascx" TagName="AssignAnotherUser"
	TagPrefix="uc1" %>
<%@ Register Src="~/Controls/AssignToAnotherRole.ascx" TagName="AssignAnotherRole"
	TagPrefix="uc2" %>
<%@ Register Src="../Controls/TaskTracking.ascx" TagName="TaskTracking" TagPrefix="uc2" %>
<asp:Content ID="content" runat="server" ContentPlaceHolderID="bodyContentPlaceHolder">
	<table width="100%" cellpadding="5" cellspacing="5" border="0">
		<tr>
			<td style="width: 500px;">
				<img alt="workflow image" src="../workflowImages/test.png?act=<%= activityName %>&type=<%= workflowTypeName %>" />
			</td>
			<td>
				<uc2:AssignAnotherRole ID="assignAnotherRole" runat="server" />
				<uc1:AssignAnotherUser ID="assignAnotherUser" runat="server" ShowActivitySelector="true" />
				<br />
			</td>
		</tr>
	</table>
	<uc2:TaskTracking ID="taskTracking" runat="server" />
	<br />
</asp:Content>
