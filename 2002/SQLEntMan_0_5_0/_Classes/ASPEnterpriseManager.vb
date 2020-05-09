Imports System.Web
Imports System.Data
Imports System.Collections
Imports Microsoft.VisualBasic
Imports System.Data.SQLClient


Namespace ASPEnterpriseManager

	Public Enum ObjectTypes
		Database
	   View 
	   Table
	   StoredProcedure
	End Enum


'*************************** SYSTEM INFORMATION ********************************************
	Public Class SystemInformation
		Dim _Context as HTTPContext = HTTPContext.Current
		Dim _Objects as HashTable
		Dim SysObjects as ObjectTypes
		Dim _Types(23) as String
		
		Public Sub New()
			_Objects = New HashTable
			_Objects.Add("dtproperties", SysObjects.Table)
			
			_Objects.Add("sysalternates", SysObjects.View)
			_Objects.Add("sysconstraints", SysObjects.View)
			_Objects.Add("syssegments", SysObjects.View)
			
			_Objects.Add("model", SysObjects.Database)
			_Objects.Add("msdb", SysObjects.Database)
			_Objects.Add("tempdb", SysObjects.Database)
		End Sub
		
		
		Public ReadOnly Property DataTypes
			Get
				_Types(0) = "binary"
	         _Types(1) = "bit"
	         _Types(2) = "char" 
	         _Types(3) = "datetime"
	         _Types(4) = "decimal"
	         _Types(5) = "float"
	         _Types(6) = "image"
	         _Types(7) = "int"
	         _Types(8) = "money"
	         _Types(9) = "nchar"
	      	_Types(10) = "ntext"
	      	_Types(11) = "numeric"
	      	_Types(12) = "nvarchar"
	      	_Types(13) = "real"
	      	_Types(14) = "smalldatetime"
	      	_Types(15) = "smallint"
	      	_Types(16) = "smallmoney"
	      	_Types(17) = "text"
	      	_Types(18) = "timestamp"
	      	_Types(19) = "tinyint"
	      	_Types(20) = "uniqueidentifier"
	      	_Types(21) = "varbinary"
	      	_Types(22) = "varchar" 
				Return(_Types)
			End Get
		End Property
		
		
		Public ReadOnly Property Objects as HashTable
			Get
				Return(_Objects)
			End Get
		End Property
		
		
		Public ReadOnly Property ServerRoles as ArrayList
			Get
				Dim _SR as ArrayList = New ArrayList
				Dim Con as SQLConnection = New SQLConnection(_Context.Session.StaticObjects("ConnectionString").Value)				
				Dim cmd as SQLCommand
				Dim DR as SQLDataReader
				Dim SysObject as SystemObject
				Con.Open()
				cmd = New SQLCommand("sp_helpsrvrole", Con)
				DR = cmd.ExecuteReader()				
				While DR.Read()
					SysObject = New SystemObject
					SysObject.ObjectName = DR("Description")
					SysObject.ObjectValue = DR("ServerRole")
					_SR.Add(SysObject)
				End While
				DR.Close()
				Con.Close
				Cmd = Nothing
				DR = Nothing
				Con = Nothing
				Return (_SR)
			End Get
		End Property
		
		
		Public ReadOnly Property Languages as ArrayList
			Get
				Dim _Lang as ArrayList = New ArrayList
				Dim Con as SQLConnection = New SQLConnection(_Context.Session.StaticObjects("ConnectionString").Value)				
				Dim cmd as SQLCommand
				Dim DR as SQLDataReader
				Dim SysObject as SystemObject
				Con.Open()
				cmd = New SQLCommand("sp_helpLanguage", Con)
				DR = cmd.ExecuteReader()				
				While DR.Read()
					SysObject = New SystemObject
					SysObject.ObjectName = DR("Alias")
					SysObject.ObjectValue = DR("Name")
					_Lang.Add(SysObject)
				End While
				DR.Close()
				Con.Close
				Cmd = Nothing
				DR = Nothing
				Con = Nothing
				Return (_Lang)
			End Get
		End Property
	End Class

' *********************************** SERVER ROLES ****************************************
	Public Class ServerRoles
		Dim _Roles as ArrayList
		
		Public Sub New()
			_Roles = New ArrayList
		End Sub
		
		Public ReadOnly Property List as ArrayList
			Get
				Return(_roles)
			End Get
		End Property
			
		Public Sub Load()	
			Dim _Context as HTTPContext = HTTPContext.Current
			Dim Con as SQLConnection = New SQLConnection(_Context.Session.StaticObjects("ConnectionString").Value)				
			Dim cmd as SQLCommand
			Dim DR as SQLDataReader
			Dim SysObject as SystemObject
			Con.Open()
			cmd = New SQLCommand("sp_helpsrvrole", Con)
			DR = cmd.ExecuteReader()	
			While DR.Read()
				SysObject = New SystemObject
				SysObject.ObjectName = dr("ServerRole")
				SysObject.ObjectValue = dr("Description")
				_Roles.Add (SysObject)	
			End While
			DR.Close()
			Con.Close
			DR = Nothing
			Con = Nothing
			cmd = nothing
		End Sub
		

	End Class
	
