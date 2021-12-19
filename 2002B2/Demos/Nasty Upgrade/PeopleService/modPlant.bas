Attribute VB_Name = "modPlant"
Option Explicit

Public cnWos As ADODB.Connection

Public Function ValidatePlant()
    Dim intLen As Integer
    Dim MyControl As Control
    Dim ans As Integer
    Dim strName As String
        
On Error GoTo errorhandler

    For Each MyControl In frmAddPlant.Controls
        If TypeName(MyControl) = "TextBox" Then
            strName = MyControl.Name
            intLen = Len(MyControl.Text)
            
            Select Case strName
            Case "txtPlantName"
                
                If intLen > 15 Then
                    ans = MsgBox("The plant name field can not have more than 15 characters.", vbOKOnly, "WOS")
                    frmAddPlant.txtPlantName.Text = ""
                    frmAddPlant.txtPlantName.SetFocus
                Else
                    If intLen = 0 Then
                        ans = MsgBox("We need value in the textbox above to create a plant.", vbOKOnly, "WOS")
                    Else
                        ans = MsgBox("Are you sure you want to create " & frmAddPlant.txtPlantName.Text & " plant? You will not be able to delete or update it once its created.", vbYesNo, "WOS")
                        If ans = 6 Then
                            frmAddPlant.AddPlant
                        End If
                    End If
                End If
            End Select
        
        End If
    Next MyControl
Exit Function
errorhandler:
Err.Raise Err.Number, "WOS: modPlant - ValidatePlant", Err.Description
End Function


Public Function RecordsetPlant(strSQL As String, strCurType As String) As ADODB.Recordset
    Dim strAppPath As String
    Dim strPathToWOS As String
    Dim strConn As String
    Dim rsplant As ADODB.Recordset
    
On Error GoTo errorhandler

    strAppPath = App.Path
    strAppPath = strAppPath & "\"
    strPathToWOS = strAppPath & "WOS.MDB"
       
    strConn = "Provider=Microsoft.Jet.OLEDB.4.0;" & _
          "Data Source=" & strPathToWOS & ";"
    
    Set cnWos = New ADODB.Connection
    cnWos.CursorLocation = adUseClient
    cnWos.Open strConn
    
    Set rsplant = New ADODB.Recordset
    If strCurType = "Retrieve" Then
        rsplant.Open strSQL, cnWos, adOpenStatic, _
                     adLockReadOnly, adCmdText
    Else
        rsplant.Open strSQL, cnWos, adOpenDynamic, _
                     adLockOptimistic, adCmdText
    End If

    Set RecordsetPlant = rsplant
Exit Function
errorhandler:
Err.Raise Err.Number, "WOS: WO - modPlant - RecordsetPlant", Err.Description
End Function
