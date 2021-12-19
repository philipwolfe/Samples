<%@ Register TagPrefix="UserControlSample" TagName="PairedListBox" Src="PairedListBox.ascx" %>
<%@ Page language="c#" Codebehind="WebForm1.aspx.cs" AutoEventWireup="false" Inherits="UserControlSample.WebForm1" %>

<html>
	<head>
		<meta name="GENERATOR" content="Microsoft Visual Studio.NET 7.0">
		<meta name="CODE_LANGUAGE" content="C#">
	</head>
	<body>
		<h1>Demo page for PairedListBox user control</h1>
		<p>
			All controls below are encapsulated in a single user control
		</p>
		<form id="WebForm1" method="post" runat="server">
			<!-- -->
			<UserControlSample:PairedListBox id="AvailableSelected" runat="server" NAME="AvailableSelected">
			</UserControlSample:PairedListBox>
		</form>
	</body>
</html>
