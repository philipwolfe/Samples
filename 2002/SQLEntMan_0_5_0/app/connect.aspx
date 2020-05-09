<%@ Page Language="VB" src="__codebehinds/connect.aspx.vb" Inherits="ASPEnterpriseManager.Pages.Connect" %>
<!--#include file="includes/StyleSheet.aspx"-->

<table width="100%" height="90%">
<tr><td valign="top" height="35%">
	<img src="images/_splash_screen.gif">
</td></tr>	
<tr><td align="center" valign="top">
	
	<% AppInterface.DrawWindowHeader ("Connect to Server", "javascript:window.close();", "350") %>
	
		<form runat="server">
		<table width="100%" class="WindowText">
		<tr><td valign="top" rowspan="4" style="padding-right: 10px;">
			<img src="images/icon_SQLServer.gif">
		</td><td NOWRAP>
			Server Address:	
		</td><td>
			<input type="text" id="DataSource" class="InputStyle" runat="server">
		</td></tr>
		<tr><td NOWRAP>
			Username:	
		</td><td>
			<input type="text" id="UID" class="InputStyle" runat="server">
		</td></tr>
		<tr><td NOWRAP>
			Password:	
		</td><td>
			<input type="text" id="PWD" class="InputStyle" runat="server">
		</td></tr>
		<tr><td colspan="2" align="center" style="padding-top: 10px;">
			<input type="submit" value="Connect" class="ButtonStyle">
		</table>
		</form>

	<% AppInterface.DrawWindowFooter() %>

</td></tr>
</table>