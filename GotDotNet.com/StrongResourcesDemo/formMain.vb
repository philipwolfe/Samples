Public Class formMain
    Inherits System.Windows.Forms.Form

#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        System.Threading.Thread.CurrentThread.CurrentUICulture = System.Threading.Thread.CurrentThread.CurrentCulture

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
    Private WithEvents labelFirstName As System.Windows.Forms.Label
    Private WithEvents textFirstName As System.Windows.Forms.TextBox
    Private WithEvents labelLastName As System.Windows.Forms.Label
    Private WithEvents textLastName As System.Windows.Forms.TextBox
    Private WithEvents numericChildren As System.Windows.Forms.NumericUpDown
    Private WithEvents labelStreet1 As System.Windows.Forms.Label
    Private WithEvents labelStreet2 As System.Windows.Forms.Label
    Private WithEvents labelCity As System.Windows.Forms.Label
    Private WithEvents labelChildren As System.Windows.Forms.Label
    Private WithEvents labelMaritalStatus As System.Windows.Forms.Label
    Private WithEvents comboMaritalStatus As System.Windows.Forms.ComboBox
    Private WithEvents buttonBirthDate As System.Windows.Forms.Button
    Private WithEvents textBirthDate As System.Windows.Forms.TextBox
    Private WithEvents TextBox1 As System.Windows.Forms.TextBox
    Private WithEvents TextBox2 As System.Windows.Forms.TextBox
    Private WithEvents TextBox3 As System.Windows.Forms.TextBox
    Private WithEvents comboState As System.Windows.Forms.ComboBox
    Private WithEvents groupAddress As System.Windows.Forms.GroupBox
    Private WithEvents groupPersonal As System.Windows.Forms.GroupBox
    Private WithEvents labelState As System.Windows.Forms.Label
    Private WithEvents labelDOB As System.Windows.Forms.Label
    Private WithEvents buttonFlag As System.Windows.Forms.Button
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(formMain))
        Me.groupAddress = New System.Windows.Forms.GroupBox
        Me.comboState = New System.Windows.Forms.ComboBox
        Me.labelState = New System.Windows.Forms.Label
        Me.TextBox3 = New System.Windows.Forms.TextBox
        Me.TextBox2 = New System.Windows.Forms.TextBox
        Me.TextBox1 = New System.Windows.Forms.TextBox
        Me.labelCity = New System.Windows.Forms.Label
        Me.labelStreet2 = New System.Windows.Forms.Label
        Me.labelStreet1 = New System.Windows.Forms.Label
        Me.groupPersonal = New System.Windows.Forms.GroupBox
        Me.textBirthDate = New System.Windows.Forms.TextBox
        Me.buttonBirthDate = New System.Windows.Forms.Button
        Me.labelDOB = New System.Windows.Forms.Label
        Me.comboMaritalStatus = New System.Windows.Forms.ComboBox
        Me.labelMaritalStatus = New System.Windows.Forms.Label
        Me.labelChildren = New System.Windows.Forms.Label
        Me.numericChildren = New System.Windows.Forms.NumericUpDown
        Me.labelLastName = New System.Windows.Forms.Label
        Me.textLastName = New System.Windows.Forms.TextBox
        Me.textFirstName = New System.Windows.Forms.TextBox
        Me.labelFirstName = New System.Windows.Forms.Label
        Me.buttonFlag = New System.Windows.Forms.Button
        Me.groupAddress.SuspendLayout()
        Me.groupPersonal.SuspendLayout()
        CType(Me.numericChildren, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'groupAddress
        '
        Me.groupAddress.AccessibleDescription = resources.GetString("groupAddress.AccessibleDescription")
        Me.groupAddress.AccessibleName = resources.GetString("groupAddress.AccessibleName")
        Me.groupAddress.Anchor = CType(resources.GetObject("groupAddress.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.groupAddress.AutoSize = CType(resources.GetObject("groupAddress.AutoSize"), Boolean)
        Me.groupAddress.BackgroundImage = CType(resources.GetObject("groupAddress.BackgroundImage"), System.Drawing.Image)
        Me.groupAddress.BackgroundImageLayout = CType(resources.GetObject("groupAddress.BackgroundImageLayout"), System.Windows.Forms.ImageLayout)
        Me.groupAddress.Controls.Add(Me.comboState)
        Me.groupAddress.Controls.Add(Me.labelState)
        Me.groupAddress.Controls.Add(Me.TextBox3)
        Me.groupAddress.Controls.Add(Me.TextBox2)
        Me.groupAddress.Controls.Add(Me.TextBox1)
        Me.groupAddress.Controls.Add(Me.labelCity)
        Me.groupAddress.Controls.Add(Me.labelStreet2)
        Me.groupAddress.Controls.Add(Me.labelStreet1)
        Me.groupAddress.Dock = CType(resources.GetObject("groupAddress.Dock"), System.Windows.Forms.DockStyle)
        Me.groupAddress.Font = CType(resources.GetObject("groupAddress.Font"), System.Drawing.Font)
        Me.groupAddress.ImeMode = CType(resources.GetObject("groupAddress.ImeMode"), System.Windows.Forms.ImeMode)
        Me.groupAddress.Location = CType(resources.GetObject("groupAddress.Location"), System.Drawing.Point)
        Me.groupAddress.Name = "groupAddress"
        Me.groupAddress.RightToLeft = CType(resources.GetObject("groupAddress.RightToLeft"), System.Windows.Forms.RightToLeft)
        Me.groupAddress.Size = CType(resources.GetObject("groupAddress.Size"), System.Drawing.Size)
        Me.groupAddress.TabIndex = CType(resources.GetObject("groupAddress.TabIndex"), Integer)
        Me.groupAddress.TabStop = False
        '
        'comboState
        '
        Me.comboState.AccessibleDescription = resources.GetString("comboState.AccessibleDescription")
        Me.comboState.AccessibleName = resources.GetString("comboState.AccessibleName")
        Me.comboState.Anchor = CType(resources.GetObject("comboState.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.comboState.AutoSize = CType(resources.GetObject("comboState.AutoSize"), Boolean)
        Me.comboState.BackgroundImage = CType(resources.GetObject("comboState.BackgroundImage"), System.Drawing.Image)
        Me.comboState.BackgroundImageLayout = CType(resources.GetObject("comboState.BackgroundImageLayout"), System.Windows.Forms.ImageLayout)
        Me.comboState.Dock = CType(resources.GetObject("comboState.Dock"), System.Windows.Forms.DockStyle)
        Me.comboState.FlatStyle = CType(resources.GetObject("comboState.FlatStyle"), System.Windows.Forms.FlatStyle)
        Me.comboState.Font = CType(resources.GetObject("comboState.Font"), System.Drawing.Font)
        Me.comboState.ImeMode = CType(resources.GetObject("comboState.ImeMode"), System.Windows.Forms.ImeMode)
        Me.comboState.IntegralHeight = CType(resources.GetObject("comboState.IntegralHeight"), Boolean)
        Me.comboState.ItemHeight = CType(resources.GetObject("comboState.ItemHeight"), Integer)
        Me.comboState.Location = CType(resources.GetObject("comboState.Location"), System.Drawing.Point)
        Me.comboState.MaxDropDownItems = CType(resources.GetObject("comboState.MaxDropDownItems"), Integer)
        Me.comboState.MaxLength = CType(resources.GetObject("comboState.MaxLength"), Integer)
        Me.comboState.Name = "comboState"
        Me.comboState.RightToLeft = CType(resources.GetObject("comboState.RightToLeft"), System.Windows.Forms.RightToLeft)
        Me.comboState.Size = CType(resources.GetObject("comboState.Size"), System.Drawing.Size)
        Me.comboState.TabIndex = CType(resources.GetObject("comboState.TabIndex"), Integer)
        '
        'labelState
        '
        Me.labelState.AccessibleDescription = resources.GetString("labelState.AccessibleDescription")
        Me.labelState.AccessibleName = resources.GetString("labelState.AccessibleName")
        Me.labelState.Anchor = CType(resources.GetObject("labelState.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.labelState.AutoSize = CType(resources.GetObject("labelState.AutoSize"), Boolean)
        Me.labelState.BackgroundImageLayout = CType(resources.GetObject("labelState.BackgroundImageLayout"), System.Windows.Forms.ImageLayout)
        Me.labelState.Dock = CType(resources.GetObject("labelState.Dock"), System.Windows.Forms.DockStyle)
        Me.labelState.Font = CType(resources.GetObject("labelState.Font"), System.Drawing.Font)
        Me.labelState.ImageAlign = CType(resources.GetObject("labelState.ImageAlign"), System.Drawing.ContentAlignment)
        Me.labelState.ImageIndex = CType(resources.GetObject("labelState.ImageIndex"), Integer)
        Me.labelState.ImageKey = resources.GetString("labelState.ImageKey")
        Me.labelState.ImeMode = CType(resources.GetObject("labelState.ImeMode"), System.Windows.Forms.ImeMode)
        Me.labelState.Location = CType(resources.GetObject("labelState.Location"), System.Drawing.Point)
        Me.labelState.Name = "labelState"
        Me.labelState.RightToLeft = CType(resources.GetObject("labelState.RightToLeft"), System.Windows.Forms.RightToLeft)
        Me.labelState.Size = CType(resources.GetObject("labelState.Size"), System.Drawing.Size)
        Me.labelState.TabIndex = CType(resources.GetObject("labelState.TabIndex"), Integer)
        Me.labelState.TextAlign = CType(resources.GetObject("labelState.TextAlign"), System.Drawing.ContentAlignment)
        '
        'TextBox3
        '
        Me.TextBox3.AccessibleDescription = resources.GetString("TextBox3.AccessibleDescription")
        Me.TextBox3.AccessibleName = resources.GetString("TextBox3.AccessibleName")
        Me.TextBox3.Anchor = CType(resources.GetObject("TextBox3.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.TextBox3.AutoSize = CType(resources.GetObject("TextBox3.AutoSize"), Boolean)
        Me.TextBox3.BackgroundImage = CType(resources.GetObject("TextBox3.BackgroundImage"), System.Drawing.Image)
        Me.TextBox3.BackgroundImageLayout = CType(resources.GetObject("TextBox3.BackgroundImageLayout"), System.Windows.Forms.ImageLayout)
        Me.TextBox3.Dock = CType(resources.GetObject("TextBox3.Dock"), System.Windows.Forms.DockStyle)
        Me.TextBox3.Font = CType(resources.GetObject("TextBox3.Font"), System.Drawing.Font)
        Me.TextBox3.ImeMode = CType(resources.GetObject("TextBox3.ImeMode"), System.Windows.Forms.ImeMode)
        Me.TextBox3.Location = CType(resources.GetObject("TextBox3.Location"), System.Drawing.Point)
        Me.TextBox3.MaxLength = CType(resources.GetObject("TextBox3.MaxLength"), Integer)
        Me.TextBox3.Multiline = CType(resources.GetObject("TextBox3.Multiline"), Boolean)
        Me.TextBox3.Name = "TextBox3"
        Me.TextBox3.PasswordChar = CType(resources.GetObject("TextBox3.PasswordChar"), Char)
        Me.TextBox3.RightToLeft = CType(resources.GetObject("TextBox3.RightToLeft"), System.Windows.Forms.RightToLeft)
        Me.TextBox3.ScrollBars = CType(resources.GetObject("TextBox3.ScrollBars"), System.Windows.Forms.ScrollBars)
        Me.TextBox3.Size = CType(resources.GetObject("TextBox3.Size"), System.Drawing.Size)
        Me.TextBox3.TabIndex = CType(resources.GetObject("TextBox3.TabIndex"), Integer)
        Me.TextBox3.TextAlign = CType(resources.GetObject("TextBox3.TextAlign"), System.Windows.Forms.HorizontalAlignment)
        Me.TextBox3.WordWrap = CType(resources.GetObject("TextBox3.WordWrap"), Boolean)
        '
        'TextBox2
        '
        Me.TextBox2.AccessibleDescription = resources.GetString("TextBox2.AccessibleDescription")
        Me.TextBox2.AccessibleName = resources.GetString("TextBox2.AccessibleName")
        Me.TextBox2.Anchor = CType(resources.GetObject("TextBox2.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.TextBox2.AutoSize = CType(resources.GetObject("TextBox2.AutoSize"), Boolean)
        Me.TextBox2.BackgroundImage = CType(resources.GetObject("TextBox2.BackgroundImage"), System.Drawing.Image)
        Me.TextBox2.BackgroundImageLayout = CType(resources.GetObject("TextBox2.BackgroundImageLayout"), System.Windows.Forms.ImageLayout)
        Me.TextBox2.Dock = CType(resources.GetObject("TextBox2.Dock"), System.Windows.Forms.DockStyle)
        Me.TextBox2.Font = CType(resources.GetObject("TextBox2.Font"), System.Drawing.Font)
        Me.TextBox2.ImeMode = CType(resources.GetObject("TextBox2.ImeMode"), System.Windows.Forms.ImeMode)
        Me.TextBox2.Location = CType(resources.GetObject("TextBox2.Location"), System.Drawing.Point)
        Me.TextBox2.MaxLength = CType(resources.GetObject("TextBox2.MaxLength"), Integer)
        Me.TextBox2.Multiline = CType(resources.GetObject("TextBox2.Multiline"), Boolean)
        Me.TextBox2.Name = "TextBox2"
        Me.TextBox2.PasswordChar = CType(resources.GetObject("TextBox2.PasswordChar"), Char)
        Me.TextBox2.RightToLeft = CType(resources.GetObject("TextBox2.RightToLeft"), System.Windows.Forms.RightToLeft)
        Me.TextBox2.ScrollBars = CType(resources.GetObject("TextBox2.ScrollBars"), System.Windows.Forms.ScrollBars)
        Me.TextBox2.Size = CType(resources.GetObject("TextBox2.Size"), System.Drawing.Size)
        Me.TextBox2.TabIndex = CType(resources.GetObject("TextBox2.TabIndex"), Integer)
        Me.TextBox2.TextAlign = CType(resources.GetObject("TextBox2.TextAlign"), System.Windows.Forms.HorizontalAlignment)
        Me.TextBox2.WordWrap = CType(resources.GetObject("TextBox2.WordWrap"), Boolean)
        '
        'TextBox1
        '
        Me.TextBox1.AccessibleDescription = resources.GetString("TextBox1.AccessibleDescription")
        Me.TextBox1.AccessibleName = resources.GetString("TextBox1.AccessibleName")
        Me.TextBox1.Anchor = CType(resources.GetObject("TextBox1.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.TextBox1.AutoSize = CType(resources.GetObject("TextBox1.AutoSize"), Boolean)
        Me.TextBox1.BackgroundImage = CType(resources.GetObject("TextBox1.BackgroundImage"), System.Drawing.Image)
        Me.TextBox1.BackgroundImageLayout = CType(resources.GetObject("TextBox1.BackgroundImageLayout"), System.Windows.Forms.ImageLayout)
        Me.TextBox1.Dock = CType(resources.GetObject("TextBox1.Dock"), System.Windows.Forms.DockStyle)
        Me.TextBox1.Font = CType(resources.GetObject("TextBox1.Font"), System.Drawing.Font)
        Me.TextBox1.ImeMode = CType(resources.GetObject("TextBox1.ImeMode"), System.Windows.Forms.ImeMode)
        Me.TextBox1.Location = CType(resources.GetObject("TextBox1.Location"), System.Drawing.Point)
        Me.TextBox1.MaxLength = CType(resources.GetObject("TextBox1.MaxLength"), Integer)
        Me.TextBox1.Multiline = CType(resources.GetObject("TextBox1.Multiline"), Boolean)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.PasswordChar = CType(resources.GetObject("TextBox1.PasswordChar"), Char)
        Me.TextBox1.RightToLeft = CType(resources.GetObject("TextBox1.RightToLeft"), System.Windows.Forms.RightToLeft)
        Me.TextBox1.ScrollBars = CType(resources.GetObject("TextBox1.ScrollBars"), System.Windows.Forms.ScrollBars)
        Me.TextBox1.Size = CType(resources.GetObject("TextBox1.Size"), System.Drawing.Size)
        Me.TextBox1.TabIndex = CType(resources.GetObject("TextBox1.TabIndex"), Integer)
        Me.TextBox1.TextAlign = CType(resources.GetObject("TextBox1.TextAlign"), System.Windows.Forms.HorizontalAlignment)
        Me.TextBox1.WordWrap = CType(resources.GetObject("TextBox1.WordWrap"), Boolean)
        '
        'labelCity
        '
        Me.labelCity.AccessibleDescription = resources.GetString("labelCity.AccessibleDescription")
        Me.labelCity.AccessibleName = resources.GetString("labelCity.AccessibleName")
        Me.labelCity.Anchor = CType(resources.GetObject("labelCity.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.labelCity.AutoSize = CType(resources.GetObject("labelCity.AutoSize"), Boolean)
        Me.labelCity.BackgroundImageLayout = CType(resources.GetObject("labelCity.BackgroundImageLayout"), System.Windows.Forms.ImageLayout)
        Me.labelCity.Dock = CType(resources.GetObject("labelCity.Dock"), System.Windows.Forms.DockStyle)
        Me.labelCity.Font = CType(resources.GetObject("labelCity.Font"), System.Drawing.Font)
        Me.labelCity.ImageAlign = CType(resources.GetObject("labelCity.ImageAlign"), System.Drawing.ContentAlignment)
        Me.labelCity.ImageIndex = CType(resources.GetObject("labelCity.ImageIndex"), Integer)
        Me.labelCity.ImageKey = resources.GetString("labelCity.ImageKey")
        Me.labelCity.ImeMode = CType(resources.GetObject("labelCity.ImeMode"), System.Windows.Forms.ImeMode)
        Me.labelCity.Location = CType(resources.GetObject("labelCity.Location"), System.Drawing.Point)
        Me.labelCity.Name = "labelCity"
        Me.labelCity.RightToLeft = CType(resources.GetObject("labelCity.RightToLeft"), System.Windows.Forms.RightToLeft)
        Me.labelCity.Size = CType(resources.GetObject("labelCity.Size"), System.Drawing.Size)
        Me.labelCity.TabIndex = CType(resources.GetObject("labelCity.TabIndex"), Integer)
        Me.labelCity.TextAlign = CType(resources.GetObject("labelCity.TextAlign"), System.Drawing.ContentAlignment)
        '
        'labelStreet2
        '
        Me.labelStreet2.AccessibleDescription = resources.GetString("labelStreet2.AccessibleDescription")
        Me.labelStreet2.AccessibleName = resources.GetString("labelStreet2.AccessibleName")
        Me.labelStreet2.Anchor = CType(resources.GetObject("labelStreet2.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.labelStreet2.AutoSize = CType(resources.GetObject("labelStreet2.AutoSize"), Boolean)
        Me.labelStreet2.BackgroundImageLayout = CType(resources.GetObject("labelStreet2.BackgroundImageLayout"), System.Windows.Forms.ImageLayout)
        Me.labelStreet2.Dock = CType(resources.GetObject("labelStreet2.Dock"), System.Windows.Forms.DockStyle)
        Me.labelStreet2.Font = CType(resources.GetObject("labelStreet2.Font"), System.Drawing.Font)
        Me.labelStreet2.ImageAlign = CType(resources.GetObject("labelStreet2.ImageAlign"), System.Drawing.ContentAlignment)
        Me.labelStreet2.ImageIndex = CType(resources.GetObject("labelStreet2.ImageIndex"), Integer)
        Me.labelStreet2.ImageKey = resources.GetString("labelStreet2.ImageKey")
        Me.labelStreet2.ImeMode = CType(resources.GetObject("labelStreet2.ImeMode"), System.Windows.Forms.ImeMode)
        Me.labelStreet2.Location = CType(resources.GetObject("labelStreet2.Location"), System.Drawing.Point)
        Me.labelStreet2.Name = "labelStreet2"
        Me.labelStreet2.RightToLeft = CType(resources.GetObject("labelStreet2.RightToLeft"), System.Windows.Forms.RightToLeft)
        Me.labelStreet2.Size = CType(resources.GetObject("labelStreet2.Size"), System.Drawing.Size)
        Me.labelStreet2.TabIndex = CType(resources.GetObject("labelStreet2.TabIndex"), Integer)
        Me.labelStreet2.TextAlign = CType(resources.GetObject("labelStreet2.TextAlign"), System.Drawing.ContentAlignment)
        '
        'labelStreet1
        '
        Me.labelStreet1.AccessibleDescription = resources.GetString("labelStreet1.AccessibleDescription")
        Me.labelStreet1.AccessibleName = resources.GetString("labelStreet1.AccessibleName")
        Me.labelStreet1.Anchor = CType(resources.GetObject("labelStreet1.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.labelStreet1.AutoSize = CType(resources.GetObject("labelStreet1.AutoSize"), Boolean)
        Me.labelStreet1.BackgroundImageLayout = CType(resources.GetObject("labelStreet1.BackgroundImageLayout"), System.Windows.Forms.ImageLayout)
        Me.labelStreet1.Dock = CType(resources.GetObject("labelStreet1.Dock"), System.Windows.Forms.DockStyle)
        Me.labelStreet1.Font = CType(resources.GetObject("labelStreet1.Font"), System.Drawing.Font)
        Me.labelStreet1.ImageAlign = CType(resources.GetObject("labelStreet1.ImageAlign"), System.Drawing.ContentAlignment)
        Me.labelStreet1.ImageIndex = CType(resources.GetObject("labelStreet1.ImageIndex"), Integer)
        Me.labelStreet1.ImageKey = resources.GetString("labelStreet1.ImageKey")
        Me.labelStreet1.ImeMode = CType(resources.GetObject("labelStreet1.ImeMode"), System.Windows.Forms.ImeMode)
        Me.labelStreet1.Location = CType(resources.GetObject("labelStreet1.Location"), System.Drawing.Point)
        Me.labelStreet1.Name = "labelStreet1"
        Me.labelStreet1.RightToLeft = CType(resources.GetObject("labelStreet1.RightToLeft"), System.Windows.Forms.RightToLeft)
        Me.labelStreet1.Size = CType(resources.GetObject("labelStreet1.Size"), System.Drawing.Size)
        Me.labelStreet1.TabIndex = CType(resources.GetObject("labelStreet1.TabIndex"), Integer)
        Me.labelStreet1.TextAlign = CType(resources.GetObject("labelStreet1.TextAlign"), System.Drawing.ContentAlignment)
        '
        'groupPersonal
        '
        Me.groupPersonal.AccessibleDescription = resources.GetString("groupPersonal.AccessibleDescription")
        Me.groupPersonal.AccessibleName = resources.GetString("groupPersonal.AccessibleName")
        Me.groupPersonal.Anchor = CType(resources.GetObject("groupPersonal.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.groupPersonal.AutoSize = CType(resources.GetObject("groupPersonal.AutoSize"), Boolean)
        Me.groupPersonal.BackgroundImage = CType(resources.GetObject("groupPersonal.BackgroundImage"), System.Drawing.Image)
        Me.groupPersonal.BackgroundImageLayout = CType(resources.GetObject("groupPersonal.BackgroundImageLayout"), System.Windows.Forms.ImageLayout)
        Me.groupPersonal.Controls.Add(Me.textBirthDate)
        Me.groupPersonal.Controls.Add(Me.buttonBirthDate)
        Me.groupPersonal.Controls.Add(Me.labelDOB)
        Me.groupPersonal.Controls.Add(Me.comboMaritalStatus)
        Me.groupPersonal.Controls.Add(Me.labelMaritalStatus)
        Me.groupPersonal.Controls.Add(Me.labelChildren)
        Me.groupPersonal.Controls.Add(Me.numericChildren)
        Me.groupPersonal.Controls.Add(Me.labelLastName)
        Me.groupPersonal.Controls.Add(Me.textLastName)
        Me.groupPersonal.Controls.Add(Me.textFirstName)
        Me.groupPersonal.Controls.Add(Me.labelFirstName)
        Me.groupPersonal.Dock = CType(resources.GetObject("groupPersonal.Dock"), System.Windows.Forms.DockStyle)
        Me.groupPersonal.Font = CType(resources.GetObject("groupPersonal.Font"), System.Drawing.Font)
        Me.groupPersonal.ImeMode = CType(resources.GetObject("groupPersonal.ImeMode"), System.Windows.Forms.ImeMode)
        Me.groupPersonal.Location = CType(resources.GetObject("groupPersonal.Location"), System.Drawing.Point)
        Me.groupPersonal.Name = "groupPersonal"
        Me.groupPersonal.RightToLeft = CType(resources.GetObject("groupPersonal.RightToLeft"), System.Windows.Forms.RightToLeft)
        Me.groupPersonal.Size = CType(resources.GetObject("groupPersonal.Size"), System.Drawing.Size)
        Me.groupPersonal.TabIndex = CType(resources.GetObject("groupPersonal.TabIndex"), Integer)
        Me.groupPersonal.TabStop = False
        '
        'textBirthDate
        '
        Me.textBirthDate.AccessibleDescription = resources.GetString("textBirthDate.AccessibleDescription")
        Me.textBirthDate.AccessibleName = resources.GetString("textBirthDate.AccessibleName")
        Me.textBirthDate.Anchor = CType(resources.GetObject("textBirthDate.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.textBirthDate.AutoSize = CType(resources.GetObject("textBirthDate.AutoSize"), Boolean)
        Me.textBirthDate.BackgroundImage = CType(resources.GetObject("textBirthDate.BackgroundImage"), System.Drawing.Image)
        Me.textBirthDate.BackgroundImageLayout = CType(resources.GetObject("textBirthDate.BackgroundImageLayout"), System.Windows.Forms.ImageLayout)
        Me.textBirthDate.Dock = CType(resources.GetObject("textBirthDate.Dock"), System.Windows.Forms.DockStyle)
        Me.textBirthDate.Font = CType(resources.GetObject("textBirthDate.Font"), System.Drawing.Font)
        Me.textBirthDate.ImeMode = CType(resources.GetObject("textBirthDate.ImeMode"), System.Windows.Forms.ImeMode)
        Me.textBirthDate.Location = CType(resources.GetObject("textBirthDate.Location"), System.Drawing.Point)
        Me.textBirthDate.MaxLength = CType(resources.GetObject("textBirthDate.MaxLength"), Integer)
        Me.textBirthDate.Multiline = CType(resources.GetObject("textBirthDate.Multiline"), Boolean)
        Me.textBirthDate.Name = "textBirthDate"
        Me.textBirthDate.PasswordChar = CType(resources.GetObject("textBirthDate.PasswordChar"), Char)
        Me.textBirthDate.RightToLeft = CType(resources.GetObject("textBirthDate.RightToLeft"), System.Windows.Forms.RightToLeft)
        Me.textBirthDate.ScrollBars = CType(resources.GetObject("textBirthDate.ScrollBars"), System.Windows.Forms.ScrollBars)
        Me.textBirthDate.Size = CType(resources.GetObject("textBirthDate.Size"), System.Drawing.Size)
        Me.textBirthDate.TabIndex = CType(resources.GetObject("textBirthDate.TabIndex"), Integer)
        Me.textBirthDate.TextAlign = CType(resources.GetObject("textBirthDate.TextAlign"), System.Windows.Forms.HorizontalAlignment)
        Me.textBirthDate.WordWrap = CType(resources.GetObject("textBirthDate.WordWrap"), Boolean)
        '
        'buttonBirthDate
        '
        Me.buttonBirthDate.AccessibleDescription = resources.GetString("buttonBirthDate.AccessibleDescription")
        Me.buttonBirthDate.AccessibleName = resources.GetString("buttonBirthDate.AccessibleName")
        Me.buttonBirthDate.Anchor = CType(resources.GetObject("buttonBirthDate.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.buttonBirthDate.AutoSize = CType(resources.GetObject("buttonBirthDate.AutoSize"), Boolean)
        Me.buttonBirthDate.BackgroundImage = CType(resources.GetObject("buttonBirthDate.BackgroundImage"), System.Drawing.Image)
        Me.buttonBirthDate.BackgroundImageLayout = CType(resources.GetObject("buttonBirthDate.BackgroundImageLayout"), System.Windows.Forms.ImageLayout)
        Me.buttonBirthDate.Dock = CType(resources.GetObject("buttonBirthDate.Dock"), System.Windows.Forms.DockStyle)
        Me.buttonBirthDate.FlatStyle = CType(resources.GetObject("buttonBirthDate.FlatStyle"), System.Windows.Forms.FlatStyle)
        Me.buttonBirthDate.Font = CType(resources.GetObject("buttonBirthDate.Font"), System.Drawing.Font)
        Me.buttonBirthDate.ImageAlign = CType(resources.GetObject("buttonBirthDate.ImageAlign"), System.Drawing.ContentAlignment)
        Me.buttonBirthDate.ImageIndex = CType(resources.GetObject("buttonBirthDate.ImageIndex"), Integer)
        Me.buttonBirthDate.ImageKey = resources.GetString("buttonBirthDate.ImageKey")
        Me.buttonBirthDate.ImeMode = CType(resources.GetObject("buttonBirthDate.ImeMode"), System.Windows.Forms.ImeMode)
        Me.buttonBirthDate.Location = CType(resources.GetObject("buttonBirthDate.Location"), System.Drawing.Point)
        Me.buttonBirthDate.Name = "buttonBirthDate"
        Me.buttonBirthDate.RightToLeft = CType(resources.GetObject("buttonBirthDate.RightToLeft"), System.Windows.Forms.RightToLeft)
        Me.buttonBirthDate.Size = CType(resources.GetObject("buttonBirthDate.Size"), System.Drawing.Size)
        Me.buttonBirthDate.TabIndex = CType(resources.GetObject("buttonBirthDate.TabIndex"), Integer)
        Me.buttonBirthDate.Text = resources.GetString("buttonBirthDate.Text")
        Me.buttonBirthDate.TextAlign = CType(resources.GetObject("buttonBirthDate.TextAlign"), System.Drawing.ContentAlignment)
        Me.buttonBirthDate.TextImageRelation = CType(resources.GetObject("buttonBirthDate.TextImageRelation"), System.Windows.Forms.TextImageRelation)
        '
        'labelDOB
        '
        Me.labelDOB.AccessibleDescription = resources.GetString("labelDOB.AccessibleDescription")
        Me.labelDOB.AccessibleName = resources.GetString("labelDOB.AccessibleName")
        Me.labelDOB.Anchor = CType(resources.GetObject("labelDOB.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.labelDOB.AutoSize = CType(resources.GetObject("labelDOB.AutoSize"), Boolean)
        Me.labelDOB.BackgroundImageLayout = CType(resources.GetObject("labelDOB.BackgroundImageLayout"), System.Windows.Forms.ImageLayout)
        Me.labelDOB.Dock = CType(resources.GetObject("labelDOB.Dock"), System.Windows.Forms.DockStyle)
        Me.labelDOB.Font = CType(resources.GetObject("labelDOB.Font"), System.Drawing.Font)
        Me.labelDOB.ImageAlign = CType(resources.GetObject("labelDOB.ImageAlign"), System.Drawing.ContentAlignment)
        Me.labelDOB.ImageIndex = CType(resources.GetObject("labelDOB.ImageIndex"), Integer)
        Me.labelDOB.ImageKey = resources.GetString("labelDOB.ImageKey")
        Me.labelDOB.ImeMode = CType(resources.GetObject("labelDOB.ImeMode"), System.Windows.Forms.ImeMode)
        Me.labelDOB.Location = CType(resources.GetObject("labelDOB.Location"), System.Drawing.Point)
        Me.labelDOB.Name = "labelDOB"
        Me.labelDOB.RightToLeft = CType(resources.GetObject("labelDOB.RightToLeft"), System.Windows.Forms.RightToLeft)
        Me.labelDOB.Size = CType(resources.GetObject("labelDOB.Size"), System.Drawing.Size)
        Me.labelDOB.TabIndex = CType(resources.GetObject("labelDOB.TabIndex"), Integer)
        Me.labelDOB.TextAlign = CType(resources.GetObject("labelDOB.TextAlign"), System.Drawing.ContentAlignment)
        '
        'comboMaritalStatus
        '
        Me.comboMaritalStatus.AccessibleDescription = resources.GetString("comboMaritalStatus.AccessibleDescription")
        Me.comboMaritalStatus.AccessibleName = resources.GetString("comboMaritalStatus.AccessibleName")
        Me.comboMaritalStatus.Anchor = CType(resources.GetObject("comboMaritalStatus.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.comboMaritalStatus.AutoSize = CType(resources.GetObject("comboMaritalStatus.AutoSize"), Boolean)
        Me.comboMaritalStatus.BackgroundImage = CType(resources.GetObject("comboMaritalStatus.BackgroundImage"), System.Drawing.Image)
        Me.comboMaritalStatus.BackgroundImageLayout = CType(resources.GetObject("comboMaritalStatus.BackgroundImageLayout"), System.Windows.Forms.ImageLayout)
        Me.comboMaritalStatus.Dock = CType(resources.GetObject("comboMaritalStatus.Dock"), System.Windows.Forms.DockStyle)
        Me.comboMaritalStatus.FlatStyle = CType(resources.GetObject("comboMaritalStatus.FlatStyle"), System.Windows.Forms.FlatStyle)
        Me.comboMaritalStatus.Font = CType(resources.GetObject("comboMaritalStatus.Font"), System.Drawing.Font)
        Me.comboMaritalStatus.ImeMode = CType(resources.GetObject("comboMaritalStatus.ImeMode"), System.Windows.Forms.ImeMode)
        Me.comboMaritalStatus.IntegralHeight = CType(resources.GetObject("comboMaritalStatus.IntegralHeight"), Boolean)
        Me.comboMaritalStatus.ItemHeight = CType(resources.GetObject("comboMaritalStatus.ItemHeight"), Integer)
        Me.comboMaritalStatus.Location = CType(resources.GetObject("comboMaritalStatus.Location"), System.Drawing.Point)
        Me.comboMaritalStatus.MaxDropDownItems = CType(resources.GetObject("comboMaritalStatus.MaxDropDownItems"), Integer)
        Me.comboMaritalStatus.MaxLength = CType(resources.GetObject("comboMaritalStatus.MaxLength"), Integer)
        Me.comboMaritalStatus.Name = "comboMaritalStatus"
        Me.comboMaritalStatus.RightToLeft = CType(resources.GetObject("comboMaritalStatus.RightToLeft"), System.Windows.Forms.RightToLeft)
        Me.comboMaritalStatus.Size = CType(resources.GetObject("comboMaritalStatus.Size"), System.Drawing.Size)
        Me.comboMaritalStatus.TabIndex = CType(resources.GetObject("comboMaritalStatus.TabIndex"), Integer)
        '
        'labelMaritalStatus
        '
        Me.labelMaritalStatus.AccessibleDescription = resources.GetString("labelMaritalStatus.AccessibleDescription")
        Me.labelMaritalStatus.AccessibleName = resources.GetString("labelMaritalStatus.AccessibleName")
        Me.labelMaritalStatus.Anchor = CType(resources.GetObject("labelMaritalStatus.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.labelMaritalStatus.AutoSize = CType(resources.GetObject("labelMaritalStatus.AutoSize"), Boolean)
        Me.labelMaritalStatus.BackgroundImageLayout = CType(resources.GetObject("labelMaritalStatus.BackgroundImageLayout"), System.Windows.Forms.ImageLayout)
        Me.labelMaritalStatus.Dock = CType(resources.GetObject("labelMaritalStatus.Dock"), System.Windows.Forms.DockStyle)
        Me.labelMaritalStatus.Font = CType(resources.GetObject("labelMaritalStatus.Font"), System.Drawing.Font)
        Me.labelMaritalStatus.ImageAlign = CType(resources.GetObject("labelMaritalStatus.ImageAlign"), System.Drawing.ContentAlignment)
        Me.labelMaritalStatus.ImageIndex = CType(resources.GetObject("labelMaritalStatus.ImageIndex"), Integer)
        Me.labelMaritalStatus.ImageKey = resources.GetString("labelMaritalStatus.ImageKey")
        Me.labelMaritalStatus.ImeMode = CType(resources.GetObject("labelMaritalStatus.ImeMode"), System.Windows.Forms.ImeMode)
        Me.labelMaritalStatus.Location = CType(resources.GetObject("labelMaritalStatus.Location"), System.Drawing.Point)
        Me.labelMaritalStatus.Name = "labelMaritalStatus"
        Me.labelMaritalStatus.RightToLeft = CType(resources.GetObject("labelMaritalStatus.RightToLeft"), System.Windows.Forms.RightToLeft)
        Me.labelMaritalStatus.Size = CType(resources.GetObject("labelMaritalStatus.Size"), System.Drawing.Size)
        Me.labelMaritalStatus.TabIndex = CType(resources.GetObject("labelMaritalStatus.TabIndex"), Integer)
        Me.labelMaritalStatus.TextAlign = CType(resources.GetObject("labelMaritalStatus.TextAlign"), System.Drawing.ContentAlignment)
        '
        'labelChildren
        '
        Me.labelChildren.AccessibleDescription = resources.GetString("labelChildren.AccessibleDescription")
        Me.labelChildren.AccessibleName = resources.GetString("labelChildren.AccessibleName")
        Me.labelChildren.Anchor = CType(resources.GetObject("labelChildren.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.labelChildren.AutoSize = CType(resources.GetObject("labelChildren.AutoSize"), Boolean)
        Me.labelChildren.BackgroundImageLayout = CType(resources.GetObject("labelChildren.BackgroundImageLayout"), System.Windows.Forms.ImageLayout)
        Me.labelChildren.Dock = CType(resources.GetObject("labelChildren.Dock"), System.Windows.Forms.DockStyle)
        Me.labelChildren.Font = CType(resources.GetObject("labelChildren.Font"), System.Drawing.Font)
        Me.labelChildren.ImageAlign = CType(resources.GetObject("labelChildren.ImageAlign"), System.Drawing.ContentAlignment)
        Me.labelChildren.ImageIndex = CType(resources.GetObject("labelChildren.ImageIndex"), Integer)
        Me.labelChildren.ImageKey = resources.GetString("labelChildren.ImageKey")
        Me.labelChildren.ImeMode = CType(resources.GetObject("labelChildren.ImeMode"), System.Windows.Forms.ImeMode)
        Me.labelChildren.Location = CType(resources.GetObject("labelChildren.Location"), System.Drawing.Point)
        Me.labelChildren.Name = "labelChildren"
        Me.labelChildren.RightToLeft = CType(resources.GetObject("labelChildren.RightToLeft"), System.Windows.Forms.RightToLeft)
        Me.labelChildren.Size = CType(resources.GetObject("labelChildren.Size"), System.Drawing.Size)
        Me.labelChildren.TabIndex = CType(resources.GetObject("labelChildren.TabIndex"), Integer)
        Me.labelChildren.TextAlign = CType(resources.GetObject("labelChildren.TextAlign"), System.Drawing.ContentAlignment)
        '
        'numericChildren
        '
        Me.numericChildren.AccessibleDescription = resources.GetString("numericChildren.AccessibleDescription")
        Me.numericChildren.AccessibleName = resources.GetString("numericChildren.AccessibleName")
        Me.numericChildren.Anchor = CType(resources.GetObject("numericChildren.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.numericChildren.AutoSize = CType(resources.GetObject("numericChildren.AutoSize"), Boolean)
        Me.numericChildren.Dock = CType(resources.GetObject("numericChildren.Dock"), System.Windows.Forms.DockStyle)
        Me.numericChildren.Font = CType(resources.GetObject("numericChildren.Font"), System.Drawing.Font)
        Me.numericChildren.ImeMode = CType(resources.GetObject("numericChildren.ImeMode"), System.Windows.Forms.ImeMode)
        Me.numericChildren.Location = CType(resources.GetObject("numericChildren.Location"), System.Drawing.Point)
        Me.numericChildren.Maximum = New Decimal(New Integer() {20, 0, 0, 0})
        Me.numericChildren.Name = "numericChildren"
        Me.numericChildren.RightToLeft = CType(resources.GetObject("numericChildren.RightToLeft"), System.Windows.Forms.RightToLeft)
        Me.numericChildren.Size = CType(resources.GetObject("numericChildren.Size"), System.Drawing.Size)
        Me.numericChildren.TabIndex = CType(resources.GetObject("numericChildren.TabIndex"), Integer)
        Me.numericChildren.TextAlign = CType(resources.GetObject("numericChildren.TextAlign"), System.Windows.Forms.HorizontalAlignment)
        Me.numericChildren.ThousandsSeparator = CType(resources.GetObject("numericChildren.ThousandsSeparator"), Boolean)
        Me.numericChildren.UpDownAlign = CType(resources.GetObject("numericChildren.UpDownAlign"), System.Windows.Forms.LeftRightAlignment)
        '
        'labelLastName
        '
        Me.labelLastName.AccessibleDescription = resources.GetString("labelLastName.AccessibleDescription")
        Me.labelLastName.AccessibleName = resources.GetString("labelLastName.AccessibleName")
        Me.labelLastName.Anchor = CType(resources.GetObject("labelLastName.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.labelLastName.AutoSize = CType(resources.GetObject("labelLastName.AutoSize"), Boolean)
        Me.labelLastName.BackgroundImageLayout = CType(resources.GetObject("labelLastName.BackgroundImageLayout"), System.Windows.Forms.ImageLayout)
        Me.labelLastName.Dock = CType(resources.GetObject("labelLastName.Dock"), System.Windows.Forms.DockStyle)
        Me.labelLastName.Font = CType(resources.GetObject("labelLastName.Font"), System.Drawing.Font)
        Me.labelLastName.ImageAlign = CType(resources.GetObject("labelLastName.ImageAlign"), System.Drawing.ContentAlignment)
        Me.labelLastName.ImageIndex = CType(resources.GetObject("labelLastName.ImageIndex"), Integer)
        Me.labelLastName.ImageKey = resources.GetString("labelLastName.ImageKey")
        Me.labelLastName.ImeMode = CType(resources.GetObject("labelLastName.ImeMode"), System.Windows.Forms.ImeMode)
        Me.labelLastName.Location = CType(resources.GetObject("labelLastName.Location"), System.Drawing.Point)
        Me.labelLastName.Name = "labelLastName"
        Me.labelLastName.RightToLeft = CType(resources.GetObject("labelLastName.RightToLeft"), System.Windows.Forms.RightToLeft)
        Me.labelLastName.Size = CType(resources.GetObject("labelLastName.Size"), System.Drawing.Size)
        Me.labelLastName.TabIndex = CType(resources.GetObject("labelLastName.TabIndex"), Integer)
        Me.labelLastName.TextAlign = CType(resources.GetObject("labelLastName.TextAlign"), System.Drawing.ContentAlignment)
        '
        'textLastName
        '
        Me.textLastName.AccessibleDescription = resources.GetString("textLastName.AccessibleDescription")
        Me.textLastName.AccessibleName = resources.GetString("textLastName.AccessibleName")
        Me.textLastName.Anchor = CType(resources.GetObject("textLastName.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.textLastName.AutoSize = CType(resources.GetObject("textLastName.AutoSize"), Boolean)
        Me.textLastName.BackgroundImage = CType(resources.GetObject("textLastName.BackgroundImage"), System.Drawing.Image)
        Me.textLastName.BackgroundImageLayout = CType(resources.GetObject("textLastName.BackgroundImageLayout"), System.Windows.Forms.ImageLayout)
        Me.textLastName.Dock = CType(resources.GetObject("textLastName.Dock"), System.Windows.Forms.DockStyle)
        Me.textLastName.Font = CType(resources.GetObject("textLastName.Font"), System.Drawing.Font)
        Me.textLastName.ImeMode = CType(resources.GetObject("textLastName.ImeMode"), System.Windows.Forms.ImeMode)
        Me.textLastName.Location = CType(resources.GetObject("textLastName.Location"), System.Drawing.Point)
        Me.textLastName.MaxLength = CType(resources.GetObject("textLastName.MaxLength"), Integer)
        Me.textLastName.Multiline = CType(resources.GetObject("textLastName.Multiline"), Boolean)
        Me.textLastName.Name = "textLastName"
        Me.textLastName.PasswordChar = CType(resources.GetObject("textLastName.PasswordChar"), Char)
        Me.textLastName.RightToLeft = CType(resources.GetObject("textLastName.RightToLeft"), System.Windows.Forms.RightToLeft)
        Me.textLastName.ScrollBars = CType(resources.GetObject("textLastName.ScrollBars"), System.Windows.Forms.ScrollBars)
        Me.textLastName.Size = CType(resources.GetObject("textLastName.Size"), System.Drawing.Size)
        Me.textLastName.TabIndex = CType(resources.GetObject("textLastName.TabIndex"), Integer)
        Me.textLastName.TextAlign = CType(resources.GetObject("textLastName.TextAlign"), System.Windows.Forms.HorizontalAlignment)
        Me.textLastName.WordWrap = CType(resources.GetObject("textLastName.WordWrap"), Boolean)
        '
        'textFirstName
        '
        Me.textFirstName.AccessibleDescription = resources.GetString("textFirstName.AccessibleDescription")
        Me.textFirstName.AccessibleName = resources.GetString("textFirstName.AccessibleName")
        Me.textFirstName.Anchor = CType(resources.GetObject("textFirstName.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.textFirstName.AutoSize = CType(resources.GetObject("textFirstName.AutoSize"), Boolean)
        Me.textFirstName.BackgroundImage = CType(resources.GetObject("textFirstName.BackgroundImage"), System.Drawing.Image)
        Me.textFirstName.BackgroundImageLayout = CType(resources.GetObject("textFirstName.BackgroundImageLayout"), System.Windows.Forms.ImageLayout)
        Me.textFirstName.Dock = CType(resources.GetObject("textFirstName.Dock"), System.Windows.Forms.DockStyle)
        Me.textFirstName.Font = CType(resources.GetObject("textFirstName.Font"), System.Drawing.Font)
        Me.textFirstName.ImeMode = CType(resources.GetObject("textFirstName.ImeMode"), System.Windows.Forms.ImeMode)
        Me.textFirstName.Location = CType(resources.GetObject("textFirstName.Location"), System.Drawing.Point)
        Me.textFirstName.MaxLength = CType(resources.GetObject("textFirstName.MaxLength"), Integer)
        Me.textFirstName.Multiline = CType(resources.GetObject("textFirstName.Multiline"), Boolean)
        Me.textFirstName.Name = "textFirstName"
        Me.textFirstName.PasswordChar = CType(resources.GetObject("textFirstName.PasswordChar"), Char)
        Me.textFirstName.RightToLeft = CType(resources.GetObject("textFirstName.RightToLeft"), System.Windows.Forms.RightToLeft)
        Me.textFirstName.ScrollBars = CType(resources.GetObject("textFirstName.ScrollBars"), System.Windows.Forms.ScrollBars)
        Me.textFirstName.Size = CType(resources.GetObject("textFirstName.Size"), System.Drawing.Size)
        Me.textFirstName.TabIndex = CType(resources.GetObject("textFirstName.TabIndex"), Integer)
        Me.textFirstName.TextAlign = CType(resources.GetObject("textFirstName.TextAlign"), System.Windows.Forms.HorizontalAlignment)
        Me.textFirstName.WordWrap = CType(resources.GetObject("textFirstName.WordWrap"), Boolean)
        '
        'labelFirstName
        '
        Me.labelFirstName.AccessibleDescription = resources.GetString("labelFirstName.AccessibleDescription")
        Me.labelFirstName.AccessibleName = resources.GetString("labelFirstName.AccessibleName")
        Me.labelFirstName.Anchor = CType(resources.GetObject("labelFirstName.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.labelFirstName.AutoSize = CType(resources.GetObject("labelFirstName.AutoSize"), Boolean)
        Me.labelFirstName.BackgroundImageLayout = CType(resources.GetObject("labelFirstName.BackgroundImageLayout"), System.Windows.Forms.ImageLayout)
        Me.labelFirstName.Dock = CType(resources.GetObject("labelFirstName.Dock"), System.Windows.Forms.DockStyle)
        Me.labelFirstName.Font = CType(resources.GetObject("labelFirstName.Font"), System.Drawing.Font)
        Me.labelFirstName.ImageAlign = CType(resources.GetObject("labelFirstName.ImageAlign"), System.Drawing.ContentAlignment)
        Me.labelFirstName.ImageIndex = CType(resources.GetObject("labelFirstName.ImageIndex"), Integer)
        Me.labelFirstName.ImageKey = resources.GetString("labelFirstName.ImageKey")
        Me.labelFirstName.ImeMode = CType(resources.GetObject("labelFirstName.ImeMode"), System.Windows.Forms.ImeMode)
        Me.labelFirstName.Location = CType(resources.GetObject("labelFirstName.Location"), System.Drawing.Point)
        Me.labelFirstName.Name = "labelFirstName"
        Me.labelFirstName.RightToLeft = CType(resources.GetObject("labelFirstName.RightToLeft"), System.Windows.Forms.RightToLeft)
        Me.labelFirstName.Size = CType(resources.GetObject("labelFirstName.Size"), System.Drawing.Size)
        Me.labelFirstName.TabIndex = CType(resources.GetObject("labelFirstName.TabIndex"), Integer)
        Me.labelFirstName.TextAlign = CType(resources.GetObject("labelFirstName.TextAlign"), System.Drawing.ContentAlignment)
        '
        'buttonFlag
        '
        Me.buttonFlag.AccessibleDescription = resources.GetString("buttonFlag.AccessibleDescription")
        Me.buttonFlag.AccessibleName = resources.GetString("buttonFlag.AccessibleName")
        Me.buttonFlag.Anchor = CType(resources.GetObject("buttonFlag.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.buttonFlag.AutoSize = CType(resources.GetObject("buttonFlag.AutoSize"), Boolean)
        Me.buttonFlag.BackgroundImage = CType(resources.GetObject("buttonFlag.BackgroundImage"), System.Drawing.Image)
        Me.buttonFlag.BackgroundImageLayout = CType(resources.GetObject("buttonFlag.BackgroundImageLayout"), System.Windows.Forms.ImageLayout)
        Me.buttonFlag.Dock = CType(resources.GetObject("buttonFlag.Dock"), System.Windows.Forms.DockStyle)
        Me.buttonFlag.FlatStyle = CType(resources.GetObject("buttonFlag.FlatStyle"), System.Windows.Forms.FlatStyle)
        Me.buttonFlag.Font = CType(resources.GetObject("buttonFlag.Font"), System.Drawing.Font)
        Me.buttonFlag.ImageAlign = CType(resources.GetObject("buttonFlag.ImageAlign"), System.Drawing.ContentAlignment)
        Me.buttonFlag.ImageIndex = CType(resources.GetObject("buttonFlag.ImageIndex"), Integer)
        Me.buttonFlag.ImageKey = resources.GetString("buttonFlag.ImageKey")
        Me.buttonFlag.ImeMode = CType(resources.GetObject("buttonFlag.ImeMode"), System.Windows.Forms.ImeMode)
        Me.buttonFlag.Location = CType(resources.GetObject("buttonFlag.Location"), System.Drawing.Point)
        Me.buttonFlag.Name = "buttonFlag"
        Me.buttonFlag.RightToLeft = CType(resources.GetObject("buttonFlag.RightToLeft"), System.Windows.Forms.RightToLeft)
        Me.buttonFlag.Size = CType(resources.GetObject("buttonFlag.Size"), System.Drawing.Size)
        Me.buttonFlag.TabIndex = CType(resources.GetObject("buttonFlag.TabIndex"), Integer)
        Me.buttonFlag.TextAlign = CType(resources.GetObject("buttonFlag.TextAlign"), System.Drawing.ContentAlignment)
        Me.buttonFlag.TextImageRelation = CType(resources.GetObject("buttonFlag.TextImageRelation"), System.Windows.Forms.TextImageRelation)
        '
        'formMain
        '
        Me.AutoScaleBaseSize = CType(resources.GetObject("$this.AutoScaleBaseSize"), System.Drawing.Size)
        Me.BackgroundImageLayout = CType(resources.GetObject("$this.BackgroundImageLayout"), System.Windows.Forms.ImageLayout)
        Me.ClientSize = CType(resources.GetObject("$this.ClientSize"), System.Drawing.Size)
        Me.Controls.Add(Me.buttonFlag)
        Me.Controls.Add(Me.groupPersonal)
        Me.Controls.Add(Me.groupAddress)
        Me.Font = CType(resources.GetObject("$this.Font"), System.Drawing.Font)
        Me.Name = "formMain"
        Me.StartPosition = CType(resources.GetObject("$this.StartPosition"), System.Windows.Forms.FormStartPosition)
        Me.groupAddress.ResumeLayout(False)
        Me.groupAddress.PerformLayout()
        Me.groupPersonal.ResumeLayout(False)
        Me.groupPersonal.PerformLayout()
        CType(Me.numericChildren, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region
    'Private resMgr As System.Resources.ResourceManager

    Private Sub formMain_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        ' do we have to set up a resource manager???
        'resMgr = New System.Resources.ResourceManager(GetType(formMain))

        '
        '
        '
        ' only comment these out
        'Me.Text = resMgr.GetString("CustomerFormTile")
        'groupPersonal.Text = resMgr.GetString("CustomerFormpersonal")
        'labelChildren.Text = resMgr.GetString("CustomerFormKids")
        'labelDOB.Text = resMgr.GetString("FlagSmall")
        'buttonFlag.BackgroundImage = resMgr.GetObject("CustomerFirmDOB")
        '
        '
        '
        '
        '
        '
        '
        '
        '
        '
        '
        '
        '
        '
        '
        '
        '
        '
        '
        '''' CustomerFormTitle
        Me.Text = strings.CustomerFormTitle
        '''CustomerFormPersonal
        groupPersonal.Text = strings.CustomerFormPersonal
        '''CustomerFormChildren
        labelChildren.Text = strings.CustomerFormChildren
        '''CustomerFormDOB
        labelDOB.Text = strings.CustomerFormDOB
        '''MainFlag
        buttonFlag.BackgroundImage = strings.MainFlag
        '
        '
        '
        '
        '
        '
        '
        '
        '
        '
        '
        '
        '
        '
        '
        '
        '
        '
        '
        '
        ' precooked...
        labelFirstName.Text = strings.CustomerFormFirstName
        labelCity.Text = strings.CustomerFormCity
        labelState.Text = strings.CustomerFormState
        labelStreet1.Text = strings.CustomerFormStreet1
        labelStreet2.Text = strings.CustomerFormStreet2
        groupAddress.Text = strings.CustomerFormAddress
        labelLastName.Text = strings.CustomerFormLastName
        labelMaritalStatus.Text = strings.CustomerFormMaritalStatus

    End Sub
End Class
