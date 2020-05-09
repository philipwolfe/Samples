<!--#include file="includes/stylesheet.aspx"-->
<%@ Import Namespace="System.Collections" %>
<%@ Import Namespace="System.Data.SQLClient" %>

<%
		
		Dim Con as SQLConnection = New SQLConnection(ConnectionString.Value)
		Con.Open()
		Dim cmd as SQLCommand 
		Dim DR as SQLDataReader
		Dim X as Integer
		Dim First as Boolean
		Dim sqlstmt as String
		cmd = New SQLCommand("SP_Columns '" & request("table") & "'", Con)
		dr = cmd.ExecuteReader()
		Dim TypeTable as New Hashtable()
		While dr.read()
			TypeTable.Add(dr("Column_Name"), dr("Type_Name"))
		End While
		DR.Close()
		
		if request("sqlstmt") <> "" then
			sqlstmt = request("sqlstmt")
		elseif request("Table") <> "" then
			sqlstmt = "Select Top 1000 * from [" & request("table") & "]"
		end if
		


	%>
	
	<center>
	<%	AppInterface.DrawWindowHeader ("Query", "tables.aspx", "100%") %>	
	
				<form action="query.aspx" method="post">
				<table cellpadding="3" cellspacing="0" width="100%">
					<tr><td >
						<table width="100%">
						<tr><td>
							<img src="images/large_icons_query.gif" align="left">
						</td><td align="right">
							<input type="submit" value="Run Query">
						</td></tr>
						</table>
						
						<img src="images/spacer.gif" height="90" width="1" align="right">
						<img src="images/spacer.gif" height="90" width="1" align="left">
						<textarea style="width:100%; height:70;" name="sqlstmt"><%= sqlstmt %></textarea>
						
					</td></tr>
					</table>
				</form>
		
	
<% AppInterface.DrawWindowFooter() %>		
<br><Br>					
</center>	
		
		
<%

	Try	
		if sqlstmt <> "" then	
				cmd = New SQLCommand (sqlstmt, con)
				dr = cmd.ExecuteReader()
				
				With Response
					.write ("<table class=""InputBorder"" cellspacing=""0"" cellpadding=""3"">")
					
				
						First = True
						while dr.read()
							if First then
								.write ("<tr>")
									For X = 0 to dr.FieldCount - 1
										.write ("<td class=""TableHeader"">" & dr.GetName(X) & "</td>")
											
									Next	
								.write ("</tr>")
								First = False
							end if
							.write ("<tr>")
								For X = 0 to dr.FieldCount - 1
									if TypeTable(dr.GetName(x)) = "text" then
										.write ("<td valign=""top"" NOWRAP class=""TableGrid"">&lt; &nbsp; long text &nbsp; &gt;</td>")
									else	
										.write ("<td valign=""top"" NOWRAP class=""TableGrid"">" & Replace(dr.Item(x).ToString, "<",  "&lt;") & "&nbsp;</td>")
									end if	
								Next	
							.write ("</tr>")
						end while
					   .write ("</table><br>")
						While dr.NextResult()
							.write ("<table class=""InputBorder"" cellspacing=""0"" cellpadding=""3"">")
							First = True
							while dr.read()
								if First then
									.write ("<tr>")
										For X = 0 to dr.FieldCount - 1
											.write ("<td class=""TableHeader"">" & dr.GetName(X) & "</td>")
												
										Next	
									.write ("</tr>")
									First = False
								end if
								.write ("<tr>")
									For X = 0 to dr.FieldCount - 1
										if TypeTable(dr.GetName(x)) = "text" then
											.write ("<td valign=""top"" NOWRAP class=""TableGrid"">&lt; &nbsp; long text &nbsp; &gt;</td>")
										else	
											.write ("<td valign=""top"" NOWRAP class=""TableGrid"">" & Replace(dr.Item(x).ToString, "<",  "&lt;") & "&nbsp;</td>")
										end if	
									Next	
								.write ("</tr>")
							end while
							.write ("</table><br>")
						End While
					
					
				End With
			End if			
				
		Catch e as Exception
			
		Finally
		
		dr.close
		con.close	
		dr = nothing
		con = Nothing
		cmd = Nothing
		
		End Try
		

%>
