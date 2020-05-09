Imports System.Web
Imports System.Data
Imports System.Collections
Imports ASPEnterpriseManager
Imports Microsoft.VisualBasic
Imports System.Data.SQLClient

Namespace ASPEnterpriseManager

 	Public Class Role 
		Private _RoleName as String
		Private _RoleID as Integer
		Private _IsAppRole as Boolean
		
		Public Property RoleName As String
			Get
				Return(_RoleName)
			End Get
			Set
				_RoleName = value
			End Set
		End Property
		
		Public Property RoleID As Integer
			Get
				Return(_RoleID)
			End Get
			Set
				_RoleID = value
			End Set
		End Property
		
		Public Property IsAppRole As Boolean
			Get
				Return(_IsAppRole)
			End Get
			Set
				_IsAppRole = value
			End Set
		End Property

	End Class


' ************************************* DATABASE ROLES ********************************************************
	Public Class Roles
		Public ReadOnly Property List as ArrayList
			Get
				Dim _List as ArrayList = New ArrayList
				Dim _Context as HTTPContext = HTTPContext.Current
				Dim Con as SQLConnection = New SQLConnection(_Context.Session.StaticObjects("ConnectionString").Value)
				Con.Open()
				Dim cmd as SQLCommand = New SQLCommand("sp_helprole", Con)
				Dim DR as SQLDataReader
				DR = Cmd.ExecuteReader()
				Dim Role as ASPEnterpriseManager.Role
				While DR.Read()
					Role = New ASPEnterpriseManager.Role
					Role.RoleName = dr("RoleName")
					Role.RoleID = dr("RoleID")
					Role.IsAppRole = dr("IsAppRole")
					_List.Add (Role)
				End While
				DR.Close()
				Con.Close()
				cmd = Nothing
				DR = Nothing
				Con = Nothing
				Return (_List)
			End Get
		End Property
	End Class

' ************************************* DATABASE EXTENDED USER OBJECT *****************************************
	Public Class ExtendedUser
		Inherits User
		Dim _Roles as ArrayList
		
		Public Sub New()
			_Roles = New ArrayList
		End Sub	
		
		Public ReadOnly Property Roles as ArrayList
			Get
				Return (_Roles)
			End Get
		End Property  
		
		Public Sub New (LoginName as String, UserName as String)
			' "sp_grantdbAccess '" & request("LoginName") & "', '" & Username & "'"
		
		End Sub
		
		
		Private Sub AddRoles (NewRoles as ArrayList)
			Dim X as Integer
			Dim _Context as HTTPContext = HTTPContext.Current
			Dim Con as SQLConnection = New SQLConnection(_Context.Session.StaticObjects("ConnectionString").Value)
			Con.Open()
			Dim cmd as SQLCommand
			'Add the New Roles
			For X = 0 to NewRoles.Count - 1
				If NewRoles(x) <> "public" and Me.UserName <> "dbo" Then
					cmd = New SQLCommand("sp_addrolemember '" & NewRoles(X) & "', '" & Me.UserName & "'", con)
					cmd.ExecuteNonQuery()
				End If
			Next
			Con.Close()
			cmd = Nothing
			Con = Nothing
		End Sub
		
		
		Public Sub Update (NewRoles as ArrayList)
			Dim X as Integer
			Dim _Context as HTTPContext = HTTPContext.Current
			Dim ARoles as ASPEnterpriseManager.Roles = New ASPEnterpriseManager.Roles
			Dim Con as SQLConnection = New SQLConnection(_Context.Session.StaticObjects("ConnectionString").Value)
			Con.Open()
			Dim Roles as ArrayList = New ArrayList
			Dim cmd as SQLCommand
			'Clear Current Roles
			Roles = ARoles.List
			For X = 0 to Roles.Count - 1
				if Roles(X).RoleName <> "public" and Me.UserName <> "dbo" Then
					cmd = New SQLCommand("sp_droprolemember '" & Roles(X).RoleName & "', '" & Me.UserName & "'", con)
					cmd.ExecuteNonQuery()
				end if
			Next
			AddRoles (NewRoles)
			Con.Close()
			cmd = nothing
			con = nothing
			Me.Load (Me.UserName)
		End Sub
		
		Public Sub Create (LoginName as String, UserName as String, NewRoles as ArrayList)
			Dim X as Integer
			Dim _Context as HTTPContext = HTTPContext.Current
			Dim Con as SQLConnection = New SQLConnection(_Context.Session.StaticObjects("ConnectionString").Value)
			Con.Open()
			Dim cmd as SQLCommand
			Username = iif (UserName = "", LoginName, UserName)
			cmd = New SQLCommand("sp_grantdbAccess '" & LoginName & "', '" & Username & "'", Con)
			cmd.ExecuteNonQuery()
			Me.UserName = Username
			Me.LoginName = LoginName
			Con.Close()
			cmd = Nothing
			Con = Nothing
			AddRoles (NewRoles)
			Me.Load (Me.Username)
		
		End Sub
		
		
		Public Sub Load (UserName as String)
			Dim X as Integer
			Dim DR as SQLDataReader
			Dim _Context as HTTPContext = HTTPContext.Current
			Dim _AvailRoles as ArrayList = New ArrayList
			Dim Roles as ASPEnterpriseManager.Roles = New ASPEnterpriseManager.Roles
			Dim Con as SQLConnection = New SQLConnection(_Context.Session.StaticObjects("ConnectionString").Value)
			Con.Open()
			Dim cmd as SQLCommand = New SQLCommand("sp_helpuser '" & UserName & "'", Con)
			dr = cmd.ExecuteReader()
			dr.read()
			Me.Username = dr("UserName")
			Me.Loginname = iif(IsDBNull(dr("LoginName")), dr("UserName"), dr("LoginName"))
			Me.DefaultDB = dr("DefDBName")
			dr.close()
			' Get the roles the user has in the database
			_AvailRoles = Roles.List
			For X = 0 to _AvailRoles.Count - 1
				cmd = New SQLCommand("sp_helpRoleMember '" & _AvailRoles(X).RoleName & "'", con)
				dr = cmd.ExecuteReader()
				While dr.Read()
					if LCase(dr("MemberName")) = LCase(Me.UserName) Then
						_Roles.Add (_AvailRoles(X).RoleName)
					 	Exit While
					End If
				End While
				dr.close()
			Next
		End Sub
		
	End Class


