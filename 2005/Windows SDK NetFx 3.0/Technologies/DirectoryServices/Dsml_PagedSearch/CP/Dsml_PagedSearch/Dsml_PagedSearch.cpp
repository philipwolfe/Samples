/*=====================================================================
  File:      PagedSearch.cpp

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


// To run: App.exe <dsmlServer> <user> <pwd> <domain> <targetOU>
//       Eg: App.exe http://myDC1.testDom.fabrikam.com/dsml/adssoap.dsmlx user1  
//           secret@~1 testDom OU=samples,DC=testDom,DC=fabrikam,DC=com

using namespace System;
using namespace System::Net;
using namespace System::Security::Permissions;
using namespace System::DirectoryServices::Protocols;

[assembly: System::Reflection::AssemblyVersion("1.0.0.0")];

[assembly: SecurityPermission(SecurityAction::RequestMinimum, 
                              Execution = true,
                              ControlAppDomain = true,
                              UnmanagedCode = true,
                              SkipVerification = true)];

[assembly: System::DirectoryServices::DirectoryServicesPermission
                                      (SecurityAction::RequestMinimum)];



[assembly: EnvironmentPermission(SecurityAction::RequestMinimum,
                                 Unrestricted=true)];


namespace Microsoft
{

namespace Samples
{

namespace DirectoryServices
{

public ref class App sealed
{
    // static variables used throughout the sample code
    static DsmlSoapHttpConnection^ dsmlConnection;
    static String^  dsmlServer;
    static NetworkCredential^ credential;
    static String^ targetOU; // dn of an OU. eg: "OU=sample,DC=fabrikam,DC=com"

    // change the below numbers to try for 
    // different page sizes and number of pages
    
    // the max number of entries we want in each SearchResponse
    static int pageSize = 5; 
    static int numberOfPages = 8;

public:
    static void Main(array<String^>^ args)
    {
        GetParameters(args);            
        CreateConnection();
        CreateObjectsToSearch();
        DoPagedSearch();
        DeleteObjectsToSearch();            
    }


private:

    App(){};

    static void GetParameters(array<String^>^ args)
    {    
        if(args->Length != 6)
        {
            Console::WriteLine("Usage: App.exe <dsmlServer> <user> <pwd> "+
                                                        "<domain> <targetOU>");

            Environment::Exit(-1);// return an error code of -1
        }

        // initialize variables
        dsmlServer = args[1];
        credential = gcnew NetworkCredential(args[2], args[3], args[4]);
        targetOU = args[5];
    }



    static void CreateConnection()
    {
        dsmlConnection = gcnew DsmlSoapHttpConnection(gcnew Uri(dsmlServer));
        dsmlConnection->Credential = credential;
        Console::WriteLine("DsmlSoapHttpConnection is created successfully.");
    }


    static void CreateObjectsToSearch()
    {
        Console::WriteLine("Creating objects to search...");
        DsmlRequestDocument^ batchRequest = gcnew DsmlRequestDocument();
        
        for(int i=1;i<=numberOfPages*pageSize;i++)
        {
            String^ dn = String::Concat("OU=object", i, ",", targetOU);
            batchRequest->Add(gcnew AddRequest(dn, "organizationalUnit"));            
        }
        dsmlConnection->SendRequest(batchRequest);
        Console::WriteLine("{0} Objects are created successfully.",
                           numberOfPages*pageSize);
    }

    
    
    static void DoPagedSearch()
    {
        Console::WriteLine("\r\nDoing a paged search ...");
        
        String^ ldapSearchFilter = 
                              "(&(objectClass=organizationalUnit)(ou=object*))";

        // return only these attributes
        array<String^>^ attributesToReturn = {"description", 
                                              "ou" , 
                                              "objectClass"};

        PageResultRequestControl^ pageRequestControl = 
                                       gcnew PageResultRequestControl(pageSize);

        // used to retrieve the cookie to send for the subsequent request
        PageResultResponseControl^ pageResponseControl; 
        SearchResponse^ searchResponse;
        
        // create a search request: specify baseDn, ldap search filter, 
        // attributes to return and scope of the search
        SearchRequest^ searchRequest = gcnew SearchRequest(targetOU, 
                                                           ldapSearchFilter, 
                                                           SearchScope::Subtree,
                                                           attributesToReturn);

        // attach a page request control to retrieve the results in small chunks
        searchRequest->Controls->Add(pageRequestControl);
        

        // The cookie returned by the page-result response control is 
        // valid on the same LDAP connection that DSML server uses,
        // therefore we want DSML server to hold on to that same connection
        // for the subsequent SendRequest calls. This is achived by initiating
        // a session on the DsmlSoapHttpConnection
        Console::WriteLine("Initiating a session with the DSML server...");
        dsmlConnection->BeginSession();
        Console::WriteLine("SessionId={0}", dsmlConnection->SessionId);
        
        int pageCount = 0;
        // search in a loop untill there is no more page to retrieve
        while(true)
        {            
            pageCount++;
            
            searchResponse = (SearchResponse^)dsmlConnection->SendRequest(
                                                                 searchRequest);
            Console::WriteLine("\r\nPage{0}: {1} entries:", 
                               pageCount,searchResponse->Entries->Count);

            // print the entries in this page            
            SearchResultEntry^ entry; 
            for(int i=0;i<searchResponse->Entries->Count;i++)
            {
                entry = searchResponse->Entries[i];
                Console::WriteLine("{0}:{1}", (i+1), entry->DistinguishedName);
            }


            // retrieve the cookie 
            if(searchResponse->Controls->Length != 1 || 
               searchResponse->Controls[0]->GetType() != 
                                        PageResultResponseControl::typeid) 
            {
                Console::WriteLine("The server did not return a "+
                                      "PageResultResponseControl as expected.");
                return;
            }
            
            pageResponseControl = 
                        (PageResultResponseControl^)searchResponse->Controls[0];
            
            // if responseControl.Cookie.Length is 0 then there 
            // is no more page to retrieve so break the loop
            if(pageResponseControl->Cookie->Length == 0) break;       

            // set the cookie from the response control 
            // to retrieve the next page
            pageRequestControl->Cookie= pageResponseControl->Cookie;
        }

        Console::WriteLine("\r\nClosing the session with the DSML server.");
        dsmlConnection->EndSession();

        Console::WriteLine("\r\nPaged search is completed successfully.\r\n");
    }




    static void DeleteObjectsToSearch()
    {
        Console::WriteLine("Deleting objects...");
        DsmlRequestDocument^ batchRequest = gcnew DsmlRequestDocument();
        
        for(int i=1;i<=numberOfPages*pageSize;i++)
        {
            String^ dn = String::Concat("OU=object", i, ",", targetOU);
            batchRequest->Add(gcnew DeleteRequest(dn));
        }
        dsmlConnection->SendRequest(batchRequest);
        Console::WriteLine("{0} Objects are deleted successfully.", 
                            numberOfPages*pageSize);
    }    
    
};// end class App

}}}

using namespace Microsoft::Samples::DirectoryServices;

void main()
{   
    try
    {
		App::Main(Environment::GetCommandLineArgs());
        
        Console::WriteLine("\r\nApplication Finished Successfully!!!");
    }
    catch(Exception^ e)
    {
        Console::WriteLine("\r\nUnexpected exception occured:\r\n\t{0}:{1}", 
                           e->GetType()->Name, e->Message);
    }
}