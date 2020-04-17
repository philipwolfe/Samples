'-----------------------------------------------------------------------
'  This file is part of the Microsoft .NET Framework SDK Code Samples.
' 
'  Copyright (C) Microsoft Corporation.  All rights reserved.
' 
'This source code is intended only as a supplement to Microsoft
'Development Tools and/or on-line documentation.  See these other
'materials for detailed information regarding Microsoft code samples.
' 
'THIS CODE AND INFORMATION ARE PROVIDED AS IS WITHOUT WARRANTY OF ANY
'KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE
'IMPLIED WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A
'PARTICULAR PURPOSE.
' =====================================================================
'  File:      Permissions.vb
'
'  Summary:   Demonstrates how use code access security.
'
' =====================================================================*/

Option Explicit On
Option Strict On


'  Add the classes in the following namespaces to our namespace
Imports System
Imports System.IO
Imports System.Security.Permissions
Imports System.Security

Namespace Microsoft.Samples.CAS.Permissions

    Module Application

        Sub Main()
            '  Try to access resources using the permissions currently available.
            AttemptAccess("Default permissions")

            '  Create a permission set that allows read access to the TEMP 
            '  environment variable and read, write, and append access to SomeFile
            Dim ps As New PermissionSet(PermissionState.None)
            Dim fs As FileIOPermission
            Dim ep As EnvironmentPermission

            fs = New FileIOPermission(FileIOPermissionAccess.Read Or FileIOPermissionAccess.Write Or FileIOPermissionAccess.Append, Path.GetFullPath("SomeFile"))
            ep = New EnvironmentPermission(EnvironmentPermissionAccess.Read, "TEMP")

            ps.AddPermission(ep)
            ps.AddPermission(fs)

            ' Use caution in asserting permissions in publicly callable code without
            ' any kind of check on the caller.  There is a danger of the assert being
            ' used to exploit a downstream caller by stopping its security check, 
            ' allowing the malicious code access to unauthorized resources.

            ' Stop security checks at this point in the stack walk
            ' for the specified permissions
            ps.Assert()

            '  Try to access resources using the permissions we've just asserted.
            AttemptAccess("Assert permissions")

            '  Remove this stack frame's Assert
            CodeAccessPermission.RevertAssert()

            '  Deny access to the resources we specify
            ps.Deny()

            '  Try to access resources using the permissions we've just denied.
            AttemptAccess("Deny permissions")

            '  Remove this stack frame's Deny so we're back to default permissions.
            CodeAccessPermission.RevertDeny()

            '  Make the permissions indicate the only things that we're allowed to do.
            ps.PermitOnly()

            '  Try to access resources using only the permissions we've just permitted.
            AttemptAccess("PermitOnly permissions")

            '  Remove this stack frame's PermitOnly so we're back to default permissions.
            CodeAccessPermission.RevertPermitOnly()

            '  Remove the FileIOPermissions from the permission set
            ps.RemovePermission(fs.GetType())

            '  Try to access resources using only the Environment permissions.
            ps.PermitOnly()
            AttemptAccess("PermitOnly without FileIOPermission permissions")
            CodeAccessPermission.RevertPermitOnly()

            '  Remove the EnvironmentPermission from the permission set
            ps.RemovePermission(ep.GetType())

            '  Try to access resources using no permissions.
            ps.PermitOnly()
            AttemptAccess("PermitOnly without any permissions")
            CodeAccessPermission.RevertPermitOnly()

            ' Show how to use Demand/Assert to improve performance
            CopyFile(".\\Permissions.exe", ".\\Permissions.copy.exe")

            ' Delete .exe copy
            File.Delete(".\\Permissions.copy.exe")

        End Sub


        Public Sub AttemptAccess(ByVal s As String)
            Dim fs As FileStream = Nothing
            Dim ev As String = Nothing
            Dim attemptResult As String = s & " test: "

            '  Try to access a file
            Try
                fs = New FileStream("SomeFile", FileMode.OpenOrCreate)
            Catch se As SecurityException
                ' Handle exception appropriately - for this sample, we will
                ' simply ignore the exception
            Finally
                '  If we opened the file, close it & delete it
                If fs IsNot Nothing Then
                    attemptResult += "File opened, "
                    fs.Close()
                    File.Delete("SomeFile")
                Else
                    attemptResult += "File NOT opened, "
                End If
            End Try

            '  Try to read an environment variable
            Try
                ev = Environment.GetEnvironmentVariable("TEMP")
            Catch se As SecurityException
                ' Handle exception appropriately - for this sample, we will
                ' simply ignore the exception
            Finally
                If ev IsNot Nothing Then
                    attemptResult += "Environment variable read"
                Else
                    attemptResult += "Environment variable NOT read"
                End If
            End Try

            Console.WriteLine(attemptResult)

        End Sub


        Public Sub CopyFile(ByVal sourcePath As String, ByVal destinationPath As String)

            '  Create a file permission set indicating all of this method's intentions.
            Dim fp As FileIOPermission = New FileIOPermission(FileIOPermissionAccess.Read, Path.GetFullPath(sourcePath))
            fp.AddPathList(FileIOPermissionAccess.Write Or FileIOPermissionAccess.Append, _
                Path.GetFullPath(destinationPath))

            '  Verify that we can be granted all the permissions we'll need.
            fp.Demand()

            '  Assert the desired permissions here.
            fp.Assert()

            '  For the remainder of this method, demands for source file read access
            '  and demands for destination file write/append access will be granted
            '  immediately; walking the remainder of the stack will not be necessary.
            Dim srcFile As FileInfo = New FileInfo(sourcePath)
            Dim dstFile As FileInfo = New FileInfo(destinationPath)
            Dim src As Stream = srcFile.Open(FileMode.Open, FileAccess.Read, FileShare.Read)
            Dim dst As Stream = dstFile.Open(FileMode.Create, FileAccess.Write, FileShare.None)

            ' NOTE: FileInfo.Length is a Int64, but the Stream.Read and .Write methods take
            ' Int32 counts - hence the casting/throttling below
            If srcFile.Length > Int32.MaxValue Then
                Throw New ArgumentOutOfRangeException("CopyFile requires that the source file be less than 2GB.")
            End If

            Dim buffer(Convert.ToInt32(srcFile.Length)) As Byte
            src.Read(buffer, 0, Convert.ToInt32(srcFile.Length))
            dst.Write(buffer, 0, Convert.ToInt32(srcFile.Length))

            src.Close()
            dst.Close()

            ' We do not need a RevertAssert here because we are going out of scope
        End Sub

    End Module   ' Application

End Namespace
' /////////////////////////////// End of File /////////////////////////////////