' ************************************* DATABASE USER OBJECT **************************************************
	Public Class User
		Dim _UserName as String
		Dim _LoginName as String
		Dim _DefaultDB as String
		
		Public Property UserName As String
			Get
				Return(_UserName)
			End Get
			Set
				_UserName = value
			End Set
		End Property
		
		Public Property LoginName As String
			Get
				Return(_LoginName)
			End Get
			Set
				_LoginName = value
			End Set
		End Property
		
		Public Property DefaultDB As String
			Get
				Return(_DefaultDB)
			End Get
			Set
				_DefaultDB = value
			End Set
		End Property
	End Class


' ************************************* DATABASE USERS COLLECTION *********************************************
	Public Class Users
		Dim _Users as ArrayList
		
		Public Sub New()
			_Users = New ArrayList
		End Sub 
		
		Public ReadOnly Property List as ArrayList
			Get
				Dim _UsersAdded as String = ""
				Dim _Context as HTTPContext = HTTPContext.Current
				Dim Con as SQLConnection = New SQLConnection(_Context.Session.StaticObjects("ConnectionString").Value)
				Dim DR as SqlDataReader
				Con.Open()
				Dim cmd as SQLCommand = New SQLCommand("sp_helpuser", con)
				DR = cmd.ExecuteReader()
				Dim User as ASPEnterpriseManager.User
				While DR.Read
					If InStr(_UsersAdded, "*" & dr("UserName") & "*") = 0 Then
						_UsersAdded = _UsersAdded & "*" & dr("UserName") & "*"
						User = New ASPEnterpriseManager.User
						User.UserName = IIf(IsDBNull(dr("UserName")), "", dr("UserName"))
						User.LoginName = IIf(IsDBNull(dr("LoginName")), "", dr("LoginName"))
						User.DefaultDB = IIf(IsDBNull(dr("DefDBName")), "", dr("DefDBName"))
						_Users.Add(User)
					End If
				End While
				DR.Close()
				cmd = nothing
				dr = nothing
				con.close()
				con = Nothing
				Return (_Users)
			End Get
		End Property
		
		Public ReadOnly Property AvailableLogins as ArrayList
			Get
				Dim X as Integer
				Dim Y as Integer
				Dim Logins as ASPEnterpriseManager.Logins = New ASPEnterpriseManager.Logins
				Dim _CurUsers as ArrayList = New ArrayList
				Dim _AvailUsers as ArrayList = New ArrayList
				Dim _Logins as ArrayList = New ArrayList
				_CurUsers = Me.List
				Logins.Load()	
				_Logins = Logins.List
				Dim Found as Boolean = False
				For X = 0 to _Logins.Count - 1
					For Y = 0 to _CurUsers.Count - 1
						If _CurUsers(Y).LoginName = _Logins(X).Name Then
							Found = true
							Exit For
						End If
					Next
					If not Found Then _AvailUsers.Add(_Logins(x).Name)
					Found = False
				Next
				Return (_AvailUsers)
			End Get
		End Property
		
		
	End Class

End NameSpace