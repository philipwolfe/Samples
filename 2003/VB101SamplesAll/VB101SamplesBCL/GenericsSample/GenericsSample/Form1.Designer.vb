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
        Me.groupBox1 = New System.Windows.Forms.GroupBox
        Me.AddUnsafeList = New System.Windows.Forms.Button
        Me.AddSafeList = New System.Windows.Forms.Button
        Me.label2 = New System.Windows.Forms.Label
        Me.label3 = New System.Windows.Forms.Label
        Me.label1 = New System.Windows.Forms.Label
        Me.safeObjectList = New System.Windows.Forms.CheckedListBox
        Me.unsafeObjectList = New System.Windows.Forms.CheckedListBox
        Me.masterObjectList = New System.Windows.Forms.CheckedListBox
        Me.groupBox3 = New System.Windows.Forms.GroupBox
        Me.IterateUnsafeListMs = New System.Windows.Forms.TextBox
        Me.LoadUnsafeListMs = New System.Windows.Forms.TextBox
        Me.iterateSafeListMs = New System.Windows.Forms.TextBox
        Me.LoadSafeListMs = New System.Windows.Forms.TextBox
        Me.label7 = New System.Windows.Forms.Label
        Me.label6 = New System.Windows.Forms.Label
        Me.label5 = New System.Windows.Forms.Label
        Me.label4 = New System.Windows.Forms.Label
        Me.startSpeedTest = New System.Windows.Forms.Button
        Me.groupBox2 = New System.Windows.Forms.GroupBox
        Me.exceptionLog = New System.Windows.Forms.TextBox
        Me.label8 = New System.Windows.Forms.Label
        Me.label9 = New System.Windows.Forms.Label
        Me.groupBox1.SuspendLayout()
        Me.groupBox3.SuspendLayout()
        Me.groupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'groupBox1
        '
        Me.groupBox1.Controls.Add(Me.label8)
        Me.groupBox1.Controls.Add(Me.AddUnsafeList)
        Me.groupBox1.Controls.Add(Me.AddSafeList)
        Me.groupBox1.Controls.Add(Me.label2)
        Me.groupBox1.Controls.Add(Me.label3)
        Me.groupBox1.Controls.Add(Me.label1)
        Me.groupBox1.Controls.Add(Me.safeObjectList)
        Me.groupBox1.Controls.Add(Me.unsafeObjectList)
        Me.groupBox1.Controls.Add(Me.masterObjectList)
        Me.groupBox1.Location = New System.Drawing.Point(12, 12)
        Me.groupBox1.Name = "groupBox1"
        Me.groupBox1.Size = New System.Drawing.Size(475, 262)
        Me.groupBox1.TabIndex = 17
        Me.groupBox1.TabStop = False
        Me.groupBox1.Text = "Type Safety"
        '
        'AddUnsafeList
        '
        Me.AddUnsafeList.Location = New System.Drawing.Point(141, 228)
        Me.AddUnsafeList.Name = "AddUnsafeList"
        Me.AddUnsafeList.Size = New System.Drawing.Size(118, 23)
        Me.AddUnsafeList.TabIndex = 14
        Me.AddUnsafeList.Text = "Add to unsafe List"
        '
        'AddSafeList
        '
        Me.AddSafeList.Location = New System.Drawing.Point(7, 228)
        Me.AddSafeList.Name = "AddSafeList"
        Me.AddSafeList.Size = New System.Drawing.Size(116, 23)
        Me.AddSafeList.TabIndex = 13
        Me.AddSafeList.Text = "Add to Safe List"
        '
        'label2
        '
        Me.label2.AutoSize = True
        Me.label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.label2.Location = New System.Drawing.Point(265, 15)
        Me.label2.Name = "label2"
        Me.label2.Size = New System.Drawing.Size(60, 13)
        Me.label2.TabIndex = 12
        Me.label2.Text = "Unsafe List"
        '
        'label3
        '
        Me.label3.AutoSize = True
        Me.label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.label3.Location = New System.Drawing.Point(265, 106)
        Me.label3.Name = "label3"
        Me.label3.Size = New System.Drawing.Size(48, 13)
        Me.label3.TabIndex = 5
        Me.label3.Text = "Safe List"
        '
        'label1
        '
        Me.label1.AutoSize = True
        Me.label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.label1.Location = New System.Drawing.Point(6, 15)
        Me.label1.Name = "label1"
        Me.label1.Size = New System.Drawing.Size(58, 13)
        Me.label1.TabIndex = 11
        Me.label1.Text = "Master List"
        '
        'safeObjectList
        '
        Me.safeObjectList.FormattingEnabled = True
        Me.safeObjectList.Location = New System.Drawing.Point(265, 123)
        Me.safeObjectList.Name = "safeObjectList"
        Me.safeObjectList.Size = New System.Drawing.Size(195, 64)
        Me.safeObjectList.TabIndex = 10
        '
        'unsafeObjectList
        '
        Me.unsafeObjectList.FormattingEnabled = True
        Me.unsafeObjectList.Location = New System.Drawing.Point(265, 33)
        Me.unsafeObjectList.Name = "unsafeObjectList"
        Me.unsafeObjectList.Size = New System.Drawing.Size(195, 64)
        Me.unsafeObjectList.TabIndex = 9
        '
        'masterObjectList
        '
        Me.masterObjectList.CheckOnClick = True
        Me.masterObjectList.FormattingEnabled = True
        Me.masterObjectList.Location = New System.Drawing.Point(6, 33)
        Me.masterObjectList.Name = "masterObjectList"
        Me.masterObjectList.Size = New System.Drawing.Size(253, 154)
        Me.masterObjectList.TabIndex = 8
        '
        'groupBox3
        '
        Me.groupBox3.Controls.Add(Me.label9)
        Me.groupBox3.Controls.Add(Me.IterateUnsafeListMs)
        Me.groupBox3.Controls.Add(Me.LoadUnsafeListMs)
        Me.groupBox3.Controls.Add(Me.iterateSafeListMs)
        Me.groupBox3.Controls.Add(Me.LoadSafeListMs)
        Me.groupBox3.Controls.Add(Me.label7)
        Me.groupBox3.Controls.Add(Me.label6)
        Me.groupBox3.Controls.Add(Me.label5)
        Me.groupBox3.Controls.Add(Me.label4)
        Me.groupBox3.Controls.Add(Me.startSpeedTest)
        Me.groupBox3.Location = New System.Drawing.Point(12, 280)
        Me.groupBox3.Name = "groupBox3"
        Me.groupBox3.Size = New System.Drawing.Size(475, 161)
        Me.groupBox3.TabIndex = 16
        Me.groupBox3.TabStop = False
        Me.groupBox3.Text = "Speed Test"
        '
        'IterateUnsafeListMs
        '
        Me.IterateUnsafeListMs.Location = New System.Drawing.Point(378, 95)
        Me.IterateUnsafeListMs.Name = "IterateUnsafeListMs"
        Me.IterateUnsafeListMs.Size = New System.Drawing.Size(51, 20)
        Me.IterateUnsafeListMs.TabIndex = 8
        '
        'LoadUnsafeListMs
        '
        Me.LoadUnsafeListMs.Location = New System.Drawing.Point(378, 65)
        Me.LoadUnsafeListMs.Name = "LoadUnsafeListMs"
        Me.LoadUnsafeListMs.Size = New System.Drawing.Size(51, 20)
        Me.LoadUnsafeListMs.TabIndex = 7
        '
        'iterateSafeListMs
        '
        Me.iterateSafeListMs.Location = New System.Drawing.Point(141, 95)
        Me.iterateSafeListMs.Name = "iterateSafeListMs"
        Me.iterateSafeListMs.Size = New System.Drawing.Size(51, 20)
        Me.iterateSafeListMs.TabIndex = 6
        '
        'LoadSafeListMs
        '
        Me.LoadSafeListMs.Location = New System.Drawing.Point(141, 65)
        Me.LoadSafeListMs.Name = "LoadSafeListMs"
        Me.LoadSafeListMs.Size = New System.Drawing.Size(51, 20)
        Me.LoadSafeListMs.TabIndex = 5
        '
        'label7
        '
        Me.label7.AutoSize = True
        Me.label7.Location = New System.Drawing.Point(261, 98)
        Me.label7.Name = "label7"
        Me.label7.Size = New System.Drawing.Size(115, 13)
        Me.label7.TabIndex = 4
        Me.label7.Text = "Iterate Unsafe List(ms):"
        '
        'label6
        '
        Me.label6.AutoSize = True
        Me.label6.Location = New System.Drawing.Point(267, 68)
        Me.label6.Name = "label6"
        Me.label6.Size = New System.Drawing.Size(109, 13)
        Me.label6.TabIndex = 3
        Me.label6.Text = "Load Unsafe List(ms):"
        '
        'label5
        '
        Me.label5.AutoSize = True
        Me.label5.Location = New System.Drawing.Point(33, 98)
        Me.label5.Name = "label5"
        Me.label5.Size = New System.Drawing.Size(103, 13)
        Me.label5.TabIndex = 2
        Me.label5.Text = "Iterate Safe List(ms):"
        '
        'label4
        '
        Me.label4.AutoSize = True
        Me.label4.Location = New System.Drawing.Point(39, 68)
        Me.label4.Name = "label4"
        Me.label4.Size = New System.Drawing.Size(97, 13)
        Me.label4.TabIndex = 1
        Me.label4.Text = "Load Safe List(ms):"
        '
        'startSpeedTest
        '
        Me.startSpeedTest.Location = New System.Drawing.Point(174, 132)
        Me.startSpeedTest.Name = "startSpeedTest"
        Me.startSpeedTest.Size = New System.Drawing.Size(117, 23)
        Me.startSpeedTest.TabIndex = 0
        Me.startSpeedTest.Text = "Start Speed test"
        '
        'groupBox2
        '
        Me.groupBox2.Controls.Add(Me.exceptionLog)
        Me.groupBox2.Location = New System.Drawing.Point(12, 447)
        Me.groupBox2.Name = "groupBox2"
        Me.groupBox2.Size = New System.Drawing.Size(475, 105)
        Me.groupBox2.TabIndex = 15
        Me.groupBox2.TabStop = False
        Me.groupBox2.Text = "Exception Log"
        '
        'exceptionLog
        '
        Me.exceptionLog.Location = New System.Drawing.Point(7, 19)
        Me.exceptionLog.Multiline = True
        Me.exceptionLog.Name = "exceptionLog"
        Me.exceptionLog.Size = New System.Drawing.Size(446, 80)
        Me.exceptionLog.TabIndex = 8
        '
        'label8
        '
        Me.label8.Location = New System.Drawing.Point(6, 191)
        Me.label8.Name = "label8"
        Me.label8.Size = New System.Drawing.Size(441, 35)
        Me.label8.TabIndex = 16
        Me.label8.Text = "Select items from the master list, and select add to safe list and add to unsafe " & _
            "list to see the type safety of generics."
        '
        'label9
        '
        Me.label9.Location = New System.Drawing.Point(77, 16)
        Me.label9.Name = "label9"
        Me.label9.Size = New System.Drawing.Size(337, 35)
        Me.label9.TabIndex = 17
        Me.label9.Text = "Select the ""Start Speed test"" button to see the speed difference between an Array" & _
            "List and a safe Genric container."
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(497, 564)
        Me.Controls.Add(Me.groupBox1)
        Me.Controls.Add(Me.groupBox3)
        Me.Controls.Add(Me.groupBox2)
        Me.Name = "Form1"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Generics Sample"
        Me.groupBox1.ResumeLayout(False)
        Me.groupBox1.PerformLayout()
        Me.groupBox3.ResumeLayout(False)
        Me.groupBox3.PerformLayout()
        Me.groupBox2.ResumeLayout(False)
        Me.groupBox2.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents groupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents AddUnsafeList As System.Windows.Forms.Button
    Friend WithEvents AddSafeList As System.Windows.Forms.Button
    Friend WithEvents label2 As System.Windows.Forms.Label
    Friend WithEvents label3 As System.Windows.Forms.Label
    Friend WithEvents label1 As System.Windows.Forms.Label
    Friend WithEvents safeObjectList As System.Windows.Forms.CheckedListBox
    Friend WithEvents unsafeObjectList As System.Windows.Forms.CheckedListBox
    Friend WithEvents masterObjectList As System.Windows.Forms.CheckedListBox
    Friend WithEvents groupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents IterateUnsafeListMs As System.Windows.Forms.TextBox
    Friend WithEvents LoadUnsafeListMs As System.Windows.Forms.TextBox
    Friend WithEvents iterateSafeListMs As System.Windows.Forms.TextBox
    Friend WithEvents LoadSafeListMs As System.Windows.Forms.TextBox
    Friend WithEvents label7 As System.Windows.Forms.Label
    Friend WithEvents label6 As System.Windows.Forms.Label
    Friend WithEvents label5 As System.Windows.Forms.Label
    Friend WithEvents label4 As System.Windows.Forms.Label
    Friend WithEvents startSpeedTest As System.Windows.Forms.Button
    Friend WithEvents groupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents exceptionLog As System.Windows.Forms.TextBox
    Private WithEvents label8 As System.Windows.Forms.Label
    Private WithEvents label9 As System.Windows.Forms.Label

End Class
