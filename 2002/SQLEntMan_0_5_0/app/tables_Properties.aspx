<%@ PAGE Language="VB" src="__codebehinds/table_Properties.aspx.vb" Inherits="Table_Properties" Trace="False"%>
<!--#include file="includes/StyleSheet.aspx"-->
<center> 
<br>
	<%	
		if request("Sync") = "true" then AppInterface.SyncLeftFrame() 
		
		AppInterface.DrawWindowHeader ("Table Properties", "tables.aspx", "450") %>
		
		<form runat="server">		
		<table width="100%" class="WindowText" cellpadding="7" height="100%">
			<tr><td colspan="2">
				<table width="100%" class="WindowText">
					<tr><Td NOWRAP>
						<img src="images/large_icons_tableProps.gif" align="ABSMiddle">
						&nbsp;&nbsp;&nbsp;&nbsp;
						<b>Name:</b>&nbsp;&nbsp; <%= request("table") %>
					</td><td align="right">
						&nbsp;&nbsp;&nbsp;&nbsp;
						
						<asp:ImageButton id="DropTable" ImageUrl="buttons/delete.gif" runat="server"
										onmouseover="this.src='buttons/delete_over.gif';"
           							onmouseout="this.src='buttons/delete.gif';" OnClick="DropTable_Click" />
						
						&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
						
						<asp:ImageButton id="InsertData" ImageUrl="buttons/insertData.gif" runat="server"
										onmouseover="this.src='buttons/insertData_Over.gif';"
           							onmouseout="this.src='buttons/insertData.gif';" OnClick="InsertData_Click" />
						
						&nbsp;
						
						<asp:ImageButton id="DesignTable" ImageUrl="buttons/table.gif" runat="server"
										onmouseover="this.src='buttons/table_over.gif';"
           							onmouseout="this.src='buttons/table.gif';" OnClick="DesignTable_Click" />
						
						<asp:ImageButton id="QueryTable" ImageUrl="buttons/run.gif" runat="server"
										onmouseover="this.src='buttons/run_over.gif';"
           							onmouseout="this.src='buttons/run.gif';" OnClick="QueryTable_Click" />
						
					</td></tr>
				</table>
			</td></tr>
			<tr><td colspan="2">
				<hr>
				<table width="100%" class="WindowText" cellpadding="5">
					<tr><td NOWRAP>
						<b>Owner:</b> 
					</td><td NOWRAP>
							<asp:label id="TableOwner" runat="Server" />
					</td></tr>
					
					<tr><td NOWRAP>
						<b>Create date:</b> 
					</td><td NOWRAP>
							<asp:label id="DateCreated" runat="Server" />
					</td></tr>
				</table>
				<br>
				<hr style="margin-bottom: 2px;">
				
			</td></tr>
			<tr><td height="100%" valign="top">
				<b>Columns:</b>
				<br>
				<div style='width:100%; height:250; overflow:auto; background: #ffffff; border: 1px solid #000000;'>
					<asp:Repeater id=Repeater1 OnItemCommand="R1_ItemCommand"  runat="server">
						<HeaderTemplate>
							<table cellpadding="2" cellspacing="0" width="100%">
							<tr><Td class="TableHeader" NOWRAP>
								Drop
							</td><Td class="TableHeader" NOWRAP>
								Key
							</td><td class="TableHeader" NOWRAP>
								ID
							</td><td class="TableHeader" width="100%" NOWRAP>
								Name
							</td><td class="TableHeader" NOWRAP>
								Data Type
							</td><td class="TableHeader" NOWRAP>
								Size
							</td><td class="TableHeader" NOWRAP>
								Nulls
							</td><td class="TableHeader" NOWRAP>
								Default
							</td></tr>
						</HeaderTemplate>
						<ItemTemplate>							
							<tr><td class="TableGrid" align="center">
								<asp:imagebutton id="Drop" runat="server"  src="images/drop.gif" />
							</td><td class="TableGrid" align="center" NOWRAP>
								<%# iif(Session("Table").Keys.ContainsKey(Container.DataItem.Name), "<img src=""images/key.gif"">", "&nbsp;") %>							
							</td><td class="TableGrid" align="center" NOWRAP>
								<%# iif(Container.DataItem.IsIdentity, "<img src=""images/checkbox.gif"">", "&nbsp;") %>
							</td><td class="TableGrid" NOWRAP>
								<%# Container.DataItem.Name %>
							</td><td class="TableGrid" NOWRAP>
								<%# Container.DataItem.Type %>
							</td><td class="TableGrid" NOWRAP>
								<%# iif(Container.DataItem.Size <> "", Container.DataItem.Size, "&nbsp;") %>
							</td><td class="TableGrid" align="center" NOWRAP>
								<%# iif(Container.DataItem.AllowNulls, "<img src=""images/checkbox.gif"">", "&nbsp;") %>
							</td><td class="TableGrid" NOWRAP>
								<%# iif(Container.DataItem.DefaultValue = "", "&nbsp;", Container.DataItem.DefaultValue) %>
							</td></tr>
						</ItemTemplate>
						 <FooterTemplate>
				          </table>
				      </FooterTemplate>
					</asp:Repeater>
				</div>
			</td></tr>
		</table>			
		</form>
		
	<% AppInterface.DrawWindowFooter() %>
