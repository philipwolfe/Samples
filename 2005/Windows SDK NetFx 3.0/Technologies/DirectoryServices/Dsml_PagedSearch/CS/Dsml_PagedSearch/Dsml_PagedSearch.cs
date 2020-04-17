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
//                                                            PagedSearch.cs
//
// To run: App.exe <dsmlServer> <user> <pwd> <domain> <targetOU>
//     Eg: App.exe http://myDC1.testDom.fabrikam.com/dsml/adssoap.dsmlx user1  
//                   secret@~1 testDom OU=samples,DC=testDom,DC=fabrikam,DC=com            

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
    static DsmlSoapHttpConnection dsmlConnection;
    static string  dsmlServer;
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
            Console.WriteLine("Usage: App.exe <dsmlServer> <user> <pwd>" +
                                                       " <domain> <targetOU>");
            
            // return error 
            return false;            
        }

        // initialize variables
        dsmlServer = args[0];
        credential = new NetworkCredential(args[1], args[2], args[3]);
        targetOU = args[4];

        // return success
        return true;        
    }



    static void CreateConnection()
    {
        dsmlConnection = new DsmlSoapHttpConnection(new Uri(dsmlServer));
        dsmlConnection.Credential = credential;
        Console.WriteLine("DsmlSoapHttpConnection is created successfully.");
    }


    static void CreateObjectsToSearch()
    {
        Console.WriteLine("Creating objects to search...");
        DsmlRequestDocument batchRequest = new DsmlRequestDocument();
        
        for(int i=1;i<=numberOfPages*pageSize;i++)
        {
            string dn = "OU=object" + i + "," + targetOU;
            batchRequest.Add(new AddRequest(dn, "organizationalUnit"));            
        }
        dsmlConnection.SendRequest(batchRequest);
        Console.WriteLine(numberOfPages*pageSize + 
                                    " Objects are created successfully.");
    }

    
    
    static void DoPagedSearch()
    {
        Console.WriteLine("\r\nDoing a paged search ...");
        
        string ldapSearchFilter = "(&(objectClass=organizationalUnit)"+
                                                               "(ou=object*))";
        
        // return only these attributes
        string[] attributesToReturn = new string[]{
                                                   "description",
                                                   "ou", 
                                                   "objectClass"
                                                  };
        
        PageResultRequestControl pageRequestControl = 
                                        new PageResultRequestControl(pageSize);

        // used to retrieve the cookie to send for the subsequent request
        PageResultResponseControl pageResponseControl;
        SearchResponse searchResponse;
        
        // create a search request: specify baseDn, ldap search filter, 
        // attributes to return and scope of the search
        SearchRequest searchRequest = new SearchRequest(
                                                        targetOU, 
                                                        ldapSearchFilter, 
                                                        SearchScope.Subtree, 
                                                        attributesToReturn
                                                        );

        // attach a page request control to retrieve the results in small chunks
        searchRequest.Controls.Add(pageRequestControl);
        

        // The cookie returned by the page-result response control is 
        // valid on the same LDAP connection that DSML server uses,
        // therefore we want DSML server to hold on to that same connection
        // for the subsequent SendRequest calls. This is achived by initiating
        // a session on the DsmlSoapHttpConnection
        Console.WriteLine("Initiating a session with the DSML server...");
        dsmlConnection.BeginSession();
        Console.WriteLine("SessionId=" + dsmlConnection.SessionId);
        
        int pageCount = 0;
        int count;
        // search in a loop untill there is no more page to retrieve
        while(true)
        {            
            pageCount++;
            
            searchResponse = (SearchResponse)dsmlConnection.SendRequest(searchRequest);
            Console.WriteLine("\r\nPage" + pageCount + ": " + 
                              searchResponse.Entries.Count + 
                              " entries:");

            // print the entries in this page
            count = 0;
            foreach(SearchResultEntry entry in searchResponse.Entries)
            {
                Console.WriteLine(++ count + ":" + entry.DistinguishedName);
            }


            // retrieve the cookie 
            if( searchResponse.Controls.Length != 1 || 
                !(searchResponse.Controls[0] is PageResultResponseControl)
              ) 
            {
                Console.WriteLine("The server did not return " +
                                  "a PageResultResponseControl as expected.");
                return;
            }
            
            pageResponseControl = (PageResultResponseControl)searchResponse.Controls[0];
            
            // if responseControl.Cookie.Length is 0 then there 
            // is no more page to retrieve so break the loop
            if(pageResponseControl.Cookie.Length == 0) break;       

            // set the cookie from the response control to retrieve the next page
            pageRequestControl.Cookie= pageResponseControl.Cookie;            
        }

        Console.WriteLine("\r\nClosing the session with the DSML server.");
        dsmlConnection.EndSession();

        Console.WriteLine("\r\nPaged search is completed successfully.\r\n");
    }




    static void DeleteObjectsToSearch()
    {
        Console.WriteLine("Deleting objects...");
        DsmlRequestDocument batchRequest = new DsmlRequestDocument();
        
        for(int i=1;i<=numberOfPages*pageSize;i++)
        {
            string dn = "OU=object" + i + "," + targetOU;
            batchRequest.Add(new DeleteRequest(dn));
        }
        
        dsmlConnection.SendRequest(batchRequest);
        Console.WriteLine(numberOfPages*pageSize + 
                          " Objects are deleted successfully.");
    }    
    
}// end class App


}
