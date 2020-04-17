/*=====================================================================
  File:      ReadRootDSE.cpp

  Summary:   Reads the RootDSE object and prints its attributes

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

// To run: App.exe <dsmlServer>
//       Eg: App.exe http://myDC1.testDom.fabrikam.com/dsml/adssoap.dsmlx

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
    static DsmlSoapHttpConnection^ dsmlConnection;

     // this DSML server's VDIR should be configured to 
     // accept anonymous connections for this sample to work
    static String^  dsmlServer;

public:
    static void Main(array<String^>^ args)
    {
        GetParameters(args);            
        CreateConnection();            
        ReadRootDSE();            
    }


private:
    App(){};

    static void GetParameters(array<String^>^ args)
    {    
        if(args->Length != 2)
        {
            Console::WriteLine("Usage: App.exe <dsmlServer>");
            Environment::Exit(-1);// return an error code of -1
        }

        // initialize variables
        dsmlServer = args[1];
    }



    static void CreateConnection()
    {
        dsmlConnection = gcnew DsmlSoapHttpConnection(gcnew Uri(dsmlServer));
        Console::WriteLine("DsmlSoapHttpConnection is created successfully.");
    }



    static void ReadRootDSE()
    {
        String^ baseDN = nullptr; // specify base as null for RootDSE search
        String^ ldapSearchFilter = "(objectClass=*)";

        // return ALL attributes that have some value
        array<String^>^ attributesToReturn = nullptr;

        // create a search request: specify baseDn, ldap search filter, 
        // attributes to return and scope of the search
        // SearchScope should be Base for a RootDSE search
        SearchRequest^ searchRequest = gcnew SearchRequest(baseDN, 
                                                           ldapSearchFilter, 
                                                           SearchScope::Base, 
                                                           attributesToReturn);


        // send the request through the connection
        SearchResponse^ searchResponse = 
                    (SearchResponse^)dsmlConnection->SendRequest(searchRequest);

        // print the returned entries & their attributes
        Console::WriteLine("\r\nSearch matched {0} entries:", 
                           searchResponse->Entries->Count);
        SearchResultEntry^ entry;

        for(int i=0;i<searchResponse->Entries->Count;i++)
        {  
            entry = searchResponse->Entries[i];
            // retrieve a specific attribute
            DirectoryAttribute^ attribute = 
                                       entry->Attributes["schemaNamingContext"];

            // get the first value since "schemaNamingContext" 
            // is a single valued attribute
            Console::WriteLine("{0}={1}" ,attribute->Name, attribute[0]);

            // retrieve all attributes            
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
        
        Console::WriteLine("RootDSE Search is completed successfully.\r\n");
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