<%@ Page language="c#" Codebehind="Config.aspx.cs" AutoEventWireup="false" Inherits="WebSample.Config" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>Config</title>
		<meta name="GENERATOR" Content="Microsoft Visual Studio 7.0">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="Config" method="post" runat="server">
			<asp:Button id="btnEncrypt" style="Z-INDEX: 101; LEFT: 47px; POSITION: absolute; TOP: 192px" runat="server" Text="Encrypt"></asp:Button>
			<asp:TextBox id="txtDecryptedData" style="Z-INDEX: 110; LEFT: 46px; POSITION: absolute; TOP: 155px" runat="server" Width="414px"></asp:TextBox>
			<asp:TextBox id="txtEncryptedData" style="Z-INDEX: 109; LEFT: 46px; POSITION: absolute; TOP: 107px" runat="server" Width="417px"></asp:TextBox>
			<asp:Label id="lblDecryptedData" style="Z-INDEX: 108; LEFT: 46px; POSITION: absolute; TOP: 133px" runat="server">Decrypted Data</asp:Label>
			<asp:Label id="lblEncryptedData" style="Z-INDEX: 107; LEFT: 46px; POSITION: absolute; TOP: 84px" runat="server">Encrypted Data</asp:Label>
			<asp:TextBox id="txtDataToEncrypt" style="Z-INDEX: 105; LEFT: 47px; POSITION: absolute; TOP: 51px" runat="server" Width="416px"></asp:TextBox>
			<asp:Button id="btnDecrypt" style="Z-INDEX: 102; LEFT: 136px; POSITION: absolute; TOP: 193px" runat="server" Text="Decrypt"></asp:Button>
			<asp:Label id="lblDataToEncrypt" style="Z-INDEX: 106; LEFT: 46px; POSITION: absolute; TOP: 28px" runat="server">Data to Encrypt</asp:Label>
			<asp:Label id="lblError" style="Z-INDEX: 111; LEFT: 216px; POSITION: absolute; TOP: 196px" runat="server" ForeColor="Red"></asp:Label>
		</form>
	</body>
</HTML>
