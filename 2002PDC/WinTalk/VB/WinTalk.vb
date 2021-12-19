'==========================================================================
'  File:      wintalk.vb
'
'  Summary:   This contains the front-end logic to wintalk, and entry point.
'             This application demonstrates the use of WFC and System.Net.DLL.
'
'             Wintalk starts with a dialog that with to multi-line edit boxes
'             and two buttons (one grayed out).  In the background, it spins 
'             off a thread (ServerConnectionThread) which begins listening on 
'             TCP/IP port 5000.  When an incoming connection arrives, the 
'             ServerConnectionThread posts a message to the UI thread to 
'             un-gray the "disconnect" button, and gray out the "connect" 
'             button, and a client thread is started which receive all data
'             and sends the characters to the top edit window.  The user types 
'             in the bottom edit window to transmit to the remote end.
'
'             WFC's InvokeAsync is used to provide a thread switch from one 
'             of the "worker" threads (such as ServerConnectionThread) to 
'             the UI thread (which is started from Main, and messages pumped
'             in Application.Run).
'             
'  Classes:   Wintalk
'
'  Functions: 
'         Overrides:              Dispose
'
'         Initialization:         InitForm
'
'         Thread procedures:      ClientConnectionThreadProc, 
'                                 ServerConnectionThreadProc
'
'         Async Invoked Methods:  OnClientActive, OnClientClosed,
'                                 OnServerAccept, OnServerReject
'
'         Other:                  EnableClientConnection, 
'                                 DisableClientConnection
'			 
'         UI Event Handlers:      panel1_resize, button1_click, 
'                                 button2_click, WinTalk_activate
'
'         Entry point:            Main
'
'----------------------------------------------------------------------------
'  This file is part of the Microsoft COM+ 2.0 Samples.
'
'  Copyright (C) 1998-2000 Microsoft Corporation.  All rights reserved.
'==========================================================================+*/

Imports System
Imports System.Threading
Imports System.ComponentModel
Imports System.Core
Imports System.WinForms
Imports System.Runtime.InteropServices
Imports System.Drawing
Imports System.Net
Imports System.Net.Sockets

Imports Microsoft.VisualBasic.ControlChars

Option Explicit
Option Strict Off


Public Module ModMain

' define delegates to be used with AsyncInvoke
Public Delegate Sub AsyncInvokeDelegate
Public Delegate Sub AsyncInvokeStringDelegate(str As String)



Public Class WinTalk
Inherits Form

	protected ClientConnection As Socket = Nothing
	protected ServerConnection As Socket = Nothing
	
	public ServerPort As Integer = 5000

	protected ClientConnectionThread As Thread = Nothing
	protected ServerConnectionThread As Thread = Nothing

	protected m_ListenStr As String
	
	protected bIsInDispose As Boolean = false
	
'*****************************************************************************
' Constructor : WinTalk
'
' Abstract:     Constructs an instance of Wintalk, calls Window's default
'               contructor.
'			
' Input Parameters: port(int)
'
'******************************************************************************/
	Public Sub New(port As Integer)
		MyBase.New

		Me.ServerPort = port

		InitForm		

		' start "Listening" thread
		ServerConnectionThread = new Thread(AddressOf Me.ServerConnectionThreadProc)
		ServerConnectionThread.Start
	End Sub

'*****************************************************************************
' Function:     Dispose
'
' Abstract:     Overrides Form.Dispose, cleans up the component list.
'			
' Input Parameters: (None)
'
' Returns: void
'******************************************************************************/
	Overrides Public Sub Dispose
	
		bIsInDispose = true
		MyBase.Dispose
		components.Dispose		
		
		DisableClientConnection
		
		' Kill server thread
		Try 
			if (ServerConnection <> Nothing) Then ServerConnection.Close
		Catch Ex As Exception
			Console.WriteLine("Error while closing server connection!!!!!")
		End Try

		ServerConnection = Nothing
		
		if (ServerConnectionThread <> Nothing) Then ServerConnectionThread.Join
		ServerConnectionThread = Nothing

		if (ClientConnectionThread <> Nothing) Then ClientConnectionThread.Join
		ClientConnectionThread = Nothing
	End Sub

