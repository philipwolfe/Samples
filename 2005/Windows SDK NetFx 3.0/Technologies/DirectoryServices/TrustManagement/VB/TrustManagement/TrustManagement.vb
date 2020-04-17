'=====================================================================
'  File:     TrustManagement.vb
'
'  Summary:  Demonstrates managing a cross forest trust.
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

    Public NotInheritable Class TrustManagement

        Private Sub New()
        End Sub

        Shared Sub Main()
            Try
                Dim sourceForestName As String = "fabrikam.com"

                Dim targetForestName As String = "app.com"

                Dim excludedTopLevelName1 As String = "external.app.com"

                ' trust lifetime management
                Dim sourceForest As Forest = _
                    Forest.GetForest( _
                        New DirectoryContext( _
                            DirectoryContextType.Forest, sourceForestName))

                Dim targetForest As Forest = _
                    Forest.GetForest( _
                        New DirectoryContext( _
                            DirectoryContextType.Forest, targetForestName))

                ' create an inbound forest trust
                sourceForest.CreateTrustRelationship(targetForest, _
                                                    TrustDirection.Outbound)
                Console.WriteLine()
                Console.WriteLine("CreateTrustRelationship succeed")

                ' obtain the newly created trust
                Dim forestTrust As ForestTrustRelationshipInformation = _
                            sourceForest.GetTrustRelationship(targetForestName)

                Console.WriteLine()
                Console.WriteLine("The new forest trust: ""{0}"" - ""{1}"", " + _
                                    "trust direction is {2}, trust type is {3}", _
                                    sourceForestName, targetForestName, _
                                    forestTrust.TrustDirection, _
                                    forestTrust.TrustType)

                Console.WriteLine( _
                    "SelectiveAuthenticationStatus of the trust is {0}", _
                    sourceForest.GetSelectiveAuthenticationStatus( _
                                                        targetForestName))

                Console.WriteLine("SidFilteringStatus of the trust is {0}", _
                    sourceForest.GetSidFilteringStatus(targetForestName))

                ' change trust attribute
                sourceForest.SetSelectiveAuthenticationStatus( _
                                                    targetForestName, True)
                sourceForest.SetSidFilteringStatus(targetForestName, False)
                Console.WriteLine()
                Console.WriteLine("SelectiveAuthenticationStatus of the " + _
                                "trust is now {0}", _
                                sourceForest.GetSelectiveAuthenticationStatus( _
                                                            targetForestName))

                Console.WriteLine("SidFilteringStatus of the trust is now {0}", _
                            sourceForest.GetSidFilteringStatus(targetForestName))

                ' verify trust relationship
                sourceForest.VerifyOutboundTrustRelationship(targetForestName)
                Console.WriteLine()
                Console.WriteLine("VerifyOutboundTrustRelationship succeeded")
                Console.WriteLine()

                ' update the trust direction
                sourceForest.UpdateTrustRelationship(targetForest, _
                                                TrustDirection.Bidirectional)

                Console.WriteLine()
                Console.WriteLine("UpdateTrustRelationship succeeded")

                ' check the trust direction has been updated
                forestTrust = sourceForest.GetTrustRelationship(targetForestName)
                Console.WriteLine()
                Console.WriteLine("After updating the trust direction: " + _
                                """{0}"" - ""{1}"", trust direction is {2}, " + _
                                "trust type is {3}", _
                                sourceForestName, targetForestName, _
                                forestTrust.TrustDirection, forestTrust.TrustType)

                ' verify the trust direction again
                sourceForest.VerifyTrustRelationship(targetForest, _
                                                TrustDirection.Bidirectional)
                Console.WriteLine()
                Console.WriteLine("VerifyTrustRelationship succeeded")

                ' get the forest trust information
                Console.WriteLine()
                Console.WriteLine("Get forest trust information")
                Console.WriteLine("TopLevelNems include:")
                Dim t As TopLevelName
                For Each t In forestTrust.TopLevelNames
                    Console.Write(ControlChars.Tab)
                    Console.WriteLine("{0}, status is {1}", t.Name, t.Status)
                Next t
                Console.WriteLine("ExcludedTopLevelNems include:")
                Dim s As String
                For Each s In forestTrust.ExcludedTopLevelNames
                    Console.WriteLine(ControlChars.Tab + "{0}", s)
                Next s
                Console.WriteLine("ForestTrustDomainInformation:")
                Dim info As ForestTrustDomainInformation
                For Each info In forestTrust.TrustedDomainInformation
                    Console.Write(ControlChars.Tab)
                    Console.WriteLine("DNS name is {0}, NetBIOS name is {1}, " + _
                                "domain sid is {2} and status is {3}", _
                                info.DnsName, info.NetBiosName, _
                                info.DomainSid, info.Status)
                Next info

                ' modify the excluded top level name
                forestTrust.ExcludedTopLevelNames.Add(excludedTopLevelName1)
                forestTrust.Save()

                Console.WriteLine()
                Console.WriteLine("After modifying, " + _
                                    "ExcludedTopLevelNames include:")

                For Each s In forestTrust.ExcludedTopLevelNames
                    Console.WriteLine(ControlChars.Tab + "{0}", s)
                Next s

                ' repair the trust when necessary
                sourceForest.RepairTrustRelationship(targetForest)
                Console.WriteLine()
                Console.WriteLine("RepairTrustRelationship succeeded")

                ' delete the forest trust
                sourceForest.DeleteTrustRelationship(targetForest)
                Console.WriteLine()
                Console.WriteLine("DeleteTrustRelationship succeeded")
            Catch e As Exception
                Console.WriteLine()
                Console.WriteLine("Unexpected exception occured:")
                Console.WriteLine(e.GetType().Name + ":" + e.Message)
            End Try
        End Sub 'Main
    End Class 'TrustManagement
End Namespace 'Microsoft.Samples.DirectoryServices