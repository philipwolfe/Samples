<%@ Page language="c#" Codebehind="HelloWorld.aspx.cs" AutoEventWireup="false" Inherits="WebHelloWorld.WebForm1" %>

<HTML>
	<HEAD>
		<meta name=vs_targetSchema content="Internet Explorer 5.0">
		<meta name="GENERATOR" Content="Microsoft Visual Studio 7.0">
		<meta name="CODE_LANGUAGE" Content="C#">
	</HEAD>
	<body ms_positioning="GridLayout">
		<form id="HelloWorld" method="post" runat="server">
			<asp:TextBox id=txtName runat="server" NAME="txtName" style="LEFT: 155px; POSITION: absolute; TOP: 10px">Bob</asp:TextBox>
			<asp:Label id=Label1 runat="server" Width="113px" Height="19px" style="LEFT: 40px; POSITION: absolute; TOP: 13px">
				Enter your name:
			</asp:Label>
			<asp:Button id=Button1 runat="server" Width="98px" Height="24px" Text="Say Hello" style="LEFT: 209px; POSITION: absolute; TOP: 41px">
			</asp:Button>
			<asp:TextBox id=txtGreeting runat="server" Width="251px" Height="26px" NAME="txtGreeting" style="LEFT: 55px; POSITION: absolute; TOP: 79px"></asp:TextBox>
		</form>
	</body>
</HTML>
