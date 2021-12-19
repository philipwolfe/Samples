<%@ Page Language="vb" AutoEventWireup="false" Codebehind="WebForm1.aspx.vb" Inherits="webbTSDemo.WebForm1"%>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>TerraService Demo</title>
		<meta content="Microsoft Visual Studio.NET 7.0" name="GENERATOR">
		<meta content="Visual Basic 7.0" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<asp:label id="Label1" style="Z-INDEX: 101; LEFT: 27px; POSITION: absolute; TOP: 86px" runat="server" Font-Size="X-Small" Font-Names="Verdana">Political Unit</asp:label>
			<asp:label id="Label2" style="Z-INDEX: 102; LEFT: 30px; POSITION: absolute; TOP: 125px" runat="server" Font-Size="X-Small" Font-Names="Verdana">Year</asp:label>
			<asp:label id="lblResult" style="Z-INDEX: 103; LEFT: 32px; POSITION: absolute; TOP: 161px" runat="server" Font-Size="Large" Font-Names="Verdana" Height="182px" Width="300px"></asp:label>
			<asp:textbox id="txtYear" style="Z-INDEX: 104; LEFT: 156px; POSITION: absolute; TOP: 118px" runat="server" Font-Size="X-Small" Font-Names="Verdana">1990</asp:textbox>
			<asp:dropdownlist id="ddPU" style="Z-INDEX: 105; LEFT: 155px; POSITION: absolute; TOP: 87px" runat="server" Font-Size="X-Small" Font-Names="Verdana">
				<asp:ListItem Value="CensusTract">CensusTract</asp:ListItem>
				<asp:ListItem Value="City" Selected="True">City</asp:ListItem>
				<asp:ListItem Value="State">State</asp:ListItem>
				<asp:ListItem Value="County">County</asp:ListItem>
			</asp:dropdownlist>
			<asp:button id="btnCheck" style="Z-INDEX: 106; LEFT: 147px; POSITION: absolute; TOP: 364px" runat="server" Font-Size="X-Small" Text="Check"></asp:button>
			<asp:label id="Label4" style="Z-INDEX: 107; LEFT: 148px; POSITION: absolute; TOP: 15px" runat="server" Font-Size="XX-Large" Font-Names="Verdana" Height="60px" Width="393px" Font-Bold="True">TerraService</asp:label>
			<asp:image id="Image1" style="Z-INDEX: 108; LEFT: 12px; POSITION: absolute; TOP: 10px" runat="server" AlternateText="Microsoft .NET Services" ImageUrl="images/bnrWindowsNgws1_sm.gif"></asp:image>
		</form>
	</body>
</HTML>
