'*****************************************************************************
' Copyright (C) 1999-2002, Microsoft Corporation.  All Rights Reserved.
'*****************************************************************************

Imports System.Windows.Forms
Imports System.Collections
Imports System.Diagnostics
Imports System.Drawing


Public Class NodeWindow : Inherits Form
    ' A form UI for adding and modifying XML content for an assembly
    ' member.  This form acts as the visual and editable representation of a
    ' member node's content descriptors.

    Private Const INDENT_WIDTH As Integer = 30      'The offset for controls from the corresponding DescriptoLabel.
    Private Const VERT_MARGIN As Integer = 4        'Vertical distance between controls.
    Private Const LEFT_MARGIN As Integer = 5        'The amount of space between the controls and the form's left edge.
    Private Const RIGHT_MARGIN As Integer = 20      'The amount of space between the controls and the form's right edge.
    Private Const TOP_MARGIN As Integer = 5         'The amount of space between the controls and the form's top edge.
    Private Const BOTTOM_MARGIN As Integer = 40     'The amount of space between the controls and the form's bottom edge.

    Private m_Doc As MainDoc                        'The core engine instance.
    Private m_MemberNode As MemberNode              'The form's corresponding member node.

    'The form raises these events so the logic in MainWindow can handle them (rather than duplicate the logic here).
    Public Event MenuCutClicked(ByVal sender As System.Object, ByVal e As System.EventArgs)
    Public Event MenuCopyClicked(ByVal sender As System.Object, ByVal e As System.EventArgs)
    Public Event MenuPasteClicked(ByVal sender As System.Object, ByVal e As System.EventArgs)


