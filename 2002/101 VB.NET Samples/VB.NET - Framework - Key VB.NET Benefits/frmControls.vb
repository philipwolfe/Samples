'Copyright (C) 2002 Microsoft Corporation
'All rights reserved.
'THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, EITHER
'EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED WARRANTIES OF
'MERCHANTIBILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.

'Requires the Trial or Release version of Visual Studio .NET Professional (or greater).

Option Strict On

Public Class frmControls
    Inherits System.Windows.Forms.Form

#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call

    End Sub

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
    Friend WithEvents txtDockedBottom As System.Windows.Forms.TextBox
    Friend WithEvents TextBox2 As System.Windows.Forms.TextBox
    Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtCSZ As System.Windows.Forms.TextBox
    Friend WithEvents txtAddress As System.Windows.Forms.TextBox
    Friend WithEvents txtName As System.Windows.Forms.TextBox
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.txtDockedBottom = New System.Windows.Forms.TextBox()
        Me.TextBox2 = New System.Windows.Forms.TextBox()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtCSZ = New System.Windows.Forms.TextBox()
        Me.txtAddress = New System.Windows.Forms.TextBox()
        Me.txtName = New System.Windows.Forms.TextBox()
        Me.SuspendLayout()
        '
        'txtDockedBottom
        '
        Me.txtDockedBottom.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.txtDockedBottom.Location = New System.Drawing.Point(0, 165)
        Me.txtDockedBottom.Multiline = True
        Me.txtDockedBottom.Name = "txtDockedBottom"
        Me.txtDockedBottom.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtDockedBottom.Size = New System.Drawing.Size(568, 184)
        Me.txtDockedBottom.TabIndex = 8
        Me.txtDockedBottom.Text = ""
        '
        'TextBox2
        '
        Me.TextBox2.Anchor = (System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right)
        Me.TextBox2.Location = New System.Drawing.Point(384, 128)
        Me.TextBox2.Name = "TextBox2"
        Me.TextBox2.Size = New System.Drawing.Size(56, 20)
        Me.TextBox2.TabIndex = 6
        Me.TextBox2.Text = ""
        '
        'TextBox1
        '
        Me.TextBox1.Anchor = (System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right)
        Me.TextBox1.Location = New System.Drawing.Point(448, 128)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(104, 20)
        Me.TextBox1.TabIndex = 7
        Me.TextBox1.Text = ""
        '
        'Label3
        '
        Me.Label3.Anchor = (System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left)
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(8, 128)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(78, 13)
        Me.Label3.TabIndex = 4
        Me.Label3.Text = "City, State, Zip"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(8, 40)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(46, 13)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Address"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(8, 16)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(34, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Name"
        '
        'txtCSZ
        '
        Me.txtCSZ.Anchor = ((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right)
        Me.txtCSZ.Location = New System.Drawing.Point(88, 128)
        Me.txtCSZ.Name = "txtCSZ"
        Me.txtCSZ.Size = New System.Drawing.Size(288, 20)
        Me.txtCSZ.TabIndex = 5
        Me.txtCSZ.Text = ""
        '
        'txtAddress
        '
        Me.txtAddress.Anchor = (((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right)
        Me.txtAddress.Location = New System.Drawing.Point(88, 40)
        Me.txtAddress.Multiline = True
        Me.txtAddress.Name = "txtAddress"
        Me.txtAddress.Size = New System.Drawing.Size(464, 80)
        Me.txtAddress.TabIndex = 3
        Me.txtAddress.Text = ""
        '
        'txtName
        '
        Me.txtName.Anchor = ((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right)
        Me.txtName.Location = New System.Drawing.Point(88, 16)
        Me.txtName.Name = "txtName"
        Me.txtName.Size = New System.Drawing.Size(464, 20)
        Me.txtName.TabIndex = 1
        Me.txtName.Text = ""
        '
        'frmControls
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(568, 349)
        Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.TextBox2, Me.TextBox1, Me.Label3, Me.Label2, Me.Label1, Me.txtCSZ, Me.txtAddress, Me.txtName, Me.txtDockedBottom})
        Me.Name = "frmControls"
        Me.Text = "Anchoring and Docked Controls"
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private Sub frmControls_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        txtDockedBottom.Text = "The Name textbox is anchored to the Top, Left and Right. It will automatically resize with the form, maintaining its relative position to those three points." & vbCrLf & vbCrLf
        txtDockedBottom.Text &= "The Address multiline textbox is anchored to the Top, Bottom, Left and Right. It will automatically resize all its dimensions with the form." & vbCrLf & vbCrLf
        txtDockedBottom.Text &= "The City textbox is anchored to the Bottom, Left and Right. The State and Zip textboxes are anchored to the Bottom and Right." & vbCrLf & vbCrLf
        txtDockedBottom.Text &= "This multiline text box is docked to the bottom of the form. It will maintain its original size and stay docked to the bottom when the form is resized. Docking " & ControlChars.Quote & "glues" & ControlChars.Quote & " a control to one or more edges of the form."
    End Sub
End Class
