'Copyright (C) 2002 Microsoft Corporation
'All rights reserved.
'THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, EITHER 
'EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED WARRANTIES OF 
'MERCHANTIBILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.

'Requires the Trial or Release version of Visual Studio .NET Professional (or greater).

Option Strict On

Imports System.Windows.Forms

' This class is needed because the 
' System.Windows.Forms.Design.FolderNameEditor.FolderBrowser is Protected and thus 
' is not accessible in this context. Deriving a Public class from it enables you to
' use the dialog in your code.
Public Class FolderBrowser
    Inherits System.Windows.Forms.Design.FolderNameEditor

    Public Shared Function ShowDialog() As String
        Dim fb As New FolderBrowser()
        fb.Description = "Select a Directory to Scan"
        fb.Style = Design.FolderNameEditor.FolderBrowserStyles.RestrictToFilesystem
        fb.ShowDialog()

        Return fb.DirectoryPath
    End Function
End Class
