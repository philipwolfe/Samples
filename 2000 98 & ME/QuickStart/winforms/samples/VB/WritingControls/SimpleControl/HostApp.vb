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
Imports Microsoft.Samples.WinForms.VB.SimpleControl

                                                   
Namespace Microsoft.Samples.WinForms.VB.HostApp 

    Public Class HostApp
        Inherits System.WinForms.Form 
        
        Private components As System.ComponentModel.Container 
    	Private radioButton3 As System.WinForms.RadioButton 
	    Private radioButton2 As System.WinForms.RadioButton 
	    Private radioButton1 As System.WinForms.RadioButton 
	    Private groupBox1 As System.WinForms.GroupBox 
	    Private simpleControl1 As Microsoft.Samples.WinForms.VB.SimpleControl.SimpleControl 

        Public Sub New() 
            MyBase.New
            
            ' Required by the Windows Forms Designer
            InitializeComponent

            ' TODO: Add any constructor code after InitializeComponent call
        End Sub

                                                   
        Private Sub radioButton3_CheckedChanged(sender As object, e As System.EventArgs)
    	    If (radioButton3.Checked) Then
                simpleControl1.DrawingMode = DrawingModeStyle.Angry
            End If
        End Sub
    	
        Private Sub radioButton2_CheckedChanged(sender As object, e As System.EventArgs)
    	    If (radioButton2.Checked) Then
                simpleControl1.DrawingMode = DrawingModeStyle.Sad
            End If
        End Sub
    	
        Private Sub radioButton1_CheckedChanged(sender As object, e As System.EventArgs)
    	    If (radioButton1.Checked) Then
                simpleControl1.DrawingMode = DrawingModeStyle.Happy
            End If
        End Sub
    	
        Private Sub simpleControl1_DrawingModeChanged(sender As object, e As System.EventArgs)
            
            Select Case (simpleControl1.DrawingMode) 
                 
                Case DrawingModeStyle.Happy:
                    MessageBox.Show("Well that's good to know")
 
                Case DrawingModeStyle.Sad:
                    MessageBox.Show("Come on cheer up!")
 
                Case DrawingModeStyle.Angry:
                    MessageBox.Show("Well calm down then!")
 
                Case Else 
                    MessageBox.Show("Please make up your mind")
                    
            End Select
              
        End Sub


        Private Sub InitializeComponent() 
    		Me.components = new System.ComponentModel.Container()
    		Me.radioButton1 = new System.WinForms.RadioButton()
    		Me.radioButton3 = new System.WinForms.RadioButton()
    		Me.groupBox1 = new System.WinForms.GroupBox()
    		Me.simpleControl1 = new Microsoft.Samples.WinForms.VB.SimpleControl.SimpleControl()
    		Me.radioButton2 = new System.WinForms.RadioButton()
    		
    		radioButton1.Location = new System.Drawing.Point(24, 24)
    		radioButton1.Size = new System.Drawing.Size(128, 24)
    		radioButton1.TabIndex = 0
    		radioButton1.TabStop = true
    		radioButton1.Text = "Happy"
    		radioButton1.Checked = true
    		AddHandler radioButton1.CheckedChanged, AddressOf radioButton1_CheckedChanged
    		
    		radioButton3.Location = new System.Drawing.Point(24, 104)
    		radioButton3.Size = new System.Drawing.Size(128, 24)
    		radioButton3.TabIndex = 2
    		radioButton3.Text = "Angry"
    		AddHandler radioButton3.CheckedChanged, AddressOf radioButton3_CheckedChanged
    		
    		groupBox1.Size = new System.Drawing.Size(192, 152)
    		groupBox1.TabIndex = 1
    		groupBox1.Anchor = System.WinForms.AnchorStyles.TopRight
    		groupBox1.TabStop = false
    		groupBox1.Text = "I am"
    		groupBox1.Location = new System.Drawing.Point(320, 16)
    		
    		Me.AutoScaleBaseSize = new System.Drawing.Size(5, 13)
    		Me.Text = "Control Example"
    		Me.ClientSize = new System.Drawing.Size(528, 325)
    		
    		simpleControl1.Size = new System.Drawing.Size(304, 328)
    		simpleControl1.TabIndex = 0
    		simpleControl1.Anchor = System.WinForms.AnchorStyles.All
    		simpleControl1.Font = new System.Drawing.Font("TAHOMA", 16f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.World)
    		simpleControl1.Text = "Windows Forms Mood Control"
    		AddHandler simpleControl1.DrawingModeChanged, AddressOf simpleControl1_DrawingModeChanged
    		
    		radioButton2.Location = new System.Drawing.Point(24, 64)
    		radioButton2.Size = new System.Drawing.Size(128, 24)
    		radioButton2.TabIndex = 1
    		radioButton2.Text = "Sad"
    		AddHandler radioButton2.CheckedChanged, AddressOf radioButton2_CheckedChanged
    		
    		Me.Controls.Add(groupBox1)
    		Me.Controls.Add(simpleControl1)
    		groupBox1.Controls.Add(radioButton3)
    		groupBox1.Controls.Add(radioButton2)
    		groupBox1.Controls.Add(radioButton1)
    		
        End Sub
    	

        'The main entry point for the application
        Shared Sub Main()
            System.WinForms.Application.Run(New HostApp())
        End Sub


    End Class
    
End Namespace










