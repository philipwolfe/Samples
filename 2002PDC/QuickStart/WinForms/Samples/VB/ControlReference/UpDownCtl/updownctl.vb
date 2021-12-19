'=====================================================================
'  File:     UpDownCtl.Vb
'
'  Summary:   This sample demonstrates the basic functionality of the
'             NumericUpDown and DomainUpDown controls.
'
'---------------------------------------------------------------------
'  This file is part of the Microsoft COM+ 2.0 SDK Code Samples.
'
'  Copyright (C) 1999 Microsoft Corporation.  All rights reserved.
'
'This source code is intended only as a supplement to Microsoft
'Development Tools and/or on-line documentation.  See these other
'materials for detailed information regarding Microsoft code samples.
'
'THIS CODE AND INFORMATION ARE PROVIDED "AS IS" WITHOUT WARRANTY OF ANY
'KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE
'IMPLIED WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A
'PARTICULAR PURPOSE.
'=====================================================================*/

Imports System
Imports System.Collections
Imports System.ComponentModel
Imports System.Drawing
Imports System.WinForms

Option Explicit
Option Strict Off

Namespace Microsoft.Samples.WinForms.Vb.UpDownCtl 


    ' <doc>
    ' <desc>
    '     This sample demonstrates how to use NumericUpDown and DomainUpDown controls
    ' </desc>
    ' </doc>
    '
    public class UpDownCtl
    inherits System.WinForms.Form 

        public Sub New()
	    mybase.New() 
            
            ' This call is required for support of the WFC Form Designer
            InitializeComponent()		

            'Complete intialization of the Form
            Me.updnTextAlign.Items.Add(new StringIntObject("Center",HorizontalAlignment.Center))
            Me.updnTextAlign.Items.Add(new StringIntObject("Left",HorizontalAlignment.Left))
            Me.updnTextAlign.Items.Add(new StringIntObject("Right",HorizontalAlignment.Right))
            Me.updnTextAlign.SelectedIndex = 1
            
            Me.updnUpDownAlignment.Items.Add(new StringIntObject("Left",LeftRightAlignment.Left))
            Me.updnUpDownAlignment.Items.Add(new StringIntObject("Right",LeftRightAlignment.Right))
            Me.updnUpDownAlignment.SelectedIndex = 1
            
            Me.domainUpDown1.Items.Add("King Kong")
            Me.domainUpDown1.Items.Add("The Creature from the Black Lagoon")
            Me.domainUpDown1.Items.Add("Dracula")
            Me.domainUpDown1.Items.Add("Frankenstein's Monster")
            Me.domainUpDown1.Items.Add("Godzilla")
            Me.domainUpDown1.SelectedIndex = 0

            Me.updnDecimalPlaces.DecimalPlaces = 0
        end sub

        ' <doc>
        ' <desc>
        '     UpDownCtl overrides dispose so it can clean up the
        '     component list.
        ' </desc>
        ' </doc>
        '
        overrides public Sub Dispose() 
            mybase.Dispose()
            components.Dispose()
        end sub

        private Sub updnUpDownAlignment_SelectedItemChanged(sender As Object, e As EventArgs) 
            Dim sio As StringIntObject = updnUpDownAlignment.Items(updnUpDownAlignment.SelectedIndex) 
            numericUpDown1.UpDownAlign = sio.i
            domainUpDown1.UpDownAlign = sio.i
        end sub

        private Sub updnTextAlign_SelectedItemChanged(sender As Object, e As EventArgs) 
            Dim sio As StringIntObject = updnTextAlign.Items(updnTextAlign.SelectedIndex) 
            numericUpDown1.TextAlign = sio.i
            domainUpDown1.TextAlign = sio.i
        end sub

        private Sub chkInterceptArrowKeys_CheckedChanged(sender As Object, e As EventArgs) 
            numericUpDown1.InterceptArrowKeys = chkInterceptArrowKeys.Checked
            domainUpDown1.InterceptArrowKeys = chkInterceptArrowKeys.Checked
        end sub

        private Sub chkSorted_CheckedChanged(sender As Object, e As EventArgs) 
            domainUpDown1.Sorted = chkSorted.Checked
        end sub

        private Sub chkWrap_CheckedChanged(sender As Object, e As EventArgs) 
            domainUpDown1.Wrap = chkWrap.Checked
        end sub

        private Sub updnIncrement_ValueChanged(sender As Object, e As EventArgs) 
           numericUpDown1.Increment = updnIncrement.Value
        end sub

        private Sub updnDecimalPlaces_ValueChanged(sender As Object, e As EventArgs) 
            numericUpDown1.DecimalPlaces = updnDecimalPlaces.Value
            updnIncrement.Value = updnIncrement.Value  ' Just so we don't increment by amounts we can't see.
            updnIncrement.DecimalPlaces = updnDecimalPlaces.Value
        end sub


        ' NOTE: The following code is required by the WFC Form Designer
        ' It can be modified using the WFC Form Designer.  
        ' Do not modify it using the code editor.
    	private components As System.ComponentModel.Container 
        private updnUpDownAlignment As System.WinForms.DomainUpDown  
        private updnTextAlign As System.WinForms.DomainUpDown 
        private lblIncrement As System.WinForms.Label 
        private updnIncrement As System.WinForms.NumericUpDown 
        private lblDecimalPlaces As System.WinForms.Label 
        private updnDecimalPlaces As System.WinForms.NumericUpDown 
        private chkSorted As System.WinForms.CheckBox 
        private lblUpDownAlignment As System.WinForms.Label 
        private lblTextAlign As System.WinForms.Label 

        private chkInterceptArrowKeys As System.WinForms.CheckBox 
        private chkWrap As System.WinForms.CheckBox 
        private grpCommonProperties As System.WinForms.GroupBox 
        private numericUpDown1 As System.WinForms.NumericUpDown 
        private domainUpDown1 As System.WinForms.DomainUpDown 
        private grpDomainUpDown As System.WinForms.GroupBox 
        private grpNumericUpDown As System.WinForms.GroupBox 

    	private Sub InitializeComponent() 
            Me.components = new System.ComponentModel.Container()
            Me.grpDomainUpDown = new System.WinForms.GroupBox()
            Me.updnDecimalPlaces = new System.WinForms.NumericUpDown()
            Me.chkWrap = new System.WinForms.CheckBox()
            Me.grpNumericUpDown = new System.WinForms.GroupBox()
            Me.chkSorted = new System.WinForms.CheckBox()
            Me.lblUpDownAlignment = new System.WinForms.Label()
            Me.lblIncrement = new System.WinForms.Label()
            Me.chkInterceptArrowKeys = new System.WinForms.CheckBox()
            Me.grpCommonProperties = new System.WinForms.GroupBox()
            Me.lblTextAlign = new System.WinForms.Label()
            Me.domainUpDown1 = new System.WinForms.DomainUpDown()
            Me.updnTextAlign = new System.WinForms.DomainUpDown()
            Me.updnIncrement = new System.WinForms.NumericUpDown()
            Me.lblDecimalPlaces = new System.WinForms.Label()
            Me.updnUpDownAlignment = new System.WinForms.DomainUpDown()
            Me.numericUpDown1 = new System.WinForms.NumericUpDown()

            grpDomainUpDown.Location = new System.Drawing.Point(280, 24)
            grpDomainUpDown.TabIndex = 1
            grpDomainUpDown.TabStop = false
            grpDomainUpDown.Text = "DomainUpDown"
            grpDomainUpDown.Size = new System.Drawing.Size(208, 176)

            updnDecimalPlaces.Location = new System.Drawing.Point(152, 80)
            updnDecimalPlaces.Maximum = new System.Decimal(10d)
            updnDecimalPlaces.Minimum = new System.Decimal(0d)
            updnDecimalPlaces.DecimalPlaces = 0
            updnDecimalPlaces.TabIndex = 1
            updnDecimalPlaces.Text = "2"
            updnDecimalPlaces.Size = new System.Drawing.Size(56, 23)
            updnDecimalPlaces.AddOnValueChanged(new EventHandler(AddressOf Me.updnDecimalPlaces_ValueChanged))

            chkWrap.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            chkWrap.Location = new System.Drawing.Point(32, 80)
            chkWrap.TabIndex = 1
            chkWrap.Text = "Wrap"
            chkWrap.Size = new System.Drawing.Size(104, 24)
            chkWrap.AddOnCheckedChanged(new EventHandler(AddressOf Me.chkWrap_CheckedChanged))

            grpNumericUpDown.Location = new System.Drawing.Point(16, 24)
            grpNumericUpDown.TabIndex = 0
            grpNumericUpDown.TabStop = false
            grpNumericUpDown.Text = "NumericUpDown"
            grpNumericUpDown.Size = new System.Drawing.Size(232, 176)

            chkSorted.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            chkSorted.Location = new System.Drawing.Point(32, 120)
            chkSorted.TabIndex = 2
            chkSorted.Text = "Sorted"
            chkSorted.Size = new System.Drawing.Size(104, 24)
            chkSorted.AddOnCheckedChanged(new EventHandler(AddressOf Me.chkSorted_CheckedChanged))

            lblUpDownAlignment.Location = new System.Drawing.Point(16, 64)
            lblUpDownAlignment.TabIndex = 2
            lblUpDownAlignment.TabStop = false
            lblUpDownAlignment.Text = "UpDownAlignment"
            lblUpDownAlignment.Size = new System.Drawing.Size(120, 24)

            lblIncrement.Location = new System.Drawing.Point(32, 120)
            lblIncrement.TabIndex = 4
            lblIncrement.TabStop = false
            lblIncrement.Text = "Increment"
            lblIncrement.Size = new System.Drawing.Size(72, 24)

            chkInterceptArrowKeys.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            chkInterceptArrowKeys.Location = new System.Drawing.Point(304, 32)
            chkInterceptArrowKeys.TabIndex = 0
            chkInterceptArrowKeys.CheckState = System.WinForms.CheckState.Checked
            chkInterceptArrowKeys.Text = "InterceptArrowKeys"
            chkInterceptArrowKeys.Size = new System.Drawing.Size(144, 24)
            chkInterceptArrowKeys.Checked = true
            chkInterceptArrowKeys.AddOnCheckedChanged(new EventHandler(AddressOf Me.chkInterceptArrowKeys_CheckedChanged))

            grpCommonProperties.Location = new System.Drawing.Point(16, 224)
            grpCommonProperties.TabIndex = 2
            grpCommonProperties.TabStop = false
            grpCommonProperties.Text = "CommonProperties"
            grpCommonProperties.Size = new System.Drawing.Size(472, 112)

            lblTextAlign.Location = new System.Drawing.Point(16, 32)
            lblTextAlign.TabIndex = 1
            lblTextAlign.TabStop = false
            lblTextAlign.Text = "TextAlign"
            lblTextAlign.Size = new System.Drawing.Size(120, 24)

            domainUpDown1.Location = new System.Drawing.Point(32, 32)
            domainUpDown1.TabIndex = 0
            domainUpDown1.Size = new System.Drawing.Size(96, 23)

            updnTextAlign.Location = new System.Drawing.Point(152, 32)
            updnTextAlign.TabIndex = 3
            updnTextAlign.Size = new System.Drawing.Size(120, 23)
            updnTextAlign.AddOnSelectedItemChanged(new EventHandler(AddressOf Me.updnTextAlign_SelectedItemChanged))

            updnIncrement.Location = new System.Drawing.Point(152, 120)
            updnIncrement.Maximum = new System.Decimal(100d)
            updnIncrement.Minimum = new System.Decimal(1d)
            updnIncrement.TabIndex = 2
            updnIncrement.DecimalPlaces = 0
            updnIncrement.Text = "1"
            updnIncrement.Size = new System.Drawing.Size(56, 23)
            updnIncrement.AddOnValueChanged(new EventHandler(AddressOf Me.updnIncrement_ValueChanged))

            Me.AutoScaleBaseSize = new System.Drawing.Size(6, 16)
            Me.ClientSize = new System.Drawing.Size(504, 352)
            Me.Text = "UpDownCtlForm"

            lblDecimalPlaces.Location = new System.Drawing.Point(32, 80)
            lblDecimalPlaces.TabIndex = 3
            lblDecimalPlaces.TabStop = false
            lblDecimalPlaces.Text = "DecimalPlaces"
            lblDecimalPlaces.Size = new System.Drawing.Size(96, 24)

            updnUpDownAlignment.Location = new System.Drawing.Point(152, 64)
            updnUpDownAlignment.TabIndex = 4
            updnUpDownAlignment.Size = new System.Drawing.Size(120, 23)
            updnUpDownAlignment.AddOnSelectedItemChanged(new EventHandler(AddressOf Me.updnUpDownAlignment_SelectedItemChanged))

            numericUpDown1.Location = new System.Drawing.Point(32, 32)
            numericUpDown1.Maximum = new System.Decimal(100d)
            numericUpDown1.Minimum = new System.Decimal(0d)
            numericUpDown1.TabIndex = 0
            numericUpDown1.DecimalPlaces = 2
            numericUpDown1.Text = "0.00"
            numericUpDown1.Size = new System.Drawing.Size(104, 23)

            Me.Controls.Add(grpCommonProperties)
            Me.Controls.Add(grpDomainUpDown)
            Me.Controls.Add(grpNumericUpDown)
            grpCommonProperties.Controls.Add(updnUpDownAlignment)
            grpCommonProperties.Controls.Add(updnTextAlign)
            grpCommonProperties.Controls.Add(lblUpDownAlignment)
            grpCommonProperties.Controls.Add(lblTextAlign)
            grpCommonProperties.Controls.Add(chkInterceptArrowKeys)
            grpNumericUpDown.Controls.Add(lblIncrement)
            grpNumericUpDown.Controls.Add(updnIncrement)
            grpNumericUpDown.Controls.Add(lblDecimalPlaces)
            grpNumericUpDown.Controls.Add(updnDecimalPlaces)
            grpNumericUpDown.Controls.Add(numericUpDown1)
            grpDomainUpDown.Controls.Add(chkSorted)
            grpDomainUpDown.Controls.Add(chkWrap)
            grpDomainUpDown.Controls.Add(domainUpDown1)
        end sub

        ' <doc>
        ' <desc>
        '        The main entry point for the application. 
        ' </desc>
        ' <param term='args'>
        '        Array of parameters passed to the application via the command line.
        ' </param>
        ' </doc>
        '
        public shared Sub Main() 
            Application.Run(new UpDownCtl())
        end sub

        ' <doc>
        ' <desc>
        '     This class defines the objects in the DomainUpDown controls that drive
        '     the properties of the UpDown controls ComboBoxes.
        ' </desc>
        ' </doc>
        '
        private class StringIntObject 
            public s As string 
            public i As integer

            public Sub New(sz As String, n As Integer) 
		MyBase.New()
                s=sz
                i=n
            end sub

            overrides public Function ToString() As String
                return s
            end Function
        end class

    End class

End Namespace

