<%@ Control Language="C#" AutoEventWireup="true" CodeFile="TaskTracking.ascx.cs"
	Inherits="Controls_TaskTracking" %>
<%@ Register Src="FilterControl.ascx" TagName="FilterControl" TagPrefix="uc1" %>
<div class="tabPage">
	<table style="width: 100%" cellspacing="0" cellpadding="0">
		<tr>
			<td style="white-space: nowrap">
				&nbsp;&nbsp;&nbsp;<div class="greenBoxTitle">
					Tracking Information</div>
			</td>
			<td style="text-align: right; white-space: nowrap">
				<uc1:FilterControl ID="filterControl" runat="server" OnFilterChanged="filterControl_FilterChanged" />
			</td>
		</tr>
	</table>
	<asp:GridView ID="trackingGridView" Width="100%" runat="server" CssClass="greenBox"
		AlternatingRowStyle-CssClass="gridRowAlternate" HeaderStyle-CssClass="greenHeader"
		AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False" DataSourceID="trackingObjectDataSource"
		PageSize="100">
		<Columns>
			<asp:BoundField DataField="WorkItemName" HeaderText="Work Item Name" SortExpression="WorkItemName" />
			<asp:BoundField DataField="WorkItemType" HeaderText="Work Item Type" SortExpression="WorkItemType" />
			<asp:BoundField DataField="Description" HeaderText="Description" SortExpression="Description" />
			<asp:BoundField DataField="Reason" HeaderText="Reason" SortExpression="Reason" />
			<asp:BoundField DataField="DateRequested" HeaderText="Date Requested" SortExpression="DateRequested" />
			<asp:BoundField DataField="FundingCostCenter" HeaderText="Funding Cost Center" SortExpression="FundingCostCenter" />
			<asp:BoundField DataField="AreaAffected" HeaderText="Area Affected" SortExpression="AreaAffected" />
			<asp:CheckBoxField DataField="Approved" HeaderText="Approved" SortExpression="Approved" />
			<asp:BoundField DataField="Result" HeaderText="Result" SortExpression="Result" />
			<asp:BoundField DataField="ExecutionStatus" HeaderText="Execution Status" SortExpression="ExecutionStatus" />
			<asp:BoundField DataField="QualifiedName" HeaderText="Qualified Name" SortExpression="QualifiedName" />
			<asp:BoundField DataField="ActivityType" HeaderText="Activity Type" SortExpression="ActivityType" />
			<asp:BoundField DataField="EventDateTime" HeaderText="Event Date Time" SortExpression="EventDateTime" />
		</Columns>
		<HeaderStyle CssClass="greenHeader" />
		<AlternatingRowStyle CssClass="gridRowAlternate" />
	</asp:GridView>
	<asp:ObjectDataSource ID="trackingObjectDataSource" runat="server" SelectMethod="GetCurrentWorkflowTrackingDetail"
		SortParameterName="sort" TypeName="DatabaseTrackingHelper" OldValuesParameterFormatString="original_{0}">
		<SelectParameters>
			<asp:QueryStringParameter Name="workflowGuid" QueryStringField="Workflowid" Type="Object" />
			<asp:Parameter Name="sort" Type="String" />
			<asp:ControlParameter ControlID="filterControl" Name="filter" PropertyName="FilterExpression"
				Type="String" />
		</SelectParameters>
	</asp:ObjectDataSource>
	<br />
	&nbsp;<asp:ImageButton ID="exportImageButton" runat="server" ImageUrl="~/Images/export1.gif"
		OnClick="exportImageButton_Click" /></div>
