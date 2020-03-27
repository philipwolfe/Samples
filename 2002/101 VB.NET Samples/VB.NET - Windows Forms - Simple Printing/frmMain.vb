'Copyright (C) 2002 Microsoft Corporation
'All rights reserved.
'THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, EITHER 
'EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED WARRANTIES OF 
'MERCHANTIBILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.

'Requires the Trial or Release version of Visual Studio .NET Professional (or greater).

Option Strict On
Imports System.Drawing.Printing

Public Class frmMain
    Inherits System.Windows.Forms.Form

    ' It's important that all the event procedures work with the same PrintDocument
    ' object.
    Private WithEvents pdoc As New PrintDocument()

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
    Friend WithEvents btnPageSetup As System.Windows.Forms.Button
    Friend WithEvents btnPrintDialog As System.Windows.Forms.Button
    Friend WithEvents btnPrintPreview As System.Windows.Forms.Button
    Friend WithEvents odlgDocument As System.Windows.Forms.OpenFileDialog
    Friend WithEvents txtDocument As System.Windows.Forms.TextBox
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmMain))
        Me.mnuMain = New System.Windows.Forms.MainMenu()
        Me.mnuFile = New System.Windows.Forms.MenuItem()
        Me.mnuExit = New System.Windows.Forms.MenuItem()
        Me.mnuHelp = New System.Windows.Forms.MenuItem()
        Me.mnuAbout = New System.Windows.Forms.MenuItem()
        Me.btnPageSetup = New System.Windows.Forms.Button()
        Me.btnPrintDialog = New System.Windows.Forms.Button()
        Me.btnPrintPreview = New System.Windows.Forms.Button()
        Me.odlgDocument = New System.Windows.Forms.OpenFileDialog()
        Me.txtDocument = New System.Windows.Forms.TextBox()
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
        'btnPageSetup
        '
        Me.btnPageSetup.AccessibleDescription = resources.GetString("btnPageSetup.AccessibleDescription")
        Me.btnPageSetup.AccessibleName = resources.GetString("btnPageSetup.AccessibleName")
        Me.btnPageSetup.Anchor = CType(resources.GetObject("btnPageSetup.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.btnPageSetup.BackgroundImage = CType(resources.GetObject("btnPageSetup.BackgroundImage"), System.Drawing.Image)
        Me.btnPageSetup.Dock = CType(resources.GetObject("btnPageSetup.Dock"), System.Windows.Forms.DockStyle)
        Me.btnPageSetup.Enabled = CType(resources.GetObject("btnPageSetup.Enabled"), Boolean)
        Me.btnPageSetup.FlatStyle = CType(resources.GetObject("btnPageSetup.FlatStyle"), System.Windows.Forms.FlatStyle)
        Me.btnPageSetup.Font = CType(resources.GetObject("btnPageSetup.Font"), System.Drawing.Font)
        Me.btnPageSetup.Image = CType(resources.GetObject("btnPageSetup.Image"), System.Drawing.Image)
        Me.btnPageSetup.ImageAlign = CType(resources.GetObject("btnPageSetup.ImageAlign"), System.Drawing.ContentAlignment)
        Me.btnPageSetup.ImageIndex = CType(resources.GetObject("btnPageSetup.ImageIndex"), Integer)
        Me.btnPageSetup.ImeMode = CType(resources.GetObject("btnPageSetup.ImeMode"), System.Windows.Forms.ImeMode)
        Me.btnPageSetup.Location = CType(resources.GetObject("btnPageSetup.Location"), System.Drawing.Point)
        Me.btnPageSetup.Name = "btnPageSetup"
        Me.btnPageSetup.RightToLeft = CType(resources.GetObject("btnPageSetup.RightToLeft"), System.Windows.Forms.RightToLeft)
        Me.btnPageSetup.Size = CType(resources.GetObject("btnPageSetup.Size"), System.Drawing.Size)
        Me.btnPageSetup.TabIndex = CType(resources.GetObject("btnPageSetup.TabIndex"), Integer)
        Me.btnPageSetup.Text = resources.GetString("btnPageSetup.Text")
        Me.btnPageSetup.TextAlign = CType(resources.GetObject("btnPageSetup.TextAlign"), System.Drawing.ContentAlignment)
        Me.btnPageSetup.Visible = CType(resources.GetObject("btnPageSetup.Visible"), Boolean)
        '
        'btnPrintDialog
        '
        Me.btnPrintDialog.AccessibleDescription = resources.GetString("btnPrintDialog.AccessibleDescription")
        Me.btnPrintDialog.AccessibleName = resources.GetString("btnPrintDialog.AccessibleName")
        Me.btnPrintDialog.Anchor = CType(resources.GetObject("btnPrintDialog.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.btnPrintDialog.BackgroundImage = CType(resources.GetObject("btnPrintDialog.BackgroundImage"), System.Drawing.Image)
        Me.btnPrintDialog.Dock = CType(resources.GetObject("btnPrintDialog.Dock"), System.Windows.Forms.DockStyle)
        Me.btnPrintDialog.Enabled = CType(resources.GetObject("btnPrintDialog.Enabled"), Boolean)
        Me.btnPrintDialog.FlatStyle = CType(resources.GetObject("btnPrintDialog.FlatStyle"), System.Windows.Forms.FlatStyle)
        Me.btnPrintDialog.Font = CType(resources.GetObject("btnPrintDialog.Font"), System.Drawing.Font)
        Me.btnPrintDialog.Image = CType(resources.GetObject("btnPrintDialog.Image"), System.Drawing.Image)
        Me.btnPrintDialog.ImageAlign = CType(resources.GetObject("btnPrintDialog.ImageAlign"), System.Drawing.ContentAlignment)
        Me.btnPrintDialog.ImageIndex = CType(resources.GetObject("btnPrintDialog.ImageIndex"), Integer)
        Me.btnPrintDialog.ImeMode = CType(resources.GetObject("btnPrintDialog.ImeMode"), System.Windows.Forms.ImeMode)
        Me.btnPrintDialog.Location = CType(resources.GetObject("btnPrintDialog.Location"), System.Drawing.Point)
        Me.btnPrintDialog.Name = "btnPrintDialog"
        Me.btnPrintDialog.RightToLeft = CType(resources.GetObject("btnPrintDialog.RightToLeft"), System.Windows.Forms.RightToLeft)
        Me.btnPrintDialog.Size = CType(resources.GetObject("btnPrintDialog.Size"), System.Drawing.Size)
        Me.btnPrintDialog.TabIndex = CType(resources.GetObject("btnPrintDialog.TabIndex"), Integer)
        Me.btnPrintDialog.Text = resources.GetString("btnPrintDialog.Text")
        Me.btnPrintDialog.TextAlign = CType(resources.GetObject("btnPrintDialog.TextAlign"), System.Drawing.ContentAlignment)
        Me.btnPrintDialog.Visible = CType(resources.GetObject("btnPrintDialog.Visible"), Boolean)
        '
        'btnPrintPreview
        '
        Me.btnPrintPreview.AccessibleDescription = resources.GetString("btnPrintPreview.AccessibleDescription")
        Me.btnPrintPreview.AccessibleName = resources.GetString("btnPrintPreview.AccessibleName")
        Me.btnPrintPreview.Anchor = CType(resources.GetObject("btnPrintPreview.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.btnPrintPreview.BackgroundImage = CType(resources.GetObject("btnPrintPreview.BackgroundImage"), System.Drawing.Image)
        Me.btnPrintPreview.Dock = CType(resources.GetObject("btnPrintPreview.Dock"), System.Windows.Forms.DockStyle)
        Me.btnPrintPreview.Enabled = CType(resources.GetObject("btnPrintPreview.Enabled"), Boolean)
        Me.btnPrintPreview.FlatStyle = CType(resources.GetObject("btnPrintPreview.FlatStyle"), System.Windows.Forms.FlatStyle)
        Me.btnPrintPreview.Font = CType(resources.GetObject("btnPrintPreview.Font"), System.Drawing.Font)
        Me.btnPrintPreview.Image = CType(resources.GetObject("btnPrintPreview.Image"), System.Drawing.Image)
        Me.btnPrintPreview.ImageAlign = CType(resources.GetObject("btnPrintPreview.ImageAlign"), System.Drawing.ContentAlignment)
        Me.btnPrintPreview.ImageIndex = CType(resources.GetObject("btnPrintPreview.ImageIndex"), Integer)
        Me.btnPrintPreview.ImeMode = CType(resources.GetObject("btnPrintPreview.ImeMode"), System.Windows.Forms.ImeMode)
        Me.btnPrintPreview.Location = CType(resources.GetObject("btnPrintPreview.Location"), System.Drawing.Point)
        Me.btnPrintPreview.Name = "btnPrintPreview"
        Me.btnPrintPreview.RightToLeft = CType(resources.GetObject("btnPrintPreview.RightToLeft"), System.Windows.Forms.RightToLeft)
        Me.btnPrintPreview.Size = CType(resources.GetObject("btnPrintPreview.Size"), System.Drawing.Size)
        Me.btnPrintPreview.TabIndex = CType(resources.GetObject("btnPrintPreview.TabIndex"), Integer)
        Me.btnPrintPreview.Text = resources.GetString("btnPrintPreview.Text")
        Me.btnPrintPreview.TextAlign = CType(resources.GetObject("btnPrintPreview.TextAlign"), System.Drawing.ContentAlignment)
        Me.btnPrintPreview.Visible = CType(resources.GetObject("btnPrintPreview.Visible"), Boolean)
        '
        'odlgDocument
        '
        Me.odlgDocument.Filter = resources.GetString("odlgDocument.Filter")
        Me.odlgDocument.Title = resources.GetString("odlgDocument.Title")
        '
        'txtDocument
        '
        Me.txtDocument.AccessibleDescription = resources.GetString("txtDocument.AccessibleDescription")
        Me.txtDocument.AccessibleName = resources.GetString("txtDocument.AccessibleName")
        Me.txtDocument.Anchor = CType(resources.GetObject("txtDocument.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.txtDocument.AutoSize = CType(resources.GetObject("txtDocument.AutoSize"), Boolean)
        Me.txtDocument.BackgroundImage = CType(resources.GetObject("txtDocument.BackgroundImage"), System.Drawing.Image)
        Me.txtDocument.Dock = CType(resources.GetObject("txtDocument.Dock"), System.Windows.Forms.DockStyle)
        Me.txtDocument.Enabled = CType(resources.GetObject("txtDocument.Enabled"), Boolean)
        Me.txtDocument.Font = CType(resources.GetObject("txtDocument.Font"), System.Drawing.Font)
        Me.txtDocument.ImeMode = CType(resources.GetObject("txtDocument.ImeMode"), System.Windows.Forms.ImeMode)
        Me.txtDocument.Location = CType(resources.GetObject("txtDocument.Location"), System.Drawing.Point)
        Me.txtDocument.MaxLength = CType(resources.GetObject("txtDocument.MaxLength"), Integer)
        Me.txtDocument.Multiline = CType(resources.GetObject("txtDocument.Multiline"), Boolean)
        Me.txtDocument.Name = "txtDocument"
        Me.txtDocument.PasswordChar = CType(resources.GetObject("txtDocument.PasswordChar"), Char)
        Me.txtDocument.RightToLeft = CType(resources.GetObject("txtDocument.RightToLeft"), System.Windows.Forms.RightToLeft)
        Me.txtDocument.ScrollBars = CType(resources.GetObject("txtDocument.ScrollBars"), System.Windows.Forms.ScrollBars)
        Me.txtDocument.Size = CType(resources.GetObject("txtDocument.Size"), System.Drawing.Size)
        Me.txtDocument.TabIndex = CType(resources.GetObject("txtDocument.TabIndex"), Integer)
        Me.txtDocument.Text = resources.GetString("txtDocument.Text")
        Me.txtDocument.TextAlign = CType(resources.GetObject("txtDocument.TextAlign"), System.Windows.Forms.HorizontalAlignment)
        Me.txtDocument.Visible = CType(resources.GetObject("txtDocument.Visible"), Boolean)
        Me.txtDocument.WordWrap = CType(resources.GetObject("txtDocument.WordWrap"), Boolean)
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
        Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.txtDocument, Me.btnPageSetup, Me.btnPrintDialog, Me.btnPrintPreview})
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


    ' The PrintDialog allows the user to select the printer that they want to print 
    ' to, as well as other printing options.
    Private Sub btnPrintDialog_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPrintDialog.Click
        Dim dialog As New PrintDialog()
        dialog.Document = pdoc

        If dialog.ShowDialog = DialogResult.OK Then
            pdoc.Print()
        End If
    End Sub

    ' The PrintPreviewDialog is associated with the PrintDocument as the preview is 
    ' rendered, the PrintPage event is triggered. This event is passed a graphics 
    ' context where it "draws" the page.
    Private Sub btnPrintPreview_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPrintPreview.Click
        Dim ppd As New PrintPreviewDialog()
        Try
            ppd.Document = pdoc
            ppd.ShowDialog()
        Catch exp As Exception
            MessageBox.Show("An error occurred while trying to load the " & _
                "document for Print Preview. Make sure you currently have " & _
                "access to a printer. A printer must be connected and " & _
                "accessible for Print Preview to work.", Me.Text, _
                 MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    ' Page setup lets you specify things like the paper size, portrait, 
    ' landscape, etc.
    Private Sub btnPageSetup_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPageSetup.Click
        Dim psd As New PageSetupDialog()
        With psd
            .Document = pdoc
            .PageSettings = pdoc.DefaultPageSettings
        End With

        If psd.ShowDialog = DialogResult.OK Then
            pdoc.DefaultPageSettings = psd.PageSettings
        End If
    End Sub

    ' Handles the Form's Load event, initializing the TextBox with some text
    ' for printing.
    Private Sub frmMain_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        txtDocument.Text = _
            "Lincoln's Gettysburg Address (November 19, 1863)" & _
            vbCrLf & vbCrLf & vbTab & _
            "Four score and seven years ago our fathers brought forth on this " & _
            "continent a new nation, conceived in liberty and dedicated to the " & _
            "proposition that all men are created equal. " & _
            vbCrLf & vbCrLf & vbTab & _
            "Now we are engaged in a great civil war, testing whether that " & _
            "nation or any nation so conceived and so dedicated can long " & _
            "endure. We are met on a great battlefield of that war. We have " & _
            "come to dedicate a portion of that field as a final " & _
            "resting-place for those who here gave their lives that that " & _
            "nation might live. It is altogether fitting and proper that we " & _
            "should do this." & _
            vbCrLf & vbCrLf & vbTab & _
            "But in a larger sense, we cannot dedicate, we cannot consecrate, " & _
            "we cannot hallow this ground. The brave men, living and dead who " & _
            "struggled here have consecrated it far above our poor power to " & _
            "add or detract. The world will little note nor long remember " & _
            "what we say here, but it can never forget what they did here. " & _
            "It is for us the living rather to be dedicated here to the " & _
            "unfinished work which they who fought here have thus far so " & _
            "nobly advanced. It is rather for us to be here dedicated to " & _
            "the great task remaining before us--that from these honored " & _
            "dead we take increased devotion to that cause for which they " & _
            "gave the last full measure of devotion--that we here highly " & _
            "resolve that these dead shall not have died in vain, that this " & _
            "nation under God shall have a new birth of freedom, and that " & _
            "government of the people, by the people, for the people shall " & _
            "not perish from the earth."
    End Sub

    ' PrintPage is the foundational printing event. This event gets fired for every 
    ' page that will be printed. You could also handle the BeginPrint and EndPrint
    ' events for more control.
    ' 
    ' The following is very 
    ' fast and useful for plain text as MeasureString calculates the text that
    ' can be fitted on an entire page. This is not that useful, however, for 
    ' formatted text. In that case you would want to have word-level (vs page-level)
    ' control, which is more complicated.
    Private Sub pdoc_PrintPage(ByVal sender As Object, ByVal e As System.Drawing.Printing.PrintPageEventArgs) Handles pdoc.PrintPage
        ' Declare a variable to hold the position of the last printed char. Declare
        ' as static so that subsequent PrintPage events can reference it.
        Static intCurrentChar As Int32
        ' Initialize the font to be used for printing.
        Dim font As New font("Microsoft Sans Serif", 24)

        Dim intPrintAreaHeight, intPrintAreaWidth, marginLeft, marginTop As Int32
        With pdoc.DefaultPageSettings
            ' Initialize local variables that contain the bounds of the printing 
            ' area rectangle.
            intPrintAreaHeight = .PaperSize.Height - .Margins.Top - .Margins.Bottom
            intPrintAreaWidth = .PaperSize.Width - .Margins.Left - .Margins.Right

            ' Initialize local variables to hold margin values that will serve
            ' as the X and Y coordinates for the upper left corner of the printing 
            ' area rectangle.
            marginLeft = .Margins.Left ' X coordinate
            marginTop = .Margins.Top ' Y coordinate
        End With

        ' If the user selected Landscape mode, swap the printing area height 
        ' and width.
        If pdoc.DefaultPageSettings.Landscape Then
            Dim intTemp As Int32
            intTemp = intPrintAreaHeight
            intPrintAreaHeight = intPrintAreaWidth
            intPrintAreaWidth = intTemp
        End If

        ' Calculate the total number of lines in the document based on the height of
        ' the printing area and the height of the font.
        Dim intLineCount As Int32 = CInt(intPrintAreaHeight / font.Height)
        ' Initialize the rectangle structure that defines the printing area.
        Dim rectPrintingArea As New RectangleF(marginLeft, marginTop, intPrintAreaWidth, intPrintAreaHeight)

        ' Instantiate the StringFormat class, which encapsulates text layout 
        ' information (such as alignment and line spacing), display manipulations 
        ' (such as ellipsis insertion and national digit substitution) and OpenType 
        ' features. Use of StringFormat causes MeasureString and DrawString to use
        ' only an integer number of lines when printing each page, ignoring partial
        ' lines that would otherwise likely be printed if the number of lines per 
        ' page do not divide up cleanly for each page (which is usually the case).
        ' See further discussion in the SDK documentation about StringFormatFlags.
        Dim fmt As New StringFormat(StringFormatFlags.LineLimit)
        ' Call MeasureString to determine the number of characters that will fit in
        ' the printing area rectangle. The CharFitted Int32 is passed ByRef and used
        ' later when calculating intCurrentChar and thus HasMorePages. LinesFilled 
        ' is not needed for this sample but must be passed when passing CharsFitted.
        ' Mid is used to pass the segment of remaining text left off from the 
        ' previous page of printing (recall that intCurrentChar was declared as 
        ' static.
        Dim intLinesFilled, intCharsFitted As Int32
        e.Graphics.MeasureString(Mid(txtDocument.Text, intCurrentChar + 1), font, _
                    New SizeF(intPrintAreaWidth, intPrintAreaHeight), fmt, _
                    intCharsFitted, intLinesFilled)

        ' Print the text to the page.
        e.Graphics.DrawString(Mid(txtDocument.Text, intCurrentChar + 1), font, _
            Brushes.Black, rectPrintingArea, fmt)

        ' Advance the current char to the last char printed on this page. As 
        ' intCurrentChar is a static variable, its value can be used for the next
        ' page to be printed. It is advanced by 1 and passed to Mid() to print the
        ' next page (see above in MeasureString()).
        intCurrentChar += intCharsFitted

        ' HasMorePages tells the printing module whether another PrintPage event
        ' should be fired.
        If intCurrentChar < txtDocument.Text.Length Then
            e.HasMorePages = True
        Else
            e.HasMorePages = False
            ' You must explicitly reset intCurrentChar as it is static.
            intCurrentChar = 0
        End If
    End Sub
End Class