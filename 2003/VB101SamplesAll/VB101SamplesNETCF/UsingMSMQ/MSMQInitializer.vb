Option Strict On

Imports System.Text ' For StringBuilder
Imports System.Runtime.InteropServices ' For DllImport
Imports System.IO ' For File IO

Public Class MSMQInitializer
    ' Constructor
    Public Sub MSMQInitializer()

    End Sub

    ' MSMQAdm.exe utility 
    Private Const MSMQ_ADM As String = "\windows\msmqadm.exe"
    Private Const MSMQ_DRIVER_REG As String = "Drivers\BuiltIn\MSMQD"

    Public Class ProcessInfo
        Public hProcess As IntPtr = IntPtr.Zero
        Public hThread As IntPtr = IntPtr.Zero
        Public ProcessId As Int32 = 0
        Public ThreadId As Int32 = 0
    End Class

    <DllImport("CoreDll.DLL", SetLastError:=True)> _
    Private Shared Function CreateProcess( _
        ByVal imageName As String, _
        ByVal cmdLine As String, _
        ByVal lpProcessAttributes As IntPtr, _
        ByVal lpThreadAttributes As IntPtr, _
        ByVal boolInheritHandles As Int32, _
        ByVal dwCreationFlags As Int32, _
        ByVal lpEnvironment As IntPtr, _
        ByVal lpszCurrentDir As IntPtr, _
        ByVal lpsiStartInfo As IntPtr, _
        ByVal pi As ProcessInfo) As Integer
    End Function

    <DllImport("CoreDll.dll")> _
    Private Shared Function GetLastError() As Int32
    End Function

    <DllImport("CoreDll.dll")> _
    Private Shared Function GetExitCodeProcess(ByVal hProcess As IntPtr, ByRef exitcode As Int32) As Int32
    End Function

    <DllImport("CoreDll.dll")> _
    Private Shared Function CloseHandle(ByVal hProcess As IntPtr) As Int32
    End Function

    <DllImport("CoreDll.dll")> _
    Private Shared Function ActivateDevice(ByVal lpszDevKey As String, ByVal dwClientInfo As Int32) As IntPtr
    End Function

    <DllImport("CoreDll.dll")> _
    Private Shared Function WaitForSingleObject(ByVal Handle As IntPtr, ByVal Wait As Int32) As Int32
    End Function

    Public Function Init() As String
        ' Create a StringBuilder to store the status
        Dim sb As StringBuilder = New StringBuilder()

        ' We need to move the MSMQ components deployed to the system folder
        CopyFilesRequired()

        ' Check status of MSMQ (is it installed and running yet?
        If Not CreateProcess(MSMQ_ADM, "status") Then
            ' Deletes the MSMQ registry key and store directory. All messages are lost.
            CreateProcess(MSMQ_ADM, "register cleanup")

            ' Installs MSMQ as device drivers.
            If CreateProcess(MSMQ_ADM, "register install") Then
                sb.Append("Registered Drivers Successfully" & ControlChars.CrLf)
            Else
                Throw New Exception("Failed to install MSMQ! System Error = " + GetLastError().ToString())
            End If

            ' Creates the MSMQ Configuration in Registry
            If CreateProcess(MSMQ_ADM, "register") Then
                sb.Append("Registered MSMQ Successfully" & ControlChars.CrLf)
            Else
                Throw New Exception("Failed to Register MSMQ! System Error = " + GetLastError().ToString())
            End If

            ' Enables the native MSMQ protocol
            If CreateProcess(MSMQ_ADM, "enable binary") Then
                sb.Append("Enable Binary Successfully" & ControlChars.CrLf)
            Else
                Throw New Exception("Failed to enable Binary! System Error = " + GetLastError().ToString())
            End If

            ' Starts the MSMQ service
            If CreateProcess(MSMQ_ADM, "start") Then
                sb.Append("Started MSMQ Successfully" & ControlChars.CrLf)
            Else
                ' This is one additional step that is needed for PocketPCs
                ' The Device Drivers have to be loaded before the service can be started 

                ' ActivateDevice will load the device drivers
                Dim handle As IntPtr = ActivateDevice(MSMQ_DRIVER_REG, 0)
                CloseHandle(handle)

                ' Let us check if MSMQ is running
                If CreateProcess(MSMQ_ADM, "status") Then
                    sb.Append("MSMQ is up and running" & ControlChars.CrLf)
                Else
                    Throw New Exception("Failed to start MSMQ! System Error = " + GetLastError().ToString())
                End If
            End If
        Else
            sb.Append("MSMQ is already up and running" & ControlChars.CrLf)
        End If
        ' Return Status
        Return sb.ToString()
    End Function

    ' CreateProcess
    ' Used to Create a process
    Private Function CreateProcess(ByVal ExeName As String, ByVal CmdLine As String) As Boolean

        Dim pi As ProcessInfo = New ProcessInfo()
        If CreateProcess(ExeName, CmdLine, IntPtr.Zero, IntPtr.Zero, _
            0, 0, IntPtr.Zero, IntPtr.Zero, IntPtr.Zero, pi) = 0 Then
            Return False
        End If

        WaitForSingleObject(pi.hProcess, -1) ' Wait for infinite time
        Dim exitCode As Int32
        If GetExitCodeProcess(pi.hProcess, exitCode) = 0 Then
            ' Free handles
            CloseHandle(pi.hThread)
            CloseHandle(pi.hProcess)
            Throw New Exception("Failure in GetExitCodeProcess")
        End If

        ' Free handles
        CloseHandle(pi.hThread)
        CloseHandle(pi.hProcess)

        If exitCode <> 0 Then
            Return False
        Else
            Return True
        End If
    End Function


    ' CopyFilesRequired
    Private Shared Sub CopyFilesRequired()
        Dim myPath As String = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase)

        If Not File.Exists("\windows\msmqadm.exe") Then
            File.Copy(myPath & "\msmqadm.exe", "\windows\msmqadm.exe")
        End If

        If Not File.Exists("\windows\msmqadmext.dll") Then
            File.Copy(myPath & "\msmqadmext.dll", "\windows\msmqadmext.dll")
        End If

        If Not File.Exists("\windows\msmqd.dll") Then
            File.Copy(myPath & "\msmqd.dll", "\windows\msmqd.dll")
        End If

        If Not File.Exists("\windows\msmqrt.dll") Then
            File.Copy(myPath & "\msmqrt.dll", "\windows\msmqrt.dll")
        End If

        File.Delete(myPath & "\msmqadm.exe")
        File.Delete(myPath & "\msmqadmext.dll")
        File.Delete(myPath & "\msmqd.dll")
        File.Delete(myPath & "\msmqrt.dll")
    End Sub
End Class
