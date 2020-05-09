<%@ Import Namespace="ASPEnterpriseManager" %>
<%@ Page language="VB"  Inherits="ASPEnterpriseManager.Page" %>
<!--#include file="includes/StyleSheet.aspx"-->

<% if request("Sync") <> "true" then AppInterface.SyncLeftFrame() 
	if ConnectionString.InitialCatalog <> "" then %>
				<!--	
				<IMG SRC="images/Icons_Diagrams.gif" WIDTH=71 HEIGHT=69 ALT="">   
				-->
				<table cellpadding="0" cellspacing="0">
				<tr><td>
		 			<img src="images/Icons_database.gif">
			 	</td><td>
			 		<h1>&nbsp;&nbsp;<%= ConnectionString.InitialCatalog %></h1>
			 	</td></tr>
			 	</table>
				
				<hr><br>
				<a href="Tables.aspx">
				<IMG SRC="images/Icons_Tables.gif" WIDTH=76 HEIGHT=69 ALT="" border="0"></a>
				
				<a href="views.aspx">
				<IMG SRC="images/Icons_Views.gif" WIDTH=71 HEIGHT=69 ALT="" border="0"></a>
				
				<a href="StoredProcedures.aspx">
				<IMG SRC="images/Icons_StoredProcudures.gif" WIDTH=82 HEIGHT=69 ALT="" border="0"></a>
			
				<a href="Users.aspx">
				<IMG SRC="images/Icons_Users.gif" WIDTH=70 HEIGHT=69 ALT="" border="0"></a>
				
				<a href="DatabaseRoles.aspx">
				<IMG SRC="images/Icons_Roles.gif" WIDTH=74 HEIGHT=69 ALT="" border="0"></a>
		
				<!--
				<IMG SRC="images/Icons_Rules.gif" WIDTH=75 HEIGHT=69 ALT="">
				<IMG SRC="images/Icons_Defaults.gif" WIDTH=70 HEIGHT=69 ALT="">
				<IMG SRC="images/Icons_UserDefinedDataTypes.gif" WIDTH=80 HEIGHT=69 ALT="">
				<IMG SRC="images/Icons_UserDefinedFunctions.gif" WIDTH=80 HEIGHT=69 ALT="">
				<IMG SRC="images/Icons_FullTextCatalogs.gif" WIDTH=72 HEIGHT=69 ALT="">
				-->		
<% else %>
				<br>
				&nbsp;&nbsp;&nbsp;&nbsp;<img src="images/_splash_screen.gif">
				

<% end if %>
