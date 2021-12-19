VERSION 1.0 CLASS
BEGIN
  MultiUse = -1  'True
  Persistable = 0  'NotPersistable
  DataBindingBehavior = 0  'vbNone
  DataSourceBehavior  = 0  'vbNone
  MTSTransactionMode  = 0  'NotAnMTSObject
END
Attribute VB_Name = "Class1"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = True
Attribute VB_PredeclaredId = False
Attribute VB_Exposed = False
Public WithEvents myButton As Button
Attribute myButton.VB_VarHelpID = -1
Dim nFlag As Integer

Private Sub Class_Initialize()
    Set myButton = New Button
    nStart = 0
End Sub

Private Sub myButton_Click(ByVal x As Long, ByVal y As Long)
    MsgBox "Start event"
    nFlag = 100
End Sub

Private Sub myButton_Resize()
    MsgBox "Stop event"
    nFlag = 0
    Form1.Panel.Caption = ""
End Sub

Private Sub myButton_Pulse()
    If nFlag = 100 Then
        Form1.Panel.Caption = Time
        If Form1.nMute = 0 Then
            Beep
        End If
    End If
End Sub
