<%@ PAGE Language="VB" src="__codebehinds/databases_edit.aspx.vb" Inherits="ASPEnterpriseManager.Pages.Databases_Edit" Trace="False"%>
<!--#include file="includes/StyleSheet.aspx"-->


<br><center>
<form runat="server">
<%	AppInterface.DrawWindowHeader ("Database Properties", "logins.aspx", "400") %>
	<table width="100%" class="WindowText">
	<tr><td colspan="2" align="right">
		<asp:button text="Save Login" id="Save" OnClick="Save_Click" runat="server" />
		<hr>
	</td></tr>
	<tr><td>
		<img src="images/large_Icons_Databases.gif" ALIGN="LEFT">
	</td><td width="100%">
		<table class="WindowText" width="100%">
			<tr><td NOWRAP>
				<b>Database Name:</b>
			</td><td align="right" width="100%">
				<asp:TextBox id="DatabaseName" runat="server" style="width: 100%;" />
			</td></tr>
		</table>
	</td></tr>
	<tr><td colspan="2">
		<br>
	</td></tr>
	<tr><td>
		Size
	</td><td>
		<hr>
	</td></tr>

	<tr><td>
		&nbsp;
	</td><td>
		<table class="WindowText" width="100%">
		<tr><td>
			<b>Initial Size:</b>
		</td><td align="center">
			<asp:textbox id="InitialSize" runat="server" style="width: 50px;" value="2" /> MB
		</td></tr>
		<tr><td>
			&nbsp;
		</td><td align="center">
			<asp:checkbox id="GrowFile" runat="server" CHECKED /> Automatically grow file
		</td></tr>
		</table>
	</td></tr>
	
	<tr><td colspan="2">
		<br>
	</td></tr>
	<tr><td NOWRAP>
		File Growth
	</td><td>
		<hr>
	</td></tr>
	
	<tr><td>
		&nbsp;
	</td><td>
		<table class="WindowText" width="100%">
		<tr><td>
			<asp:RadioButton id="SelectFileGrowthInMB" runat="server" CHECKED />in  megabytes
		</td><td align="right">
			<asp:textbox id="FileGrowthInMB" runat="server" style="width: 50px;" Value="2" /> MB
		</td></tr>		
		</table>
	</td></tr>
	
	<tr><td colspan="2">
		<br>
	</td></tr>
	<tr><td NOWRAP>
		Max Size
	</td><td>
		<hr>
	</td></tr>
	
	<tr><td>
		&nbsp;
	</td><td>
		<table class="WindowText" width="100%">
		<tr><td>
			<asp:RadioButton id="SelectRestrictFileGrowthInMB" runat="server" CHECKED />restrict file growth
		</td><td align="right">
			<asp:textbox id="RestrictFileGrowthInMB" runat="server" style="width: 50px;" value="8" /> MB
		</td></tr>
		</table>
	</td></tr>
	
	<tr><td colspan="2">
		<br><br>
	</td></tr>
	
	</table>
	
<% AppInterface.DrawWindowFooter() %>
</form>
</center>	
	
	