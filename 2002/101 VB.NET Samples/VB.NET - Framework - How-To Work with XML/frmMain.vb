'Copyright (C) 2002 Microsoft Corporation
'All rights reserved.
'THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, EITHER 
'EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED WARRANTIES OF 
'MERCHANTIBILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.

'Requires the Trial or Release version of Visual Studio .NET Professional (or greater).

Option Strict On

' Used to access various XML classes
Imports System.Xml
' Used to access the File class
' which is used to check for file existance.
Imports System.IO

Public Class frmMain
	Inherits System.Windows.Forms.Form

	' Variables to contain the three
	' file names used in this sample.
	Private mstrModifyFile As String
	Private mstrSimpleFile As String
	Private mstrBadFile As String

	' For seperating headers in text output. Search for examples.
	Private mstrLine As New String(System.Convert.ToChar("="), 35)

	' Module level variables for working with the DOM
	Private mxDoc As XmlDocument
	Private mxNode As XmlNode
	Private mxNodeList As XmlNodeList

	' StringWriter for building text blocks with carriage returns
	' and line feeds.
	Dim msw As New StringWriter()

	' Commands to run. Text is loaded at Form_Load into listbox control
	Private Const CMD_LOAD_XML_FILE As String = "Load XML File"
	Private Const CMD_LOAD_XML_STRING As String = "Load XML from String"
	Private Const CMD_TEST_FOR_CHILD_NODES As String = "Tell if a node has children"
	Private Const CMD_ITERATE_ALL_NODES As String = "Iterate through all nodes"
	Private Const CMD_DETERMINE_NODE_TYPE As String = "Determine a Node's Type"
	Private Const CMD_LIST_ALL_ELEMENT_NODES As String = "Retrieve a list of all element nodes"
	Private Const CMD_LIST_ELEMENTS_BY_TAG As String = "Build a list of all nodes that match a specific tag"
	Private Const CMD_SELECT_NODES As String = "Get nodes by XPath Expression (selectNodes)"
	Private Const CMD_SELECT_NODE As String = "Get a node by XPath Expression (selectSingleNode)"
	Private Const CMD_NAVIGATE_RELATED_NODES As String = "Navigate to Related Nodes, Once I've Found a Node?"
	Private Const CMD_RETRIEVE_ATTRIBUTES As String = "Retrieve Attributes of a Node?"
	Private Const CMD_CREATE_XML As String = "Create XML Programmatically?"
	Private Const CMD_ADD_OR_DELETE_ELEMENTS As String = "Add or Delete Elements?"
	Private Const CMD_ADD_OR_DELETE_ATTRIBUTES As String = "Add or Delete Attributes?"
	Private Const CMD_MODIFY_ELEMENT As String = "Modify the Value of an Element Node?"
	Private Const CMD_MODIFY_ATTRIBUTE As String = "Modify the Value of an Attribute?"
	Private Const CMD_VALID_XML As String = "Tell if I've Loaded Valid XML?"
	Private Const CMD_PARSE_ERRORS As String = "Determine What Went Wrong if My XML Won't Load?"

	' Some expressions are hard-coded. Here's a method that lets you enter
	' the text only once.
	Private Const DEF_XPATH_EXP_FIND_NODES As String = "//Item[New]"
	Private Const DEF_XPATH_EXP_FIND_NODE As String = "//Department[@Name='Fruits']"

	' TODO: Clean up text and match to correct procs

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
	Friend WithEvents pnlText As System.Windows.Forms.Panel
	Friend WithEvents splHorText As System.Windows.Forms.Splitter
	Friend WithEvents txtXMLDisplay As System.Windows.Forms.TextBox
	Friend WithEvents txtXMLEdits As System.Windows.Forms.TextBox
	Friend WithEvents sbInfo As System.Windows.Forms.StatusBar
	Friend WithEvents splVert As System.Windows.Forms.Splitter
	Friend WithEvents lstCommands As System.Windows.Forms.CheckedListBox
	Friend WithEvents pnlLB As System.Windows.Forms.Panel
	Friend WithEvents MenuItem1 As System.Windows.Forms.MenuItem
	Friend WithEvents mnuResetCheckBoxes As System.Windows.Forms.MenuItem
	Friend WithEvents lblHowDoI As System.Windows.Forms.Label

	<System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
		Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmMain))
		Me.mnuMain = New System.Windows.Forms.MainMenu()
		Me.mnuFile = New System.Windows.Forms.MenuItem()
		Me.mnuExit = New System.Windows.Forms.MenuItem()
		Me.mnuHelp = New System.Windows.Forms.MenuItem()
		Me.mnuResetCheckBoxes = New System.Windows.Forms.MenuItem()
		Me.MenuItem1 = New System.Windows.Forms.MenuItem()
		Me.mnuAbout = New System.Windows.Forms.MenuItem()
		Me.sbInfo = New System.Windows.Forms.StatusBar()
		Me.pnlLB = New System.Windows.Forms.Panel()
		Me.lstCommands = New System.Windows.Forms.CheckedListBox()
		Me.splVert = New System.Windows.Forms.Splitter()
		Me.pnlText = New System.Windows.Forms.Panel()
		Me.splHorText = New System.Windows.Forms.Splitter()
		Me.txtXMLDisplay = New System.Windows.Forms.TextBox()
		Me.txtXMLEdits = New System.Windows.Forms.TextBox()
		Me.lblHowDoI = New System.Windows.Forms.Label()
		Me.pnlLB.SuspendLayout()
		Me.pnlText.SuspendLayout()
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
		Me.mnuHelp.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.mnuResetCheckBoxes, Me.MenuItem1, Me.mnuAbout})
		Me.mnuHelp.Text = "&Help"
		'
		'mnuResetCheckBoxes
		'
		Me.mnuResetCheckBoxes.Index = 0
		Me.mnuResetCheckBoxes.Text = "&Reset Check Boxes"
		'
		'MenuItem1
		'
		Me.MenuItem1.Index = 1
		Me.MenuItem1.Text = "-"
		'
		'mnuAbout
		'
		Me.mnuAbout.Index = 2
		Me.mnuAbout.Text = "Text Comes from AssemblyInfo"
		'
		'sbInfo
		'
		Me.sbInfo.Location = New System.Drawing.Point(0, 469)
		Me.sbInfo.Name = "sbInfo"
		Me.sbInfo.Size = New System.Drawing.Size(802, 22)
		Me.sbInfo.TabIndex = 4
		Me.sbInfo.Text = "Ready"
		'
		'pnlLB
		'
		Me.pnlLB.Controls.AddRange(New System.Windows.Forms.Control() {Me.lblHowDoI, Me.lstCommands})
		Me.pnlLB.Dock = System.Windows.Forms.DockStyle.Left
		Me.pnlLB.Name = "pnlLB"
		Me.pnlLB.Size = New System.Drawing.Size(344, 469)
		Me.pnlLB.TabIndex = 9
		'
		'lstCommands
		'
		Me.lstCommands.Dock = System.Windows.Forms.DockStyle.Fill
		Me.lstCommands.Name = "lstCommands"
		Me.lstCommands.Size = New System.Drawing.Size(344, 469)
		Me.lstCommands.TabIndex = 7
		'
		'splVert
		'
		Me.splVert.Location = New System.Drawing.Point(344, 0)
		Me.splVert.Name = "splVert"
		Me.splVert.Size = New System.Drawing.Size(3, 469)
		Me.splVert.TabIndex = 10
		Me.splVert.TabStop = False
		'
		'pnlText
		'
		Me.pnlText.Controls.AddRange(New System.Windows.Forms.Control() {Me.splHorText, Me.txtXMLDisplay, Me.txtXMLEdits})
		Me.pnlText.Dock = System.Windows.Forms.DockStyle.Fill
		Me.pnlText.Location = New System.Drawing.Point(347, 0)
		Me.pnlText.Name = "pnlText"
		Me.pnlText.Size = New System.Drawing.Size(455, 469)
		Me.pnlText.TabIndex = 11
		'
		'splHorText
		'
		Me.splHorText.Dock = System.Windows.Forms.DockStyle.Bottom
		Me.splHorText.Location = New System.Drawing.Point(0, 242)
		Me.splHorText.Name = "splHorText"
		Me.splHorText.Size = New System.Drawing.Size(455, 3)
		Me.splHorText.TabIndex = 5
		Me.splHorText.TabStop = False
		'
		'txtXMLDisplay
		'
		Me.txtXMLDisplay.Dock = System.Windows.Forms.DockStyle.Fill
		Me.txtXMLDisplay.Multiline = True
		Me.txtXMLDisplay.Name = "txtXMLDisplay"
		Me.txtXMLDisplay.ScrollBars = System.Windows.Forms.ScrollBars.Both
		Me.txtXMLDisplay.Size = New System.Drawing.Size(455, 245)
		Me.txtXMLDisplay.TabIndex = 4
		Me.txtXMLDisplay.Text = ""
		'
		'txtXMLEdits
		'
		Me.txtXMLEdits.Dock = System.Windows.Forms.DockStyle.Bottom
		Me.txtXMLEdits.Location = New System.Drawing.Point(0, 245)
		Me.txtXMLEdits.Multiline = True
		Me.txtXMLEdits.Name = "txtXMLEdits"
		Me.txtXMLEdits.ScrollBars = System.Windows.Forms.ScrollBars.Both
		Me.txtXMLEdits.Size = New System.Drawing.Size(455, 224)
		Me.txtXMLEdits.TabIndex = 3
		Me.txtXMLEdits.Text = ""
		'
		'lblHowDoI
		'
		Me.lblHowDoI.BackColor = System.Drawing.SystemColors.ControlDark
		Me.lblHowDoI.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
		Me.lblHowDoI.Dock = System.Windows.Forms.DockStyle.Top
		Me.lblHowDoI.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.lblHowDoI.ForeColor = System.Drawing.SystemColors.ControlLight
		Me.lblHowDoI.Name = "lblHowDoI"
		Me.lblHowDoI.Size = New System.Drawing.Size(344, 32)
		Me.lblHowDoI.TabIndex = 8
		Me.lblHowDoI.Text = "How do I . . ."
		'
		'frmMain
		'
		Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
		Me.ClientSize = New System.Drawing.Size(802, 491)
		Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.pnlText, Me.splVert, Me.pnlLB, Me.sbInfo})
		Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
		Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
		Me.MaximizeBox = False
		Me.Menu = Me.mnuMain
		Me.Name = "frmMain"
		Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
		Me.Text = "Title Comes from Assembly Info"
		Me.pnlLB.ResumeLayout(False)
		Me.pnlText.ResumeLayout(False)
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
		Dim strPath As String

		' Find our where we're running from
		strPath = AppDomain.CurrentDomain.SetupInformation.ApplicationBase

		' Add path to file names
		mstrSimpleFile = strPath & "Simple.xml"
		mstrModifyFile = strPath & "New.XML"
		mstrBadFile = strPath & "Bad.xml"

		Dim blnFileNotFound As Boolean = False

		' Check to make sure files exists
		Dim strMsg As String = "The file '{0}' was not found. Please place it in the same directory as the application EXE and restart the application."

		' test to see if files exist
		If Not File.Exists(mstrSimpleFile) Then
			MessageBox.Show(String.Format(strMsg, mstrSimpleFile), Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
			blnFileNotFound = True
		End If
		If Not File.Exists(mstrModifyFile) Then
			MessageBox.Show(String.Format(strMsg, mstrModifyFile), Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
			blnFileNotFound = True
		End If
		If Not File.Exists(mstrBadFile) Then
			MessageBox.Show(String.Format(strMsg, mstrModifyFile), Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
			blnFileNotFound = True
		End If

		' Load the command text which are defined as constants in the 
		' module declaration section.
		With Me.lstCommands.Items
			.Add(CMD_LOAD_XML_FILE, False)
			.Add(CMD_LOAD_XML_STRING, False)
			.Add(CMD_TEST_FOR_CHILD_NODES, False)
			.Add(CMD_ITERATE_ALL_NODES, False)
			.Add(CMD_DETERMINE_NODE_TYPE, False)
			.Add(CMD_LIST_ALL_ELEMENT_NODES, False)
			.Add(CMD_LIST_ELEMENTS_BY_TAG, False)
			.Add(CMD_SELECT_NODES, False)
			.Add(CMD_SELECT_NODE, False)
			.Add(CMD_NAVIGATE_RELATED_NODES, False)
			.Add(CMD_RETRIEVE_ATTRIBUTES, False)
			.Add(CMD_CREATE_XML, False)
			.Add(CMD_ADD_OR_DELETE_ELEMENTS, False)
			.Add(CMD_MODIFY_ELEMENT, False)
			.Add(CMD_ADD_OR_DELETE_ATTRIBUTES, False)
			.Add(CMD_MODIFY_ATTRIBUTE, False)
			.Add(CMD_VALID_XML, False)
			.Add(CMD_PARSE_ERRORS, False)
		End With

		' Enable the listbox only if all 3 files were found.
		Me.lstCommands.Enabled = (Not blnFileNotFound)
	End Sub

	Private Sub lstCommands_ItemCheck(ByVal sender As System.Object, ByVal e As System.Windows.Forms.ItemCheckEventArgs) Handles lstCommands.ItemCheck
		' The check box next to a command has been
		' changed to checked, run the command.
		If e.NewValue = CheckState.Checked Then

			Me.txtXMLDisplay.Text = String.Empty
			Me.txtXMLEdits.Text = String.Empty

			' Reinitialize the StringWriter which is used
			' to build strings for display in the text boxes
			' on the form.
			msw = New StringWriter()

			Select Case Me.lstCommands.Items(e.Index).ToString()
				Case CMD_LOAD_XML_FILE
					Me.LoadAndDisplayXML()
				Case CMD_LOAD_XML_STRING
					Me.LoadXMLFromString()
				Case CMD_TEST_FOR_CHILD_NODES
					Me.HasAnyChildren()
				Case CMD_ITERATE_ALL_NODES
					Me.IterateThroughNodes()
				Case CMD_DETERMINE_NODE_TYPE
					Me.DetermineNodeType()
				Case CMD_LIST_ALL_ELEMENT_NODES
					Me.ListElementNodes()
				Case CMD_LIST_ELEMENTS_BY_TAG
					Me.ListSpecificTag()
				Case CMD_SELECT_NODES
					Me.CreateNodeList()
				Case CMD_SELECT_NODE
					Me.ReferToNode()
				Case CMD_NAVIGATE_RELATED_NODES
					Me.NavigateToNodes()
				Case CMD_RETRIEVE_ATTRIBUTES
					Me.RetrieveAttributes()
				Case CMD_CREATE_XML
					Me.CreateXML()
				Case CMD_ADD_OR_DELETE_ELEMENTS
					Me.AddDeleteNode()
				Case CMD_ADD_OR_DELETE_ATTRIBUTES
					Me.AddDeleteAttribute()
				Case CMD_MODIFY_ELEMENT
					Me.ModifyElementValue()
				Case CMD_MODIFY_ATTRIBUTE
					ModifyAttributeValue()
				Case CMD_VALID_XML
					Me.CheckIfXMLValid()
				Case CMD_PARSE_ERRORS
					Me.GetXMLErrorDetail()
			End Select

			' Update the status bar with the last run command
			Me.sbInfo.Text = "Last run command: " & Me.lstCommands.Items(e.Index).ToString()

			' Clean up the StringWriter
			msw.Flush()
			msw.Close()
		End If
	End Sub

	Private Sub mnuResetCheckBoxes_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuResetCheckBoxes.Click
		' Reset the check boxes that are checked to be 
		' not checked.
		If Me.lstCommands.CheckedItems.Count > 0 Then
			Me.txtXMLDisplay.Text = String.Empty
			Me.txtXMLEdits.Text = String.Empty

			Dim i As Integer
			Dim enumRef As IEnumerator

			enumRef = Me.lstCommands.CheckedIndices.GetEnumerator()

			While Not (enumRef.MoveNext() = False)
				i = CInt(enumRef.Current)
				Me.lstCommands.SetItemChecked(i, False)
			End While

		End If
	End Sub

	Private Sub AddDeleteNode()
		' This method will remove a node
		' and then add four new nodes.
		Dim xDoc As New XmlDocument()

		xDoc.Load(mstrModifyFile)

		Me.txtXMLDisplay.Text = xDoc.OuterXml

		Dim xNode As XmlNode
		Dim xElmntFamily As XmlElement
		' Search for a particular node
		xNode = xDoc.SelectSingleNode("//Family")

		If Not (xNode Is Nothing) Then
			If TypeOf xNode Is XmlElement Then
				xElmntFamily = CType(xNode, XmlElement)
			End If

			xElmntFamily.RemoveChild(xElmntFamily.SelectSingleNode("Father"))

			' Insert node for each family member:
			InsertTextNode(xDoc, xElmntFamily, "Person", "Gerald L. Smith")
			' Here's what InsertTextNode does:
			'Set xNode = xDoc.createElement("father")
			'xNode.appendChild xDoc.createTextNode("Gerald L. Smith")
			'xElmntFamily.appendChild xNode
			InsertTextNode(xDoc, xElmntFamily, "Person", "Sara Ann Smith")
			InsertTextNode(xDoc, xElmntFamily, "Person", "Richard Andrew Smith")
			InsertTextNode(xDoc, xElmntFamily, "Person", "Emily Jean Smith")

			xDoc.Save(mstrModifyFile)

			Me.txtXMLEdits.Text = xDoc.OuterXml
		Else
			Me.txtXMLEdits.Text = String.Format("Family Node was not found. Please try the '{0}' option first.", CMD_CREATE_XML)
		End If
	End Sub

	Private Sub AddDeleteAttribute()
		' This method will remove
		' all child nodes of the Family 
		' node and then re-add them with 
		' some attributes.
		' It also shows how to manipulate
		' existing attributes.
		Dim xDoc As New XmlDocument()

		xDoc.Load(mstrModifyFile)

		Me.txtXMLDisplay.Text = xDoc.OuterXml

		Dim xNode As XmlNode
		Dim xElem As XmlElement

		Dim xElmntFamily As XmlElement

		' Search for a particular node.
		xNode = xDoc.SelectSingleNode("//Family")

		If Not (xNode Is Nothing) Then
			If TypeOf xNode Is XmlElement Then
				xElmntFamily = CType(xNode, XmlElement)
			End If

			' Delete all the nodes created in the previous answer.
			For Each xNode In xElmntFamily
				xElmntFamily.RemoveChild(xNode)
			Next

			' Insert node for each family member:
			xElem = InsertTextNode(xDoc, xElmntFamily, "Person", "Gerald L. Smith")
			xElem.SetAttribute("type", "parent")
			xElem.SetAttribute("age", "70")

			xElem = InsertTextNode(xDoc, xElmntFamily, "Person", "Sara Ann Smith")
			xElem.SetAttribute("type", "mother")

			xElem = InsertTextNode(xDoc, xElmntFamily, "Person", "Richard Andrew Smith")
			xElem.SetAttribute("type", "son")

			xElem = InsertTextNode(xDoc, xElmntFamily, "Person", "Emily Jean Smith")
			xElem.SetAttribute("type", "daughter")

			' Attributes aren't quite right. Fix up father's.
			xNode = xDoc.SelectSingleNode("//Person[@type='parent']")
			If Not (xNode Is Nothing) Then
				' Remove "age" attribute, and change "type" attribute
				' to "father".
				xElem = CType(xNode, XmlElement)
				xElem.Attributes.RemoveNamedItem("age")
				xElem.SetAttribute("type", "father")
			End If

			xDoc.Save(mstrModifyFile)

			Me.txtXMLEdits.Text = xDoc.OuterXml
		Else
			Me.txtXMLEdits.Text = String.Format("Family Node was not found. Please try the '{0}' option first.", CMD_CREATE_XML)
		End If

	End Sub

	Private Sub CheckIfXMLValid()
		Dim xDoc As New XmlDocument()

		Try
			' If the XML file (or string for that matter)
			' is invalid, an exception of the type
			' XmlException will be thrown
			xDoc.Load(mstrBadFile)

			' You should not see this if using our 'bad' file.
			Me.txtXMLDisplay.Text = "Valid XML File: " & mstrBadFile

		Catch exp As XmlException
			Me.txtXMLDisplay.Text = "Invalid XML File: " & mstrBadFile
		Catch exp As Exception
			' Just in case
			MessageBox.Show(exp.Message, exp.Source, MessageBoxButtons.OK, MessageBoxIcon.Error)
		End Try
	End Sub

	Private Sub CreateNodeList()
		' intialize XML Document
		Me.LoadXMLFromFile()

		Dim xElem As XmlElement
		Dim strTag As String


		strTag = InputBox("Enter an XPath expression to find:", "Enter Search Expression", DEF_XPATH_EXP_FIND_NODES)

		If strTag.Length > 0 Then
			' Find a group of nodes based upon the enterd XPath expression.
			mxNodeList = mxDoc.SelectNodes(strTag)
			With msw
				.WriteLine("All text elements matching '{0}':", strTag)
				.WriteLine(mstrLine)

				If Not mxNodeList Is Nothing Then
					For Each xElem In mxNodeList
						.WriteLine("Name: " & xElem.Name)
						.WriteLine("InnerText: " & xElem.InnerText)
						.WriteLine("InnerXml: " & xElem.InnerXml)
					Next xElem
				End If

				Me.txtXMLDisplay.Text = .ToString()
			End With
		End If
	End Sub

	Private Sub CreateXML()
		' This method shows how to build
		' an XML file all from code.
		Dim xDoc As New XmlDocument()

		Dim xPI As XmlProcessingInstruction
		Dim xComment As XmlComment
		Dim xElmntRoot As XmlElement
		Dim xElmntFamily As XmlElement

		xPI = xDoc.CreateProcessingInstruction("xml", "version='1.0'")
		xDoc.AppendChild(xPI)

		xComment = xDoc.CreateComment("Family Information")
		xDoc.AppendChild(xComment)

		xElmntRoot = xDoc.CreateElement("xml")
		xDoc.AppendChild(xElmntRoot)

		' Rather than creating new nodes individually,
		' count on the fact that AppendChild returns a reference
		' to the newly added node.
		xElmntFamily = CType(xElmntRoot.AppendChild(xDoc.CreateElement("Family")), XmlElement)
		Call xElmntFamily.AppendChild(xDoc.CreateElement("Father"))

		' Obviously this could fail if we don't have permission.
		' Note that if the file exists, Save just overwrites.
		' You might want to check for its existance like this:

		'If File.Exists(mstrModifyFile) Then
		'	If MessageBox.Show(String.Format("Do you want to overwrite the file {0}?", mstrModifyFile), Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
		'		xDoc.Save(mstrModifyFile)
		'	End If
		'End If

		xDoc.Save(mstrModifyFile)

		' Note that the XML that is output is not 'pretty'.
		' The parser doesn't introduce whitespace like 
		' carriage returns, etc.
		Me.txtXMLDisplay.Text = xDoc.OuterXml
	End Sub

	Private Sub DetermineNodeType()
		' intialize XML Document
		Me.LoadXMLFromFile()

		' Use a recursive function to visit all nodes
		TraverseTreeType(msw, mxDoc, 0)

		Me.txtXMLDisplay.Text = msw.ToString
	End Sub

	Private Sub GetXMLErrorDetail()
		Dim xDoc As New XmlDocument()

		Try
			' If the XML file (or string for that matter)
			' is invalid, an exception of the type
			' XmlException will be thrown
			xDoc.Load(mstrBadFile)

			' You should not see this if using our 'bad' file.
			Me.txtXMLDisplay.Text = "Valid XML File: " & mstrBadFile

		Catch exp As XmlException
			With msw
				.WriteLine(exp.Message)
				' You can get these items individually.
				'.WriteLine(exp.LineNumber)
				'.WriteLine(exp.LinePosition)

				' Other items are buried in the args array
				' Take a look in break mode.

				Me.txtXMLDisplay.Text = .ToString
			End With
		Catch exp As Exception
			' Just in case
			MessageBox.Show(exp.Message, exp.Source, MessageBoxButtons.OK, MessageBoxIcon.Error)
		End Try

	End Sub

	Private Sub HasAnyChildren()
		' intialize XML Document
		Me.LoadXMLFromFile()

		Dim tab2x As String = vbTab & vbTab

		' If the document has children, 
		' look at them all.
		If mxDoc.HasChildNodes Then
			For Each mxNode In mxDoc.ChildNodes
				With msw
					.WriteLine(mstrLine)
					.WriteLine("Name: {0}{1}", tab2x, mxNode.Name)
					.WriteLine("Type: {0}{1}", tab2x, mxNode.NodeType)
					.WriteLine("Type (String): {0}{1}", vbTab, mxNode.NodeType.ToString())
					.WriteLine("Value: {0}{1}", tab2x, mxNode.Value)
					.WriteLine("Outer XML: {0}{1}", vbTab, mxNode.OuterXml)
				End With
			Next mxNode

			Me.txtXMLDisplay.Text = msw.ToString()
		End If
	End Sub

	Private Function InsertTextNode(ByVal xDoc As XmlDocument, ByVal xNode As XmlNode, ByVal strTag As String, ByVal strText As String) As XmlElement
		' Insert a text node as a child of xNode.
		' Set the tag to be strTag, and the
		' text to be strText. Return a pointer
		' to the new node.

		Dim xNodeTemp As XmlNode

		xNodeTemp = xDoc.CreateElement(strTag)
		xNodeTemp.AppendChild(xDoc.CreateTextNode(strText))
		xNode.AppendChild(xNodeTemp)

		Return CType(xNodeTemp, XmlElement)
	End Function

	Private Sub IterateThroughNodes()
		' intialize XML Document
		Me.LoadXMLFromFile()

		' Use a recursive function to visit all nodes
		TraverseTree(msw, mxDoc, 0)

		Me.txtXMLDisplay.Text = msw.ToString
	End Sub

	Private Sub ListElementNodes()
		' intialize XML Document
		Me.LoadXMLFromFile()

		' Search for elements by tag name.
		' This example is hard-coded to find ALL (*) elements
		mxNodeList = mxDoc.GetElementsByTagName("*")

		With msw
			.WriteLine("Elements matching '*':")
			.WriteLine(mstrLine)
			For Each mxNode In mxNodeList
				.WriteLine(mxNode.Name)
			Next mxNode

			Me.txtXMLDisplay.Text = .ToString()
		End With
	End Sub

	Private Sub ListSpecificTag()
		' intialize XML Document
		Me.LoadXMLFromFile()

		Dim strTag As String
		Dim xnt As XmlNode

		' This function allows you to search for specific elements by tag name.
		strTag = InputBox("Enter a Tag to find:", "Enter Tag", "*")
		If Len(strTag) > 0 Then
			mxNodeList = mxDoc.GetElementsByTagName(strTag)

			With msw
				.WriteLine("All text elements matching '{0}':", strTag)
				.WriteLine(mstrLine)

				For Each mxNode In mxNodeList
					For Each xnt In mxNode.ChildNodes
						If xnt.NodeType = XmlNodeType.Text Then
							.WriteLine(mxNode.Name & ": " & xnt.Value)
						End If
					Next xnt
				Next mxNode

				Me.txtXMLDisplay.Text = .ToString()
			End With
		End If
	End Sub

	Private Sub LoadXMLFromFile()
		' Defer to more complex version
		Me.LoadXMLFromFile(False)
	End Sub

	Private Sub LoadXMLFromFile(ByVal ForceReload As Boolean)
		' intialize XML Document
		' Only re-load if ForceReload is true or
		' the document is uninitialized.
		' OrElse performs short-circut evaluation
		' unlike Or which will execute both tests
		' even if ForceReload is True
		If ForceReload OrElse (mxDoc Is Nothing) Then
			mxDoc = New XmlDocument()
			mxDoc.Load(mstrSimpleFile)
		End If
	End Sub

	Private Sub LoadAndDisplayXML()
		Me.LoadXMLFromFile()

		Me.txtXMLDisplay.Text = mxDoc.OuterXml()
	End Sub

	Private Sub LoadXMLFromString()
		' Build an arbitrary string with XML Markup.
		' Note that the carriage returns are for humans.
		' The XML processor doesn't need them.
		' You can adjust whether or not the parser 'respects'
		' whitespace by adjusting the PreserveWhitespace
		' property of the XmlDocument class as shown below.

		' Use the StringWriter class
		With msw
			.WriteLine("<xml>")
			.WriteLine("<Family>")
			.WriteLine("    <Person type='father'>Gerald L. Smith</Person>")
			.WriteLine("    <Person type='mother'>Sara Ann Smith</Person>")
			.WriteLine("    <Person type='child' gender='male'>Richard Andrew Smith</Person>")
			.WriteLine("    <Person type='child' gender='female'>Emily Jean Smith</Person>")
			.WriteLine("</Family>")
			.WriteLine("</xml>")
		End With

		' intialize a new local XML Document instance
		Dim xDoc As New XmlDocument()
		' Tell the parser to leave CRLFs in the document.
		xDoc.PreserveWhitespace = True
		xDoc.LoadXml(msw.ToString())

		Me.txtXMLDisplay.Text = xDoc.OuterXml()

	End Sub

	Private Sub ModifyElementValue()
		' Shows how to modify an element's text value
		Dim xDoc As New XmlDocument()

		xDoc.Load(mstrModifyFile)

		Me.txtXMLDisplay.Text = xDoc.OuterXml

		Dim xNode As XmlNode
		Dim xElem As XmlElement

		Dim xElmntFamily As XmlElement
		xNode = xDoc.SelectSingleNode("//Person")

		If Not (xNode Is Nothing) Then
			xElem = CType(xNode, XmlElement)

			' Change "Gerald L. Smith" to "Jerry Smith"
			xElem.InnerText = "Jerry Smith"

			Me.txtXMLEdits.Text = xDoc.OuterXml
		Else
			Me.txtXMLEdits.Text = String.Format("Family Node was not found. Please try the '{0}' option first.", CMD_CREATE_XML)
		End If
	End Sub

	Private Sub ModifyAttributeValue()
		' Shows how to modify existing attribute values
		Dim xDoc As New XmlDocument()

		xDoc.Load(mstrModifyFile)

		Me.txtXMLDisplay.Text = xDoc.OuterXml

		Dim xNode As XmlNode
		Dim xElem As XmlElement

		For Each xNode In xDoc.SelectNodes("//Person")
			xElem = CType(xNode, XmlElement)

			Select Case xElem.GetAttribute("type")
				Case "father"
					xElem.SetAttribute("type", "parent")
					xElem.SetAttribute("gender", "male")
				Case "mother"
					xElem.SetAttribute("type", "parent")
					xElem.SetAttribute("gender", "female")
				Case "son"
					xElem.SetAttribute("type", "child")
					xElem.SetAttribute("gender", "male")
				Case "daughter"
					xElem.SetAttribute("type", "child")
					xElem.SetAttribute("gender", "female")
			End Select
		Next

		Me.txtXMLEdits.Text = xDoc.OuterXml
	End Sub

	Private Sub NavigateToNodes()
		' intialize XML Document
		Me.LoadXMLFromFile()

		Dim xElem As XmlElement
		Dim xnodTemp As XmlNode

		' Print out the name of each new item:
		mxNodeList = mxDoc.SelectNodes("//New")

		If Not (mxNodeList Is Nothing) Then
			With msw
				.WriteLine("All New Items:")
				.WriteLine(mstrLine)
				For Each mxNode In mxNodeList
					xnodTemp = mxNode.ParentNode.SelectSingleNode("Name")
					If Not (xnodTemp Is Nothing) Then
						If TypeOf xnodTemp Is XmlElement Then
							xElem = CType(xnodTemp, XmlElement)
							.WriteLine(xElem.InnerText)
						End If
					End If
				Next mxNode


				Me.txtXMLDisplay.Text = .ToString()
			End With
		End If
	End Sub

	Private Sub ReferToNode()
		' intialize XML Document
		Me.LoadXMLFromFile()

		Dim xElem As XmlElement

		Dim strTag As String

		strTag = InputBox("Enter an XPath expression to find:", "Enter Search Expression", DEF_XPATH_EXP_FIND_NODE)
		If strTag.Length > 0 Then
			With msw
				.WriteLine("All elements matching '{0}':", strTag)
				.WriteLine(mstrLine)

				mxNode = mxDoc.SelectSingleNode(strTag)
				If Not (mxNode Is Nothing) Then
					If TypeOf mxNode Is XmlElement Then
						xElem = CType(mxNode, XmlElement)
						.WriteLine(xElem.InnerText)
					End If
				End If

				Me.txtXMLDisplay.Text = .ToString()
			End With
		End If
	End Sub

	Private Sub RetrieveAttributes()
		' intialize XML Document
		Me.LoadXMLFromFile()

		Dim xAttr As XmlAttribute
		Dim xTmpNode As XmlNode

		With msw
			mxNodeList = mxDoc.SelectNodes("//Item")

			If Not (mxNodeList Is Nothing) Then
				.WriteLine("All Item Attributes:")
				.WriteLine(mstrLine)

				For Each mxNode In mxNodeList
					.WriteLine("{0} ({1})", mxNode.Name, mxNode.InnerText)
					For Each xAttr In mxNode.Attributes
						.WriteLine("   {0}: {1}", xAttr.Name, xAttr.Value)
					Next
				Next
			End If

			.WriteLine()
			.WriteLine()

			mxNodeList = mxDoc.SelectNodes("//Department")

			If Not (mxNodeList Is Nothing) Then
				.WriteLine("Departments:")
				.WriteLine(mstrLine)

				For Each mxNode In mxNodeList
					xTmpNode = mxNode.Attributes.GetNamedItem("Name")
					If Not (xTmpNode Is Nothing) Then
						xAttr = CType(xTmpNode, XmlAttribute)
						.WriteLine(xAttr.Value)
					End If
				Next
			End If

			Me.txtXMLDisplay.Text = .ToString()
		End With
	End Sub

	Private Sub TraverseTree(ByVal sw As StringWriter, ByVal xNode As XmlNode, ByVal intLevel As Integer)
		Dim xNodeLoop As XmlNode

		' Print out the node name for the
		' current node.
		Dim s As New String(System.Convert.ToChar(vbTab), intLevel)
		sw.WriteLine(s & xNode.Name)

		' If the current node has children, call this
		' same procedure, passing in that node. Increase
		' the lngLevel value, so the output can be indented.
		If xNode.HasChildNodes Then
			For Each xNodeLoop In xNode.ChildNodes
				Call TraverseTree(sw, xNodeLoop, intLevel + 1)
			Next xNodeLoop
		End If
	End Sub

	Private Sub TraverseTreeType(ByVal sw As StringWriter, ByVal xNode As XmlNode, ByVal intLevel As Integer)
		Dim xNodeLoop As XmlNode

		' Print out the node name for the
		' current node.
		Dim s As New String(System.Convert.ToChar(vbTab), intLevel)
		Dim strValues() As String = {s, xNode.Name, xNode.NodeType.ToString()}
		sw.WriteLine("{0}{1} ({2})", strValues)

		' If the current node has children, call this
		' same procedure, passing in that node. Increase
		' the lngLevel value, so the output can be indented.
		If xNode.HasChildNodes Then
			For Each xNodeLoop In xNode.ChildNodes
				Call TraverseTreeType(sw, xNodeLoop, intLevel + 1)
			Next xNodeLoop
		End If
	End Sub


End Class