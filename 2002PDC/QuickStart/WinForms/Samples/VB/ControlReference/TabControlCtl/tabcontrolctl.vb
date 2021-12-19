'------------------------------------------------------------------------------
' <copyright from='1997' to='2001' company='Microsoft Corporation'>           
'    Copyright (c) Microsoft Corporation. All Rights Reserved.                
'       
'    This source code is intended only as a supplement to Microsoft'
'    Development Tools and/or on-line documentation.  See these other
'    materials for detailed information regarding Microsoft code samples.
'
' </copyright>                                                                
'------------------------------------------------------------------------------

    Imports System
    Imports System.Collections
    Imports System.ComponentModel
    Imports System.Drawing
    Imports System.WinForms
    Imports System.Resources


    Option Explicit
    Option Strict Off

    ' <doc>
    ' <desc>
    '     This class demonstrates the TabControl control.
    '
    '     Typically the contents of each page are encapsulated 
    '     in a UserControl however for this simple example the 
    '     contents of all pages are defined directly in this 
    '     form.
    '
    '     TabPages can either be added at designtime or runtime
    '     The main MiscUI file shows an example of how to add pages 
    '     dynamically at runtime
    '
    ' </desc>
    ' </doc>
    '

    Public Module ModMain


    	Public Class TabControlCtl 
    	Inherits Form
	

    	Public Sub New()
        	MyBase.New
        	' This call is required for support of the WinForms Form Designer.
        	InitializeComponent

        	appearanceComboBox.SelectedIndex = 0 
        	alignmentComboBox.SelectedIndex = 0
        	sizeModeComboBox.SelectedIndex = 0 
        	tabControl1.ImageList = Nothing

        	' BUG BUG: 31070
        	'imageList1.Images.Add(resources.GetObject("speaker"))
        	'imageList1.Images.Add(resources.GetObject("camcorder"))
        	'imageList1.Images.Add(resources.GetObject("note"))
        	'imageList1.Images.Add(resources.GetObject("calendar"))
        	'imageList1.Images.Add(resources.GetObject("time"))

        	imageList1.Images.Add(System.Drawing.Image.FromFile("speaker.bmp"))
        	imageList1.Images.Add(System.Drawing.Image.FromFile("camcord.bmp"))
        	imageList1.Images.Add(System.Drawing.Image.FromFile("note.bmp"))
        	imageList1.Images.Add(System.Drawing.Image.FromFile("calendar.bmp"))
        	imageList1.Images.Add(System.Drawing.Image.FromFile("time.bmp"))

    	End Sub

        ' <doc>
        ' <desc>
        '     TabControlCtl overrides dispose so it can clean up the
        '     component list.
        ' </desc>
        ' </doc>
        '
    
    	Overrides Public Sub Dispose 
        	MyBase.Dispose
        	components.Dispose      
   	End Sub


       	Private Sub appearanceComboBox_SelectedIndexChanged(sender As Object, e As EventArgs) 
            	Dim index As Integer = appearanceComboBox.SelectedIndex
            	if (index = 0) 
               		tabControl1.Appearance = TabAppearance.Normal
            	elseif (index = 1) 
                	tabControl1.Appearance = TabAppearance.Buttons
            	else 
               		tabControl1.Appearance = TabAppearance.FlatButtons
            	end if
            	tabControl1.PerformLayout
	end sub

       	Private Sub checkBox1_Click(sender As Object, e As EventArgs) 
            	Me.tabControl1.Multiline = checkBox1.Checked
        End Sub

       	Private Sub alignmentComboBox_SelectedIndexChanged(sender As Object, e As EventArgs) 
            	Dim index As Integer = alignmentComboBox.SelectedIndex
            	if (index = 0) 
                	tabControl1.Alignment = TabAlignment.Top
            	elseif (index = 1) 
                	tabControl1.Alignment = TabAlignment.Bottom
            	elseif (index = 2) 
                	tabControl1.Alignment = TabAlignment.Left
            	else
                	tabControl1.Alignment = TabAlignment.Right
            	end if
        end sub

        Private Sub checkBox2_Click(sender As Object, e As EventArgs) 
            	Me.tabControl1.HotTrack = checkBox2.Checked
        End Sub


        private Sub sizeModeComboBox_SelectedIndexChanged(sender As Object, e As EventArgs) 
            	Dim index As Integer = sizeModeComboBox.SelectedIndex
            	if (index = 0) 
                	tabControl1.SizeMode = TabSizeMode.Normal
            	elseif (index = 1) 
                	tabControl1.SizeMode = TabSizeMode.FillToRight
            	else
                	tabControl1.SizeMode = TabSizeMode.Fixed
	    	end if
        end sub

        private Sub trackBar_Scroll(sender As Object, e As EventArgs) 
            	tabControl1.Width = trackBar.Value
        end sub

        private sub tabControl1_SelectedIndexChanged(sender As Object, e As EventArgs) 

        End Sub

        private Sub checkBox3_Click(sender As Object, e As EventArgs) 
            	if (checkBox3.Checked)
                	tabControl1.ImageList = imageList1
            	else
                	tabControl1.ImageList = Nothing
            	end if
        end Sub


    	Private components As System.ComponentModel.Container
    	Private tp5DomainUpDown1 As System.WinForms.DomainUpDown 
    	Private tp5GroupBox1 As System.WinForms.GroupBox 
    	Private tp4ComboBox1 As System.WinForms.ComboBox 
    	Private tp4UpDown1 As System.WinForms.NumericUpDown 
    	Private tp4GroupBox1 As System.WinForms.GroupBox 
    	Private tp3ComboBox1 As System.WinForms.ComboBox 
    	Private tp3RadioButton1 As System.WinForms.RadioButton 
    	Private tp3RadioButton2 As System.WinForms.RadioButton 
    	Private tp3ComboBox2 As System.WinForms.ComboBox 
    	Private tp3Label1 As System.WinForms.Label 
    	Private tp3Button1 As System.WinForms.Button 
    	Private tp3GroupBox1 As System.WinForms.GroupBox 
    	Private tabPage5 As System.WinForms.TabPage 
    	Private tabPage4 As System.WinForms.TabPage 
    	Private tabPage3 As System.WinForms.TabPage 
    	Private tp2ComboBox1 As System.WinForms.ComboBox 
    	Private tp2RadioButton1 As System.WinForms.RadioButton 
    	Private tp2RadioButton2 As System.WinForms.RadioButton 
    	Private tp2GroupBox1 As System.WinForms.GroupBox 
    	Private tabPage2 As System.WinForms.TabPage 
    	Private tabPage1 As System.WinForms.TabPage 
    	Private groupBox1 As System.WinForms.GroupBox 
    	Private appearanceComboBox As System.WinForms.ComboBox 
    	Private checkBox1 As System.WinForms.CheckBox 
    	Private tabControl1 As System.WinForms.TabControl 
    	Private alignmentComboBox As System.WinForms.ComboBox 
    	Private checkBox2 As System.WinForms.CheckBox  
    	Private sizeModeComboBox As System.WinForms.ComboBox  
    	Private label1 As System.WinForms.Label  
    	Private label2 As System.WinForms.Label  
    	Private label3 As System.WinForms.Label  
    	Private trackBar As System.WinForms.TrackBar  
    	Private label4 As System.WinForms.Label  
    	Private pictureBox1 As System.WinForms.PictureBox  
    	Private toolTip1 As System.WinForms.ToolTip 
    	Private imageList1 As System.WinForms.ImageList  
    	Private checkBox3 As System.WinForms.CheckBox  
    	Private tp1ComboBox1 As System.WinForms.ComboBox 
    	Private tp1Label1 As System.WinForms.Label 
    	Private tp1Label2 As System.WinForms.Label 
    	Private tp1Button1 As System.WinForms.Button 
    	Private tp1GroupBox1 As System.WinForms.GroupBox 
    	Private resources As System.Resources.ResourceManager 



    	Private Sub InitializeComponent()
		'resources = new System.Resources.ResourceManager("TabControlCtl", typeof(TabControlCtl), null, true);
		'this doesn't work ?????
		'resources = new System.Resources.ResourceManager("TabControlCtl", Me.GetType, Nothing, true)

		try 
			resources = new System.Resources.ResourceManager("TabControlCtl", Me.GetType, Nothing, True)

		catch Ex As Exception
			
			MessageBox.Show(Me,"Exception: " & Ex.Message)

		end try

		Me.components = new System.ComponentModel.Container
		Me.tp5DomainUpDown1 = new System.WinForms.DomainUpDown
		Me.alignmentComboBox = new System.WinForms.ComboBox
		Me.tp2ComboBox1 = new System.WinForms.ComboBox
		Me.sizeModeComboBox = new System.WinForms.ComboBox
		Me.checkBox1 = new System.WinForms.CheckBox
		Me.tp3RadioButton1 = new System.WinForms.RadioButton
		Me.trackBar = new System.WinForms.TrackBar
		Me.tp1GroupBox1 = new System.WinForms.GroupBox
		Me.tp3RadioButton2 = new System.WinForms.RadioButton
		Me.tp3Label1 = new System.WinForms.Label
		Me.label1 = new System.WinForms.Label
		Me.tp1ComboBox1 = new System.WinForms.ComboBox
		Me.label2 = new System.WinForms.Label
		Me.groupBox1 = new System.WinForms.GroupBox
		Me.toolTip1 = new System.WinForms.ToolTip(components)
		Me.checkBox2 = new System.WinForms.CheckBox
		Me.tp4ComboBox1 = new System.WinForms.ComboBox
		Me.tp1Label2 = new System.WinForms.Label
		Me.tp1Label1 = new System.WinForms.Label
		Me.label4 = new System.WinForms.Label
		Me.appearanceComboBox = new System.WinForms.ComboBox
		Me.pictureBox1 = new System.WinForms.PictureBox
		Me.tp2RadioButton2 = new System.WinForms.RadioButton
		Me.tabPage4 = new System.WinForms.TabPage
		Me.tp2RadioButton1 = new System.WinForms.RadioButton
		Me.tp4GroupBox1 = new System.WinForms.GroupBox
		Me.checkBox3 = new System.WinForms.CheckBox
		Me.label3 = new System.WinForms.Label
		Me.tp3ComboBox1 = new System.WinForms.ComboBox
		Me.tp4UpDown1 = new System.WinForms.NumericUpDown
		Me.tp3ComboBox2 = new System.WinForms.ComboBox
		Me.tp3Button1 = new System.WinForms.Button
		Me.tp5GroupBox1 = new System.WinForms.GroupBox
		Me.tabControl1 = new System.WinForms.TabControl
		Me.imageList1 = new System.WinForms.ImageList
		Me.tp1Button1 = new System.WinForms.Button
		Me.tp2GroupBox1 = new System.WinForms.GroupBox
		Me.tabPage2 = new System.WinForms.TabPage
		Me.tabPage5 = new System.WinForms.TabPage
		Me.tabPage3 = new System.WinForms.TabPage
		Me.tp3GroupBox1 = new System.WinForms.GroupBox
		Me.tabPage1 = new System.WinForms.TabPage

		tp5DomainUpDown1.Location = new System.Drawing.Point(24, 32)
		tp5DomainUpDown1.TabIndex = 0
		tp5DomainUpDown1.Enabled = false
		tp5DomainUpDown1.Text = "11:01:35 AM"
		tp5DomainUpDown1.Size = new System.Drawing.Size(112, 20)

		alignmentComboBox.ForeColor = System.Drawing.SystemColors.WindowText
		alignmentComboBox.Location = new System.Drawing.Point(128, 48)
		alignmentComboBox.TabIndex = 4
		alignmentComboBox.Text = ""
		alignmentComboBox.Size = new System.Drawing.Size(104, 21)
		alignmentComboBox.Style = System.WinForms.ComboBoxStyle.DropDownList
		toolTip1.SetToolTip(alignmentComboBox, "Determines whether the tabs appear on the top, bottom,left or, right side of the control.")
		alignmentComboBox.AddOnSelectedIndexChanged(New EventHandler(AddressOf Me.alignmentComboBox_SelectedIndexChanged))
		alignmentComboBox.Items.All = new object() {"top", "bottom", "left", "right"}
		
		tp2ComboBox1.ForeColor = System.Drawing.SystemColors.WindowText
		tp2ComboBox1.Location = new System.Drawing.Point(32, 80)
		tp2ComboBox1.TabIndex = 2
		tp2ComboBox1.Enabled = false
		tp2ComboBox1.Text = "Original Size"
		tp2ComboBox1.Size = new System.Drawing.Size(160, 21)
		
		sizeModeComboBox.ForeColor = System.Drawing.SystemColors.WindowText
		sizeModeComboBox.Location = new System.Drawing.Point(128, 80)
		sizeModeComboBox.TabIndex = 6
		sizeModeComboBox.Text = ""
		sizeModeComboBox.Size = new System.Drawing.Size(104, 21)
		sizeModeComboBox.Style = System.WinForms.ComboBoxStyle.DropDownList
		toolTip1.SetToolTip(sizeModeComboBox, "Indicates how tabs are sized.")
		sizeModeComboBox.AddOnSelectedIndexChanged(New EventHandler(AddressOf Me.sizeModeComboBox_SelectedIndexChanged))
		sizeModeComboBox.Items.All = new object() {"Normal", "Fill to Right", "Fixed"}
		
		checkBox1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
		checkBox1.Location = new System.Drawing.Point(16, 112)
		checkBox1.TabIndex = 0
		checkBox1.Text = "multiline"
		checkBox1.Size = new System.Drawing.Size(88, 16)
		toolTip1.SetToolTip(checkBox1, "Indicates if more than one row of tabs is allowed.")
		checkBox1.AddOnClick(New EventHandler(AddressOf Me.checkBox1_Click))
		
		tp3RadioButton1.Location = new System.Drawing.Point(8, 24)
		tp3RadioButton1.TabIndex = 4
		tp3RadioButton1.Enabled = false
		tp3RadioButton1.Text = "&Single Instrument"
		tp3RadioButton1.Size = new System.Drawing.Size(100, 23)
		
		trackBar.Location = new System.Drawing.Point(16, 192)
		trackBar.TickFrequency = 10
		trackBar.TabIndex = 2
		trackBar.TabStop = false
		trackBar.Maximum = 220
		trackBar.Value = 220
		trackBar.Text = "trackBar1"
		trackBar.Size = new System.Drawing.Size(216, 42)
		trackBar.AddOnScroll(New EventHandler(AddressOf Me.trackBar_Scroll))
		trackBar.BackColor = System.Drawing.SystemColors.Control
		
		tp1GroupBox1.Location = new System.Drawing.Point(12, 16)
		tp1GroupBox1.TabIndex = 0
		tp1GroupBox1.TabStop = false
		tp1GroupBox1.Text = "Playback"
		tp1GroupBox1.Size = new System.Drawing.Size(202, 144)
		
		tp3RadioButton2.Location = new System.Drawing.Point(8, 80)
		tp3RadioButton2.TabIndex = 3
		tp3RadioButton2.Enabled = false
		tp3RadioButton2.Text = "&Custom Configuration"
		tp3RadioButton2.Size = new System.Drawing.Size(168, 23)
		
		tp3Label1.Location = new System.Drawing.Point(24, 104)
		tp3Label1.TabIndex = 1
		tp3Label1.TabStop = false
		tp3Label1.Text = "Midi Scheme:"
		tp3Label1.Size = new System.Drawing.Size(100, 16)
		
		label1.Location = new System.Drawing.Point(16, 16)
		label1.TabIndex = 7
		label1.TabStop = false
		label1.Text = "appearance"
		label1.Size = new System.Drawing.Size(72, 16)
		
		tp1ComboBox1.ForeColor = System.Drawing.SystemColors.WindowText
		tp1ComboBox1.Location = new System.Drawing.Point(24, 48)
		tp1ComboBox1.TabIndex = 3
		tp1ComboBox1.Enabled = false
		tp1ComboBox1.Text = "(Use any available device)"
		tp1ComboBox1.Size = new System.Drawing.Size(160, 21)
                
		Me.TabIndex = 0
		Me.Text = "TabControl VB"
		Me.Size = new System.Drawing.Size(554, 320)
		
		label2.Location = new System.Drawing.Point(16, 48)
		label2.TabIndex = 8
		label2.TabStop = false
		label2.Text = "alignment"
		label2.Size = new System.Drawing.Size(64, 16)
		
		groupBox1.Location = new System.Drawing.Point(280, 16)
		groupBox1.TabIndex = 1
		groupBox1.TabStop = false
		groupBox1.Text = "TabControl"
		groupBox1.Size = new System.Drawing.Size(248, 264)
		
		toolTip1.Active = true
		'@design toolTip1.SetLocation(new System.Drawing.Point(20, 10))
		
		checkBox2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
		checkBox2.Location = new System.Drawing.Point(16, 136)
		checkBox2.TabIndex = 5
		checkBox2.Text = "hotTrack"
		checkBox2.Size = new System.Drawing.Size(100, 23)
		toolTip1.SetToolTip(checkBox2, "Indiactes whether the tabs visually change as the mouse passes")
		checkBox2.AddOnClick(New EventHandler(AddressOf Me.checkBox2_Click))
		
		tp4ComboBox1.ForeColor = System.Drawing.SystemColors.WindowText
		tp4ComboBox1.Location = new System.Drawing.Point(16, 32)
		tp4ComboBox1.TabIndex = 1
		tp4ComboBox1.Enabled = false
		tp4ComboBox1.Text = "June"
		tp4ComboBox1.Size = new System.Drawing.Size(56, 21)
		
		tp1Label2.Location = new System.Drawing.Point(24, 88)
		tp1Label2.TabIndex = 1
		tp1Label2.TabStop = false
		tp1Label2.Text = "To select advanced options, click:"
		tp1Label2.Size = new System.Drawing.Size(176, 16)
		
		tp1Label1.Location = new System.Drawing.Point(24, 24)
		tp1Label1.TabIndex = 2
		tp1Label1.TabStop = false
		tp1Label1.Text = "Preferred device:"
		tp1Label1.Size = new System.Drawing.Size(100, 16)
		
		label4.Location = new System.Drawing.Point(16, 168)
		label4.TabIndex = 3
		label4.TabStop = false
		label4.Text = "Tab Control Width:"
		label4.Size = new System.Drawing.Size(120, 16)
		
		appearanceComboBox.ForeColor = System.Drawing.SystemColors.WindowText
		appearanceComboBox.Location = new System.Drawing.Point(128, 16)
		appearanceComboBox.TabIndex = 1
		appearanceComboBox.Text = ""
		appearanceComboBox.Size = new System.Drawing.Size(104, 21)
		appearanceComboBox.Style = System.WinForms.ComboBoxStyle.DropDownList
		toolTip1.SetToolTip(appearanceComboBox, "Indicates whether the tabs are painted as buttons or regular tabs.")
		appearanceComboBox.AddOnSelectedIndexChanged(New EventHandler(AddressOf Me.appearanceComboBox_SelectedIndexChanged))
		appearanceComboBox.Items.All = new object() {"Normal", "Buttons", "Flat Buttons"}
		
		pictureBox1.BorderStyle = System.WinForms.BorderStyle.Fixed3D
		pictureBox1.Location = new System.Drawing.Point(8, 24)
		pictureBox1.BackColor = System.Drawing.SystemColors.ControlLightLight
		pictureBox1.TabIndex = 2
		pictureBox1.TabStop = false
		pictureBox1.Text = "pictureBox1"
		pictureBox1.Size = new System.Drawing.Size(264, 256)
		
		tp2RadioButton2.Location = new System.Drawing.Point(32, 48)
		tp2RadioButton2.TabIndex = 0
		tp2RadioButton2.Enabled = false
		tp2RadioButton2.Text = "&Full Screen"
		tp2RadioButton2.Size = new System.Drawing.Size(100, 23)
		
		tabPage4.ImageIndex = 3
		tabPage4.TabIndex = 3
		tabPage4.Text = "Date"
		tabPage4.Size = new System.Drawing.Size(224, 191)
		tabPage4.Location = new System.Drawing.Point(4, 25)
		
		tp2RadioButton1.Location = new System.Drawing.Point(32, 24)
		tp2RadioButton1.TabIndex = 1
		tp2RadioButton1.Enabled = false
		tp2RadioButton1.Text = "&Window"
		tp2RadioButton1.Size = new System.Drawing.Size(100, 23)
		
		tp4GroupBox1.Location = new System.Drawing.Point(12, 16)
		tp4GroupBox1.TabIndex = 0
		tp4GroupBox1.TabStop = false
		tp4GroupBox1.Text = "Date"
		tp4GroupBox1.Size = new System.Drawing.Size(202, 88)
		
		checkBox3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
		checkBox3.Location = new System.Drawing.Point(128, 112)
		checkBox3.TabIndex = 10
		checkBox3.CheckState = System.WinForms.CheckState.Checked
		checkBox3.Text = "Images"
		checkBox3.Size = new System.Drawing.Size(72, 16)
		checkBox3.Checked = false
		checkBox3.AddOnClick(New EventHandler(AddressOf Me.checkBox3_Click))
		
		label3.Location = new System.Drawing.Point(16, 80)
		label3.TabIndex = 9
		label3.TabStop = false
		label3.Text = "sizeMode"
		label3.Size = new System.Drawing.Size(80, 16)
		
		tp3ComboBox1.ForeColor = System.Drawing.SystemColors.WindowText
		tp3ComboBox1.Location = new System.Drawing.Point(24, 48)
		tp3ComboBox1.TabIndex = 5
		tp3ComboBox1.Enabled = false
		tp3ComboBox1.Text = "Creative Music Synth [220]"
		tp3ComboBox1.Size = new System.Drawing.Size(160, 21)
		
		tp4UpDown1.TextAlign = System.WinForms.HorizontalAlignment.Right
		tp4UpDown1.Location = new System.Drawing.Point(88, 32)
		tp4UpDown1.Minimum = new System.Decimal(0d)
		tp4UpDown1.Maximum = new System.Decimal(0d)
		tp4UpDown1.TabIndex = 0
		tp4UpDown1.DecimalPlaces = 2
		tp4UpDown1.Enabled = false
		tp4UpDown1.Text = "0.00"
		tp4UpDown1.Size = new System.Drawing.Size(64, 20)
		
		tp3ComboBox2.ForeColor = System.Drawing.SystemColors.WindowText
		tp3ComboBox2.Location = new System.Drawing.Point(24, 120)
		tp3ComboBox2.TabIndex = 2
		tp3ComboBox2.Enabled = false
		tp3ComboBox2.Text = "Default"
		tp3ComboBox2.Size = new System.Drawing.Size(96, 21)
		
		tp3Button1.Location = new System.Drawing.Point(122, 120)
		tp3Button1.TabIndex = 0
		tp3Button1.Enabled = false
		tp3Button1.Text = "&Configure"
		tp3Button1.Size = new System.Drawing.Size(74, 24)
		
		tp5GroupBox1.Location = new System.Drawing.Point(12, 16)
		tp5GroupBox1.TabIndex = 0
		tp5GroupBox1.TabStop = false
		tp5GroupBox1.Text = "Time"
		tp5GroupBox1.Size = new System.Drawing.Size(202, 88)
		
		tabControl1.ImageList = imageList1
		tabControl1.Location = new System.Drawing.Point(24, 32)
		tabControl1.SelectedIndex = 0
		tabControl1.TabIndex = 0
		tabControl1.Text = "tabControl1"
		tabControl1.Size = new System.Drawing.Size(232, 220)
		tabControl1.AddOnSelectedIndexChanged(New EventHandler(AddressOf Me.tabControl1_SelectedIndexChanged))
		
        	imageList1.ImageSize = new System.Drawing.Size(16, 16)
		'//BUG: imageList1.ImageStream = (System.WinForms.ImageListStreamer)resources.GetObject("imageList1.ImageStream")
		imageList1.TransparentColor = System.Drawing.Color.Transparent
		'//@design imageList1.SetLocation(new System.Drawing.Point(20, 40))
		
		tp1Button1.Location = new System.Drawing.Point(24, 112)
		tp1Button1.TabIndex = 0
		tp1Button1.Enabled = false
		tp1Button1.Text = "Advanced &Properties"
		tp1Button1.Size = new System.Drawing.Size(160, 23)
		
		tp2GroupBox1.Location = new System.Drawing.Point(12, 16)
		tp2GroupBox1.TabIndex = 0
		tp2GroupBox1.TabStop = false
		tp2GroupBox1.Text = "Show video in:"
		tp2GroupBox1.Size = new System.Drawing.Size(202, 128)
		
		tabPage2.ImageIndex = 1
		tabPage2.TabIndex = 1
		tabPage2.Text = "Video"
		tabPage2.Size = new System.Drawing.Size(224, 191)
		tabPage2.Location = new System.Drawing.Point(4, 25)
		
		tabPage5.ImageIndex = 4
		tabPage5.TabIndex = 4
		tabPage5.Text = "Time"
		tabPage5.Size = new System.Drawing.Size(224, 191)
		tabPage5.Location = new System.Drawing.Point(4, 25)
		
		tabPage3.ImageIndex = 2
		tabPage3.TabIndex = 2
		tabPage3.Text = "Midi"
		tabPage3.Size = new System.Drawing.Size(224, 191)
		tabPage3.Location = new System.Drawing.Point(4, 25)
		
		tp3GroupBox1.Location = new System.Drawing.Point(12, 16)
		tp3GroupBox1.TabIndex = 0
		tp3GroupBox1.TabStop = false
		tp3GroupBox1.Text = "Midi Output"
		tp3GroupBox1.Size = new System.Drawing.Size(202, 160)
		
		tabPage1.ImageIndex = 0
		tabPage1.TabIndex = 0
		tabPage1.Text = "Audio"
		tabPage1.Size = new System.Drawing.Size(224, 191)
		tabPage1.Location = new System.Drawing.Point(4, 25)
		
		tp4GroupBox1.Controls.Add(tp4ComboBox1)
		tp4GroupBox1.Controls.Add(tp4UpDown1)
		tabPage4.Controls.Add(tp4GroupBox1)
		tabPage5.Controls.Add(tp5GroupBox1)
		tabPage2.Controls.Add(tp2GroupBox1)
		tabPage3.Controls.Add(tp3GroupBox1)
		tabPage1.Controls.Add(tp1GroupBox1)
		tp3GroupBox1.Controls.Add(tp3ComboBox2)
		tp3GroupBox1.Controls.Add(tp3Label1)
		tp3GroupBox1.Controls.Add(tp3RadioButton2)
		tp3GroupBox1.Controls.Add(tp3Button1)
		tp3GroupBox1.Controls.Add(tp3ComboBox1)
		tp3GroupBox1.Controls.Add(tp3RadioButton1)
		tp2GroupBox1.Controls.Add(tp2ComboBox1)
		tp2GroupBox1.Controls.Add(tp2RadioButton1)
		tp2GroupBox1.Controls.Add(tp2RadioButton2)
		tp5GroupBox1.Controls.Add(tp5DomainUpDown1)
		tabControl1.Controls.Add(tabPage1)
		tabControl1.Controls.Add(tabPage2)
		tabControl1.Controls.Add(tabPage4)
		tabControl1.Controls.Add(tabPage3)
		tabControl1.Controls.Add(tabPage5)
		tp1GroupBox1.Controls.Add(tp1Label1)
		tp1GroupBox1.Controls.Add(tp1Label2)
		tp1GroupBox1.Controls.Add(tp1Button1)
		tp1GroupBox1.Controls.Add(tp1ComboBox1)
		Me.Controls.Add(tabControl1)
		Me.Controls.Add(pictureBox1)
		Me.Controls.Add(groupBox1)
		groupBox1.Controls.Add(checkBox3)
		groupBox1.Controls.Add(label4)
		groupBox1.Controls.Add(trackBar)
		groupBox1.Controls.Add(label3)
		groupBox1.Controls.Add(label2)
		groupBox1.Controls.Add(label1)
		groupBox1.Controls.Add(sizeModeComboBox)
		groupBox1.Controls.Add(checkBox2)
		groupBox1.Controls.Add(alignmentComboBox)
		groupBox1.Controls.Add(appearanceComboBox)
		groupBox1.Controls.Add(checkBox1)
		
	End Sub


	End Class
    
    
    Sub Main
        System.WinForms.Application.Run(New TabControlCtl)
    End Sub


End Module



