<%@ LANGUAGE = "VBScript" %>
<!--METADATA TYPE="System.Data"
			FILE="c:\inetpub\wwwroot\System.Data.tlb"-->	
	
<HTML>
    <HEAD>
        <TITLE> Managed ADO Query</TITLE>
    
	

<!--script language="VBScript" runat=server--> 
<%
		dim MyTable 
		dim ds
		dim cn	
		dim myCommand
		dim cmm
		dim QueryStr
		QueryStr="Select * from pubs"
	sub init(QueryStr)
			
			set cn=Server.CreateObject("System.Data.SQL.SQLConnection")
			cn.ConnectionString = "server=localhost;uid=sa;pwd=;database=pubs"
		
			set cmm=Server.CreateObject("System.Data.SQL.SQLCommand")
			cmm.CommandText = QueryStr
			set myCommand=Server.CreateObject("System.Data.SQL.SQLDataSetCommand")

			set ds =Server.CreateObject("System.Data.DataSet")
			set myCommand.SelectCommand=cmm
			set myCommand.SelectCommand.ActiveConnection=cn
			myCommand.SelectCommand.ActiveConnection.Open
		
			res=myCommand.FillDataSet_2(ds, "titles")
			'Response.Write(res)
			set myTable=Server.CreateObject("System.Data.DataTable") 

			set myTable=ds.Tables(0)
			
	end sub 
	
	sub updateR(UpdateStr)
			set cn=Server.CreateObject("System.Data.SQL.SQLConnection")
			cn.ConnectionString = "server=localhost;uid=sa;pwd=;database=pubs"
			set cmm=Server.CreateObject("System.Data.SQL.SQLCommand")
			cmm.CommandText=UpdateStr
			set cmm.ActiveConnection=cn
			cmm.ActiveConnection.Open
			cmm.Execute
	end sub
	
	sub close()

		cn.close
		myTable.Dispose
		ds.Dispose

	end sub

%>	

</HEAD>
		
<BODY> 
			<font size="4" face="Arial, Helvetica">
		
			<hr size="1" color="#000000">
    
			<hr size="1" color="#000000">
	This page uses the ADO+ functionality imported as System.Data.TLB
		
			<%
			
			QueryStr="Select * from titles"
			 init(QueryStr) %>
			
			<table colspan=3 cellpadding=5 border=7>
			Initial records in the SQL table titles	
			
				
				<tr> <% for K=0 to myTable.Columns.Count-1 
				%><TH> <% =myTable.Columns(K).ToString %> </TH>
				<% 
				Next %></tr> 

					<dt><tr>
					<% for I=0 To myTable.Rows.Count-1 
					%><tr><TD><%
						for J=0 To myTable.Columns.Count-1 %>
						<% = myTable.Rows(I)(J) %><TD>						
					<%	Next%></td></tr>
					<% Next
					close()
					%></TD>
					</dt>
					</table>


<% 
	uStr = "Update titles set title ='A Good News',type='business',ytd_sales=2000 where title like 'Life Without Fear'"

	
	
	addNew="insert into titles"& "("&"title_id,title,type,pub_id,price,ytd_sales,notes"&")"& _
	" values('BU9999','Come with us to the Moon','popular','1389',19.25,'2222'," & _
	"'How to prepare for your travel adventure')"  
			updateR(uStr)
			updateR(addnew)
			close()
			init(QueryStr)
%>	
		Updating a record with an UpdateCommand: changing the title from 'Life Without Fear' to "A Good News" and ytd_sales and type 
		<br>
		Adding a new record with title 'Come with us to the Moon' 
		
				<table colspan=3 cellpadding=5 border=7>
					
					<dt><tr>
					<tr> <% for K=0 to myTable.Columns.Count-1 
				%><TH> <% =myTable.Columns(K).ToString %> </TH>
				<% 
				Next %></tr> 


					<% for I=0 To myTable.Rows.Count-1 
					%><tr><TD><%
						for J=0 To myTable.Columns.Count-1 %>
						<% = myTable.Rows(I)(J) %><TD>						
					<%	Next%></td></tr>
					<% Next 
					close()
					 
  UpdateStr = "Update titles set title ='Life Without Fear',type='psychology', ytd_sales='111' where title like 'A Good News'+'%'"  
  delStr="delete from titles where title like 'Come with us to the Moon'" 
  updateR(UpdateStr)
  updateR(delStr)
cn.Close

%></TD>
					</dt>
					</table>

					


</body>
<html>		
