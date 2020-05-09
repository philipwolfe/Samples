Imports System.Web
Imports System.Data
Imports System.Collections
Imports ASPEnterpriseManager
Imports Microsoft.VisualBasic
Imports System.Data.SQLClient

Namespace ASPEnterpriseManager

' ************************************* EXTENDED LOGIN CLASS *********************************************
	Public Class ExtendedLogin
		Inherits Login
		Dim _ServerRoles as HashTable
		
		Public Sub New()
			_ServerRoles = New HashTable
		End Sub
		
		
		Public ReadOnly Property ServerRoles as HashTable
			Get
				Return(_ServerRoles)
			End Get
		End Property
		
		Public Sub Load (LoginName as String)
			Dim _Context as HTTPContext = HTTPContext.Current
			Dim ServerRoles as ArrayList = New ArrayList
			Dim SysInfo as ASPEnterpriseManager.SystemInformation = New ASPEnterpriseManager.SystemInformation
			Dim X as Integer
			Dim Con as SQLConnection = New SQLConnection(_Context.Session.StaticObjects("ConnectionString").Value)
			Dim DR as SqlDataReader
			Con.Open()
			Dim cmd as SQLCommand = New SQLCommand("sp_helplogins '" & LoginName & "'", Con)
			DR = cmd.ExecuteReader()
			Me.Name = LoginName	
			If DR.Read()
				Me.DefaultDB = IIf(IsDBNull(dr("DefDBName")), "", dr("DefDBName")) 
				Me.DefaultLanguage = iif(IsDBNull(dr("DefLangName")), "", dr("DefLangName"))
			End If
			DR.Close()			
			
			ServerRoles = SysInfo.ServerRoles				
			
			For X = 0 to ServerRoles.Count - 1 
				cmd = New SqlCommand("sp_helpsrvrolemember '" & ServerRoles(X).ObjectValue & "'", Con)
				dr = cmd.ExecuteReader()
				While dr.read()
					if dr("MemberName") = LoginName then
					 	_ServerRoles.Add (dr("ServerRole"), "")
					 	Exit While
					End If
				End While
				dr.Close()
			Next
			Con.Close() 
			cmd = Nothing 
			dr = nothing
			con = nothing
		End Sub
		
		Public Sub ChangePassword (OldPassword as String, NewPassword as String)
			Dim _Context as HTTPContext = HTTPContext.Current
			Dim Con as SQLConnection = New SQLConnection(_Context.Session.StaticObjects("ConnectionString").Value)
			Con.Open()
			Dim cmd as SQLCommand = New SQLCommand("sp_password '" & OldPassword & "', '" & NewPassword & "', '" & Me.Name & "'", Con)
			Cmd.ExecuteNonQuery()
			cmd = Nothing
			Con.Close()
			Con = Nothing
		End Sub
		
		Public Sub Create (Name as String, Password as String, DefDB as String, DefLang as String, ServerRoles as HashTable)
			Dim S as String
			Dim sqlstmt as String
			Dim _Context as HTTPContext = HTTPContext.Current
			Dim Con as SQLConnection = New SQLConnection(_Context.Session.StaticObjects("ConnectionString").Value)
			Con.Open()
			sqlStmt = "sp_addlogin '" & Name & "', '" & Password & "', '" & DefDB & "'"
			if DefLang <> "" then _
					sqlstmt = sqlstmt & ", '" & DefLang & "'"
			Dim cmd as SQLCommand = New SQLCommand(sqlStmt, Con)
			cmd.ExecuteNonQuery
			For Each S in ServerRoles.Keys
				cmd  = New SQLCommand("sp_addsrvrolemember '" & Name & "', '" & S & "'", Con)
				cmd.ExecuteNonQuery()
			Next
			Me.Name = Name
			Me.DefaultDB = DefDB
			Me.DefaultLanguage = DefLang
			_ServerRoles = ServerRoles
			Con.Close()
			Cmd = Nothing
			Con = Nothing
		End Sub
	
	
		Public Sub Update (DefDB as String, DefLang as String, ServerRoles as HashTable)
			Dim X as Integer
			Dim _Context as HTTPContext = HTTPContext.Current
			Dim Con as SQLConnection = New SQLConnection(_Context.Session.StaticObjects("ConnectionString").Value)
			Dim SysInfo as ASPEnterpriseManager.SystemInformation = New ASPEnterpriseManager.SystemInformation
			Con.Open()
			Dim cmd as SQLCommand
			For X = 0 to SysInfo.ServerRoles.Count - 1
				if ServerRoles.ContainsKey(SysInfo.ServerRoles(X).ObjectValue) Then
					cmd  = New SQLCommand("sp_addsrvrolemember '" & Me.Name & "', '" & SysInfo.ServerRoles(X).ObjectValue & "'", Con)
					cmd.ExecuteNonQuery()
				Else
					cmd  = New SQLCommand("sp_dropsrvrolemember '" & Me.Name & "', '" & SysInfo.ServerRoles(X).ObjectValue & "'", Con)
					cmd.ExecuteNonQuery()	
				end if
			Next
			If DefDB <> Me.DefaultDB Then
				cmd  = New SQLCommand("sp_defaultdb '" & Me.Name & "', '" & DefDB & "'", Con)
				cmd.ExecuteNonQuery()
			End If
			If DefLang <> Me.DefaultLanguage Then
				cmd  = New SQLCommand("sp_defaultlanguage '" & Me.Name & "', '" & DefLang & "'", Con)
				cmd.ExecuteNonQuery()
			End If
			Me.DefaultDB = DefDB
			Me.DefaultLanguage = DefLang
			_ServerRoles = ServerRoles
			Con.Close()
			cmd = Nothing
			Con = Nothing
		End Sub
	End Class


