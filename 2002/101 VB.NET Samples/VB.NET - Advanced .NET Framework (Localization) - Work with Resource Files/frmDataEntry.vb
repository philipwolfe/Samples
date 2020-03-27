Option Strict On
Imports System.Globalization

Public Class frmDataEntry
    Inherits System.Windows.Forms.Form
    Private dt As New DataTable("Names")

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
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents cmdSave As System.Windows.Forms.Button
    Friend WithEvents txtCity As System.Windows.Forms.TextBox
    Friend WithEvents txtName As System.Windows.Forms.TextBox
    Friend WithEvents lblCity As System.Windows.Forms.Label
    Friend WithEvents lblName As System.Windows.Forms.Label
    Friend WithEvents grdPeople As System.Windows.Forms.DataGrid
    Friend WithEvents lblWelcome As System.Windows.Forms.Label
    Friend WithEvents cmdQuit As System.Windows.Forms.Button
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmDataEntry))
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.cmdSave = New System.Windows.Forms.Button()
        Me.txtCity = New System.Windows.Forms.TextBox()
        Me.txtName = New System.Windows.Forms.TextBox()
        Me.lblCity = New System.Windows.Forms.Label()
        Me.lblName = New System.Windows.Forms.Label()
        Me.grdPeople = New System.Windows.Forms.DataGrid()
        Me.lblWelcome = New System.Windows.Forms.Label()
        Me.cmdQuit = New System.Windows.Forms.Button()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.GroupBox1.SuspendLayout()
        CType(Me.grdPeople, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.AccessibleDescription = CType(resources.GetObject("GroupBox1.AccessibleDescription"), String)
        Me.GroupBox1.AccessibleName = CType(resources.GetObject("GroupBox1.AccessibleName"), String)
        Me.GroupBox1.Anchor = CType(resources.GetObject("GroupBox1.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.GroupBox1.BackgroundImage = CType(resources.GetObject("GroupBox1.BackgroundImage"), System.Drawing.Image)
        Me.GroupBox1.Controls.AddRange(New System.Windows.Forms.Control() {Me.cmdSave, Me.txtCity, Me.txtName, Me.lblCity, Me.lblName})
        Me.GroupBox1.Dock = CType(resources.GetObject("GroupBox1.Dock"), System.Windows.Forms.DockStyle)
        Me.GroupBox1.Enabled = CType(resources.GetObject("GroupBox1.Enabled"), Boolean)
        Me.GroupBox1.Font = CType(resources.GetObject("GroupBox1.Font"), System.Drawing.Font)
        Me.GroupBox1.ImeMode = CType(resources.GetObject("GroupBox1.ImeMode"), System.Windows.Forms.ImeMode)
        Me.GroupBox1.Location = CType(resources.GetObject("GroupBox1.Location"), System.Drawing.Point)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.RightToLeft = CType(resources.GetObject("GroupBox1.RightToLeft"), System.Windows.Forms.RightToLeft)
        Me.GroupBox1.Size = CType(resources.GetObject("GroupBox1.Size"), System.Drawing.Size)
        Me.GroupBox1.TabIndex = CType(resources.GetObject("GroupBox1.TabIndex"), Integer)
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = resources.GetString("GroupBox1.Text")
        Me.GroupBox1.Visible = CType(resources.GetObject("GroupBox1.Visible"), Boolean)
        '
        'cmdSave
        '
        Me.cmdSave.AccessibleDescription = CType(resources.GetObject("cmdSave.AccessibleDescription"), String)
        Me.cmdSave.AccessibleName = CType(resources.GetObject("cmdSave.AccessibleName"), String)
        Me.cmdSave.Anchor = CType(resources.GetObject("cmdSave.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.cmdSave.BackgroundImage = CType(resources.GetObject("cmdSave.BackgroundImage"), System.Drawing.Image)
        Me.cmdSave.Dock = CType(resources.GetObject("cmdSave.Dock"), System.Windows.Forms.DockStyle)
        Me.cmdSave.Enabled = CType(resources.GetObject("cmdSave.Enabled"), Boolean)
        Me.cmdSave.FlatStyle = CType(resources.GetObject("cmdSave.FlatStyle"), System.Windows.Forms.FlatStyle)
        Me.cmdSave.Font = CType(resources.GetObject("cmdSave.Font"), System.Drawing.Font)
        Me.cmdSave.Image = CType(resources.GetObject("cmdSave.Image"), System.Drawing.Image)
        Me.cmdSave.ImageAlign = CType(resources.GetObject("cmdSave.ImageAlign"), System.Drawing.ContentAlignment)
        Me.cmdSave.ImageIndex = CType(resources.GetObject("cmdSave.ImageIndex"), Integer)
        Me.cmdSave.ImeMode = CType(resources.GetObject("cmdSave.ImeMode"), System.Windows.Forms.ImeMode)
        Me.cmdSave.Location = CType(resources.GetObject("cmdSave.Location"), System.Drawing.Point)
        Me.cmdSave.Name = "cmdSave"
        Me.cmdSave.RightToLeft = CType(resources.GetObject("cmdSave.RightToLeft"), System.Windows.Forms.RightToLeft)
        Me.cmdSave.Size = CType(resources.GetObject("cmdSave.Size"), System.Drawing.Size)
        Me.cmdSave.TabIndex = CType(resources.GetObject("cmdSave.TabIndex"), Integer)
        Me.cmdSave.Text = resources.GetString("cmdSave.Text")
        Me.cmdSave.TextAlign = CType(resources.GetObject("cmdSave.TextAlign"), System.Drawing.ContentAlignment)
        Me.cmdSave.Visible = CType(resources.GetObject("cmdSave.Visible"), Boolean)
        '
        'txtCity
        '
        Me.txtCity.AccessibleDescription = CType(resources.GetObject("txtCity.AccessibleDescription"), String)
        Me.txtCity.AccessibleName = CType(resources.GetObject("txtCity.AccessibleName"), String)
        Me.txtCity.Anchor = CType(resources.GetObject("txtCity.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.txtCity.AutoSize = CType(resources.GetObject("txtCity.AutoSize"), Boolean)
        Me.txtCity.BackgroundImage = CType(resources.GetObject("txtCity.BackgroundImage"), System.Drawing.Image)
        Me.txtCity.Dock = CType(resources.GetObject("txtCity.Dock"), System.Windows.Forms.DockStyle)
        Me.txtCity.Enabled = CType(resources.GetObject("txtCity.Enabled"), Boolean)
        Me.txtCity.Font = CType(resources.GetObject("txtCity.Font"), System.Drawing.Font)
        Me.txtCity.ImeMode = CType(resources.GetObject("txtCity.ImeMode"), System.Windows.Forms.ImeMode)
        Me.txtCity.Location = CType(resources.GetObject("txtCity.Location"), System.Drawing.Point)
        Me.txtCity.MaxLength = CType(resources.GetObject("txtCity.MaxLength"), Integer)
        Me.txtCity.Multiline = CType(resources.GetObject("txtCity.Multiline"), Boolean)
        Me.txtCity.Name = "txtCity"
        Me.txtCity.PasswordChar = CType(resources.GetObject("txtCity.PasswordChar"), Char)
        Me.txtCity.RightToLeft = CType(resources.GetObject("txtCity.RightToLeft"), System.Windows.Forms.RightToLeft)
        Me.txtCity.ScrollBars = CType(resources.GetObject("txtCity.ScrollBars"), System.Windows.Forms.ScrollBars)
        Me.txtCity.Size = CType(resources.GetObject("txtCity.Size"), System.Drawing.Size)
        Me.txtCity.TabIndex = CType(resources.GetObject("txtCity.TabIndex"), Integer)
        Me.txtCity.Text = resources.GetString("txtCity.Text")
        Me.txtCity.TextAlign = CType(resources.GetObject("txtCity.TextAlign"), System.Windows.Forms.HorizontalAlignment)
        Me.txtCity.Visible = CType(resources.GetObject("txtCity.Visible"), Boolean)
        Me.txtCity.WordWrap = CType(resources.GetObject("txtCity.WordWrap"), Boolean)
        '
        'txtName
        '
        Me.txtName.AccessibleDescription = CType(resources.GetObject("txtName.AccessibleDescription"), String)
        Me.txtName.AccessibleName = CType(resources.GetObject("txtName.AccessibleName"), String)
        Me.txtName.Anchor = CType(resources.GetObject("txtName.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.txtName.AutoSize = CType(resources.GetObject("txtName.AutoSize"), Boolean)
        Me.txtName.BackgroundImage = CType(resources.GetObject("txtName.BackgroundImage"), System.Drawing.Image)
        Me.txtName.Dock = CType(resources.GetObject("txtName.Dock"), System.Windows.Forms.DockStyle)
        Me.txtName.Enabled = CType(resources.GetObject("txtName.Enabled"), Boolean)
        Me.txtName.Font = CType(resources.GetObject("txtName.Font"), System.Drawing.Font)
        Me.txtName.ImeMode = CType(resources.GetObject("txtName.ImeMode"), System.Windows.Forms.ImeMode)
        Me.txtName.Location = CType(resources.GetObject("txtName.Location"), System.Drawing.Point)
        Me.txtName.MaxLength = CType(resources.GetObject("txtName.MaxLength"), Integer)
        Me.txtName.Multiline = CType(resources.GetObject("txtName.Multiline"), Boolean)
        Me.txtName.Name = "txtName"
        Me.txtName.PasswordChar = CType(resources.GetObject("txtName.PasswordChar"), Char)
        Me.txtName.RightToLeft = CType(resources.GetObject("txtName.RightToLeft"), System.Windows.Forms.RightToLeft)
        Me.txtName.ScrollBars = CType(resources.GetObject("txtName.ScrollBars"), System.Windows.Forms.ScrollBars)
        Me.txtName.Size = CType(resources.GetObject("txtName.Size"), System.Drawing.Size)
        Me.txtName.TabIndex = CType(resources.GetObject("txtName.TabIndex"), Integer)
        Me.txtName.Text = resources.GetString("txtName.Text")
        Me.txtName.TextAlign = CType(resources.GetObject("txtName.TextAlign"), System.Windows.Forms.HorizontalAlignment)
        Me.txtName.Visible = CType(resources.GetObject("txtName.Visible"), Boolean)
        Me.txtName.WordWrap = CType(resources.GetObject("txtName.WordWrap"), Boolean)
        '
        'lblCity
        '
        Me.lblCity.AccessibleDescription = CType(resources.GetObject("lblCity.AccessibleDescription"), String)
        Me.lblCity.AccessibleName = CType(resources.GetObject("lblCity.AccessibleName"), String)
        Me.lblCity.Anchor = CType(resources.GetObject("lblCity.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.lblCity.AutoSize = CType(resources.GetObject("lblCity.AutoSize"), Boolean)
        Me.lblCity.Dock = CType(resources.GetObject("lblCity.Dock"), System.Windows.Forms.DockStyle)
        Me.lblCity.Enabled = CType(resources.GetObject("lblCity.Enabled"), Boolean)
        Me.lblCity.Font = CType(resources.GetObject("lblCity.Font"), System.Drawing.Font)
        Me.lblCity.Image = CType(resources.GetObject("lblCity.Image"), System.Drawing.Image)
        Me.lblCity.ImageAlign = CType(resources.GetObject("lblCity.ImageAlign"), System.Drawing.ContentAlignment)
        Me.lblCity.ImageIndex = CType(resources.GetObject("lblCity.ImageIndex"), Integer)
        Me.lblCity.ImeMode = CType(resources.GetObject("lblCity.ImeMode"), System.Windows.Forms.ImeMode)
        Me.lblCity.Location = CType(resources.GetObject("lblCity.Location"), System.Drawing.Point)
        Me.lblCity.Name = "lblCity"
        Me.lblCity.RightToLeft = CType(resources.GetObject("lblCity.RightToLeft"), System.Windows.Forms.RightToLeft)
        Me.lblCity.Size = CType(resources.GetObject("lblCity.Size"), System.Drawing.Size)
        Me.lblCity.TabIndex = CType(resources.GetObject("lblCity.TabIndex"), Integer)
        Me.lblCity.Text = resources.GetString("lblCity.Text")
        Me.lblCity.TextAlign = CType(resources.GetObject("lblCity.TextAlign"), System.Drawing.ContentAlignment)
        Me.lblCity.Visible = CType(resources.GetObject("lblCity.Visible"), Boolean)
        '
        'lblName
        '
        Me.lblName.AccessibleDescription = CType(resources.GetObject("lblName.AccessibleDescription"), String)
        Me.lblName.AccessibleName = CType(resources.GetObject("lblName.AccessibleName"), String)
        Me.lblName.Anchor = CType(resources.GetObject("lblName.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.lblName.AutoSize = CType(resources.GetObject("lblName.AutoSize"), Boolean)
        Me.lblName.Dock = CType(resources.GetObject("lblName.Dock"), System.Windows.Forms.DockStyle)
        Me.lblName.Enabled = CType(resources.GetObject("lblName.Enabled"), Boolean)
        Me.lblName.Font = CType(resources.GetObject("lblName.Font"), System.Drawing.Font)
        Me.lblName.Image = CType(resources.GetObject("lblName.Image"), System.Drawing.Image)
        Me.lblName.ImageAlign = CType(resources.GetObject("lblName.ImageAlign"), System.Drawing.ContentAlignment)
        Me.lblName.ImageIndex = CType(resources.GetObject("lblName.ImageIndex"), Integer)
        Me.lblName.ImeMode = CType(resources.GetObject("lblName.ImeMode"), System.Windows.Forms.ImeMode)
        Me.lblName.Location = CType(resources.GetObject("lblName.Location"), System.Drawing.Point)
        Me.lblName.Name = "lblName"
        Me.lblName.RightToLeft = CType(resources.GetObject("lblName.RightToLeft"), System.Windows.Forms.RightToLeft)
        Me.lblName.Size = CType(resources.GetObject("lblName.Size"), System.Drawing.Size)
        Me.lblName.TabIndex = CType(resources.GetObject("lblName.TabIndex"), Integer)
        Me.lblName.Text = resources.GetString("lblName.Text")
        Me.lblName.TextAlign = CType(resources.GetObject("lblName.TextAlign"), System.Drawing.ContentAlignment)
        Me.lblName.Visible = CType(resources.GetObject("lblName.Visible"), Boolean)
        '
        'grdPeople
        '
        Me.grdPeople.AccessibleDescription = CType(resources.GetObject("grdPeople.AccessibleDescription"), String)
        Me.grdPeople.AccessibleName = CType(resources.GetObject("grdPeople.AccessibleName"), String)
        Me.grdPeople.Anchor = CType(resources.GetObject("grdPeople.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.grdPeople.BackgroundImage = CType(resources.GetObject("grdPeople.BackgroundImage"), System.Drawing.Image)
        Me.grdPeople.CaptionFont = CType(resources.GetObject("grdPeople.CaptionFont"), System.Drawing.Font)
        Me.grdPeople.CaptionText = resources.GetString("grdPeople.CaptionText")
        Me.grdPeople.ColumnHeadersVisible = False
        Me.grdPeople.DataMember = ""
        Me.grdPeople.Dock = CType(resources.GetObject("grdPeople.Dock"), System.Windows.Forms.DockStyle)
        Me.grdPeople.Enabled = CType(resources.GetObject("grdPeople.Enabled"), Boolean)
        Me.grdPeople.Font = CType(resources.GetObject("grdPeople.Font"), System.Drawing.Font)
        Me.grdPeople.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.grdPeople.ImeMode = CType(resources.GetObject("grdPeople.ImeMode"), System.Windows.Forms.ImeMode)
        Me.grdPeople.Location = CType(resources.GetObject("grdPeople.Location"), System.Drawing.Point)
        Me.grdPeople.Name = "grdPeople"
        Me.grdPeople.PreferredColumnWidth = 90
        Me.grdPeople.ReadOnly = True
        Me.grdPeople.RightToLeft = CType(resources.GetObject("grdPeople.RightToLeft"), System.Windows.Forms.RightToLeft)
        Me.grdPeople.RowHeadersVisible = False
        Me.grdPeople.Size = CType(resources.GetObject("grdPeople.Size"), System.Drawing.Size)
        Me.grdPeople.TabIndex = CType(resources.GetObject("grdPeople.TabIndex"), Integer)
        Me.grdPeople.TabStop = False
        Me.grdPeople.Visible = CType(resources.GetObject("grdPeople.Visible"), Boolean)
        '
        'lblWelcome
        '
        Me.lblWelcome.AccessibleDescription = CType(resources.GetObject("lblWelcome.AccessibleDescription"), String)
        Me.lblWelcome.AccessibleName = CType(resources.GetObject("lblWelcome.AccessibleName"), String)
        Me.lblWelcome.Anchor = CType(resources.GetObject("lblWelcome.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.lblWelcome.AutoSize = CType(resources.GetObject("lblWelcome.AutoSize"), Boolean)
        Me.lblWelcome.Dock = CType(resources.GetObject("lblWelcome.Dock"), System.Windows.Forms.DockStyle)
        Me.lblWelcome.Enabled = CType(resources.GetObject("lblWelcome.Enabled"), Boolean)
        Me.lblWelcome.Font = CType(resources.GetObject("lblWelcome.Font"), System.Drawing.Font)
        Me.lblWelcome.Image = CType(resources.GetObject("lblWelcome.Image"), System.Drawing.Image)
        Me.lblWelcome.ImageAlign = CType(resources.GetObject("lblWelcome.ImageAlign"), System.Drawing.ContentAlignment)
        Me.lblWelcome.ImageIndex = CType(resources.GetObject("lblWelcome.ImageIndex"), Integer)
        Me.lblWelcome.ImeMode = CType(resources.GetObject("lblWelcome.ImeMode"), System.Windows.Forms.ImeMode)
        Me.lblWelcome.Location = CType(resources.GetObject("lblWelcome.Location"), System.Drawing.Point)
        Me.lblWelcome.Name = "lblWelcome"
        Me.lblWelcome.RightToLeft = CType(resources.GetObject("lblWelcome.RightToLeft"), System.Windows.Forms.RightToLeft)
        Me.lblWelcome.Size = CType(resources.GetObject("lblWelcome.Size"), System.Drawing.Size)
        Me.lblWelcome.TabIndex = CType(resources.GetObject("lblWelcome.TabIndex"), Integer)
        Me.lblWelcome.Text = resources.GetString("lblWelcome.Text")
        Me.lblWelcome.TextAlign = CType(resources.GetObject("lblWelcome.TextAlign"), System.Drawing.ContentAlignment)
        Me.lblWelcome.Visible = CType(resources.GetObject("lblWelcome.Visible"), Boolean)
        '
        'cmdQuit
        '
        Me.cmdQuit.AccessibleDescription = CType(resources.GetObject("cmdQuit.AccessibleDescription"), String)
        Me.cmdQuit.AccessibleName = CType(resources.GetObject("cmdQuit.AccessibleName"), String)
        Me.cmdQuit.Anchor = CType(resources.GetObject("cmdQuit.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.cmdQuit.BackgroundImage = CType(resources.GetObject("cmdQuit.BackgroundImage"), System.Drawing.Image)
        Me.cmdQuit.Dock = CType(resources.GetObject("cmdQuit.Dock"), System.Windows.Forms.DockStyle)
        Me.cmdQuit.Enabled = CType(resources.GetObject("cmdQuit.Enabled"), Boolean)
        Me.cmdQuit.FlatStyle = CType(resources.GetObject("cmdQuit.FlatStyle"), System.Windows.Forms.FlatStyle)
        Me.cmdQuit.Font = CType(resources.GetObject("cmdQuit.Font"), System.Drawing.Font)
        Me.cmdQuit.Image = CType(resources.GetObject("cmdQuit.Image"), System.Drawing.Image)
        Me.cmdQuit.ImageAlign = CType(resources.GetObject("cmdQuit.ImageAlign"), System.Drawing.ContentAlignment)
        Me.cmdQuit.ImageIndex = CType(resources.GetObject("cmdQuit.ImageIndex"), Integer)
        Me.cmdQuit.ImeMode = CType(resources.GetObject("cmdQuit.ImeMode"), System.Windows.Forms.ImeMode)
        Me.cmdQuit.Location = CType(resources.GetObject("cmdQuit.Location"), System.Drawing.Point)
        Me.cmdQuit.Name = "cmdQuit"
        Me.cmdQuit.RightToLeft = CType(resources.GetObject("cmdQuit.RightToLeft"), System.Windows.Forms.RightToLeft)
        Me.cmdQuit.Size = CType(resources.GetObject("cmdQuit.Size"), System.Drawing.Size)
        Me.cmdQuit.TabIndex = CType(resources.GetObject("cmdQuit.TabIndex"), Integer)
        Me.cmdQuit.Text = resources.GetString("cmdQuit.Text")
        Me.cmdQuit.TextAlign = CType(resources.GetObject("cmdQuit.TextAlign"), System.Drawing.ContentAlignment)
        Me.cmdQuit.Visible = CType(resources.GetObject("cmdQuit.Visible"), Boolean)
        '
        'PictureBox1
        '
        Me.PictureBox1.AccessibleDescription = CType(resources.GetObject("PictureBox1.AccessibleDescription"), String)
        Me.PictureBox1.AccessibleName = CType(resources.GetObject("PictureBox1.AccessibleName"), String)
        Me.PictureBox1.Anchor = CType(resources.GetObject("PictureBox1.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.PictureBox1.BackgroundImage = CType(resources.GetObject("PictureBox1.BackgroundImage"), System.Drawing.Image)
        Me.PictureBox1.Dock = CType(resources.GetObject("PictureBox1.Dock"), System.Windows.Forms.DockStyle)
        Me.PictureBox1.Enabled = CType(resources.GetObject("PictureBox1.Enabled"), Boolean)
        Me.PictureBox1.Font = CType(resources.GetObject("PictureBox1.Font"), System.Drawing.Font)
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Bitmap)
        Me.PictureBox1.ImeMode = CType(resources.GetObject("PictureBox1.ImeMode"), System.Windows.Forms.ImeMode)
        Me.PictureBox1.Location = CType(resources.GetObject("PictureBox1.Location"), System.Drawing.Point)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.RightToLeft = CType(resources.GetObject("PictureBox1.RightToLeft"), System.Windows.Forms.RightToLeft)
        Me.PictureBox1.Size = CType(resources.GetObject("PictureBox1.Size"), System.Drawing.Size)
        Me.PictureBox1.SizeMode = CType(resources.GetObject("PictureBox1.SizeMode"), System.Windows.Forms.PictureBoxSizeMode)
        Me.PictureBox1.TabIndex = CType(resources.GetObject("PictureBox1.TabIndex"), Integer)
        Me.PictureBox1.TabStop = False
        Me.PictureBox1.Text = resources.GetString("PictureBox1.Text")
        Me.PictureBox1.Visible = CType(resources.GetObject("PictureBox1.Visible"), Boolean)
        '
        'frmDataEntry
        '
        Me.AccessibleDescription = CType(resources.GetObject("$this.AccessibleDescription"), String)
        Me.AccessibleName = CType(resources.GetObject("$this.AccessibleName"), String)
        Me.Anchor = CType(resources.GetObject("$this.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.AutoScaleBaseSize = CType(resources.GetObject("$this.AutoScaleBaseSize"), System.Drawing.Size)
        Me.AutoScroll = CType(resources.GetObject("$this.AutoScroll"), Boolean)
        Me.AutoScrollMargin = CType(resources.GetObject("$this.AutoScrollMargin"), System.Drawing.Size)
        Me.AutoScrollMinSize = CType(resources.GetObject("$this.AutoScrollMinSize"), System.Drawing.Size)
        Me.BackgroundImage = CType(resources.GetObject("$this.BackgroundImage"), System.Drawing.Image)
        Me.ClientSize = CType(resources.GetObject("$this.ClientSize"), System.Drawing.Size)
        Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.PictureBox1, Me.GroupBox1, Me.grdPeople, Me.lblWelcome, Me.cmdQuit})
        Me.Dock = CType(resources.GetObject("$this.Dock"), System.Windows.Forms.DockStyle)
        Me.Enabled = CType(resources.GetObject("$this.Enabled"), Boolean)
        Me.Font = CType(resources.GetObject("$this.Font"), System.Drawing.Font)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.ImeMode = CType(resources.GetObject("$this.ImeMode"), System.Windows.Forms.ImeMode)
        Me.Location = CType(resources.GetObject("$this.Location"), System.Drawing.Point)
        Me.MaximumSize = CType(resources.GetObject("$this.MaximumSize"), System.Drawing.Size)
        Me.MinimumSize = CType(resources.GetObject("$this.MinimumSize"), System.Drawing.Size)
        Me.Name = "frmDataEntry"
        Me.RightToLeft = CType(resources.GetObject("$this.RightToLeft"), System.Windows.Forms.RightToLeft)
        Me.StartPosition = CType(resources.GetObject("$this.StartPosition"), System.Windows.Forms.FormStartPosition)
        Me.Text = resources.GetString("$this.Text")
        Me.Visible = CType(resources.GetObject("$this.Visible"), Boolean)
        Me.GroupBox1.ResumeLayout(False)
        CType(Me.grdPeople, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private Sub cmdQuit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdQuit.Click
        Me.Close()
    End Sub

    Private Sub cmdSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSave.Click

        Dim myDataRow As DataRow

        ' Creates a new Row from the DataTable
        myDataRow = dt.NewRow()

        ' Fills in the data
        myDataRow.Item("Name") = txtName.Text
        myDataRow.Item("City") = txtCity.Text

        '  Adds the new Row to the people DataTable
        dt.Rows.Add(myDataRow)

    End Sub

    Private Sub frmDataEntry_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ' Create the schema for the table of names.
        dt.Columns.Add("Name")
        dt.Columns.Add("City")
        grdPeople.DataSource = dt
    End Sub
End Class
