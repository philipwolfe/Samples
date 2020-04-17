/*=====================================================================
  File:      DirSyncSearch.cs

  Summary:   This sample shows how directory synchronization search
             works in System.DirectoryServices

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
//      csc.exe DirectorySynchronization.cs 
// To run: 
//      DirectorySynchronization.exe 

using System;
using System.Security.Permissions;

using System.DirectoryServices;


[assembly: System.Runtime.InteropServices.ComVisible(false)]
[assembly: System.Reflection.AssemblyVersion("1.0.0.0")]
[assembly: SecurityPermission(SecurityAction.RequestMinimum, Execution = true)]
[assembly: DirectoryServicesPermission(SecurityAction.RequestMinimum)]

namespace Microsoft.Samples.DirectoryServices
{
    public class DirectorySynchronizationSearchSample
    {
        // Change the value of next constant to bind to a particular domain
        // Value of null means current domain
        static string domainADsPath = null;

        public static void Main(string[] args)
        {
            try
            {
                DirectorySynchronizationSearch();

                Console.WriteLine("\r\nApplication Finished Successfully!!!");
            }
            catch (Exception e)
            {
                Console.WriteLine("\r\nUnexpected exception occured:\r\n\t" +
                                e.GetType() + ":" + e.Message);
            }            
        }

        static void DirectorySynchronizationSearch()
        {
            // First add a temporal user to help the sample
            string lDAPPathUser = addTempUser(); 
            
            DirectorySearcher searcher = new DirectorySearcher();

            
            searcher.SearchRoot = new DirectoryEntry(domainADsPath);
            searcher.Filter = "(objectClass=user)";
            // For a directory synchronization search search scope must be subtree
            searcher.SearchScope = SearchScope.Subtree;
            searcher.Sort = new SortOption(
                                "name", SortDirection.Ascending);

            searcher.PropertiesToLoad.AddRange(
                            new string[] { "displayName", "name" });

            searcher.DirectorySynchronization = new DirectorySynchronization();

            // Do the first search - results should be all
            SearchResultCollection results = searcher.FindAll();
            Console.WriteLine("DO THE FIRST SEARCH");
            displayResults(results);
            // Results are disposed explicitly
            results.Dispose();

            // Do the same search - results should be none
            SearchResultCollection newResults = searcher.FindAll();
            Console.WriteLine("\r\n\r\nDO THE SAME SEARCH");
            displayResults(newResults);
            // Results are disposed explicitly
            newResults.Dispose();

            // Modify displayName property value
            modifyUser(lDAPPathUser, "_MODIFIED");

            // Do the same search - results should be modified user
            newResults = searcher.FindAll();
            Console.WriteLine("\r\n\r\nDO THE SAME SEARCH");
            displayResults(newResults);
            // Results are disposed explicitly
            newResults.Dispose();

            // Delete temporary user
            deleteTempUser(lDAPPathUser);
        }

        private static string addTempUser()
        {
            DirectoryEntry entry = new DirectoryEntry(domainADsPath);

            DirectoryEntry newEntry = 
                        entry.Children.Add("CN=TemporaryUser", "user");

            newEntry.Properties["displayName"].Value = "TemporaryUser";
            newEntry.CommitChanges();

            return newEntry.Path;
        }

        private static void deleteTempUser(string lDAPPathUser)
        {
            DirectoryEntry entry = new DirectoryEntry(domainADsPath);

            entry.Children.Remove(new DirectoryEntry(lDAPPathUser));
        }

        private static void modifyUser(string lDAPPAth, string stringToAdd)
        {
            DirectoryEntry entry = new DirectoryEntry(lDAPPAth);

            entry.Properties["displayName"].Value += stringToAdd;
            entry.CommitChanges();
        }

        private static void displayResults(SearchResultCollection results)
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
    } // End class DirectorySynchronizationSearchSample
}
