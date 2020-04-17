<%@ Control Language="C#" AutoEventWireup="true" CodeFile="TaskTracking.ascx.cs"
	Inherits="Controls_TaskTracking" %>
<%@ Register Src="FilterControl.ascx" TagName="FilterControl" TagPrefix="uc1" %>
<div class="greenBorderBox clearfix" style="width: 960px; padding:0px;overflow-x:auto;padding-bottom:10px;">
<h4>Tracking Information</h4>

<div style="clear:both;">
    <uc1:FilterControl ID="filterControl" runat="server" OnFilterChanged="filterControl_FilterChanged" />
</div>		
	
		        
		
		        <asp:GridView ID="trackingGridView" Width="100%" runat="server"
		AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False" DataSourceID="trackingObjectDataSource"
		PageSize="100">
		<Columns>
			<asp:BoundField DataField="TrackedAt" HeaderText="Event Date Time" SortExpression="TrackedAt" />
			<asp:BoundField DataField="ActivityDescription" HeaderText="Activity Description" SortExpression="ActivityDescription" />
			<asp:BoundField DataField="Status" HeaderText="Execution Status" SortExpression="Status" />
			<asp:BoundField DataField="WorkItemName" HeaderText="Work Item Name" SortExpression="WorkItemName" />
			<asp:BoundField DataField="WorkItemType" HeaderText="Work Item Type" SortExpression="WorkItemType" />
			<asp:BoundField DataField="Description" HeaderText="Description" SortExpression="Description" />
			<asp:BoundField DataField="Reason" HeaderText="Reason" SortExpression="Reason" />
			<asp:BoundField DataField="DateRequested" HeaderText="Date Requested" SortExpression="DateRequested" />
			<asp:BoundField DataField="FundingCostCenter" HeaderText="Funding Cost Center" SortExpression="FundingCostCenter" />
			<asp:BoundField DataField="AreaAffected" HeaderText="Area Affected" SortExpression="AreaAffected" />
			<asp:CheckBoxField DataField="Approved" HeaderText="Approved" SortExpression="Approved" />
			<asp:BoundField DataField="Result" HeaderText="Result" SortExpression="Result" />
			<asp:BoundField DataField="ActivityTypeName" HeaderText="Activity Type" SortExpression="ActivityTypeName" />
			<asp:BoundField DataField="ActivityName" HeaderText="Qualified Name" SortExpression="ActivityName" />
		</Columns>
                    <RowStyle CssClass="gridRow" />
                    <HeaderStyle CssClass="gridHeader" />
                    <AlternatingRowStyle CssClass="gridAltRow" />
	</asp:GridView>
	<asp:ObjectDataSource ID="trackingObjectDataSource" runat="server" SelectMethod="GetCurrentWorkflowTrackingDetail"
		SortParameterName="sort" TypeName="TrackingHelper" OldValuesParameterFormatString="original_{0}">
		<SelectParameters>
			<asp:QueryStringParameter Name="workflowGuid" QueryStringField="Workflowid" Type="Object" />
			<asp:Parameter Name="sort" Type="String" />
			<asp:ControlParameter ControlID="filterControl" Name="filter" PropertyName="FilterExpression"
				Type="String" />
		</SelectParameters>
	</asp:ObjectDataSource>
	
		
			
		
	    </div>

<asp:ImageButton ID="exportImageButton" runat="server" ImageUrl="~/Images/btn-save.gif"
		OnClick="exportImageButton_Click" />
