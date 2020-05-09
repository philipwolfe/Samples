<%@ PAGE Language="VB" src="__codebehinds/users.aspx.vb" Inherits="ASPEnterpriseManager.Pages.Users" Trace="False"%>
<%@ Import Namespace="ASPEnterpriseManager" %>
<!--#include file="includes/StyleSheet.aspx"-->

<br><center>
<%	AppInterface.DrawWindowHeader ("Database Users", "setDatabase.aspx", "90%") %>

	<a href="users_edit.aspx">New User</a>
	
	<div style='width:100%; height:250; overflow:auto; background: #ffffff; border: 1px solid #000000;'>
	<asp:Repeater id=Repeater1 runat="server">
	      <HeaderTemplate>
	          <table width="100%" cellpadding="2" cellspacing="0">
		          	<tr><td class="TableHeader" colspan="2">	          
							User Name
						</td><td class="TableHeader">	          
							Login Name
						</td><td class="TableHeader" align="right" >
							Default DB
						</td></tr>
	      </HeaderTemplate>
	      <ItemTemplate>
		          <tr ><td width="20">
		          	<img src="images/small_icons_users.gif">
		          </td><td NOWRAP class="TableGrid">
		          	<a href="users_edit.aspx?loginName=<%# Container.DataItem.UserName %>">
		          		<%# Container.DataItem.UserName %></a>
		          </td><td NOWRAP class="TableGrid">
		          	<%# Container.DataItem.LoginName %>
		          </td><td align="right" NOWRAP class="TableGrid">
		         	<%# Container.DataItem.DefaultDB %>
		          </td></tr>
	      </ItemTemplate>
	      <FooterTemplate>
	          </table>
	      </FooterTemplate>
	  </asp:Repeater>

	</div>
<% AppInterface.DrawWindowFooter() %>
</center>	