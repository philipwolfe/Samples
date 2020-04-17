Partial Class BasicDataEntry
    Inherits System.Windows.Forms.Form '

    Private components As System.ComponentModel.IContainer = Nothing

    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso Not (components Is Nothing) Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)

    End Sub 'Dispose


    Public Overrides Function ToString() As String
        Return "Basic Data Entry Form"

    End Function 'ToString

#Region "Windows Form Designer generated code"


    '/ <summary>
    '/ Required method for Designer support - do not modify
    '/ the contents of this method with the code editor.
    '/ </summary>
    Private Sub InitializeComponent()
        Me.tableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel
        Me.label1 = New System.Windows.Forms.Label
        Me.label2 = New System.Windows.Forms.Label
        Me.label3 = New System.Windows.Forms.Label
        Me.label4 = New System.Windows.Forms.Label
        Me.label5 = New System.Windows.Forms.Label
        Me.label6 = New System.Windows.Forms.Label
        Me.label9 = New System.Windows.Forms.Label
        Me.textBox2 = New System.Windows.Forms.TextBox
        Me.textBox3 = New System.Windows.Forms.TextBox
        Me.textBox4 = New System.Windows.Forms.TextBox
        Me.textBox5 = New System.Windows.Forms.TextBox
        Me.maskedTextBox1 = New System.Windows.Forms.MaskedTextBox
        Me.maskedTextBox2 = New System.Windows.Forms.MaskedTextBox
        Me.comboBox1 = New System.Windows.Forms.ComboBox
        Me.textBox1 = New System.Windows.Forms.TextBox
        Me.label7 = New System.Windows.Forms.Label
        Me.label8 = New System.Windows.Forms.Label
        Me.richTextBox1 = New System.Windows.Forms.RichTextBox
        Me.button1 = New System.Windows.Forms.Button
        Me.button2 = New System.Windows.Forms.Button
        Me.tableLayoutPanel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'tableLayoutPanel1
        '
        Me.tableLayoutPanel1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tableLayoutPanel1.ColumnCount = 4
        Me.tableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle)
        Me.tableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.tableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle)
        Me.tableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.tableLayoutPanel1.Controls.Add(Me.label1, 0, 0)
        Me.tableLayoutPanel1.Controls.Add(Me.label2, 2, 0)
        Me.tableLayoutPanel1.Controls.Add(Me.label3, 0, 1)
        Me.tableLayoutPanel1.Controls.Add(Me.label4, 0, 2)
        Me.tableLayoutPanel1.Controls.Add(Me.label5, 0, 3)
        Me.tableLayoutPanel1.Controls.Add(Me.label6, 2, 3)
        Me.tableLayoutPanel1.Controls.Add(Me.label9, 2, 4)
        Me.tableLayoutPanel1.Controls.Add(Me.textBox2, 1, 1)
        Me.tableLayoutPanel1.Controls.Add(Me.textBox3, 1, 2)
        Me.tableLayoutPanel1.Controls.Add(Me.textBox4, 1, 3)
        Me.tableLayoutPanel1.Controls.Add(Me.textBox5, 3, 0)
        Me.tableLayoutPanel1.Controls.Add(Me.maskedTextBox1, 1, 4)
        Me.tableLayoutPanel1.Controls.Add(Me.maskedTextBox2, 3, 4)
        Me.tableLayoutPanel1.Controls.Add(Me.comboBox1, 3, 3)
        Me.tableLayoutPanel1.Controls.Add(Me.textBox1, 1, 0)
        Me.tableLayoutPanel1.Controls.Add(Me.label7, 0, 5)
        Me.tableLayoutPanel1.Controls.Add(Me.label8, 0, 4)
        Me.tableLayoutPanel1.Controls.Add(Me.richTextBox1, 1, 5)
        Me.tableLayoutPanel1.Location = New System.Drawing.Point(13, 13)
        Me.tableLayoutPanel1.Name = "tableLayoutPanel1"
        Me.tableLayoutPanel1.RowCount = 6
        Me.tableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28.0!))
        Me.tableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28.0!))
        Me.tableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28.0!))
        Me.tableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28.0!))
        Me.tableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28.0!))
        Me.tableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 80.0!))
        Me.tableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.tableLayoutPanel1.Size = New System.Drawing.Size(623, 286)
        Me.tableLayoutPanel1.TabIndex = 0
        '
        'label1
        '
        Me.label1.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.label1.AutoSize = True
        Me.label1.Location = New System.Drawing.Point(4, 7)
        Me.label1.Name = "label1"
        Me.label1.Size = New System.Drawing.Size(57, 13)
        Me.label1.TabIndex = 20
        Me.label1.Text = "First Name"
        '
        'label2
        '
        Me.label2.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.label2.AutoSize = True
        Me.label2.Location = New System.Drawing.Point(314, 7)
        Me.label2.Name = "label2"
        Me.label2.Size = New System.Drawing.Size(58, 13)
        Me.label2.TabIndex = 21
        Me.label2.Text = "Last Name"
        '
        'label3
        '
        Me.label3.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.label3.AutoSize = True
        Me.label3.Location = New System.Drawing.Point(10, 35)
        Me.label3.Name = "label3"
        Me.label3.Size = New System.Drawing.Size(51, 13)
        Me.label3.TabIndex = 22
        Me.label3.Text = "Address1"
        '
        'label4
        '
        Me.label4.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.label4.AutoSize = True
        Me.label4.Location = New System.Drawing.Point(7, 63)
        Me.label4.Name = "label4"
        Me.label4.Size = New System.Drawing.Size(54, 13)
        Me.label4.TabIndex = 23
        Me.label4.Text = "Address 2"
        '
        'label5
        '
        Me.label5.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.label5.AutoSize = True
        Me.label5.Location = New System.Drawing.Point(37, 91)
        Me.label5.Name = "label5"
        Me.label5.Size = New System.Drawing.Size(24, 13)
        Me.label5.TabIndex = 24
        Me.label5.Text = "City"
        '
        'label6
        '
        Me.label6.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.label6.AutoSize = True
        Me.label6.Location = New System.Drawing.Point(340, 91)
        Me.label6.Name = "label6"
        Me.label6.Size = New System.Drawing.Size(32, 13)
        Me.label6.TabIndex = 25
        Me.label6.Text = "State"
        '
        'label9
        '
        Me.label9.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.label9.AutoSize = True
        Me.label9.Location = New System.Drawing.Point(317, 119)
        Me.label9.Name = "label9"
        Me.label9.Size = New System.Drawing.Size(55, 13)
        Me.label9.TabIndex = 33
        Me.label9.Text = "Phone (H)"
        '
        'textBox2
        '
        Me.textBox2.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tableLayoutPanel1.SetColumnSpan(Me.textBox2, 3)
        Me.textBox2.Location = New System.Drawing.Point(67, 32)
        Me.textBox2.Name = "textBox2"
        Me.textBox2.Size = New System.Drawing.Size(553, 20)
        Me.textBox2.TabIndex = 2
        '
        'textBox3
        '
        Me.textBox3.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tableLayoutPanel1.SetColumnSpan(Me.textBox3, 3)
        Me.textBox3.Location = New System.Drawing.Point(67, 60)
        Me.textBox3.Name = "textBox3"
        Me.textBox3.Size = New System.Drawing.Size(553, 20)
        Me.textBox3.TabIndex = 3
        '
        'textBox4
        '
        Me.textBox4.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.textBox4.Location = New System.Drawing.Point(67, 88)
        Me.textBox4.Name = "textBox4"
        Me.textBox4.Size = New System.Drawing.Size(241, 20)
        Me.textBox4.TabIndex = 4
        '
        'textBox5
        '
        Me.textBox5.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.textBox5.Location = New System.Drawing.Point(378, 4)
        Me.textBox5.Name = "textBox5"
        Me.textBox5.Size = New System.Drawing.Size(242, 20)
        Me.textBox5.TabIndex = 1
        '
        'maskedTextBox1
        '
        Me.maskedTextBox1.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.maskedTextBox1.Location = New System.Drawing.Point(67, 116)
        Me.maskedTextBox1.Mask = "(999)000-0000"
        Me.maskedTextBox1.Name = "maskedTextBox1"
        Me.maskedTextBox1.Size = New System.Drawing.Size(100, 20)
        Me.maskedTextBox1.TabIndex = 6
        '
        'maskedTextBox2
        '
        Me.maskedTextBox2.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.maskedTextBox2.Location = New System.Drawing.Point(378, 116)
        Me.maskedTextBox2.Mask = "(999)000-0000"
        Me.maskedTextBox2.Name = "maskedTextBox2"
        Me.maskedTextBox2.Size = New System.Drawing.Size(100, 20)
        Me.maskedTextBox2.TabIndex = 7
        '
        'comboBox1
        '
        Me.comboBox1.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.comboBox1.FormattingEnabled = True
        Me.comboBox1.Items.AddRange(New Object() {"AK - Alaska", "WA - Washington"})
        Me.comboBox1.Location = New System.Drawing.Point(378, 87)
        Me.comboBox1.Name = "comboBox1"
        Me.comboBox1.Size = New System.Drawing.Size(139, 21)
        Me.comboBox1.TabIndex = 5
        '
        'textBox1
        '
        Me.textBox1.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.textBox1.Location = New System.Drawing.Point(67, 4)
        Me.textBox1.Name = "textBox1"
        Me.textBox1.Size = New System.Drawing.Size(241, 20)
        Me.textBox1.TabIndex = 0
        '
        'label7
        '
        Me.label7.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.label7.AutoSize = True
        Me.label7.Location = New System.Drawing.Point(26, 140)
        Me.label7.Name = "label7"
        Me.label7.Size = New System.Drawing.Size(35, 13)
        Me.label7.TabIndex = 26
        Me.label7.Text = "Notes"
        '
        'label8
        '
        Me.label8.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.label8.AutoSize = True
        Me.label8.Location = New System.Drawing.Point(3, 119)
        Me.label8.Name = "label8"
        Me.label8.Size = New System.Drawing.Size(58, 13)
        Me.label8.TabIndex = 32
        Me.label8.Text = "Phone (W)"
        '
        'richTextBox1
        '
        Me.tableLayoutPanel1.SetColumnSpan(Me.richTextBox1, 3)
        Me.richTextBox1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.richTextBox1.Location = New System.Drawing.Point(67, 143)
        Me.richTextBox1.Name = "richTextBox1"
        Me.richTextBox1.Size = New System.Drawing.Size(553, 140)
        Me.richTextBox1.TabIndex = 8
        Me.richTextBox1.Text = ""
        '
        'button1
        '
        Me.button1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.button1.Location = New System.Drawing.Point(558, 306)
        Me.button1.Name = "button1"
        Me.button1.Size = New System.Drawing.Size(75, 23)
        Me.button1.TabIndex = 1
        Me.button1.Text = "Cancel"
        '
        'button2
        '
        Me.button2.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.button2.Location = New System.Drawing.Point(476, 306)
        Me.button2.Name = "button2"
        Me.button2.Size = New System.Drawing.Size(75, 23)
        Me.button2.TabIndex = 2
        Me.button2.Text = "OK"
        '
        'BasicDataEntry
        '
        Me.ClientSize = New System.Drawing.Size(642, 338)
        Me.Controls.Add(Me.button2)
        Me.Controls.Add(Me.button1)
        Me.Controls.Add(Me.tableLayoutPanel1)
        Me.Name = "BasicDataEntry"
        Me.Padding = New System.Windows.Forms.Padding(9)
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "Basic Data Entry"
        Me.tableLayoutPanel1.ResumeLayout(False)
        Me.tableLayoutPanel1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub 'InitializeComponent 

#End Region

    Private tableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Private label1 As System.Windows.Forms.Label
    Private label2 As System.Windows.Forms.Label
    Private label3 As System.Windows.Forms.Label
    Private label4 As System.Windows.Forms.Label
    Private label5 As System.Windows.Forms.Label
    Private label6 As System.Windows.Forms.Label
    Private label7 As System.Windows.Forms.Label
    Private label8 As System.Windows.Forms.Label
    Private label9 As System.Windows.Forms.Label
    Private WithEvents button1 As System.Windows.Forms.Button
    Private WithEvents button2 As System.Windows.Forms.Button
    Private textBox1 As System.Windows.Forms.TextBox
    Private textBox2 As System.Windows.Forms.TextBox
    Private textBox3 As System.Windows.Forms.TextBox
    Private textBox4 As System.Windows.Forms.TextBox
    Private textBox5 As System.Windows.Forms.TextBox
    Private maskedTextBox1 As System.Windows.Forms.MaskedTextBox
    Private maskedTextBox2 As System.Windows.Forms.MaskedTextBox
    Private comboBox1 As System.Windows.Forms.ComboBox
    Private richTextBox1 As System.Windows.Forms.RichTextBox

End Class 'BasicDataEntry 

