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



'NOTE: When changing the namespace; please update XmlnsDefinitionAttribute in AssemblyInfo.vb
<ToolboxItemAttribute(GetType(ActivityToolboxItem)), _
 Designer(GetType(CustomActivityDesigner), GetType(IDesigner)), _
 ToolboxBitmap(GetType(GetManager), "Resources.Approved.bmp")> _
Public Class AutoApprove
    Inherits SequenceActivity

    Public Shared AmountProperty As DependencyProperty = System.Workflow.ComponentModel.DependencyProperty.Register("Amount", GetType(System.Int32), GetType(AutoApprove))

    Public Shared ApprovedProperty As DependencyProperty = System.Workflow.ComponentModel.DependencyProperty.Register("Approved", GetType(System.Boolean), GetType(AutoApprove))

    <Description("The amount of the expense report."), _
     Category("Some Category"), _
     Browsable(True), _
     DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)> _
    Public Property Amount() As Integer
        Get
            Return CType(MyBase.GetValue(AutoApprove.AmountProperty), Integer)
        End Get
        Set(ByVal value As Integer)
            MyBase.SetValue(AutoApprove.AmountProperty, value)
        End Set
    End Property

    <Description("Determines whether an expense report can be automatically approved."), _
     Category("Some Category"), _
     Browsable(True), _
     DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)> _
    Public Property Approved() As Boolean
        Get
            Return CType(MyBase.GetValue(AutoApprove.ApprovedProperty), Boolean)
        End Get
        Set(ByVal value As Boolean)
            MyBase.SetValue(AutoApprove.ApprovedProperty, value)
        End Set
    End Property
End Class

