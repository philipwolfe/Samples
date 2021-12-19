<%@ Page Language="vb" AutoEventWireup="false" Codebehind="HelloWorld.vb" Inherits="WebHelloWorld.HelloWorld" %>
<html>
	<head>
		<meta name="GENERATOR" content="Microsoft Visual Studio.NET 7.0">
		<meta name="CODE_LANGUAGE" content="Visual Basic 7.0">
	</head>
	<body ms_positioning="GridLayout">
		<table height="162" cellspacing="0" cellpadding="0" width="757" border="0" ms_2d_layout="TRUE">
			<tr valign="top">
				<td width="10" height="15">
				</td>
				<td width="747">
				</td>
			</tr>
			<tr valign="top">
				<td height="147">
				</td>
				<td>
					<form id="HelloWorld" method="post" runat="server">
						<table height="121" cellspacing="0" cellpadding="0" width="322" border="0" ms_2d_layout="TRUE">
							<tr valign="top">
								<td width="40" height="10">
								</td>
								<td width="15">
								</td>
								<td width="100">
								</td>
								<td width="54">
								</td>
								<td width="113">
								</td>
							</tr>
							<tr valign="top">
								<td colspan="3" height="3">
								</td>
								<td colspan="2" rowspan="2">
									<asp:TextBox id="txtName" runat="server">Bob</asp:TextBox>
								</td>
							</tr>
							<tr valign="top">
								<td height="28">
								</td>
								<td colspan="2">
									<asp:Label id="Label1" runat="server" Width="113" Height="19">Enter your name:</asp:Label>
								</td>
							</tr>
							<tr valign="top">
								<td colspan="4" height="38">
								</td>
								<td>
									<asp:Button id="Button1" runat="server" Width="98" Height="24" Text="Say Hello"></asp:Button>
								</td>
							</tr>
							<tr valign="top">
								<td colspan="2" height="42">
								</td>
								<td colspan="3">
									<asp:TextBox id="txtGreeting" runat="server" Width="251" Height="26"></asp:TextBox>
								</td>
							</tr>
						</table>
					</form>
				</td>
			</tr>
		</table>
	</body>
</html>
