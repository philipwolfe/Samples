'//------------------------------------------------------------------------------
'/// <copyright from='1997' to='2001' company='Microsoft Corporation'>           
'///    Copyright (c) Microsoft Corporation. All Rights Reserved.                
'///       
'///    This source code is intended only as a supplement to Microsoft
'///    Development Tools and/or on-line documentation.  See these other
'///    materials for detailed information regarding Microsoft code samples.
'///
'/// </copyright>                                                                
'//------------------------------------------------------------------------------

Imports System
Imports System.ComponentModel
Imports System.Drawing
Imports System.WinForms

Namespace Microsoft.Samples.WinForms.VB.Docking 

    Public Class Docking
        Inherits System.WinForms.Form

        'Required by the Windows Forms Designer   
        Private components As System.ComponentModel.Container
        private statusBarPanel2 as System.WinForms.StatusBarPanel
        private statusBarPanel1 as System.WinForms.StatusBarPanel 
        Private panel1 As System.WinForms.Panel
        Private statusBar1 As System.WinForms.StatusBar
    
        Public Sub New()
           MyBase.New
    
           'This call is required by the Windows Forms Designer.
           InitializeComponent
    
           ' TODO: Add any constructor code after InitializeComponent call

        End Sub

        'Clean up any resources being used
        Overrides Public Sub Dispose()
            MyBase.Dispose
            components.Dispose
        End Sub 

        'The main entry point for the application
        Shared Sub Main()
            System.WinForms.Application.Run(New Docking())
        End Sub

        'NOTE: The following procedure is required by the Windows Forms Designer
        'Do not modify it.
        Private Sub InitializeComponent() 
            Me.components = New System.ComponentModel.Container
            Me.statusBar1 = New System.WinForms.StatusBar
            Me.panel1 = New System.WinForms.Panel
            Me.statusBarPanel1 = new System.WinForms.StatusBarPanel
            Me.statusBarPanel2 = new System.WinForms.StatusBarPanel

            Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
            Me.Text = "Docking Example"
            Me.ClientSize = New System.Drawing.Size(496, 293)

            panel1.Dock = System.WinForms.DockStyle.Left
            panel1.AutoScrollMinSize = new System.Drawing.Size(0, 0)
            panel1.BackColor = System.Drawing.Color.RosyBrown
            panel1.Size = New System.Drawing.Size(248, 273)
            panel1.TabIndex = 0
            panel1.Text = "panel1"

            statusBar1.BackColor = System.Drawing.SystemColors.Control
            statusBar1.Location = New System.Drawing.Point(0, 273)
            statusBar1.Size = New System.Drawing.Size(496, 20)
            statusBar1.TabIndex = 1
            statusBar1.Text = "statusBar1"
            statusBar1.Panels.All = new System.WinForms.StatusBarPanel() {statusBarPanel1, statusBarPanel2}
            
            statusBarPanel1.Text = "Panel1"
            statusBarPanel1.AutoSize = StatusBarPanelAutoSize.Contents

            statusBarPanel2.Text = "Panel2"
            statusBarPanel2.AutoSize = StatusBarPanelAutoSize.Contents

            Me.Controls.Add(statusBar1)
            Me.Controls.Add(panel1)

        End Sub

    
    End Class

End Namespace
