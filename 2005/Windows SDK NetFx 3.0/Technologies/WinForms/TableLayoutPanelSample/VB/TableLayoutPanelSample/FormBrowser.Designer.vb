

Partial Class formBrowser
    Inherits System.Windows.Forms.Form
    '/ <summary>
    '/ Required method for Designer support - do not modify
    '/ the contents of this method with the code editor.
    '/ </summary>
    Private Sub InitializeComponent()
        Me.buttonViewForm = New System.Windows.Forms.Button
        Me.groupBox1 = New System.Windows.Forms.GroupBox
        Me.textDescription = New System.Windows.Forms.TextBox
        Me.pictureThumbnail = New System.Windows.Forms.PictureBox
        Me.comboSelectForm = New System.Windows.Forms.ComboBox
        Me.label1 = New System.Windows.Forms.Label
        Me.groupBox2 = New System.Windows.Forms.GroupBox
        Me.tableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel
        Me.groupBox1.SuspendLayout()
        CType(Me.pictureThumbnail, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.groupBox2.SuspendLayout()
        Me.tableLayoutPanel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'buttonViewForm
        '
        Me.buttonViewForm.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.buttonViewForm.AutoSize = True
        Me.buttonViewForm.Location = New System.Drawing.Point(299, 10)
        Me.buttonViewForm.Name = "buttonViewForm"
        Me.buttonViewForm.Size = New System.Drawing.Size(91, 23)
        Me.buttonViewForm.TabIndex = 0
        Me.buttonViewForm.Text = "View Form"
        '
        'groupBox1
        '
        Me.groupBox1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.groupBox1.Controls.Add(Me.textDescription)
        Me.groupBox1.Location = New System.Drawing.Point(3, 3)
        Me.groupBox1.Name = "groupBox1"
        Me.groupBox1.Size = New System.Drawing.Size(369, 212)
        Me.groupBox1.TabIndex = 2
        Me.groupBox1.TabStop = False
        Me.groupBox1.Text = "Form Description"
        '
        'textDescription
        '
        Me.textDescription.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.textDescription.Location = New System.Drawing.Point(10, 24)
        Me.textDescription.Multiline = True
        Me.textDescription.Name = "textDescription"
        Me.textDescription.ReadOnly = True
        Me.textDescription.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.textDescription.Size = New System.Drawing.Size(356, 169)
        Me.textDescription.TabIndex = 0
        '
        'pictureThumbnail
        '
        Me.pictureThumbnail.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pictureThumbnail.Location = New System.Drawing.Point(13, 26)
        Me.pictureThumbnail.Name = "pictureThumbnail"
        Me.pictureThumbnail.Size = New System.Drawing.Size(342, 174)
        Me.pictureThumbnail.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.pictureThumbnail.TabIndex = 3
        Me.pictureThumbnail.TabStop = False
        '
        'comboSelectForm
        '
        Me.comboSelectForm.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.comboSelectForm.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.comboSelectForm.FormattingEnabled = True
        Me.comboSelectForm.Location = New System.Drawing.Point(91, 10)
        Me.comboSelectForm.Margin = New System.Windows.Forms.Padding(2, 3, 3, 3)
        Me.comboSelectForm.Name = "comboSelectForm"
        Me.comboSelectForm.Size = New System.Drawing.Size(201, 21)
        Me.comboSelectForm.TabIndex = 5
        '
        'label1
        '
        Me.label1.AutoSize = True
        Me.label1.Location = New System.Drawing.Point(13, 13)
        Me.label1.Margin = New System.Windows.Forms.Padding(3, 3, 1, 3)
        Me.label1.Name = "label1"
        Me.label1.Size = New System.Drawing.Size(71, 13)
        Me.label1.TabIndex = 6
        Me.label1.Text = "Form to View:"
        '
        'groupBox2
        '
        Me.groupBox2.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.groupBox2.Controls.Add(Me.pictureThumbnail)
        Me.groupBox2.Location = New System.Drawing.Point(3, 221)
        Me.groupBox2.Name = "groupBox2"
        Me.groupBox2.Size = New System.Drawing.Size(369, 212)
        Me.groupBox2.TabIndex = 7
        Me.groupBox2.TabStop = False
        Me.groupBox2.Text = "Form Preview"
        '
        'tableLayoutPanel1
        '
        Me.tableLayoutPanel1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tableLayoutPanel1.ColumnCount = 1
        Me.tableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 272.0!))
        Me.tableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 0.0!))
        Me.tableLayoutPanel1.Controls.Add(Me.groupBox1, 0, 0)
        Me.tableLayoutPanel1.Controls.Add(Me.groupBox2, 0, 1)
        Me.tableLayoutPanel1.Location = New System.Drawing.Point(15, 37)
        Me.tableLayoutPanel1.Name = "tableLayoutPanel1"
        Me.tableLayoutPanel1.RowCount = 2
        Me.tableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.tableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.tableLayoutPanel1.Size = New System.Drawing.Size(375, 436)
        Me.tableLayoutPanel1.TabIndex = 8
        '
        'formBrowser
        '
        Me.ClientSize = New System.Drawing.Size(394, 479)
        Me.Controls.Add(Me.tableLayoutPanel1)
        Me.Controls.Add(Me.label1)
        Me.Controls.Add(Me.comboSelectForm)
        Me.Controls.Add(Me.buttonViewForm)
        Me.Location = New System.Drawing.Point(50, 50)
        Me.MinimumSize = New System.Drawing.Size(402, 513)
        Me.Name = "formBrowser"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "Sample Form Browser"
        Me.groupBox1.ResumeLayout(False)
        Me.groupBox1.PerformLayout()
        CType(Me.pictureThumbnail, System.ComponentModel.ISupportInitialize).EndInit()
        Me.groupBox2.ResumeLayout(False)
        Me.tableLayoutPanel1.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub 'InitializeComponent


    '/ <summary>
    '/ Clean up any resources being used.
    '/ </summary>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing Then
            If Not (components Is Nothing) Then
                components.Dispose()
            End If
        End If
        MyBase.Dispose(disposing)

    End Sub 'Dispose

    Private WithEvents buttonViewForm As System.Windows.Forms.Button
    Private groupBox1 As System.Windows.Forms.GroupBox
    Private pictureThumbnail As System.Windows.Forms.PictureBox
    Private WithEvents comboSelectForm As System.Windows.Forms.ComboBox
    Private label1 As System.Windows.Forms.Label
    Private textDescription As System.Windows.Forms.TextBox
    Private groupBox2 As System.Windows.Forms.GroupBox
    Private tableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
End Class 'formBrowser
