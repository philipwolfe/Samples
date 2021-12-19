'//------------------------------------------------------------------------------
'/// <copyright from='1997' to='2001' company='Microsoft Corporation'>           
'///    Copyright (c) Microsoft Corporation. All Rights Reserved.                
'///       
'///    This source code is intended only as a supplement to Microsoft
'///    Development Tools and/or on-line documentation.  See these other
'///    materials for detailed information regarding Microsoft code samples.
'///
'/// </copyright>                                                                
'//------------------------------------------------------------------------------
Imports System
Imports System.ComponentModel
Imports System.Drawing
Imports System.WinForms

Namespace Microsoft.Samples.WinForms.VB.Accessible

    Public Class Accessible
        Inherits System.WinForms.Form

        'Required by the Windows Forms Designer   
        Private components As System.ComponentModel.Container
        Private button1 As System.WinForms.Button
        Private textBox1 As System.WinForms.TextBox
    
        Public Sub New()
           MyBase.New
    
           'This call is required by the Windows Forms Designer.
           InitializeComponent
    
           ' TODO: Add any constructor code after InitializeComponent call
           'Set the minimum form size to the client size + the height of the title bar
           Me.MinTrackSize = new Size(392, (117 + SystemInformation.CaptionHeight))

        End Sub

        'Clean up any resources being used
        Overrides Public Sub Dispose()
            MyBase.Dispose
            components.Dispose
        End Sub 

        'The main entry point for the application
        Shared Sub Main()
            System.WinForms.Application.Run(New Accessible())
        End Sub

        'NOTE: The following procedure is required by the Windows Forms Designer
        'Do not modify it.
        Private Sub InitializeComponent() 
            Me.components = New System.ComponentModel.Container
            Me.button1 = New System.WinForms.Button
            Me.textBox1 = New System.WinForms.TextBox

            button1.AccessibleDescription = "Once you've entered some text push this button"
            button1.Location = New System.Drawing.Point(256, 64)
            button1.Size = New System.Drawing.Size(120, 40)
            button1.TabIndex = 1
            button1.Text = "Click Me!"
            button1.AccessibleName = "DefaultAction"
            AddHandler button1.Click, New System.EventHandler(AddressOf Me.button1_Click)
            button1.Anchor = System.WinForms.AnchorStyles.BottomRight


            textBox1.Location = New System.Drawing.Point(16, 24)
            textBox1.Text = "Hello WinForms World"
            textBox1.Anchor = System.WinForms.AnchorStyles.All
            textBox1.AccessibleName = "TextEntryField"
            textBox1.TabIndex = 0
            textBox1.AccessibleDescription = "Please enter some text in the box"
            textBox1.Size = New System.Drawing.Size(360, 20)

            Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
            Me.Text = "Accessibility"
            '@design Me.TrayLargeIcon = True
            Me.AccessibleRole = System.WinForms.AccessibleRoles.Window
            Me.AccessibleName = "AccessibleForm"
            Me.AcceptButton = button1
            '@design Me.TrayHeight = 0
            Me.AccessibleDescription = "Simple Form that demonstrates accessibility"
            Me.ClientSize = New System.Drawing.Size(392, 117)

            Me.Controls.Add(textBox1)
            Me.Controls.Add(button1)

        End Sub


        Protected Sub button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) 
            MessageBox.Show("Text is: '" + textBox1.Text + "'")
        End Sub

    
    End Class

End Namespace