'*****************************************************************************
' Function:     OnClientActive
'
' Abstract:     Invoked asynchronously when a connection becomes active.
'			
' Input Parameters: (None)
'
' Returns: void
'******************************************************************************/
	Protected Sub OnClientActive
	
		button1.Enabled = false
		button2.Enabled = true
		edit2.Focus ' helps to eliminate confusion, sets focus to SendEdit
		
		Dim ep As IPEndPoint = ClientConnection.RemoteEndpoint

		Dim addr As String = DNS.InetNtoa(ep.Address)
		Dim port As Integer = ep.Port
		Dim host As String = DNS.GetHostByAddr(addr).Hostname
		Dim s As String = "Talking to " & addr & ":" & port.ToString & "(" & host & ")"
		Console.WriteLine(s)
		label1.Text = s
	End Sub

'*****************************************************************************
' Function:     OnClientClosed
'
' Abstract:     Invoked asynchronously when the active connection is closed
			
' Input Parameters: (None)

' Returns: void
'******************************************************************************/
	Protected Sub OnClientClosed
	
		edit1.Append(CrLf & "****Notice: Connection Closed****" & CrLf)
		button1.Enabled = true
		button2.Enabled = false
		label1.Text = m_ListenStr
	End Sub
	
'*****************************************************************************
' Function:     OnServerAccept
'
' Abstract:     Invoked asynchronously when an incoming connection is accepted
'               by the server thread.
'			
' Input Parameters: (None)
'
' Returns: void
'******************************************************************************/
	Protected Sub OnServerAccept
	
		edit1.Append(CrLf & "****CONNECTION ACTIVE****" & CrLf)
		WindowState = FormWindowState.Normal
		'Windows.SetForegroundWindow(Handle)
	End Sub
	
'*****************************************************************************
' Function:     OnServerReject
'
' Abstract:     Invoked asynchronously when an incoming connection is rejected
'               by the server thread.
'			
' Input Parameters: (None)
'
' Returns: void
'******************************************************************************/
	Protected Sub OnServerReject
	
		edit1.Append(CrLf & "****Warning: Incoming being rejected****" & CrLf)
	End Sub

'*****************************************************************************
' Function:     EnableClientConnection
'
' Abstract:     Called when "ClientConnection" becomes valid.  Resets UI to 
'               proper state and spins off a ClientConnectionThread thread.
'			
' Input Parameters: None
'
' Returns: Void
'******************************************************************************/
	Public Sub EnableClientConnection
	
		if (ClientConnectionThread <> Nothing) Then
			throw new ApplicationException("Client reader thread " & _
						       "(ClientConnectionThread) already " & _
						       "active!!")
		End If

		ClientConnectionThread = new Thread(AddressOf Me.ClientConnectionThreadProc)
		ClientConnectionThread.Start
		BeginInvoke(new AsyncInvokeDelegate(AddressOf Me.OnClientActive))
		edit2.SetClientConnection(ClientConnection)
	End Sub
	
'*****************************************************************************
' Function:     DisableClientConnection
'
' Abstract:     Called when "ClientConnection" becomes invalid, or actually
'               closes ClientConnection.  Resets UI to proper state and if not 
'               called from ClientConnectionThread, waits for this thread to 
'               terminate.
'			
' Input Parameters: None
'
' Returns: Void
'******************************************************************************/
	Public Sub DisableClientConnection

		Try 
			edit2.SetClientConnection(Nothing)
			SyncLock(Me)
				If (ClientConnection <> Nothing) Then

					Console.WriteLine("DisableClientConnection: " & _
							  "closing connection")
					ClientConnection.Close
					ClientConnection = Nothing
				End If
			End SyncLock
		
		Catch e As Exception
			MessageBox.Show(Me, e.Message, "Close Error")
		End Try

		if (Thread.CurrentThread.Equals(ClientConnectionThread)) Then
			ClientConnectionThread = Nothing
			if (Me.HandleCreated) Then
				BeginInvoke(new AsyncInvokeDelegate(AddressOf Me.OnClientClosed))
			End If
		else 
			if (ClientConnectionThread <> Nothing) Then
				ClientConnectionThread.Join
				ClientConnectionThread = Nothing
			End If
		End If
	End Sub

