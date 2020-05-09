<%@ Control language="VB" %>	
<%@ Import Namespace="ASPEnterpriseManager" %> 

<% 	
 	Dim X as Integer
 	Dim Y As Integer
 	Dim Server as ASpEnterpriseManager.Server = New Server
 	DIm Database as ASPEnterpriseManager.Database
 	Server.LoadDatabases()
 	if ConnectionString.InitialCatalog <> "" then 
 		Database = New Database
 		Database.LoadObjects
 		Session("Database") = Database
 	end if
 	Session("Server") = Server
%> 	

		<table class="LeftStyle" cellpadding="1" cellspacing="0">
			<tr><td width="100%" colspan="2">
				<img src="images/small_Icons_Folder.gif" align="left">
				&nbsp;Databases
			</td></tr>
		
			
<%			For X = 0 To Server.Databases.Count - 1 %>
		
					<tr><td>		
						&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<img src="images/smallIcon_database.gif">	
					</td><td width="100%">
				  		<a href="setdatabase.aspx?Catalog=<%= Server.Databases(X)%>"  target="MainFrame">
				   		<%= Server.Databases(X) %></a>
					</td></tr>
				

		<%		if lcase(ConnectionString.InitialCatalog) = lcase(Server.Databases(X)) then  %>
					
						<!--
						<tr><td>
							&nbsp;
						</td><td>
							<img src="images/small_Icons_Diagrams.gif" ALIGN="ABSMIDDLE">
							&nbsp;Diagrams				
						</td></tr>
						-->
						
						<tr><td>
							&nbsp;
						</td><td>
							<img src="images/small_Icons_Tables.gif" ALIGN="ABSMIDDLE">
							<a href="tables.aspx" target="MainFrame">
								&nbsp;<b>Tables</b></a>
						</td></tr>
						
		<!-- TABLES -->						
						<tr><td>
							&nbsp;
						</td><td>
							&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
							<a href="tables_design.aspx?NewTable=true" target="MainFrame">
							<i>New Table...</i></a>	
						</td></tr>
							
				<!-- ENUMERATE TABLES -->	
						<% for Y = 0 to Database.Tables.Count - 1 %> 
							<tr><td>
								&nbsp;
							</td><td NOWRAP>
								&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
								<a class="ItemLink" href="tables_properties.aspx?table=<%= Database.Tables(Y).ObjectName %>" target="MainFrame">
									<%= Database.Tables(Y).ObjectName %></a>
							</td><td>
						<% Next %>	
								
						
		
		<!-- VIEWS -->				
						<tr><td>
							&nbsp;
						</td><td>
							<img src="images/small_Icons_Views.gif" ALIGN="ABSMIDDLE">
							&nbsp;<a href="views.aspx" target="MainFrame"><b>Views</b></a>
						</td></tr>
						
						<tr><td>
							&nbsp;
						</td><td>
							&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
							<a href="editText.aspx?Type=View" target="MainFrame">
								<i>New View...</i></a>
						</td></tr>
			
				<!--- ENUMERATE VIEWS -->
						<% for Y = 0 to Database.Views.Count - 1 %> 
								<tr><td>
									&nbsp;
								</td><td NOWRAP>
									&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
									<a class="ItemLink" href="editText.aspx?Type=View&View=<%= Database.Views(Y).ObjectName %>" target="MainFrame">
										<%= Database.Views(Y).ObjectName %></a>
								</td><td>
						<% Next %>	
						
								
						
		<!-- STORED PROCEDURES -->				
						<tr><td>
							&nbsp;
						</td><td NOWRAP>
							<img src="images/small_Icons_Stored_Procedur.gif" ALIGN="ABSMIDDLE">
							&nbsp;<a href="storedProcedures.aspx" target="MainFrame"><b>Stored Procedures</b></a>
						</td></tr>
						<tr><td>
							&nbsp;
						</td><td>
							&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
							<a href="editText.aspx?Type=SP" target="MainFrame">
								<i>New Procedure...</i></a>
						</td></tr>
		
				<!--ENUMERATE STORED PROCEDURES-->
						<% for Y = 0 to Database.StoredProcedures.Count - 1 %> 
									<tr><td>
										&nbsp;
									</td><td NOWRAP>
										&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
										<a href="editText.aspx?Type=SP&SP=<%= Database.StoredProcedures(Y).ObjectName %>" target="MainFrame" class="ItemLink">
											<%= Database.StoredProcedures(Y).ObjectName %>
									</a>
						<% Next %>	
						
						
							
		<!-- USERS -->				
						<tr><td>
							&nbsp;
						</td><td>
							<img src="images/small_Icons_Users.gif" ALIGN="ABSMIDDLE">
							&nbsp;<a href="users.aspx" target="MainFrame">Users</a>
						</td></tr>
						
		<!-- ROLES --->				
						<tr><td>
							&nbsp;
						</td><td>
							<img src="images/small_Icons_Roles.gif" ALIGN="ABSMIDDLE">
							&nbsp;<a href="databaseRoles.aspx" target="MainFrame">Roles</a>
						</td></tr>
						
						
<!--							
						<tr><td>
							&nbsp;
						</td><td>
							<img src="images/small_Icons_Rules.gif" ALIGN="ABSMIDDLE">
							&nbsp;Rules
						</td></tr>
		
						<tr><td>
							&nbsp;
						</td><td>
							<img src="images/small_Icons_Defaults.gif" ALIGN="ABSMIDDLE">
							&nbsp;Defaults
						</td></tr>
						
						<tr><td>
							&nbsp;
						</td><td>
							<img src="images/small_Icons_User_Defined_Ty.gif" ALIGN="ABSMIDDLE">
							&nbsp;User Defined Data Types
						</td></tr>
						
						<tr><td>
							&nbsp;
						</td><td>
							<img src="images/small_Icons_User_Defined_Fu.gif" ALIGN="ABSMIDDLE">
							&nbsp;User Defined Functions
						</td></tr>
						
						<tr><td>
							&nbsp;
						</td><td>
							<img src="images/small_Icons_Full_Text_Catal.gif" ALIGN="ABSMIDDLE">
							&nbsp;Full-Text Catalogs
						</td></tr>
						
						<tr><td colsapn="2">
							<img src="images/spacer.gif">
						</td></tr>
-->						
						
					
						
<%		end if 
Next %>
		
		
		
		
			<tr><td width="100%" colspan="2">
				<img src="images/small_Icons_Folder.gif" align="left">
				&nbsp;Security
			</td></tr>
		
			<tr><td>		
				&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<img src="images/small_Icons_logins.gif">	
			</td><td width="100%">
			   <a href="logins.aspx" target="MainFrame">
			   	&nbsp;Logins</a>
			</td></tr>
		
			<tr><td>		
				&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<img src="images/small_Icons_ServerRoles.gif">	
			</td><td width="100%">
				<a href="ServerRoles.aspx" target="MainFrame">
			   	&nbsp;Server Roles</a>
			</td></tr>
			
			<tr><td width="100%" colspan="2">
				<img src="images/small_Icons_Folder.gif" align="left">
				&nbsp;Management
			</td></tr>
		
			<tr><td>		
				&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<img src="images/small_Icons_ProcessInfo.gif">	
			</td><td width="100%">
			   <a href="processInfo.aspx" target="MainFrame">
			   	&nbsp;Process Info</a>
			</td></tr>
		
		
		</table>
