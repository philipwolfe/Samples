<%@ Register TagPrefix="miu" Namespace="MarkItUp.WebControls" Assembly="MarkItUp.WebControls.ContextMenu" %>
<%@ Page language="c#" Codebehind="LinksMaster.aspx.cs" AutoEventWireup="false" Inherits="Demo_ContextMenu.LinksMaster" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<html>
	<head>
		<title>LinksMaster</title>
		<script language="javascript">

			function ChangeTitle( sender, e )
			{
				var value = prompt( "Enter the value for the textbox.", e.MenuItemCommandArgument ) ;
				document.getElementById( "txtPageTitle" ).value = value ;
			}
			
			
			function ChangeColor( sender, e )
			{
				var value = prompt( "Enter a new background color for the page.", e.MenuItemCommandArgument ) ;
				document.body.style.background = value ;
			}

		</script>
		<link id="MainStyle" href="DHTMLPopUpMenu.css" type="text/css" rel="stylesheet">
	</head>
	<body>
		<form id="Form1" method="post" runat="server">
		<p>
			This page demonstrates how to handle ContextMenu events both client-side as well as server-side.
		</p>
			<table cellpadding="2" width="60%" border="0">
				<tr>
					<td>
						<asp:TextBox id="txtPageTitle" runat="server">Dynamic Page</asp:TextBox>
					</td>
					<td width="10%"><miu:contextmenulink id="lnkPageTitle" runat="server" contextmenutoopen="ctxChangeTitle" text="Change Stuff"></miu:contextmenulink></td>
				</tr>
				<tr>
					<td>
						<asp:datagrid id="grdTest" runat="server" enableviewstate="False" width="90%" autogeneratecolumns="False"
							horizontalalign="Center">
							<headerstyle backcolor="#b9d1f4" />
							<alternatingitemstyle backcolor="White" />
							<columns>
								<asp:templatecolumn>
									<itemtemplate>
										<miu:contextmenulink id="ctxChangeTitleFromGrid" runat="server" 
											ImageUrl="Images/PopUpIcon.gif" contextmenutoopen="ctxDataBound" 
												commandargument='<%# DataBinder.Eval(Container.DataItem, "ItemText") %>' />
									</itemtemplate>
								</asp:templatecolumn>
								<asp:boundcolumn datafield="ItemText" />
							</columns>
						</asp:datagrid>
					</td>
					<td width="15%"></td>
				</tr>
			</table>
			
			<!-- THE CONTEXT MENU USED BY THE LINKS IN THE DATAGRID -->
			
			<!-- The context menu item is handled server-side because it
				     doesn't have a ClientNotificationFunction value. -->
			<miu:contextmenu id="ctxDataBound" runat="server">
				<miu:contextmenuitem id="ctxItemChangeTitle2" runat="server" commandargument="" text="Change TextBox value."></miu:contextmenuitem>
			</miu:contextmenu>
			
			
			
			<!-- THE CONTEXT MENU USED BY THE LINK AT THE TOP OF THE PAGE -->
			
			<!-- These context menu item are handled client-side because they
				     DO have a ClientNotificationFunction value. -->
			<miu:contextmenu id="ctxChangeTitle" runat="server">
				<miu:contextmenuitem id="ctxItemChangeColor" runat="server" text="Change background color" commandargument="White"
					clientnotificationfunction="ChangeColor"></miu:contextmenuitem>
				
				<miu:contextmenuitem id="ctxItemChangeTitle" runat="server" text="Change Title" commandargument="New Value"
					clientnotificationfunction="ChangeTitle"></miu:contextmenuitem>
			</miu:contextmenu></form>
	</body>
</html>
