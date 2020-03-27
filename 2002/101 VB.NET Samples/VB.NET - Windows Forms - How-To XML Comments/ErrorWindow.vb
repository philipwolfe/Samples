'*****************************************************************************
' Copyright (C) 1999-2002, Microsoft Corporation.  All Rights Reserved.
'*****************************************************************************

Imports Microsoft.VisualBasic
Imports System
Imports System.Collections
Imports System.Diagnostics
Imports System.Windows.Forms


Public Enum ErrorID
    ' The ID enum is a table of all errors the tool can generate.  The entries
    ' in this enum are used to index into the table of error messages to fetch
    ' their corresponding messages.  The numeric postfix indicates the number
    ' of substitutions in the error message.

    NoError
    NodeInXMLOnly
    DuplicateField1
    UnexpectedField2
    ParamNameItemNotValid1
    ParamNotFound2
    UnknownField2
    MemberNotValid1
    MemberNameItemNotValid
    BadSignatureInMemberNode1

    'The errors below will not show up in the error window but will instead show up in error dialogs.
    FieldCountNotMatch1
    ErrorDuringLoad3
    ErrorDuringSave3
End Enum

Public Module ErrorTable
    ' The table of error messages.  Each error message may have one or more
    ' substitution sites denoted by a "|" followed by a number.

    Private ErrorStrings As String() = { _
        "No error.", _
        "This node is found only in the XML Documentation file.", _
        "Duplicate '|0' field found.", _
        "Unexpected '|0' field found. Only |1 can have '|0' fields.", _
        "'name' item for parameter on node '|0' is not valid.", _
        "Parameter '|0' on node '|1' is found only in the XML Documentation file.", _
        "Field '|0' is unrecognized; content is ignored. Content: '|1'", _
        "Node name '|0' is not valid. This node will be removed upon save.", _
        "'name' item for member node is not valid. This node will be removed upon save.", _
        "Bad signature found in member node: '|0'", _
        "The number of '|0' fields is greater in the source than in the destination. Cannot copy.", _
        "An error occurred while loading |0 '|1'. Details: " & vbCrLf & vbCrLf & "|2", _
        "An error occurred while saving |0 '|1'. Details:" & vbCrLf & vbCrLf & "|2" _
    }


    Public Function GetErrorMessage(ByVal ErrorID As ErrorID, ByVal ParamArray Substitutions As String()) As String
        ' This function maps Error IDs to error messages.  In doing so, it
        ' sequentially makes the substitutions, specified with the
        ' substitution param array, into the message using the substitution
        ' sites embedded in the string.

        Dim Message As String = ErrorStrings(ErrorID)
        If Not Substitutions Is Nothing Then
            Dim i As Integer
            For i = 0 To Substitutions.Length - 1
                'Replace instances of "|i" with the corresponding item in the substitution param array.
                Message = Message.Replace("|" & CStr(i), Substitutions(i))
            Next
        End If
        Return Message
    End Function

End Module

Public Class ErrorRecord : Inherits ListViewItem
    ' A container which represents an error.  Each record has an ID, a
    ' reference to the associated member node, and a visual style which
    ' includes the error message and path.  This class inherits from
    ' ListViewItem so it can be directly inserted into the error list.

    Private m_ErrorID As ErrorID    'This record's error ID
    Private m_Member As MemberNode  'The member this record is associated with.


    Private Sub New(ByVal Path As String, ByVal Message As String)
        ' Builds a instance of ListViewItem with the visual style of an error
        ' record.  The text which is shown to the user is passed-in as the
        ' path and message.

        MyBase.New( _
                New System.Windows.Forms.ListViewItem.ListViewSubItem() { _
                    New System.Windows.Forms.ListViewItem.ListViewSubItem( _
                        Nothing, _
                        Path, _
                        System.Drawing.SystemColors.WindowText, _
                        System.Drawing.SystemColors.Window, _
                        New System.Drawing.Font( _
                            "Microsoft Sans Serif", _
                            8.25!, _
                            System.Drawing.FontStyle.Regular, _
                            System.Drawing.GraphicsUnit.Point, _
                            0)), _
                    New System.Windows.Forms.ListViewItem.ListViewSubItem( _
                        Nothing, _
                        Message, _
                        System.Drawing.SystemColors.WindowText, _
                        System.Drawing.SystemColors.Window, _
                        New System.Drawing.Font( _
                            "Microsoft Sans Serif", _
                            8.25!, _
                            System.Drawing.FontStyle.Regular, _
                            System.Drawing.GraphicsUnit.Point, _
                            0)) _
                }, _
                -1)
    End Sub

    Public Sub New(ByVal node As MemberNode, ByVal ErrorID As ErrorID, ByVal ParamArray Substitutions As String())
        'Build the visual style, which includes fetching the error message and stripping 
        'out the slashes from the node's path so it looks good to the user.
        MyClass.New(NormalizeNodePath(node.FullPath), GetErrorMessage(ErrorID, Substitutions))

        m_ErrorID = ErrorID
        m_Member = node
    End Sub

    Public ReadOnly Property ErrorID() As ErrorID
        Get
            Return m_ErrorID
        End Get
    End Property

    Public ReadOnly Property Path() As String
        Get
            'The path is the text in the first column.
            Return Me.SubItems(0).Text
        End Get
    End Property

    Public ReadOnly Property Message() As String
        Get
            'The message is the text in the second column.
            Return Me.SubItems(1).Text
        End Get
    End Property

    Public ReadOnly Property Member() As MemberNode
        Get
            Return m_Member
        End Get
    End Property

