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

Imports System.Windows.Forms
Namespace WorkflowDesignerControl


    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Public Class WorkflowDesignerControl
        Inherits System.Windows.Forms.UserControl
        Implements IDisposable, IServiceProvider


        'Required by the Windows Form Designer
        Private components As System.ComponentModel.IContainer

        'NOTE: The following procedure is required by the Windows Form Designer
        'It can be modified using the Windows Form Designer.  
        'Do not modify it using the code editor.
        <System.Diagnostics.DebuggerStepThrough()> _
        Private Sub InitializeComponent()
            Me.pnlDesigner = New Panel
            Me.workflowViewSplitter = New SplitContainer
            Me.propertyGridSplitter = New SplitContainer
            Me.PropertyGrid = New PropertyGrid
            Me.pnlDesigner.SuspendLayout()
            Me.workflowViewSplitter.Panel2.SuspendLayout()
            Me.workflowViewSplitter.SuspendLayout()
            Me.propertyGridSplitter.Panel2.SuspendLayout()
            Me.propertyGridSplitter.SuspendLayout()
            MyBase.SuspendLayout()
            Me.pnlDesigner.BackColor = SystemColors.Control
            Me.pnlDesigner.Controls.Add(Me.workflowViewSplitter)
            Me.pnlDesigner.Dock = DockStyle.Fill
            Me.pnlDesigner.Location = New Point(0, 0)
            Me.pnlDesigner.Name = "pnlDesigner"
            Me.pnlDesigner.Size = New Size(&H2BB, &H18F)
            Me.pnlDesigner.TabIndex = 1
            Me.pnlDesigner.TabStop = True
            Me.workflowViewSplitter.BorderStyle = BorderStyle.FixedSingle
            Me.workflowViewSplitter.Dock = DockStyle.Fill
            Me.workflowViewSplitter.Location = New Point(0, 0)
            Me.workflowViewSplitter.Name = "workflowViewSplitter"
            Me.workflowViewSplitter.Orientation = Orientation.Horizontal
            Me.workflowViewSplitter.Panel1.BackColor = Color.FromArgb(&HFF, &HC0, &HC0)
            Me.workflowViewSplitter.Panel1MinSize = 300
            Me.workflowViewSplitter.Panel2.Controls.Add(Me.propertyGridSplitter)
            Me.workflowViewSplitter.Size = New Size(&H2BB, &H18F)
            Me.workflowViewSplitter.SplitterDistance = &H12D
            Me.workflowViewSplitter.TabIndex = 0
            Me.workflowViewSplitter.Text = "splitContainer1"
            Me.propertyGridSplitter.BorderStyle = BorderStyle.FixedSingle
            Me.propertyGridSplitter.Dock = DockStyle.Fill
            Me.propertyGridSplitter.Location = New Point(0, 0)
            Me.propertyGridSplitter.Name = "propertyGridSplitter"
            Me.propertyGridSplitter.Panel2.Controls.Add(Me.PropertyGrid)
            Me.propertyGridSplitter.Size = New Size(&H2BB, &H5E)
            Me.propertyGridSplitter.SplitterDistance = &H150
            Me.propertyGridSplitter.TabIndex = 1
            Me.propertyGridSplitter.Text = "splitContainer2"
            Me.PropertyGrid.CommandsVisibleIfAvailable = False
            Me.PropertyGrid.Dock = DockStyle.Fill
            Me.PropertyGrid.Font = New Font("Verdana", 8.25!, FontStyle.Regular, GraphicsUnit.Point, 0)
            Me.PropertyGrid.HelpVisible = False
            Me.PropertyGrid.LineColor = Color.LightSteelBlue
            Me.PropertyGrid.Location = New Point(0, 0)
            Me.PropertyGrid.Name = "propertyGrid"
            Me.PropertyGrid.PropertySort = PropertySort.Alphabetical
            Me.PropertyGrid.Size = New Size(&H165, &H5C)
            Me.PropertyGrid.TabIndex = 1
            Me.PropertyGrid.ToolbarVisible = False
            MyBase.BorderStyle = BorderStyle.FixedSingle
            MyBase.Controls.Add(Me.pnlDesigner)
            MyBase.Name = "WorkflowDesignerControl"
            MyBase.Size = New Size(&H2BB, &H18F)
            Me.pnlDesigner.ResumeLayout(False)
            Me.workflowViewSplitter.Panel2.ResumeLayout(False)
            Me.workflowViewSplitter.ResumeLayout(False)
            Me.propertyGridSplitter.Panel2.ResumeLayout(False)
            Me.propertyGridSplitter.ResumeLayout(False)
            MyBase.ResumeLayout(False)


        End Sub
        Friend WithEvents pnlDesigner As System.Windows.Forms.Panel
        Friend WithEvents workflowViewSplitter As System.Windows.Forms.SplitContainer
        Friend WithEvents propertyGridSplitter As System.Windows.Forms.SplitContainer
        Friend WithEvents PropertyGrid As System.Windows.Forms.PropertyGrid


    End Class
End Namespace