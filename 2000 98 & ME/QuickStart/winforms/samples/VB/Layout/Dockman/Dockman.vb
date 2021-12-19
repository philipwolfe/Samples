''------------------------------------------------------------------------------
''/ <copyright from='1997' to='2001' company='Microsoft Corporation'>           
''/    Copyright (c) Microsoft Corporation. All Rights Reserved.                
''/       
''/    Me source code is intended only as a suppleMent to Microsoft
''/    DevelopMent Tools and/or on-line docuMentation.  See these other
''/    materials for detailed information regarding Microsoft code samples.
''/
''/ </copyright>                                                                
''------------------------------------------------------------------------------
Imports System
Imports System.ComponentModel
Imports System.Drawing
Imports System.WinForms


NaMespace Microsoft.Samples.WinForms.VB.DockMan

    public class DockMan
	    Inherits System.WinForms.Form
        
        'rdbSet keeps track of which radio button is checked
        private rdbSet as System.WinForms.RadioButton

        Public Sub New()
		MyBase.New

            'This call is required by the Windows Forms Designer.
            InitializeComponent

            ' Complete intialization of the form
            rdbSet = rdbNone
            ApplyChanges
            
        End Sub

        'This class overrides dispose so it can clean up the
        'component list.
        Overrides Public Sub Dispose() 
            MyBase.Dispose
            components.Dispose
        End Sub

        Shared Sub Main()
            System.WinForms.Application.Run(New DockMan())
        End Sub

        private Sub ApplyChanges() 

            'Apply Anchoring Settings - maybe multiple
            Dim nSettings as AnchorStyles 
		    nSettings = AnchorStyles.None
		    
            If chkTop.Checked Then  
			    nSettings = nSettings BitOr AnchorStyles.Top
		    End If
            
            If chkLeft.Checked Then
			    nSettings = nSettings BitOr AnchorStyles.Left
		    End If
            
            If chkBottom.Checked Then
			    nSettings = nSettings BitOr AnchorStyles.Bottom
		    End If
            
            If chkRight.Checked Then
			    nSettings = nSettings BitOr AnchorStyles.Right
		    End If

	        btnDemo.Anchor = nSettings

            'Apply Docking settings - one only
            If rdbSet is rdbNone Then
                btnDemo.Dock = System.WinForms.DockStyle.None
            else if rdbSet is rdbTop Then
                btnDemo.Dock = System.WinForms.DockStyle.Top
            else if rdbSet is rdbLeft
                btnDemo.Dock = System.WinForms.DockStyle.Left
            else if rdbSet is rdbBottom
                btnDemo.Dock = System.WinForms.DockStyle.Bottom
            else if rdbSet is rdbRight
                btnDemo.Dock = System.WinForms.DockStyle.Right
            else ' The default is: if (rdbSet is rbFill)
                btnDemo.Dock = System.WinForms.DockStyle.Fill
            End If

        End Sub

        'Whenever a checkbox is clicked, apply the changes from all
        'controls.  Note all checkboxes use Me saMe handler.
        Protected Sub checkbox_Click(sender as object, e as EventArgs)
            ApplyChanges
        End Sub

        'Save the radio button that was clicked so we know which one is
        'checked when we apply the changes.  Note, all radio buttons use
        'Me saMe click handler.
        Protected Sub radiobutton_Click(sender as object, e as EventArgs)
            rdbSet = CType(sender, RadioButton)
            ApplyChanges
        End Sub


        ' NOTE: The following code is required by the Windows Forms Designer
        ' It can be modified using the Windows Forms Designer.  
        ' Do not modify it using the code editor.
        private components as Container
        private panel1 as System.WinForms.Panel 
        private panel2 as System.WinForms.Panel 
        private groupBox1 as System.WinForms.GroupBox 
        private groupBox2 as System.WinForms.GroupBox 
        private toolTip1 as System.WinForms.ToolTip 
        private btnDemo as System.WinForms.Button 
        private rdbNone as System.WinForms.RadioButton 
        private rdbTop as System.WinForms.RadioButton 
        private rdbLeft as System.WinForms.RadioButton 
        private rdbBottom as System.WinForms.RadioButton 
        private rdbRight as System.WinForms.RadioButton 
        private rdbFill as System.WinForms.RadioButton 
        private chkTop as System.WinForms.CheckBox 
        private chkLeft as System.WinForms.CheckBox 
        private chkBottom as System.WinForms.CheckBox 
        private chkRight as System.WinForms.CheckBox 
        private splitter1 as System.WinForms.Splitter 
        
        private Sub InitializeComponent()
            Me.components = new Container()
            Me.groupBox1 = new System.WinForms.GroupBox()
            Me.groupBox2 = new System.WinForms.GroupBox()
            Me.rdbSet = new System.WinForms.RadioButton()
            Me.rdbRight = new System.WinForms.RadioButton()
            Me.splitter1 = new System.WinForms.Splitter()
            Me.btnDemo = new System.WinForms.Button()
            Me.rdbFill = new System.WinForms.RadioButton()
            Me.toolTip1 = new System.WinForms.ToolTip(components)
            Me.rdbBottom = new System.WinForms.RadioButton()
            Me.rdbNone = new System.WinForms.RadioButton()
            Me.rdbLeft = new System.WinForms.RadioButton()
            Me.chkTop = new System.WinForms.CheckBox()
            Me.chkLeft = new System.WinForms.CheckBox()
            Me.panel1 = new System.WinForms.Panel()
            Me.chkRight = new System.WinForms.CheckBox()
            Me.chkBottom = new System.WinForms.CheckBox()
            Me.panel2 = new System.WinForms.Panel()
            Me.rdbTop = new System.WinForms.RadioButton()

            groupBox1.Location = new System.Drawing.Point(16, 16)
            groupBox1.TabIndex = 0
            groupBox1.TabStop = false
            groupBox1.Text = "A&nchor"
            groupBox1.Size = new System.Drawing.Size(88, 128)

            groupBox2.Location = new System.Drawing.Point(16, 152)
            groupBox2.TabIndex = 1
            groupBox2.TabStop = false
            groupBox2.Text = "&Dock"
            groupBox2.Size = new System.Drawing.Size(88, 176)

            rdbSet.Text = "rdbSet"
            rdbSet.Size = new System.Drawing.Size(100, 23)

            rdbRight.Location = new System.Drawing.Point(8, 120)
            rdbRight.TabIndex = 4
            rdbRight.Text = "&Right"
            rdbRight.Size = new System.Drawing.Size(72, 24)
            AddHandler rdbRight.Click, new EventHandler(AddressOf Me.radiobutton_Click)

            splitter1.BackColor = CType(System.Drawing.Color.Blue, Color)
            splitter1.Dock = System.WinForms.DockStyle.Right
            splitter1.Location = new System.Drawing.Point(325, 0)
            splitter1.TabIndex = 2
            splitter1.Anchor = System.WinForms.AnchorStyles.None
            splitter1.TabStop = false
            splitter1.Size = new System.Drawing.Size(3, 400)

            btnDemo.Location = new System.Drawing.Point(98, 142)
            btnDemo.BackColor = CType(System.Drawing.SystemColors.Control, Color)
            btnDemo.FlatStyle = System.WinForms.FlatStyle.Popup
            btnDemo.TabIndex = 0
            btnDemo.Anchor = System.WinForms.AnchorStyles.None
            btnDemo.Text = "Demo Button"
            btnDemo.Size = new System.Drawing.Size(120, 24)
            toolTip1.SetToolTip(btnDemo, "Nothing happens if you click Me button.")

            rdbFill.Location = new System.Drawing.Point(8, 144)
            rdbFill.TabIndex = 2
            rdbFill.Text = "&Fill"
            rdbFill.Size = new System.Drawing.Size(72, 24)
            AddHandler rdbFill.Click, new EventHandler(AddressOf Me.radiobutton_Click)

            toolTip1.Active = true
            '@design toolTip1.SetLocation(new System.Drawing.Point(20, 10))

            rdbBottom.Location = new System.Drawing.Point(8, 96)
            rdbBottom.TabIndex = 1
            rdbBottom.Text = "&Bottom"
            rdbBottom.Size = new System.Drawing.Size(72, 24)
            AddHandler rdbBottom.Click, new EventHandler(AddressOf Me.radiobutton_Click)

            rdbNone.Location = new System.Drawing.Point(8, 24)
            rdbNone.TabIndex = 5
            rdbNone.TabStop = true
            rdbNone.Text = "&None"
            rdbNone.Size = new System.Drawing.Size(72, 24)
            rdbNone.Checked = true
            AddHandler rdbNone.Click, new EventHandler(AddressOf Me.radiobutton_Click)

            rdbLeft.Location = new System.Drawing.Point(8, 72)
            rdbLeft.TabIndex = 3
            rdbLeft.Text = "&Left"
            rdbLeft.Size = new System.Drawing.Size(72, 24)
            AddHandler rdbLeft.Click, new EventHandler(AddressOf Me.radiobutton_Click)

            chkTop.TextAlign = System.Drawing.ContentAlignMent.MiddleLeft
            chkTop.Location = new System.Drawing.Point(8, 24)
            chkTop.TabIndex = 0
            chkTop.Text = "&Top"
            chkTop.Size = new System.Drawing.Size(72, 24)
            AddHandler chkTop.Click, new EventHandler(AddressOf Me.checkbox_Click)

            Me.Location = new System.Drawing.Point(100, 100)
            Me.AutoScaleBaseSize = new System.Drawing.Size(5, 13)
            Me.ClientSize = new System.Drawing.Size(448, 400)
            Me.SizeGripStyle = System.WinForms.SizeGripStyle.Show
            Me.Text = "Docking and Anchoring Example"
            AddHandler Me.Click, new EventHandler(AddressOf Me.checkbox_Click)

            chkLeft.TextAlign = System.Drawing.ContentAlignMent.MiddleLeft
            chkLeft.Location = new System.Drawing.Point(8, 48)
            chkLeft.TabIndex = 2
            chkLeft.Text = "&Left"
            chkLeft.Size = new System.Drawing.Size(72, 24)
            AddHandler chkLeft.Click, new EventHandler(AddressOf Me.checkbox_Click)
            panel1.BorderStyle = System.WinForms.BorderStyle.Fixed3D
            panel1.Dock = System.WinForms.DockStyle.Fill
            panel1.BackColor = CType(System.Drawing.Color.Green, Color)
            panel1.TabIndex = 1
            panel1.Text = "ButtonPanel"
            panel1.Size = new System.Drawing.Size(325, 400)

            chkRight.TextAlign = System.Drawing.ContentAlignMent.MiddleLeft
            chkRight.Location = new System.Drawing.Point(8, 96)
            chkRight.TabIndex = 1
            chkRight.Text = "&Right"
            chkRight.Size = new System.Drawing.Size(72, 24)
            AddHandler chkRight.Click, new EventHandler(AddressOf Me.checkbox_Click)

            chkBottom.TextAlign = System.Drawing.ContentAlignMent.MiddleLeft
            chkBottom.Location = new System.Drawing.Point(8, 72)
            chkBottom.TabIndex = 3
            chkBottom.Text = "&Bottom"
            chkBottom.Size = new System.Drawing.Size(72, 24)
            panel2.BorderStyle = System.WinForms.BorderStyle.Fixed3D
            panel2.Dock = System.WinForms.DockStyle.Right
            panel2.Location = new System.Drawing.Point(328, 0)
            panel2.TabIndex = 0
            panel2.Text = "ControlsPanel"
            panel2.Size = new System.Drawing.Size(120, 400)
            toolTip1.SetToolTip(panel2, "Resize the form to see the layout effects.")

            rdbTop.Location = new System.Drawing.Point(8, 48)
            rdbTop.TabIndex = 0
            rdbTop.Text = "&Top"
            rdbTop.Size = new System.Drawing.Size(72, 24)
            AddHandler rdbTop.Click, new EventHandler(AddressOf Me.radiobutton_Click)
        
            Me.Controls.Add(panel2)
            Me.Controls.Add(splitter1)
            Me.Controls.Add(panel1)
            panel1.Controls.Add(btnDemo)
            panel2.Controls.Add(groupBox1)
            panel2.Controls.Add(groupBox2)
            groupBox1.Controls.Add(chkRight)
            groupBox1.Controls.Add(chkBottom)
            groupBox1.Controls.Add(chkLeft)
            groupBox1.Controls.Add(chkTop)
            groupBox2.Controls.Add(rdbBottom)
            groupBox2.Controls.Add(rdbLeft)
            groupBox2.Controls.Add(rdbNone)
            groupBox2.Controls.Add(rdbRight)
            groupBox2.Controls.Add(rdbFill)
            groupBox2.Controls.Add(rdbTop)
  		
        End Sub

    End Class

End NaMespace