End Class

Public Class ErrorWindow : Inherits UserControl
    ' Displays all errors to the user.  Errors are represented as ErrorRecords
    ' held in a ListView control.  The report and delete methods on this
    ' control are the only way to add and remove ErrorRecords from the list.
    '
    ' Errors are created by passing-in an Error ID and a optional set of
    ' substitutions.  During construction of an error record, the message
    ' string is looked up in the error table using the ID and the
    ' substitutions are made into the string.  The error record is then
    ' inserted into the list view and also into any associated member nodes
    ' and content descriptors (so these objects can keep track of it as well).
    '
    ' Errors are deleted by passing-in the error record to be deleted.  The
    ' record gets removed from the list as well as from any member nodes and
    ' content descriptors that are keeping track of it.

    Private Class ErrorRecordComparer
        Implements IComparer
        ' This class compares Error Records for sorting when the user clicks
        ' on the error window's column headers.

        Public Enum CompareKind
            Path        'The 0th column in the error window.
            Message     'The 1st column in the error window.
        End Enum

        Private m_Kind As CompareKind

        Public Sub New(ByVal kind As CompareKind)
            'The compare kind determines which field to compare Error Records with.
            m_Kind = kind
        End Sub

        Public Function Compare(ByVal x As Object, ByVal y As Object) As Integer Implements IComparer.Compare
            ' Compare two Error Records.  The comparison kind determines which
            ' field of the Error Record to perform the comparison on.

            Select Case m_Kind
                Case CompareKind.Path
                    Return CType(x, ErrorRecord).Path.CompareTo(CType(y, ErrorRecord).Path)
                Case CompareKind.Message
                    Return CType(x, ErrorRecord).Message.CompareTo(CType(y, ErrorRecord).Message)
                Case Else
                    Debug.Fail("Unexpected compare kind: " & m_Kind.ToString)
            End Select
        End Function
    End Class

    Public Event ErrorListDoubleClick(ByVal member As MemberNode)   'Fires when an error record is double-clicked.
    Public Event OnCloseButtonClicked()                             'Fires when the button to close the error window is clicked.