' *********************************** SYSTEM OBJECT PAIRS *********************************	
	Public Class SystemObject
		Dim _ObjectName as String
		Dim _ObjectValue as String
		
		Public Property ObjectName As String
			Get
				Return(_ObjectName)
			End Get
			Set
				_ObjectName = value
			End Set
		End Property
		
		Public Property ObjectValue As String
			Get
				Return(_ObjectValue)
			End Get
			Set
				_ObjectValue = value
			End Set
		End Property
		
	End Class
	
	
	
'*************************** SERVER CLASSES ***************************************************
' Loads and Stores the available Databases on the Initial Catalog setting on the Current Connection String 	
	Public Class Server
		Private _Databases as ArrayList
		
		Public ReadOnly Property Databases () as ArrayList
			Get
           Return(_Databases)
         End Get	
		End Property 
		
		Public Sub New()
			_Databases = New ArrayList
		End Sub
		
		Public Sub LoadDatabases()
			Dim _Context as HTTPContext = HTTPContext.Current
			Dim Con as SQLConnection = New SQLConnection(_Context.Session.StaticObjects("ConnectionString").Value)
			Dim DR as SqlDataReader
			Dim cmd as SQLCommand
			
			Con.Open()
			cmd = New SQLCommand("SELECT name FROM master.dbo.sysdatabases WHERE has_dbaccess(name) = 1 ORDER BY name;", con)	
			DR = cmd.ExecuteReader()
			
			While DR.Read
				_Databases.Add (DR("Name"))
			End While
			DR.Close()			
			DR = Nothing
			Con.Close()
			Con = Nothing			
		End Sub
	
	End Class


'*************************** PAGE CLASS *******************************************************
' This class is to be used for pages inside the application that require a connection string
' If there is no Connection String (the Static Object ConnectionString is declared in global.asax)
' The PageInit generates Javascript to break out of the frames used in the application and
' redirect to the connection page (connect.aspx) 	
	Public Class Page	
		Inherits System.Web.UI.Page
			Sub Page_Init (Sender as System.Object, e as System.EventArgs)
				Dim _Context as HTTPContext = HTTPContext.Current
				If _Context.Session.StaticObjects("ConnectionString").Value = "" Then
					With _Context.Response
						.write ("	<script language=""javascript"">")
						.write ("		parent.location.href = (""connect.aspx"");")
						.write ("	</script>")
						.end
					End With
				End If
				' See if the Catalog has been changed
				If _Context.Request("Catalog") <> _Context.Session.StaticObjects("ConnectionString").InitialCatalog then _
						_Context.Session.StaticObjects("ConnectionString").InitialCatalog = _Context.Request("Catalog")
			End Sub
	End Class


