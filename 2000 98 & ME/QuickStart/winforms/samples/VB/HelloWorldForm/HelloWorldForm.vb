'------------------------------------------------------------------------------
'/ <copyright from='1997' to='2001' company='Microsoft Corporation'>           
'/    Copyright (c) Microsoft Corporation. All Rights Reserved.                
'/       
'/    This source code is intended only as a supplement to Microsoft
'/    Development Tools and/or on-line documentation.  See these other
'/    materials for detailed information regarding Microsoft code samples.
'/
'/ </copyright>                                                                
'------------------------------------------------------------------------------
Imports System
Imports System.ComponentModel
Imports System.Drawing
Imports System.WinForms

Namespace Microsoft.Samples.WinForms.VB.HelloWorldForm 

    Public Class HelloWorldForm
        Inherits Form

        Private components As Container
        
        'Declare the buttons using WithEvents so that we can register declarative 
        'event handlers
        Private WithEvents button1 as Button
        Private WithEvents button2 As Button
        
        Private textBox1 As New TextBox

        'When the application is started show the Form
        Shared Sub Main()
            System.WinForms.Application.Run(New HelloWorldForm())
        End Sub
    
        Public Sub New()
           
            MyBase.New
    
            'Set up the Form
            Me.Text = "Hello WinForms World"
            Me.AutoScaleBaseSize = new Size(5, 13)
            Me.ClientSize = new Size(392, 117)

            'Set the minimum form size to the client size + the height of the title bar
            Me.MinTrackSize = new Size(392, (117 + SystemInformation.CaptionHeight))

            'Create button1
            button1 = new Button()
            button1.Location = new Point(56, 64)
            button1.Size = new Size(90, 40)
            button1.TabIndex = 2
            button1.Text = "Click Me!"

            'Create button2
            button2 = new Button()
            button2.Location = new Point(156, 64)
            button2.Size = new Size(90, 40)
            button2.TabIndex = 3
            button2.Text = "Click Me Too!"

            'Create the text box
            textBox1.Text = "Hello WinForms World"
            textBox1.TabIndex = 1
            textBox1.Size = new Size(360, 20)
            textBox1.Location = new Point(16, 24)

            'Set the default button on the form
            Me.AcceptButton=button1	
            
            'Add the controls to the form
            Me.Controls.Add(button1)
            Me.Controls.Add(button2)
            Me.Controls.Add(textBox1)

        End Sub

        'Called when the Form closes
        'Note that the MessageBox call is simply to
        'demonstrate that Dispose is called. You 
        'should keep your Dispose method code as simple and 
        'robust as possible
        Overrides Public Sub Dispose()
            MyBase.Dispose()
            Try 		
                MessageBox.Show("Disposed!")
            Catch ex As Exception
            End Try
            
        End Sub

        'The event handling method for button1 - registered by the compiler
        'because the name matches <controlname>_<eventname>
        Private Sub button1_Click(sender As Object, evArgs As EventArgs) 
            
            'Disable button1 - we only want to add one button
            button1.Enabled=False
            
            'Add the new button and add an event handler using AddHandler                             
            Dim newButton As new Button
            newButton = new Button()
            newButton.Location = new Point(256, 64)
            newButton.Size = new Size(90, 40)
            newButton.TabIndex = 4
            newButton.Text = "Click Me Three!"
            Me.Controls.Add(newButton)
            
            AddHandler newButton.Click, AddressOf Me.clickNewbutton
        End Sub

        'The event handling method for button2 - registered using Handles
        Private Sub OnButton2Click(sender As Object, ByVal evArgs As EventArgs) Handles button2.Click
            MessageBox.Show("Text is: '" + textBox1.Text + "'")
        End Sub

        'The event handling method for the new button -  registered using AddHandler
        Private Sub clickNewbutton(sender As Object, evArgs As EventArgs)
            MessageBox.Show("Hello from the new Button")
        End Sub
        
    End Class
    
End Namespace









