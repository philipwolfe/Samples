Imports System
Imports System.Collections
Imports System.Core
Imports System.ComponentModel
Imports System.Drawing
Imports System.Data
Imports System.WinForms
Imports ChartEngine

    Public Class ChartCustomizerForm
        Inherits System.WinForms.Form

        'Required by the Win Form Designer
        Private components As System.ComponentModel.Container
    Private WithEvents buttonOK As System.WinForms.Button
    Private WithEvents buttonApply As System.WinForms.Button
    Private WithEvents listBox1 As System.WinForms.ListBox
    Private WithEvents buttonCancel As System.WinForms.Button
    Private WithEvents propertyGrid1 As System.WinForms.PropertyGrid

        Private chartData1 As ChartData
    Private WithEvents chartControl1 As RichControl

        Public Sub New(ByVal newChartData As ChartData, ByVal newControl As RichControl)
            MyBase.New()

            Me.chartData1 = newChartData
            Me.chartControl1 = newControl

            'This call is required by the Win Form Designer.
        InitializeComponent()
        
        AddHandler Me.Closed, (AddressOf Me.ChartCustomizerForm_Closed)

            'TODO: Add any initialization after the InitForm call
            PopulateListbox()
        End Sub

        'Populate the List box with the available chart lines
        Private Sub PopulateListbox()
            Dim cl As ChartLine
            For Each cl In chartData1.Lines
                listBox1.Items.Add(cl.Title)
            Next
            
            If (chartData1.Lines.Count > 0) Then
                listBox1.SelectedIndex = 0
            End If

        End Sub

        'Event Handlers
        Protected Sub buttonApply_Click(ByVal sender As Object, ByVal e As System.EventArgs)
            chartControl1.Invalidate()
        End Sub
        
        Protected Sub buttonCancel_Click(ByVal sender As Object, ByVal e As System.EventArgs)
            Me.Close()
        End Sub

        Protected Sub buttonOK_Click(ByVal sender As Object, ByVal e As System.EventArgs)
            chartControl1.Invalidate()
            Me.Close()
        End Sub
        
        Protected Sub ChartCustomizerForm_Closed(ByVal sender As Object, ByVal e As System.EventArgs)
            chartControl1.Invalidate()
        End Sub

        Protected Sub listBox1_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)
            propertyGrid1.SelectedObject = chartData1.Lines(listBox1.SelectedIndex)
        End Sub


        'Form overrides dispose to clean up the component list.
        Overrides Public Sub Dispose()
            MyBase.Dispose()
            components.Dispose()
        End Sub


        'NOTE: The following procedure is required by the Win Form Designer
        'It can be modified using the Win Form Designer.  
        'Do not modify it using the code editor.
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.buttonOK = New System.WinForms.Button()
        Me.listBox1 = New System.WinForms.ListBox()
        Me.buttonCancel = New System.WinForms.Button()
        Me.propertyGrid1 = New System.WinForms.PropertyGrid()
        Me.buttonApply = New System.WinForms.Button()
        
        '@design Me.TrayHeight = 0
        '@design Me.TrayLargeIcon = False
        '@design Me.TrayAutoArrange = True
        buttonOK.Location = New System.Drawing.Point(192, 432)
        buttonOK.FlatStyle = System.WinForms.FlatStyle.Popup
        buttonOK.Size = New System.Drawing.Size(72, 24)
        buttonOK.TabIndex = 4
        buttonOK.Anchor = System.WinForms.AnchorStyles.BottomRight
        buttonOK.Text = "&OK"
        
        listBox1.Location = New System.Drawing.Point(8, 8)
        listBox1.Size = New System.Drawing.Size(120, 384)
        listBox1.TabIndex = 2
        listBox1.Anchor = System.WinForms.AnchorStyles.TopBottomLeft
        
        buttonCancel.Location = New System.Drawing.Point(280, 432)
        buttonCancel.DialogResult = System.WinForms.DialogResult.Cancel
        buttonCancel.FlatStyle = System.WinForms.FlatStyle.Popup
        buttonCancel.Size = New System.Drawing.Size(72, 24)
        buttonCancel.TabIndex = 1
        buttonCancel.Anchor = System.WinForms.AnchorStyles.BottomRight
        buttonCancel.Text = "Cancel"
        
        propertyGrid1.Cursor = System.Drawing.Cursors.HSplit
        propertyGrid1.Text = "PropertyGrid"
        propertyGrid1.LineColor = System.Drawing.SystemColors.ScrollBar
        propertyGrid1.OutlineColor = System.Drawing.SystemColors.GrayText
        propertyGrid1.TextColor = System.Drawing.SystemColors.WindowText
        propertyGrid1.Size = New System.Drawing.Size(304, 408)
        propertyGrid1.SelectedObject = buttonApply
        propertyGrid1.LargeButtons = False
        propertyGrid1.ServiceObjectProvider = Nothing
        propertyGrid1.ActiveDocument = Nothing
        propertyGrid1.TabIndex = 0
        propertyGrid1.Anchor = System.WinForms.AnchorStyles.All
        propertyGrid1.Location = New System.Drawing.Point(139, 8)
        propertyGrid1.CommandsVisibleIfAvailable = True
        
        buttonApply.Location = New System.Drawing.Point(368, 432)
        buttonApply.FlatStyle = System.WinForms.FlatStyle.Popup
        buttonApply.Size = New System.Drawing.Size(72, 24)
        buttonApply.TabIndex = 3
        buttonApply.Anchor = System.WinForms.AnchorStyles.BottomRight
        buttonApply.Text = "&Apply"
        Me.AutoScaleBaseSize = New System.Drawing.Size(8, 19)
        Me.CancelButton = buttonCancel
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 16!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.World)
        Me.AcceptButton = buttonOK
        Me.ClientSize = New System.Drawing.Size(456, 469)
        
        Me.Controls.Add(buttonOK)
        Me.Controls.Add(propertyGrid1)
        Me.Controls.Add(listBox1)
        Me.Controls.Add(buttonApply)
        Me.Controls.Add(buttonCancel)
    End Sub
    
End Class
