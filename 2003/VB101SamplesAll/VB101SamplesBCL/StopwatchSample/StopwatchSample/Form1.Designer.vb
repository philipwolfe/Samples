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
        Me.components = New System.ComponentModel.Container
        Me.groupBox2 = New System.Windows.Forms.GroupBox
        Me.StopTimer = New System.Windows.Forms.Button
        Me.ElapsedTicks = New System.Windows.Forms.TextBox
        Me.ElapsedMilliseconds = New System.Windows.Forms.TextBox
        Me.ElapsedTimeSpan = New System.Windows.Forms.TextBox
        Me.label5 = New System.Windows.Forms.Label
        Me.label4 = New System.Windows.Forms.Label
        Me.label3 = New System.Windows.Forms.Label
        Me.StartNew = New System.Windows.Forms.Button
        Me.Reset = New System.Windows.Forms.Button
        Me.Start = New System.Windows.Forms.Button
        Me.groupBox1 = New System.Windows.Forms.GroupBox
        Me.SWTimeStamp = New System.Windows.Forms.TextBox
        Me.label2 = New System.Windows.Forms.Label
        Me.SWFrequency = New System.Windows.Forms.TextBox
        Me.label1 = New System.Windows.Forms.Label
        Me.checkBox1 = New System.Windows.Forms.CheckBox
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.groupBox2.SuspendLayout()
        Me.groupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'groupBox2
        '
        Me.groupBox2.Controls.Add(Me.StopTimer)
        Me.groupBox2.Controls.Add(Me.ElapsedTicks)
        Me.groupBox2.Controls.Add(Me.ElapsedMilliseconds)
        Me.groupBox2.Controls.Add(Me.ElapsedTimeSpan)
        Me.groupBox2.Controls.Add(Me.label5)
        Me.groupBox2.Controls.Add(Me.label4)
        Me.groupBox2.Controls.Add(Me.label3)
        Me.groupBox2.Controls.Add(Me.StartNew)
        Me.groupBox2.Controls.Add(Me.Reset)
        Me.groupBox2.Controls.Add(Me.Start)
        Me.groupBox2.Location = New System.Drawing.Point(12, 150)
        Me.groupBox2.Name = "groupBox2"
        Me.groupBox2.Size = New System.Drawing.Size(340, 171)
        Me.groupBox2.TabIndex = 4
        Me.groupBox2.TabStop = False
        Me.groupBox2.Text = "Instance properties and methods"
        '
        'StopTimer
        '
        Me.StopTimer.Location = New System.Drawing.Point(87, 121)
        Me.StopTimer.Name = "StopTimer"
        Me.StopTimer.Size = New System.Drawing.Size(75, 23)
        Me.StopTimer.TabIndex = 10
        Me.StopTimer.Text = "Stop"
        '
        'ElapsedTicks
        '
        Me.ElapsedTicks.Enabled = False
        Me.ElapsedTicks.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ElapsedTicks.Location = New System.Drawing.Point(137, 76)
        Me.ElapsedTicks.Name = "ElapsedTicks"
        Me.ElapsedTicks.Size = New System.Drawing.Size(164, 20)
        Me.ElapsedTicks.TabIndex = 9
        '
        'ElapsedMilliseconds
        '
        Me.ElapsedMilliseconds.Enabled = False
        Me.ElapsedMilliseconds.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ElapsedMilliseconds.Location = New System.Drawing.Point(137, 48)
        Me.ElapsedMilliseconds.Name = "ElapsedMilliseconds"
        Me.ElapsedMilliseconds.Size = New System.Drawing.Size(164, 20)
        Me.ElapsedMilliseconds.TabIndex = 8
        '
        'ElapsedTimeSpan
        '
        Me.ElapsedTimeSpan.Enabled = False
        Me.ElapsedTimeSpan.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ElapsedTimeSpan.Location = New System.Drawing.Point(137, 20)
        Me.ElapsedTimeSpan.Name = "ElapsedTimeSpan"
        Me.ElapsedTimeSpan.Size = New System.Drawing.Size(164, 20)
        Me.ElapsedTimeSpan.TabIndex = 7
        '
        'label5
        '
        Me.label5.AutoSize = True
        Me.label5.Location = New System.Drawing.Point(43, 80)
        Me.label5.Name = "label5"
        Me.label5.Size = New System.Drawing.Size(77, 13)
        Me.label5.TabIndex = 6
        Me.label5.Text = "Elapsed Ticks:"
        '
        'label4
        '
        Me.label4.AutoSize = True
        Me.label4.Location = New System.Drawing.Point(12, 52)
        Me.label4.Name = "label4"
        Me.label4.Size = New System.Drawing.Size(108, 13)
        Me.label4.TabIndex = 5
        Me.label4.Text = "Elapsed Milliseconds:"
        '
        'label3
        '
        Me.label3.AutoSize = True
        Me.label3.Location = New System.Drawing.Point(21, 24)
        Me.label3.Name = "label3"
        Me.label3.Size = New System.Drawing.Size(99, 13)
        Me.label3.TabIndex = 4
        Me.label3.Text = "Elapsed TimeSpan:"
        '
        'StartNew
        '
        Me.StartNew.Location = New System.Drawing.Point(249, 121)
        Me.StartNew.Name = "StartNew"
        Me.StartNew.Size = New System.Drawing.Size(75, 23)
        Me.StartNew.TabIndex = 3
        Me.StartNew.Text = "Start new"
        '
        'Reset
        '
        Me.Reset.Location = New System.Drawing.Point(168, 121)
        Me.Reset.Name = "Reset"
        Me.Reset.Size = New System.Drawing.Size(75, 23)
        Me.Reset.TabIndex = 2
        Me.Reset.Text = "Reset"
        '
        'Start
        '
        Me.Start.Location = New System.Drawing.Point(6, 121)
        Me.Start.Name = "Start"
        Me.Start.Size = New System.Drawing.Size(75, 23)
        Me.Start.TabIndex = 0
        Me.Start.Text = "Start"
        '
        'groupBox1
        '
        Me.groupBox1.Controls.Add(Me.SWTimeStamp)
        Me.groupBox1.Controls.Add(Me.label2)
        Me.groupBox1.Controls.Add(Me.SWFrequency)
        Me.groupBox1.Controls.Add(Me.label1)
        Me.groupBox1.Controls.Add(Me.checkBox1)
        Me.groupBox1.Location = New System.Drawing.Point(12, 12)
        Me.groupBox1.Name = "groupBox1"
        Me.groupBox1.Size = New System.Drawing.Size(340, 121)
        Me.groupBox1.TabIndex = 3
        Me.groupBox1.TabStop = False
        Me.groupBox1.Text = "Static properties and methods"
        '
        'SWTimeStamp
        '
        Me.SWTimeStamp.Enabled = False
        Me.SWTimeStamp.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.SWTimeStamp.Location = New System.Drawing.Point(155, 84)
        Me.SWTimeStamp.Name = "SWTimeStamp"
        Me.SWTimeStamp.Size = New System.Drawing.Size(146, 20)
        Me.SWTimeStamp.TabIndex = 4
        '
        'label2
        '
        Me.label2.AutoSize = True
        Me.label2.Location = New System.Drawing.Point(21, 84)
        Me.label2.Name = "label2"
        Me.label2.Size = New System.Drawing.Size(122, 13)
        Me.label2.TabIndex = 3
        Me.label2.Text = "Time Stamp (tick count):"
        '
        'SWFrequency
        '
        Me.SWFrequency.Enabled = False
        Me.SWFrequency.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.SWFrequency.Location = New System.Drawing.Point(155, 49)
        Me.SWFrequency.Name = "SWFrequency"
        Me.SWFrequency.Size = New System.Drawing.Size(146, 20)
        Me.SWFrequency.TabIndex = 2
        '
        'label1
        '
        Me.label1.AutoSize = True
        Me.label1.Location = New System.Drawing.Point(12, 53)
        Me.label1.Name = "label1"
        Me.label1.Size = New System.Drawing.Size(131, 13)
        Me.label1.TabIndex = 1
        Me.label1.Text = "Frequency (ticks/second):"
        '
        'checkBox1
        '
        Me.checkBox1.AutoSize = True
        Me.checkBox1.Enabled = False
        Me.checkBox1.Location = New System.Drawing.Point(15, 21)
        Me.checkBox1.Name = "checkBox1"
        Me.checkBox1.Size = New System.Drawing.Size(183, 17)
        Me.checkBox1.TabIndex = 0
        Me.checkBox1.Text = "System has High Resolution timer"
        '
        'Timer1
        '
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(364, 335)
        Me.Controls.Add(Me.groupBox2)
        Me.Controls.Add(Me.groupBox1)
        Me.Name = "Form1"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Stopwatch Sample"
        Me.groupBox2.ResumeLayout(False)
        Me.groupBox2.PerformLayout()
        Me.groupBox1.ResumeLayout(False)
        Me.groupBox1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents groupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents StopTimer As System.Windows.Forms.Button
    Friend WithEvents ElapsedTicks As System.Windows.Forms.TextBox
    Friend WithEvents ElapsedMilliseconds As System.Windows.Forms.TextBox
    Friend WithEvents ElapsedTimeSpan As System.Windows.Forms.TextBox
    Friend WithEvents label5 As System.Windows.Forms.Label
    Friend WithEvents label4 As System.Windows.Forms.Label
    Friend WithEvents label3 As System.Windows.Forms.Label
    Friend WithEvents StartNew As System.Windows.Forms.Button
    Friend WithEvents Reset As System.Windows.Forms.Button
    Friend WithEvents Start As System.Windows.Forms.Button
    Friend WithEvents groupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents SWTimeStamp As System.Windows.Forms.TextBox
    Friend WithEvents label2 As System.Windows.Forms.Label
    Friend WithEvents SWFrequency As System.Windows.Forms.TextBox
    Friend WithEvents label1 As System.Windows.Forms.Label
    Friend WithEvents checkBox1 As System.Windows.Forms.CheckBox
    Friend WithEvents Timer1 As System.Windows.Forms.Timer

End Class
