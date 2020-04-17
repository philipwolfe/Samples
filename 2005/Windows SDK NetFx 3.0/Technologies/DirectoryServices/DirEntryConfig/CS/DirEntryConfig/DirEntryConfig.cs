/*=====================================================================
  File:      DirectoryEntryConfigurationSettings.cs

  Summary:   This sample shows how to get and set directory entry
             configuration settings using DirectoryEntryConfiguration
             class

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
//      csc.exe DirectoryEntryConfigurationSettings.cs /r:Interop.ActiveDs.dll
// To run: 
//      DirectoryEntryConfigurationSettings.exe 

using System;
using System.Security.Permissions;

using System.DirectoryServices;


[assembly: System.Runtime.InteropServices.ComVisible(false)]
[assembly: System.Reflection.AssemblyVersion("1.0.0.0")]
[assembly: CLSCompliant(true)]
[assembly: SecurityPermission(SecurityAction.RequestMinimum, Execution = true)]
[assembly: DirectoryServicesPermission(SecurityAction.RequestMinimum)]

namespace Microsoft.Samples.DirectoryServices
{
    public class DirectoryEntryConfigurationSettingsSample
    {
        // Change the value of next constant to bind to a particular domain
        // Value of null means current domain
        static string domainADsPath = null;

        public static void Main(string[] args)
        {
            try
            {
                DirectoryEntryConfigurationSettings();

                Console.WriteLine("\r\nApplication Finished Successfully!!!");
            }
            catch (Exception e)
            {
                Console.WriteLine("\r\nUnexpected exception occured:\r\n\t" +
                                e.GetType() + ":" + e.Message);
            }
            
        }

        static void DirectoryEntryConfigurationSettings()
        {
            // Bind to current domain
            DirectoryEntry entry = new DirectoryEntry(domainADsPath);
            DirectoryEntryConfiguration entryConfiguration = entry.Options;

            // Display directory entry configuration
            // Notice that options property (entry.Options) is the parameter to the function
            DisplayConfigurationEntryConfiguration(entry.Options);

            // Enable paged search and referral chasing in directory entry configuration
            // Clear security masks in directory entry configuration
            // Notice that the changes are set in the reference object (entryConfiguration object)
            entryConfiguration.PageSize = 50;
            entryConfiguration.Referral = ReferralChasingOption.Subordinate;
            // Or can be done directly to the property (entry.Options property)
            entry.Options.SecurityMasks = SecurityMasks.None;

            // Display directory entry configuration modified
            // Notice that options property (entry.Options) is the parameter to the function
            DisplayConfigurationEntryConfiguration(entry.Options);

            // Set the defaults again for directory entry configuration
            SetDefaultsForEntryConfiguration(entryConfiguration);

            // Display directory entry configuration modified to defaults
            DisplayConfigurationEntryConfiguration(entry.Options);
        }

        static void SetDefaultsForEntryConfiguration(DirectoryEntryConfiguration entryConfiguration)
        {
            entryConfiguration.PageSize = 512;
            entryConfiguration.PasswordEncoding = PasswordEncodingMethod.PasswordEncodingSsl;
            entryConfiguration.PasswordPort = 636;
            entryConfiguration.Referral = ReferralChasingOption.External;
            entryConfiguration.SecurityMasks = SecurityMasks.Owner | SecurityMasks.Group | SecurityMasks.Dacl;
        }

        static void DisplayConfigurationEntryConfiguration(DirectoryEntryConfiguration entryConfiguration)
        {
            Console.WriteLine("DISPLAYING DIRECTORY ENTRY CONFIGURATION");
            Console.WriteLine("Server\t\t\t\t" + entryConfiguration.GetCurrentServerName());
            Console.WriteLine("Page Size\t\t\t" + entryConfiguration.PageSize.ToString());
            Console.WriteLine("Password Encoding\t\t" + entryConfiguration.PasswordEncoding.ToString());
            Console.WriteLine("Password Port\t\t\t" + entryConfiguration.PasswordPort.ToString());
            Console.WriteLine("Referral\t\t\t" + entryConfiguration.Referral.ToString());
            Console.WriteLine("Security Masks\t\t\t" + entryConfiguration.SecurityMasks.ToString());
            Console.WriteLine("Is Mutually Authenticated\t" + entryConfiguration.IsMutuallyAuthenticated().ToString());
            Console.WriteLine();
        }
    } // End class DirectoryEntryConfigurationSettingsSample
}
