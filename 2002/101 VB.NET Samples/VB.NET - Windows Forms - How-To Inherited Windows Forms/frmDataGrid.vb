'Copyright (C) 2002 Microsoft Corporation
'All rights reserved.
'THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, EITHER 
'EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED WARRANTIES OF 
'MERCHANTIBILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.

'Requires the Trial or Release version of Visual Studio .NET Professional (or greater).

Option Strict On

Public Class frmDataGrid
    Inherits frmBase

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
    Friend WithEvents dgProducts As System.Windows.Forms.DataGrid
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmDataGrid))
        Me.dgProducts = New System.Windows.Forms.DataGrid()
        CType(Me.dgProducts, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lblProtected
        '
        Me.lblProtected.Visible = CType(resources.GetObject("lblProtected.Visible"), Boolean)
        '
        'dgProducts
        '
        Me.dgProducts.AccessibleDescription = resources.GetString("dgProducts.AccessibleDescription")
        Me.dgProducts.AccessibleName = resources.GetString("dgProducts.AccessibleName")
        Me.dgProducts.Anchor = CType(resources.GetObject("dgProducts.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.dgProducts.BackgroundColor = System.Drawing.SystemColors.ActiveBorder
        Me.dgProducts.BackgroundImage = CType(resources.GetObject("dgProducts.BackgroundImage"), System.Drawing.Image)
        Me.dgProducts.CaptionFont = CType(resources.GetObject("dgProducts.CaptionFont"), System.Drawing.Font)
        Me.dgProducts.CaptionText = resources.GetString("dgProducts.CaptionText")
        Me.dgProducts.DataMember = ""
        Me.dgProducts.Dock = CType(resources.GetObject("dgProducts.Dock"), System.Windows.Forms.DockStyle)
        Me.dgProducts.Enabled = CType(resources.GetObject("dgProducts.Enabled"), Boolean)
        Me.dgProducts.Font = CType(resources.GetObject("dgProducts.Font"), System.Drawing.Font)
        Me.dgProducts.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.dgProducts.ImeMode = CType(resources.GetObject("dgProducts.ImeMode"), System.Windows.Forms.ImeMode)
        Me.dgProducts.Location = CType(resources.GetObject("dgProducts.Location"), System.Drawing.Point)
        Me.dgProducts.Name = "dgProducts"
        Me.dgProducts.RightToLeft = CType(resources.GetObject("dgProducts.RightToLeft"), System.Windows.Forms.RightToLeft)
        Me.dgProducts.Size = CType(resources.GetObject("dgProducts.Size"), System.Drawing.Size)
        Me.dgProducts.TabIndex = CType(resources.GetObject("dgProducts.TabIndex"), Integer)
        Me.dgProducts.Visible = CType(resources.GetObject("dgProducts.Visible"), Boolean)
        '
        'frmDataGrid
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
        Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.lblProtected, Me.dgProducts})
        Me.Dock = CType(resources.GetObject("$this.Dock"), System.Windows.Forms.DockStyle)
        Me.Enabled = CType(resources.GetObject("$this.Enabled"), Boolean)
        Me.Font = CType(resources.GetObject("$this.Font"), System.Drawing.Font)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.ImeMode = CType(resources.GetObject("$this.ImeMode"), System.Windows.Forms.ImeMode)
        Me.Location = CType(resources.GetObject("$this.Location"), System.Drawing.Point)
        Me.MaximumSize = CType(resources.GetObject("$this.MaximumSize"), System.Drawing.Size)
        Me.MinimumSize = CType(resources.GetObject("$this.MinimumSize"), System.Drawing.Size)
        Me.Name = "frmDataGrid"
        Me.RightToLeft = CType(resources.GetObject("$this.RightToLeft"), System.Windows.Forms.RightToLeft)
        Me.StartPosition = CType(resources.GetObject("$this.StartPosition"), System.Windows.Forms.FormStartPosition)
        Me.Text = resources.GetString("$this.Text")
        Me.Visible = CType(resources.GetObject("$this.Visible"), Boolean)
        CType(Me.dgProducts, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

    ' Handles the Close button click event.
    Private Sub btnClose_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    ' Handles the Form load event, which displays the data in the DataGrid.
    Private Sub frmDataGrid_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load

        With dgProducts
            .CaptionText = "Northwind Products"
            .DataSource = GetDataSource().Tables(0)
        End With

        ' Use a table style object to apply custom formatting to the DataGrid.
        Dim dgTableStyle1 As New DataGridTableStyle()
        With dgTableStyle1
            .AlternatingBackColor = Color.Lavender
            .BackColor = Color.WhiteSmoke
            .ForeColor = Color.MidnightBlue
            .GridLineColor = Color.Gainsboro
            .GridLineStyle = System.Windows.Forms.DataGridLineStyle.None
            .HeaderBackColor = Color.MidnightBlue
            .HeaderFont = New Font("Tahoma", 8.0!, FontStyle.Bold)
            .HeaderForeColor = Color.WhiteSmoke
            .LinkColor = Color.Teal
            ' Do not forget to set the MappingName property. 
            ' Without this, the DataGridTableStyle properties
            ' and any associated DataGridColumnStyle objects
            ' will have no effect.
            .MappingName = "Products"
            .SelectionBackColor = Color.CadetBlue
            .SelectionForeColor = Color.WhiteSmoke
        End With

        ' Use column style objects to apply formatting specific to each column.
        Dim grdColStyle1 As New DataGridTextBoxColumn()
        With grdColStyle1
            .HeaderText = "ID#"
            .MappingName = "ProductID"
            .Width = 50
        End With

        Dim grdColStyle2 As New DataGridTextBoxColumn()
        With grdColStyle2
            .HeaderText = "Name"
            .MappingName = "ProductName"
            .Width = 225
        End With

        Dim grdColStyle3 As New DataGridTextBoxColumn()
        With grdColStyle3
            .HeaderText = "Price"
            .MappingName = "UnitPrice"
            .Width = 70
        End With

        Dim grdColStyle4 As New DataGridTextBoxColumn()
        With grdColStyle4
            .HeaderText = "# in Stock"
            .MappingName = "UnitsInStock"
            .Width = 70
        End With

        ' Add the column style objects to the tables style's column styles 
        ' collection. If you fail to do this the column styles will not apply.
        dgTableStyle1.GridColumnStyles.AddRange _
            (New DataGridColumnStyle() _
            {grdColStyle1, grdColStyle2, grdColStyle3, grdColStyle4})
        ' Add the table style object to the DataGrid's table styles collection.
        ' Again, failure to add the style to the collection will cause the style
        ' to not take effect.
        dgProducts.TableStyles.Add(dgTableStyle1)

        ' Set the Form's title in the inherited Label control.
        lblTitle.Text = "Inherited Form with DataGrid"
    End Sub

End Class
