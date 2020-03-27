Partial Class Form1
    Inherits System.Windows.Forms.Form

    ' <summary>
    ' Required designer variable.
    ' </summary>
    Private components As System.ComponentModel.IContainer = Nothing
    Private WithEvents backgroundWorker1 As System.ComponentModel.BackgroundWorker
    Private WithEvents tabControl1 As System.Windows.Forms.TabControl
    Private WithEvents tabPage1 As System.Windows.Forms.TabPage
    Private WithEvents closeButton As System.Windows.Forms.Button
    Private WithEvents Shadows cancelButton As System.Windows.Forms.Button
    Private WithEvents beginButton As System.Windows.Forms.Button
    Private resultsTextBoxMain As System.Windows.Forms.TextBox
    Private WithEvents tabPage2 As System.Windows.Forms.TabPage
    Private WithEvents beginButtonBGW As System.Windows.Forms.Button
    Private WithEvents resultsTextBoxBGW As System.Windows.Forms.TextBox
    Private WithEvents cancelButtonBGW As System.Windows.Forms.Button
    Private label2 As System.Windows.Forms.Label
    Private label3 As System.Windows.Forms.Label
    Private label4 As System.Windows.Forms.Label
    Private label5 As System.Windows.Forms.Label
    Private label7 As System.Windows.Forms.Label
    Private WithEvents progressBar1 As System.Windows.Forms.ProgressBar
    Private WithEvents clearResultsButton As System.Windows.Forms.Button
    Private WithEvents resultsTextBoxBackground As System.Windows.Forms.TextBox
    Private WithEvents clearResultsBGW As System.Windows.Forms.Button
    Private label1 As System.Windows.Forms.Label
    Private WithEvents numberToDoubleComboBox As System.Windows.Forms.ComboBox
    Private WithEvents exponentResultTextBox As System.Windows.Forms.TextBox
    Private label6 As System.Windows.Forms.Label
    Private label9 As System.Windows.Forms.Label
    Private WithEvents backgroundLoopsComboBox As System.Windows.Forms.ComboBox
    Private label8 As System.Windows.Forms.Label
    Private WithEvents foregroundLoopsComboBox As System.Windows.Forms.ComboBox
    Private label10 As System.Windows.Forms.Label
    Private WithEvents timesToDoubleComboBox As System.Windows.Forms.ComboBox

    ' <summary>
    ' Clean up any resources being used.
    ' </summary>
    ' <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If (disposing _
                    AndAlso (Not (components) Is Nothing)) Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    ' <summary>
    ' Required method for Designer support - do not modify
    ' the contents of this method with the code editor.
    ' </summary>
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form1))
        Me.backgroundWorker1 = New System.ComponentModel.BackgroundWorker
        Me.tabControl1 = New System.Windows.Forms.TabControl
        Me.tabPage1 = New System.Windows.Forms.TabPage
        Me.label9 = New System.Windows.Forms.Label
        Me.backgroundLoopsComboBox = New System.Windows.Forms.ComboBox
        Me.label8 = New System.Windows.Forms.Label
        Me.foregroundLoopsComboBox = New System.Windows.Forms.ComboBox
        Me.clearResultsButton = New System.Windows.Forms.Button
        Me.label4 = New System.Windows.Forms.Label
        Me.label5 = New System.Windows.Forms.Label
        Me.cancelButton = New System.Windows.Forms.Button
        Me.beginButton = New System.Windows.Forms.Button
        Me.resultsTextBoxBackground = New System.Windows.Forms.TextBox
        Me.resultsTextBoxMain = New System.Windows.Forms.TextBox
        Me.tabPage2 = New System.Windows.Forms.TabPage
        Me.exponentResultTextBox = New System.Windows.Forms.TextBox
        Me.label6 = New System.Windows.Forms.Label
        Me.label10 = New System.Windows.Forms.Label
        Me.label1 = New System.Windows.Forms.Label
        Me.timesToDoubleComboBox = New System.Windows.Forms.ComboBox
        Me.numberToDoubleComboBox = New System.Windows.Forms.ComboBox
        Me.clearResultsBGW = New System.Windows.Forms.Button
        Me.label7 = New System.Windows.Forms.Label
        Me.progressBar1 = New System.Windows.Forms.ProgressBar
        Me.label3 = New System.Windows.Forms.Label
        Me.label2 = New System.Windows.Forms.Label
        Me.cancelButtonBGW = New System.Windows.Forms.Button
        Me.beginButtonBGW = New System.Windows.Forms.Button
        Me.resultsTextBoxBGW = New System.Windows.Forms.TextBox
        Me.closeButton = New System.Windows.Forms.Button
        Me.tabControl1.SuspendLayout()
        Me.tabPage1.SuspendLayout()
        Me.tabPage2.SuspendLayout()
        Me.SuspendLayout()
        '
        'backgroundWorker1
        '
        Me.backgroundWorker1.WorkerReportsProgress = True
        Me.backgroundWorker1.WorkerSupportsCancellation = True
        '
        'tabControl1
        '
        Me.tabControl1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tabControl1.Controls.Add(Me.tabPage1)
        Me.tabControl1.Controls.Add(Me.tabPage2)
        Me.tabControl1.Location = New System.Drawing.Point(15, 8)
        Me.tabControl1.Name = "tabControl1"
        Me.tabControl1.SelectedIndex = 0
        Me.tabControl1.Size = New System.Drawing.Size(662, 434)
        Me.tabControl1.TabIndex = 0
        '
        'tabPage1
        '
        Me.tabPage1.Controls.Add(Me.label9)
        Me.tabPage1.Controls.Add(Me.backgroundLoopsComboBox)
        Me.tabPage1.Controls.Add(Me.label8)
        Me.tabPage1.Controls.Add(Me.foregroundLoopsComboBox)
        Me.tabPage1.Controls.Add(Me.clearResultsButton)
        Me.tabPage1.Controls.Add(Me.label4)
        Me.tabPage1.Controls.Add(Me.label5)
        Me.tabPage1.Controls.Add(Me.cancelButton)
        Me.tabPage1.Controls.Add(Me.beginButton)
        Me.tabPage1.Controls.Add(Me.resultsTextBoxBackground)
        Me.tabPage1.Controls.Add(Me.resultsTextBoxMain)
        Me.tabPage1.Location = New System.Drawing.Point(4, 22)
        Me.tabPage1.Name = "tabPage1"
        Me.tabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.tabPage1.Size = New System.Drawing.Size(654, 408)
        Me.tabPage1.TabIndex = 0
        Me.tabPage1.Text = "Basic Threading"
        Me.tabPage1.UseVisualStyleBackColor = True
        '
        'label9
        '
        Me.label9.AutoSize = True
        Me.label9.Location = New System.Drawing.Point(20, 226)
        Me.label9.Name = "label9"
        Me.label9.Size = New System.Drawing.Size(93, 13)
        Me.label9.TabIndex = 7
        Me.label9.Text = "Background loops"
        '
        'backgroundLoopsComboBox
        '
        Me.backgroundLoopsComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.backgroundLoopsComboBox.FormattingEnabled = True
        Me.backgroundLoopsComboBox.Items.AddRange(New Object() {"2", "4", "6", "8"})
        Me.backgroundLoopsComboBox.Location = New System.Drawing.Point(117, 226)
        Me.backgroundLoopsComboBox.Name = "backgroundLoopsComboBox"
        Me.backgroundLoopsComboBox.Size = New System.Drawing.Size(121, 21)
        Me.backgroundLoopsComboBox.TabIndex = 8
        '
        'label8
        '
        Me.label8.AutoSize = True
        Me.label8.Location = New System.Drawing.Point(20, 199)
        Me.label8.Name = "label8"
        Me.label8.Size = New System.Drawing.Size(58, 13)
        Me.label8.TabIndex = 5
        Me.label8.Text = "Main loops"
        '
        'foregroundLoopsComboBox
        '
        Me.foregroundLoopsComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.foregroundLoopsComboBox.FormattingEnabled = True
        Me.foregroundLoopsComboBox.Items.AddRange(New Object() {"2", "4", "6", "8"})
        Me.foregroundLoopsComboBox.Location = New System.Drawing.Point(117, 199)
        Me.foregroundLoopsComboBox.Name = "foregroundLoopsComboBox"
        Me.foregroundLoopsComboBox.Size = New System.Drawing.Size(121, 21)
        Me.foregroundLoopsComboBox.TabIndex = 6
        '
        'clearResultsButton
        '
        Me.clearResultsButton.Location = New System.Drawing.Point(224, 365)
        Me.clearResultsButton.Name = "clearResultsButton"
        Me.clearResultsButton.Size = New System.Drawing.Size(81, 23)
        Me.clearResultsButton.TabIndex = 2
        Me.clearResultsButton.Text = "Clear Results"
        Me.clearResultsButton.UseVisualStyleBackColor = True
        '
        'label4
        '
        Me.label4.Location = New System.Drawing.Point(20, 50)
        Me.label4.Name = "label4"
        Me.label4.Size = New System.Drawing.Size(350, 83)
        Me.label4.TabIndex = 4
        Me.label4.Text = resources.GetString("label4.Text")
        '
        'label5
        '
        Me.label5.AutoSize = True
        Me.label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.label5.Location = New System.Drawing.Point(19, 14)
        Me.label5.Name = "label5"
        Me.label5.Size = New System.Drawing.Size(138, 20)
        Me.label5.TabIndex = 3
        Me.label5.Text = "Basic Threading"
        '
        'cancelButton
        '
        Me.cancelButton.Enabled = False
        Me.cancelButton.Location = New System.Drawing.Point(104, 365)
        Me.cancelButton.Name = "cancelButton"
        Me.cancelButton.Size = New System.Drawing.Size(112, 23)
        Me.cancelButton.TabIndex = 1
        Me.cancelButton.Text = "Cancel Background"
        Me.cancelButton.UseVisualStyleBackColor = True
        '
        'beginButton
        '
        Me.beginButton.Location = New System.Drawing.Point(23, 365)
        Me.beginButton.Name = "beginButton"
        Me.beginButton.Size = New System.Drawing.Size(75, 23)
        Me.beginButton.TabIndex = 0
        Me.beginButton.Text = "Begin"
        Me.beginButton.UseVisualStyleBackColor = True
        '
        'resultsTextBoxBackground
        '
        Me.resultsTextBoxBackground.Location = New System.Drawing.Point(388, 268)
        Me.resultsTextBoxBackground.Multiline = True
        Me.resultsTextBoxBackground.Name = "resultsTextBoxBackground"
        Me.resultsTextBoxBackground.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.resultsTextBoxBackground.Size = New System.Drawing.Size(249, 120)
        Me.resultsTextBoxBackground.TabIndex = 10
        '
        'resultsTextBoxMain
        '
        Me.resultsTextBoxMain.Location = New System.Drawing.Point(388, 16)
        Me.resultsTextBoxMain.Multiline = True
        Me.resultsTextBoxMain.Name = "resultsTextBoxMain"
        Me.resultsTextBoxMain.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.resultsTextBoxMain.Size = New System.Drawing.Size(249, 246)
        Me.resultsTextBoxMain.TabIndex = 9
        '
        'tabPage2
        '
        Me.tabPage2.Controls.Add(Me.exponentResultTextBox)
        Me.tabPage2.Controls.Add(Me.label6)
        Me.tabPage2.Controls.Add(Me.label10)
        Me.tabPage2.Controls.Add(Me.label1)
        Me.tabPage2.Controls.Add(Me.timesToDoubleComboBox)
        Me.tabPage2.Controls.Add(Me.numberToDoubleComboBox)
        Me.tabPage2.Controls.Add(Me.clearResultsBGW)
        Me.tabPage2.Controls.Add(Me.label7)
        Me.tabPage2.Controls.Add(Me.progressBar1)
        Me.tabPage2.Controls.Add(Me.label3)
        Me.tabPage2.Controls.Add(Me.label2)
        Me.tabPage2.Controls.Add(Me.cancelButtonBGW)
        Me.tabPage2.Controls.Add(Me.beginButtonBGW)
        Me.tabPage2.Controls.Add(Me.resultsTextBoxBGW)
        Me.tabPage2.Location = New System.Drawing.Point(4, 22)
        Me.tabPage2.Name = "tabPage2"
        Me.tabPage2.Size = New System.Drawing.Size(654, 408)
        Me.tabPage2.TabIndex = 2
        Me.tabPage2.Text = "Background Worker"
        Me.tabPage2.UseVisualStyleBackColor = True
        '
        'exponentResultTextBox
        '
        Me.exponentResultTextBox.Location = New System.Drawing.Point(141, 225)
        Me.exponentResultTextBox.Name = "exponentResultTextBox"
        Me.exponentResultTextBox.Size = New System.Drawing.Size(121, 20)
        Me.exponentResultTextBox.TabIndex = 10
        '
        'label6
        '
        Me.label6.AutoSize = True
        Me.label6.Location = New System.Drawing.Point(20, 228)
        Me.label6.Name = "label6"
        Me.label6.Size = New System.Drawing.Size(37, 13)
        Me.label6.TabIndex = 9
        Me.label6.Text = "Result"
        '
        'label10
        '
        Me.label10.AutoSize = True
        Me.label10.Location = New System.Drawing.Point(20, 202)
        Me.label10.Name = "label10"
        Me.label10.Size = New System.Drawing.Size(84, 13)
        Me.label10.TabIndex = 7
        Me.label10.Text = "Times to Double"
        '
        'label1
        '
        Me.label1.AutoSize = True
        Me.label1.Location = New System.Drawing.Point(20, 175)
        Me.label1.Name = "label1"
        Me.label1.Size = New System.Drawing.Size(93, 13)
        Me.label1.TabIndex = 5
        Me.label1.Text = "Number to Double"
        '
        'timesToDoubleComboBox
        '
        Me.timesToDoubleComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.timesToDoubleComboBox.FormattingEnabled = True
        Me.timesToDoubleComboBox.Items.AddRange(New Object() {"3", "5", "7", "9"})
        Me.timesToDoubleComboBox.Location = New System.Drawing.Point(141, 198)
        Me.timesToDoubleComboBox.Name = "timesToDoubleComboBox"
        Me.timesToDoubleComboBox.Size = New System.Drawing.Size(121, 21)
        Me.timesToDoubleComboBox.TabIndex = 8
        '
        'numberToDoubleComboBox
        '
        Me.numberToDoubleComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.numberToDoubleComboBox.FormattingEnabled = True
        Me.numberToDoubleComboBox.Items.AddRange(New Object() {"2", "4", "6", "8"})
        Me.numberToDoubleComboBox.Location = New System.Drawing.Point(141, 171)
        Me.numberToDoubleComboBox.Name = "numberToDoubleComboBox"
        Me.numberToDoubleComboBox.Size = New System.Drawing.Size(121, 21)
        Me.numberToDoubleComboBox.TabIndex = 6
        '
        'clearResultsBGW
        '
        Me.clearResultsBGW.Location = New System.Drawing.Point(221, 363)
        Me.clearResultsBGW.Name = "clearResultsBGW"
        Me.clearResultsBGW.Size = New System.Drawing.Size(81, 23)
        Me.clearResultsBGW.TabIndex = 2
        Me.clearResultsBGW.Text = "Clear Results"
        Me.clearResultsBGW.UseVisualStyleBackColor = True
        '
        'label7
        '
        Me.label7.AutoSize = True
        Me.label7.Location = New System.Drawing.Point(20, 284)
        Me.label7.Name = "label7"
        Me.label7.Size = New System.Drawing.Size(48, 13)
        Me.label7.TabIndex = 11
        Me.label7.Text = "Progress"
        '
        'progressBar1
        '
        Me.progressBar1.Location = New System.Drawing.Point(20, 300)
        Me.progressBar1.Name = "progressBar1"
        Me.progressBar1.Size = New System.Drawing.Size(350, 19)
        Me.progressBar1.TabIndex = 12
        '
        'label3
        '
        Me.label3.Location = New System.Drawing.Point(20, 50)
        Me.label3.Name = "label3"
        Me.label3.Size = New System.Drawing.Size(350, 98)
        Me.label3.TabIndex = 4
        Me.label3.Text = resources.GetString("label3.Text")
        '
        'label2
        '
        Me.label2.AutoSize = True
        Me.label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.label2.Location = New System.Drawing.Point(20, 14)
        Me.label2.Name = "label2"
        Me.label2.Size = New System.Drawing.Size(259, 20)
        Me.label2.TabIndex = 3
        Me.label2.Text = "BackgroundWorker Component"
        '
        'cancelButtonBGW
        '
        Me.cancelButtonBGW.Enabled = False
        Me.cancelButtonBGW.Location = New System.Drawing.Point(101, 363)
        Me.cancelButtonBGW.Name = "cancelButtonBGW"
        Me.cancelButtonBGW.Size = New System.Drawing.Size(112, 23)
        Me.cancelButtonBGW.TabIndex = 1
        Me.cancelButtonBGW.Text = "Cancel Background"
        Me.cancelButtonBGW.UseVisualStyleBackColor = True
        '
        'beginButtonBGW
        '
        Me.beginButtonBGW.Location = New System.Drawing.Point(20, 363)
        Me.beginButtonBGW.Name = "beginButtonBGW"
        Me.beginButtonBGW.Size = New System.Drawing.Size(75, 23)
        Me.beginButtonBGW.TabIndex = 0
        Me.beginButtonBGW.Text = "Begin"
        Me.beginButtonBGW.UseVisualStyleBackColor = True
        '
        'resultsTextBoxBGW
        '
        Me.resultsTextBoxBGW.Location = New System.Drawing.Point(387, 14)
        Me.resultsTextBoxBGW.Multiline = True
        Me.resultsTextBoxBGW.Name = "resultsTextBoxBGW"
        Me.resultsTextBoxBGW.Size = New System.Drawing.Size(247, 372)
        Me.resultsTextBoxBGW.TabIndex = 13
        '
        'closeButton
        '
        Me.closeButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.closeButton.Location = New System.Drawing.Point(598, 448)
        Me.closeButton.Name = "closeButton"
        Me.closeButton.Size = New System.Drawing.Size(75, 23)
        Me.closeButton.TabIndex = 0
        Me.closeButton.Text = "Close"
        Me.closeButton.UseVisualStyleBackColor = True
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(692, 482)
        Me.Controls.Add(Me.closeButton)
        Me.Controls.Add(Me.tabControl1)
        Me.Name = "Form1"
        Me.Padding = New System.Windows.Forms.Padding(15, 0, 15, 40)
        Me.Text = "Form1"
        Me.tabControl1.ResumeLayout(False)
        Me.tabPage1.ResumeLayout(False)
        Me.tabPage1.PerformLayout()
        Me.tabPage2.ResumeLayout(False)
        Me.tabPage2.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
End Class
