/*=====================================================================
  File:      BasicDirectorySearch.cs

  Summary:   This sample shows how to do a basic search in 
             Active Directory

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
//      csc.exe BasicDirectorySearch.cs 
// To run: 
//      BasicDirectorySearch.exe 

using System;
using System.Security.Permissions;

using System.DirectoryServices;


[assembly: System.Runtime.InteropServices.ComVisible(false)]
[assembly: System.Reflection.AssemblyVersion("1.0.0.0")]
[assembly: SecurityPermission(SecurityAction.RequestMinimum, Execution = true)]
[assembly: DirectoryServicesPermission(SecurityAction.RequestMinimum)]

namespace Microsoft.Samples.DirectoryServices
{
    public class BasicDirectorySearchSample
    {
        // Change the value of next constant to bind to a particular domain
        // Value of null means current domain
        static string domainADsPath = "LDAP://fabrikam.com";
        static string username = "someone@example.com";
        static string password = "Pass@word1";
        // Change the value of next constant to search for particular objects
        // Value of "user" means will search for users in the domain
        static string schemaClassNameToSearch = "user";

        public static void Main(string[] args)
        {
            try
            {
                BasicDirectorySearch();

                Console.WriteLine("\r\nApplication Finished Successfully!!!");
            }
            catch (Exception e)
            {
                Console.WriteLine("\r\nUnexpected exception occured:\r\n\t" +
                                e.GetType() + ":" + e.Message);
            }            
        }

        static void BasicDirectorySearch()
        {
            DirectorySearcher searcher = new DirectorySearcher();

            // Will perform a search of <schemaClassNameToSearch> objects
            searcher.SearchRoot = new DirectoryEntry(domainADsPath, 
                                                        username, password);
            searcher.Filter = "(objectClass=" + schemaClassNameToSearch + ")";
            searcher.SearchScope = SearchScope.Subtree;
            searcher.Sort = new SortOption("name", 
                                                SortDirection.Ascending);
            // If there is a large set to be return ser page size for a paged search
            searcher.PageSize = 512;

            searcher.PropertiesToLoad.AddRange(
                            new string[] { "displayName", "name" });

            SearchResultCollection results = searcher.FindAll();
            DisplayResults(results);

            // Results are explicitly disposed
            results.Dispose();
        }

        public static void DisplayResults(SearchResultCollection results)
        {
            // About to perform search
            Console.Write("Searching...");
            if (results.Count == 0) 
                Console.WriteLine("\r\nThere is no results to display");
            else
            {
                Console.WriteLine("\r\nRESULT COLLECTION INFORMATION");
                Console.WriteLine("Number of results:\t\t" + 
                                        results.Count.ToString());
                Console.WriteLine("Number of properties loaded:\t" + 
                                        results.PropertiesLoaded.Length);
                Console.Write("Properties loaded:\t\t");
                for (int i = 0; i < results.PropertiesLoaded.Length; i++)
                    Console.Write(results.PropertiesLoaded[i] + " ");
                Console.WriteLine("\r\n\r\nRESULTS");

                foreach (SearchResult result in results)
                {
                    Console.WriteLine("Path:\t\t" + result.Path);
                    Console.WriteLine("Display Name:\t" + 
                                        result.Properties["displayName"]);
                    Console.WriteLine("Name:\t\t" + 
                                        result.Properties["name"]);
                }
            }
        }

    } // End class BasicDirectorySearchSample
}
