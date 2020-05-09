<%@ PAGE Language="VB" src="__codebehinds/DatabaseRoles.aspx.vb" Inherits="ASPEnterpriseManager.Pages.DatabaseRoles" Trace="False"%>
<!--#include file="includes/StyleSheet.aspx"-->

<br><center>
<%	AppInterface.DrawWindowHeader ("Database Roles", "setDatabase.aspx", "90%") %>
	
	<div style='width:100%; height:250; overflow:auto; background: #ffffff; border: 1px solid #000000;'>
	<asp:Repeater id=Repeater1 runat="server">
      <HeaderTemplate>
          <table width="100%" cellpadding="2" cellspacing="0">
	          	<tr><td class="TableHeader">	          
						Server Role Name
					</td><td class="TableHeader">
						Role ID
					</td><td class="TableHeader">
						Is App Role
					</td></tr>
      </HeaderTemplate>
      <ItemTemplate>
	          <tr ><td NOWRAP class="TableGrid">
	          		<%# Container.DataItem.RoleName %>
	          </td><td NOWRAP class="TableGrid">
	         		<%# Container.DataItem.RoleID %>
	          </td><td NOWRAP class="TableGrid">
	         		<%# Container.DataItem.IsAppRole %>
	          </td></tr>
      </ItemTemplate>
      <FooterTemplate>
          </table>
      </FooterTemplate>
	</asp:Repeater>
	</div>
<% 
	AppInterface.DrawWindowFooter() 
%>
</center>	