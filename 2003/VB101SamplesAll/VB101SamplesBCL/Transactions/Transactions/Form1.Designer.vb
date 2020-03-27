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
        Me.ClearDetails = New System.Windows.Forms.Button
        Me.IsTransactionSuccess = New System.Windows.Forms.CheckBox
        Me.label1 = New System.Windows.Forms.Label
        Me.transDetails = New System.Windows.Forms.TextBox
        Me.button1 = New System.Windows.Forms.Button
        Me.SuspendLayout()
        '
        'ClearDetails
        '
        Me.ClearDetails.Location = New System.Drawing.Point(200, 306)
        Me.ClearDetails.Name = "ClearDetails"
        Me.ClearDetails.Size = New System.Drawing.Size(84, 23)
        Me.ClearDetails.TabIndex = 9
        Me.ClearDetails.Text = "Clear Details"
        '
        'IsTransactionSuccess
        '
        Me.IsTransactionSuccess.AutoSize = True
        Me.IsTransactionSuccess.Checked = True
        Me.IsTransactionSuccess.CheckState = System.Windows.Forms.CheckState.Checked
        Me.IsTransactionSuccess.Location = New System.Drawing.Point(12, 276)
        Me.IsTransactionSuccess.Name = "IsTransactionSuccess"
        Me.IsTransactionSuccess.Size = New System.Drawing.Size(227, 17)
        Me.IsTransactionSuccess.TabIndex = 8
        Me.IsTransactionSuccess.Text = "Allow Transaction  to complete successfully"
        '
        'label1
        '
        Me.label1.AutoSize = True
        Me.label1.Location = New System.Drawing.Point(150, 5)
        Me.label1.Name = "label1"
        Me.label1.Size = New System.Drawing.Size(94, 13)
        Me.label1.TabIndex = 7
        Me.label1.Text = "Transaction Details"
        '
        'transDetails
        '
        Me.transDetails.Location = New System.Drawing.Point(12, 23)
        Me.transDetails.Multiline = True
        Me.transDetails.Name = "transDetails"
        Me.transDetails.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.transDetails.Size = New System.Drawing.Size(370, 237)
        Me.transDetails.TabIndex = 6
        '
        'button1
        '
        Me.button1.Location = New System.Drawing.Point(110, 306)
        Me.button1.Name = "button1"
        Me.button1.Size = New System.Drawing.Size(84, 23)
        Me.button1.TabIndex = 5
        Me.button1.Text = "Start"
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(406, 338)
        Me.Controls.Add(Me.ClearDetails)
        Me.Controls.Add(Me.IsTransactionSuccess)
        Me.Controls.Add(Me.label1)
        Me.Controls.Add(Me.transDetails)
        Me.Controls.Add(Me.button1)
        Me.Name = "Form1"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Transaction Sample"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ClearDetails As System.Windows.Forms.Button
    Friend WithEvents IsTransactionSuccess As System.Windows.Forms.CheckBox
    Friend WithEvents label1 As System.Windows.Forms.Label
    Friend WithEvents transDetails As System.Windows.Forms.TextBox
    Friend WithEvents button1 As System.Windows.Forms.Button

End Class
