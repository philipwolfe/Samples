<%@ Control language="VB" src="tristate_Checkbox.ascx.vb" Inherits="ASPEnterpriseManager.Controls.Tristate_Checkbox"  %>


	<table cellpadding="0" cellspacing="0">
	<tr><td>
		<asp:RadioButton id="GRANT"  runat="server" style="visibility: vhidden;" />
	</td><td rowspan="2">
		<asp:ImageButton id="tri_checkbox" runat="server"  />
	</td><td>
		<asp:RadioButton id="NONE"  runat="server"  style="visibility: vhidden;" />
	</td></tr>
	<tr><td>
		<asp:RadioButton id="DENY"  runat="server"  style="visibility: vhidden;" />
	</td></tr>
	</table>
	
	
