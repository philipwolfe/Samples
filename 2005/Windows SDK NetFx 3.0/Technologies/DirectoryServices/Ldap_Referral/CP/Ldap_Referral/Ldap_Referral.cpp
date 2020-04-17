/*=====================================================================
  File:      Referral.cpp

  Summary:   Demonstrates sending a request that will generate a referral.

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


// To run: App.exe <ldapServer> <user> <pwd> <domain>
//       Eg: App.exe myDC1.testDom.fabrikam.com  user1  secret@~1 testDom                        

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
    static LdapConnection^ ldapConnection;
    static String^ ldapServer;
    static NetworkCredential^ credential;

public:

    static void Main(array<String^>^ args)
    {
        GetParameters(args);        
        CreateConnection();            
        ReferralTest();
    }

private:
    App(){};

    static void GetParameters(array<String^>^ args)
    {    
        if(args->Length != 5)
        {
            Console::WriteLine("Usage: App.exe <ldapServer> <user> "+
                                                              "<pwd> <domain>");
            Environment::Exit(-1);// return an error code of -1
        }

        // initialize variables
        ldapServer = args[1];
        credential = gcnew NetworkCredential(args[2], args[3], args[4]);
    }



    static void CreateConnection()
    {
        ldapConnection = gcnew LdapConnection(ldapServer);        
        ldapConnection->Credential = credential;
        Console::WriteLine("LdapConnection is created successfully.");
    }



    static void ReferralTest()
    {
        Console::WriteLine("Sending a request that will generate a referral");
        SearchRequest^ searchRequest = gcnew SearchRequest();
        searchRequest->DistinguishedName = 
                                  "OU=Users,DC=non-existing,DC=fabrikam,DC=com";

        // send the request through the connection
        DirectoryResponse^ response =ldapConnection->SendRequest(searchRequest);
        
        Console::WriteLine("ResultCode:{0}", response->ResultCode);

        for(int i=0;i<response->Referral->Length;i++)
        {
            Console::WriteLine("Referral:{0}", response->Referral[i]);
        }

        Console::WriteLine("Referral is received successfully.");
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