Imports ChartEngine

Public Class ChartCustomizerForm
    Inherits System.Windows.Forms.Form

    Private chartData As chartData
    Private chartControl As Control

    Public Sub New(ByVal newChartData As chartData, ByVal newControl As Control)
        MyBase.New()

        Me.chartData = newChartData
        Me.chartControl = newControl

        'This call is required by the Win Form Designer.
        InitializeComponent()

        PopulateListbox()

        'If (chartData.Lines.Count > 0) Then
        'PropertyGrid1.SelectedObject = chartData.Lines(0)
        'End If

    End Sub

    'Populate the List box with the available chart lines
    Private Sub PopulateListbox()
        ListBox1.DataSource = chartData.Lines
        ListBox1.DisplayMember = "Title"
    End Sub

    'Event Handlers
    Private Sub ButtonApply_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonApply.Click
        chartControl.Invalidate()
    End Sub

    Private Sub ButtonCancel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonCancel.Click
        Me.Close()
    End Sub

    Private Sub ButtonOK_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonOK.Click
        chartControl.Invalidate()
        Me.Close()
    End Sub

    Private Sub ChartCustomizerForm_Closed(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Click
        chartControl.Invalidate()
    End Sub

    Private Sub ListBox1_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ListBox1.Click
        PropertyGrid1.SelectedObject = ListBox1.SelectedItem
    End Sub


    'Form overrides dispose to clean up the component list.
    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing Then
            If Not (components Is Nothing) Then
                components.Dispose()
            End If
        End If
        MyBase.Dispose(disposing)
    End Sub

#Region " Windows Form Designer generated code "

    Friend WithEvents ButtonOK As System.Windows.Forms.Button
    Friend WithEvents ButtonApply As System.Windows.Forms.Button
    Friend WithEvents ListBox1 As System.Windows.Forms.ListBox
    Friend WithEvents ButtonCancel As System.Windows.Forms.Button
    Friend WithEvents PropertyGrid1 As System.Windows.Forms.PropertyGrid


    'Required by the Windows Form Designer
    Private components As System.ComponentModel.Container

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.PropertyGrid1 = New System.Windows.Forms.PropertyGrid()
        Me.ButtonApply = New System.Windows.Forms.Button()
        Me.ListBox1 = New System.Windows.Forms.ListBox()
        Me.ButtonCancel = New System.Windows.Forms.Button()
        Me.ButtonOK = New System.Windows.Forms.Button()
        Me.PropertyGrid1.SuspendLayout()
        Me.SuspendLayout()
        '
        'PropertyGrid1
        '
        Me.PropertyGrid1.Anchor = (((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right)
        Me.PropertyGrid1.CommandsVisibleIfAvailable = True
        Me.PropertyGrid1.LargeButtons = False
        Me.PropertyGrid1.LineColor = System.Drawing.SystemColors.ScrollBar
        Me.PropertyGrid1.Location = New System.Drawing.Point(139, 8)
        Me.PropertyGrid1.Name = "PropertyGrid1"
        Me.PropertyGrid1.Size = New System.Drawing.Size(192, 272)
        Me.PropertyGrid1.TabIndex = 0
        Me.PropertyGrid1.Text = "PropertyGrid"
        Me.PropertyGrid1.ViewBackColor = System.Drawing.SystemColors.Window
        Me.PropertyGrid1.ViewForeColor = System.Drawing.SystemColors.WindowText
        '
        'ButtonApply
        '
        Me.ButtonApply.Anchor = (System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right)
        Me.ButtonApply.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.ButtonApply.Location = New System.Drawing.Point(256, 296)
        Me.ButtonApply.Name = "ButtonApply"
        Me.ButtonApply.Size = New System.Drawing.Size(72, 24)
        Me.ButtonApply.TabIndex = 3
        Me.ButtonApply.Text = "&Apply"
        '
        'ListBox1
        '
        Me.ListBox1.Anchor = ((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left)
        Me.ListBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.ListBox1.IntegralHeight = False
        Me.ListBox1.Location = New System.Drawing.Point(8, 8)
        Me.ListBox1.Name = "ListBox1"
        Me.ListBox1.Size = New System.Drawing.Size(120, 272)
        Me.ListBox1.TabIndex = 2
        '
        'ButtonCancel
        '
        Me.ButtonCancel.Anchor = (System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right)
        Me.ButtonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.ButtonCancel.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.ButtonCancel.Location = New System.Drawing.Point(168, 296)
        Me.ButtonCancel.Name = "ButtonCancel"
        Me.ButtonCancel.Size = New System.Drawing.Size(72, 24)
        Me.ButtonCancel.TabIndex = 1
        Me.ButtonCancel.Text = "Cancel"
        '
        'ButtonOK
        '
        Me.ButtonOK.Anchor = (System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right)
        Me.ButtonOK.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.ButtonOK.Location = New System.Drawing.Point(80, 296)
        Me.ButtonOK.Name = "ButtonOK"
        Me.ButtonOK.Size = New System.Drawing.Size(72, 24)
        Me.ButtonOK.TabIndex = 4
        Me.ButtonOK.Text = "&OK"
        '
        'ChartCustomizerForm
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(344, 333)
        Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.ButtonOK, Me.ButtonCancel, Me.ButtonApply, Me.ListBox1, Me.PropertyGrid1})
        Me.Name = "ChartCustomizerForm"
        Me.Text = "ChartCustomizerForm"
        Me.PropertyGrid1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region


End Class

