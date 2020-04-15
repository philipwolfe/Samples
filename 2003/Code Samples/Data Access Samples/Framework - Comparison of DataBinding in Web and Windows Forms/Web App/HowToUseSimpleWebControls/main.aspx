<%@ Page Language="c#" AutoEventWireup="false" Codebehind="main.aspx.cs" Inherits="Main" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>Visual Basic .NET How-to: Use Simple Controls Shared By Web and Windows 
			Forms</title>
		<meta content="Microsoft Visual Studio.NET 7.0" name="GENERATOR">
		<meta content="Visual Basic 7.0" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
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
			<HR width="100%" SIZE="1">
			<table>
				<tr>
					<td>Fill DropDownList using:</td>
				</tr>
			</table>
			<asp:radiobuttonlist id="optlDataSource" runat="server" RepeatDirection="Horizontal">
				<asp:ListItem Value="DataSet" Selected="True">DataSet</asp:ListItem>
				<asp:ListItem Value="DataReader">DataReader</asp:ListItem>
			</asp:radiobuttonlist>
			<P>New Option:
				<asp:textbox id="txtNewOption" runat="server">All Products</asp:textbox>&nbsp;(leave 
				blank to not add an option)</P>
			<P><asp:button id="btnBindDropDownList" runat="server" Text="Bind DropDownList"></asp:button>&nbsp;
				<asp:button id="btnShowSelectedItem" runat="server" Text="Show Selected Item"></asp:button></P>
			<P><asp:dropdownlist id="cboProducts" runat="server"></asp:dropdownlist></P>
			<P><asp:label id="lblSelected" runat="server"></asp:label></P>
			<P>
				<HR width="100%" SIZE="1">
				<asp:CheckBoxList id="clstProducts" runat="server" RepeatDirection="Horizontal" RepeatColumns="4"></asp:CheckBoxList>
			<P></P>
			<P>
				<asp:Button id="btnShowCheckedItems" runat="server" Text="Show Checked Items"></asp:Button></P>
			<P>
				<asp:Label id="lblChecked" runat="server"></asp:Label></P>
		</form>
	</body>
</HTML>
