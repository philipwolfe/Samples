/*=====================================================================
  File:      DisplaySecurityDescObj.cs

  Summary:   This sample shows how to display the security descriptor
             object for a directory entry

---------------------------------------------------------------------
  This file is part of the Microsoft .NET SDK Code Samples.

  Copyright (C) Microsoft Corporation.  All rights reserved.

This source code is intended only as a supplement to Microsoft
Development Tools and/or on-line documentation.  See these other
materials for detailed information regarding Microsoft code samples.

THIS CODE AND INFORMATION ARE PROVIDED "AS IS" WITHOUT WARRANTY OF ANY
KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE
IMPLIED WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A
PARTICULAR PURPOSE.
=====================================================================*/

// To compile: 
//      csc.exe DisplaySecurityDescriptorObject.cs /r:Interop.ActiveDs.dll
// To run: 
//      DisplaySecurityDescriptorObject.exe 

using System;
using System.Security.Permissions;

using System.DirectoryServices;

using System.Security.Principal; // For SecurityIdentifier class
using System.Security.AccessControl; // For AuthorizationRuleCollection class

[assembly: System.Runtime.InteropServices.ComVisible(false)]
[assembly: System.Reflection.AssemblyVersion("1.0.0.0")]
[assembly: SecurityPermission(SecurityAction.RequestMinimum, Execution = true)]
[assembly: DirectoryServicesPermission(SecurityAction.RequestMinimum)]

namespace Microsoft.Samples.DirectoryServices
{
    public class DisplaySecurityDescriptorObjectSample
    {
        // Change the value of next constant to bind to a particular domain
        // Value of null means current domain
        static string domainADsPath = null;

        public static void Main(string[] args)
        {
            try
            {
                DisplaySecurityDescriptor(new DirectoryEntry(domainADsPath));

                Console.WriteLine("\r\nApplication Finished Successfully!!!");
            }
            catch (Exception e)
            {
                Console.WriteLine("\r\nUnexpected exception occured:\r\n\t" +
                                e.GetType() + ":" + e.Message);
            }            
        }

        public static void DisplaySecurityDescriptor(DirectoryEntry entry)
        {
            // Specify SACL and DACL to be returned
            entry.Options.SecurityMasks = SecurityMasks.Owner | SecurityMasks.Group
					 | SecurityMasks.Dacl | SecurityMasks.Sacl;
            ActiveDirectorySecurity sd = entry.ObjectSecurity;

            Console.WriteLine("DISPLAYING DIRECTORY ENTRY SID");
            Console.WriteLine("Group:\t" + 
                                sd.GetGroup(typeof(SecurityIdentifier)).Value);
            Console.WriteLine("Owner:\t" + 
                                sd.GetOwner(typeof(SecurityIdentifier)).Value);
            Console.WriteLine("Access Rules canonical:\t" + 
                                sd.AreAccessRulesCanonical.ToString());
            Console.WriteLine("Access Rules protected:\t" + 
                                sd.AreAccessRulesProtected);
            Console.WriteLine("Audit Rules canonical:\t" + 
                                sd.AreAuditRulesCanonical.ToString());
            Console.WriteLine("Audit Rules protected:\t" + 
                                sd.AreAuditRulesProtected.ToString());
            Console.WriteLine("Access right type:\t" + 
                                sd.AccessRightType.ToString());
            Console.WriteLine("Audit rule type:\t" + 
                                sd.AuditRuleType.ToString());
            Console.WriteLine();

            Console.WriteLine("Access Rules");
            DisplayDACL(sd.GetAccessRules(true, true, typeof(SecurityIdentifier)));
            Console.WriteLine("Audit Rules");
            Console.ReadLine();
            DisplaySACL(sd.GetAuditRules(true, true, typeof(SecurityIdentifier)));
        }

        public static void DisplayDACL(AuthorizationRuleCollection dACL)
        {
            DisplayACL(true, dACL);
        }

        public static void DisplaySACL(AuthorizationRuleCollection sACL)
        {
            DisplayACL(false, sACL);
        }

        public static void DisplayACL(bool isDACL, AuthorizationRuleCollection aCL)
        {
            Console.WriteLine("DISPLAYING ACL");

            foreach (AuthorizationRule aCE in aCL)
            {
                // Display common AuthorizationRule properties
                Console.WriteLine("Identity Reference: " + 
                                        aCE.IdentityReference.ToString());
                Console.WriteLine("Inheritance Flags: " + 
                                        aCE.InheritanceFlags.ToString());
                Console.WriteLine("Is Inherited: " +
                                        aCE.IsInherited.ToString());
                Console.WriteLine("Propagation Flags: " +
                                        aCE.PropagationFlags.ToString());

                // Display properties of AccessRule or AuditRule only
                ActiveDirectorySecurityInheritance inheritanceType;
                InheritanceFlags inheritanceFlags;
                ObjectAceFlags objectFlags;
                Guid objectType;

                if (isDACL)
                {
                    inheritanceType = 
                        ((ActiveDirectoryAccessRule)aCE).InheritanceType;
                    inheritanceFlags = 
                        ((ActiveDirectoryAccessRule)aCE).InheritanceFlags;
                    objectFlags = 
                        ((ActiveDirectoryAccessRule)aCE).ObjectFlags;
                    objectType = 
                        ((ActiveDirectoryAccessRule)aCE).ObjectType;
                }
                else
                {
                    inheritanceType = 
                        ((ActiveDirectoryAuditRule)aCE).InheritanceType;
                    inheritanceFlags = 
                        ((ActiveDirectoryAuditRule)aCE).InheritanceFlags;
                    objectFlags = 
                        ((ActiveDirectoryAuditRule)aCE).ObjectFlags;
                    objectType = 
                        ((ActiveDirectoryAuditRule)aCE).ObjectType;
                }

                Console.WriteLine("Inheritance Type: " +
                                        inheritanceType.ToString());
                Console.WriteLine("Inherited Object Type: " +
                                        inheritanceFlags.ToString());
                Console.WriteLine("Object Flags: " +
                                        objectFlags.ToString());
                Console.WriteLine("Object Type: " +
                                        objectType.ToString());
                Console.WriteLine();
            }
        }
    } // End class DisplaySecurityDescriptorObjectSample
}
