'=====================================================================
'  File:      DisplaySecurityDescObj.vb
'
'  Summary:   This sample shows how to display the security descriptor
'             object for a directory entry
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

Imports System.Security.Principal ' For SecurityIdentifier class
Imports System.Security.AccessControl ' For AuthorizationRuleCollection class


<Assembly: System.Reflection.AssemblyVersion("1.0.0.0")> 
<Assembly: SecurityPermission(SecurityAction.RequestMinimum, Execution:=True)> 
<Assembly: DirectoryServicesPermission(SecurityAction.RequestMinimum)> 

Namespace Microsoft.Samples.DirectoryServices

    Public NotInheritable Class DisplaySecurityDescriptorObjectSample
        ' Change the value of next constant to bind to a particular domain
        ' Value of Nothing means current domain
        Private Shared domainADsPath As String = Nothing

        Public Overloads Shared Sub Main()
            Try
                DisplaySecurityDescriptor(New DirectoryEntry(domainADsPath))

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

        Public Shared Sub DisplaySecurityDescriptor(ByVal entry As DirectoryEntry)
            ' Specify SACL and DACL to be returned
            entry.Options.SecurityMasks = SecurityMasks.Owner Or SecurityMasks.Group _
					 Or SecurityMasks.Dacl Or SecurityMasks.Sacl
            Dim sd As ActiveDirectorySecurity = entry.ObjectSecurity

            Console.WriteLine("DISPLAYING DIRECTORY ENTRY SID")
            Console.WriteLine(("Group:" + _
                                sd.GetGroup(GetType(SecurityIdentifier)).Value))
            Console.WriteLine(("Owner:" + _
                                sd.GetOwner(GetType(SecurityIdentifier)).Value))
            Console.WriteLine(("Access Rules canonical:" + _
                                sd.AreAccessRulesCanonical.ToString()))
            Console.WriteLine(("Access Rules protected:" + _
                                sd.AreAccessRulesProtected.ToString()))
            Console.WriteLine(("Audit Rules canonical:" + _
                                sd.AreAuditRulesCanonical.ToString()))
            Console.WriteLine(("Audit Rules protected:" + _
                                sd.AreAuditRulesProtected.ToString()))
            Console.WriteLine(("Access right type:" + _
                                sd.AccessRightType.ToString()))
            Console.WriteLine(("Audit rule type:" + _
                                sd.AuditRuleType.ToString()))
            Console.WriteLine()

            Console.WriteLine("Access Rules")
            DisplayDACL(sd.GetAccessRules(True, True, GetType(SecurityIdentifier)))
            Console.WriteLine("Audit Rules")
            DisplaySACL(sd.GetAuditRules(True, True, GetType(SecurityIdentifier)))
        End Sub 'DisplaySecurityDescriptor

        Public Shared Sub DisplayDACL(ByVal dACL As AuthorizationRuleCollection)
            DisplayACL(true, dACL)
        End Sub

        Public Shared Sub DisplaySACL(ByVal sACL As AuthorizationRuleCollection)
            DisplayACL(false, sACL)
        End Sub

        Public Shared Sub DisplayACL(ByVal isDACL As Boolean, ByVal aCL As AuthorizationRuleCollection)
            Console.WriteLine("DISPLAYING ACL")

            Dim aCE As AuthorizationRule
            For Each aCE In  aCL
               ' Display common AuthorizationRule properties
               Console.WriteLine(("Identity Reference: " + aCE.IdentityReference.ToString()))
               Console.WriteLine(("Inheritance Flags: " + aCE.InheritanceFlags.ToString()))
               Console.WriteLine(("Is Inherited: " + aCE.IsInherited.ToString()))
               Console.WriteLine(("Propagation Flags: " + aCE.PropagationFlags.ToString()))
   
               ' Display properties of AccessRule or AuditRule only
               Dim inheritanceType As ActiveDirectorySecurityInheritance
               Dim inheritanceFlags As InheritanceFlags
               Dim objectFlags As ObjectAceFlags
               Dim objectType As Guid
   
               If isDACL Then
                  inheritanceType = CType(aCE, ActiveDirectoryAccessRule).InheritanceType
                  inheritanceFlags = CType(aCE, ActiveDirectoryAccessRule).InheritanceFlags
                  objectFlags = CType(aCE, ActiveDirectoryAccessRule).ObjectFlags
                  objectType = CType(aCE, ActiveDirectoryAccessRule).ObjectType
               Else
                  inheritanceType = CType(aCE, ActiveDirectoryAuditRule).InheritanceType
                  inheritanceFlags = CType(aCE, ActiveDirectoryAuditRule).InheritanceFlags
                  objectFlags = CType(aCE, ActiveDirectoryAuditRule).ObjectFlags
                  objectType = CType(aCE, ActiveDirectoryAuditRule).ObjectType
               End If
   
               Console.WriteLine(("Inheritance Type: " + inheritanceType.ToString()))
               Console.WriteLine(("Inherited Object Type: " + inheritanceFlags.ToString()))
               Console.WriteLine(("Object Flags: " + objectFlags.ToString()))
               Console.WriteLine(("Object Type: " + objectType.ToString()))
               Console.WriteLine()
            Next aCE
        End Sub 'DisplayACL
    End Class 'DisplaySecurityDescriptorObjectSample
End Namespace 'Microsoft.Samples.DirectoryServices