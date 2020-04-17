'=====================================================================
'  File:      DirSyncSearch.vb
'
'  Summary:   This sample shows how directory synchronization search
'             works in System.DirectoryServices
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

    Public NotInheritable Class DirectorySynchronizationSearchSample
        ' Change the value of next constant to bind to a particular domain
        ' Value of null means current domain
        Private Shared domainADsPath As String = "LDAP://fabrikam.com"

        Public Overloads Shared Sub Main()
            Try
                DirectorySynchronizationSearch()

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

        Shared Sub DirectorySynchronizationSearch()
            ' First add a temporal user to help the sample
            Dim lDAPPathUser As String = addTempUser()

            Dim searcher As New DirectorySearcher()

            searcher.SearchRoot = New DirectoryEntry(domainADsPath)
            searcher.Filter = "(objectClass=user)"
            ' For a directory synchronization search scope must be subtree
            searcher.SearchScope = SearchScope.Subtree
            searcher.Sort = New SortOption("name", _
                            SortDirection.Ascending)

            searcher.PropertiesToLoad.AddRange( _
                            New String() {"displayName", "name"})

            searcher.DirectorySynchronization = New DirectorySynchronization()

            ' Do the first search - results should be all
            Dim results As SearchResultCollection = searcher.FindAll()
            Console.WriteLine("DO THE FIRST SEARCH")
            displayResults(results)
            ' Results are disposed explicitly
            results.Dispose()

            ' Do the same search - results should be none
            Dim newResults As SearchResultCollection = searcher.FindAll()
            Console.WriteLine()
            Console.WriteLine()
            Console.WriteLine("DO THE SAME SEARCH")
            displayResults(newResults)
            ' Results are disposed explicitly
            newResults.Dispose()

            ' Modify displayName property value
            modifyUser(lDAPPathUser, "_MODIFIED")

            ' Do the same search - results should be modified user
            newResults = searcher.FindAll()
            Console.WriteLine()
            Console.WriteLine()
            Console.WriteLine("DO THE SAME SEARCH")
            displayResults(newResults)
            ' Results are disposed explicitly
            newResults.Dispose()

            ' Delete temporary user
            deleteTempUser(lDAPPathUser)
        End Sub 'DirectorySynchronizationSearch


        Private Shared Function addTempUser() As String
            Dim entry As New DirectoryEntry(domainADsPath)

            Dim newEntry As DirectoryEntry = _
                            entry.Children.Add("CN=TemporaryUser", "user")

            newEntry.Properties("displayName").Value = "TemporaryUser"
            newEntry.CommitChanges()

            Return newEntry.Path
        End Function 'addTempUser


        Private Shared Sub deleteTempUser(ByVal lDAPPathUser As String)
            Dim entry As New DirectoryEntry(domainADsPath)

            entry.Children.Remove(New DirectoryEntry(lDAPPathUser))
        End Sub 'deleteTempUser


        Private Shared Sub modifyUser(ByVal lDAPPAth As String, _
                                        ByVal stringToAdd As String)
            Dim entry As New DirectoryEntry(lDAPPAth)

            entry.Properties("displayName").Value += stringToAdd
            entry.CommitChanges()
        End Sub 'modifyUser


        Private Shared Sub displayResults( _
                                ByVal results As SearchResultCollection)
            ' About to perform search
            Console.Write("Searching...")
            If results.Count = 0 Then
                Console.WriteLine()
                Console.WriteLine("There is no results to display")
            Else
                Console.WriteLine()
                Console.WriteLine("RESULT COLLECTION INFORMATION")
                Console.WriteLine(("Number of results:" + _
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
    End Class 'DirectorySynchronizationSearchSample
End Namespace 'Microsoft.Samples.DirectoryServices