'*****************************************************************************
' Copyright (C) 1999-2002, Microsoft Corporation.  All Rights Reserved.
'*****************************************************************************

'Since we have case sensitive and insensitive search.
Option Compare Binary

Imports Microsoft.VisualBasic
Imports System.Diagnostics
Imports System.Windows.Forms

Public Class FindDialog : Inherits Form
    ' A dialog for performing text searches through the Assembly tree.
    ' The dialog maintains state for performing the Find Next command.  It
    ' keeps track of the search string as well as the node to start searching
    ' from.

    Private m_ParentForm As MainWindow      'For access to data members such as treeview and also for displaying status messages.
    Private m_LastSearchedString As String  'The last string we have searched.
    Private m_NextNode As TreeNode          'The next node we will be checking in the Assembly tree.


#Region " Windows Form Designer generated code "

    'Form overrides dispose to clean up the component list.
    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing Then
            If Not (components Is Nothing) Then
                components.Dispose()
            End If
        End If
        MyBase.Dispose(disposing)
    End Sub

    Private WithEvents findDialogLabel As System.Windows.Forms.Label

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.Container

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    Private WithEvents FindTextBox As System.Windows.Forms.TextBox
    Private WithEvents FindButton As System.Windows.Forms.Button
    Private WithEvents CloseButton As System.Windows.Forms.Button
    Private WithEvents MatchCaseCheckBox As System.Windows.Forms.CheckBox
    Private WithEvents MatchExactStringCheckBox As System.Windows.Forms.CheckBox
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(FindDialog))
        Me.findDialogLabel = New System.Windows.Forms.Label()
        Me.FindTextBox = New System.Windows.Forms.TextBox()
        Me.FindButton = New System.Windows.Forms.Button()
        Me.CloseButton = New System.Windows.Forms.Button()
        Me.MatchCaseCheckBox = New System.Windows.Forms.CheckBox()
        Me.MatchExactStringCheckBox = New System.Windows.Forms.CheckBox()
        Me.SuspendLayout()
        '
        'findDialogLabel
        '
        Me.findDialogLabel.AccessibleDescription = CType(resources.GetObject("findDialogLabel.AccessibleDescription"), String)
        Me.findDialogLabel.AccessibleName = CType(resources.GetObject("findDialogLabel.AccessibleName"), String)
        Me.findDialogLabel.Anchor = CType(resources.GetObject("findDialogLabel.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.findDialogLabel.AutoSize = CType(resources.GetObject("findDialogLabel.AutoSize"), Boolean)
        Me.findDialogLabel.Dock = CType(resources.GetObject("findDialogLabel.Dock"), System.Windows.Forms.DockStyle)
        Me.findDialogLabel.Enabled = CType(resources.GetObject("findDialogLabel.Enabled"), Boolean)
        Me.findDialogLabel.Font = CType(resources.GetObject("findDialogLabel.Font"), System.Drawing.Font)
        Me.findDialogLabel.Image = CType(resources.GetObject("findDialogLabel.Image"), System.Drawing.Image)
        Me.findDialogLabel.ImageAlign = CType(resources.GetObject("findDialogLabel.ImageAlign"), System.Drawing.ContentAlignment)
        Me.findDialogLabel.ImageIndex = CType(resources.GetObject("findDialogLabel.ImageIndex"), Integer)
        Me.findDialogLabel.ImeMode = CType(resources.GetObject("findDialogLabel.ImeMode"), System.Windows.Forms.ImeMode)
        Me.findDialogLabel.Location = CType(resources.GetObject("findDialogLabel.Location"), System.Drawing.Point)
        Me.findDialogLabel.Name = "findDialogLabel"
        Me.findDialogLabel.RightToLeft = CType(resources.GetObject("findDialogLabel.RightToLeft"), System.Windows.Forms.RightToLeft)
        Me.findDialogLabel.Size = CType(resources.GetObject("findDialogLabel.Size"), System.Drawing.Size)
        Me.findDialogLabel.TabIndex = CType(resources.GetObject("findDialogLabel.TabIndex"), Integer)
        Me.findDialogLabel.Text = resources.GetString("findDialogLabel.Text")
        Me.findDialogLabel.TextAlign = CType(resources.GetObject("findDialogLabel.TextAlign"), System.Drawing.ContentAlignment)
        Me.findDialogLabel.Visible = CType(resources.GetObject("findDialogLabel.Visible"), Boolean)
        '
        'FindTextBox
        '
        Me.FindTextBox.AccessibleDescription = CType(resources.GetObject("FindTextBox.AccessibleDescription"), String)
        Me.FindTextBox.AccessibleName = CType(resources.GetObject("FindTextBox.AccessibleName"), String)
        Me.FindTextBox.Anchor = CType(resources.GetObject("FindTextBox.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.FindTextBox.AutoSize = CType(resources.GetObject("FindTextBox.AutoSize"), Boolean)
        Me.FindTextBox.BackgroundImage = CType(resources.GetObject("FindTextBox.BackgroundImage"), System.Drawing.Image)
        Me.FindTextBox.Dock = CType(resources.GetObject("FindTextBox.Dock"), System.Windows.Forms.DockStyle)
        Me.FindTextBox.Enabled = CType(resources.GetObject("FindTextBox.Enabled"), Boolean)
        Me.FindTextBox.Font = CType(resources.GetObject("FindTextBox.Font"), System.Drawing.Font)
        Me.FindTextBox.ImeMode = CType(resources.GetObject("FindTextBox.ImeMode"), System.Windows.Forms.ImeMode)
        Me.FindTextBox.Location = CType(resources.GetObject("FindTextBox.Location"), System.Drawing.Point)
        Me.FindTextBox.MaxLength = CType(resources.GetObject("FindTextBox.MaxLength"), Integer)
        Me.FindTextBox.Multiline = CType(resources.GetObject("FindTextBox.Multiline"), Boolean)
        Me.FindTextBox.Name = "FindTextBox"
        Me.FindTextBox.PasswordChar = CType(resources.GetObject("FindTextBox.PasswordChar"), Char)
        Me.FindTextBox.RightToLeft = CType(resources.GetObject("FindTextBox.RightToLeft"), System.Windows.Forms.RightToLeft)
        Me.FindTextBox.ScrollBars = CType(resources.GetObject("FindTextBox.ScrollBars"), System.Windows.Forms.ScrollBars)
        Me.FindTextBox.Size = CType(resources.GetObject("FindTextBox.Size"), System.Drawing.Size)
        Me.FindTextBox.TabIndex = CType(resources.GetObject("FindTextBox.TabIndex"), Integer)
        Me.FindTextBox.Text = resources.GetString("FindTextBox.Text")
        Me.FindTextBox.TextAlign = CType(resources.GetObject("FindTextBox.TextAlign"), System.Windows.Forms.HorizontalAlignment)
        Me.FindTextBox.Visible = CType(resources.GetObject("FindTextBox.Visible"), Boolean)
        Me.FindTextBox.WordWrap = CType(resources.GetObject("FindTextBox.WordWrap"), Boolean)
        '
        'FindButton
        '
        Me.FindButton.AccessibleDescription = CType(resources.GetObject("FindButton.AccessibleDescription"), String)
        Me.FindButton.AccessibleName = CType(resources.GetObject("FindButton.AccessibleName"), String)
        Me.FindButton.Anchor = CType(resources.GetObject("FindButton.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.FindButton.BackgroundImage = CType(resources.GetObject("FindButton.BackgroundImage"), System.Drawing.Image)
        Me.FindButton.Dock = CType(resources.GetObject("FindButton.Dock"), System.Windows.Forms.DockStyle)
        Me.FindButton.Enabled = CType(resources.GetObject("FindButton.Enabled"), Boolean)
        Me.FindButton.FlatStyle = CType(resources.GetObject("FindButton.FlatStyle"), System.Windows.Forms.FlatStyle)
        Me.FindButton.Font = CType(resources.GetObject("FindButton.Font"), System.Drawing.Font)
        Me.FindButton.Image = CType(resources.GetObject("FindButton.Image"), System.Drawing.Image)
        Me.FindButton.ImageAlign = CType(resources.GetObject("FindButton.ImageAlign"), System.Drawing.ContentAlignment)
        Me.FindButton.ImageIndex = CType(resources.GetObject("FindButton.ImageIndex"), Integer)
        Me.FindButton.ImeMode = CType(resources.GetObject("FindButton.ImeMode"), System.Windows.Forms.ImeMode)
        Me.FindButton.Location = CType(resources.GetObject("FindButton.Location"), System.Drawing.Point)
        Me.FindButton.Name = "FindButton"
        Me.FindButton.RightToLeft = CType(resources.GetObject("FindButton.RightToLeft"), System.Windows.Forms.RightToLeft)
        Me.FindButton.Size = CType(resources.GetObject("FindButton.Size"), System.Drawing.Size)
        Me.FindButton.TabIndex = CType(resources.GetObject("FindButton.TabIndex"), Integer)
        Me.FindButton.Text = resources.GetString("FindButton.Text")
        Me.FindButton.TextAlign = CType(resources.GetObject("FindButton.TextAlign"), System.Drawing.ContentAlignment)
        Me.FindButton.Visible = CType(resources.GetObject("FindButton.Visible"), Boolean)
        '
        'CloseButton
        '
        Me.CloseButton.AccessibleDescription = CType(resources.GetObject("CloseButton.AccessibleDescription"), String)
        Me.CloseButton.AccessibleName = CType(resources.GetObject("CloseButton.AccessibleName"), String)
        Me.CloseButton.Anchor = CType(resources.GetObject("CloseButton.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.CloseButton.BackgroundImage = CType(resources.GetObject("CloseButton.BackgroundImage"), System.Drawing.Image)
        Me.CloseButton.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.CloseButton.Dock = CType(resources.GetObject("CloseButton.Dock"), System.Windows.Forms.DockStyle)
        Me.CloseButton.Enabled = CType(resources.GetObject("CloseButton.Enabled"), Boolean)
        Me.CloseButton.FlatStyle = CType(resources.GetObject("CloseButton.FlatStyle"), System.Windows.Forms.FlatStyle)
        Me.CloseButton.Font = CType(resources.GetObject("CloseButton.Font"), System.Drawing.Font)
        Me.CloseButton.Image = CType(resources.GetObject("CloseButton.Image"), System.Drawing.Image)
        Me.CloseButton.ImageAlign = CType(resources.GetObject("CloseButton.ImageAlign"), System.Drawing.ContentAlignment)
        Me.CloseButton.ImageIndex = CType(resources.GetObject("CloseButton.ImageIndex"), Integer)
        Me.CloseButton.ImeMode = CType(resources.GetObject("CloseButton.ImeMode"), System.Windows.Forms.ImeMode)
        Me.CloseButton.Location = CType(resources.GetObject("CloseButton.Location"), System.Drawing.Point)
        Me.CloseButton.Name = "CloseButton"
        Me.CloseButton.RightToLeft = CType(resources.GetObject("CloseButton.RightToLeft"), System.Windows.Forms.RightToLeft)
        Me.CloseButton.Size = CType(resources.GetObject("CloseButton.Size"), System.Drawing.Size)
        Me.CloseButton.TabIndex = CType(resources.GetObject("CloseButton.TabIndex"), Integer)
        Me.CloseButton.Text = resources.GetString("CloseButton.Text")
        Me.CloseButton.TextAlign = CType(resources.GetObject("CloseButton.TextAlign"), System.Drawing.ContentAlignment)
        Me.CloseButton.Visible = CType(resources.GetObject("CloseButton.Visible"), Boolean)
        '
        'MatchCaseCheckBox
        '
        Me.MatchCaseCheckBox.AccessibleDescription = CType(resources.GetObject("MatchCaseCheckBox.AccessibleDescription"), String)
        Me.MatchCaseCheckBox.AccessibleName = CType(resources.GetObject("MatchCaseCheckBox.AccessibleName"), String)
        Me.MatchCaseCheckBox.Anchor = CType(resources.GetObject("MatchCaseCheckBox.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.MatchCaseCheckBox.Appearance = CType(resources.GetObject("MatchCaseCheckBox.Appearance"), System.Windows.Forms.Appearance)
        Me.MatchCaseCheckBox.BackgroundImage = CType(resources.GetObject("MatchCaseCheckBox.BackgroundImage"), System.Drawing.Image)
        Me.MatchCaseCheckBox.CheckAlign = CType(resources.GetObject("MatchCaseCheckBox.CheckAlign"), System.Drawing.ContentAlignment)
        Me.MatchCaseCheckBox.Dock = CType(resources.GetObject("MatchCaseCheckBox.Dock"), System.Windows.Forms.DockStyle)
        Me.MatchCaseCheckBox.Enabled = CType(resources.GetObject("MatchCaseCheckBox.Enabled"), Boolean)
        Me.MatchCaseCheckBox.FlatStyle = CType(resources.GetObject("MatchCaseCheckBox.FlatStyle"), System.Windows.Forms.FlatStyle)
        Me.MatchCaseCheckBox.Font = CType(resources.GetObject("MatchCaseCheckBox.Font"), System.Drawing.Font)
        Me.MatchCaseCheckBox.Image = CType(resources.GetObject("MatchCaseCheckBox.Image"), System.Drawing.Image)
        Me.MatchCaseCheckBox.ImageAlign = CType(resources.GetObject("MatchCaseCheckBox.ImageAlign"), System.Drawing.ContentAlignment)
        Me.MatchCaseCheckBox.ImageIndex = CType(resources.GetObject("MatchCaseCheckBox.ImageIndex"), Integer)
        Me.MatchCaseCheckBox.ImeMode = CType(resources.GetObject("MatchCaseCheckBox.ImeMode"), System.Windows.Forms.ImeMode)
        Me.MatchCaseCheckBox.Location = CType(resources.GetObject("MatchCaseCheckBox.Location"), System.Drawing.Point)
        Me.MatchCaseCheckBox.Name = "MatchCaseCheckBox"
        Me.MatchCaseCheckBox.RightToLeft = CType(resources.GetObject("MatchCaseCheckBox.RightToLeft"), System.Windows.Forms.RightToLeft)
        Me.MatchCaseCheckBox.Size = CType(resources.GetObject("MatchCaseCheckBox.Size"), System.Drawing.Size)
        Me.MatchCaseCheckBox.TabIndex = CType(resources.GetObject("MatchCaseCheckBox.TabIndex"), Integer)
        Me.MatchCaseCheckBox.Text = resources.GetString("MatchCaseCheckBox.Text")
        Me.MatchCaseCheckBox.TextAlign = CType(resources.GetObject("MatchCaseCheckBox.TextAlign"), System.Drawing.ContentAlignment)
        Me.MatchCaseCheckBox.Visible = CType(resources.GetObject("MatchCaseCheckBox.Visible"), Boolean)
        '
        'MatchExactStringCheckBox
        '
        Me.MatchExactStringCheckBox.AccessibleDescription = CType(resources.GetObject("MatchExactStringCheckBox.AccessibleDescription"), String)
        Me.MatchExactStringCheckBox.AccessibleName = CType(resources.GetObject("MatchExactStringCheckBox.AccessibleName"), String)
        Me.MatchExactStringCheckBox.Anchor = CType(resources.GetObject("MatchExactStringCheckBox.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.MatchExactStringCheckBox.Appearance = CType(resources.GetObject("MatchExactStringCheckBox.Appearance"), System.Windows.Forms.Appearance)
        Me.MatchExactStringCheckBox.BackgroundImage = CType(resources.GetObject("MatchExactStringCheckBox.BackgroundImage"), System.Drawing.Image)
        Me.MatchExactStringCheckBox.CheckAlign = CType(resources.GetObject("MatchExactStringCheckBox.CheckAlign"), System.Drawing.ContentAlignment)
        Me.MatchExactStringCheckBox.Dock = CType(resources.GetObject("MatchExactStringCheckBox.Dock"), System.Windows.Forms.DockStyle)
        Me.MatchExactStringCheckBox.Enabled = CType(resources.GetObject("MatchExactStringCheckBox.Enabled"), Boolean)
        Me.MatchExactStringCheckBox.FlatStyle = CType(resources.GetObject("MatchExactStringCheckBox.FlatStyle"), System.Windows.Forms.FlatStyle)
        Me.MatchExactStringCheckBox.Font = CType(resources.GetObject("MatchExactStringCheckBox.Font"), System.Drawing.Font)
        Me.MatchExactStringCheckBox.Image = CType(resources.GetObject("MatchExactStringCheckBox.Image"), System.Drawing.Image)
        Me.MatchExactStringCheckBox.ImageAlign = CType(resources.GetObject("MatchExactStringCheckBox.ImageAlign"), System.Drawing.ContentAlignment)
        Me.MatchExactStringCheckBox.ImageIndex = CType(resources.GetObject("MatchExactStringCheckBox.ImageIndex"), Integer)
        Me.MatchExactStringCheckBox.ImeMode = CType(resources.GetObject("MatchExactStringCheckBox.ImeMode"), System.Windows.Forms.ImeMode)
        Me.MatchExactStringCheckBox.Location = CType(resources.GetObject("MatchExactStringCheckBox.Location"), System.Drawing.Point)
        Me.MatchExactStringCheckBox.Name = "MatchExactStringCheckBox"
        Me.MatchExactStringCheckBox.RightToLeft = CType(resources.GetObject("MatchExactStringCheckBox.RightToLeft"), System.Windows.Forms.RightToLeft)
        Me.MatchExactStringCheckBox.Size = CType(resources.GetObject("MatchExactStringCheckBox.Size"), System.Drawing.Size)
        Me.MatchExactStringCheckBox.TabIndex = CType(resources.GetObject("MatchExactStringCheckBox.TabIndex"), Integer)
        Me.MatchExactStringCheckBox.Text = resources.GetString("MatchExactStringCheckBox.Text")
        Me.MatchExactStringCheckBox.TextAlign = CType(resources.GetObject("MatchExactStringCheckBox.TextAlign"), System.Drawing.ContentAlignment)
        Me.MatchExactStringCheckBox.Visible = CType(resources.GetObject("MatchExactStringCheckBox.Visible"), Boolean)
        '
        'FindDialog
        '
        Me.AcceptButton = Me.FindButton
        Me.AccessibleDescription = CType(resources.GetObject("$this.AccessibleDescription"), String)
        Me.AccessibleName = CType(resources.GetObject("$this.AccessibleName"), String)
        Me.Anchor = CType(resources.GetObject("$this.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.AutoScaleBaseSize = CType(resources.GetObject("$this.AutoScaleBaseSize"), System.Drawing.Size)
        Me.AutoScroll = CType(resources.GetObject("$this.AutoScroll"), Boolean)
        Me.AutoScrollMargin = CType(resources.GetObject("$this.AutoScrollMargin"), System.Drawing.Size)
        Me.AutoScrollMinSize = CType(resources.GetObject("$this.AutoScrollMinSize"), System.Drawing.Size)
        Me.BackgroundImage = CType(resources.GetObject("$this.BackgroundImage"), System.Drawing.Image)
        Me.CancelButton = Me.CloseButton
        Me.ClientSize = CType(resources.GetObject("$this.ClientSize"), System.Drawing.Size)
        Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.FindButton, Me.findDialogLabel, Me.MatchExactStringCheckBox, Me.MatchCaseCheckBox, Me.CloseButton, Me.FindTextBox})
        Me.Dock = CType(resources.GetObject("$this.Dock"), System.Windows.Forms.DockStyle)
        Me.Enabled = CType(resources.GetObject("$this.Enabled"), Boolean)
        Me.Font = CType(resources.GetObject("$this.Font"), System.Drawing.Font)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.ImeMode = CType(resources.GetObject("$this.ImeMode"), System.Windows.Forms.ImeMode)
        Me.Location = CType(resources.GetObject("$this.Location"), System.Drawing.Point)
        Me.MaximizeBox = False
        Me.MaximumSize = CType(resources.GetObject("$this.MaximumSize"), System.Drawing.Size)
        Me.MinimizeBox = False
        Me.MinimumSize = CType(resources.GetObject("$this.MinimumSize"), System.Drawing.Size)
        Me.Name = "FindDialog"
        Me.RightToLeft = CType(resources.GetObject("$this.RightToLeft"), System.Windows.Forms.RightToLeft)
        Me.ShowInTaskbar = False
        Me.StartPosition = CType(resources.GetObject("$this.StartPosition"), System.Windows.Forms.FormStartPosition)
        Me.Text = resources.GetString("$this.Text")
        Me.TopMost = True
        Me.Visible = CType(resources.GetObject("$this.Visible"), Boolean)
        Me.ResumeLayout(False)

    End Sub

#End Region

    Public Sub New(ByVal form As MainWindow)
        MyBase.New()

        m_ParentForm = form

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Reset function is equivalent to an initialize() here
        Reset()
    End Sub

    Public Sub Reset()
        ' Resets the state of the Find so a new search can begin.

        m_LastSearchedString = Nothing

        'The next node is now the first node in the Assembly tree, unless it has no nodes.
        If m_ParentForm.TreeView.GetNodeCount(False) > 0 Then
            m_NextNode = m_ParentForm.TreeView.Nodes(0)
        Else
            m_NextNode = Nothing
        End If

    End Sub

    Private Sub CloseButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CloseButton.Click
        'Hide the form instead of closing it because we want to maintain the Find state.
        Me.Hide()
    End Sub

    Private Sub FindTextBox_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles FindTextBox.TextChanged
        FindButton.Enabled = FindTextBox.Text <> ""
    End Sub

    Private Sub FindButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles FindButton.Click
        If m_ParentForm.TreeView.Nodes.Count = 0 Then
            MsgBox("The Assembly tree is empty.")
            Exit Sub
        End If

        Dim searchtext As String = Me.FindTextBox.Text

        'Reset the Find state if this is a new search string.
        If searchtext <> m_LastSearchedString Then
            Reset()
            m_LastSearchedString = searchtext
        End If

        StartSearch(searchtext)
    End Sub

    Private Sub StartSearch(ByVal searchtext As String)
        ' Perform the actual search.

        m_ParentForm.StatusMessage("Searching ...")

        Dim currentNode As TreeNode
        Dim found As Boolean = False

        While Not found AndAlso Not m_NextNode Is Nothing
            currentNode = m_NextNode

            If IsMatch(searchtext, currentNode.Text) Then
                m_ParentForm.TreeView.SelectedNode = currentNode
                m_ParentForm.StatusMessageReady()
                found = True
            End If

            FindNext(currentNode)
        End While

        'If we have reached the end of the search, ask to search again.
        If m_NextNode Is Nothing AndAlso Not found Then
            m_ParentForm.StatusMessageReady()
            If vbOK = MsgBox("The end of the tree has been reached. Start search from the beginning?", MsgBoxStyle.OKCancel) Then
                m_NextNode = m_ParentForm.TreeView.Nodes(0)

                'For simplicity, just recurse.
                StartSearch(searchtext)
            End If
        End If

        m_ParentForm.StatusMessageReady()

    End Sub

    Private Sub FindNext(ByVal StartingNode As TreeNode)
        'Set the next node to be searched.
        '
        'We need to consider three cases:
        '   1. If the node has children, select the first child.
        '   2. If the node has a sibling next to it it, select the sibling.
        '   3. Else, go to the parent and do case #2 over again.
        '
        'If there are no nodes left to search, the loop will bottom out at the
        'root of the tree and m_NextNode will be Nothing.

        If StartingNode.Nodes.Count > 0 Then
            'The next node is the first child.
            m_NextNode = StartingNode.Nodes(0)

        ElseIf Not StartingNode.NextNode Is Nothing Then
            'The next node is the next sibling.
            m_NextNode = StartingNode.NextNode

        Else
            'The next node is the parent's next sibling.
            'Walk up the tree, looking for a parent that has a next sibling.
            m_NextNode = StartingNode.Parent
            While Not m_NextNode Is Nothing
                If Not m_NextNode.NextNode Is Nothing Then
                    'We have found a sibling.
                    m_NextNode = m_NextNode.NextNode
                    Exit While
                End If
                m_NextNode = m_NextNode.Parent
            End While
        End If
    End Sub

    Public Sub SkipDeletedNode(ByVal DeletedNode As TreeNode)
        Debug.Assert(Not DeletedNode Is Nothing, "DeletedNode doesn't exist.")

        If m_NextNode Is DeletedNode Then
            FindNext(DeletedNode)
        End If
    End Sub

    Private Function IsMatch(ByVal searchtext As String, ByVal nodetext As String) As Boolean
        Debug.Assert(searchtext <> "", "Cannot search with an empty string; the find button should be disabled.")

        'Option Compare Binary ensures we have the ability to turn case-sensitive compare on and off.
        'Normalize both strings to lower-case if the user is not doing a matched-case search.
        If Not Me.MatchCaseCheckBox.Checked Then
            searchtext = LCase(searchtext)
            nodetext = LCase(nodetext)
        End If

        'The text must match exactly if the user is doing an exact string search, otherwise
        'substring matches are okay.
        If Me.MatchExactStringCheckBox.Checked Then
            Return searchtext = nodetext
        Else
            Return nodetext.IndexOf(searchtext) <> -1
        End If

    End Function

    Private Sub CheckBox_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MatchCaseCheckBox.CheckedChanged, MatchExactStringCheckBox.CheckedChanged
        Reset()
    End Sub

End Class
