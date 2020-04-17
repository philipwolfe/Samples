'=====================================================================
'  File:     ReplicationStateManagement.vb
'
'  Summary:  Demonstrates replication management related classes and 
'            methods.
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
Imports System.Security.Permissions
Imports System.DirectoryServices
Imports System.DirectoryServices.ActiveDirectory


<Assembly: System.Reflection.AssemblyVersion("1.0.0.0")> 
<Assembly: SecurityPermission(SecurityAction.RequestMinimum, Execution:=True)> 
<Assembly: DirectoryServicesPermission(SecurityAction.RequestMinimum)> 


Namespace Microsoft.Samples.DirectoryServices

    Public NotInheritable Class ReplicationStateManagement

        Private Sub New()
        End Sub

        Shared Function SyncFromAllServersCallbackRoutine( _
                                ByVal eventType As SyncFromAllServersEvent, _
                                ByVal target As String, _
                                ByVal [source] As String, _
                                ByVal exception As _
                                    SyncFromAllServersOperationException) _
                                                                As Boolean
            Console.WriteLine(ControlChars.Lf + "eventType is {0}", eventType)
            Console.WriteLine("target is {0}", target)
            Console.WriteLine("source is {0}", [source])
            Console.WriteLine("exception is {0}", exception)
            Return True
        End Function 'SyncFromAllServersCallbackRoutine

        Shared Sub Main()
            Try
                Dim targetDomainName As String = "fabrikam.com"

                Dim targetServer As String = "server1.fabrikam.com"
                Dim sourceServer As String = "server2.fabrikam.com"
                Dim partitionName As String = _
                                    "CN=Configuration,DC=fabrikam,DC=com"

                ' get to the domain controller
                Dim dc As DomainController = DomainController.FindOne( _
                            New DirectoryContext(DirectoryContextType.Domain, _
                            targetDomainName))

                ' to use alternate credentials use the below code
                ' Dim dc As DomainController = DomainController.FindOne( _
                '                          new DirectoryContext(
                '                                   DirectoryContextType.Domain, 
                '                                   targetDomainName, 
                '                                   "alt-username", 
                '                                   "alt-password"))
                '
                '

                ' invoke kcc to check replication consistency
                dc.CheckReplicationConsistency()
                Console.WriteLine()
                Console.WriteLine("Check replication consistency succeed")
                Console.WriteLine()

                ' sync replica from a source server
                dc.SyncReplicaFromServer(partitionName, sourceServer)
                Console.WriteLine()
                Console.WriteLine("Synchronize naming context ""{0}"" " + _
                                        "with server {1} succeed", _
                                        partitionName, sourceServer)

                ' sync replica from all neighbors
                dc.TriggerSyncReplicaFromNeighbors(partitionName)
                Console.WriteLine()
                Console.WriteLine("Synchronize naming context ""{0}"" " + _
                                        "with all neighbors succeed", _
                                        partitionName)

                ' sync replica from all servers
                dc.SyncFromAllServersCallback = _
                                    AddressOf SyncFromAllServersCallbackRoutine
                Console.WriteLine()
                Console.WriteLine("Start sync with all servers:")
                dc.SyncReplicaFromAllServers(partitionName, _
                            SyncFromAllServersOptions.AbortIfServerUnavailable)

                Console.WriteLine()
                Console.WriteLine("Synchronize naming context ""{0}"" " + _
                                    "with all servers succeed", partitionName)

                ' replication connection
                ' create new replication connections
                Dim sourceDC As DirectoryServer = _
                                DomainController.GetDomainController( _
                                    New DirectoryContext( _
                                        DirectoryContextType.DirectoryServer, _
                                        sourceServer))

                ' to use alternate credentials use the below code
                ' Dim sourceDC As DirectoryServer = _
                '               DomainController.GetDomainController(
                '                   new DirectoryContext(
                '                        DirectoryContextType.DirectoryServer, 
                '                        sourceServer, 
                '                        "alt-username", 
                '                        "alt-password"));
                '


                Dim connection As _
                    New ReplicationConnection( _
                        New DirectoryContext( _
                            DirectoryContextType.DirectoryServer, _
                                    targetServer), "myconnection", sourceDC)

                ' to use alternate credentials use the below code
                ' ReplicationConnection connection = _
                '               new ReplicationConnection(
                '                   new DirectoryContext(
                '                       DirectoryContextType.DirectoryServer, 
                '                                 targetServer, 
                '                                 "alt-username", 
                '                                 "alt-password"), 
                '                       "myconnection", 
                '                       sourceDC)
                '

                ' set change notification status
                connection.ChangeNotificationStatus = _
                                    NotificationStatus.IntraSiteOnly

                ' create customized replication schedule
                Dim schedule As New ActiveDirectorySchedule()
                schedule.SetDailySchedule(HourOfDay.Twelve, _
                                        MinuteOfHour.Zero, _
                                        HourOfDay.Fifteen, MinuteOfHour.Zero)

                schedule.SetSchedule(DayOfWeek.Sunday, HourOfDay.Eight, _
                                        MinuteOfHour.Zero, HourOfDay.Eleven, _
                                        MinuteOfHour.Zero)

                schedule.SetSchedule(DayOfWeek.Saturday, HourOfDay.Seven, _
                                        MinuteOfHour.Zero, HourOfDay.Ten, _
                                        MinuteOfHour.Zero)

                connection.ReplicationSchedule = schedule
                connection.ReplicationScheduleOwnedByUser = True
                connection.Save()
                Console.WriteLine()
                Console.WriteLine("New replication connection is " + _
                                                "created successfully")

                connection = ReplicationConnection.FindByName( _
                                New DirectoryContext( _
                                        DirectoryContextType.DirectoryServer, _
                                        targetServer), _
                                "myconnection")

                ' to use alternate credentials use the below code
                ' connection = ReplicationConnection.FindByName(
                '                   new DirectoryContext(
                '                       DirectoryContextType.DirectoryServer, 
                '                                 targetServer,
                '                                 "alt-username", 
                '                                 "alt-password"), 
                '                   "myconnection")
                '
                Console.WriteLine()
                Console.WriteLine("Get replication connection ""{0}"" information:", _
                                    connection.Name)

                Console.WriteLine("ChangeNotificationStatus is {0}", _
                                    connection.ChangeNotificationStatus)
                Console.WriteLine("ReplicationSpan is {0}", _
                                    connection.ReplicationSpan)
                Console.WriteLine("ReplicationScheduleOwnedByUser is {0}", _
                                    connection.ReplicationScheduleOwnedByUser)

                ' delete the replication connection
                connection.Delete()
                Console.WriteLine()
                Console.WriteLine("Replication connection is deleted")
                Console.WriteLine()
            Catch e As Exception
                Console.WriteLine()
                Console.WriteLine("Unexpected exception occured:")
                Console.WriteLine(e.GetType().Name + ":" + e.Message)
            End Try
        End Sub 'Main
    End Class 'ReplicationStateManagement
End Namespace 'Microsoft.Samples.DirectoryServices