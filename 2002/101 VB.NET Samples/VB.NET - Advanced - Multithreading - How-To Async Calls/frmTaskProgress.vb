'Copyright (C) 2002 Microsoft Corporation
'All rights reserved.
'THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, EITHER 
'EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED WARRANTIES OF 
'MERCHANTIBILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.

'Requires the Trial or Release version of Visual Studio .NET Professional (or greater).

Option Strict On

Public Class frmTaskProgress
    Inherits System.Windows.Forms.Form

#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call

    End Sub

    'Form overrides dispose to clean up the component list.
    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing Then
            If Not (components Is Nothing) Then
                components.Dispose()
            End If
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    Friend WithEvents prgTaskProgress As System.Windows.Forms.ProgressBar
    Friend WithEvents lblLengthyTask As System.Windows.Forms.Label
    Friend WithEvents lblThreadID As System.Windows.Forms.Label
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
		Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmTaskProgress))
		Me.prgTaskProgress = New System.Windows.Forms.ProgressBar()
		Me.lblLengthyTask = New System.Windows.Forms.Label()
		Me.lblThreadID = New System.Windows.Forms.Label()
		Me.SuspendLayout()
		'
		'prgTaskProgress
		'
		Me.prgTaskProgress.Location = New System.Drawing.Point(32, 40)
		Me.prgTaskProgress.Name = "prgTaskProgress"
		Me.prgTaskProgress.Size = New System.Drawing.Size(216, 24)
		Me.prgTaskProgress.TabIndex = 0
		'
		'lblLengthyTask
		'
		Me.lblLengthyTask.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.lblLengthyTask.Location = New System.Drawing.Point(56, 72)
		Me.lblLengthyTask.Name = "lblLengthyTask"
		Me.lblLengthyTask.Size = New System.Drawing.Size(184, 16)
		Me.lblLengthyTask.TabIndex = 1
		Me.lblLengthyTask.Text = "Executing some lengthy task..."
		'
		'lblThreadID
		'
		Me.lblThreadID.ImeMode = System.Windows.Forms.ImeMode.NoControl
		Me.lblThreadID.Location = New System.Drawing.Point(32, 8)
		Me.lblThreadID.Name = "lblThreadID"
		Me.lblThreadID.Size = New System.Drawing.Size(272, 24)
		Me.lblThreadID.TabIndex = 5
		Me.lblThreadID.Text = "This window is being serviced by thread: "
		'
		'frmTaskProgress
		'
		Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
		Me.ClientSize = New System.Drawing.Size(292, 101)
		Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.lblThreadID, Me.lblLengthyTask, Me.prgTaskProgress})
		Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
		Me.Name = "frmTaskProgress"
		Me.Text = "Task Progress"
		Me.ResumeLayout(False)

	End Sub

#End Region

    Private Sub frmTaskProgress_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
		'Display the ID of the thread that is loading this form.
		Me.lblThreadID.Text &= CStr(AppDomain.GetCurrentThreadId())
	End Sub
End Class
