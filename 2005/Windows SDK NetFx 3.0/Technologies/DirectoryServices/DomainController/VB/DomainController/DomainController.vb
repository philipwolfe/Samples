'=====================================================================
'  File:     DomainController.vb
'
'  Summary:  Demonstrates retrieving information about the global
'            catalogs and domain controllers.
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

    Public NotInheritable Class DomainControllerSamples

        ' what context to use (using current context here)
        Private Shared forestContext As New DirectoryContext(DirectoryContextType.Forest)
        Private Shared domainContext As New DirectoryContext(DirectoryContextType.Domain)

        ' site name used to find a DC in a specific site
        Private Shared siteName As String = "<replaceWithASiteName>"

        Private Sub New()
        End Sub

        Public Shared Sub Main()
            Try
                GCSample()
                DCSample()
            Catch e As Exception
                Console.WriteLine()
                Console.WriteLine("Unexpected exception occured:" + _
                                    e.GetType().Name + ":" + e.Message)
                Console.WriteLine()
            End Try
        End Sub 'Main

        Public Shared Sub GCSample()

            Console.WriteLine()
            Console.WriteLine("<---------GLOBAL CATALOG INFO---------->")
            Console.WriteLine()

            ' Find one global catalog within the current forest
            Dim gc As GlobalCatalog

            Try
                gc = GlobalCatalog.FindOne(forestContext)
                Console.WriteLine("Finding one global catalog " + _
                                        "in the current forest:")
                Console.WriteLine("Name: {0}", gc)
                Console.WriteLine("Site: {0}", gc.SiteName)

                ' roles held by the GC
                Console.WriteLine()
                Console.WriteLine("Roles:")
                Dim role As ActiveDirectoryRole
                For Each role In gc.Roles
                    Console.WriteLine(role)
                Next role

                ' partitions hosted by the GC
                Console.WriteLine()
                Console.WriteLine("Partitions hosted by this global catalog:")
                Dim partition As String
                For Each partition In gc.Partitions
                    Console.WriteLine(partition)
                Next partition
            Catch e As ActiveDirectoryObjectNotFoundException
                ' gc not found
                Console.WriteLine(e.Message)
            End Try
            Console.WriteLine()
        End Sub 'GCSample


        Public Shared Sub DCSample()

            Console.WriteLine()
            Console.WriteLine("<---------DOMAIN CONTROLLER INFO---------->")
            Console.WriteLine()

            Dim dc As ActiveDirectory.DomainController

            ' Find one domain controller within the current domain
            Try
                dc = ActiveDirectory.DomainController.FindOne(domainContext)
                Console.WriteLine("Domain controller in the current domain:")
                Console.WriteLine(dc)
                Console.WriteLine("Site: {0}", dc.SiteName)
                Console.WriteLine("Is global catalog: {0}", dc.IsGlobalCatalog())
                Console.WriteLine("Current Time: {0}", dc.CurrentTime.ToLocalTime())
                Console.WriteLine("IP Address: {0}", dc.IPAddress)
                Console.WriteLine()
            Catch e As ActiveDirectoryObjectNotFoundException
                ' dc not found
                Console.WriteLine(e.Message)
            End Try

            ' finding DC in a specific site
            Try
                dc = ActiveDirectory.DomainController.FindOne(domainContext, _
                                                                    siteName)
                Console.WriteLine("Domain controller in the current" + _
                                        " domain and site ""{0}"":", siteName)
                Console.WriteLine(dc)
                Console.WriteLine("Site: {0}", dc.SiteName)
                Console.WriteLine("Is global catalog: {0}", dc.IsGlobalCatalog())
                Console.WriteLine()
            Catch
            End Try
            ' dc not found

            ' finding KDC
            Try
                dc = ActiveDirectory.DomainController.FindOne(domainContext, _
                                                    LocatorOptions.KdcRequired)
                Console.WriteLine("KDC in the current domain:")
                Console.WriteLine(dc)
                Console.WriteLine("Site: {0}", dc.SiteName)
                Console.WriteLine("Is global catalog: {0}", dc.IsGlobalCatalog())
                Console.WriteLine()
            Catch
            End Try
        End Sub 'DCSample
    End Class 'DomainControllerSamples
End Namespace 'Microsoft.Samples.DirectoryServices
