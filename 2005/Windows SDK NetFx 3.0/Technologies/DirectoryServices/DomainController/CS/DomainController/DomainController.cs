/*=====================================================================
  File:     DomainController.cs

  Summary:  Demonstrates retrieving information about the global
            catalogs and domain controllers.

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


using System;
using System.Security.Permissions;
using System.DirectoryServices;
using System.DirectoryServices.ActiveDirectory;


[assembly: System.Reflection.AssemblyVersion("1.0.0.0")]
[assembly: SecurityPermission(SecurityAction.RequestMinimum, Execution = true)]
[assembly: DirectoryServicesPermission(SecurityAction.RequestMinimum)]




namespace Microsoft.Samples.DirectoryServices
{
    public class DomainControllerSamples
    {

        // what context to use (using current context here)
        static DirectoryContext forestContext = 
                            new DirectoryContext(DirectoryContextType.Forest);
        static DirectoryContext domainContext = 
                            new DirectoryContext(DirectoryContextType.Domain);

        // site name used to find a DC in a specific site
        static string siteName = "<replaceWithASiteName>";

        public static void Main()
        {
            try
            {
                GCSample();
                DCSample();
            }
            catch (Exception e)
            {
                Console.WriteLine("\r\nUnexpected exception occured:\r\n\t" +
                                  e.GetType().Name + ":" + e.Message);
            }           
        }

        public static void GCSample()
        {

            Console.WriteLine();
            Console.WriteLine("<---------GLOBAL CATALOG INFO---------->\n");

            // Find one global catalog within the current forest
            GlobalCatalog gc;

            try
            {
                gc = GlobalCatalog.FindOne(forestContext);
                Console.WriteLine("Finding one global catalog "+
                                                    "in the current forest:");
                Console.WriteLine("Name: {0}", gc);
                Console.WriteLine("Site: {0}", gc.SiteName);

                // roles held by the GC
                Console.WriteLine();
                Console.WriteLine("Roles:");
                foreach (ActiveDirectoryRole role in gc.Roles)
                {
                    Console.WriteLine(role);
                }

                // partitions hosted by the GC
                Console.WriteLine();
                Console.WriteLine("Partitions hosted by this global catalog:");
                foreach (string partition in gc.Partitions)
                {
                    Console.WriteLine(partition);
                }
            }
            catch (ActiveDirectoryObjectNotFoundException e)
            {
                // gc not found
                Console.WriteLine(e.Message);
            }
            Console.WriteLine();

        }

        public static void DCSample()
        {

            Console.WriteLine();
            Console.WriteLine("<---------DOMAIN CONTROLLER INFO---------->\n");

            DomainController dc;

            // Find one domain controller within the current domain
            try
            {
                dc = DomainController.FindOne(domainContext);
                Console.WriteLine("Domain controller in the current domain:");
                Console.WriteLine(dc);
                Console.WriteLine("Site: {0}", dc.SiteName);
                Console.WriteLine("Is global catalog: {0}",
                                                          dc.IsGlobalCatalog());
                Console.WriteLine("Current Time: {0}", 
                                                  dc.CurrentTime.ToLocalTime());
                Console.WriteLine("IP Address: {0}", dc.IPAddress);
                Console.WriteLine();
            }
            catch (ActiveDirectoryObjectNotFoundException e)
            {
                // dc not found
                Console.WriteLine(e.Message);
            }

            // finding DC in a specific site
            try
            {
                dc = DomainController.FindOne(domainContext, siteName);
                Console.WriteLine("Domain controller in the current"+
                                         " domain and site \"{0}\":", siteName);
                Console.WriteLine(dc);
                Console.WriteLine("Site: {0}", dc.SiteName);
                Console.WriteLine("Is global catalog: {0}", 
                                                          dc.IsGlobalCatalog());
                Console.WriteLine();
            }
            catch (ActiveDirectoryObjectNotFoundException)
            {
                // dc not found
                Console.WriteLine("Domain controller in site \"{0}\" not found.",
                                                                      siteName);
            }

            // finding KDC
            try
            {
                dc = DomainController.FindOne(domainContext, 
                                                    LocatorOptions.KdcRequired);
                Console.WriteLine("KDC in the current domain:");
                Console.WriteLine(dc);
                Console.WriteLine("Site: {0}", dc.SiteName);
                Console.WriteLine("Is global catalog: {0}", dc.IsGlobalCatalog());
                Console.WriteLine();
            }
            catch (ActiveDirectoryObjectNotFoundException)
            {
                // dc not found
                Console.WriteLine("KDC not found in current domain.");
            }

        }
    }
}