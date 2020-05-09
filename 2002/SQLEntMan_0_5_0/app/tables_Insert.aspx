<!--#include file="includes/stylesheet.aspx"-->
<%@ Import Namespace="System.Data.SQLClient" %>

<%

Dim Con as SQLConnection = New SQLConnection(ConnectionString.Value)
Con.Open()
Dim cmd as SQLCommand 
Dim DR as SQLDataReader

if request("save") <> "" then
	Dim x as Integer
	Dim Fields as String
	Dim Values as String
	
	
	
	For x = 1 to Request("FieldCount")
		
		if Request("Value_" & x) <> "" then
			Fields = Fields & Request("Name_" & x) & ", "
			
			'Select Case Request("Type_" & X)
				'case "decimal", "numeric", "float", "real", "bigint", "int", "smallint", "tinyint", "money", "smallmoney", "bit":
				'		Values = Values & Request("Value_" & x) & ", "
				'case else:
				
						Values = Values & "'" & Request("Value_" & x) & "', "
			
			'End Select
			
			
		End If	
	Next
	
	if Len(Values) > 2 then _
		Values = Left(Values, Len(Values) - 2)
		
	if Len(Fields) > 2 then _
		Fields = Left(Fields, Len(Fields) - 2)

	
 	cmd = New SQLCommand ("Insert Into [" & request("table") & "] (" & Fields & ") values (" & values & ")", Con)
	cmd.ExecuteNonQuery()
	
	Response.redirect("tables_properties.aspx?table=" & request("table"))

End if

%>

<%	AppInterface.DrawWindowHeader ("Inser Data", "tables_properties.aspx?table=" & request("table"), "95%") %>	

<form action="tables_Insert.aspx" method="POST">
<input type="hidden" name="save" value="true">
<input type="hidden" name="table" value="<%= Request("Table") %>">
		<table width="100%" cellpadding="3" cellspacing="0" class="TableStyle">
		<tr><td class="WindowText" style="padding: 10px;">
			<table width="100%" class="MainStyle">
			<tr><td>
				<b>Table: </b> <%= Request("Table") %>
			</td><td align="right">
				<input type="submit" value="Insert">
			</td></tr>
			</table>
			<br>
			<% Dim Count as Integer = 0 
				cmd = New SQLCommand("SP_Columns '" & request("table") & "'", Con)
				DR = Cmd.ExecuteReader()
				
				With Response
					.write ("<table class=""TableStyle"" width=""100%"">")
					.write ("<tr><td>")
					
					
					
					.write ("<table cellpadding=""0"" cellspacing=""0"" width=""100%"">")
					
					Dim typeStr as String
					Dim type as String
					Dim isIdentity as Boolean
					
					
					While dr.Read()
						Count = Count + 1
						isIdentity = iif(InStr(lcase(dr("Type_Name")), "identity") = 0, false, true)
						typeStr = lcase(dr("Type_Name"))
						typeStr = replace(typeStr, "(", "")
						typeStr = replace(typeStr, ")", "")
						if instr(typeStr, " ") then
							type = Trim(Left(typeStr, Instr(TypeStr, " ")))
						else
							type = typeStr
						end if	
					
						.write ("<tr><td class=""TableGrid"" NOWRAP style=""padding: 4px;"">")
						.write ("<b>" & dr("Column_Name") & "</b>")
						.write ("<input type=""hidden"" name=""Name_" & Count & """ value=""" & dr("Column_Name") & """>")
						.write ("<input type=""hidden"" name=""Type_" & Count & """ value=""" & type & """>")
						.write ("<br>(" & type & ")")
						.write ("</td><td width=""100%"" class=""TableGrid"">")
						if IsIdentity then
							.write ("<b>IDENTITY</b>")
							.write ("<input type=""hidden"" name=""Identity_" & Count & """ value=""true"">")
							.write ("<input type=""hidden"" class=""InsertCell"" name=""Value_" & Count & """>")
						else
							.write ("<input type=""hidden"" name=""Identity_" & Count & """ value=""false"">")
							if type="ntext" or type="text" then
								.write ("<textarea class=""InsertCell"" name=""Value_" & Count & """></textarea>")
							else
								.write ("<input type=""text"" class=""InsertCell"" name=""Value_" & Count & """>")
							end if
						end if
						.write ("</td></tr>")
					
					End While
					
					.write ("</table>")		
					
					.write ("</td></tr>")
					.write ("</table>")
		
		
				End With
			%>
		</td></tr>
		</table>
	<input type="hidden" name="FieldCount" value="<%= Count %>">
</form>

<% AppInterface.DrawWindowFooter() %>			
