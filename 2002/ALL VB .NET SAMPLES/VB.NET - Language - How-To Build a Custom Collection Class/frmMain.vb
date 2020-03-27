Public Class frmMain
    Inherits System.Windows.Forms.Form

    Private myCustomers As New Customers()

#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call


        ' This code sets up the Help|About menuitem.
        Dim ainfo As New AssemblyInfo()

        Me.Text = ainfo.Title
        Me.mnuAbout.Text = String.Format("&About {0} ...", ainfo.Title)

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
	Friend WithEvents cmdRemove As System.Windows.Forms.Button
	Friend WithEvents cmdItem As System.Windows.Forms.Button
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents cmdAdd As System.Windows.Forms.Button
    Friend WithEvents txtAccount As System.Windows.Forms.TextBox
    Friend WithEvents txtLastName As System.Windows.Forms.TextBox
    Friend WithEvents txtFirstName As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents lstItems As System.Windows.Forms.ListBox
    Friend WithEvents cmdReload As System.Windows.Forms.Button
	Friend WithEvents mnuMain As System.Windows.Forms.MainMenu
	Friend WithEvents mnuFile As System.Windows.Forms.MenuItem
	Friend WithEvents mnuExit As System.Windows.Forms.MenuItem
	Friend WithEvents mnuHelp As System.Windows.Forms.MenuItem
	Friend WithEvents mnuAbout As System.Windows.Forms.MenuItem
	<System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
		Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmMain))
		Me.cmdRemove = New System.Windows.Forms.Button()
		Me.cmdItem = New System.Windows.Forms.Button()
		Me.GroupBox1 = New System.Windows.Forms.GroupBox()
		Me.cmdAdd = New System.Windows.Forms.Button()
		Me.txtAccount = New System.Windows.Forms.TextBox()
		Me.txtLastName = New System.Windows.Forms.TextBox()
		Me.txtFirstName = New System.Windows.Forms.TextBox()
		Me.Label3 = New System.Windows.Forms.Label()
		Me.Label2 = New System.Windows.Forms.Label()
		Me.Label1 = New System.Windows.Forms.Label()
		Me.lstItems = New System.Windows.Forms.ListBox()
		Me.cmdReload = New System.Windows.Forms.Button()
		Me.mnuMain = New System.Windows.Forms.MainMenu()
		Me.mnuFile = New System.Windows.Forms.MenuItem()
		Me.mnuExit = New System.Windows.Forms.MenuItem()
		Me.mnuHelp = New System.Windows.Forms.MenuItem()
		Me.mnuAbout = New System.Windows.Forms.MenuItem()
		Me.GroupBox1.SuspendLayout()
		Me.SuspendLayout()
		'
		'cmdRemove
		'
		Me.cmdRemove.Location = New System.Drawing.Point(272, 200)
		Me.cmdRemove.Name = "cmdRemove"
		Me.cmdRemove.Size = New System.Drawing.Size(160, 32)
		Me.cmdRemove.TabIndex = 3
		Me.cmdRemove.Text = "&Remove"
		'
		'cmdItem
		'
		Me.cmdItem.Location = New System.Drawing.Point(272, 160)
		Me.cmdItem.Name = "cmdItem"
		Me.cmdItem.Size = New System.Drawing.Size(160, 32)
		Me.cmdItem.TabIndex = 2
		Me.cmdItem.Text = "Show &Item Details"
		'
		'GroupBox1
		'
		Me.GroupBox1.Controls.AddRange(New System.Windows.Forms.Control() {Me.cmdAdd, Me.txtAccount, Me.txtLastName, Me.txtFirstName, Me.Label3, Me.Label2, Me.Label1})
		Me.GroupBox1.Location = New System.Drawing.Point(8, 8)
		Me.GroupBox1.Name = "GroupBox1"
		Me.GroupBox1.Size = New System.Drawing.Size(424, 144)
		Me.GroupBox1.TabIndex = 0
		Me.GroupBox1.TabStop = False
		Me.GroupBox1.Text = "Add to Collection"
		'
		'cmdAdd
		'
		Me.cmdAdd.Location = New System.Drawing.Point(304, 16)
		Me.cmdAdd.Name = "cmdAdd"
		Me.cmdAdd.Size = New System.Drawing.Size(112, 32)
		Me.cmdAdd.TabIndex = 6
		Me.cmdAdd.Text = "A&dd"
		'
		'txtAccount
		'
		Me.txtAccount.Location = New System.Drawing.Point(180, 105)
		Me.txtAccount.Name = "txtAccount"
		Me.txtAccount.TabIndex = 5
		Me.txtAccount.Text = ""
		'
		'txtLastName
		'
		Me.txtLastName.Location = New System.Drawing.Point(180, 73)
		Me.txtLastName.Name = "txtLastName"
		Me.txtLastName.TabIndex = 3
		Me.txtLastName.Text = ""
		'
		'txtFirstName
		'
		Me.txtFirstName.Location = New System.Drawing.Point(180, 41)
		Me.txtFirstName.Name = "txtFirstName"
		Me.txtFirstName.TabIndex = 1
		Me.txtFirstName.Text = ""
		'
		'Label3
		'
		Me.Label3.Location = New System.Drawing.Point(20, 105)
		Me.Label3.Name = "Label3"
		Me.Label3.Size = New System.Drawing.Size(152, 23)
		Me.Label3.TabIndex = 4
		Me.Label3.Text = "&Account Number:"
		Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
		'
		'Label2
		'
		Me.Label2.Location = New System.Drawing.Point(20, 73)
		Me.Label2.Name = "Label2"
		Me.Label2.Size = New System.Drawing.Size(152, 23)
		Me.Label2.TabIndex = 2
		Me.Label2.Text = "&Last Name:"
		Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
		'
		'Label1
		'
		Me.Label1.Location = New System.Drawing.Point(20, 41)
		Me.Label1.Name = "Label1"
		Me.Label1.Size = New System.Drawing.Size(152, 23)
		Me.Label1.TabIndex = 0
		Me.Label1.Text = "First &Name:"
		Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
		'
		'lstItems
		'
		Me.lstItems.Location = New System.Drawing.Point(8, 160)
		Me.lstItems.Name = "lstItems"
		Me.lstItems.Size = New System.Drawing.Size(256, 121)
		Me.lstItems.TabIndex = 1
		'
		'cmdReload
		'
		Me.cmdReload.Location = New System.Drawing.Point(272, 240)
		Me.cmdReload.Name = "cmdReload"
		Me.cmdReload.Size = New System.Drawing.Size(160, 32)
		Me.cmdReload.TabIndex = 4
		Me.cmdReload.Text = "Re&load list from collection"
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
		'frmMain
		'
		Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
		Me.ClientSize = New System.Drawing.Size(440, 305)
		Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.cmdReload, Me.lstItems, Me.GroupBox1, Me.cmdItem, Me.cmdRemove})
		Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
		Me.Name = "frmMain"
		Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
		Me.Text = "Title Comes from Assembly Info"
		Me.GroupBox1.ResumeLayout(False)
		Me.ResumeLayout(False)

	End Sub

