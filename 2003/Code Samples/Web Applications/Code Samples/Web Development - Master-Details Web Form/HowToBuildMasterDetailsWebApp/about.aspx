<%@ Page Language="c#" AutoEventWireup="false" Codebehind="about.aspx.cs" Inherits="about"%>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>About ...</title>
		<meta name="GENERATOR" content="Microsoft Visual Studio.NET 7.0">
		<meta name="CODE_LANGUAGE" content="Visual Basic 7.0">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
	</HEAD>
	<body>
		<form id="frmAbout" method="post" runat="server">
			<table id="tblTitle" border="0" width="100%">
				<tr>
					<td align="left" width="85%">
						<h1>About . . .</h1>
					</td>
					<td align="right" width="*">
						<asp:Button id="btnBack" runat="server" Text="Back to Main"></asp:Button>
					</td>
				</tr>
			</table>
			<P>
				<hr>
			<P></P>
			<P>
				<asp:Label id="lblTitle" runat="server" Width="360px">Application Title</asp:Label></P>
			<P>
				<asp:Label id="lblVersion" runat="server" Width="360px">Application Version</asp:Label></P>
			<P>
				<asp:Label id="lblCopyright" runat="server" Width="360px">Application Copyright</asp:Label></P>
			<P>&nbsp;</P>
			<P>
				<asp:Label id="lblDescription" runat="server" Width="360px" Height="50px">Application Description</asp:Label></P>
			<P>
				<asp:Label id="lblCodebase" runat="server" Height="50px">Application Codebase</asp:Label></P>
		</form>
	</body>
</HTML>
