<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Public Class MainForm
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(MainForm))
        Me.LayoutToolStrip = New System.Windows.Forms.ToolStrip
        Me.flowDirectionDropDown = New System.Windows.Forms.ToolStripDropDownButton
        Me.horizontalToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.verticalToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.toolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator
        Me.FlowTabPage = New System.Windows.Forms.TabPage
        Me.flowLayoutPanel = New System.Windows.Forms.FlowLayoutPanel
        Me.flowLabel = New System.Windows.Forms.Label
        Me.UserInfo = New System.Windows.Forms.GroupBox
        Me.DepartmentInfo = New System.Windows.Forms.GroupBox
        Me.SalesForcastInfo = New System.Windows.Forms.GroupBox
        Me.singleBorderToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.insetBorderToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.outsetBorderToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.noneBorderToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.tableLayoutPanel = New System.Windows.Forms.TableLayoutPanel
        Me.FirstNameLabel = New System.Windows.Forms.Label
        Me.FirstName = New System.Windows.Forms.TextBox
        Me.LastNameLabel = New System.Windows.Forms.Label
        Me.LastName = New System.Windows.Forms.TextBox
        Me.BiographyLabel = New System.Windows.Forms.Label
        Me.Biography = New System.Windows.Forms.TextBox
        Me.DepartmentLabel = New System.Windows.Forms.Label
        Me.Departments = New System.Windows.Forms.ComboBox
        Me.tableLabel = New System.Windows.Forms.Label
        Me.tabControl1 = New System.Windows.Forms.TabControl
        Me.TableTabPage = New System.Windows.Forms.TabPage
        Me.TableToolStrip = New System.Windows.Forms.ToolStrip
        Me.cellBorderStyles = New System.Windows.Forms.ToolStripDropDownButton
        Me.LayoutToolStrip.SuspendLayout()
        Me.FlowTabPage.SuspendLayout()
        Me.flowLayoutPanel.SuspendLayout()
        Me.tableLayoutPanel.SuspendLayout()
        Me.tabControl1.SuspendLayout()
        Me.TableTabPage.SuspendLayout()
        Me.TableToolStrip.SuspendLayout()
        Me.SuspendLayout()
        '
        'LayoutToolStrip
        '
        Me.LayoutToolStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.flowDirectionDropDown, Me.toolStripSeparator3})
        Me.LayoutToolStrip.Location = New System.Drawing.Point(3, 3)
        Me.LayoutToolStrip.Name = "LayoutToolStrip"
        Me.LayoutToolStrip.Size = New System.Drawing.Size(528, 25)
        Me.LayoutToolStrip.TabIndex = 0
        Me.LayoutToolStrip.Text = "toolStrip1"
        '
        'flowDirectionDropDown
        '
        Me.flowDirectionDropDown.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.flowDirectionDropDown.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.horizontalToolStripMenuItem, Me.verticalToolStripMenuItem})
        Me.flowDirectionDropDown.Image = CType(resources.GetObject("flowDirectionDropDown.Image"), System.Drawing.Image)
        Me.flowDirectionDropDown.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.flowDirectionDropDown.Name = "flowDirectionDropDown"
        Me.flowDirectionDropDown.Text = "Flow Direction"
        '
        'horizontalToolStripMenuItem
        '
        Me.horizontalToolStripMenuItem.Name = "horizontalToolStripMenuItem"
        Me.horizontalToolStripMenuItem.Text = "Horizontal"
        '
        'verticalToolStripMenuItem
        '
        Me.verticalToolStripMenuItem.Name = "verticalToolStripMenuItem"
        Me.verticalToolStripMenuItem.Text = "Vertical"
        '
        'toolStripSeparator3
        '
        Me.toolStripSeparator3.Name = "toolStripSeparator3"
        '
        'FlowTabPage
        '
        Me.FlowTabPage.Controls.Add(Me.LayoutToolStrip)
        Me.FlowTabPage.Controls.Add(Me.flowLayoutPanel)
        Me.FlowTabPage.Location = New System.Drawing.Point(4, 22)
        Me.FlowTabPage.Name = "FlowTabPage"
        Me.FlowTabPage.Padding = New System.Windows.Forms.Padding(3)
        Me.FlowTabPage.Size = New System.Drawing.Size(534, 390)
        Me.FlowTabPage.TabIndex = 1
        Me.FlowTabPage.Text = "FlowLayoutPanel"
        '
        'flowLayoutPanel1
        '
        Me.flowLayoutPanel.Controls.Add(Me.flowLabel)
        Me.flowLayoutPanel.Controls.Add(Me.UserInfo)
        Me.flowLayoutPanel.Controls.Add(Me.DepartmentInfo)
        Me.flowLayoutPanel.Controls.Add(Me.SalesForcastInfo)
        Me.flowLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill
        Me.flowLayoutPanel.Location = New System.Drawing.Point(3, 3)
        Me.flowLayoutPanel.Margin = New System.Windows.Forms.Padding(3, 300, 3, 3)
        Me.flowLayoutPanel.Name = "flowLayoutPanel1"
        Me.flowLayoutPanel.Padding = New System.Windows.Forms.Padding(0, 25, 0, 0)
        Me.flowLayoutPanel.Size = New System.Drawing.Size(528, 384)
        Me.flowLayoutPanel.TabIndex = 1
        '
        'flowLabel
        '
        Me.flowLabel.AutoSize = True
        Me.flowLabel.Location = New System.Drawing.Point(3, 25)
        Me.flowLabel.Name = "flowLabel"
        Me.flowLabel.Size = New System.Drawing.Size(515, 39)
        Me.flowLabel.TabIndex = 3
        Me.flowLabel.Text = resources.GetString("flowLabel.Text")
        '
        'UserInfo
        '
        Me.UserInfo.Location = New System.Drawing.Point(3, 67)
        Me.UserInfo.Name = "UserInfo"
        Me.UserInfo.Size = New System.Drawing.Size(146, 65)
        Me.UserInfo.TabIndex = 0
        Me.UserInfo.TabStop = False
        Me.UserInfo.Text = "User Information"
        '
        'DepartmentInfo
        '
        Me.DepartmentInfo.Location = New System.Drawing.Point(155, 67)
        Me.DepartmentInfo.Name = "DepartmentInfo"
        Me.DepartmentInfo.Size = New System.Drawing.Size(111, 65)
        Me.DepartmentInfo.TabIndex = 1
        Me.DepartmentInfo.TabStop = False
        Me.DepartmentInfo.Text = "Department"
        '
        'SalesForcastInfo
        '
        Me.SalesForcastInfo.Location = New System.Drawing.Point(3, 138)
        Me.SalesForcastInfo.Name = "SalesForcastInfo"
        Me.SalesForcastInfo.Size = New System.Drawing.Size(356, 141)
        Me.SalesForcastInfo.TabIndex = 2
        Me.SalesForcastInfo.TabStop = False
        Me.SalesForcastInfo.Text = "Sales Forecast"
        '
        'singleBorderToolStripMenuItem
        '
        Me.singleBorderToolStripMenuItem.Name = "singleBorderToolStripMenuItem"
        Me.singleBorderToolStripMenuItem.Text = "Single"
        '
        'insetBorderToolStripMenuItem
        '
        Me.insetBorderToolStripMenuItem.Name = "insetBorderToolStripMenuItem"
        Me.insetBorderToolStripMenuItem.Text = "Inset"
        '
        'outsetBorderToolStripMenuItem
        '
        Me.outsetBorderToolStripMenuItem.Name = "outsetBorderToolStripMenuItem"
        Me.outsetBorderToolStripMenuItem.Text = "Outset"
        '
        'noneBorderToolStripMenuItem
        '
        Me.noneBorderToolStripMenuItem.Name = "noneBorderToolStripMenuItem"
        Me.noneBorderToolStripMenuItem.Text = "None"
        '
        'tableLayoutPanel1
        '
        Me.tableLayoutPanel.ColumnCount = 5
        Me.tableLayoutPanel.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100.0!))
        Me.tableLayoutPanel.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.tableLayoutPanel.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100.0!))
        Me.tableLayoutPanel.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.tableLayoutPanel.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 120.0!))
        Me.tableLayoutPanel.Controls.Add(Me.FirstNameLabel, 0, 1)
        Me.tableLayoutPanel.Controls.Add(Me.FirstName, 1, 1)
        Me.tableLayoutPanel.Controls.Add(Me.LastNameLabel, 0, 2)
        Me.tableLayoutPanel.Controls.Add(Me.LastName, 1, 2)
        Me.tableLayoutPanel.Controls.Add(Me.BiographyLabel, 0, 3)
        Me.tableLayoutPanel.Controls.Add(Me.Biography, 1, 3)
        Me.tableLayoutPanel.Controls.Add(Me.DepartmentLabel, 2, 1)
        Me.tableLayoutPanel.Controls.Add(Me.Departments, 3, 1)
        Me.tableLayoutPanel.Controls.Add(Me.tableLabel, 0, 0)
        Me.tableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tableLayoutPanel.Location = New System.Drawing.Point(3, 28)
        Me.tableLayoutPanel.Name = "tableLayoutPanel1"
        Me.tableLayoutPanel.RowCount = 5
        Me.tableLayoutPanel.RowStyles.Add(New System.Windows.Forms.RowStyle)
        Me.tableLayoutPanel.RowStyles.Add(New System.Windows.Forms.RowStyle)
        Me.tableLayoutPanel.RowStyles.Add(New System.Windows.Forms.RowStyle)
        Me.tableLayoutPanel.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.tableLayoutPanel.RowStyles.Add(New System.Windows.Forms.RowStyle)
        Me.tableLayoutPanel.Size = New System.Drawing.Size(528, 359)
        Me.tableLayoutPanel.TabIndex = 1
        '
        'FirstNameLabel
        '
        Me.FirstNameLabel.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.FirstNameLabel.AutoSize = True
        Me.FirstNameLabel.Location = New System.Drawing.Point(22, 65)
        Me.FirstNameLabel.Name = "FirstNameLabel"
        Me.FirstNameLabel.Size = New System.Drawing.Size(56, 13)
        Me.FirstNameLabel.TabIndex = 0
        Me.FirstNameLabel.Text = "First Name:"
        '
        'FirstName
        '
        Me.FirstName.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.FirstName.Location = New System.Drawing.Point(103, 61)
        Me.FirstName.Name = "FirstName"
        Me.FirstName.Size = New System.Drawing.Size(98, 20)
        Me.FirstName.TabIndex = 1
        '
        'LastNameLabel
        '
        Me.LastNameLabel.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.LastNameLabel.AutoSize = True
        Me.LastNameLabel.Location = New System.Drawing.Point(21, 91)
        Me.LastNameLabel.Name = "LastNameLabel"
        Me.LastNameLabel.Size = New System.Drawing.Size(57, 13)
        Me.LastNameLabel.TabIndex = 2
        Me.LastNameLabel.Text = "Last Name:"
        '
        'LastName
        '
        Me.LastName.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.LastName.Location = New System.Drawing.Point(103, 88)
        Me.LastName.Name = "LastName"
        Me.LastName.Size = New System.Drawing.Size(98, 20)
        Me.LastName.TabIndex = 3
        '
        'BiographyLabel
        '
        Me.BiographyLabel.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.BiographyLabel.AutoSize = True
        Me.BiographyLabel.Location = New System.Drawing.Point(23, 228)
        Me.BiographyLabel.Name = "BiographyLabel"
        Me.BiographyLabel.Size = New System.Drawing.Size(53, 13)
        Me.BiographyLabel.TabIndex = 4
        Me.BiographyLabel.Text = "Biography:"
        '
        'Biography
        '
        Me.tableLayoutPanel.SetColumnSpan(Me.Biography, 3)
        Me.Biography.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Biography.Location = New System.Drawing.Point(103, 114)
        Me.Biography.Multiline = True
        Me.Biography.Name = "Biography"
        Me.Biography.Size = New System.Drawing.Size(302, 242)
        Me.Biography.TabIndex = 5
        '
        'DepartmentLabel
        '
        Me.DepartmentLabel.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.DepartmentLabel.AutoSize = True
        Me.DepartmentLabel.Location = New System.Drawing.Point(223, 65)
        Me.DepartmentLabel.Name = "DepartmentLabel"
        Me.DepartmentLabel.Size = New System.Drawing.Size(61, 13)
        Me.DepartmentLabel.TabIndex = 6
        Me.DepartmentLabel.Text = "Department:"
        '
        'Departments
        '
        Me.Departments.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Departments.FormattingEnabled = True
        Me.Departments.Location = New System.Drawing.Point(307, 61)
        Me.Departments.Name = "Departments"
        Me.Departments.Size = New System.Drawing.Size(98, 21)
        Me.Departments.TabIndex = 7
        '
        'tableLabel
        '
        Me.tableLabel.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.tableLabel.AutoSize = True
        Me.tableLayoutPanel.SetColumnSpan(Me.tableLabel, 4)
        Me.tableLabel.Location = New System.Drawing.Point(5, 0)
        Me.tableLabel.Name = "tableLabel"
        Me.tableLabel.Padding = New System.Windows.Forms.Padding(2, 4, 2, 2)
        Me.tableLabel.Size = New System.Drawing.Size(398, 58)
        Me.tableLabel.TabIndex = 8
        Me.tableLabel.Text = resources.GetString("tableLabel.Text")
        '
        'tabControl1
        '
        Me.tabControl1.Controls.Add(Me.TableTabPage)
        Me.tabControl1.Controls.Add(Me.FlowTabPage)
        Me.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tabControl1.Location = New System.Drawing.Point(0, 0)
        Me.tabControl1.Name = "tabControl1"
        Me.tabControl1.SelectedIndex = 0
        Me.tabControl1.Size = New System.Drawing.Size(542, 416)
        Me.tabControl1.TabIndex = 1
        '
        'TableTabPage
        '
        Me.TableTabPage.Controls.Add(Me.tableLayoutPanel)
        Me.TableTabPage.Controls.Add(Me.TableToolStrip)
        Me.TableTabPage.Location = New System.Drawing.Point(4, 22)
        Me.TableTabPage.Name = "TableTabPage"
        Me.TableTabPage.Padding = New System.Windows.Forms.Padding(3)
        Me.TableTabPage.Size = New System.Drawing.Size(534, 390)
        Me.TableTabPage.TabIndex = 0
        Me.TableTabPage.Text = "TableLayoutPanel"
        '
        'TableToolStrip
        '
        Me.TableToolStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.cellBorderStyles})
        Me.TableToolStrip.Location = New System.Drawing.Point(3, 3)
        Me.TableToolStrip.Name = "TableToolStrip"
        Me.TableToolStrip.Size = New System.Drawing.Size(528, 25)
        Me.TableToolStrip.TabIndex = 0
        Me.TableToolStrip.Text = "TableToolStrip"
        '
        'cellBorderStyleDropDown
        '
        Me.cellBorderStyles.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.cellBorderStyles.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.noneBorderToolStripMenuItem, Me.singleBorderToolStripMenuItem, Me.insetBorderToolStripMenuItem, Me.outsetBorderToolStripMenuItem})
        Me.cellBorderStyles.Image = CType(resources.GetObject("cellBorderStyleDropDown.Image"), System.Drawing.Image)
        Me.cellBorderStyles.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.cellBorderStyles.Name = "cellBorderStyleDropDown"
        Me.cellBorderStyles.Text = "Cell Border"
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(542, 416)
        Me.Controls.Add(Me.tabControl1)
        Me.Name = "Form1"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Using Layout Panels"
        Me.LayoutToolStrip.ResumeLayout(False)
        Me.FlowTabPage.ResumeLayout(False)
        Me.FlowTabPage.PerformLayout()
        Me.flowLayoutPanel.ResumeLayout(False)
        Me.flowLayoutPanel.PerformLayout()
        Me.tableLayoutPanel.ResumeLayout(False)
        Me.tableLayoutPanel.PerformLayout()
        Me.tabControl1.ResumeLayout(False)
        Me.TableTabPage.ResumeLayout(False)
        Me.TableTabPage.PerformLayout()
        Me.TableToolStrip.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents LayoutToolStrip As System.Windows.Forms.ToolStrip
    Friend WithEvents flowDirectionDropDown As System.Windows.Forms.ToolStripDropDownButton
    Friend WithEvents horizontalToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents verticalToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents toolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents FlowTabPage As System.Windows.Forms.TabPage
    Friend WithEvents flowLayoutPanel As System.Windows.Forms.FlowLayoutPanel
    Friend WithEvents flowLabel As System.Windows.Forms.Label
    Friend WithEvents UserInfo As System.Windows.Forms.GroupBox
    Friend WithEvents DepartmentInfo As System.Windows.Forms.GroupBox
    Friend WithEvents SalesForcastInfo As System.Windows.Forms.GroupBox
    Friend WithEvents singleBorderToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents insetBorderToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents outsetBorderToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents noneBorderToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tableLayoutPanel As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents FirstNameLabel As System.Windows.Forms.Label
    Friend WithEvents FirstName As System.Windows.Forms.TextBox
    Friend WithEvents LastNameLabel As System.Windows.Forms.Label
    Friend WithEvents LastName As System.Windows.Forms.TextBox
    Friend WithEvents BiographyLabel As System.Windows.Forms.Label
    Friend WithEvents Biography As System.Windows.Forms.TextBox
    Friend WithEvents DepartmentLabel As System.Windows.Forms.Label
    Friend WithEvents Departments As System.Windows.Forms.ComboBox
    Friend WithEvents tableLabel As System.Windows.Forms.Label
    Friend WithEvents tabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents TableTabPage As System.Windows.Forms.TabPage
    Friend WithEvents TableToolStrip As System.Windows.Forms.ToolStrip
    Friend WithEvents cellBorderStyles As System.Windows.Forms.ToolStripDropDownButton

End Class
