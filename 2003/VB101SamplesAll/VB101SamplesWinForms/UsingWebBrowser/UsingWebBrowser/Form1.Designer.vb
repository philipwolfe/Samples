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
        Me.tabPage3 = New System.Windows.Forms.TabPage
        Me.splitContainer2 = New System.Windows.Forms.SplitContainer
        Me.salesDetailsRowDataGridView = New System.Windows.Forms.DataGridView
        Me.headerIDLabel = New System.Windows.Forms.Label
        Me.headerIDTextBox = New System.Windows.Forms.TextBox
        Me.salesPersonIDLabel = New System.Windows.Forms.Label
        Me.salesPersonIDTextBox = New System.Windows.Forms.TextBox
        Me.salesPersonNameLabel = New System.Windows.Forms.Label
        Me.salesPersonNameTextBox = New System.Windows.Forms.TextBox
        Me.customerIDLabel = New System.Windows.Forms.Label
        Me.customerIDTextBox = New System.Windows.Forms.TextBox
        Me.customerNameLabel = New System.Windows.Forms.Label
        Me.customerNameTextBox = New System.Windows.Forms.TextBox
        Me.salesDateLabel = New System.Windows.Forms.Label
        Me.salesDateDateTimePicker = New System.Windows.Forms.DateTimePicker
        Me.salesTotalLabel = New System.Windows.Forms.Label
        Me.salesTotalTextBox = New System.Windows.Forms.TextBox
        Me.label2 = New System.Windows.Forms.Label
        Me.panel1 = New System.Windows.Forms.Panel
        Me.webBrowser3 = New System.Windows.Forms.WebBrowser
        Me.label3 = New System.Windows.Forms.Label
        Me.webBrowser2 = New System.Windows.Forms.WebBrowser
        Me.viewButton = New System.Windows.Forms.Button
        Me.browseButton = New System.Windows.Forms.Button
        Me.splitContainer1 = New System.Windows.Forms.SplitContainer
        Me.fileNameTextBox = New System.Windows.Forms.TextBox
        Me.htmlDocPanel = New System.Windows.Forms.Panel
        Me.tabPage2 = New System.Windows.Forms.TabPage
        Me.browserGoButton = New System.Windows.Forms.ToolStripButton
        Me.tabPage1 = New System.Windows.Forms.TabPage
        Me.browserPanel = New System.Windows.Forms.Panel
        Me.webBrowser1 = New System.Windows.Forms.WebBrowser
        Me.simpleBrowserStatusStrip = New System.Windows.Forms.StatusStrip
        Me.browserStatusLabel = New System.Windows.Forms.ToolStripStatusLabel
        Me.simpleBrowserToolStrip = New System.Windows.Forms.ToolStrip
        Me.browserBackButton = New System.Windows.Forms.ToolStripButton
        Me.browserForwardButton = New System.Windows.Forms.ToolStripButton
        Me.browserStopButton = New System.Windows.Forms.ToolStripButton
        Me.browserRefreshButton = New System.Windows.Forms.ToolStripButton
        Me.browserSeparator = New System.Windows.Forms.ToolStripSeparator
        Me.browserAddressLabel = New System.Windows.Forms.ToolStripLabel
        Me.browserAddressTextBox = New System.Windows.Forms.ToolStripTextBox
        Me.tabControl1 = New System.Windows.Forms.TabControl
        Me.tabPage3.SuspendLayout()
        Me.splitContainer2.Panel1.SuspendLayout()
        Me.splitContainer2.Panel2.SuspendLayout()
        Me.splitContainer2.SuspendLayout()
        CType(Me.salesDetailsRowDataGridView, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.panel1.SuspendLayout()
        Me.splitContainer1.Panel1.SuspendLayout()
        Me.splitContainer1.Panel2.SuspendLayout()
        Me.splitContainer1.SuspendLayout()
        Me.htmlDocPanel.SuspendLayout()
        Me.tabPage2.SuspendLayout()
        Me.tabPage1.SuspendLayout()
        Me.browserPanel.SuspendLayout()
        Me.simpleBrowserStatusStrip.SuspendLayout()
        Me.simpleBrowserToolStrip.SuspendLayout()
        Me.tabControl1.SuspendLayout()
        Me.SuspendLayout()
        '
        'tabPage3
        '
        Me.tabPage3.Controls.Add(Me.splitContainer2)
        Me.tabPage3.Location = New System.Drawing.Point(4, 22)
        Me.tabPage3.Name = "tabPage3"
        Me.tabPage3.Size = New System.Drawing.Size(534, 390)
        Me.tabPage3.TabIndex = 2
        Me.tabPage3.Text = "2-way Interaction"
        '
        'splitContainer2
        '
        Me.splitContainer2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.splitContainer2.Location = New System.Drawing.Point(0, 0)
        Me.splitContainer2.Name = "splitContainer2"
        '
        'splitContainer2.Panel1
        '
        Me.splitContainer2.Panel1.AutoScroll = True
        Me.splitContainer2.Panel1.BackColor = System.Drawing.Color.Silver
        Me.splitContainer2.Panel1.Controls.Add(Me.salesDetailsRowDataGridView)
        Me.splitContainer2.Panel1.Controls.Add(Me.headerIDLabel)
        Me.splitContainer2.Panel1.Controls.Add(Me.headerIDTextBox)
        Me.splitContainer2.Panel1.Controls.Add(Me.salesPersonIDLabel)
        Me.splitContainer2.Panel1.Controls.Add(Me.salesPersonIDTextBox)
        Me.splitContainer2.Panel1.Controls.Add(Me.salesPersonNameLabel)
        Me.splitContainer2.Panel1.Controls.Add(Me.salesPersonNameTextBox)
        Me.splitContainer2.Panel1.Controls.Add(Me.customerIDLabel)
        Me.splitContainer2.Panel1.Controls.Add(Me.customerIDTextBox)
        Me.splitContainer2.Panel1.Controls.Add(Me.customerNameLabel)
        Me.splitContainer2.Panel1.Controls.Add(Me.customerNameTextBox)
        Me.splitContainer2.Panel1.Controls.Add(Me.salesDateLabel)
        Me.splitContainer2.Panel1.Controls.Add(Me.salesDateDateTimePicker)
        Me.splitContainer2.Panel1.Controls.Add(Me.salesTotalLabel)
        Me.splitContainer2.Panel1.Controls.Add(Me.salesTotalTextBox)
        Me.splitContainer2.Panel1.Controls.Add(Me.label2)
        '
        'splitContainer2.Panel2
        '
        Me.splitContainer2.Panel2.Controls.Add(Me.panel1)
        Me.splitContainer2.Panel2.Controls.Add(Me.label3)
        Me.splitContainer2.Size = New System.Drawing.Size(534, 390)
        Me.splitContainer2.SplitterDistance = 238
        Me.splitContainer2.SplitterIncrement = 10
        Me.splitContainer2.SplitterWidth = 6
        Me.splitContainer2.TabIndex = 1
        Me.splitContainer2.Text = "splitContainer2"
        '
        'salesDetailsRowDataGridView
        '
        Me.salesDetailsRowDataGridView.Location = New System.Drawing.Point(5, 243)
        Me.salesDetailsRowDataGridView.Name = "salesDetailsRowDataGridView"
        Me.salesDetailsRowDataGridView.Size = New System.Drawing.Size(305, 201)
        Me.salesDetailsRowDataGridView.TabIndex = 16
        '
        'headerIDLabel
        '
        Me.headerIDLabel.AutoSize = True
        Me.headerIDLabel.Location = New System.Drawing.Point(4, 58)
        Me.headerIDLabel.Name = "headerIDLabel"
        Me.headerIDLabel.Size = New System.Drawing.Size(55, 13)
        Me.headerIDLabel.TabIndex = 1
        Me.headerIDLabel.Text = "Header ID:"
        '
        'headerIDTextBox
        '
        Me.headerIDTextBox.Location = New System.Drawing.Point(110, 55)
        Me.headerIDTextBox.Name = "headerIDTextBox"
        Me.headerIDTextBox.Size = New System.Drawing.Size(200, 20)
        Me.headerIDTextBox.TabIndex = 2
        '
        'salesPersonIDLabel
        '
        Me.salesPersonIDLabel.AutoSize = True
        Me.salesPersonIDLabel.Location = New System.Drawing.Point(4, 85)
        Me.salesPersonIDLabel.Name = "salesPersonIDLabel"
        Me.salesPersonIDLabel.Size = New System.Drawing.Size(82, 13)
        Me.salesPersonIDLabel.TabIndex = 3
        Me.salesPersonIDLabel.Text = "Sales Person ID:"
        '
        'salesPersonIDTextBox
        '
        Me.salesPersonIDTextBox.Location = New System.Drawing.Point(110, 82)
        Me.salesPersonIDTextBox.Name = "salesPersonIDTextBox"
        Me.salesPersonIDTextBox.Size = New System.Drawing.Size(200, 20)
        Me.salesPersonIDTextBox.TabIndex = 4
        '
        'salesPersonNameLabel
        '
        Me.salesPersonNameLabel.AutoSize = True
        Me.salesPersonNameLabel.Location = New System.Drawing.Point(4, 112)
        Me.salesPersonNameLabel.Name = "salesPersonNameLabel"
        Me.salesPersonNameLabel.Size = New System.Drawing.Size(99, 13)
        Me.salesPersonNameLabel.TabIndex = 5
        Me.salesPersonNameLabel.Text = "Sales Person Name:"
        '
        'salesPersonNameTextBox
        '
        Me.salesPersonNameTextBox.Location = New System.Drawing.Point(110, 109)
        Me.salesPersonNameTextBox.Name = "salesPersonNameTextBox"
        Me.salesPersonNameTextBox.Size = New System.Drawing.Size(200, 20)
        Me.salesPersonNameTextBox.TabIndex = 6
        '
        'customerIDLabel
        '
        Me.customerIDLabel.AutoSize = True
        Me.customerIDLabel.Location = New System.Drawing.Point(4, 139)
        Me.customerIDLabel.Name = "customerIDLabel"
        Me.customerIDLabel.Size = New System.Drawing.Size(64, 13)
        Me.customerIDLabel.TabIndex = 7
        Me.customerIDLabel.Text = "Customer ID:"
        '
        'customerIDTextBox
        '
        Me.customerIDTextBox.Location = New System.Drawing.Point(110, 136)
        Me.customerIDTextBox.Name = "customerIDTextBox"
        Me.customerIDTextBox.Size = New System.Drawing.Size(200, 20)
        Me.customerIDTextBox.TabIndex = 8
        '
        'customerNameLabel
        '
        Me.customerNameLabel.AutoSize = True
        Me.customerNameLabel.Location = New System.Drawing.Point(4, 166)
        Me.customerNameLabel.Name = "customerNameLabel"
        Me.customerNameLabel.Size = New System.Drawing.Size(81, 13)
        Me.customerNameLabel.TabIndex = 9
        Me.customerNameLabel.Text = "Customer Name:"
        '
        'customerNameTextBox
        '
        Me.customerNameTextBox.Location = New System.Drawing.Point(110, 163)
        Me.customerNameTextBox.Name = "customerNameTextBox"
        Me.customerNameTextBox.Size = New System.Drawing.Size(200, 20)
        Me.customerNameTextBox.TabIndex = 10
        '
        'salesDateLabel
        '
        Me.salesDateLabel.AutoSize = True
        Me.salesDateLabel.Location = New System.Drawing.Point(4, 190)
        Me.salesDateLabel.Name = "salesDateLabel"
        Me.salesDateLabel.Size = New System.Drawing.Size(58, 13)
        Me.salesDateLabel.TabIndex = 11
        Me.salesDateLabel.Text = "Sales Date:"
        '
        'salesDateDateTimePicker
        '
        Me.salesDateDateTimePicker.Location = New System.Drawing.Point(110, 190)
        Me.salesDateDateTimePicker.Name = "salesDateDateTimePicker"
        Me.salesDateDateTimePicker.Size = New System.Drawing.Size(200, 20)
        Me.salesDateDateTimePicker.TabIndex = 12
        '
        'salesTotalLabel
        '
        Me.salesTotalLabel.AutoSize = True
        Me.salesTotalLabel.Location = New System.Drawing.Point(4, 220)
        Me.salesTotalLabel.Name = "salesTotalLabel"
        Me.salesTotalLabel.Size = New System.Drawing.Size(59, 13)
        Me.salesTotalLabel.TabIndex = 13
        Me.salesTotalLabel.Text = "Sales Total:"
        '
        'salesTotalTextBox
        '
        Me.salesTotalTextBox.Location = New System.Drawing.Point(110, 217)
        Me.salesTotalTextBox.Name = "salesTotalTextBox"
        Me.salesTotalTextBox.Size = New System.Drawing.Size(200, 20)
        Me.salesTotalTextBox.TabIndex = 14
        '
        'label2
        '
        Me.label2.AutoSize = True
        Me.label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.label2.Location = New System.Drawing.Point(3, 25)
        Me.label2.Name = "label2"
        Me.label2.Size = New System.Drawing.Size(150, 24)
        Me.label2.TabIndex = 0
        Me.label2.Text = "Parts Order Form"
        '
        'panel1
        '
        Me.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.panel1.Controls.Add(Me.webBrowser3)
        Me.panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.panel1.Location = New System.Drawing.Point(0, 24)
        Me.panel1.Name = "panel1"
        Me.panel1.Size = New System.Drawing.Size(286, 362)
        Me.panel1.TabIndex = 3
        '
        'webBrowser3
        '
        Me.webBrowser3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.webBrowser3.Location = New System.Drawing.Point(0, 0)
        Me.webBrowser3.Name = "webBrowser3"
        Me.webBrowser3.Size = New System.Drawing.Size(282, 358)
        '
        'label3
        '
        Me.label3.AutoSize = True
        Me.label3.Dock = System.Windows.Forms.DockStyle.Top
        Me.label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.label3.Location = New System.Drawing.Point(0, 0)
        Me.label3.Name = "label3"
        Me.label3.Size = New System.Drawing.Size(89, 24)
        Me.label3.TabIndex = 2
        Me.label3.Text = "Print View"
        '
        'webBrowser2
        '
        Me.webBrowser2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.webBrowser2.Location = New System.Drawing.Point(0, 0)
        Me.webBrowser2.Name = "webBrowser2"
        Me.webBrowser2.Size = New System.Drawing.Size(524, 334)
        '
        'viewButton
        '
        Me.viewButton.Location = New System.Drawing.Point(428, 7)
        Me.viewButton.Name = "viewButton"
        Me.viewButton.Size = New System.Drawing.Size(75, 23)
        Me.viewButton.TabIndex = 3
        Me.viewButton.Text = "View"
        '
        'browseButton
        '
        Me.browseButton.Location = New System.Drawing.Point(330, 7)
        Me.browseButton.Name = "browseButton"
        Me.browseButton.Size = New System.Drawing.Size(89, 23)
        Me.browseButton.TabIndex = 1
        Me.browseButton.Text = "Browse..."
        '
        'splitContainer1
        '
        Me.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1
        Me.splitContainer1.Location = New System.Drawing.Point(3, 3)
        Me.splitContainer1.Name = "splitContainer1"
        Me.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'splitContainer1.Panel1
        '
        Me.splitContainer1.Panel1.Controls.Add(Me.viewButton)
        Me.splitContainer1.Panel1.Controls.Add(Me.browseButton)
        Me.splitContainer1.Panel1.Controls.Add(Me.fileNameTextBox)
        '
        'splitContainer1.Panel2
        '
        Me.splitContainer1.Panel2.Controls.Add(Me.htmlDocPanel)
        Me.splitContainer1.Size = New System.Drawing.Size(528, 384)
        Me.splitContainer1.SplitterDistance = 42
        Me.splitContainer1.TabIndex = 0
        Me.splitContainer1.Text = "splitContainer1"
        '
        'fileNameTextBox
        '
        Me.fileNameTextBox.Location = New System.Drawing.Point(16, 9)
        Me.fileNameTextBox.Name = "fileNameTextBox"
        Me.fileNameTextBox.Size = New System.Drawing.Size(303, 20)
        Me.fileNameTextBox.TabIndex = 0
        '
        'htmlDocPanel
        '
        Me.htmlDocPanel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.htmlDocPanel.Controls.Add(Me.webBrowser2)
        Me.htmlDocPanel.Dock = System.Windows.Forms.DockStyle.Fill
        Me.htmlDocPanel.Location = New System.Drawing.Point(0, 0)
        Me.htmlDocPanel.Name = "htmlDocPanel"
        Me.htmlDocPanel.Size = New System.Drawing.Size(528, 338)
        Me.htmlDocPanel.TabIndex = 0
        '
        'tabPage2
        '
        Me.tabPage2.Controls.Add(Me.splitContainer1)
        Me.tabPage2.Location = New System.Drawing.Point(4, 22)
        Me.tabPage2.Name = "tabPage2"
        Me.tabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.tabPage2.Size = New System.Drawing.Size(534, 390)
        Me.tabPage2.TabIndex = 1
        Me.tabPage2.Text = "HTML Doc Viewer"
        '
        'browserGoButton
        '
        Me.browserGoButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.browserGoButton.Name = "browserGoButton"
        Me.browserGoButton.Text = "Go"
        '
        'tabPage1
        '
        Me.tabPage1.Controls.Add(Me.browserPanel)
        Me.tabPage1.Controls.Add(Me.simpleBrowserStatusStrip)
        Me.tabPage1.Controls.Add(Me.simpleBrowserToolStrip)
        Me.tabPage1.Location = New System.Drawing.Point(4, 22)
        Me.tabPage1.Name = "tabPage1"
        Me.tabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.tabPage1.Size = New System.Drawing.Size(534, 390)
        Me.tabPage1.TabIndex = 0
        Me.tabPage1.Text = "Simple Browser"
        '
        'browserPanel
        '
        Me.browserPanel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.browserPanel.Controls.Add(Me.webBrowser1)
        Me.browserPanel.Dock = System.Windows.Forms.DockStyle.Fill
        Me.browserPanel.Location = New System.Drawing.Point(3, 28)
        Me.browserPanel.Name = "browserPanel"
        Me.browserPanel.Size = New System.Drawing.Size(528, 334)
        Me.browserPanel.TabIndex = 2
        '
        'webBrowser1
        '
        Me.webBrowser1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.webBrowser1.Location = New System.Drawing.Point(0, 0)
        Me.webBrowser1.Name = "webBrowser1"
        Me.webBrowser1.Size = New System.Drawing.Size(524, 330)
        '
        'simpleBrowserStatusStrip
        '
        Me.simpleBrowserStatusStrip.AutoSize = False
        Me.simpleBrowserStatusStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.browserStatusLabel})
        Me.simpleBrowserStatusStrip.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.Table
        Me.simpleBrowserStatusStrip.Location = New System.Drawing.Point(3, 362)
        Me.simpleBrowserStatusStrip.Name = "simpleBrowserStatusStrip"
        Me.simpleBrowserStatusStrip.Size = New System.Drawing.Size(528, 25)
        Me.simpleBrowserStatusStrip.TabIndex = 1
        Me.simpleBrowserStatusStrip.Text = "statusStrip1"
        '
        'browserStatusLabel
        '
        Me.browserStatusLabel.AutoSize = False
        Me.browserStatusLabel.Name = "browserStatusLabel"
        Me.browserStatusLabel.Size = New System.Drawing.Size(23, 23)
        Me.browserStatusLabel.Spring = True
        Me.browserStatusLabel.TextAlign = System.Drawing.ContentAlignment.TopLeft
        '
        'simpleBrowserToolStrip
        '
        Me.simpleBrowserToolStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.browserBackButton, Me.browserForwardButton, Me.browserStopButton, Me.browserRefreshButton, Me.browserSeparator, Me.browserAddressLabel, Me.browserAddressTextBox, Me.browserGoButton})
        Me.simpleBrowserToolStrip.Location = New System.Drawing.Point(3, 3)
        Me.simpleBrowserToolStrip.Name = "simpleBrowserToolStrip"
        Me.simpleBrowserToolStrip.Size = New System.Drawing.Size(528, 25)
        Me.simpleBrowserToolStrip.TabIndex = 0
        Me.simpleBrowserToolStrip.Text = "toolStrip1"
        '
        'browserBackButton
        '
        Me.browserBackButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.browserBackButton.Name = "browserBackButton"
        Me.browserBackButton.Text = "Back"
        '
        'browserForwardButton
        '
        Me.browserForwardButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.browserForwardButton.Name = "browserForwardButton"
        Me.browserForwardButton.Text = "Forward"
        '
        'browserStopButton
        '
        Me.browserStopButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.browserStopButton.Name = "browserStopButton"
        Me.browserStopButton.Text = "Stop"
        '
        'browserRefreshButton
        '
        Me.browserRefreshButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.browserRefreshButton.Name = "browserRefreshButton"
        Me.browserRefreshButton.Text = "Refresh"
        '
        'browserSeparator
        '
        Me.browserSeparator.Name = "browserSeparator"
        '
        'browserAddressLabel
        '
        Me.browserAddressLabel.Name = "browserAddressLabel"
        Me.browserAddressLabel.Text = "Address: "
        '
        'browserAddressTextBox
        '
        Me.browserAddressTextBox.AutoSize = False
        Me.browserAddressTextBox.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.ImageAndText
        Me.browserAddressTextBox.Name = "browserAddressTextBox"
        Me.browserAddressTextBox.Size = New System.Drawing.Size(200, 21)
        Me.browserAddressTextBox.Text = "msdn.microsoft.com"
        '
        'tabControl1
        '
        Me.tabControl1.Controls.Add(Me.tabPage1)
        Me.tabControl1.Controls.Add(Me.tabPage2)
        Me.tabControl1.Controls.Add(Me.tabPage3)
        Me.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tabControl1.Location = New System.Drawing.Point(0, 0)
        Me.tabControl1.Name = "tabControl1"
        Me.tabControl1.SelectedIndex = 0
        Me.tabControl1.Size = New System.Drawing.Size(542, 416)
        Me.tabControl1.TabIndex = 2
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(542, 416)
        Me.Controls.Add(Me.tabControl1)
        Me.Name = "Form1"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Using the Web Browser Control"
        Me.tabPage3.ResumeLayout(False)
        Me.splitContainer2.Panel1.ResumeLayout(False)
        Me.splitContainer2.Panel1.PerformLayout()
        Me.splitContainer2.Panel2.ResumeLayout(False)
        Me.splitContainer2.Panel2.PerformLayout()
        Me.splitContainer2.ResumeLayout(False)
        CType(Me.salesDetailsRowDataGridView, System.ComponentModel.ISupportInitialize).EndInit()
        Me.panel1.ResumeLayout(False)
        Me.splitContainer1.Panel1.ResumeLayout(False)
        Me.splitContainer1.Panel1.PerformLayout()
        Me.splitContainer1.Panel2.ResumeLayout(False)
        Me.splitContainer1.ResumeLayout(False)
        Me.htmlDocPanel.ResumeLayout(False)
        Me.tabPage2.ResumeLayout(False)
        Me.tabPage1.ResumeLayout(False)
        Me.tabPage1.PerformLayout()
        Me.browserPanel.ResumeLayout(False)
        Me.simpleBrowserStatusStrip.ResumeLayout(False)
        Me.simpleBrowserToolStrip.ResumeLayout(False)
        Me.simpleBrowserToolStrip.PerformLayout()
        Me.tabControl1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents tabPage3 As System.Windows.Forms.TabPage
    Friend WithEvents splitContainer2 As System.Windows.Forms.SplitContainer
    Friend WithEvents salesDetailsRowDataGridView As System.Windows.Forms.DataGridView
    Friend WithEvents headerIDLabel As System.Windows.Forms.Label
    Friend WithEvents headerIDTextBox As System.Windows.Forms.TextBox
    Friend WithEvents salesPersonIDLabel As System.Windows.Forms.Label
    Friend WithEvents salesPersonIDTextBox As System.Windows.Forms.TextBox
    Friend WithEvents salesPersonNameLabel As System.Windows.Forms.Label
    Friend WithEvents salesPersonNameTextBox As System.Windows.Forms.TextBox
    Friend WithEvents customerIDLabel As System.Windows.Forms.Label
    Friend WithEvents customerIDTextBox As System.Windows.Forms.TextBox
    Friend WithEvents customerNameLabel As System.Windows.Forms.Label
    Friend WithEvents customerNameTextBox As System.Windows.Forms.TextBox
    Friend WithEvents salesDateLabel As System.Windows.Forms.Label
    Friend WithEvents salesDateDateTimePicker As System.Windows.Forms.DateTimePicker
    Friend WithEvents salesTotalLabel As System.Windows.Forms.Label
    Friend WithEvents salesTotalTextBox As System.Windows.Forms.TextBox
    Friend WithEvents label2 As System.Windows.Forms.Label
    Friend WithEvents panel1 As System.Windows.Forms.Panel
    Friend WithEvents webBrowser3 As System.Windows.Forms.WebBrowser
    Friend WithEvents label3 As System.Windows.Forms.Label
    Friend WithEvents webBrowser2 As System.Windows.Forms.WebBrowser
    Friend WithEvents viewButton As System.Windows.Forms.Button
    Friend WithEvents browseButton As System.Windows.Forms.Button
    Friend WithEvents splitContainer1 As System.Windows.Forms.SplitContainer
    Friend WithEvents fileNameTextBox As System.Windows.Forms.TextBox
    Friend WithEvents htmlDocPanel As System.Windows.Forms.Panel
    Friend WithEvents tabPage2 As System.Windows.Forms.TabPage
    Friend WithEvents browserGoButton As System.Windows.Forms.ToolStripButton
    Friend WithEvents tabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents browserPanel As System.Windows.Forms.Panel
    Friend WithEvents webBrowser1 As System.Windows.Forms.WebBrowser
    Friend WithEvents simpleBrowserStatusStrip As System.Windows.Forms.StatusStrip
    Friend WithEvents browserStatusLabel As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents simpleBrowserToolStrip As System.Windows.Forms.ToolStrip
    Friend WithEvents browserBackButton As System.Windows.Forms.ToolStripButton
    Friend WithEvents browserForwardButton As System.Windows.Forms.ToolStripButton
    Friend WithEvents browserStopButton As System.Windows.Forms.ToolStripButton
    Friend WithEvents browserRefreshButton As System.Windows.Forms.ToolStripButton
    Friend WithEvents browserSeparator As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents browserAddressLabel As System.Windows.Forms.ToolStripLabel
    Friend WithEvents browserAddressTextBox As System.Windows.Forms.ToolStripTextBox
    Friend WithEvents tabControl1 As System.Windows.Forms.TabControl

End Class
