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

Namespace Microsoft.Samples.WinForms.VB.PrintingExample1 

    Public Class PrintingExample1 
        Inherits System.WinForms.Form 
        
        private components As System.ComponentModel.Container 
	    private printButton As System.WinForms.Button 

        private printFont As Font
        private streamToPrint As StreamReader 

        Public Sub New () 
            
            MyBase.New
            
            ' This call is required by the Windows Forms Designer.
            InitializeComponent()
            
        End Sub


        'Event fired when the user presses the print button
        Private Sub printButton_Click(sender As object, e As System.EventArgs)
        
            Try 
                streamToPrint = new StreamReader ("PrintMe.Txt")
                Try
                    printFont = new Font("Arial", 10)
                    Dim pd as PrintDocument = new PrintDocument() 'Assumes the default printer
                    AddHandler pd.PrintPage, AddressOf Me.pd_PrintPage
                    pd.Print()
                Finally
                    streamToPrint.Close() 
                End Try

            Catch ex As Exception
                MessageBox.Show("An error occurred printing the file - " + ex.Message)
            End Try
            
        End Sub

        'Event fired for each page to print
        Private Sub pd_PrintPage(sender As object, ev As System.Drawing.Printing.PrintPageEventArgs)
        
            Dim lpp As Single = 0 
            Dim yPos As Single =  0 
            Dim count As Integer = 0 
            Dim leftMargin As Single = ev.MarginBounds.Left
            Dim topMargin As Single = ev.MarginBounds.Top
            Dim line as String
            
            'Work out the number of lines per page 
            'Use the MarginBounds on the event to do this
            lpp = ev.MarginBounds.Height  / printFont.GetHeight(ev.Graphics) 

            'Now iterate over the file printing out each line
            'NOTE WELL: This assumes that a single line is not wider than the page width
            'Check count first so that we don't read line that we won't print
            line=streamToPrint.ReadLine()
            while (count < lpp AND line <> Nothing)
                
                yPos = topMargin + (count * printFont.GetHeight(ev.Graphics))
                
                'NOTE WELL: In the PDC Release you must pass a StringFormat to DrawString or the 
                'Print Preview control will not work. 
                ev.Graphics.DrawString (line, printFont, Brushes.Black, leftMargin, yPos, new StringFormat())
                
                count = count + 1

                if (count < lpp) then
                    line=streamToPrint.ReadLine()
                end if
                    
            End While

            'If we have more lines then print another page
            If (line <> Nothing) Then
                ev.HasMorePages = True 
            Else 
                ev.HasMorePages = False 
            End If 
            
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
    		Me.Text = "Print Example 1"
    		
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
            System.WinForms.Application.Run(New PrintingExample1())
        End Sub


    End Class

End Namespace






