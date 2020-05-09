Imports System.Web
Imports System.Data
Imports System.Collections
Imports Microsoft.VisualBasic
Imports System.Data.SQLClient


Namespace ASPEnterpriseManager	
	
	Public Class Processes
		Private _Processes as ArrayList
	
		Public Sub New()
			_Processes = New ArrayList
		End Sub
		
		Public ReadOnly Property List As ArrayList
			Get
				Return(_Processes)
			End Get
		End Property
		
		Public Sub Load()
			Dim _Context as HTTPContext = HTTPContext.Current
			Dim Con as SQLConnection = New SQLConnection(_Context.Session.StaticObjects("ConnectionString").Value)
			Dim DR as SqlDataReader
			Con.Open()
			Dim cmd as SQLCommand = New SQLCommand("sp_who2", con)
			DR = cmd.ExecuteReader()
			Dim Process as ASPEnterpriseManager.Process 
			While DR.Read()
				Process = New ASPEnterpriseManager.Process
				Process.SPID = IIf(isDBNull(dr("SPID")) , 0, dr("SPID"))
				Process.Status = IIf(isDBNull(dr("Status")), "", dr("Status"))
				Process.Login = IIf(isDBNull(dr("Login")), "", dr("Login"))
				Process.HostName = IIf(isDBNull(dr("HostName")), "", dr("HostName"))
				Process.BlockedBy = IIf(isDBNull(dr("BlkBy")), "", dr("BlkBy"))
				Process.DBName = IIf(isDBNull(dr("DBName")), "", dr("DBName"))
				Process.Command = IIf(isDBNull(dr("Command")), "", dr("Command"))
				Process.CPUTime = IIf(isDBNull(dr("CPUTime")), 0, dr("CPUTime"))
				Process.DiskIO = IIf(isDBNull(dr("DiskIO")), 0, dr("DiskIO"))
				Process.LastBatch = IIf(isDBNull(dr("LastBatch")), "", dr("Lastbatch"))
				Process.ProgramName = IIf(isDBNull(dr("ProgramName")), "", dr("ProgramName"))
				_Processes.Add (Process)
			End While 
			DR.Close()
			Con.Close()
			DR = Nothing
			Con = Nothing
			cmd = Nothing
		End Sub
	End Class
	
	
	'*********************** PROCESS CLASS ************************************
	Public Class Process
		Private _SPID as Integer
		Private _Status as String
		Private _Login as String
		Private _HostName as String
		Private _BlockedBy as String
		Private _DBName as String
		Private _Command as String
		Private _CPUTime as Integer
		Private _DiskIO as Integer
		Private _LastBatch as String
		Private _ProgramName as String
		
		
		Public Property SPID As Integer
			Get
				Return(_SPID)
			End Get
			Set
				_SPID = value
			End Set
		End Property
		
		Public Property Status As String
			Get
				Return(_Status)
			End Get
			Set
				_Status = value
			End Set
		End Property
		
		Public Property Login As String
			Get
				Return(_Login)
			End Get
			Set
				_Login = value
			End Set
		End Property
		
		Public Property HostName As String
			Get
				Return(_HostName)
			End Get
			Set
				_HostName = value
			End Set
		End Property
		
		Public Property BlockedBy As String
			Get
				Return(_BlockedBy)
			End Get
			Set
				_BlockedBy = value
			End Set
		End Property
				
		Public Property DBName As String
			Get
				Return(_DBName)
			End Get
			Set
				_DBName = value
			End Set
		End Property
	
		Public Property Command As String
			Get
				Return(_Command)
			End Get
			Set
				_Command = value
			End Set
		End Property
		
		Public Property CPUTime As Integer
			Get
				Return(_CPUTime)
			End Get
			Set
				_CPUTime = value
			End Set
		End Property
		
		Public Property DiskIO As Integer
			Get
				Return(_DiskIO)
			End Get
			Set
				_DiskIO = value
			End Set
		End Property
		
		Public Property LastBatch As String
			Get
				Return(_LastBatch)
			End Get
			Set
				_LastBatch = value
			End Set
		End Property
		
		Public Property ProgramName As String
			Get
				Return(_ProgramName)
			End Get
			Set
				_ProgramName = value
			End Set
		End Property
		
		
		
	End Class

End Namespace	