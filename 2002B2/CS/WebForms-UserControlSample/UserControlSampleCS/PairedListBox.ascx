<%@ Control Language="c#" AutoEventWireup="false" Codebehind="PairedListBox.ascx.cs" Inherits="UserControlSample.PairedListBox" %>

<html>
	<head>
		<meta name="GENERATOR" content="Microsoft Visual Studio.NET 7.0">
		<meta name="CODE_LANGUAGE" content="Visual Basic 7.0">
	</head>
	<body>
		<table cellspacing=1 width="75%" border=0>
			<tr>
				<td>
					<div id=divLabel1 runat="server">
						Available:
					</div>
				</td>
				<td>
				</td>
				<td>
					<div id=divLabel2 runat="server">
						Selected:
					</div>
				</td>
			</tr>
			<tr>
				<td>
					<asp:ListBox id=ListBox1 runat="server" width="202">
					</asp:ListBox>
				</td>
				<td width="100" align=middle>
					<asp:Button id=btnAdd runat="server" Height="24" Width="75" Text="Add">
					</asp:Button>
					<br>
					<br>
					<asp:Button id=btnRemove runat="server" Height="24" Width="75" Text="Remove">
					</asp:Button>
				</td>
				<td>
					<asp:ListBox id=ListBox2 runat="server" width="201">
					</asp:ListBox>
				</td>
			</tr>
		</table>
		</form>
	</body>
</html>
