<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Public Class Form1
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.listBoxDirectReports = New System.Windows.Forms.ListBox
        Me.SuspendLayout()
        '
        'listBoxDirectReports
        '
        Me.listBoxDirectReports.FormattingEnabled = True
        Me.listBoxDirectReports.HorizontalScrollbar = True
        Me.listBoxDirectReports.Location = New System.Drawing.Point(160, 148)
        Me.listBoxDirectReports.Name = "listBoxDirectReports"
        Me.listBoxDirectReports.Size = New System.Drawing.Size(222, 121)
        Me.listBoxDirectReports.Sorted = True
        Me.listBoxDirectReports.TabIndex = 3
        Me.listBoxDirectReports.Visible = False
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(542, 416)
        Me.Controls.Add(Me.listBoxDirectReports)
        Me.Name = "Form1"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Using the DataGridView Control"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents listBoxDirectReports As System.Windows.Forms.ListBox

End Class
