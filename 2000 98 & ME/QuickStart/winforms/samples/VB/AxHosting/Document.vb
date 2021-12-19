''------------------------------------------------------------------------------
''/ <copyright from='1997' to='2001' company='Microsoft Corporation'>           
''/    Copyright (c) Microsoft Corporation. All Rights Reserved.                
''/       
''/    This source code is intended only as a supplement to Microsoft
''/    Development Tools and/or on-line documentation.  See these other
''/    materials for detailed information regarding Microsoft code samples.
''/
''/ </copyright>                                                                
''------------------------------------------------------------------------------
Imports System
Imports System.ComponentModel
Imports System.Drawing
Imports System.WinForms
Imports AxSHDocVw

Namespace Microsoft.Samples.WinForms.VB.AxHosting 

    Public Class Document
        Inherits System.WinForms.Form

        'Required by the Windows Forms Designer   
        Private components As System.ComponentModel.Container
        Private label1 As System.WinForms.Label
        Private panel1 As System.WinForms.Panel
        Private textBox1 As System.WinForms.TextBox
        Private AxWebBrowser1 As AxSHDocVw.AxWebBrowser
        Private buttonGo As System.WinForms.Button
    
        Public Sub New()
           MyBase.New
    
           'This call is required by the Windows Forms Designer.
           InitializeComponent
    
           ' TODO: Add any constructor code after InitializeComponent call
           Me.Text = "New Web Browser"

           'Handle the Title Change event so that we can update the caption and the 
           'status bar on our parent
           
           AddHandler AxWebBrowser1.TitleChange, AddressOf Me.AxWebBrowser1_TitleChanged

           'Once the Browser Control has been created we can interact with it
           'So hook the handle created event and use  this to navigate 
           'to the start page
           AddHandler AxWebBrowser1.HandleCreated, AddressOf Me.AxWebBrowser1_Created

           'Set the minimum form size 
           Me.MinTrackSize = new Size(100, 100)
        End Sub

        'The WebBrowser has been created so complete initialisation
    	Private Sub AxWebBrowser1_Created(sender As object, evArgs As EventArgs) 
	        
           'Navigate to the starting page
	       buttonGo_Click(buttonGo, EventArgs.Empty)

           'Don't need this event handler any more so remove it 
           RemoveHandler AxWebBrowser1.HandleCreated, AddressOf Me.AxWebBrowser1_Created
            
	    End Sub


        'Handle the title changed event
        Private Sub AxWebBrowser1_TitleChanged(sender As object, e As DWebBrowserEvents2_TitleChangeEvent) 
            Me.Text =  e.p_text
            Dim f As MainForm = CType(Me.MDIParent,MainForm)
            f.statusBar1.Text=Me.Text
        End Sub


        'Handle the click of the go button
        Private Sub buttonGo_Click(sender As object, evArgs As EventArgs) 

            Dim currentCursor As Cursor = Cursor.Current
            Try 
                Cursor.Current = Cursors.WaitCursor

                AxWebBrowser1.Navigate(textBox1.Text,0,"", "", "")

            Finally 
                Cursor.Current = currentCursor 
            End Try
            
        End Sub


        'Clean up any resources being used
        Overrides Public Sub Dispose()
            MyBase.Dispose
            components.Dispose
        End Sub 


        'NOTE: The following procedure is required by the Windows Forms Designer
        'Do not modify it.
        Private Sub InitializeComponent() 
            Me.components = New System.ComponentModel.Container
            Me.textBox1 = New System.WinForms.TextBox
            Me.panel1 = New System.WinForms.Panel
            Me.label1 = New System.WinForms.Label
            Me.AxWebBrowser1 = New AxSHDocVw.AxWebBrowser
            Me.buttonGo = New System.WinForms.Button

            AxWebBrowser1.BeginInit()

            textBox1.Location = New System.Drawing.Point(56, 1)
            textBox1.Text = "http://localhost/quickstart/winforms/samples/cs/axhosting/WinForms.html"
            textBox1.Anchor = System.WinForms.AnchorStyles.LeftRight
            textBox1.BorderStyle = System.WinForms.BorderStyle.FixedSingle
            textBox1.TabIndex = 1
            textBox1.Size = New System.Drawing.Size(504, 20)

            panel1.Dock = System.WinForms.DockStyle.Top
            panel1.Size = New System.Drawing.Size(650, 24)
            panel1.TabIndex = 0
            panel1.Text = "panel1"

            label1.Location = New System.Drawing.Point(0, 4)
            label1.Text = "Address:"
            label1.Anchor = System.WinForms.AnchorStyles.Left
            label1.Size = New System.Drawing.Size(64, 16)
            label1.TabIndex = 0

            Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
            '@design Me.TrayLargeIcon = True
            Me.AcceptButton = buttonGo
            '@design Me.TrayHeight = 0
            Me.ClientSize = New System.Drawing.Size(650, 480)

            AxWebBrowser1.Location = New System.Drawing.Point(0, 24)
            AxWebBrowser1.Size = New System.Drawing.Size(650, 456)
            AxWebBrowser1.Dock = System.WinForms.DockStyle.Fill
            AxWebBrowser1.TabIndex = 3

            buttonGo.Location = New System.Drawing.Point(562, 0)
            buttonGo.FlatStyle = System.WinForms.FlatStyle.Flat
            buttonGo.Size = New System.Drawing.Size(88, 24)
            buttonGo.TabIndex = 2
            buttonGo.Anchor = System.WinForms.AnchorStyles.Right
            buttonGo.Text = "&Go"
            AddHandler buttonGo.Click, AddressOf buttonGo_Click

            Me.Controls.Add(panel1)
            panel1.Controls.Add(textBox1)
            panel1.Controls.Add(buttonGo)
            panel1.Controls.Add(label1)
            Me.Controls.Add(AxWebBrowser1)

            AxWebBrowser1.EndInit()
        End Sub

    End Class

End Namespace










