'Copyright (C) 2002 Microsoft Corporation
'All rights reserved.
'THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, EITHER 
'EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED WARRANTIES OF 
'MERCHANTIBILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.

'Requires the Trial or Release version of Visual Studio .NET Professional (or greater).

Option Strict On

Imports System.Net.Sockets

Public Class frmMain
    Inherits System.Windows.Forms.Form

#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call

        ' So that we only need to set the title of the application once,
        ' we use the AssemblyInfo class (defined in the AssemblyInfo.vb file)
        ' to read the AssemblyTitle attribute.
        Dim ainfo As New AssemblyInfo()

        Me.Text = ainfo.Title
        Me.mnuAbout.Text = String.Format("&About {0} ...", ainfo.Title)

    End Sub

    'Form overrides dispose to clean up the component list.
    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing Then
            If Not (components Is Nothing) Then
                components.Dispose()
            End If
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    Friend WithEvents mnuMain As System.Windows.Forms.MainMenu
    Friend WithEvents mnuFile As System.Windows.Forms.MenuItem
    Friend WithEvents mnuExit As System.Windows.Forms.MenuItem
    Friend WithEvents mnuHelp As System.Windows.Forms.MenuItem
    Friend WithEvents mnuAbout As System.Windows.Forms.MenuItem
    Friend WithEvents lstStatus As System.Windows.Forms.ListBox
    Friend WithEvents btnBroadcast As System.Windows.Forms.Button
    Friend WithEvents txtBroadcast As System.Windows.Forms.TextBox
    Friend WithEvents lblInstructions As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmMain))
        Me.mnuMain = New System.Windows.Forms.MainMenu()
        Me.mnuFile = New System.Windows.Forms.MenuItem()
        Me.mnuExit = New System.Windows.Forms.MenuItem()
        Me.mnuHelp = New System.Windows.Forms.MenuItem()
        Me.mnuAbout = New System.Windows.Forms.MenuItem()
        Me.lstStatus = New System.Windows.Forms.ListBox()
        Me.txtBroadcast = New System.Windows.Forms.TextBox()
        Me.btnBroadcast = New System.Windows.Forms.Button()
        Me.lblInstructions = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'mnuMain
        '
        Me.mnuMain.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.mnuFile, Me.mnuHelp})
        Me.mnuMain.RightToLeft = CType(resources.GetObject("mnuMain.RightToLeft"), System.Windows.Forms.RightToLeft)
        '
        'mnuFile
        '
        Me.mnuFile.Enabled = CType(resources.GetObject("mnuFile.Enabled"), Boolean)
        Me.mnuFile.Index = 0
        Me.mnuFile.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.mnuExit})
        Me.mnuFile.Shortcut = CType(resources.GetObject("mnuFile.Shortcut"), System.Windows.Forms.Shortcut)
        Me.mnuFile.ShowShortcut = CType(resources.GetObject("mnuFile.ShowShortcut"), Boolean)
        Me.mnuFile.Text = resources.GetString("mnuFile.Text")
        Me.mnuFile.Visible = CType(resources.GetObject("mnuFile.Visible"), Boolean)
        '
        'mnuExit
        '
        Me.mnuExit.Enabled = CType(resources.GetObject("mnuExit.Enabled"), Boolean)
        Me.mnuExit.Index = 0
        Me.mnuExit.Shortcut = CType(resources.GetObject("mnuExit.Shortcut"), System.Windows.Forms.Shortcut)
        Me.mnuExit.ShowShortcut = CType(resources.GetObject("mnuExit.ShowShortcut"), Boolean)
        Me.mnuExit.Text = resources.GetString("mnuExit.Text")
        Me.mnuExit.Visible = CType(resources.GetObject("mnuExit.Visible"), Boolean)
        '
        'mnuHelp
        '
        Me.mnuHelp.Enabled = CType(resources.GetObject("mnuHelp.Enabled"), Boolean)
        Me.mnuHelp.Index = 1
        Me.mnuHelp.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.mnuAbout})
        Me.mnuHelp.Shortcut = CType(resources.GetObject("mnuHelp.Shortcut"), System.Windows.Forms.Shortcut)
        Me.mnuHelp.ShowShortcut = CType(resources.GetObject("mnuHelp.ShowShortcut"), Boolean)
        Me.mnuHelp.Text = resources.GetString("mnuHelp.Text")
        Me.mnuHelp.Visible = CType(resources.GetObject("mnuHelp.Visible"), Boolean)
        '
        'mnuAbout
        '
        Me.mnuAbout.Enabled = CType(resources.GetObject("mnuAbout.Enabled"), Boolean)
        Me.mnuAbout.Index = 0
        Me.mnuAbout.Shortcut = CType(resources.GetObject("mnuAbout.Shortcut"), System.Windows.Forms.Shortcut)
        Me.mnuAbout.ShowShortcut = CType(resources.GetObject("mnuAbout.ShowShortcut"), Boolean)
        Me.mnuAbout.Text = resources.GetString("mnuAbout.Text")
        Me.mnuAbout.Visible = CType(resources.GetObject("mnuAbout.Visible"), Boolean)
        '
        'lstStatus
        '
        Me.lstStatus.AccessibleDescription = resources.GetString("lstStatus.AccessibleDescription")
        Me.lstStatus.AccessibleName = resources.GetString("lstStatus.AccessibleName")
        Me.lstStatus.Anchor = CType(resources.GetObject("lstStatus.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.lstStatus.BackgroundImage = CType(resources.GetObject("lstStatus.BackgroundImage"), System.Drawing.Image)
        Me.lstStatus.ColumnWidth = CType(resources.GetObject("lstStatus.ColumnWidth"), Integer)
        Me.lstStatus.Dock = CType(resources.GetObject("lstStatus.Dock"), System.Windows.Forms.DockStyle)
        Me.lstStatus.Enabled = CType(resources.GetObject("lstStatus.Enabled"), Boolean)
        Me.lstStatus.Font = CType(resources.GetObject("lstStatus.Font"), System.Drawing.Font)
        Me.lstStatus.HorizontalExtent = CType(resources.GetObject("lstStatus.HorizontalExtent"), Integer)
        Me.lstStatus.HorizontalScrollbar = CType(resources.GetObject("lstStatus.HorizontalScrollbar"), Boolean)
        Me.lstStatus.ImeMode = CType(resources.GetObject("lstStatus.ImeMode"), System.Windows.Forms.ImeMode)
        Me.lstStatus.IntegralHeight = CType(resources.GetObject("lstStatus.IntegralHeight"), Boolean)
        Me.lstStatus.ItemHeight = CType(resources.GetObject("lstStatus.ItemHeight"), Integer)
        Me.lstStatus.Location = CType(resources.GetObject("lstStatus.Location"), System.Drawing.Point)
        Me.lstStatus.Name = "lstStatus"
        Me.lstStatus.RightToLeft = CType(resources.GetObject("lstStatus.RightToLeft"), System.Windows.Forms.RightToLeft)
        Me.lstStatus.ScrollAlwaysVisible = CType(resources.GetObject("lstStatus.ScrollAlwaysVisible"), Boolean)
        Me.lstStatus.Size = CType(resources.GetObject("lstStatus.Size"), System.Drawing.Size)
        Me.lstStatus.TabIndex = CType(resources.GetObject("lstStatus.TabIndex"), Integer)
        Me.lstStatus.Visible = CType(resources.GetObject("lstStatus.Visible"), Boolean)
        '
        'txtBroadcast
        '
        Me.txtBroadcast.AccessibleDescription = resources.GetString("txtBroadcast.AccessibleDescription")
        Me.txtBroadcast.AccessibleName = resources.GetString("txtBroadcast.AccessibleName")
        Me.txtBroadcast.Anchor = CType(resources.GetObject("txtBroadcast.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.txtBroadcast.AutoSize = CType(resources.GetObject("txtBroadcast.AutoSize"), Boolean)
        Me.txtBroadcast.BackgroundImage = CType(resources.GetObject("txtBroadcast.BackgroundImage"), System.Drawing.Image)
        Me.txtBroadcast.Dock = CType(resources.GetObject("txtBroadcast.Dock"), System.Windows.Forms.DockStyle)
        Me.txtBroadcast.Enabled = CType(resources.GetObject("txtBroadcast.Enabled"), Boolean)
        Me.txtBroadcast.Font = CType(resources.GetObject("txtBroadcast.Font"), System.Drawing.Font)
        Me.txtBroadcast.ImeMode = CType(resources.GetObject("txtBroadcast.ImeMode"), System.Windows.Forms.ImeMode)
        Me.txtBroadcast.Location = CType(resources.GetObject("txtBroadcast.Location"), System.Drawing.Point)
        Me.txtBroadcast.MaxLength = CType(resources.GetObject("txtBroadcast.MaxLength"), Integer)
        Me.txtBroadcast.Multiline = CType(resources.GetObject("txtBroadcast.Multiline"), Boolean)
        Me.txtBroadcast.Name = "txtBroadcast"
        Me.txtBroadcast.PasswordChar = CType(resources.GetObject("txtBroadcast.PasswordChar"), Char)
        Me.txtBroadcast.RightToLeft = CType(resources.GetObject("txtBroadcast.RightToLeft"), System.Windows.Forms.RightToLeft)
        Me.txtBroadcast.ScrollBars = CType(resources.GetObject("txtBroadcast.ScrollBars"), System.Windows.Forms.ScrollBars)
        Me.txtBroadcast.Size = CType(resources.GetObject("txtBroadcast.Size"), System.Drawing.Size)
        Me.txtBroadcast.TabIndex = CType(resources.GetObject("txtBroadcast.TabIndex"), Integer)
        Me.txtBroadcast.Text = resources.GetString("txtBroadcast.Text")
        Me.txtBroadcast.TextAlign = CType(resources.GetObject("txtBroadcast.TextAlign"), System.Windows.Forms.HorizontalAlignment)
        Me.txtBroadcast.Visible = CType(resources.GetObject("txtBroadcast.Visible"), Boolean)
        Me.txtBroadcast.WordWrap = CType(resources.GetObject("txtBroadcast.WordWrap"), Boolean)
        '
        'btnBroadcast
        '
        Me.btnBroadcast.AccessibleDescription = resources.GetString("btnBroadcast.AccessibleDescription")
        Me.btnBroadcast.AccessibleName = resources.GetString("btnBroadcast.AccessibleName")
        Me.btnBroadcast.Anchor = CType(resources.GetObject("btnBroadcast.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.btnBroadcast.BackgroundImage = CType(resources.GetObject("btnBroadcast.BackgroundImage"), System.Drawing.Image)
        Me.btnBroadcast.Dock = CType(resources.GetObject("btnBroadcast.Dock"), System.Windows.Forms.DockStyle)
        Me.btnBroadcast.Enabled = CType(resources.GetObject("btnBroadcast.Enabled"), Boolean)
        Me.btnBroadcast.FlatStyle = CType(resources.GetObject("btnBroadcast.FlatStyle"), System.Windows.Forms.FlatStyle)
        Me.btnBroadcast.Font = CType(resources.GetObject("btnBroadcast.Font"), System.Drawing.Font)
        Me.btnBroadcast.Image = CType(resources.GetObject("btnBroadcast.Image"), System.Drawing.Image)
        Me.btnBroadcast.ImageAlign = CType(resources.GetObject("btnBroadcast.ImageAlign"), System.Drawing.ContentAlignment)
        Me.btnBroadcast.ImageIndex = CType(resources.GetObject("btnBroadcast.ImageIndex"), Integer)
        Me.btnBroadcast.ImeMode = CType(resources.GetObject("btnBroadcast.ImeMode"), System.Windows.Forms.ImeMode)
        Me.btnBroadcast.Location = CType(resources.GetObject("btnBroadcast.Location"), System.Drawing.Point)
        Me.btnBroadcast.Name = "btnBroadcast"
        Me.btnBroadcast.RightToLeft = CType(resources.GetObject("btnBroadcast.RightToLeft"), System.Windows.Forms.RightToLeft)
        Me.btnBroadcast.Size = CType(resources.GetObject("btnBroadcast.Size"), System.Drawing.Size)
        Me.btnBroadcast.TabIndex = CType(resources.GetObject("btnBroadcast.TabIndex"), Integer)
        Me.btnBroadcast.Text = resources.GetString("btnBroadcast.Text")
        Me.btnBroadcast.TextAlign = CType(resources.GetObject("btnBroadcast.TextAlign"), System.Drawing.ContentAlignment)
        Me.btnBroadcast.Visible = CType(resources.GetObject("btnBroadcast.Visible"), Boolean)
        '
        'lblInstructions
        '
        Me.lblInstructions.AccessibleDescription = resources.GetString("lblInstructions.AccessibleDescription")
        Me.lblInstructions.AccessibleName = resources.GetString("lblInstructions.AccessibleName")
        Me.lblInstructions.Anchor = CType(resources.GetObject("lblInstructions.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.lblInstructions.AutoSize = CType(resources.GetObject("lblInstructions.AutoSize"), Boolean)
        Me.lblInstructions.Dock = CType(resources.GetObject("lblInstructions.Dock"), System.Windows.Forms.DockStyle)
        Me.lblInstructions.Enabled = CType(resources.GetObject("lblInstructions.Enabled"), Boolean)
        Me.lblInstructions.Font = CType(resources.GetObject("lblInstructions.Font"), System.Drawing.Font)
        Me.lblInstructions.ForeColor = System.Drawing.Color.FromArgb(CType(0, Byte), CType(0, Byte), CType(192, Byte))
        Me.lblInstructions.Image = CType(resources.GetObject("lblInstructions.Image"), System.Drawing.Image)
        Me.lblInstructions.ImageAlign = CType(resources.GetObject("lblInstructions.ImageAlign"), System.Drawing.ContentAlignment)
        Me.lblInstructions.ImageIndex = CType(resources.GetObject("lblInstructions.ImageIndex"), Integer)
        Me.lblInstructions.ImeMode = CType(resources.GetObject("lblInstructions.ImeMode"), System.Windows.Forms.ImeMode)
        Me.lblInstructions.Location = CType(resources.GetObject("lblInstructions.Location"), System.Drawing.Point)
        Me.lblInstructions.Name = "lblInstructions"
        Me.lblInstructions.RightToLeft = CType(resources.GetObject("lblInstructions.RightToLeft"), System.Windows.Forms.RightToLeft)
        Me.lblInstructions.Size = CType(resources.GetObject("lblInstructions.Size"), System.Drawing.Size)
        Me.lblInstructions.TabIndex = CType(resources.GetObject("lblInstructions.TabIndex"), Integer)
        Me.lblInstructions.Text = resources.GetString("lblInstructions.Text")
        Me.lblInstructions.TextAlign = CType(resources.GetObject("lblInstructions.TextAlign"), System.Drawing.ContentAlignment)
        Me.lblInstructions.Visible = CType(resources.GetObject("lblInstructions.Visible"), Boolean)
        '
        'Label1
        '
        Me.Label1.AccessibleDescription = CType(resources.GetObject("Label1.AccessibleDescription"), String)
        Me.Label1.AccessibleName = CType(resources.GetObject("Label1.AccessibleName"), String)
        Me.Label1.Anchor = CType(resources.GetObject("Label1.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.Label1.AutoSize = CType(resources.GetObject("Label1.AutoSize"), Boolean)
        Me.Label1.Dock = CType(resources.GetObject("Label1.Dock"), System.Windows.Forms.DockStyle)
        Me.Label1.Enabled = CType(resources.GetObject("Label1.Enabled"), Boolean)
        Me.Label1.Font = CType(resources.GetObject("Label1.Font"), System.Drawing.Font)
        Me.Label1.ForeColor = System.Drawing.Color.FromArgb(CType(0, Byte), CType(0, Byte), CType(192, Byte))
        Me.Label1.Image = CType(resources.GetObject("Label1.Image"), System.Drawing.Image)
        Me.Label1.ImageAlign = CType(resources.GetObject("Label1.ImageAlign"), System.Drawing.ContentAlignment)
        Me.Label1.ImageIndex = CType(resources.GetObject("Label1.ImageIndex"), Integer)
        Me.Label1.ImeMode = CType(resources.GetObject("Label1.ImeMode"), System.Windows.Forms.ImeMode)
        Me.Label1.Location = CType(resources.GetObject("Label1.Location"), System.Drawing.Point)
        Me.Label1.Name = "Label1"
        Me.Label1.RightToLeft = CType(resources.GetObject("Label1.RightToLeft"), System.Windows.Forms.RightToLeft)
        Me.Label1.Size = CType(resources.GetObject("Label1.Size"), System.Drawing.Size)
        Me.Label1.TabIndex = CType(resources.GetObject("Label1.TabIndex"), Integer)
        Me.Label1.Text = resources.GetString("Label1.Text")
        Me.Label1.TextAlign = CType(resources.GetObject("Label1.TextAlign"), System.Drawing.ContentAlignment)
        Me.Label1.Visible = CType(resources.GetObject("Label1.Visible"), Boolean)
        '
        'frmMain
        '
        Me.AccessibleDescription = resources.GetString("$this.AccessibleDescription")
        Me.AccessibleName = resources.GetString("$this.AccessibleName")
        Me.Anchor = CType(resources.GetObject("$this.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.AutoScaleBaseSize = CType(resources.GetObject("$this.AutoScaleBaseSize"), System.Drawing.Size)
        Me.AutoScroll = CType(resources.GetObject("$this.AutoScroll"), Boolean)
        Me.AutoScrollMargin = CType(resources.GetObject("$this.AutoScrollMargin"), System.Drawing.Size)
        Me.AutoScrollMinSize = CType(resources.GetObject("$this.AutoScrollMinSize"), System.Drawing.Size)
        Me.BackgroundImage = CType(resources.GetObject("$this.BackgroundImage"), System.Drawing.Image)
        Me.ClientSize = CType(resources.GetObject("$this.ClientSize"), System.Drawing.Size)
        Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.Label1, Me.lblInstructions, Me.btnBroadcast, Me.txtBroadcast, Me.lstStatus})
        Me.Dock = CType(resources.GetObject("$this.Dock"), System.Windows.Forms.DockStyle)
        Me.Enabled = CType(resources.GetObject("$this.Enabled"), Boolean)
        Me.Font = CType(resources.GetObject("$this.Font"), System.Drawing.Font)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.ImeMode = CType(resources.GetObject("$this.ImeMode"), System.Windows.Forms.ImeMode)
        Me.Location = CType(resources.GetObject("$this.Location"), System.Drawing.Point)
        Me.MaximizeBox = False
        Me.MaximumSize = CType(resources.GetObject("$this.MaximumSize"), System.Drawing.Size)
        Me.Menu = Me.mnuMain
        Me.MinimumSize = CType(resources.GetObject("$this.MinimumSize"), System.Drawing.Size)
        Me.Name = "frmMain"
        Me.RightToLeft = CType(resources.GetObject("$this.RightToLeft"), System.Windows.Forms.RightToLeft)
        Me.StartPosition = CType(resources.GetObject("$this.StartPosition"), System.Windows.Forms.FormStartPosition)
        Me.Text = resources.GetString("$this.Text")
        Me.Visible = CType(resources.GetObject("$this.Visible"), Boolean)
        Me.ResumeLayout(False)

    End Sub

#End Region

#Region " Standard Menu Code "
    ' <System.Diagnostics.DebuggerStepThrough()> has been added to some procedures since they are
    ' not the focus of the demo. Remove them if you wish to debug the procedures.
    ' This code simply shows the About form.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub mnuAbout_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuAbout.Click
        ' Open the About form in Dialog Mode
        Dim frm As New frmAbout()
        frm.ShowDialog(Me)
        frm.Dispose()
    End Sub

    ' This code will close the form.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub mnuExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuExit.Click
        ' Close the current form
        Me.Close()
    End Sub
#End Region

    Const PORT_NUM As Integer = 10000

    Private clients As New Hashtable()
    Private listener As TcpListener
    Private listenerThread As Threading.Thread

    ' This subroutine sends a message to all attached clients
    Private Sub Broadcast(ByVal strMessage As String)
        Dim client As UserConnection
        Dim entry As DictionaryEntry

        ' All entries in the clients Hashtable are UserConnection so it is possible
        ' to assign it safely.
        For Each entry In clients
            client = CType(entry.Value, UserConnection)
            client.SendData(strMessage)
        Next
    End Sub

    ' This subroutine sends the contents of the Broadcast textbox to all clients, if
    ' it is not empty, and clears the textbox
    Private Sub btnBroadcast_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBroadcast.Click
        If txtBroadcast.Text <> "" Then
            UpdateStatus("Broadcasting: " & txtBroadcast.Text)
            Broadcast("BROAD|" & txtBroadcast.Text)

            txtBroadcast.Text = ""
        End If
    End Sub

    ' This subroutine checks to see if username already exists in the clients 
    ' Hashtable.  If it does, send a REFUSE message, otherwise confirm with a JOIN.
    Private Sub ConnectUser(ByVal userName As String, ByVal sender As UserConnection)
        If clients.Contains(userName) Then
            ReplyToSender("REFUSE", sender)
        Else
            sender.Name = userName
            UpdateStatus(userName & " has joined the chat.")
            clients.Add(userName, sender)

            ' Send a JOIN to sender, and notify all other clients that sender joined
            ReplyToSender("JOIN", sender)
            SendToClients("CHAT|" & sender.Name & " has joined the chat.", sender)
        End If
    End Sub

    ' This subroutine notifies other clients that sender left the chat, and removes
    ' the name from the clients Hashtable
    Private Sub DisconnectUser(ByVal sender As UserConnection)
        UpdateStatus(sender.Name & " has left the chat.")
        SendToClients("CHAT|" & sender.Name & " has left the chat.", sender)
        clients.Remove(sender.Name)
    End Sub

    ' This subroutine is used as a background listener thread to allow reading incoming
    ' messages without lagging the user interface.
    Private Sub DoListen()
        Try
            ' Listen for new connections.
            listener = New TcpListener(PORT_NUM)
            listener.Start()
            Do
                ' Create a new user connection using TcpClient returned by
                ' TcpListener.AcceptTcpClient()
                Dim client As New UserConnection(listener.AcceptTcpClient)

                ' Create an event handler to allow the UserConnection to communicate
                ' with the window.
                AddHandler client.LineReceived, AddressOf OnLineReceived
                UpdateStatus("New connection found: waiting for log-in")
            Loop Until False
        Catch
        End Try
    End Sub

    ' When the window closes, stop the listener.
    Private Sub frmMain_Closing(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
        listener.Stop()
    End Sub

    ' Start the background listener thread.
    Private Sub frmMain_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        listenerThread = New Threading.Thread(AddressOf DoListen)
        listenerThread.Start()
        UpdateStatus("Listener started")
    End Sub

    ' Concatenate all the client names and send them to the user who requested user list
    Private Sub ListUsers(ByVal sender As UserConnection)
        Dim client As UserConnection
        Dim entry As DictionaryEntry
        Dim strUserList As String

        UpdateStatus("Sending " & sender.Name & " a list of users online.")

        strUserList = "LISTUSERS"

        ' All entries in the clients Hashtable are UserConnection so it is possible
        ' to assign it safely.
        For Each entry In clients
            client = CType(entry.Value, UserConnection)
            strUserList = strUserList & "|" & client.Name
        Next

        ' Send the list to the sender.
        ReplyToSender(strUserList, sender)
    End Sub

    ' This is the event handler for the UserConnection when it receives a full line.
    ' Parse the cammand and parameters and take appropriate action.
    Private Sub OnLineReceived(ByVal sender As UserConnection, ByVal data As String)
        Dim dataArray() As String

        ' Message parts are divided by "|"  Break the string into an array accordingly.
        dataArray = data.Split(Chr(124))

        ' dataArray(0) is the command.
        Select Case dataArray(0)
            Case "CONNECT"
                 ConnectUser(dataArray(1), sender)
            Case "CHAT"
                SendChat(dataArray(1), sender)
            Case "DISCONNECT"
                DisconnectUser(sender)
            Case "REQUESTUSERS"
                ListUsers(sender)
            Case Else
                UpdateStatus("Unknown message:" & data)
        End Select
    End Sub

    ' This subroutine sends a response to the sender.
    Private Sub ReplyToSender(ByVal strMessage As String, ByVal sender As UserConnection)
        sender.SendData(strMessage)
    End Sub

    ' Send a chat message to all clients except sender.
    Private Sub SendChat(ByVal message As String, ByVal sender As UserConnection)
        UpdateStatus(sender.Name & ": " & message)
        SendToClients("CHAT|" & sender.Name & ": " & message, sender)
    End Sub

    ' This subroutine sends a message to all attached clients except the sender.
    Private Sub SendToClients(ByVal strMessage As String, ByVal sender As UserConnection)
        Dim client As UserConnection
        Dim entry As DictionaryEntry

        ' All entries in the clients Hashtable are UserConnection so it is possible
        ' to assign it safely.
        For Each entry In clients
            client = CType(entry.Value, UserConnection)

            ' Exclude the sender.
            If client.Name <> sender.Name Then
                client.SendData(strMessage)
            End If
        Next
    End Sub

    ' This subroutine adds line to the Status listbox
    Private Sub UpdateStatus(ByVal statusMessage As String)
        lstStatus.Items.Add(statusMessage)
    End Sub
End Class