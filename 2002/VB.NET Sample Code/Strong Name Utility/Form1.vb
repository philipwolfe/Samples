Imports System.IO


Public Class Form1
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
    Friend WithEvents Button1 As System.Windows.Forms.Button
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(41, 30)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(311, 28)
        Me.Button1.TabIndex = 0
        Me.Button1.Text = "Click to Generate Strong Name"
        '
        'Form1
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(6, 15)
        Me.ClientSize = New System.Drawing.Size(384, 95)
        Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.Button1})
        Me.Name = "Form1"
        Me.Text = "Strong Name Utility"
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click

        Dim snFilename As String
        Dim filename As String
        Dim drives As String()
        Dim driveLetter As String
        Dim clip As String
        Dim path As String
        Dim r As New Random()

        Dim bytes(15) As Byte
        Randomize(Now.Ticks)
        r.NextBytes(bytes)
        Dim g As New Guid(bytes)

        Try
            '-- Get a string array with all the logical drives in it: {"A:\", "C:\"}
            drives = System.IO.Directory.GetLogicalDrives()
            '-- Scroll through
            For Each driveLetter In drives
                '-- Look for the strong name utility in the SDK... don't look on floppies
                If driveLetter <> "A:\" And driveLetter <> "B:\" Then
                    '-- here's the file name we're looking for
                    snFilename = driveLetter & "Program Files\Microsoft Visual Studio .NET\FrameworkSDK\Bin\sn.exe"
                    '-- Is it there?
                    If File.Exists(snFilename) Then
                        '-- Yes. check for a StrongNames directory on this drive
                        path = driveLetter & "StrongNames"
                        If Directory.Exists(path) = False Then
                            '-- Create one if it doesn't exist
                            Directory.CreateDirectory(path)
                        End If
                        '-- Create a new snk filename from a guid (unique)
                        filename = path & "\" & g.ToString & ".snk"
                        '-- Shell the sn utility to create the assembly key file
                        Shell(snFilename & " -k " & filename, AppWinStyle.Hide, True, 5)
                        '-- compose a line of text for the clipboard
                        clip = "<Assembly: AssemblyKeyFile(" & Chr(34) & filename & Chr(34) & ")>"
                        '-- copy the string to the clipboard for pasting in AssemblyInfo.vb
                        Clipboard.SetDataObject(clip, True)
                        '-- outta here
                        MsgBox("Now paste the Assembly attribute from the clipboard into your AssemblyInfo.vb file")
                        Exit For
                    End If
                End If
            Next driveLetter

        Catch ex As Exception
            MsgBox(ex)

        End Try

    End Sub

End Class
