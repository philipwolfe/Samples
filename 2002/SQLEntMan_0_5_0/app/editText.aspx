<%@ PAGE Language="VB" src="__codebehinds/EditText.aspx.vb" Inherits="ASPEnterpriseManager.Pages.EditText" Trace="False"%>
<%@ Import Namespace="ASPEnterpriseManager" %>
<!--#include file="includes/StyleSheet.aspx"-->

<br><center>
<%	AppInterface.DrawWindowHeader ("Edit " & Request("Type"), "setDatabase.aspx", "90%") %>
	<form runat="server">
		<asp:label id="Type" runat="Server" visible="False" />
		<asp:label id="Name" runat="Server" visible="False" />
	<table width="100%">
	<tr><td align="right">
		<asp:button id="Save" text="Save" runat="server" OnClick="Save_Click"  />
	</td></tr>
	<tr><td>
		<asp:TextBox id="InputText" TextMode="MultiLine" runat="server" style='width:100%; height:250; background: #ffffff; border: 1px solid #000000;' />
	</td></tr>
	</table>
	</form>
	

<% AppInterface.DrawWindowFooter() %>
</center>	