'=====================================================================
'  File:      BasicDirectorySearch.vb
'
'  Summary:   This sample shows how to do a basic search in a 
'             Active Directory
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


<Assembly: System.Reflection.AssemblyVersion("1.0.0.0")> 
<Assembly: SecurityPermission(SecurityAction.RequestMinimum, Execution:=True)> 
<Assembly: DirectoryServicesPermission(SecurityAction.RequestMinimum)> 


Namespace Microsoft.Samples.DirectoryServices

    Public NotInheritable Class BasicDirectorySearchSample
        ' Change the value of next constant to bind to a particular domain
        ' Value of null means current domain
        Private Shared domainADsPath As String = "LDAP://fabrikam.com"
        Private Shared username As String = "someone@example.com"
        Private Shared password As String = "Pass@word1"
        ' Change the value of next constant to search for particular objects
        ' Value of "user" means will search for users in the domain
        Private Shared schemaClassNameToSearch As String = "user"

        Private Sub New()
        End Sub

        Public Overloads Shared Sub Main()
            Try
                BasicDirectorySearch()

                Console.WriteLine(ControlChars.Cr + ControlChars.Lf + _
                                    "Application Finished Successfully!!!")
            Catch e As Exception
                Console.WriteLine((ControlChars.Cr + ControlChars.Lf + _
                                    "Unexpected exception occured:" + _
                                    ControlChars.Cr + ControlChars.Lf + _
                                    ControlChars.Tab + e.GetType().ToString() + _
                                    ":" + e.Message))
            End Try
        End Sub 'Main

        Shared Sub BasicDirectorySearch()
            Dim searcher As New DirectorySearcher()

            ' Will perform a search of <schemaClassNameToSearch> objects in 
            ' current(domain)
            searcher.SearchRoot = New DirectoryEntry(domainADsPath, _
                                                        username, password)
            searcher.Filter = "(objectClass=" + schemaClassNameToSearch + ")"
            searcher.SearchScope = SearchScope.Subtree
            searcher.Sort = New SortOption("name", _
                                                SortDirection.Ascending)
            ' If there is a large set to be return ser page size for a paged search
            searcher.PageSize = 512

            searcher.PropertiesToLoad.AddRange(New String() {"displayName", _
                                                        "name"})

            Dim results As SearchResultCollection = searcher.FindAll()
            DisplayResults(results)

            ' Results are explicitly disposed
            results.Dispose()
        End Sub 'BasicDirectorySearch


        Public Shared Sub DisplayResults(ByVal results As SearchResultCollection)
            ' About to perform search
            Console.Write("Searching...")
            If results.Count = 0 Then
                Console.WriteLine(ControlChars.Cr + ControlChars.Lf + _
                                    "There is no results to display")
            Else
                Console.WriteLine()
                Console.WriteLine("RESULT COLLECTION INFORMATION")
                Console.WriteLine(("Number of results: " + _
                                results.Count.ToString()))
                Console.WriteLine(("Number of properties loaded:" + _
                                results.PropertiesLoaded.Length.ToString()))
                Console.Write("Properties loaded:")
                Dim i As Integer
                For i = 0 To results.PropertiesLoaded.Length - 1
                    Console.Write((results.PropertiesLoaded(i) + " "))
                Next i
                Console.WriteLine()
                Console.WriteLine()
                Console.WriteLine("RESULTS")

                Dim result As SearchResult
                For Each result In results
                    Console.WriteLine(("Path:" + result.Path))
                    Console.WriteLine(("Display Name:" + _
                            result.Properties("displayName").ToString()))
                    Console.WriteLine(("Name:" + _
                            result.Properties("name").ToString()))
                Next result
            End If
        End Sub 'displayResults
    End Class 'BasicDirectorySearchSample 
End Namespace 'Microsoft.Samples.DirectoryServices ' End class BasicDirectorySearchSample