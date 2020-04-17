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
Imports System.Windows.Forms
Imports System.Globalization
Imports System.Text
Imports System.Reflection
Imports Microsoft.VisualBasic

Namespace Microsoft.Samples.StringWalker
    Public Class MainForm
        Inherits System.Windows.Forms.Form

        Friend WithEvents groupBox1 As System.Windows.Forms.GroupBox
        Friend WithEvents groupBox2 As System.Windows.Forms.GroupBox
        Friend WithEvents gbInsert As System.Windows.Forms.GroupBox
        Friend WithEvents label1 As System.Windows.Forms.Label
        Friend WithEvents BaseString As System.Windows.Forms.TextBox
        Friend WithEvents InsertString As System.Windows.Forms.TextBox
        Friend WithEvents label2 As System.Windows.Forms.Label
        Friend WithEvents buttonInsert As System.Windows.Forms.Button
        Friend WithEvents buttonWalk As System.Windows.Forms.Button
        Friend WithEvents InsertPos As System.Windows.Forms.TextBox
        Friend WithEvents groupBox3 As System.Windows.Forms.GroupBox
        Friend WithEvents label3 As System.Windows.Forms.Label
        Friend WithEvents RemoveCount As System.Windows.Forms.TextBox
        Friend WithEvents label4 As System.Windows.Forms.Label
        Friend WithEvents RemovePos As System.Windows.Forms.TextBox
        Friend WithEvents buttonRemove As System.Windows.Forms.Button
        Friend WithEvents listBoxWalk As System.Windows.Forms.ListBox
        Friend WithEvents groupBox4 As System.Windows.Forms.GroupBox
        Friend WithEvents label5 As System.Windows.Forms.Label
        Friend WithEvents FindString As System.Windows.Forms.TextBox
        Friend WithEvents label6 As System.Windows.Forms.Label
        Friend WithEvents FindPos As System.Windows.Forms.TextBox
        Friend WithEvents buttonFind As System.Windows.Forms.Button
        Friend WithEvents labelFind As System.Windows.Forms.Label
        Friend WithEvents label7 As System.Windows.Forms.Label
        Friend WithEvents label8 As System.Windows.Forms.Label
        Friend WithEvents labelTEL As System.Windows.Forms.Label
        Friend WithEvents labelCL As System.Windows.Forms.Label

        Private rm As System.Resources.ResourceManager

