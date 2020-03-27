'Copyright (C) 2002 Microsoft Corporation
'All rights reserved.
'THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, EITHER 
'EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED WARRANTIES OF 
'MERCHANTIBILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.

'Requires the Trial or Release version of Visual Studio .NET Professional (or greater).

Option Strict On
Imports System.Text

Public Class frmRichTextBox
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
    Friend WithEvents rtbProducts As System.Windows.Forms.RichTextBox
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmRichTextBox))
        Me.rtbProducts = New System.Windows.Forms.RichTextBox()
        Me.SuspendLayout()
        '
        'lblProtected
        '
        Me.lblProtected.Visible = CType(resources.GetObject("lblProtected.Visible"), Boolean)
        '
        'rtbProducts
        '
        Me.rtbProducts.AccessibleDescription = resources.GetString("rtbProducts.AccessibleDescription")
        Me.rtbProducts.AccessibleName = resources.GetString("rtbProducts.AccessibleName")
        Me.rtbProducts.Anchor = CType(resources.GetObject("rtbProducts.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.rtbProducts.AutoSize = CType(resources.GetObject("rtbProducts.AutoSize"), Boolean)
        Me.rtbProducts.BackgroundImage = CType(resources.GetObject("rtbProducts.BackgroundImage"), System.Drawing.Image)
        Me.rtbProducts.BulletIndent = CType(resources.GetObject("rtbProducts.BulletIndent"), Integer)
        Me.rtbProducts.Dock = CType(resources.GetObject("rtbProducts.Dock"), System.Windows.Forms.DockStyle)
        Me.rtbProducts.Enabled = CType(resources.GetObject("rtbProducts.Enabled"), Boolean)
        Me.rtbProducts.Font = CType(resources.GetObject("rtbProducts.Font"), System.Drawing.Font)
        Me.rtbProducts.ImeMode = CType(resources.GetObject("rtbProducts.ImeMode"), System.Windows.Forms.ImeMode)
        Me.rtbProducts.Location = CType(resources.GetObject("rtbProducts.Location"), System.Drawing.Point)
        Me.rtbProducts.MaxLength = CType(resources.GetObject("rtbProducts.MaxLength"), Integer)
        Me.rtbProducts.Multiline = CType(resources.GetObject("rtbProducts.Multiline"), Boolean)
        Me.rtbProducts.Name = "rtbProducts"
        Me.rtbProducts.RightMargin = CType(resources.GetObject("rtbProducts.RightMargin"), Integer)
        Me.rtbProducts.RightToLeft = CType(resources.GetObject("rtbProducts.RightToLeft"), System.Windows.Forms.RightToLeft)
        Me.rtbProducts.ScrollBars = CType(resources.GetObject("rtbProducts.ScrollBars"), System.Windows.Forms.RichTextBoxScrollBars)
        Me.rtbProducts.Size = CType(resources.GetObject("rtbProducts.Size"), System.Drawing.Size)
        Me.rtbProducts.TabIndex = CType(resources.GetObject("rtbProducts.TabIndex"), Integer)
        Me.rtbProducts.Text = resources.GetString("rtbProducts.Text")
        Me.rtbProducts.Visible = CType(resources.GetObject("rtbProducts.Visible"), Boolean)
        Me.rtbProducts.WordWrap = CType(resources.GetObject("rtbProducts.WordWrap"), Boolean)
        Me.rtbProducts.ZoomFactor = CType(resources.GetObject("rtbProducts.ZoomFactor"), Single)
        '
        'frmRichTextBox
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
        Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.lblProtected, Me.rtbProducts})
        Me.Dock = CType(resources.GetObject("$this.Dock"), System.Windows.Forms.DockStyle)
        Me.Enabled = CType(resources.GetObject("$this.Enabled"), Boolean)
        Me.Font = CType(resources.GetObject("$this.Font"), System.Drawing.Font)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.ImeMode = CType(resources.GetObject("$this.ImeMode"), System.Windows.Forms.ImeMode)
        Me.Location = CType(resources.GetObject("$this.Location"), System.Drawing.Point)
        Me.MaximumSize = CType(resources.GetObject("$this.MaximumSize"), System.Drawing.Size)
        Me.MinimumSize = CType(resources.GetObject("$this.MinimumSize"), System.Drawing.Size)
        Me.Name = "frmRichTextBox"
        Me.RightToLeft = CType(resources.GetObject("$this.RightToLeft"), System.Windows.Forms.RightToLeft)
        Me.StartPosition = CType(resources.GetObject("$this.StartPosition"), System.Windows.Forms.FormStartPosition)
        Me.Text = resources.GetString("$this.Text")
        Me.Visible = CType(resources.GetObject("$this.Visible"), Boolean)
        Me.ResumeLayout(False)

    End Sub

#End Region

    ' Handles the Close button click event.
    Private Sub btnClose_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    ' Handles the Form load event.
    Private Sub frmRichTextBox_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load

        ' Get a DataSet
        Dim ds As DataSet = GetDataSource()

        ' Instead of traditional string concatenation, use the new StringBuilder
        ' class which is optimized for concatenation as it can modify the buffer
        ' instead of having to make a copy of the string for each concatenation.
        Dim sb As New StringBuilder()

        ' Set the first row of column headers.
        sb.Append("=======================================================")
        sb.Append(vbCrLf)
        sb.Append("ID")
        sb.Append(vbTab)
        sb.Append("Name")
        sb.Append(vbCrLf)
        sb.Append("=======================================================")
        sb.Append(vbCrLf)

        ' Loop through the rows in the DataSet and append them using the 
        ' StringBuilder.
        Dim dr As DataRow
        For Each dr In ds.Tables(0).Rows
            sb.Append(dr("ProductID"))
            sb.Append(vbTab)
            sb.Append(dr("ProductName"))
            sb.Append(vbCrLf)
        Next

        ' Convert the contents of the StringBuilder object to Text for display
        ' in the RichTextBox.
        rtbProducts.Text = sb.ToString

        ' Set the Form's title in the inherited Label control.
        lblTitle.Text = "Inherited Form with RichTextBox"
    End Sub

End Class
