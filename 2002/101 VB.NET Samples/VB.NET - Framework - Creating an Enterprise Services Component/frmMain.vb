'Copyright (C) 2002 Microsoft Corporation
'All rights reserved.
'THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, EITHER
'EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED WARRANTIES OF
'MERCHANTIBILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.

'Requires the Trial or Release version of Visual Studio .NET Professional (or greater).

Option Strict On
Imports VBNET.HowTo.CreateEnterpriseServicesComponents

Public Class frmMain
	Inherits System.Windows.Forms.Form

#Region " Windows Form Designer generated code "

	Public Sub New()
		MyBase.New()

		'This call is required by the Windows Form Designer.
		InitializeComponent()

		'Add any initialization after the InitializeComponent() call

		' So that we only need to set the title of the application once,
		' we use the AssemblyInfo class (defined in the AssemblyInfo.vb file)
		' to read the AssemblyTitle attribute.
		Dim ainfo As New AssemblyInfo()

		Me.Text = ainfo.Title
        Me.mnuAbout.Text = String.Format("&About {0} ...", ainfo.Title)

        SetupTips()
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
    Friend WithEvents mnuMain As System.Windows.Forms.MainMenu
    Friend WithEvents mnuFile As System.Windows.Forms.MenuItem
    Friend WithEvents mnuExit As System.Windows.Forms.MenuItem
    Friend WithEvents mnuHelp As System.Windows.Forms.MenuItem
    Friend WithEvents mnuAbout As System.Windows.Forms.MenuItem
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents pgeModifyData As System.Windows.Forms.TabPage
    Friend WithEvents pgeTips As System.Windows.Forms.TabPage
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents btnAddSupplier As System.Windows.Forms.Button
    Friend WithEvents txtPhone As System.Windows.Forms.TextBox
    Friend WithEvents txtCompanyName As System.Windows.Forms.TextBox
    Friend WithEvents txtTips As System.Windows.Forms.TextBox
    Friend WithEvents btnDeleteSupplier As System.Windows.Forms.Button
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents btnUpdateSupplier As System.Windows.Forms.Button
    Friend WithEvents btnGetSuppliers As System.Windows.Forms.Button
    Friend WithEvents txtSupplierID1 As System.Windows.Forms.TextBox
    Friend WithEvents sbrStatus As System.Windows.Forms.StatusBar
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents btnAddProduct As System.Windows.Forms.Button
    Friend WithEvents txtUnitPrice As System.Windows.Forms.TextBox
    Friend WithEvents txtProductName As System.Windows.Forms.TextBox
    Friend WithEvents btnDeleteProduct As System.Windows.Forms.Button
    Friend WithEvents btnGetProducts As System.Windows.Forms.Button
    Friend WithEvents btnUpdateProduct As System.Windows.Forms.Button
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txtProductID As System.Windows.Forms.TextBox
    Friend WithEvents txtSupplierID2 As System.Windows.Forms.TextBox
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmMain))
        Me.mnuMain = New System.Windows.Forms.MainMenu()
        Me.mnuFile = New System.Windows.Forms.MenuItem()
        Me.mnuExit = New System.Windows.Forms.MenuItem()
        Me.mnuHelp = New System.Windows.Forms.MenuItem()
        Me.mnuAbout = New System.Windows.Forms.MenuItem()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.pgeModifyData = New System.Windows.Forms.TabPage()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtProductID = New System.Windows.Forms.TextBox()
        Me.btnUpdateProduct = New System.Windows.Forms.Button()
        Me.btnGetProducts = New System.Windows.Forms.Button()
        Me.btnDeleteProduct = New System.Windows.Forms.Button()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.btnAddProduct = New System.Windows.Forms.Button()
        Me.txtUnitPrice = New System.Windows.Forms.TextBox()
        Me.txtSupplierID2 = New System.Windows.Forms.TextBox()
        Me.txtProductName = New System.Windows.Forms.TextBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.btnGetSuppliers = New System.Windows.Forms.Button()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtSupplierID1 = New System.Windows.Forms.TextBox()
        Me.btnUpdateSupplier = New System.Windows.Forms.Button()
        Me.btnDeleteSupplier = New System.Windows.Forms.Button()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.btnAddSupplier = New System.Windows.Forms.Button()
        Me.txtPhone = New System.Windows.Forms.TextBox()
        Me.txtCompanyName = New System.Windows.Forms.TextBox()
        Me.pgeTips = New System.Windows.Forms.TabPage()
        Me.txtTips = New System.Windows.Forms.TextBox()
        Me.sbrStatus = New System.Windows.Forms.StatusBar()
        Me.TabControl1.SuspendLayout()
        Me.pgeModifyData.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.pgeTips.SuspendLayout()
        Me.SuspendLayout()
        '
        'mnuMain
        '
        Me.mnuMain.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.mnuFile, Me.mnuHelp})
        '
        'mnuFile
        '
        Me.mnuFile.Index = 0
        Me.mnuFile.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.mnuExit})
        Me.mnuFile.Text = "&File"
        '
        'mnuExit
        '
        Me.mnuExit.Index = 0
        Me.mnuExit.Text = "E&xit"
        '
        'mnuHelp
        '
        Me.mnuHelp.Index = 1
        Me.mnuHelp.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.mnuAbout})
        Me.mnuHelp.Text = "&Help"
        '
        'mnuAbout
        '
        Me.mnuAbout.Index = 0
        Me.mnuAbout.Text = "Text Comes from AssemblyInfo"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(16, 16)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(312, 19)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Create Enterprise Services Components"
        '
        'TabControl1
        '
        Me.TabControl1.Controls.AddRange(New System.Windows.Forms.Control() {Me.pgeModifyData, Me.pgeTips})
        Me.TabControl1.Location = New System.Drawing.Point(16, 48)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(576, 328)
        Me.TabControl1.TabIndex = 1
        Me.TabControl1.TabStop = False
        '
        'pgeModifyData
        '
        Me.pgeModifyData.Controls.AddRange(New System.Windows.Forms.Control() {Me.GroupBox3, Me.GroupBox1})
        Me.pgeModifyData.Location = New System.Drawing.Point(4, 22)
        Me.pgeModifyData.Name = "pgeModifyData"
        Me.pgeModifyData.Size = New System.Drawing.Size(568, 302)
        Me.pgeModifyData.TabIndex = 0
        Me.pgeModifyData.Text = "Modify Data"
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.AddRange(New System.Windows.Forms.Control() {Me.Label6, Me.txtProductID, Me.btnUpdateProduct, Me.btnGetProducts, Me.btnDeleteProduct, Me.Label5, Me.Label4, Me.Label3, Me.btnAddProduct, Me.txtUnitPrice, Me.txtSupplierID2, Me.txtProductName})
        Me.GroupBox3.Location = New System.Drawing.Point(28, 144)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(516, 136)
        Me.GroupBox3.TabIndex = 2
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Products"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(16, 96)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(58, 13)
        Me.Label6.TabIndex = 6
        Me.Label6.Text = "Product ID"
        '
        'txtProductID
        '
        Me.txtProductID.Location = New System.Drawing.Point(104, 96)
        Me.txtProductID.Name = "txtProductID"
        Me.txtProductID.Size = New System.Drawing.Size(152, 20)
        Me.txtProductID.TabIndex = 7
        Me.txtProductID.Text = ""
        '
        'btnUpdateProduct
        '
        Me.btnUpdateProduct.Enabled = False
        Me.btnUpdateProduct.Location = New System.Drawing.Point(392, 24)
        Me.btnUpdateProduct.Name = "btnUpdateProduct"
        Me.btnUpdateProduct.Size = New System.Drawing.Size(104, 23)
        Me.btnUpdateProduct.TabIndex = 9
        Me.btnUpdateProduct.Text = "Update P&roduct"
        '
        'btnGetProducts
        '
        Me.btnGetProducts.Location = New System.Drawing.Point(280, 24)
        Me.btnGetProducts.Name = "btnGetProducts"
        Me.btnGetProducts.Size = New System.Drawing.Size(104, 23)
        Me.btnGetProducts.TabIndex = 8
        Me.btnGetProducts.Text = "G&et Products"
        '
        'btnDeleteProduct
        '
        Me.btnDeleteProduct.Enabled = False
        Me.btnDeleteProduct.Location = New System.Drawing.Point(392, 64)
        Me.btnDeleteProduct.Name = "btnDeleteProduct"
        Me.btnDeleteProduct.Size = New System.Drawing.Size(104, 23)
        Me.btnDeleteProduct.TabIndex = 11
        Me.btnDeleteProduct.Text = "De&lete Product"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(16, 72)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(53, 13)
        Me.Label5.TabIndex = 4
        Me.Label5.Text = "Unit Price"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(16, 48)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(60, 13)
        Me.Label4.TabIndex = 2
        Me.Label4.Text = "Supplier ID"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(16, 24)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(76, 13)
        Me.Label3.TabIndex = 0
        Me.Label3.Text = "Product Name"
        '
        'btnAddProduct
        '
        Me.btnAddProduct.Enabled = False
        Me.btnAddProduct.Location = New System.Drawing.Point(280, 64)
        Me.btnAddProduct.Name = "btnAddProduct"
        Me.btnAddProduct.Size = New System.Drawing.Size(104, 23)
        Me.btnAddProduct.TabIndex = 10
        Me.btnAddProduct.Text = "Add &Product"
        '
        'txtUnitPrice
        '
        Me.txtUnitPrice.Location = New System.Drawing.Point(104, 72)
        Me.txtUnitPrice.Name = "txtUnitPrice"
        Me.txtUnitPrice.Size = New System.Drawing.Size(152, 20)
        Me.txtUnitPrice.TabIndex = 5
        Me.txtUnitPrice.Text = ""
        '
        'txtSupplierID2
        '
        Me.txtSupplierID2.Location = New System.Drawing.Point(104, 48)
        Me.txtSupplierID2.Name = "txtSupplierID2"
        Me.txtSupplierID2.Size = New System.Drawing.Size(152, 20)
        Me.txtSupplierID2.TabIndex = 3
        Me.txtSupplierID2.Text = ""
        '
        'txtProductName
        '
        Me.txtProductName.Location = New System.Drawing.Point(104, 24)
        Me.txtProductName.Name = "txtProductName"
        Me.txtProductName.Size = New System.Drawing.Size(152, 20)
        Me.txtProductName.TabIndex = 1
        Me.txtProductName.Text = ""
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.AddRange(New System.Windows.Forms.Control() {Me.btnGetSuppliers, Me.Label2, Me.txtSupplierID1, Me.btnUpdateSupplier, Me.btnDeleteSupplier, Me.Label7, Me.Label8, Me.btnAddSupplier, Me.txtPhone, Me.txtCompanyName})
        Me.GroupBox1.Location = New System.Drawing.Point(28, 27)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(516, 109)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Suppliers"
        '
        'btnGetSuppliers
        '
        Me.btnGetSuppliers.Location = New System.Drawing.Point(280, 24)
        Me.btnGetSuppliers.Name = "btnGetSuppliers"
        Me.btnGetSuppliers.Size = New System.Drawing.Size(104, 23)
        Me.btnGetSuppliers.TabIndex = 6
        Me.btnGetSuppliers.Text = "&Get Suppliers"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(16, 72)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(60, 13)
        Me.Label2.TabIndex = 4
        Me.Label2.Text = "Supplier ID"
        '
        'txtSupplierID1
        '
        Me.txtSupplierID1.Location = New System.Drawing.Point(104, 72)
        Me.txtSupplierID1.Name = "txtSupplierID1"
        Me.txtSupplierID1.Size = New System.Drawing.Size(152, 20)
        Me.txtSupplierID1.TabIndex = 5
        Me.txtSupplierID1.Text = ""
        '
        'btnUpdateSupplier
        '
        Me.btnUpdateSupplier.Enabled = False
        Me.btnUpdateSupplier.Location = New System.Drawing.Point(392, 24)
        Me.btnUpdateSupplier.Name = "btnUpdateSupplier"
        Me.btnUpdateSupplier.Size = New System.Drawing.Size(104, 23)
        Me.btnUpdateSupplier.TabIndex = 7
        Me.btnUpdateSupplier.Text = "&Update Supplier"
        '
        'btnDeleteSupplier
        '
        Me.btnDeleteSupplier.Enabled = False
        Me.btnDeleteSupplier.Location = New System.Drawing.Point(392, 64)
        Me.btnDeleteSupplier.Name = "btnDeleteSupplier"
        Me.btnDeleteSupplier.Size = New System.Drawing.Size(104, 23)
        Me.btnDeleteSupplier.TabIndex = 9
        Me.btnDeleteSupplier.Text = "&Delete Supplier"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(16, 48)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(37, 13)
        Me.Label7.TabIndex = 2
        Me.Label7.Text = "Phone"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(16, 24)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(86, 13)
        Me.Label8.TabIndex = 0
        Me.Label8.Text = "Company Name"
        '
        'btnAddSupplier
        '
        Me.btnAddSupplier.Enabled = False
        Me.btnAddSupplier.Location = New System.Drawing.Point(280, 64)
        Me.btnAddSupplier.Name = "btnAddSupplier"
        Me.btnAddSupplier.Size = New System.Drawing.Size(104, 23)
        Me.btnAddSupplier.TabIndex = 8
        Me.btnAddSupplier.Text = "&Add Supplier"
        '
        'txtPhone
        '
        Me.txtPhone.Location = New System.Drawing.Point(104, 48)
        Me.txtPhone.Name = "txtPhone"
        Me.txtPhone.Size = New System.Drawing.Size(152, 20)
        Me.txtPhone.TabIndex = 3
        Me.txtPhone.Text = ""
        '
        'txtCompanyName
        '
        Me.txtCompanyName.Location = New System.Drawing.Point(104, 24)
        Me.txtCompanyName.Name = "txtCompanyName"
        Me.txtCompanyName.Size = New System.Drawing.Size(152, 20)
        Me.txtCompanyName.TabIndex = 1
        Me.txtCompanyName.Text = ""
        '
        'pgeTips
        '
        Me.pgeTips.Controls.AddRange(New System.Windows.Forms.Control() {Me.txtTips})
        Me.pgeTips.Location = New System.Drawing.Point(4, 22)
        Me.pgeTips.Name = "pgeTips"
        Me.pgeTips.Size = New System.Drawing.Size(568, 302)
        Me.pgeTips.TabIndex = 1
        Me.pgeTips.Text = "Tips"
        '
        'txtTips
        '
        Me.txtTips.Anchor = (((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right)
        Me.txtTips.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtTips.Location = New System.Drawing.Point(8, 8)
        Me.txtTips.Multiline = True
        Me.txtTips.Name = "txtTips"
        Me.txtTips.ReadOnly = True
        Me.txtTips.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtTips.Size = New System.Drawing.Size(552, 288)
        Me.txtTips.TabIndex = 0
        Me.txtTips.Text = ""
        '
        'sbrStatus
        '
        Me.sbrStatus.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.sbrStatus.Location = New System.Drawing.Point(0, 381)
        Me.sbrStatus.Name = "sbrStatus"
        Me.sbrStatus.Size = New System.Drawing.Size(610, 22)
        Me.sbrStatus.SizingGrip = False
        Me.sbrStatus.TabIndex = 2
        '
        'frmMain
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(610, 403)
        Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.sbrStatus, Me.TabControl1, Me.Label1})
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Menu = Me.mnuMain
        Me.Name = "frmMain"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Title Comes from Assembly Info"
        Me.TabControl1.ResumeLayout(False)
        Me.pgeModifyData.ResumeLayout(False)
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.pgeTips.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region

