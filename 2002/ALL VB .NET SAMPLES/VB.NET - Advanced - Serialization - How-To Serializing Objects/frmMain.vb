'Copyright (C) 2002 Microsoft Corporation
'All rights reserved.
'THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, EITHER 
'EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED WARRANTIES OF 
'MERCHANTIBILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.

'Requires the Trial or Release version of Visual Studio .NET Professional (or greater).

Option Strict On

Imports System.IO 'Namespace for Filestreams
Imports System.Runtime.Serialization.Formatters.Binary 'Namespace for BinaryFormatter

'Need to reference System.Runtime.Serialization.Formatters.Soap for this Import
Imports System.Runtime.Serialization.Formatters.Soap


Public Class frmMain
	Inherits System.Windows.Forms.Form

	' These variables are initialized in the Form_Load event.
	Private strFileName1 As String
	Private strFileName2 As String
	Private strFileName3 As String

#Region " Windows Form Designer generated code "

	Public Sub New()
		MyBase.New()

		'This call is required by the Windows Form Designer.
		InitializeComponent()

		'Add any initialization after the InitializeComponent() call

		' So that we only need to set the title of the application once,
		' we use the AssemblyInfo class (defined in the AssemblyInfo.vb file)
		' to read the AssemblyTitle attribute.
		Dim ainfo As New AssemblyInfo()

		Me.Text = ainfo.Title
		Me.mnuAbout.Text = String.Format("&About {0} ...", ainfo.Title)

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
	Friend WithEvents mnuMain As System.Windows.Forms.MainMenu
	Friend WithEvents mnuFile As System.Windows.Forms.MenuItem
	Friend WithEvents mnuExit As System.Windows.Forms.MenuItem
	Friend WithEvents mnuHelp As System.Windows.Forms.MenuItem
	Friend WithEvents mnuAbout As System.Windows.Forms.MenuItem
	Friend WithEvents cmdCustomDeserialization As System.Windows.Forms.Button
	Friend WithEvents cmdCustomSerialization As System.Windows.Forms.Button
	Friend WithEvents grpCustomSerialization As System.Windows.Forms.GroupBox
	Friend WithEvents grpDefaultSerializationSoap As System.Windows.Forms.GroupBox
	Friend WithEvents grpDefaultSerializationBinary As System.Windows.Forms.GroupBox
	Friend WithEvents cmdStandardSerializationBinary As System.Windows.Forms.Button
	Friend WithEvents cmdStandardDeserializationSoap As System.Windows.Forms.Button
	Friend WithEvents cmdStandardSerializationSoap As System.Windows.Forms.Button
	Friend WithEvents cmdStandardDeserializationBinary As System.Windows.Forms.Button
	Friend WithEvents DataValues As System.Windows.Forms.GroupBox
	Friend WithEvents txtX As System.Windows.Forms.TextBox
	Friend WithEvents lblx As System.Windows.Forms.Label
	Friend WithEvents txtY As System.Windows.Forms.TextBox
	Friend WithEvents lbly As System.Windows.Forms.Label
	Friend WithEvents txtZ As System.Windows.Forms.TextBox
	Friend WithEvents lblz As System.Windows.Forms.Label
	Friend WithEvents Label1 As System.Windows.Forms.Label
	Friend WithEvents Label2 As System.Windows.Forms.Label
	Friend WithEvents Label3 As System.Windows.Forms.Label
	Friend WithEvents Label4 As System.Windows.Forms.Label
	Friend WithEvents Label5 As System.Windows.Forms.Label
	Friend WithEvents txtYAfter As System.Windows.Forms.TextBox
	Friend WithEvents txtXAfter As System.Windows.Forms.TextBox
	Friend WithEvents txtZAfter As System.Windows.Forms.TextBox
	Friend WithEvents cmdViewClass1 As System.Windows.Forms.Button
	Friend WithEvents txtView As System.Windows.Forms.TextBox
	Friend WithEvents cmdViewClass2 As System.Windows.Forms.Button
	Friend WithEvents sbFilePath As System.Windows.Forms.StatusBar
	<System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
		Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmMain))
		Me.mnuMain = New System.Windows.Forms.MainMenu()
		Me.mnuFile = New System.Windows.Forms.MenuItem()
		Me.mnuExit = New System.Windows.Forms.MenuItem()
		Me.mnuHelp = New System.Windows.Forms.MenuItem()
		Me.mnuAbout = New System.Windows.Forms.MenuItem()
		Me.grpDefaultSerializationSoap = New System.Windows.Forms.GroupBox()
		Me.cmdStandardDeserializationSoap = New System.Windows.Forms.Button()
		Me.cmdStandardSerializationSoap = New System.Windows.Forms.Button()
		Me.grpCustomSerialization = New System.Windows.Forms.GroupBox()
		Me.cmdCustomDeserialization = New System.Windows.Forms.Button()
		Me.cmdCustomSerialization = New System.Windows.Forms.Button()
		Me.grpDefaultSerializationBinary = New System.Windows.Forms.GroupBox()
		Me.cmdStandardDeserializationBinary = New System.Windows.Forms.Button()
		Me.cmdStandardSerializationBinary = New System.Windows.Forms.Button()
		Me.DataValues = New System.Windows.Forms.GroupBox()
		Me.Label5 = New System.Windows.Forms.Label()
		Me.txtZAfter = New System.Windows.Forms.TextBox()
		Me.Label1 = New System.Windows.Forms.Label()
		Me.txtYAfter = New System.Windows.Forms.TextBox()
		Me.Label2 = New System.Windows.Forms.Label()
		Me.txtXAfter = New System.Windows.Forms.TextBox()
		Me.Label3 = New System.Windows.Forms.Label()
		Me.txtZ = New System.Windows.Forms.TextBox()
		Me.lblz = New System.Windows.Forms.Label()
		Me.txtY = New System.Windows.Forms.TextBox()
		Me.lbly = New System.Windows.Forms.Label()
		Me.txtX = New System.Windows.Forms.TextBox()
		Me.lblx = New System.Windows.Forms.Label()
		Me.Label4 = New System.Windows.Forms.Label()
		Me.cmdViewClass1 = New System.Windows.Forms.Button()
		Me.txtView = New System.Windows.Forms.TextBox()
		Me.cmdViewClass2 = New System.Windows.Forms.Button()
		Me.sbFilePath = New System.Windows.Forms.StatusBar()
		Me.grpDefaultSerializationSoap.SuspendLayout()
		Me.grpCustomSerialization.SuspendLayout()
		Me.grpDefaultSerializationBinary.SuspendLayout()
		Me.DataValues.SuspendLayout()
		Me.SuspendLayout()
		'
		'mnuMain
		'
		Me.mnuMain.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.mnuFile, Me.mnuHelp})
		'
		'mnuFile
		'
		Me.mnuFile.Index = 0
		Me.mnuFile.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.mnuExit})
		Me.mnuFile.Text = "&File"
		'
		'mnuExit
		'
		Me.mnuExit.Index = 0
		Me.mnuExit.Text = "E&xit"
		'
		'mnuHelp
		'
		Me.mnuHelp.Index = 1
		Me.mnuHelp.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.mnuAbout})
		Me.mnuHelp.Text = "&Help"
		'
		'mnuAbout
		'
		Me.mnuAbout.Index = 0
		Me.mnuAbout.Text = "Text Comes from AssemblyInfo"
		'
		'grpDefaultSerializationSoap
		'
		Me.grpDefaultSerializationSoap.AccessibleRole = System.Windows.Forms.AccessibleRole.None
		Me.grpDefaultSerializationSoap.Controls.AddRange(New System.Windows.Forms.Control() {Me.cmdStandardDeserializationSoap, Me.cmdStandardSerializationSoap})
		Me.grpDefaultSerializationSoap.Location = New System.Drawing.Point(24, 24)
		Me.grpDefaultSerializationSoap.Name = "grpDefaultSerializationSoap"
		Me.grpDefaultSerializationSoap.Size = New System.Drawing.Size(232, 96)
		Me.grpDefaultSerializationSoap.TabIndex = 0
		Me.grpDefaultSerializationSoap.TabStop = False
		Me.grpDefaultSerializationSoap.Text = "Default Serialization with &Soap Formatter"
		'
		'cmdStandardDeserializationSoap
		'
		Me.cmdStandardDeserializationSoap.Anchor = ((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
					Or System.Windows.Forms.AnchorStyles.Right)
		Me.cmdStandardDeserializationSoap.Enabled = False
		Me.cmdStandardDeserializationSoap.ImeMode = System.Windows.Forms.ImeMode.NoControl
		Me.cmdStandardDeserializationSoap.Location = New System.Drawing.Point(16, 56)
		Me.cmdStandardDeserializationSoap.Name = "cmdStandardDeserializationSoap"
		Me.cmdStandardDeserializationSoap.Size = New System.Drawing.Size(200, 23)
		Me.cmdStandardDeserializationSoap.TabIndex = 2
		Me.cmdStandardDeserializationSoap.Text = "&Deserialize Class1 Instance"
		'
		'cmdStandardSerializationSoap
		'
		Me.cmdStandardSerializationSoap.Anchor = ((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
					Or System.Windows.Forms.AnchorStyles.Right)
		Me.cmdStandardSerializationSoap.ImeMode = System.Windows.Forms.ImeMode.NoControl
		Me.cmdStandardSerializationSoap.Location = New System.Drawing.Point(16, 24)
		Me.cmdStandardSerializationSoap.Name = "cmdStandardSerializationSoap"
		Me.cmdStandardSerializationSoap.Size = New System.Drawing.Size(200, 23)
		Me.cmdStandardSerializationSoap.TabIndex = 1
		Me.cmdStandardSerializationSoap.Text = "S&erialize Class1 Instance"
		'
		'grpCustomSerialization
		'
		Me.grpCustomSerialization.AccessibleRole = System.Windows.Forms.AccessibleRole.None
		Me.grpCustomSerialization.Controls.AddRange(New System.Windows.Forms.Control() {Me.cmdCustomDeserialization, Me.cmdCustomSerialization})
		Me.grpCustomSerialization.Location = New System.Drawing.Point(264, 136)
		Me.grpCustomSerialization.Name = "grpCustomSerialization"
		Me.grpCustomSerialization.Size = New System.Drawing.Size(232, 96)
		Me.grpCustomSerialization.TabIndex = 21
		Me.grpCustomSerialization.TabStop = False
		Me.grpCustomSerialization.Text = "&Custom Serialization"
		'
		'cmdCustomDeserialization
		'
		Me.cmdCustomDeserialization.Anchor = ((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
					Or System.Windows.Forms.AnchorStyles.Right)
		Me.cmdCustomDeserialization.Enabled = False
		Me.cmdCustomDeserialization.ImeMode = System.Windows.Forms.ImeMode.NoControl
		Me.cmdCustomDeserialization.Location = New System.Drawing.Point(16, 56)
		Me.cmdCustomDeserialization.Name = "cmdCustomDeserialization"
		Me.cmdCustomDeserialization.Size = New System.Drawing.Size(200, 23)
		Me.cmdCustomDeserialization.TabIndex = 23
		Me.cmdCustomDeserialization.Text = "Deseriali&ze Class2 Instance"
		'
		'cmdCustomSerialization
		'
		Me.cmdCustomSerialization.Anchor = ((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
					Or System.Windows.Forms.AnchorStyles.Right)
		Me.cmdCustomSerialization.ImeMode = System.Windows.Forms.ImeMode.NoControl
		Me.cmdCustomSerialization.Location = New System.Drawing.Point(16, 24)
		Me.cmdCustomSerialization.Name = "cmdCustomSerialization"
		Me.cmdCustomSerialization.Size = New System.Drawing.Size(200, 23)
		Me.cmdCustomSerialization.TabIndex = 22
		Me.cmdCustomSerialization.Text = "Seria&lize Class2 Instance"
		'
		'grpDefaultSerializationBinary
		'
		Me.grpDefaultSerializationBinary.AccessibleRole = System.Windows.Forms.AccessibleRole.None
		Me.grpDefaultSerializationBinary.Controls.AddRange(New System.Windows.Forms.Control() {Me.cmdStandardDeserializationBinary, Me.cmdStandardSerializationBinary})
		Me.grpDefaultSerializationBinary.Location = New System.Drawing.Point(24, 136)
		Me.grpDefaultSerializationBinary.Name = "grpDefaultSerializationBinary"
		Me.grpDefaultSerializationBinary.Size = New System.Drawing.Size(232, 96)
		Me.grpDefaultSerializationBinary.TabIndex = 18
		Me.grpDefaultSerializationBinary.TabStop = False
		Me.grpDefaultSerializationBinary.Text = "Default Serialization with Bi&nary Formatter"
		'
		'cmdStandardDeserializationBinary
		'
		Me.cmdStandardDeserializationBinary.Anchor = ((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
					Or System.Windows.Forms.AnchorStyles.Right)
		Me.cmdStandardDeserializationBinary.Enabled = False
		Me.cmdStandardDeserializationBinary.ImeMode = System.Windows.Forms.ImeMode.NoControl
		Me.cmdStandardDeserializationBinary.Location = New System.Drawing.Point(16, 56)
		Me.cmdStandardDeserializationBinary.Name = "cmdStandardDeserializationBinary"
		Me.cmdStandardDeserializationBinary.Size = New System.Drawing.Size(200, 23)
		Me.cmdStandardDeserializationBinary.TabIndex = 20
		Me.cmdStandardDeserializationBinary.Text = "Deser&ialize Class1 Instance"
		'
		'cmdStandardSerializationBinary
		'
		Me.cmdStandardSerializationBinary.Anchor = ((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
					Or System.Windows.Forms.AnchorStyles.Right)
		Me.cmdStandardSerializationBinary.ImeMode = System.Windows.Forms.ImeMode.NoControl
		Me.cmdStandardSerializationBinary.Location = New System.Drawing.Point(16, 24)
		Me.cmdStandardSerializationBinary.Name = "cmdStandardSerializationBinary"
		Me.cmdStandardSerializationBinary.Size = New System.Drawing.Size(200, 23)
		Me.cmdStandardSerializationBinary.TabIndex = 19
		Me.cmdStandardSerializationBinary.Text = "Se&rialize Class1 Instance"
		'
		'DataValues
		'
		Me.DataValues.Controls.AddRange(New System.Windows.Forms.Control() {Me.Label5, Me.txtZAfter, Me.Label1, Me.txtYAfter, Me.Label2, Me.txtXAfter, Me.Label3, Me.txtZ, Me.lblz, Me.txtY, Me.lbly, Me.txtX, Me.lblx, Me.Label4})
		Me.DataValues.Location = New System.Drawing.Point(264, 24)
		Me.DataValues.Name = "DataValues"
		Me.DataValues.Size = New System.Drawing.Size(232, 98)
		Me.DataValues.TabIndex = 3
		Me.DataValues.TabStop = False
		Me.DataValues.Text = "Da&ta Values for Instance"
		'
		'Label5
		'
		Me.Label5.ImeMode = System.Windows.Forms.ImeMode.NoControl
		Me.Label5.Location = New System.Drawing.Point(128, 48)
		Me.Label5.Name = "Label5"
		Me.Label5.Size = New System.Drawing.Size(32, 24)
		Me.Label5.TabIndex = 11
		Me.Label5.Text = "&After"
		'
		'txtZAfter
		'
		Me.txtZAfter.Location = New System.Drawing.Point(176, 72)
		Me.txtZAfter.MaxLength = 3
		Me.txtZAfter.Name = "txtZAfter"
		Me.txtZAfter.ReadOnly = True
		Me.txtZAfter.Size = New System.Drawing.Size(40, 20)
		Me.txtZAfter.TabIndex = 17
		Me.txtZAfter.Text = ""
		'
		'Label1
		'
		Me.Label1.ImeMode = System.Windows.Forms.ImeMode.NoControl
		Me.Label1.Location = New System.Drawing.Point(160, 72)
		Me.Label1.Name = "Label1"
		Me.Label1.Size = New System.Drawing.Size(24, 16)
		Me.Label1.TabIndex = 16
		Me.Label1.Text = "z:"
		'
		'txtYAfter
		'
		Me.txtYAfter.Location = New System.Drawing.Point(176, 48)
		Me.txtYAfter.MaxLength = 3
		Me.txtYAfter.Name = "txtYAfter"
		Me.txtYAfter.ReadOnly = True
		Me.txtYAfter.Size = New System.Drawing.Size(40, 20)
		Me.txtYAfter.TabIndex = 15
		Me.txtYAfter.Text = ""
		'
		'Label2
		'
		Me.Label2.ImeMode = System.Windows.Forms.ImeMode.NoControl
		Me.Label2.Location = New System.Drawing.Point(160, 48)
		Me.Label2.Name = "Label2"
		Me.Label2.Size = New System.Drawing.Size(24, 16)
		Me.Label2.TabIndex = 14
		Me.Label2.Text = "y:"
		'
		'txtXAfter
		'
		Me.txtXAfter.Location = New System.Drawing.Point(176, 24)
		Me.txtXAfter.MaxLength = 3
		Me.txtXAfter.Name = "txtXAfter"
		Me.txtXAfter.ReadOnly = True
		Me.txtXAfter.Size = New System.Drawing.Size(40, 20)
		Me.txtXAfter.TabIndex = 13
		Me.txtXAfter.Text = ""
		'
		'Label3
		'
		Me.Label3.ImeMode = System.Windows.Forms.ImeMode.NoControl
		Me.Label3.Location = New System.Drawing.Point(160, 24)
		Me.Label3.Name = "Label3"
		Me.Label3.Size = New System.Drawing.Size(24, 16)
		Me.Label3.TabIndex = 12
		Me.Label3.Text = "x:"
		'
		'txtZ
		'
		Me.txtZ.Location = New System.Drawing.Point(67, 72)
		Me.txtZ.MaxLength = 3
		Me.txtZ.Name = "txtZ"
		Me.txtZ.Size = New System.Drawing.Size(40, 20)
		Me.txtZ.TabIndex = 10
		Me.txtZ.Text = "3"
		'
		'lblz
		'
		Me.lblz.ImeMode = System.Windows.Forms.ImeMode.NoControl
		Me.lblz.Location = New System.Drawing.Point(51, 74)
		Me.lblz.Name = "lblz"
		Me.lblz.Size = New System.Drawing.Size(24, 16)
		Me.lblz.TabIndex = 9
		Me.lblz.Text = "&z:"
		'
		'txtY
		'
		Me.txtY.Location = New System.Drawing.Point(67, 48)
		Me.txtY.MaxLength = 3
		Me.txtY.Name = "txtY"
		Me.txtY.Size = New System.Drawing.Size(40, 20)
		Me.txtY.TabIndex = 8
		Me.txtY.Text = "2"
		'
		'lbly
		'
		Me.lbly.ImeMode = System.Windows.Forms.ImeMode.NoControl
		Me.lbly.Location = New System.Drawing.Point(51, 50)
		Me.lbly.Name = "lbly"
		Me.lbly.Size = New System.Drawing.Size(24, 16)
		Me.lbly.TabIndex = 7
		Me.lbly.Text = "&y:"
		'
		'txtX
		'
		Me.txtX.Location = New System.Drawing.Point(67, 24)
		Me.txtX.MaxLength = 3
		Me.txtX.Name = "txtX"
		Me.txtX.Size = New System.Drawing.Size(40, 20)
		Me.txtX.TabIndex = 6
		Me.txtX.Text = "1"
		'
		'lblx
		'
		Me.lblx.ImeMode = System.Windows.Forms.ImeMode.NoControl
		Me.lblx.Location = New System.Drawing.Point(51, 26)
		Me.lblx.Name = "lblx"
		Me.lblx.Size = New System.Drawing.Size(24, 16)
		Me.lblx.TabIndex = 5
		Me.lblx.Text = "&x:"
		'
		'Label4
		'
		Me.Label4.ImeMode = System.Windows.Forms.ImeMode.NoControl
		Me.Label4.Location = New System.Drawing.Point(8, 48)
		Me.Label4.Name = "Label4"
		Me.Label4.Size = New System.Drawing.Size(48, 24)
		Me.Label4.TabIndex = 4
		Me.Label4.Text = "&Before"
		'
		'cmdViewClass1
		'
		Me.cmdViewClass1.Enabled = False
		Me.cmdViewClass1.ImeMode = System.Windows.Forms.ImeMode.NoControl
		Me.cmdViewClass1.Location = New System.Drawing.Point(40, 248)
		Me.cmdViewClass1.Name = "cmdViewClass1"
		Me.cmdViewClass1.Size = New System.Drawing.Size(200, 24)
		Me.cmdViewClass1.TabIndex = 24
		Me.cmdViewClass1.Text = "&View Serialized Class1 SOAP file"
		'
		'txtView
		'
		Me.txtView.Location = New System.Drawing.Point(24, 288)
		Me.txtView.Multiline = True
		Me.txtView.Name = "txtView"
		Me.txtView.ReadOnly = True
		Me.txtView.Size = New System.Drawing.Size(472, 232)
		Me.txtView.TabIndex = 26
		Me.txtView.Text = ""
		'
		'cmdViewClass2
		'
		Me.cmdViewClass2.Enabled = False
		Me.cmdViewClass2.ImeMode = System.Windows.Forms.ImeMode.NoControl
		Me.cmdViewClass2.Location = New System.Drawing.Point(280, 248)
		Me.cmdViewClass2.Name = "cmdViewClass2"
		Me.cmdViewClass2.Size = New System.Drawing.Size(200, 24)
		Me.cmdViewClass2.TabIndex = 25
		Me.cmdViewClass2.Text = "Vie&w Serialized Class2 SOAP file"
		'
		'sbFilePath
		'
		Me.sbFilePath.Location = New System.Drawing.Point(0, 531)
		Me.sbFilePath.Name = "sbFilePath"
		Me.sbFilePath.Size = New System.Drawing.Size(522, 24)
		Me.sbFilePath.TabIndex = 27
		Me.sbFilePath.Text = "File Location"
		'
		'frmMain
		'
		Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
		Me.ClientSize = New System.Drawing.Size(522, 555)
		Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.sbFilePath, Me.cmdViewClass2, Me.txtView, Me.cmdViewClass1, Me.DataValues, Me.grpDefaultSerializationBinary, Me.grpDefaultSerializationSoap, Me.grpCustomSerialization})
		Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
		Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
		Me.MaximizeBox = False
		Me.Menu = Me.mnuMain
		Me.Name = "frmMain"
		Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
		Me.Text = "Title Comes from Assembly Info"
		Me.grpDefaultSerializationSoap.ResumeLayout(False)
		Me.grpCustomSerialization.ResumeLayout(False)
		Me.grpDefaultSerializationBinary.ResumeLayout(False)
		Me.DataValues.ResumeLayout(False)
		Me.ResumeLayout(False)

	End Sub

#End Region

#Region " Standard Menu Code "
	' <System.Diagnostics.DebuggerStepThrough()> has been added to some procedures since they are
	' not the focus of the demo. Remove them if you wish to debug the procedures.
	' This code simply shows the About form.
	<System.Diagnostics.DebuggerStepThrough()> Private Sub mnuAbout_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuAbout.Click
		' Open the About form in Dialog Mode
		Dim frm As New frmAbout()
		frm.ShowDialog(Me)
		frm.Dispose()
	End Sub

	' This code will close the form.
	<System.Diagnostics.DebuggerStepThrough()> Private Sub mnuExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuExit.Click
		' Close the current form
		Me.Close()
	End Sub
#End Region

	Private Sub cmdStandardSerializationSoap_Click(ByVal sender As System.Object, _
				 ByVal e As System.EventArgs) _
				 Handles cmdStandardSerializationSoap.Click
		'This routine creates a new instance of Class1, then serializes it to
		'the file Class1File.xml with the SOAP Formatter.

		'Create the object to be serialized
		Dim c As New Class1(CInt(txtX.Text), CInt(txtY.Text), CInt(txtZ.Text))

		'Get a filestream that writes to the file specified by strFileName1
		Dim fs As New FileStream(strFileName1, FileMode.OpenOrCreate)

		'Get a SOAP Formatter instance
		Dim sf As New SoapFormatter()

		'Serialize c to strFileName1
		sf.Serialize(fs, c)

		'Close the file and release resources (avoids GC delays)
		fs.Close()

		'Deserialization is now available
		cmdStandardDeserializationSoap.Enabled = True
		cmdViewClass1.Enabled = True

	End Sub

	Private Sub cmdStandardDeserializationSoap_Click(ByVal sender As System.Object, _
			   ByVal e As System.EventArgs) _
			   Handles cmdStandardDeserializationSoap.Click
		'This routine deserializes an object from the file Class1File.xml
		'and assigns it to a Class1 reference.

		'Declare the reference that will point to the object to be deserialized
		Dim c As Class1

		'Get a filestream that reads from strFileName1
		Dim fs As New FileStream(strFileName1, FileMode.Open)

		'Get a SOAP Formatter instance
		Dim sf As New SoapFormatter()

		'Deserialize c from strFileName1
		'Note that the deserialized object must be cast to the proper type.
		c = CType(sf.Deserialize(fs), Class1)

		'close the file and release resources (avoids GC delays)
		fs.Close()

		'Put the deserialized values for the fields into the textboxes
		txtXAfter.Text = CStr(c.x)
		txtYAfter.Text = CStr(c.GetY)
		txtZAfter.Text = CStr(c.z)

		'Reset buttons after deserializing
		cmdStandardDeserializationSoap.Enabled = False
		cmdViewClass1.Enabled = False

	End Sub

	Private Sub cmdStandardSerializationBinary_Click(ByVal sender As System.Object, _
			   ByVal e As System.EventArgs) _
			   Handles cmdStandardSerializationBinary.Click
		'This routine creates a new instance of Class1, then serializes it to 
		'the file Class1File.dat using the Binary formatter.

		'Create the object to be serialized
		Dim c As New Class1(CInt(txtX.Text), CInt(txtY.Text), CInt(txtZ.Text))

		'Get a filestream that writes to strFilename2
		Dim fs As New FileStream(strFileName2, FileMode.OpenOrCreate)

		'Get a Binary Formatter instance
		Dim bf As New BinaryFormatter()

		'Serialize c to strFileName2
		bf.Serialize(fs, c)

		'Close the file and release resources (avoids GC delays)
		fs.Close()

		'Deserialization is now available
		cmdStandardDeserializationBinary.Enabled = True

	End Sub

	Private Sub cmdStandardDeserializationBinary_Click(ByVal sender As System.Object, _
			  ByVal e As System.EventArgs) _
			  Handles cmdStandardDeserializationBinary.Click
		'This routine deserializes an object from the file Class1File.dat
		'and assigns it to a Class1 reference.

		'Declare the reference that will point to the object to be deserialized
		Dim c As Class1

		'Get a filestream that reads from strFilename2
		Dim fs As New FileStream(strFileName2, FileMode.Open)

		'Get a Binary Formatter instance
		Dim bf As New BinaryFormatter()

		'Deserialize c from strFilename2
		'Note that the deserialized object must be cast to the proper type.
		c = CType(bf.Deserialize(fs), Class1)

		'Close the file and release resources (avoids GC delays)
		fs.Close()

		'Put the deserialized values for the fields into the textboxes
		txtXAfter.Text = CStr(c.x)
		txtYAfter.Text = CStr(c.GetY)
		txtZAfter.Text = CStr(c.z)

		'Reset button after deserializing
		cmdStandardDeserializationBinary.Enabled = False

	End Sub

	Private Sub cmdCustomSerialization_Click(ByVal sender As System.Object, _
			  ByVal e As System.EventArgs) _
			  Handles cmdCustomSerialization.Click
		'This routine creates a new instance of Class1, then serializes it to
		'the file Class2File.xml with the SOAP Formatter. Note that even though
		'class2 has custom serialization, the client code is identical to that
		'of standard serialization. The difference is in the class code, not the
		'client code.

		'Create the object to be serialized
		Dim c As New Class2(CInt(txtX.Text), CInt(txtY.Text), CInt(txtZ.Text))

		'Get a filestream that writes to strFileName3
		Dim fs As New FileStream(strFileName3, FileMode.OpenOrCreate)

		'Get a SOAP Formatter instance
		Dim sf As New SoapFormatter()

		'Serialize c to strFileName3
		sf.Serialize(fs, c)

		'Close the file and release resources (avoids GC delays)
		fs.Close()

		'Deserialization is now available
		cmdCustomDeserialization.Enabled = True
		cmdViewClass2.Enabled = True

	End Sub

	Private Sub cmdCustomDeserialization_Click(ByVal sender As System.Object, _
			  ByVal e As System.EventArgs) _
			  Handles cmdCustomDeserialization.Click
		'This routine deserializes an object from the file Class2File.xml
		'and assigns it to a Class2 reference. Note that even though
		'class2 has custom serialization, the client code is identical to that
		'of standard serialization. The difference is in the class code, not the
		'client code.

		'Declare the reference that will point to the object to be deserialized
		Dim c As Class2

		'Get a filestream that reads from strFileName3
		Dim fs As New FileStream(strFileName3, FileMode.Open)

		'Get a SOAP Formatter instance
		Dim sf As New SoapFormatter()

		'Deserialize c from strFileName3
		'Note that the deserialized object must be cast to the proper type.
		c = CType(sf.Deserialize(fs), Class2)

		'close the file and release resources (avoids GC delays)
		fs.Close()

		'Put the deserialized values for the fields into the textboxes
		txtXAfter.Text = CStr(c.x)
		txtYAfter.Text = CStr(c.GetY)
		txtZAfter.Text = CStr(c.z)

		'Reset button after deserializing
		cmdCustomDeserialization.Enabled = False
		cmdViewClass2.Enabled = False

	End Sub

	Private Sub cmdViewClass1_Click(ByVal sender As System.Object, _
			ByVal e As System.EventArgs) _
			Handles cmdViewClass1.Click
		'Dump the file contents into a textbox. This routine quickly copies the file
		'contents into a read-only textbox. It merely let's the user examine the 
		'serialized object state of Class1.

		Dim fs As New FileStream(strFileName1, FileMode.Open)
		Dim sr As New StreamReader(fs)
		txtView.Text = sr.ReadToEnd()
		sr.Close()
		fs.Close()

	End Sub

	Private Sub cmdViewClass2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdViewClass2.Click
		'Dump the file contents into a textbox. This routine quickly copies the file
		'contents into a read-only textbox. It merely let's the user examine the 
		'serialized object state of Class2.

		Dim fs As New FileStream(strFileName3, FileMode.Open)
		Dim sr As New StreamReader(fs)
		txtView.Text = sr.ReadToEnd()
		sr.Close()
		fs.Close()

	End Sub

	Private Sub frmMain_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
		' Get the system temp path using the Path class
		' in the System.Io namespace
		Dim strTempPath As String = Path.GetTempPath()

		strFileName1 = strTempPath & "Class1File.xml"
		strFileName2 = strTempPath & "Class1File.dat"
		strFileName3 = strTempPath & "Class2File.xml"

		Me.sbFilePath.Text = "All files will be written to " & strTempPath
	End Sub

	Private Function IsValidInt32(ByVal Data As String) As Boolean
		' This is an alternative to VB function IsNumeric 
		' that works for Int32 data only.
		' Other languages, like C# do not have IsNumeric.
		Try
			Dim i As Integer
			i = System.Convert.ToInt32(Data)
			Return True

		Catch exp As FormatException
			' The conversion failed.
			Return False

		Catch exp As Exception
			' Just in case some other wierd error occurs.
			Return False
		End Try
	End Function

	Private Sub ValidatingTextIsInt32(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtX.Validating, txtY.Validating, txtZ.Validating
		' Makre sure the value entered can be converted to an Int32 (Integer)
		Dim txt As TextBox = CType(sender, TextBox)

		If Not IsValidInt32(txt.Text) Then
			Dim strMsg As String
			strMsg = String.Format("The value you entered {0} is not a valid 32-bit integer. Value will be changed to zero.", txt.Text)
			MsgBox(strMsg, MsgBoxStyle.Exclamation, "Validation Warning")
			txt.Text = "0"
		End If
	End Sub
End Class