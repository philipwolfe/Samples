/*=====================================================================
  File:      PagedSearch.cs

  Summary:   Demonstrates doing a paged search using Ldap controls.
                    

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

// To compile: csc.exe /out:App.exe /r:System.DirectoryServices.Protocols.dll
//                                                              PagedSearch.cs
//
// To run: App.exe <ldapServer> <user> <pwd> <domain> <targetOU>
//     Eg: App.exe myDC1.testDom.fabrikam.com  user1  secret@~1 testDom 
//                                  OU=samples,DC=testDom,DC=fabrikam,DC=com            

using System;
using System.Net;
using System.Security.Permissions;
using SDS = System.DirectoryServices;

using System.DirectoryServices.Protocols;

[assembly: System.Reflection.AssemblyVersion("1.0.0.0")]
[assembly: SecurityPermission(SecurityAction.RequestMinimum, Execution = true)]
[assembly: SDS.DirectoryServicesPermission(SecurityAction.RequestMinimum)]

namespace Microsoft.Samples.DirectoryServices
{

public class App
{
    // static variables used throughout the sample code
    static LdapConnection ldapConnection;
    static string  ldapServer;
    static NetworkCredential credential;
    static string targetOU; // dn of an OU. eg: "OU=sample,DC=fabrikam,DC=com"

    // change the below numbers to try for different page sizes and number of pages
    static int pageSize = 5; // the max number of entries we want in each SearchResponse
    static int numberOfPages = 8;

    public static void Main(string[] args)
    {
        try
        {
            if(!GetParameters(args))
            {
                return;
            }

            CreateConnection();
            CreateObjectsToSearch();
            DoPagedSearch();
            DeleteObjectsToSearch();
            
            Console.WriteLine("\r\nApplication Finished Successfully!!!");
        }
        catch(Exception e)
        {
            Console.WriteLine("\r\nUnexpected exception occured:\r\n\t" + 
                              e.GetType().Name + ":" + e.Message);
        }        
    }



    static bool GetParameters(string[] args)
    {    
        if(args.Length != 5)
        {
            Console.WriteLine("Usage: App.exe <ldapServer> <user> <pwd> "+
                                             "<domain> <targetOU>");

            // return error 
            return false;
        }

        // initialize variables
        ldapServer = args[0];
        credential = new NetworkCredential(args[1], args[2], args[3]);
        targetOU = args[4];

        // return success
        return true;
    }



    static void CreateConnection()
    {
        ldapConnection = new LdapConnection(ldapServer);        
        ldapConnection.Credential = credential;
        Console.WriteLine("LdapConnection is created successfully.");
    }


    static void CreateObjectsToSearch()
    {
        for(int i=1;i<=numberOfPages*pageSize;i++)
        {
            string dn = "OU=object" + i + "," + targetOU;
            ldapConnection.SendRequest(new AddRequest(dn, "organizationalUnit"));
            Console.WriteLine("OU=object" + i + " created successfully.");
        }
    }

    
    
    static void DoPagedSearch()
    {
        Console.WriteLine("\r\nDoing a paged search ...");
        
        string ldapSearchFilter = "(&(objectClass=organizationalUnit)(ou=object*))";

        // return only these attributes
        string[] attributesToReturn = new string[]{"description","ou","objectClass"};
        
        PageResultRequestControl pageRequestControl = 
                                        new PageResultRequestControl(pageSize);

        // used to retrieve the cookie to send for the subsequent request
        PageResultResponseControl pageResponseControl; 

        SearchResponse searchResponse;
        
        // create a search request: specify baseDn, 
        // ldap search filter, attributes to return and scope of the search
        SearchRequest searchRequest = new SearchRequest
                                                (targetOU, 
                                                 ldapSearchFilter,
                                                 SearchScope.Subtree,
                                                 attributesToReturn);

        // attach a page request control to retrieve the results in small chunks
        searchRequest.Controls.Add(pageRequestControl);
        

        int pageCount = 0;
        int count;

        // search in a loop untill there is no more page to retrieve
        while(true)
        {            
            pageCount++;
            
            searchResponse = (SearchResponse)ldapConnection.SendRequest(searchRequest);

            Console.WriteLine("\r\nPage" + pageCount + ": " + 
                              searchResponse.Entries.Count + " entries:");

            // print the entries in this page
            count = 0;
            foreach(SearchResultEntry entry in searchResponse.Entries)
            {
                Console.WriteLine(++ count + ":" + entry.DistinguishedName);
            }


            // retrieve the cookie 
            if(searchResponse.Controls.Length != 1 || 
               !(searchResponse.Controls[0] is PageResultResponseControl)) 
            {
                Console.WriteLine("The server did not return a "+
                                  "PageResultResponseControl as expected.");
                return;
            }
            
            pageResponseControl = (PageResultResponseControl)searchResponse.Controls[0];
            
            // if responseControl.Cookie.Length is 0 then there 
            // is no more page to retrieve so break the loop
            if(pageResponseControl.Cookie.Length == 0) break;       

            // set the cookie from the response control to retrieve the next page
            pageRequestControl.Cookie= pageResponseControl.Cookie;            
        }

        Console.WriteLine("\r\nPaged search is completed successfully.\r\n");
    }




    static void DeleteObjectsToSearch()
    {
        for(int i=1;i<=numberOfPages*pageSize;i++)
        {
            string dn = "OU=object" + i + "," + targetOU;
            ldapConnection.SendRequest(new DeleteRequest(dn));
            Console.WriteLine("OU=object" + i + " deleted successfully.");
        }
    }    
    
}// end class App

}
