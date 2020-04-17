'=====================================================================
'  File:     TopologyInformation.vb
'
'  Summary:  Demonstrates  
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

    Public NotInheritable Class TopologyInformation

        Private Sub New()
        End Sub

        Shared Sub Main()
            Try
                Dim targetForestName As String = "fabrikam.com"

                Dim context As _
                    New DirectoryContext(DirectoryContextType.Forest, _
                                            targetForestName)

                Dim forest As _
                    Forest = ActiveDirectory.Forest.GetForest(context)

                Console.WriteLine()
                Console.WriteLine("Get intersite transport object")
                Dim transport As _
                    ActiveDirectoryInterSiteTransport = _
                        ActiveDirectoryInterSiteTransport.FindByTransportType( _
                                    context, ActiveDirectoryTransportType.Rpc)

                Console.Write(ControlChars.Tab)
                Console.WriteLine("BridgeAllSiteLinks is {0}", _
                                    transport.BridgeAllSiteLinks)

                Console.Write(ControlChars.Tab)
                Console.WriteLine("IgnoreReplicationSchedule is {0}", _
                                    transport.IgnoreReplicationSchedule)

                ' get all the site links that have transport type as RPC over IP
                Console.WriteLine()
                Console.WriteLine("Forest ""{0}"" has site links: ", forest)
                Dim link As ActiveDirectorySiteLink
                For Each link In transport.SiteLinks
                    Console.Write(ControlChars.Tab)
                    Console.WriteLine("Sitelink ""{0}""", link)
                Next link

                ' get all the site link bridges that have transport type as RPC over IP
                Console.WriteLine()
                Console.WriteLine("Forest ""{0}"" has site link bridges: ", forest)
                Dim bridge As ActiveDirectorySiteLinkBridge
                For Each bridge In transport.SiteLinkBridges
                    Console.WriteLine("SitelinkBridge ""{0}""", bridge)
                Next bridge

                ' get all the sites in the forest
                Dim site As ActiveDirectorySite
                For Each site In forest.Sites
                    Console.WriteLine()
                    Console.WriteLine("Site ""{0}"":", site.Name)
                    Console.WriteLine("It contains domain:")

                    Dim addomain As Domain
                    For Each addomain In site.Domains
                        Console.Write(ControlChars.Tab)
                        Console.WriteLine("Domain ""{0}""", addomain.Name)
                    Next addomain
                    Console.WriteLine("It contains server:")

                    Dim server As DirectoryServer
                    For Each server In site.Servers
                        Console.Write(ControlChars.Tab)
                        Console.WriteLine("Server ""{0}""", server.Name)
                    Next server
                    Console.WriteLine("It contains subnet:")

                    Dim subnet As ActiveDirectorySubnet
                    For Each subnet In site.Subnets
                        Console.Write(ControlChars.Tab)
                        Console.WriteLine("Subnet ""{0}"", location is {1}", _
                                            subnet.Name, subnet.Location)
                    Next subnet
                    Console.WriteLine()
                    Console.WriteLine("InterSiteTopologyGenerator is {0}", _
                                        site.InterSiteTopologyGenerator)
                    Console.WriteLine()
                    Console.WriteLine("Bridgehead servers are:")

                    For Each server In site.BridgeheadServers
                        Console.Write(ControlChars.Tab)
                        Console.WriteLine("Server ""{0}""", server.Name)
                    Next server
                    Console.WriteLine(ControlChars.Lf + "Adjacent sites are:")

                    Dim adsite As ActiveDirectorySite
                    For Each adsite In site.AdjacentSites
                        Console.Write(ControlChars.Tab)
                        Console.WriteLine("Site ""{0}""", adsite.Name)
                    Next adsite
                Next site
            Catch e As Exception
                Console.WriteLine()
                Console.WriteLine("Unexpected exception occured:")
                Console.WriteLine(e.GetType().Name + ":" + e.Message)
            End Try
        End Sub 'Main
    End Class 'TopologyInformation
End Namespace 'Microsoft.Samples.DirectoryServices