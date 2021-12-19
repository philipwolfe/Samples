'------------------------------------------------------------------------------
' <copyright from='1997' to='2001' company='Microsoft Corporation'>           
'    Copyright (c) Microsoft Corporation. All Rights Reserved.                
'       
'    This source code is intended only as a supplement to Microsoft
'    Development Tools and/or on-line documentation.  See these other
'    materials for detailed information regarding Microsoft code samples.
'
' </copyright>                                                                
'------------------------------------------------------------------------------

Imports System
Imports System.ComponentModel
Imports System.Core
Imports System.Drawing
Imports System.WinForms
Imports System.Diagnostics

Imports Microsoft.VisualBasic.ControlChars

Option Explicit
Option Strict Off

namespace Microsoft.Samples.WinForms.Vb.ToolTipCtl 

    public class ToolTipCtl : inherits System.WinForms.Form 
        protected toolTips() As string = { "Open", "New", "Save", "Cut", "Copy", "Paste" }
        protected picts() As PictureBox = Nothing

        public sub New()
            MyBase.New() 
            InitializeComponent()

            ReDim picts(6)
            picts(0) = pictureBox1
            picts(1) = pictureBox2
            picts(2) = pictureBox3
            picts(3) = pictureBox4
            picts(4) = pictureBox5
            picts(5) = pictureBox6

            ' Initialize all property ComboBox selections
            cmbAutomaticDelay.SelectedIndex = 1
            cmbAutoPopDelay.SelectedIndex = 1
            cmbInitialDelay.SelectedIndex = 1
            cmbReshowDelay.SelectedIndex = 1

            'BUG BUG: 31070
            'imageList1.Images.Add((Bitmap)resources.GetObject("open"))
            'imageList1.Images.Add((Bitmap)resources.GetObject("newbmp"))
            'imageList1.Images.Add((Bitmap)resources.GetObject("save"))
            'imageList1.Images.Add((Bitmap)resources.GetObject("cut"))
            'imageList1.Images.Add((Bitmap)resources.GetObject("copy"))
            'imageList1.Images.Add((Bitmap)resources.GetObject("paste"))

       	    imageList1.Images.Add(System.Drawing.Image.FromFile("open.bmp"))
       	    imageList1.Images.Add(System.Drawing.Image.FromFile("new.bmp"))
       	    imageList1.Images.Add(System.Drawing.Image.FromFile("save.bmp"))
       	    imageList1.Images.Add(System.Drawing.Image.FromFile("cut.bmp"))
       	    imageList1.Images.Add(System.Drawing.Image.FromFile("copy.bmp"))
       	    imageList1.Images.Add(System.Drawing.Image.FromFile("paste.bmp"))


            ' Set the images for the PictureBoxes
            SetImages()

            ' Set the tooltips for the PictureBoxes
            SetToolTips()

        end sub

        private sub SetImages() 
            Debug.Assert(picts.Length >= imageList1.Images.Count, "Not enough PictureBoxes")
	    dim i as integer
            for i = 0 to imageList1.Images.Count-1
                picts(i).Image = imageList1.Images(i)
	    next
        end sub

        private sub SetToolTips() 
            Debug.Assert(toolTips.Length >= picts.Length, "Not enough tooltip text")
	    dim i as integer
            for i = 0 to picts.Length-1
                toolTip.SetToolTip(picts(i), toolTips(i))
	    next
        end sub

        '
        ' Since rdbActivateTrue and rdbActivateFalse are in the same container in the
        ' form designer, their states will be mutually exclusive.  We can use the same
        ' code to handle their checkedChanged events.
        '
        private sub RdbActivate_checkedChanged(source As Object, e As EventArgs) 
            dim isTrue As boolean = rdbActivateTrue.Checked
            toolTip.Active = isTrue
        end sub

        '
        ' Since rdbShowAlwaysTrue and rdbShowAlwaysFalse are in the same container in the
        ' form designer, their states will be mutually exclusive.  We can use the same
        ' code to handle their checkedChanged events.
        '
        private sub RdbShowAlways_checkedChanged(source As Object, e As EventArgs) 
            dim isTrue As Boolean = rdbShowAlwaysTrue.Checked
            toolTip.ShowAlways = isTrue
        end sub

        ' <doc>
    	' <desc>
        '     Helper routine to retrieve the integer value of the selected item in
        '     a ComboBox object passed to it.
        ' </desc>
    	' </doc>
    	'
        private shared function GetCmbIntValue(combo as Object) as integer
            dim cmb As ComboBox = combo
            return Int32.Parse(cmb.SelectedItem)
        end function

        private sub CmbAutomaticDelay_selectedIndexChanged(source As Object, e As EventArgs) 
            try 
                toolTip.AutomaticDelay = GetCmbIntValue(source)
            
            catch ex as FormatException

            end try
        end sub

        private sub CmbAutoPopDelay_selectedIndexChanged(source As Object, e As EventArgs) 
            try 
                toolTip.AutoPopDelay = GetCmbIntValue(source)
            
            catch ex as FormatException

            end try
        end sub

        private sub CmbInitialDelay_selectedIndexChanged(source As Object, e As EventArgs) 
            try 
                toolTip.InitialDelay = GetCmbIntValue(source)
            
            catch ex as FormatException

            end try
        end sub

        private sub CmbReshowDelay_selectedIndexChanged(source As Object, e As EventArgs) 
            try 
                toolTip.ReshowDelay = GetCmbIntValue(source)
            
            catch ex as FormatException

            end try
        end sub

        private sub BtnChange_click(source As Object, e As EventArgs) 
            dim dlg as new ChangeToolTips(imageList1, toolTips)
            dim res as DialogResult = dlg.ShowDialog()

            if (res = System.WinForms.DialogResult.Cancel) then 
		exit sub
            else 
                toolTips = dlg.GetToolTips()
                SetToolTips()
            end if
        end sub

        ' <doc>
        ' <desc>
        '     NOTE: The following code is required by the WFC form
        '     designer.  It can be modified using the form editor.  Do not
        '     modify it using the code editor.
        ' </desc>
        ' </doc>
        '

        private components as System.ComponentModel.Container 
        private toolTip as System.WinForms.ToolTip 
        private groupBox1 as System.WinForms.GroupBox 
        private rdbActivateTrue as System.WinForms.RadioButton 
        private rdbActivateFalse as System.WinForms.RadioButton
        private grpActivate as System.WinForms.GroupBox 
        private grpShowAlways as System.WinForms.GroupBox 
        private rdbShowAlwaysFalse as System.WinForms.RadioButton 
        private rdbShowAlwaysTrue as System.WinForms.RadioButton 
        private label1 as System.WinForms.Label 
        private label2 as System.WinForms.Label 
        private label3 as System.WinForms.Label 
        private label4 as System.WinForms.Label 
        private cmbAutomaticDelay as System.WinForms.ComboBox 
        private cmbAutoPopDelay as System.WinForms.ComboBox 
        private cmbInitialDelay as System.WinForms.ComboBox 
        private cmbReshowDelay as System.WinForms.ComboBox 
        private panel as System.WinForms.Panel 
        private toolBarButton1 as System.WinForms.ToolBarButton 
        private toolBarButton2 as System.WinForms.ToolBarButton 
        private toolBarButton3 as System.WinForms.ToolBarButton 
        private toolBarButton4 as System.WinForms.ToolBarButton 
        private toolBarButton5 as System.WinForms.ToolBarButton 
        private pictureBox1 as System.WinForms.PictureBox 
        private pictureBox2 as System.WinForms.PictureBox 
        private pictureBox3 as System.WinForms.PictureBox 
        private pictureBox4 as System.WinForms.PictureBox 
        private pictureBox5 as System.WinForms.PictureBox 
        private imageList1 as System.WinForms.ImageList 
        private pictureBox6 as System.WinForms.PictureBox 
        private propertyTips As System.WinForms.ToolTip 
        private btnChange as System.WinForms.Button 
        private resources as System.Resources.ResourceManager 

        private sub InitializeComponent() 
	        try
			resources = new System.Resources.ResourceManager("ToolTipCtl", ToolTipCtl.GetType, Nothing, true)
		catch ex as Exception
			MessageBox.Show(Me,"Exception: " & ex.Message)
		end try

		Me.components = new System.ComponentModel.Container()
		Me.groupBox1 = new System.WinForms.GroupBox()
		Me.toolTip = new System.WinForms.ToolTip(components)
		Me.rdbActivateTrue = new System.WinForms.RadioButton()
		Me.panel = new System.WinForms.Panel()
		Me.toolBarButton3 = new System.WinForms.ToolBarButton()
		Me.cmbInitialDelay = new System.WinForms.ComboBox()
		Me.propertyTips = new System.WinForms.ToolTip(components)
		Me.cmbAutoPopDelay = new System.WinForms.ComboBox()
		Me.toolBarButton2 = new System.WinForms.ToolBarButton()
		Me.rdbShowAlwaysFalse = new System.WinForms.RadioButton()
		Me.btnChange = new System.WinForms.Button()
		Me.rdbShowAlwaysTrue = new System.WinForms.RadioButton()
		Me.rdbActivateFalse = new System.WinForms.RadioButton()
		Me.grpActivate = new System.WinForms.GroupBox()
		Me.toolBarButton1 = new System.WinForms.ToolBarButton()
		Me.pictureBox4 = new System.WinForms.PictureBox()
		Me.label4 = new System.WinForms.Label()
		Me.toolBarButton5 = new System.WinForms.ToolBarButton()
		Me.pictureBox3 = new System.WinForms.PictureBox()
		Me.pictureBox5 = new System.WinForms.PictureBox()
		Me.imageList1 = new System.WinForms.ImageList()
		Me.pictureBox2 = new System.WinForms.PictureBox()
		Me.grpShowAlways = new System.WinForms.GroupBox()
		Me.cmbAutomaticDelay = new System.WinForms.ComboBox()
		Me.pictureBox1 = new System.WinForms.PictureBox()
		Me.pictureBox6 = new System.WinForms.PictureBox()
		Me.cmbReshowDelay = new System.WinForms.ComboBox()
		Me.label1 = new System.WinForms.Label()
		Me.toolBarButton4 = new System.WinForms.ToolBarButton()
		Me.label3 = new System.WinForms.Label()
		Me.label2 = new System.WinForms.Label()
		
		groupBox1.Location = new System.Drawing.Point(248, 16)
		groupBox1.TabIndex = 2
		groupBox1.TabStop = false
		groupBox1.Text = "ToolTip"
		groupBox1.Size = new System.Drawing.Size(248, 264)
		
		toolTip.Active = true
		'@design toolTip.SetLocation(new System.Drawing.Point(20, 10))
		
		rdbActivateTrue.Location = new System.Drawing.Point(8, 16)
		rdbActivateTrue.TabIndex = 0
		rdbActivateTrue.TabStop = true
		rdbActivateTrue.Text = "true"
		rdbActivateTrue.Size = new System.Drawing.Size(88, 16)
		rdbActivateTrue.Checked = true
		toolTip.SetToolTip(rdbActivateTrue, "Indicates whether the ToolTip" & CrLf & "control is currently active")
		rdbActivateTrue.AddOnCheckedChanged(new EventHandler(AddressOf RdbActivate_checkedChanged))
		
		Me.TabIndex = 0
		Me.Text = "ToolTip"
		Me.Size = new System.Drawing.Size(512, 300)
		
		panel.BorderStyle = System.WinForms.BorderStyle.Fixed3D
		panel.Location = new System.Drawing.Point(24, 24)
		panel.TabIndex = 0
		panel.Text = "panel1"
		panel.Size = new System.Drawing.Size(208, 40)
		
		toolBarButton3.ImageIndex = 2
		toolBarButton3.Text = "toolBarButton3"
		
		cmbInitialDelay.ForeColor = System.Drawing.SystemColors.WindowText
		cmbInitialDelay.Location = new System.Drawing.Point(112, 160)
		cmbInitialDelay.Style = System.WinForms.ComboBoxStyle.DropDownList
		cmbInitialDelay.TabIndex = 7
		cmbInitialDelay.Text = ""
		cmbInitialDelay.Size = new System.Drawing.Size(121, 21)
		toolTip.SetToolTip(cmbInitialDelay, "The period of time, in milliseconds, that the" & CrLf & "mouse pointer must remain stationary within the" & CrLf & "tooltip region before the tooltip text is displayed")
		cmbInitialDelay.AddOnSelectedIndexChanged(new EventHandler(AddressOf CmbInitialDelay_selectedIndexChanged))
		cmbInitialDelay.Items.All = new object() {"250", "500", "750", "1000", "5000"}
		
		propertyTips.Active = true
		'@design propertyTips.SetLocation(new System.Drawing.Point(20, 70))
		
		cmbAutoPopDelay.ForeColor = System.Drawing.SystemColors.WindowText
		cmbAutoPopDelay.Location = new System.Drawing.Point(112, 136)
		cmbAutoPopDelay.Style = System.WinForms.ComboBoxStyle.DropDownList
		cmbAutoPopDelay.TabIndex = 4
		cmbAutoPopDelay.Text = ""
		cmbAutoPopDelay.Size = new System.Drawing.Size(121, 21)
		toolTip.SetToolTip(cmbAutoPopDelay, "The period of time, in milliseconds, that " & CrLf & "the tooltip remains visible when the mouse" & CrLf & "pointer is stationary within the tooltip region")
		cmbAutoPopDelay.AddOnSelectedIndexChanged(new EventHandler(AddressOf CmbAutoPopDelay_selectedIndexChanged))
		cmbAutoPopDelay.Items.All = new object() {"2500", "5000", "7500", "10000"}
		
		toolBarButton2.ImageIndex = 1
		toolBarButton2.Text = "toolBarButton2"
		
		rdbShowAlwaysFalse.Location = new System.Drawing.Point(112, 16)
		rdbShowAlwaysFalse.TabIndex = 1
		rdbShowAlwaysFalse.TabStop = true
		rdbShowAlwaysFalse.Text = "false"
		rdbShowAlwaysFalse.Size = new System.Drawing.Size(80, 16)
		rdbShowAlwaysFalse.Checked = true
		toolTip.SetToolTip(rdbShowAlwaysFalse, "Indicates whether the tooltip window is " & CrLf & "displayed even when its parent control " & CrLf & "is not active")
		rdbShowAlwaysFalse.AddOnCheckedChanged(new EventHandler(AddressOf RdbShowAlways_checkedChanged))
		
		btnChange.Location = new System.Drawing.Point(264, 240)
		btnChange.TabIndex = 1
		btnChange.Text = "&Change ToolTips..."
		btnChange.Size = new System.Drawing.Size(104, 23)
		btnChange.AddOnClick(new EventHandler(AddressOf BtnChange_click))
		
		rdbShowAlwaysTrue.Location = new System.Drawing.Point(8, 16)
		rdbShowAlwaysTrue.TabIndex = 0
		rdbShowAlwaysTrue.Text = "true"
		rdbShowAlwaysTrue.Size = new System.Drawing.Size(88, 16)
		toolTip.SetToolTip(rdbShowAlwaysTrue, "Indicates whether the tooltip window is " & CrLf & "displayed even when its parent control " & CrLf & "is not active")
		rdbShowAlwaysTrue.AddOnCheckedChanged(new EventHandler(AddressOf RdbShowAlways_checkedChanged))
		
		rdbActivateFalse.Location = new System.Drawing.Point(112, 16)
		rdbActivateFalse.TabIndex = 1
		rdbActivateFalse.Text = "false"
		rdbActivateFalse.Size = new System.Drawing.Size(80, 16)
		toolTip.SetToolTip(rdbActivateFalse, "Indicates whether the ToolTip" & CrLf & "control is currently active")
		rdbActivateFalse.AddOnCheckedChanged(new EventHandler(AddressOf RdbActivate_checkedChanged))
		
		grpActivate.Location = new System.Drawing.Point(16, 16)
		grpActivate.TabIndex = 0
		grpActivate.TabStop = false
		grpActivate.Text = "Active"
		grpActivate.Size = new System.Drawing.Size(216, 40)
		
		toolBarButton1.ImageIndex = 0
		toolBarButton1.Text = "toolBarButton1"
		
		pictureBox4.Location = new System.Drawing.Point(68, 7)
		pictureBox4.TabIndex = 2
		pictureBox4.TabStop = false
		pictureBox4.Text = "pictureBox1"
		pictureBox4.Size = new System.Drawing.Size(20, 20)
		
		label4.Location = new System.Drawing.Point(16, 186)
		label4.TabIndex = 8
		label4.TabStop = false
		label4.Text = "reshowDelay:"
		label4.Size = new System.Drawing.Size(88, 16)
		
		toolBarButton5.ImageIndex = 5
		toolBarButton5.Text = "toolBarButton5"
		
		pictureBox3.Location = new System.Drawing.Point(48, 7)
		pictureBox3.TabIndex = 3
		pictureBox3.TabStop = false
		pictureBox3.Text = "pictureBox1"
		pictureBox3.Size = new System.Drawing.Size(20, 20)
		
		pictureBox5.Location = new System.Drawing.Point(88, 7)
		pictureBox5.TabIndex = 1
		pictureBox5.TabStop = false
		pictureBox5.Text = "pictureBox1"
		pictureBox5.Size = new System.Drawing.Size(20, 20)
		
	        imageList1.ImageSize = new System.Drawing.Size(16, 15)
            	'BUG imageList1.ImageStream = resources.GetObject("imageList1.ImageStream")
		imageList1.TransparentColor = System.Drawing.Color.Transparent
		'@design imageList1.SetLocation(new System.Drawing.Point(20, 40))
		
		pictureBox2.Location = new System.Drawing.Point(28, 7)
		pictureBox2.TabIndex = 4
		pictureBox2.TabStop = false
		pictureBox2.Text = "pictureBox1"
		pictureBox2.Size = new System.Drawing.Size(20, 20)
		
		grpShowAlways.Location = new System.Drawing.Point(16, 58)
		grpShowAlways.TabIndex = 1
		grpShowAlways.TabStop = false
		grpShowAlways.Text = "showAlways"
		grpShowAlways.Size = new System.Drawing.Size(216, 40)
		
		cmbAutomaticDelay.ForeColor = System.Drawing.SystemColors.WindowText
		cmbAutomaticDelay.Location = new System.Drawing.Point(112, 112)
		cmbAutomaticDelay.Style = System.WinForms.ComboBoxStyle.DropDownList
		cmbAutomaticDelay.TabIndex = 3
		cmbAutomaticDelay.Text = ""
		cmbAutomaticDelay.Size = new System.Drawing.Size(121, 21)
		toolTip.SetToolTip(cmbAutomaticDelay, "The amount of time in milliseconds that" & CrLf & "passes before the tooltip is displayed")
		cmbAutomaticDelay.AddOnSelectedIndexChanged(new EventHandler(AddressOf CmbAutomaticDelay_selectedIndexChanged))
		cmbAutomaticDelay.Items.All = new object() {"250", "500", "750", "1000"}
		
		pictureBox1.Location = new System.Drawing.Point(8, 7)
		pictureBox1.TabIndex = 5
		pictureBox1.TabStop = false
		pictureBox1.Text = "pictureBox1"
		pictureBox1.Size = new System.Drawing.Size(20, 20)
		
		pictureBox6.Location = new System.Drawing.Point(108, 7)
		pictureBox6.TabIndex = 0
		pictureBox6.TabStop = false
		pictureBox6.Text = "pictureBox1"
		pictureBox6.Size = new System.Drawing.Size(20, 20)
		
		cmbReshowDelay.ForeColor = System.Drawing.SystemColors.WindowText
		cmbReshowDelay.Location = new System.Drawing.Point(112, 184)
		cmbReshowDelay.Style = System.WinForms.ComboBoxStyle.DropDownList
		cmbReshowDelay.TabIndex = 9
		cmbReshowDelay.Text = ""
		cmbReshowDelay.Size = new System.Drawing.Size(121, 21)
		toolTip.SetToolTip(cmbReshowDelay, "The period, in milliseconds, that must transpire" & CrLf & "before subsequent tooltip windows appear as the" & CrLf & "mouse pointer moves from one tooltip region to another")
		cmbReshowDelay.AddOnSelectedIndexChanged(new EventHandler(AddressOf CmbReshowDelay_selectedIndexChanged))
		cmbReshowDelay.Items.All = new object() {"50", "100", "200", "300", "500", "1000"}
		
		label1.Location = new System.Drawing.Point(16, 114)
		label1.TabIndex = 2
		label1.TabStop = false
		label1.Text = "automaticDelay:"
		label1.Size = new System.Drawing.Size(88, 16)
		
		toolBarButton4.ImageIndex = 3
		toolBarButton4.Text = "toolBarButton4"
		
		label3.Location = new System.Drawing.Point(16, 162)
		label3.TabIndex = 6
		label3.TabStop = false
		label3.Text = "initialDelay"
		label3.Size = new System.Drawing.Size(88, 16)
		
		label2.Location = new System.Drawing.Point(16, 138)
		label2.TabIndex = 5
		label2.TabStop = false
		label2.Text = "autoPopDelay"
		label2.Size = new System.Drawing.Size(88, 16)
		
		grpShowAlways.Controls.Add(rdbShowAlwaysFalse)
		grpShowAlways.Controls.Add(rdbShowAlwaysTrue)
		panel.Controls.Add(pictureBox6)
		panel.Controls.Add(pictureBox5)
		panel.Controls.Add(pictureBox4)
		panel.Controls.Add(pictureBox3)
		panel.Controls.Add(pictureBox2)
		panel.Controls.Add(pictureBox1)
		groupBox1.Controls.Add(cmbReshowDelay)
		groupBox1.Controls.Add(cmbInitialDelay)
		groupBox1.Controls.Add(cmbAutoPopDelay)
		groupBox1.Controls.Add(cmbAutomaticDelay)
		groupBox1.Controls.Add(label4)
		groupBox1.Controls.Add(label3)
		groupBox1.Controls.Add(label2)
		groupBox1.Controls.Add(label1)
		groupBox1.Controls.Add(grpShowAlways)
		groupBox1.Controls.Add(grpActivate)
		Me.Controls.Add(btnChange)
		Me.Controls.Add(panel)
		Me.Controls.Add(groupBox1)
		grpActivate.Controls.Add(rdbActivateFalse)
		grpActivate.Controls.Add(rdbActivateTrue)
		
	end sub

        ' The main entry point for the application.
        public shared sub Main() 
            Application.Run(new ToolTipCtl())
        end sub

    end class
end namespace