'***************************** XP INTERFACE CLASS *************************************************
	Public Class XPInterface
		Sub DrawTitleBar (Title as String, location as String)
			Dim _Context as HTTPContext = HTTPContext.Current
			With _Context.Response
					.write ("	<table cellpadding=""0"" cellspacing=""0"" width=""100%"">")
					.write ("	<tr><td>")
					.write ("		<img src=""images/Windows/TitleBar_Left.gif""></td>")
					.write ("	<td background=""images/windows/TitleBar_Background.gif"">")
					.write ("		<img src=""images/windows/icon_ASPEntMan.gif""></td>")
					.write ("	<td background=""images/windows/TitleBar_Background.gif"" width=""100%"">")
					.write ("		<font style=""font-family: Trebuchet MS, Arial; color: #FFFFFF; font-size: 10pt; font-weight: bold; text-shadow: #333333 1px 1px;"">")
					.write ("			&nbsp;" & Title)
					.write ("		</font>")
					.write ("	</td><td background=""images/windows/TitleBar_Background.gif""  valign=""bottom"">")	
					.write ("	   <A href=""http://sourceforge.net/projects/asp-ent-man/"" target=""_new""><IMG src=""http://sourceforge.net/sflogo.php?group_id=63363&amp;type=1"" width=""50"" height=""20""  border=""0"" alt=""SourceForge Logo""></A>") 
					.write ("	</td><td background=""images/windows/TitleBar_Background.gif"">")	
					.write ("		&nbsp;&nbsp;&nbsp;&nbsp;")
					.write ("	</td><td background=""images/windows/TitleBar_Background.gif"">")	
					.write ("		<a href=""" & location & """ ONMOUSEOUT=""document['CloseImage'].src = 'images/windows/TitleBar_CloseButton.gif';"" ONMOUSEOVER=""document['CloseImage'].src = 'images/windows/TitleBar_CloseButtonOver.gif';"">")
					.write ("		<img src=""images/windows/TitleBar_CloseButton.gif"" name=""CloseImage"" border=""0""></a></td>")
					.write ("	<td>")
					.write ("		<img src=""images/Windows/TitleBar_Right.gif""></td>")
					.write ("	</tr>")
					.write ("	</table>")	
			End With
		End Sub
			
		Sub DrawWindowHeader (Title as String, location as String, Width as String) 
			Dim _Context as HTTPContext = HTTPContext.Current
			With _Context.Response
					.write ("<table width=""" & Width & """ cellpadding=""0"" cellspacing=""0"">")
					.write ("<tr><td colspan=""3"">")
					DrawTitleBar (Title, Location)
					.write ("</td></tr>")
					.write ("<tr><td background=""images/Windows/border_Left.gif"">")
					.write ("</td><td width=""100%"" class=""WindowBackground"">")
			End With
		End Sub	
		
		Sub DrawWindowFooter ()	
			Dim _Context as HTTPContext = HTTPContext.Current
			With _Context.Response
				.write ("</td><td background=""images/Windows/border_right.gif"">")
				.write ("</td></tr>")
				.write ("<tr><td>")
				.write ("	<img src=""images/windows/border_BottomLeft.gif""></td>")
				.write ("<td background=""images/Windows/border_Bottom.gif"">")
				.write ("</td><td>")
				.write ("	<img src=""images/windows/border_BottomRight.gif""></td>")
				.write ("</tr>")
				.write ("</table>")
			End With
		End Sub
		
		Sub SyncFrames ()
			Dim _Context as HTTPContext = HTTPContext.Current
			With _Context.Response
				.write ("	<script language=""javascript"">")
				.write ("		parent.frames('LeftFrame').location.href=('Databases.aspx');")
				.write ("		parent.frames('MainFrame').location.href=('setDatabase.aspx');")
				.write ("	</script>")
				.end
			End With
		End Sub	
		
		Sub SyncLeftFrame ()
			Dim _Context as HTTPContext = HTTPContext.Current
			With _Context.Response
				.write ("	<script language=""javascript"">")
				.write ("		parent.frames('LeftFrame').location.href=('Databases.aspx');")
				.write ("	</script>")
			End With
		End Sub	
		
	End Class
	

'***************************** CONNECTION STRING ***********************************************	
	Public Class ConnectionString	
			Private _DataSource as String
			Private _InitialCatalog as String
			Private _UID as String
			Private _PWD as String
			Private _ConStr as String
	
	 		Public Property DataSource As String
	         Get
	           Return(_DataSource)
	         End get
	         Set
	         	_DataSource  = value
	         	_ConStr = "Data Source=" & _DataSource & ";Initial Catalog=" & _InitialCatalog & ";uid=" & _UID & ";pwd=" & _PWD
	          End Set
	      End Property
	      
	      Public Property InitialCatalog As String
	         Get
	           Return(_InitialCatalog)
	         End get
	         Set
	         	If value <> "" and value <> _InitialCatalog Then
	           		_InitialCatalog  = value
	           		_ConStr = "Data Source=" & _DataSource & ";Initial Catalog=" & _InitialCatalog & ";uid=" & _UID & ";pwd=" & _PWD
	           		Dim _Context as HTTPContext = HTTPContext.Current
						With _Context.Response
							.write ("	<script language=""javascript"">")
							.write ("		parent.frames('LeftFrame').location.href=('Databases.aspx');")
							.write ("		parent.frames('MainFrame').location.href=('setDatabase.aspx');")
							.write ("	</script>")
							.end
						End With
	           	End If
	         End Set
	      End Property
	      
	      Public Property UID As String
	         Get
	           Return(_UID)
	         End get
	         Set
	         	_UID  = value
           		_ConStr = "Data Source=" & _DataSource & ";Initial Catalog=" & _InitialCatalog & ";uid=" & _UID & ";pwd=" & _PWD
	         End Set
	      End Property
	      
	      Public Property PWD As String
	         Get
	           Return(_PWD)
	         End get
	         Set
	         	_PWD  = value
           		_ConStr = "Data Source=" & _DataSource & ";Initial Catalog=" & _InitialCatalog & ";uid=" & _UID & ";pwd=" & _PWD
	          End Set
	      End Property
	      
	      Public ReadOnly Property Value as String
	      	Get
	      		Return(_ConStr)
	      	End Get
	   	End Property 
	   	
	   	Sub Clear()
	   		_DataSource = ""
	   		_InitialCatalog = ""
	   		_UID = ""
	   		_PWD = ""
	   	End Sub
	End Class
End NameSpace