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
Imports Microsoft.Samples.WinForms.VB.HelloWorldControl

Namespace Microsoft.Samples.WinForms.VB.HostApp 

    Public Class HostApp
        Inherits System.WinForms.Form 
        
        private components As System.ComponentModel.Container 
	    private helloWorldControl1 As Microsoft.Samples.WinForms.VB.HelloWorldControl.HelloWorldControl 

        Public Sub New() 
            MyBase.New
            
            ' Required by the Windows Forms Designer
            InitializeComponent

            ' TODO: Add any constructor code after InitializeComponent call
        End Sub

        Overrides Public Sub Dispose()
            MyBase.Dispose
            components.Dispose
        End Sub

        ' NOTE: The following code is required by the Windows Forms Designer
        ' Do not modify it 
        Private Sub InitializeComponent() 
		    Me.components = new System.ComponentModel.Container()
		    Me.helloWorldControl1 = new Microsoft.Samples.WinForms.VB.HelloWorldControl.HelloWorldControl()
		
		    helloWorldControl1.Dock = System.WinForms.DockStyle.Fill
		    helloWorldControl1.Size = new System.Drawing.Size(600, 450)
		    helloWorldControl1.TabIndex = 0
		    helloWorldControl1.Text = "Hello Windows Forms Control World"
		
		    Me.AutoScaleBaseSize = new System.Drawing.Size(5, 13)
		    Me.Text = "Control Example"
		    Me.ClientSize = new System.Drawing.Size(600, 450)
		
		    Me.Controls.Add(helloWorldControl1)
	    End Sub


        'The main entry point for the application
        Shared Sub Main()
            System.WinForms.Application.Run(New HostApp())
        End Sub

    End Class

End Namespace










