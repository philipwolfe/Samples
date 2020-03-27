<%@ Page Language="C#" AutoEventWireup="true" CodeFile="CacheOnControl.aspx.cs" Inherits="CacheOnControl_aspx" %>
 
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.1//EN" "http://www.w3.org/TR/xhtml11/DTD/xhtml11.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Caching on the SqlDataSource Control</title>
    <LINK rel="stylesheet" type="text/css" href="styles.css">
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <h1>
            Caching on the SqlDataSource Control</h1>
        <p>
            <a href="start.aspx">Return to Start Page</a></p>
        <p>
            This page displays department data from the AdventureWorks database and caches it
        for 10 seconds. The caching properties are set directly on the <strong>SqlDataSource
            </strong>control.</p>
            
        <p>Continually press <b>F5</b> to refresh the browser and notice the last data retrieval time.</p>    
        
        <p>
            <b>Current Time:</b> <asp:Literal ID="CurrentTimeLiteral" runat="server"></asp:Literal><br />
            <b>Last Data Retrieval:</b> <asp:Literal ID="RetrievalTimeLiteral" runat="server"></asp:Literal>
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
        
        <asp:SqlDataSource
            ConnectionString="<%$ ConnectionStrings:AppConnectionString1 %>"
            ID="DepartmentSqlDataSource"
            ProviderName="<%$ ConnectionStrings:AppConnectionString1.ProviderName %>"
            runat="server"
            SelectCommand="SELECT [DepartmentID], [Name], [GroupName], [ModifiedDate] FROM [DepartmentSample]"
            CacheDuration="10"
            EnableCaching="True"
            OnSelected="DepartmentSqlDataSource_Selected">
        </asp:SqlDataSource>
    
    </div>
    </form>
</body>
</html>
