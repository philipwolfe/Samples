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
        Me.groupBox3 = New System.Windows.Forms.GroupBox
        Me.resultsCount = New System.Windows.Forms.Label
        Me.resultsView = New System.Windows.Forms.ListView
        Me.groupBox8 = New System.Windows.Forms.GroupBox
        Me.groupBox4 = New System.Windows.Forms.GroupBox
        Me.SplitExpression = New System.Windows.Forms.TextBox
        Me.label3 = New System.Windows.Forms.Label
        Me.SplitStartPosition = New System.Windows.Forms.TextBox
        Me.label2 = New System.Windows.Forms.Label
        Me.SplitMaxElements = New System.Windows.Forms.TextBox
        Me.label1 = New System.Windows.Forms.Label
        Me.SplitText = New System.Windows.Forms.Button
        Me.groupBox7 = New System.Windows.Forms.GroupBox
        Me.label4 = New System.Windows.Forms.Label
        Me.SplitResultsView = New System.Windows.Forms.ListView
        Me.ChunkHeader = New System.Windows.Forms.ColumnHeader
        Me.groupBox2 = New System.Windows.Forms.GroupBox
        Me.searchText = New System.Windows.Forms.RichTextBox
        Me.groupBox1 = New System.Windows.Forms.GroupBox
        Me.groupBox9 = New System.Windows.Forms.GroupBox
        Me.regularExpression = New System.Windows.Forms.TextBox
        Me.Test = New System.Windows.Forms.Button
        Me.groupBox6 = New System.Windows.Forms.GroupBox
        Me.IsRegexSingleline = New System.Windows.Forms.CheckBox
        Me.IsRegexRightToLeft = New System.Windows.Forms.CheckBox
        Me.IsRegexOptionsNone = New System.Windows.Forms.CheckBox
        Me.IsRegexMultiline = New System.Windows.Forms.CheckBox
        Me.IsRegexIgnorePatternWhitespace = New System.Windows.Forms.CheckBox
        Me.IsRegexIgnoreCase = New System.Windows.Forms.CheckBox
        Me.IsRegexExplicitCapture = New System.Windows.Forms.CheckBox
        Me.IsRegexCultureInvariant = New System.Windows.Forms.CheckBox
        Me.IsRegexCompiled = New System.Windows.Forms.CheckBox
        Me.groupBox5 = New System.Windows.Forms.GroupBox
        Me.ReplaceWith = New System.Windows.Forms.TextBox
        Me.label6 = New System.Windows.Forms.Label
        Me.TextReplace = New System.Windows.Forms.Button
        Me.ReplaceFindWhat = New System.Windows.Forms.TextBox
        Me.label5 = New System.Windows.Forms.Label
        Me.groupBox3.SuspendLayout()
        Me.groupBox8.SuspendLayout()
        Me.groupBox4.SuspendLayout()
        Me.groupBox7.SuspendLayout()
        Me.groupBox2.SuspendLayout()
        Me.groupBox1.SuspendLayout()
        Me.groupBox9.SuspendLayout()
        Me.groupBox6.SuspendLayout()
        Me.groupBox5.SuspendLayout()
        Me.SuspendLayout()
        '
        'groupBox3
        '
        Me.groupBox3.Controls.Add(Me.resultsCount)
        Me.groupBox3.Controls.Add(Me.resultsView)
        Me.groupBox3.Location = New System.Drawing.Point(12, 200)
        Me.groupBox3.Name = "groupBox3"
        Me.groupBox3.Size = New System.Drawing.Size(704, 149)
        Me.groupBox3.TabIndex = 18
        Me.groupBox3.TabStop = False
        Me.groupBox3.Text = "Results"
        '
        'resultsCount
        '
        Me.resultsCount.AutoSize = True
        Me.resultsCount.Location = New System.Drawing.Point(7, 18)
        Me.resultsCount.Name = "resultsCount"
        Me.resultsCount.Size = New System.Drawing.Size(0, 0)
        Me.resultsCount.TabIndex = 1
        '
        'resultsView
        '
        Me.resultsView.FullRowSelect = True
        Me.resultsView.GridLines = True
        Me.resultsView.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable
        Me.resultsView.Location = New System.Drawing.Point(6, 37)
        Me.resultsView.Name = "resultsView"
        Me.resultsView.Size = New System.Drawing.Size(677, 106)
        Me.resultsView.TabIndex = 0
        Me.resultsView.View = System.Windows.Forms.View.Details
        '
        'groupBox8
        '
        Me.groupBox8.Controls.Add(Me.groupBox4)
        Me.groupBox8.Controls.Add(Me.groupBox7)
        Me.groupBox8.Location = New System.Drawing.Point(12, 355)
        Me.groupBox8.Name = "groupBox8"
        Me.groupBox8.Size = New System.Drawing.Size(704, 224)
        Me.groupBox8.TabIndex = 19
        Me.groupBox8.TabStop = False
        Me.groupBox8.Text = "Split"
        '
        'groupBox4
        '
        Me.groupBox4.Controls.Add(Me.SplitExpression)
        Me.groupBox4.Controls.Add(Me.label3)
        Me.groupBox4.Controls.Add(Me.SplitStartPosition)
        Me.groupBox4.Controls.Add(Me.label2)
        Me.groupBox4.Controls.Add(Me.SplitMaxElements)
        Me.groupBox4.Controls.Add(Me.label1)
        Me.groupBox4.Controls.Add(Me.SplitText)
        Me.groupBox4.Location = New System.Drawing.Point(7, 19)
        Me.groupBox4.Name = "groupBox4"
        Me.groupBox4.Size = New System.Drawing.Size(686, 55)
        Me.groupBox4.TabIndex = 2
        Me.groupBox4.TabStop = False
        Me.groupBox4.Text = "Split Expression"
        '
        'SplitExpression
        '
        Me.SplitExpression.Location = New System.Drawing.Point(92, 20)
        Me.SplitExpression.Name = "SplitExpression"
        Me.SplitExpression.Size = New System.Drawing.Size(136, 20)
        Me.SplitExpression.TabIndex = 6
        '
        'label3
        '
        Me.label3.AutoSize = True
        Me.label3.Location = New System.Drawing.Point(6, 23)
        Me.label3.Name = "label3"
        Me.label3.Size = New System.Drawing.Size(80, 13)
        Me.label3.TabIndex = 5
        Me.label3.Text = "Split Expression:"
        '
        'SplitStartPosition
        '
        Me.SplitStartPosition.Location = New System.Drawing.Point(461, 20)
        Me.SplitStartPosition.Name = "SplitStartPosition"
        Me.SplitStartPosition.Size = New System.Drawing.Size(44, 20)
        Me.SplitStartPosition.TabIndex = 4
        Me.SplitStartPosition.Text = "0"
        '
        'label2
        '
        Me.label2.AutoSize = True
        Me.label2.Location = New System.Drawing.Point(387, 23)
        Me.label2.Name = "label2"
        Me.label2.Size = New System.Drawing.Size(68, 13)
        Me.label2.TabIndex = 3
        Me.label2.Text = "Start Position:"
        '
        'SplitMaxElements
        '
        Me.SplitMaxElements.Location = New System.Drawing.Point(316, 20)
        Me.SplitMaxElements.Name = "SplitMaxElements"
        Me.SplitMaxElements.Size = New System.Drawing.Size(45, 20)
        Me.SplitMaxElements.TabIndex = 2
        Me.SplitMaxElements.Text = "100"
        '
        'label1
        '
        Me.label1.AutoSize = True
        Me.label1.Location = New System.Drawing.Point(238, 23)
        Me.label1.Name = "label1"
        Me.label1.Size = New System.Drawing.Size(72, 13)
        Me.label1.TabIndex = 1
        Me.label1.Text = "Max Elements:"
        '
        'SplitText
        '
        Me.SplitText.Location = New System.Drawing.Point(532, 18)
        Me.SplitText.Name = "SplitText"
        Me.SplitText.Size = New System.Drawing.Size(75, 23)
        Me.SplitText.TabIndex = 0
        Me.SplitText.Text = "Split"
        '
        'groupBox7
        '
        Me.groupBox7.Controls.Add(Me.label4)
        Me.groupBox7.Controls.Add(Me.SplitResultsView)
        Me.groupBox7.Location = New System.Drawing.Point(7, 80)
        Me.groupBox7.Name = "groupBox7"
        Me.groupBox7.Size = New System.Drawing.Size(686, 137)
        Me.groupBox7.TabIndex = 14
        Me.groupBox7.TabStop = False
        Me.groupBox7.Text = "Results"
        '
        'label4
        '
        Me.label4.AutoSize = True
        Me.label4.Location = New System.Drawing.Point(7, 18)
        Me.label4.Name = "label4"
        Me.label4.Size = New System.Drawing.Size(0, 0)
        Me.label4.TabIndex = 1
        '
        'SplitResultsView
        '
        Me.SplitResultsView.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ChunkHeader})
        Me.SplitResultsView.FullRowSelect = True
        Me.SplitResultsView.GridLines = True
        Me.SplitResultsView.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable
        Me.SplitResultsView.Location = New System.Drawing.Point(6, 18)
        Me.SplitResultsView.Name = "SplitResultsView"
        Me.SplitResultsView.Size = New System.Drawing.Size(670, 103)
        Me.SplitResultsView.TabIndex = 0
        Me.SplitResultsView.View = System.Windows.Forms.View.Details
        '
        'ChunkHeader
        '
        Me.ChunkHeader.Text = "Chunk"
        Me.ChunkHeader.Width = 322
        '
        'groupBox2
        '
        Me.groupBox2.Controls.Add(Me.searchText)
        Me.groupBox2.Location = New System.Drawing.Point(12, 585)
        Me.groupBox2.Name = "groupBox2"
        Me.groupBox2.Size = New System.Drawing.Size(704, 141)
        Me.groupBox2.TabIndex = 17
        Me.groupBox2.TabStop = False
        Me.groupBox2.Text = "Text to Search"
        '
        'searchText
        '
        Me.searchText.Location = New System.Drawing.Point(3, 16)
        Me.searchText.Name = "searchText"
        Me.searchText.Size = New System.Drawing.Size(680, 112)
        Me.searchText.TabIndex = 0
        Me.searchText.Text = ""
        '
        'groupBox1
        '
        Me.groupBox1.Controls.Add(Me.groupBox9)
        Me.groupBox1.Controls.Add(Me.groupBox6)
        Me.groupBox1.Controls.Add(Me.groupBox5)
        Me.groupBox1.Location = New System.Drawing.Point(12, 12)
        Me.groupBox1.Name = "groupBox1"
        Me.groupBox1.Size = New System.Drawing.Size(704, 182)
        Me.groupBox1.TabIndex = 16
        Me.groupBox1.TabStop = False
        '
        'groupBox9
        '
        Me.groupBox9.Controls.Add(Me.regularExpression)
        Me.groupBox9.Controls.Add(Me.Test)
        Me.groupBox9.Location = New System.Drawing.Point(6, 19)
        Me.groupBox9.Name = "groupBox9"
        Me.groupBox9.Size = New System.Drawing.Size(334, 76)
        Me.groupBox9.TabIndex = 13
        Me.groupBox9.TabStop = False
        Me.groupBox9.Text = "Search Expression"
        '
        'regularExpression
        '
        Me.regularExpression.Location = New System.Drawing.Point(6, 19)
        Me.regularExpression.Name = "regularExpression"
        Me.regularExpression.Size = New System.Drawing.Size(315, 20)
        Me.regularExpression.TabIndex = 0
        '
        'Test
        '
        Me.Test.Location = New System.Drawing.Point(6, 45)
        Me.Test.Name = "Test"
        Me.Test.Size = New System.Drawing.Size(75, 23)
        Me.Test.TabIndex = 1
        Me.Test.Text = "Search"
        '
        'groupBox6
        '
        Me.groupBox6.Controls.Add(Me.IsRegexSingleline)
        Me.groupBox6.Controls.Add(Me.IsRegexRightToLeft)
        Me.groupBox6.Controls.Add(Me.IsRegexOptionsNone)
        Me.groupBox6.Controls.Add(Me.IsRegexMultiline)
        Me.groupBox6.Controls.Add(Me.IsRegexIgnorePatternWhitespace)
        Me.groupBox6.Controls.Add(Me.IsRegexIgnoreCase)
        Me.groupBox6.Controls.Add(Me.IsRegexExplicitCapture)
        Me.groupBox6.Controls.Add(Me.IsRegexCultureInvariant)
        Me.groupBox6.Controls.Add(Me.IsRegexCompiled)
        Me.groupBox6.Location = New System.Drawing.Point(8, 103)
        Me.groupBox6.Name = "groupBox6"
        Me.groupBox6.Size = New System.Drawing.Size(685, 72)
        Me.groupBox6.TabIndex = 12
        Me.groupBox6.TabStop = False
        Me.groupBox6.Text = "Options"
        '
        'IsRegexSingleline
        '
        Me.IsRegexSingleline.AutoSize = True
        Me.IsRegexSingleline.Location = New System.Drawing.Point(312, 22)
        Me.IsRegexSingleline.Name = "IsRegexSingleline"
        Me.IsRegexSingleline.Size = New System.Drawing.Size(67, 17)
        Me.IsRegexSingleline.TabIndex = 21
        Me.IsRegexSingleline.Text = "Singleline"
        '
        'IsRegexRightToLeft
        '
        Me.IsRegexRightToLeft.AutoSize = True
        Me.IsRegexRightToLeft.Location = New System.Drawing.Point(92, 45)
        Me.IsRegexRightToLeft.Name = "IsRegexRightToLeft"
        Me.IsRegexRightToLeft.Size = New System.Drawing.Size(78, 17)
        Me.IsRegexRightToLeft.TabIndex = 20
        Me.IsRegexRightToLeft.Text = "RightToLeft"
        '
        'IsRegexOptionsNone
        '
        Me.IsRegexOptionsNone.AutoSize = True
        Me.IsRegexOptionsNone.Location = New System.Drawing.Point(6, 22)
        Me.IsRegexOptionsNone.Name = "IsRegexOptionsNone"
        Me.IsRegexOptionsNone.Size = New System.Drawing.Size(73, 17)
        Me.IsRegexOptionsNone.TabIndex = 19
        Me.IsRegexOptionsNone.Text = "No options"
        '
        'IsRegexMultiline
        '
        Me.IsRegexMultiline.AutoSize = True
        Me.IsRegexMultiline.Location = New System.Drawing.Point(312, 45)
        Me.IsRegexMultiline.Name = "IsRegexMultiline"
        Me.IsRegexMultiline.Size = New System.Drawing.Size(60, 17)
        Me.IsRegexMultiline.TabIndex = 18
        Me.IsRegexMultiline.Text = "Multiline"
        '
        'IsRegexIgnorePatternWhitespace
        '
        Me.IsRegexIgnorePatternWhitespace.AutoSize = True
        Me.IsRegexIgnorePatternWhitespace.Location = New System.Drawing.Point(387, 22)
        Me.IsRegexIgnorePatternWhitespace.Name = "IsRegexIgnorePatternWhitespace"
        Me.IsRegexIgnorePatternWhitespace.Size = New System.Drawing.Size(146, 17)
        Me.IsRegexIgnorePatternWhitespace.TabIndex = 17
        Me.IsRegexIgnorePatternWhitespace.Text = "IgnorePattern Whitespace"
        '
        'IsRegexIgnoreCase
        '
        Me.IsRegexIgnoreCase.AutoSize = True
        Me.IsRegexIgnoreCase.Location = New System.Drawing.Point(206, 45)
        Me.IsRegexIgnoreCase.Name = "IsRegexIgnoreCase"
        Me.IsRegexIgnoreCase.Size = New System.Drawing.Size(79, 17)
        Me.IsRegexIgnoreCase.TabIndex = 16
        Me.IsRegexIgnoreCase.Text = "Ignore Case"
        '
        'IsRegexExplicitCapture
        '
        Me.IsRegexExplicitCapture.AutoSize = True
        Me.IsRegexExplicitCapture.Location = New System.Drawing.Point(206, 22)
        Me.IsRegexExplicitCapture.Name = "IsRegexExplicitCapture"
        Me.IsRegexExplicitCapture.Size = New System.Drawing.Size(95, 17)
        Me.IsRegexExplicitCapture.TabIndex = 15
        Me.IsRegexExplicitCapture.Text = "Explicit Capture"
        '
        'IsRegexCultureInvariant
        '
        Me.IsRegexCultureInvariant.AutoSize = True
        Me.IsRegexCultureInvariant.Location = New System.Drawing.Point(92, 22)
        Me.IsRegexCultureInvariant.Name = "IsRegexCultureInvariant"
        Me.IsRegexCultureInvariant.Size = New System.Drawing.Size(99, 17)
        Me.IsRegexCultureInvariant.TabIndex = 13
        Me.IsRegexCultureInvariant.Text = "Culture Invariant"
        '
        'IsRegexCompiled
        '
        Me.IsRegexCompiled.AutoSize = True
        Me.IsRegexCompiled.Location = New System.Drawing.Point(6, 45)
        Me.IsRegexCompiled.Name = "IsRegexCompiled"
        Me.IsRegexCompiled.Size = New System.Drawing.Size(65, 17)
        Me.IsRegexCompiled.TabIndex = 12
        Me.IsRegexCompiled.Text = "Compiled"
        '
        'groupBox5
        '
        Me.groupBox5.Controls.Add(Me.ReplaceWith)
        Me.groupBox5.Controls.Add(Me.label6)
        Me.groupBox5.Controls.Add(Me.TextReplace)
        Me.groupBox5.Controls.Add(Me.ReplaceFindWhat)
        Me.groupBox5.Controls.Add(Me.label5)
        Me.groupBox5.Location = New System.Drawing.Point(346, 19)
        Me.groupBox5.Name = "groupBox5"
        Me.groupBox5.Size = New System.Drawing.Size(347, 78)
        Me.groupBox5.TabIndex = 3
        Me.groupBox5.TabStop = False
        Me.groupBox5.Text = "Replace"
        '
        'ReplaceWith
        '
        Me.ReplaceWith.Location = New System.Drawing.Point(93, 45)
        Me.ReplaceWith.Name = "ReplaceWith"
        Me.ReplaceWith.Size = New System.Drawing.Size(161, 20)
        Me.ReplaceWith.TabIndex = 11
        '
        'label6
        '
        Me.label6.AutoSize = True
        Me.label6.Location = New System.Drawing.Point(13, 48)
        Me.label6.Name = "label6"
        Me.label6.Size = New System.Drawing.Size(71, 13)
        Me.label6.TabIndex = 10
        Me.label6.Text = "Replace With:"
        '
        'TextReplace
        '
        Me.TextReplace.Location = New System.Drawing.Point(262, 30)
        Me.TextReplace.Name = "TextReplace"
        Me.TextReplace.Size = New System.Drawing.Size(75, 23)
        Me.TextReplace.TabIndex = 9
        Me.TextReplace.Text = "Replace"
        '
        'ReplaceFindWhat
        '
        Me.ReplaceFindWhat.Location = New System.Drawing.Point(93, 19)
        Me.ReplaceFindWhat.Name = "ReplaceFindWhat"
        Me.ReplaceFindWhat.Size = New System.Drawing.Size(161, 20)
        Me.ReplaceFindWhat.TabIndex = 8
        '
        'label5
        '
        Me.label5.AutoSize = True
        Me.label5.Location = New System.Drawing.Point(13, 22)
        Me.label5.Name = "label5"
        Me.label5.Size = New System.Drawing.Size(55, 13)
        Me.label5.TabIndex = 7
        Me.label5.Text = "Find What:"
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(725, 743)
        Me.Controls.Add(Me.groupBox3)
        Me.Controls.Add(Me.groupBox8)
        Me.Controls.Add(Me.groupBox2)
        Me.Controls.Add(Me.groupBox1)
        Me.Name = "Form1"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Regular Expression Sample"
        Me.groupBox3.ResumeLayout(False)
        Me.groupBox3.PerformLayout()
        Me.groupBox8.ResumeLayout(False)
        Me.groupBox4.ResumeLayout(False)
        Me.groupBox4.PerformLayout()
        Me.groupBox7.ResumeLayout(False)
        Me.groupBox7.PerformLayout()
        Me.groupBox2.ResumeLayout(False)
        Me.groupBox1.ResumeLayout(False)
        Me.groupBox9.ResumeLayout(False)
        Me.groupBox9.PerformLayout()
        Me.groupBox6.ResumeLayout(False)
        Me.groupBox6.PerformLayout()
        Me.groupBox5.ResumeLayout(False)
        Me.groupBox5.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents groupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents resultsCount As System.Windows.Forms.Label
    Friend WithEvents resultsView As System.Windows.Forms.ListView
    Friend WithEvents groupBox8 As System.Windows.Forms.GroupBox
    Friend WithEvents groupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents SplitExpression As System.Windows.Forms.TextBox
    Friend WithEvents label3 As System.Windows.Forms.Label
    Friend WithEvents SplitStartPosition As System.Windows.Forms.TextBox
    Friend WithEvents label2 As System.Windows.Forms.Label
    Friend WithEvents SplitMaxElements As System.Windows.Forms.TextBox
    Friend WithEvents label1 As System.Windows.Forms.Label
    Friend WithEvents SplitText As System.Windows.Forms.Button
    Friend WithEvents groupBox7 As System.Windows.Forms.GroupBox
    Friend WithEvents label4 As System.Windows.Forms.Label
    Friend WithEvents SplitResultsView As System.Windows.Forms.ListView
    Friend WithEvents ChunkHeader As System.Windows.Forms.ColumnHeader
    Friend WithEvents groupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents searchText As System.Windows.Forms.RichTextBox
    Friend WithEvents groupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents groupBox9 As System.Windows.Forms.GroupBox
    Friend WithEvents regularExpression As System.Windows.Forms.TextBox
    Friend WithEvents Test As System.Windows.Forms.Button
    Friend WithEvents groupBox6 As System.Windows.Forms.GroupBox
    Friend WithEvents IsRegexSingleline As System.Windows.Forms.CheckBox
    Friend WithEvents IsRegexRightToLeft As System.Windows.Forms.CheckBox
    Friend WithEvents IsRegexOptionsNone As System.Windows.Forms.CheckBox
    Friend WithEvents IsRegexMultiline As System.Windows.Forms.CheckBox
    Friend WithEvents IsRegexIgnorePatternWhitespace As System.Windows.Forms.CheckBox
    Friend WithEvents IsRegexIgnoreCase As System.Windows.Forms.CheckBox
    Friend WithEvents IsRegexExplicitCapture As System.Windows.Forms.CheckBox
    Friend WithEvents IsRegexCultureInvariant As System.Windows.Forms.CheckBox
    Friend WithEvents IsRegexCompiled As System.Windows.Forms.CheckBox
    Friend WithEvents groupBox5 As System.Windows.Forms.GroupBox
    Friend WithEvents ReplaceWith As System.Windows.Forms.TextBox
    Friend WithEvents label6 As System.Windows.Forms.Label
    Friend WithEvents TextReplace As System.Windows.Forms.Button
    Friend WithEvents ReplaceFindWhat As System.Windows.Forms.TextBox
    Friend WithEvents label5 As System.Windows.Forms.Label

End Class
