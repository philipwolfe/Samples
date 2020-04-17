'--------------------------------------------------------------------------------
' This file is a "Sample" as from Windows Workflow Foundation
' Hands on Labs RC
'
' Copyright (c) Microsoft Corporation. All rights reserved.
'
' This source code is intended only as a supplement to Microsoft
' Development Tools and/or on-line documentation.  See these other
' materials for detailed information regarding Microsoft code samples.
' 
' THIS CODE AND INFORMATION ARE PROVIDED AS IS WITHOUT WARRANTY OF ANY
' KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE
' IMPLIED WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A
' PARTICULAR PURPOSE.
'--------------------------------------------------------------------------------

'--------------------------------------------------------------------------------
' This file is a "Sample" as from Windows Workflow Foundation
' Hands on Labs RC
'
' Copyright (c) Microsoft Corporation. All rights reserved.
'
' This source code is intended only as a supplement to Microsoft
' Development Tools and/or on-line documentation.  See these other
' materials for detailed information regarding Microsoft code samples.
' 
' THIS CODE AND INFORMATION ARE PROVIDED AS IS WITHOUT WARRANTY OF ANY
' KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE
' IMPLIED WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A
' PARTICULAR PURPOSE.
'--------------------------------------------------------------------------------

Imports System.Drawing.Drawing2D

'NOTE: When changing the namespace; please update XmlnsDefinitionAttribute in AssemblyInfo.vb
<ActivityDesignerThemeAttribute(GetType(CustomActivityDesignerTheme))> _
Public Class CustomActivityDesigner
    Inherits ActivityDesigner
End Class

NotInheritable Class CustomActivityDesignerTheme
    Inherits ActivityDesignerTheme

    Public Sub New(ByVal theme As WorkflowTheme)
        MyBase.New(theme)
        Me.BorderColor = Color.GreenYellow
        Me.BorderStyle = DashStyle.Solid
        Me.BackColorStart = Color.Green
        Me.BackColorEnd = Color.Yellow
        Me.BackgroundStyle = LinearGradientMode.Vertical
    End Sub
End Class

<ToolboxItemAttribute(GetType(ActivityToolboxItem)), _
 Designer(GetType(CustomActivityDesigner), GetType(IDesigner)), _
 ToolboxBitmap(GetType(GetManager), "Resources.FindManager.bmp")> _
Public Class GetManager
    Inherits System.Workflow.ComponentModel.Activity

    Public Shared ReportEmployeeIdProperty As DependencyProperty = DependencyProperty.Register("ReportEmployeeId", GetType(System.String), GetType(ExpenseActivities.GetManager))

    Public Shared ManagerEmployeeIdProperty As DependencyProperty = DependencyProperty.Register("ManagerEmployeeId", GetType(System.String), GetType(ExpenseActivities.GetManager))

    <DesignerSerializationVisibilityAttribute(DesignerSerializationVisibility.Visible), _
     BrowsableAttribute(True)> _
    Public Property ReportEmployeeId() As String
        Get
            Return CType(MyBase.GetValue(ExpenseActivities.GetManager.ReportEmployeeIdProperty), String)
        End Get
        Set(ByVal value As String)
            MyBase.SetValue(ExpenseActivities.GetManager.ReportEmployeeIdProperty, value)
        End Set
    End Property

    <DesignerSerializationVisibilityAttribute(DesignerSerializationVisibility.Visible), _
     BrowsableAttribute(True)> _
    Public Property ManagerEmployeeId() As String
        Get
            Return CType(MyBase.GetValue(ExpenseActivities.GetManager.ManagerEmployeeIdProperty), String)
        End Get
        Set(ByVal value As String)
            MyBase.SetValue(ExpenseActivities.GetManager.ManagerEmployeeIdProperty, value)
        End Set
    End Property

    Protected Overrides Function Execute(ByVal executionContext As ActivityExecutionContext) As ActivityExecutionStatus
        MyBase.Execute(executionContext)
        CType(executionContext.Activity, GetManager).ManagerEmployeeId = "neilhut"
        Return ActivityExecutionStatus.Closed
    End Function
End Class

