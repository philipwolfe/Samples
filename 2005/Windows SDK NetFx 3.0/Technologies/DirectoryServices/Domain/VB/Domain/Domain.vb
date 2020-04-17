'=====================================================================
'  File:     Domain.vb
'
'  Summary:  Demonstrates retrieving information about the current
'            forest and domain like the domain names, GCs and DCs, role
'            owners etc.   
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

    Public NotInheritable Class Domainsample

        Private Sub New()
        End Sub

        Public Shared Sub Main()
            Try
                ForestSample()
                DomainSample()
            Catch e As Exception
                Console.WriteLine("Unexpected exception occured:")
                Console.WriteLine(e.GetType().Name + ":" + e.Message)
            End Try
        End Sub 'Main

        Public Shared Sub ForestSample()

            Console.WriteLine()
            Console.WriteLine("<---------FOREST INFO---------->")
            Console.WriteLine()

            ' get the current forest
            Dim forest As Forest

            Try
                forest = ActiveDirectory.Forest.GetCurrentForest()
            Catch e As ActiveDirectoryObjectNotFoundException
                ' current context is not associated with domain/forest
                Console.WriteLine(e.Message)
                Return
            End Try

            Console.WriteLine("Current forest: {0}", forest.Name)
            Console.WriteLine()

            ' all domains with this forest
            Console.WriteLine("Domains in the forest:")
            Dim domain As ActiveDirectory.Domain
            For Each domain In forest.Domains
                Console.WriteLine(domain.Name)
            Next domain
            Console.WriteLine()

            ' all global catalogs within the forest
            Console.WriteLine("Global catalogs in the forest:")
            Dim gc As GlobalCatalog
            For Each gc In forest.GlobalCatalogs
                Console.WriteLine(gc.Name)
            Next gc
            Console.WriteLine()

            ' role owners in the forest
            Console.WriteLine("Role owners:")
            Console.WriteLine("NamingRole: {0}", forest.NamingRoleOwner)
            Console.WriteLine("SchemaRole: {0}", forest.SchemaRoleOwner)
            Console.WriteLine()
        End Sub 'ForestSample


        Public Shared Sub DomainSample()

            Console.WriteLine()
            Console.WriteLine("<---------DOMAIN INFO---------->")
            Console.WriteLine()

            ' get the current domain
            Dim domain As ActiveDirectory.Domain

            Try
                domain = ActiveDirectory.Domain.GetCurrentDomain()
            Catch e As ActiveDirectoryObjectNotFoundException
                ' current context is not associated with a domain/forest
                Console.WriteLine(e.Message)
                Return
            End Try

            Console.WriteLine("Current domain: {0}", domain.Name)
            Console.WriteLine()

            ' get it's parent domain
            Console.WriteLine("Parent domain:")
            Dim parentDomain As ActiveDirectory.Domain = domain.Parent
            If parentDomain Is Nothing Then
                Console.WriteLine(("Current domain is the root of the " + "domain tree."))
            Else
                Console.WriteLine(domain.Parent)
            End If
            Console.WriteLine()

            ' all child domains
            Console.WriteLine("Child domains:")
            Dim childDomain As ActiveDirectory.Domain
            For Each childDomain In domain.Children
                Console.WriteLine(childDomain.Name)
            Next childDomain
            Console.WriteLine()

            ' all domain contollers within the domain
            Console.WriteLine("Domain controllers in the domain:")
            Dim dc As DomainController
            For Each dc In domain.DomainControllers
                Console.WriteLine(dc.Name)
            Next dc
            Console.WriteLine()

            ' Find the PDC
            Console.WriteLine("PDC: {0}", domain.PdcRoleOwner)
            Console.WriteLine()
        End Sub 'DomainSample 
    End Class 'Domainsample
End Namespace 'Microsoft.Samples.DirectoryServices