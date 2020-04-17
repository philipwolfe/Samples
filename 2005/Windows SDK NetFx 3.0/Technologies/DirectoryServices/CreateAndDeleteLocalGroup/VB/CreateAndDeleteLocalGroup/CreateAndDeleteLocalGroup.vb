'=====================================================================
'  File:      CreateAndDeleteLocalGroup.vb
'
'  Summary:   This sample shows how to create a local group, add
'             a user using Invoke method of DirectoryEntry class,
'             and then delete group using Remove method of
'             DirectoryEntries class
'
'---------------------------------------------------------------------
'  This file is part of the Microsoft .NET SDK Code Samples.
'
'  Copyright (C) Microsoft Corporation.  All rights reserved.
'
'This source code is intended only as a supplement to Microsoft
'Development Tools and/or on-line documentation.  See these other
'materials for detailed information regarding Microsoft code samples.
'
'THIS CODE AND INFORMATION ARE PROVIDED "AS IS" WITHOUT WARRANTY OF ANY
'KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE
'IMPLIED WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A
'PARTICULAR PURPOSE.
'=====================================================================


Imports System
Imports System.Net
Imports System.Security.Permissions

Imports System.DirectoryServices


<Assembly: System.Reflection.AssemblyVersion("1.0.0.0")> 
<Assembly: SecurityPermission(SecurityAction.RequestMinimum, Execution:=True)> 
<Assembly: DirectoryServicesPermission(SecurityAction.RequestMinimum)> 

Namespace Microsoft.Samples.DirectoryServices

    Public NotInheritable Class CreateAndDeleteLocalGroupSample
        Private Shared localComputerName As String = "fabrikam"
        Private Shared newGroupName As String = "TestGroup"
        Private Shared existingUserName As String = "ExistingUser"

        Public Overloads Shared Sub Main()
            Try
                CreateAndDeleteLocalGroup()

                Console.WriteLine()
                Console.WriteLine("Application Finished Successfully!!!")
            Catch e As Exception
                Console.WriteLine()
                Console.WriteLine("Unexpected exception occured:")
                Console.WriteLine(e.GetType().ToString() + ":" + e.Message)
            End Try
        End Sub 'Main

        Private Sub New()
        End Sub

        Shared Sub CreateAndDeleteLocalGroup()
            ' Bind to local computer
            Dim localComputer As New DirectoryEntry("WinNT://" + _
                                            localComputerName + ",computer")

            ' Create new group using Add method of Children collection
            Dim newGroup As DirectoryEntry = _
                            localComputer.Children.Add(newGroupName, "group")
            ' Commit the group to the directory
            newGroup.CommitChanges()
            Console.WriteLine("Group created!")

            ' Add existing user to new group
            newGroup.Invoke("Add", New Object() { _
                   "WinNT://" + localComputerName + "/" + existingUserName})
            Console.WriteLine("User added to group!")

            ' Dispose DirectoryEntry object
            newGroup.Dispose()

            ' Now delete recently created group
            ' Once group deleted  user will also have group out of member of
            DeleteGroup(localComputer, newGroupName)
            Console.WriteLine("Group deleted! User no longer in group!")
        End Sub 'CreateAndDeleteLocalGroup

        Shared Sub DeleteGroup(ByVal computer As DirectoryEntry, ByVal groupName As String)
            ' Bind to group object to delete
            Dim groupToDelete As New DirectoryEntry("WinNT://" + _
                                localComputerName + "/" + groupName + ",group")
            ' Delete it calling Remove method of DirectoryEntries object
            computer.Children.Remove(groupToDelete)
        End Sub 'DeleteGroup
    End Class ' CreateAndDeleteLocalGroupSample
End Namespace 'Microsoft.Samples.DirectoryServices 
