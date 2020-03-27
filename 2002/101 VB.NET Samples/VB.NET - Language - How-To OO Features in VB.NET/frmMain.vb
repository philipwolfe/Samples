'Copyright (C) 2002 Microsoft Corporation
'All rights reserved.
'THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, EITHER 
'EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED WARRANTIES OF 
'MERCHANTIBILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.

'Requires the Trial or Release version of Visual Studio .NET Professional (or greater).

Option Strict On

Public Class frmMain
	Inherits System.Windows.Forms.Form

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
	Friend WithEvents cmdOverloads As System.Windows.Forms.Button
	Friend WithEvents cmdConstructors As System.Windows.Forms.Button
	Friend WithEvents cmdPropertySyntax As System.Windows.Forms.Button
	Friend WithEvents cmdParamProperties As System.Windows.Forms.Button
	Friend WithEvents cmdSharedMembers As System.Windows.Forms.Button
	Friend WithEvents MainMenu1 As System.Windows.Forms.MainMenu
	Friend WithEvents mnuFile As System.Windows.Forms.MenuItem
	Friend WithEvents mnuExit As System.Windows.Forms.MenuItem
	Friend WithEvents mnuHelp As System.Windows.Forms.MenuItem
	Friend WithEvents mnuAbout As System.Windows.Forms.MenuItem
	<System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
		Me.cmdOverloads = New System.Windows.Forms.Button()
		Me.cmdConstructors = New System.Windows.Forms.Button()
		Me.cmdPropertySyntax = New System.Windows.Forms.Button()
		Me.cmdParamProperties = New System.Windows.Forms.Button()
		Me.cmdSharedMembers = New System.Windows.Forms.Button()
		Me.MainMenu1 = New System.Windows.Forms.MainMenu()
		Me.mnuFile = New System.Windows.Forms.MenuItem()
		Me.mnuExit = New System.Windows.Forms.MenuItem()
		Me.mnuHelp = New System.Windows.Forms.MenuItem()
		Me.mnuAbout = New System.Windows.Forms.MenuItem()
		Me.SuspendLayout()
		'
		'cmdOverloads
		'
		Me.cmdOverloads.Location = New System.Drawing.Point(8, 8)
		Me.cmdOverloads.Name = "cmdOverloads"
		Me.cmdOverloads.Size = New System.Drawing.Size(336, 25)
		Me.cmdOverloads.TabIndex = 0
		Me.cmdOverloads.Text = "&Overloads"
		'
		'cmdConstructors
		'
		Me.cmdConstructors.Location = New System.Drawing.Point(8, 48)
		Me.cmdConstructors.Name = "cmdConstructors"
		Me.cmdConstructors.Size = New System.Drawing.Size(336, 25)
		Me.cmdConstructors.TabIndex = 1
		Me.cmdConstructors.Text = "&Constructors"
		'
		'cmdPropertySyntax
		'
		Me.cmdPropertySyntax.Location = New System.Drawing.Point(8, 88)
		Me.cmdPropertySyntax.Name = "cmdPropertySyntax"
		Me.cmdPropertySyntax.Size = New System.Drawing.Size(336, 25)
		Me.cmdPropertySyntax.TabIndex = 2
		Me.cmdPropertySyntax.Text = "Property &Syntax"
		'
		'cmdParamProperties
		'
		Me.cmdParamProperties.Location = New System.Drawing.Point(8, 128)
		Me.cmdParamProperties.Name = "cmdParamProperties"
		Me.cmdParamProperties.Size = New System.Drawing.Size(336, 25)
		Me.cmdParamProperties.TabIndex = 3
		Me.cmdParamProperties.Text = "&Parameterized Properties"
		'
		'cmdSharedMembers
		'
		Me.cmdSharedMembers.Location = New System.Drawing.Point(8, 168)
		Me.cmdSharedMembers.Name = "cmdSharedMembers"
		Me.cmdSharedMembers.Size = New System.Drawing.Size(336, 25)
		Me.cmdSharedMembers.TabIndex = 4
		Me.cmdSharedMembers.Text = "Shared &Members"
		'
		'MainMenu1
		'
		Me.MainMenu1.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.mnuFile, Me.mnuHelp})
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
		Me.ClientSize = New System.Drawing.Size(352, 201)
		Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.cmdSharedMembers, Me.cmdParamProperties, Me.cmdPropertySyntax, Me.cmdConstructors, Me.cmdOverloads})
		Me.Menu = Me.MainMenu1
		Me.Name = "frmMain"
		Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
		Me.Text = "Title Comes from Assembly Info"
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

	Private Sub cmdConstructors_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdConstructors.Click

		' A Constructor in VB.NET is simply code that executes when
		' an class is instanced. The constructor may or may not require
		' parameters to be passed into the constructor.

		' Here is the syntax for instantiating a class with a
		' constructor in a single line. This is the recommended way to
		' instantiate a class with a constructor:

		Dim cust As New CustomerWithConstructor("1101", "Carmen", "Smith")

		' Alternatively you can instantiate a class after creating the
		' variable:

		Dim cust2 As CustomerWithConstructor
		cust2 = New CustomerWithConstructor("1101", "Carmen", "Smith")

		' You can overload the Sub New procedure in a class if you want.
		' By doing this, you can create different versions of the
		' constructor that can be called from different client code.
		' For example, you may want a constructor that can only be called
		' by external code, in which case you would use Public Overloads Sub
		' New(). Then you might want to add a separate constructor that can
		' only be called from code within the class (for example, if you
		' were implementing a Clone method). In that case you would use
		' Private Overloads Sub New().
		'
		' For more information on overloading constructors, see 
		' ms-help://MS.VSCC/MS.MSDNVS/vbcon/html/vbconHowDoIControlCreationOfComponents.htm
		' in the Visual Studio .NET documentation.
		'
		' Another thing you can do with constructors in VB.NET is perform 
		' access control for your class. For example, suppose you wanted to
		' develop a class that is exposed to external code, but not creatable
		' directly. In classic Visual Basic you would set the Instancing
		' property of the class to "PublicNotCreatable". In VB.NET, you would
		' create a public class and add a constructor to the class that is
		' declared Friend. For more information on using constructors to
		' control access to your class, see
		' ms-help://MS.VSCC/MS.MSDNVS/vbcon/html/vbconhowvisualbasic60instancingmapstovisualbasic70.htm
		' in the Visual Studio .NET documentation.

	End Sub

	Private Sub cmdOverloads_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdOverloads.Click

		Dim myCust1 As Customer
		Dim myCust2 As Customer

		' The purpose of the "Overloads" keyword in VB.NET is to allow
		' you to create multiple procedures that have the same name but
		' execute separate code.
		'
		' Suppose that you want to create a way of looking up a customer
		' from either a database or a collection. You also want to be able
		' to look up the customer by either last name or the customer's ID
		' number. In classic Visual Basic, you would normally create two
		' separate functions such as "GetCustomerByID" and 
		' "GetCustomerByLastName".
		'
		' In VB.NET you can create to functions with the same name by using
		' the Overloads keyword. Each version of the function can have its
		' own set of parameters that are different from the others.
		'
		' When calling an overloaded procedure, you will see the different
		' versions that are available through VB.NET's Intellisense. At the
		' beginning of the Intellisense message you will see up and down
		' arrows with an indicator to show how many overloaded versions of
		' the procedure exist, and which one you are currently viewing.
		'
		' You can see an example of the Intellisense for an overloaded
		' procedure by changing the parameters below. Put your cursor after
		' the number 1101 in the second GetCustomer call and hit the space
		' bar.

		myCust1 = GetCustomer("Smith")
		myCust2 = GetCustomer(1101)

		' Scroll down to the GetCustomer procedures below to see how to
		' implement the Overloads keyword in VB.NET.

	End Sub

	Private Sub cmdParamProperties_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdParamProperties.Click

		Dim cust As New CustomerWithParameterizedProperty()

		' To create a parameterized property, you add a parameter to the
		' Property statement. See 
		' CustomerWithParameterizedProperty.DefaultQuantity for more details.
		'
		' The parameter can be of any type, but is normally an integer for
		' use as an index.
		'
		' You can see below that when you implement a parameterized property,
		' you must specify the parameter even if the property procedure
		' doesn't use the parameter, as in this case. We set up the property
		' procedure to use the parameter as a multiplier to the customer's
		' default quantity. If you pass a 5, it multiplies the customer's
		' default quantity by five.
		'
		' When setting the DefaultQuantity value, we must pass in the 
		' multiplier parameter even though it is not used.


		cust.DefaultQuantity(0) = 100

		MessageBox.Show("The default quantity for this customer is " & cust.DefaultQuantity(3), Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)


	End Sub

	Private Sub cmdPropertySyntax_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdPropertySyntax.Click

		' The code below creates an instance of the 
		' CustomerPropertySyntax class and retrieves the value
		' from a read-only property, AccountNumber. Step into the
		' code to see more details on property syntax.

		Dim myAccount As String
		Dim cust As New CustomerPropertySyntax("1101")

		myAccount = cust.AccountNumber

	End Sub

	Private Sub cmdSharedMembers_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSharedMembers.Click

		' There are two main types of shared members in a class.
		' The first type are shared variables, and the second
		' type are shared procedures.
		'
		' Below we create two instances of the customer class
		' and change the shared variable "CompanyName". When
		' you run this code you should see a message that the
		' company name is Tailspin Toys. This shows that
		' changing the variable on any instance of the class
		' actually changes its value for all instances.

		Dim cust1 As New CustomerWithSharedMembers()
		Dim cust2 As New CustomerWithSharedMembers()

		' You can use the standard object syntax as follows:
		cust1.CompanyName = "Wingtip Toys"
		cust2.CompanyName = "Tailspin Toys"
		' However the recommended syntax for accessing shared
		' members is ClassName.SharedMemberName, like this:
		' CustomerWithSharedMembers.CompanyName = "Tailspin Toys".
		'
		' The reason we are using object syntax above is to
		' demonstrate that changing the shared variable on any
		' instance of the class will change all instances.

		MessageBox.Show("The company name is " & cust1.CompanyName, Me.Text)

		' The next type of shared member is the shared procedure.
		' When you declare a procedure as shared inside a class,
		' you can invoke the procedure the normal way through
		' an instance of the class (ie cust1.LastOrderDate).
		' You can also invoke the procedure without using an
		' instance of the class by using the syntax:
		' Classname.ProcedureName.
		'
		' Just like the shared variables, the recommended way to
		' invoke a shared procedure is to use the
		' ClassName.SharedProcedureName syntax.

		' Invoke the shared procedure by using object
		' syntax:
		MessageBox.Show("The last order was placed on " & _
		 cust1.LastOrderDate, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)

		' Invoke the shared procedure by using the classname
		' syntax (recommended):
		MessageBox.Show("The last order was placed on " & _
		 CustomerWithSharedMembers.LastOrderDate, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)

	End Sub

	Private Overloads Function GetCustomer(ByVal CustID As Integer) As Customer

		' This is the function that is called if you pass in an integer.

		Dim cust As New Customer()

		' Normally, you would use the CustID integer to search a
		' database or collection for the customer's ID number.
		' Here, we're just going to populate a Customer object with
		' dummy data.
		cust.AccountNumber = "1101"
		cust.FirstName = "Carmen"
		cust.LastName = "Smith"

		Return cust
	End Function

	Private Overloads Function GetCustomer(ByVal CustLastName As String) As Customer

		' This is the function that is called if you pass in a string.

		Dim cust As New Customer()

		' Normally, you would use the CustLastName string to search a
		' database or collection for the customer's last name.
		' Here, we're just going to populate a Customer object with
		' dummy data.
		cust.AccountNumber = "1101"
		cust.FirstName = "Carmen"
		cust.LastName = "Smith"

		Return cust

	End Function

	Private Sub frmMain_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

	End Sub
End Class
