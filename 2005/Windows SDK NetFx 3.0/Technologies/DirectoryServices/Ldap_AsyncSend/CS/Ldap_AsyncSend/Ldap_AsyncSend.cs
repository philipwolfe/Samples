/*=====================================================================
  File:      AsyncSend.cs

  Summary:   Demonstrates using LdapConnection to do 
             directory operations asynchronously.
                    

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
//                                                    AsyncSend.cs
//
// To run: App.exe <ldapServer> <user> <pwd> <domain> <targetOU>
//     Eg: App.exe myDC1.testDom.fabrikam.com  user1  secret@~1 
//                 testDom OU=samples,DC=testDom,DC=fabrikam,DC=com            

using System;
using System.Threading;
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

    static int numberOfObjects = 10;

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
            DoNotificationSearch();
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
            Console.WriteLine("Usage: App.exe <ldapServer> <user> "+
                                             "<pwd> <domain> <targetOU>");

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
        IAsyncResult[] asyncResults = new IAsyncResult[numberOfObjects];
        
        for(int i=1;i<=numberOfObjects;i++)
        {
            string dn = "OU=object" + i + "," + targetOU;
            
            asyncResults[i-1] = ldapConnection.BeginSendRequest
                                (
                                  new AddRequest(dn, "organizationalUnit"),
                                  PartialResultProcessing.NoPartialResultSupport,
                                  null, // no callback
                                  null // no custom state object
                                );
        }

        for(int i=0;i<asyncResults.Length;i++)
        {
            ldapConnection.EndSendRequest(asyncResults[i]);
            Console.WriteLine("OU=object" + (i+1) + " created successfully.");
        }        
    }

    
    
    static void DoNotificationSearch()
    {
        Console.WriteLine("\r\nDoing a notification search asynchronously.");
        IAsyncResult asyncResult;

        SearchRequest searchRequest = new SearchRequest();
        searchRequest.DistinguishedName = targetOU;
        searchRequest.Scope = SearchScope.OneLevel;

        // attach a notification control
        searchRequest.Controls.Add(new DirectoryNotificationControl());
        

        Console.WriteLine("Initiating the notification search "+
                                                        "with AsyncCallback.");
        
        asyncResult = ldapConnection.BeginSendRequest
                      (
                        searchRequest, 
                        PartialResultProcessing.ReturnPartialResultsAndNotifyCallback, 
                        new AsyncCallback(NotificationSearchCallback),
                        null
                      );                
            
        
        for(int notifications=0;notifications<5;notifications++)
        {        
            Console.WriteLine("\r\nSending ModifyRequest so that "+
                              "the callback is invoked with the new changes");

            ldapConnection.SendRequest(
                                    new ModifyRequest(
                                            "OU=object1," + targetOU,
                                            DirectoryAttributeOperation.Replace,
                                            "description",
                                            "newDescription" + notifications
                                        ));
        
            // make sure the callback is called
            Console.WriteLine("Waiting for callback to be invoked...");

            // wait for AsyncCallback to be invoked
            while(!asyncCallbackFinished)
            {
                    Thread.Sleep(10); 
            }            

            asyncCallbackFinished = false;
        }
        
        
        Console.WriteLine("\r\nCalling Abort to finish notification search.");
        ldapConnection.Abort(asyncResult);
        
        Console.WriteLine("CompletedSynchronously=" +
                                asyncResult.CompletedSynchronously);

        Console.WriteLine("\r\nNotification search is completed successfully.\r\n");
    }


    static bool asyncCallbackFinished;
    static void NotificationSearchCallback(IAsyncResult asyncRes)
    {
        asyncCallbackFinished = false;
        
        Console.WriteLine("AsyncCallback invoked.");        

        Console.WriteLine("IAsyncResult.IsCompleted:" + asyncRes.IsCompleted);

        Console.WriteLine("Retrieving partial results.");
        PartialResultsCollection partialResults = 
                                    ldapConnection.GetPartialResults(asyncRes);

        int count = 0;
        foreach(object obj in partialResults)
        {
            count ++;
            if(obj is SearchResultEntry)
            {
                SearchResultEntry entry = (SearchResultEntry)obj;
                Console.WriteLine(entry.DistinguishedName + 
                          ": Description:" +entry.Attributes["description"][0]);
            }    
            else if(obj is SearchResultReference)
            {
                SearchResultReference reference = (SearchResultReference)obj; 
                Console.WriteLine("SearchResultReference:");
                foreach(Uri uri in reference.Reference)
                {
                    Console.WriteLine(uri);
                }
            }
        }
        asyncCallbackFinished = true;
    }    



    static void DeleteObjectsToSearch()
    {
        IAsyncResult[] asyncResults = new IAsyncResult[numberOfObjects];
        
        for(int i=1;i<=numberOfObjects;i++)
        {
            string dn = "OU=object" + i + "," + targetOU;
            
            asyncResults[i-1] = ldapConnection.BeginSendRequest
                                (
                                 new DeleteRequest(dn),
                                 PartialResultProcessing.NoPartialResultSupport,
                                 null, // no callback
                                 null // no custom state object
                                );
        }

        for(int i=0;i<asyncResults.Length;i++)
        {
            ldapConnection.EndSendRequest(asyncResults[i]);
            Console.WriteLine("OU=object" + (i+1) + " deleted successfully.");
        }
    }    
    
}// end class App

}
