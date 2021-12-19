'=====================================================================
'  File:      DateTimePickerCtl.vb
'
'  Summary:   This sample demonstrates the properties and features
'             of the DateTimePicker control.
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
Imports System.ComponentModel
Imports System.Drawing
Imports System.WinForms

Imports Microsoft.VisualBasic.ControlChars

Option Explicit

Namespace DateTimePickerCtl 


    ' <doc>
    ' <desc>
    '     This sample control demonstrates various properties and
    '     methods for the DateTimePicker control.  Users should
    '     play with the various controls and then look at the code
    '     behind the behaviors that are most interesting.
    ' </desc>
    ' </doc>
    '
    public class DateTimePickerCtl
    Inherits System.WinForms.Form 

        private components As System.ComponentModel.Container 
        private groupBox1 As System.WinForms.GroupBox 
        private label1 As System.WinForms.Label 
        private label2 As System.WinForms.Label 
        private label4 As System.WinForms.Label 
        private dateTimePicker As System.WinForms.DateTimePicker 
        private dtpMinDate As System.WinForms.DateTimePicker 
        private dtpMaxDate As System.WinForms.DateTimePicker 
        private chkShowUpDown As System.WinForms.CheckBox 
        private cmbFormat As System.WinForms.ComboBox 
        private btnChangeFont As System.WinForms.Button 
        private btnChangeColor As System.WinForms.Button 
        private fontDialog As System.WinForms.FontDialog 
        private toolTip1 As System.WinForms.ToolTip 

        ' <doc>
        ' <desc>
        '     Public Constructor
        ' </desc>
        ' </doc>
        '
        public Sub New()
             	
	    MyBase.New()

            ' This call is required for support of the Win Forms Form Designer.
            InitializeComponent()

            ' Make sure that we are starting in Long date format
            dateTimePicker.Format = DateTimePickerFormats.Long
            cmbFormat.SelectedIndex = 0

            ' Initialize the control values
            Dim now As DateTime = DateTime.Now
            dateTimePicker.Value = now
            dtpMaxDate.Value = now.AddDays(30)
            dtpMinDate.Value = now.AddDays(-30)
            dateTimePicker.MaxDate = dtpMaxDate.Value
            dateTimePicker.MinDate = dtpMinDate.Value
        End Sub


        ' <doc>
        ' <desc>
        '     DateTimePickerCtl overrides dispose so it can clean up the
        '     component list.
        ' </desc>
        ' </doc>
        '
        Overrides Public Sub Dispose() 
            myBase.Dispose()
            components.Dispose()
        End Sub

        ' <doc>
        ' <desc>
        '     Return the DateTimePicker control - used by the 
        '     ChangeColorDlg
        ' </desc>
        ' </doc>
        '
        Public ReadOnly Property DTPicker As DateTimePicker 
            get 
                return dateTimePicker
            end get
        end Property

        Private Sub btnChangeFont_Click(sender As Object, e As EventArgs) 
            fontDialog.ShowDialog()
            Dim newFont As Font = fontDialog.Font
            dateTimePicker.Font = newFont
        End Sub

        Private Sub btnChangeColor_Click(sender As Object, e As EventArgs)
            Dim dlg As new ChangeColorDlg(Me)
            dlg.ShowDialog()
        End Sub

        private Sub dtpMinDate_ValueChanged(sender As Object, e As EventArgs) 
            dateTimePicker.MinDate = dtpMinDate.Value
        End Sub

        private Sub dtpMaxDate_ValueChanged(sender As Object, e As EventArgs) 
            dateTimePicker.MaxDate = dtpMaxDate.Value
        End Sub
                               
        private Sub cmbFormat_SelectedIndexChanged(sender As Object, e As EventArgs) 
            if (cmbFormat.SelectedIndex < 0) Then return

            Dim firstChar As Char = cmbFormat.SelectedItem.ToString().Chars(0)
            Dim format As DateTimePickerFormats
            Select Case (firstChar) 
                case Convert.ToChar("S")
                    format = DateTimePickerFormats.Short
                case Convert.ToChar("T")
                    format = DateTimePickerFormats.Time
                case Convert.ToChar("C")
                    format = DateTimePickerFormats.Custom
                case else
                    format = DateTimePickerFormats.Long
		End Select	
            dateTimePicker.Format = format
        End Sub

        private Sub chkShowUpDown_Click(sender As Object, e As EventArgs) 
            Dim showUpDown As Boolean = chkShowUpDown.Checked
            Me.dateTimePicker.ShowUpDown = showUpDown

            btnChangeColor.Enabled = Not showUpDown
            btnChangeFont.Enabled = Not showUpDown
        End Sub

        ' NOTE: The following code is required by the Win Forms Form Designer
        ' It can be modified using the Win Forms Form Designer.  
        ' Do not modify it using the code editor.
        private Sub InitializeComponent() 
		Me.components = new System.ComponentModel.Container()
		Me.label4 = new System.WinForms.Label()
		Me.dtpMinDate = new System.WinForms.DateTimePicker()
		Me.cmbFormat = new System.WinForms.ComboBox()
		Me.groupBox1 = new System.WinForms.GroupBox()
		Me.label2 = new System.WinForms.Label()
		Me.label1 = new System.WinForms.Label()
		Me.toolTip1 = new System.WinForms.ToolTip(components)
		Me.btnChangeFont = new System.WinForms.Button()
		Me.chkShowUpDown = new System.WinForms.CheckBox()
		Me.fontDialog = new System.WinForms.FontDialog()
		Me.btnChangeColor = new System.WinForms.Button()
		Me.dtpMaxDate = new System.WinForms.DateTimePicker()
		Me.dateTimePicker = new System.WinForms.DateTimePicker()
		
		label4.TabIndex = 0
		label4.Size = new System.Drawing.Size(64, 16)
		label4.TabStop = false
		label4.Location = new System.Drawing.Point(16, 104)
		label4.Text = "Format:"
		
		dtpMinDate.Location = new System.Drawing.Point(128, 48)
		dtpMinDate.TabIndex = 6
		dtpMinDate.ValueSet = true
		dtpMinDate.Format = System.WinForms.DateTimePickerFormats.Short
		dtpMinDate.Size = new System.Drawing.Size(104, 21)
		toolTip1.SetToolTip(dtpMinDate, _
			"The value indicating the first date that" & CrLf & _
			"the control allows the user to select")
		dtpMinDate.AddOnValueChanged(new EventHandler(AddressOf dtpMinDate_ValueChanged))
		
		cmbFormat.ForeColor = System.Drawing.Color.FromKnownColor(System.Drawing.KnownColor.WindowText)
		cmbFormat.Location = new System.Drawing.Point(128, 96)
		cmbFormat.Style = System.WinForms.ComboBoxStyle.DropDownList
		cmbFormat.TabIndex = 7
		cmbFormat.Text = ""
		cmbFormat.Size = new System.Drawing.Size(104, 21)
		toolTip1.SetToolTip(cmbFormat, _
			"A value indicating the whether the control displays date and time" & CrLf & _
			"information in long date Format(for example, ""Wednesday, April 7, 1999"")," & CrLf & _
			"short date Format(for example, ""4/7/99""), time Format(for example," & CrLf & _
			"""5:31:34 PM""), or custom format.")
		cmbFormat.AddOnSelectedIndexChanged(new EventHandler(AddressOf cmbFormat_SelectedIndexChanged))
		cmbFormat.Items.All = new object() {"Long", "Short", "Time", "Custom"}
		
		groupBox1.TabIndex = 0
		groupBox1.Size = new System.Drawing.Size(248, 264)
		groupBox1.TabStop = false
		groupBox1.Location = new System.Drawing.Point(248, 16)
		groupBox1.Text = "DateTimePicker"
		
		Me.TabIndex = 0
		Me.Size = new System.Drawing.Size(512, 320)
		Me.Text = "DateTimePicker"
		
		label2.TabIndex = 1
		label2.Size = new System.Drawing.Size(96, 16)
		label2.TabStop = false
		label2.Location = new System.Drawing.Point(16, 80)
		label2.Text = "MaxDate:"
		
		label1.TabIndex = 3
		label1.Size = new System.Drawing.Size(80, 16)
		label1.TabStop = false
		label1.Location = new System.Drawing.Point(16, 56)
		label1.Text = "MinDate:"
		
		toolTip1.Active = true
		'@design toolTip1.SetLocation(new System.Drawing.Point(20, 40))
		
		btnChangeFont.Location = new System.Drawing.Point(16, 168)
		btnChangeFont.TabIndex = 5
		btnChangeFont.Text = "Change &Font"
		btnChangeFont.Size = new System.Drawing.Size(75, 23)
		btnChangeFont.AddOnClick(new EventHandler(AddressOf btnChangeFont_Click))
		
		chkShowUpDown.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
		chkShowUpDown.Location = new System.Drawing.Point(16, 24)
		chkShowUpDown.TabIndex = 8
		chkShowUpDown.Text = "ShowUpDown"
		chkShowUpDown.Size = new System.Drawing.Size(100, 23)
		chkShowUpDown.AddOnClick(new EventHandler(AddressOf chkShowUpDown_Click))
		
		'@design fontDialog.SetLocation(new System.Drawing.Point(20, 10))
		
		btnChangeColor.Location = new System.Drawing.Point(96, 168)
		btnChangeColor.TabIndex = 2
		btnChangeColor.Text = "Change &Color"
		btnChangeColor.Size = new System.Drawing.Size(80, 23)
		btnChangeColor.AddOnClick(new EventHandler(AddressOf btnChangeColor_Click))
		
		dtpMaxDate.Location = new System.Drawing.Point(128, 72)
		dtpMaxDate.TabIndex = 4
		dtpMaxDate.ValueSet = true
		dtpMaxDate.Format = System.WinForms.DateTimePickerFormats.Short
		dtpMaxDate.Size = new System.Drawing.Size(104, 21)
		toolTip1.SetToolTip(dtpMaxDate, _
			"The value indicating the last date that " & CrLf & _
			"the control allows the user to select")
		dtpMaxDate.AddOnValueChanged(new EventHandler(AddressOf dtpMaxDate_ValueChanged))
		
		dateTimePicker.Location = new System.Drawing.Point(24, 24)
		dateTimePicker.TabIndex = 1
		dateTimePicker.ValueSet = true
		dateTimePicker.Format = System.WinForms.DateTimePickerFormats.Long
		dateTimePicker.Size = new System.Drawing.Size(200, 21)
		dateTimePicker.CustomFormat = "\'The date is: \'yy MM d - HH\':\'mm\':\'s ddd"
		
		groupBox1.Controls.Add(chkShowUpDown)
		groupBox1.Controls.Add(btnChangeFont)
		groupBox1.Controls.Add(btnChangeColor)
		groupBox1.Controls.Add(dtpMaxDate)
		groupBox1.Controls.Add(dtpMinDate)
		groupBox1.Controls.Add(label4)
		groupBox1.Controls.Add(label2)
		groupBox1.Controls.Add(label1)
		groupBox1.Controls.Add(cmbFormat)
		Me.Controls.Add(dateTimePicker)
		Me.Controls.Add(groupBox1)
		
	End Sub

        ' The main entry point for the application.
        public Shared Sub Main() 
            Application.Run(new DateTimePickerCtl())
        End Sub


    End Class

End Namespace





