<%@ Import Namespace="ADODB"%>
<%@ Assembly Name = "ADODB"%>
<%@ PAGE LANGUAGE = "C#" %>



<html>
<head>
	<TITLE>ADO Access from ASPPlus page using C#</TITLE>
</head>
<body BGCOLOR="silver" topmargin="10" leftmargin="10"> 
<font size="4" face="Arial, Helvetica">
This page imports the unmanaged ADO.dll    

<%         	
	ADODB.Connection cn=null;
	ADODB.Recordset rs=null;
	ADODB.Command cmm = null;
	
		try
		{
			cn = new ADODB.Connection();

			
			String strConn = "DRIVER={SQL Server};SERVER=(local);UID=sa;PWD=;DATABASE=pubs;";
			cn.Open(strConn, "", "", -1);
			
		}
	catch (Exception e)
			{
			Response.Write(e.ToString());
			Response.Flush();
			Response.End();
			}
		
	
	rs= new ADODB.Recordset();
	
	// open a recordset on a table titles with cursor LockType adOpenOptimic on wich the provider locks the records when updated only
	// with CursorType adOpenKeyset to allow batch updates-->
	
	rs.Open("titles",cn,ADODB.CursorTypeEnum.adOpenKeyset,ADODB.LockTypeEnum.adLockOptimistic, (int)ADODB.CommandTypeEnum.adCmdTable);
		
	if (rs.BOF || rs.EOF) 
		{
		 Response.Write("No records found"); 
		}

		 
ADODB.Field fld=null;
//rs.MoveFirst();

%>


<table Border=1 Cols=<%=rs.Fields.Count%>>
Initial record in the Table
<tr> <% for (int ii=0;ii<rs.Fields.Count;ii++) {
%><TH> <% =((rs.Fields[ii]).Name) %> </TH>
<% 
} %></tr> 

<%
//rs.MoveFirst();
while (!rs.EOF){ 

for (int jj=0;jj<rs.Fields.Count;jj++)
	{ %> <td><%
	Response.Write((rs.Fields[jj]).Value.ToString()); %></td><%
	} %></tr> <%
	rs.MoveNext(); %> </TR> <%
	}
	rs.MoveFirst();

%>
</table>

<% 
			
			rs.Update("Title", "Inside DirectX");
			rs.Update("Type", "Business");
			rs.Update("ytd_sales", 1705);
			rs.UpdateBatch(ADODB.AffectEnum.adAffectCurrent);
// adding a new record
			DateTime dt=DateTime.Now; 	

			rs.MoveLast();
			Object[] objOne={"title_id", "title","type","price","ytd_sales","pubdate"};
			Object[] objTwo={"TZ9999","Programming Outlook and Exchange","business",19.25,9999,dt}; 
		
					
		rs.AddNew(objOne,objTwo);
		
		rs.UpdateBatch(ADODB.AffectEnum.adAffectCurrent);
		
		rs.MoveLast();
		rs.MoveFirst();


%>
<BR><BR>
<table Border=1 Cols=<%=rs.Fields.Count%>>
After updating a record and adding a new record
<BR>
<tr> <% for (int ii=0;ii<rs.Fields.Count;ii++) {
%><TH> <% =((rs.Fields[ii]).Name)%> </TH>
<%	
} %></tr> 

<%
//rs.MoveFirst();
while (!rs.EOF){ 

for (int jj=0;jj<rs.Fields.Count;jj++)
	{ %> <td><%
	Response.Write((rs.Fields[jj]).Value.ToString()); %></td><%
} %></tr> <%
	rs.MoveNext(); %> </TR> <%
	}
	rs.MoveFirst();

%>
</table>

<%	//Update the records back to their values. 	
	rs.MoveFirst();
	rs.Update("title","But is It User Friendly?");
	rs.Update("Type","popular_comp");
	rs.Update("ytd_sales","8790");
	rs.UpdateBatch(ADODB.AffectEnum.adAffectCurrent);
	rs.MoveFirst();
	Object dummy="";
	cn.Execute(" delete from titles where title like 'Programming Outlook and Exchange'",ref dummy, -1);
	rs.Close();
	cn.Close();

%>
	
	</BODY>

  
</html>

