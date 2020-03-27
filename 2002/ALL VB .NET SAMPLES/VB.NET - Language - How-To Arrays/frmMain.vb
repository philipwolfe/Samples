'Copyright (C) 2002 Microsoft Corporation
'All rights reserved.
'THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, EITHER 
'EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED WARRANTIES OF 
'MERCHANTIBILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.

'Requires the Trial or Release version of Visual Studio .NET Professional (or greater).

Option Strict On

Public Class frmMain
	Inherits System.Windows.Forms.Form

	' Used to specify which listbox the DisplayArrayData
	' method should use when loading data.
	Private Enum WhichListBox
		BoxOne
		BoxTwo
	End Enum

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
	Friend WithEvents cmdCreateStatic As System.Windows.Forms.Button
	Friend WithEvents cmdCreateDynamic As System.Windows.Forms.Button
	Friend WithEvents cmdSort As System.Windows.Forms.Button
	Friend WithEvents cmdReverse As System.Windows.Forms.Button
	Friend WithEvents cmdBinarySearch As System.Windows.Forms.Button
	Friend WithEvents grpArrayType As System.Windows.Forms.GroupBox
	Friend WithEvents optStrings As System.Windows.Forms.RadioButton
	Friend WithEvents optObjects As System.Windows.Forms.RadioButton
	Friend WithEvents lstArrayData As System.Windows.Forms.ListBox
	Friend WithEvents lstAfter As System.Windows.Forms.ListBox
	Friend WithEvents grpCompareField As System.Windows.Forms.GroupBox
	Friend WithEvents optId As System.Windows.Forms.RadioButton
	Friend WithEvents optName As System.Windows.Forms.RadioButton
	Friend WithEvents lblDataAfter As System.Windows.Forms.Label
	Friend WithEvents txtLength As System.Windows.Forms.TextBox
	Friend WithEvents txtBSearchFor As System.Windows.Forms.TextBox
	Friend WithEvents lblDataAsLoaded As System.Windows.Forms.Label
	Friend WithEvents lblSearchFor As System.Windows.Forms.Label
	Friend WithEvents lblNumElements As System.Windows.Forms.Label
	Friend WithEvents cmdCreateMatrix As System.Windows.Forms.Button
	<System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
		Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmMain))
		Me.mnuMain = New System.Windows.Forms.MainMenu()
		Me.mnuFile = New System.Windows.Forms.MenuItem()
		Me.mnuExit = New System.Windows.Forms.MenuItem()
		Me.mnuHelp = New System.Windows.Forms.MenuItem()
		Me.mnuAbout = New System.Windows.Forms.MenuItem()
		Me.cmdCreateStatic = New System.Windows.Forms.Button()
		Me.cmdCreateDynamic = New System.Windows.Forms.Button()
		Me.cmdSort = New System.Windows.Forms.Button()
		Me.cmdReverse = New System.Windows.Forms.Button()
		Me.cmdBinarySearch = New System.Windows.Forms.Button()
		Me.cmdCreateMatrix = New System.Windows.Forms.Button()
		Me.grpArrayType = New System.Windows.Forms.GroupBox()
		Me.optObjects = New System.Windows.Forms.RadioButton()
		Me.optStrings = New System.Windows.Forms.RadioButton()
		Me.lstArrayData = New System.Windows.Forms.ListBox()
		Me.lstAfter = New System.Windows.Forms.ListBox()
		Me.grpCompareField = New System.Windows.Forms.GroupBox()
		Me.optName = New System.Windows.Forms.RadioButton()
		Me.optId = New System.Windows.Forms.RadioButton()
		Me.lblDataAsLoaded = New System.Windows.Forms.Label()
		Me.lblDataAfter = New System.Windows.Forms.Label()
		Me.txtLength = New System.Windows.Forms.TextBox()
		Me.txtBSearchFor = New System.Windows.Forms.TextBox()
		Me.lblSearchFor = New System.Windows.Forms.Label()
		Me.lblNumElements = New System.Windows.Forms.Label()
		Me.grpArrayType.SuspendLayout()
		Me.grpCompareField.SuspendLayout()
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
		'cmdCreateStatic
		'
		Me.cmdCreateStatic.Location = New System.Drawing.Point(8, 8)
		Me.cmdCreateStatic.Name = "cmdCreateStatic"
		Me.cmdCreateStatic.Size = New System.Drawing.Size(144, 23)
		Me.cmdCreateStatic.TabIndex = 0
		Me.cmdCreateStatic.Text = "&Create Static Array"
		'
		'cmdCreateDynamic
		'
		Me.cmdCreateDynamic.Location = New System.Drawing.Point(8, 192)
		Me.cmdCreateDynamic.Name = "cmdCreateDynamic"
		Me.cmdCreateDynamic.Size = New System.Drawing.Size(144, 23)
		Me.cmdCreateDynamic.TabIndex = 6
		Me.cmdCreateDynamic.Text = "Create &Dynamic Array"
		'
		'cmdSort
		'
		Me.cmdSort.Location = New System.Drawing.Point(8, 40)
		Me.cmdSort.Name = "cmdSort"
		Me.cmdSort.Size = New System.Drawing.Size(144, 23)
		Me.cmdSort.TabIndex = 1
		Me.cmdSort.Text = "&Sort"
		'
		'cmdReverse
		'
		Me.cmdReverse.Location = New System.Drawing.Point(8, 72)
		Me.cmdReverse.Name = "cmdReverse"
		Me.cmdReverse.Size = New System.Drawing.Size(144, 23)
		Me.cmdReverse.TabIndex = 2
		Me.cmdReverse.Text = "&Reverse"
		'
		'cmdBinarySearch
		'
		Me.cmdBinarySearch.Location = New System.Drawing.Point(8, 104)
		Me.cmdBinarySearch.Name = "cmdBinarySearch"
		Me.cmdBinarySearch.Size = New System.Drawing.Size(144, 23)
		Me.cmdBinarySearch.TabIndex = 3
		Me.cmdBinarySearch.Text = "&Binary Search"
		'
		'cmdCreateMatrix
		'
		Me.cmdCreateMatrix.Location = New System.Drawing.Point(8, 256)
		Me.cmdCreateMatrix.Name = "cmdCreateMatrix"
		Me.cmdCreateMatrix.Size = New System.Drawing.Size(144, 23)
		Me.cmdCreateMatrix.TabIndex = 9
		Me.cmdCreateMatrix.Text = "Create a &Matrix Array"
		'
		'grpArrayType
		'
		Me.grpArrayType.Controls.AddRange(New System.Windows.Forms.Control() {Me.optObjects, Me.optStrings})
		Me.grpArrayType.Location = New System.Drawing.Point(160, 8)
		Me.grpArrayType.Name = "grpArrayType"
		Me.grpArrayType.Size = New System.Drawing.Size(120, 80)
		Me.grpArrayType.TabIndex = 10
		Me.grpArrayType.TabStop = False
		Me.grpArrayType.Text = "&Array of . . ."
		'
		'optObjects
		'
		Me.optObjects.Location = New System.Drawing.Point(8, 48)
		Me.optObjects.Name = "optObjects"
		Me.optObjects.Size = New System.Drawing.Size(75, 24)
		Me.optObjects.TabIndex = 1
		Me.optObjects.Text = "Objects"
		'
		'optStrings
		'
		Me.optStrings.Location = New System.Drawing.Point(8, 24)
		Me.optStrings.Name = "optStrings"
		Me.optStrings.Size = New System.Drawing.Size(75, 24)
		Me.optStrings.TabIndex = 0
		Me.optStrings.Text = "Strings"
		'
		'lstArrayData
		'
		Me.lstArrayData.Location = New System.Drawing.Point(160, 120)
		Me.lstArrayData.Name = "lstArrayData"
		Me.lstArrayData.Size = New System.Drawing.Size(264, 95)
		Me.lstArrayData.TabIndex = 13
		'
		'lstAfter
		'
		Me.lstAfter.Location = New System.Drawing.Point(160, 248)
		Me.lstAfter.Name = "lstAfter"
		Me.lstAfter.Size = New System.Drawing.Size(264, 108)
		Me.lstAfter.TabIndex = 15
		'
		'grpCompareField
		'
		Me.grpCompareField.Controls.AddRange(New System.Windows.Forms.Control() {Me.optName, Me.optId})
		Me.grpCompareField.Location = New System.Drawing.Point(288, 8)
		Me.grpCompareField.Name = "grpCompareField"
		Me.grpCompareField.Size = New System.Drawing.Size(136, 80)
		Me.grpCompareField.TabIndex = 11
		Me.grpCompareField.TabStop = False
		Me.grpCompareField.Text = "&Field to use for Sorts"
		'
		'optName
		'
		Me.optName.Location = New System.Drawing.Point(8, 48)
		Me.optName.Name = "optName"
		Me.optName.Size = New System.Drawing.Size(120, 24)
		Me.optName.TabIndex = 1
		Me.optName.Text = "Customer Name"
		'
		'optId
		'
		Me.optId.Location = New System.Drawing.Point(8, 24)
		Me.optId.Name = "optId"
		Me.optId.Size = New System.Drawing.Size(110, 24)
		Me.optId.TabIndex = 0
		Me.optId.Text = "Customer Id"
		'
		'lblDataAsLoaded
		'
		Me.lblDataAsLoaded.Location = New System.Drawing.Point(160, 96)
		Me.lblDataAsLoaded.Name = "lblDataAsLoaded"
		Me.lblDataAsLoaded.Size = New System.Drawing.Size(264, 23)
		Me.lblDataAsLoaded.TabIndex = 12
		Me.lblDataAsLoaded.Text = "Data As Loaded"
		'
		'lblDataAfter
		'
		Me.lblDataAfter.Location = New System.Drawing.Point(160, 224)
		Me.lblDataAfter.Name = "lblDataAfter"
		Me.lblDataAfter.Size = New System.Drawing.Size(264, 23)
		Me.lblDataAfter.TabIndex = 14
		Me.lblDataAfter.Text = "No Data Displayed"
		'
		'txtLength
		'
		Me.txtLength.Location = New System.Drawing.Point(112, 224)
		Me.txtLength.Name = "txtLength"
		Me.txtLength.Size = New System.Drawing.Size(40, 20)
		Me.txtLength.TabIndex = 8
		Me.txtLength.Text = "3"
		Me.txtLength.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
		'
		'txtBSearchFor
		'
		Me.txtBSearchFor.Location = New System.Drawing.Point(8, 160)
		Me.txtBSearchFor.Name = "txtBSearchFor"
		Me.txtBSearchFor.Size = New System.Drawing.Size(144, 20)
		Me.txtBSearchFor.TabIndex = 5
		Me.txtBSearchFor.Text = "Joe Max"
		'
		'lblSearchFor
		'
		Me.lblSearchFor.Location = New System.Drawing.Point(8, 136)
		Me.lblSearchFor.Name = "lblSearchFor"
		Me.lblSearchFor.Size = New System.Drawing.Size(144, 23)
		Me.lblSearchFor.TabIndex = 4
		Me.lblSearchFor.Text = "Search F&or:"
		'
		'lblNumElements
		'
		Me.lblNumElements.Location = New System.Drawing.Point(8, 224)
		Me.lblNumElements.Name = "lblNumElements"
		Me.lblNumElements.Size = New System.Drawing.Size(96, 32)
		Me.lblNumElements.TabIndex = 7
		Me.lblNumElements.Text = "# of &Elements for Dynamic Array"
		'
		'frmMain
		'
		Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
		Me.ClientSize = New System.Drawing.Size(434, 371)
		Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.lblNumElements, Me.lblSearchFor, Me.txtBSearchFor, Me.txtLength, Me.lblDataAfter, Me.lblDataAsLoaded, Me.grpCompareField, Me.lstAfter, Me.lstArrayData, Me.grpArrayType, Me.cmdCreateMatrix, Me.cmdBinarySearch, Me.cmdReverse, Me.cmdSort, Me.cmdCreateDynamic, Me.cmdCreateStatic})
		Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
		Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
		Me.MaximizeBox = False
		Me.Menu = Me.mnuMain
		Me.Name = "frmMain"
		Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
		Me.Text = "Title Comes from Assembly Info"
		Me.grpArrayType.ResumeLayout(False)
		Me.grpCompareField.ResumeLayout(False)
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

	Private Sub frmMain_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
		Me.optStrings.Checked = True
		Me.optName.Checked = True
	End Sub

	Private Sub cmdBinarySearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdBinarySearch.Click
		Dim strMsg As String
		Dim intPos As Integer

		' Make sure there is a value to use a search criteria.
		If Me.txtBSearchFor.Text.Length = 0 Then
			MessageBox.Show("Please enter a value to search for", "Binary Search", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
			Me.txtBSearchFor.Select()
			Exit Sub
		End If

		Dim strDataToFind As String = Me.txtBSearchFor.Text
		Me.lstAfter.Items.Clear()

		If Me.optStrings.Checked Then
			Dim strData() As String = {"Joe Hasterman", "Ted Mattison", "Joe Rummel", "Brian Gurnure", "Doug Landal"}

			' Sort the array otherwise the BinarySearch method won't work.
			Array.Sort(strData)

			' Show the data sorted.
			DisplayArrayData(strData)

			' Perform search
			intPos = Array.BinarySearch(strData, strDataToFind)

			If intPos > 0 Then
				strMsg = String.Format("The value {0} was found in the array at position {1}.", strDataToFind, intPos.ToString())
			Else
				' If the item is not found, a negative number is returned.
				' This is the bitwise complement for the location where the
				' item would have been *if* it existed.
				' We use the Not operator to flip it back to a postive number.
				Dim intBWC As Integer = (Not intPos)

				If intBWC = 0 Then
					strMsg = String.Format("The value {0} was NOT found in the array. If it did exist it would be at position {1} before {2}", strDataToFind, intBWC.ToString(), strData(1))
				Else
					Dim strItems() As String = {strDataToFind, intBWC.ToString(), strData(intBWC - 1), strData(intBWC)}
					strMsg = String.Format("The value {0} was NOT found in the array. If it did exist it would be at position {1} between {2} and {3}.", strItems)
				End If
			End If

			MessageBox.Show(strMsg, "Binary Search Results", MessageBoxButtons.OK, MessageBoxIcon.Information)
		Else

			Dim objData() As Customer = {New Customer(3423, "Joe Hasterman"), New Customer(9348, "Ted Mattison"), New Customer(3581, "Joe Rummel"), New Customer(7642, "Brian Gurnure"), New Customer(2985, "Doug Landal")}

			Array.Sort(objData)

			DisplayArrayData(objData)

			' When searching an array of objects, we need to use
			' a compatible object type. In this case we're using
			' the value provided by the txtBSearchFor box as the 
			' customer's name and providing a bogus Id value.
			' The key to binary search working with objects is that
			' the object must implement IComparable.
			Dim c As New Customer(1, Me.txtBSearchFor.Text)

			intPos = Array.BinarySearch(objData, c, Nothing)

			If intPos > 0 Then
				strMsg = String.Format("The value {0} was found in the array at position {1}.", strDataToFind, intPos.ToString())
			Else
				Dim intBWC As Integer = (Not intPos)

				If intBWC = 0 Then
					strMsg = String.Format("The value {0} was NOT found in the array. If it did exist it would be at position {1} before {2}", strDataToFind, intBWC.ToString(), objData(1).Name)
				Else
					Dim strItems() As String = {strDataToFind, intBWC.ToString(), objData(intBWC - 1).name, objData(intBWC).name}
					strMsg = String.Format("The value {0} was NOT found in the array. If it did exist it would be at position {1} between {2} and {3}.", strItems)
				End If
			End If

			MessageBox.Show(strMsg, "Binary Search Results", MessageBoxButtons.OK, MessageBoxIcon.Information)
		End If
	End Sub

	Private Sub cmdCreateDynamic_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCreateDynamic.Click
		' This routine builds a dynamic array
		' using the value specified in txtLength
		' to set the number of buckets.
		If Me.optStrings.Checked Then
			Dim strDynamicData() As String
			ReDim strDynamicData(System.Convert.ToInt32(Me.txtLength.Text) - 1)
			Dim i As Integer
			Dim strInput As String
			For i = 0 To strDynamicData.Length - 1
				strDynamicData(i) = InputBox("Enter a string", i.ToString(), "None " & i)
			Next
			DisplayArrayData(strDynamicData)
		Else
			Dim strDynamicData() As Customer
			ReDim strDynamicData(System.Convert.ToInt32(Me.txtLength.Text) - 1)
			Dim i As Integer
			Dim strInput As String

			For i = 0 To strDynamicData.Length - 1
				strDynamicData(i) = New Customer()
				strDynamicData(i).Id = ((i + 1) * 10)
				strDynamicData(i).Name = InputBox("Enter a string", ("Item " & (i + 1)), ("None " & i + 1))
			Next

			DisplayArrayData(strDynamicData)
		End If
	End Sub

	Private Sub cmdCreateMatrix_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCreateMatrix.Click
		' This procedure uses the new initialization syntax to create a simple matrix array.
		Dim strMatrix(,) As String = {{"Bob", "Carol"}, {"Ted", "Alice"}, {"Joe", "Lisa"}}
		Me.DisplayArrayData(strMatrix)
	End Sub

	Private Sub cmdCreateStatic_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCreateStatic.Click
		' This procedure uses the new initialization to build either a static
		' array of strings or an array of Customer objects.
		' Note that the arrary could of course be resized using the ReDim staetment.
		If Me.optStrings.Checked Then
			Dim strData() As String = {"Joe Hasterman", "Ted Mattison", "Joe Rummel", "Brian Gurnure", "Doug Landal"}
			DisplayArrayData(strData)
		Else
			' This command here takes advantage of the fact that objects in .NET
			' can have parameterized constructors. This allows us to specify an
			' array of objects in one line of code.
			Dim objData() As Customer = {New Customer(3423, "Joe Hasterman"), New Customer(9348, "Ted Mattison"), New Customer(3581, "Joe Rummel"), New Customer(7642, "Brian Gurnure"), New Customer(2985, "Doug Landal")}
			DisplayArrayData(objData)
		End If
	End Sub

	Private Sub cmdReverse_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdReverse.Click
		' Reverse reorders the elements in an array in decending order as they were added.
		Me.lblDataAfter.Text = "Data After Reverse"
		If Me.optStrings.Checked Then
			Dim strData() As String = {"Joe Hasterman", "Ted Mattison", "Joe Rummel", "Brian Gurnure", "Doug Landal"}
			Array.Reverse(strData)
			DisplayArrayData(strData, WhichListBox.BoxTwo)
		Else
			Dim objData() As Customer = {New Customer(3423, "Joe Hasterman"), New Customer(9348, "Ted Mattison"), New Customer(3581, "Joe Rummel"), New Customer(7642, "Brian Gurnure"), New Customer(2985, "Doug Landal")}
			Array.Reverse(objData)
			DisplayArrayData(objData, WhichListBox.BoxTwo)
		End If

	End Sub

	Private Sub cmdSort_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSort.Click
		' In order for this procedure to work, the items contained in the array
		' must support comparsion. This is accomplished by objects by implementing
		' the IComparable interface.
		' See the Customer object definition below for more information.

		Me.lblDataAfter.Text = "Data After Sort"

		If Me.optStrings.Checked Then
			Dim strData() As String = {"Joe Hasterman", "Ted Mattison", "Joe Rummel", "Brian Gurnure", "Doug Landal"}
			Array.Sort(strData)
			DisplayArrayData(strData, WhichListBox.BoxTwo)
		Else
			Dim objData() As Customer = {New Customer(3423, "Joe Hasterman"), New Customer(9348, "Ted Mattison"), New Customer(3581, "Joe Rummel"), New Customer(7642, "Brian Gurnure"), New Customer(2985, "Doug Landal")}
			Array.Sort(objData)
			DisplayArrayData(objData, WhichListBox.BoxTwo)
		End If
	End Sub

	Private Sub txtLength_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtLength.Validating
		Dim txt As TextBox = CType(sender, TextBox)

		If Not IsNumeric(txt.Text) Then
			' Make sure only numbers are entered in this text box.
			MessageBox.Show(txt.Text & " is not a valid number.", "Non-Numeric Data", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
			txt.Text = 1.ToString()
		Else
			Try
				' Make sure the value fits within an Integer data types value range.
				Dim i As Integer = CInt(txt.Text)
			Catch exp As OverflowException
				Dim strMsg As String
				strMsg = String.Format("The value you entered, {0} is too large. Valid values are between -{1} and {2}", txt.Text, Integer.MaxValue, Integer.MaxValue)

				MessageBox.Show(strMsg, "Value Overflow", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
				' 
				txt.Text = 1.ToString()
			End Try
		End If
	End Sub

	Private Sub CompareKeyCheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles optId.CheckedChanged, optId.CheckedChanged
		Dim opt As RadioButton = CType(sender, RadioButton)
		' Change the field used by the Customer object when sorts or searches 
		' are applied.
		If opt.Name = "optId" Then
			' SetCompareKey is a shared member that will affect all instances
			' of the Customer type in this AppDomain.
			Customer.SetCompareKey(Customer.CompareField.Id)
		Else
			Customer.SetCompareKey(Customer.CompareField.Name)
		End If

		Me.lstAfter.Items.Clear()
		Me.lblDataAfter.Text = "Data Cleared. Sort Again"
		Me.cmdSort.Select()
	End Sub

	Private Sub DataTypeCheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles optStrings.CheckedChanged, optObjects.CheckedChanged
		' Enabled the grpCompareField only when objects are being loaded
		' into arrays.
		Dim opt As RadioButton = CType(sender, RadioButton)
		Me.grpCompareField.Enabled = Not (opt.Name = "optStrings")
		Me.lstArrayData.Items.Clear()
		Me.lstAfter.Items.Clear()
	End Sub

	Private Sub DisplayArrayData(ByVal arr As Array)
		' Delegate to the next more complex version.
		Me.DisplayArrayData(arr, WhichListBox.BoxOne)
	End Sub

	Private Sub DisplayArrayData(ByVal arr As Array, ByVal ListBox As WhichListBox)

		Dim i As Integer
		Dim u As Integer = (arr.Length - 1)
		Dim strOutput As String

		Dim lst As ListBox
		If ListBox = WhichListBox.BoxOne Then
			lst = Me.lstArrayData
		Else
			lst = Me.lstAfter
		End If

		lst.Items.Clear()

		' Figure out how many dimensions (expressed as Rank)
		' the passed in array has.
		Select Case arr.Rank
			Case 1
				For i = 0 To u
					lst.Items.Add(String.Format("{0} = {1}", i, arr.GetValue(i).ToString()))
				Next
			Case 2
				Dim j As Integer
				For i = 0 To (arr.GetLength(0) - 1)
					For j = 0 To (arr.GetLength(1) - 1)
						lst.Items.Add(String.Format("({0}, {1}) = {2}", i, j, arr.GetValue(i, j).ToString()))
					Next j
				Next i

			Case Else
				' Sorry, we don't go beyond two dimensions
				lst.Items.Add(String.Format("The array received has too many dimensions ({0})", arr.Rank))

		End Select
	End Sub
End Class

Public Class Customer
	Implements IComparable	' This allows us to support sorting and binary searches

	' Used to control which field is used for comparisons.
	Private Shared m_CompareField As CompareField

	Public Id As Integer
	Public Name As String

	Public Enum CompareField
		Name
		Id
	End Enum

	Shared Sub New()
		' Set the default compare field
		m_CompareField = CompareField.Name
	End Sub

	Public Shared Sub SetCompareKey(ByVal CompareKey As CompareField)
		' Change the comparison field
		m_CompareField = CompareKey
	End Sub

	Public Sub New()
		' Set default values by delegating to the next most complex constructor
		Me.New(-1, "No Name")
	End Sub

	Public Sub New(ByVal NewId As Integer, ByVal NewName As String)
		Me.Id = NewId
		Me.Name = NewName
	End Sub

	Public Function CompareTo(ByVal obj As Object) As Integer Implements System.IComparable.CompareTo
		' First check to make sure we're only being compared to another customer.
		If TypeOf obj Is Customer Then
			' Create a strongly typed reference
			Dim c As Customer = CType(obj, Customer)
			' Determine if we should compare by Name or Id
			If Customer.m_CompareField = CompareField.Name Then
				If c.Name = Me.Name Then
					Return 0
				ElseIf c.Name < Me.Name Then
					Return 1
				Else
					Return -1
				End If
			Else
				If c.Id = Me.Id Then
					Return 0
				ElseIf c.Id < Me.Id Then
					Return 1
				Else
					Return -1
				End If
			End If
		Else
			Throw New ArgumentException("Customers can only be compared against other customers. The object being passed in was a " & obj.GetType.ToString())
		End If
	End Function

	Public Overrides Function ToString() As String
		' Normally ToString returns the fully qualified typename.
		' In this example it would be VBNET.HowTo.Arrays.Customer
		' We are overriding it so that we can return a simple
		' display string when we're added to a list box.
		Return String.Format("Id={0}, Name={1}", Me.Id, Me.Name)
	End Function
End Class