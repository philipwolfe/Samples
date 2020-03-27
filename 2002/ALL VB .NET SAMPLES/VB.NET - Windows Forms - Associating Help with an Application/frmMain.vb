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
    Friend WithEvents tcMain As System.Windows.Forms.TabControl
    Friend WithEvents tpToolTip As System.Windows.Forms.TabPage
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtProductName As System.Windows.Forms.TextBox
    Friend WithEvents txtPrice As System.Windows.Forms.TextBox
    Friend WithEvents btnExecute As System.Windows.Forms.Button
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents tpPopUpHelp As System.Windows.Forms.TabPage
    Friend WithEvents btnSave As System.Windows.Forms.Button
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents btnClear As System.Windows.Forms.Button
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents tpHTMLHelp As System.Windows.Forms.TabPage
    Friend WithEvents mnuContentsHelp As System.Windows.Forms.MenuItem
    Friend WithEvents mnuIndexHelp As System.Windows.Forms.MenuItem
    Friend WithEvents mnuSearchHelp As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem4 As System.Windows.Forms.MenuItem
    Friend WithEvents tpErrorHelp As System.Windows.Forms.TabPage
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txtNumberValue As System.Windows.Forms.TextBox
    Friend WithEvents btnSubmit As System.Windows.Forms.Button
    Friend WithEvents txtTextValue As System.Windows.Forms.TextBox
    Friend WithEvents ErrorProvider1 As System.Windows.Forms.ErrorProvider
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents btnLink2 As System.Windows.Forms.Button
    Friend WithEvents btnLink1 As System.Windows.Forms.Button
    Friend WithEvents hpAdvancedCHM As System.Windows.Forms.HelpProvider
    Friend WithEvents btnLink3 As System.Windows.Forms.Button
    Friend WithEvents hpPlainHTML As System.Windows.Forms.HelpProvider
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents rtbTextEntry As System.Windows.Forms.RichTextBox
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmMain))
        Me.mnuMain = New System.Windows.Forms.MainMenu()
        Me.mnuFile = New System.Windows.Forms.MenuItem()
        Me.mnuExit = New System.Windows.Forms.MenuItem()
        Me.mnuHelp = New System.Windows.Forms.MenuItem()
        Me.mnuContentsHelp = New System.Windows.Forms.MenuItem()
        Me.mnuIndexHelp = New System.Windows.Forms.MenuItem()
        Me.mnuSearchHelp = New System.Windows.Forms.MenuItem()
        Me.MenuItem4 = New System.Windows.Forms.MenuItem()
        Me.mnuAbout = New System.Windows.Forms.MenuItem()
        Me.tcMain = New System.Windows.Forms.TabControl()
        Me.tpToolTip = New System.Windows.Forms.TabPage()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.btnExecute = New System.Windows.Forms.Button()
        Me.txtPrice = New System.Windows.Forms.TextBox()
        Me.txtProductName = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.tpPopUpHelp = New System.Windows.Forms.TabPage()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.btnClear = New System.Windows.Forms.Button()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.btnSave = New System.Windows.Forms.Button()
        Me.rtbTextEntry = New System.Windows.Forms.RichTextBox()
        Me.tpHTMLHelp = New System.Windows.Forms.TabPage()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.btnLink3 = New System.Windows.Forms.Button()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.btnLink2 = New System.Windows.Forms.Button()
        Me.btnLink1 = New System.Windows.Forms.Button()
        Me.tpErrorHelp = New System.Windows.Forms.TabPage()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtNumberValue = New System.Windows.Forms.TextBox()
        Me.btnSubmit = New System.Windows.Forms.Button()
        Me.txtTextValue = New System.Windows.Forms.TextBox()
        Me.hpAdvancedCHM = New System.Windows.Forms.HelpProvider()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.ErrorProvider1 = New System.Windows.Forms.ErrorProvider()
        Me.hpPlainHTML = New System.Windows.Forms.HelpProvider()
        Me.tcMain.SuspendLayout()
        Me.tpToolTip.SuspendLayout()
        Me.tpPopUpHelp.SuspendLayout()
        Me.tpHTMLHelp.SuspendLayout()
        Me.tpErrorHelp.SuspendLayout()
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
        Me.mnuHelp.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.mnuContentsHelp, Me.mnuIndexHelp, Me.mnuSearchHelp, Me.MenuItem4, Me.mnuAbout})
        Me.mnuHelp.Text = "&Help"
        '
        'mnuContentsHelp
        '
        Me.mnuContentsHelp.Index = 0
        Me.mnuContentsHelp.Text = "Contents..."
        '
        'mnuIndexHelp
        '
        Me.mnuIndexHelp.Index = 1
        Me.mnuIndexHelp.Text = "Index..."
        '
        'mnuSearchHelp
        '
        Me.mnuSearchHelp.Index = 2
        Me.mnuSearchHelp.Text = "Search..."
        '
        'MenuItem4
        '
        Me.MenuItem4.Index = 3
        Me.MenuItem4.Text = "-"
        '
        'mnuAbout
        '
        Me.mnuAbout.Index = 4
        Me.mnuAbout.Text = "Text Comes from AssemblyInfo"
        '
        'tcMain
        '
        Me.tcMain.AccessibleDescription = "Tab Control"
        Me.tcMain.AccessibleName = "Tab Control"
        Me.tcMain.Controls.AddRange(New System.Windows.Forms.Control() {Me.tpToolTip, Me.tpPopUpHelp, Me.tpHTMLHelp, Me.tpErrorHelp})
        Me.tcMain.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tcMain.ItemSize = New System.Drawing.Size(76, 18)
        Me.tcMain.Name = "tcMain"
        Me.tcMain.SelectedIndex = 0
        Me.hpAdvancedCHM.SetShowHelp(Me.tcMain, False)
        Me.hpPlainHTML.SetShowHelp(Me.tcMain, False)
        Me.tcMain.ShowToolTips = True
        Me.tcMain.Size = New System.Drawing.Size(418, 267)
        Me.tcMain.TabIndex = 0
        '
        'tpToolTip
        '
        Me.tpToolTip.AccessibleDescription = "Tab Page Tool Tip"
        Me.tpToolTip.AccessibleName = "Tab Page Tool Tip"
        Me.tpToolTip.Controls.AddRange(New System.Windows.Forms.Control() {Me.Label3, Me.Label2, Me.btnExecute, Me.txtPrice, Me.txtProductName, Me.Label1})
        Me.tpToolTip.Location = New System.Drawing.Point(4, 22)
        Me.tpToolTip.Name = "tpToolTip"
        Me.hpAdvancedCHM.SetShowHelp(Me.tpToolTip, False)
        Me.hpPlainHTML.SetShowHelp(Me.tpToolTip, False)
        Me.tpToolTip.Size = New System.Drawing.Size(410, 241)
        Me.tpToolTip.TabIndex = 0
        Me.tpToolTip.Text = "Tool Tip Help"
        Me.tpToolTip.ToolTipText = "Tab One"
        '
        'Label3
        '
        Me.Label3.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label3.Location = New System.Drawing.Point(216, 80)
        Me.Label3.Name = "Label3"
        Me.hpPlainHTML.SetShowHelp(Me.Label3, False)
        Me.hpAdvancedCHM.SetShowHelp(Me.Label3, False)
        Me.Label3.Size = New System.Drawing.Size(64, 16)
        Me.Label3.TabIndex = 5
        Me.Label3.Text = "Price"
        '
        'Label2
        '
        Me.Label2.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label2.Location = New System.Drawing.Point(24, 80)
        Me.Label2.Name = "Label2"
        Me.hpPlainHTML.SetShowHelp(Me.Label2, False)
        Me.hpAdvancedCHM.SetShowHelp(Me.Label2, False)
        Me.Label2.Size = New System.Drawing.Size(168, 16)
        Me.Label2.TabIndex = 4
        Me.Label2.Text = "Product Name"
        '
        'btnExecute
        '
        Me.btnExecute.AccessibleDescription = "Execute button"
        Me.btnExecute.AccessibleName = "Execute button"
        Me.btnExecute.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btnExecute.Location = New System.Drawing.Point(24, 120)
        Me.btnExecute.Name = "btnExecute"
        Me.hpPlainHTML.SetShowHelp(Me.btnExecute, False)
        Me.hpAdvancedCHM.SetShowHelp(Me.btnExecute, False)
        Me.btnExecute.TabIndex = 3
        Me.btnExecute.Text = "Execute"
        Me.ToolTip1.SetToolTip(Me.btnExecute, "Execute the Query")
        '
        'txtPrice
        '
        Me.txtPrice.AccessibleDescription = "Product Price"
        Me.txtPrice.AccessibleName = "Product Price"
        Me.txtPrice.Location = New System.Drawing.Point(216, 96)
        Me.txtPrice.Name = "txtPrice"
        Me.hpAdvancedCHM.SetShowHelp(Me.txtPrice, False)
        Me.hpPlainHTML.SetShowHelp(Me.txtPrice, False)
        Me.txtPrice.Size = New System.Drawing.Size(72, 20)
        Me.txtPrice.TabIndex = 2
        Me.txtPrice.Text = ""
        Me.ToolTip1.SetToolTip(Me.txtPrice, "Enter a price.")
        '
        'txtProductName
        '
        Me.txtProductName.AccessibleDescription = "Product Name"
        Me.txtProductName.AccessibleName = "Product Name"
        Me.txtProductName.Location = New System.Drawing.Point(24, 96)
        Me.txtProductName.Name = "txtProductName"
        Me.hpAdvancedCHM.SetShowHelp(Me.txtProductName, False)
        Me.hpPlainHTML.SetShowHelp(Me.txtProductName, False)
        Me.txtProductName.Size = New System.Drawing.Size(184, 20)
        Me.txtProductName.TabIndex = 1
        Me.txtProductName.Text = ""
        Me.ToolTip1.SetToolTip(Me.txtProductName, "Enter a product name.")
        '
        'Label1
        '
        Me.Label1.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label1.Location = New System.Drawing.Point(16, 16)
        Me.Label1.Name = "Label1"
        Me.hpPlainHTML.SetShowHelp(Me.Label1, False)
        Me.hpAdvancedCHM.SetShowHelp(Me.Label1, False)
        Me.Label1.Size = New System.Drawing.Size(376, 56)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Hover your mouse pointer over the controls to display the tool tip.  The ToolTip " & _
        "control is being used to do this. This control gives every control on the form a" & _
        " new property called tooltip on tooltip1.  This is where the tool tip message is" & _
        " entered."
        '
        'tpPopUpHelp
        '
        Me.tpPopUpHelp.Controls.AddRange(New System.Windows.Forms.Control() {Me.Label5, Me.btnClear, Me.Label4, Me.btnSave, Me.rtbTextEntry})
        Me.tpPopUpHelp.Location = New System.Drawing.Point(4, 22)
        Me.tpPopUpHelp.Name = "tpPopUpHelp"
        Me.hpAdvancedCHM.SetShowHelp(Me.tpPopUpHelp, False)
        Me.hpPlainHTML.SetShowHelp(Me.tpPopUpHelp, False)
        Me.tpPopUpHelp.Size = New System.Drawing.Size(410, 241)
        Me.tpPopUpHelp.TabIndex = 1
        Me.tpPopUpHelp.Text = "PopUp Help"
        '
        'Label5
        '
        Me.Label5.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label5.Location = New System.Drawing.Point(16, 88)
        Me.Label5.Name = "Label5"
        Me.hpPlainHTML.SetShowHelp(Me.Label5, False)
        Me.hpAdvancedCHM.SetShowHelp(Me.Label5, False)
        Me.Label5.Size = New System.Drawing.Size(100, 16)
        Me.Label5.TabIndex = 4
        Me.Label5.Text = "Text Entry"
        '
        'btnClear
        '
        Me.btnClear.AccessibleDescription = "Clear button"
        Me.btnClear.AccessibleName = "Clear button"
        Me.hpAdvancedCHM.SetHelpString(Me.btnClear, "This is the clear text area button. Press this button to clear the text area.")
        Me.btnClear.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btnClear.Location = New System.Drawing.Point(96, 208)
        Me.btnClear.Name = "btnClear"
        Me.hpPlainHTML.SetShowHelp(Me.btnClear, False)
        Me.hpAdvancedCHM.SetShowHelp(Me.btnClear, True)
        Me.btnClear.TabIndex = 3
        Me.btnClear.Text = "Clear"
        '
        'Label4
        '
        Me.Label4.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label4.Location = New System.Drawing.Point(16, 16)
        Me.Label4.Name = "Label4"
        Me.hpPlainHTML.SetShowHelp(Me.Label4, False)
        Me.hpAdvancedCHM.SetShowHelp(Me.Label4, False)
        Me.Label4.Size = New System.Drawing.Size(384, 72)
        Me.Label4.TabIndex = 2
        Me.Label4.Text = "Left click the question mark icon on the top right of the form and then left clic" & _
        "k one of the controls to view the pop up help.  The helpprovider is being used t" & _
        "o provide the pop up help for the controls.  The help provider control adds a ne" & _
        "w property to each control called HelpString on HelpProvider1.  The text for the" & _
        " popup message is entered for this property."
        '
        'btnSave
        '
        Me.btnSave.AccessibleDescription = "Save Button"
        Me.btnSave.AccessibleName = "Save Button"
        Me.hpAdvancedCHM.SetHelpString(Me.btnSave, "This is the save button.  Press this button to save the text in a rtf file.")
        Me.btnSave.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btnSave.Location = New System.Drawing.Point(16, 208)
        Me.btnSave.Name = "btnSave"
        Me.hpPlainHTML.SetShowHelp(Me.btnSave, False)
        Me.hpAdvancedCHM.SetShowHelp(Me.btnSave, True)
        Me.btnSave.TabIndex = 1
        Me.btnSave.Text = "Save"
        '
        'rtbTextEntry
        '
        Me.rtbTextEntry.AccessibleDescription = "Test Text Entry form"
        Me.rtbTextEntry.AccessibleName = "Test Text Entry form"
        Me.hpAdvancedCHM.SetHelpString(Me.rtbTextEntry, "This is the text entry area.  Use this area to enter text which can be saved to a" & _
        "n rtf file.")
        Me.rtbTextEntry.Location = New System.Drawing.Point(16, 104)
        Me.rtbTextEntry.Name = "rtbTextEntry"
        Me.hpAdvancedCHM.SetShowHelp(Me.rtbTextEntry, True)
        Me.hpPlainHTML.SetShowHelp(Me.rtbTextEntry, False)
        Me.rtbTextEntry.Size = New System.Drawing.Size(376, 96)
        Me.rtbTextEntry.TabIndex = 0
        Me.rtbTextEntry.Text = ""
        '
        'tpHTMLHelp
        '
        Me.tpHTMLHelp.Controls.AddRange(New System.Windows.Forms.Control() {Me.Label10, Me.btnLink3, Me.Label9, Me.btnLink2, Me.btnLink1})
        Me.tpHTMLHelp.Location = New System.Drawing.Point(4, 22)
        Me.tpHTMLHelp.Name = "tpHTMLHelp"
        Me.hpAdvancedCHM.SetShowHelp(Me.tpHTMLHelp, False)
        Me.hpPlainHTML.SetShowHelp(Me.tpHTMLHelp, False)
        Me.tpHTMLHelp.Size = New System.Drawing.Size(410, 241)
        Me.tpHTMLHelp.TabIndex = 2
        Me.tpHTMLHelp.Text = "HTML Help"
        '
        'Label10
        '
        Me.Label10.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label10.Location = New System.Drawing.Point(16, 120)
        Me.Label10.Name = "Label10"
        Me.hpPlainHTML.SetShowHelp(Me.Label10, False)
        Me.hpAdvancedCHM.SetShowHelp(Me.Label10, False)
        Me.Label10.Size = New System.Drawing.Size(376, 40)
        Me.Label10.TabIndex = 5
        Me.Label10.Text = "Left clicking the button below with the question mark will bring up a basic HTML " & _
        "page that could have information about this control and how it is used."
        '
        'btnLink3
        '
        Me.btnLink3.AccessibleDescription = "Link to basic HTML help file"
        Me.btnLink3.AccessibleName = "Link to basic HTML help file"
        Me.hpPlainHTML.SetHelpKeyword(Me.btnLink3, "help.htm")
        Me.btnLink3.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btnLink3.Location = New System.Drawing.Point(16, 168)
        Me.btnLink3.Name = "btnLink3"
        Me.hpPlainHTML.SetShowHelp(Me.btnLink3, True)
        Me.hpAdvancedCHM.SetShowHelp(Me.btnLink3, False)
        Me.btnLink3.Size = New System.Drawing.Size(376, 23)
        Me.btnLink3.TabIndex = 4
        Me.btnLink3.Text = "Link to Basic &HTML help file"
        '
        'Label9
        '
        Me.Label9.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label9.Location = New System.Drawing.Point(16, 16)
        Me.Label9.Name = "Label9"
        Me.hpPlainHTML.SetShowHelp(Me.Label9, False)
        Me.hpAdvancedCHM.SetShowHelp(Me.Label9, False)
        Me.Label9.Size = New System.Drawing.Size(376, 40)
        Me.Label9.TabIndex = 2
        Me.Label9.Text = "Left click the question mark on the top right of the window then left click one o" & _
        "f the buttons to just to a help topic in the help file."
        '
        'btnLink2
        '
        Me.btnLink2.AccessibleDescription = "Link to compiling keyword indexes"
        Me.btnLink2.AccessibleName = "Link to compiling keyword indexes"
        Me.hpAdvancedCHM.SetHelpKeyword(Me.btnLink2, "compiling keyword indexes")
        Me.hpAdvancedCHM.SetHelpNavigator(Me.btnLink2, System.Windows.Forms.HelpNavigator.KeywordIndex)
        Me.btnLink2.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btnLink2.Location = New System.Drawing.Point(16, 88)
        Me.btnLink2.Name = "btnLink2"
        Me.hpPlainHTML.SetShowHelp(Me.btnLink2, False)
        Me.hpAdvancedCHM.SetShowHelp(Me.btnLink2, True)
        Me.btnLink2.Size = New System.Drawing.Size(376, 23)
        Me.btnLink2.TabIndex = 1
        Me.btnLink2.Text = "Link To ""&compiling keyword indexes"""
        '
        'btnLink1
        '
        Me.btnLink1.AccessibleDescription = "Link to Compiling a help project"
        Me.btnLink1.AccessibleName = "Link to Compiling a help project"
        Me.hpAdvancedCHM.SetHelpKeyword(Me.btnLink1, "about compiling a help project")
        Me.hpAdvancedCHM.SetHelpNavigator(Me.btnLink1, System.Windows.Forms.HelpNavigator.KeywordIndex)
        Me.btnLink1.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btnLink1.Location = New System.Drawing.Point(16, 56)
        Me.btnLink1.Name = "btnLink1"
        Me.hpPlainHTML.SetShowHelp(Me.btnLink1, False)
        Me.hpAdvancedCHM.SetShowHelp(Me.btnLink1, True)
        Me.btnLink1.Size = New System.Drawing.Size(376, 24)
        Me.btnLink1.TabIndex = 0
        Me.btnLink1.Text = "Link To ""&about compiling a help project"""
        '
        'tpErrorHelp
        '
        Me.tpErrorHelp.Controls.AddRange(New System.Windows.Forms.Control() {Me.Label8, Me.Label7, Me.Label6, Me.txtNumberValue, Me.btnSubmit, Me.txtTextValue})
        Me.tpErrorHelp.Location = New System.Drawing.Point(4, 22)
        Me.tpErrorHelp.Name = "tpErrorHelp"
        Me.hpAdvancedCHM.SetShowHelp(Me.tpErrorHelp, False)
        Me.hpPlainHTML.SetShowHelp(Me.tpErrorHelp, False)
        Me.tpErrorHelp.Size = New System.Drawing.Size(410, 241)
        Me.tpErrorHelp.TabIndex = 3
        Me.tpErrorHelp.Text = "Error Help"
        '
        'Label8
        '
        Me.Label8.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label8.Location = New System.Drawing.Point(16, 16)
        Me.Label8.Name = "Label8"
        Me.hpPlainHTML.SetShowHelp(Me.Label8, False)
        Me.hpAdvancedCHM.SetShowHelp(Me.Label8, False)
        Me.Label8.Size = New System.Drawing.Size(368, 56)
        Me.Label8.TabIndex = 1
        Me.Label8.Text = "Enter a non numeric value in the number here box and then click on the other text" & _
        " box.  A red icon will appear next to the number here box indicating an error.  " & _
        "Hover over the icon for a pop up message of the error."
        '
        'Label7
        '
        Me.Label7.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label7.Location = New System.Drawing.Point(16, 120)
        Me.Label7.Name = "Label7"
        Me.hpPlainHTML.SetShowHelp(Me.Label7, False)
        Me.hpAdvancedCHM.SetShowHelp(Me.Label7, False)
        Me.Label7.Size = New System.Drawing.Size(72, 16)
        Me.Label7.TabIndex = 4
        Me.Label7.Text = "Number here"
        '
        'Label6
        '
        Me.Label6.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label6.Location = New System.Drawing.Point(16, 80)
        Me.Label6.Name = "Label6"
        Me.hpPlainHTML.SetShowHelp(Me.Label6, False)
        Me.hpAdvancedCHM.SetShowHelp(Me.Label6, False)
        Me.Label6.Size = New System.Drawing.Size(56, 16)
        Me.Label6.TabIndex = 2
        Me.Label6.Text = "Text here"
        '
        'txtNumberValue
        '
        Me.txtNumberValue.AccessibleDescription = "Number Input"
        Me.txtNumberValue.AccessibleName = "Number Input"
        Me.txtNumberValue.Location = New System.Drawing.Point(16, 136)
        Me.txtNumberValue.Name = "txtNumberValue"
        Me.hpAdvancedCHM.SetShowHelp(Me.txtNumberValue, False)
        Me.hpPlainHTML.SetShowHelp(Me.txtNumberValue, False)
        Me.txtNumberValue.Size = New System.Drawing.Size(64, 20)
        Me.txtNumberValue.TabIndex = 5
        Me.txtNumberValue.Text = ""
        '
        'btnSubmit
        '
        Me.btnSubmit.AccessibleDescription = "Submit Button for Form"
        Me.btnSubmit.AccessibleName = "Submit Button"
        Me.btnSubmit.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btnSubmit.Location = New System.Drawing.Point(16, 160)
        Me.btnSubmit.Name = "btnSubmit"
        Me.hpPlainHTML.SetShowHelp(Me.btnSubmit, False)
        Me.hpAdvancedCHM.SetShowHelp(Me.btnSubmit, False)
        Me.btnSubmit.TabIndex = 5
        Me.btnSubmit.Text = "&Submit"
        '
        'txtTextValue
        '
        Me.txtTextValue.AccessibleDescription = "Text Input"
        Me.txtTextValue.AccessibleName = "Text Input"
        Me.txtTextValue.Location = New System.Drawing.Point(16, 96)
        Me.txtTextValue.Name = "txtTextValue"
        Me.hpAdvancedCHM.SetShowHelp(Me.txtTextValue, False)
        Me.hpPlainHTML.SetShowHelp(Me.txtTextValue, False)
        Me.txtTextValue.Size = New System.Drawing.Size(160, 20)
        Me.txtTextValue.TabIndex = 3
        Me.txtTextValue.Text = ""
        '
        'hpAdvancedCHM
        '
        Me.hpAdvancedCHM.HelpNamespace = "..\htmlhelp.chm"
        '
        'ErrorProvider1
        '
        Me.ErrorProvider1.Icon = CType(resources.GetObject("ErrorProvider1.Icon"), System.Drawing.Icon)
        '
        'hpPlainHTML
        '
        Me.hpPlainHTML.HelpNamespace = "..\help.htm"
        '
        'frmMain
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(418, 267)
        Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.tcMain})
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.HelpButton = True
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Menu = Me.mnuMain
        Me.MinimizeBox = False
        Me.Name = "frmMain"
        Me.hpAdvancedCHM.SetShowHelp(Me, False)
        Me.hpPlainHTML.SetShowHelp(Me, False)
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Title Comes from Assembly Info"
        Me.tcMain.ResumeLayout(False)
        Me.tpToolTip.ResumeLayout(False)
        Me.tpPopUpHelp.ResumeLayout(False)
        Me.tpHTMLHelp.ResumeLayout(False)
        Me.tpErrorHelp.ResumeLayout(False)
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

    Private Sub mnuContentsHelp_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuContentsHelp.Click
        ' Show the contents of the help file.
        Help.ShowHelp(Me, hpAdvancedCHM.HelpNamespace)
    End Sub

    Private Sub mnuIndexHelp_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuIndexHelp.Click
        ' Show index of the help file.
        Help.ShowHelpIndex(Me, hpAdvancedCHM.HelpNamespace)
    End Sub

    Private Sub mnuSearchHelp_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuSearchHelp.Click
        ' Show the search tab of the help file.
        Help.ShowHelp(Me, hpAdvancedCHM.HelpNamespace, HelpNavigator.Find, "")
    End Sub

    Private Sub txtNumberValue_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtNumberValue.Validating
        If Not IsNumeric(txtNumberValue.Text) Then
            ' Activate the error provider to notify the user of a
            ' problem.
            ErrorProvider1.SetError(txtNumberValue, "Not a numeric value.")
        Else
            ' Clear the Error
            ErrorProvider1.SetError(txtNumberValue, "")
        End If
    End Sub

End Class