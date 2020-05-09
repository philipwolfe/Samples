<%@ PAGE Language="VB" src="__codebehinds/tables.aspx.vb" Inherits="ASPEnterpriseManager.Pages.Tables" Trace="False"%>
<!--#include file="includes/StyleSheet.aspx"-->

<br><center>
<%	AppInterface.DrawWindowHeader ("Tables", "setDatabase.aspx", "90%") %>
	
	<div style='width:100%; height:250; overflow:auto; background: #ffffff; border: 1px solid #000000;'>
	<asp:Repeater id=Repeater1 runat="server">
      <HeaderTemplate>
          <table width="100%" cellpadding="2" cellspacing="0">
	          	<tr><td class="TableHeader">	          
						Name
					</td><td class="TableHeader" align="right">
						Owner
					</td></tr>
      </HeaderTemplate>
      <ItemTemplate>
	          <tr ><td NOWRAP class="TableGrid">
	          	<a href="tables_Properties.aspx?table=<%# Container.DataItem.ObjectName %>">
	          		<%# Container.DataItem.ObjectName %></a>
	          </td><td align="right" NOWRAP class="TableGrid">
	         		<%# Container.DataItem.ObjectOwner %>
	          </td></tr>
      </ItemTemplate>
      <FooterTemplate>
          </table>
      </FooterTemplate>
	</asp:Repeater>
	</div>
<% 
	AppInterface.DrawWindowFooter() 
	if request("Sync") <> "true" then AppInterface.SyncLeftFrame() 
%>
</center>	