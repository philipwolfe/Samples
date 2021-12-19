Option Strict Off
Option Explicit On
Module modEquipment
	
	Public cnWos As ADODB.Connection
	Public rsEquip As ADODB.Recordset
	
	Public Function ValidateEquipment() As Short
		Dim intLen As Short
		Dim MyControl As System.Windows.Forms.Control
		Dim ans As Short
		Dim strName As String
		Dim intPass As Short
		
		On Error GoTo errorhandler
		
		intPass = 0
		
		For	Each MyControl In frmEquipment.DefInstance.Controls
			'UPGRADE_WARNING: TypeName has a new behavior. Click for more: 'ms-help://MS.VSCC/commoner/redir/redirect.htm?keyword="vbup1041"'
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
		Err.Raise(Err.Number, "WOS: modEquipment - ValidateEquipment", Err.Description)
	End Function
	
	Public Function RecordsetEquip(ByRef strSQL As String) As ADODB.Recordset
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
		
		rsEquip = New ADODB.Recordset
		rsEquip.Open(strSQL, cnWos, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic, ADODB.CommandTypeEnum.adCmdText)
		
		RecordsetEquip = rsEquip
		
		'UPGRADE_NOTE: Object rsEquip may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC/commoner/redir/redirect.htm?keyword="vbup1029"'
		rsEquip = Nothing
		Exit Function
errorhandler: 
		Err.Raise(Err.Number, "WOS: modEquipment - RecordsetEquip", Err.Description)
	End Function
End Module