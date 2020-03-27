<%@ Page Language="C#" CodeFile="GridViewPagingSorting.aspx.cs" Inherits="GridViewPagingSorting_aspx" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.1//EN" "http://www.w3.org/TR/xhtml11/DTD/xhtml11.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Paging and Sorting with the GridView Control</title>
    <LINK rel="stylesheet" type="text/css" href="styles.css">
    <style>TH A {color: white}</style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
    <h1>
        Paging and Sorting with the GridView Control</h1>
        <p>
            <a href="start.aspx">Return to Start Page</a></p>
        <p>
            This example binds the <strong>GridView </strong>control to a <strong>SqlDataSource 
            </strong>control, which will retrieve all
    employees from the AdventureWorks database, and allows you to specify the number of employees to display
    per page.</p>
    
    <p>It also allows you to enable/disable sorting of the <strong>GridView</strong>. If sorting is turned on, each column in
    the <strong>GridView </strong>can be sorted by clicking the column name. The first click of a column sorts the column in
    ascending order; the second click of a column sorts the column in descending order.</p>
    
    <p>
        Number of employees per page: <asp:textbox id="NumPerPageTextBox" runat="Server" columns="5">10</asp:textbox>
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        Enable sorting <asp:checkbox id="EnableSortCheckbox" runat="Server" AutoPostBack="true" />
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:button id="EmployeesButton" runat="Server" text="Get Employees" />
    </p>
    
    <asp:gridview id="EmployeesGridView" runat="server" borderwidth="1px" backcolor="White" gridlines="Horizontal" cellpadding="3" borderstyle="None" bordercolor="#E7E7FF" datasourceid="EmployeesSqlDataSource" visible="False" allowpaging="True">
        <footerstyle forecolor="#4A3C8C" backcolor="#B5C7DE"></footerstyle>
        <pagerstyle forecolor="#4A3C8C" horizontalalign="Right" backcolor="#E7E7FF"></pagerstyle>
        <headerstyle forecolor="#F7F7F7" font-bold="True" backcolor="#4A3C8C"></headerstyle>
        <pagersettings position="TopAndBottom"></pagersettings>
        <alternatingrowstyle backcolor="#F7F7F7"></alternatingrowstyle>
        <selectedrowstyle forecolor="#F7F7F7" font-bold="True" backcolor="#738A9C"></selectedrowstyle>
        <rowstyle forecolor="#4A3C8C" backcolor="#E7E7FF"></rowstyle>
    </asp:gridview>
    
    <asp:SqlDataSource 
        ID="EmployeesSqlDataSource" runat="server" 
        ConnectionString="<%$ ConnectionStrings:AppConnectionString1 %>" 
        SelectCommand="SELECT HumanResources.Employee.Title, HumanResources.Employee.EmployeeID, HumanResources.Department.DepartmentID, 
                      HumanResources.EmployeeAddress.AddressID, HumanResources.Employee.ManagerID, HumanResources.Employee.BirthDate, 
                      HumanResources.Employee.MaritalStatus, HumanResources.Employee.Gender, HumanResources.Employee.HireDate, 
                      HumanResources.Employee.SalariedFlag, HumanResources.Employee.VacationHours
                      FROM HumanResources.Employee 
                      INNER JOIN
                      HumanResources.EmployeeAddress ON HumanResources.Employee.EmployeeID = HumanResources.EmployeeAddress.EmployeeID 
                      CROSS JOIN
                      HumanResources.Department" 
        ProviderName="<%$ ConnectionStrings:AppConnectionString1.ProviderName %>">
    </asp:SqlDataSource>
    
    </div>
    </form>
</body>
</html>
