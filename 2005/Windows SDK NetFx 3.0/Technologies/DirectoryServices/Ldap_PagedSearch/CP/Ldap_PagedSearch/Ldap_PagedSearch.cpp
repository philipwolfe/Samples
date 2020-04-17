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


// To run: App.exe <ldapServer> <user> <pwd> <domain> <targetOU>
//       Eg: App.exe myDC1.testDom.fabrikam.com  user1  secret@~1 
//                              testDom OU=samples,DC=testDom,DC=fabrikam,DC=com            

using namespace System;
using namespace System::Net;
using namespace System::DirectoryServices::Protocols;
using namespace System::Security::Permissions;


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
    static LdapConnection^ ldapConnection;
    static String^ ldapServer;
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
            Console::WriteLine("Usage: App.exe <ldapServer> <user> "+
                                                  "<pwd> <domain> <targetOU>");
            Environment::Exit(-1);// return an error code of -1
        }

        // initialize variables
        ldapServer = args[1];
        credential = gcnew NetworkCredential(args[2], args[3], args[4]);
        targetOU = args[5];
    }



    static void CreateConnection()
    {
        ldapConnection = gcnew LdapConnection(ldapServer);        
        ldapConnection->Credential = credential;
        Console::WriteLine("LdapConnection is created successfully.");
    }


    static void CreateObjectsToSearch()
    {
        for(int i=1;i<=numberOfPages*pageSize;i++)
        {
            String^ dn = String::Concat("OU=object", i, ",", targetOU);
            ldapConnection->SendRequest(gcnew AddRequest(dn, 
                                                         "organizationalUnit"));

            Console::WriteLine("OU=object{0} created successfully.", i);
        }
    }

    
    
    static void DoPagedSearch()
    {
        Console::WriteLine("\r\nDoing a paged search ...");
        
        String^ ldapSearchFilter = 
                              "(&(objectClass=organizationalUnit)(ou=object*))";

        // return only these attributes
        array<String^>^ attributesToReturn = gcnew array<String^>{"description",
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
        

        int pageCount = 0;
        // search in a loop untill there is no more page to retrieve
        while(true)
        {            
            pageCount++;
            
            searchResponse = 
                    (SearchResponse^)ldapConnection->SendRequest(searchRequest);

            Console::WriteLine("\r\nPage{0}: {1} entries:", 
                               pageCount,
                               searchResponse->Entries->Count);

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

            // set the cookie from the response control to retrieve the next page
            pageRequestControl->Cookie= pageResponseControl->Cookie;
        }

        Console::WriteLine("\r\nPaged search is completed successfully.\r\n");
    }




    static void DeleteObjectsToSearch()
    {
        for(int i=1;i<=numberOfPages*pageSize;i++)
        {
            String^ dn = String::Concat("OU=object", i, ",", targetOU);
            ldapConnection->SendRequest(gcnew DeleteRequest(dn));
            Console::WriteLine("OU=object{0} deleted successfully.", i);
        }
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
                           e->GetType()->Name,
                           e->Message);
    }
}