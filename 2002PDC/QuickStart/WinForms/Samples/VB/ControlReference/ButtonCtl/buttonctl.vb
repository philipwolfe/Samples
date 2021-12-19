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
'namespace Microsoft.Samples.WinForms.Cs.ButtonCtl

    imports System
    imports System.ComponentModel
    imports System.WinForms
    imports System.Resources
    imports System.Drawing

    Option Explicit
    Option Strict Off
    ' <doc>
    ' <desc>
    '     This class demonstrates the Button control.
    ' </desc>
    ' </doc>
    '

    public Module ModMain

 
    ' <doc>
    ' <desc>
    '     This class defines the objects in the ComboBoxes that drive
    '     the properties of the Button style selection ComboBoxes.
    ' </desc>
    ' </doc>
    '
    public class ButtonCtl
    Inherits System.WinForms.Form

    Public Sub New()
        MyBase.New
        ' This call is required for support of the WinForms Form Designer.
       	InitializeComponent

            ' Set up combo-boxes

            cmbFlatStyle.Items.All = new Object() { _
                                new StringIntObject("Flat",FlatStyle.Flat), _
                                new StringIntObject("Popup",FlatStyle.Popup), _
                                new StringIntObject("Standard",FlatStyle.Standard)} 
            cmbFlatStyle.SelectedIndex = 0
	    

            cmbTextAlign.Items.All = new object() { _
                                new StringIntObject("Left",ContentAlignment.Left), _
                                new StringIntObject("Center",ContentAlignment.Center), _
                                new StringIntObject("Right",ContentAlignment.Right), _
                                new StringIntObject("Middle",ContentAlignment.Middle), _
                                new StringIntObject("Top",ContentAlignment.Top), _
                                new StringIntObject("Bottom",ContentAlignment.Bottom), _
                                new StringIntObject("TopLeft",ContentAlignment.TopLeft), _
                                new StringIntObject("TopCenter",ContentAlignment.TopCenter), _
                                new StringIntObject("TopRight",ContentAlignment.TopRight), _
                                new StringIntObject("MiddleLeft",ContentAlignment.MiddleLeft), _
                                new StringIntObject("MiddleCenter",ContentAlignment.MiddleCenter), _
                                new StringIntObject("MiddleRight",ContentAlignment.MiddleRight), _
                                new StringIntObject("BottomLeft",ContentAlignment.BottomLeft), _
                                new StringIntObject("BottomCenter",ContentAlignment.BottomCenter), _
                                new StringIntObject("BottomRight",ContentAlignment.BottomRight)} 
            cmbTextAlign.SelectedIndex = 1 

            cmbImageAlign.Items.All = cmbTextAlign.Items.All 
            cmbImageAlign.SelectedIndex = 0 

        end sub
        ' <doc>
        ' <desc>
        '     This class defines the objects in the ComboBoxes that drive
        '     the properties of the color selection ComboBoxes.
        '     Use this object to use erations with ComboBoxes and ListBoxes.
        '     Add the <paramref term='s'/> data member to the eration item's
        '     english description and the <paramref term='i'/> data member to the actual
        '     value of the eration item.
        '     The ToString() method will allow the ComboBox and ListBox controls to 
        '     display the text which represents the eration item.
        ' </desc>
        ' </doc>
        '
        private class StringIntObject

            public s as String
            public i as Integer

            public Sub New(sz as String, n as Integer)
		MyBase.New
                s=sz
                i=n
            End Sub

            OverRides Public Function ToString() as string
                ToString = s
            End Function

        End Class

    
        ' <doc>
        ' <desc>
        '     ButtonCtl overrides dispose so it can clean up the
        '     component list.
        ' </desc>
        ' </doc>
        '
        overrides public Sub Dispose()
            Mybase.Dispose()
            components.Dispose()
        end sub
    
        ' <doc>
        ' <desc>
        '     Handle the click event on the button
        ' </desc>
        ' </doc>
        '
        private Sub button1_Click(sender as object , e as EventArgs)
            MessageBox.Show("You pressed the test button") 
        end sub

    	private sub cmbImageAlign_SelectedIndexChanged(sender as object , e as EventArgs)
	        dim i as integer = cmbImageAlign.SelectedItem.i
                button1.ImageAlign = i 
	end sub
	
        private sub cmbTextAlign_SelectedIndexChanged(sender as object , e as EventArgs)
	        dim i as integer = cmbTextAlign.SelectedItem.i
            button1.TextAlign = i 
        end sub
	
        private sub cmbFlatStyle_SelectedIndexChanged(sender as object , e as EventArgs)
	        dim i as FlatStyle = cmbFlatStyle.SelectedItem.i
            button1.FlatStyle = i 
	end sub

        private sub chkImage_Click(sender as object , e as EventArgs)
            if (chkImage.Checked) then
