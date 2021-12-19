'=====================================================================
'  File:      ChangeColorDlg.vb
'
'  Summary:   This form is used to customise the DateTime picker
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

Option Explicit

Namespace DateTimePickerCtl 


    ' <doc>
    ' <desc>
    '     This form is used to customise the DateTime picker 
    '     It demonstrates how to use the common color dialog
    ' </desc>
    ' </doc>
    '
    Public class ChangeColorDlg
    Inherits System.WinForms.Form 
        Private dtp As DateTimePicker 

        ' <doc>
        ' <desc>
        '     Public Constructor
        ' </desc>
        ' </doc>
        '
        Public Sub New(parent As DateTimePickerCtl)
	    myBase.New()
            
            ' This call is required for support of the Win Forms Form Designer.
            InitializeComponent()

            dtp = parent.DTPicker

            SynchronizePanelColors()
        End Sub

        ' <doc>
        ' <desc>
        '     Make sure that the color display panels are displaying the 
        '     Color used by the date time picker
        ' </desc>
        ' </doc>
        '
        Private Sub SynchronizePanelColors() 
            pnlForeColor.BackColor = dtp.CalendarForeColor
            pnlMonthBackground.BackColor = dtp.CalendarMonthBackground
            pnlTitleBackColor.BackColor = dtp.CalendarTitleBackColor
            pnlTitleForeColor.BackColor = dtp.CalendarTitleForeColor
            pnlTrailingForeColor.BackColor = dtp.CalendarTrailingForeColor
        End Sub

        ' <doc>
        ' <desc>
        '     ChangeColorDlg overrides dispose so it can clean up the
        '     component list.
        ' </desc>
        ' </doc>
        '
        Overrides Public Sub Dispose() 
            MyBase.Dispose()
            components.Dispose()
        End Sub

        Private Sub btnForeColor_Click(sender As Object, e As EventArgs) 
            colorDialog.Color = dtp.CalendarForeColor
            Dim res As DialogResult = colorDialog.ShowDialog()
            If (res = System.WinForms.DialogResult.OK) Then
                dtp.CalendarForeColor = colorDialog.Color
                SynchronizePanelColors()
            End If
        End Sub

        Private Sub btnMonthBackground_Click(sender As Object, e As EventArgs) 
            colorDialog.Color = dtp.CalendarMonthBackground
            Dim res As DialogResult = colorDialog.ShowDialog()
            If (res = System.WinForms.DialogResult.OK) Then
                dtp.CalendarMonthBackground = colorDialog.Color
                SynchronizePanelColors()
            End If
        End Sub

        Private Sub btnTitleBackColor_Click(sender As Object, e As EventArgs) 
            colorDialog.Color = dtp.CalendarTitleBackColor
            Dim res As DialogResult = colorDialog.ShowDialog()
            If (res = System.WinForms.DialogResult.OK) Then
                dtp.CalendarTitleBackColor = colorDialog.Color
                SynchronizePanelColors()
            End If
        End Sub

        Private Sub btnTitleForeColor_Click(sender As Object, e As EventArgs) 
            colorDialog.Color = dtp.CalendarTitleForeColor
            Dim res As DialogResult = colorDialog.ShowDialog()
            If (res = System.WinForms.DialogResult.OK) Then
                dtp.CalendarTitleForeColor = colorDialog.Color
                SynchronizePanelColors()
            End If
        End Sub

        Private Sub btnTrailingForeColor_Click(sender As Object, e As EventArgs) 
            colorDialog.Color = dtp.CalendarTrailingForeColor
            Dim res As DialogResult = colorDialog.ShowDialog()
            If (res = System.WinForms.DialogResult.OK) Then
                dtp.CalendarTrailingForeColor = colorDialog.Color
                SynchronizePanelColors()
            End If
        End Sub

        ' NOTE: The following code is required by the Win Forms Form Designer
        ' It can be modified using the Win Forms Form Designer.  
        ' Do not modify it using the code editor.
        private components As System.ComponentModel.Container 
        private label1 As System.WinForms.Label 
        private label2 As System.WinForms.Label 
        private label3 As System.WinForms.Label 
        private label4 As System.WinForms.Label 
        private label5 As System.WinForms.Label 
        private btnOk As System.WinForms.Button 
        private pnlForeColor As System.WinForms.Panel 
        private pnlMonthBackground As System.WinForms.Panel 
        private pnlTitleBackColor As System.WinForms.Panel 
        private pnlTitleForeColor As System.WinForms.Panel 
        private pnlTrailingForeColor As System.WinForms.Panel 
        private btnForeColor As System.WinForms.Button 
        private btnMonthBackground As System.WinForms.Button 
        private btnTitleBackColor As System.WinForms.Button
        private btnTitleForeColor As System.WinForms.Button 
        private btnTrailingForeColor As System.WinForms.Button 
        private colorDialog As System.WinForms.ColorDialog 

        Private Sub InitializeComponent() 
            Me.components = new System.ComponentModel.Container()
            Me.label1 = new System.WinForms.Label()
            Me.label2 = new System.WinForms.Label()
            Me.label3 = new System.WinForms.Label()
            Me.label4 = new System.WinForms.Label()
            Me.label5 = new System.WinForms.Label()
            Me.btnOK = new System.WinForms.Button()
            Me.pnlForeColor = new System.WinForms.Panel()
            Me.pnlMonthBackground = new System.WinForms.Panel()
            Me.pnlTitleBackColor = new System.WinForms.Panel()
            Me.pnlTitleForeColor = new System.WinForms.Panel()
            Me.pnlTrailingForeColor = new System.WinForms.Panel()
            Me.btnForeColor = new System.WinForms.Button()
            Me.btnMonthBackground = new System.WinForms.Button()
            Me.btnTitleBackColor = new System.WinForms.Button()
            Me.btnTitleForeColor = new System.WinForms.Button()
            Me.btnTrailingForeColor = new System.WinForms.Button()
            Me.colorDialog = new ColorDialog()

            Me.Text = "Change Color"
            Me.AutoScaleBaseSize = new System.Drawing.Size(5, 13)
            Me.BorderStyle = System.WinForms.FormBorderStyle.FixedDialog
            Me.ClientSize = new System.Drawing.Size(406, 194)
            Me.MaximizeBox = false
            Me.MinimizeBox = false

            label1.Location = new System.Drawing.Point(16, 19)
            label1.Size = new System.Drawing.Size(136, 16)
            label1.TabIndex = 8
            label1.TabStop = false
            label1.Text = "CalendarForeColor:"

            label2.Location = new System.Drawing.Point(16, 43)
            label2.Size = new System.Drawing.Size(136, 16)
            label2.TabIndex = 7
            label2.TabStop = false
            label2.Text = "CalendarMonthBackground:"

            label3.Location = new System.Drawing.Point(16, 67)
            label3.Size = new System.Drawing.Size(136, 16)
            label3.TabIndex = 6
            label3.TabStop = false
            label3.Text = "CalendarTitleBackColor:"

            label4.Location = new System.Drawing.Point(16, 91)
            label4.Size = new System.Drawing.Size(136, 16)
            label4.TabIndex = 5
            label4.TabStop = false
            label4.Text = "CalendarTitleForeColor:"

            label5.Location = new System.Drawing.Point(16, 115)
            label5.Size = new System.Drawing.Size(136, 16)
            label5.TabIndex = 4
            label5.TabStop = false
            label5.Text = "CalendarTrailingForeColor:"

            btnOK.Location = new System.Drawing.Point(320, 160)
            btnOK.Size = new System.Drawing.Size(75, 23)
            btnOK.TabIndex = 9
            btnOK.Text = "&OK"
            btnOK.DialogResult = System.WinForms.DialogResult.OK

            pnlForeColor.Location = new System.Drawing.Point(160, 19)
            pnlForeColor.Size = new System.Drawing.Size(48, 16)
            pnlForeColor.TabIndex = 10
            pnlForeColor.Text = "panel1"
            pnlForeColor.BorderStyle = System.WinForms.BorderStyle.Fixed3D

            pnlMonthBackground.Location = new System.Drawing.Point(160, 43)
            pnlMonthBackground.Size = new System.Drawing.Size(48, 16)
            pnlMonthBackground.TabIndex = 3
            pnlMonthBackground.Text = "panel1"
            pnlMonthBackground.BorderStyle = System.WinForms.BorderStyle.Fixed3D

            pnlTitleBackColor.Location = new System.Drawing.Point(160, 67)
            pnlTitleBackColor.Size = new System.Drawing.Size(48, 16)
            pnlTitleBackColor.TabIndex = 2
            pnlTitleBackColor.Text = "panel1"
            pnlTitleBackColor.BorderStyle = System.WinForms.BorderStyle.Fixed3D

            pnlTitleForeColor.Location = new System.Drawing.Point(160, 91)
            pnlTitleForeColor.Size = new System.Drawing.Size(48, 16)
            pnlTitleForeColor.TabIndex = 1
            pnlTitleForeColor.Text = "panel1"
            pnlTitleForeColor.BorderStyle = System.WinForms.BorderStyle.Fixed3D

            pnlTrailingForeColor.Location = new System.Drawing.Point(160, 115)
            pnlTrailingForeColor.Size = new System.Drawing.Size(48, 16)
            pnlTrailingForeColor.TabIndex = 0
            pnlTrailingForeColor.Text = "panel1"
            pnlTrailingForeColor.BorderStyle = System.WinForms.BorderStyle.Fixed3D

            btnForeColor.Location = new System.Drawing.Point(232, 16)
            btnForeColor.Size = new System.Drawing.Size(75, 23)
            btnForeColor.TabIndex = 11
            btnForeColor.Text = "Change"
            btnForeColor.AddOnClick(new EventHandler(AddressOf Me.btnForeColor_Click))

            btnMonthBackground.Location = new System.Drawing.Point(232, 40)
            btnMonthBackground.Size = new System.Drawing.Size(75, 23)
            btnMonthBackground.TabIndex = 15
            btnMonthBackground.Text = "Change"
            btnMonthBackground.AddOnClick(new EventHandler(AddressOf Me.btnMonthBackground_Click))

            btnTitleBackColor.Location = new System.Drawing.Point(232, 64)
            btnTitleBackColor.Size = new System.Drawing.Size(75, 23)
            btnTitleBackColor.TabIndex = 14
            btnTitleBackColor.Text = "Change"
            btnTitleBackColor.AddOnClick(new EventHandler(AddressOf Me.btnTitleBackColor_Click))

            btnTitleForeColor.Location = new System.Drawing.Point(232, 88)
            btnTitleForeColor.Size = new System.Drawing.Size(75, 23)
            btnTitleForeColor.TabIndex = 13
            btnTitleForeColor.Text = "Change"
            btnTitleForeColor.AddOnClick(new EventHandler(AddressOf Me.btnTitleForeColor_Click))

            btnTrailingForeColor.Location = new System.Drawing.Point(232, 112)
            btnTrailingForeColor.Size = new System.Drawing.Size(75, 23)
            btnTrailingForeColor.TabIndex = 12
            btnTrailingForeColor.Text = "Change"
            btnTrailingForeColor.AddOnClick(new EventHandler(AddressOf Me.btnTrailingForeColor_Click))

            '/* @designTimeOnly colorDialog.setLocation(new System.Drawing.Point(16, 152)) */

            Me.Controls.Add(btnTrailingForeColor)
            Me.Controls.Add(btnTitleForeColor)
            Me.Controls.Add(btnTitleBackColor)
            Me.Controls.Add(btnMonthBackground)
            Me.Controls.Add(btnForeColor)
            Me.Controls.Add(pnlTrailingForeColor)
            Me.Controls.Add(pnlTitleForeColor)
            Me.Controls.Add(pnlTitleBackColor)
            Me.Controls.Add(pnlMonthBackground)
            Me.Controls.Add(pnlForeColor)
            Me.Controls.Add(btnOK)
            Me.Controls.Add(label5)
            Me.Controls.Add(label4)
            Me.Controls.Add(label3)
            Me.Controls.Add(label2)
            Me.Controls.Add(label1)
        End Sub
                   
    End Class

End Namespace
