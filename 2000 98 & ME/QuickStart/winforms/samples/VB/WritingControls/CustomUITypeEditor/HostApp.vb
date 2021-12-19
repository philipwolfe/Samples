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
Imports Microsoft.Samples.WinForms.VB.FlashTrackBar

                                                   
Namespace Microsoft.Samples.WinForms.VB.HostApp 

    Public Class HostApp
        Inherits System.WinForms.Form 
        
        Private components As System.ComponentModel.Container 
	    private flashTrackBar1 As Microsoft.Samples.WinForms.VB.FlashTrackBar.FlashTrackBar 

        Public Sub New() 
            MyBase.New
            
            ' Required by the Windows Forms Designer
            InitializeComponent

            ' TODO: Add any constructor code after InitializeComponent call
        End Sub

                                                   
        Private Sub InitializeComponent() 
    		Me.components = new System.ComponentModel.Container()
            Me.flashTrackBar1 = new Microsoft.Samples.WinForms.VB.FlashTrackBar.FlashTrackBar()
    		
    		flashTrackBar1.Dock = System.WinForms.DockStyle.Fill
    		flashTrackBar1.ForeColor = System.Drawing.Color.White
    		flashTrackBar1.BackColor = System.Drawing.Color.Black
    		flashTrackBar1.Size = new System.Drawing.Size(600, 450)
    		flashTrackBar1.TabIndex = 0
    		flashTrackBar1.Value = 73
    		flashTrackBar1.Text = "Drag the Mouse and say ""Wow!"""
    		
            Me.AutoScaleBaseSize = new System.Drawing.Size(5, 13)
    		Me.Text = "Control Example"
    		Me.ClientSize = new System.Drawing.Size(528, 325)
	
	    	Me.Controls.Add(flashTrackBar1)
    		
        End Sub
    	

        'The main entry point for the application
        Shared Sub Main()
            System.WinForms.Application.Run(New HostApp())
        End Sub


    End Class
    
End Namespace










