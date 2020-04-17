'-----------------------------------------------------------------------
'  This file is part of the Microsoft .NET Framework SDK Code Samples.
' 
'  Copyright (C) Microsoft Corporation.  All rights reserved.
' 
'This source code is intended only as a supplement to Microsoft
'Development Tools and/or on-line documentation.  See these other
'materials for detailed information regarding Microsoft code samples.
' 
'THIS CODE AND INFORMATION ARE PROVIDED AS IS WITHOUT WARRANTY OF ANY
'KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE
'IMPLIED WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A
'PARTICULAR PURPOSE.
'-----------------------------------------------------------------------
Imports System
Imports System.ComponentModel
Imports System.Drawing
Imports System.Windows.Forms
Imports System.Collections
Imports System.Data
Imports System.Globalization
Imports System.Threading
Imports System.Resources
Imports System.Reflection

Namespace Microsoft.Samples.International.CustomCulture

  Public Class MainForm
    Inherits System.Windows.Forms.Form

    'Run the application
    <STAThread()> Shared Sub Main()
      System.Windows.Forms.Application.Run(New MainForm())
    End Sub

    Friend WithEvents label1 As System.Windows.Forms.Label 
    Friend WithEvents groupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents label2 As System.Windows.Forms.Label 
    Friend WithEvents labelDate As System.Windows.Forms.Label 
    Friend WithEvents groupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents radioENUS As System.Windows.Forms.RadioButton
    Friend WithEvents radioCUSTOM As System.Windows.Forms.RadioButton
    Friend WithEvents label3 As System.Windows.Forms.Label 
    Friend WithEvents labelCulture As System.Windows.Forms.Label 
    Friend WithEvents buttonClose As System.Windows.Forms.Button
    Friend WithEvents imageBox As System.Windows.Forms.PictureBox

    Public Sub New()
      MyBase.New()
      InitializeComponent()
      radioENUS.Checked = True
    End Sub 'New

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
      
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
	    Me.label1 = New System.Windows.Forms.Label()
	    Me.groupBox1 = New System.Windows.Forms.GroupBox()
	    Me.labelCulture = New System.Windows.Forms.Label()
	    Me.label3 = New System.Windows.Forms.Label()
	    Me.labelDate = New System.Windows.Forms.Label()
	    Me.label2 = New System.Windows.Forms.Label()
	    Me.imageBox = New System.Windows.Forms.PictureBox()
	    Me.groupBox2 = New System.Windows.Forms.GroupBox()
	    Me.radioCUSTOM = New System.Windows.Forms.RadioButton()
	    Me.radioENUS = New System.Windows.Forms.RadioButton()
	    Me.buttonClose = New System.Windows.Forms.Button()
	    Me.groupBox1.SuspendLayout()
	    Me.groupBox2.SuspendLayout()
	    Me.SuspendLayout()
      ' 
      ' label1
      ' 
      Me.label1.Location = New System.Drawing.Point(9, 10)
      Me.label1.Name = "label1"
      Me.label1.Size = New System.Drawing.Size(353, 43)
      Me.label1.TabIndex = 0
      Me.label1.Text = "This application shows how to create and use a custom culture to both display a resource and format a numeric value using a currency format"
      ' 
      ' groupBox1
      ' 
      Me.groupBox1.Controls.AddRange(New System.Windows.Forms.Control() {Me.labelCulture, Me.label3, Me.labelDate, Me.label2, Me.imageBox})
      Me.groupBox1.Location = New System.Drawing.Point(9, 61)
      Me.groupBox1.Name = "groupBox1"
      Me.groupBox1.Size = New System.Drawing.Size(361, 122)
      Me.groupBox1.TabIndex = 1
      Me.groupBox1.TabStop = False
      Me.groupBox1.Text = "Culture related information"
      ' 
      ' labelCulture
      ' 
      Me.labelCulture.Location = New System.Drawing.Point(107, 97)
      Me.labelCulture.Name = "labelCulture"
      Me.labelCulture.Size = New System.Drawing.Size(242, 15)
      Me.labelCulture.TabIndex = 4
      Me.labelCulture.Text = "[culture goes here]"
      ' 
      ' label3
      ' 
      Me.label3.Location = New System.Drawing.Point(17, 97)
      Me.label3.Name = "label3"
      Me.label3.Size = New System.Drawing.Size(68, 15)
      Me.label3.TabIndex = 3
      Me.label3.Text = "Culture: "
      ' 
      ' labelDate
      ' 
      Me.labelDate.BackColor = System.Drawing.SystemColors.Highlight
      Me.labelDate.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
      Me.labelDate.FlatStyle = System.Windows.Forms.FlatStyle.Flat
      Me.labelDate.ForeColor = System.Drawing.SystemColors.HighlightText
      Me.labelDate.Location = New System.Drawing.Point(129, 48)
      Me.labelDate.Name = "labelDate"
      Me.labelDate.Size = New System.Drawing.Size(224, 23)
      Me.labelDate.TabIndex = 2
      Me.labelDate.Text = "[amount goes here]"
      Me.labelDate.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
      ' 
      ' label2
      ' 
      Me.label2.Location = New System.Drawing.Point(129, 24)
      Me.label2.Name = "label2"
      Me.label2.Size = New System.Drawing.Size(184, 16)
      Me.label2.TabIndex = 1
      Me.label2.Text = "Amount"
      ' 
      ' imageBox
      ' 
      Me.imageBox.BackColor = System.Drawing.SystemColors.ActiveCaption
      Me.imageBox.Location = New System.Drawing.Point(17, 25)
      Me.imageBox.Name = "imageBox"
      Me.imageBox.Size = New System.Drawing.Size(90, 60)
      Me.imageBox.TabIndex = 0
      Me.imageBox.TabStop = False
      ' 
      ' groupBox2
      ' 
      Me.groupBox2.Controls.AddRange(New System.Windows.Forms.Control() {Me.radioCUSTOM, Me.radioENUS})
      Me.groupBox2.Location = New System.Drawing.Point(9, 191)
      Me.groupBox2.Name = "groupBox2"
      Me.groupBox2.Size = New System.Drawing.Size(194, 81)
      Me.groupBox2.TabIndex = 2
      Me.groupBox2.TabStop = False
      Me.groupBox2.Text = "Select culture:"
      ' 
      ' radioCUSTOM
      ' 
      Me.radioCUSTOM.Location = New System.Drawing.Point(17, 50)
      Me.radioCUSTOM.Name = "radioCUSTOM"
      Me.radioCUSTOM.Size = New System.Drawing.Size(161, 19)
      Me.radioCUSTOM.TabIndex = 1
      Me.radioCUSTOM.Text = "Custom-culture"
      ' 
      ' radioENUS
      ' 
      Me.radioENUS.Location = New System.Drawing.Point(17, 24)
      Me.radioENUS.Name = "radioENUS"
      Me.radioENUS.Size = New System.Drawing.Size(161, 19)
      Me.radioENUS.TabIndex = 0
      Me.radioENUS.Text = "English (United States)"
      ' 
      ' buttonClose
      ' 
      Me.buttonClose.Location = New System.Drawing.Point(295, 240)
      Me.buttonClose.Name = "buttonClose"
      Me.buttonClose.Size = New System.Drawing.Size(75, 32)
      Me.buttonClose.TabIndex = 3
      Me.buttonClose.Text = "Close"
      ' 
      ' MainForm
      ' 
      Me.AutoScaleDimensions = New System.Drawing.Size(5, 13)
      Me.ClientSize = New System.Drawing.Size(376, 280)
      Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.buttonClose, Me.groupBox2, Me.groupBox1, Me.label1})
      Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
      Me.Name = "MainForm"
      Me.Text = "CustomCulture Demo"
      Me.groupBox1.ResumeLayout(False)
      Me.groupBox2.ResumeLayout(False)
      Me.ResumeLayout(False)

    End Sub 'InitializeComponent
       
    Private Sub buttonClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles buttonClose.Click
      Me.Close()
    End Sub

    Private Sub radioENUS_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles radioENUS.CheckedChanged
      SetCulture(new CultureInfo("en-US"))
    End Sub

    Private Sub radioCUSTOM_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles radioCUSTOM.CheckedChanged
      SetCulture(new customCultureInfo("en-US", "xyz"))
    End Sub

    ' the SetCulture method is the one responsible for setting the culture
    ' and updating the resource and the date information on the form
    Private Sub SetCulture(ci As CultureInfo)
      ' set the current thread culture, which is used for date formatting
      Thread.CurrentThread.CurrentCulture = ci
      labelDate.Text = 123456789.ToString("C")      

      ' set the current thread UI culture and retrieve resource based on that
      Thread.CurrentThread.CurrentUICulture = ci

      ' in order to retrieve appropriate resource, we need to provide
      ' fully qualified path to the logo satellite
      Dim AssemblyPath As String = Application.StartupPath + "\logo.dll"
      Dim a As [Assembly] = [Assembly].LoadFrom(AssemblyPath)
      Dim rm As New ResourceManager("logo", a)
      imageBox.Image = CType(rm.GetObject("logo"), System.Drawing.Image)

      ' finally update culture information on the form
      labelCulture.Text = ci.DisplayName
    End Sub 'SetCulture

  End Class 'MainForm

End Namespace 'CustomCulture
