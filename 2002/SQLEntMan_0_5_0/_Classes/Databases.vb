Imports System.Web
Imports System.Data
Imports System.Collections
Imports Microsoft.VisualBasic
Imports System.Data.SQLClient


Namespace ASPEnterpriseManager	


' *************************************** DATABASE INFO CLASS *************************************************	
	Public Class DatabaseInfo
		Private _Owner as String
		Private _DateCreated as String
		Private _DatabaseSize as String
		Private _MaximumSize as String
		Private _FileSize as String
	
		Public ReadOnly Property Owner as String
			Get
				Return(_Owner)
			End Get
		End Property
		
		Public ReadOnly Property DateCreated as String
			Get
				Return(_DateCreated)
			End Get
		End Property
		
		Public ReadOnly Property DatabaseSize as String
			Get
				Return(_DatabaseSize)
			End Get
		End Property
		
		Public ReadOnly Property MaximumSize as String
			Get
				Return(_MaximumSize)
			End Get
		End Property
		
		Public ReadOnly Property FileSize as String
			Get
				Return(_FileSize)
			End Get
		End Property
	
		Public Sub Load (Name as String)
			Dim _Context as HTTPContext = HTTPContext.Current
			Dim SQLStmt as String = "sp_helpdb [" & Name & "]"
			Dim Con as SQLConnection = New SQLConnection(_Context.Session.StaticObjects("ConnectionString").Value)
			Con.Open()
			Dim cmd as SQLCommand = New SQLCommand(SQLStmt, Con)
			Dim DR as SQLDataReader
			DR = cmd.ExecuteReader()
			If DR.Read()
				_Owner = dr("Owner")
				_DateCreated = dr("Created")
				_DatabaseSize = dr("db_size")
				
				dr.NextResult()
				dr.read()
				_MaximumSize = dr("MaxSize")
				_FileSize = dr("size")
			End If
			DR.Close
			Con.Close
			DR = Nothing
			Con = Nothing
			cmd = Nothing
		End Sub
	
	End Class
	
	'******************************** DATABASE CLASS **********************************************

	Public Class Database
		Dim _Tables as ArrayList
		Dim _Views as ArrayList
		Dim _StoredProcedures as ArrayList
		Dim SystemInformation as New SystemInformation
		Dim SysObjects as ObjectTypes
		Dim DBObject as DatabaseObject
		
		Public Sub New()
			_Tables = New ArrayList
			_Views = New ArrayList
			_StoredProcedures = New ArrayList
		End Sub
		
		Public ReadOnly Property Tables as ArrayList
			Get
				Return(_Tables)
			End Get
		End Property
		
		Public ReadOnly Property Views as ArrayList
			Get
				Return(_Views)
			End Get
		End Property
		 
		Public ReadOnly Property StoredProcedures as ArrayList
			Get
				Return(_StoredProcedures)
			End Get
		End Property
		
		
		
		Public Sub Create (Name as String)
			Dim _Context as HTTPContext = HTTPContext.Current
			Dim SQLStmt as String = "CREATE DATABASE [" & Name & "]"
			Dim Con as SQLConnection = New SQLConnection(_Context.Session.StaticObjects("ConnectionString").Value)
			Con.Open()
			Dim cmd as SQLCommand = New SQLCommand(SQLStmt, Con)
			cmd.ExecuteNonQuery()
			_Context.Session.StaticObjects("ConnectionString").InitialCatalog = Name
			cmd = nothing
			con.close()
			con = nothing
		End Sub
		
		
		
		Public Sub DropTable (Name as String)
			Dim X as Integer
			Dim _Context as HTTPContext = HTTPContext.Current
			Dim SQLStmt as String = "DROP TABLE [" & Name & "]"
			Dim Con as SQLConnection = New SQLConnection(_Context.Session.StaticObjects("ConnectionString").Value)
			Con.Open()
			Dim cmd as SQLCommand = New SQLCommand(SQLStmt, Con)
			cmd.ExecuteNonQuery()
			For X = 0 to _Tables.Count - 1
				If _Tables(X).ObjectName = Name Then
					_Tables.RemoveAt(x)
					Exit For
				End If
			Next 
			_Context.Response.redirect ("tables.aspx?Sync=True")
			cmd = Nothing
			Con.Close()
			Con = Nothing
		End Sub
			
		
		Public Sub LoadObjects ()
			Dim _Context as HTTPContext = HTTPContext.Current
			Dim Con as SQLConnection = New SQLConnection(_Context.Session.StaticObjects("ConnectionString").Value)
			Dim DR as SqlDataReader
			Con.Open()
			Dim cmd as SQLCommand = New SQLCommand("sp_tables", con)
			DR = cmd.ExecuteReader()
			
			' Load Tables and Views
			While DR.Read()
				If dr("Table_Type") <> "SYSTEM TABLE" and dr("Table_Owner") <> "INFORMATION_SCHEMA" and not SystemInformation.Objects.ContainsKey(dr("Table_Name").toLower) Then
					DBObject = New DatabaseObject
					DBObject.ObjectOwner = dr("TABLE_OWNER")
					If dr("Table_Type") = "VIEW" Then
						DBObject.ObjectName = dr("Table_Name")
						DBObject.ObjectType = SysObjects.View
						_Views.Add (DBObject)
					Else
						DBObject.ObjectName = dr("Table_Name")
						DBObject.ObjectType = SysObjects.Table
						_Tables.Add (DBObject)
					End If
				End If
			End While			
			DR.Close()
			Dim ProcedureName as String
			Dim ShowProcedure as Boolean
			cmd = New SQLCommand("sp_stored_procedures", con)
			DR = cmd.ExecuteReader()			
			' Load Stored Procedures
			While DR.Read()
				ProcedureName = dr("Procedure_Name").SubString(0, dr("Procedure_Name").IndexOf(";"))
				' Do not display the 30 stored procedures that are generated when creating a view using the visual tools of Microsoft Enterprise Manager Software
				' all start with dt_
				ShowProcedure = False
				if ProcedureName.Length > 3 then
					if ProcedureName.SubString(0, 3) <> "dt_" then
						ShowProcedure = True
					end if
				else
					ShowProcedure = True
				end If
				If ShowProcedure Then						
						DBObject = New Databaseobject
						DBObject.ObjectName = ProcedureName
						DBObject.ObjectOwner = dr("Procedure_Owner")
						DBObject.ObjectType = SysObjects.StoredProcedure
						_StoredProcedures.Add (DBObject)	
				End If
			End While
			DR.Close()
			cmd = Nothing
			DR = Nothing
			Con.Close()
			Con = Nothing
		End Sub
		
	
	End Class

'********************************* DATABASE OBJECT CLASS ************************************************

	Public Class DatabaseObject
		Dim _ObjectName as String
		Dim _ObjectOwner as String
		Dim _ObjectType as ObjectTypes
		
		Public Property ObjectName As String
			Get
				Return(_ObjectName)
			End Get
			Set
				_ObjectName = value
			End Set
		End Property
		
		Public Property ObjectOwner As String
			Get
				Return(_ObjectOwner)
			End Get
			Set
				_ObjectOwner = value
			End Set
		End Property
		
		
		Public Property ObjectType As ObjectTypes
			Get
				Return(_ObjectType)
			End Get
			Set
				_ObjectType = value
			End Set
		End Property
		
	End Class

End Namespace	