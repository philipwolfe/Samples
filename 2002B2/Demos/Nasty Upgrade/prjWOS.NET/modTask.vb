Option Strict Off
Option Explicit On
Module modTask
	
	Public cnWos As ADODB.Connection
	Public rsTask As ADODB.Recordset
	
	Public cnWos2 As ADODB.Connection
	Public rsEquipList As ADODB.Recordset
	
	Public Function ValidateTask() As Short
		Dim intLen As Short
		Dim MyControl As System.Windows.Forms.Control
		Dim ans As Short
		Dim strName As String
		Dim intPass As Short
		
		On Error GoTo errorhandler
		
		intPass = 0
		
		For	Each MyControl In frmTask.DefInstance.Controls
			'UPGRADE_WARNING: TypeName has a new behavior. Click for more: 'ms-help://MS.VSCC/commoner/redir/redirect.htm?keyword="vbup1041"'
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
				
				'UPGRADE_WARNING: TypeName has a new behavior. Click for more: 'ms-help://MS.VSCC/commoner/redir/redirect.htm?keyword="vbup1041"'
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
		Err.Raise(Err.Number, "WOS: WO - modTask - ValidateTask", Err.Description)
	End Function
	
	Public Function RecordsetTask(ByVal strSQL As String) As ADODB.Recordset
		Dim strAppPath As String
		Dim strPathToWOS As String
		Dim strConn As String
		
		On Error GoTo errorhandler
		
		strAppPath = VB6.GetPath
		strAppPath = strAppPath & "\"
		strPathToWOS = strAppPath & "WOS.MDB"
		
		strConn = "Provider=Microsoft.Jet.OLEDB.4.0;" & "Data Source=" & strPathToWOS & ";"
		
		cnWos = New ADODB.Connection
		cnWos.CursorLocation = ADODB.CursorLocationEnum.adUseClient
		cnWos.Open(strConn)
		
		rsTask = New ADODB.Recordset
		
		rsTask.Open(strSQL, cnWos, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic, ADODB.CommandTypeEnum.adCmdText)
		
		RecordsetTask = rsTask
		
		'UPGRADE_NOTE: Object rsTask may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC/commoner/redir/redirect.htm?keyword="vbup1029"'
		rsTask = Nothing
		Exit Function
errorhandler: 
		Err.Raise(Err.Number, "WOS: modTask - RecordsetTask", Err.Description)
	End Function
	
	Public Function EquipList(ByRef strSQL As String) As ADODB.Recordset
		Dim strAppPath As String
		Dim strPathToWOS As String
		Dim strConn As String
		
		On Error GoTo errorhandler
		
		strAppPath = VB6.GetPath
		strAppPath = strAppPath & "\"
		strPathToWOS = strAppPath & "WOS.MDB"
		
		strConn = "Provider=Microsoft.Jet.OLEDB.4.0;" & "Data Source=" & strPathToWOS & ";"
		
		cnWos2 = New ADODB.Connection
		cnWos2.CursorLocation = ADODB.CursorLocationEnum.adUseClient
		cnWos2.Open(strConn)
		rsEquipList = New ADODB.Recordset
		
		rsEquipList.Open(strSQL, cnWos2, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockReadOnly, ADODB.CommandTypeEnum.adCmdText)
		EquipList = rsEquipList
		
		'UPGRADE_NOTE: Object rsEquipList may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC/commoner/redir/redirect.htm?keyword="vbup1029"'
		rsEquipList = Nothing
		Exit Function
errorhandler: 
		Err.Raise(Err.Number, "WOS: modTask - EquipList", Err.Description)
	End Function
End Module