'imageList1.Images.Add(resources.GetObject("time"))
'imageList1.Images.Add(System.Drawing.Image.FromFile("speaker.bmp"))
                button1.Image = resources.GetObject("button1.Image")
                cmbImageAlign.Enabled=true
            else
                button1.Image = nothing 
                cmbImageAlign.Enabled=false
            endif
	end sub
	
        private sub chkBGImage_Click(sender as object ,  e as EventArgs)
            if (chkBGImage.Checked) then
                button1.BackgroundImage = resources.GetObject("button1.BackgroundImage")
            else
                button1.BackgroundImage = nothing 
            endif
        end sub

            Private components as System.ComponentModel.Container 
	    Private chkImage as System.WinForms.CheckBox 
	    Private cmbImageAlign as System.WinForms.ComboBox 
	    Private label3 as System.WinForms.Label 
	    Private cmbTextAlign as System.WinForms.ComboBox 
	    Private label2 as System.WinForms.Label 
	    Private cmbFlatStyle as System.WinForms.ComboBox 
	    Private label1 as System.WinForms.Label 
	    Private chkBGImage as System.WinForms.CheckBox 
	    Private button1 as System.WinForms.Button 
	    Private panel1 as System.WinForms.Panel 
            Private grpBehavior as System.WinForms.GroupBox  
            Private resources as System.Resources.ResourceManager 


        ' NOTE: The following code is required by the Win Forms Form Designer
        ' It can be modified using the Win Forms Form Designer.  
        ' Do not modify it using the code editor.
        private Sub InitializeComponent()
		
		try
            		resources = new System.Resources.ResourceManager("ButtonCtl", Me.GetType, Nothing, true)

		catch Ex As Exception
			
			MessageBox.Show(Me,"Exception: " & Ex.Message)

		end try


    		me.components = new System.ComponentModel.Container()
    		me.chkImage = new System.WinForms.CheckBox()
    		me.grpBehavior = new System.WinForms.GroupBox()
    		me.cmbImageAlign = new System.WinForms.ComboBox()
    		me.label3 = new System.WinForms.Label()
    		me.label2 = new System.WinForms.Label()
    		me.label1 = new System.WinForms.Label()
    		me.cmbTextAlign = new System.WinForms.ComboBox()
    		me.cmbFlatStyle = new System.WinForms.ComboBox()
    		me.chkBGImage = new System.WinForms.CheckBox()
    		me.panel1 = new System.WinForms.Panel()
    		me.button1 = new System.WinForms.Button()
    		
    		chkImage.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
    		chkImage.Location = new System.Drawing.Point(16, 64)
    		chkImage.TabIndex = 7
    		chkImage.Text = "Display image"
    		chkImage.Size = new System.Drawing.Size(160, 24)
    		chkImage.AddOnClick(new System.EventHandler(AddressOf chkImage_Click))
    		
    		grpBehavior.Location = new System.Drawing.Point(248, 16)
    		grpBehavior.TabIndex = 0
    		grpBehavior.TabStop = false
    		grpBehavior.Text = "Button Properties"
    		grpBehavior.Size = new System.Drawing.Size(248, 352)
    		
    		cmbImageAlign.ForeColor = System.Drawing.Color.FromKnownColor(System.Drawing.KnownColor.WindowText)
    		cmbImageAlign.Location = new System.Drawing.Point(88, 216)
    		cmbImageAlign.TabIndex = 6
    		cmbImageAlign.Text = "comboBox1"
    		cmbImageAlign.Size = new System.Drawing.Size(144, 21)
    		cmbImageAlign.AddOnSelectedIndexChanged(new System.EventHandler(AddressOf cmbImageAlign_SelectedIndexChanged))
                cmbImageAlign.Enabled=false
                cmbImageAlign.Style = System.WinForms.ComboBoxStyle.DropDownList
    		
    		label3.Location = new System.Drawing.Point(16, 216)
    		label3.TabIndex = 5
    		label3.TabStop = false
    		label3.Text = "Image align:"
    		label3.Size = new System.Drawing.Size(64, 24)
    		
    		label2.Location = new System.Drawing.Point(16, 168)
    		label2.TabIndex = 3
    		label2.TabStop = false
    		label2.Text = "Text align:"
    		label2.Size = new System.Drawing.Size(64, 32)
    		
    		label1.Location = new System.Drawing.Point(16, 120)
    		label1.TabIndex = 1
    		label1.TabStop = false
    		label1.Text = "Flat style:"
    		label1.Size = new System.Drawing.Size(64, 16)
    		
    		me.AutoScaleBaseSize = new System.Drawing.Size(5, 13)
    		me.ClientSize = new System.Drawing.Size(504, 381)
    		me.Text = "Button"
    		
    		cmbTextAlign.ForeColor = System.Drawing.Color.FromKnownColor(System.Drawing.KnownColor.WindowText)
    		cmbTextAlign.Location = new System.Drawing.Point(88, 168)
    		cmbTextAlign.TabIndex = 4
    		cmbTextAlign.Text = "comboBox1"
    		cmbTextAlign.Size = new System.Drawing.Size(144, 21)
                cmbTextAlign.Style = System.WinForms.ComboBoxStyle.DropDownList
    		cmbTextAlign.AddOnSelectedIndexChanged(new System.EventHandler(AddressOf cmbTextAlign_SelectedIndexChanged))
    		
    		cmbFlatStyle.ForeColor = System.Drawing.Color.FromKnownColor(System.Drawing.KnownColor.WindowText)
    		cmbFlatStyle.Location = new System.Drawing.Point(88, 120)
    		cmbFlatStyle.TabIndex = 2
    		cmbFlatStyle.Text = "cmbFlatStyle"
    		cmbFlatStyle.Size = new System.Drawing.Size(144, 21)
    		cmbFlatStyle.AddOnSelectedIndexChanged(new System.EventHandler(AddressOf cmbFlatStyle_SelectedIndexChanged))
                cmbFlatStyle.Style = System.WinForms.ComboBoxStyle.DropDownList
    		
    		chkBGImage.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
    		chkBGImage.Location = new System.Drawing.Point(16, 32)
    		chkBGImage.TabIndex = 0
    		chkBGImage.Text = "Display background image"
    		chkBGImage.Size = new System.Drawing.Size(152, 24)
    		chkBGImage.AddOnClick(new System.EventHandler(AddressOf chkBGImage_Click))
    		
    		panel1.Location = new System.Drawing.Point(24, 40)
    		panel1.BackColor = System.Drawing.Color.FromKnownColor(System.Drawing.KnownColor.DarkGoldenrod)
    		panel1.TabIndex = 1
    		panel1.Text = "panel1"
    		panel1.Size = new System.Drawing.Size(200, 320)
    		
    		button1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
    		button1.Location = new System.Drawing.Point(32, 112)
    		button1.FlatStyle = System.WinForms.FlatStyle.Flat
    		button1.TabIndex = 0
    		button1.Text = "TestButton"
    		button1.Size = new System.Drawing.Size(136, 56)
    		button1.AddOnClick(new System.EventHandler(AddressOf button1_Click))
    		
    		me.Controls.Add(panel1)
    		me.Controls.Add(grpBehavior)
    		panel1.Controls.Add(button1)
    		grpBehavior.Controls.Add(chkImage)
    		grpBehavior.Controls.Add(cmbImageAlign)
    		grpBehavior.Controls.Add(cmbTextAlign)
    		grpBehavior.Controls.Add(label2)
    		grpBehavior.Controls.Add(cmbFlatStyle)
    		grpBehavior.Controls.Add(label1)
    		grpBehavior.Controls.Add(chkBGImage)
    		grpBehavior.Controls.Add(label3)
    		
    	end sub
   end class


        ' The main entry point for the application.
        public sub Main()
            Application.Run(new ButtonCtl())
        end sub

end Module






