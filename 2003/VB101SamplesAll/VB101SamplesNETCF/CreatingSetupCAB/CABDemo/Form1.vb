Option Strict On

Imports Microsoft.Win32 ' For Registry Classes

Public Class Form1

    Private Sub Form1_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Display the OK button for closing the application.
        MinimizeBox = False
    End Sub

    ' The purpose of this click event is to verify that the values placed
    ' in the registry by the CAB Setup program are actually in the registry.
    ' The registry values are read and displayed on the form.
    Private Sub ReadRegistryButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ReadRegistryButton.Click
        ' Registry path
        Const regPath As String = "SOFTWARE\CABDemo"
        Dim appKey As RegistryKey = Nothing
        Try
            ' Get current setting from the registry
            appKey = Registry.CurrentUser.OpenSubKey(regPath, False)
            If appKey Is Nothing Then
                ' Registry SubKey does not exist...is the sample being run in the emulator?
                MessageLabel.Text = "No Info in Registry."
                VersionLabel.Text = "No Info in Registry."
                Throw New Exception("Registry Sub Key does not exist.  You must install the CAB file and run this sample from a physical device.")
            End If
            MessageLabel.Text = CStr(appKey.GetValue("Message"))
            VersionLabel.Text = CStr(appKey.GetValue("Version"))
        Catch ex As Exception
            MessageBox.Show("Error: " & ex.Message)
        Finally
            If Not appKey Is Nothing Then
                appKey.Close()
            End If
        End Try
    End Sub

End Class