#Region " Windows Form Designer generated code "

    Private WithEvents Holder As UserControl
    Private WithEvents TextBoxContextMenu As System.Windows.Forms.ContextMenu
    Private WithEvents ContextMenuCut As System.Windows.Forms.MenuItem
    Private WithEvents ContextMenuCopy As System.Windows.Forms.MenuItem
    Private WithEvents ContextMenuPaste As System.Windows.Forms.MenuItem

    'Form overrides dispose to clean up the component list.
    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        MyBase.Dispose(disposing)
        If Not (components Is Nothing) Then
            components.Dispose()
        End If
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.Container

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    Private WithEvents List As System.Windows.Forms.UserControl
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(NodeWindow))
        Me.List = New System.Windows.Forms.UserControl()
        Me.TextBoxContextMenu = New System.Windows.Forms.ContextMenu()
        Me.ContextMenuCut = New System.Windows.Forms.MenuItem()
        Me.ContextMenuCopy = New System.Windows.Forms.MenuItem()
        Me.ContextMenuPaste = New System.Windows.Forms.MenuItem()
        Me.SuspendLayout()
        '
        'List
        '
        Me.List.AccessibleDescription = CType(resources.GetObject("List.AccessibleDescription"), String)
        Me.List.AccessibleName = CType(resources.GetObject("List.AccessibleName"), String)
        Me.List.Anchor = CType(resources.GetObject("List.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.List.AutoScroll = CType(resources.GetObject("List.AutoScroll"), Boolean)
        Me.List.AutoScrollMargin = CType(resources.GetObject("List.AutoScrollMargin"), System.Drawing.Size)
        Me.List.AutoScrollMinSize = CType(resources.GetObject("List.AutoScrollMinSize"), System.Drawing.Size)
        Me.List.BackColor = System.Drawing.SystemColors.Control
        Me.List.BackgroundImage = CType(resources.GetObject("List.BackgroundImage"), System.Drawing.Image)
        Me.List.Dock = CType(resources.GetObject("List.Dock"), System.Windows.Forms.DockStyle)
        Me.List.Enabled = CType(resources.GetObject("List.Enabled"), Boolean)
        Me.List.Font = CType(resources.GetObject("List.Font"), System.Drawing.Font)
        Me.List.ImeMode = CType(resources.GetObject("List.ImeMode"), System.Windows.Forms.ImeMode)
        Me.List.Location = CType(resources.GetObject("List.Location"), System.Drawing.Point)
        Me.List.Name = "List"
        Me.List.RightToLeft = CType(resources.GetObject("List.RightToLeft"), System.Windows.Forms.RightToLeft)
        Me.List.Size = CType(resources.GetObject("List.Size"), System.Drawing.Size)
        Me.List.TabIndex = CType(resources.GetObject("List.TabIndex"), Integer)
        Me.List.Visible = CType(resources.GetObject("List.Visible"), Boolean)
        '
        'TextBoxContextMenu
        '
        Me.TextBoxContextMenu.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.ContextMenuCut, Me.ContextMenuCopy, Me.ContextMenuPaste})
        Me.TextBoxContextMenu.RightToLeft = CType(resources.GetObject("TextBoxContextMenu.RightToLeft"), System.Windows.Forms.RightToLeft)
        '
        'ContextMenuCut
        '
        Me.ContextMenuCut.Enabled = CType(resources.GetObject("ContextMenuCut.Enabled"), Boolean)
        Me.ContextMenuCut.Index = 0
        Me.ContextMenuCut.Shortcut = CType(resources.GetObject("ContextMenuCut.Shortcut"), System.Windows.Forms.Shortcut)
        Me.ContextMenuCut.ShowShortcut = CType(resources.GetObject("ContextMenuCut.ShowShortcut"), Boolean)
        Me.ContextMenuCut.Text = resources.GetString("ContextMenuCut.Text")
        Me.ContextMenuCut.Visible = CType(resources.GetObject("ContextMenuCut.Visible"), Boolean)
        '
        'ContextMenuCopy
        '
        Me.ContextMenuCopy.Enabled = CType(resources.GetObject("ContextMenuCopy.Enabled"), Boolean)
        Me.ContextMenuCopy.Index = 1
        Me.ContextMenuCopy.Shortcut = CType(resources.GetObject("ContextMenuCopy.Shortcut"), System.Windows.Forms.Shortcut)
        Me.ContextMenuCopy.ShowShortcut = CType(resources.GetObject("ContextMenuCopy.ShowShortcut"), Boolean)
        Me.ContextMenuCopy.Text = resources.GetString("ContextMenuCopy.Text")
        Me.ContextMenuCopy.Visible = CType(resources.GetObject("ContextMenuCopy.Visible"), Boolean)
        '
        'ContextMenuPaste
        '
        Me.ContextMenuPaste.Enabled = CType(resources.GetObject("ContextMenuPaste.Enabled"), Boolean)
        Me.ContextMenuPaste.Index = 2
        Me.ContextMenuPaste.Shortcut = CType(resources.GetObject("ContextMenuPaste.Shortcut"), System.Windows.Forms.Shortcut)
        Me.ContextMenuPaste.ShowShortcut = CType(resources.GetObject("ContextMenuPaste.ShowShortcut"), Boolean)
        Me.ContextMenuPaste.Text = resources.GetString("ContextMenuPaste.Text")
        Me.ContextMenuPaste.Visible = CType(resources.GetObject("ContextMenuPaste.Visible"), Boolean)
        '
        'NodeWindow
        '
        Me.AccessibleDescription = CType(resources.GetObject("$this.AccessibleDescription"), String)
        Me.AccessibleName = CType(resources.GetObject("$this.AccessibleName"), String)
        Me.Anchor = CType(resources.GetObject("$this.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.AutoScaleBaseSize = CType(resources.GetObject("$this.AutoScaleBaseSize"), System.Drawing.Size)
        Me.AutoScroll = CType(resources.GetObject("$this.AutoScroll"), Boolean)
        Me.AutoScrollMargin = CType(resources.GetObject("$this.AutoScrollMargin"), System.Drawing.Size)
        Me.AutoScrollMinSize = CType(resources.GetObject("$this.AutoScrollMinSize"), System.Drawing.Size)
        Me.BackColor = System.Drawing.SystemColors.Window
        Me.BackgroundImage = CType(resources.GetObject("$this.BackgroundImage"), System.Drawing.Image)
        Me.ClientSize = CType(resources.GetObject("$this.ClientSize"), System.Drawing.Size)
        Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.List})
        Me.Dock = CType(resources.GetObject("$this.Dock"), System.Windows.Forms.DockStyle)
        Me.Enabled = CType(resources.GetObject("$this.Enabled"), Boolean)
        Me.Font = CType(resources.GetObject("$this.Font"), System.Drawing.Font)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.ImeMode = CType(resources.GetObject("$this.ImeMode"), System.Windows.Forms.ImeMode)
        Me.Location = CType(resources.GetObject("$this.Location"), System.Drawing.Point)
        Me.MaximumSize = CType(resources.GetObject("$this.MaximumSize"), System.Drawing.Size)
        Me.MinimumSize = CType(resources.GetObject("$this.MinimumSize"), System.Drawing.Size)
        Me.Name = "NodeWindow"
        Me.RightToLeft = CType(resources.GetObject("$this.RightToLeft"), System.Windows.Forms.RightToLeft)
        Me.StartPosition = CType(resources.GetObject("$this.StartPosition"), System.Windows.Forms.FormStartPosition)
        Me.Text = resources.GetString("$this.Text")
        Me.Visible = CType(resources.GetObject("$this.Visible"), Boolean)
        Me.ResumeLayout(False)

    End Sub

