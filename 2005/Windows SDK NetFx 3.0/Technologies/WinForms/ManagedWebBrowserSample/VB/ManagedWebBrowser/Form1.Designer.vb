

Partial Class Form1
    Inherits System.Windows.Forms.Form
        '/ <summary>
    '/ Required method for Designer support - do not modify
    '/ the contents of this method with the code editor.
    '/ </summary>
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form1))
        Me.splitContainer1 = New System.Windows.Forms.SplitContainer
        Me.groupBox3 = New System.Windows.Forms.GroupBox
        Me.label3 = New System.Windows.Forms.Label
        Me.loadScriptButton = New System.Windows.Forms.Button
        Me.groupBox2 = New System.Windows.Forms.GroupBox
        Me.label2 = New System.Windows.Forms.Label
        Me.browseButton = New System.Windows.Forms.Button
        Me.htmlFileName = New System.Windows.Forms.TextBox
        Me.filenameLabel = New System.Windows.Forms.Label
        Me.groupBox1 = New System.Windows.Forms.GroupBox
        Me.label1 = New System.Windows.Forms.Label
        Me.toolStrip1 = New System.Windows.Forms.ToolStrip
        Me.backButton = New System.Windows.Forms.ToolStripButton
        Me.forwardButton = New System.Windows.Forms.ToolStripButton
        Me.stopButton = New System.Windows.Forms.ToolStripButton
        Me.refreshButton = New System.Windows.Forms.ToolStripButton
        Me.homeButton = New System.Windows.Forms.ToolStripButton
        Me.urlAddress = New System.Windows.Forms.ToolStripTextBox
        Me.goButton = New System.Windows.Forms.ToolStripButton
        Me.webBrowser1 = New System.Windows.Forms.WebBrowser
        Me.openFileDialog1 = New System.Windows.Forms.OpenFileDialog
        Me.splitContainer1.Panel1.SuspendLayout()
        Me.splitContainer1.Panel2.SuspendLayout()
        Me.splitContainer1.SuspendLayout()
        Me.groupBox3.SuspendLayout()
        Me.groupBox2.SuspendLayout()
        Me.groupBox1.SuspendLayout()
        Me.toolStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'splitContainer1
        '
        resources.ApplyResources(Me.splitContainer1, "splitContainer1")
        Me.splitContainer1.Name = "splitContainer1"
        '
        'splitContainer1.Panel1
        '
        Me.splitContainer1.Panel1.Controls.Add(Me.groupBox3)
        Me.splitContainer1.Panel1.Controls.Add(Me.groupBox2)
        Me.splitContainer1.Panel1.Controls.Add(Me.groupBox1)
        '
        'splitContainer1.Panel2
        '
        Me.splitContainer1.Panel2.Controls.Add(Me.webBrowser1)
        '
        'groupBox3
        '
        Me.groupBox3.Controls.Add(Me.label3)
        Me.groupBox3.Controls.Add(Me.loadScriptButton)
        resources.ApplyResources(Me.groupBox3, "groupBox3")
        Me.groupBox3.Name = "groupBox3"
        Me.groupBox3.TabStop = False
        '
        'label3
        '
        resources.ApplyResources(Me.label3, "label3")
        Me.label3.Name = "label3"
        '
        'loadScriptButton
        '
        resources.ApplyResources(Me.loadScriptButton, "loadScriptButton")
        Me.loadScriptButton.Name = "loadScriptButton"
        '
        'groupBox2
        '
        Me.groupBox2.Controls.Add(Me.label2)
        Me.groupBox2.Controls.Add(Me.browseButton)
        Me.groupBox2.Controls.Add(Me.htmlFileName)
        Me.groupBox2.Controls.Add(Me.filenameLabel)
        resources.ApplyResources(Me.groupBox2, "groupBox2")
        Me.groupBox2.Name = "groupBox2"
        Me.groupBox2.TabStop = False
        '
        'label2
        '
        resources.ApplyResources(Me.label2, "label2")
        Me.label2.Name = "label2"
        '
        'browseButton
        '
        resources.ApplyResources(Me.browseButton, "browseButton")
        Me.browseButton.Name = "browseButton"
        '
        'htmlFileName
        '
        resources.ApplyResources(Me.htmlFileName, "htmlFileName")
        Me.htmlFileName.Name = "htmlFileName"
        '
        'filenameLabel
        '
        resources.ApplyResources(Me.filenameLabel, "filenameLabel")
        Me.filenameLabel.Name = "filenameLabel"
        '
        'groupBox1
        '
        Me.groupBox1.Controls.Add(Me.label1)
        Me.groupBox1.Controls.Add(Me.toolStrip1)
        resources.ApplyResources(Me.groupBox1, "groupBox1")
        Me.groupBox1.Name = "groupBox1"
        Me.groupBox1.TabStop = False
        '
        'label1
        '
        resources.ApplyResources(Me.label1, "label1")
        Me.label1.Name = "label1"
        '
        'toolStrip1
        '
        Me.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.toolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.backButton, Me.forwardButton, Me.stopButton, Me.refreshButton, Me.homeButton, Me.urlAddress, Me.goButton})
        resources.ApplyResources(Me.toolStrip1, "toolStrip1")
        Me.toolStrip1.Name = "toolStrip1"
        Me.toolStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.System
        '
        'backButton
        '
        Me.backButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.backButton.Image = Global.ManagedWebBrowserSample.My.Resources.MyResources.back
        Me.backButton.Name = "backButton"
        resources.ApplyResources(Me.backButton, "backButton")
        '
        'forwardButton
        '
        Me.forwardButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.forwardButton.Image = Global.ManagedWebBrowserSample.My.Resources.MyResources.forward
        Me.forwardButton.Name = "forwardButton"
        resources.ApplyResources(Me.forwardButton, "forwardButton")
        '
        'stopButton
        '
        Me.stopButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.stopButton.Image = Global.ManagedWebBrowserSample.My.Resources.MyResources.stopme
        Me.stopButton.Name = "stopButton"
        resources.ApplyResources(Me.stopButton, "stopButton")
        '
        'refreshButton
        '
        Me.refreshButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.refreshButton.Image = Global.ManagedWebBrowserSample.My.Resources.MyResources.refresh
        Me.refreshButton.Name = "refreshButton"
        resources.ApplyResources(Me.refreshButton, "refreshButton")
        '
        'homeButton
        '
        Me.homeButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.homeButton.Image = Global.ManagedWebBrowserSample.My.Resources.MyResources.home
        Me.homeButton.Name = "homeButton"
        resources.ApplyResources(Me.homeButton, "homeButton")
        '
        'urlAddress
        '
        Me.urlAddress.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.ImageAndText
        resources.ApplyResources(Me.urlAddress, "urlAddress")
        Me.urlAddress.Name = "urlAddress"
        '
        'goButton
        '
        Me.goButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.goButton.Image = Global.ManagedWebBrowserSample.My.Resources.MyResources.go
        Me.goButton.Name = "goButton"
        resources.ApplyResources(Me.goButton, "goButton")
        '
        'webBrowser1
        '
        resources.ApplyResources(Me.webBrowser1, "webBrowser1")
        Me.webBrowser1.Name = "webBrowser1"
        '
        'openFileDialog1
        '
        resources.ApplyResources(Me.openFileDialog1, "openFileDialog1")
        '
        'Form1
        '
        resources.ApplyResources(Me, "$this")
        Me.Controls.Add(Me.splitContainer1)
        Me.Name = "Form1"
        Me.splitContainer1.Panel1.ResumeLayout(False)
        Me.splitContainer1.Panel2.ResumeLayout(False)
        Me.splitContainer1.ResumeLayout(False)
        Me.groupBox3.ResumeLayout(False)
        Me.groupBox2.ResumeLayout(False)
        Me.groupBox2.PerformLayout()
        Me.groupBox1.ResumeLayout(False)
        Me.groupBox1.PerformLayout()
        Me.toolStrip1.ResumeLayout(False)
        Me.toolStrip1.PerformLayout()
        Me.ResumeLayout(False)

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

    End Sub
    Friend WithEvents splitContainer1 As System.Windows.Forms.SplitContainer
    Friend WithEvents webBrowser1 As System.Windows.Forms.WebBrowser
    Friend WithEvents groupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents toolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents backButton As System.Windows.Forms.ToolStripButton
    Friend WithEvents forwardButton As System.Windows.Forms.ToolStripButton
    Friend WithEvents stopButton As System.Windows.Forms.ToolStripButton
    Friend WithEvents refreshButton As System.Windows.Forms.ToolStripButton
    Friend WithEvents homeButton As System.Windows.Forms.ToolStripButton
    Friend WithEvents urlAddress As System.Windows.Forms.ToolStripTextBox
    Friend WithEvents goButton As System.Windows.Forms.ToolStripButton
    Friend WithEvents groupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents browseButton As System.Windows.Forms.Button
    Friend WithEvents htmlFileName As System.Windows.Forms.TextBox
    Friend WithEvents filenameLabel As System.Windows.Forms.Label
    Friend WithEvents openFileDialog1 As System.Windows.Forms.OpenFileDialog
    Friend WithEvents groupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents label1 As System.Windows.Forms.Label
    Friend WithEvents label2 As System.Windows.Forms.Label
    Friend WithEvents loadScriptButton As System.Windows.Forms.Button
    Friend WithEvents label3 As System.Windows.Forms.Label 'Dispose


 End Class 'Form1
