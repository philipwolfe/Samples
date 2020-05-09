<%@ PAGE Language="VB" src="__codebehinds/ProcessInfo.aspx.vb" Inherits="ASPEnterpriseManager.Pages.ProcessInfo" Trace="False"%>
<!--#include file="includes/StyleSheet.aspx"-->

<br><center>
<%	AppInterface.DrawWindowHeader ("Process Information", "setDatabase.aspx", "90%") %>
	
	<div style='width:100%; height:400; overflow:auto; background: #ffffff; border: 1px solid #000000;'>
	<asp:Repeater id=Repeater1 runat="server">
      <HeaderTemplate>
          <table width="100%" cellpadding="2" cellspacing="0">
	          	<tr><td class="TableHeader">	          
						SPID
					</td><td class="TableHeader">
						User
					</td><td class="TableHeader">
						Database
					</td><td class="TableHeader">
						Status
					</td><td class="TableHeader">
						Command
					</td><td class="TableHeader">
						Application
					</td><td class="TableHeader">
						CPU
					</td><td class="TableHeader">
						Physical IO
					</td><td class="TableHeader">
						Host
					</td><td class="TableHeader">
						Last Batch
					</td></tr>
      </HeaderTemplate>
      <ItemTemplate>
	          <tr><td NOWRAP class="TableGrid">
	          		<img src="images/process_<%# Trim(Container.DataItem.Status) %>.gif" ALign="ABSMiddle">
	          		<%# Container.DataItem.SPID %>
	          </td><td NOWRAP class="TableGrid">
	         		&nbsp;<%# Container.DataItem.Login %>
	          </td><td NOWRAP class="TableGrid">
	         		&nbsp;<%# Container.DataItem.DBName %>
	          </td><td NOWRAP class="TableGrid">
	         		&nbsp;<%# Container.DataItem.Status %>
	          </td><td NOWRAP class="TableGrid">
	         		&nbsp;<%# Container.DataItem.Command %>
	          </td><td NOWRAP class="TableGrid">
	         		&nbsp;<%# Container.DataItem.ProgramName %>
	          </td><td NOWRAP class="TableGrid">
	         		&nbsp;<%# Container.DataItem.CPUTime %>
	          </td><td NOWRAP class="TableGrid">
	         		&nbsp;<%# Container.DataItem.DiskIO %>
	          </td><td NOWRAP class="TableGrid">
	         		&nbsp;<%# Container.DataItem.HostName %>
	          </td><td NOWRAP class="TableGrid">
	         		&nbsp;<%# Container.DataItem.LastBatch %>
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