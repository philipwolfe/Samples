Attribute VB_Name = "modEquipment"
Option Explicit

Public cnWos As ADODB.Connection
Public rsEquip As ADODB.Recordset

Public Function ValidateEquipment() As Integer
    Dim intLen As Integer
    Dim MyControl As Control
    Dim ans As Integer
    Dim strName As String
    Dim intPass As Integer
    
On Error GoTo errorhandler

    intPass = 0
        
    For Each MyControl In frmEquipment.Controls
        If TypeName(MyControl) = "TextBox" Then
            strName = MyControl.Name
            intLen = Len(MyControl.Text)
            
            Select Case strName
                Case "txtEquipKey"
                    If intLen = 0 Then
                        intPass = intPass + 1
                    End If
                Case "txtEquipDesc"
                    If intLen = 0 Then
                         intPass = intPass + 1
                    End If
            End Select
        End If
    Next MyControl
    ValidateEquipment = intPass
    If intPass > 0 Then
        If intPass > 1 Then
            ans = MsgBox("There are more than one required fields not populated. Data was not saved.")
            Exit Function
        Else
            ans = MsgBox("There is a required field not populated. Data was not saved.")
            Exit Function
        End If
    End If
Exit Function
errorhandler:
Err.Raise Err.Number, "WOS: modEquipment - ValidateEquipment", Err.Description
End Function

Public Function RecordsetEquip(strSQL As String) As ADODB.Recordset
    Dim strAppPath As String
    Dim strPathToWOS As String
    Dim strConn As String
    
On Error GoTo errorhandler

    strAppPath = App.Path
    strAppPath = strAppPath & "\"
    strPathToWOS = strAppPath & "WOS.MDB"
       
    strConn = "Provider=Microsoft.Jet.OLEDB.4.0;" & _
          "Data Source=" & strPathToWOS & ";"
    
    Set cnWos = New ADODB.Connection
    cnWos.CursorLocation = adUseClient
    cnWos.Open strConn
    
    Set rsEquip = New ADODB.Recordset
    rsEquip.Open strSQL, cnWos, adOpenDynamic, _
                     adLockOptimistic, adCmdText
    
    Set RecordsetEquip = rsEquip
    
    Set rsEquip = Nothing
Exit Function
errorhandler:
Err.Raise Err.Number, "WOS: modEquipment - RecordsetEquip", Err.Description
End Function
