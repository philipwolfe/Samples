<%@ PAGE Language="VB" src="__codebehinds/users_edit.aspx.vb" Inherits="ASPEnterpriseManager.Pages.Users_Edit" Trace="False"%>
<!--#include file="includes/StyleSheet.aspx"-->

<br><center>
<form runat="server">
<%	AppInterface.DrawWindowHeader ("Edit Database User", "users.aspx", "400") %>
	
	<table width="100%">
		<tr><td align="right" colspan="2">
			<asp:button id="UserPermissions" onclick="UserPermissions_Click" text="Permissions" runat="Server" />
			<asp:button id="SaveUser" onclick="SaveUser_Click" text="Save User" runat="Server" />
			<hr>
		</td></tr>
		<tr><td NOWRAP>
			<img src="images/large_Icons_Users.gif">
			&nbsp;&nbsp;&nbsp;&nbsp;
		</td><td width="100%">
			<asp:panel id="NewUser" runat="server">
				<table width="100%" class="WindowText">
					<tr><td>
						<b>Login Name:</b>
					</td><td align="right">
						<asp:DropDownList id="NewLoginName" runat="server" style="width: 175px;"  />
					</td></tr>
					<tr><td>
						<b>User Name:</b>
					</td><td align="right">
						<asp:textbox id="NewUserName" runat="Server" style="width: 175px;"  />
					</td></tr>
				</table>
			</asp:panel>
			<asp:panel id="CurUser" runat="server">
				<table width="100%" class="WindowText">
					<tr><td NOWRAP>
						<b>Login Name:</b>&nbsp;&nbsp;&nbsp;
					</td><td>
						<asp:label id="LoginName" runat="server" style="width: 175px;"  />
					</td></tr>
					<tr><td NOWRAP>
						<b>User Name:</b>&nbsp;&nbsp;&nbsp;
					</td><td>
						<asp:label id="UserName" runat="Server" style="width: 175px;"  />
					</td></tr>
				</table>
			</asp:panel>
		</td></tr>	
		<tr><Td colspan="2">
			<hr>
		</td></tr>
		<tr><td colspan="2" style="padding: 8px;">
			<table class="InputBorder" width="100%" height="175">
				<tr><td> 
					<asp:CheckBoxList id="DBRoles" class="WindowText"  runat="server" />
				</td></tr>
			</table>
		</td></tr>
	</table>
	
<% AppInterface.DrawWindowFooter() %>
</form>
</center>	
	
	