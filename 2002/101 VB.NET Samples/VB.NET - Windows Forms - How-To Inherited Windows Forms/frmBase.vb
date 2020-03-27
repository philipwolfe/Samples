'Copyright (C) 2002 Microsoft Corporation
'All rights reserved.
'THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, EITHER 
'EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED WARRANTIES OF 
'MERCHANTIBILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.

'Requires the Trial or Release version of Visual Studio .NET Professional (or greater).

Option Strict On

Imports System.Data.SqlClient

Public Class frmBase
    Inherits System.Windows.Forms.Form

    ' Initialize constants for connecting to the database
    ' and displaying a connection error to the user.
    Protected Const SQL_CONNECTION_STRING As String = _
        "Server=localhost;" & _
        "DataBase=Northwind;" & _
        "Integrated Security=SSPI"

    Protected Const MSDE_CONNECTION_STRING As String = _
        "Server=(local)\NetSDK;" & _
        "DataBase=Northwind;" & _
        "Integrated Security=SSPI"

    Protected Const CONNECTION_ERROR_MSG As String = _
        "To run this sample, you must have SQL " & _
        "or MSDE with the Northwind database installed.  For " & _
        "instructions on installing MSDE, view the ReadMe file."

    Protected DidPreviouslyConnect As Boolean = False
    Protected DidCreateTable As Boolean = False
    Protected connectionString As String = SQL_CONNECTION_STRING

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
    Friend WithEvents lblTitle As System.Windows.Forms.Label
    Friend WithEvents btnClose As System.Windows.Forms.Button
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Protected WithEvents lblProtected As System.Windows.Forms.Label
    Private WithEvents lblPrivate As System.Windows.Forms.Label
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmBase))
        Me.lblTitle = New System.Windows.Forms.Label()
        Me.btnClose = New System.Windows.Forms.Button()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.lblProtected = New System.Windows.Forms.Label()
        Me.lblPrivate = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'lblTitle
        '
        Me.lblTitle.AccessibleDescription = resources.GetString("lblTitle.AccessibleDescription")
        Me.lblTitle.AccessibleName = resources.GetString("lblTitle.AccessibleName")
        Me.lblTitle.Anchor = CType(resources.GetObject("lblTitle.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.lblTitle.AutoSize = CType(resources.GetObject("lblTitle.AutoSize"), Boolean)
        Me.lblTitle.BackColor = System.Drawing.SystemColors.Control
        Me.lblTitle.Dock = CType(resources.GetObject("lblTitle.Dock"), System.Windows.Forms.DockStyle)
        Me.lblTitle.Enabled = CType(resources.GetObject("lblTitle.Enabled"), Boolean)
        Me.lblTitle.Font = CType(resources.GetObject("lblTitle.Font"), System.Drawing.Font)
        Me.lblTitle.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblTitle.Image = CType(resources.GetObject("lblTitle.Image"), System.Drawing.Image)
        Me.lblTitle.ImageAlign = CType(resources.GetObject("lblTitle.ImageAlign"), System.Drawing.ContentAlignment)
        Me.lblTitle.ImageIndex = CType(resources.GetObject("lblTitle.ImageIndex"), Integer)
        Me.lblTitle.ImeMode = CType(resources.GetObject("lblTitle.ImeMode"), System.Windows.Forms.ImeMode)
        Me.lblTitle.Location = CType(resources.GetObject("lblTitle.Location"), System.Drawing.Point)
        Me.lblTitle.Name = "lblTitle"
        Me.lblTitle.RightToLeft = CType(resources.GetObject("lblTitle.RightToLeft"), System.Windows.Forms.RightToLeft)
        Me.lblTitle.Size = CType(resources.GetObject("lblTitle.Size"), System.Drawing.Size)
        Me.lblTitle.TabIndex = CType(resources.GetObject("lblTitle.TabIndex"), Integer)
        Me.lblTitle.Text = resources.GetString("lblTitle.Text")
        Me.lblTitle.TextAlign = CType(resources.GetObject("lblTitle.TextAlign"), System.Drawing.ContentAlignment)
        Me.lblTitle.Visible = CType(resources.GetObject("lblTitle.Visible"), Boolean)
        '
        'btnClose
        '
        Me.btnClose.AccessibleDescription = resources.GetString("btnClose.AccessibleDescription")
        Me.btnClose.AccessibleName = resources.GetString("btnClose.AccessibleName")
        Me.btnClose.Anchor = CType(resources.GetObject("btnClose.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.btnClose.BackColor = System.Drawing.SystemColors.Control
        Me.btnClose.BackgroundImage = CType(resources.GetObject("btnClose.BackgroundImage"), System.Drawing.Image)
        Me.btnClose.Dock = CType(resources.GetObject("btnClose.Dock"), System.Windows.Forms.DockStyle)
        Me.btnClose.Enabled = CType(resources.GetObject("btnClose.Enabled"), Boolean)
        Me.btnClose.FlatStyle = CType(resources.GetObject("btnClose.FlatStyle"), System.Windows.Forms.FlatStyle)
        Me.btnClose.Font = CType(resources.GetObject("btnClose.Font"), System.Drawing.Font)
        Me.btnClose.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnClose.Image = CType(resources.GetObject("btnClose.Image"), System.Drawing.Image)
        Me.btnClose.ImageAlign = CType(resources.GetObject("btnClose.ImageAlign"), System.Drawing.ContentAlignment)
        Me.btnClose.ImageIndex = CType(resources.GetObject("btnClose.ImageIndex"), Integer)
        Me.btnClose.ImeMode = CType(resources.GetObject("btnClose.ImeMode"), System.Windows.Forms.ImeMode)
        Me.btnClose.Location = CType(resources.GetObject("btnClose.Location"), System.Drawing.Point)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.RightToLeft = CType(resources.GetObject("btnClose.RightToLeft"), System.Windows.Forms.RightToLeft)
        Me.btnClose.Size = CType(resources.GetObject("btnClose.Size"), System.Drawing.Size)
        Me.btnClose.TabIndex = CType(resources.GetObject("btnClose.TabIndex"), Integer)
        Me.btnClose.Text = resources.GetString("btnClose.Text")
        Me.btnClose.TextAlign = CType(resources.GetObject("btnClose.TextAlign"), System.Drawing.ContentAlignment)
        Me.btnClose.Visible = CType(resources.GetObject("btnClose.Visible"), Boolean)
        '
        'PictureBox1
        '
        Me.PictureBox1.AccessibleDescription = resources.GetString("PictureBox1.AccessibleDescription")
        Me.PictureBox1.AccessibleName = resources.GetString("PictureBox1.AccessibleName")
        Me.PictureBox1.Anchor = CType(resources.GetObject("PictureBox1.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.PictureBox1.BackgroundImage = CType(resources.GetObject("PictureBox1.BackgroundImage"), System.Drawing.Image)
        Me.PictureBox1.Dock = CType(resources.GetObject("PictureBox1.Dock"), System.Windows.Forms.DockStyle)
        Me.PictureBox1.Enabled = CType(resources.GetObject("PictureBox1.Enabled"), Boolean)
        Me.PictureBox1.Font = CType(resources.GetObject("PictureBox1.Font"), System.Drawing.Font)
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Bitmap)
        Me.PictureBox1.ImeMode = CType(resources.GetObject("PictureBox1.ImeMode"), System.Windows.Forms.ImeMode)
        Me.PictureBox1.Location = CType(resources.GetObject("PictureBox1.Location"), System.Drawing.Point)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.RightToLeft = CType(resources.GetObject("PictureBox1.RightToLeft"), System.Windows.Forms.RightToLeft)
        Me.PictureBox1.Size = CType(resources.GetObject("PictureBox1.Size"), System.Drawing.Size)
        Me.PictureBox1.SizeMode = CType(resources.GetObject("PictureBox1.SizeMode"), System.Windows.Forms.PictureBoxSizeMode)
        Me.PictureBox1.TabIndex = CType(resources.GetObject("PictureBox1.TabIndex"), Integer)
        Me.PictureBox1.TabStop = False
        Me.PictureBox1.Text = resources.GetString("PictureBox1.Text")
        Me.PictureBox1.Visible = CType(resources.GetObject("PictureBox1.Visible"), Boolean)
        '
        'lblProtected
        '
        Me.lblProtected.AccessibleDescription = resources.GetString("lblProtected.AccessibleDescription")
        Me.lblProtected.AccessibleName = resources.GetString("lblProtected.AccessibleName")
        Me.lblProtected.Anchor = CType(resources.GetObject("lblProtected.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.lblProtected.AutoSize = CType(resources.GetObject("lblProtected.AutoSize"), Boolean)
        Me.lblProtected.Dock = CType(resources.GetObject("lblProtected.Dock"), System.Windows.Forms.DockStyle)
        Me.lblProtected.Enabled = CType(resources.GetObject("lblProtected.Enabled"), Boolean)
        Me.lblProtected.Font = CType(resources.GetObject("lblProtected.Font"), System.Drawing.Font)
        Me.lblProtected.Image = CType(resources.GetObject("lblProtected.Image"), System.Drawing.Image)
        Me.lblProtected.ImageAlign = CType(resources.GetObject("lblProtected.ImageAlign"), System.Drawing.ContentAlignment)
        Me.lblProtected.ImageIndex = CType(resources.GetObject("lblProtected.ImageIndex"), Integer)
        Me.lblProtected.ImeMode = CType(resources.GetObject("lblProtected.ImeMode"), System.Windows.Forms.ImeMode)
        Me.lblProtected.Location = CType(resources.GetObject("lblProtected.Location"), System.Drawing.Point)
        Me.lblProtected.Name = "lblProtected"
        Me.lblProtected.RightToLeft = CType(resources.GetObject("lblProtected.RightToLeft"), System.Windows.Forms.RightToLeft)
        Me.lblProtected.Size = CType(resources.GetObject("lblProtected.Size"), System.Drawing.Size)
        Me.lblProtected.TabIndex = CType(resources.GetObject("lblProtected.TabIndex"), Integer)
        Me.lblProtected.Text = resources.GetString("lblProtected.Text")
        Me.lblProtected.TextAlign = CType(resources.GetObject("lblProtected.TextAlign"), System.Drawing.ContentAlignment)
        Me.lblProtected.Visible = CType(resources.GetObject("lblProtected.Visible"), Boolean)
        '
        'lblPrivate
        '
        Me.lblPrivate.AccessibleDescription = resources.GetString("lblPrivate.AccessibleDescription")
        Me.lblPrivate.AccessibleName = resources.GetString("lblPrivate.AccessibleName")
        Me.lblPrivate.Anchor = CType(resources.GetObject("lblPrivate.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.lblPrivate.AutoSize = CType(resources.GetObject("lblPrivate.AutoSize"), Boolean)
        Me.lblPrivate.Dock = CType(resources.GetObject("lblPrivate.Dock"), System.Windows.Forms.DockStyle)
        Me.lblPrivate.Enabled = CType(resources.GetObject("lblPrivate.Enabled"), Boolean)
        Me.lblPrivate.Font = CType(resources.GetObject("lblPrivate.Font"), System.Drawing.Font)
        Me.lblPrivate.Image = CType(resources.GetObject("lblPrivate.Image"), System.Drawing.Image)
        Me.lblPrivate.ImageAlign = CType(resources.GetObject("lblPrivate.ImageAlign"), System.Drawing.ContentAlignment)
        Me.lblPrivate.ImageIndex = CType(resources.GetObject("lblPrivate.ImageIndex"), Integer)
        Me.lblPrivate.ImeMode = CType(resources.GetObject("lblPrivate.ImeMode"), System.Windows.Forms.ImeMode)
        Me.lblPrivate.Location = CType(resources.GetObject("lblPrivate.Location"), System.Drawing.Point)
        Me.lblPrivate.Name = "lblPrivate"
        Me.lblPrivate.RightToLeft = CType(resources.GetObject("lblPrivate.RightToLeft"), System.Windows.Forms.RightToLeft)
        Me.lblPrivate.Size = CType(resources.GetObject("lblPrivate.Size"), System.Drawing.Size)
        Me.lblPrivate.TabIndex = CType(resources.GetObject("lblPrivate.TabIndex"), Integer)
        Me.lblPrivate.Text = resources.GetString("lblPrivate.Text")
        Me.lblPrivate.TextAlign = CType(resources.GetObject("lblPrivate.TextAlign"), System.Drawing.ContentAlignment)
        Me.lblPrivate.Visible = CType(resources.GetObject("lblPrivate.Visible"), Boolean)
        '
        'frmBase
        '
        Me.AccessibleDescription = CType(resources.GetObject("$this.AccessibleDescription"), String)
        Me.AccessibleName = CType(resources.GetObject("$this.AccessibleName"), String)
        Me.Anchor = CType(resources.GetObject("$this.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.AutoScaleBaseSize = CType(resources.GetObject("$this.AutoScaleBaseSize"), System.Drawing.Size)
        Me.AutoScroll = CType(resources.GetObject("$this.AutoScroll"), Boolean)
        Me.AutoScrollMargin = CType(resources.GetObject("$this.AutoScrollMargin"), System.Drawing.Size)
        Me.AutoScrollMinSize = CType(resources.GetObject("$this.AutoScrollMinSize"), System.Drawing.Size)
        Me.BackgroundImage = CType(resources.GetObject("$this.BackgroundImage"), System.Drawing.Image)
        Me.ClientSize = CType(resources.GetObject("$this.ClientSize"), System.Drawing.Size)
        Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.lblPrivate, Me.lblProtected, Me.PictureBox1, Me.btnClose, Me.lblTitle})
        Me.Dock = CType(resources.GetObject("$this.Dock"), System.Windows.Forms.DockStyle)
        Me.Enabled = CType(resources.GetObject("$this.Enabled"), Boolean)
        Me.Font = CType(resources.GetObject("$this.Font"), System.Drawing.Font)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.ImeMode = CType(resources.GetObject("$this.ImeMode"), System.Windows.Forms.ImeMode)
        Me.Location = CType(resources.GetObject("$this.Location"), System.Drawing.Point)
        Me.MaximizeBox = False
        Me.MaximumSize = CType(resources.GetObject("$this.MaximumSize"), System.Drawing.Size)
        Me.MinimumSize = CType(resources.GetObject("$this.MinimumSize"), System.Drawing.Size)
        Me.Name = "frmBase"
        Me.RightToLeft = CType(resources.GetObject("$this.RightToLeft"), System.Windows.Forms.RightToLeft)
        Me.StartPosition = CType(resources.GetObject("$this.StartPosition"), System.Windows.Forms.FormStartPosition)
        Me.Text = resources.GetString("$this.Text")
        Me.Visible = CType(resources.GetObject("$this.Visible"), Boolean)
        Me.ResumeLayout(False)

    End Sub

#End Region

    ' Creates a connection to the database and uses a SqlDataAdapter
    ' object to fill a DataSet.
    Protected Function GetDataSource() As DataSet

        Static ConnectionString As String = SQL_CONNECTION_STRING
        Static DidPreviouslyConnect As Boolean = False

        ' Display a status message saying that we're attempting to connect.
        ' This only needs to be done the very first time a connection is
        ' attempted.  After we've determined that MSDE or SQL Server is
        ' installed, this message no longer needs to be displayed.
        Dim frmStatusMessage As New frmStatus()
        If Not DidPreviouslyConnect Then
            frmStatusMessage.Show("Connecting to SQL Server")
        End If

        ' Attempt to connect to the local SQL server instance, and a local
        ' MSDE installation (with Northwind).  
        Dim IsConnecting As Boolean = True
        While IsConnecting

            Try
                ' The SqlConnection class allows you to communicate with SQL Server.
                ' The constructor accepts a connection string as an argument.  This
                ' connection string uses Integrated Security, which means that you 
                ' must have a login in SQL Server, or be part of the Administrators
                ' group for this to work.
                Dim cnNorthwind As New SqlConnection(ConnectionString)

                ' The SqlDataAdapter is used to move data between SQL Server, 
                ' and a DataSet.
                Dim da As New SqlDataAdapter( _
                    "SELECT ProductID, ProductName, UnitPrice, UnitsInStock " & _
                    "FROM products", cnNorthwind)

                Dim dsProducts As New DataSet()

                ' Populate the DataSet with the information from the products
                ' table.  Since a DataSet can hold multiple result sets, it's
                ' a good idea to "name" the result set when you populate the
                ' DataSet.  In this case, the result set is named "Products".
                da.Fill(dsProducts, "Products")

                ' Data has been successfully retrieved, so break out of the loop
                ' and close the status form.
                IsConnecting = False
                DidPreviouslyConnect = True
                frmStatusMessage.Close()

                Return dsProducts

            Catch exc As Exception
                If ConnectionString = SQL_CONNECTION_STRING Then
                    ' Couldn't connect to SQL Server.  Now try MSDE.
                    ConnectionString = MSDE_CONNECTION_STRING
                    frmStatusMessage.Show("Connecting to MSDE")
                Else
                    ' Unable to connect to SQL Server or MSDE
                    frmStatusMessage.Close()
                    MessageBox.Show("To run this sample, you must have SQL " & _
                        "or MSDE with the Northwind database installed.  For " & _
                        "instructions on installing MSDE, view the ReadMe file.", _
                        "Connection Problem", MessageBoxButtons.OK, _
                        MessageBoxIcon.Error)
                    End
                End If
            End Try
        End While

        frmStatusMessage.Close()

    End Function

    Private Sub frmBase_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub
End Class
