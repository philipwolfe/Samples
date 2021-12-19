Attribute VB_Name = "modTask"
Option Explicit

Public cnWos As ADODB.Connection
Public rsTask As ADODB.Recordset

Public cnWos2 As ADODB.Connection
Public rsEquipList As ADODB.Recordset

Public Function ValidateTask() As Integer
    Dim intLen As Integer
    Dim MyControl As Control
    Dim ans As Integer
    Dim strName As String
    Dim intPass As Integer

On Error GoTo errorhandler

    intPass = 0
        
    For Each MyControl In frmTask.Controls
        If TypeName(MyControl) = "TextBox" Then
            strName = MyControl.Name
            intLen = Len(MyControl.Text)
            
            Select Case strName
                Case "txtTaskDesc"
                    If intLen = 0 Then
                        intPass = intPass + 1
                    End If
                Case "txtDateTaskCreated"
                    If intLen = 0 Then
                        intPass = intPass + 1
                    End If
            End Select
            
        ElseIf TypeName(MyControl) = "ComboBox" Then
            strName = MyControl.Name
            intLen = Len(MyControl.Text)
            
            Select Case strName
                Case "cboEquipID"
                    If intLen = 0 Then
                        intPass = intPass + 1
                    End If
                Case "cboCycleType"
                    If intLen = 0 Then
                        intPass = intPass + 1
                    End If
            End Select
        ElseIf TypeName(MyControl) = "MaskEdBox" Then
            strName = MyControl.Name
            intLen = Len(MyControl.Text)
            Select Case strName
            Case "txtDateTaskCreated"
                If intLen = 0 Then
                    intPass = intPass + 1
                End If
            End Select
        End If
    Next MyControl
    
    ValidateTask = intPass
    If intPass > 0 Then
        If intPass > 1 Then
            ans = MsgBox("There are more than one required field not populated. Data was not saved.")
            Exit Function
        Else
            ans = MsgBox("There is a required field not populated. Data was not saved.")
            Exit Function
        End If
    End If
Exit Function
errorhandler:
Err.Raise Err.Number, "WOS: WO - modTask - ValidateTask", Err.Description
End Function

Public Function RecordsetTask(ByVal strSQL As String) As ADODB.Recordset
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
    
    Set rsTask = New ADODB.Recordset
    
    rsTask.Open strSQL, cnWos, adOpenDynamic, _
                     adLockOptimistic, adCmdText
    
    Set RecordsetTask = rsTask
    
    Set rsTask = Nothing
Exit Function
errorhandler:
Err.Raise Err.Number, "WOS: modTask - RecordsetTask", Err.Description
End Function

Public Function EquipList(strSQL As String) As ADODB.Recordset
    Dim strAppPath As String
    Dim strPathToWOS As String
    Dim strConn As String
    
On Error GoTo errorhandler

    strAppPath = App.Path
    strAppPath = strAppPath & "\"
    strPathToWOS = strAppPath & "WOS.MDB"
       
    strConn = "Provider=Microsoft.Jet.OLEDB.4.0;" & _
          "Data Source=" & strPathToWOS & ";"
    
    Set cnWos2 = New ADODB.Connection
    cnWos2.CursorLocation = adUseClient
    cnWos2.Open strConn
    Set rsEquipList = New ADODB.Recordset
    
    rsEquipList.Open strSQL, cnWos2, adOpenDynamic, adLockReadOnly, _
                                adCmdText
    Set EquipList = rsEquipList
                                
    Set rsEquipList = Nothing
Exit Function
errorhandler:
Err.Raise Err.Number, "WOS: modTask - EquipList", Err.Description
End Function
