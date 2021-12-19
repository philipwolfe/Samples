Imports System
Imports System.Drawing
Imports System.Collections
Imports System.ComponentModel
Imports System.WinForms
Imports Charting
Imports ChartEngine

Public Class ChartHost
    Inherits System.WinForms.Form
    
    
    Public Sub New()
        MyBase.New()
        InitializeComponent()
        
    End Sub
    
    Public Overrides Sub Dispose()
        MyBase.Dispose()
        components.Dispose()
    End Sub
    
    Private components As System.ComponentModel.Container
    Private ChartPanel1 As Charting.ChartPanel
    
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.ChartPanel1 = New Charting.ChartPanel()
        
        ChartPanel1.Location = New Point(32, 16)
        ChartPanel1.Text = "Control1"
        ChartPanel1.Size = New Size(700, 384)
        ChartPanel1.TabIndex = 0
        ChartPanel1.AutoScrollMinSize = New Size(0, 0)
        ChartPanel1.Anchor = AnchorStyles.All
        
        Me.AutoScaleBaseSize = New System.Drawing.Size(8, 19)
        '@design this.TrayLargeIcon = false
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.World)
        '@design this.TrayHeight = 0
        Me.ClientSize = New System.Drawing.Size(740, 400)
        Me.BackColor = System.Drawing.Color.Beige
        Me.Text = "Pig Iron Production"
        
        Me.Controls.Add(ChartPanel1)
        
    End Sub
End Class

