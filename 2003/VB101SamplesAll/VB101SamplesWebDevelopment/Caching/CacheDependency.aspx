<%@ Page Language="VB" AutoEventWireup="true" CodeFile="CacheDependency.aspx.vb" Inherits="CacheDependency_aspx" %>
<%@ OutputCache Duration="10" SqlDependency="AdventureWorks:DepartmentSample" VaryByParam="None" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.1//EN" "http://www.w3.org/TR/xhtml11/DTD/xhtml11.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Using SqlCacheDependency</title>
    <LINK rel="stylesheet" type="text/css" href="styles.css">
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <h1>
            Using SqlCacheDependency</h1>
        <p>
            <a href="start.aspx">Return to Start Page</a></p>
        <p>
            This sample displays department data from the AdventureWorks database and will
        cache the data for 10 seconds. Once the 10 seconds expires, the data will be removed from 
        the cache and shown fresh on the next request. It also has a dependency on the table in the
        database, so if the data in that table changes, the cache will be flushed and the page will
        display fresh data on the next request.</p>
        
        <p>The caching settings for this page are in the web.config file (look in the <strong>&lt;caching&gt;</strong>
        section) and in the <strong>OutputCache</strong> page directive. Also, to make the 
            <strong>SqlCacheDependency</strong> control work
        properly, the database and table must be enabled for cache notifications. To enable cache
        notification programmatically, you use the <strong>SqlCacheDependencyAdmin</strong> class, which for this
        sample is used in the <strong>Application_Start </strong>method in the global.asax file.</p>
        
        <p>Continually press <b>F5</b> to refresh the browser and notice the last data retrieval time. Unlike the other 
        example, these times stay the same because the entire page output is cached.</p>    
        
        <p>
            <b>Current Time:</b> <asp:Literal ID="CurrentTimeLiteral" runat="server"></asp:Literal><br />
            <b>Last Data Retrieval:</b> <asp:Literal ID="RetrievalTimeLiteral" runat="server" EnableViewState="true"></asp:Literal>
        </p>
        
        <asp:GridView AutoGenerateColumns="False" CellPadding="4" DataSourceID="DepartmentSqlDataSource"
            EmptyDataText="There are no data records to display." ForeColor="#333333" GridLines="None"
            ID="DepartmentGridView" runat="server">
            <FooterStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
            <Columns>
                <asp:BoundField DataField="DepartmentID" HeaderText="DepartmentID" ReadOnly="True"
                    SortExpression="DepartmentID"></asp:BoundField>
                <asp:BoundField DataField="Name" HeaderText="Name" SortExpression="Name"></asp:BoundField>
                <asp:BoundField DataField="GroupName" HeaderText="GroupName" SortExpression="GroupName">
                </asp:BoundField>
                <asp:BoundField DataField="ModifiedDate" HeaderText="ModifiedDate" SortExpression="ModifiedDate">
                </asp:BoundField>
            </Columns>
            <RowStyle BackColor="#FFFBD6" ForeColor="#333333" />
            <PagerStyle BackColor="#FFCC66" ForeColor="#333333" HorizontalAlign="Center" />
            <SelectedRowStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="Navy" />
            <HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
            <EditRowStyle Font-Bold="False" Font-Italic="False" />
            <AlternatingRowStyle BackColor="White" />
        </asp:GridView>
        <asp:SqlDataSource ConnectionString="<%$ ConnectionStrings:AppConnectionString1 %>"
            ID="DepartmentSqlDataSource" ProviderName="<%$ ConnectionStrings:AppConnectionString1.ProviderName %>"
            runat="server" SelectCommand="SELECT [DepartmentID], [Name], [GroupName], [ModifiedDate] FROM [DepartmentSample]" OnSelected="DepartmentSqlDataSource_Selected">
        </asp:SqlDataSource>
    
    </div>
    </form>
</body>
</html>
