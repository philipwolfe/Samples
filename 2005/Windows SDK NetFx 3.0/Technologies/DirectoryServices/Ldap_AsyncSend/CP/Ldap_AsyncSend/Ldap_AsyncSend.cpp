/*=====================================================================
  File:      AsyncSend.cpp

  Summary:   Demonstrates using LdapConnection to do directory
             operations asynchronously.
                    

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
//     Eg: App.exe myDC1.testDom.fabrikam.com  user1  secret@~1 testDom 
//                                      OU=samples,DC=testDom,DC=fabrikam,DC=com            


using namespace System;
using namespace System::Threading;
using namespace System::Collections;
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
    static LdapConnection^ ldapConnection;
    static String^  ldapServer;
    static NetworkCredential^ credential;
    static String^ targetOU; // dn of an OU. eg: "OU=sample,DC=fabrikam,DC=com"

    static int numberOfObjects = 10;

public:
    static void Main(array<String^>^ args)
    {
        GetParameters(args);            
        CreateConnection();
        CreateObjectsToSearch();
        DoNotificationSearch();
        DeleteObjectsToSearch();
    }


private:
    App(){};

    static void GetParameters(array<String^>^ args)
    {    
        if(args->Length != 6)
        {
            Console::WriteLine("Usage: App.exe <ldapServer> <user> <pwd> "+
                                                         "<domain> <targetOU>");
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
        array<IAsyncResult^>^ asyncResults = 
                                    gcnew array<IAsyncResult^>(numberOfObjects);
        
        for(int i=1;i<=numberOfObjects;i++)
        {
            String^ dn = String::Concat("OU=object", i, ",", targetOU);
            
            asyncResults[i-1] = ldapConnection->BeginSendRequest
                                (
                                 gcnew AddRequest(dn, "organizationalUnit"),
                                 // no partial results
                                 PartialResultProcessing::NoPartialResultSupport, 
                                 nullptr, // no callback
                                 nullptr // no custom state object
                                );
        }

        for(int i=0;i<asyncResults->Length;i++)
        {
            ldapConnection->EndSendRequest(asyncResults[i]);
            Console::WriteLine("OU=object{0} created successfully.", (i+1));
        }        
    }

    
    
    static void DoNotificationSearch()
    {
        Console::WriteLine("\r\nDoing a notification search asynchronously.");
        IAsyncResult^ asyncResult;

        SearchRequest^ searchRequest = gcnew SearchRequest();
        searchRequest->DistinguishedName = targetOU;
        searchRequest->Scope = SearchScope::OneLevel;

        // attach a notification control
        searchRequest->Controls->Add(gcnew DirectoryNotificationControl());
        

        Console::WriteLine("Initiating the notification search "+
                                                         "with AsyncCallback.");

        asyncResult = ldapConnection->BeginSendRequest
                      (
                        searchRequest,
                        PartialResultProcessing::ReturnPartialResultsAndNotifyCallback, 
                        gcnew AsyncCallback(NotificationSearchCallback), nullptr
                       );
            
        
        for(int notifications=0;notifications<5;notifications++)
        {        
            Console::WriteLine("\r\nSending ModifyRequest so that the "+
                                    "callback is invoked with the new changes");

            ldapConnection->SendRequest
                           (
                             gcnew ModifyRequest
                             (
                                String::Concat("OU=object1,", targetOU),
								DirectoryAttributeOperation::Replace,
                                "description",
                                String::Concat("newDescription", notifications)
                             )
                            );
        
            // make sure the callback is called
            Console::WriteLine("Waiting for callback to be invoked...");

            // wait for AsyncCallback to be invoked
            while(!asyncCallbackFinished) Thread::Sleep(10); 
            
            asyncCallbackFinished = false;
        }
        
        
        Console::WriteLine("\r\nCalling Abort to finish notification search.");
        ldapConnection->Abort(asyncResult);
        
        Console::WriteLine("CompletedSynchronously={0}", 
                           asyncResult->CompletedSynchronously);

        Console::WriteLine("\r\nNotification search is "+
                                                 "completed successfully.\r\n");
    }


    static bool asyncCallbackFinished;
    static void NotificationSearchCallback(IAsyncResult^ asyncRes)
    {
        asyncCallbackFinished = false;
        
        Console::WriteLine("AsyncCallback invoked.");        

        Console::WriteLine("IAsyncResult.IsCompleted:{0}", 
                           asyncRes->IsCompleted);

        Console::WriteLine("Retrieving partial results.");
        PartialResultsCollection^ partialResults = 
                                    ldapConnection->GetPartialResults(asyncRes);

        int count = 0;
        
        IEnumerator^ resultsEnumerator = partialResults->GetEnumerator();
        Object^ obj;
        while(resultsEnumerator->MoveNext())        
        {
            obj = resultsEnumerator->Current;
            count++;
            
            if(obj->GetType() == SearchResultEntry::typeid)
            {
                SearchResultEntry^ entry = (SearchResultEntry^)obj;
                Console::WriteLine("{0}: Description:{1}", 
                                   entry->DistinguishedName, 
                                   entry->Attributes["description"][0]);
            }    
            else if(obj->GetType() == SearchResultReference::typeid)
            {
                SearchResultReference^ reference = (SearchResultReference^)obj; 
                Console::WriteLine("SearchResultReference:");
                for(int k=0;k<reference->Reference->Length;k++)
                {
                    Console::WriteLine(reference->Reference[k]);
                }
            }
        }

        asyncCallbackFinished = true;
    }    



    static void DeleteObjectsToSearch()
    {
        array<IAsyncResult^>^ asyncResults = 
                                    gcnew array<IAsyncResult^>(numberOfObjects);
        
        for(int i=1;i<=numberOfObjects;i++)
        {
            String^ dn = String::Concat("OU=object", i, ",", targetOU);
            
            asyncResults[i-1] = ldapConnection->BeginSendRequest
                                (
                                 gcnew DeleteRequest(dn),
                                 // no partial results
                                 PartialResultProcessing::NoPartialResultSupport,
                                 nullptr, // no callback
                                 nullptr // no custom state object
                                );
        }

        for(int i=0;i<asyncResults->Length;i++)
        {
            ldapConnection->EndSendRequest(asyncResults[i]);
            Console::WriteLine("OU=object{0} deleted successfully.", (i+1));
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