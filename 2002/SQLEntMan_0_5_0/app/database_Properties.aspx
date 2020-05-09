<%@ PAGE Language="VB" src="__codebehinds/database_properties.aspx.vb" Inherits="ASPEnterpriseManager.Pages.DatabaseProperties" Trace="False"%>
<!--#include file="includes/StyleSheet.aspx"-->

<br><center>
<%	AppInterface.DrawWindowHeader ("Database Properties", "setDatabase.aspx", "450") %>
	<form runat="server">
	<table width="100%" class="WindowText" cellpadding="5">
		<tr><Td NOWRAP colspan="2">
			<img src="images/Large_Icons_Databases.gif" align="ABSMiddle">&nbsp;&nbsp;&nbsp;&nbsp;
			<b>Name:</b>&nbsp;&nbsp;
			<asp:label id="DBName" runat="server" />
			<br><Br><hr>
		</td></tr>
		<tr><td NOWRAP>
			Owner:
		</td><td>
			<asp:label id="Owner" runat="server" />
		</td></tr>
		<tr><td NOWRAP>
			Date Created:
		</td><td>
			<asp:label id="DateCreated" runat="server" />
		</td></tr>
		<tr><td NOWRAP>
			Database Size:
		</td><td>
			<asp:label id="DatabaseSize" runat="server" />
		</td></tr>
		<tr><td NOWRAP>
			Maximum Size:
		</td><td>
			<asp:label id="MaximumSize" runat="server" />
		</td></tr>
		<tr><td NOWRAP>
			File Size:
		</td><td>
			<asp:label id="FileSize" runat="server" />
		</td></tr>
		<tr><Td colspan="2">
			<br><hr><br>
		</td></tr>
	</table>
	</form>

<% AppInterface.DrawWindowFooter() %>
</center>	