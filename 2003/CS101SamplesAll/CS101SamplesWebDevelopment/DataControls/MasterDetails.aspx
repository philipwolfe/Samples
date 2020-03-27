<%@ Page Language="C#" CodeFile="MasterDetails.aspx.cs" Inherits="MasterDetails_aspx" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.1//EN" "http://www.w3.org/TR/xhtml11/DTD/xhtml11.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Creating a Master/Details Page</title>
    <LINK rel="stylesheet" type="text/css" href="styles.css">
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <h1>
            Creating a Master/Details Page</h1>
        <p>
            <a href="start.aspx">Return to Start Page</a></p>
        <p>
            This page retrieves the top 10 employees from the AdventureWorks database and displays them in a
        GridView control. Each employee record has a "Details" link that when clicked will display other
        details for the selected employee, thus creating a master/details relationship. The details for an
        employee are shown in a DetailsView control.</p>
        
        <p><asp:button id="GetEmployeesButton" runat="Server" text="Get Employees" /></p>
        

        <asp:detailsview id="AddressDetailsView" runat="server" datasourceid="AddressSqlDataSource" borderwidth="1px" backcolor="White" gridlines="Horizontal" cellpadding="3" bordercolor="#E7E7FF" borderstyle="None" visible="False" EnableViewState="False">
            <footerstyle forecolor="#4A3C8C" backcolor="#B5C7DE"></footerstyle>
            <rowstyle forecolor="#4A3C8C" backcolor="#E7E7FF"></rowstyle>
            <pagerstyle forecolor="#4A3C8C" horizontalalign="Right" backcolor="#E7E7FF"></pagerstyle>
            <headerstyle forecolor="#F7F7F7" font-bold="True" backcolor="#4A3C8C"></headerstyle>
            <editrowstyle forecolor="#F7F7F7" font-bold="True" backcolor="#738A9C"></editrowstyle>
            <AlternatingRowStyle BackColor="#F7F7F7" />
        </asp:detailsview>

        <br />

    <asp:gridview id="EmployeesGridView" runat="server" datasourceid="EmployeesSqlDataSource" borderwidth="1px" 
                    backcolor="White" gridlines="Horizontal" cellpadding="3" bordercolor="#E7E7FF" datakeynames="EmployeeID" visible="False" EnableViewState="False" BorderStyle="None">
        <footerstyle backcolor="#B5C7DE" ForeColor="#4A3C8C"></footerstyle>
        <pagerstyle forecolor="#4A3C8C" horizontalalign="Right" backcolor="#E7E7FF"></pagerstyle>
        <headerstyle font-bold="True" backcolor="#4A3C8C" ForeColor="#F7F7F7"></headerstyle>
        <RowStyle  HorizontalAlign="Center" BackColor="#E7E7FF" ForeColor="#4A3C8C"></RowStyle>
        <alternatingrowstyle backcolor="#F7F7F7" HorizontalAlign="Center"></alternatingrowstyle>
        <columns>
            <asp:commandfield showselectbutton="True" selecttext="Details"></asp:commandfield>
        </columns>
        <selectedrowstyle forecolor="#F7F7F7"  HorizontalAlign="Center" backcolor="#738A9C" Font-Bold="True"></selectedrowstyle>
    </asp:gridview>
    
    <asp:SqlDataSource 
        ID="EmployeesSqlDataSource" runat="server" 
        ConnectionString="<%$ ConnectionStrings:AppConnectionString1 %>" 
        SelectCommand="SELECT HumanResources.EmployeeAddress.AddressID, HumanResources.Employee.EmployeeID AS EXPR1, HumanResources.Employee.Title, 
                      HumanResources.Employee.BirthDate, HumanResources.Employee.MaritalStatus, HumanResources.Employee.Gender, 
                      HumanResources.Employee.HireDate, HumanResources.Employee.SalariedFlag, HumanResources.Employee.VacationHours, 
                      HumanResources.EmployeeAddress.EmployeeID
                      FROM HumanResources.Employee INNER JOIN
                      HumanResources.EmployeeAddress ON HumanResources.Employee.EmployeeID = HumanResources.EmployeeAddress.EmployeeID"
        ProviderName="<%$ ConnectionStrings:AppConnectionString1.ProviderName %>">
    </asp:SqlDataSource>
    
        <asp:sqldatasource id="AddressSqlDataSource" runat="server" EnableViewState="False" ConnectionString="<%$ ConnectionStrings:AppConnectionString1 %>" SelectCommand="SELECT [AddressLine1], [City], [StateProvinceID], [PostalCode] FROM [Person].[Address] WHERE ([AddressID] = @AddressID)" >
            <SelectParameters>
                <asp:ControlParameter ControlID="EmployeesGridView" Name="AddressID" PropertyName="SelectedValue"
                    Type="Int32" />
            </SelectParameters>
        </asp:sqldatasource>
    </div>
    </form>
</body>
</html>
