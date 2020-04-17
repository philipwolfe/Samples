<%@ Control Language="C#" AutoEventWireup="true" CodeFile="FilterControl.ascx.cs"
	Inherits="Controls_FilterControl" %>
<table>
	<tr>
		<td style="vertical-align: middle">
			Filter by
		</td>
		<td style="vertical-align: middle">
			<asp:DropDownList ID="dropDownList" runat="server">
			</asp:DropDownList></td>
		<td style="vertical-align: middle">
			&nbsp;=&nbsp;
		</td>
		<td style="vertical-align: middle">
			<asp:TextBox ID="filterTextBox" runat="server"></asp:TextBox>
		</td>
		<td style="vertical-align: middle">
			<asp:Button ID="button" runat="server" Text="Go" OnClick="button_Click" /></td>
	</tr>
</table>