'*****************************************************************************
' Function:     ClientConnectionThreadProc
'
' Abstract:     Called when a client connection is made (click the "connect"
'               button, or incoming connection is made).  This thread is
'			   created and started from the "EnableClientConnection" method.
'			
' Input Parameters: None
'
' Returns: Void
'******************************************************************************/
	Protected Sub ClientConnectionThreadProc
	
		Console.WriteLine("ClientConnectionThreadProc thread is starting")
		Try 
			Dim c As Char = NullChar
		
			Dim ignore_next_return As Boolean = false
			Dim b(1) As Byte

			' read one character at a time from the Socket

			while ((ClientConnection <> Nothing) AND (ClientConnection.Receive(b, b.Length, 0) > 0)) 

				c = Convert.ToChar(b(0))
				If (ignore_next_return AND (c = Cr OR c = Lf)) Then
					ignore_next_return = false
				 	goto continue
				End If
				ignore_next_return = false

				if (c = Back) Then
					' backspace character causes use to truncate one char
					' off of the edit control
					edit1.BeginInvoke(new AsyncInvokeDelegate(AddressOf edit1.TruncateOneCharFromEnd))
					goto continue
				End if

				Dim str As String = Nothing

				if (c = Cr OR c = Lf) Then
					ignore_next_return = true
					' if we receive \r\n, then we only pay attention to \r
					str = Convert.ToString(CrLf)
				else 
					str = Convert.ToString(c)
				End If

				Dim o() As Object = { str }

				edit1.BeginInvoke(new AsyncInvokeStringDelegate(AddressOf edit1.Append),o)

				continue:
			End While

		Catch e As Exception 
			Console.WriteLine("Client Connection thread: " & e.ToString)
		End Try

		Console.WriteLine("Connection Closed")

		DisableClientConnection
		Console.WriteLine("ClientConnectionThreadProc thread is ending")
	End Sub
	
'*****************************************************************************
' Function:     ServerConnectionThreadProc
'
' Abstract:     Listens on "ServerPort" and creates Socket's for each incoming 
'               request.  If ClientConnection is already active, the new 
'               Socket is destroyed.
'			
' Input Parameters: None
'
' Returns: Void
'******************************************************************************/
	Protected Sub ServerConnectionThreadProc
	
		Console.WriteLine("ServerConnectionThread starting")
		Try 
			' create server socket and listen on port
			ServerConnection = new Socket(AddressFamily.AfINet,SocketType.SockStream,ProtocolType.ProtTCP)
			ServerConnection.Blocking = true
			if (ServerConnection.Bind(new IPEndPoint(IPAddress.InaddrAny,ServerPort)) <> 0) Then
				throw new ApplicationException("Unable to bind to port " & ServerPort.ToString)
			End If

			ServerConnection.Listen(-1)
			m_ListenStr = "WinTalk listening on port " & ServerPort.ToString
			Console.WriteLine(m_ListenStr)
			label1.Text = m_ListenStr
		
		Catch e As Exception 
			Console.WriteLine("Excpetion: " & e.Message)
			m_ListenStr = "Not listening on any port"
			Console.WriteLine(m_ListenStr)
			label1.Text = m_ListenStr
			Exit Sub
		End Try
		
		Try 
			while (true) 
				' accept socket requests to our listening port
				Dim s As Socket = ServerConnection.Accept
				
				SyncLock(Me)
					if (s = Nothing) Then
						throw new ApplicationException("Server connection closed")
					End If

					' if connection already active, reject
					if (ClientConnection <> Nothing) Then
						BeginInvoke(new AsyncInvokeDelegate(AddressOf Me.OnServerReject))
						Dim Str As String = "Sorry connection is being rejected...." & CrLf
						Console.WriteLine(str)

						Dim c() As char = str.ToCharArray
						Dim b(c.Length) As byte
						Dim i As Integer
						for i = 0 to c.Length-1
							b(i) = Convert.ToByte(c(i))
						Next
						s.Send(b, b.Length, 0)
						s.Close
						goto continue
					End If

					' no connection active, make the incoming one our current 
					' connection
					ClientConnection = s

					' notify user that connection has been made
					BeginInvoke(new AsyncInvokeDelegate(AddressOf Me.OnServerAccept))

					' notify UI thread that connection is active and 
					' spin off client thread to handle reads from socket
					EnableClientConnection
					continue:
				End SyncLock			
			End While
		
		catch e As Exception
			Console.WriteLine("Server Connection Thread: " & e.ToString)
			if (HandleCreated) Then
				MessageBox.Show(Me,"Server Connection: " & e.ToString,"WinTalk")
			End If
			m_ListenStr = "Not listening on any port"
			label1.Text = m_ListenStr
			if (Not bIsInDispose) Then
				Console.WriteLine("Server Connection Thread: " & e.ToString)
				MessageBox.Show("Server Connection: " & e.ToString,"WinTalk")
			End If
		End Try

		try 
			if (ServerConnection <> Nothing) Then
				ServerConnection.Close
				ServerConnection = Nothing
			End If
		
		Catch e As Exception 
			Console.WriteLine("Server Connection Thread(2): " & e.ToString)
		End Try

		Console.WriteLine("Server Connection Thread exiting")
	End Sub
		
	