#End Region

#Region " Standard Menu Code "
    ' <System.Diagnostics.DebuggerStepThrough()> has been added to some procedures since they are
    ' not the focus of the demo. Remove them if you wish to debug the procedures.
    ' This code simply shows the About form.
	<System.Diagnostics.DebuggerStepThroughAttribute()> Private Sub mnuAbout_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
		' Open the About form in Dialog Mode
		Dim frm As New frmAbout()
		frm.ShowDialog(Me)
		frm.Dispose()
	End Sub

	' This code will close the form.
	<System.Diagnostics.DebuggerStepThroughAttribute()> Private Sub mnuFileClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
		' Close the current form
		Me.Close()
	End Sub
#End Region

    Private Sub cmdAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAdd.Click
		Dim cust As Customer
		Dim listNumber As Integer

        cust = myCustomers.Add(txtFirstName.Text, txtLastName.Text, txtAccount.Text)

		listNumber = lstItems.Items.Add(cust)

        lstItems.Refresh()

		txtFirstName.Text = String.Empty
		txtLastName.Text = String.Empty
		txtAccount.Text = String.Empty
	End Sub

	Private Sub cmdItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdItem.Click
		Dim listCustomer As Customer
		Dim cust As Customer

		If lstItems.SelectedIndex > -1 Then
			listCustomer = lstItems.SelectedItem

			' From here, we COULD simply display the information
			' by using the listCustomer object instead of looking
			' up the primary copy in the Customers collection.
			'
			' However, we will be looking up the item in the 
			' Customers collection since we went through the trouble
			' of creating the collection to begin with. Also to show
			' how it is done.

			Try
				cust = myCustomers.Item(listCustomer)
				MessageBox.Show(cust.AccountNumber & " " & cust.FirstName & _
				 " " & cust.LastName, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)

			Catch exp As Exception
				MessageBox.Show(exp.Message, exp.Source, MessageBoxButtons.OK, MessageBoxIcon.Error)
			End Try
		End If
	End Sub

	Private Sub cmdReload_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdReload.Click

		Dim cust As Customer

		lstItems.Items.Clear()
		'lstItems.DisplayMember = "AccountNumber"

		For Each cust In myCustomers
			lstItems.Items.Add(cust)
		Next

	End Sub

	Private Sub cmdRemove_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdRemove.Click


		Dim listCustomer As Customer
		Dim cust As Customer

		If lstItems.SelectedIndex > -1 Then
			listCustomer = lstItems.SelectedItem

			' From here, we COULD simply remove the collection
			' item by using the listCustomer object instead of
			' looking up the primary copy in the Customers 
			' collection.
			'
			' However, we will be looking up the item in the 
			' Customers collection since we went through the trouble
			' of creating the collection to begin with. Also to show
			' how it is done.

			Try
				cust = myCustomers.Item(listCustomer)
				myCustomers.Remove(cust)
				lstItems.Items.Remove(listCustomer)

			Catch exp As Exception
				MessageBox.Show(exp.Message, exp.Source, MessageBoxButtons.OK, MessageBoxIcon.Error)
			End Try
		End If


	End Sub

	Private Sub frmMain_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
		Dim cust As Customer
		Dim listNumber As Integer

		' When adding an object to a listbox, you must
		' set the listbox "DisplayMember" property BEFORE
		' adding the object. This will allow the listbox
		' to display whatever property of the added object
		' you want.
		lstItems.DisplayMember = "DisplayData"

		' Remove the comment below to change the binded property
		'lstItems.DisplayMember = "AccountNumber"

		' Load Some Samples Customers
		cust = myCustomers.Add("Tom", "Slick", "1234567890")
		listNumber = lstItems.Items.Add(cust)

		cust = myCustomers.Add("Bob", "Dabs", "9812462424")
		listNumber = lstItems.Items.Add(cust)

		cust = myCustomers.Add("Mike", "Chevel", "5783574123")
		listNumber = lstItems.Items.Add(cust)

	End Sub
End Class
