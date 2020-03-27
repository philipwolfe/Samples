'Copyright (C) 2002 Microsoft Corporation
'All rights reserved.
'THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, EITHER 
'EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED WARRANTIES OF 
'MERCHANTIBILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.

'Requires the Trial or Release version of Visual Studio .NET Professional (or greater).

Option Strict On
Imports System.Text
Imports System.IO

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
    Friend WithEvents optInsert As System.Windows.Forms.RadioButton
    Friend WithEvents optRemove As System.Windows.Forms.RadioButton
    Friend WithEvents optReplace As System.Windows.Forms.RadioButton
    Friend WithEvents optSubstring As System.Windows.Forms.RadioButton
    Friend WithEvents optPadRight As System.Windows.Forms.RadioButton
    Friend WithEvents optPadLeft As System.Windows.Forms.RadioButton
    Friend WithEvents optTrim As System.Windows.Forms.RadioButton
    Friend WithEvents optToUpper As System.Windows.Forms.RadioButton
    Friend WithEvents optToLower As System.Windows.Forms.RadioButton
    Friend WithEvents optTrimStart As System.Windows.Forms.RadioButton
    Friend WithEvents optTrimEnd As System.Windows.Forms.RadioButton
    Friend WithEvents lblPrm1 As System.Windows.Forms.Label
    Friend WithEvents lblPrm2 As System.Windows.Forms.Label
    Friend WithEvents lblPrm3 As System.Windows.Forms.Label
    Friend WithEvents txtPrm1 As System.Windows.Forms.TextBox
    Friend WithEvents txtPrm2 As System.Windows.Forms.TextBox
    Friend WithEvents txtPrm3 As System.Windows.Forms.TextBox
    Friend WithEvents txtSample As System.Windows.Forms.TextBox
    Friend WithEvents lblResultsLabel As System.Windows.Forms.Label
    Friend WithEvents lblResults As System.Windows.Forms.Label
    Friend WithEvents btnRecalc As System.Windows.Forms.Button
    Friend WithEvents btnRefresh As System.Windows.Forms.Button
    Friend WithEvents ttpStrings As System.Windows.Forms.ToolTip
    Friend WithEvents pnlDemo As System.Windows.Forms.Panel
    Friend WithEvents tabStringDemo As System.Windows.Forms.TabControl
    Friend WithEvents pagReturnStrings As System.Windows.Forms.TabPage
    Friend WithEvents pagInfo As System.Windows.Forms.TabPage
    Friend WithEvents optEndsWith As System.Windows.Forms.RadioButton
    Friend WithEvents optStartsWith As System.Windows.Forms.RadioButton
    Friend WithEvents optLastIndexOfAny As System.Windows.Forms.RadioButton
    Friend WithEvents optIndexOfAny As System.Windows.Forms.RadioButton
    Friend WithEvents optIndexOf As System.Windows.Forms.RadioButton
    Friend WithEvents optLastIndexOf As System.Windows.Forms.RadioButton
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents pagShared As System.Windows.Forms.TabPage
    Friend WithEvents optFormat As System.Windows.Forms.RadioButton
    Friend WithEvents optConcat As System.Windows.Forms.RadioButton
    Friend WithEvents optCompareOrdinal As System.Windows.Forms.RadioButton
    Friend WithEvents optCompare As System.Windows.Forms.RadioButton
    Friend WithEvents optJoin As System.Windows.Forms.RadioButton
    Friend WithEvents grpResults As System.Windows.Forms.GroupBox
    Friend WithEvents grpParameters As System.Windows.Forms.GroupBox
    Friend WithEvents grpSample As System.Windows.Forms.GroupBox
    Friend WithEvents optSplit As System.Windows.Forms.RadioButton
    Friend WithEvents btnStringWriter As System.Windows.Forms.Button
    Friend WithEvents btnStringBuilder As System.Windows.Forms.Button
    Friend WithEvents pagOther As System.Windows.Forms.TabPage
    Friend WithEvents txtResults As System.Windows.Forms.TextBox
    Friend WithEvents chkDebug As System.Windows.Forms.CheckBox
    Friend WithEvents btnClear As System.Windows.Forms.Button
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmMain))
        Me.mnuMain = New System.Windows.Forms.MainMenu()
        Me.mnuFile = New System.Windows.Forms.MenuItem()
        Me.mnuExit = New System.Windows.Forms.MenuItem()
        Me.mnuHelp = New System.Windows.Forms.MenuItem()
        Me.mnuAbout = New System.Windows.Forms.MenuItem()
        Me.tabStringDemo = New System.Windows.Forms.TabControl()
        Me.pagReturnStrings = New System.Windows.Forms.TabPage()
        Me.optTrimStart = New System.Windows.Forms.RadioButton()
        Me.optTrimEnd = New System.Windows.Forms.RadioButton()
        Me.optTrim = New System.Windows.Forms.RadioButton()
        Me.optToUpper = New System.Windows.Forms.RadioButton()
        Me.optToLower = New System.Windows.Forms.RadioButton()
        Me.optSubstring = New System.Windows.Forms.RadioButton()
        Me.optPadRight = New System.Windows.Forms.RadioButton()
        Me.optPadLeft = New System.Windows.Forms.RadioButton()
        Me.optReplace = New System.Windows.Forms.RadioButton()
        Me.optRemove = New System.Windows.Forms.RadioButton()
        Me.optInsert = New System.Windows.Forms.RadioButton()
        Me.pnlDemo = New System.Windows.Forms.Panel()
        Me.grpResults = New System.Windows.Forms.GroupBox()
        Me.lblResultsLabel = New System.Windows.Forms.Label()
        Me.lblResults = New System.Windows.Forms.Label()
        Me.btnRecalc = New System.Windows.Forms.Button()
        Me.grpParameters = New System.Windows.Forms.GroupBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.lblPrm2 = New System.Windows.Forms.Label()
        Me.lblPrm3 = New System.Windows.Forms.Label()
        Me.txtPrm1 = New System.Windows.Forms.TextBox()
        Me.txtPrm2 = New System.Windows.Forms.TextBox()
        Me.lblPrm1 = New System.Windows.Forms.Label()
        Me.txtPrm3 = New System.Windows.Forms.TextBox()
        Me.grpSample = New System.Windows.Forms.GroupBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtSample = New System.Windows.Forms.TextBox()
        Me.btnRefresh = New System.Windows.Forms.Button()
        Me.pagInfo = New System.Windows.Forms.TabPage()
        Me.optSplit = New System.Windows.Forms.RadioButton()
        Me.optEndsWith = New System.Windows.Forms.RadioButton()
        Me.optStartsWith = New System.Windows.Forms.RadioButton()
        Me.optLastIndexOfAny = New System.Windows.Forms.RadioButton()
        Me.optLastIndexOf = New System.Windows.Forms.RadioButton()
        Me.optIndexOfAny = New System.Windows.Forms.RadioButton()
        Me.optIndexOf = New System.Windows.Forms.RadioButton()
        Me.pagShared = New System.Windows.Forms.TabPage()
        Me.optJoin = New System.Windows.Forms.RadioButton()
        Me.optFormat = New System.Windows.Forms.RadioButton()
        Me.optConcat = New System.Windows.Forms.RadioButton()
        Me.optCompareOrdinal = New System.Windows.Forms.RadioButton()
        Me.optCompare = New System.Windows.Forms.RadioButton()
        Me.pagOther = New System.Windows.Forms.TabPage()
        Me.btnStringWriter = New System.Windows.Forms.Button()
        Me.btnStringBuilder = New System.Windows.Forms.Button()
        Me.ttpStrings = New System.Windows.Forms.ToolTip(Me.components)
        Me.txtResults = New System.Windows.Forms.TextBox()
        Me.chkDebug = New System.Windows.Forms.CheckBox()
        Me.btnClear = New System.Windows.Forms.Button()
        Me.tabStringDemo.SuspendLayout()
        Me.pagReturnStrings.SuspendLayout()
        Me.pnlDemo.SuspendLayout()
        Me.grpResults.SuspendLayout()
        Me.grpParameters.SuspendLayout()
        Me.grpSample.SuspendLayout()
        Me.pagInfo.SuspendLayout()
        Me.pagShared.SuspendLayout()
        Me.pagOther.SuspendLayout()
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
        'tabStringDemo
        '
        Me.tabStringDemo.Anchor = (((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right)
        Me.tabStringDemo.Controls.AddRange(New System.Windows.Forms.Control() {Me.pagReturnStrings, Me.pagInfo, Me.pagShared, Me.pagOther})
        Me.tabStringDemo.Location = New System.Drawing.Point(8, 8)
        Me.tabStringDemo.Name = "tabStringDemo"
        Me.tabStringDemo.SelectedIndex = 0
        Me.tabStringDemo.Size = New System.Drawing.Size(640, 324)
        Me.tabStringDemo.TabIndex = 0
        '
        'pagReturnStrings
        '
        Me.pagReturnStrings.Controls.AddRange(New System.Windows.Forms.Control() {Me.optTrimStart, Me.optTrimEnd, Me.optTrim, Me.optToUpper, Me.optToLower, Me.optSubstring, Me.optPadRight, Me.optPadLeft, Me.optReplace, Me.optRemove, Me.optInsert, Me.pnlDemo})
        Me.pagReturnStrings.Location = New System.Drawing.Point(4, 22)
        Me.pagReturnStrings.Name = "pagReturnStrings"
        Me.pagReturnStrings.Size = New System.Drawing.Size(632, 298)
        Me.pagReturnStrings.TabIndex = 0
        Me.pagReturnStrings.Text = "Methods that Return Strings"
        '
        'optTrimStart
        '
        Me.optTrimStart.Appearance = System.Windows.Forms.Appearance.Button
        Me.optTrimStart.Location = New System.Drawing.Point(8, 248)
        Me.optTrimStart.Name = "optTrimStart"
        Me.optTrimStart.Size = New System.Drawing.Size(104, 22)
        Me.optTrimStart.TabIndex = 10
        Me.optTrimStart.Text = "TrimStart"
        Me.optTrimStart.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'optTrimEnd
        '
        Me.optTrimEnd.Appearance = System.Windows.Forms.Appearance.Button
        Me.optTrimEnd.Location = New System.Drawing.Point(8, 224)
        Me.optTrimEnd.Name = "optTrimEnd"
        Me.optTrimEnd.Size = New System.Drawing.Size(104, 22)
        Me.optTrimEnd.TabIndex = 9
        Me.optTrimEnd.Text = "TrimEnd"
        Me.optTrimEnd.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'optTrim
        '
        Me.optTrim.Appearance = System.Windows.Forms.Appearance.Button
        Me.optTrim.Location = New System.Drawing.Point(8, 200)
        Me.optTrim.Name = "optTrim"
        Me.optTrim.Size = New System.Drawing.Size(104, 22)
        Me.optTrim.TabIndex = 8
        Me.optTrim.Text = "Trim"
        Me.optTrim.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'optToUpper
        '
        Me.optToUpper.Appearance = System.Windows.Forms.Appearance.Button
        Me.optToUpper.Location = New System.Drawing.Point(8, 176)
        Me.optToUpper.Name = "optToUpper"
        Me.optToUpper.Size = New System.Drawing.Size(104, 22)
        Me.optToUpper.TabIndex = 7
        Me.optToUpper.Text = "ToUpper"
        Me.optToUpper.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'optToLower
        '
        Me.optToLower.Appearance = System.Windows.Forms.Appearance.Button
        Me.optToLower.Location = New System.Drawing.Point(8, 152)
        Me.optToLower.Name = "optToLower"
        Me.optToLower.Size = New System.Drawing.Size(104, 22)
        Me.optToLower.TabIndex = 6
        Me.optToLower.Text = "ToLower"
        Me.optToLower.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'optSubstring
        '
        Me.optSubstring.Appearance = System.Windows.Forms.Appearance.Button
        Me.optSubstring.Location = New System.Drawing.Point(8, 128)
        Me.optSubstring.Name = "optSubstring"
        Me.optSubstring.Size = New System.Drawing.Size(104, 22)
        Me.optSubstring.TabIndex = 5
        Me.optSubstring.Text = "Substring"
        Me.optSubstring.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'optPadRight
        '
        Me.optPadRight.Appearance = System.Windows.Forms.Appearance.Button
        Me.optPadRight.Location = New System.Drawing.Point(8, 104)
        Me.optPadRight.Name = "optPadRight"
        Me.optPadRight.Size = New System.Drawing.Size(104, 22)
        Me.optPadRight.TabIndex = 4
        Me.optPadRight.Text = "PadRight"
        Me.optPadRight.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'optPadLeft
        '
        Me.optPadLeft.Appearance = System.Windows.Forms.Appearance.Button
        Me.optPadLeft.Location = New System.Drawing.Point(8, 80)
        Me.optPadLeft.Name = "optPadLeft"
        Me.optPadLeft.Size = New System.Drawing.Size(104, 22)
        Me.optPadLeft.TabIndex = 3
        Me.optPadLeft.Text = "PadLeft"
        Me.optPadLeft.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'optReplace
        '
        Me.optReplace.Appearance = System.Windows.Forms.Appearance.Button
        Me.optReplace.Location = New System.Drawing.Point(8, 56)
        Me.optReplace.Name = "optReplace"
        Me.optReplace.Size = New System.Drawing.Size(104, 22)
        Me.optReplace.TabIndex = 2
        Me.optReplace.Text = "Replace"
        Me.optReplace.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'optRemove
        '
        Me.optRemove.Appearance = System.Windows.Forms.Appearance.Button
        Me.optRemove.Location = New System.Drawing.Point(8, 32)
        Me.optRemove.Name = "optRemove"
        Me.optRemove.Size = New System.Drawing.Size(104, 22)
        Me.optRemove.TabIndex = 1
        Me.optRemove.Text = "Remove"
        Me.optRemove.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'optInsert
        '
        Me.optInsert.Appearance = System.Windows.Forms.Appearance.Button
        Me.optInsert.Checked = True
        Me.optInsert.Location = New System.Drawing.Point(8, 8)
        Me.optInsert.Name = "optInsert"
        Me.optInsert.Size = New System.Drawing.Size(104, 22)
        Me.optInsert.TabIndex = 0
        Me.optInsert.TabStop = True
        Me.optInsert.Text = "Insert"
        Me.optInsert.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'pnlDemo
        '
        Me.pnlDemo.Anchor = (((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right)
        Me.pnlDemo.Controls.AddRange(New System.Windows.Forms.Control() {Me.grpResults, Me.grpParameters, Me.grpSample})
        Me.pnlDemo.Location = New System.Drawing.Point(120, 8)
        Me.pnlDemo.Name = "pnlDemo"
        Me.pnlDemo.Size = New System.Drawing.Size(504, 284)
        Me.pnlDemo.TabIndex = 11
        '
        'grpResults
        '
        Me.grpResults.Anchor = (((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right)
        Me.grpResults.Controls.AddRange(New System.Windows.Forms.Control() {Me.lblResultsLabel, Me.lblResults, Me.btnRecalc})
        Me.grpResults.Location = New System.Drawing.Point(8, 192)
        Me.grpResults.Name = "grpResults"
        Me.grpResults.Size = New System.Drawing.Size(488, 76)
        Me.grpResults.TabIndex = 2
        Me.grpResults.TabStop = False
        '
        'lblResultsLabel
        '
        Me.lblResultsLabel.AutoSize = True
        Me.lblResultsLabel.Location = New System.Drawing.Point(8, 0)
        Me.lblResultsLabel.Name = "lblResultsLabel"
        Me.lblResultsLabel.Size = New System.Drawing.Size(42, 13)
        Me.lblResultsLabel.TabIndex = 0
        Me.lblResultsLabel.Text = "Results"
        Me.lblResultsLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblResults
        '
        Me.lblResults.Anchor = (((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right)
        Me.lblResults.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblResults.Location = New System.Drawing.Point(16, 24)
        Me.lblResults.Name = "lblResults"
        Me.lblResults.Size = New System.Drawing.Size(376, 44)
        Me.lblResults.TabIndex = 1
        '
        'btnRecalc
        '
        Me.btnRecalc.Anchor = (System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right)
        Me.btnRecalc.Location = New System.Drawing.Point(400, 24)
        Me.btnRecalc.Name = "btnRecalc"
        Me.btnRecalc.TabIndex = 2
        Me.btnRecalc.Text = "&Recalc"
        Me.ttpStrings.SetToolTip(Me.btnRecalc, "Recalculate the results")
        '
        'grpParameters
        '
        Me.grpParameters.Anchor = ((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right)
        Me.grpParameters.Controls.AddRange(New System.Windows.Forms.Control() {Me.Label1, Me.lblPrm2, Me.lblPrm3, Me.txtPrm1, Me.txtPrm2, Me.lblPrm1, Me.txtPrm3})
        Me.grpParameters.Location = New System.Drawing.Point(8, 80)
        Me.grpParameters.Name = "grpParameters"
        Me.grpParameters.Size = New System.Drawing.Size(488, 104)
        Me.grpParameters.TabIndex = 1
        Me.grpParameters.TabStop = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(8, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(63, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Parameters"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblPrm2
        '
        Me.lblPrm2.Location = New System.Drawing.Point(16, 48)
        Me.lblPrm2.Name = "lblPrm2"
        Me.lblPrm2.Size = New System.Drawing.Size(120, 23)
        Me.lblPrm2.TabIndex = 3
        Me.lblPrm2.Text = "Param2"
        Me.lblPrm2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblPrm3
        '
        Me.lblPrm3.Location = New System.Drawing.Point(16, 72)
        Me.lblPrm3.Name = "lblPrm3"
        Me.lblPrm3.Size = New System.Drawing.Size(120, 23)
        Me.lblPrm3.TabIndex = 5
        Me.lblPrm3.Text = "Param3"
        Me.lblPrm3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtPrm1
        '
        Me.txtPrm1.Anchor = ((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right)
        Me.txtPrm1.Location = New System.Drawing.Point(136, 24)
        Me.txtPrm1.Name = "txtPrm1"
        Me.txtPrm1.Size = New System.Drawing.Size(200, 20)
        Me.txtPrm1.TabIndex = 2
        Me.txtPrm1.Text = ""
        '
        'txtPrm2
        '
        Me.txtPrm2.Anchor = ((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right)
        Me.txtPrm2.Location = New System.Drawing.Point(136, 48)
        Me.txtPrm2.Name = "txtPrm2"
        Me.txtPrm2.Size = New System.Drawing.Size(200, 20)
        Me.txtPrm2.TabIndex = 4
        Me.txtPrm2.Text = ""
        '
        'lblPrm1
        '
        Me.lblPrm1.Location = New System.Drawing.Point(16, 24)
        Me.lblPrm1.Name = "lblPrm1"
        Me.lblPrm1.Size = New System.Drawing.Size(120, 23)
        Me.lblPrm1.TabIndex = 1
        Me.lblPrm1.Text = "Param1"
        Me.lblPrm1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtPrm3
        '
        Me.txtPrm3.Anchor = ((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right)
        Me.txtPrm3.Location = New System.Drawing.Point(136, 72)
        Me.txtPrm3.Name = "txtPrm3"
        Me.txtPrm3.Size = New System.Drawing.Size(200, 20)
        Me.txtPrm3.TabIndex = 6
        Me.txtPrm3.Text = ""
        '
        'grpSample
        '
        Me.grpSample.Anchor = ((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right)
        Me.grpSample.Controls.AddRange(New System.Windows.Forms.Control() {Me.Label2, Me.txtSample, Me.btnRefresh})
        Me.grpSample.Location = New System.Drawing.Point(8, 8)
        Me.grpSample.Name = "grpSample"
        Me.grpSample.Size = New System.Drawing.Size(488, 64)
        Me.grpSample.TabIndex = 0
        Me.grpSample.TabStop = False
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(8, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(43, 13)
        Me.Label2.TabIndex = 0
        Me.Label2.Text = "Sample"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtSample
        '
        Me.txtSample.Anchor = ((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right)
        Me.txtSample.Location = New System.Drawing.Point(16, 24)
        Me.txtSample.Name = "txtSample"
        Me.txtSample.Size = New System.Drawing.Size(376, 20)
        Me.txtSample.TabIndex = 1
        Me.txtSample.Text = ""
        '
        'btnRefresh
        '
        Me.btnRefresh.Anchor = (System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right)
        Me.btnRefresh.Location = New System.Drawing.Point(400, 24)
        Me.btnRefresh.Name = "btnRefresh"
        Me.btnRefresh.TabIndex = 2
        Me.btnRefresh.Text = "Re&fresh"
        Me.ttpStrings.SetToolTip(Me.btnRefresh, "Refresh the sample text")
        '
        'pagInfo
        '
        Me.pagInfo.Controls.AddRange(New System.Windows.Forms.Control() {Me.optSplit, Me.optEndsWith, Me.optStartsWith, Me.optLastIndexOfAny, Me.optLastIndexOf, Me.optIndexOfAny, Me.optIndexOf})
        Me.pagInfo.Location = New System.Drawing.Point(4, 22)
        Me.pagInfo.Name = "pagInfo"
        Me.pagInfo.Size = New System.Drawing.Size(632, 294)
        Me.pagInfo.TabIndex = 1
        Me.pagInfo.Text = "Methods that Return Information"
        '
        'optSplit
        '
        Me.optSplit.Appearance = System.Windows.Forms.Appearance.Button
        Me.optSplit.Location = New System.Drawing.Point(8, 152)
        Me.optSplit.Name = "optSplit"
        Me.optSplit.Size = New System.Drawing.Size(104, 22)
        Me.optSplit.TabIndex = 6
        Me.optSplit.Text = "Split"
        Me.optSplit.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'optEndsWith
        '
        Me.optEndsWith.Appearance = System.Windows.Forms.Appearance.Button
        Me.optEndsWith.Location = New System.Drawing.Point(8, 128)
        Me.optEndsWith.Name = "optEndsWith"
        Me.optEndsWith.Size = New System.Drawing.Size(104, 22)
        Me.optEndsWith.TabIndex = 5
        Me.optEndsWith.Text = "EndsWith"
        Me.optEndsWith.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'optStartsWith
        '
        Me.optStartsWith.Appearance = System.Windows.Forms.Appearance.Button
        Me.optStartsWith.Location = New System.Drawing.Point(8, 104)
        Me.optStartsWith.Name = "optStartsWith"
        Me.optStartsWith.Size = New System.Drawing.Size(104, 22)
        Me.optStartsWith.TabIndex = 4
        Me.optStartsWith.Text = "StartsWith"
        Me.optStartsWith.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'optLastIndexOfAny
        '
        Me.optLastIndexOfAny.Appearance = System.Windows.Forms.Appearance.Button
        Me.optLastIndexOfAny.Location = New System.Drawing.Point(8, 80)
        Me.optLastIndexOfAny.Name = "optLastIndexOfAny"
        Me.optLastIndexOfAny.Size = New System.Drawing.Size(104, 22)
        Me.optLastIndexOfAny.TabIndex = 3
        Me.optLastIndexOfAny.Text = "LastIndexOfAny"
        Me.optLastIndexOfAny.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'optLastIndexOf
        '
        Me.optLastIndexOf.Appearance = System.Windows.Forms.Appearance.Button
        Me.optLastIndexOf.Location = New System.Drawing.Point(8, 56)
        Me.optLastIndexOf.Name = "optLastIndexOf"
        Me.optLastIndexOf.Size = New System.Drawing.Size(104, 22)
        Me.optLastIndexOf.TabIndex = 2
        Me.optLastIndexOf.Text = "LastIndexOf"
        Me.optLastIndexOf.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'optIndexOfAny
        '
        Me.optIndexOfAny.Appearance = System.Windows.Forms.Appearance.Button
        Me.optIndexOfAny.Location = New System.Drawing.Point(8, 32)
        Me.optIndexOfAny.Name = "optIndexOfAny"
        Me.optIndexOfAny.Size = New System.Drawing.Size(104, 22)
        Me.optIndexOfAny.TabIndex = 1
        Me.optIndexOfAny.Text = "IndexOfAny"
        Me.optIndexOfAny.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'optIndexOf
        '
        Me.optIndexOf.Appearance = System.Windows.Forms.Appearance.Button
        Me.optIndexOf.Checked = True
        Me.optIndexOf.Location = New System.Drawing.Point(8, 8)
        Me.optIndexOf.Name = "optIndexOf"
        Me.optIndexOf.Size = New System.Drawing.Size(104, 22)
        Me.optIndexOf.TabIndex = 0
        Me.optIndexOf.TabStop = True
        Me.optIndexOf.Text = "IndexOf"
        Me.optIndexOf.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'pagShared
        '
        Me.pagShared.Controls.AddRange(New System.Windows.Forms.Control() {Me.optJoin, Me.optFormat, Me.optConcat, Me.optCompareOrdinal, Me.optCompare})
        Me.pagShared.Location = New System.Drawing.Point(4, 22)
        Me.pagShared.Name = "pagShared"
        Me.pagShared.Size = New System.Drawing.Size(632, 294)
        Me.pagShared.TabIndex = 2
        Me.pagShared.Text = "Shared Methods"
        '
        'optJoin
        '
        Me.optJoin.Appearance = System.Windows.Forms.Appearance.Button
        Me.optJoin.Location = New System.Drawing.Point(8, 104)
        Me.optJoin.Name = "optJoin"
        Me.optJoin.Size = New System.Drawing.Size(104, 22)
        Me.optJoin.TabIndex = 4
        Me.optJoin.Text = "Join"
        Me.optJoin.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'optFormat
        '
        Me.optFormat.Appearance = System.Windows.Forms.Appearance.Button
        Me.optFormat.Location = New System.Drawing.Point(8, 80)
        Me.optFormat.Name = "optFormat"
        Me.optFormat.Size = New System.Drawing.Size(104, 22)
        Me.optFormat.TabIndex = 3
        Me.optFormat.Text = "Format"
        Me.optFormat.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'optConcat
        '
        Me.optConcat.Appearance = System.Windows.Forms.Appearance.Button
        Me.optConcat.Location = New System.Drawing.Point(8, 56)
        Me.optConcat.Name = "optConcat"
        Me.optConcat.Size = New System.Drawing.Size(104, 22)
        Me.optConcat.TabIndex = 2
        Me.optConcat.Text = "Concat"
        Me.optConcat.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'optCompareOrdinal
        '
        Me.optCompareOrdinal.Appearance = System.Windows.Forms.Appearance.Button
        Me.optCompareOrdinal.Location = New System.Drawing.Point(8, 32)
        Me.optCompareOrdinal.Name = "optCompareOrdinal"
        Me.optCompareOrdinal.Size = New System.Drawing.Size(104, 22)
        Me.optCompareOrdinal.TabIndex = 1
        Me.optCompareOrdinal.Text = "CompareOrdinal"
        Me.optCompareOrdinal.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'optCompare
        '
        Me.optCompare.Appearance = System.Windows.Forms.Appearance.Button
        Me.optCompare.Checked = True
        Me.optCompare.Location = New System.Drawing.Point(8, 8)
        Me.optCompare.Name = "optCompare"
        Me.optCompare.Size = New System.Drawing.Size(104, 22)
        Me.optCompare.TabIndex = 0
        Me.optCompare.TabStop = True
        Me.optCompare.Text = "Compare"
        Me.optCompare.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'pagOther
        '
        Me.pagOther.Controls.AddRange(New System.Windows.Forms.Control() {Me.btnClear, Me.chkDebug, Me.txtResults, Me.btnStringWriter, Me.btnStringBuilder})
        Me.pagOther.Location = New System.Drawing.Point(4, 22)
        Me.pagOther.Name = "pagOther"
        Me.pagOther.Size = New System.Drawing.Size(632, 298)
        Me.pagOther.TabIndex = 3
        Me.pagOther.Text = "Other Classes"
        '
        'btnStringWriter
        '
        Me.btnStringWriter.Location = New System.Drawing.Point(8, 32)
        Me.btnStringWriter.Name = "btnStringWriter"
        Me.btnStringWriter.Size = New System.Drawing.Size(104, 22)
        Me.btnStringWriter.TabIndex = 1
        Me.btnStringWriter.Text = "StringWriter"
        '
        'btnStringBuilder
        '
        Me.btnStringBuilder.Location = New System.Drawing.Point(8, 8)
        Me.btnStringBuilder.Name = "btnStringBuilder"
        Me.btnStringBuilder.Size = New System.Drawing.Size(104, 22)
        Me.btnStringBuilder.TabIndex = 0
        Me.btnStringBuilder.Text = "StringBuilder"
        '
        'txtResults
        '
        Me.txtResults.Anchor = (((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right)
        Me.txtResults.Location = New System.Drawing.Point(128, 8)
        Me.txtResults.Multiline = True
        Me.txtResults.Name = "txtResults"
        Me.txtResults.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtResults.Size = New System.Drawing.Size(496, 256)
        Me.txtResults.TabIndex = 2
        Me.txtResults.Text = ""
        '
        'chkDebug
        '
        Me.chkDebug.Checked = True
        Me.chkDebug.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkDebug.Location = New System.Drawing.Point(8, 80)
        Me.chkDebug.Name = "chkDebug"
        Me.chkDebug.TabIndex = 3
        Me.chkDebug.Text = "Single Step"
        '
        'btnClear
        '
        Me.btnClear.Location = New System.Drawing.Point(8, 104)
        Me.btnClear.Name = "btnClear"
        Me.btnClear.Size = New System.Drawing.Size(104, 22)
        Me.btnClear.TabIndex = 4
        Me.btnClear.Text = "Clear Output"
        '
        'frmMain
        '
        Me.AcceptButton = Me.btnRecalc
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(656, 333)
        Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.tabStringDemo})
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Menu = Me.mnuMain
        Me.MinimumSize = New System.Drawing.Size(664, 380)
        Me.Name = "frmMain"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Title Comes from Assembly Info"
        Me.tabStringDemo.ResumeLayout(False)
        Me.pagReturnStrings.ResumeLayout(False)
        Me.pnlDemo.ResumeLayout(False)
        Me.grpResults.ResumeLayout(False)
        Me.grpParameters.ResumeLayout(False)
        Me.grpSample.ResumeLayout(False)
        Me.pagInfo.ResumeLayout(False)
        Me.pagShared.ResumeLayout(False)
        Me.pagOther.ResumeLayout(False)
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

    Private Const DEFAULT_TEXT As String = "the quick brown fox jumps over the lazy dog"
    Private Const QUOTE As String = """"
    Private mstrSample As String = DEFAULT_TEXT
    Private rbtnShared As RadioButton
    Private rbtnStringReturn As RadioButton
    Private rbtnStringInfo As RadioButton

    Private Enum SelectedMethod
        Compare
        CompareOrdinal
        Concat
        EndsWith
        Format
        IndexOf
        IndexOfAny
        Insert
        Join
        LastIndexOf
        LastIndexOfAny
        PadLeft
        PadRight
        Remove
        Replace
        Split
        StartsWith
        Substring
        ToLower
        ToUpper
        Trim
        TrimEnd
        TrimStart
    End Enum
    Private sm As SelectedMethod

    Private Sub btnClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClear.Click
        txtResults.Clear()
    End Sub

    Private Sub btnRecalc_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRecalc.Click
        Recalc()
    End Sub

    Private Sub btnRefresh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRefresh.Click
        RefreshText()
    End Sub

    Private Sub btnStringBuilder_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnStringBuilder.Click
        ' Demonstrate the StringBuilder class.

        If chkDebug.Checked Then
            ' Trigger a breakpoint.
            System.Diagnostics.Debugger.Break()
        End If

        ' StringBuilder is provided by the System.Text 
        ' namespace. See the Imports statement
        ' at the top of this module.
        Dim sb As New StringBuilder("The quick brown fox jumps over the lazy dog")

        sb.Insert(19, " happily")
        sb.Remove(10, 6)
        sb.Replace("jumps", "leaps")
        sb.AppendFormat(" {0} times in {1} minutes", 17, 2)

        ' Suppose you want to insert a comma after the word "dog".
        ' You need to locate the word, then insert a comma
        ' after the word. To locate the string, you must search
        ' using IndexOf, but StringBuilder doesn't supply this method.
        ' Therefore, you must use the ToString method to retrieve
        ' the string, and work with that object instead.
        Dim intPos As Integer
        intPos = sb.ToString.IndexOf("dog")
        If intPos > 0 Then
            ' Insert the comma at the position
            ' you found + the length of the text "dog".
            sb.Insert(intPos + "dog".Length, ", ")
        End If

        ' The same code using the String object directly
        ' would look like this. Note the number of times 
        ' you require the .NET framework to create new strings.
        ' StringBuilder is significantly more efficient for
        ' this sort of operation.
        Dim str As String = "The quick brown fox jumps over the lazy dog"
        str = str.Insert(19, " happily")
        str = str.Remove(10, 6)
        str = str.Replace("jumps", "leaps")
        str &= String.Format("{0} times in {1} minutes", 17, 2)
        intPos = str.IndexOf("dog")
        If intPos > 0 Then
            str = str.Insert(intPos + "dog".Length, ", ")
        End If

        txtResults.AppendText("StringBuilder output: " & sb.ToString & Environment.NewLine)
        txtResults.AppendText("String output: " & str & Environment.NewLine)
    End Sub

    Private Sub btnStringWriter_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnStringWriter.Click
        ' Simple demonstration of the StringWriter class.
        ' Write to the StringWriter as if you were 
        ' writing to a file--you're really writing to 
        ' a buffer in memory, instead.

        ' StringWriter is provided by the System.IO
        ' namespace. See the Imports statement
        ' at the top of this module.
        Dim sw As New StringWriter()

        If chkDebug.Checked Then
            ' Trigger a breakpoint.
            System.Diagnostics.Debugger.Break()
        End If

        ' You've been supplied with some data structure,
        ' perhaps an array of strings, containing
        ' address information. Create a formatted
        ' address.
        Dim addressInfo() As String = {"John Smith", "123 Main Street", "Centerville", "WA", "98111"}

        ' Add in the name and address lines:
        sw.WriteLine(addressInfo(0))
        sw.WriteLine(addressInfo(1))

        ' You might use the String.Format method to create
        ' this line of the address, but this demo 
        ' shows how to use both the WriteLine and the
        ' Write methods. Although this is somewhat contrived, you 
        ' can at least see how to use the two methods:
        sw.Write(addressInfo(2))
        sw.Write(", ")
        sw.Write(addressInfo(3))
        sw.Write(" ")
        sw.WriteLine(addressInfo(4))

        ' Or:
        ' sw.WriteLine(String.Format("{0}, {1} {2}", addressInfo(2), addressInfo(3), addressInfo(4)))

        ' Using the String class, the code's uglier:
        Dim str As String
        str = addressInfo(0) & Environment.NewLine
        str &= addressInfo(1) & Environment.NewLine

        ' Add on the city/region/postal code values:
        str &= addressInfo(2) & ", "
        str &= addressInfo(3) & " " & addressInfo(4)
        str &= Environment.NewLine

        ' Or: 
        ' str &= String.Format("{0}, {1} {2}{3}", addressInfo(2), addressInfo(3), addressInfo(4), Environment.NewLine)

        ' Display the output:
        txtResults.AppendText("StringWriter output: " & _
            Environment.NewLine & sw.ToString)

        txtResults.AppendText("String output: " & _
            Environment.NewLine & str)

    End Sub

    Private Sub frmMain_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ' Initialize values.
        ' Selected page:
        tabStringDemo.SelectedIndex = 0

        ' Selected buttons on each page.
        ' We've selected the first button on each page.
        rbtnStringInfo = optIndexOf
        rbtnStringReturn = optInsert
        rbtnShared = optCompare

        ' Display text on the first page.
        DisplayText(optInsert)
    End Sub

    Private Sub tabStringDemo_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tabStringDemo.SelectedIndexChanged
        Dim pagSelected As TabPage = tabStringDemo.SelectedTab

        ' This code runs before the Load event of the form.
        ' Skip all the code if the Load event hasn't yet 
        ' run.
        If Not rbtnStringReturn Is Nothing Then
            ' Move the panel containing the 
            ' info to the current page. Don't do 
            ' this for the "other" page, however.
            If Not pagSelected Is pagOther Then
                pnlDemo.Parent = pagSelected
            End If

            ' Based on the selected page, display output
            ' from the item previously selected.
            If pagSelected Is pagReturnStrings Then
                grpSample.Visible = True
                DisplayText(rbtnStringReturn)
            ElseIf pagSelected Is pagInfo Then
                grpSample.Visible = True
                DisplayText(rbtnStringInfo)
            ElseIf pagSelected Is pagShared Then
                grpSample.Visible = False
                DisplayText(rbtnShared)
            End If
        End If
    End Sub

    Private Function AddQuotes(ByVal strValue As String) As String
        ' Add quotes around the supplied text.
        ' Replace single quotes (") with double quotes ("")
        ' to appease the VB.NET parser.
        Return QUOTE & Replace(strValue, QUOTE, QUOTE & QUOTE) & QUOTE
    End Function

    Private Sub DisplayText(ByVal rbtn As RadioButton)
        ' Take action depending on which radio button you've selected.
        If rbtn Is optCompare Then
            rbtnShared = rbtn
            sm = SelectedMethod.Compare
            HandleParameters("strA", "This is a test", "strB", "this is a test", "ignoreCase", "True")

        ElseIf rbtn Is optCompareOrdinal Then
            rbtnShared = rbtn
            sm = SelectedMethod.CompareOrdinal
            HandleParameters("strA", "This is a test", "strB", "this is a test")

        ElseIf rbtn Is optConcat Then
            rbtnShared = rbtn
            sm = SelectedMethod.Concat
            HandleParameters("strA", "This is a test", "strB", " of how this works", "strC", " when you concatenate")

        ElseIf rbtn Is optEndsWith Then
            rbtnStringInfo = rbtn
            sm = SelectedMethod.EndsWith
            mstrSample = DEFAULT_TEXT
            HandleParameters("value", "dog")

        ElseIf rbtn Is optFormat Then
            rbtnShared = rbtn
            sm = SelectedMethod.Format
            HandleParameters("Format", "Your {0:N0} items total {1:C}.", "Param1", "12", "Param2", "12.35")

        ElseIf rbtn Is optIndexOf Then
            rbtnStringInfo = rbtn
            sm = SelectedMethod.IndexOf
            mstrSample = DEFAULT_TEXT
            HandleParameters("value", "o", "startIndex", "", "count", "")

        ElseIf rbtn Is optIndexOfAny Then
            rbtnStringInfo = rbtn
            sm = SelectedMethod.IndexOfAny
            mstrSample = DEFAULT_TEXT
            HandleParameters("anyOf()", "abc", "startIndex", "", "count", "")

        ElseIf rbtn Is optInsert Then
            rbtnStringReturn = rbtn
            sm = SelectedMethod.Insert
            mstrSample = DEFAULT_TEXT
            HandleParameters("startIndex", "19", "value", " happily")

        ElseIf rbtn Is optJoin Then
            rbtnShared = rbtn
            sm = SelectedMethod.Join
            HandleParameters("separator", "-", "values()", "item1,item2,item3,item4")

        ElseIf rbtn Is optLastIndexOf Then
            rbtnStringInfo = rbtn
            sm = SelectedMethod.LastIndexOf
            mstrSample = DEFAULT_TEXT
            HandleParameters("value", "o", "startIndex", "", "count", "")

        ElseIf rbtn Is optLastIndexOfAny Then
            rbtnStringInfo = rbtn
            sm = SelectedMethod.LastIndexOfAny
            mstrSample = DEFAULT_TEXT
            HandleParameters("anyOf()", "abc", "startIndex", "", "count", "")

        ElseIf rbtn Is optPadLeft Then
            rbtnStringReturn = rbtn
            sm = SelectedMethod.PadLeft
            mstrSample = "123.45"
            HandleParameters("totalWidth", "10", "paddingChar", "$")

        ElseIf rbtn Is optPadRight Then
            rbtnStringReturn = rbtn
            sm = SelectedMethod.PadRight
            mstrSample = "Pad"
            HandleParameters("totalWidth", "10", "paddingChar", "_")

        ElseIf rbtn Is optRemove Then
            rbtnStringReturn = rbtn
            sm = SelectedMethod.Remove
            mstrSample = DEFAULT_TEXT
            HandleParameters("startIndex", "10", "count", "6")

        ElseIf rbtn Is optReplace Then
            rbtnStringReturn = rbtn
            sm = SelectedMethod.Replace
            mstrSample = DEFAULT_TEXT
            HandleParameters("oldValue", "jumps", "newValue", "leaps")

        ElseIf rbtn Is optSplit Then
            rbtnStringInfo = rbtn
            sm = SelectedMethod.Split
            mstrSample = DEFAULT_TEXT
            HandleParameters("separator()", "abc", "count", "")

        ElseIf rbtn Is optStartsWith Then
            rbtnStringInfo = rbtn
            sm = SelectedMethod.StartsWith
            mstrSample = DEFAULT_TEXT
            HandleParameters("value", "The qui")

        ElseIf rbtn Is optSubstring Then
            rbtnStringReturn = rbtn
            sm = SelectedMethod.Substring
            mstrSample = DEFAULT_TEXT
            HandleParameters("startIndex", "12", "length", "5")

        ElseIf rbtn Is optToLower Then
            rbtnStringReturn = rbtn
            sm = SelectedMethod.ToLower
            mstrSample = "This Sample has SOME mixed-CASE Text!"
            HandleParameters()

        ElseIf rbtn Is optToUpper Then
            rbtnStringReturn = rbtn
            sm = SelectedMethod.ToUpper
            mstrSample = "This Sample has SOME mixed-CASE Text!"
            HandleParameters()

        ElseIf rbtn Is optTrim Then
            rbtnStringReturn = rbtn
            sm = SelectedMethod.Trim
            mstrSample = DEFAULT_TEXT
            HandleParameters("trimChars()", "the dog")

        ElseIf rbtn Is optTrimEnd Then
            rbtnStringReturn = rbtn
            sm = SelectedMethod.TrimEnd
            mstrSample = DEFAULT_TEXT
            HandleParameters("trimChars()", "the dog")

        ElseIf rbtn Is optTrimStart Then
            rbtnStringReturn = rbtn
            sm = SelectedMethod.TrimStart
            mstrSample = DEFAULT_TEXT
            HandleParameters("trimChars()", "the dog")
        End If

        ' Display the sample text, and 
        ' recalc to display the output.
        RefreshText()
        Recalc()
    End Sub

    Private Sub HandleCheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles optInsert.CheckedChanged, optPadLeft.CheckedChanged, optPadRight.CheckedChanged, optRemove.CheckedChanged, optReplace.CheckedChanged, optSubstring.CheckedChanged, optToLower.CheckedChanged, optToUpper.CheckedChanged, optTrim.CheckedChanged, optTrimEnd.CheckedChanged, optTrimStart.CheckedChanged, optEndsWith.CheckedChanged, optIndexOf.CheckedChanged, optIndexOfAny.CheckedChanged, optLastIndexOfAny.CheckedChanged, optStartsWith.CheckedChanged, optLastIndexOf.CheckedChanged, optCompare.CheckedChanged, optCompareOrdinal.CheckedChanged, optConcat.CheckedChanged, optFormat.CheckedChanged, optJoin.CheckedChanged
        DisplayText(CType(sender, RadioButton))
    End Sub

    Private Sub HandleParameters()
        ' Display 0 parameters.
        HandleParameterDisplay(0)
    End Sub

    Private Sub HandleParameters(ByVal Param1 As String, ByVal Param1Value As String)
        ' Display one parameter.
        lblPrm1.Text = Param1
        txtPrm1.Text = Param1Value
        HandleParameterDisplay(1)
    End Sub

    Private Sub HandleParameters(ByVal Param1 As String, ByVal Param1Value As String, ByVal Param2 As String, ByVal Param2Value As String)
        ' Display two parameters.
        lblPrm1.Text = Param1
        txtPrm1.Text = Param1Value
        lblPrm2.Text = Param2
        txtPrm2.Text = Param2Value
        HandleParameterDisplay(2)
    End Sub

    Private Sub HandleParameters(ByVal Param1 As String, ByVal Param1Value As String, ByVal Param2 As String, ByVal Param2Value As String, ByVal Param3 As String, ByVal Param3Value As String)
        ' Display three parameters.
        lblPrm1.Text = Param1
        txtPrm1.Text = Param1Value
        lblPrm2.Text = Param2
        txtPrm2.Text = Param2Value
        lblPrm3.Text = Param3
        txtPrm3.Text = Param3Value
        HandleParameterDisplay(3)
    End Sub

    Private Sub HandleParameterDisplay(ByVal intCount As Integer)
        ' Show or hide the parameter labels and text boxes, 
        ' depending on the number of parameters.
        lblPrm1.Visible = (intCount > 0)
        txtPrm1.Visible = (intCount > 0)
        lblPrm2.Visible = (intCount > 1)
        txtPrm2.Visible = (intCount > 1)
        lblPrm3.Visible = (intCount > 2)
        txtPrm3.Visible = (intCount > 2)
    End Sub

    Private Sub HandleResultsLabel(ByVal MethodName As String)
        SetResultsLabel("Sample", MethodName, Nothing)
    End Sub

    Private Sub HandleResultsLabel(ByVal MethodName As String, ByVal Param1 As String)
        SetResultsLabel("Sample", MethodName, Param1)
    End Sub

    Private Sub HandleResultsLabel(ByVal MethodName As String, ByVal Param1 As String, ByVal Param2 As String)
        SetResultsLabel("Sample", MethodName, Param1 & ", " & Param2)
    End Sub

    Private Sub HandleResultsLabel(ByVal MethodName As String, ByVal Param1 As String, ByVal Param2 As String, ByVal Param3 As String)
        SetResultsLabel("Sample", MethodName, Param1 & ", " & Param2 & ", " & Param3)
    End Sub

    Private Sub HandleSharedResultsLabel(ByVal MethodName As String)
        SetResultsLabel("String", MethodName, Nothing)
    End Sub

    Private Sub HandleSharedResultsLabel(ByVal MethodName As String, ByVal Param1 As String)
        SetResultsLabel("String", MethodName, Param1)
    End Sub

    Private Sub HandleSharedResultsLabel(ByVal MethodName As String, ByVal Param1 As String, ByVal Param2 As String)
        SetResultsLabel("String", MethodName, Param1 & ", " & Param2)
    End Sub

    Private Sub HandleSharedResultsLabel(ByVal MethodName As String, ByVal Param1 As String, ByVal Param2 As String, ByVal Param3 As String)
        SetResultsLabel("String", MethodName, Param1 & ", " & Param2 & ", " & Param3)
    End Sub

    Private Sub Recalc()
        Dim strSample As String = txtSample.Text
        Dim strParam1 As String = txtPrm1.Text.TrimEnd
        Dim strParam2 As String = txtPrm2.Text.TrimEnd
        Dim strParam3 As String = txtPrm3.Text.TrimEnd

        Try
            Select Case sm
                Case SelectedMethod.Compare
                    If strParam3 <> String.Empty Then
                        HandleSharedResultsLabel("Compare", AddQuotes(strParam1), AddQuotes(strParam2), strParam3)
                        lblResults.Text = String.Compare(strParam1, strParam2, CBool(strParam3)).ToString
                    Else
                        HandleSharedResultsLabel("Compare", AddQuotes(strParam1), AddQuotes(strParam2))
                        lblResults.Text = String.Compare(strParam1, strParam2).ToString
                    End If

                Case SelectedMethod.CompareOrdinal
                    HandleSharedResultsLabel("CompareOrdinal", AddQuotes(strParam1))
                    lblResults.Text = String.CompareOrdinal(strParam1, strParam2).ToString

                Case SelectedMethod.Concat
                    HandleSharedResultsLabel("Concat", AddQuotes(strParam1), AddQuotes(strParam2), AddQuotes(strParam3))
                    lblResults.Text = String.Concat(strParam1, strParam2, strParam3)

                Case SelectedMethod.EndsWith
                    HandleResultsLabel("EndsWith", AddQuotes(strParam1))
                    ' EndsWith returns a boolean -- convert to a string.
                    lblResults.Text = strSample.EndsWith(strParam1).ToString

                Case SelectedMethod.Format
                    HandleSharedResultsLabel("Format", AddQuotes(strParam1), strParam2, strParam3)
                    lblResults.Text = String.Format(strParam1, CInt(strParam2), CDbl(strParam3))

                Case SelectedMethod.IndexOf
                    If strParam1 <> String.Empty Then
                        If strParam2 <> String.Empty And strParam3 <> String.Empty Then
                            HandleResultsLabel("IndexOf", AddQuotes(strParam1), strParam2, strParam3)
                            lblResults.Text = strSample.IndexOf(strParam1, CInt(strParam2), CInt(strParam3)).ToString
                        ElseIf strParam2 <> String.Empty Then
                            HandleResultsLabel("IndexOf", AddQuotes(strParam1), strParam2)
                            lblResults.Text = strSample.IndexOf(strParam1, CInt(strParam2)).ToString
                        Else
                            HandleResultsLabel("IndexOf", AddQuotes(strParam1))
                            lblResults.Text = strSample.IndexOf(strParam1).ToString
                        End If
                    End If

                Case SelectedMethod.IndexOfAny
                    If strParam1 <> String.Empty Then
                        If strParam2 <> String.Empty And strParam3 <> String.Empty Then
                            HandleResultsLabel("IndexOfAny", AddQuotes(strParam1), strParam2, strParam3)
                            lblResults.Text = strSample.IndexOfAny(strParam1.ToCharArray, CInt(strParam2), CInt(strParam3)).ToString
                        ElseIf strParam2 <> String.Empty Then
                            HandleResultsLabel("IndexOfAny", AddQuotes(strParam1), strParam2)
                            lblResults.Text = strSample.IndexOfAny(strParam1.ToCharArray, CInt(strParam2)).ToString
                        Else
                            HandleResultsLabel("IndexOfAny", AddQuotes(strParam1))
                            lblResults.Text = strSample.IndexOfAny(strParam1.ToCharArray).ToString
                        End If
                    End If

                Case SelectedMethod.Insert
                    HandleResultsLabel("Insert", strParam1, AddQuotes(strParam2))
                    lblResults.Text = strSample.Insert(CInt(strParam1), strParam2)

                Case SelectedMethod.Join
                    ' This code expects to receive a comma-delimited
                    ' list of values. We'll strip out spaces, as well.
                    ' HandleSharedResultsLabel("Join", AddQuotes(strParam1), )
                    Dim astrValues() As String
                    astrValues = strParam2.Split(", ".ToCharArray)
                    lblResults.Text = String.Join(strParam1, astrValues)

                Case SelectedMethod.LastIndexOf
                    If strParam1 <> String.Empty Then
                        If strParam2 <> String.Empty And strParam3 <> String.Empty Then
                            HandleResultsLabel("LastIndexOf", AddQuotes(strParam1), strParam2, strParam3)
                            lblResults.Text = strSample.LastIndexOf(strParam1, CInt(strParam2), CInt(strParam3)).ToString
                        ElseIf strParam2 <> String.Empty Then
                            HandleResultsLabel("LastIndexOf", AddQuotes(strParam1), strParam2)
                            lblResults.Text = strSample.LastIndexOf(strParam1, CInt(strParam2)).ToString
                        Else
                            HandleResultsLabel("LastIndexOf", AddQuotes(strParam1))
                            lblResults.Text = strSample.LastIndexOf(strParam1).ToString
                        End If
                    End If

                Case SelectedMethod.LastIndexOfAny
                    If strParam1 <> String.Empty Then
                        If strParam2 <> String.Empty And strParam3 <> String.Empty Then
                            HandleResultsLabel("LastIndexOfAny", AddQuotes(strParam1), strParam2, strParam3)
                            lblResults.Text = strSample.LastIndexOfAny(strParam1.ToCharArray, CInt(strParam2), CInt(strParam3)).ToString
                        ElseIf strParam2 <> String.Empty Then
                            HandleResultsLabel("LastIndexOfAny", AddQuotes(strParam1), strParam2)
                            lblResults.Text = strSample.LastIndexOfAny(strParam1.ToCharArray, CInt(strParam2)).ToString
                        Else
                            HandleResultsLabel("LastIndexOfAny", AddQuotes(strParam1))
                            lblResults.Text = strSample.LastIndexOfAny(strParam1.ToCharArray).ToString
                        End If
                    End If

                Case SelectedMethod.PadLeft
                    If strParam2 = String.Empty Then
                        ' If you leave off the second parameter, String.PadLeft
                        ' uses a space character.
                        HandleResultsLabel("PadLeft", strParam1)
                        lblResults.Text = strSample.PadLeft(CInt(strParam1))
                    Else
                        HandleResultsLabel("PadLeft", strParam1, AddQuotes(strParam2))
                        lblResults.Text = strSample.PadLeft(CInt(strParam1), CChar(strParam2))
                    End If

                Case SelectedMethod.PadRight
                    ' If you leave off the second parameter, String.PadRight
                    ' uses a space character.
                    If strParam2 = String.Empty Then
                        HandleResultsLabel("PadRight", strParam1)
                        lblResults.Text = strSample.PadRight(CInt(strParam1))
                    Else
                        HandleResultsLabel("PadRight", strParam1, AddQuotes(strParam2))
                        lblResults.Text = strSample.PadRight(CInt(strParam1), CChar(strParam2))
                    End If

                Case SelectedMethod.Remove
                    HandleResultsLabel("Remove", strParam1, strParam2)
                    lblResults.Text = strSample.Remove(CInt(strParam1), CInt(strParam2))

                Case SelectedMethod.Replace
                    HandleResultsLabel("Replace", AddQuotes(strParam1), AddQuotes(strParam2))
                    lblResults.Text = strSample.Replace(strParam1, strParam2)

                Case SelectedMethod.Split
                    ' Display an array of strings, formatted 
                    ' like this:
                    ' {"item1", "item2", "item3"}
                    ' This example uses the Join method, as well
                    ' as the Split method.  
                    If strParam2 = String.Empty Then
                        HandleResultsLabel("Split", AddQuotes(strParam1))
                        lblResults.Text = "{" & QUOTE & String.Join(QUOTE & "," & QUOTE, strSample.Split(strParam1.ToCharArray)) & QUOTE & "}"
                    Else
                        HandleResultsLabel("Split", AddQuotes(strParam1), strParam2)
                        lblResults.Text = "{" & QUOTE & String.Join(QUOTE & "," & QUOTE, strSample.Split(strParam1.ToCharArray, CInt(strParam2))) & QUOTE & "}"
                    End If

                Case SelectedMethod.StartsWith
                    HandleResultsLabel("StartsWith", AddQuotes(strParam1))
                    lblResults.Text = strSample.StartsWith(strParam1).ToString

                Case SelectedMethod.Substring
                    ' If you leave off the second parameter, 
                    ' String.Substring returns all the remaining characters.
                    If strParam2 = String.Empty Then
                        HandleResultsLabel("Substring", strParam1)
                        lblResults.Text = strSample.Substring(CInt(strParam1))
                    Else
                        HandleResultsLabel("Substring", strParam1, strParam2)
                        lblResults.Text = strSample.Substring(CInt(strParam1), CInt(strParam2))
                    End If

                Case SelectedMethod.ToLower
                    HandleResultsLabel("ToLower")
                    lblResults.Text = strSample.ToLower

                Case SelectedMethod.ToUpper
                    HandleResultsLabel("ToUpper")
                    lblResults.Text = strSample.ToUpper

                Case SelectedMethod.Trim
                    ' If you don't pass a parameter, Trim
                    ' assumes you want to trim spaces only.
                    If strParam1 = String.Empty Then
                        HandleResultsLabel("Trim")
                        lblResults.Text = strSample.Trim()
                    Else
                        HandleResultsLabel("Trim", AddQuotes(strParam1))
                        lblResults.Text = strSample.Trim(strParam1.ToCharArray())
                    End If

                Case SelectedMethod.TrimEnd
                    ' If you don't pass a parameter, TrimEnd
                    ' assumes you want to trim spaces only.
                    If strParam1 = String.Empty Then
                        HandleResultsLabel("TrimEnd")
                        lblResults.Text = strSample.TrimEnd()
                    Else
                        HandleResultsLabel("TrimEnd", AddQuotes(strParam1))
                        lblResults.Text = strSample.TrimEnd(strParam1.ToCharArray())
                    End If

                Case SelectedMethod.TrimStart
                    ' If you don't pass a parameter, Trim
                    ' assumes you want to trim spaces only.
                    If strParam1 = String.Empty Then
                        HandleResultsLabel("TrimStart")
                        lblResults.Text = strSample.TrimStart()
                    Else
                        HandleResultsLabel("TrimStart", AddQuotes(strParam1))
                        lblResults.Text = strSample.TrimStart(strParam1.ToCharArray())
                    End If
            End Select

        Catch exp As Exception
            ' If any error occurs, display the information.
            lblResultsLabel.Text = "<<ERROR>>"
            lblResults.Text = exp.Message
        End Try
    End Sub

    Private Sub RefreshText()
        txtSample.Text = mstrSample
    End Sub

    Private Sub SetResultsLabel(ByVal Source As String, ByVal Method As String, ByVal Parameters As String)
        lblResultsLabel.Text = String.Format("Results of {0}.{1}({2})", Source, Method, Parameters)
    End Sub

End Class