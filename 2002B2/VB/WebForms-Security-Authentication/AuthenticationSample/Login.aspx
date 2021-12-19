<%@ Page Language="vb" AutoEventWireup="false" Codebehind="Login.aspx.vb" Inherits="Authentication_Sample.WebForm1" %>
<HTML>
	<HEAD>
		<title>Authentication Sample - Login Page </title>
		<meta content="Microsoft Visual Studio.NET 7.0" name="GENERATOR">
		<meta content="Visual Basic 7.0" name="CODE_LANGUAGE">
	</HEAD>
	<body>
		<form id="Login" method="post" runat="server">
			<table cellSpacing="1" width="75%" border="0">
				<tr>
					<td align="right">
						User Name:
					</td>
					<td>
						<input id="txtUser" type="text" maxLength="20" runat="server" NAME="txtUser">
					</td>
				</tr>
				<tr>
					<td align="right">
						Password:
					</td>
					<td>
						<input id="txtPassword" type="password" runat="server" NAME="txtPassword">
					</td>
				</tr>
				<tr>
					<td align="right">
					</td>
					<td>
						<input id="Submit1" type="submit" value="Submit" runat="server" NAME="Submit1">
					</td>
				</tr>
				<tr>
					<td>
					</td>
					<td align="left">
						<asp:customvalidator id="LoginValCust" runat="server" ErrorMessage="Invalid Login" OnServerValidate="LoginServerValidate"></asp:customvalidator>
					</td>
				</tr>
			</table>
		</form>
	</body>
</HTML>
