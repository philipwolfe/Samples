Public Class MainForm

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ' Load some default text.
        EntryArea.Rtf = "{\rtf1\ansi \b me\b0  is a \ul RichTextBox\ul0. \i Try\i0  some \b formatting\b0!  Also try the right-click Context Menu.}"

        ' By default the Form's opacity is set to 100%, so show this option checked.
        Me.OnehundredPercent.Checked = True
    End Sub

    Private Sub fileMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles newToolStripMenuItem.Click, saveToolStripMenuItem.Click, openToolStripMenuItem.Click, exitToolStripMenuItem.Click
        manipulateFile(CType(sender, ToolStripMenuItem).Text)
    End Sub

    Private Sub fileToolStrip_ItemClicked(ByVal sender As System.Object, ByVal e As ToolStripItemClickedEventArgs) Handles fileToolStrip.ItemClicked
        manipulateFile(CType(e.ClickedItem, ToolStripItem).Text)
    End Sub

    Private Sub formatMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles boldToolStripMenuItem.Click, underlineToolStripMenuItem.Click, italicsToolStripMenuItem.Click
        formatText(CType(sender, ToolStripItem).Text)
    End Sub

    Private Sub formatToolStrip_ItemClicked(ByVal sender As System.Object, ByVal e As ToolStripItemClickedEventArgs) Handles formatToolStrip.ItemClicked
        formatText(CType(e.ClickedItem, ToolStripItem).Text)
    End Sub

    Private Sub changeOpacityToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TwentyfivePercent.Click, OnehundredPercent.Click, seventyfivePercent.Click, fiftyPercent.Click
        Dim menuItem As ToolStripMenuItem = CType(sender, ToolStripMenuItem)
        Dim opacity As Double = Convert.ToDouble(menuItem.Tag.ToString())
        Me.Opacity = opacity

        ' The Opacity settings are exclusive of each other. Ensure only the current 
        ' setting is checked.
        Dim menuChangeOpacity As ToolStripMenuItem = CType(optionsToolStripMenuItem.DropDownItems(1), ToolStripMenuItem)
        For Each item As ToolStripMenuItem In menuChangeOpacity.DropDownItems
            item.Checked = False
        Next
        MenuItem.Checked = True
    End Sub

    ' This method handles the text formatting operations for the 
    ' Format menu strip, tool bar, and context menu.
    Private Sub formatText(ByVal menuItemText As String)
        Dim fontOfSelectedText As Font = Me.EntryArea.SelectionFont
        Dim styleApplied As FontStyle

        Select Case (menuItemText)
            Case "&Bold"
                If Me.EntryArea.SelectionFont.Bold = True Then
                    styleApplied = FontStyle.Regular
                Else
                    styleApplied = FontStyle.Bold
                End If

                Exit Select
            Case "&Italics"
                If Me.EntryArea.SelectionFont.Italic = True Then
                    styleApplied = FontStyle.Regular
                Else
                    styleApplied = FontStyle.Italic
                End If

                Exit Select
            Case Else
                If Me.EntryArea.SelectionFont.Underline = True Then
                    styleApplied = FontStyle.Regular
                Else
                    styleApplied = FontStyle.Underline
                End If
        End Select

        Dim FontToApply As New Font(fontOfSelectedText, styleApplied)
        Me.EntryArea.SelectionFont = FontToApply
    End Sub

    ' This method handles the file manipulation operations for both the 
    ' File menu strip and tool bar.
    Private Sub manipulateFile(ByVal menuItemText As String)
        Select Case menuItemText
            Case "&New"
                ' Simulate creating a new document by merely clearing the existing text.
                EntryArea.Text = ""
                EntryArea.Focus()

                Exit Select
            Case "&Open"
                If Me.openFileDialog.ShowDialog() = DialogResult.OK Then
                    MessageBox.Show("The Open button was clicked, but for sample purposes " + _
                        vbCrLf + "the " + Me.openFileDialog.FileName + " file is not opened.", "Sample Info", MessageBoxButtons.OK, MessageBoxIcon.Information)
                End If

                Exit Select
            Case "&Save"
                If Me.saveFileDialog.ShowDialog() = DialogResult.OK Then
                    MessageBox.Show("The Save button was clicked, but for sample purposes " + _
                        vbCrLf + "the " + Me.saveFileDialog.FileName + " file does not save.", "Sample Info", MessageBoxButtons.OK, MessageBoxIcon.Information)
                End If

                Exit Select
            Case Else
                Me.Close()
                Me.Dispose()
        End Select
    End Sub

    Public Sub TestProgressBar()
        ' Do a loop to simulate a lengthy task and make the progress bar
        ' show progress to its maximum value.
        While (toolStripProgressBar.Value < toolStripProgressBar.Maximum)
            System.Threading.Thread.Sleep(10)
            toolStripProgressBar.Value += 1
        End While

        ' Reset the progress bar.
        toolStripProgressBar.Value = toolStripProgressBar.Minimum
    End Sub

    Private Sub testProgressBarToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles testProgressBarToolStripMenuItem.Click
        TestProgressBar()
    End Sub
End Class
