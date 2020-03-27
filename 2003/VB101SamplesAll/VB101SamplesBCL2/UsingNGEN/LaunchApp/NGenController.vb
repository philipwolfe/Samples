Imports System.Diagnostics
Imports System.Collections.Specialized

Namespace LaunchApp
    Public Class NGenController

        Private Sub NGenController()

        End Sub

        Private Shared outputLines As StringCollection = New StringCollection()

        Public Shared Function Run(ByVal command As NGenCommand, ByVal arguments As String) As StringCollection
            outputLines.Clear()

            If command = NGenCommand.Undefined Then
                outputLines.Add("Please provide a valid NGenCommand")
                Return outputLines
            End If

            Dim ngenProcess As Process = New Process()
            ngenProcess.StartInfo.FileName = "c:\windows\microsoft.net\framework\v2.0.50727\ngen"
            If arguments = Nothing Or arguments.Trim().Length = 0 Then
                ngenProcess.StartInfo.Arguments = command.ToString()
            Else
                ngenProcess.StartInfo.Arguments = String.Format("{0} {1}", command.ToString(), arguments)
            End If
            ngenProcess.StartInfo.RedirectStandardOutput = True
            ngenProcess.StartInfo.UseShellExecute = False
            ngenProcess.StartInfo.CreateNoWindow = True

            If ngenProcess.Start() Then
                ngenProcess.WaitForExit()
            End If

            Return outputLines
        End Function
    End Class
End Namespace
