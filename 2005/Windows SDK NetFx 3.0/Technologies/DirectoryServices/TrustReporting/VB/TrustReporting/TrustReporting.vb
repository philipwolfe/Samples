'=====================================================================
'  File:     TrustReporting.vb
'
'  Summary:  Demonstrates retrieving trust information.
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

    Public NotInheritable Class TrustReporting

        Shared Sub Main()
            Try
                Dim targetDomainName As String = "fabrikam.com"
                Dim targetForestName As String = "corp.fabrikam.com"

                Dim currentDomain As Domain = Domain.GetCurrentDomain()
                Dim currentForest As Forest = Forest.GetCurrentForest()

                ' Retrieve all the domain trusts
                Console.WriteLine()
                Console.WriteLine("Retrieve all the trusts with current domain:")
                Console.WriteLine()
                Dim trust As TrustRelationshipInformation
                For Each trust In currentDomain.GetAllTrustRelationships()
                    ' for each domain trust relationship, get its properties
                    Console.WriteLine("""{0}"" - ""{1}"", trust direction is {2}, " + _
                                        "trust type is {3}", _
                                        trust.SourceName, trust.TargetName, _
                                        trust.TrustDirection, trust.TrustType)
                Next trust

                ' Retrieve all the forest trusts
                Console.WriteLine()
                Console.WriteLine("Retrieve all the forest trusts " + _
                                    "with current forest:")
                Console.WriteLine()

                For Each trust In currentForest.GetAllTrustRelationships()
                    ' for each forest trust relationship, get its properties
                    Console.WriteLine("""{0}"" - ""{1}"", trust direction is {2}, " + _
                                        "trust type is {3}", _
                                        trust.SourceName, trust.TargetName, _
                                        trust.TrustDirection, trust.TrustType)
                Next trust

                ' Retrieve trust by name
                Console.WriteLine()
                Console.WriteLine("Retrieve the trust with the target domain:")
                Console.WriteLine()
                Dim domainTrust As TrustRelationshipInformation = _
                                currentDomain.GetTrustRelationship(targetDomainName)

                Console.WriteLine("""{0}"" - ""{1}"", trust direction is {2}, " + _
                                    "trust type is {3}", _
                                    currentDomain.Name, targetDomainName, _
                                    domainTrust.TrustDirection, domainTrust.TrustType)

                Console.WriteLine()
                Console.WriteLine("Retrieve the trust with the target forest:")
                Console.WriteLine()
                Dim forestTrust As ForestTrustRelationshipInformation = _
                                currentForest.GetTrustRelationship(targetForestName)
                Console.WriteLine("""{0}"" - ""{1}"", trust direction is {2}, " + _
                                    "trust type is {3}", _
                                    currentForest.Name, targetForestName, _
                                    forestTrust.TrustDirection, forestTrust.TrustType)
            Catch e As Exception
                Console.WriteLine()
                Console.WriteLine("Unexpected exception occured:")
                Console.WriteLine(e.GetType().Name + ":" + e.Message)
            End Try
        End Sub 'Main
    End Class 'TrustReporting
End Namespace 'Microsoft.Samples.DirectoryServices