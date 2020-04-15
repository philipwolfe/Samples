<%@ Page Language="c#" AutoEventWireup="false" Codebehind="main.aspx.cs" Inherits="HowToDoDataGridPaging.Main" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>Visual Basic .NET How-to: Do DataGrid Paging</title>
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
					<td align="right" width="*"><asp:button id="btnAbout" runat="server" Text="About . . ."></asp:button></td>
				</tr>
			</table>
			<hr>
			<table align="center">
				<tr>
					<td>
						<asp:checkbox id="chkUseCustomPaging" runat="server" Text="Use Custom Paging" AutoPostBack="True" />
					</td>
				</tr>
				<tr>
					<td>
						<asp:datagrid id="grdOrderDetails" runat="server" AllowSorting="True" AutoGenerateColumns="False"
							AllowPaging="True" PageSize="20">
							<SelectedItemStyle CssClass="DataGrid_SelectedItemStyle" />
							<ItemStyle CssClass="DataGrid_ItemStyle" />
							<HeaderStyle CssClass="DataGrid_HeaderStyle" />
							<FooterStyle CssClass="DataGrid_FooterStyle" />
							<Columns>
								<asp:BoundColumn DataField="OrderID" SortExpression="OrderID" HeaderText="Order ID" />
								<asp:BoundColumn DataField="ProductName" SortExpression="ProductName" HeaderText="Product" />
								<asp:BoundColumn DataField="UnitPrice" SortExpression="UnitPrice" HeaderText="Price" DataFormatString="{0:c}" />
								<asp:BoundColumn DataField="Quantity" SortExpression="Quantity" HeaderText="Quantity" />
								<asp:BoundColumn DataField="Discount" SortExpression="Discount" HeaderText="Discount" DataFormatString="{0:p2}" />
								<asp:BoundColumn DataField="CategoryName" SortExpression="CategoryName" HeaderText="Category" />
							</Columns>
							<PagerStyle CssClass="DataGrid_PagerStyle" Mode="NumericPages" />
						</asp:datagrid>
					</td>
				</tr>
				<tr>
					<td>
						<input id="htmlHiddenSortExpression" type="hidden" value="OrderID" runat="server" NAME="htmlHiddenSortExpression"><br>
						<asp:Panel id="pnlCustomPaging" Runat="server" CssClass="CustomPaging">
							<P>Page&nbsp;
								<asp:Label id="lblCurrentPage" runat="server"></asp:Label>&nbsp;of&nbsp;
								<asp:Label id="lblTotalPages" runat="server"></asp:Label></P>
							<P>
								<asp:LinkButton id="lbtnFirstPage" runat="server" Text="[First Page]" OnCommand="NavigationLink_Click"
									CommandName="First"></asp:LinkButton>
								<asp:LinkButton id="lbtnPreviousPage" runat="server" Text="[Previous Page]" OnCommand="NavigationLink_Click"
									CommandName="Prev"></asp:LinkButton>
								<asp:LinkButton id="lbtnNextPage" runat="server" Text="[Next Page]" OnCommand="NavigationLink_Click"
									CommandName="Next"></asp:LinkButton>
								<asp:LinkButton id="lbtnLastPage" runat="server" Text="[Last Page]" OnCommand="NavigationLink_Click"
									CommandName="Last"></asp:LinkButton></P>
						</asp:Panel>
					</td>
				</tr>
			</table>
		</form>
	</body>
</HTML>
