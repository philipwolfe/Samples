<%@ Page Language="c#" AutoEventWireup="false" Codebehind="main.aspx.cs" Inherits="Main" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>C# .NET How-to: Build a Master-Details Web Application</title>
		<meta content="Microsoft Visual Studio.NET 7.0" name="GENERATOR">
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
			<TABLE width="100%" border="0">
				<TR>
					<td><asp:button id="btnAddNew" Text="Add New Item" CssClass="Button" Runat="server" CausesValidation="False"></asp:button></td>
				</TR>
				<TR>
					<TD vAlign="top"><asp:datagrid id="grdProducts" runat="server" AllowPaging="True" AutoGenerateColumns="False" AllowSorting="True"
							DataKeyField="ProductID">
							<SelectedItemStyle CssClass="DataGrid_SelectedItemStyle" />
							<ItemStyle CssClass="DataGrid_ItemStyle" />
							<AlternatingItemStyle CssClass="DataGrid_AlternatingItemStyle" />
							<HeaderStyle CssClass="DataGrid_HeaderStyle" />
							<FooterStyle CssClass="DataGrid_FooterStyle" />
							<Columns>
								<asp:BoundColumn DataField="ProductID" SortExpression="ProductID" HeaderText="Product ID" />
								<asp:BoundColumn DataField="ProductName" SortExpression="ProductName" HeaderText="Product" />
								<asp:BoundColumn DataField="QuantityPerUnit" SortExpression="QuantityPerUnit" HeaderText="Qty / Unit" />
								<asp:BoundColumn DataField="UnitPrice" SortExpression="UnitPrice" HeaderText="Unit Price" DataFormatString="{0:c}" />
								<asp:BoundColumn DataField="UnitsInStock" SortExpression="UnitsInStock" HeaderText="# In Stock" />
								<asp:TemplateColumn SortExpression="Discontinued" ItemStyle-CssClass="Discontinued" HeaderText="Discontinued">
									<ItemTemplate>
										<asp:CheckBox ID="chkDiscontinuedGrid" Runat="server" Checked='<%# Convert.ToBoolean(DataBinder.Eval(Container.DataItem, "Discontinued")) %>' />
									</ItemTemplate>
								</asp:TemplateColumn>
								<asp:ButtonColumn Text="Edit" ButtonType="PushButton" CommandName="Select" />
								<asp:ButtonColumn Text="Delete" ButtonType="PushButton" CommandName="Select" />
							</Columns>
							<PagerStyle CssClass="DataGrid_PagerStyle" Mode="NumericPages" />
						</asp:datagrid><br>
						<input id="htmlHiddenSortExpression" type="hidden" value="ProductID" name="htmlHiddenSortExpression"
							runat="server">
					</TD>
				</TR>
			</TABLE>
			<span class="Message">
				<%= strMsg %>
			</span><span class="ErrorMessage">
				<%= strErrorMsg %>
			</span>
			<asp:panel id="pnlForm" Visible="False" Runat="server">
				<TABLE id="Table1" width="100%">
					<TR>
						<TD class="FormLabel" width="15%">Product Name:
						</TD>
						<TD class="FormInput">
							<asp:textbox id="txtProductName" runat="server" Columns="42" MaxLength="40" EnableViewState="False"></asp:textbox>&nbsp;
							<asp:RequiredFieldValidator id="rfvProductName" runat="server" ErrorMessage="Required!" Display="Dynamic" ControlToValidate="txtProductName"></asp:RequiredFieldValidator></TD>
					</TR>
					<TR>
						<TD class="FormLabel">Qty / Unit:
						</TD>
						<TD class="FormInput">
							<asp:textbox id="txtQtyUnit" runat="server" Columns="22" MaxLength="20" EnableViewState="False"></asp:textbox>&nbsp;
							<asp:RequiredFieldValidator id="rfvQtyUnit" runat="server" ErrorMessage="Required!" Display="Dynamic" ControlToValidate="txtQtyUnit"></asp:RequiredFieldValidator></TD>
					</TR>
					<TR>
						<TD class="FormLabel">Unit Price:
						</TD>
						<TD class="FormInput">
							<asp:textbox id="txtPrice" runat="server" Columns="10" MaxLength="8" EnableViewState="False"></asp:textbox>&nbsp;
							<asp:RequiredFieldValidator id="rfvPrice" runat="server" ErrorMessage="Required!" Display="Dynamic" ControlToValidate="txtPrice"></asp:RequiredFieldValidator>&nbsp;
							<asp:RegularExpressionValidator id="revPrice" runat="server" ErrorMessage="You must enter a valid price." Display="Dynamic"
								ControlToValidate="txtPrice" ValidationExpression="\d+[.]?[\d]{0,2}"></asp:RegularExpressionValidator></TD>
					</TR>
					<TR>
						<TD class="FormLabel"># In Stock:
						</TD>
						<TD class="FormInput">
							<asp:textbox id="txtInStock" runat="server" Columns="6" MaxLength="4" EnableViewState="False"></asp:textbox>&nbsp;
							<asp:RequiredFieldValidator id="rfvInStock" runat="server" ErrorMessage="Required!" Display="Dynamic" ControlToValidate="txtInStock"></asp:RequiredFieldValidator>&nbsp;
							<asp:RegularExpressionValidator id="revInStock" runat="server" ErrorMessage="You must enter a number." Display="Dynamic"
								ControlToValidate="txtInStock" ValidationExpression="\d+"></asp:RegularExpressionValidator></TD>
					</TR>
					<TR>
						<TD class="FormLabel">Discontinued:
						</TD>
						<TD class="FormCheckBox">
							<asp:checkbox id="chkDiscontinued" runat="server" CssClass="CheckBox"></asp:checkbox></TD>
					</TR>
					<TR>
						<TD>&nbsp;</TD>
						<TD>
							<asp:Button id="btnSave" Text="Save Changes" Runat="server" CssClass="Button"></asp:Button></TD>
					</TR>
				</TABLE>
			</asp:panel></form>
	</body>
</HTML>
