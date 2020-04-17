

Partial Class TwoPaneProp
    Inherits System.Windows.Forms.Form 

    Private components As System.ComponentModel.IContainer = Nothing

    Protected Overrides Sub Dispose(ByVal disposing As Boolean)

        If disposing AndAlso Not (components Is Nothing) Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)

    End Sub 'Dispose

#Region "Windows Form Designer generated code"


    '/ <summary>
    '/ Required method for Designer support - do not modify
    '/ the contents of this method with the code editor.
    '/ </summary>
    Private Sub InitializeComponent()
        Dim ListViewItem4 As System.Windows.Forms.ListViewItem = New System.Windows.Forms.ListViewItem("Thing One")
        Dim ListViewItem5 As System.Windows.Forms.ListViewItem = New System.Windows.Forms.ListViewItem("Thing Two")
        Dim ListViewItem6 As System.Windows.Forms.ListViewItem = New System.Windows.Forms.ListViewItem("Thing Three")
        Me.treeView1 = New System.Windows.Forms.TreeView
        Me.listView1 = New System.Windows.Forms.ListView
        Me.tableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel
        Me.panel1 = New System.Windows.Forms.Panel
        Me.button1 = New System.Windows.Forms.Button
        Me.button2 = New System.Windows.Forms.Button
        Me.button3 = New System.Windows.Forms.Button
        Me.button4 = New System.Windows.Forms.Button
        Me.tableLayoutPanel1.SuspendLayout()
        Me.panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'treeView1
        '
        Me.treeView1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.treeView1.Location = New System.Drawing.Point(3, 3)
        Me.treeView1.Name = "treeView1"
        Me.treeView1.Size = New System.Drawing.Size(78, 208)
        Me.treeView1.TabIndex = 0
        '
        'listView1
        '
        Me.listView1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.listView1.Items.AddRange(New System.Windows.Forms.ListViewItem() {ListViewItem4, ListViewItem5, ListViewItem6})
        Me.listView1.Location = New System.Drawing.Point(177, 3)
        Me.listView1.Name = "listView1"
        Me.listView1.Size = New System.Drawing.Size(120, 208)
        Me.listView1.TabIndex = 1
        '
        'tableLayoutPanel1
        '
        Me.tableLayoutPanel1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tableLayoutPanel1.ColumnCount = 3
        Me.tableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40.0!))
        Me.tableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 90.0!))
        Me.tableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 60.0!))
        Me.tableLayoutPanel1.Controls.Add(Me.panel1, 1, 0)
        Me.tableLayoutPanel1.Controls.Add(Me.treeView1, 0, 0)
        Me.tableLayoutPanel1.Controls.Add(Me.listView1, 2, 0)
        Me.tableLayoutPanel1.Location = New System.Drawing.Point(-2, 1)
        Me.tableLayoutPanel1.Name = "tableLayoutPanel1"
        Me.tableLayoutPanel1.RowCount = 1
        Me.tableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50.0!))
        Me.tableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50.0!))
        Me.tableLayoutPanel1.Size = New System.Drawing.Size(300, 214)
        Me.tableLayoutPanel1.TabIndex = 4
        '
        'panel1
        '
        Me.panel1.Controls.Add(Me.button1)
        Me.panel1.Controls.Add(Me.button2)
        Me.panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.panel1.Location = New System.Drawing.Point(87, 3)
        Me.panel1.Name = "panel1"
        Me.panel1.Size = New System.Drawing.Size(84, 208)
        Me.panel1.TabIndex = 5
        '
        'button1
        '
        Me.button1.Location = New System.Drawing.Point(4, 81)
        Me.button1.Name = "button1"
        Me.button1.Size = New System.Drawing.Size(75, 23)
        Me.button1.TabIndex = 2
        Me.button1.Text = "Add >>"
        '
        'button2
        '
        Me.button2.Location = New System.Drawing.Point(4, 111)
        Me.button2.Name = "button2"
        Me.button2.Size = New System.Drawing.Size(75, 23)
        Me.button2.TabIndex = 3
        Me.button2.Text = "<< Remove"
        '
        'button3
        '
        Me.button3.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.button3.Location = New System.Drawing.Point(220, 222)
        Me.button3.Name = "button3"
        Me.button3.Size = New System.Drawing.Size(75, 23)
        Me.button3.TabIndex = 5
        Me.button3.Text = "Cancel"
        '
        'button4
        '
        Me.button4.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.button4.Location = New System.Drawing.Point(138, 222)
        Me.button4.Name = "button4"
        Me.button4.Size = New System.Drawing.Size(75, 23)
        Me.button4.TabIndex = 6
        Me.button4.Text = "OK"
        '
        'TwoPaneProp
        '
        Me.ClientSize = New System.Drawing.Size(301, 250)
        Me.Controls.Add(Me.button4)
        Me.Controls.Add(Me.button3)
        Me.Controls.Add(Me.tableLayoutPanel1)
        Me.Name = "TwoPaneProp"
        Me.Padding = New System.Windows.Forms.Padding(9)
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "Two-Pane Proportional Form"
        Me.tableLayoutPanel1.ResumeLayout(False)
        Me.panel1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub 'InitializeComponent 

#End Region

    Private treeView1 As System.Windows.Forms.TreeView
    Private listView1 As System.Windows.Forms.ListView
    Private WithEvents button1 As System.Windows.Forms.Button
    Private WithEvents button2 As System.Windows.Forms.Button
    Private WithEvents button3 As System.Windows.Forms.Button
    Private WithEvents button4 As System.Windows.Forms.Button
    Private tableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Private panel1 As System.Windows.Forms.Panel

End Class 'TwoPaneProp

