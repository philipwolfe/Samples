Imports System.Web
Imports System.Data
Imports System.Collections
Imports Microsoft.VisualBasic
Imports System.Data.SQLClient

Namespace ASPEnterpriseManager

	Public Class DatabaseObjectPermissions
		Dim _Permissions as HashTable
		Dim _UserName as String
		
		Public Sub New ()
			_Permissions = New HashTable
		End Sub
		
		Public Property List As HashTable
			Get
				Return(_Permissions)
			End Get
			Set
				_Permissions = value
			End Set
		End Property	
		
		Public ReadOnly Property UserName As String
			Get
				Return(_UserName)
			End Get
		End Property
		
		
		Private Sub UpdatePermissions (Action as String, PType as String, Owner as String, ObjectName as String)
			Dim _Context as HTTPContext = HTTPContext.Current
			Dim Con as SQLConnection = New SQLConnection(_Context.Session.StaticObjects("ConnectionString").Value)
			Con.Open()
			Dim sqlstmt as String
			Select Case UCase(Action)
				Case "GRANT" :
						sqlstmt = "GRANT " & PType & " ON [" & Owner & "].[" & ObjectName & "] to [" & _UserName & "]"
				Case "DENY"
						sqlstmt = "DENY " & PType & " ON [" & Owner & "].[" & ObjectName & "] to [" & _UserName & "]"
				Case Else:
						sqlstmt = "REVOKE " & PType & " ON [" & Owner & "].[" & ObjectName & "] to [" & _UserName & "]"
			End Select
			_Context.Trace.Write (sqlstmt)
			 
			Dim cmd as SQLCommand = New SQLCommand(sqlstmt, Con)
			cmd.ExecuteNonQuery()
			Con.Close()
			cmd = Nothing
			Con = Nothing
		End Sub
		
		
		Public Sub Update (NewPermissions as HashTable)
			Dim _Context as HTTPContext = HTTPContext.Current
			Dim S as String
			_Context.Trace.Write ("Updating.....")
			For each s in NewPermissions.Keys
				_Context.Trace.Write (s)
				If Trim(_Permissions(s).ObjectType) = "U" or Trim(_Permissions(s).ObjectType) = "V" Then
					If NewPermissions(s).PSelect <> _Permissions(s).PSelect Then
						UpdatePermissions (NewPermissions(s).PSelect, "Select",  _Permissions(s).ObjectOwner, _Permissions(s).ObjectName)	
					End If
				
					If NewPermissions(s).PInsert <> _Permissions(s).PInsert Then
						UpdatePermissions (NewPermissions(s).PInsert, "Insert",  _Permissions(s).ObjectOwner, _Permissions(s).ObjectName)	
					End If
					
					If NewPermissions(s).PUpdate <> _Permissions(s).PUpdate Then
						UpdatePermissions (NewPermissions(s).PUpdate, "Update",  _Permissions(s).ObjectOwner, _Permissions(s).ObjectName)	
					End If
				
					If NewPermissions(s).PDelete <> _Permissions(s).PDelete Then
						UpdatePermissions (NewPermissions(s).PDelete, "Delete",  _Permissions(s).ObjectOwner, _Permissions(s).ObjectName)	
					End If
				End If
				
				If Trim(_Permissions(s).ObjectType) = "P" Then
					If NewPermissions(s).PExec <> _Permissions(s).PExec Then
						UpdatePermissions (NewPermissions(s).PExec, "Execute",  _Permissions(s).ObjectOwner, _Permissions(s).ObjectName)	
					End If
				End If
				
				If Trim(_Permissions(s).ObjectType) = "U" Then
					If NewPermissions(s).PDri <> _Permissions(s).PDri Then
						UpdatePermissions (NewPermissions(s).PDri, "References",  _Permissions(s).ObjectOwner, _Permissions(s).ObjectName)	
					End If
				End If
			Next
			
			
		
		End Sub
		
			
		
		Public Sub Load (username as String)
			_UserName = username
			Dim _Context as HTTPContext = HTTPContext.Current
			Dim Con as SQLConnection = New SQLConnection(_Context.Session.StaticObjects("ConnectionString").Value)
			Con.Open()
			Dim sqlstmt as String = "Select User_Name(uid) as UserName, Name, id, xType from sysobjects where  xtype = 'U' or xtype = 'P' or xtype = 'V' order by status"
			Dim cmd as SQLCommand = New SQLCommand(sqlstmt, Con)
			Dim DR as SQLDataReader
			dr = Cmd.ExecuteReader()
			Dim P as ASPEnterpriseManager.Permission
			While dr.read()
				P = New ASPEnterpriseManager.Permission
				P.ObjectName = dr("Name")
				P.ObjectOwner = dr("UserName")
				P.ObjectType = dr("xType")
				_Permissions.Add (P.ObjectName, P)
			End While
			dr.close()
			dr = Nothing
			cmd = Nothing
			
			sqlstmt = "Select O.name, P.action, p.ProtectType from sysprotects P, sysObjects O where O.id=P.id and User_Name(P.uid) = '" & UserName & "' order by Name ASC"
			cmd = New SQLCommand(sqlstmt, Con)
			dr = Cmd.ExecuteReader()
			Dim pType as String = ""
			While dr.read()
				If _Permissions.ContainsKey(dr("Name")) Then	
					P = New ASPEnterpriseManager.Permission
					P = _Permissions(dr("Name"))
					If Not P is Nothing Then
						pType = ""
						If dr("ProtectType") = 204 or  dr("ProtectType") = 205
							pType = "GRANT"
						else
							pType = "DENY"
						end if
						Select Case dr("Action")
							Case 26 : P.PDRI = pType
							Case 193: P.PSELECT = pType
							Case 195: P.PINSERT = pType
							Case 196: P.PDELETE = pType
							Case 197: P.PUPDATE = pType
							Case 224: P.PEXEC = pType
						End Select
					End If
				End If
			End While
			dr.close()
			con.close()
			cmd = Nothing
			dr = Nothing
			con = Nothing
		End Sub 
	
	
	
	End Class



	'******************************** PERMISSION CLASS **********************************************
	Public Class Permission	
		Dim _ObjectName as String
		Dim _ObjectOwner as String
		Dim _ObjectType as String
		Dim _Select as String
		Dim _Insert as String
		Dim _Update as String
		Dim _Delete as String
		Dim _Exec as String
		Dim _Dri as String
		
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
		
		Public Property ObjectType As String
			Get
				Return(_ObjectType)
			End Get
			Set
				_ObjectType = value
			End Set
		End Property	
		
		Public Property PSelect As String
			Get
				Return(_Select)
			End Get
			Set
				_Select = value
			End Set
		End Property	
		
		Public Property PInsert As String
			Get
				Return(_Insert)
			End Get
			Set
				_Insert = value
			End Set
		End Property
		
		Public Property PUpdate As String
			Get
				Return(_Update)
			End Get
			Set
				_Update = value
			End Set
		End Property
		
		Public Property PDelete As String
			Get
				Return(_Delete)
			End Get
			Set
				_Delete = value
			End Set
		End Property
		
		Public Property PExec As String
			Get
				Return(_Exec)
			End Get
			Set
				_Exec = value
			End Set
		End Property
		
		Public Property PDri As String
			Get
				Return(_Dri)
			End Get
			Set
				_Dri = value
			End Set
		End Property
		
	End Class

End Namespace	