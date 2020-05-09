Imports System.Web
Imports System.Data
Imports System.Collections
Imports Microsoft.VisualBasic
Imports System.Data.SQLClient


Namespace ASPEnterpriseManager	
	
	'******************************** VIEW CLASS **********************************************
	Public Class View
		Dim _Value as String
		Dim _Name as String
		
		Public Property Text As String
			Get
				Return(_Value)
			End Get
			Set
				_Value = value
			End Set
		End Property
		
		Public Property Name As String
			Get
				Return(_Name)
			End Get
			Set
				_Name = value
			End Set
		End Property
		
		Sub Load (Name as String)
			Dim _Context as HTTPContext = HTTPContext.Current
			Dim Con as SQLConnection = New SQLConnection(_Context.Session.StaticObjects("ConnectionString").Value)
			Con.Open()
			Dim cmd as SQLCommand = New SQLCommand("sp_helptext """ & Name & """", Con)
			Dim DR as SQLDataReader = cmd.ExecuteReader()
			_Value = ""
			while dr.read()
				_Value = _Value & dr("text")
			End While	
			_Name = Name
			DR.Close()
			Con.Close()
			cmd = Nothing
			DR = Nothing
			Con = Nothing
		End Sub
		
		Sub Save()
			Dim _Context as HTTPContext = HTTPContext.Current
			Dim Con as SQLConnection = New SQLConnection(_Context.Session.StaticObjects("ConnectionString").Value)
			Con.Open()
			Dim cmd as SQLCommand = new SqlCommand()
			Dim Trans as SqlTransaction
			cmd.Connection = Con
			Trans = Con.BeginTransaction()
			cmd.Transaction = Trans
			If _Name <> "" Then
				cmd.CommandText = "DROP VIEW " & _Name
		      cmd.ExecuteNonQuery()
		   End If
		   cmd.CommandText = _Value
		   cmd.ExecuteNonQuery()
		   Trans.Commit()
		   Trans = Nothing
		   cmd = Nothing
		   Con.Close()
		   Con = Nothing
		End Sub
		
		
	
		
	End Class

End Namespace	