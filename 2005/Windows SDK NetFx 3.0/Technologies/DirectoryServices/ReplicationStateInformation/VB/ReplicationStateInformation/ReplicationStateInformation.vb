'=====================================================================
'  File:     ReplicationStateInformation.vb
'
'  Summary:  Demonstrates replication related classes and methods
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

    Public NotInheritable Class ReplicationStateInformation

        Private Sub New()
        End Sub

        Shared Sub Main()
            Try
                Dim targetDomainName As String = "fabrikam.com"

                Dim objectPath As String = "cn=users,dc=fabrikam,dc=com"

                ' get to the domain controller
                Dim dc As DomainController = _
                DomainController.FindOne(New DirectoryContext( _
                            DirectoryContextType.Domain, targetDomainName))

                ' to provide alternate credentials, use the below 
                ' DomainController dc = DomainController.FindOne(
                '                              new DirectoryContext(
                '                                      DirectoryContextType.Domain, 
                '                                      targetDomainName, 
                '                                      "alt-username", 
                '                                      "alt-password"));
                ' retrieve replication cursor information
                Console.WriteLine()
                Console.WriteLine("Get replication cursor information" + _
                                            " for each partition")
                Dim s As String
                For Each s In dc.Partitions
                    Console.WriteLine(ControlChars.Lf + "Partition {0}", s)
                    Dim cursor As ReplicationCursor
                    For Each cursor In dc.GetReplicationCursors(s)
                        Console.Write(ControlChars.Tab)
                        Console.WriteLine("SourceServer is {0}, " + _
                                            "SourceInvocationId is {1}, " + _
                                            "LastSuccessfulSyncTime is {2}", _
                                            cursor.SourceServer, _
                                            cursor.SourceInvocationId, _
                                            cursor.LastSuccessfulSyncTime)
                    Next cursor
                Next s

                ' retrieve replication neighbor information
                Console.WriteLine()
                Console.WriteLine("Get replication neighbor information")

                For Each s In dc.Partitions
                    Console.WriteLine(ControlChars.Lf + "Partition {0}", s)
                    Dim neighbor As ReplicationNeighbor
                    For Each neighbor In dc.GetReplicationNeighbors(s)
                        Console.Write(ControlChars.Tab)
                        Console.WriteLine("SourceServer is {0}, " + _
                                            "ReplicationNeighborFlag is {1}, " + _
                                            "UsnAttributeFilter is {2}, " + _
                                            "LastSuccessfulSync is {3}", _
                                            neighbor.SourceServer, _
                                            neighbor.ReplicationNeighborOption, _
                                            neighbor.UsnAttributeFilter, _
                                            neighbor.LastSuccessfulSync)
                    Next neighbor
                Next s

                ' retrieve the replication metadata information
                Console.WriteLine()
                Console.WriteLine("Get replication metadata information")
                Dim metadata As ActiveDirectoryReplicationMetadata = _
                                        dc.GetReplicationMetadata(objectPath)
                Dim o As Object
                For Each o In metadata.AttributeNames
                    Console.WriteLine()
                    Console.WriteLine("Attribute {0}", o)
                    Dim attr As AttributeMetadata = metadata(CStr(o))
                    Console.Write(ControlChars.Tab)
                    Console.WriteLine("OriginatingServer is {0}, " + _
                                        "OriginatingChangeUsn is {1}, " + _
                                        "LocalChangeUsn is {2}, " + _
                                        "LastOriginatingChangeTime is {3}", _
                                        attr.OriginatingServer, _
                                        attr.OriginatingChangeUsn, _
                                        attr.LocalChangeUsn, _
                                        attr.LastOriginatingChangeTime)
                Next o

                ' retrieve the inbound replication connections
                Console.WriteLine()
                Console.WriteLine("Get inbound replication " + _
                                        "connection information")
                Dim con As ReplicationConnection
                For Each con In dc.InboundConnections
                    Console.Write(ControlChars.Tab)
                    Console.WriteLine("Replication connection ""{0}"", " + _
                                        "SourceServer is {1}, " + _
                                        "DestinationServer is {2}", _
                                        con.Name, con.SourceServer, _
                                        con.DestinationServer)
                Next con

                ' retrieve the outbound replication connections
                Console.WriteLine()
                Console.WriteLine("Get outbound replication " + _
                                        "connection information")

                For Each con In dc.OutboundConnections
                    Console.Write(ControlChars.Tab)
                    Console.WriteLine("Replication connection ""{0}"", " + _
                                        "SourceServer is {1}, " + _
                                        "DestinationServer is {2}", _
                                        con.Name, con.SourceServer, _
                                        con.DestinationServer)
                Next con
            Catch e As Exception
                Console.WriteLine()
                Console.WriteLine("Unexpected exception occured:")
                Console.WriteLine(e.GetType().Name + ":" + e.Message)
            End Try
        End Sub 'Main
    End Class 'ReplicationStateInformation
End Namespace 'Microsoft.Samples.DirectoryServices