Option Strict Off
Option Explicit On
Module modWorkOrder
	
	Public cnWos As ADODB.Connection
	Public rsWO As ADODB.Recordset
	
	Public Function ValidateWO() As Short
		Dim intLen As Short
		Dim MyControl As System.Windows.Forms.Control
		Dim ans As Short
		Dim strName As String
		Dim intPass As Short
		
		On Error GoTo errorhandler
		
		intPass = 0
		
		For	Each MyControl In frmWorkOrder.DefInstance.Controls
			'UPGRADE_WARNING: TypeName has a new behavior. Click for more: 'ms-help://MS.VSCC/commoner/redir/redirect.htm?keyword="vbup1041"'
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
				'UPGRADE_WARNING: TypeName has a new behavior. Click for more: 'ms-help://MS.VSCC/commoner/redir/redirect.htm?keyword="vbup1041"'
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
		Err.Raise(Err.Number, "WOS: modWorkOrder - ValidateWO", Err.Description)
	End Function
	
	Public Function RecordsetWO(ByVal strSQL As String) As ADODB.Recordset
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
		
		rsWO = New ADODB.Recordset
		
		rsWO.Open(strSQL, cnWos, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic, ADODB.CommandTypeEnum.adCmdText)
		
		RecordsetWO = rsWO
		
		'UPGRADE_NOTE: Object rsWO may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC/commoner/redir/redirect.htm?keyword="vbup1029"'
		rsWO = Nothing
		Exit Function
errorhandler: 
		Err.Raise(Err.Number, "WOS: modWorkOrder - RecordsetWO", Err.Description)
	End Function
End Module