#End Region

    Public Sub New(ByVal node As MemberNode, ByVal Doc As MainDoc, ByVal ParentForm As MainWindow)
        ' Builds a Node Window from a member node.

        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        m_Doc = Doc
        m_MemberNode = node

        'The title of the window is the full friendly signature.
        Me.Text = m_MemberNode.FriendlySignatureWithPathAndModifiers

        'The new form takes on the state of the currently active form.
        'If there is none, the default state is Maximized.
        If ParentForm.ActiveMdiChild Is Nothing Then
            Me.WindowState = FormWindowState.Maximized
        Else
            Me.WindowState = ParentForm.ActiveMdiChild.WindowState
        End If

        BuildFormMembers()
    End Sub

    Private Sub PositionControls(ByVal newlabel As DescriptoLabel, ByVal newbox As DescriptoBox, ByVal indentlevel As Integer, ByRef runningypos As Integer)
        ' Given a box and label control, and the current indentation level and
        ' running Y coordinate, this function calculates the appropriate
        ' location for the controls.  The running Y coordinate is ByRef
        ' because the next controls' positions are dependent on the previous
        ' controls' positions.

        'The X coordinate is the indentation plus the left margin.
        newlabel.Location = New Point(indentlevel * INDENT_WIDTH + LEFT_MARGIN, runningypos)

        'Calls to this function can be made without supplying a DescriptoBox instance, in which case the
        'running y coordiate must be based off the location of the label.
        If Not newbox Is Nothing Then
            'DescriptoBoxes are indented one level beyond their associated labels.
            newbox.Location = New Point((indentlevel + 1) * INDENT_WIDTH + LEFT_MARGIN, newlabel.Bottom + VERT_MARGIN)
            'The box's width stretches to the right side of the form (minus the right margin).
            newbox.Width = Me.Width - newbox.Location.X - RIGHT_MARGIN
            runningypos = newbox.Bottom + VERT_MARGIN
        Else
            runningypos = newlabel.Bottom + VERT_MARGIN
        End If
    End Sub

    Private Sub BuildFields(ByVal Descriptors As ArrayList, ByVal LabelText As String, ByVal indentlevel As Integer, ByRef runningypos As Integer)
        ' Add new DescriptoLabel/DescriptoBox pairs onto the form based on a
        ' list of content descriptors.

        Dim CurrentDescriptor As ContentDescriptor
        For Each CurrentDescriptor In Descriptors

            Dim newlabel As DescriptoLabel = New DescriptoLabel(LabelText, CurrentDescriptor, AddressOf RemoveDescriptor)
            Dim newbox As DescriptoBox = New DescriptoBox(CurrentDescriptor, Me.TextBoxContextMenu, AddressOf UpdateDescriptorState)

            PositionControls(newlabel, newbox, indentlevel, runningypos)
            Me.List.Controls.AddRange(New Control() {newlabel, newbox})
        Next
    End Sub

    Private Sub BuildParamFields(ByVal Descriptors As ArrayList, ByVal indentlevel As Integer, ByRef runningypos As Integer)
        ' Add new DescriptoLabel/DescriptoBox pairs onto the form based on a
        ' list of parameter descriptors.

        Dim CurrentParameter As ParameterDescriptor
        For Each CurrentParameter In Descriptors

            Dim newlabel As DescriptoLabel = New DescriptoLabel(CurrentParameter.FriendlySignature, CurrentParameter, AddressOf RemoveDescriptor)
            Dim newbox As DescriptoBox = New DescriptoBox(CurrentParameter, Me.TextBoxContextMenu, AddressOf UpdateDescriptorState)

            PositionControls(newlabel, newbox, indentlevel, runningypos)
            Me.List.Controls.AddRange(New Control() {newlabel, newbox})
        Next
    End Sub

    Friend Sub BuildFormMembers()
        ' Builds all the controls in a node window based on the content
        ' descriptors of the member node.

        'To save memory, member nodes are not automatically allocated their default content 
        'descriptors.  But without the content descriptors, the controls cannot be built on
        'the form.  We need to ensure those default descriptors exist to ensure the controls
        'will be built.
        m_MemberNode.EnsureDefaultDescriptors()

        'Keep track of the Y coordinate as we build the controls so we can know where to
        'position the next control.
        Dim runningypos As Integer = TOP_MARGIN

        Me.SuspendLayout()

        BuildFields(m_MemberNode.m_Summary, "Summary", 0, runningypos)

        'Parameters are placed under a label called "Parameters".
        If m_MemberNode.m_Params.Count > 0 Then
            'Create the label "Parameters" and position it on the form.
            Dim paramlabel As New DescriptoLabel("Parameters", Nothing, Nothing)
            PositionControls(paramlabel, Nothing, 0, runningypos)
            Me.List.Controls.Add(paramlabel)

            'Params are indented from the other fields.
            BuildParamFields(m_MemberNode.m_Params, 1, runningypos)
        End If

        Dim returntype As String = m_MemberNode.FriendlyReturnType

        BuildFields(m_MemberNode.m_PropertyValue, "Value" & returntype, 0, runningypos)
        BuildFields(m_MemberNode.m_ReturnValue, "Returns" & returntype, 0, runningypos)
        BuildFields(m_MemberNode.m_Remarks, "Remarks", 0, runningypos)

        Me.Height = (runningypos - VERT_MARGIN) + BOTTOM_MARGIN

        Me.ResumeLayout(True)
    End Sub

    Private Sub MenuCut_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ContextMenuCut.Click
        RaiseEvent MenuCutClicked(sender, e)
    End Sub

    Private Sub MenuCopy_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ContextMenuCopy.Click
        RaiseEvent MenuCopyClicked(sender, e)
    End Sub

    Private Sub MenuPaste_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ContextMenuPaste.Click
        RaiseEvent MenuPasteClicked(sender, e)
    End Sub

    Private Sub ContextMenu_Popup(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBoxContextMenu.Popup
        'Disable/enable the context menu items.
        If Not Me.List.ActiveControl Is Nothing Then
            Dim box As DescriptoBox = CType(Me.List.ActiveControl, DescriptoBox)
            ContextMenuCut.Enabled = Not box.ReadOnly AndAlso box.SelectionLength > 0
            ContextMenuCopy.Enabled = box.SelectionLength > 0
            ContextMenuPaste.Enabled = Not box.ReadOnly AndAlso TypeOf System.Windows.Forms.Clipboard.GetDataObject.GetData(DataFormats.Text) Is String
        End If
    End Sub

    Private Sub UpdateDescriptorState(ByVal sender As Object, ByVal e As System.EventArgs)
        ' The user has made an edit to the DescriptoBox.  Copy the text into
        ' the content descriptor.  This tight coupling ensures the content
        ' descriptor always has the correct state.

        Dim Field As DescriptoBox = CType(sender, DescriptoBox)

        If Field.Text.Length > 32000 Then
            Field.Text = Microsoft.VisualBasic.Left(Field.Text, 32000)
            Field.SelectionStart = Field.TextLength
            Microsoft.VisualBasic.Beep()
        End If
        Field.Descriptor.Content = Field.Text
        m_MemberNode.UpdateEditState()
    End Sub

    Public Sub RemoveDescriptor(ByVal Descriptor As ContentDescriptor)
        ' The user has chosen to delete a field.  Remove the corresponding
        ' descriptor from the member node, remove all of its errors, and re-
        ' build the node window.

        Debug.Assert(Descriptor.HasErrors, "Labels with no errors cannot be removed.")

        Dim e As ErrorRecord
        For Each e In Descriptor.Errors
            m_Doc.DeleteError(m_MemberNode, Descriptor, e)
        Next

        'For simplicity, remove the descriptor from all lists. If the descriptor is not
        'in the list, Remove will do nothing.
        m_MemberNode.m_Summary.Remove(Descriptor)
        m_MemberNode.m_PropertyValue.Remove(Descriptor)
        m_MemberNode.m_Remarks.Remove(Descriptor)
        m_MemberNode.m_ReturnValue.Remove(Descriptor)
        m_MemberNode.m_Params.Remove(Descriptor)

        Me.List.Controls.Clear()
        BuildFormMembers()
    End Sub

End Class
