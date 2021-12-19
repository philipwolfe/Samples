''------------------------------------------------------------------------------
''/ <copyright from='1997' to='2001' company='Microsoft Corporation'>           
''/    Copyright (c) Microsoft Corporation. All Rights Reserved.                
''/       
''/    Source code is intended only as a suppleMent to Microsoft
''/    DevelopMent Tools and/or on-line docuMentation.  See these other
''/    materials for detailed information regarding Microsoft code samples.
''/
''/ </copyright>                                                                
''------------------------------------------------------------------------------
Imports System
Imports System.ComponentModel
Imports System.Drawing
Imports System.Windows.Forms


Namespace Microsoft.Samples.Windows.Forms.VB.DockMan

    Public Class DockMan
        Inherits System.Windows.Forms.Form

        'ButtonSet keeps track of which radio button is checked
        Private ButtonSet As System.Windows.Forms.RadioButton

        Public Sub New()

            MyBase.New()

            DockMan = Me

            'This call is required by the Win Form Designer.
            InitializeComponent()

            'TODO: Add any initialization after the InitializeComponent() call

            'Wire up event handlers
            AddHandler rdbRight.Click, New EventHandler(AddressOf Me.radiobutton_Click)
            AddHandler rdbFill.Click, New EventHandler(AddressOf Me.radiobutton_Click)
            AddHandler rdbBottom.Click, New EventHandler(AddressOf Me.radiobutton_Click)
            AddHandler rdbNone.Click, New EventHandler(AddressOf Me.radiobutton_Click)
            AddHandler rdbLeft.Click, New EventHandler(AddressOf Me.radiobutton_Click)
            AddHandler rdbTop.Click, New EventHandler(AddressOf Me.radiobutton_Click)
            AddHandler chkTop.Click, New EventHandler(AddressOf Me.checkbox_Click)
            AddHandler chkLeft.Click, New EventHandler(AddressOf Me.checkbox_Click)
            AddHandler chkRight.Click, New EventHandler(AddressOf Me.checkbox_Click)
            AddHandler Me.Click, New EventHandler(AddressOf Me.checkbox_Click)

            ' Complete intialization of the form
            ButtonSet = rdbNone
            ApplyChanges()

        End Sub

        'Form overrides dispose to clean up the component list.
        Public Overloads Overrides Sub Dispose()
            MyBase.Dispose()
            components.Dispose()
        End Sub

        'The main entry point for the application        
        <STAThread()> Shared Sub Main()
            System.Windows.Forms.Application.Run(New DockMan())
        End Sub

        Private Sub ApplyChanges()

            'Apply Anchoring Settings - maybe multiple
            Dim Settings As AnchorStyles
            Settings = AnchorStyles.None

            If chkTop.Checked Then
                Settings = Settings Or AnchorStyles.Top
            End If

            If chkLeft.Checked Then
                Settings = Settings Or AnchorStyles.Left
            End If

            If chkBottom.Checked Then
                Settings = Settings Or AnchorStyles.Bottom
            End If

            If chkRight.Checked Then
                Settings = Settings Or AnchorStyles.Right
            End If

            btnDemo.Anchor = Settings

            'Apply Docking settings - one only
            If ButtonSet Is rdbNone Then
                btnDemo.Dock = System.Windows.Forms.DockStyle.None
            ElseIf ButtonSet Is rdbTop Then
                btnDemo.Dock = System.Windows.Forms.DockStyle.Top
            ElseIf ButtonSet Is rdbLeft Then
                btnDemo.Dock = System.Windows.Forms.DockStyle.Left
            ElseIf ButtonSet Is rdbBottom Then
                btnDemo.Dock = System.Windows.Forms.DockStyle.Bottom
            ElseIf ButtonSet Is rdbRight Then
                btnDemo.Dock = System.Windows.Forms.DockStyle.Right
            Else ' The default is: if (ButtonSet is rbFill)
                btnDemo.Dock = System.Windows.Forms.DockStyle.Fill
            End If

        End Sub
        Private components As System.ComponentModel.IContainer

