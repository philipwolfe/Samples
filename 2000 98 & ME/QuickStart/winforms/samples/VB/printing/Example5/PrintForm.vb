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

Namespace Microsoft.Samples.WinForms.VB.PrintingExample5 

    Public Class PrintForm 
        Inherits System.WinForms.Form 
        
        private components As System.ComponentModel.Container 
	    private printButton As System.WinForms.Button 
	    private pageSetupButton As System.WinForms.Button 
	    private printPreviewButton As System.WinForms.Button 

        private storedPageSettings As PageSettings

        Public Sub New () 
            
            MyBase.New
            
            ' This call is required by the Windows Forms Designer.
            InitializeComponent()
            
        End Sub
    
        'Event fired when the user presses the page setup button
        Private Sub pageSetupButton_Click(sender As object, e As System.EventArgs)
            
            Try            
                Dim psDlg As New PageSetupDialog
            
                If (storedPageSettings Is Nothing) Then
                    storedPageSettings = new PageSettings()
                End If

                psDlg.PageSettings = storedPageSettings 
                psDlg.ShowDialog
            Catch ex As Exception
                MessageBox.Show("An error occurred - " + ex.Message)
            End Try
            
        End Sub
                             
                             
        'Event fired when the user presses the print button
        Private Sub printButton_Click(sender As object, e As System.EventArgs)
        
            Try 
                Dim streamToPrint As StreamReader = new StreamReader ("PrintMe.Txt")
                Try
                    'Assumes the default printer
                    Dim pd As TextFilePrintDocument = new TextFilePrintDocument(streamToPrint) 
                    
                    If (storedPageSettings <> Nothing) Then
                        pd.DefaultPageSettings = storedPageSettings 
                    End If

                    
                    Dim dlg As New PrintDialog
                    dlg.Document = pd
                    Dim result As DialogResult = dlg.ShowDialog()

                    If (result = System.WinForms.DialogResult.OK) Then
                        pd.Print()
                    End If
                    
                Finally
                    streamToPrint.Close() 
                End Try

            Catch ex As Exception
                MessageBox.Show("An error occurred printing the file - " + ex.Message)
            End Try
            
        End Sub

                    
        'Event fired when the user presses the print preview button
        Private Sub printPreviewButton_Click(sender As object, e As System.EventArgs)
        
            Try 
                Dim streamToPrint As StreamReader = new StreamReader ("PrintMe.Txt")
                Try
                    'Assumes the default printer
                    Dim pd As TextFilePrintDocument = new TextFilePrintDocument(streamToPrint) 
                    
                    If (storedPageSettings <> Nothing) Then
                        pd.DefaultPageSettings = storedPageSettings 
                    End If
                    
                    Dim dlg As New PrintPreviewDialog
                    dlg.Document = pd
                    dlg.ShowDialog()
                    
                Finally
                    streamToPrint.Close() 
                End Try

            Catch ex As Exception
                MessageBox.Show("An error occurred - " + ex.Message)
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
            Me.pageSetupButton = new System.WinForms.Button()
            Me.printPreviewButton = new System.WinForms.Button()
    		
    		Me.AutoScaleBaseSize = new System.Drawing.Size(5, 13)
    		Me.ClientSize = new System.Drawing.Size(504, 381)
    		Me.Text = "Print Example 5"
    		
    		printButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
    		printButton.Location = new System.Drawing.Point(32, 110)
    		printButton.FlatStyle = System.WinForms.FlatStyle.Flat
    		printButton.TabIndex = 0
    		printButton.Text = "Print the file"
    		printButton.Size = new System.Drawing.Size(136, 40)
    		AddHandler printButton.Click, AddressOf printButton_Click
    		
            pageSetupButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
    		pageSetupButton.Location = new System.Drawing.Point(32, 160)
    		pageSetupButton.FlatStyle = System.WinForms.FlatStyle.Flat
    		pageSetupButton.TabIndex = 1
    		pageSetupButton.Text = "Page Settings"
    		pageSetupButton.Size = new System.Drawing.Size(136, 40)
    		AddHandler pageSetupButton.Click, AddressOf pageSetupButton_Click

            printPreviewButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
    		printPreviewButton.Location = new System.Drawing.Point(32, 210)
    		printPreviewButton.FlatStyle = System.WinForms.FlatStyle.Flat
    		printPreviewButton.TabIndex = 2
    		printPreviewButton.Text = "Print Preview"
    		printPreviewButton.Size = new System.Drawing.Size(136, 40)
    		AddHandler printPreviewButton.Click, AddressOf printPreviewButton_Click
                                              
    		Me.Controls.Add(printButton)
    		Me.Controls.Add(pageSetupButton)
    		Me.Controls.Add(printPreviewButton)
    		
    	End Sub
        
        'The main entry point for the application
        Shared Sub Main()
            System.WinForms.Application.Run(New PrintForm())
        End Sub


    End Class

End Namespace











