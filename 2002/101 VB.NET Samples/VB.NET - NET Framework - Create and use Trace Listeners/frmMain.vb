'Copyright (C) 2002 Microsoft Corporation
'All rights reserved.
'THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, EITHER 
'EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED WARRANTIES OF 
'MERCHANTIBILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.

'Requires the Trial or Release version of Visual Studio .NET Professional 
'(or greater).

Option Strict On

Imports System
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
    Friend WithEvents cmdTraceToOutput As System.Windows.Forms.Button
    Friend WithEvents cmdTraceToEventLog As System.Windows.Forms.Button
    Friend WithEvents cmdTraceToFile As System.Windows.Forms.Button
    Friend WithEvents cmdTraceToHTML As System.Windows.Forms.Button
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmMain))
        Me.mnuMain = New System.Windows.Forms.MainMenu()
        Me.mnuFile = New System.Windows.Forms.MenuItem()
        Me.mnuExit = New System.Windows.Forms.MenuItem()
        Me.mnuHelp = New System.Windows.Forms.MenuItem()
        Me.mnuAbout = New System.Windows.Forms.MenuItem()
        Me.cmdTraceToOutput = New System.Windows.Forms.Button()
        Me.cmdTraceToEventLog = New System.Windows.Forms.Button()
        Me.cmdTraceToFile = New System.Windows.Forms.Button()
        Me.cmdTraceToHTML = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'mnuMain
        '
        Me.mnuMain.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.mnuFile, Me.mnuHelp})
        Me.mnuMain.RightToLeft = CType(resources.GetObject("mnuMain.RightToLeft"), System.Windows.Forms.RightToLeft)
        '
        'mnuFile
        '
        Me.mnuFile.Enabled = CType(resources.GetObject("mnuFile.Enabled"), Boolean)
        Me.mnuFile.Index = 0
        Me.mnuFile.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.mnuExit})
        Me.mnuFile.Shortcut = CType(resources.GetObject("mnuFile.Shortcut"), System.Windows.Forms.Shortcut)
        Me.mnuFile.ShowShortcut = CType(resources.GetObject("mnuFile.ShowShortcut"), Boolean)
        Me.mnuFile.Text = resources.GetString("mnuFile.Text")
        Me.mnuFile.Visible = CType(resources.GetObject("mnuFile.Visible"), Boolean)
        '
        'mnuExit
        '
        Me.mnuExit.Enabled = CType(resources.GetObject("mnuExit.Enabled"), Boolean)
        Me.mnuExit.Index = 0
        Me.mnuExit.Shortcut = CType(resources.GetObject("mnuExit.Shortcut"), System.Windows.Forms.Shortcut)
        Me.mnuExit.ShowShortcut = CType(resources.GetObject("mnuExit.ShowShortcut"), Boolean)
        Me.mnuExit.Text = resources.GetString("mnuExit.Text")
        Me.mnuExit.Visible = CType(resources.GetObject("mnuExit.Visible"), Boolean)
        '
        'mnuHelp
        '
        Me.mnuHelp.Enabled = CType(resources.GetObject("mnuHelp.Enabled"), Boolean)
        Me.mnuHelp.Index = 1
        Me.mnuHelp.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.mnuAbout})
        Me.mnuHelp.Shortcut = CType(resources.GetObject("mnuHelp.Shortcut"), System.Windows.Forms.Shortcut)
        Me.mnuHelp.ShowShortcut = CType(resources.GetObject("mnuHelp.ShowShortcut"), Boolean)
        Me.mnuHelp.Text = resources.GetString("mnuHelp.Text")
        Me.mnuHelp.Visible = CType(resources.GetObject("mnuHelp.Visible"), Boolean)
        '
        'mnuAbout
        '
        Me.mnuAbout.Enabled = CType(resources.GetObject("mnuAbout.Enabled"), Boolean)
        Me.mnuAbout.Index = 0
        Me.mnuAbout.Shortcut = CType(resources.GetObject("mnuAbout.Shortcut"), System.Windows.Forms.Shortcut)
        Me.mnuAbout.ShowShortcut = CType(resources.GetObject("mnuAbout.ShowShortcut"), Boolean)
        Me.mnuAbout.Text = resources.GetString("mnuAbout.Text")
        Me.mnuAbout.Visible = CType(resources.GetObject("mnuAbout.Visible"), Boolean)
        '
        'cmdTraceToOutput
        '
        Me.cmdTraceToOutput.AccessibleDescription = resources.GetString("cmdTraceToOutput.AccessibleDescription")
        Me.cmdTraceToOutput.AccessibleName = resources.GetString("cmdTraceToOutput.AccessibleName")
        Me.cmdTraceToOutput.Anchor = CType(resources.GetObject("cmdTraceToOutput.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.cmdTraceToOutput.BackgroundImage = CType(resources.GetObject("cmdTraceToOutput.BackgroundImage"), System.Drawing.Image)
        Me.cmdTraceToOutput.Dock = CType(resources.GetObject("cmdTraceToOutput.Dock"), System.Windows.Forms.DockStyle)
        Me.cmdTraceToOutput.Enabled = CType(resources.GetObject("cmdTraceToOutput.Enabled"), Boolean)
        Me.cmdTraceToOutput.FlatStyle = CType(resources.GetObject("cmdTraceToOutput.FlatStyle"), System.Windows.Forms.FlatStyle)
        Me.cmdTraceToOutput.Font = CType(resources.GetObject("cmdTraceToOutput.Font"), System.Drawing.Font)
        Me.cmdTraceToOutput.Image = CType(resources.GetObject("cmdTraceToOutput.Image"), System.Drawing.Image)
        Me.cmdTraceToOutput.ImageAlign = CType(resources.GetObject("cmdTraceToOutput.ImageAlign"), System.Drawing.ContentAlignment)
        Me.cmdTraceToOutput.ImageIndex = CType(resources.GetObject("cmdTraceToOutput.ImageIndex"), Integer)
        Me.cmdTraceToOutput.ImeMode = CType(resources.GetObject("cmdTraceToOutput.ImeMode"), System.Windows.Forms.ImeMode)
        Me.cmdTraceToOutput.Location = CType(resources.GetObject("cmdTraceToOutput.Location"), System.Drawing.Point)
        Me.cmdTraceToOutput.Name = "cmdTraceToOutput"
        Me.cmdTraceToOutput.RightToLeft = CType(resources.GetObject("cmdTraceToOutput.RightToLeft"), System.Windows.Forms.RightToLeft)
        Me.cmdTraceToOutput.Size = CType(resources.GetObject("cmdTraceToOutput.Size"), System.Drawing.Size)
        Me.cmdTraceToOutput.TabIndex = CType(resources.GetObject("cmdTraceToOutput.TabIndex"), Integer)
        Me.cmdTraceToOutput.Text = resources.GetString("cmdTraceToOutput.Text")
        Me.cmdTraceToOutput.TextAlign = CType(resources.GetObject("cmdTraceToOutput.TextAlign"), System.Drawing.ContentAlignment)
        Me.cmdTraceToOutput.Visible = CType(resources.GetObject("cmdTraceToOutput.Visible"), Boolean)
        '
        'cmdTraceToEventLog
        '
        Me.cmdTraceToEventLog.AccessibleDescription = resources.GetString("cmdTraceToEventLog.AccessibleDescription")
        Me.cmdTraceToEventLog.AccessibleName = resources.GetString("cmdTraceToEventLog.AccessibleName")
        Me.cmdTraceToEventLog.Anchor = CType(resources.GetObject("cmdTraceToEventLog.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.cmdTraceToEventLog.BackgroundImage = CType(resources.GetObject("cmdTraceToEventLog.BackgroundImage"), System.Drawing.Image)
        Me.cmdTraceToEventLog.Dock = CType(resources.GetObject("cmdTraceToEventLog.Dock"), System.Windows.Forms.DockStyle)
        Me.cmdTraceToEventLog.Enabled = CType(resources.GetObject("cmdTraceToEventLog.Enabled"), Boolean)
        Me.cmdTraceToEventLog.FlatStyle = CType(resources.GetObject("cmdTraceToEventLog.FlatStyle"), System.Windows.Forms.FlatStyle)
        Me.cmdTraceToEventLog.Font = CType(resources.GetObject("cmdTraceToEventLog.Font"), System.Drawing.Font)
        Me.cmdTraceToEventLog.Image = CType(resources.GetObject("cmdTraceToEventLog.Image"), System.Drawing.Image)
        Me.cmdTraceToEventLog.ImageAlign = CType(resources.GetObject("cmdTraceToEventLog.ImageAlign"), System.Drawing.ContentAlignment)
        Me.cmdTraceToEventLog.ImageIndex = CType(resources.GetObject("cmdTraceToEventLog.ImageIndex"), Integer)
        Me.cmdTraceToEventLog.ImeMode = CType(resources.GetObject("cmdTraceToEventLog.ImeMode"), System.Windows.Forms.ImeMode)
        Me.cmdTraceToEventLog.Location = CType(resources.GetObject("cmdTraceToEventLog.Location"), System.Drawing.Point)
        Me.cmdTraceToEventLog.Name = "cmdTraceToEventLog"
        Me.cmdTraceToEventLog.RightToLeft = CType(resources.GetObject("cmdTraceToEventLog.RightToLeft"), System.Windows.Forms.RightToLeft)
        Me.cmdTraceToEventLog.Size = CType(resources.GetObject("cmdTraceToEventLog.Size"), System.Drawing.Size)
        Me.cmdTraceToEventLog.TabIndex = CType(resources.GetObject("cmdTraceToEventLog.TabIndex"), Integer)
        Me.cmdTraceToEventLog.Text = resources.GetString("cmdTraceToEventLog.Text")
        Me.cmdTraceToEventLog.TextAlign = CType(resources.GetObject("cmdTraceToEventLog.TextAlign"), System.Drawing.ContentAlignment)
        Me.cmdTraceToEventLog.Visible = CType(resources.GetObject("cmdTraceToEventLog.Visible"), Boolean)
        '
        'cmdTraceToFile
        '
        Me.cmdTraceToFile.AccessibleDescription = resources.GetString("cmdTraceToFile.AccessibleDescription")
        Me.cmdTraceToFile.AccessibleName = resources.GetString("cmdTraceToFile.AccessibleName")
        Me.cmdTraceToFile.Anchor = CType(resources.GetObject("cmdTraceToFile.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.cmdTraceToFile.BackgroundImage = CType(resources.GetObject("cmdTraceToFile.BackgroundImage"), System.Drawing.Image)
        Me.cmdTraceToFile.Dock = CType(resources.GetObject("cmdTraceToFile.Dock"), System.Windows.Forms.DockStyle)
        Me.cmdTraceToFile.Enabled = CType(resources.GetObject("cmdTraceToFile.Enabled"), Boolean)
        Me.cmdTraceToFile.FlatStyle = CType(resources.GetObject("cmdTraceToFile.FlatStyle"), System.Windows.Forms.FlatStyle)
        Me.cmdTraceToFile.Font = CType(resources.GetObject("cmdTraceToFile.Font"), System.Drawing.Font)
        Me.cmdTraceToFile.Image = CType(resources.GetObject("cmdTraceToFile.Image"), System.Drawing.Image)
        Me.cmdTraceToFile.ImageAlign = CType(resources.GetObject("cmdTraceToFile.ImageAlign"), System.Drawing.ContentAlignment)
        Me.cmdTraceToFile.ImageIndex = CType(resources.GetObject("cmdTraceToFile.ImageIndex"), Integer)
        Me.cmdTraceToFile.ImeMode = CType(resources.GetObject("cmdTraceToFile.ImeMode"), System.Windows.Forms.ImeMode)
        Me.cmdTraceToFile.Location = CType(resources.GetObject("cmdTraceToFile.Location"), System.Drawing.Point)
        Me.cmdTraceToFile.Name = "cmdTraceToFile"
        Me.cmdTraceToFile.RightToLeft = CType(resources.GetObject("cmdTraceToFile.RightToLeft"), System.Windows.Forms.RightToLeft)
        Me.cmdTraceToFile.Size = CType(resources.GetObject("cmdTraceToFile.Size"), System.Drawing.Size)
        Me.cmdTraceToFile.TabIndex = CType(resources.GetObject("cmdTraceToFile.TabIndex"), Integer)
        Me.cmdTraceToFile.Text = resources.GetString("cmdTraceToFile.Text")
        Me.cmdTraceToFile.TextAlign = CType(resources.GetObject("cmdTraceToFile.TextAlign"), System.Drawing.ContentAlignment)
        Me.cmdTraceToFile.Visible = CType(resources.GetObject("cmdTraceToFile.Visible"), Boolean)
        '
        'cmdTraceToHTML
        '
        Me.cmdTraceToHTML.AccessibleDescription = resources.GetString("cmdTraceToHTML.AccessibleDescription")
        Me.cmdTraceToHTML.AccessibleName = resources.GetString("cmdTraceToHTML.AccessibleName")
        Me.cmdTraceToHTML.Anchor = CType(resources.GetObject("cmdTraceToHTML.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.cmdTraceToHTML.BackgroundImage = CType(resources.GetObject("cmdTraceToHTML.BackgroundImage"), System.Drawing.Image)
        Me.cmdTraceToHTML.Dock = CType(resources.GetObject("cmdTraceToHTML.Dock"), System.Windows.Forms.DockStyle)
        Me.cmdTraceToHTML.Enabled = CType(resources.GetObject("cmdTraceToHTML.Enabled"), Boolean)
        Me.cmdTraceToHTML.FlatStyle = CType(resources.GetObject("cmdTraceToHTML.FlatStyle"), System.Windows.Forms.FlatStyle)
        Me.cmdTraceToHTML.Font = CType(resources.GetObject("cmdTraceToHTML.Font"), System.Drawing.Font)
        Me.cmdTraceToHTML.Image = CType(resources.GetObject("cmdTraceToHTML.Image"), System.Drawing.Image)
        Me.cmdTraceToHTML.ImageAlign = CType(resources.GetObject("cmdTraceToHTML.ImageAlign"), System.Drawing.ContentAlignment)
        Me.cmdTraceToHTML.ImageIndex = CType(resources.GetObject("cmdTraceToHTML.ImageIndex"), Integer)
        Me.cmdTraceToHTML.ImeMode = CType(resources.GetObject("cmdTraceToHTML.ImeMode"), System.Windows.Forms.ImeMode)
        Me.cmdTraceToHTML.Location = CType(resources.GetObject("cmdTraceToHTML.Location"), System.Drawing.Point)
        Me.cmdTraceToHTML.Name = "cmdTraceToHTML"
        Me.cmdTraceToHTML.RightToLeft = CType(resources.GetObject("cmdTraceToHTML.RightToLeft"), System.Windows.Forms.RightToLeft)
        Me.cmdTraceToHTML.Size = CType(resources.GetObject("cmdTraceToHTML.Size"), System.Drawing.Size)
        Me.cmdTraceToHTML.TabIndex = CType(resources.GetObject("cmdTraceToHTML.TabIndex"), Integer)
        Me.cmdTraceToHTML.Text = resources.GetString("cmdTraceToHTML.Text")
        Me.cmdTraceToHTML.TextAlign = CType(resources.GetObject("cmdTraceToHTML.TextAlign"), System.Drawing.ContentAlignment)
        Me.cmdTraceToHTML.Visible = CType(resources.GetObject("cmdTraceToHTML.Visible"), Boolean)
        '
        'frmMain
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
        Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.cmdTraceToHTML, Me.cmdTraceToFile, Me.cmdTraceToEventLog, Me.cmdTraceToOutput})
        Me.Dock = CType(resources.GetObject("$this.Dock"), System.Windows.Forms.DockStyle)
        Me.Enabled = CType(resources.GetObject("$this.Enabled"), Boolean)
        Me.Font = CType(resources.GetObject("$this.Font"), System.Drawing.Font)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.ImeMode = CType(resources.GetObject("$this.ImeMode"), System.Windows.Forms.ImeMode)
        Me.Location = CType(resources.GetObject("$this.Location"), System.Drawing.Point)
        Me.MaximizeBox = False
        Me.MaximumSize = CType(resources.GetObject("$this.MaximumSize"), System.Drawing.Size)
        Me.Menu = Me.mnuMain
        Me.MinimumSize = CType(resources.GetObject("$this.MinimumSize"), System.Drawing.Size)
        Me.Name = "frmMain"
        Me.RightToLeft = CType(resources.GetObject("$this.RightToLeft"), System.Windows.Forms.RightToLeft)
        Me.StartPosition = CType(resources.GetObject("$this.StartPosition"), System.Windows.Forms.FormStartPosition)
        Me.Text = resources.GetString("$this.Text")
        Me.Visible = CType(resources.GetObject("$this.Visible"), Boolean)
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

    Private Sub cmdTraceToEventLog_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdTraceToEventLog.Click
        ' This Sub demonstrates how to create and add a trace 
        ' listener that sends messages to the application
        ' event log.  This should be used sparingly due to the 
        ' resources it uses to write to the event log.

        ' Create an EventLog instance and assign it a source.
        Dim myLog As New EventLog()
        myLog.Source = Me.Text

        ' Create a trace listener for the application event log.
        Dim tlEventLog As New EventLogTraceListener(myLog)

        Trace.Listeners.Clear()

        ' Add the event log trace listener to the collection.
        Trace.Listeners.Add(tlEventLog)

        ' Write output to the event log.
        Trace.WriteLine("This is a test of event log tracing")

    End Sub

    Private Sub cmdTraceToFile_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdTraceToFile.Click
        ' This sub shows how to add a trace listener that sends 
        ' the trace output to a text file called TraceOutput.txt.
        ' This file is created in the same folder as the EXE which 
        ' is usually the bin folder where the project is saved.

        ' Create a file for output named TraceOutput.txt.
        Dim traceFile As System.IO.Stream = File.Create("TraceOutput.txt")

        ' Dim some variables to display in trace output
        Dim ProductType As String = "Computer"
        Dim Price As Integer = 2000
        Dim UnitsInStock As Integer = 23

        ' Create an instance of the text writer trace listener to 
        ' output to a text file
        Dim tlTextFile As New TextWriterTraceListener(traceFile)

        ' Clear the listeners collection
        Trace.Listeners.Clear()
        Trace.Listeners.Add(tlTextFile)

        ' WriteLine will output a mesaage and will issue a carriage 
        ' return line feed
        Trace.WriteLine("******  Trace Output to File ******")
        Trace.WriteLine("Trace output for " & Me.Text)
        Trace.WriteLine("")

        ' This will indent all lines until Unindent is called
        Trace.Indent()
        Trace.WriteLine("This line is indented")
        Trace.WriteLine("Product Type = " & ProductType)
        Trace.WriteLine("Price = $" & Price)

        ' WriteLineIf is a condition way of sending messages to the trace
        ' when the first argument evaluates to True
        Trace.WriteLineIf(Price > 1800, "Price > $1800")
        Trace.Unindent()

        ' Flush and close the output.
        tlTextFile.Flush()
        tlTextFile.Close()

        ' Show text file output
        System.Diagnostics.Process.Start("Notepad.exe", "TraceOutput.txt")

    End Sub

    Private Sub cmdTraceToHTML_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdTraceToHTML.Click
        ' This sub shows how to add a custom trace listener that 
        ' sends the trace output to a HTML file called TraceOutputHTML.htm
        ' This file is created in the same folder as your EXE which 
        ' is usually the bin folder under where the project is saved.

        ' Create a file for output named TraceOutputHTML.htm
        Dim traceFile As System.IO.Stream = File.Create("TraceOutputHTML.htm")

        ' Dim some variables to display in trace output
        Dim ProductType As String = "Computer"
        Dim Price As Integer = 2000
        Dim UnitsInStock As Integer = 23

        ' Create an instance of the text writer trace listener to 
        ' output to a text file
        Dim tlHTMLFile As New HTMLTraceListener(traceFile)
        tlHTMLFile.WriteHeader("HTML Trace Output Example for " & Me.Text)

        ' Clear the listeners collection
        Trace.Listeners.Clear()
        Trace.Listeners.Add(tlHTMLFile)

        ' This will indent all lines until Unindent is called
        Trace.Indent()
        Trace.WriteLine("This line is indented")
        Trace.Unindent()
        Trace.WriteLine("Product Type = " & ProductType)
        Trace.WriteLine("Price = $" & Price)

        ' WriteLineIf is a condition way of sending messages to the trace
        ' when the first argument evaluates to True
        Trace.WriteLineIf(Price > 1800, "Price > $1800")

        ' Flush and close the output.
        tlHTMLFile.Flush()
        tlHTMLFile.Close()

        ' Launch default browser to show file output
        System.Diagnostics.Process.Start("TraceOutputHTML.htm")

    End Sub

    Private Sub cmdTraceToOutput_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdTraceToOutput.Click
        ' This sub shows how to use the default trace listener that 
        ' sends the trace output to the Output window in the IDE.  
        ' It also shows how to readd the default trace listener if the 
        ' trace listeners collection has been cleared. The default trace 
        ' listener by default is added to the trace listeners collection.

        ' Dim some variables to display in trace output
        Dim ProductType As String = "Computer"
        Dim Price As Integer = 2000
        Dim UnitsInStock As Integer = 23

        ' Create instance of the default trace listener
        Dim tlDefault As New DefaultTraceListener()

        ' Clear all trace listeners from the collection
        Trace.Listeners.Clear()

        ' Add the default listener to the collection
        Trace.Listeners.Add(tlDefault)

        ' WriteLine will output a mesaage and will issue a 
        ' carriage return line feed
        Trace.WriteLine("******  Trace OutPut Start  ******")
        Trace.WriteLine("Output window trace information")

        ' This will indent all lines until Unindent is called
        Trace.Indent()
        Trace.WriteLine("This line is indented")
        Trace.WriteLine("Product Type = " & ProductType)
        Trace.WriteLine("Price = $" & Price)

        ' WriteLineIf is a condition way of sending messages to the trace
        ' when the first argument evaluates to True
        Trace.WriteLineIf(Price > 1800, "Price > $1800")
        Trace.Unindent()
        Trace.WriteLine("******   Trace Output End   ******")

    End Sub

End Class