#Region " Windows Form Designer generated code "

        'Required by the Windows Form Designer
        Private WithEvents panel1 As System.Windows.Forms.Panel
        Private WithEvents panel2 As System.Windows.Forms.Panel
        Private WithEvents groupBox1 As System.Windows.Forms.GroupBox
        Private WithEvents groupBox2 As System.Windows.Forms.GroupBox
        Private toolTip1 As System.Windows.Forms.ToolTip
        Private WithEvents btnDemo As System.Windows.Forms.Button
        Private WithEvents rdbNone As System.Windows.Forms.RadioButton
        Private WithEvents rdbTop As System.Windows.Forms.RadioButton
        Private WithEvents rdbLeft As System.Windows.Forms.RadioButton
        Private WithEvents rdbBottom As System.Windows.Forms.RadioButton
        Private WithEvents rdbRight As System.Windows.Forms.RadioButton
        Private WithEvents rdbFill As System.Windows.Forms.RadioButton
        Private WithEvents chkTop As System.Windows.Forms.CheckBox
        Private WithEvents chkLeft As System.Windows.Forms.CheckBox
        Private WithEvents chkBottom As System.Windows.Forms.CheckBox
        Private WithEvents chkRight As System.Windows.Forms.CheckBox

        Private WithEvents DockMan As System.Windows.Forms.Form

        'NOTE: The following procedure is required by the Windows Form Designer        
        Private Sub InitializeComponent()
            Me.components = New System.ComponentModel.Container()
            Me.chkLeft = New System.Windows.Forms.CheckBox()
            Me.rdbLeft = New System.Windows.Forms.RadioButton()
            Me.chkTop = New System.Windows.Forms.CheckBox()
            Me.panel1 = New System.Windows.Forms.Panel()
            Me.panel2 = New System.Windows.Forms.Panel()
            Me.rdbTop = New System.Windows.Forms.RadioButton()
            Me.chkRight = New System.Windows.Forms.CheckBox()
            Me.chkBottom = New System.Windows.Forms.CheckBox()
            Me.rdbNone = New System.Windows.Forms.RadioButton()
            Me.ButtonSet = New System.Windows.Forms.RadioButton()
            Me.rdbRight = New System.Windows.Forms.RadioButton()
            Me.groupBox1 = New System.Windows.Forms.GroupBox()
            Me.groupBox2 = New System.Windows.Forms.GroupBox()
            Me.toolTip1 = New System.Windows.Forms.ToolTip(Me.components)
            Me.rdbBottom = New System.Windows.Forms.RadioButton()
            Me.btnDemo = New System.Windows.Forms.Button()
            Me.rdbFill = New System.Windows.Forms.RadioButton()
            Me.chkLeft.Location = New System.Drawing.Point(8, 48)
            Me.chkLeft.Size = New System.Drawing.Size(72, 24)
            Me.chkLeft.TabIndex = 2
            Me.chkLeft.Text = "&Left"
            Me.rdbLeft.Location = New System.Drawing.Point(8, 72)
            Me.rdbLeft.Size = New System.Drawing.Size(72, 24)
            Me.rdbLeft.TabIndex = 3
            Me.rdbLeft.Text = "&Left"
            Me.chkTop.Location = New System.Drawing.Point(8, 24)
            Me.chkTop.Size = New System.Drawing.Size(72, 24)
            Me.chkTop.TabIndex = 0
            Me.chkTop.Text = "&Top"
            Me.panel1.BackColor = System.Drawing.Color.Green
            Me.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
            Me.panel1.Controls.AddRange(New System.Windows.Forms.Control() {Me.btnDemo})
            Me.panel1.Dock = System.Windows.Forms.DockStyle.Fill
            Me.panel1.Size = New System.Drawing.Size(448, 400)
            Me.panel1.TabIndex = 1
            Me.panel1.Text = "ButtonPanel"
            Me.panel2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
            Me.panel2.Controls.AddRange(New System.Windows.Forms.Control() {Me.groupBox1, Me.groupBox2})
            Me.panel2.Dock = System.Windows.Forms.DockStyle.Right
            Me.panel2.Location = New System.Drawing.Point(328, 0)
            Me.panel2.Size = New System.Drawing.Size(120, 400)
            Me.panel2.TabIndex = 0
            Me.panel2.Text = "ControlsPanel"
            Me.toolTip1.SetToolTip(Me.panel2, "Resize the form to see the layout effects.")
            Me.rdbTop.Location = New System.Drawing.Point(8, 48)
            Me.rdbTop.Size = New System.Drawing.Size(72, 24)
            Me.rdbTop.TabIndex = 0
            Me.rdbTop.Text = "&Top"
            Me.chkRight.Location = New System.Drawing.Point(8, 96)
            Me.chkRight.Size = New System.Drawing.Size(72, 24)
            Me.chkRight.TabIndex = 1
            Me.chkRight.Text = "&Right"
            Me.chkBottom.Location = New System.Drawing.Point(8, 72)
            Me.chkBottom.Size = New System.Drawing.Size(72, 24)
            Me.chkBottom.TabIndex = 3
            Me.chkBottom.Text = "&Bottom"
            Me.rdbNone.Checked = True
            Me.rdbNone.Location = New System.Drawing.Point(8, 24)
            Me.rdbNone.Size = New System.Drawing.Size(72, 24)
            Me.rdbNone.TabIndex = 5
            Me.rdbNone.TabStop = True
            Me.rdbNone.Text = "&None"
            Me.ButtonSet.Size = New System.Drawing.Size(100, 23)
            Me.ButtonSet.TabIndex = 0
            Me.ButtonSet.Text = "rdbSet"
            Me.rdbRight.Location = New System.Drawing.Point(8, 120)
            Me.rdbRight.Size = New System.Drawing.Size(72, 24)
            Me.rdbRight.TabIndex = 4
            Me.rdbRight.Text = "&Right"
            Me.groupBox1.Controls.AddRange(New System.Windows.Forms.Control() {Me.chkRight, Me.chkBottom, Me.chkLeft, Me.chkTop})
            Me.groupBox1.Location = New System.Drawing.Point(16, 16)
            Me.groupBox1.Size = New System.Drawing.Size(88, 128)
            Me.groupBox1.TabIndex = 0
            Me.groupBox1.TabStop = False
            Me.groupBox1.Text = "A&nchor"
            Me.groupBox2.Controls.AddRange(New System.Windows.Forms.Control() {Me.rdbBottom, Me.rdbLeft, Me.rdbNone, Me.rdbRight, Me.rdbFill, Me.rdbTop})
            Me.groupBox2.Location = New System.Drawing.Point(16, 152)
            Me.groupBox2.Size = New System.Drawing.Size(88, 176)
            Me.groupBox2.TabIndex = 1
            Me.groupBox2.TabStop = False
            Me.groupBox2.Text = "&Dock"
            Me.rdbBottom.Location = New System.Drawing.Point(8, 96)
            Me.rdbBottom.Size = New System.Drawing.Size(72, 24)
            Me.rdbBottom.TabIndex = 1
            Me.rdbBottom.Text = "&Bottom"
            Me.btnDemo.Anchor = System.Windows.Forms.AnchorStyles.None
            Me.btnDemo.BackColor = System.Drawing.SystemColors.Control
            Me.btnDemo.FlatStyle = System.Windows.Forms.FlatStyle.Popup
            Me.btnDemo.Location = New System.Drawing.Point(64, 72)
            Me.btnDemo.Size = New System.Drawing.Size(120, 24)
            Me.btnDemo.TabIndex = 0
            Me.btnDemo.Text = "Demo Button"
            Me.toolTip1.SetToolTip(Me.btnDemo, "Nothing happens if you click Me button.")
            Me.rdbFill.Location = New System.Drawing.Point(8, 144)
            Me.rdbFill.Size = New System.Drawing.Size(72, 24)
            Me.rdbFill.TabIndex = 2
            Me.rdbFill.Text = "&Fill"
            Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
            Me.ClientSize = New System.Drawing.Size(448, 400)
            Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.panel2, Me.panel1})
            Me.Location = New System.Drawing.Point(100, 100)
            Me.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show
            Me.Text = "Docking and Anchoring Example"

        End Sub

#End Region

        'Whenever a checkbox is clicked, apply the changes from all
        'controls.  Note all checkboxes use Me saMe handler.
        Private Sub checkbox_Click(ByVal sender As Object, ByVal e As EventArgs)
            ApplyChanges()
        End Sub

        'Save the radio button that was clicked so we know which one is
        'checked when we apply the changes.  Note, all radio buttons use
        'Me saMe click handler.
        Private Sub radiobutton_Click(ByVal sender As Object, ByVal e As EventArgs)
            ButtonSet = CType(sender, RadioButton)
            ApplyChanges()
        End Sub

    End Class

End Namespace