'*****************************************************************************
' Function:     panel1_resize
'
' Abstract:     Invoked when the WFC panel containing the two edit fields
'               is resized.  Adjusts the edit boxes to be equal size.
'			
' Input Parameters: source(Object), e(EventArgs)
'
' Returns: Void
'******************************************************************************/
	Private Sub panel1_resize(source As Object, e As EventArgs)
	
		' Position the splitter in the center of the window
		edit1.Height = (panel1.Height - splitter1.Height) / 2
	End Sub

'*****************************************************************************
' Function:     button1_click
'
' Abstract:     Invoked when the "Connect" button is clicked.  Creates the 
'               "ConnectDialog" and enables the client connection.
'			
' Input Parameters: source(Object), e(EventArgs)
'
' Returns: Void
'******************************************************************************/
	Private Sub button1_click(source As Object, e As EventArgs)
	
		Console.WriteLine("BUTTON1 clicked!!!")
		SyncLock(Me)
			if (ClientConnection <> Nothing) Then
				Console.WriteLine("ERROR Connection already is open!!")
				'return
				Exit Sub
			End If
			Dim dlg As new ConnectDialog
			Dim ret As DialogResult = dlg.ShowDialog(Me)
			If (ret = System.WinForms.DialogResult.OK) Then
				Try 
					ClientConnection = new Socket(AddressFamily.AfINet,SocketType.SockStream,ProtocolType.ProtTCP)
					Dim host_addr As IPAddress = DNS.Resolve(dlg.host)
					if (host_addr = Nothing) then
						throw new ApplicationException("Unable to resolve host " & dlg.host)
					End If
					Dim ep As new IPEndPoint(host_addr, dlg.port)
					if (ClientConnection.Connect(ep) <> 0) Then
						throw new ApplicationException("Client connection failed")
					End If

					EnableClientConnection
				
				Catch ev As Exception
					DisableClientConnection
					MessageBox.Show(Me,ev.Message,"Connect Error")
				End Try
			End If
		End SyncLock		
	End Sub

'*****************************************************************************
' Function:     button2_click
'
' Abstract:     Invoked when the "Disconnect" button is clicked. Disables the 
'               client connection.
'			
' Input Parameters: source(Object), e(EventArgs)
'
' Returns: Void
'******************************************************************************/
	Private Sub button2_click(source As Object, e As EventArgs)
	
		Console.WriteLine("BUTTON2 clicked!!!")
		DisableClientConnection		
	End Sub