#Region " Windows Form Designer generated code "

        Public Sub New()
            MyBase.New()

            InitializeComponent()

            ' string initialization:
            BaseString.Text = "abc" & ChrW(&HD841) & ChrW(&HDC0F) & ChrW(&H61) & ChrW(&H30A) & _
                              ChrW(&HE5) & ChrW(&H17F) & ChrW(&H5E9) & ChrW(&H5B1) & ChrW(&H5D3)

            ' initialize resource manager for localizable strings
            rm = New System.Resources.ResourceManager("StringWalker.strings", [Assembly].GetExecutingAssembly())
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

        'NOTE: The following procedure is required by the Windows Form Designer
        'It can be modified using the Windows Form Designer.  
        'Do not modify it using the code editor.
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
            Dim resources As New System.Resources.ResourceManager(GetType(MainForm))
            Me.groupBox1 = New System.Windows.Forms.GroupBox()
            Me.labelCL = New System.Windows.Forms.Label()
            Me.labelTEL = New System.Windows.Forms.Label()
            Me.label8 = New System.Windows.Forms.Label()
            Me.label7 = New System.Windows.Forms.Label()
            Me.BaseString = New System.Windows.Forms.TextBox()
            Me.groupBox2 = New System.Windows.Forms.GroupBox()
            Me.listBoxWalk = New System.Windows.Forms.ListBox()
            Me.buttonWalk = New System.Windows.Forms.Button()
            Me.gbInsert = New System.Windows.Forms.GroupBox()
            Me.buttonInsert = New System.Windows.Forms.Button()
            Me.InsertPos = New System.Windows.Forms.TextBox()
            Me.label2 = New System.Windows.Forms.Label()
            Me.InsertString = New System.Windows.Forms.TextBox()
            Me.label1 = New System.Windows.Forms.Label()
            Me.groupBox3 = New System.Windows.Forms.GroupBox()
            Me.buttonRemove = New System.Windows.Forms.Button()
            Me.RemovePos = New System.Windows.Forms.TextBox()
            Me.label4 = New System.Windows.Forms.Label()
            Me.RemoveCount = New System.Windows.Forms.TextBox()
            Me.label3 = New System.Windows.Forms.Label()
            Me.groupBox4 = New System.Windows.Forms.GroupBox()
            Me.labelFind = New System.Windows.Forms.Label()
            Me.buttonFind = New System.Windows.Forms.Button()
            Me.FindPos = New System.Windows.Forms.TextBox()
            Me.label6 = New System.Windows.Forms.Label()
            Me.FindString = New System.Windows.Forms.TextBox()
            Me.label5 = New System.Windows.Forms.Label()
            Me.groupBox1.SuspendLayout()
            Me.groupBox2.SuspendLayout()
            Me.gbInsert.SuspendLayout()
            Me.groupBox3.SuspendLayout()
            Me.groupBox4.SuspendLayout()
            Me.SuspendLayout()
            ' 
            ' groupBox1
            ' 
            Me.groupBox1.AccessibleDescription = CStr(resources.GetObject("groupBox1.AccessibleDescription"))
            Me.groupBox1.AccessibleName = CStr(resources.GetObject("groupBox1.AccessibleName"))
            Me.groupBox1.Anchor = CType(resources.GetObject("groupBox1.Anchor"), System.Windows.Forms.AnchorStyles)
            Me.groupBox1.BackgroundImage = CType(resources.GetObject("groupBox1.BackgroundImage"), System.Drawing.Image)
            Me.groupBox1.Controls.AddRange(New System.Windows.Forms.Control() {Me.labelCL, Me.labelTEL, Me.label8, Me.label7, Me.BaseString})
            Me.groupBox1.Dock = CType(resources.GetObject("groupBox1.Dock"), System.Windows.Forms.DockStyle)
            Me.groupBox1.Enabled = CBool(resources.GetObject("groupBox1.Enabled"))
            Me.groupBox1.Font = CType(resources.GetObject("groupBox1.Font"), System.Drawing.Font)
            Me.groupBox1.ImeMode = CType(resources.GetObject("groupBox1.ImeMode"), System.Windows.Forms.ImeMode)
            Me.groupBox1.Location = CType(resources.GetObject("groupBox1.Location"), System.Drawing.Point)
            Me.groupBox1.Name = "groupBox1"
            Me.groupBox1.RightToLeft = CType(resources.GetObject("groupBox1.RightToLeft"), System.Windows.Forms.RightToLeft)
            Me.groupBox1.Size = CType(resources.GetObject("groupBox1.Size"), System.Drawing.Size)
            Me.groupBox1.TabIndex = CInt(resources.GetObject("groupBox1.TabIndex"))
            Me.groupBox1.TabStop = False
            Me.groupBox1.Text = resources.GetString("groupBox1.Text")
            Me.groupBox1.Visible = CBool(resources.GetObject("groupBox1.Visible"))
            ' 
            ' labelCL
            ' 
            Me.labelCL.AccessibleDescription = CStr(resources.GetObject("labelCL.AccessibleDescription"))
            Me.labelCL.AccessibleName = CStr(resources.GetObject("labelCL.AccessibleName"))
            Me.labelCL.Anchor = CType(resources.GetObject("labelCL.Anchor"), System.Windows.Forms.AnchorStyles)
            Me.labelCL.AutoSize = CBool(resources.GetObject("labelCL.AutoSize"))
            Me.labelCL.BackColor = System.Drawing.SystemColors.Highlight
            Me.labelCL.Dock = CType(resources.GetObject("labelCL.Dock"), System.Windows.Forms.DockStyle)
            Me.labelCL.Enabled = CBool(resources.GetObject("labelCL.Enabled"))
            Me.labelCL.Font = CType(resources.GetObject("labelCL.Font"), System.Drawing.Font)
            Me.labelCL.ForeColor = System.Drawing.SystemColors.HighlightText
            Me.labelCL.Image = CType(resources.GetObject("labelCL.Image"), System.Drawing.Image)
            Me.labelCL.ImageAlign = CType(resources.GetObject("labelCL.ImageAlign"), System.Drawing.ContentAlignment)
            Me.labelCL.ImageIndex = CInt(resources.GetObject("labelCL.ImageIndex"))
            Me.labelCL.ImeMode = CType(resources.GetObject("labelCL.ImeMode"), System.Windows.Forms.ImeMode)
            Me.labelCL.Location = CType(resources.GetObject("labelCL.Location"), System.Drawing.Point)
            Me.labelCL.Name = "labelCL"
            Me.labelCL.RightToLeft = CType(resources.GetObject("labelCL.RightToLeft"), System.Windows.Forms.RightToLeft)
            Me.labelCL.Size = CType(resources.GetObject("labelCL.Size"), System.Drawing.Size)
            Me.labelCL.TabIndex = CInt(resources.GetObject("labelCL.TabIndex"))
            Me.labelCL.Text = resources.GetString("labelCL.Text")
            Me.labelCL.TextAlign = CType(resources.GetObject("labelCL.TextAlign"), System.Drawing.ContentAlignment)
            Me.labelCL.UseMnemonic = False
            Me.labelCL.Visible = CBool(resources.GetObject("labelCL.Visible"))
            ' 
            ' labelTEL
            ' 
            Me.labelTEL.AccessibleDescription = CStr(resources.GetObject("labelTEL.AccessibleDescription"))
            Me.labelTEL.AccessibleName = CStr(resources.GetObject("labelTEL.AccessibleName"))
            Me.labelTEL.Anchor = CType(resources.GetObject("labelTEL.Anchor"), System.Windows.Forms.AnchorStyles)
            Me.labelTEL.AutoSize = CBool(resources.GetObject("labelTEL.AutoSize"))
            Me.labelTEL.BackColor = System.Drawing.SystemColors.Highlight
            Me.labelTEL.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
            Me.labelTEL.Dock = CType(resources.GetObject("labelTEL.Dock"), System.Windows.Forms.DockStyle)
            Me.labelTEL.Enabled = CBool(resources.GetObject("labelTEL.Enabled"))
            Me.labelTEL.Font = CType(resources.GetObject("labelTEL.Font"), System.Drawing.Font)
            Me.labelTEL.ForeColor = System.Drawing.SystemColors.HighlightText
            Me.labelTEL.Image = CType(resources.GetObject("labelTEL.Image"), System.Drawing.Image)
            Me.labelTEL.ImageAlign = CType(resources.GetObject("labelTEL.ImageAlign"), System.Drawing.ContentAlignment)
            Me.labelTEL.ImageIndex = CInt(resources.GetObject("labelTEL.ImageIndex"))
            Me.labelTEL.ImeMode = CType(resources.GetObject("labelTEL.ImeMode"), System.Windows.Forms.ImeMode)
            Me.labelTEL.Location = CType(resources.GetObject("labelTEL.Location"), System.Drawing.Point)
            Me.labelTEL.Name = "labelTEL"
            Me.labelTEL.RightToLeft = CType(resources.GetObject("labelTEL.RightToLeft"), System.Windows.Forms.RightToLeft)
            Me.labelTEL.Size = CType(resources.GetObject("labelTEL.Size"), System.Drawing.Size)
            Me.labelTEL.TabIndex = CInt(resources.GetObject("labelTEL.TabIndex"))
            Me.labelTEL.Text = resources.GetString("labelTEL.Text")
            Me.labelTEL.TextAlign = CType(resources.GetObject("labelTEL.TextAlign"), System.Drawing.ContentAlignment)
            Me.labelTEL.UseMnemonic = False
            Me.labelTEL.Visible = CBool(resources.GetObject("labelTEL.Visible"))
            ' 
            ' label8
            ' 
            Me.label8.AccessibleDescription = CStr(resources.GetObject("label8.AccessibleDescription"))
            Me.label8.AccessibleName = CStr(resources.GetObject("label8.AccessibleName"))
            Me.label8.Anchor = CType(resources.GetObject("label8.Anchor"), System.Windows.Forms.AnchorStyles)
            Me.label8.AutoSize = CBool(resources.GetObject("label8.AutoSize"))
            Me.label8.Dock = CType(resources.GetObject("label8.Dock"), System.Windows.Forms.DockStyle)
            Me.label8.Enabled = CBool(resources.GetObject("label8.Enabled"))
            Me.label8.Font = CType(resources.GetObject("label8.Font"), System.Drawing.Font)
            Me.label8.Image = CType(resources.GetObject("label8.Image"), System.Drawing.Image)
            Me.label8.ImageAlign = CType(resources.GetObject("label8.ImageAlign"), System.Drawing.ContentAlignment)
            Me.label8.ImageIndex = CInt(resources.GetObject("label8.ImageIndex"))
            Me.label8.ImeMode = CType(resources.GetObject("label8.ImeMode"), System.Windows.Forms.ImeMode)
            Me.label8.Location = CType(resources.GetObject("label8.Location"), System.Drawing.Point)
            Me.label8.Name = "label8"
            Me.label8.RightToLeft = CType(resources.GetObject("label8.RightToLeft"), System.Windows.Forms.RightToLeft)
            Me.label8.Size = CType(resources.GetObject("label8.Size"), System.Drawing.Size)
            Me.label8.TabIndex = CInt(resources.GetObject("label8.TabIndex"))
            Me.label8.Text = resources.GetString("label8.Text")
            Me.label8.TextAlign = CType(resources.GetObject("label8.TextAlign"), System.Drawing.ContentAlignment)
            Me.label8.Visible = CBool(resources.GetObject("label8.Visible"))
            ' 
            ' label7
            ' 
            Me.label7.AccessibleDescription = CStr(resources.GetObject("label7.AccessibleDescription"))
            Me.label7.AccessibleName = CStr(resources.GetObject("label7.AccessibleName"))
            Me.label7.Anchor = CType(resources.GetObject("label7.Anchor"), System.Windows.Forms.AnchorStyles)
            Me.label7.AutoSize = CBool(resources.GetObject("label7.AutoSize"))
            Me.label7.Dock = CType(resources.GetObject("label7.Dock"), System.Windows.Forms.DockStyle)
            Me.label7.Enabled = CBool(resources.GetObject("label7.Enabled"))
            Me.label7.Font = CType(resources.GetObject("label7.Font"), System.Drawing.Font)
            Me.label7.Image = CType(resources.GetObject("label7.Image"), System.Drawing.Image)
            Me.label7.ImageAlign = CType(resources.GetObject("label7.ImageAlign"), System.Drawing.ContentAlignment)
            Me.label7.ImageIndex = CInt(resources.GetObject("label7.ImageIndex"))
            Me.label7.ImeMode = CType(resources.GetObject("label7.ImeMode"), System.Windows.Forms.ImeMode)
            Me.label7.Location = CType(resources.GetObject("label7.Location"), System.Drawing.Point)
            Me.label7.Name = "label7"
            Me.label7.RightToLeft = CType(resources.GetObject("label7.RightToLeft"), System.Windows.Forms.RightToLeft)
            Me.label7.Size = CType(resources.GetObject("label7.Size"), System.Drawing.Size)
            Me.label7.TabIndex = CInt(resources.GetObject("label7.TabIndex"))
            Me.label7.Text = resources.GetString("label7.Text")
            Me.label7.TextAlign = CType(resources.GetObject("label7.TextAlign"), System.Drawing.ContentAlignment)
            Me.label7.Visible = CBool(resources.GetObject("label7.Visible"))
            ' 
            ' BaseString
            ' 
            Me.BaseString.AccessibleDescription = CStr(resources.GetObject("BaseString.AccessibleDescription"))
            Me.BaseString.AccessibleName = CStr(resources.GetObject("BaseString.AccessibleName"))
            Me.BaseString.Anchor = CType(resources.GetObject("BaseString.Anchor"), System.Windows.Forms.AnchorStyles)
            Me.BaseString.AutoSize = CBool(resources.GetObject("BaseString.AutoSize"))
            Me.BaseString.BackgroundImage = CType(resources.GetObject("BaseString.BackgroundImage"), System.Drawing.Image)
            Me.BaseString.Dock = CType(resources.GetObject("BaseString.Dock"), System.Windows.Forms.DockStyle)
            Me.BaseString.Enabled = CBool(resources.GetObject("BaseString.Enabled"))
            Me.BaseString.Font = CType(resources.GetObject("BaseString.Font"), System.Drawing.Font)
            Me.BaseString.ImeMode = CType(resources.GetObject("BaseString.ImeMode"), System.Windows.Forms.ImeMode)
            Me.BaseString.Location = CType(resources.GetObject("BaseString.Location"), System.Drawing.Point)
            Me.BaseString.MaxLength = CInt(resources.GetObject("BaseString.MaxLength"))
            Me.BaseString.Multiline = CBool(resources.GetObject("BaseString.Multiline"))
            Me.BaseString.Name = "BaseString"
            Me.BaseString.PasswordChar = CChar(resources.GetObject("BaseString.PasswordChar"))
            Me.BaseString.RightToLeft = CType(resources.GetObject("BaseString.RightToLeft"), System.Windows.Forms.RightToLeft)
            Me.BaseString.ScrollBars = CType(resources.GetObject("BaseString.ScrollBars"), System.Windows.Forms.ScrollBars)
            Me.BaseString.Size = CType(resources.GetObject("BaseString.Size"), System.Drawing.Size)
            Me.BaseString.TabIndex = CInt(resources.GetObject("BaseString.TabIndex"))
            Me.BaseString.Text = resources.GetString("BaseString.Text")
            Me.BaseString.TextAlign = CType(resources.GetObject("BaseString.TextAlign"), System.Windows.Forms.HorizontalAlignment)
            Me.BaseString.Visible = CBool(resources.GetObject("BaseString.Visible"))
            Me.BaseString.WordWrap = CBool(resources.GetObject("BaseString.WordWrap"))
            ' 
            ' groupBox2
            ' 
            Me.groupBox2.AccessibleDescription = CStr(resources.GetObject("groupBox2.AccessibleDescription"))
            Me.groupBox2.AccessibleName = CStr(resources.GetObject("groupBox2.AccessibleName"))
            Me.groupBox2.Anchor = CType(resources.GetObject("groupBox2.Anchor"), System.Windows.Forms.AnchorStyles)
            Me.groupBox2.BackgroundImage = CType(resources.GetObject("groupBox2.BackgroundImage"), System.Drawing.Image)
            Me.groupBox2.Controls.AddRange(New System.Windows.Forms.Control() {Me.listBoxWalk, Me.buttonWalk})
            Me.groupBox2.Dock = CType(resources.GetObject("groupBox2.Dock"), System.Windows.Forms.DockStyle)
            Me.groupBox2.Enabled = CBool(resources.GetObject("groupBox2.Enabled"))
            Me.groupBox2.Font = CType(resources.GetObject("groupBox2.Font"), System.Drawing.Font)
            Me.groupBox2.ImeMode = CType(resources.GetObject("groupBox2.ImeMode"), System.Windows.Forms.ImeMode)
            Me.groupBox2.Location = CType(resources.GetObject("groupBox2.Location"), System.Drawing.Point)
            Me.groupBox2.Name = "groupBox2"
            Me.groupBox2.RightToLeft = CType(resources.GetObject("groupBox2.RightToLeft"), System.Windows.Forms.RightToLeft)
            Me.groupBox2.Size = CType(resources.GetObject("groupBox2.Size"), System.Drawing.Size)
            Me.groupBox2.TabIndex = CInt(resources.GetObject("groupBox2.TabIndex"))
            Me.groupBox2.TabStop = False
            Me.groupBox2.Text = resources.GetString("groupBox2.Text")
            Me.groupBox2.Visible = CBool(resources.GetObject("groupBox2.Visible"))
            ' 
            ' listBoxWalk
            ' 
            Me.listBoxWalk.AccessibleDescription = CStr(resources.GetObject("listBoxWalk.AccessibleDescription"))
            Me.listBoxWalk.AccessibleName = CStr(resources.GetObject("listBoxWalk.AccessibleName"))
            Me.listBoxWalk.Anchor = CType(resources.GetObject("listBoxWalk.Anchor"), System.Windows.Forms.AnchorStyles)
            Me.listBoxWalk.BackgroundImage = CType(resources.GetObject("listBoxWalk.BackgroundImage"), System.Drawing.Image)
            Me.listBoxWalk.ColumnWidth = CInt(resources.GetObject("listBoxWalk.ColumnWidth"))
            Me.listBoxWalk.Dock = CType(resources.GetObject("listBoxWalk.Dock"), System.Windows.Forms.DockStyle)
            Me.listBoxWalk.Enabled = CBool(resources.GetObject("listBoxWalk.Enabled"))
            Me.listBoxWalk.Font = CType(resources.GetObject("listBoxWalk.Font"), System.Drawing.Font)
            Me.listBoxWalk.HorizontalExtent = CInt(resources.GetObject("listBoxWalk.HorizontalExtent"))
            Me.listBoxWalk.HorizontalScrollbar = CBool(resources.GetObject("listBoxWalk.HorizontalScrollbar"))
            Me.listBoxWalk.ImeMode = CType(resources.GetObject("listBoxWalk.ImeMode"), System.Windows.Forms.ImeMode)
            Me.listBoxWalk.IntegralHeight = CBool(resources.GetObject("listBoxWalk.IntegralHeight"))
            Me.listBoxWalk.ItemHeight = CInt(resources.GetObject("listBoxWalk.ItemHeight"))
            Me.listBoxWalk.Location = CType(resources.GetObject("listBoxWalk.Location"), System.Drawing.Point)
            Me.listBoxWalk.Name = "listBoxWalk"
            Me.listBoxWalk.RightToLeft = CType(resources.GetObject("listBoxWalk.RightToLeft"), System.Windows.Forms.RightToLeft)
            Me.listBoxWalk.ScrollAlwaysVisible = CBool(resources.GetObject("listBoxWalk.ScrollAlwaysVisible"))
            Me.listBoxWalk.Size = CType(resources.GetObject("listBoxWalk.Size"), System.Drawing.Size)
            Me.listBoxWalk.TabIndex = CInt(resources.GetObject("listBoxWalk.TabIndex"))
            Me.listBoxWalk.Visible = CBool(resources.GetObject("listBoxWalk.Visible"))
            ' 
            ' buttonWalk
            ' 
            Me.buttonWalk.AccessibleDescription = CStr(resources.GetObject("buttonWalk.AccessibleDescription"))
            Me.buttonWalk.AccessibleName = CStr(resources.GetObject("buttonWalk.AccessibleName"))
            Me.buttonWalk.Anchor = CType(resources.GetObject("buttonWalk.Anchor"), System.Windows.Forms.AnchorStyles)
            Me.buttonWalk.BackgroundImage = CType(resources.GetObject("buttonWalk.BackgroundImage"), System.Drawing.Image)
            Me.buttonWalk.Dock = CType(resources.GetObject("buttonWalk.Dock"), System.Windows.Forms.DockStyle)
            Me.buttonWalk.Enabled = CBool(resources.GetObject("buttonWalk.Enabled"))
            Me.buttonWalk.FlatStyle = CType(resources.GetObject("buttonWalk.FlatStyle"), System.Windows.Forms.FlatStyle)
            Me.buttonWalk.Font = CType(resources.GetObject("buttonWalk.Font"), System.Drawing.Font)
            Me.buttonWalk.Image = CType(resources.GetObject("buttonWalk.Image"), System.Drawing.Image)
            Me.buttonWalk.ImageAlign = CType(resources.GetObject("buttonWalk.ImageAlign"), System.Drawing.ContentAlignment)
            Me.buttonWalk.ImageIndex = CInt(resources.GetObject("buttonWalk.ImageIndex"))
            Me.buttonWalk.ImeMode = CType(resources.GetObject("buttonWalk.ImeMode"), System.Windows.Forms.ImeMode)
            Me.buttonWalk.Location = CType(resources.GetObject("buttonWalk.Location"), System.Drawing.Point)
            Me.buttonWalk.Name = "buttonWalk"
            Me.buttonWalk.RightToLeft = CType(resources.GetObject("buttonWalk.RightToLeft"), System.Windows.Forms.RightToLeft)
            Me.buttonWalk.Size = CType(resources.GetObject("buttonWalk.Size"), System.Drawing.Size)
            Me.buttonWalk.TabIndex = CInt(resources.GetObject("buttonWalk.TabIndex"))
            Me.buttonWalk.Text = resources.GetString("buttonWalk.Text")
            Me.buttonWalk.TextAlign = CType(resources.GetObject("buttonWalk.TextAlign"), System.Drawing.ContentAlignment)
            Me.buttonWalk.Visible = CBool(resources.GetObject("buttonWalk.Visible"))
            ' 
            ' gbInsert
            ' 
            Me.gbInsert.AccessibleDescription = CStr(resources.GetObject("gbInsert.AccessibleDescription"))
            Me.gbInsert.AccessibleName = CStr(resources.GetObject("gbInsert.AccessibleName"))
            Me.gbInsert.Anchor = CType(resources.GetObject("gbInsert.Anchor"), System.Windows.Forms.AnchorStyles)
            Me.gbInsert.BackgroundImage = CType(resources.GetObject("gbInsert.BackgroundImage"), System.Drawing.Image)
            Me.gbInsert.Controls.AddRange(New System.Windows.Forms.Control() {Me.buttonInsert, Me.InsertPos, Me.label2, Me.InsertString, Me.label1})
            Me.gbInsert.Dock = CType(resources.GetObject("gbInsert.Dock"), System.Windows.Forms.DockStyle)
            Me.gbInsert.Enabled = CBool(resources.GetObject("gbInsert.Enabled"))
            Me.gbInsert.Font = CType(resources.GetObject("gbInsert.Font"), System.Drawing.Font)
            Me.gbInsert.ImeMode = CType(resources.GetObject("gbInsert.ImeMode"), System.Windows.Forms.ImeMode)
            Me.gbInsert.Location = CType(resources.GetObject("gbInsert.Location"), System.Drawing.Point)
            Me.gbInsert.Name = "gbInsert"
            Me.gbInsert.RightToLeft = CType(resources.GetObject("gbInsert.RightToLeft"), System.Windows.Forms.RightToLeft)
            Me.gbInsert.Size = CType(resources.GetObject("gbInsert.Size"), System.Drawing.Size)
            Me.gbInsert.TabIndex = CInt(resources.GetObject("gbInsert.TabIndex"))
            Me.gbInsert.TabStop = False
            Me.gbInsert.Text = resources.GetString("gbInsert.Text")
            Me.gbInsert.Visible = CBool(resources.GetObject("gbInsert.Visible"))
            ' 
            ' buttonInsert
            ' 
            Me.buttonInsert.AccessibleDescription = CStr(resources.GetObject("buttonInsert.AccessibleDescription"))
            Me.buttonInsert.AccessibleName = CStr(resources.GetObject("buttonInsert.AccessibleName"))
            Me.buttonInsert.Anchor = CType(resources.GetObject("buttonInsert.Anchor"), System.Windows.Forms.AnchorStyles)
            Me.buttonInsert.BackgroundImage = CType(resources.GetObject("buttonInsert.BackgroundImage"), System.Drawing.Image)
            Me.buttonInsert.Dock = CType(resources.GetObject("buttonInsert.Dock"), System.Windows.Forms.DockStyle)
            Me.buttonInsert.Enabled = CBool(resources.GetObject("buttonInsert.Enabled"))
            Me.buttonInsert.FlatStyle = CType(resources.GetObject("buttonInsert.FlatStyle"), System.Windows.Forms.FlatStyle)
            Me.buttonInsert.Font = CType(resources.GetObject("buttonInsert.Font"), System.Drawing.Font)
            Me.buttonInsert.Image = CType(resources.GetObject("buttonInsert.Image"), System.Drawing.Image)
            Me.buttonInsert.ImageAlign = CType(resources.GetObject("buttonInsert.ImageAlign"), System.Drawing.ContentAlignment)
            Me.buttonInsert.ImageIndex = CInt(resources.GetObject("buttonInsert.ImageIndex"))
            Me.buttonInsert.ImeMode = CType(resources.GetObject("buttonInsert.ImeMode"), System.Windows.Forms.ImeMode)
            Me.buttonInsert.Location = CType(resources.GetObject("buttonInsert.Location"), System.Drawing.Point)
            Me.buttonInsert.Name = "buttonInsert"
            Me.buttonInsert.RightToLeft = CType(resources.GetObject("buttonInsert.RightToLeft"), System.Windows.Forms.RightToLeft)
            Me.buttonInsert.Size = CType(resources.GetObject("buttonInsert.Size"), System.Drawing.Size)
            Me.buttonInsert.TabIndex = CInt(resources.GetObject("buttonInsert.TabIndex"))
            Me.buttonInsert.Text = resources.GetString("buttonInsert.Text")
            Me.buttonInsert.TextAlign = CType(resources.GetObject("buttonInsert.TextAlign"), System.Drawing.ContentAlignment)
            Me.buttonInsert.Visible = CBool(resources.GetObject("buttonInsert.Visible"))
            ' 
            ' InsertPos
            ' 
            Me.InsertPos.AccessibleDescription = CStr(resources.GetObject("InsertPos.AccessibleDescription"))
            Me.InsertPos.AccessibleName = CStr(resources.GetObject("InsertPos.AccessibleName"))
            Me.InsertPos.Anchor = CType(resources.GetObject("InsertPos.Anchor"), System.Windows.Forms.AnchorStyles)
            Me.InsertPos.AutoSize = CBool(resources.GetObject("InsertPos.AutoSize"))
            Me.InsertPos.BackgroundImage = CType(resources.GetObject("InsertPos.BackgroundImage"), System.Drawing.Image)
            Me.InsertPos.Dock = CType(resources.GetObject("InsertPos.Dock"), System.Windows.Forms.DockStyle)
            Me.InsertPos.Enabled = CBool(resources.GetObject("InsertPos.Enabled"))
            Me.InsertPos.Font = CType(resources.GetObject("InsertPos.Font"), System.Drawing.Font)
            Me.InsertPos.ImeMode = CType(resources.GetObject("InsertPos.ImeMode"), System.Windows.Forms.ImeMode)
            Me.InsertPos.Location = CType(resources.GetObject("InsertPos.Location"), System.Drawing.Point)
            Me.InsertPos.MaxLength = CInt(resources.GetObject("InsertPos.MaxLength"))
            Me.InsertPos.Multiline = CBool(resources.GetObject("InsertPos.Multiline"))
            Me.InsertPos.Name = "InsertPos"
            Me.InsertPos.PasswordChar = CChar(resources.GetObject("InsertPos.PasswordChar"))
            Me.InsertPos.RightToLeft = CType(resources.GetObject("InsertPos.RightToLeft"), System.Windows.Forms.RightToLeft)
            Me.InsertPos.ScrollBars = CType(resources.GetObject("InsertPos.ScrollBars"), System.Windows.Forms.ScrollBars)
            Me.InsertPos.Size = CType(resources.GetObject("InsertPos.Size"), System.Drawing.Size)
            Me.InsertPos.TabIndex = CInt(resources.GetObject("InsertPos.TabIndex"))
            Me.InsertPos.Text = resources.GetString("InsertPos.Text")
            Me.InsertPos.TextAlign = CType(resources.GetObject("InsertPos.TextAlign"), System.Windows.Forms.HorizontalAlignment)
            Me.InsertPos.Visible = CBool(resources.GetObject("InsertPos.Visible"))
            Me.InsertPos.WordWrap = CBool(resources.GetObject("InsertPos.WordWrap"))
            ' 
            ' label2
            ' 
            Me.label2.AccessibleDescription = CStr(resources.GetObject("label2.AccessibleDescription"))
            Me.label2.AccessibleName = CStr(resources.GetObject("label2.AccessibleName"))
            Me.label2.Anchor = CType(resources.GetObject("label2.Anchor"), System.Windows.Forms.AnchorStyles)
            Me.label2.AutoSize = CBool(resources.GetObject("label2.AutoSize"))
            Me.label2.Dock = CType(resources.GetObject("label2.Dock"), System.Windows.Forms.DockStyle)
            Me.label2.Enabled = CBool(resources.GetObject("label2.Enabled"))
            Me.label2.Font = CType(resources.GetObject("label2.Font"), System.Drawing.Font)
            Me.label2.Image = CType(resources.GetObject("label2.Image"), System.Drawing.Image)
            Me.label2.ImageAlign = CType(resources.GetObject("label2.ImageAlign"), System.Drawing.ContentAlignment)
            Me.label2.ImageIndex = CInt(resources.GetObject("label2.ImageIndex"))
            Me.label2.ImeMode = CType(resources.GetObject("label2.ImeMode"), System.Windows.Forms.ImeMode)
            Me.label2.Location = CType(resources.GetObject("label2.Location"), System.Drawing.Point)
            Me.label2.Name = "label2"
            Me.label2.RightToLeft = CType(resources.GetObject("label2.RightToLeft"), System.Windows.Forms.RightToLeft)
            Me.label2.Size = CType(resources.GetObject("label2.Size"), System.Drawing.Size)
            Me.label2.TabIndex = CInt(resources.GetObject("label2.TabIndex"))
            Me.label2.Text = resources.GetString("label2.Text")
            Me.label2.TextAlign = CType(resources.GetObject("label2.TextAlign"), System.Drawing.ContentAlignment)
            Me.label2.Visible = CBool(resources.GetObject("label2.Visible"))
            ' 
            ' InsertString
            ' 
            Me.InsertString.AccessibleDescription = CStr(resources.GetObject("InsertString.AccessibleDescription"))
            Me.InsertString.AccessibleName = CStr(resources.GetObject("InsertString.AccessibleName"))
            Me.InsertString.Anchor = CType(resources.GetObject("InsertString.Anchor"), System.Windows.Forms.AnchorStyles)
            Me.InsertString.AutoSize = CBool(resources.GetObject("InsertString.AutoSize"))
            Me.InsertString.BackgroundImage = CType(resources.GetObject("InsertString.BackgroundImage"), System.Drawing.Image)
            Me.InsertString.Dock = CType(resources.GetObject("InsertString.Dock"), System.Windows.Forms.DockStyle)
            Me.InsertString.Enabled = CBool(resources.GetObject("InsertString.Enabled"))
            Me.InsertString.Font = CType(resources.GetObject("InsertString.Font"), System.Drawing.Font)
            Me.InsertString.ImeMode = CType(resources.GetObject("InsertString.ImeMode"), System.Windows.Forms.ImeMode)
            Me.InsertString.Location = CType(resources.GetObject("InsertString.Location"), System.Drawing.Point)
            Me.InsertString.MaxLength = CInt(resources.GetObject("InsertString.MaxLength"))
            Me.InsertString.Multiline = CBool(resources.GetObject("InsertString.Multiline"))
            Me.InsertString.Name = "InsertString"
            Me.InsertString.PasswordChar = CChar(resources.GetObject("InsertString.PasswordChar"))
            Me.InsertString.RightToLeft = CType(resources.GetObject("InsertString.RightToLeft"), System.Windows.Forms.RightToLeft)
            Me.InsertString.ScrollBars = CType(resources.GetObject("InsertString.ScrollBars"), System.Windows.Forms.ScrollBars)
            Me.InsertString.Size = CType(resources.GetObject("InsertString.Size"), System.Drawing.Size)
            Me.InsertString.TabIndex = CInt(resources.GetObject("InsertString.TabIndex"))
            Me.InsertString.Text = resources.GetString("InsertString.Text")
            Me.InsertString.TextAlign = CType(resources.GetObject("InsertString.TextAlign"), System.Windows.Forms.HorizontalAlignment)
            Me.InsertString.Visible = CBool(resources.GetObject("InsertString.Visible"))
            Me.InsertString.WordWrap = CBool(resources.GetObject("InsertString.WordWrap"))
            ' 
            ' label1
            ' 
            Me.label1.AccessibleDescription = CStr(resources.GetObject("label1.AccessibleDescription"))
            Me.label1.AccessibleName = CStr(resources.GetObject("label1.AccessibleName"))
            Me.label1.Anchor = CType(resources.GetObject("label1.Anchor"), System.Windows.Forms.AnchorStyles)
            Me.label1.AutoSize = CBool(resources.GetObject("label1.AutoSize"))
            Me.label1.Dock = CType(resources.GetObject("label1.Dock"), System.Windows.Forms.DockStyle)
            Me.label1.Enabled = CBool(resources.GetObject("label1.Enabled"))
            Me.label1.Font = CType(resources.GetObject("label1.Font"), System.Drawing.Font)
            Me.label1.Image = CType(resources.GetObject("label1.Image"), System.Drawing.Image)
            Me.label1.ImageAlign = CType(resources.GetObject("label1.ImageAlign"), System.Drawing.ContentAlignment)
            Me.label1.ImageIndex = CInt(resources.GetObject("label1.ImageIndex"))
            Me.label1.ImeMode = CType(resources.GetObject("label1.ImeMode"), System.Windows.Forms.ImeMode)
            Me.label1.Location = CType(resources.GetObject("label1.Location"), System.Drawing.Point)
            Me.label1.Name = "label1"
            Me.label1.RightToLeft = CType(resources.GetObject("label1.RightToLeft"), System.Windows.Forms.RightToLeft)
            Me.label1.Size = CType(resources.GetObject("label1.Size"), System.Drawing.Size)
            Me.label1.TabIndex = CInt(resources.GetObject("label1.TabIndex"))
            Me.label1.Text = resources.GetString("label1.Text")
            Me.label1.TextAlign = CType(resources.GetObject("label1.TextAlign"), System.Drawing.ContentAlignment)
            Me.label1.Visible = CBool(resources.GetObject("label1.Visible"))
            ' 
            ' groupBox3
            ' 
            Me.groupBox3.AccessibleDescription = CStr(resources.GetObject("groupBox3.AccessibleDescription"))
            Me.groupBox3.AccessibleName = CStr(resources.GetObject("groupBox3.AccessibleName"))
            Me.groupBox3.Anchor = CType(resources.GetObject("groupBox3.Anchor"), System.Windows.Forms.AnchorStyles)
            Me.groupBox3.BackgroundImage = CType(resources.GetObject("groupBox3.BackgroundImage"), System.Drawing.Image)
            Me.groupBox3.Controls.AddRange(New System.Windows.Forms.Control() {Me.buttonRemove, Me.RemovePos, Me.label4, Me.RemoveCount, Me.label3})
            Me.groupBox3.Dock = CType(resources.GetObject("groupBox3.Dock"), System.Windows.Forms.DockStyle)
            Me.groupBox3.Enabled = CBool(resources.GetObject("groupBox3.Enabled"))
            Me.groupBox3.Font = CType(resources.GetObject("groupBox3.Font"), System.Drawing.Font)
            Me.groupBox3.ImeMode = CType(resources.GetObject("groupBox3.ImeMode"), System.Windows.Forms.ImeMode)
            Me.groupBox3.Location = CType(resources.GetObject("groupBox3.Location"), System.Drawing.Point)
            Me.groupBox3.Name = "groupBox3"
            Me.groupBox3.RightToLeft = CType(resources.GetObject("groupBox3.RightToLeft"), System.Windows.Forms.RightToLeft)
            Me.groupBox3.Size = CType(resources.GetObject("groupBox3.Size"), System.Drawing.Size)
            Me.groupBox3.TabIndex = CInt(resources.GetObject("groupBox3.TabIndex"))
            Me.groupBox3.TabStop = False
            Me.groupBox3.Text = resources.GetString("groupBox3.Text")
            Me.groupBox3.Visible = CBool(resources.GetObject("groupBox3.Visible"))
            ' 
            ' buttonRemove
            ' 
            Me.buttonRemove.AccessibleDescription = CStr(resources.GetObject("buttonRemove.AccessibleDescription"))
            Me.buttonRemove.AccessibleName = CStr(resources.GetObject("buttonRemove.AccessibleName"))
            Me.buttonRemove.Anchor = CType(resources.GetObject("buttonRemove.Anchor"), System.Windows.Forms.AnchorStyles)
            Me.buttonRemove.BackgroundImage = CType(resources.GetObject("buttonRemove.BackgroundImage"), System.Drawing.Image)
            Me.buttonRemove.Dock = CType(resources.GetObject("buttonRemove.Dock"), System.Windows.Forms.DockStyle)
            Me.buttonRemove.Enabled = CBool(resources.GetObject("buttonRemove.Enabled"))
            Me.buttonRemove.FlatStyle = CType(resources.GetObject("buttonRemove.FlatStyle"), System.Windows.Forms.FlatStyle)
            Me.buttonRemove.Font = CType(resources.GetObject("buttonRemove.Font"), System.Drawing.Font)
            Me.buttonRemove.Image = CType(resources.GetObject("buttonRemove.Image"), System.Drawing.Image)
            Me.buttonRemove.ImageAlign = CType(resources.GetObject("buttonRemove.ImageAlign"), System.Drawing.ContentAlignment)
            Me.buttonRemove.ImageIndex = CInt(resources.GetObject("buttonRemove.ImageIndex"))
            Me.buttonRemove.ImeMode = CType(resources.GetObject("buttonRemove.ImeMode"), System.Windows.Forms.ImeMode)
            Me.buttonRemove.Location = CType(resources.GetObject("buttonRemove.Location"), System.Drawing.Point)
            Me.buttonRemove.Name = "buttonRemove"
            Me.buttonRemove.RightToLeft = CType(resources.GetObject("buttonRemove.RightToLeft"), System.Windows.Forms.RightToLeft)
            Me.buttonRemove.Size = CType(resources.GetObject("buttonRemove.Size"), System.Drawing.Size)
            Me.buttonRemove.TabIndex = CInt(resources.GetObject("buttonRemove.TabIndex"))
            Me.buttonRemove.Text = resources.GetString("buttonRemove.Text")
            Me.buttonRemove.TextAlign = CType(resources.GetObject("buttonRemove.TextAlign"), System.Drawing.ContentAlignment)
            Me.buttonRemove.Visible = CBool(resources.GetObject("buttonRemove.Visible"))
            ' 
            ' RemovePos
            ' 
            Me.RemovePos.AccessibleDescription = CStr(resources.GetObject("RemovePos.AccessibleDescription"))
            Me.RemovePos.AccessibleName = CStr(resources.GetObject("RemovePos.AccessibleName"))
            Me.RemovePos.Anchor = CType(resources.GetObject("RemovePos.Anchor"), System.Windows.Forms.AnchorStyles)
            Me.RemovePos.AutoSize = CBool(resources.GetObject("RemovePos.AutoSize"))
            Me.RemovePos.BackgroundImage = CType(resources.GetObject("RemovePos.BackgroundImage"), System.Drawing.Image)
            Me.RemovePos.Dock = CType(resources.GetObject("RemovePos.Dock"), System.Windows.Forms.DockStyle)
            Me.RemovePos.Enabled = CBool(resources.GetObject("RemovePos.Enabled"))
            Me.RemovePos.Font = CType(resources.GetObject("RemovePos.Font"), System.Drawing.Font)
            Me.RemovePos.ImeMode = CType(resources.GetObject("RemovePos.ImeMode"), System.Windows.Forms.ImeMode)
            Me.RemovePos.Location = CType(resources.GetObject("RemovePos.Location"), System.Drawing.Point)
            Me.RemovePos.MaxLength = CInt(resources.GetObject("RemovePos.MaxLength"))
            Me.RemovePos.Multiline = CBool(resources.GetObject("RemovePos.Multiline"))
            Me.RemovePos.Name = "RemovePos"
            Me.RemovePos.PasswordChar = CChar(resources.GetObject("RemovePos.PasswordChar"))
            Me.RemovePos.RightToLeft = CType(resources.GetObject("RemovePos.RightToLeft"), System.Windows.Forms.RightToLeft)
            Me.RemovePos.ScrollBars = CType(resources.GetObject("RemovePos.ScrollBars"), System.Windows.Forms.ScrollBars)
            Me.RemovePos.Size = CType(resources.GetObject("RemovePos.Size"), System.Drawing.Size)
            Me.RemovePos.TabIndex = CInt(resources.GetObject("RemovePos.TabIndex"))
            Me.RemovePos.Text = resources.GetString("RemovePos.Text")
            Me.RemovePos.TextAlign = CType(resources.GetObject("RemovePos.TextAlign"), System.Windows.Forms.HorizontalAlignment)
            Me.RemovePos.Visible = CBool(resources.GetObject("RemovePos.Visible"))
            Me.RemovePos.WordWrap = CBool(resources.GetObject("RemovePos.WordWrap"))
            ' 
            ' label4
            ' 
            Me.label4.AccessibleDescription = CStr(resources.GetObject("label4.AccessibleDescription"))
            Me.label4.AccessibleName = CStr(resources.GetObject("label4.AccessibleName"))
            Me.label4.Anchor = CType(resources.GetObject("label4.Anchor"), System.Windows.Forms.AnchorStyles)
            Me.label4.AutoSize = CBool(resources.GetObject("label4.AutoSize"))
            Me.label4.Dock = CType(resources.GetObject("label4.Dock"), System.Windows.Forms.DockStyle)
            Me.label4.Enabled = CBool(resources.GetObject("label4.Enabled"))
            Me.label4.Font = CType(resources.GetObject("label4.Font"), System.Drawing.Font)
            Me.label4.Image = CType(resources.GetObject("label4.Image"), System.Drawing.Image)
            Me.label4.ImageAlign = CType(resources.GetObject("label4.ImageAlign"), System.Drawing.ContentAlignment)
            Me.label4.ImageIndex = CInt(resources.GetObject("label4.ImageIndex"))
            Me.label4.ImeMode = CType(resources.GetObject("label4.ImeMode"), System.Windows.Forms.ImeMode)
            Me.label4.Location = CType(resources.GetObject("label4.Location"), System.Drawing.Point)
            Me.label4.Name = "label4"
            Me.label4.RightToLeft = CType(resources.GetObject("label4.RightToLeft"), System.Windows.Forms.RightToLeft)
            Me.label4.Size = CType(resources.GetObject("label4.Size"), System.Drawing.Size)
            Me.label4.TabIndex = CInt(resources.GetObject("label4.TabIndex"))
            Me.label4.Text = resources.GetString("label4.Text")
            Me.label4.TextAlign = CType(resources.GetObject("label4.TextAlign"), System.Drawing.ContentAlignment)
            Me.label4.Visible = CBool(resources.GetObject("label4.Visible"))
            ' 
            ' RemoveCount
            ' 
            Me.RemoveCount.AccessibleDescription = CStr(resources.GetObject("RemoveCount.AccessibleDescription"))
            Me.RemoveCount.AccessibleName = CStr(resources.GetObject("RemoveCount.AccessibleName"))
            Me.RemoveCount.Anchor = CType(resources.GetObject("RemoveCount.Anchor"), System.Windows.Forms.AnchorStyles)
            Me.RemoveCount.AutoSize = CBool(resources.GetObject("RemoveCount.AutoSize"))
            Me.RemoveCount.BackgroundImage = CType(resources.GetObject("RemoveCount.BackgroundImage"), System.Drawing.Image)
            Me.RemoveCount.Dock = CType(resources.GetObject("RemoveCount.Dock"), System.Windows.Forms.DockStyle)
            Me.RemoveCount.Enabled = CBool(resources.GetObject("RemoveCount.Enabled"))
            Me.RemoveCount.Font = CType(resources.GetObject("RemoveCount.Font"), System.Drawing.Font)
            Me.RemoveCount.ImeMode = CType(resources.GetObject("RemoveCount.ImeMode"), System.Windows.Forms.ImeMode)
            Me.RemoveCount.Location = CType(resources.GetObject("RemoveCount.Location"), System.Drawing.Point)
            Me.RemoveCount.MaxLength = CInt(resources.GetObject("RemoveCount.MaxLength"))
            Me.RemoveCount.Multiline = CBool(resources.GetObject("RemoveCount.Multiline"))
            Me.RemoveCount.Name = "RemoveCount"
            Me.RemoveCount.PasswordChar = CChar(resources.GetObject("RemoveCount.PasswordChar"))
            Me.RemoveCount.RightToLeft = CType(resources.GetObject("RemoveCount.RightToLeft"), System.Windows.Forms.RightToLeft)
            Me.RemoveCount.ScrollBars = CType(resources.GetObject("RemoveCount.ScrollBars"), System.Windows.Forms.ScrollBars)
            Me.RemoveCount.Size = CType(resources.GetObject("RemoveCount.Size"), System.Drawing.Size)
            Me.RemoveCount.TabIndex = CInt(resources.GetObject("RemoveCount.TabIndex"))
            Me.RemoveCount.Text = resources.GetString("RemoveCount.Text")
            Me.RemoveCount.TextAlign = CType(resources.GetObject("RemoveCount.TextAlign"), System.Windows.Forms.HorizontalAlignment)
            Me.RemoveCount.Visible = CBool(resources.GetObject("RemoveCount.Visible"))
            Me.RemoveCount.WordWrap = CBool(resources.GetObject("RemoveCount.WordWrap"))
            ' 
            ' label3
            ' 
            Me.label3.AccessibleDescription = CStr(resources.GetObject("label3.AccessibleDescription"))
            Me.label3.AccessibleName = CStr(resources.GetObject("label3.AccessibleName"))
            Me.label3.Anchor = CType(resources.GetObject("label3.Anchor"), System.Windows.Forms.AnchorStyles)
            Me.label3.AutoSize = CBool(resources.GetObject("label3.AutoSize"))
            Me.label3.Dock = CType(resources.GetObject("label3.Dock"), System.Windows.Forms.DockStyle)
            Me.label3.Enabled = CBool(resources.GetObject("label3.Enabled"))
            Me.label3.Font = CType(resources.GetObject("label3.Font"), System.Drawing.Font)
            Me.label3.Image = CType(resources.GetObject("label3.Image"), System.Drawing.Image)
            Me.label3.ImageAlign = CType(resources.GetObject("label3.ImageAlign"), System.Drawing.ContentAlignment)
            Me.label3.ImageIndex = CInt(resources.GetObject("label3.ImageIndex"))
            Me.label3.ImeMode = CType(resources.GetObject("label3.ImeMode"), System.Windows.Forms.ImeMode)
            Me.label3.Location = CType(resources.GetObject("label3.Location"), System.Drawing.Point)
            Me.label3.Name = "label3"
            Me.label3.RightToLeft = CType(resources.GetObject("label3.RightToLeft"), System.Windows.Forms.RightToLeft)
            Me.label3.Size = CType(resources.GetObject("label3.Size"), System.Drawing.Size)
            Me.label3.TabIndex = CInt(resources.GetObject("label3.TabIndex"))
            Me.label3.Text = resources.GetString("label3.Text")
            Me.label3.TextAlign = CType(resources.GetObject("label3.TextAlign"), System.Drawing.ContentAlignment)
            Me.label3.Visible = CBool(resources.GetObject("label3.Visible"))
            ' 
            ' groupBox4
            ' 
            Me.groupBox4.AccessibleDescription = CStr(resources.GetObject("groupBox4.AccessibleDescription"))
            Me.groupBox4.AccessibleName = CStr(resources.GetObject("groupBox4.AccessibleName"))
            Me.groupBox4.Anchor = CType(resources.GetObject("groupBox4.Anchor"), System.Windows.Forms.AnchorStyles)
            Me.groupBox4.BackgroundImage = CType(resources.GetObject("groupBox4.BackgroundImage"), System.Drawing.Image)
            Me.groupBox4.Controls.AddRange(New System.Windows.Forms.Control() {Me.labelFind, Me.buttonFind, Me.FindPos, Me.label6, Me.FindString, Me.label5})
            Me.groupBox4.Dock = CType(resources.GetObject("groupBox4.Dock"), System.Windows.Forms.DockStyle)
            Me.groupBox4.Enabled = CBool(resources.GetObject("groupBox4.Enabled"))
            Me.groupBox4.Font = CType(resources.GetObject("groupBox4.Font"), System.Drawing.Font)
            Me.groupBox4.ImeMode = CType(resources.GetObject("groupBox4.ImeMode"), System.Windows.Forms.ImeMode)
            Me.groupBox4.Location = CType(resources.GetObject("groupBox4.Location"), System.Drawing.Point)
            Me.groupBox4.Name = "groupBox4"
            Me.groupBox4.RightToLeft = CType(resources.GetObject("groupBox4.RightToLeft"), System.Windows.Forms.RightToLeft)
            Me.groupBox4.Size = CType(resources.GetObject("groupBox4.Size"), System.Drawing.Size)
            Me.groupBox4.TabIndex = CInt(resources.GetObject("groupBox4.TabIndex"))
            Me.groupBox4.TabStop = False
            Me.groupBox4.Text = resources.GetString("groupBox4.Text")
            Me.groupBox4.Visible = CBool(resources.GetObject("groupBox4.Visible"))
            ' 
            ' labelFind
            ' 
            Me.labelFind.AccessibleDescription = CStr(resources.GetObject("labelFind.AccessibleDescription"))
            Me.labelFind.AccessibleName = CStr(resources.GetObject("labelFind.AccessibleName"))
            Me.labelFind.Anchor = CType(resources.GetObject("labelFind.Anchor"), System.Windows.Forms.AnchorStyles)
            Me.labelFind.AutoSize = CBool(resources.GetObject("labelFind.AutoSize"))
            Me.labelFind.BackColor = System.Drawing.SystemColors.Highlight
            Me.labelFind.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
            Me.labelFind.Dock = CType(resources.GetObject("labelFind.Dock"), System.Windows.Forms.DockStyle)
            Me.labelFind.Enabled = CBool(resources.GetObject("labelFind.Enabled"))
            Me.labelFind.Font = CType(resources.GetObject("labelFind.Font"), System.Drawing.Font)
            Me.labelFind.ForeColor = System.Drawing.SystemColors.HighlightText
            Me.labelFind.Image = CType(resources.GetObject("labelFind.Image"), System.Drawing.Image)
            Me.labelFind.ImageAlign = CType(resources.GetObject("labelFind.ImageAlign"), System.Drawing.ContentAlignment)
            Me.labelFind.ImageIndex = CInt(resources.GetObject("labelFind.ImageIndex"))
            Me.labelFind.ImeMode = CType(resources.GetObject("labelFind.ImeMode"), System.Windows.Forms.ImeMode)
            Me.labelFind.Location = CType(resources.GetObject("labelFind.Location"), System.Drawing.Point)
            Me.labelFind.Name = "labelFind"
            Me.labelFind.RightToLeft = CType(resources.GetObject("labelFind.RightToLeft"), System.Windows.Forms.RightToLeft)
            Me.labelFind.Size = CType(resources.GetObject("labelFind.Size"), System.Drawing.Size)
            Me.labelFind.TabIndex = CInt(resources.GetObject("labelFind.TabIndex"))
            Me.labelFind.Text = resources.GetString("labelFind.Text")
            Me.labelFind.TextAlign = CType(resources.GetObject("labelFind.TextAlign"), System.Drawing.ContentAlignment)
            Me.labelFind.Visible = CBool(resources.GetObject("labelFind.Visible"))
            ' 
            ' buttonFind
            ' 
            Me.buttonFind.AccessibleDescription = CStr(resources.GetObject("buttonFind.AccessibleDescription"))
            Me.buttonFind.AccessibleName = CStr(resources.GetObject("buttonFind.AccessibleName"))
            Me.buttonFind.Anchor = CType(resources.GetObject("buttonFind.Anchor"), System.Windows.Forms.AnchorStyles)
            Me.buttonFind.BackgroundImage = CType(resources.GetObject("buttonFind.BackgroundImage"), System.Drawing.Image)
            Me.buttonFind.Dock = CType(resources.GetObject("buttonFind.Dock"), System.Windows.Forms.DockStyle)
            Me.buttonFind.Enabled = CBool(resources.GetObject("buttonFind.Enabled"))
            Me.buttonFind.FlatStyle = CType(resources.GetObject("buttonFind.FlatStyle"), System.Windows.Forms.FlatStyle)
            Me.buttonFind.Font = CType(resources.GetObject("buttonFind.Font"), System.Drawing.Font)
            Me.buttonFind.Image = CType(resources.GetObject("buttonFind.Image"), System.Drawing.Image)
            Me.buttonFind.ImageAlign = CType(resources.GetObject("buttonFind.ImageAlign"), System.Drawing.ContentAlignment)
            Me.buttonFind.ImageIndex = CInt(resources.GetObject("buttonFind.ImageIndex"))
            Me.buttonFind.ImeMode = CType(resources.GetObject("buttonFind.ImeMode"), System.Windows.Forms.ImeMode)
            Me.buttonFind.Location = CType(resources.GetObject("buttonFind.Location"), System.Drawing.Point)
            Me.buttonFind.Name = "buttonFind"
            Me.buttonFind.RightToLeft = CType(resources.GetObject("buttonFind.RightToLeft"), System.Windows.Forms.RightToLeft)
            Me.buttonFind.Size = CType(resources.GetObject("buttonFind.Size"), System.Drawing.Size)
            Me.buttonFind.TabIndex = CInt(resources.GetObject("buttonFind.TabIndex"))
            Me.buttonFind.Text = resources.GetString("buttonFind.Text")
            Me.buttonFind.TextAlign = CType(resources.GetObject("buttonFind.TextAlign"), System.Drawing.ContentAlignment)
            Me.buttonFind.Visible = CBool(resources.GetObject("buttonFind.Visible"))
            ' 
            ' FindPos
            ' 
            Me.FindPos.AccessibleDescription = CStr(resources.GetObject("FindPos.AccessibleDescription"))
            Me.FindPos.AccessibleName = CStr(resources.GetObject("FindPos.AccessibleName"))
            Me.FindPos.Anchor = CType(resources.GetObject("FindPos.Anchor"), System.Windows.Forms.AnchorStyles)
            Me.FindPos.AutoSize = CBool(resources.GetObject("FindPos.AutoSize"))
            Me.FindPos.BackgroundImage = CType(resources.GetObject("FindPos.BackgroundImage"), System.Drawing.Image)
            Me.FindPos.Dock = CType(resources.GetObject("FindPos.Dock"), System.Windows.Forms.DockStyle)
            Me.FindPos.Enabled = CBool(resources.GetObject("FindPos.Enabled"))
            Me.FindPos.Font = CType(resources.GetObject("FindPos.Font"), System.Drawing.Font)
            Me.FindPos.ImeMode = CType(resources.GetObject("FindPos.ImeMode"), System.Windows.Forms.ImeMode)
            Me.FindPos.Location = CType(resources.GetObject("FindPos.Location"), System.Drawing.Point)
            Me.FindPos.MaxLength = CInt(resources.GetObject("FindPos.MaxLength"))
            Me.FindPos.Multiline = CBool(resources.GetObject("FindPos.Multiline"))
            Me.FindPos.Name = "FindPos"
            Me.FindPos.PasswordChar = CChar(resources.GetObject("FindPos.PasswordChar"))
            Me.FindPos.RightToLeft = CType(resources.GetObject("FindPos.RightToLeft"), System.Windows.Forms.RightToLeft)
            Me.FindPos.ScrollBars = CType(resources.GetObject("FindPos.ScrollBars"), System.Windows.Forms.ScrollBars)
            Me.FindPos.Size = CType(resources.GetObject("FindPos.Size"), System.Drawing.Size)
            Me.FindPos.TabIndex = CInt(resources.GetObject("FindPos.TabIndex"))
            Me.FindPos.Text = resources.GetString("FindPos.Text")
            Me.FindPos.TextAlign = CType(resources.GetObject("FindPos.TextAlign"), System.Windows.Forms.HorizontalAlignment)
            Me.FindPos.Visible = CBool(resources.GetObject("FindPos.Visible"))
            Me.FindPos.WordWrap = CBool(resources.GetObject("FindPos.WordWrap"))
            ' 
            ' label6
            ' 
            Me.label6.AccessibleDescription = CStr(resources.GetObject("label6.AccessibleDescription"))
            Me.label6.AccessibleName = CStr(resources.GetObject("label6.AccessibleName"))
            Me.label6.Anchor = CType(resources.GetObject("label6.Anchor"), System.Windows.Forms.AnchorStyles)
            Me.label6.AutoSize = CBool(resources.GetObject("label6.AutoSize"))
            Me.label6.Dock = CType(resources.GetObject("label6.Dock"), System.Windows.Forms.DockStyle)
            Me.label6.Enabled = CBool(resources.GetObject("label6.Enabled"))
            Me.label6.Font = CType(resources.GetObject("label6.Font"), System.Drawing.Font)
            Me.label6.Image = CType(resources.GetObject("label6.Image"), System.Drawing.Image)
            Me.label6.ImageAlign = CType(resources.GetObject("label6.ImageAlign"), System.Drawing.ContentAlignment)
            Me.label6.ImageIndex = CInt(resources.GetObject("label6.ImageIndex"))
            Me.label6.ImeMode = CType(resources.GetObject("label6.ImeMode"), System.Windows.Forms.ImeMode)
            Me.label6.Location = CType(resources.GetObject("label6.Location"), System.Drawing.Point)
            Me.label6.Name = "label6"
            Me.label6.RightToLeft = CType(resources.GetObject("label6.RightToLeft"), System.Windows.Forms.RightToLeft)
            Me.label6.Size = CType(resources.GetObject("label6.Size"), System.Drawing.Size)
            Me.label6.TabIndex = CInt(resources.GetObject("label6.TabIndex"))
            Me.label6.Text = resources.GetString("label6.Text")
            Me.label6.TextAlign = CType(resources.GetObject("label6.TextAlign"), System.Drawing.ContentAlignment)
            Me.label6.Visible = CBool(resources.GetObject("label6.Visible"))
            ' 
            ' FindString
            ' 
            Me.FindString.AccessibleDescription = CStr(resources.GetObject("FindString.AccessibleDescription"))
            Me.FindString.AccessibleName = CStr(resources.GetObject("FindString.AccessibleName"))
            Me.FindString.Anchor = CType(resources.GetObject("FindString.Anchor"), System.Windows.Forms.AnchorStyles)
            Me.FindString.AutoSize = CBool(resources.GetObject("FindString.AutoSize"))
            Me.FindString.BackgroundImage = CType(resources.GetObject("FindString.BackgroundImage"), System.Drawing.Image)
            Me.FindString.Dock = CType(resources.GetObject("FindString.Dock"), System.Windows.Forms.DockStyle)
            Me.FindString.Enabled = CBool(resources.GetObject("FindString.Enabled"))
            Me.FindString.Font = CType(resources.GetObject("FindString.Font"), System.Drawing.Font)
            Me.FindString.ImeMode = CType(resources.GetObject("FindString.ImeMode"), System.Windows.Forms.ImeMode)
            Me.FindString.Location = CType(resources.GetObject("FindString.Location"), System.Drawing.Point)
            Me.FindString.MaxLength = CInt(resources.GetObject("FindString.MaxLength"))
            Me.FindString.Multiline = CBool(resources.GetObject("FindString.Multiline"))
            Me.FindString.Name = "FindString"
            Me.FindString.PasswordChar = CChar(resources.GetObject("FindString.PasswordChar"))
            Me.FindString.RightToLeft = CType(resources.GetObject("FindString.RightToLeft"), System.Windows.Forms.RightToLeft)
            Me.FindString.ScrollBars = CType(resources.GetObject("FindString.ScrollBars"), System.Windows.Forms.ScrollBars)
            Me.FindString.Size = CType(resources.GetObject("FindString.Size"), System.Drawing.Size)
            Me.FindString.TabIndex = CInt(resources.GetObject("FindString.TabIndex"))
            Me.FindString.Text = resources.GetString("FindString.Text")
            Me.FindString.TextAlign = CType(resources.GetObject("FindString.TextAlign"), System.Windows.Forms.HorizontalAlignment)
            Me.FindString.Visible = CBool(resources.GetObject("FindString.Visible"))
            Me.FindString.WordWrap = CBool(resources.GetObject("FindString.WordWrap"))
            ' 
            ' label5
            ' 
            Me.label5.AccessibleDescription = CStr(resources.GetObject("label5.AccessibleDescription"))
            Me.label5.AccessibleName = CStr(resources.GetObject("label5.AccessibleName"))
            Me.label5.Anchor = CType(resources.GetObject("label5.Anchor"), System.Windows.Forms.AnchorStyles)
            Me.label5.AutoSize = CBool(resources.GetObject("label5.AutoSize"))
            Me.label5.Dock = CType(resources.GetObject("label5.Dock"), System.Windows.Forms.DockStyle)
            Me.label5.Enabled = CBool(resources.GetObject("label5.Enabled"))
            Me.label5.Font = CType(resources.GetObject("label5.Font"), System.Drawing.Font)
            Me.label5.Image = CType(resources.GetObject("label5.Image"), System.Drawing.Image)
            Me.label5.ImageAlign = CType(resources.GetObject("label5.ImageAlign"), System.Drawing.ContentAlignment)
            Me.label5.ImageIndex = CInt(resources.GetObject("label5.ImageIndex"))
            Me.label5.ImeMode = CType(resources.GetObject("label5.ImeMode"), System.Windows.Forms.ImeMode)
            Me.label5.Location = CType(resources.GetObject("label5.Location"), System.Drawing.Point)
            Me.label5.Name = "label5"
            Me.label5.RightToLeft = CType(resources.GetObject("label5.RightToLeft"), System.Windows.Forms.RightToLeft)
            Me.label5.Size = CType(resources.GetObject("label5.Size"), System.Drawing.Size)
            Me.label5.TabIndex = CInt(resources.GetObject("label5.TabIndex"))
            Me.label5.Text = resources.GetString("label5.Text")
            Me.label5.TextAlign = CType(resources.GetObject("label5.TextAlign"), System.Drawing.ContentAlignment)
            Me.label5.Visible = CBool(resources.GetObject("label5.Visible"))
            ' 
            ' MainForm
            ' 
            Me.AccessibleDescription = CStr(resources.GetObject("$this.AccessibleDescription"))
            Me.AccessibleName = CStr(resources.GetObject("$this.AccessibleName"))
            Me.Anchor = CType(resources.GetObject("$this.Anchor"), System.Windows.Forms.AnchorStyles)
            Me.AutoScroll = CBool(resources.GetObject("$this.AutoScroll"))
            Me.AutoScrollMargin = CType(resources.GetObject("$this.AutoScrollMargin"), System.Drawing.Size)
            Me.AutoScrollMinSize = CType(resources.GetObject("$this.AutoScrollMinSize"), System.Drawing.Size)
            Me.BackgroundImage = CType(resources.GetObject("$this.BackgroundImage"), System.Drawing.Image)
            Me.ClientSize = CType(resources.GetObject("$this.ClientSize"), System.Drawing.Size)
            Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.groupBox4, Me.groupBox3, Me.gbInsert, Me.groupBox2, Me.groupBox1})
            Me.Dock = CType(resources.GetObject("$this.Dock"), System.Windows.Forms.DockStyle)
            Me.Enabled = CBool(resources.GetObject("$this.Enabled"))
            Me.Font = CType(resources.GetObject("$this.Font"), System.Drawing.Font)
            Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
            Me.ImeMode = CType(resources.GetObject("$this.ImeMode"), System.Windows.Forms.ImeMode)
            Me.Location = CType(resources.GetObject("$this.Location"), System.Drawing.Point)
            Me.MaximumSize = CType(resources.GetObject("$this.MaximumSize"), System.Drawing.Size)
            Me.MinimumSize = CType(resources.GetObject("$this.MinimumSize"), System.Drawing.Size)
            Me.Name = "MainForm"
            Me.RightToLeft = CType(resources.GetObject("$this.RightToLeft"), System.Windows.Forms.RightToLeft)
            Me.StartPosition = CType(resources.GetObject("$this.StartPosition"), System.Windows.Forms.FormStartPosition)
            Me.Text = resources.GetString("$this.Text")
            Me.Visible = CBool(resources.GetObject("$this.Visible"))
            Me.groupBox1.ResumeLayout(False)
            Me.groupBox2.ResumeLayout(False)
            Me.gbInsert.ResumeLayout(False)
            Me.groupBox3.ResumeLayout(False)
            Me.groupBox4.ResumeLayout(False)
            Me.ResumeLayout(False)
        End Sub

