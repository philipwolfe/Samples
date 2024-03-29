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
Imports System.WinForms
Imports System.Drawing
Imports System.Drawing.Printing
Imports System.IO

Namespace Microsoft.Samples.WinForms.VB.PrintingExample2 

    Public Class PrintForm 
        Inherits System.WinForms.Form 
        
        private components As System.ComponentModel.Container 
	    private printButton As System.WinForms.Button 

        Public Sub New () 
            
            MyBase.New
            
            ' This call is required by the Windows Forms Designer.
            InitializeComponent()
            
        End Sub
    
        'Event fired when the user presses the print button
        Private Sub printButton_Click(sender As object, e As System.EventArgs)
        
            Try 
                Dim streamToPrint As StreamReader = new StreamReader ("PrintMe.Txt")
                Try
                    'Assumes the default printer
                    Dim pd As TextFilePrintDocument = new TextFilePrintDocument(streamToPrint) 
                    pd.Print()
                Finally
                    streamToPrint.Close() 
                End Try

            Catch ex As Exception
                MessageBox.Show("An error occurred printing the file - " + ex.Message)
            End Try
            
        End Sub

        Overrides Public Sub Dispose()
            MyBase.Dispose
            components.Dispose
        End Sub
    

        ' NOTE: The following code is required by the Windows Forms Designer
        ' Do not modify it 
        Private Sub InitializeComponent() 
		
    		Me.components = new System.ComponentModel.Container()
    		Me.printButton = new System.WinForms.Button()
    		
    		Me.AutoScaleBaseSize = new System.Drawing.Size(5, 13)
    		Me.ClientSize = new System.Drawing.Size(504, 381)
    		Me.Text = "Print Example 2"
    		
    		printButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
    		printButton.Location = new System.Drawing.Point(32, 110)
    		printButton.FlatStyle = System.WinForms.FlatStyle.Flat
    		printButton.TabIndex = 0
    		printButton.Text = "Print the file"
    		printButton.Size = new System.Drawing.Size(136, 40)
    		AddHandler printButton.Click, AddressOf printButton_Click
    		
    		Me.Controls.Add(printButton)
    		
    	End Sub
        
        'The main entry point for the application
        Shared Sub Main()
            System.WinForms.Application.Run(New PrintForm())
        End Sub


    End Class

End Namespace











