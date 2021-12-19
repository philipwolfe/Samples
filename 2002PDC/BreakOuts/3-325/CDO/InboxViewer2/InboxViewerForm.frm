VERSION 5.00
Object = "{831FDD16-0C5C-11D2-A9FC-0000F8754DA1}#2.0#0"; "Mscomctl.ocx"
Begin VB.Form InboxViewerForm 
   Caption         =   "VB6 Inbox Viewer With Data From C# Server"
   ClientHeight    =   6600
   ClientLeft      =   60
   ClientTop       =   345
   ClientWidth     =   9465
   LinkTopic       =   "Form1"
   ScaleHeight     =   440
   ScaleMode       =   3  'Pixel
   ScaleWidth      =   631
   StartUpPosition =   3  'Windows Default
   Begin MSComctlLib.ListView ListView1 
      Height          =   5055
      Left            =   0
      TabIndex        =   0
      Top             =   0
      Width           =   7935
      _ExtentX        =   13996
      _ExtentY        =   8916
      View            =   3
      LabelWrap       =   -1  'True
      HideSelection   =   -1  'True
      FullRowSelect   =   -1  'True
      _Version        =   393217
      ForeColor       =   -2147483640
      BackColor       =   -2147483643
      BorderStyle     =   1
      Appearance      =   1
      NumItems        =   3
      BeginProperty ColumnHeader(1) {BDD1F052-858B-11D1-B16A-00C0F0283628} 
         Text            =   "From"
         Object.Width           =   3969
      EndProperty
      BeginProperty ColumnHeader(2) {BDD1F052-858B-11D1-B16A-00C0F0283628} 
         SubItemIndex    =   1
         Text            =   "Subject"
         Object.Width           =   2540
      EndProperty
      BeginProperty ColumnHeader(3) {BDD1F052-858B-11D1-B16A-00C0F0283628} 
         SubItemIndex    =   2
         Text            =   "Received"
         Object.Width           =   3334
      EndProperty
   End
End
Attribute VB_Name = "InboxViewerForm"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = False
Attribute VB_PredeclaredId = True
Attribute VB_Exposed = False
''===========================================================================
''  File:       InboxViewerForm.frm
''
''  Summary:    The inbox form that displays the list of e-mail messages.
''
''---------------------------------------------------------------------------
''  Copyright (C) 1998-2000 Microsoft Corporation.  All rights reserved.
''===========================================================================
Dim CDO As New CDODataProvider.CDODataProvider
Dim currentSession As Object
Dim inbox As Object
Dim message As Object
Dim messageCollection As Object
Dim messageInfo() As String
Dim numMessages As Integer

Private Sub Form_Load()

On Error GoTo ErrCatch

    Me.Show

    ' Create a new Session
    Set currentSession = CDO.CreateNewSession()
    If (currentSession Is Nothing) Then End
    
    Me.Caption = "VB6 Inbox Viewer With Data From C# Server - Populating ListView with messages....."
    
    ' Get the messages from the inbox
    Set inbox = currentSession.inbox
    Set messageCollection = inbox.Messages
    
    ' Get the first message
    Set message = messageCollection.GetFirst
    
    While (Not message Is Nothing)
        numMessages = numMessages + 1
                
        If (message.Type = "IPM.Note") Then
            messageInfo = CDO.GetMessageInfo(message)
            ListView1.ListItems.Add 1, "key" & CStr(numMessages), messageInfo(0)
            ListView1.ListItems(1).SubItems(1) = messageInfo(1)
            ListView1.ListItems(1).SubItems(2) = messageInfo(2)

            If (numMessages Mod 10 = 0) Then DoEvents
        End If
        
        ' Get the next message
        Set message = messageCollection.GetNext()
    Wend

    Me.Caption = "VB6 Inbox Viewer With Data From C# Server - " & CStr(numMessages) & " Messages"

    Exit Sub

ErrCatch:

    ' Check for MAPI_E_USER_CANCEL:
    If Err.Number = -2147221229 Then
        MsgBox "Logon has been canceled, so the progam will now exit."
    Else
        MsgBox "Unexpected Error: " & Err.Description
    End If
    
    End
    
End Sub

Private Sub Form_Resize()
    ListView1.Width = Me.ScaleWidth
    ListView1.Height = Me.ScaleHeight
    ListView1.ColumnHeaders(2).Width = Me.ScaleWidth - ListView1.ColumnHeaders(1).Width - ListView1.ColumnHeaders(3).Width - 25
End Sub

Private Sub ListView1_DblClick()
    Dim info() As String
    Dim index As Integer
    
    index = Val(Right(ListView1.SelectedItem.Key, Len(ListView1.SelectedItem.Key) - 3))
    
    Set message = messageCollection(index)
    info = CDO.GetMessageDetails(message)
    
    MessageForm.labelFrom = "From: " & ListView1.SelectedItem.Text
    MessageForm.Caption = ListView1.SelectedItem.SubItems(1)
    MessageForm.labelSubject = "Subject: " & ListView1.SelectedItem.SubItems(1)
    MessageForm.labelTo = "To: " & info(1)
    MessageForm.labelCC = "Cc: " & info(2)
    MessageForm.labelSent = "Sent: " & info(3)
    MessageForm.RichTextBox1 = info(0)
    MessageForm.Show
End Sub
