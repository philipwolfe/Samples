<%@ PAGE Language="VB" src="__codebehinds/tables_Design.aspx.vb" Inherits="ASPEnterpriseManager.Pages.Tables_Design" Trace="False"%>
<!--#include file="includes/StyleSheet.aspx"-->

<script language="javascript" src="javascript/tables_design.js"></script>
<center>
<br>
<form runat="Server" id="editForm">

<%		Dim TableName as String
		if not Session("Table") is Nothing then _
				  TableName = Session("Table").Name
		
		AppInterface.DrawWindowHeader ("Design Table...", iif(not Session("Table") is Nothing, "tables_properties.aspx?Table=" & TableName, "tables.aspx"), "500")  %>

<table width="100%" class="WindowText">
	<tr><Td>
		<b>Table Name:</b>
		<input type="text" name="TableName" id="TableName" runat="Server" />
	</td><td>
		<asp:TextBox id="ColumnsToAdd" runat="server" size="4" />
		<asp:Button text="Add Columns" OnClick="AddColumns_Click" runat="Server" /> 
	</td><td align="right">
		<asp:Button Text="Save Table" OnClick="Save_Click" runat="Server" />
	</td></tr>
</table>
<img src="images/spacer.gif">
	
<div style='height:250; overflow:auto; background: #ffffff; border: 1px solid #000000;'>
	
		<asp:Repeater id=Repeater1 OnItemCommand="R1_ItemCommand"  runat="server">
	      <HeaderTemplate>
	          <table width="100%" cellpadding="2" cellspacing="0">
		          	<tr><td class="TableHeader">	          
							Key
						</td><td class="TableHeader">	          
							Name
						</td><td class="TableHeader">
							Type
						</td><td class="TableHeader">
							Length
						</td><td class="TableHeader">
							Prec
						</td><td class="TableHeader">
							Scale
						</td><td class="TableHeader">
							Nulls
						</td><td class="TableHeader">
							Default
						</td><td class="TableHeader">
							Ident
						</td><td class="TableHeader">
							Seed
						</td><td class="TableHeader">
							Incr
						</td><td class="TableHeader">
							Insert
						</td></tr>
	      </HeaderTemplate>
	      <ItemTemplate>
		          <tr ><td NOWRAP class="TableGrid">
		          	<asp:checkbox id="Key"  Checked="<%# Container.DataItem.IsPrimaryKey %>"  runat="Server" />
		          </td><td NOWRAP class="TableGrid" style="width: 150;">
		          	<input type="Text" id="Name" value="<%# Container.DataItem.Name %>"  class="TableInput"  style="width: 100%;" runat="Server" />
		          </td><td  NOWRAP class="TableGrid">
		         
		         <!--
		         '********************************* MAKE A CONTROL OUT OF THIS *******************************************
		         ' Figure out how to databind this dropdown list to the SystemInfo.DataTypes and set the appropriate value	
		         '********************************************************************************************************
		         -->
				   	<script language=VB runat="Server">
		         		Dim SystemInfo as ASPEnterpriseManager.SystemInformation = New ASPEnterpriseManager.SystemInformation
		         		function GetIndex(s as String) as Integer
		         			Dim X as Integer
		         			For X = 0 to Ubound(SystemInfo.DataTypes) - 1
		         				if SystemInfo.DataTypes(X) = s then return (x)
		         			Next
		         		End Function
		         	</script>
		         	<asp:DropDownList onChange="SetFields (this, 1);" id="Type" class="TableInput" 
		         		runat="server" SelectedIndex='<%# GetIndex(Container.DataItem.Type) %>'>
		         			<asp:ListItem>binary</asp:ListItem>
					         <asp:ListItem>bit</asp:ListItem>
					         <asp:ListItem>char</asp:ListItem> 
					         <asp:ListItem>datetime</asp:ListItem>
					         <asp:ListItem>decimal</asp:ListItem>
					         <asp:ListItem>float</asp:ListItem>
					         <asp:ListItem>image</asp:ListItem>
					         <asp:ListItem>int</asp:ListItem>
					         <asp:ListItem>money</asp:ListItem>
					         <asp:ListItem>nchar</asp:ListItem>
					      	<asp:ListItem>ntext</asp:ListItem>
					      	<asp:ListItem>numeric</asp:ListItem>
					      	<asp:ListItem>nvarchar</asp:ListItem>
					      	<asp:ListItem>real</asp:ListItem>
					      	<asp:ListItem>smalldatetime</asp:ListItem>
					      	<asp:ListItem>smallint</asp:ListItem>
					      	<asp:ListItem>smallmoney</asp:ListItem>
					      	<asp:ListItem>text</asp:ListItem>
					      	<asp:ListItem>timestamp</asp:ListItem>
					      	<asp:ListItem>tinyint</asp:ListItem>
					      	<asp:ListItem>uniqueidentifier</asp:ListItem>
					      	<asp:ListItem>varbinary</asp:ListItem>
					      	<asp:ListItem>varchar</asp:ListItem> 
				      </asp:DropDownList>
				    <!--  
				    ' ********************************* END CONTROL PART ******************************************************
				    -->  
		          </td><td  NOWRAP class="TableGrid">
		          	<input type="text" id="Length" value="<%# Container.DataItem.Length %>" size="4" class="TableInput"  runat="Server" />
		          </td><td  NOWRAP class="TableGrid">
		         	<input type="text" id="Precision" value="<%# Container.DataItem.Precision %>" size="4" class="TableInput"  runat="Server" />
		          </td><td  NOWRAP class="TableGrid">
		         	<input type="text" id="Scale" value="<%# Container.DataItem.Scale %>" size="4" class="TableInput"  runat="Server" />
		          </td><td NOWRAP class="TableGrid" align="center">
		          	<asp:checkbox id="Nulls"  Checked="<%# Container.DataItem.AllowNulls %>"  runat="Server" />
		          </td><td NOWRAP class="TableGrid">
		          	<input type="text" id="DefaultValue" value="<%# Container.DataItem.DefaultValue %>" class="TableInput"  runat="Server" />
		          </td><td NOWRAP class="TableGrid" align="center">
		          	<asp:checkbox type="checkbox" id="Identity" Checked="<%# Container.DataItem.IsIdentity %>" runat="Server" />
		          </td><td  NOWRAP class="TableGrid">
		         	<input type="text" id="Seed" value="<%# Container.DataItem.Seed %>" size="2" class="TableInput"  runat="Server" />
		          </td><td  NOWRAP class="TableGrid">
		         	<input type="text" id="Increment" value="<%# Container.DataItem.Increment %>" class="TableInput"  size="2" runat="Server" />
		          </td><td  NOWRAP class="TableGrid">
		          	 <asp:Button id="Insert" Text="Insert" runat="server" />
		          </td></tr>
	      </ItemTemplate>
	      <FooterTemplate>
	          </table>
	      </FooterTemplate>
	  </asp:Repeater>
</div>

<% AppInterface.DrawWindowFooter() %>

</form>
</center>

<!-- The Folllowing Javascript Initializes the inputs appropriately --->
<script language="javascript">
	for(x=1; x <= <%= Repeater1.Items.Count %>; x++) {
		SetFields (document.forms("editForm").elements("Repeater1:_ctl" + x + ":Type"), 0);
	}
</script>



