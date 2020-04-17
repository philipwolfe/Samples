'---------------------------------------------------------------------
'  This file is part of the Microsoft .NET Framework SDK Code Samples.
' 
'  Copyright (C) Microsoft Corporation.  All rights reserved.
' 
'This source code is intended only as a supplement to Microsoft
'Development Tools and/or on-line documentation.  See these other
'materials for detailed information regarding Microsoft code samples.
' 
'THIS CODE AND INFORMATION ARE PROVIDED AS IS WITHOUT WARRANTY OF ANY
'KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE
'IMPLIED WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A
'PARTICULAR PURPOSE.
'---------------------------------------------------------------------
Partial Public Class MainForm
    Inherits System.Windows.Forms.Form

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call

    End Sub

    'Form overrides dispose to clean up the component list.
    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerNonUserCode()> Private Sub InitializeComponent()
        Me.btnAsyncPictureBoxSample = New System.Windows.Forms.Button
        Me.btnAsyncWebClientSample = New System.Windows.Forms.Button
        Me.btnAsyncWebServiceSample = New System.Windows.Forms.Button
        Me.btnBackgroundWorkerSample = New System.Windows.Forms.Button
        Me.tableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel
        Me.label4 = New System.Windows.Forms.Label
        Me.label3 = New System.Windows.Forms.Label
        Me.label2 = New System.Windows.Forms.Label
        Me.label1 = New System.Windows.Forms.Label
        Me.tableLayoutPanel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnAsyncPictureBoxSample
        '
        Me.btnAsyncPictureBoxSample.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.btnAsyncPictureBoxSample.Location = New System.Drawing.Point(3, 17)
        Me.btnAsyncPictureBoxSample.Name = "btnAsyncPictureBoxSample"
        Me.btnAsyncPictureBoxSample.Size = New System.Drawing.Size(188, 26)
        Me.btnAsyncPictureBoxSample.TabIndex = 0
        Me.btnAsyncPictureBoxSample.Text = "Async &PictureBox sample"
        '
        'btnAsyncWebClientSample
        '
        Me.btnAsyncWebClientSample.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.btnAsyncWebClientSample.Location = New System.Drawing.Point(3, 77)
        Me.btnAsyncWebClientSample.Name = "btnAsyncWebClientSample"
        Me.btnAsyncWebClientSample.Size = New System.Drawing.Size(188, 26)
        Me.btnAsyncWebClientSample.TabIndex = 1
        Me.btnAsyncWebClientSample.Text = "Async Web &Client sample"
        '
        'btnAsyncWebServiceSample
        '
        Me.btnAsyncWebServiceSample.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.btnAsyncWebServiceSample.Location = New System.Drawing.Point(3, 137)
        Me.btnAsyncWebServiceSample.Name = "btnAsyncWebServiceSample"
        Me.btnAsyncWebServiceSample.Size = New System.Drawing.Size(188, 26)
        Me.btnAsyncWebServiceSample.TabIndex = 2
        Me.btnAsyncWebServiceSample.Text = "Async Web &Service sample"
        '
        'btnBackgroundWorkerSample
        '
        Me.btnBackgroundWorkerSample.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.btnBackgroundWorkerSample.Location = New System.Drawing.Point(3, 197)
        Me.btnBackgroundWorkerSample.Name = "btnBackgroundWorkerSample"
        Me.btnBackgroundWorkerSample.Size = New System.Drawing.Size(188, 26)
        Me.btnBackgroundWorkerSample.TabIndex = 3
        Me.btnBackgroundWorkerSample.Text = "&BackgroundWorker sample"
        '
        'tableLayoutPanel1
        '
        Me.tableLayoutPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.tableLayoutPanel1.ColumnCount = 2
        Me.tableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle)
        Me.tableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.tableLayoutPanel1.Controls.Add(Me.label4, 1, 3)
        Me.tableLayoutPanel1.Controls.Add(Me.label3, 1, 2)
        Me.tableLayoutPanel1.Controls.Add(Me.label2, 1, 1)
        Me.tableLayoutPanel1.Controls.Add(Me.btnAsyncPictureBoxSample, 0, 0)
        Me.tableLayoutPanel1.Controls.Add(Me.btnBackgroundWorkerSample, 0, 3)
        Me.tableLayoutPanel1.Controls.Add(Me.btnAsyncWebClientSample, 0, 1)
        Me.tableLayoutPanel1.Controls.Add(Me.btnAsyncWebServiceSample, 0, 2)
        Me.tableLayoutPanel1.Controls.Add(Me.label1, 1, 0)
        Me.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tableLayoutPanel1.Location = New System.Drawing.Point(10, 10)
        Me.tableLayoutPanel1.Name = "tableLayoutPanel1"
        Me.tableLayoutPanel1.RowCount = 5
        Me.tableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 60.0!))
        Me.tableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 60.0!))
        Me.tableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 60.0!))
        Me.tableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 60.0!))
        Me.tableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 60.0!))
        Me.tableLayoutPanel1.Size = New System.Drawing.Size(422, 244)
        Me.tableLayoutPanel1.TabIndex = 4
        '
        'label4
        '
        Me.label4.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.label4.AutoSize = True
        Me.label4.Location = New System.Drawing.Point(197, 190)
        Me.label4.Name = "label4"
        Me.label4.Size = New System.Drawing.Size(221, 39)
        Me.label4.TabIndex = 7
        Me.label4.Text = "This sample demonstrates how to use the BackgroundWorker component to execute a l" & _
            "ong running task in the background."
        '
        'label3
        '
        Me.label3.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.label3.AutoSize = True
        Me.label3.Location = New System.Drawing.Point(197, 137)
        Me.label3.Name = "label3"
        Me.label3.Size = New System.Drawing.Size(176, 26)
        Me.label3.TabIndex = 6
        Me.label3.Text = "This sample demonstrates how to asynchronously call a Web Service."
        '
        'label2
        '
        Me.label2.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.label2.AutoSize = True
        Me.label2.Location = New System.Drawing.Point(197, 70)
        Me.label2.Name = "label2"
        Me.label2.Size = New System.Drawing.Size(221, 39)
        Me.label2.TabIndex = 5
        Me.label2.Text = "This sample demonstrates how to asynchronously retrieve a large file from a Web S" & _
            "erver using the WebClient component."
        '
        'label1
        '
        Me.label1.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.label1.AutoSize = True
        Me.label1.Location = New System.Drawing.Point(197, 10)
        Me.label1.Name = "label1"
        Me.label1.Size = New System.Drawing.Size(181, 39)
        Me.label1.TabIndex = 4
        Me.label1.Text = "This sample demonstrates how to asynchronously load an image into a PictureBox co" & _
            "ntrol."
        '
        'MainForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(442, 264)
        Me.Controls.Add(Me.tableLayoutPanel1)
        Me.MinimumSize = New System.Drawing.Size(450, 298)
        Me.Name = "MainForm"
        Me.Padding = New System.Windows.Forms.Padding(10)
        Me.Text = "Event Based Async Samples"
        Me.tableLayoutPanel1.ResumeLayout(False)
        Me.tableLayoutPanel1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents btnAsyncPictureBoxSample As System.Windows.Forms.Button
    Friend WithEvents btnAsyncWebClientSample As System.Windows.Forms.Button
    Friend WithEvents btnAsyncWebServiceSample As System.Windows.Forms.Button
    Friend WithEvents btnBackgroundWorkerSample As System.Windows.Forms.Button
    Friend WithEvents tableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents label1 As System.Windows.Forms.Label
    Friend WithEvents label4 As System.Windows.Forms.Label
    Friend WithEvents label3 As System.Windows.Forms.Label
    Friend WithEvents label2 As System.Windows.Forms.Label

End Class
