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

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class DesignerShell
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(DesignerShell))
        Me.toolStrip = New System.Windows.Forms.ToolStrip
        Me.zoomDropDown = New System.Windows.Forms.ToolStripDropDownButton
        Me.mni25PercentZoom = New System.Windows.Forms.ToolStripMenuItem
        Me.mni100PercentZoom = New System.Windows.Forms.ToolStripMenuItem
        Me.mni200PercentZoom = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator
        Me.btnDelete = New System.Windows.Forms.ToolStripButton
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator
        Me.btnOpen = New System.Windows.Forms.ToolStripButton
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator
        Me.btnSave = New System.Windows.Forms.ToolStripButton
        Me.ToolStripSeparator4 = New System.Windows.Forms.ToolStripSeparator
        Me.btnCompile = New System.Windows.Forms.ToolStripButton
        Me.ToolStripSeparator5 = New System.Windows.Forms.ToolStripSeparator
        Me.btnRun = New System.Windows.Forms.ToolStripButton
        Me.workflowDesignerControl = New WorkflowDesignerControl.WorkflowDesignerControl
        Me.toolStrip.SuspendLayout()
        Me.SuspendLayout()
        '
        'toolStrip
        '
        Me.toolStrip.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.toolStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.zoomDropDown, Me.ToolStripSeparator1, Me.btnDelete, Me.ToolStripSeparator2, Me.btnOpen, Me.ToolStripSeparator3, Me.btnSave, Me.ToolStripSeparator4, Me.btnCompile, Me.ToolStripSeparator5, Me.btnRun})
        Me.toolStrip.Location = New System.Drawing.Point(0, 0)
        Me.toolStrip.Name = "toolStrip"
        Me.toolStrip.RenderMode = System.Windows.Forms.ToolStripRenderMode.System
        Me.toolStrip.Size = New System.Drawing.Size(584, 25)
        Me.toolStrip.TabIndex = 0
        Me.toolStrip.Text = "ToolStrip1"
        '
        'zoomDropDown
        '
        Me.zoomDropDown.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.zoomDropDown.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mni25PercentZoom, Me.mni100PercentZoom, Me.mni200PercentZoom})
        Me.zoomDropDown.Image = CType(resources.GetObject("zoomDropDown.Image"), System.Drawing.Image)
        Me.zoomDropDown.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.zoomDropDown.Name = "zoomDropDown"
        Me.zoomDropDown.Size = New System.Drawing.Size(52, 22)
        Me.zoomDropDown.Text = "Zoom"
        '
        'mni25PercentZoom
        '
        Me.mni25PercentZoom.Name = "mni25PercentZoom"
        Me.mni25PercentZoom.Size = New System.Drawing.Size(102, 22)
        Me.mni25PercentZoom.Tag = "25"
        Me.mni25PercentZoom.Text = "25%"
        '
        'mni100PercentZoom
        '
        Me.mni100PercentZoom.Name = "mni100PercentZoom"
        Me.mni100PercentZoom.Size = New System.Drawing.Size(102, 22)
        Me.mni100PercentZoom.Tag = "100"
        Me.mni100PercentZoom.Text = "100%"
        '
        'mni200PercentZoom
        '
        Me.mni200PercentZoom.Name = "mni200PercentZoom"
        Me.mni200PercentZoom.Size = New System.Drawing.Size(102, 22)
        Me.mni200PercentZoom.Tag = "200"
        Me.mni200PercentZoom.Text = "200%"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 25)
        '
        'btnDelete
        '
        Me.btnDelete.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.btnDelete.Image = CType(resources.GetObject("btnDelete.Image"), System.Drawing.Image)
        Me.btnDelete.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnDelete.Name = "btnDelete"
        Me.btnDelete.Size = New System.Drawing.Size(97, 22)
        Me.btnDelete.Text = "Remove Activity"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 25)
        '
        'btnOpen
        '
        Me.btnOpen.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.btnOpen.Image = CType(resources.GetObject("btnOpen.Image"), System.Drawing.Image)
        Me.btnOpen.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnOpen.Name = "btnOpen"
        Me.btnOpen.Size = New System.Drawing.Size(40, 22)
        Me.btnOpen.Text = "Open"
        '
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        Me.ToolStripSeparator3.Size = New System.Drawing.Size(6, 25)
        '
        'btnSave
        '
        Me.btnSave.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.btnSave.Image = CType(resources.GetObject("btnSave.Image"), System.Drawing.Image)
        Me.btnSave.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(35, 22)
        Me.btnSave.Text = "Save"
        '
        'ToolStripSeparator4
        '
        Me.ToolStripSeparator4.Name = "ToolStripSeparator4"
        Me.ToolStripSeparator4.Size = New System.Drawing.Size(6, 25)
        '
        'btnCompile
        '
        Me.btnCompile.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.btnCompile.Image = CType(resources.GetObject("btnCompile.Image"), System.Drawing.Image)
        Me.btnCompile.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnCompile.Name = "btnCompile"
        Me.btnCompile.Size = New System.Drawing.Size(56, 22)
        Me.btnCompile.Text = "Compile"
        '
        'ToolStripSeparator5
        '
        Me.ToolStripSeparator5.Name = "ToolStripSeparator5"
        Me.ToolStripSeparator5.Size = New System.Drawing.Size(6, 25)
        '
        'btnRun
        '
        Me.btnRun.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.btnRun.Image = CType(resources.GetObject("btnRun.Image"), System.Drawing.Image)
        Me.btnRun.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnRun.Name = "btnRun"
        Me.btnRun.Size = New System.Drawing.Size(32, 22)
        Me.btnRun.Text = "Run"
        '
        'workflowDesignerControl
        '
        Me.workflowDesignerControl.BackColor = System.Drawing.SystemColors.Control
        Me.workflowDesignerControl.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.workflowDesignerControl.Dock = System.Windows.Forms.DockStyle.Fill
        Me.workflowDesignerControl.Location = New System.Drawing.Point(0, 25)
        Me.workflowDesignerControl.Name = "workflowDesignerControl"
        Me.workflowDesignerControl.Size = New System.Drawing.Size(584, 439)
        Me.workflowDesignerControl.TabIndex = 1
        Me.workflowDesignerControl.Xoml = resources.GetString("workflowDesignerControl.Xoml")
        Me.workflowDesignerControl.XomlFile = resources.GetString("workflowDesignerControl.XomlFile")
        '
        'DesignerShell
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(584, 464)
        Me.Controls.Add(Me.workflowDesignerControl)
        Me.Controls.Add(Me.toolStrip)
        Me.Name = "DesignerShell"
        Me.Text = "DesignerShell"
        Me.toolStrip.ResumeLayout(False)
        Me.toolStrip.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents toolStrip As System.Windows.Forms.ToolStrip
    Friend WithEvents workflowDesignerControl As WorkflowDesignerControl.WorkflowDesignerControl
    Friend WithEvents zoomDropDown As System.Windows.Forms.ToolStripDropDownButton
    Friend WithEvents mni25PercentZoom As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mni100PercentZoom As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mni200PercentZoom As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents btnDelete As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents btnOpen As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents btnSave As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator4 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents btnCompile As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator5 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents btnRun As System.Windows.Forms.ToolStripButton

End Class
