<%@ PAGE Language="VB" src="__codebehinds/logins.aspx.vb" Inherits="ASPEnterpriseManager.Pages.Logins" Trace="False"%>
<%@ Import Namespace="ASPEnterpriseManager" %>
<!--#include file="includes/StyleSheet.aspx"-->

<br><center>
<%	AppInterface.DrawWindowHeader ("SQL Server Logins", "setDatabase.aspx", "90%") %>

	<div style='width:100%; height:250; overflow:auto; background: #ffffff; border: 1px solid #000000;'>
	<asp:Repeater id=Repeater1 runat="server">
	      <HeaderTemplate>
	          <table width="100%" cellpadding="2" cellspacing="0">
		          	<tr><td class="TableHeader">	          
							Login Name
						</td><td class="TableHeader">
							Default DB
						</td><td class="TableHeader"align="right" >
							Default Language
						</td></tr>
	      </HeaderTemplate>
	      <ItemTemplate>
		          <tr ><td NOWRAP class="TableGrid">
		          	<a href="logins_edit.aspx?loginName=<%# Container.DataItem.Name %>">
		          		<%# Container.DataItem.Name %></a>
		          </td><td NOWRAP class="TableGrid">
		          	<%# Container.DataItem.DefaultDB %>
		          </td><td align="right" NOWRAP class="TableGrid">
		         	<%# Container.DataItem.DefaultLanguage %>
		          </td></tr>
	      </ItemTemplate>
	      <FooterTemplate>
	          </table>
	      </FooterTemplate>
	  </asp:Repeater>

	</div>
<% AppInterface.DrawWindowFooter() %>
</center>	