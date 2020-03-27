Imports System.Diagnostics
Imports System.Collections.Specialized

Partial Public Class frmMain
    Inherits Form

    Private outputLines As StringCollection = New StringCollection()
    Public Sub frmMain()
        InitializeComponent()

        lvNativeImageCache.Columns(0).Width = 300
        lvNativeImageCache.Columns(1).Width = 77
        lvNativeImageCache.Columns(2).Width = 72
        lvNativeImageCache.Columns(3).Width = 200
    End Sub

    Private Sub ParseNGENOutput(ByVal ngenOutput As StringCollection)
        If ngenOutput Is Nothing Then
            Return
        End If

        Dim nativeImageSectionReached As Boolean = False

        Dim line As String

        For Each line In ngenOutput

            If nativeImageSectionReached Then
                If line.Trim().Length > 0 Then

                    Dim assemblyNameParts() As String = line.Split(New Char() {","c})

                    If assemblyNameParts.Length > 4 Then
                        Dim index As Integer = assemblyNameParts(1).IndexOf("=")
                        assemblyNameParts(1) = assemblyNameParts(1).Substring(index + 1)

                        index = assemblyNameParts(2).IndexOf("=")
                        assemblyNameParts(2) = assemblyNameParts(2).Substring(index + 1)

                        index = assemblyNameParts(3).IndexOf("=")
                        assemblyNameParts(3) = assemblyNameParts(3).Substring(index + 1)

                        lvNativeImageCache.Items.Add(New ListViewItem(assemblyNameParts))
                    End If
                End If
            Else
                nativeImageSectionReached = (String.Compare(line.Trim(), 0, "Native Images:", 0, 14) = 0)
            End If

        Next

        If lvNativeImageCache.Items.Count > 1 Then
            lvNativeImageCache.Sorting = SortOrder.Ascending
            lvNativeImageCache.Sort()
        End If

    End Sub


    Private Sub InitializeComponent()
        Me.btnInstall = New System.Windows.Forms.Button
        Me.btnViewCache = New System.Windows.Forms.Button
        Me.btnUninstall = New System.Windows.Forms.Button
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.chkConfirm = New System.Windows.Forms.CheckBox
        Me.lvNativeImageCache = New System.Windows.Forms.ListView
        Me.Label4 = New System.Windows.Forms.Label
        Me.columnName = New System.Windows.Forms.ColumnHeader
        Me.columnVersion = New System.Windows.Forms.ColumnHeader
        Me.columnCulture = New System.Windows.Forms.ColumnHeader
        Me.columnPublicKeyToken = New System.Windows.Forms.ColumnHeader
        Me.SuspendLayout()
        '
        'btnInstall
        '
        Me.btnInstall.Location = New System.Drawing.Point(446, 22)
        Me.btnInstall.Name = "btnInstall"
        Me.btnInstall.Size = New System.Drawing.Size(150, 23)
        Me.btnInstall.TabIndex = 0
        Me.btnInstall.Text = "Install"
        Me.btnInstall.UseVisualStyleBackColor = True
        '
        'btnViewCache
        '
        Me.btnViewCache.Location = New System.Drawing.Point(446, 63)
        Me.btnViewCache.Name = "btnViewCache"
        Me.btnViewCache.Size = New System.Drawing.Size(150, 23)
        Me.btnViewCache.TabIndex = 1
        Me.btnViewCache.Text = "View Native Image Cache"
        Me.btnViewCache.UseVisualStyleBackColor = True
        '
        'btnUninstall
        '
        Me.btnUninstall.Location = New System.Drawing.Point(446, 106)
        Me.btnUninstall.Name = "btnUninstall"
        Me.btnUninstall.Size = New System.Drawing.Size(150, 23)
        Me.btnUninstall.TabIndex = 2
        Me.btnUninstall.Text = "Uninstall"
        Me.btnUninstall.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(12, 22)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(386, 32)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "Install: Browse for an assembly file to install into the .NET Native Image Cache." & _
            ""
        '
        'Label2
        '
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(12, 63)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(293, 23)
        Me.Label2.TabIndex = 4
        Me.Label2.Text = "View the contents of the Native Image Cache"
        '
        'Label3
        '
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(15, 106)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(383, 32)
        Me.Label3.TabIndex = 5
        Me.Label3.Text = "Uninstall: Removes the selected assemblies from the Native Image Cache."
        '
        'chkConfirm
        '
        Me.chkConfirm.AutoSize = True
        Me.chkConfirm.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkConfirm.Location = New System.Drawing.Point(18, 162)
        Me.chkConfirm.Name = "chkConfirm"
        Me.chkConfirm.Size = New System.Drawing.Size(214, 17)
        Me.chkConfirm.TabIndex = 6
        Me.chkConfirm.Text = "Prompt for Uninstall confirmation."
        Me.chkConfirm.UseVisualStyleBackColor = True
        '
        'lvNativeImageCache
        '
        Me.lvNativeImageCache.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.columnName, Me.columnVersion, Me.columnCulture, Me.columnPublicKeyToken})
        Me.lvNativeImageCache.Location = New System.Drawing.Point(18, 227)
        Me.lvNativeImageCache.Name = "lvNativeImageCache"
        Me.lvNativeImageCache.Size = New System.Drawing.Size(578, 217)
        Me.lvNativeImageCache.TabIndex = 7
        Me.lvNativeImageCache.UseCompatibleStateImageBehavior = False
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(13, 208)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(126, 13)
        Me.Label4.TabIndex = 8
        Me.Label4.Text = "Native Image Cache:"
        '
        'columnName
        '
        Me.columnName.Text = "Assembly Name"
        '
        'columnVersion
        '
        Me.columnVersion.Text = "Version"
        '
        'columnCulture
        '
        Me.columnCulture.Text = "Culture"
        '
        'columnPublicKeyToken
        '
        Me.columnPublicKeyToken.Text = "Public Key Token"
        '
        'frmMain
        '
        Me.ClientSize = New System.Drawing.Size(618, 456)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.lvNativeImageCache)
        Me.Controls.Add(Me.chkConfirm)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.btnUninstall)
        Me.Controls.Add(Me.btnViewCache)
        Me.Controls.Add(Me.btnInstall)
        Me.Name = "frmMain"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnInstall As System.Windows.Forms.Button
    Friend WithEvents btnViewCache As System.Windows.Forms.Button
    Friend WithEvents btnUninstall As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents chkConfirm As System.Windows.Forms.CheckBox
    Friend WithEvents lvNativeImageCache As System.Windows.Forms.ListView
    Friend WithEvents columnName As System.Windows.Forms.ColumnHeader
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents columnVersion As System.Windows.Forms.ColumnHeader
    Friend WithEvents columnCulture As System.Windows.Forms.ColumnHeader
    Friend WithEvents columnPublicKeyToken As System.Windows.Forms.ColumnHeader



    Private Sub btnInstall_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnInstall.Click
        Dim saveCursor As Cursor = Nothing

        Try
            ' Allow the user to browse for an assembly to install.
            Dim fileDialog As OpenFileDialog = New OpenFileDialog()
            fileDialog.Filter = "Executable Assemblies (*.exe)|*.exe|Class Library Assemblies (*.dll)|*.dll"
            fileDialog.CheckFileExists = True
            fileDialog.CheckPathExists = True
            fileDialog.DereferenceLinks = True
            MessageBox.Show("got here")

            If System.Windows.Forms.DialogResult.OK = fileDialog.ShowDialog() Then
                saveCursor = Me.Cursor
                Me.Cursor = Cursors.WaitCursor

                Dim output As StringCollection = NGenController.Run(NGenCommand.Install, fileDialog.FileName)

                Me.Cursor = saveCursor

                ' Refresh the list of installed images if it was already visible.
                If Not lvNativeImageCache.Items Is Nothing And lvNativeImageCache.Items.Count > 0 Then
                    btnViewCache_Click(sender, e)
                End If
            End If

        Catch
            If Not saveCursor Is Nothing Then
                Me.Cursor = saveCursor
            End If
        End Try

    End Sub

    Private Sub btnViewCache_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnViewCache.Click
        Dim saveCursor As Cursor = Nothing

        Try
            lvNativeImageCache.Items.Clear()

            saveCursor = Me.Cursor
            Me.Cursor = Cursors.WaitCursor

            Dim output As StringCollection = NGenController.Run(NGenCommand.Display, Nothing)

            If Not output Is Nothing Then
                ParseNGENOutput(output)
            End If
            Me.Cursor = saveCursor

        Catch ex As Exception
            If Not saveCursor Is Nothing Then
                Me.Cursor = saveCursor
            End If
        End Try

    End Sub

    Private Sub btnUninstall_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnUninstall.Click
        Dim saveCursor As Cursor = Nothing

        Try
            Dim i As Integer

            'Iterate through the selected items and remove from the Native Image Cache.
            For Each i In lvNativeImageCache.SelectedIndices

                Dim name As String

                name = lvNativeImageCache.Items(i).SubItems(0).Text

                If (chkConfirm.Checked) Then
                    Dim result As DialogResult
                    result = MessageBox.Show(String.Format("Are you sure you want to remove {0} from the Native Image Cache?", name), "Confirm Remove", MessageBoxButtons.YesNo)
                    If (result = System.Windows.Forms.DialogResult.No) Then
                        Continue For
                    End If
                End If

                saveCursor = Me.Cursor
                Me.Cursor = Cursors.WaitCursor

                Dim output As StringCollection
                output = NGenController.Run(NGenCommand.Uninstall, name)
                Me.Cursor = saveCursor
            Next

            btnUninstall.Enabled = False

            'Refresh the list of installed images.
            btnViewCache_Click(sender, e)

        Catch ex As Exception

            If (Not saveCursor Is Nothing) Then
                Me.Cursor = saveCursor
            End If

        End Try

    End Sub

    Private Sub lvNativeImageCache_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lvNativeImageCache.SelectedIndexChanged
        btnUninstall.Enabled = True
    End Sub
End Class
