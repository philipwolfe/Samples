<%@ PAGE Language="VB" src="__codebehinds/ServerRoles.aspx.vb" Inherits="ASPEnterpriseManager.Pages.ServerRoles" Trace="False"%>
<!--#include file="includes/StyleSheet.aspx"-->

<br><center>
<%	AppInterface.DrawWindowHeader ("Server Roles", "setDatabase.aspx", "90%") %>
	
	<div style='width:100%; height:250; overflow:auto; background: #ffffff; border: 1px solid #000000;'>
	<asp:Repeater id=Repeater1 runat="server">
      <HeaderTemplate>
          <table width="100%" cellpadding="2" cellspacing="0">
	          	<tr><td class="TableHeader">	          
						Server Role Name
					</td><td class="TableHeader">
						Description
					</td></tr>
      </HeaderTemplate>
      <ItemTemplate>
	          <tr ><td NOWRAP class="TableGrid">
	          		<%# Container.DataItem.ObjectName %>
	          </td><td NOWRAP class="TableGrid">
	         		<%# Container.DataItem.ObjectValue %>
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