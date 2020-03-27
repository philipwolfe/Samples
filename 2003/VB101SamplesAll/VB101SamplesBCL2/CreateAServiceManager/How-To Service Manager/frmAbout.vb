'Copyright (C) 2002 Microsoft Corporation
'All rights reserved.
'THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, EITHER 
'EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED WARRANTIES OF 
'MERCHANTIBILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.

'Requires the Trial or Release version of Visual Studio 2005.

Option Strict On

Public Class frmAbout
    ' Note: Because this form is opened by frmMain using the ShowDialog command, we simply set the
    ' DialogResult property of cmdOK to OK which causes the form to close when clicked.
    Private Sub frmAbout_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            ' Set this Form's Text & Icon properties by using values from the parent form
            Me.Text = "About " & Me.Owner.Text
            Me.Icon = Me.Owner.Icon

            ' Set this Form's Picture Box's image using the parent's icon 
            ' However, we need to convert it to a Bitmap since the Picture Box Control
            ' will not accept a raw Icon.
            Me.pbIcon.Image = Me.Owner.Icon.ToBitmap()

            ' Set the labels identitying the Title, Version, and Description by
            ' reading Assembly meta-data originally entered in the AssemblyInfo.vb file
            ' using the AssemblyInfo class defined in the same file
            Dim ainfo As New AssemblyInfo()

            Me.lblTitle.Text = ainfo.Title
            Me.lblVersion.Text = String.Format("Version {0}", ainfo.Version)
            Me.lblCopyright.Text = ainfo.Copyright
            Me.lblDescription.Text = ainfo.Description
            Me.lblCodebase.Text = ainfo.CodeBase

        Catch exp As System.Exception
            ' This catch will trap any unexpected error.
            MessageBox.Show(exp.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Stop)

        End Try
    End Sub
End Class