'*****************************************************************************
' Function:     WinTalk_activate
'
' Abstract:     Invoked when the Wintalk application window becomes active.
'               Sets focus to the bottom edit control (less confusion to the
'			   user as to which edit box to type in).
'			
' Input Parameters: source(Object), e(EventArgs)
'
' Returns: Void
'******************************************************************************/
	Private Sub WinTalk_activate(source As Object, e As EventArgs)
	
		edit2.Focus
	End Sub

	Public components As new Container
	Public edit2 As new SendEdit
	Public edit1 As new DataEdit
	Public button1 As new Button
	Public button2 As new Button
	Public label1 As new Label
	Public splitter1 As new Splitter
	Public panel1 As new Panel

'*****************************************************************************
' Function:     InitForm
'
' Abstract:     Creates UI elements (buttons, edit controls, ...) on the 
'               Wintalk WFC form.
'			
' Input Parameters: None
'
' Returns: Void
'******************************************************************************/
	Private Sub InitForm
	
		Me.Text = "WinTalk"
		Me.AutoScaleBaseSize = new Size(5, 13)
		Me.ClientSize = new Size(406, 344)
		Me.AddOnActivate(new EventHandler(AddressOf Me.WinTalk_activate))

		edit2.Dock = DockStyle.Fill
		edit2.Location = new Point(0, 158)
		edit2.Size = new Size(406, 154)
		edit2.TabIndex = 1
		edit2.Text = ""
		edit2.Multiline = true
		edit2.ReadOnly = true
		edit2.ScrollBars = ScrollBars.Vertical
		edit2.BackColor = Color.White

		edit1.Dock = DockStyle.Top
		edit1.Size = new Size(406, 153)
		edit1.TabIndex = 0
		edit1.Text = ""
		edit1.Multiline = true
		edit1.ReadOnly = true
		edit1.ScrollBars = ScrollBars.Vertical
		edit1.BackColor = Color.White

		label1.Anchor = AnchorStyles.BottomLeftRight
		label1.Location = new Point(0, 321)
		label1.Size = new Size(230, 18)
		label1.TabIndex = 2
		label1.TabStop = false
		label1.Text = ""

		button1.Anchor = AnchorStyles.BottomRight
		button1.Location = new Point(331, 317)		
		button1.Size = new Size(72, 24)
		button1.TabIndex = 0
		button1.Text = "Connect"
		button1.AddOnClick(new EventHandler(AddressOf Me.button1_click))

		button2.Anchor = AnchorStyles.BottomRight
		button2.Enabled = false
		button2.Location = new Point(235, 317)
		button2.Size = new Size(88, 24)
		button2.TabIndex = 1
		button2.Text = "Disconnect"
		button2.AddOnClick(new EventHandler(AddressOf Me.button2_click))

		splitter1.Cursor = Cursors.HSplit
		splitter1.Dock = DockStyle.Top
		splitter1.Location = new Point(0, 153)
		splitter1.Size = new Size(406, 5)
		splitter1.TabIndex = 2
		splitter1.TabStop = false

		panel1.Anchor = AnchorStyles.All
		panel1.Size = new Size(406, 312)
		panel1.TabIndex = 3
		panel1.Text = "panel1"
		panel1.AddOnResize(new EventHandler(AddressOf Me.panel1_resize))

		Me.Controls.All = new Control() { panel1, button2, button1, label1} 
		panel1.Controls.All = new Control() { splitter1, edit2, edit1}
	End Sub

End Class

'*****************************************************************************
' Function:     Main
'
' Abstract:     Entry point into application.
'			
' Input Parameters: String[]
'
' Returns: void

'******************************************************************************/
	Sub Main
		Dim port As Integer = 5000
		Dim args() As String = Environment.GetCommandLineArgs()
		if (args.Length > 1) Then
			
			Try 
				if (args.Length > 1) Then throw new ArgumentException
				port = Convert.ToInt32(args(0))
			
			Catch 
				Console.WriteLine("Usage: Wintalk [port]")
				Exit Sub
			End Try
		End If
		Application.Run(new WinTalk(port))
	End Sub

End Module
