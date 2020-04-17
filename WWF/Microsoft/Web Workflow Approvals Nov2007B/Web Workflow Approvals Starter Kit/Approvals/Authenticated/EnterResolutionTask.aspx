<%@ Page Language="C#" MasterPageFile="~/MasterPages/WorkflowTask.master" AutoEventWireup="true"
	CodeFile="EnterResolutionTask.aspx.cs" Inherits="Authenticated_EnterResolutionTask"
	Title="City Power &amp; Light" %>

<%@ Register Assembly="Controls" Namespace="Samples.Controls" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="taskFieldsContentPlaceHolder" runat="Server">
	<table width="100%" cellpadding="5" cellspacing="5" border="0">
		<tr>
			<td>
				<cc1:FieldControl ID="nameFieldControl" Caption="Name" runat="server" DataTextField="WorkItemName"
					CaptionAlignment="Top" DataControlWidth="100%" Width="100%" IsRequired="true" ValidationDisplay="None"
					ValidationGroup="TaskFields" Enabled="false" />
				<br />
				<cc1:FieldControl ID="descriptionFieldControl" Caption="Description" runat="server"
					DataTextField="Description" CaptionAlignment="Top" DataControlWidth="100%" Width="100%"
					IsRequired="true" ValidationDisplay="None" ValidationGroup="TaskFields" Enabled="false" />
				<br />
				<asp:ValidationSummary ID="validationSummary" runat="server" ValidationGroup="TaskFields"
					HeaderText="Whoops! unable to save..." />
			</td>
			<td style="width: 359px">
				<cc1:FieldControl ID="typeOfWorkFieldControl" Caption="Type of work" runat="server"
					DataTextField="WorkItemType" CaptionAlignment="Top" DataControlWidth="100%" Width="300px"
					OptionTextField="WorkTypeName" OptionValueField="WorkTypeName" IsLookup="true"
					Enabled="false" />
				<br />
				<cc1:FieldControl ID="reasonFieldControl" Caption="Reason" runat="server" DataTextField="Reason"
					CaptionAlignment="Top" DataControlWidth="100%" Width="100%" IsRequired="true" ValidationDisplay="None"
					ValidationGroup="TaskFields" Enabled="false" />
				<br />
				<cc1:FieldControl ID="dateRequestedFieldControl" Caption="Date requested" runat="server"
					DataTextField="DateRequested" CaptionAlignment="Top" DataControlWidth="100%" Width="100%"
					Enabled="false" />
				<br />
				<cc1:FieldControl ID="fundingFieldControl" Caption="Funding cost center" runat="server"
					DataTextField="FundingCostCenter" CaptionAlignment="Top" DataControlWidth="100%"
					Width="100%" IsRequired="true" ValidationDisplay="None" ValidationGroup="TaskFields"
					Enabled="false" />
				<br />
				<cc1:FieldControl ID="areaFieldControl" Caption="Area Affected" runat="server" DataTextField="AreaAffected"
					CaptionAlignment="Top" DataControlWidth="100%" Width="100%" IsRequired="true" ValidationDisplay="None"
					ValidationGroup="TaskFields" Enabled="false" />
				<cc1:FieldControl ID="approvedFieldControl" Caption="Approved" runat="server" DataTextField="Approved"
					CaptionAlignment="Top" Width="100%" Enabled="false" />
				<cc1:FieldControl ID="resultFieldControl" Caption="Result" runat="server" DataTextField="Result"
					CaptionAlignment="Top" DataControlWidth="100%" Width="100%" IsRequired="true" ValidationDisplay="None"
					ValidationGroup="TaskFields" />
			</td>
		</tr>
	</table>
</asp:Content>
