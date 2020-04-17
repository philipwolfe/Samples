<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Workflows.ascx.cs" Inherits="Controls_Workflows" %>
<%@ Register Src="FilterControl.ascx" TagName="FilterControl" TagPrefix="uc1" %>
<div>
    <asp:MultiView ActiveViewIndex="0" runat="server" ID="multiView">
        <asp:View runat="server" ID="currentView">
            <table cellspacing="0" cellpadding="0">
                <tr>
                    <td style="white-space: nowrap">
                        &nbsp;&nbsp;&nbsp;<asp:Button runat="server" ID="btnCurrentActive" CssClass="tabOn"
                            Text="Current" />
                        &nbsp;<asp:Button runat="server" ID="btnCompletedInactive" Enabled="true" CssClass="tabOff"
                            Text="Completed" OnClick="btnCompletedInactive_Click" />
                    </td>
                    <td style="text-align: right; white-space: nowrap">
                        <uc1:FilterControl ID="currentFilterControl" runat="server" OnFilterChanged="currentFilter_FilterChanged" />
                    </td>
                </tr>
            </table>
            <div class="greenBorderBox clearfix" style="padding: 0px">
                <asp:GridView Width="100%" ID="currentGridView" runat="server" DataSourceID="currentWorkflowsObjectDataSource"
                    AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False" OnRowCommand="gridView_RowCommand"
                    PageSize="100">
                    <RowStyle CssClass="gridRow" />
                    <HeaderStyle CssClass="gridHeader" />
                    <AlternatingRowStyle CssClass="gridAltRow" />
                    <Columns>
                        <asp:TemplateField HeaderText="Name" SortExpression="Name">
                            <ItemTemplate>
                                <asp:LinkButton ID="ViewDetailsLinkButton" runat="server" Text='<%# Bind("Name") %>'
                                    CommandName="ViewDetails" CommandArgument='<%# Eval("WorkflowGuid") %>' />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="Started" HeaderText="Started On" SortExpression="Started" />
                        <asp:BoundField DataField="WaitingOn" HeaderText="Waiting On" SortExpression="WaitingOn" />
                    </Columns>
                </asp:GridView>
            </div>
            <asp:ObjectDataSource ID="currentWorkflowsObjectDataSource" runat="server" SelectMethod="GetCurrentWorkflows"
                TypeName="TrackingHelper" SortParameterName="sort" OldValuesParameterFormatString="original_{0}">
                <SelectParameters>
                    <asp:Parameter Name="sort" Type="String" />
                    <asp:ControlParameter ControlID="currentFilterControl" Name="filter" PropertyName="FilterExpression"
                        Type="String" />
                </SelectParameters>
            </asp:ObjectDataSource>
            <br />
            <asp:ImageButton ID="exportCurrentImageButton" runat="server" ImageUrl="~/Images/btn-save.gif"
                OnClick="exportCurrentImageButton_Click" /></asp:View>
        <asp:View runat="server" ID="completedView">
            <table style="width: 100%" cellspacing="0" cellpadding="0">
                <tr>
                    <td style="white-space: nowrap">
                        &nbsp;&nbsp;&nbsp;<asp:Button runat="server" ID="btnCurrentInactive" CssClass="tabOff"
                            Enabled="true" Text="Current" OnClick="btnCurrentInactive_Click" />
                        &nbsp;<asp:Button runat="server" ID="btnCompletedActive" CssClass="tabOn" Text="Completed" />
                    </td>
                    <td style="text-align: right; white-space: nowrap">
                        <uc1:FilterControl ID="completedFilterControl" runat="server" OnFilterChanged="completedFilter_FilterChanged" />
                    </td>
                </tr>
            </table>
            <div class="greenBorderBox clearfix" style="padding: 0px">
                <asp:GridView ID="completedGridView" Width="100%" runat="server" AllowPaging="True"
                    AllowSorting="True" AutoGenerateColumns="False" DataSourceID="completedWorkflowsObjectDataSource"
                    OnRowCommand="gridView_RowCommand" PageSize="100">
                    <Columns>
                        <asp:TemplateField HeaderText="Name" SortExpression="Name">
                            <ItemTemplate>
                                <asp:LinkButton ID="ViewDetailsLinkButton" runat="server" Text='<%# Bind("Name") %>'
                                    CommandName="ViewDetails" CommandArgument='<%# Eval("WorkflowGuid") %>' />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="Started" HeaderText="Started On" SortExpression="Started" />
                        <asp:BoundField DataField="Finished" HeaderText="Completed On" SortExpression="Finished" />
                    </Columns>
                    <RowStyle CssClass="gridRow" />
                    <HeaderStyle CssClass="gridHeader" />
                    <AlternatingRowStyle CssClass="gridAltRow" />
                </asp:GridView>
            </div>
            <asp:ObjectDataSource ID="completedWorkflowsObjectDataSource" runat="server" SelectMethod="GetCompletedWorkflows"
                TypeName="TrackingHelper" SortParameterName="sort">
                <SelectParameters>
                    <asp:Parameter Name="sort" Type="String" />
                    <asp:ControlParameter ControlID="completedFilterControl" Name="filter" PropertyName="FilterExpression"
                        Type="String" />
                </SelectParameters>
            </asp:ObjectDataSource>
            <br />
            <asp:ImageButton ID="exportCompleteImageButton" runat="server" ImageUrl="~/Images/btn-save.gif"
                OnClick="exportCompleteImageButton_Click" /></asp:View>
    </asp:MultiView>
</div>
