<%@ Page language="c#" Codebehind="default.aspx.cs" AutoEventWireup="false" Inherits="FileDownloadSample._default" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>default</title>
		<meta name="GENERATOR" Content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
	</HEAD>
	<body>
		<form id="Form1" method="post" runat="server">
			<h1>File Download Sample</h1>
			<p style="WIDTH:700px">This sample is used to show how you can send a file down to 
				a website visitor from the current page. Simply click on the link below and you 
				will be prompted to download a sample .xls file. You can accomplish this with 
				all types of files. Please see the comments in the codebehind file to see how 
				this is accomplished.</p>
			<p><asp:LinkButton ID="btnDownload" Runat="server">Download File!</asp:LinkButton></p>
			<h2>Disclaimer -
			</h2>
			<p style="WIDTH:700px">This sample is provided as-is and has no warrantees neither 
				expressed nor implied. If you have any questions regarding this sample please 
				feel free to e-mail me at (Mitchel.sellers@gmail.com)</p>
		</form>
	</body>
</HTML>
