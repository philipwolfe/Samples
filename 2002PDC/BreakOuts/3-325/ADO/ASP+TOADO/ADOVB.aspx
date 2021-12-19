<%@ Import Namespace="ADODB"%>
<%@ Assembly Name = "ADODB"%>
<%@ Page Language="VB"%>

<html>
<head>
	<TITLE>ADO Access from ASPPlus page using VB</TITLE>
<body BGCOLOR="silver" topmargin="10" leftmargin="10"> 
<font size="4" face="Arial, Helvetica">
This page imports the unmanaged ADO.dll    
 

<%
 
	dim cn as ADODB.Connection
    dim rs as ADODB.Recordset
	dim cmm as ADODB.Command 
	dim strConn as String

	try
			
		strConn = "DRIVER={SQL Server};SERVER=(local);UID=sa;PWD=;DATABASE=pubs;"
		cn = new ADODB.Connection
		cn.Open (strConn)
	catch connErr as Exception 		
			response.Write("Opening Connection Failed")
	end try

	rs=new ADODB.Recordset

	rs.CursorType=ADODB.CursorTypeEnum.adOpenKeyset
	rs.LockType= ADODB.LockTypeEnum.adLockOptimistic
	rs.Open ("titles",cn,,, ADODB.CommandTypeEnum.adCmdTable)

	If (rs.BOF OR rs.EOF) Then 
		Response.Write("No records found") 
	End If


Page.DataBind()
%>	
<br>
	
<BR>

	<% dim fld as ADODB.Field
	
	Response.Write("Enumerate trough the fields collection of the SQL database table")%><br><%
	
	%><font size="2" face="Arial, Helvetica"><%
	
	If (rs.EOF)
		rs.MoveFirst
	End	If%>
		<font size="4" face="Arial, Helvetica">
		
		<table border=1 cols=<%=rs.Fields.Count%>
		<tr>
		<%	For Each fld in rs.Fields %>
			<TH><% = fld.Name %></TH>
		<% Next %>
		</tr>		
      		
    	
	<%  Do While Not rs.EOF %>

	<tr>
	<% For each fld In rs.Fields %>
		<TD ALIGN=right>
		<% 
		If fld.Value=Null Then
			Response.Write ("&nbsp;")
		Else 
			Response.Write(fld.Value)
		End IF %>
		</TD>
	<%	Next
			
	 rs.MoveNext %>
	</TR><%
	Loop %>

	</table>
	
	<%  
	
	rs.MoveFirst

			rs.Update("Title", "Inside DirectX")
			rs.Update("Type", "Business")
			rs.Update("ytd_sales", 1705)
			rs.UpdateBatch(ADODB.AffectEnum.adAffectCurrent)
' adding a new record checking types int, string, money, date
			'DateTime dt=DateTime.Now 	

			rs.MoveLast
			dim objOne(6) As Object
			dim objTwo(6) As Object
			objOne(0)="title_id"
			objOne(1)="title"
			objOne(2)="type"
			objOne(3) = "price"
			objOne(4)="ytd_sales"
			objOne(5)="pubdate"

			objTwo(0)="TZ9999"
			objTwo(1)="Programming Outlook and Exchange"   '("TZ9999","Programming Outlook and Exchange","")  
			objTwo(2)="beginners"
			objTwo(3)=19.25
			objTwo(4)=9999
				dim dt as Object
			dt=Now
			objTwo(5)=dt
					
		rs.AddNew (objOne,objTwo)
		
	
	rs.MoveFirst		
	%>

	Records in the table after updating and adding a new record
   <table border=1 cols=<%=rs.Fields.Count%>
		<tr>
		<%	For Each fld in rs.Fields %>
			<TH><% = fld.Name %></TH>
		<% Next %>
		</tr>		
      		
    	
	<%  Do While Not rs.EOF %>

	<tr>
	<% For each fld In rs.Fields %>
		<TD ALIGN=right>
		<% 
		If fld.Value=Null Then
			Response.Write ("&nbsp;")
		Else 
			Response.Write(fld.Value)
		End IF %>
		</TD>
	<%	Next
			
	 rs.MoveNext %>
	</TR><%
	Loop %>

	</table>
<%
	' Change back the records back to initial status
	' Update the records back to their values. 	
	rs.MoveFirst

	rs.Update("title","But is It User Friendly?")
	rs.Update("Type","popular_comp")
	rs.Update("ytd_sales","8790")
	rs.UpdateBatch(ADODB.AffectEnum.adAffectCurrent)
	rs.MoveFirst
	
	cn.Execute(" delete from titles where title like 'Programming Outlook and Exchange'")
	rs.Close
	cn.Close
	 %>

	</BODY>

  
</html>

