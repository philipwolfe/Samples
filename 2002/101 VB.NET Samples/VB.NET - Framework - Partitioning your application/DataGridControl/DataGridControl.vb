'Copyright (C) 2002 Microsoft Corporation
'All rights reserved.
'THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, EITHER 
'EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED WARRANTIES OF 
'MERCHANTIBILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.

'Requires the Trial or Release version of Visual Studio .NET Professional (or greater).

Option Strict On

Public Class DataGridControl
    Inherits System.Windows.Forms.UserControl

#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call

    End Sub

    'UserControl1 overrides dispose to clean up the component list.
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
    Friend WithEvents dgData As System.Windows.Forms.DataGrid
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.dgData = New System.Windows.Forms.DataGrid()
        CType(Me.dgData, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'dgData
        '
        Me.dgData.AllowNavigation = False
        Me.dgData.DataMember = ""
        Me.dgData.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgData.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.dgData.Name = "dgData"
        Me.dgData.ReadOnly = True
        Me.dgData.Size = New System.Drawing.Size(584, 150)
        Me.dgData.TabIndex = 0
        '
        'DataGridControl
        '
        Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.dgData})
        Me.Name = "DataGridControl"
        Me.Size = New System.Drawing.Size(584, 150)
        CType(Me.dgData, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

    Protected m_FileName As String

    Public Property FileName() As String
        ' Read/Write FileName property for use by
        ' data access procedures.
        Get
            ' Read FileName
            FileName = m_FileName
        End Get
        Set(ByVal Value As String)
            ' Write FileName
            m_FileName = Value
        End Set
    End Property

    Sub BindCustomers()
        ' Access the DataAccessComponent directly,
        ' populate the DataGrid with the results.
        ' Hides the details from the developer using
        ' this control.  If a new object was created 
        ' this code could change without affecting 
        ' any apps that use this control.
        Dim dtCustomers As DataTable

        ' Instantiate the data access object
        Dim oBusiness As DataAccessComponent.Business = New DataAccessComponent.Business()

        ' Pass the filename to open
        oBusiness.FileName = m_FileName

        ' Get a DataTable containing the customers
        ' in the file
        dtCustomers = oBusiness.GetCustomers

        ' Display results
        dgData.SetDataBinding(dtCustomers, "")
    End Sub
End Class
