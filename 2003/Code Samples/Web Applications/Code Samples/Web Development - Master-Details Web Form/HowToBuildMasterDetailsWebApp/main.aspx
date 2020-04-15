<%@ Page Language="c#" AutoEventWireup="false" Codebehind="main.aspx.cs" Inherits="Main"%>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>Visual Basic .NET How-to: Build a Master-Details Web Application</title>
		<meta content="Microsoft Visual Studio.NET 7.0" name="GENERATOR">
		<meta content="Visual Basic 7.0" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="styles.css" rel="stylesheet">
	</HEAD>
	<body>
		<form id="frmMain" method="post" runat="server">
			<table id="tblTitle" width="100%" border="0">
				<tr>
					<td align="left" width="85%">
						<h1><asp:label id="lblTitle" runat="server"> Text read from Page_Load</asp:label></h1>
					</td>
					<td width="*"><asp:button id="btnAbout" runat="server" Text="About . . ."></asp:button></td>
				</tr>
			</table>
			<hr>
			<TABLE id="Table1" width="100%" border="0">
				<TR>
					<TD valign="top"><asp:datagrid id="grdCustomers" runat="server" AllowSorting="True" AutoGenerateColumns="False"
							AllowPaging="True">
							<SelectedItemStyle CssClass="DataGrid_SelectedItemStyle" />
							<ItemStyle CssClass="DataGrid_ItemStyle" />
							<HeaderStyle CssClass="DataGrid_HeaderStyle" />
							<FooterStyle CssClass="DataGrid_FooterStyle" />
							<Columns>
								<asp:BoundColumn DataField="CustomerID" SortExpression="CustomerID" HeaderText="Customer ID" />
								<asp:BoundColumn DataField="CompanyName" HeaderText="Company" />
								<asp:BoundColumn DataField="City" HeaderText="City" />
								<asp:ButtonColumn Text="Orders" ButtonType="PushButton" CommandName="Select" />
							</Columns>
							<PagerStyle CssClass="DataGrid_PagerStyle" Mode="NumericPages" />
						</asp:datagrid>
					</TD>
					<TD valign="top">
						<asp:datagrid id="grdOrders" runat="server" AllowPaging="True" AutoGenerateColumns="False" Visible="False">
							<SelectedItemStyle CssClass="DataGrid_SelectedItemStyle" />
							<ItemStyle CssClass="DataGrid_ItemStyle" />
							<HeaderStyle CssClass="DataGrid_HeaderStyle" />
							<FooterStyle CssClass="DataGrid_FooterStyle" />
							<Columns>
								<asp:BoundColumn DataField="OrderID" HeaderText="Order ID" />
								<asp:BoundColumn DataField="OrderDate" HeaderText="Ordered" DataFormatString="{0:d}" />
								<asp:BoundColumn DataField="ShippedDate" HeaderText="Shipped" DataFormatString="{0:d}" />
								<asp:BoundColumn DataField="Freight" HeaderText="Freight" DataFormatString="{0:c}" />
								<asp:BoundColumn DataField="ShippedVia" HeaderText="Shipped Via" />
								<asp:ButtonColumn Text="Details" ButtonType="PushButton" CommandName="Select" />
							</Columns>
							<PagerStyle CssClass="DataGrid_PagerStyle" Mode="NumericPages" />
						</asp:datagrid>
					</TD>
				</TR>
				<TR>
					<TD class="details" valign="top" colSpan="2"><asp:datagrid id="grdOrderDetails" runat="server" AutoGenerateColumns="False" AllowPaging="False"
							Visible="False">
							<SelectedItemStyle CssClass="DataGrid_SelectedItemStyle" />
							<ItemStyle CssClass="DataGrid_ItemStyle" />
							<HeaderStyle CssClass="DataGrid_HeaderStyle" />
							<FooterStyle CssClass="DataGrid_FooterStyle" />
							<Columns>
								<asp:BoundColumn DataField="ProductName" HeaderText="Product" />
								<asp:BoundColumn DataField="UnitPrice" HeaderText="Price" DataFormatString="{0:c}" />
								<asp:BoundColumn DataField="Quantity" HeaderText="Quantity" />
								<asp:BoundColumn DataField="Discount" HeaderText="Discount" DataFormatString="{0:p2}" />
								<asp:BoundColumn DataField="CategoryName" HeaderText="Category" />
							</Columns>
						</asp:datagrid>
					</TD>
				</TR>
			</TABLE>
		</form>
	</body>
</HTML>
