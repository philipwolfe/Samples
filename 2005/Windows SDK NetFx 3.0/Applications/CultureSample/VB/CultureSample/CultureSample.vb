 '-----------------------------------------------------------------------
'  This file is part of the Microsoft .NET SDK Code Samples.
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
'-----------------------------------------------------------------------
Imports System
Imports System.Drawing
Imports System.Collections
Imports System.ComponentModel
Imports System.Windows.Forms
Imports System.Globalization


'/ <summary>
'/ Main window for the application.
'/ </summary>

Public Class CultureBuilder
    Inherits System.Windows.Forms.Form
    #Region "Windows Form Designer declarations"
    Private toolStripTop As System.Windows.Forms.ToolStrip
    Private WithEvents newToolStripButton As System.Windows.Forms.ToolStripButton
    Private WithEvents mixToolStripButton As System.Windows.Forms.ToolStripButton
    Private WithEvents instanceToolStripButton As System.Windows.Forms.ToolStripButton
    Private panelDisplayCulture As System.Windows.Forms.Panel
    #End Region
    
    '/ <summary>
    '/ Required designer variable.
    '/ </summary>
    Private components As System.ComponentModel.Container = Nothing
    
    'Helper to pass on to the children windows
    Private helper As CultureInfoHelper
    
    
    Public Sub New() 
        '
        ' Required for Windows Form Designer support
        '
        InitializeComponent()
        Dim display As New DisplayCulture()
        helper = New CultureInfoHelper(display)
        display.LoadComboBox(helper.GetCultures(CultureTypes.AllCultures))
        panelDisplayCulture.Controls.Add(display)
    
    End Sub 'New
    
    
    '/ <summary>
    '/ Clean up any resources being used.
    '/ </summary>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean) 
        If disposing Then
            If Not (components Is Nothing) Then
                components.Dispose()
            End If
        End If
        MyBase.Dispose(disposing)
    
    End Sub 'Dispose
    
    #Region "Windows Form Designer generated code"
    
    '/ <summary>
    '/ Required method for Designer support - do not modify
    '/ the contents of this method with the code editor.
    '/ </summary>
    Private Sub InitializeComponent() 
        Me.toolStripTop = New System.Windows.Forms.ToolStrip()
        Me.newToolStripButton = New System.Windows.Forms.ToolStripButton()
        Me.mixToolStripButton = New System.Windows.Forms.ToolStripButton()
        Me.instanceToolStripButton = New System.Windows.Forms.ToolStripButton()
        Me.panelDisplayCulture = New System.Windows.Forms.Panel()
        Me.toolStripTop.SuspendLayout()
        Me.SuspendLayout()
        ' 
        ' toolStripTop
        ' 
        Me.toolStripTop.Cursor = System.Windows.Forms.Cursors.Default
        Me.toolStripTop.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.toolStripTop.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.newToolStripButton, Me.mixToolStripButton, Me.instanceToolStripButton})
        Me.toolStripTop.Location = New System.Drawing.Point(0, 0)
        Me.toolStripTop.Name = "toolStripTop"
        Me.toolStripTop.Size = New System.Drawing.Size(377, 25)
        Me.toolStripTop.TabIndex = 15
        Me.toolStripTop.Visible = True
        ' 
        ' newToolStripButton
        ' 
        Me.newToolStripButton.Name = "newToolStripButton"
        Me.newToolStripButton.Text = "New culture"
        ' 
        ' mixToolStripButton
        ' 
        Me.mixToolStripButton.Name = "mixToolStripButton"
        Me.mixToolStripButton.Text = "Mix cultures"
        ' 
        ' instanceToolStripButton
        ' 
        Me.instanceToolStripButton.Name = "instanceToolStripButton"
        Me.instanceToolStripButton.Text = "New instance"
        ' 
        ' panelDisplayCulture
        ' 
        Me.panelDisplayCulture.Location = New System.Drawing.Point(4, 26)
        Me.panelDisplayCulture.Name = "panelDisplayCulture"
        Me.panelDisplayCulture.Size = New System.Drawing.Size(369, 374)
        Me.panelDisplayCulture.TabIndex = 16
        ' 
        ' CultureBuilder
        ' 
        Me.ClientSize = New System.Drawing.Size(377, 403)
        Me.Controls.Add(panelDisplayCulture)
        Me.Controls.Add(toolStripTop)
        Me.Name = "CultureBuilder"
        Me.Text = "Culture Builder"
        Me.toolStripTop.ResumeLayout(False)
        Me.toolStripTop.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()
    
    End Sub 'InitializeComponent
    #End Region
    
    
    Private Sub newToolStripButton_Click(ByVal sender As Object, ByVal e As System.EventArgs)  Handles newToolStripButton.Click
        Dim newCultureForm As NewCulture
        newCultureForm = New NewCulture(helper)
        newCultureForm.Show()
    End Sub 'newToolStripButton_Click
    
    
    Private Sub mixToolStripButton_Click(ByVal sender As Object, ByVal e As System.EventArgs)  Handles mixToolStripButton.Click
        Dim mixCulturesForm As MixCultures
        mixCulturesForm = New MixCultures(helper)
        mixCulturesForm.Show()
    End Sub 'mixToolStripButton_Click
    
    
    Private Sub instanceToolStripButton_Click(ByVal sender As Object, ByVal e As System.EventArgs)  Handles instanceToolStripButton.Click
        Dim newInstanceForm As NewInstance
        newInstanceForm = New NewInstance(helper)
        newInstanceForm.Show()
    End Sub 'instanceToolStripButton_Click
End Class 'CultureBuilder