#End Region

        Private Sub buttonWalk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles buttonWalk.Click
            Dim sw As New StringWalker(BaseString.Text)
            Dim str As String = ""

            Dim fcontinue As Boolean = sw.GetFirst(str)
            listBoxWalk.Items.Clear()
            While fcontinue
                Dim sb As New StringBuilder()
                sb.Append(str)
                sb.Append(ControlChars.Tab)

                Dim c As Char
                For Each c In str
                    Dim uc As UnicodeCategory = Char.GetUnicodeCategory(c)
                    Select Case uc
                        Case UnicodeCategory.Surrogate
                            sb.AppendFormat(rm.GetString("surrogate", CultureInfo.CurrentCulture))

                        Case UnicodeCategory.NonSpacingMark
                            sb.AppendFormat(rm.GetString("nonspacingmark", CultureInfo.CurrentCulture))

                        Case Else
                    End Select
                Next c

                listBoxWalk.Items.Add(sb.ToString())
                fcontinue = sw.GetNext(str)
            End While
        End Sub


        Private Sub buttonInsert_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles buttonInsert.Click
            Try
                Dim pos As Integer = Int32.Parse(InsertPos.Text, CultureInfo.CurrentCulture)
                Dim sw As New StringWalker(BaseString.Text)

                If sw.Insert(pos, InsertString.Text) Then
                    BaseString.Text = sw.ToString()
                Else
                    MessageBox.Show(Me, rm.GetString("err-insert1", CultureInfo.CurrentCulture))
                End If
            Catch
                MessageBox.Show(Me, rm.GetString("err-insert2", CultureInfo.CurrentCulture))
            End Try
        End Sub


        Private Sub buttonRemove_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles buttonRemove.Click
            Try
                Dim pos As Integer = Int32.Parse(RemovePos.Text, CultureInfo.CurrentCulture)
                Dim count As Integer = Int32.Parse(RemoveCount.Text, CultureInfo.CurrentCulture)
                Dim sw As New StringWalker(BaseString.Text)

                If sw.Remove(pos, count) Then
                    BaseString.Text = sw.ToString()
                Else
                    MessageBox.Show(Me, rm.GetString("err-remove1", CultureInfo.CurrentCulture))
                End If
            Catch
                MessageBox.Show(Me, rm.GetString("err-remove2", CultureInfo.CurrentCulture))
            End Try
        End Sub

        Private Sub buttonFind_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles buttonFind.Click
            Try
                Dim pos As Integer = Int32.Parse(FindPos.Text, CultureInfo.CurrentCulture)
                Dim sw As New StringWalker(BaseString.Text)

                Dim foundPos As Integer = sw.IndexOf(FindString.Text, pos)
                If -1 = foundPos Then
                    labelFind.Text = rm.GetString("notfound", CultureInfo.CurrentCulture)
                Else
                    labelFind.Text = String.Format(rm.GetString("foundformat", CultureInfo.CurrentCulture), FindString.Text, foundPos)
                End If
            Catch
                MessageBox.Show(Me, rm.GetString("err-find", CultureInfo.CurrentCulture))
            End Try
        End Sub

        Private Sub onTextChange(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BaseString.TextChanged
            Dim sw As New StringWalker(BaseString.Text)
            labelTEL.Text = sw.Length.ToString(CultureInfo.CurrentCulture)
            labelCL.Text = BaseString.Text.Length.ToString(CultureInfo.CurrentCulture)
        End Sub

    End Class
End Namespace