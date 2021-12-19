Option Strict Off
Option Explicit On
Imports Microsoft.VisualBasic.Compatibility

Module DataEnvironment_DEnvWos_Module
	Public DEnvWos As DataEnvironment_DEnvWos = New DataEnvironment_DEnvWos()
End Module

<System.Runtime.InteropServices.ProgId("DataEnvironment_DEnvWos_NET.DataEnvironment_DEnvWos")> Public Class DataEnvironment_DEnvWos
	Inherits VB6.BaseDataEnvironment
	Public WithEvents conWOS As ADODB.Connection
	Public WithEvents rscomEquipList As ADODB.Recordset
	Private m_comEquipList As ADODB.Command
	Public WithEvents rsComWOList As ADODB.Recordset
	Private m_ComWOList As ADODB.Command
	Public WithEvents rscomTaskList As ADODB.Recordset
	Private m_comTaskList As ADODB.Command
	Public WithEvents rscomMeterReading As ADODB.Recordset
	Private m_comMeterReading As ADODB.Command
	Public WithEvents rsComWOList2 As ADODB.Recordset
	Private m_ComWOList2 As ADODB.Command
	Public Sub New()
		MyBase.New()
		Dim par As ADODB.Parameter
		
		
		conWOS = New ADODB.Connection()
		conWOS.ConnectionString = "PROVIDER=MSDataShape;DATA PROVIDER=MICROSOFT.JET.OLEDB.4.0;Data Source=C:\Program Files\WORK ORDER\WOS.mdb;Persist Security Info=False;"
		m_Connections.Add(conWOS, "conWOS")
		m_comEquipList = New ADODB.Command()
		rscomEquipList = New ADODB.Recordset()
		m_comEquipList.Name = "comEquipList"
		m_comEquipList.CommandText = "SELECT equipment.*, (select plant_name from plant where plant_id = equipment.plant_fk) AS plant_name" & Chr(13) & Chr(10) & "FROM equipment" & Chr(13) & Chr(10) & "WHERE ([equipment].[plant_fk]=InputValue And InputValue<>0) Or ([equipment].[plant_fk]<>0 And InputValue=0);" & Chr(13) & Chr(10)
		m_comEquipList.CommandType = ADODB.CommandTypeEnum.adCmdText
		par = m_comEquipList.CreateParameter
		par.Name = "InputValue"
		par.Type = ADODB.DataTypeEnum.adVarWChar
		par.Size = 510
		par.Direction = ADODB.ParameterDirectionEnum.adParamInput
		m_comEquipList.Parameters.Append(par)
		rscomEquipList.CursorLocation = ADODB.CursorLocationEnum.adUseClient
		rscomEquipList.CursorType = ADODB.CursorTypeEnum.adOpenStatic
		rscomEquipList.LockType = ADODB.LockTypeEnum.adLockReadOnly
		rscomEquipList.Source = m_comEquipList
		m_Commands.Add(m_comEquipList, "comEquipList")
		m_Recordsets.Add(rscomEquipList, "comEquipList")
		m_ComWOList = New ADODB.Command()
		rsComWOList = New ADODB.Recordset()
		m_ComWOList.Name = "ComWOList"
		m_ComWOList.CommandText = "SELECT equipment.equip_id, equip_key, equip_desc FROM (plant INNER JOIN (equipment INNER JOIN task ON equipment.equip_id = task.equip_id) ON plant.plant_id = equipment.plant_fk) INNER JOIN work_order ON task.task_id = work_order.task_id WHERE ((work_order.plant_fk = intPlantPass AND intPlantPass <> 0) OR (work_order.plant_fk <> 0 AND intPlantPass = 0)) AND ((strOpt = ""ALL"") OR (strOpt = ""Unschedule"" AND task.cycle_type = ""Unschedule"") OR (strOpt = ""DueDate"" AND task.cycle_type = ""Days Cycle"") OR (strOpt = ""DueMeter"" AND task.cycle_type = ""Meter Cycle"")) AND ((strEquipKey = ""XXXXXXXXXXX"") OR (strEquipKey <> ""XXXXXXXXXXX"" AND equipment.equip_key = strEquipKey)) AND ((strEquipDesc = ""XXXXXXXXXXX"") OR (strEquipDesc <> ""XXXXXXXXXXX"" AND equipment.equip_desc LIKE '%' & strEquipDesc & '%')) AND ((strTaskDesc = ""XXXXXXXXXXX"") OR (strTaskDesc <> ""XXXXXXXXXXX"" AND task.task_desc LIKE '%' & strTaskDesc & '%')) AND ((strTaskMiscComments = ""XXXXXXXXXXX"") OR (strTaskMiscComments <> ""XXXXXXXXXXX"" AND task.misc_comments LIKE '%' & strTaskMiscComments & '%')) AND ((strWOComments = ""XXXXXXXXXXX"") OR (strWOComments <> ""XXXXXXXXXXX"" AND work_order.comments LIKE '%' & strWOComments & '%')) AND ((strInitial = ""XXXXXXXXXXX"") OR (strInitial <> ""XXXXXXXXXXX"" AND work_order.completed_by LIKE '%' & strInitial & '%')) AND ((strDate1 = ""01/01/1955"") OR (strDate1 <> ""01/01/1955"" AND work_order.date_work_completed >= datevalue(strDate1))) AND ((strDate2 = ""01/01/2999"") OR (strDate2 <> ""01/01/2999"" AND work_order.date_work_completed <= datevalue(strDate2)))" & Chr(13) & Chr(10) & "ORDER BY equipment.equip_key;"
		m_ComWOList.CommandType = ADODB.CommandTypeEnum.adCmdText
		par = m_ComWOList.CreateParameter
		par.Name = "intPlantPass"
		par.Type = ADODB.DataTypeEnum.adVarWChar
		par.Size = 510
		par.Direction = ADODB.ParameterDirectionEnum.adParamInput
		m_ComWOList.Parameters.Append(par)
		par = m_ComWOList.CreateParameter
		par.Name = "strOpt"
		par.Type = ADODB.DataTypeEnum.adVarWChar
		par.Size = 510
		par.Direction = ADODB.ParameterDirectionEnum.adParamInput
		m_ComWOList.Parameters.Append(par)
		par = m_ComWOList.CreateParameter
		par.Name = "strEquipKey"
		par.Type = ADODB.DataTypeEnum.adVarWChar
		par.Size = 510
		par.Direction = ADODB.ParameterDirectionEnum.adParamInput
		m_ComWOList.Parameters.Append(par)
		par = m_ComWOList.CreateParameter
		par.Name = "strEquipDesc"
		par.Type = ADODB.DataTypeEnum.adVarWChar
		par.Size = 510
		par.Direction = ADODB.ParameterDirectionEnum.adParamInput
		m_ComWOList.Parameters.Append(par)
		par = m_ComWOList.CreateParameter
		par.Name = "strTaskDesc"
		par.Type = ADODB.DataTypeEnum.adVarWChar
		par.Size = 510
		par.Direction = ADODB.ParameterDirectionEnum.adParamInput
		m_ComWOList.Parameters.Append(par)
		par = m_ComWOList.CreateParameter
		par.Name = "strTaskMiscComments"
		par.Type = ADODB.DataTypeEnum.adVarWChar
		par.Size = 510
		par.Direction = ADODB.ParameterDirectionEnum.adParamInput
		m_ComWOList.Parameters.Append(par)
		par = m_ComWOList.CreateParameter
		par.Name = "strWOComments"
		par.Type = ADODB.DataTypeEnum.adVarWChar
		par.Size = 510
		par.Direction = ADODB.ParameterDirectionEnum.adParamInput
		m_ComWOList.Parameters.Append(par)
		par = m_ComWOList.CreateParameter
		par.Name = "strInitial"
		par.Type = ADODB.DataTypeEnum.adVarWChar
		par.Size = 510
		par.Direction = ADODB.ParameterDirectionEnum.adParamInput
		m_ComWOList.Parameters.Append(par)
		par = m_ComWOList.CreateParameter
		par.Name = "strDate1"
		par.Type = ADODB.DataTypeEnum.adVarWChar
		par.Size = 510
		par.Direction = ADODB.ParameterDirectionEnum.adParamInput
		m_ComWOList.Parameters.Append(par)
		par = m_ComWOList.CreateParameter
		par.Name = "strDate2"
		par.Type = ADODB.DataTypeEnum.adVarWChar
		par.Size = 510
		par.Direction = ADODB.ParameterDirectionEnum.adParamInput
		m_ComWOList.Parameters.Append(par)
		rsComWOList.CursorLocation = ADODB.CursorLocationEnum.adUseClient
		rsComWOList.CursorType = ADODB.CursorTypeEnum.adOpenStatic
		rsComWOList.LockType = ADODB.LockTypeEnum.adLockReadOnly
		rsComWOList.Source = m_ComWOList
		m_Commands.Add(m_ComWOList, "ComWOList")
		m_Recordsets.Add(rsComWOList, "ComWOList")
		m_comTaskList = New ADODB.Command()
		rscomTaskList = New ADODB.Recordset()
		m_comTaskList.Name = "comTaskList"
		m_comTaskList.CommandText = "SELECT task.*, (select plant_name from plant where plant_id = task.plant_fk) AS plant_name, (select equip_key from equipment where equip_id = task.equip_id) as equip_key, (select equip_desc from equipment where equip_id = task.equip_id) as equip_desc,  [equipment].[last_meter_reading], [equipment].[last_meter_reading_date]" & Chr(13) & Chr(10) & "FROM equipment INNER JOIN task ON [task].[equip_id]=[equipment].[equip_id]" & Chr(13) & Chr(10) & "WHERE ((intEquip = 0 and task.equip_id <> 0) or (task.equip_id = intEquip and intEquip <>0)) and " & Chr(13) & Chr(10) & "((intTask = 0 and task.task_id <> 0) or (task.task_id = intTask and intTask <>0)) and" & Chr(13) & Chr(10) & "((intPlantPass = 0 and task.plant_fk <> 0) or (task.plant_fk = intPlantPass and intPlantPass <>0)) and  ((strOption=""Unschedule"" And cycle_type=""Unschedule"") Or (strOption=""DueDate"" And cycle_type=""Days Cycle"" And work_due_date<=datevalue(strdate)) Or (strOption=""DueMeter"" And cycle_type=""Meter Cycle"" And [equipment].[last_meter_reading]>[task].[work_due_when_meter_reads]) Or strOption=""All"") And (([equipment].[equip_key]=strEquipKey And strEquipKey<>""XXXXXXXXXXX"") Or (strEquipKey=""XXXXXXXXXXX"")) And (([misc_comments] Like '*' & strMiscComments & '*' And strMiscComments<>""XXXXXXXXXX"") Or (strMiscComments=""XXXXXXXXXXX""));"
		m_comTaskList.CommandType = ADODB.CommandTypeEnum.adCmdText
		par = m_comTaskList.CreateParameter
		par.Name = "intEquip"
		par.Type = ADODB.DataTypeEnum.adVarWChar
		par.Size = 510
		par.Direction = ADODB.ParameterDirectionEnum.adParamInput
		m_comTaskList.Parameters.Append(par)
		par = m_comTaskList.CreateParameter
		par.Name = "intTask"
		par.Type = ADODB.DataTypeEnum.adVarWChar
		par.Size = 510
		par.Direction = ADODB.ParameterDirectionEnum.adParamInput
		m_comTaskList.Parameters.Append(par)
		par = m_comTaskList.CreateParameter
		par.Name = "intPlantPass"
		par.Type = ADODB.DataTypeEnum.adVarWChar
		par.Size = 510
		par.Direction = ADODB.ParameterDirectionEnum.adParamInput
		m_comTaskList.Parameters.Append(par)
		par = m_comTaskList.CreateParameter
		par.Name = "strOption"
		par.Type = ADODB.DataTypeEnum.adVarWChar
		par.Size = 510
		par.Direction = ADODB.ParameterDirectionEnum.adParamInput
		m_comTaskList.Parameters.Append(par)
		par = m_comTaskList.CreateParameter
		par.Name = "strdate"
		par.Type = ADODB.DataTypeEnum.adVarWChar
		par.Size = 510
		par.Direction = ADODB.ParameterDirectionEnum.adParamInput
		m_comTaskList.Parameters.Append(par)
		par = m_comTaskList.CreateParameter
		par.Name = "strEquipKey"
		par.Type = ADODB.DataTypeEnum.adVarWChar
		par.Size = 510
		par.Direction = ADODB.ParameterDirectionEnum.adParamInput
		m_comTaskList.Parameters.Append(par)
		par = m_comTaskList.CreateParameter
		par.Name = "strMiscComments"
		par.Type = ADODB.DataTypeEnum.adVarWChar
		par.Size = 510
		par.Direction = ADODB.ParameterDirectionEnum.adParamInput
		m_comTaskList.Parameters.Append(par)
		rscomTaskList.CursorLocation = ADODB.CursorLocationEnum.adUseClient
		rscomTaskList.CursorType = ADODB.CursorTypeEnum.adOpenStatic
		rscomTaskList.LockType = ADODB.LockTypeEnum.adLockReadOnly
		rscomTaskList.Source = m_comTaskList
		m_Commands.Add(m_comTaskList, "comTaskList")
		m_Recordsets.Add(rscomTaskList, "comTaskList")
		m_comMeterReading = New ADODB.Command()
		rscomMeterReading = New ADODB.Recordset()
		m_comMeterReading.Name = "comMeterReading"
		m_comMeterReading.CommandText = "SELECT plant_fk, equip_id, equip_key, equip_desc, last_meter_reading, last_meter_reading_date FROM equipment" & Chr(13) & Chr(10) & "where intPlantPass = 0 or (intPlantPass <> 0 and plant_fk = intPlantPass);"
		m_comMeterReading.CommandType = ADODB.CommandTypeEnum.adCmdText
		par = m_comMeterReading.CreateParameter
		par.Name = "intPlantPass"
		par.Type = ADODB.DataTypeEnum.adVarWChar
		par.Size = 510
		par.Direction = ADODB.ParameterDirectionEnum.adParamInput
		m_comMeterReading.Parameters.Append(par)
		rscomMeterReading.CursorLocation = ADODB.CursorLocationEnum.adUseClient
		rscomMeterReading.CursorType = ADODB.CursorTypeEnum.adOpenStatic
		rscomMeterReading.LockType = ADODB.LockTypeEnum.adLockReadOnly
		rscomMeterReading.Source = m_comMeterReading
		m_Commands.Add(m_comMeterReading, "comMeterReading")
		m_Recordsets.Add(rscomMeterReading, "comMeterReading")
		m_ComWOList2 = New ADODB.Command()
		rsComWOList2 = New ADODB.Recordset()
		m_ComWOList2.Name = "ComWOList2"
		m_ComWOList2.CommandText = "SELECT work_order.*, task.*, equipment.*, plant.* FROM (plant INNER JOIN (equipment INNER JOIN task ON equipment.equip_id = task.equip_id) ON plant.plant_id = equipment.plant_fk) INNER JOIN work_order ON task.task_id = work_order.task_id " & Chr(13) & Chr(10) & "ORDER BY equipment.equip_key ASC, work_order.date_work_completed ASC;" & Chr(13) & Chr(10)
		m_ComWOList2.CommandType = ADODB.CommandTypeEnum.adCmdText
		rsComWOList2.CursorLocation = ADODB.CursorLocationEnum.adUseClient
		rsComWOList2.CursorType = ADODB.CursorTypeEnum.adOpenStatic
		rsComWOList2.LockType = ADODB.LockTypeEnum.adLockReadOnly
		rsComWOList2.Source = m_ComWOList2
		m_Commands.Add(m_ComWOList2, "ComWOList2")
		m_Recordsets.Add(rsComWOList2, "ComWOList2")
	End Sub
	Public Sub comEquipList(ByVal InputValue As String)
		If conWOS.State = ADODB.ObjectStateEnum.adStateClosed Then
			conWOS.Open()
		End If
		If rscomEquipList.State = ADODB.ObjectStateEnum.adStateOpen Then
			rscomEquipList.Close()
		End If
		m_comEquipList.ActiveConnection = conWOS
		rscomEquipList.Open()
	End Sub
	Public Sub ComWOList(ByVal intPlantPass As String, ByVal strOpt As String, ByVal strEquipKey As String, ByVal strEquipDesc As String, ByVal strTaskDesc As String, ByVal strTaskMiscComments As String, ByVal strWOComments As String, ByVal strInitial As String, ByVal strDate1 As String, ByVal strDate2 As String)
		If conWOS.State = ADODB.ObjectStateEnum.adStateClosed Then
			conWOS.Open()
		End If
		If rsComWOList.State = ADODB.ObjectStateEnum.adStateOpen Then
			rsComWOList.Close()
		End If
		m_ComWOList.ActiveConnection = conWOS
		rsComWOList.Open()
	End Sub
	Public Sub comTaskList(ByVal intEquip As String, ByVal intTask As String, ByVal intPlantPass As String, ByVal strOption As String, ByVal strdate As String, ByVal strEquipKey As String, ByVal strMiscComments As String)
		If conWOS.State = ADODB.ObjectStateEnum.adStateClosed Then
			conWOS.Open()
		End If
		If rscomTaskList.State = ADODB.ObjectStateEnum.adStateOpen Then
			rscomTaskList.Close()
		End If
		m_comTaskList.ActiveConnection = conWOS
		rscomTaskList.Open()
	End Sub
	Public Sub comMeterReading(ByVal intPlantPass As String)
		If conWOS.State = ADODB.ObjectStateEnum.adStateClosed Then
			conWOS.Open()
		End If
		If rscomMeterReading.State = ADODB.ObjectStateEnum.adStateOpen Then
			rscomMeterReading.Close()
		End If
		m_comMeterReading.ActiveConnection = conWOS
		rscomMeterReading.Open()
	End Sub
	Public Sub ComWOList2()
		If conWOS.State = ADODB.ObjectStateEnum.adStateClosed Then
			conWOS.Open()
		End If
		If rsComWOList2.State = ADODB.ObjectStateEnum.adStateOpen Then
			rsComWOList2.Close()
		End If
		m_ComWOList2.ActiveConnection = conWOS
		rsComWOList2.Open()
	End Sub
End Class