' ************************************* BASE LOGIN CLASS **************************************************		
	Public Class Login 
		Dim _Name as String
		Dim _DefaultDB as String
		Dim _DefaultLanguage as String
		
		Public Property Name As String
			Get
				Return(_Name)
			End Get
			Set
				_Name = value
			End Set
		End Property
		
		Public Property DefaultDB As String
			Get
				Return(_DefaultDB)
			End Get
			Set
				If value = "" Then value = "master"
				_DefaultDB = value
			End Set
		End Property
		
		Public Property DefaultLanguage As String
			Get
				Return(_DefaultLanguage)
			End Get
			Set
				_DefaultLanguage = value
			End Set
		End Property
	
	End Class


' ************************************* LOGINS COLLECTION CLASS ***********************************************
	Public Class Logins
		Dim _Logins as ArrayList
		
		Public Sub New()
			_Logins = New ArrayList
		End Sub
		
		Public ReadOnly Property List as ArrayList
			Get
				Return(_Logins)
			End Get
		End Property
		
		Public Sub Load()
			Dim _Context as HTTPContext = HTTPContext.Current
			Dim Con as SQLConnection = New SQLConnection(_Context.Session.StaticObjects("ConnectionString").Value)
			Dim DR as SqlDataReader
			Con.Open()
			Dim cmd as SQLCommand = New SQLCommand("sp_helplogins", con)
			DR = cmd.ExecuteReader()
			Dim Login as ASPEnterpriseManager.Login
			While DR.Read
				Login = New ASPEnterpriseManager.Login
				Login.Name = IIf(IsDBNull(dr("LoginName")), "", dr("LoginName"))
				Login.DefaultDB = IIf(IsDBNull(dr("DefDBName")), "", dr("DefDBName"))
				Login.DefaultLanguage = IIf(IsDBNull(dr("DefLangName")), "", dr("DefLangName"))
				_Logins.Add(Login)
			End While
			DR.Close()
			cmd = nothing
			dr = nothing
			con.close()
			con = Nothing
		End Sub
	End Class

End NameSpace