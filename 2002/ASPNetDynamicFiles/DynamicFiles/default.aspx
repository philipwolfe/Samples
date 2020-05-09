<%@ Page language="c#" Codebehind="default.aspx.cs" AutoEventWireup="false" Inherits="DynamicFiles.WebForm1" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>WebForm1</title>
		<meta name="GENERATOR" Content="Microsoft Visual Studio 7.0">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
	</HEAD>
	<body style="FONT-FAMILY: Arial">
		<form id="Form1" method="post" runat="server">
			<P>
				<asp:Button id="bttnStoreImage" runat="server" Text="Store Image" DESIGNTIMEDRAGDROP="13"></asp:Button></P>
			<P>
				Available&nbsp;file IDs<BR>
				<asp:DataGrid id="fileList" runat="server" ShowHeader="False"></asp:DataGrid>
			<P>File ID:
				<asp:TextBox id="fileID" runat="server" Width="100%"></asp:TextBox></P>
			<P>Load the image in the aspx page and return it directly.<BR>
				<asp:Button id="bttnGetImage" runat="server" DESIGNTIMEDRAGDROP="12" Text="Stream Image"></asp:Button>&nbsp;</P>
			<P>
				Redirect the browser to a URL which represents the image.<BR>
				<asp:Button id="bttnRedirect" runat="server" Text="Redirect to Image"></asp:Button></P>
		</form>
	</body>
</HTML>
