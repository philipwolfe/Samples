<%@ PAGE Language="VB" src="__codebehinds/logins_edit.aspx.vb" Inherits="ASPEnterpriseManager.Pages.Logins_Edit" Trace="False"%>
<!--#include file="includes/StyleSheet.aspx"-->


<br><center>
<form runat="server">
<%	AppInterface.DrawWindowHeader ("Edit SQL Server Login", "logins.aspx", "400") %>
	<table width="100%" class="WindowText">
	<tr><td colspan="2" align="right">
		<asp:button text="Save Login" id="Save" OnClick="Save_Click" runat="server" />
		<hr>
	</td></tr>
	<tr><td>
		<img src="images/large_Icons_Login.gif" ALIGN="LEFT">
	</td><td width="100%">
		<asp:panel id="NewLogin" runat="Server">
			<table class="WindowText" width="100%">
				<tr><td NOWRAP>
					<b>Login Name:</b>
				</td><td align="right">
					<asp:TextBox id="NewLoginName" runat="server" style="width: 150px;" />
				</td></tr>
			</table>
		</asp:panel>
	
		<asp:panel id="EditLogin"  runat="Server">
			<table class="WindowText" width="100%">
				<tr><td NOWRAP>
					<b>Login Name:&nbsp;&nbsp;&nbsp;</b>
				</td><td width="100%">
					<asp:label id="LoginName" runat="server" />
				</td></tr>
			</table>
		</asp:panel>
	</td></tr>

	<tr><td NOWRAP>
		Authentication&nbsp;
	</td><td width="100%">
		<hr>
	</td></tr>
	
	<tr><td>
		&nbsp;
	</td><td align="right">
		<asp:panel id="NewPassword" runat="Server">
			<table class="WindowText" width="100%">
			<tr><td>
				<b>Password: </b>
			</td><td align="right">
				<asp:textbox id="Password" TextMode="Password" runat="server"  style="width: 150px;"/>
			</td></tr>
			<tr><td>
				<b>Confirm: </b>
			</td><td align="right">
				<asp:textbox id="Confirm" TextMode="Password" runat="server" style="width: 150px;" />
			</td></tr>
			</table>
		</asp:panel>
		
		<asp:panel id="UpdatePassword" runat="Server">
			<table class="WindowText" width="100%">
			<tr><td>
				<b>Old Password: </b>
			</td><td align="right">
				<asp:textbox id="OldPassword" TextMode="Password" runat="server"  style="width: 150px;"/>
			</td></tr>
			<tr><td>
				<b>New Password: </b>
			</td><td align="right">
				<asp:textbox id="ChangePassword" TextMode="Password" runat="server"  style="width: 150px;"/>
			</td></tr>
			<tr><td>
				<b>Confirm: </b>
			</td><td align="right">
				<asp:textbox id="ChangeConfirm" TextMode="Password" runat="server" style="width: 150px;" />
			</td></tr>
			<tr><td colspan="2" align="center">
				<asp:label id="ChangePasswordError" runat="server" style="color: #CC0000; font-weight: bold;" />
			</td></tr>
			<tr><td colspan="2" align="right">
				<asp:button text="Cancel" id="CancelUpdatePassword" onClick="CancelUpdate_Click" runat="server" />
				<asp:button text="Change Password" id="cmdChangePassword" OnClick="cmdChangePassword_Click" runat="server" />
			</table>
		</asp:panel>
		
		<asp:button text="Edit Password" id="EditPassword" OnClick="EditPassword_click" runat="Server" />
		
	</td></tr>
		
	<tr><td NOWRAP>
		Defaults
	</td><td>
		<hr>
	</td></tr>
	
	<tr><td valign="top">
		<img src="images/large_Icons_Defaults.gif" ALIGN="LEFT">
	</td><td>
		Specify the default language and database for this login.
		<br><br>
		<table class="WindowText" width="100%">
			<tr><td>
				<b>Database: </b>
			</td><td align="right">
				<asp:DropDownList id="DefDatabase" runat="server"  style="width: 150px;"/>
			</td></tr>
			<tr><td>
				<b>Language: </b>
			</td><td align="right">
				<asp:DropDownList id="DefLanguage"  DataValueField="ObjectValue" DataTextField="ObjectName"  runat="server" style="width: 150px;" />
			</td></tr>
		</table>
		<br>
	</td></tr>
	
	<tr><td NOWRAP>
		Server Roles
	</td><td>
		<hr>
	</td></tr>
	
	<tr><td colspan="2" style="padding: 20px;">
		<table class="InputBorder" width="100%" height="175">
			<tr><td> 
				<asp:CheckBoxList id="ServerRoles"  DataValueField="ObjectValue" DataTextField="ObjectName" class="WindowText"  runat="server" />
			</td></tr>
		</table>
	</td></tr>
	
	</table>
	
<% AppInterface.DrawWindowFooter() %>
</form>
</center>	
	
	