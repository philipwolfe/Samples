<%@ Page Theme="theme1" Language="C#" ValidateRequest="false" AutoEventWireup="true" CodeFile="Workflows.aspx.cs" Inherits="Workflows" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Untitled Page</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" DataObjectTypeName="Workflow.workflowRow"
            DeleteMethod="Delete" InsertMethod="Insert" OldValuesParameterFormatString="original_{0}"
            SelectMethod="GetData" TypeName="WorkflowTableAdapters.workflowTableAdapter"
            UpdateMethod="Update">
            <UpdateParameters>
                <asp:Parameter Name="workflow_id" Type="Object" />
                <asp:Parameter Name="workflow_name" Type="String" />
                <asp:Parameter Name="workflow_description" Type="String" />
                <asp:Parameter Name="workflow_version" Type="String" />
                <asp:Parameter Name="workflow_xaml" Type="String" />
                <asp:Parameter Name="workflow_rules" Type="String" />
                <asp:Parameter Name="workflow_modified_by" Type="String" />
                <asp:Parameter Name="workflow_modified_datetime" Type="DateTime" />
                <asp:Parameter Name="Original_workflow_id" Type="Object" />
            </UpdateParameters>
            <InsertParameters>
                <asp:Parameter Name="workflow_id" Type="Object" />
                <asp:Parameter Name="workflow_name" Type="String" />
                <asp:Parameter Name="workflow_description" Type="String" />
                <asp:Parameter Name="workflow_version" Type="String" />
                <asp:Parameter Name="workflow_xaml" Type="String" />
                <asp:Parameter Name="workflow_rules" Type="String" />
                <asp:Parameter Name="workflow_modified_by" Type="String" />
                <asp:Parameter Name="workflow_modified_datetime" Type="DateTime" />
            </InsertParameters>
        </asp:ObjectDataSource>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:WorkflowPersistenceConnectionString %>"
            DeleteCommand="DELETE FROM [workflow] WHERE [workflow_id] = @workflow_id" InsertCommand="INSERT INTO [workflow] ([workflow_id], [workflow_name], [workflow_description], [workflow_version], [workflow_xaml], [workflow_rules], [workflow_modified_by], [workflow_modified_datetime]) VALUES (@workflow_id, @workflow_name, @workflow_description, @workflow_version, @workflow_xaml, @workflow_rules, @workflow_modified_by, @workflow_modified_datetime)"
            SelectCommand="SELECT * FROM [workflow]" UpdateCommand="UPDATE [workflow] SET [workflow_name] = @workflow_name, [workflow_description] = @workflow_description, [workflow_version] = @workflow_version, [workflow_xaml] = @workflow_xaml, [workflow_rules] = @workflow_rules, [workflow_modified_by] = @workflow_modified_by, [workflow_modified_datetime] = @workflow_modified_datetime WHERE [workflow_id] = @workflow_id">
            <DeleteParameters>
                <asp:Parameter Name="workflow_id" Type="Object" />
            </DeleteParameters>
            <UpdateParameters>
                <asp:Parameter Name="workflow_name" Type="String" />
                <asp:Parameter Name="workflow_description" Type="String" />
                <asp:Parameter Name="workflow_version" Type="String" />
                <asp:Parameter Name="workflow_xaml" Type="String" />
                <asp:Parameter Name="workflow_rules" Type="String" />
                <asp:Parameter Name="workflow_modified_by" Type="String" />
                <asp:Parameter Name="workflow_modified_datetime" Type="DateTime" />
                <asp:Parameter Name="workflow_id" Type="Object" />
            </UpdateParameters>
            <InsertParameters>
                <asp:Parameter Name="workflow_id" Type="Object" />
                <asp:Parameter Name="workflow_name" Type="String" />
                <asp:Parameter Name="workflow_description" Type="String" />
                <asp:Parameter Name="workflow_version" Type="String" />
                <asp:Parameter Name="workflow_xaml" Type="String" />
                <asp:Parameter Name="workflow_rules" Type="String" />
                <asp:Parameter Name="workflow_modified_by" Type="String" />
                <asp:Parameter Name="workflow_modified_datetime" Type="DateTime" />
            </InsertParameters>
        </asp:SqlDataSource>
    
    </div>
        <asp:GridView ID="GridView1" runat="server" AllowPaging="True" AllowSorting="True"
            AutoGenerateColumns="False" DataKeyNames="workflow_id" DataSourceID="SqlDataSource1">
            <Columns>
                <asp:CommandField ShowDeleteButton="True" ShowEditButton="True" />
                <asp:BoundField DataField="workflow_id" HeaderText="workflow_id" ReadOnly="True"
                    SortExpression="workflow_id" />
                <asp:BoundField DataField="workflow_name" HeaderText="workflow_name" SortExpression="workflow_name" />
                <asp:BoundField DataField="workflow_description" HeaderText="workflow_description"
                    SortExpression="workflow_description" />
                <asp:BoundField DataField="workflow_version" HeaderText="workflow_version" SortExpression="workflow_version" />
                <asp:BoundField DataField="workflow_xaml" HeaderText="workflow_xaml" SortExpression="workflow_xaml" />
                <asp:BoundField DataField="workflow_rules" HeaderText="workflow_rules" SortExpression="workflow_rules" />
                <asp:BoundField DataField="workflow_modified_by" HeaderText="workflow_modified_by"
                    SortExpression="workflow_modified_by" />
                <asp:BoundField DataField="workflow_modified_datetime" HeaderText="workflow_modified_datetime"
                    SortExpression="workflow_modified_datetime" />
            </Columns>
        </asp:GridView>
    </form>
</body>
</html>
