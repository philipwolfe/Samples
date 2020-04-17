/*=====================================================================
  File:      SendRequest.cpp

  Summary:   Demonstrates the use of the LdapConnection class to do 
                    various directory operations.

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
//     Eg: App.exe myDC1.testDom.fabrikam.com user1  secret@~1 
//                          testDom OU=samples,DC=testDom,DC=fabrikam,DC=com            

using namespace System;
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
    static String^ ldapServer;
    static NetworkCredential^ credential;
    static String^ targetOU; // dn of an OU. eg: "OU=sample,DC=fabrikam,DC=com"

    // object DNs that are created in the sample
    static String ^ou1, ^ou2, ^ou3;

public:
    static void Main(array<String^>^ args)
    {
        GetParameters(args);            
        CreateConnection();            
        Add();
        Modify();
        Rename();
        Move();
        Compare();
        Search();
        DeleteLeafObject();
        DeleteTree();
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



    static void Add()
    {
        // create new OUs under the specified OU
        ou1 = String::Concat("OU=sampleOU1,", targetOU);
        ou2 = String::Concat("OU=sampleOU2,", targetOU);
        ou3 = String::Concat("OU=sampleOU3,", targetOU);
        String^ objectClass = "organizationalUnit";
        
        
        // create a request to add the new object
        AddRequest^ addRequest = gcnew AddRequest(ou1, objectClass);

        // send the request through the connection
        ldapConnection->SendRequest(addRequest);

        // create a request to add the new object
        addRequest = gcnew AddRequest(ou2, objectClass);

        // send the request through the connection
        ldapConnection->SendRequest(addRequest);

        // create a request to add the new object
        addRequest = gcnew AddRequest(ou3, objectClass);

        // send the request through the connection
        ldapConnection->SendRequest(addRequest);
        
        Console::WriteLine("Objects are created successfully.");
    }

    



    static void Modify()
    {
        String^ attributeName = "description";
        array<String^>^ newValue = gcnew array<String^>{"This is a sample OU"};

        // create a request to modify the object
        ModifyRequest^  modifyRequest = gcnew ModifyRequest(
                                           ou1, 
                                           DirectoryAttributeOperation::Replace, 
                                           attributeName, 
                                           newValue);

        // send the request through the connection
        ldapConnection->SendRequest(modifyRequest);

        Console::WriteLine("Object is modified successfully." );
    }



    
    static void Rename()
    {
        // keep the parent container same to do just rename without moving
        String^ newParent = targetOU; 
        String^ newName = "OU=sampleOUNew";

        // create a request to rename the object
        ModifyDNRequest^ modDnRequest = gcnew ModifyDNRequest (ou1,
                                                               newParent,
                                                               newName);

        // send the request through the connection
        ldapConnection->SendRequest(modDnRequest);

        // this is the gcnew path of the object after rename operation
        ou1 = String::Concat("OU=sampleOUNew,", targetOU);
        Console::WriteLine("Object has been renamed successfully." );
    }


    
    static void Move()
    {
        // move sampleOU3 under sampleOU2
        String^ newParent = ou2;

        // keep the name same to just move without renaming
        String^ newName = "OU=sampleOU3"; 

        // create a request to move the object
        ModifyDNRequest^ modDnRequest = gcnew ModifyDNRequest (ou3,
                                                               newParent, 
                                                               newName);

        // send the request through the connection
        ldapConnection->SendRequest(modDnRequest);

        Console::WriteLine("Object is moved successfully." );                
    }


    
    static void Compare()
    {
        String^ attributeName = "description";
        String^ valueToCompareAgainst = "This is a sample OU";

        // create a request to do compare on the object
        CompareRequest^ compareRequest = gcnew CompareRequest(
                                                         ou1, 
                                                         attributeName,
                                                         valueToCompareAgainst);

        // send the request through the connection
        CompareResponse^ compareResponse = 
                  (CompareResponse^)ldapConnection->SendRequest(compareRequest);
        
        Console::WriteLine("The result of the comparison is:{0}", 
                           compareResponse->ResultCode);
    }


    
    static void Search()
    {
        String^ ldapSearchFilter = 
                              "(&(objectClass=organizationalUnit)(ou=sample*))";

        // return ALL attributes that have some value
        array<String^>^ attributesToReturn = nullptr;

        // create a search request: specify baseDn, ldap search filter,
        // attributes to return and scope of the search
        SearchRequest^ searchRequest = gcnew SearchRequest(targetOU, 
                                                           ldapSearchFilter, 
                                                           SearchScope::Subtree, 
                                                           attributesToReturn);


        // send the request through the connection
        SearchResponse^ searchResponse = 
                    (SearchResponse^)ldapConnection->SendRequest(searchRequest);

        // print the returned entries & their attributes
        Console::WriteLine("\r\nSearch matched {0} entries:",
                           searchResponse->Entries->Count);
        
        SearchResultEntry^ entry;
        for(int i=0;i<searchResponse->Entries->Count;i++)
        {  
            entry = searchResponse->Entries[i];
            Console::WriteLine("\r\n{0}- {1}", (i+1), entry->DistinguishedName);
            
            // retrieve a specific attribute
            DirectoryAttribute^ attribute = entry->Attributes["ou"];

            // get the first value since "ou" is a single valued attribute
            Console::WriteLine("{0}={1}", attribute->Name, attribute[0]); 

            IEnumerator^ attrEnumerator =
                                     entry->Attributes->Values->GetEnumerator();

            while(attrEnumerator->MoveNext())
            {
                attribute = (DirectoryAttribute^)(attrEnumerator->Current);
                Console::Write("{0}=", attribute->Name);

                // retrieve all values for the attribute
                // the type of the value can be one of String,byte[] or Uri
                for(int k=0;k<attribute->Count;k++)
                {
                    Console::Write("{0}  ", attribute[k]);
                }
                Console::WriteLine();
            }
        }
        
        Console::WriteLine("Search is completed successfully.\r\n");
    }


    
    
    static void DeleteLeafObject()
    {
        // create a request to delete the object (ou1 is a leaf object)
        DeleteRequest^ deleteRequest = gcnew DeleteRequest(ou1);

        // send the request through the connection
        ldapConnection->SendRequest(deleteRequest);

        Console::WriteLine("Leaf object is deleted successfully.");
    }


    
    static void DeleteTree()
    {
        // create a request to delete the object 
        // (ou2 is not a leaf object since it has child objects)
        DeleteRequest^ deleteRequest = gcnew DeleteRequest(ou2);
        
        // add a tree-delete control to the request
        deleteRequest->Controls->Add(gcnew TreeDeleteControl());

        // send the request through the connection
        ldapConnection->SendRequest(deleteRequest);

        Console::WriteLine("Object tree is deleted successfully.");
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