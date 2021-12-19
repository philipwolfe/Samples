Attribute VB_Name = "modWorkOrder"
Option Explicit

Public cnWos As ADODB.Connection
Public rsWO As ADODB.Recordset

Public Function ValidateWO() As Integer
    Dim intLen As Integer
    Dim MyControl As Control
    Dim ans As Integer
    Dim strName As String
    Dim intPass As Integer
    
On Error GoTo errorhandler

    intPass = 0
        
    For Each MyControl In frmWorkOrder.Controls
        If TypeName(MyControl) = "TextBox" Then
            strName = MyControl.Name
            intLen = Len(MyControl.Text)
        
            Select Case strName
                Case "txtCompletedBy"
                    If intLen = 0 Then
                        intPass = intPass + 1
                    End If
                Case "txtDateCompleted"
                    If intLen = 0 Then
                        intPass = intPass + 1
                    End If
        '        Case "txtDateTaskCreated"
        '            If intLen = 0 Then
        '                intPass = intPass + 1
        '            End If
            End Select
        ElseIf TypeName(MyControl) = "ComboBox" Then
            strName = MyControl.Name
            intLen = Len(MyControl.Text)
            
            Select Case strName
                Case "cboEquipID"
                    If intLen = 0 Then
                        intPass = intPass + 1
                    End If
                Case "cboTaskID"
                    If intLen = 0 Then
                        intPass = intPass + 1
                    End If
            End Select
        End If
    Next MyControl
    
    ValidateWO = intPass
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
Err.Raise Err.Number, "WOS: modWorkOrder - ValidateWO", Err.Description
End Function

Public Function RecordsetWO(ByVal strSQL As String) As ADODB.Recordset
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
    
    Set rsWO = New ADODB.Recordset
    
    rsWO.Open strSQL, cnWos, adOpenDynamic, _
                     adLockOptimistic, adCmdText
    
    Set RecordsetWO = rsWO
    
    Set rsWO = Nothing
Exit Function
errorhandler:
Err.Raise Err.Number, "WOS: modWorkOrder - RecordsetWO", Err.Description
End Function

