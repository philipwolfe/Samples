Option Strict Off
Option Explicit On
Module modPlant
	
	Public cnWos As ADODB.Connection
	
	Public Function ValidatePlant() As Object
		Dim intLen As Short
		Dim MyControl As System.Windows.Forms.Control
		Dim ans As Short
		Dim strName As String
		
		On Error GoTo errorhandler
		
		For	Each MyControl In frmAddPlant.DefInstance.Controls
			'UPGRADE_WARNING: TypeName has a new behavior. Click for more: 'ms-help://MS.VSCC/commoner/redir/redirect.htm?keyword="vbup1041"'
			If TypeName(MyControl) = "TextBox" Then
				strName = MyControl.Name
				intLen = Len(MyControl.Text)
				
				Select Case strName
					Case "txtPlantName"
						
						If intLen > 15 Then
							ans = MsgBox("The plant name field can not have more than 15 characters.", MsgBoxStyle.OKOnly, "WOS")
							frmAddPlant.DefInstance.txtPlantName.Text = ""
							frmAddPlant.DefInstance.txtPlantName.Focus()
						Else
							If intLen = 0 Then
								ans = MsgBox("We need value in the textbox above to create a plant.", MsgBoxStyle.OKOnly, "WOS")
							Else
								ans = MsgBox("Are you sure you want to create " & frmAddPlant.DefInstance.txtPlantName.Text & " plant? You will not be able to delete or update it once its created.", MsgBoxStyle.YesNo, "WOS")
								If ans = 6 Then
									frmAddPlant.DefInstance.AddPlant()
								End If
							End If
						End If
				End Select
				
			End If
		Next MyControl
		Exit Function
errorhandler: 
		Err.Raise(Err.Number, "WOS: modPlant - ValidatePlant", Err.Description)
	End Function
	
	
	Public Function RecordsetPlant(ByRef strSQL As String, ByRef strCurType As String) As ADODB.Recordset
		Dim strAppPath As String
		Dim strPathToWOS As String
		Dim strConn As String
		Dim rsplant As ADODB.Recordset
		
		On Error GoTo errorhandler
		
		strAppPath = VB6.GetPath
		strAppPath = strAppPath & "\"
		strPathToWOS = strAppPath & "WOS.MDB"
		
		strConn = "Provider=Microsoft.Jet.OLEDB.4.0;" & "Data Source=" & strPathToWOS & ";"
		
		cnWos = New ADODB.Connection
		cnWos.CursorLocation = ADODB.CursorLocationEnum.adUseClient
		cnWos.Open(strConn)
		
		rsplant = New ADODB.Recordset
		If strCurType = "Retrieve" Then
			rsplant.Open(strSQL, cnWos, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly, ADODB.CommandTypeEnum.adCmdText)
		Else
			rsplant.Open(strSQL, cnWos, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic, ADODB.CommandTypeEnum.adCmdText)
		End If
		
		RecordsetPlant = rsplant
		Exit Function
errorhandler: 
		Err.Raise(Err.Number, "WOS: WO - modPlant - RecordsetPlant", Err.Description)
	End Function
End Module