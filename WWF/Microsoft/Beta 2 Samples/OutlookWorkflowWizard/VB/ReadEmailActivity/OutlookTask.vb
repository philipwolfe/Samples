'---------------------------------------------------------------------
'  This file is part of the Windows Workflow Foundation SDK Code Samples.
' 
'  Copyright (C) Microsoft Corporation.  All rights reserved.
' 
'This source code is intended only as a supplement to Microsoft
'Development Tools and/or on-line documentation.  See these other
'materials for detailed information regarding Microsoft code samples.
' 
'THIS CODE AND INFORMATION ARE PROVIDED AS IS WITHOUT WARRANTY OF ANY
'KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE
'IMPLIED WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A
'PARTICULAR PURPOSE.
'---------------------------------------------------------------------

Imports System
Imports System.Workflow.ComponentModel
Imports System.Windows.Forms
Imports Outlook = Microsoft.Office.Interop.Outlook

Partial Public class OutlookTask
    Inherits BaseOutlookItem
    Public Sub New()
        MyBase.New()
        InitializeComponent()
    End Sub

    Protected Overrides Function Execute(ByVal executionContext As System.Workflow.ComponentModel.ActivityExecutionContext) As System.Workflow.ComponentModel.ActivityExecutionStatus
        MessageBox.Show("Creating Outlook Task")

        ' Create an Outlook Application object. 
        Dim outlookApp As Outlook.Application = New Outlook.Application()
        ' Create a new TaskItem.
        Dim NewTask As Outlook.TaskItem = CType(outlookApp.CreateItem(Outlook.OlItemType.olTaskItem), Outlook.TaskItem)
        ' Configure the task at hand and save it.
        NewTask.Body = "Workflow Generated Task"
        NewTask.DueDate = DateTime.Now
        NewTask.Importance = Outlook.OlImportance.olImportanceHigh
        NewTask.Subject = "Same Email Subject"
        NewTask.Save()

        Return ActivityExecutionStatus.Closed
    End Function
End Class
