<%@ Page Language="C#" MasterPageFile="~/MasterPages/MasterPage.master" AutoEventWireup="true"
	CodeFile="Default.aspx.cs" Inherits="_Default" Title="City Power &amp; Light" %>

<%@ Register Src="Controls/TaskList.ascx" TagName="TaskList" TagPrefix="uc1" %>
<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="bodyContentPlaceHolder">
	<table width="100%" cellpadding="5" cellspacing="5" border="0">
		<tr>
			<td style="width: 250px;">
				<div class="blueBox">
					<div class="blueBoxTitle">
						Workflows
						<br />
						<asp:LinkButton ID="approvalRequestLinkButton" runat="server" OnClick="approvalRequestLinkButton_Click">Start Approval Request</asp:LinkButton>
					</div>
				</div>
			</td>
			<td>
				<asp:LoginView ID="loginView" runat="server">
					<LoggedInTemplate>
						<div class="blueBox">
							<div class="blueBoxTitle">
								<asp:Image ID="refreshImage" runat="server" ImageAlign="AbsMiddle" ImageUrl="~/Images/refresh.gif" />
								<asp:LinkButton ID="refreshTaskListsLinkButton" runat="server" OnClick="refreshTaskListsLinkButton_Click">Refresh Task Lists</asp:LinkButton>
							</div>
						</div>
						<br />
						<uc1:TaskList ID="usersTaskList" runat="server" BodyCssClass="orangeBox" TitleCssClass="orangeBoxTitle"
							ListType="UsersTasks" Title="Tasks assigned to me" RefreshButtonVisible="false" />
						<br />
						<uc1:TaskList ID="rolesTaskList" runat="server" ListType="RolesTasks" Title="Tasks for anyone in role"
							BodyCssClass="greenBox" TitleCssClass="greenBoxTitle" RefreshButtonVisible="false" />
					</LoggedInTemplate>
					<AnonymousTemplate>
						<div class="orangeBox">
							<div class="orangeBoxTitle">
								Click one of the workflow models in the list on the left to start a new workflow
								instance.<br />
								<br />
								Login or register to see more options.<br />
								<br />
								For this starterkit you can login as Charles, Jane or Rachel. The password is password
								for all users. Charles is the administrator, Jane is a manager and Rachel is data
								entry.
							</div>
						</div>
					</AnonymousTemplate>
				</asp:LoginView>
			</td>
		</tr>
	</table>
</asp:Content>
