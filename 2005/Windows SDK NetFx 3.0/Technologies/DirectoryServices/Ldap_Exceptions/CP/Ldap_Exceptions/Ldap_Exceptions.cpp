/*=====================================================================
  File:      Exceptions.cpp

  Summary:   Demonstrates exceptions like LdapException, OperationException etc.

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
    static String^  ldapServer;
    static NetworkCredential^ credential;

public:
    static void Main(array<String^>^ args)
    {
            GetParameters(args);            
            CreateConnection();
            HandleLdapException();
            HandleOperationException();
            HandlePlatformNotSupportedException();
            HandleBerConversionException();
            HandleArgumentNullException();
            HandleTlsOperationException();
            HandleInvalidOperationException();
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

    static void HandleLdapException()
    {
        try
        {
            Console::WriteLine("\r\nTrying to connect to an "+
                                                      "unknown Ldap server...");

            LdapConnection^ conn = gcnew LdapConnection("badServer");
            conn->Bind();
        }
        catch(LdapException^ e)
        {
            Console::WriteLine("{0}: ErrorCode:{1}, Message:{2}",
                               e->GetType()->Name,
                               e->ErrorCode,
                               e->Message);
        }


        try
        {
            Console::WriteLine("\r\nTrying to authenticate "+
                                                   "with bogus credentials...");

            ldapConnection->Credential = gcnew NetworkCredential("bogusUser", 
                                                                 "bogusPwd",
                                                                 "bogusDom");
            ldapConnection->Bind();            
        }
        catch(LdapException^ e)
        {
            Console::WriteLine("{0}: ErrorCode:{1}, Message:{2}",
                               e->GetType()->Name,
                               e->ErrorCode,
                               e->Message);

            // revert back to original credentials supplied
            ldapConnection->Credential  = credential;
        }        
    }


    static void HandleOperationException()
    {
        try
        {
            Console::WriteLine("\r\nSending a delete "+
                                              "request with an invalid dn... ");

            ldapConnection->SendRequest(gcnew DeleteRequest("#thisIsAnInValidDN#"));  
        }
        catch(DirectoryOperationException^ e)
        {
            DeleteResponse^ response = (DeleteResponse^)e->Response;
            Console::WriteLine("{0}: Message:{1}",
                                e->GetType()->Name,
                                e->Message);

            Console::WriteLine("Response: ResultCode:{0} : ErrorMessage:{1}",
                               response->ResultCode,
                               response->ErrorMessage);
        }
    }


    static void HandlePlatformNotSupportedException()
    {
        try
        {
            LdapConnection^ conn = gcnew LdapConnection("someServer");
        }
        catch(PlatformNotSupportedException^ e)
        {
            Console::WriteLine("{0}: Message:{1}",
                               e->GetType()->Name,
                               e->Message);

            // The application should handle this exception and 
            // fail gracefully on an unsupported platform
            Console::WriteLine("The application is not supported on "+
                                         "this platform and will shutdown...");
        }
    }
    

    static void HandleBerConversionException()
    {
        try
        {
            Console::WriteLine("\r\nTrying to decode a binary value "+
                                          "with an incorrect decode string...");

            BerConverter::Decode("{iiiiiiiii}",
                                 gcnew array<unsigned char>
                                  {0x01,0x02,0x03,0x04,0x05,
                                   0x05,0x05,0x05,0x05,0x05,0x05});
        }
        catch(BerConversionException^ e)
        {
            Console::WriteLine("{0}: Message:{1}", 
                                e->GetType()->Name,
                                e->Message);
        }
    }


    static void HandleArgumentNullException()
    {
        try
        {
            Console::WriteLine("\r\nTrying to create DirectoryAttribute "+
                                                        "with null values...");

            DirectoryAttribute^ attribute = gcnew DirectoryAttribute("attrName", 
                                                gcnew array<String^>{"val1", 
                                                                     nullptr, 
                                                                     "val2"});
        }
        catch(ArgumentNullException^ e)
        {
            Console::WriteLine("{0}: Message:{1}", 
                               e->GetType()->Name,
                               e->Message);
        }       
    }

    
    static void HandleTlsOperationException()
    {    
        try
        {
            Console::WriteLine("\r\nCalling StopTransportLayerSecurity()... ");
            ldapConnection->SessionOptions->StopTransportLayerSecurity();
        }
        catch(TlsOperationException^ e)
        {
            Console::WriteLine("{0}: Message:{1}", 
                               e->GetType()->Name,
                               e->Message);
        }
    }


    static void HandleInvalidOperationException()
    {
        try
        {
            Console::WriteLine("\r\nTrying anonymous authentication "+
                                                 "with a non-null credential ");

            ldapConnection->AuthType = AuthType::Anonymous;
            ldapConnection->Credential = gcnew NetworkCredential("userName",
                                                                 "pwd",
                                                                 "domain");
            ldapConnection->Bind();
            
        }
        catch(InvalidOperationException^ e)
        {
            Console::WriteLine("{0}: Message:{1}",
                               e->GetType()->Name,
                               e->Message);
            // revert back
            ldapConnection->AuthType = AuthType::Negotiate;
            ldapConnection->Credential = credential;
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