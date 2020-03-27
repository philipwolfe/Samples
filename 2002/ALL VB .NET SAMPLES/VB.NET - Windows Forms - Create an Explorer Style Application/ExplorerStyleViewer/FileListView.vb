'Copyright (C) 2002 Microsoft Corporation
'All rights reserved.
'THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, EITHER 
'EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED WARRANTIES OF 
'MERCHANTIBILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.

'Requires the Trial or Release version of Visual Studio .NET Professional (or greater).

Option Strict On

Imports System.Diagnostics ' For Process.Start
Imports System.IO

Class FileListView
    Inherits ListView
    Private strDirectory As String

    ' This is the Class constructor.
    Public Sub New()
        ' Set the default View enumeration to Details.
        Me.View = View.Details

        ' Get images as icons for some of the common file types.
        Dim img As New ImageList()
        With img.Images
            .Add(New Bitmap("..\ExplorerStyleViewer\DOC.BMP"))
            .Add(New Bitmap("..\ExplorerStyleViewer\EXE.BMP"))
        End With

        ' The Small and Large image lists for the ListView use the same set of
        ' images.
        Me.SmallImageList = img
        Me.LargeImageList = img

        ' Create the columns.
        With Columns
            .Add("Name", 100, HorizontalAlignment.Left)
            .Add("Size", 100, HorizontalAlignment.Right)
            .Add("Modified", 100, HorizontalAlignment.Left)
            .Add("Attribute", 100, HorizontalAlignment.Left)
        End With
    End Sub

    ' Overrides the base class OnItemActivate event handler. Extends the base
    ' class implementation to run any .exe or file with an associated executable.
    Protected Overrides Sub OnItemActivate(ByVal ea As EventArgs)
        MyBase.OnItemActivate(ea)

        Dim lvi As ListViewItem
        For Each lvi In SelectedItems
            Try
                Process.Start(Path.Combine(strDirectory, lvi.Text))
            Catch
                ' Do nothing. Just pass to Next lvi.
                Exit Try
            End Try
        Next lvi
    End Sub

    ' This subroutine is used to display a list of all files in the directory
    ' currently selected by the user from the custom TreeView control.
    Public Sub ShowFiles(ByVal strDirectory As String)
        ' Save the directory name as a field.
        Me.strDirectory = strDirectory

        Items.Clear()

        Dim diDirectories As New DirectoryInfo(strDirectory)
        Dim afiFiles() As FileInfo

        Try
            ' Call the convenient GetFiles method to get an array of all files
            ' in the directory.
            afiFiles = diDirectories.GetFiles()
        Catch
            Return
        End Try

        Dim fi As FileInfo
        For Each fi In afiFiles
            ' Create ListViewItem.
            Dim lvi As New ListViewItem(fi.Name)

            ' Assign ImageIndex based on filename extension.
            Select Case Path.GetExtension(fi.Name).ToUpper()
                Case ".EXE"
                    lvi.ImageIndex = 1
                Case Else
                    lvi.ImageIndex = 0
            End Select

            ' Add file length and last modified time sub-items.
            lvi.SubItems.Add(fi.Length.ToString("N0"))
            lvi.SubItems.Add(fi.LastWriteTime.ToString())

            ' Add attribute subitem.
            Dim strAttr As String = ""

            If (fi.Attributes And FileAttributes.Archive) <> 0 Then
                strAttr += "A"
            End If
            If (fi.Attributes And FileAttributes.Hidden) <> 0 Then
                strAttr += "H"
            End If
            If (fi.Attributes And FileAttributes.ReadOnly) <> 0 Then
                strAttr += "R"
            End If
            If (fi.Attributes And FileAttributes.System) <> 0 Then
                strAttr += "S"
            End If
            lvi.SubItems.Add(strAttr)

            ' Add completed ListViewItem to FileListView.
            Items.Add(lvi)
        Next fi
    End Sub

End Class