#Region " Standard Menu Code "
	' <System.Diagnostics.DebuggerStepThrough()> has been added to some procedures since they are
	' not the focus of the demo. Remove them if you wish to debug the procedures.
	' This code simply shows the About form.
	<System.Diagnostics.DebuggerStepThrough()> Private Sub mnuAbout_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuAbout.Click
		' Open the About form in Dialog Mode
		Dim frm As New frmAbout()
		frm.ShowDialog(Me)
		frm.Dispose()
	End Sub

	' This code will close the form.
	<System.Diagnostics.DebuggerStepThrough()> Private Sub mnuExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuExit.Click
		' Close the current form
		Me.Close()
	End Sub
#End Region

#Region " Utility functions "

    Private Sub AddTip(ByVal strTip As String)
        txtTips.Text &= strTip & vbCrLf
    End Sub

    Private Sub AddTip2(ByVal strTip As String)
        txtTips.Text &= strTip & vbCrLf & vbCrLf
    End Sub

    Private Sub SetupTips()
        txtTips.Clear()
        AddTip2("To add a Supplier, enter a Company Name and Phone. To update, enter a Company Name, Phone and ID. To delete, only an ID is needed. Working with Products is similar.")
    End Sub

#End Region

    Private Sub btnAddProduct_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAddProduct.Click
        Try
            Cursor.Current = System.Windows.Forms.Cursors.WaitCursor
            Dim oProduct As New Product()
            Dim strProductName As String
            Dim intSupplierID As Integer
            Dim decUnitPrice As Decimal

            strProductName = txtProductName.Text.Trim
            intSupplierID = CInt(txtSupplierID2.Text.Trim)
            decUnitPrice = CDec(txtUnitPrice.Text.Trim)

            oProduct.AddProduct(strProductName, _
                intSupplierID, decUnitPrice)
            sbrStatus.Text = "Added product: " & strProductName
        Catch exp As Exception
            MsgBox(exp.ToString(), MsgBoxStyle.OKOnly, Me.Text)
        Finally
            Cursor.Current = System.Windows.Forms.Cursors.Default
        End Try
    End Sub

    Private Sub btnAddSupplier_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAddSupplier.Click
        Try
            Cursor.Current = System.Windows.Forms.Cursors.WaitCursor
            Dim oSupplier As New Supplier()
            Dim strCompanyName As String
            Dim strPhone As String

            strCompanyName = txtCompanyName.Text.Trim
            strPhone = txtPhone.Text.Trim

            oSupplier.AddSupplier(strCompanyName, strPhone)
            sbrStatus.Text = "Added supplier: " & strCompanyName
        Catch exp As Exception
            MsgBox(exp.ToString(), MsgBoxStyle.OKOnly, Me.Text)
        Finally
            Cursor.Current = System.Windows.Forms.Cursors.Default
        End Try
    End Sub

    Private Sub btnDeleteProduct_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDeleteProduct.Click
        Try
            Cursor.Current = System.Windows.Forms.Cursors.WaitCursor
            Dim oProduct As New Product()
            Dim intID As Integer

            intID = CInt(txtProductID.Text.Trim)

            oProduct.DeleteProduct(intID)
            sbrStatus.Text = "Deleted product: " & intID
        Catch exp As Exception
            MsgBox(exp.ToString(), MsgBoxStyle.OKOnly, Me.Text)
        Finally
            Cursor.Current = System.Windows.Forms.Cursors.Default
        End Try
    End Sub

    Private Sub btnDeleteSupplier_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnDeleteSupplier.Click
        Try
            Cursor.Current = System.Windows.Forms.Cursors.WaitCursor
            Dim oSupplier As New Supplier()
            Dim intID As Integer

            intID = CInt(txtSupplierID1.Text.Trim)
            oSupplier.DeleteSupplier(intID)
            sbrStatus.Text = "Deleted supplier: " & intID
        Catch exp As Exception
            MsgBox(exp.ToString(), MsgBoxStyle.OKOnly, Me.Text)
        Finally
            Cursor.Current = System.Windows.Forms.Cursors.Default
        End Try
    End Sub

    Private Sub btnGetProducts_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGetProducts.Click
        Try
            Cursor.Current = System.Windows.Forms.Cursors.WaitCursor
            Dim oProduct As New Product()

            oProduct.GetProducts()
            sbrStatus.Text = "Got list of products"
        Catch exp As Exception
            MsgBox(exp.ToString(), MsgBoxStyle.OKOnly, Me.Text)
        Finally
            Cursor.Current = System.Windows.Forms.Cursors.Default
        End Try
    End Sub

    Private Sub btnGetSuppliers_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGetSuppliers.Click
        Try
            Cursor.Current = System.Windows.Forms.Cursors.WaitCursor
            Dim oSupplier As New Supplier()
            oSupplier.GetSuppliers()
            sbrStatus.Text = "Got list of suppliers"
        Catch exp As Exception
            MsgBox(exp.ToString(), MsgBoxStyle.OKOnly, Me.Text)
        Finally
            Cursor.Current = System.Windows.Forms.Cursors.Default
        End Try
    End Sub

    Private Sub btnUpdateProduct_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnUpdateProduct.Click
        Try
            Cursor.Current = System.Windows.Forms.Cursors.WaitCursor
            Dim oProduct As New Product()
            Dim strProductName As String
            Dim intSupplierID As Integer
            Dim decUnitPrice As Decimal
            Dim intProductID As Integer

            strProductName = txtProductName.Text.Trim
            intSupplierID = CInt(txtSupplierID2.Text.Trim)
            decUnitPrice = CDec(txtUnitPrice.Text.Trim)
            intProductID = CInt(txtProductID.Text.Trim)

            oProduct.UpdateProduct(intProductID, strProductName, _
                intSupplierID, decUnitPrice)
            sbrStatus.Text = "Updated product: " & intProductID
        Catch exp As Exception
            MsgBox(exp.ToString(), MsgBoxStyle.OKOnly, Me.Text)
        Finally
            Cursor.Current = System.Windows.Forms.Cursors.Default
        End Try
    End Sub

    Private Sub btnUpdateSupplier_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnUpdateSupplier.Click
        Try
            Cursor.Current = System.Windows.Forms.Cursors.WaitCursor
            Dim oSupplier As New Supplier()
            Dim strCompanyName As String
            Dim strPhone As String
            Dim intID As Integer

            strCompanyName = txtCompanyName.Text.Trim
            strPhone = txtPhone.Text.Trim
            intID = CInt(txtSupplierID1.Text.Trim)

            oSupplier.UpdateSupplier(intID, strCompanyName, strPhone)
            sbrStatus.Text = "Updated supplier: " & strCompanyName
        Catch exp As Exception
            MsgBox(exp.ToString(), MsgBoxStyle.OKOnly, Me.Text)
        Finally
            Cursor.Current = System.Windows.Forms.Cursors.Default
        End Try
    End Sub

    Private Sub textBoxes_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtCompanyName.TextChanged, txtPhone.TextChanged, txtSupplierID1.TextChanged, txtProductName.TextChanged, txtSupplierID2.TextChanged, txtUnitPrice.TextChanged, txtProductID.TextChanged
        btnAddSupplier.Enabled = _
            txtCompanyName.Text.Trim.Length <> 0 AndAlso _
            txtPhone.Text.Trim.Length <> 0
        btnUpdateSupplier.Enabled = btnAddSupplier.Enabled AndAlso _
            txtSupplierID1.Text.Trim.Length <> 0
        btnDeleteSupplier.Enabled = txtSupplierID1.Text.Trim.Length <> 0

        btnAddProduct.Enabled = _
            txtProductName.Text.Trim.Length <> 0 AndAlso _
            txtSupplierID2.Text.Trim.Length <> 0 AndAlso _
            txtUnitPrice.Text.Trim.Length <> 0
        btnUpdateProduct.Enabled = btnAddProduct.Enabled AndAlso _
            txtProductID.Text.Trim.Length <> 0
        btnDeleteProduct.Enabled = txtProductID.Text.Trim.Length <> 0
    End Sub

End Class
