<%@ Page Language="c#" AutoEventWireup="false" Codebehind="main.aspx.cs" Inherits="Main" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>Visual Basic .NET How-to: (Change Me)</title>
		<meta name="GENERATOR" content="Microsoft Visual Studio.NET 7.0">
		<meta name="CODE_LANGUAGE" content="Visual Basic 7.0">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
	</HEAD>
	<body>
		<form id="frmMain" method="post" runat="server">
			<table id="tblTitle" border="0" width="100%">
				<tr>
					<td align="left" width="85%">
						<h1>
							<asp:Label id="lblTitle" runat="server"> Text read from Page_Load</asp:Label>
						</h1>
					</td>
					<td align="right" width="*">
						<asp:Button id="btnAbout" runat="server" Text="About . . ."></asp:Button>
					</td>
				</tr>
			</table>
			<P>
				<hr>
			<P></P>
			<P>
				<asp:Button id="btnTenMost" runat="server" Text="Get Ten Most Expensive Products"></asp:Button><BR>
				<BR>
				<asp:DataGrid id="grdProducts" runat="server" BorderColor="#E7E7FF" BorderStyle="None" BorderWidth="1px" BackColor="White" CellPadding="3" GridLines="Horizontal">
					<SelectedItemStyle Font-Bold="True" ForeColor="#F7F7F7" BackColor="#738A9C"></SelectedItemStyle>
					<AlternatingItemStyle BackColor="#F7F7F7"></AlternatingItemStyle>
					<ItemStyle ForeColor="#4A3C8C" BackColor="#E7E7FF"></ItemStyle>
					<HeaderStyle Font-Bold="True" ForeColor="#F7F7F7" BackColor="#4A3C8C"></HeaderStyle>
					<FooterStyle ForeColor="#4A3C8C" BackColor="#B5C7DE"></FooterStyle>
					<PagerStyle HorizontalAlign="Right" ForeColor="#4A3C8C" BackColor="#E7E7FF" Mode="NumericPages"></PagerStyle>
				</asp:DataGrid></P>
		</form>
	</body>
</HTML>
