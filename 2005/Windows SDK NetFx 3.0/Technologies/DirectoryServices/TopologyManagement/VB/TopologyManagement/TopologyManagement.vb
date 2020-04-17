'=====================================================================
'  File:     TopologyManagement.vb
'
'  Summary:  Demonstrates  managing directory topology such as sites,
'            subnets, sitelinks etc.
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

    Public NotInheritable Class TopologyManagement

        Private Sub New()
        End Sub

        Shared Sub Main()
            Try
                Dim targetName As String = "fabrikam.com"

                Dim subnetName1 As String = "154.55.0.0/16"
                Dim subnetName2 As String = "154.56.0.0/16"

                Dim siteName As String = "myNewSite"
                Dim siteLinkName As String = "DEFAULTIPSITELINK"
                Dim defaultSiteName As String = "Default-First-Site-Name"

                Dim domainContext As _
                    New DirectoryContext(DirectoryContextType.Domain, _
                                                targetName)

                Dim forestContext As _
                    New DirectoryContext(DirectoryContextType.Forest, _
                                                targetName)

                Dim forest As Forest = _
                        ActiveDirectory.Forest.GetForest(forestContext)

                ' create new site
                Dim site As New ActiveDirectorySite(forestContext, siteName)
                site.Options = _
                    ActiveDirectorySiteOptions.GroupMembershipCachingEnabled
                site.Save()
                Console.WriteLine()
                Console.WriteLine("Site ""{0}"" is created successfully", site)

                ' create new subnets
                Dim subnet1 As New ActiveDirectorySubnet(forestContext, _
                                                            subnetName1)
                subnet1.Location = "Bellevue"
                subnet1.Site = site
                subnet1.Save()
                Console.WriteLine()
                Console.WriteLine("Subnet ""{0}"" is created successfully", _
                                    subnet1)

                Dim subnet2 As _
                    New ActiveDirectorySubnet(forestContext, subnetName2, _
                                                siteName)
                subnet2.Location = "Redmond"
                subnet2.Save()
                Console.WriteLine()
                Console.WriteLine("Subnet ""{0}"" is created successfully", _
                                    subnet2)

                Console.WriteLine()
                Console.WriteLine("Site ""{0}"" contains subnet:", site.Name)
                Dim subnet As ActiveDirectorySubnet
                For Each subnet In site.Subnets
                    Console.Write(ControlChars.Tab)
                    Console.WriteLine("Subnet ""{0}"", location is {1}", _
                                        subnet.Name, subnet.Location)
                Next subnet

                ' add new site to an existing site link
                Dim link As ActiveDirectorySiteLink = _
                    ActiveDirectorySiteLink.FindByName(forestContext, _
                                                        siteLinkName)

                Console.WriteLine()
                Console.WriteLine("Add site ""{0}"" to site link ""{1}""", _
                                    site.Name, link.Name)

                link.Sites.Add(site)
                link.Save()
                Console.WriteLine()
                Console.WriteLine("SiteLink ""{0}"" has site: ", link)
                Dim adsite As ActiveDirectorySite
                For Each adsite In link.Sites
                    Console.Write(ControlChars.Tab)
                    Console.WriteLine("Site ""{0}""", adsite)
                Next adsite

                ' delete site and subnets
                site.Delete()
                subnet1.Delete()
                subnet2.Delete()
                Console.WriteLine()
                Console.WriteLine("Site and subnets are deleted successfully")
                Console.WriteLine()

                ' existing site management
                ' preferred RPC bridgehead server
                Dim defaultSite As ActiveDirectorySite = _
                    ActiveDirectorySite.FindByName(forestContext, _
                                                    defaultSiteName)

                Console.WriteLine()
                Console.WriteLine("Existing PreferredRpcBridgeheadServers is:")
                Dim server As DirectoryServer
                For Each server In defaultSite.PreferredRpcBridgeheadServers
                    Console.Write(ControlChars.Tab)
                    Console.WriteLine("Server {0}", server.Name)
                Next server

                Console.WriteLine()
                Console.WriteLine("Add PreferredRpcBridgeheadServers")
                Dim col As DomainControllerCollection = _
                    Domain.GetDomain(domainContext).FindAllDomainControllers( _
                                                            defaultSiteName)

                For Each server In col
                    defaultSite.PreferredRpcBridgeheadServers.Add(server)
                Next server

                defaultSite.Save()
                Console.WriteLine()
                Console.WriteLine("After updating, " + _
                                    "PreferredRpcBridgeheadServers is:")

                For Each server In defaultSite.PreferredRpcBridgeheadServers
                    Console.Write(ControlChars.Tab)
                    Console.WriteLine("Server {0}", server.Name)
                Next server

                defaultSite.PreferredRpcBridgeheadServers.Clear()
                defaultSite.Save()
                Console.WriteLine()
                Console.WriteLine("After Clear call, " + _
                                    "PreferredRpcBridgeheadServers is:")

                For Each server In defaultSite.PreferredRpcBridgeheadServers
                    Console.Write(ControlChars.Tab)
                    Console.WriteLine("Server {0}", server.Name)
                Next server
            Catch e As Exception
                Console.WriteLine()
                Console.WriteLine("Unexpected exception occured:")
                Console.WriteLine(e.GetType().Name + ":" + e.Message)
            End Try
        End Sub 'Main
    End Class 'TopologyManagement
End Namespace 'Microsoft.Samples.DirectoryServices