'*****************************************************************************
' Copyright (C) 1999-2002, Microsoft Corporation.  All Rights Reserved.
'*****************************************************************************

Imports System
Imports System.Windows.Forms


Public Class OpenFiles : Inherits Form
    ' A window which allows the user to select both Assembly and XML
    ' Documentation files to open.

#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call

    End Sub

    'Form overrides dispose to clean up the component list.
    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        MyBase.Dispose(disposing)
        If Not (components Is Nothing) Then
            components.Dispose()
        End If
    End Sub

    Private WithEvents OpenFileDialog As System.Windows.Forms.OpenFileDialog
    Private WithEvents AsmPathInputBox As System.Windows.Forms.TextBox
    Private WithEvents XMLPathInputBox As System.Windows.Forms.TextBox
    Private WithEvents BrowseAsmButton As System.Windows.Forms.Button
    Private WithEvents BrowseXMLButton As System.Windows.Forms.Button
    Private WithEvents ButtonOK As System.Windows.Forms.Button
    Private WithEvents ButtonCancel As System.Windows.Forms.Button
    Private WithEvents LabelInstruction As System.Windows.Forms.Label

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.Container

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    Public WithEvents Label1 As System.Windows.Forms.Label
    Public WithEvents Label2 As System.Windows.Forms.Label
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(OpenFiles))
        Me.LabelInstruction = New System.Windows.Forms.Label()
        Me.AsmPathInputBox = New System.Windows.Forms.TextBox()
        Me.XMLPathInputBox = New System.Windows.Forms.TextBox()
        Me.OpenFileDialog = New System.Windows.Forms.OpenFileDialog()
        Me.BrowseAsmButton = New System.Windows.Forms.Button()
        Me.BrowseXMLButton = New System.Windows.Forms.Button()
        Me.ButtonOK = New System.Windows.Forms.Button()
        Me.ButtonCancel = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'LabelInstruction
        '
        Me.LabelInstruction.AccessibleDescription = CType(resources.GetObject("LabelInstruction.AccessibleDescription"), String)
        Me.LabelInstruction.AccessibleName = CType(resources.GetObject("LabelInstruction.AccessibleName"), String)
        Me.LabelInstruction.Anchor = CType(resources.GetObject("LabelInstruction.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.LabelInstruction.AutoSize = CType(resources.GetObject("LabelInstruction.AutoSize"), Boolean)
        Me.LabelInstruction.Dock = CType(resources.GetObject("LabelInstruction.Dock"), System.Windows.Forms.DockStyle)
        Me.LabelInstruction.Enabled = CType(resources.GetObject("LabelInstruction.Enabled"), Boolean)
        Me.LabelInstruction.Font = CType(resources.GetObject("LabelInstruction.Font"), System.Drawing.Font)
        Me.LabelInstruction.Image = CType(resources.GetObject("LabelInstruction.Image"), System.Drawing.Image)
        Me.LabelInstruction.ImageAlign = CType(resources.GetObject("LabelInstruction.ImageAlign"), System.Drawing.ContentAlignment)
        Me.LabelInstruction.ImageIndex = CType(resources.GetObject("LabelInstruction.ImageIndex"), Integer)
        Me.LabelInstruction.ImeMode = CType(resources.GetObject("LabelInstruction.ImeMode"), System.Windows.Forms.ImeMode)
        Me.LabelInstruction.Location = CType(resources.GetObject("LabelInstruction.Location"), System.Drawing.Point)
        Me.LabelInstruction.Name = "LabelInstruction"
        Me.LabelInstruction.RightToLeft = CType(resources.GetObject("LabelInstruction.RightToLeft"), System.Windows.Forms.RightToLeft)
        Me.LabelInstruction.Size = CType(resources.GetObject("LabelInstruction.Size"), System.Drawing.Size)
        Me.LabelInstruction.TabIndex = CType(resources.GetObject("LabelInstruction.TabIndex"), Integer)
        Me.LabelInstruction.Text = resources.GetString("LabelInstruction.Text")
        Me.LabelInstruction.TextAlign = CType(resources.GetObject("LabelInstruction.TextAlign"), System.Drawing.ContentAlignment)
        Me.LabelInstruction.Visible = CType(resources.GetObject("LabelInstruction.Visible"), Boolean)
        '
        'AsmPathInputBox
        '
        Me.AsmPathInputBox.AccessibleDescription = CType(resources.GetObject("AsmPathInputBox.AccessibleDescription"), String)
        Me.AsmPathInputBox.AccessibleName = CType(resources.GetObject("AsmPathInputBox.AccessibleName"), String)
        Me.AsmPathInputBox.Anchor = CType(resources.GetObject("AsmPathInputBox.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.AsmPathInputBox.AutoSize = CType(resources.GetObject("AsmPathInputBox.AutoSize"), Boolean)
        Me.AsmPathInputBox.BackgroundImage = CType(resources.GetObject("AsmPathInputBox.BackgroundImage"), System.Drawing.Image)
        Me.AsmPathInputBox.Dock = CType(resources.GetObject("AsmPathInputBox.Dock"), System.Windows.Forms.DockStyle)
        Me.AsmPathInputBox.Enabled = CType(resources.GetObject("AsmPathInputBox.Enabled"), Boolean)
        Me.AsmPathInputBox.Font = CType(resources.GetObject("AsmPathInputBox.Font"), System.Drawing.Font)
        Me.AsmPathInputBox.ImeMode = CType(resources.GetObject("AsmPathInputBox.ImeMode"), System.Windows.Forms.ImeMode)
        Me.AsmPathInputBox.Location = CType(resources.GetObject("AsmPathInputBox.Location"), System.Drawing.Point)
        Me.AsmPathInputBox.MaxLength = CType(resources.GetObject("AsmPathInputBox.MaxLength"), Integer)
        Me.AsmPathInputBox.Multiline = CType(resources.GetObject("AsmPathInputBox.Multiline"), Boolean)
        Me.AsmPathInputBox.Name = "AsmPathInputBox"
        Me.AsmPathInputBox.PasswordChar = CType(resources.GetObject("AsmPathInputBox.PasswordChar"), Char)
        Me.AsmPathInputBox.RightToLeft = CType(resources.GetObject("AsmPathInputBox.RightToLeft"), System.Windows.Forms.RightToLeft)
        Me.AsmPathInputBox.ScrollBars = CType(resources.GetObject("AsmPathInputBox.ScrollBars"), System.Windows.Forms.ScrollBars)
        Me.AsmPathInputBox.Size = CType(resources.GetObject("AsmPathInputBox.Size"), System.Drawing.Size)
        Me.AsmPathInputBox.TabIndex = CType(resources.GetObject("AsmPathInputBox.TabIndex"), Integer)
        Me.AsmPathInputBox.Text = resources.GetString("AsmPathInputBox.Text")
        Me.AsmPathInputBox.TextAlign = CType(resources.GetObject("AsmPathInputBox.TextAlign"), System.Windows.Forms.HorizontalAlignment)
        Me.AsmPathInputBox.Visible = CType(resources.GetObject("AsmPathInputBox.Visible"), Boolean)
        Me.AsmPathInputBox.WordWrap = CType(resources.GetObject("AsmPathInputBox.WordWrap"), Boolean)
        '
        'XMLPathInputBox
        '
        Me.XMLPathInputBox.AccessibleDescription = CType(resources.GetObject("XMLPathInputBox.AccessibleDescription"), String)
        Me.XMLPathInputBox.AccessibleName = CType(resources.GetObject("XMLPathInputBox.AccessibleName"), String)
        Me.XMLPathInputBox.Anchor = CType(resources.GetObject("XMLPathInputBox.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.XMLPathInputBox.AutoSize = CType(resources.GetObject("XMLPathInputBox.AutoSize"), Boolean)
        Me.XMLPathInputBox.BackgroundImage = CType(resources.GetObject("XMLPathInputBox.BackgroundImage"), System.Drawing.Image)
        Me.XMLPathInputBox.Dock = CType(resources.GetObject("XMLPathInputBox.Dock"), System.Windows.Forms.DockStyle)
        Me.XMLPathInputBox.Enabled = CType(resources.GetObject("XMLPathInputBox.Enabled"), Boolean)
        Me.XMLPathInputBox.Font = CType(resources.GetObject("XMLPathInputBox.Font"), System.Drawing.Font)
        Me.XMLPathInputBox.ImeMode = CType(resources.GetObject("XMLPathInputBox.ImeMode"), System.Windows.Forms.ImeMode)
        Me.XMLPathInputBox.Location = CType(resources.GetObject("XMLPathInputBox.Location"), System.Drawing.Point)
        Me.XMLPathInputBox.MaxLength = CType(resources.GetObject("XMLPathInputBox.MaxLength"), Integer)
        Me.XMLPathInputBox.Multiline = CType(resources.GetObject("XMLPathInputBox.Multiline"), Boolean)
        Me.XMLPathInputBox.Name = "XMLPathInputBox"
        Me.XMLPathInputBox.PasswordChar = CType(resources.GetObject("XMLPathInputBox.PasswordChar"), Char)
        Me.XMLPathInputBox.RightToLeft = CType(resources.GetObject("XMLPathInputBox.RightToLeft"), System.Windows.Forms.RightToLeft)
        Me.XMLPathInputBox.ScrollBars = CType(resources.GetObject("XMLPathInputBox.ScrollBars"), System.Windows.Forms.ScrollBars)
        Me.XMLPathInputBox.Size = CType(resources.GetObject("XMLPathInputBox.Size"), System.Drawing.Size)
        Me.XMLPathInputBox.TabIndex = CType(resources.GetObject("XMLPathInputBox.TabIndex"), Integer)
        Me.XMLPathInputBox.Text = resources.GetString("XMLPathInputBox.Text")
        Me.XMLPathInputBox.TextAlign = CType(resources.GetObject("XMLPathInputBox.TextAlign"), System.Windows.Forms.HorizontalAlignment)
        Me.XMLPathInputBox.Visible = CType(resources.GetObject("XMLPathInputBox.Visible"), Boolean)
        Me.XMLPathInputBox.WordWrap = CType(resources.GetObject("XMLPathInputBox.WordWrap"), Boolean)
        '
        'OpenFileDialog
        '
        Me.OpenFileDialog.Filter = resources.GetString("OpenFileDialog.Filter")
        Me.OpenFileDialog.Title = resources.GetString("OpenFileDialog.Title")
        '
        'BrowseAsmButton
        '
        Me.BrowseAsmButton.AccessibleDescription = CType(resources.GetObject("BrowseAsmButton.AccessibleDescription"), String)
        Me.BrowseAsmButton.AccessibleName = CType(resources.GetObject("BrowseAsmButton.AccessibleName"), String)
        Me.BrowseAsmButton.Anchor = CType(resources.GetObject("BrowseAsmButton.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.BrowseAsmButton.BackgroundImage = CType(resources.GetObject("BrowseAsmButton.BackgroundImage"), System.Drawing.Image)
        Me.BrowseAsmButton.Dock = CType(resources.GetObject("BrowseAsmButton.Dock"), System.Windows.Forms.DockStyle)
        Me.BrowseAsmButton.Enabled = CType(resources.GetObject("BrowseAsmButton.Enabled"), Boolean)
        Me.BrowseAsmButton.FlatStyle = CType(resources.GetObject("BrowseAsmButton.FlatStyle"), System.Windows.Forms.FlatStyle)
        Me.BrowseAsmButton.Font = CType(resources.GetObject("BrowseAsmButton.Font"), System.Drawing.Font)
        Me.BrowseAsmButton.Image = CType(resources.GetObject("BrowseAsmButton.Image"), System.Drawing.Image)
        Me.BrowseAsmButton.ImageAlign = CType(resources.GetObject("BrowseAsmButton.ImageAlign"), System.Drawing.ContentAlignment)
        Me.BrowseAsmButton.ImageIndex = CType(resources.GetObject("BrowseAsmButton.ImageIndex"), Integer)
        Me.BrowseAsmButton.ImeMode = CType(resources.GetObject("BrowseAsmButton.ImeMode"), System.Windows.Forms.ImeMode)
        Me.BrowseAsmButton.Location = CType(resources.GetObject("BrowseAsmButton.Location"), System.Drawing.Point)
        Me.BrowseAsmButton.Name = "BrowseAsmButton"
        Me.BrowseAsmButton.RightToLeft = CType(resources.GetObject("BrowseAsmButton.RightToLeft"), System.Windows.Forms.RightToLeft)
        Me.BrowseAsmButton.Size = CType(resources.GetObject("BrowseAsmButton.Size"), System.Drawing.Size)
        Me.BrowseAsmButton.TabIndex = CType(resources.GetObject("BrowseAsmButton.TabIndex"), Integer)
        Me.BrowseAsmButton.Text = resources.GetString("BrowseAsmButton.Text")
        Me.BrowseAsmButton.TextAlign = CType(resources.GetObject("BrowseAsmButton.TextAlign"), System.Drawing.ContentAlignment)
        Me.BrowseAsmButton.Visible = CType(resources.GetObject("BrowseAsmButton.Visible"), Boolean)
        '
        'BrowseXMLButton
        '
        Me.BrowseXMLButton.AccessibleDescription = CType(resources.GetObject("BrowseXMLButton.AccessibleDescription"), String)
        Me.BrowseXMLButton.AccessibleName = CType(resources.GetObject("BrowseXMLButton.AccessibleName"), String)
        Me.BrowseXMLButton.Anchor = CType(resources.GetObject("BrowseXMLButton.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.BrowseXMLButton.BackgroundImage = CType(resources.GetObject("BrowseXMLButton.BackgroundImage"), System.Drawing.Image)
        Me.BrowseXMLButton.Dock = CType(resources.GetObject("BrowseXMLButton.Dock"), System.Windows.Forms.DockStyle)
        Me.BrowseXMLButton.Enabled = CType(resources.GetObject("BrowseXMLButton.Enabled"), Boolean)
        Me.BrowseXMLButton.FlatStyle = CType(resources.GetObject("BrowseXMLButton.FlatStyle"), System.Windows.Forms.FlatStyle)
        Me.BrowseXMLButton.Font = CType(resources.GetObject("BrowseXMLButton.Font"), System.Drawing.Font)
        Me.BrowseXMLButton.Image = CType(resources.GetObject("BrowseXMLButton.Image"), System.Drawing.Image)
        Me.BrowseXMLButton.ImageAlign = CType(resources.GetObject("BrowseXMLButton.ImageAlign"), System.Drawing.ContentAlignment)
        Me.BrowseXMLButton.ImageIndex = CType(resources.GetObject("BrowseXMLButton.ImageIndex"), Integer)
        Me.BrowseXMLButton.ImeMode = CType(resources.GetObject("BrowseXMLButton.ImeMode"), System.Windows.Forms.ImeMode)
        Me.BrowseXMLButton.Location = CType(resources.GetObject("BrowseXMLButton.Location"), System.Drawing.Point)
        Me.BrowseXMLButton.Name = "BrowseXMLButton"
        Me.BrowseXMLButton.RightToLeft = CType(resources.GetObject("BrowseXMLButton.RightToLeft"), System.Windows.Forms.RightToLeft)
        Me.BrowseXMLButton.Size = CType(resources.GetObject("BrowseXMLButton.Size"), System.Drawing.Size)
        Me.BrowseXMLButton.TabIndex = CType(resources.GetObject("BrowseXMLButton.TabIndex"), Integer)
        Me.BrowseXMLButton.Text = resources.GetString("BrowseXMLButton.Text")
        Me.BrowseXMLButton.TextAlign = CType(resources.GetObject("BrowseXMLButton.TextAlign"), System.Drawing.ContentAlignment)
        Me.BrowseXMLButton.Visible = CType(resources.GetObject("BrowseXMLButton.Visible"), Boolean)
        '
        'ButtonOK
        '
        Me.ButtonOK.AccessibleDescription = CType(resources.GetObject("ButtonOK.AccessibleDescription"), String)
        Me.ButtonOK.AccessibleName = CType(resources.GetObject("ButtonOK.AccessibleName"), String)
        Me.ButtonOK.Anchor = CType(resources.GetObject("ButtonOK.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.ButtonOK.BackgroundImage = CType(resources.GetObject("ButtonOK.BackgroundImage"), System.Drawing.Image)
        Me.ButtonOK.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.ButtonOK.Dock = CType(resources.GetObject("ButtonOK.Dock"), System.Windows.Forms.DockStyle)
        Me.ButtonOK.Enabled = CType(resources.GetObject("ButtonOK.Enabled"), Boolean)
        Me.ButtonOK.FlatStyle = CType(resources.GetObject("ButtonOK.FlatStyle"), System.Windows.Forms.FlatStyle)
        Me.ButtonOK.Font = CType(resources.GetObject("ButtonOK.Font"), System.Drawing.Font)
        Me.ButtonOK.Image = CType(resources.GetObject("ButtonOK.Image"), System.Drawing.Image)
        Me.ButtonOK.ImageAlign = CType(resources.GetObject("ButtonOK.ImageAlign"), System.Drawing.ContentAlignment)
        Me.ButtonOK.ImageIndex = CType(resources.GetObject("ButtonOK.ImageIndex"), Integer)
        Me.ButtonOK.ImeMode = CType(resources.GetObject("ButtonOK.ImeMode"), System.Windows.Forms.ImeMode)
        Me.ButtonOK.Location = CType(resources.GetObject("ButtonOK.Location"), System.Drawing.Point)
        Me.ButtonOK.Name = "ButtonOK"
        Me.ButtonOK.RightToLeft = CType(resources.GetObject("ButtonOK.RightToLeft"), System.Windows.Forms.RightToLeft)
        Me.ButtonOK.Size = CType(resources.GetObject("ButtonOK.Size"), System.Drawing.Size)
        Me.ButtonOK.TabIndex = CType(resources.GetObject("ButtonOK.TabIndex"), Integer)
        Me.ButtonOK.Text = resources.GetString("ButtonOK.Text")
        Me.ButtonOK.TextAlign = CType(resources.GetObject("ButtonOK.TextAlign"), System.Drawing.ContentAlignment)
        Me.ButtonOK.Visible = CType(resources.GetObject("ButtonOK.Visible"), Boolean)
        '
        'ButtonCancel
        '
        Me.ButtonCancel.AccessibleDescription = CType(resources.GetObject("ButtonCancel.AccessibleDescription"), String)
        Me.ButtonCancel.AccessibleName = CType(resources.GetObject("ButtonCancel.AccessibleName"), String)
        Me.ButtonCancel.Anchor = CType(resources.GetObject("ButtonCancel.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.ButtonCancel.BackgroundImage = CType(resources.GetObject("ButtonCancel.BackgroundImage"), System.Drawing.Image)
        Me.ButtonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.ButtonCancel.Dock = CType(resources.GetObject("ButtonCancel.Dock"), System.Windows.Forms.DockStyle)
        Me.ButtonCancel.Enabled = CType(resources.GetObject("ButtonCancel.Enabled"), Boolean)
        Me.ButtonCancel.FlatStyle = CType(resources.GetObject("ButtonCancel.FlatStyle"), System.Windows.Forms.FlatStyle)
        Me.ButtonCancel.Font = CType(resources.GetObject("ButtonCancel.Font"), System.Drawing.Font)
        Me.ButtonCancel.Image = CType(resources.GetObject("ButtonCancel.Image"), System.Drawing.Image)
        Me.ButtonCancel.ImageAlign = CType(resources.GetObject("ButtonCancel.ImageAlign"), System.Drawing.ContentAlignment)
        Me.ButtonCancel.ImageIndex = CType(resources.GetObject("ButtonCancel.ImageIndex"), Integer)
        Me.ButtonCancel.ImeMode = CType(resources.GetObject("ButtonCancel.ImeMode"), System.Windows.Forms.ImeMode)
        Me.ButtonCancel.Location = CType(resources.GetObject("ButtonCancel.Location"), System.Drawing.Point)
        Me.ButtonCancel.Name = "ButtonCancel"
        Me.ButtonCancel.RightToLeft = CType(resources.GetObject("ButtonCancel.RightToLeft"), System.Windows.Forms.RightToLeft)
        Me.ButtonCancel.Size = CType(resources.GetObject("ButtonCancel.Size"), System.Drawing.Size)
        Me.ButtonCancel.TabIndex = CType(resources.GetObject("ButtonCancel.TabIndex"), Integer)
        Me.ButtonCancel.Text = resources.GetString("ButtonCancel.Text")
        Me.ButtonCancel.TextAlign = CType(resources.GetObject("ButtonCancel.TextAlign"), System.Drawing.ContentAlignment)
        Me.ButtonCancel.Visible = CType(resources.GetObject("ButtonCancel.Visible"), Boolean)
        '
        'Label1
        '
        Me.Label1.AccessibleDescription = CType(resources.GetObject("Label1.AccessibleDescription"), String)
        Me.Label1.AccessibleName = CType(resources.GetObject("Label1.AccessibleName"), String)
        Me.Label1.Anchor = CType(resources.GetObject("Label1.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.Label1.AutoSize = CType(resources.GetObject("Label1.AutoSize"), Boolean)
        Me.Label1.Dock = CType(resources.GetObject("Label1.Dock"), System.Windows.Forms.DockStyle)
        Me.Label1.Enabled = CType(resources.GetObject("Label1.Enabled"), Boolean)
        Me.Label1.Font = CType(resources.GetObject("Label1.Font"), System.Drawing.Font)
        Me.Label1.Image = CType(resources.GetObject("Label1.Image"), System.Drawing.Image)
        Me.Label1.ImageAlign = CType(resources.GetObject("Label1.ImageAlign"), System.Drawing.ContentAlignment)
        Me.Label1.ImageIndex = CType(resources.GetObject("Label1.ImageIndex"), Integer)
        Me.Label1.ImeMode = CType(resources.GetObject("Label1.ImeMode"), System.Windows.Forms.ImeMode)
        Me.Label1.Location = CType(resources.GetObject("Label1.Location"), System.Drawing.Point)
        Me.Label1.Name = "Label1"
        Me.Label1.RightToLeft = CType(resources.GetObject("Label1.RightToLeft"), System.Windows.Forms.RightToLeft)
        Me.Label1.Size = CType(resources.GetObject("Label1.Size"), System.Drawing.Size)
        Me.Label1.TabIndex = CType(resources.GetObject("Label1.TabIndex"), Integer)
        Me.Label1.Text = resources.GetString("Label1.Text")
        Me.Label1.TextAlign = CType(resources.GetObject("Label1.TextAlign"), System.Drawing.ContentAlignment)
        Me.Label1.Visible = CType(resources.GetObject("Label1.Visible"), Boolean)
        '
        'Label2
        '
        Me.Label2.AccessibleDescription = CType(resources.GetObject("Label2.AccessibleDescription"), String)
        Me.Label2.AccessibleName = CType(resources.GetObject("Label2.AccessibleName"), String)
        Me.Label2.Anchor = CType(resources.GetObject("Label2.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.Label2.AutoSize = CType(resources.GetObject("Label2.AutoSize"), Boolean)
        Me.Label2.Dock = CType(resources.GetObject("Label2.Dock"), System.Windows.Forms.DockStyle)
        Me.Label2.Enabled = CType(resources.GetObject("Label2.Enabled"), Boolean)
        Me.Label2.Font = CType(resources.GetObject("Label2.Font"), System.Drawing.Font)
        Me.Label2.Image = CType(resources.GetObject("Label2.Image"), System.Drawing.Image)
        Me.Label2.ImageAlign = CType(resources.GetObject("Label2.ImageAlign"), System.Drawing.ContentAlignment)
        Me.Label2.ImageIndex = CType(resources.GetObject("Label2.ImageIndex"), Integer)
        Me.Label2.ImeMode = CType(resources.GetObject("Label2.ImeMode"), System.Windows.Forms.ImeMode)
        Me.Label2.Location = CType(resources.GetObject("Label2.Location"), System.Drawing.Point)
        Me.Label2.Name = "Label2"
        Me.Label2.RightToLeft = CType(resources.GetObject("Label2.RightToLeft"), System.Windows.Forms.RightToLeft)
        Me.Label2.Size = CType(resources.GetObject("Label2.Size"), System.Drawing.Size)
        Me.Label2.TabIndex = CType(resources.GetObject("Label2.TabIndex"), Integer)
        Me.Label2.Text = resources.GetString("Label2.Text")
        Me.Label2.TextAlign = CType(resources.GetObject("Label2.TextAlign"), System.Drawing.ContentAlignment)
        Me.Label2.Visible = CType(resources.GetObject("Label2.Visible"), Boolean)
        '
        'OpenFiles
        '
        Me.AcceptButton = Me.ButtonOK
        Me.AccessibleDescription = CType(resources.GetObject("$this.AccessibleDescription"), String)
        Me.AccessibleName = CType(resources.GetObject("$this.AccessibleName"), String)
        Me.Anchor = CType(resources.GetObject("$this.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.AutoScaleBaseSize = CType(resources.GetObject("$this.AutoScaleBaseSize"), System.Drawing.Size)
        Me.AutoScroll = CType(resources.GetObject("$this.AutoScroll"), Boolean)
        Me.AutoScrollMargin = CType(resources.GetObject("$this.AutoScrollMargin"), System.Drawing.Size)
        Me.AutoScrollMinSize = CType(resources.GetObject("$this.AutoScrollMinSize"), System.Drawing.Size)
        Me.BackgroundImage = CType(resources.GetObject("$this.BackgroundImage"), System.Drawing.Image)
        Me.CancelButton = Me.ButtonCancel
        Me.ClientSize = CType(resources.GetObject("$this.ClientSize"), System.Drawing.Size)
        Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.Label2, Me.Label1, Me.ButtonCancel, Me.ButtonOK, Me.BrowseXMLButton, Me.BrowseAsmButton, Me.XMLPathInputBox, Me.AsmPathInputBox, Me.LabelInstruction})
        Me.Dock = CType(resources.GetObject("$this.Dock"), System.Windows.Forms.DockStyle)
        Me.Enabled = CType(resources.GetObject("$this.Enabled"), Boolean)
        Me.Font = CType(resources.GetObject("$this.Font"), System.Drawing.Font)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.ImeMode = CType(resources.GetObject("$this.ImeMode"), System.Windows.Forms.ImeMode)
        Me.Location = CType(resources.GetObject("$this.Location"), System.Drawing.Point)
        Me.MaximizeBox = False
        Me.MaximumSize = CType(resources.GetObject("$this.MaximumSize"), System.Drawing.Size)
        Me.MinimizeBox = False
        Me.MinimumSize = CType(resources.GetObject("$this.MinimumSize"), System.Drawing.Size)
        Me.Name = "OpenFiles"
        Me.RightToLeft = CType(resources.GetObject("$this.RightToLeft"), System.Windows.Forms.RightToLeft)
        Me.ShowInTaskbar = False
        Me.StartPosition = CType(resources.GetObject("$this.StartPosition"), System.Windows.Forms.FormStartPosition)
        Me.Text = resources.GetString("$this.Text")
        Me.Visible = CType(resources.GetObject("$this.Visible"), Boolean)
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private Sub BrowseAsm_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BrowseAsmButton.Click
        ' Open a dialog to select the Assembly file.

        OpenFileDialog.Filter = ASSEMBLY_FILE_FILTER

        If OpenFileDialog.ShowDialog = DialogResult.OK Then
            AsmPathInputBox.Text = OpenFileDialog.FileName
            'Provide the XML Documentation file path if a corresponding file exists and the user hasn't chosen one yet.
            Dim xmlp As String = IO.Path.GetDirectoryName(AsmPathInputBox.Text) & "\" & IO.Path.GetFileNameWithoutExtension(AsmPathInputBox.Text) & ".xml"
            If XMLPathInputBox.Text = "" AndAlso IO.File.Exists(xmlp) Then
                XMLPathInputBox.Text = xmlp
                Me.ButtonOK.Focus()
            Else
                Me.BrowseXMLButton.Focus()
            End If
        End If
    End Sub

    Private Sub BrowseXML_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BrowseXMLButton.Click
        ' Open a dialog to select the XML Documentation file.

        OpenFileDialog.Filter = XML_FILE_FILTER
        If OpenFileDialog.ShowDialog = DialogResult.OK Then
            XMLPathInputBox.Text = OpenFileDialog.FileName
        End If
    End Sub

    Private Sub Path_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AsmPathInputBox.TextChanged, XMLPathInputBox.TextChanged
        'Enable OK button when an assembly file is specified.
        ButtonOK.Enabled = (AsmPathInputBox.Text <> "")
    End Sub

    Public ReadOnly Property XMLDocumentationPath() As String
        Get
            Return XMLPathInputBox.Text
        End Get
    End Property

    Public ReadOnly Property AssemblyPath() As String
        Get
            Return AsmPathInputBox.Text
        End Get
    End Property

End Class


