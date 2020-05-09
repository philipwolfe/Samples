Public Class fProperties
    Inherits System.Windows.Forms.Form

#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call

    End Sub

    'Form overrides dispose to clean up the component list.
    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing Then
            If Not (components Is Nothing) Then
                components.Dispose()
            End If
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    Friend WithEvents ImageList1 As System.Windows.Forms.ImageList
    Friend WithEvents tv As System.Windows.Forms.TreeView
    Friend WithEvents lstColumns As System.Windows.Forms.ListBox
    Friend WithEvents btnOK As System.Windows.Forms.Button
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents btnApply As System.Windows.Forms.Button
    Friend WithEvents pg As System.Windows.Forms.PropertyGrid
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(fProperties))
        Me.tv = New System.Windows.Forms.TreeView()
        Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
        Me.lstColumns = New System.Windows.Forms.ListBox()
        Me.btnOK = New System.Windows.Forms.Button()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.btnApply = New System.Windows.Forms.Button()
        Me.pg = New System.Windows.Forms.PropertyGrid()
        Me.SuspendLayout()
        '
        'tv
        '
        Me.tv.Dock = System.Windows.Forms.DockStyle.Left
        Me.tv.FullRowSelect = True
        Me.tv.ImageList = Me.ImageList1
        Me.tv.Name = "tv"
        Me.tv.Nodes.AddRange(New System.Windows.Forms.TreeNode() {New System.Windows.Forms.TreeNode("MyGridEx", New System.Windows.Forms.TreeNode() {New System.Windows.Forms.TreeNode("Columns", 1, 1), New System.Windows.Forms.TreeNode("DropDowns", 1, 1)})})
        Me.tv.Size = New System.Drawing.Size(144, 454)
        Me.tv.TabIndex = 0
        '
        'ImageList1
        '
        Me.ImageList1.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit
        Me.ImageList1.ImageSize = New System.Drawing.Size(16, 16)
        Me.ImageList1.ImageStream = CType(resources.GetObject("ImageList1.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImageList1.TransparentColor = System.Drawing.Color.Transparent
        '
        'lstColumns
        '
        Me.lstColumns.Dock = System.Windows.Forms.DockStyle.Left
        Me.lstColumns.Location = New System.Drawing.Point(144, 0)
        Me.lstColumns.Name = "lstColumns"
        Me.lstColumns.Size = New System.Drawing.Size(148, 446)
        Me.lstColumns.TabIndex = 1
        '
        'btnOK
        '
        Me.btnOK.Anchor = (System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right)
        Me.btnOK.Image = CType(resources.GetObject("btnOK.Image"), System.Drawing.Bitmap)
        Me.btnOK.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnOK.Location = New System.Drawing.Point(504, 420)
        Me.btnOK.Name = "btnOK"
        Me.btnOK.TabIndex = 3
        Me.btnOK.Text = "   OK"
        '
        'btnCancel
        '
        Me.btnCancel.Anchor = (System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right)
        Me.btnCancel.Image = CType(resources.GetObject("btnCancel.Image"), System.Drawing.Bitmap)
        Me.btnCancel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnCancel.Location = New System.Drawing.Point(608, 420)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.TabIndex = 4
        Me.btnCancel.Text = "   Cancel"
        '
        'btnApply
        '
        Me.btnApply.Anchor = (System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right)
        Me.btnApply.Image = CType(resources.GetObject("btnApply.Image"), System.Drawing.Bitmap)
        Me.btnApply.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnApply.Location = New System.Drawing.Point(708, 420)
        Me.btnApply.Name = "btnApply"
        Me.btnApply.TabIndex = 5
        Me.btnApply.Text = "   Apply"
        '
        'pg
        '
        Me.pg.Anchor = (((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right)
        Me.pg.CommandsVisibleIfAvailable = True
        Me.pg.LargeButtons = False
        Me.pg.LineColor = System.Drawing.SystemColors.ScrollBar
        Me.pg.Location = New System.Drawing.Point(296, 0)
        Me.pg.Name = "pg"
        Me.pg.PropertySort = System.Windows.Forms.PropertySort.Alphabetical
        Me.pg.Size = New System.Drawing.Size(492, 404)
        Me.pg.TabIndex = 6
        Me.pg.Text = "PropertyGrid"
        Me.pg.ViewBackColor = System.Drawing.SystemColors.Window
        Me.pg.ViewForeColor = System.Drawing.SystemColors.WindowText
        '
        'fProperties
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(792, 454)
        Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.pg, Me.btnApply, Me.btnCancel, Me.btnOK, Me.lstColumns, Me.tv})
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "fProperties"
        Me.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "MyGridEx Property Page"
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub

    Private Sub tv_AfterSelect(ByVal sender As System.Object, ByVal e As System.Windows.Forms.TreeViewEventArgs) Handles tv.AfterSelect
        Select Case e.Node.Text
            Case "Columns"
                ListeyeEkle()
            Case "DropDowns"

            Case "MyGridEx"
                Dim grd As New MyControls.grd()
                pg.SelectedObject = grd
        End Select
    End Sub

    Private Sub ListeyeEkle()
        Dim ds As DataSet

    End Sub

    Private Sub btnOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOK.Click
        Me.Close()
    End Sub

    Private Sub btnApply_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnApply.Click
        btnApply.Enabled = False
    End Sub

    Private Sub fProperties_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub

    Private Sub pg_PropertyValueChanged(ByVal s As Object, ByVal e As System.Windows.Forms.PropertyValueChangedEventArgs) Handles pg.PropertyValueChanged
        btnApply.Enabled = True
    End Sub
End Class
