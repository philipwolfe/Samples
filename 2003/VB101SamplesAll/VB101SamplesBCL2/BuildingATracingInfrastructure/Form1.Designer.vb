<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    Private panel1 As System.Windows.Forms.Panel
    Private label5 As System.Windows.Forms.Label
    Private label4 As System.Windows.Forms.Label
    Private label1 As System.Windows.Forms.Label
    Private webServiceButton As System.Windows.Forms.Button
    Private webServiceDelayTextBox As System.Windows.Forms.TextBox
    Private menuStrip1 As System.Windows.Forms.MenuStrip
    Private fileToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Private exitToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Private panel2 As System.Windows.Forms.Panel
    Private serverNamecomboBox As System.Windows.Forms.ComboBox
    Private label2 As System.Windows.Forms.Label
    Private databaseButton As System.Windows.Forms.Button
    Private label6 As System.Windows.Forms.Label
    Private label7 As System.Windows.Forms.Label
    Private panel3 As System.Windows.Forms.Panel
    Private label3 As System.Windows.Forms.Label
    Private longProcessButton As System.Windows.Forms.Button
    Private longProcessDelayTextBox As System.Windows.Forms.TextBox
    Private label9 As System.Windows.Forms.Label
    Private label10 As System.Windows.Forms.Label
    Private closeButton As System.Windows.Forms.Button

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form1))
        Me.panel1 = New System.Windows.Forms.Panel
        Me.label5 = New System.Windows.Forms.Label
        Me.label4 = New System.Windows.Forms.Label
        Me.label1 = New System.Windows.Forms.Label
        Me.webServiceButton = New System.Windows.Forms.Button
        Me.webServiceDelayTextBox = New System.Windows.Forms.TextBox
        Me.menuStrip1 = New System.Windows.Forms.MenuStrip
        Me.fileToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.exitToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.panel2 = New System.Windows.Forms.Panel
        Me.serverNamecomboBox = New System.Windows.Forms.ComboBox
        Me.label2 = New System.Windows.Forms.Label
        Me.databaseButton = New System.Windows.Forms.Button
        Me.label6 = New System.Windows.Forms.Label
        Me.label7 = New System.Windows.Forms.Label
        Me.panel3 = New System.Windows.Forms.Panel
        Me.label3 = New System.Windows.Forms.Label
        Me.longProcessButton = New System.Windows.Forms.Button
        Me.longProcessDelayTextBox = New System.Windows.Forms.TextBox
        Me.label9 = New System.Windows.Forms.Label
        Me.label10 = New System.Windows.Forms.Label
        Me.closeButton = New System.Windows.Forms.Button
        Me.panel1.SuspendLayout()
        Me.menuStrip1.SuspendLayout()
        Me.panel2.SuspendLayout()
        Me.panel3.SuspendLayout()
        Me.SuspendLayout()
        '
        ' panel1
        '
        Me.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.panel1.Controls.Add(Me.label5)
        Me.panel1.Controls.Add(Me.label4)
        Me.panel1.Controls.Add(Me.label1)
        Me.panel1.Controls.Add(Me.webServiceButton)
        Me.panel1.Controls.Add(Me.webServiceDelayTextBox)
        Me.panel1.Location = New System.Drawing.Point(32, 361)
        Me.panel1.Name = "panel1"
        Me.panel1.Size = New System.Drawing.Size(466, 139)
        Me.panel1.TabIndex = 3
        '
        ' label5
        '
        Me.label5.Location = New System.Drawing.Point(34, 36)
        Me.label5.Name = "label5"
        Me.label5.Size = New System.Drawing.Size(402, 45)
        Me.label5.TabIndex = 1
        Me.label5.Text = resources.GetString("label5.Text")
        '
        ' label4
        '
        Me.label4.AutoSize = True
        Me.label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.label4.Location = New System.Drawing.Point(34, 12)
        Me.label4.Name = "label4"
        Me.label4.Size = New System.Drawing.Size(264, 18)
        Me.label4.TabIndex = 0
        Me.label4.Text = "Retrieve Data from a Web Service"
        '
        ' label1
        '
        Me.label1.AutoSize = True
        Me.label1.Location = New System.Drawing.Point(34, 100)
        Me.label1.Name = "label1"
        Me.label1.Size = New System.Drawing.Size(68, 13)
        Me.label1.TabIndex = 2
        Me.label1.Text = "Delay (secs.)"
        '
        ' webServiceButton
        '
        Me.webServiceButton.Location = New System.Drawing.Point(286, 97)
        Me.webServiceButton.Name = "webServiceButton"
        Me.webServiceButton.Size = New System.Drawing.Size(136, 23)
        Me.webServiceButton.TabIndex = 4
        Me.webServiceButton.Text = "Access Web Service"
        Me.webServiceButton.UseVisualStyleBackColor = True
        AddHandler webServiceButton.Click, AddressOf Me.webServiceButton_Click
        '
        ' webServiceDelayTextBox
        '
        Me.webServiceDelayTextBox.Location = New System.Drawing.Point(136, 97)
        Me.webServiceDelayTextBox.Name = "webServiceDelayTextBox"
        Me.webServiceDelayTextBox.Size = New System.Drawing.Size(121, 20)
        Me.webServiceDelayTextBox.TabIndex = 3
        Me.webServiceDelayTextBox.Text = "2"
        '
        ' menuStrip1
        '
        Me.menuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.fileToolStripMenuItem})
        Me.menuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.menuStrip1.Name = "menuStrip1"
        Me.menuStrip1.Size = New System.Drawing.Size(535, 24)
        Me.menuStrip1.TabIndex = 0
        Me.menuStrip1.Text = "menuStrip1"
        '
        ' fileToolStripMenuItem
        '
        Me.fileToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.exitToolStripMenuItem})
        Me.fileToolStripMenuItem.Name = "fileToolStripMenuItem"
        Me.fileToolStripMenuItem.Size = New System.Drawing.Size(35, 20)
        Me.fileToolStripMenuItem.Text = "&File"
        '
        ' exitToolStripMenuItem
        '
        Me.exitToolStripMenuItem.Name = "exitToolStripMenuItem"
        Me.exitToolStripMenuItem.Size = New System.Drawing.Size(103, 22)
        Me.exitToolStripMenuItem.Text = "E&xit"
        AddHandler exitToolStripMenuItem.Click, AddressOf Me.exitToolStripMenuItem_Click
        '
        ' panel2
        '
        Me.panel2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.panel2.Controls.Add(Me.serverNamecomboBox)
        Me.panel2.Controls.Add(Me.label2)
        Me.panel2.Controls.Add(Me.databaseButton)
        Me.panel2.Controls.Add(Me.label6)
        Me.panel2.Controls.Add(Me.label7)
        Me.panel2.Location = New System.Drawing.Point(32, 50)
        Me.panel2.Name = "panel2"
        Me.panel2.Size = New System.Drawing.Size(466, 139)
        Me.panel2.TabIndex = 1
        '
        ' serverNamecomboBox
        '
        Me.serverNamecomboBox.FormattingEnabled = True
        Me.serverNamecomboBox.Items.AddRange(New Object() {"AvailableServer", "UnavailableServer"})
        Me.serverNamecomboBox.Location = New System.Drawing.Point(136, 93)
        Me.serverNamecomboBox.Name = "serverNamecomboBox"
        Me.serverNamecomboBox.Size = New System.Drawing.Size(121, 21)
        Me.serverNamecomboBox.TabIndex = 3
        AddHandler serverNamecomboBox.SelectedIndexChanged, AddressOf Me.serverNamecomboBox_SelectedIndexChanged
        AddHandler serverNamecomboBox.TextChanged, AddressOf Me.serverNamecomboBox_SelectedIndexChanged
        AddHandler serverNamecomboBox.TextUpdate, AddressOf Me.serverNamecomboBox_SelectedIndexChanged
        '
        ' label2
        '
        Me.label2.AutoSize = True
        Me.label2.Location = New System.Drawing.Point(34, 101)
        Me.label2.Name = "label2"
        Me.label2.Size = New System.Drawing.Size(67, 13)
        Me.label2.TabIndex = 2
        Me.label2.Text = "Server name"
        '
        ' databaseButton
        '
        Me.databaseButton.Location = New System.Drawing.Point(286, 91)
        Me.databaseButton.Name = "databaseButton"
        Me.databaseButton.Size = New System.Drawing.Size(136, 23)
        Me.databaseButton.TabIndex = 4
        Me.databaseButton.Text = "Connect to Database"
        Me.databaseButton.UseVisualStyleBackColor = True
        AddHandler databaseButton.Click, AddressOf Me.databaseButton_Click
        '
        ' label6
        '
        Me.label6.Location = New System.Drawing.Point(34, 36)
        Me.label6.Name = "label6"
        Me.label6.Size = New System.Drawing.Size(402, 43)
        Me.label6.TabIndex = 1
        Me.label6.Text = resources.GetString("label6.Text")
        '
        ' label7
        '
        Me.label7.AutoSize = True
        Me.label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.label7.Location = New System.Drawing.Point(34, 12)
        Me.label7.Name = "label7"
        Me.label7.Size = New System.Drawing.Size(181, 18)
        Me.label7.TabIndex = 0
        Me.label7.Text = "Connect to a Database"
        '
        ' panel3
        '
        Me.panel3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.panel3.Controls.Add(Me.label3)
        Me.panel3.Controls.Add(Me.longProcessButton)
        Me.panel3.Controls.Add(Me.longProcessDelayTextBox)
        Me.panel3.Controls.Add(Me.label9)
        Me.panel3.Controls.Add(Me.label10)
        Me.panel3.Location = New System.Drawing.Point(32, 204)
        Me.panel3.Name = "panel3"
        Me.panel3.Size = New System.Drawing.Size(466, 139)
        Me.panel3.TabIndex = 2
        '
        ' label3
        '
        Me.label3.AutoSize = True
        Me.label3.Location = New System.Drawing.Point(41, 104)
        Me.label3.Name = "label3"
        Me.label3.Size = New System.Drawing.Size(74, 13)
        Me.label3.TabIndex = 2
        Me.label3.Text = "Length (secs.)"
        '
        ' longProcessButton
        '
        Me.longProcessButton.Location = New System.Drawing.Point(286, 101)
        Me.longProcessButton.Name = "longProcessButton"
        Me.longProcessButton.Size = New System.Drawing.Size(136, 23)
        Me.longProcessButton.TabIndex = 4
        Me.longProcessButton.Text = "Run Long Process"
        Me.longProcessButton.UseVisualStyleBackColor = True
        AddHandler longProcessButton.Click, AddressOf Me.longProcessButton_Click
        '
        ' longProcessDelayTextBox
        '
        Me.longProcessDelayTextBox.Location = New System.Drawing.Point(136, 101)
        Me.longProcessDelayTextBox.Name = "longProcessDelayTextBox"
        Me.longProcessDelayTextBox.Size = New System.Drawing.Size(121, 20)
        Me.longProcessDelayTextBox.TabIndex = 3
        Me.longProcessDelayTextBox.Text = "2"
        '
        ' label9
        '
        Me.label9.Location = New System.Drawing.Point(34, 36)
        Me.label9.Name = "label9"
        Me.label9.Size = New System.Drawing.Size(402, 52)
        Me.label9.TabIndex = 1
        Me.label9.Text = ("This demonstration simulates running a lengthy process. It will time out if you s" + ("et the execution time longer than 3 seconds. Trace information is written to a t" + "ext file in the TraceData folder."))
        '
        ' label10
        '
        Me.label10.AutoSize = True
        Me.label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.label10.Location = New System.Drawing.Point(34, 12)
        Me.label10.Name = "label10"
        Me.label10.Size = New System.Drawing.Size(183, 18)
        Me.label10.TabIndex = 0
        Me.label10.Text = "Run a Lengthy Process"
        '
        ' closeButton
        '
        Me.closeButton.Location = New System.Drawing.Point(423, 513)
        Me.closeButton.Name = "closeButton"
        Me.closeButton.Size = New System.Drawing.Size(75, 23)
        Me.closeButton.TabIndex = 4
        Me.closeButton.Text = "Close"
        Me.closeButton.UseVisualStyleBackColor = True
        AddHandler closeButton.Click, AddressOf Me.closeButton_Click
        '
        ' Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(535, 551)
        Me.Controls.Add(Me.closeButton)
        Me.Controls.Add(Me.panel3)
        Me.Controls.Add(Me.panel2)
        Me.Controls.Add(Me.panel1)
        Me.Controls.Add(Me.menuStrip1)
        Me.MainMenuStrip = Me.menuStrip1
        Me.Name = "Form1"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Tracing"
        AddHandler Load, AddressOf Me.Form1_Load
        Me.panel1.ResumeLayout(False)
        Me.panel1.PerformLayout()
        Me.menuStrip1.ResumeLayout(False)
        Me.menuStrip1.PerformLayout()
        Me.panel2.ResumeLayout(False)
        Me.panel2.PerformLayout()
        Me.panel3.ResumeLayout(False)
        Me.panel3.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()
    End Sub
End Class

