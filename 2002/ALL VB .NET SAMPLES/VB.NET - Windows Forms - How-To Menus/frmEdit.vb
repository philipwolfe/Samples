Public Class frmEdit
    Inherits System.Windows.Forms.Form

#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call

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
    Friend WithEvents MainMenu1 As System.Windows.Forms.MainMenu
    Friend WithEvents mnuSave As System.Windows.Forms.MenuItem
    Friend WithEvents mnuPrint As System.Windows.Forms.MenuItem
    Friend WithEvents mnuEdit As System.Windows.Forms.MenuItem
    Friend WithEvents mnuCut As System.Windows.Forms.MenuItem
    Friend WithEvents mnuCopy As System.Windows.Forms.MenuItem
    Friend WithEvents mnuPaste As System.Windows.Forms.MenuItem
    Friend WithEvents txtEdit As System.Windows.Forms.TextBox
    Friend WithEvents MenuItem1 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem2 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem3 As System.Windows.Forms.MenuItem
    Friend WithEvents mnuSize As System.Windows.Forms.MenuItem
    Friend WithEvents mnuSmall As System.Windows.Forms.MenuItem
    Friend WithEvents mnuMedium As System.Windows.Forms.MenuItem
    Friend WithEvents mnuLarge As System.Windows.Forms.MenuItem
    Friend WithEvents mnuUndo As System.Windows.Forms.MenuItem
    Friend WithEvents mnuFile As System.Windows.Forms.MenuItem
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmEdit))
        Me.txtEdit = New System.Windows.Forms.TextBox()
        Me.MainMenu1 = New System.Windows.Forms.MainMenu()
        Me.mnuFile = New System.Windows.Forms.MenuItem()
        Me.MenuItem1 = New System.Windows.Forms.MenuItem()
        Me.mnuSave = New System.Windows.Forms.MenuItem()
        Me.mnuPrint = New System.Windows.Forms.MenuItem()
        Me.MenuItem2 = New System.Windows.Forms.MenuItem()
        Me.mnuEdit = New System.Windows.Forms.MenuItem()
        Me.mnuUndo = New System.Windows.Forms.MenuItem()
        Me.mnuCut = New System.Windows.Forms.MenuItem()
        Me.mnuCopy = New System.Windows.Forms.MenuItem()
        Me.mnuPaste = New System.Windows.Forms.MenuItem()
        Me.MenuItem3 = New System.Windows.Forms.MenuItem()
        Me.mnuSize = New System.Windows.Forms.MenuItem()
        Me.mnuSmall = New System.Windows.Forms.MenuItem()
        Me.mnuMedium = New System.Windows.Forms.MenuItem()
        Me.mnuLarge = New System.Windows.Forms.MenuItem()
        Me.SuspendLayout()
        '
        'txtEdit
        '
        Me.txtEdit.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtEdit.Multiline = True
        Me.txtEdit.Name = "txtEdit"
        Me.txtEdit.Size = New System.Drawing.Size(292, 154)
        Me.txtEdit.TabIndex = 0
        Me.txtEdit.Text = ""
        '
        'MainMenu1
        '
        Me.MainMenu1.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.mnuFile, Me.mnuEdit})
        '
        'mnuFile
        '
        Me.mnuFile.Index = 0
        Me.mnuFile.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.MenuItem1, Me.mnuSave, Me.mnuPrint, Me.MenuItem2})
        Me.mnuFile.MergeType = System.Windows.Forms.MenuMerge.MergeItems
        Me.mnuFile.Text = "&File"
        '
        'MenuItem1
        '
        Me.MenuItem1.Index = 0
        Me.MenuItem1.MergeOrder = 1
        Me.MenuItem1.Text = "-"
        '
        'mnuSave
        '
        Me.mnuSave.Index = 1
        Me.mnuSave.MergeOrder = 2
        Me.mnuSave.MergeType = System.Windows.Forms.MenuMerge.MergeItems
        Me.mnuSave.Text = "&Save"
        '
        'mnuPrint
        '
        Me.mnuPrint.Index = 2
        Me.mnuPrint.MergeOrder = 3
        Me.mnuPrint.MergeType = System.Windows.Forms.MenuMerge.MergeItems
        Me.mnuPrint.Text = "&Print"
        '
        'MenuItem2
        '
        Me.MenuItem2.Index = 3
        Me.MenuItem2.MergeOrder = 4
        Me.MenuItem2.Text = "-"
        '
        'mnuEdit
        '
        Me.mnuEdit.Index = 1
        Me.mnuEdit.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.mnuUndo, Me.mnuCut, Me.mnuCopy, Me.mnuPaste, Me.MenuItem3, Me.mnuSize})
        Me.mnuEdit.MergeOrder = 5
        Me.mnuEdit.Text = "&Edit"
        '
        'mnuUndo
        '
        Me.mnuUndo.Index = 0
        Me.mnuUndo.Text = "&Undo"
        '
        'mnuCut
        '
        Me.mnuCut.Index = 1
        Me.mnuCut.Shortcut = System.Windows.Forms.Shortcut.CtrlX
        Me.mnuCut.Text = "Cu&t"
        '
        'mnuCopy
        '
        Me.mnuCopy.Index = 2
        Me.mnuCopy.Shortcut = System.Windows.Forms.Shortcut.CtrlC
        Me.mnuCopy.Text = "&Copy"
        '
        'mnuPaste
        '
        Me.mnuPaste.Index = 3
        Me.mnuPaste.Shortcut = System.Windows.Forms.Shortcut.CtrlV
        Me.mnuPaste.Text = "&Paste"
        '
        'MenuItem3
        '
        Me.MenuItem3.Index = 4
        Me.MenuItem3.Text = "-"
        '
        'mnuSize
        '
        Me.mnuSize.Index = 5
        Me.mnuSize.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.mnuSmall, Me.mnuMedium, Me.mnuLarge})
        Me.mnuSize.Text = "Text &Size"
        '
        'mnuSmall
        '
        Me.mnuSmall.Checked = True
        Me.mnuSmall.Index = 0
        Me.mnuSmall.RadioCheck = True
        Me.mnuSmall.Text = "&Small"
        '
        'mnuMedium
        '
        Me.mnuMedium.Index = 1
        Me.mnuMedium.RadioCheck = True
        Me.mnuMedium.Text = "&Medium"
        '
        'mnuLarge
        '
        Me.mnuLarge.Index = 2
        Me.mnuLarge.RadioCheck = True
        Me.mnuLarge.Text = "&Large"
        '
        'frmEdit
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(292, 154)
        Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.txtEdit})
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Menu = Me.MainMenu1
        Me.Name = "frmEdit"
        Me.Text = "Demonstrate Menus and Toolbars"
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private Enum FontSize
        Small = 8
        Medium = 12
        Large = 16
    End Enum

    Private mblnModified As Boolean = False

    Private Sub mnuCopy_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuCopy.Click
        Copy()
    End Sub

    Private Sub mnuCut_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuCut.Click
        Cut()
    End Sub

    Private Sub mnuEdit_Popup(ByVal sender As Object, ByVal e As System.EventArgs) Handles mnuEdit.Popup
        HandleEditItems()
    End Sub

    Private Sub mnuFile_Popup(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuFile.Popup
        HandleFileItems()
    End Sub

    Private Sub mnuLarge_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuLarge.Click
        SetLargeFont()
    End Sub

    Private Sub mnuMedium_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuMedium.Click
        SetMediumFont()
    End Sub

    Private Sub mnuPaste_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuPaste.Click
        Paste()
    End Sub

    Private Sub mnuPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuPrint.Click
        Print()
    End Sub


    Private Sub mnuSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuSave.Click
        Save()
    End Sub

    Private Sub mnuSmall_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuSmall.Click
        SetSmallFont()
    End Sub

    Private Sub mnuUndo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuUndo.Click
        Undo()
    End Sub

    Private Sub txtEdit_ModifiedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtEdit.ModifiedChanged
        ' When the text box is modified, set the 
        ' mblnModified value.
        mblnModified = True
    End Sub

    Private Sub ClearStatus(ByVal sender As System.Object, ByVal e As System.EventArgs) _
     Handles mnuCopy.Click, mnuCut.Click, mnuEdit.Click, mnuFile.Click, mnuLarge.Click, _
     mnuMedium.Click, mnuPaste.Click, mnuPrint.Click, mnuSave.Click, mnuSize.Click, _
     mnuSmall.Click, mnuUndo.Click
        ClearStatusBar()
    End Sub

    Private Sub ClearStatusBar()
        Try
            CType(Me.ParentForm, frmMain).ClearStatusBar()
        Catch
            ' Do nothing at all if this fails.
        End Try
    End Sub

    Public Sub Copy()
        txtEdit.Copy()
    End Sub

    Public Sub Cut()
        txtEdit.Cut()
    End Sub

    Private Sub HandleEditItems()
        ' Determine if the the Cut/Copy/Paste menu items 
        ' should be enabled.

        ' Paste is enabled if the Clipboard object contains text.
        Dim iData As IDataObject = Clipboard.GetDataObject()
        mnuPaste.Enabled = iData.GetDataPresent(GetType(String))

        ' Cut and Copy are enabled if the text box contains
        ' one or more selected characters. 
        Dim blnEnable As Boolean = (txtEdit.SelectedText.Length > 0)
        mnuCut.Enabled = blnEnable
        mnuCopy.Enabled = blnEnable

        ' Handle Undo text.
        If txtEdit.CanUndo Then
            mnuUndo.Text = "&Undo"
            mnuUndo.Enabled = True
        Else
            mnuUndo.Text = "Nothing to Undo"
            mnuUndo.Enabled = False
        End If
    End Sub

    Private Sub HandleFileItems()
        mnuPrint.Enabled = (txtEdit.Text.Length > 0)
        mnuSave.Enabled = mblnModified
    End Sub

    Private Sub HandleStatus(ByVal sender As System.Object, ByVal e As System.EventArgs) _
     Handles mnuSave.Select, mnuCopy.Select, mnuCut.Select, mnuLarge.Select, mnuMedium.Select, mnuSmall.Select, _
     mnuPrint.Select, mnuPaste.Select, mnuUndo.Select, mnuSize.Select, mnuEdit.Select, mnuFile.Select

        Dim strText As String

        If sender Is mnuSave Then
            strText = "Save the current contents"
        ElseIf sender Is mnuCopy Then
            strText = "Copy selected text to the clipboard"
        ElseIf sender Is mnuCut Then
            strText = "Cut selected text to the clipboard"
        ElseIf sender Is mnuLarge Then
            strText = "Display text using large font"
        ElseIf sender Is mnuMedium Then
            strText = "Display text using medium font"
        ElseIf sender Is mnuSmall Then
            strText = "Display text using small font"
        ElseIf sender Is mnuPrint Then
            strText = "Print the current contents"
        ElseIf sender Is mnuPaste Then
            strText = "Paste the contents of the clipboard"
        ElseIf sender Is mnuUndo Then
            strText = "Undo changes to contents"
        Else
            strText = String.Empty
        End If

        CType(Me.ParentForm, frmMain).WriteToStatusBar(strText)
    End Sub

    Public Sub Paste()
        txtEdit.Paste()
    End Sub

    Public Sub Print()
        MessageBox.Show("Add code to print your document here", Me.Text)
    End Sub

    Public Sub Save()
        MessageBox.Show("Add code to save your document here", Me.Text)
    End Sub

    Public Sub SetLargeFont()
        SetSize(FontSize.Large)
    End Sub

    Public Sub SetMediumFont()
        SetSize(FontSize.Medium)
    End Sub

    Public Sub SetSmallFont()
        SetSize(FontSize.Small)
    End Sub

    Private Sub SetSize(ByVal Size As FontSize)
        Dim fnt As New Font(txtEdit.Font.FontFamily, CType(Size, Integer))
        txtEdit.Font = fnt

        ' Uncheck them all!
        mnuSmall.Checked = False
        mnuMedium.Checked = False
        mnuLarge.Checked = False

        ' Now check the appropriate item.
        Select Case Size
            Case FontSize.Small
                mnuSmall.Checked = True
            Case FontSize.Medium
                mnuMedium.Checked = True
            Case FontSize.Large
                mnuLarge.Checked = True
        End Select
    End Sub

    Public Sub Undo()
        txtEdit.Undo()
    End Sub

End Class
