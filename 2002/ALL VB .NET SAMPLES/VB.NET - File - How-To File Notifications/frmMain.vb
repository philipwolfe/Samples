'Copyright (C) 2002 Microsoft Corporation
'All rights reserved.
'THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, EITHER 
'EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED WARRANTIES OF 
'MERCHANTIBILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.

'Requires the Trial or Release version of Visual Studio .NET Professional (or greater).

Option Strict On
Imports System.IO
Imports System.Enum

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
    Friend WithEvents lblPath As System.Windows.Forms.Label
    Friend WithEvents txtPath As System.Windows.Forms.TextBox
    Friend WithEvents chkEvents As System.Windows.Forms.CheckBox
    Friend WithEvents txtFilter As System.Windows.Forms.TextBox
    Friend WithEvents lblFilter As System.Windows.Forms.Label
    Friend WithEvents chkIncludeSubdirectories As System.Windows.Forms.CheckBox
    Friend WithEvents clstNotifyFilter As System.Windows.Forms.CheckedListBox
    Friend WithEvents lblNotifyFilter As System.Windows.Forms.Label
    Friend WithEvents fsw As System.IO.FileSystemWatcher
    Friend WithEvents btnClear As System.Windows.Forms.Button
    Friend WithEvents lstEvents As System.Windows.Forms.ListBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents btnCreate As System.Windows.Forms.Button
    Friend WithEvents cboSampleFile As System.Windows.Forms.ComboBox
    Friend WithEvents btnRename As System.Windows.Forms.Button
    Friend WithEvents btnModify As System.Windows.Forms.Button
    Friend WithEvents btnDelete As System.Windows.Forms.Button
    Friend WithEvents btnDeleteAll As System.Windows.Forms.Button
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmMain))
        Me.mnuMain = New System.Windows.Forms.MainMenu()
        Me.mnuFile = New System.Windows.Forms.MenuItem()
        Me.mnuExit = New System.Windows.Forms.MenuItem()
        Me.mnuHelp = New System.Windows.Forms.MenuItem()
        Me.mnuAbout = New System.Windows.Forms.MenuItem()
        Me.lblPath = New System.Windows.Forms.Label()
        Me.txtPath = New System.Windows.Forms.TextBox()
        Me.chkEvents = New System.Windows.Forms.CheckBox()
        Me.txtFilter = New System.Windows.Forms.TextBox()
        Me.lblFilter = New System.Windows.Forms.Label()
        Me.chkIncludeSubdirectories = New System.Windows.Forms.CheckBox()
        Me.clstNotifyFilter = New System.Windows.Forms.CheckedListBox()
        Me.lblNotifyFilter = New System.Windows.Forms.Label()
        Me.btnDelete = New System.Windows.Forms.Button()
        Me.btnModify = New System.Windows.Forms.Button()
        Me.btnRename = New System.Windows.Forms.Button()
        Me.cboSampleFile = New System.Windows.Forms.ComboBox()
        Me.btnCreate = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btnClear = New System.Windows.Forms.Button()
        Me.lstEvents = New System.Windows.Forms.ListBox()
        Me.fsw = New System.IO.FileSystemWatcher()
        Me.btnDeleteAll = New System.Windows.Forms.Button()
        CType(Me.fsw, System.ComponentModel.ISupportInitialize).BeginInit()
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
        'lblPath
        '
        Me.lblPath.Location = New System.Drawing.Point(8, 8)
        Me.lblPath.Name = "lblPath"
        Me.lblPath.Size = New System.Drawing.Size(64, 23)
        Me.lblPath.TabIndex = 0
        Me.lblPath.Text = "Path"
        Me.lblPath.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtPath
        '
        Me.txtPath.Location = New System.Drawing.Point(80, 8)
        Me.txtPath.Name = "txtPath"
        Me.txtPath.Size = New System.Drawing.Size(136, 20)
        Me.txtPath.TabIndex = 1
        Me.txtPath.Text = "C:\"
        '
        'chkEvents
        '
        Me.chkEvents.Appearance = System.Windows.Forms.Appearance.Button
        Me.chkEvents.Location = New System.Drawing.Point(80, 208)
        Me.chkEvents.Name = "chkEvents"
        Me.chkEvents.Size = New System.Drawing.Size(144, 24)
        Me.chkEvents.TabIndex = 2
        Me.chkEvents.Text = "&Enable Raising Events"
        Me.chkEvents.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'txtFilter
        '
        Me.txtFilter.Location = New System.Drawing.Point(80, 32)
        Me.txtFilter.Name = "txtFilter"
        Me.txtFilter.Size = New System.Drawing.Size(136, 20)
        Me.txtFilter.TabIndex = 4
        Me.txtFilter.Text = "*.*"
        '
        'lblFilter
        '
        Me.lblFilter.Location = New System.Drawing.Point(8, 32)
        Me.lblFilter.Name = "lblFilter"
        Me.lblFilter.Size = New System.Drawing.Size(64, 23)
        Me.lblFilter.TabIndex = 3
        Me.lblFilter.Text = "Filter"
        Me.lblFilter.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'chkIncludeSubdirectories
        '
        Me.chkIncludeSubdirectories.Location = New System.Drawing.Point(80, 184)
        Me.chkIncludeSubdirectories.Name = "chkIncludeSubdirectories"
        Me.chkIncludeSubdirectories.Size = New System.Drawing.Size(144, 24)
        Me.chkIncludeSubdirectories.TabIndex = 5
        Me.chkIncludeSubdirectories.Text = "Include Subdirectories"
        '
        'clstNotifyFilter
        '
        Me.clstNotifyFilter.CheckOnClick = True
        Me.clstNotifyFilter.Location = New System.Drawing.Point(80, 56)
        Me.clstNotifyFilter.Name = "clstNotifyFilter"
        Me.clstNotifyFilter.Size = New System.Drawing.Size(136, 124)
        Me.clstNotifyFilter.TabIndex = 6
        '
        'lblNotifyFilter
        '
        Me.lblNotifyFilter.Location = New System.Drawing.Point(8, 56)
        Me.lblNotifyFilter.Name = "lblNotifyFilter"
        Me.lblNotifyFilter.Size = New System.Drawing.Size(64, 23)
        Me.lblNotifyFilter.TabIndex = 7
        Me.lblNotifyFilter.Text = "Notify Filter"
        Me.lblNotifyFilter.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'btnDelete
        '
        Me.btnDelete.Enabled = False
        Me.btnDelete.Location = New System.Drawing.Point(272, 104)
        Me.btnDelete.Name = "btnDelete"
        Me.btnDelete.Size = New System.Drawing.Size(160, 23)
        Me.btnDelete.TabIndex = 8
        Me.btnDelete.Text = "Delete Sample File"
        '
        'btnModify
        '
        Me.btnModify.Enabled = False
        Me.btnModify.Location = New System.Drawing.Point(272, 80)
        Me.btnModify.Name = "btnModify"
        Me.btnModify.Size = New System.Drawing.Size(160, 23)
        Me.btnModify.TabIndex = 7
        Me.btnModify.Text = "Modify Sample File"
        '
        'btnRename
        '
        Me.btnRename.Enabled = False
        Me.btnRename.Location = New System.Drawing.Point(272, 56)
        Me.btnRename.Name = "btnRename"
        Me.btnRename.Size = New System.Drawing.Size(160, 23)
        Me.btnRename.TabIndex = 6
        Me.btnRename.Text = "Rename Sample File"
        '
        'cboSampleFile
        '
        Me.cboSampleFile.Anchor = ((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right)
        Me.cboSampleFile.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboSampleFile.Location = New System.Drawing.Point(272, 8)
        Me.cboSampleFile.Name = "cboSampleFile"
        Me.cboSampleFile.Size = New System.Drawing.Size(400, 21)
        Me.cboSampleFile.TabIndex = 5
        '
        'btnCreate
        '
        Me.btnCreate.Location = New System.Drawing.Point(272, 32)
        Me.btnCreate.Name = "btnCreate"
        Me.btnCreate.Size = New System.Drawing.Size(160, 23)
        Me.btnCreate.TabIndex = 4
        Me.btnCreate.Text = "Create Sample File"
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(232, 8)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(32, 23)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "File"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'btnClear
        '
        Me.btnClear.Anchor = (System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left)
        Me.btnClear.Location = New System.Drawing.Point(440, 208)
        Me.btnClear.Name = "btnClear"
        Me.btnClear.Size = New System.Drawing.Size(88, 23)
        Me.btnClear.TabIndex = 1
        Me.btnClear.Text = "&Clear"
        '
        'lstEvents
        '
        Me.lstEvents.Anchor = (((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right)
        Me.lstEvents.IntegralHeight = False
        Me.lstEvents.Location = New System.Drawing.Point(440, 32)
        Me.lstEvents.Name = "lstEvents"
        Me.lstEvents.Size = New System.Drawing.Size(232, 168)
        Me.lstEvents.TabIndex = 0
        '
        'fsw
        '
        Me.fsw.Path = "C:\"
        Me.fsw.SynchronizingObject = Me
        '
        'btnDeleteAll
        '
        Me.btnDeleteAll.Location = New System.Drawing.Point(272, 128)
        Me.btnDeleteAll.Name = "btnDeleteAll"
        Me.btnDeleteAll.Size = New System.Drawing.Size(160, 23)
        Me.btnDeleteAll.TabIndex = 9
        Me.btnDeleteAll.Text = "Delete All Sample Files"
        '
        'frmMain
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(674, 233)
        Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.btnDeleteAll, Me.chkIncludeSubdirectories, Me.lblPath, Me.clstNotifyFilter, Me.lblNotifyFilter, Me.txtFilter, Me.txtPath, Me.lblFilter, Me.chkEvents, Me.Label1, Me.btnClear, Me.btnCreate, Me.btnModify, Me.btnDelete, Me.cboSampleFile, Me.lstEvents, Me.btnRename})
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Menu = Me.mnuMain
        Me.MinimumSize = New System.Drawing.Size(682, 280)
        Me.Name = "frmMain"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Title Comes from Assembly Info"
        CType(Me.fsw, System.ComponentModel.ISupportInitialize).EndInit()
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

    ' When the code creates temporary files, it will use this 
    ' name as its root.
    Private Const FILE_ROOT As String = "Tempfile.txt"

    Private Sub btnClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClear.Click
        ' Clear the list of file events.
        lstEvents.Items.Clear()
    End Sub

    Private Sub btnCreate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCreate.Click
        Try
            Dim strFile As String = GetUniqueFileName(fsw.Path, FILE_ROOT)

            ' Create the file and immediately close it.
            File.Create(strFile).Close()

            ' Add the new file to the combo box.
            cboSampleFile.Items.Add(strFile)
            cboSampleFile.Text = strFile

            ' Enable and disable buttons.
            HandleItems()

        Catch exp As Exception
            MessageBox.Show(exp.Message, Me.Text)
        End Try
    End Sub

    Private Sub btnDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDelete.Click
        Dim strName As String = cboSampleFile.Text

        ' If the file still exists, delete it, and fix up the combo box to match.
        If CheckFile(strName) Then
            Try
                File.Delete(strName)
                RemoveFileName(strName)
                HandleItems()

            Catch exp As Exception
                MessageBox.Show(exp.Message, Me.Text)
            End Try
        End If
    End Sub

    Private Sub btnModify_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnModify.Click
        Dim strName As String = cboSampleFile.Text

        ' If the file still exists, modify it.
        If CheckFile(strName) Then
            Try
                Dim fs As New FileStream(cboSampleFile.Text, FileMode.Append)
                Dim sw As New StreamWriter(fs)
                sw.WriteLine("This is more text")
                sw.Close()
                fs.Close()

            Catch exp As Exception
                MessageBox.Show(exp.Message, Me.Text)
            End Try
        End If
    End Sub

    Private Sub btnRename_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRename.Click
        Dim strOld As String
        Dim strNew As String

        ' If the file still exists, rename it.
        strOld = cboSampleFile.Text
        If CheckFile(strOld) Then
            strNew = GetUniqueFileName(Path.GetDirectoryName(strOld), Path.GetFileName(strOld))
            Try
                File.Move(strOld, strNew)
                cboSampleFile.Items.Remove(strOld)
                cboSampleFile.Items.Add(strNew)
                cboSampleFile.Text = strNew

            Catch exp As Exception
                MessageBox.Show(exp.Message, Me.Text)
            End Try
        End If
    End Sub

    Private Sub cboSampleFile_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboSampleFile.SelectedIndexChanged
        ' Check to make sure the selected file is still around. If not, 
        ' ask to have it removed.
        CheckFile(cboSampleFile.Text)
        HandleItems()
    End Sub

    Private Sub chkEvents_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkEvents.CheckedChanged
        Dim blnIsRunning As Boolean

        If chkEvents.Checked Then
            Try
                GatherFSWProperties(fsw)
            Catch exp As Exception
                MessageBox.Show(exp.Message, Me.Text)
                chkEvents.Checked = False
            End Try
        End If

        ' Is the FileSystemWatcher component
        ' monitoring file changes?
        blnIsRunning = chkEvents.Checked
        fsw.EnableRaisingEvents = blnIsRunning

        ' If the events are enabled, disable
        ' all the controls for gathering properties.
        ' Otherwise, enable the controls.
        txtPath.Enabled = Not blnIsRunning
        txtFilter.Enabled = Not blnIsRunning
        chkIncludeSubdirectories.Enabled = Not blnIsRunning
        clstNotifyFilter.Enabled = Not blnIsRunning
    End Sub

    Private Sub frmMain_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ' Add the names from the Enum to the CheckedListBox
        ' control. You can bind the data source to the return 
        ' value from the GetValues method, supplying an enumeration type.

        ' The GetValues method comes from the System.Enum namespace. It 
        ' requires an enumeration type, and returns an array of values
        ' corresponding to the items in the enumeration. This adds the 
        ' list of NotifyFilter values to the CheckedListBox control.
        clstNotifyFilter.DataSource = GetValues(GetType(NotifyFilters))

        ' Display all the properties of the FileSystemWatcher object.
        DisplayFSWProperties(fsw)
    End Sub

    Private Sub fsw_Error(ByVal sender As Object, ByVal e As System.IO.ErrorEventArgs) Handles fsw.Error
        Dim exp As Exception = e.GetException
        AddItem(exp.Message)
    End Sub

    Private Sub fsw_Renamed(ByVal sender As Object, ByVal e As System.IO.RenamedEventArgs) Handles fsw.Renamed
        Dim strText As String = String.Format("{0} was renamed to {1}", e.OldName, e.Name)
        AddItem(strText)
    End Sub

    Private Sub AddItem(ByVal strText As String)
        lstEvents.Items.Add(strText)
    End Sub

    Private Function CheckFile(ByVal strFileName As String) As Boolean
        ' Check to make sure the selected file is still around. If not, 
        ' ask to have it removed.
        If File.Exists(strFileName) Then
            Return True
        Else
            MessageBox.Show("The selected file has been deleted. It will be removed from this list as well.")
            RemoveFileName(strFileName)
            HandleItems()
            Return False
        End If
    End Function

    Private Sub DisplayFSWProperties(ByVal fsw As FileSystemWatcher)
        SetChecks(fsw.NotifyFilter, clstNotifyFilter)
        txtPath.Text = fsw.Path
        txtFilter.Text = fsw.Filter
        chkEvents.Checked = fsw.EnableRaisingEvents
        chkIncludeSubdirectories.Checked = fsw.IncludeSubdirectories
    End Sub

    Private Sub GatherFSWProperties(ByVal fsw As FileSystemWatcher)
        ' This code may raise errors, but the caller will
        ' need to catch them!
        fsw.Path = txtPath.Text
        fsw.Filter = txtFilter.Text
        fsw.IncludeSubdirectories = chkIncludeSubdirectories.Checked
        fsw.NotifyFilter = CType(GetChecks(clstNotifyFilter), NotifyFilters)
    End Sub

    Private Function GetChecks(ByVal clst As CheckedListBox) As Integer
        ' Loop through all the items in the CheckedListBox, 
        ' and generate an integer value corresponding to all the 
        ' selected bits. Each item in the CheckedListBox is actually
        ' an integer (from an enumeration), so you simply need
        ' to convert each object into an integer, then OR it with 
        ' the result.

        Dim intValue As Integer
        Dim obj As Object

        Try
            For Each obj In clst.CheckedItems
                intValue = intValue Or CInt(obj)
            Next
            Return intValue
        Catch exp As Exception
            MessageBox.Show(exp.Message, Me.Text)
        End Try
    End Function

    Private Function GetUniqueFileName(ByVal Path As String, ByVal Root As String) As String
        ' Generate a unique file name, using Root as the file name root, in the 
        ' specified path. For example, if Path is C:\ and Root is TempFile.txt,
        ' the procedure will attempt to return C:\TempFile.txt.00. If that file 
        ' exists, it will attempt to return C:\TempFile.txt.01, incrementing
        ' the value until it finds a name that doesn't already exist.
        Dim strTemp As String
        Dim i As Integer

        ' Remove \ or space from the end of the path.
        ' Remove . or space from the end of the file name.
        Path = Path.TrimEnd("\ ".ToCharArray)
        Root = Root.TrimEnd(". ".ToCharArray)

        ' Loop, incrementing a counter, until you find 
        ' a file that doesn't already exist.
        Do
            strTemp = String.Format("{0}\{1}.{2:00}", Path, Root, i)
            i += 1
        Loop While File.Exists(strTemp) And i < 100
        Return strTemp
        ' If you had 100 of these files already, you'll end up overwriting
        ' .99. Sorry.
    End Function

    Private Sub HandleChangedCreatedDeleted(ByVal sender As Object, ByVal e As System.IO.FileSystemEventArgs) Handles fsw.Changed, fsw.Created, fsw.Deleted
        ' This one procedure can handle the Changed, Created, and Deleted events, 
        ' because they all have the same event signature.
        Dim strText As String = String.Format("{0} was {1}", e.Name, e.ChangeType)
        AddItem(strText)
    End Sub

    Private Sub HandleItems()
        ' Enable or Disable buttons.
        Dim blnEnable As Boolean = (cboSampleFile.Text <> String.Empty)
        btnModify.Enabled = blnEnable
        btnDelete.Enabled = blnEnable
        btnRename.Enabled = blnEnable
    End Sub

    Private Sub RemoveFileName(ByVal strFileName As String)
        ' Remove the specified file name from 
        ' the combo box. If there are other file names
        ' to be had, select the first one.
        cboSampleFile.Items.Remove(strFileName)
        If cboSampleFile.Items.Count > 0 Then
            cboSampleFile.Text = cboSampleFile.Items(0).ToString
        End If
    End Sub

    Private Sub SetChecks(ByVal Value As Integer, ByVal clst As CheckedListBox)
        Dim intValue As Integer
        Dim i As Integer
        Dim blnCheck As Boolean

        ' Loop through each item in the CheckedListBox control.
        ' For each item, if the bit corresponding to the 
        ' current enumerated value is set, check the 
        ' corresponding item in the list.
        For i = 0 To clst.Items.Count - 1
            intValue = CInt(clst.Items(i))
            blnCheck = ((intValue And Value) = intValue)
            clst.SetItemChecked(i, blnCheck)
        Next
    End Sub

    Private Sub btnDeleteAll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDeleteAll.Click
        ' Delete all the files in the combo box.
        Dim strName As String
        For Each strName In cboSampleFile.Items
            Try
                File.Delete(strName)
            Catch
                ' If you can't delete the file, it must 
                ' already be deleted. Just go on.
            End Try
        Next
        cboSampleFile.Items.Clear()
        HandleItems()
    End Sub
End Class