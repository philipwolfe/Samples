<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
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
        Me.CalcAreaButton = New System.Windows.Forms.Button
        Me.CalcAreaLabel = New System.Windows.Forms.Label
        Me.CalcAreaCallBackButton = New System.Windows.Forms.Button
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.AreaLabel = New System.Windows.Forms.Label
        Me.TopLeftXUpDown = New System.Windows.Forms.NumericUpDown
        Me.TopLeftYUpDown = New System.Windows.Forms.NumericUpDown
        Me.BottomRightYUpDown = New System.Windows.Forms.NumericUpDown
        Me.BottomRightXUpDown = New System.Windows.Forms.NumericUpDown
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        CType(Me.TopLeftXUpDown, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TopLeftYUpDown, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BottomRightYUpDown, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BottomRightXUpDown, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'CalcAreaButton
        '
        Me.CalcAreaButton.Location = New System.Drawing.Point(33, 161)
        Me.CalcAreaButton.Name = "CalcAreaButton"
        Me.CalcAreaButton.Size = New System.Drawing.Size(106, 23)
        Me.CalcAreaButton.TabIndex = 18
        Me.CalcAreaButton.Text = "Calc Area"
        Me.CalcAreaButton.UseVisualStyleBackColor = True
        '
        'CalcAreaLabel
        '
        Me.CalcAreaLabel.AutoSize = True
        Me.CalcAreaLabel.Location = New System.Drawing.Point(145, 166)
        Me.CalcAreaLabel.Name = "CalcAreaLabel"
        Me.CalcAreaLabel.Size = New System.Drawing.Size(13, 13)
        Me.CalcAreaLabel.TabIndex = 19
        Me.CalcAreaLabel.Text = "0"
        '
        'CalcAreaCallBackButton
        '
        Me.CalcAreaCallBackButton.Location = New System.Drawing.Point(33, 219)
        Me.CalcAreaCallBackButton.Name = "CalcAreaCallBackButton"
        Me.CalcAreaCallBackButton.Size = New System.Drawing.Size(106, 23)
        Me.CalcAreaCallBackButton.TabIndex = 20
        Me.CalcAreaCallBackButton.Text = "Calc Area Callback"
        Me.CalcAreaCallBackButton.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(30, 13)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(55, 13)
        Me.Label1.TabIndex = 22
        Me.Label1.Text = "TopLeft:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(310, 98)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(72, 13)
        Me.Label2.TabIndex = 23
        Me.Label2.Text = "BottomLeft:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(18, 22)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(37, 13)
        Me.Label3.TabIndex = 24
        Me.Label3.Text = "Area:"
        '
        'AreaLabel
        '
        Me.AreaLabel.AutoSize = True
        Me.AreaLabel.Location = New System.Drawing.Point(57, 22)
        Me.AreaLabel.Name = "AreaLabel"
        Me.AreaLabel.Size = New System.Drawing.Size(13, 13)
        Me.AreaLabel.TabIndex = 25
        Me.AreaLabel.Text = "0"
        '
        'TopLeftXUpDown
        '
        Me.TopLeftXUpDown.Location = New System.Drawing.Point(87, 11)
        Me.TopLeftXUpDown.Name = "TopLeftXUpDown"
        Me.TopLeftXUpDown.Size = New System.Drawing.Size(40, 20)
        Me.TopLeftXUpDown.TabIndex = 26
        '
        'TopLeftYUpDown
        '
        Me.TopLeftYUpDown.Location = New System.Drawing.Point(132, 11)
        Me.TopLeftYUpDown.Name = "TopLeftYUpDown"
        Me.TopLeftYUpDown.Size = New System.Drawing.Size(40, 20)
        Me.TopLeftYUpDown.TabIndex = 27
        '
        'BottomRightYUpDown
        '
        Me.BottomRightYUpDown.Location = New System.Drawing.Point(430, 96)
        Me.BottomRightYUpDown.Name = "BottomRightYUpDown"
        Me.BottomRightYUpDown.Size = New System.Drawing.Size(40, 20)
        Me.BottomRightYUpDown.TabIndex = 29
        '
        'BottomRightXUpDown
        '
        Me.BottomRightXUpDown.Location = New System.Drawing.Point(384, 96)
        Me.BottomRightXUpDown.Name = "BottomRightXUpDown"
        Me.BottomRightXUpDown.Size = New System.Drawing.Size(40, 20)
        Me.BottomRightXUpDown.TabIndex = 28
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.SystemColors.Window
        Me.Panel1.Controls.Add(Me.Label3)
        Me.Panel1.Controls.Add(Me.AreaLabel)
        Me.Panel1.Location = New System.Drawing.Point(178, 30)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(132, 65)
        Me.Panel1.TabIndex = 30
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(30, 145)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(354, 13)
        Me.Label4.TabIndex = 31
        Me.Label4.Text = "Send Rectangle to Unmanaged DLL method that returns calculated Area."
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(30, 203)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(419, 13)
        Me.Label5.TabIndex = 32
        Me.Label5.Text = "Send Rectangle to Unmanaged DLL method and have callback return calculated Area."
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(492, 286)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.BottomRightYUpDown)
        Me.Controls.Add(Me.BottomRightXUpDown)
        Me.Controls.Add(Me.TopLeftYUpDown)
        Me.Controls.Add(Me.TopLeftXUpDown)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.CalcAreaCallBackButton)
        Me.Controls.Add(Me.CalcAreaLabel)
        Me.Controls.Add(Me.CalcAreaButton)
        Me.Name = "Form1"
        Me.Text = "Form1"
        CType(Me.TopLeftXUpDown, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TopLeftYUpDown, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BottomRightYUpDown, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BottomRightXUpDown, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents CalcAreaButton As System.Windows.Forms.Button
    Friend WithEvents CalcAreaLabel As System.Windows.Forms.Label
    Friend WithEvents CalcAreaCallBackButton As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents AreaLabel As System.Windows.Forms.Label
    Friend WithEvents TopLeftXUpDown As System.Windows.Forms.NumericUpDown
    Friend WithEvents TopLeftYUpDown As System.Windows.Forms.NumericUpDown
    Friend WithEvents BottomRightYUpDown As System.Windows.Forms.NumericUpDown
    Friend WithEvents BottomRightXUpDown As System.Windows.Forms.NumericUpDown
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label

End Class
