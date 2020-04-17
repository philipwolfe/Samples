/*=====================================================================
  File:     Domain.cs

  Summary:  Demonstrates retrieving information about the current
            forest and domain like the domain names, GCs and DCs, role
            owners etc.   

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
    public class Domainsample
    {
        public static void Main()
        {
            try
            {
                ForestSample();
                DomainSample();
            }
            catch(Exception e)
            {
                Console.WriteLine("\r\nUnexpected exception occured:\r\n\t" + 
                                e.GetType().Name + ":" + e.Message);
            }
            catch
            {
                // Handle non-CLSCompliant exceptions
                Console.WriteLine("\r\nA non-CLSCompliant exception occured\r\n");
            }
        }

        public static void ForestSample()
        {

            Console.WriteLine();
            Console.WriteLine("<---------FOREST INFO---------->\n");

            // get the current forest
            Forest forest;

            try
            {
                forest = Forest.GetCurrentForest();
            }
            catch (ActiveDirectoryObjectNotFoundException e)
            {
                // current context is not associated with domain/forest
                Console.WriteLine(e.Message);
                return;
            }

            Console.WriteLine("Current forest: {0}", forest.Name);
            Console.WriteLine();

            // all domains with this forest
            Console.WriteLine("Domains in the forest:");
            foreach (Domain domain in forest.Domains)
            {
                Console.WriteLine(domain.Name);
            }
            Console.WriteLine();

            // all global catalogs within the forest
            Console.WriteLine("Global catalogs in the forest:");
            foreach (GlobalCatalog gc in forest.GlobalCatalogs)
            {
                Console.WriteLine(gc.Name);
            }
            Console.WriteLine();

            // role owners in the forest
            Console.WriteLine("Role owners:");
            Console.WriteLine("NamingRole: {0}", forest.NamingRoleOwner);
            Console.WriteLine("SchemaRole: {0}", forest.SchemaRoleOwner);
            Console.WriteLine();

        }

        public static void DomainSample()
        {

            Console.WriteLine();
            Console.WriteLine("<---------DOMAIN INFO---------->\n");

            // get the current domain
            Domain domain;

            try
            {
                domain = Domain.GetCurrentDomain();
            }
            catch (ActiveDirectoryObjectNotFoundException e)
            {
                // current context is not associated with a domain/forest
                Console.WriteLine(e.Message);
                return;
            }

            Console.WriteLine("Current domain: {0}", domain.Name);
            Console.WriteLine();

            // get it's parent domain
            Console.WriteLine("Parent domain:");
            Domain parentDomain = domain.Parent;
            if (parentDomain == null)
            {
                Console.WriteLine("Current domain is the root of the "+
                                                                "domain tree.");
            }
            else
            {
                Console.WriteLine(domain.Parent);
            }
            Console.WriteLine();

            // all child domains
            Console.WriteLine("Child domains:");
            foreach (Domain childDomain in domain.Children)
            {
                Console.WriteLine(childDomain.Name);
            }
            Console.WriteLine();

            // all domain contollers within the domain
            Console.WriteLine("Domain controllers in the domain:");
            foreach (DomainController dc in domain.DomainControllers)
            {
                Console.WriteLine(dc.Name);
            }
            Console.WriteLine();

            // Find the PDC
            Console.WriteLine("PDC: {0}", domain.PdcRoleOwner);
            Console.WriteLine();

        }
    }
}