#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()
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

    Private WithEvents ErrorList As System.Windows.Forms.ListView
    Private WithEvents CloseButton As System.Windows.Forms.Button
    Private WithEvents ErrorInformationTitle As System.Windows.Forms.Label
    Private WithEvents ColumnPath As System.Windows.Forms.ColumnHeader
    Private WithEvents ColumnDescription As System.Windows.Forms.ColumnHeader

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(ErrorWindow))
        Me.ErrorInformationTitle = New System.Windows.Forms.Label()
        Me.ErrorList = New System.Windows.Forms.ListView()
        Me.ColumnPath = New System.Windows.Forms.ColumnHeader()
        Me.ColumnDescription = New System.Windows.Forms.ColumnHeader()
        Me.CloseButton = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'ErrorInformationTitle
        '
        Me.ErrorInformationTitle.AccessibleDescription = CType(resources.GetObject("ErrorInformationTitle.AccessibleDescription"), String)
        Me.ErrorInformationTitle.AccessibleName = CType(resources.GetObject("ErrorInformationTitle.AccessibleName"), String)
        Me.ErrorInformationTitle.AccessibleRole = System.Windows.Forms.AccessibleRole.TitleBar
        Me.ErrorInformationTitle.Anchor = CType(resources.GetObject("ErrorInformationTitle.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.ErrorInformationTitle.AutoSize = CType(resources.GetObject("ErrorInformationTitle.AutoSize"), Boolean)
        Me.ErrorInformationTitle.BackColor = System.Drawing.SystemColors.Control
        Me.ErrorInformationTitle.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.ErrorInformationTitle.Dock = CType(resources.GetObject("ErrorInformationTitle.Dock"), System.Windows.Forms.DockStyle)
        Me.ErrorInformationTitle.Enabled = CType(resources.GetObject("ErrorInformationTitle.Enabled"), Boolean)
        Me.ErrorInformationTitle.Font = CType(resources.GetObject("ErrorInformationTitle.Font"), System.Drawing.Font)
        Me.ErrorInformationTitle.Image = CType(resources.GetObject("ErrorInformationTitle.Image"), System.Drawing.Image)
        Me.ErrorInformationTitle.ImageAlign = CType(resources.GetObject("ErrorInformationTitle.ImageAlign"), System.Drawing.ContentAlignment)
        Me.ErrorInformationTitle.ImageIndex = CType(resources.GetObject("ErrorInformationTitle.ImageIndex"), Integer)
        Me.ErrorInformationTitle.ImeMode = CType(resources.GetObject("ErrorInformationTitle.ImeMode"), System.Windows.Forms.ImeMode)
        Me.ErrorInformationTitle.Location = CType(resources.GetObject("ErrorInformationTitle.Location"), System.Drawing.Point)
        Me.ErrorInformationTitle.Name = "ErrorInformationTitle"
        Me.ErrorInformationTitle.RightToLeft = CType(resources.GetObject("ErrorInformationTitle.RightToLeft"), System.Windows.Forms.RightToLeft)
        Me.ErrorInformationTitle.Size = CType(resources.GetObject("ErrorInformationTitle.Size"), System.Drawing.Size)
        Me.ErrorInformationTitle.TabIndex = CType(resources.GetObject("ErrorInformationTitle.TabIndex"), Integer)
        Me.ErrorInformationTitle.Text = resources.GetString("ErrorInformationTitle.Text")
        Me.ErrorInformationTitle.TextAlign = CType(resources.GetObject("ErrorInformationTitle.TextAlign"), System.Drawing.ContentAlignment)
        Me.ErrorInformationTitle.Visible = CType(resources.GetObject("ErrorInformationTitle.Visible"), Boolean)
        '
        'ErrorList
        '
        Me.ErrorList.AccessibleDescription = CType(resources.GetObject("ErrorList.AccessibleDescription"), String)
        Me.ErrorList.AccessibleName = CType(resources.GetObject("ErrorList.AccessibleName"), String)
        Me.ErrorList.Alignment = CType(resources.GetObject("ErrorList.Alignment"), System.Windows.Forms.ListViewAlignment)
        Me.ErrorList.Anchor = CType(resources.GetObject("ErrorList.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.ErrorList.BackColor = System.Drawing.SystemColors.Window
        Me.ErrorList.BackgroundImage = CType(resources.GetObject("ErrorList.BackgroundImage"), System.Drawing.Image)
        Me.ErrorList.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnPath, Me.ColumnDescription})
        Me.ErrorList.Dock = CType(resources.GetObject("ErrorList.Dock"), System.Windows.Forms.DockStyle)
        Me.ErrorList.Enabled = CType(resources.GetObject("ErrorList.Enabled"), Boolean)
        Me.ErrorList.Font = CType(resources.GetObject("ErrorList.Font"), System.Drawing.Font)
        Me.ErrorList.FullRowSelect = True
        Me.ErrorList.HideSelection = False
        Me.ErrorList.ImeMode = CType(resources.GetObject("ErrorList.ImeMode"), System.Windows.Forms.ImeMode)
        Me.ErrorList.LabelWrap = CType(resources.GetObject("ErrorList.LabelWrap"), Boolean)
        Me.ErrorList.Location = CType(resources.GetObject("ErrorList.Location"), System.Drawing.Point)
        Me.ErrorList.MultiSelect = False
        Me.ErrorList.Name = "ErrorList"
        Me.ErrorList.RightToLeft = CType(resources.GetObject("ErrorList.RightToLeft"), System.Windows.Forms.RightToLeft)
        Me.ErrorList.Size = CType(resources.GetObject("ErrorList.Size"), System.Drawing.Size)
        Me.ErrorList.Sorting = System.Windows.Forms.SortOrder.Ascending
        Me.ErrorList.TabIndex = CType(resources.GetObject("ErrorList.TabIndex"), Integer)
        Me.ErrorList.Text = resources.GetString("ErrorList.Text")
        Me.ErrorList.View = System.Windows.Forms.View.Details
        Me.ErrorList.Visible = CType(resources.GetObject("ErrorList.Visible"), Boolean)
        '
        'ColumnPath
        '
        Me.ColumnPath.Text = resources.GetString("ColumnPath.Text")
        Me.ColumnPath.TextAlign = CType(resources.GetObject("ColumnPath.TextAlign"), System.Windows.Forms.HorizontalAlignment)
        Me.ColumnPath.Width = CType(resources.GetObject("ColumnPath.Width"), Integer)
        '
        'ColumnDescription
        '
        Me.ColumnDescription.Text = resources.GetString("ColumnDescription.Text")
        Me.ColumnDescription.TextAlign = CType(resources.GetObject("ColumnDescription.TextAlign"), System.Windows.Forms.HorizontalAlignment)
        Me.ColumnDescription.Width = CType(resources.GetObject("ColumnDescription.Width"), Integer)
        '
        'CloseButton
        '
        Me.CloseButton.AccessibleDescription = CType(resources.GetObject("CloseButton.AccessibleDescription"), String)
        Me.CloseButton.AccessibleName = CType(resources.GetObject("CloseButton.AccessibleName"), String)
        Me.CloseButton.Anchor = CType(resources.GetObject("CloseButton.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.CloseButton.BackColor = System.Drawing.SystemColors.Control
        Me.CloseButton.BackgroundImage = CType(resources.GetObject("CloseButton.BackgroundImage"), System.Drawing.Image)
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
        'ErrorWindow
        '
        Me.AccessibleDescription = CType(resources.GetObject("$this.AccessibleDescription"), String)
        Me.AccessibleName = CType(resources.GetObject("$this.AccessibleName"), String)
        Me.Anchor = CType(resources.GetObject("$this.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.AutoScroll = CType(resources.GetObject("$this.AutoScroll"), Boolean)
        Me.AutoScrollMargin = CType(resources.GetObject("$this.AutoScrollMargin"), System.Drawing.Size)
        Me.AutoScrollMinSize = CType(resources.GetObject("$this.AutoScrollMinSize"), System.Drawing.Size)
        Me.BackgroundImage = CType(resources.GetObject("$this.BackgroundImage"), System.Drawing.Image)
        Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.CloseButton, Me.ErrorList, Me.ErrorInformationTitle})
        Me.Dock = CType(resources.GetObject("$this.Dock"), System.Windows.Forms.DockStyle)
        Me.Enabled = CType(resources.GetObject("$this.Enabled"), Boolean)
        Me.Font = CType(resources.GetObject("$this.Font"), System.Drawing.Font)
        Me.ImeMode = CType(resources.GetObject("$this.ImeMode"), System.Windows.Forms.ImeMode)
        Me.Location = CType(resources.GetObject("$this.Location"), System.Drawing.Point)
        Me.Name = "ErrorWindow"
        Me.RightToLeft = CType(resources.GetObject("$this.RightToLeft"), System.Windows.Forms.RightToLeft)
        Me.Size = CType(resources.GetObject("$this.Size"), System.Drawing.Size)
        Me.TabIndex = CType(resources.GetObject("$this.TabIndex"), Integer)
        Me.Visible = CType(resources.GetObject("$this.Visible"), Boolean)
        Me.ResumeLayout(False)

    End Sub

#End Region

    Public Sub ReportError(ByVal node As MemberNode, ByVal ErrorID As ErrorID, ByVal ParamArray Substitutions As String())
        Debug.Assert(ErrorID <> ErrorID.NoError, "Why report 'No Error'?")

        'Create a new error record and post it to the list.
        PostError(node, New ErrorRecord(node, ErrorID, Substitutions))
    End Sub

    Public Sub ReportError(ByVal node As MemberNode, ByVal descriptor As ContentDescriptor, ByVal ErrorID As ErrorID, ByVal ParamArray Substitutions As String())
        Debug.Assert(ErrorID <> ErrorID.NoError, "Why report 'No Error'?")

        'Create a new error record and post it to the list.
        PostError(node, descriptor, New ErrorRecord(node, ErrorID, Substitutions))
    End Sub

    Private Sub PostError(ByVal node As MemberNode, ByVal NewError As ErrorRecord)
        'Tell the node about this error.
        node.AddError(NewError)

        'Actually put the error in the list.
        Me.ErrorList.Items.Add(NewError)
    End Sub

    Private Sub PostError(ByVal node As MemberNode, ByVal descriptor As ContentDescriptor, ByVal NewError As ErrorRecord)
        PostError(node, NewError)

        'Tell the descriptor about this error.
        descriptor.AddError(NewError)
    End Sub

    Public Sub DeleteNodeFromErrorList(ByVal node As MemberNode)
        ' Deletes all errors from a node and removes those errors records from
        ' the error list.

        Debug.Assert(Not node.Errors Is Nothing, "Why try to delete a node which has no errors?")

        'Remove each Error the node is responsible for.
        Dim e As ErrorRecord
        For Each e In node.Errors
            Me.ErrorList.Items.Remove(e)
        Next

        'Remove all Errors from the node because they have all gone away.
        node.RemoveAllErrors()
    End Sub

    Public Sub DeleteError(ByVal node As MemberNode, ByVal OldError As ErrorRecord)
        Debug.Assert(Not node.Errors Is Nothing, "Why try to delete a node which has no errors?")

        'Remove the error record from the errors list.
        Me.ErrorList.Items.Remove(OldError)
        'And then tell the node to remove it as well.
        node.RemoveError(OldError)
        FileDirty = True
    End Sub

    Public Sub DeleteError(ByVal node As MemberNode, ByVal descriptor As ContentDescriptor, ByVal OldError As ErrorRecord)
        DeleteError(node, OldError)
        'Tell the descriptor to remove the error record from its list of errors.
        descriptor.RemoveError(OldError)
    End Sub

    Public Sub ClearAllItems()
        Me.ErrorList.Items.Clear()
    End Sub

    Private Sub OnErrorListDoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ErrorList.DoubleClick
        ' Signals that the user has double-clicked on an error record.  This
        ' event is handled by the main window to display the associated member
        ' node's window.

        RaiseEvent ErrorListDoubleClick(CType(Me.ErrorList.SelectedItems(0), ErrorRecord).Member)
    End Sub

    Private Sub OnColumnHeader_Click(ByVal sender As System.Object, ByVal e As System.Windows.Forms.ColumnClickEventArgs) Handles ErrorList.ColumnClick
        'Determine the kind of the comparison.  The column number determines the kind of the comparison.
        Dim kind As ErrorRecordComparer.CompareKind = CType(e.Column, ErrorRecordComparer.CompareKind)
        'Setting the list view item sorter will automatically call the sort function.
        Me.ErrorList.Columns(e.Column).ListView.ListViewItemSorter = New ErrorRecordComparer(kind)
    End Sub

    Private Sub ButtonClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CloseButton.Click
        ' Signals that this control requests to be closed.  When the close
        ' button is clicked we will just hide the window.

        RaiseEvent OnCloseButtonClicked()
    End Sub

    Public Sub AdjustColumns()
        ' Once the errors have been inserted into the list, the columns' sizes
        ' can be adjusted to fit the width of the largest item.

        'Adjust the "path" column.
        Me.ColumnDescription.Width = -1
        'Adjust the "description" column.
        'Me.ColumnPath.Width = -1  'This can be too wide so don't adjust it.
    End Sub

    Public ReadOnly Property ErrorCount() As Integer
        Get
            Return Me.ErrorList.Items.Count
        End Get
    End Property

    Public Sub BeginUpdate()
        Me.ErrorList.BeginUpdate()
    End Sub

    Public Sub EndUpdate()
        Me.ErrorList.EndUpdate()
    End Sub

End Class
