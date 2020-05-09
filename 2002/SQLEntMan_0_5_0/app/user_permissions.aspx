<%@ PAGE Language="VB" src="__codebehinds/user_permissions.aspx.vb" Inherits="ASPEnterpriseManager.Pages.User_Permissions" Trace="False"%>
<%@ Register tagprefix="wes" tagname="TriState" src="__Controls/tristate_Checkbox.ascx" %>
<!--#include file="includes/StyleSheet.aspx"-->
<form runat="server">
	<%	AppInterface.DrawWindowHeader ("Edit User Permissions", "users.aspx", "100%") %>
	<table width="100%" cellpadding="10">
	<tr><td>
		<table width="100%" class="WindowText">
		<tr><td>
			<img src="images/large_Icons_Login.gif" align="ABSMIDDLE">
			<b>&nbsp;&nbsp;Database User: </b>
			&nbsp;&nbsp;<asp:label id="UserName" runat="Server" />
		</td><td align="right">
			<asp:button id="Save" runat="server" onclick="Save_Click" text="Save Permissions" />
		</td></tr>
		</table>
		<br>
		<div style='width:100%; height:400; overflow: auto; background: #ffffff; border: 1px solid #000000;'>
		<asp:Repeater id=Repeater1 OnItemCommand="R1_ItemCommand"  runat="server">
			<HeaderTemplate>
				<table cellpadding="2" cellspacing="0" width="100%">
				<tr><Td class="TableHeader" NOWRAP colspan="2" >
					Object
				</td><Td class="TableHeader" NOWRAP>
					Owner
				</td><td class="TableHeader" NOWRAP width="60" align="center">
					SELECT
				</td><td class="TableHeader" NOWRAP width="60" align="center">
					INSERT
				</td><td class="TableHeader" NOWRAP width="60" align="center">
					UPDATE
				</td><td class="TableHeader" NOWRAP width="60" align="center">
					DELETE
				</td><td class="TableHeader" NOWRAP width="60" align="center">
					EXEC
				</td><td class="TableHeader" NOWRAP width="60" align="center">
					DRI
				</td></tr>
			</HeaderTemplate>
			<ItemTemplate>
				<tr><td class="TableGrid" align="center" width="40">
					<%# iif(Trim(Container.DataItem.ObjectType) = "V", "<img src=""images/small_Icons_views.gif"">", "") %>
					<%# iif(Trim(Container.DataItem.ObjectType) = "P", "<img src=""images/small_Icons_Stored_Procedur.gif"">", "") %>
					<%# iif(Trim(Container.DataItem.ObjectType) = "U", "<img src=""images/small_Icons_tables.gif"">", "") %>
					<asp:label id="ObjectType"  runat="server" Text="<%# Container.DataItem.ObjectType %>" style="visibility: hidden;" />
				</td><td class="TableGrid" NOWRAP>
					<asp:label id="ObjectName" runat="server" Text="<%# Container.DataItem.ObjectName %>" />
				</td><td class="TableGrid" NOWRAP>
					<%# Container.DataItem.ObjectOwner  %>
				</td><td class="TableGrid" NOWRAP align="center">
					<asp:ImageButton id="Select" runat="server" visible=<%# iif(Trim(Container.DataItem.ObjectType) = "P", "false", "true") %> ImageURL=<%# iif(Container.DataItem.PSelect = "GRANT", "__Controls/tristate_checked.gif", iif(Container.DataItem.PSelect = "DENY", "__Controls/tristate_redx.gif", "__Controls/tristate_unchecked.gif")) %> />&nbsp;
				</td><td class="TableGrid" NOWRAP align="center">
					<asp:ImageButton id="Insert" runat="server" visible=<%# iif(Trim(Container.DataItem.ObjectType) = "P", "false", "true") %> ImageURL=<%# iif(Container.DataItem.PInsert = "GRANT", "__Controls/tristate_checked.gif", iif(Container.DataItem.PInsert = "DENY", "__Controls/tristate_redx.gif", "__Controls/tristate_unchecked.gif")) %> />&nbsp;
				</td><td class="TableGrid" NOWRAP align="center">
					<asp:ImageButton id="Update" runat="server" visible=<%# iif(Trim(Container.DataItem.ObjectType) = "P", "false", "true") %> ImageURL=<%# iif(Container.DataItem.PUpdate = "GRANT", "__Controls/tristate_checked.gif", iif(Container.DataItem.PUpdate = "DENY", "__Controls/tristate_redx.gif", "__Controls/tristate_unchecked.gif")) %> />&nbsp;
				</td><td class="TableGrid" NOWRAP align="center">
					<asp:ImageButton id="Delete" runat="server" visible=<%# iif(Trim(Container.DataItem.ObjectType) = "P", "false", "true") %> ImageURL=<%# iif(Container.DataItem.PDelete = "GRANT", "__Controls/tristate_checked.gif", iif(Container.DataItem.PDelete = "DENY", "__Controls/tristate_redx.gif", "__Controls/tristate_unchecked.gif")) %> />&nbsp;
				</td><td class="TableGrid" NOWRAP align="center">
					<asp:ImageButton id="Exec" runat="server" visible=<%# iif(Trim(Container.DataItem.ObjectType) = "U" or Trim(Container.DataItem.ObjectType) = "V", "false", "true") %> ImageURL=<%# iif(Container.DataItem.PExec = "GRANT", "__Controls/tristate_checked.gif", iif(Container.DataItem.PExec = "DENY", "__Controls/tristate_redx.gif", "__Controls/tristate_unchecked.gif")) %> />&nbsp;
				</td><td class="TableGrid" NOWRAP align="center">
					<asp:ImageButton id="Dri" runat="server" visible=<%# iif(Trim(Container.DataItem.ObjectType) = "P" or Trim(Container.DataItem.ObjectType) = "V", "false", "true") %> ImageURL=<%# iif(Container.DataItem.PDri = "GRANT", "__Controls/tristate_checked.gif", iif(Container.DataItem.PDri = "DENY", "__Controls/tristate_redx.gif", "__Controls/tristate_unchecked.gif")) %> />&nbsp;
				</td></tr>
			</ItemTemplate>
			 <FooterTemplate>
	          </table>
	      </FooterTemplate>
		</asp:Repeater>
		</div>
		
	
	</td></tr>
	</table>
	
	<% AppInterface.DrawWindowFooter() %>
	
</form>