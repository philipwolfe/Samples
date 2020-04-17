/*=====================================================================
  File:      Exceptions.cpp

  Summary:   Demonstrates DSML exceptions.

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

// To run: App.exe <dsmlServer> <user> <pwd> <domain>
//       Eg: App.exe http://myDC1.testDom.fabrikam.com/dsml/adssoap.dsmlx  
//                                                  user1  secret@~1 testDom

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

private:
    App(){};

public:
    static void Main(array<String^>^ args)
    {
        GetParameters(args);            
        CreateConnection();
        HandleErrorResponseException();
        HandleWebException();            
    }



    static void GetParameters(array<String^>^ args)
    {    
        if(args->Length != 5)
        {
			Console::WriteLine("Usage: App.exe <dsmlServer> <user> <pwd> "+
			                                                    "<domain>");
			Environment::Exit(-1);// return an error code of -1
        }

        // initialize variables
        dsmlServer = args[1];
        credential = gcnew NetworkCredential(args[2], args[3], args[4]);
    }



    static void CreateConnection()
    {
        dsmlConnection = gcnew DsmlSoapHttpConnection(gcnew Uri(dsmlServer));        
        dsmlConnection->Credential = credential;
		Console::WriteLine("DsmlSoapHttpConnection is created successfully.");
    }

    static void HandleErrorResponseException()
    {
        try
        {
			Console::WriteLine("\r\nSending a compare request with an "+
			                                        "invalid attribute name..");

            // the request will generate an ErrorResponseException
            // because the attribute name is not valid according 
            // to the dsmlv2 schema (eg.: $ is not allowed in attribute names)
            dsmlConnection->SendRequest(
                                gcnew CompareRequest(
                                                "CN=myUser,DC=fabrikam,DC=com",
                                                "$description", 
                                                "attrVal"));
        }
        catch(ErrorResponseException^ e)
        {
            DsmlErrorResponse^ errResponse = e->Response;
			Console::WriteLine("{0}: Message:{1}", 
			                   e->GetType()->Name, 
			                   e->Message);

			Console::WriteLine("{0}:\r\nType:{1}\r\nMessage:{2}",
			                    errResponse->GetType()->Name, 
			                    errResponse->Type, 
			                    errResponse->Message);
        }
    }

    static void HandleWebException()
    {
        try
        {
			Console::WriteLine("\r\nTrying to authenticate with "+
			                                            "bogus credentials...");
            dsmlConnection->Credential = gcnew NetworkCredential("bogusUser", 
                                                                 "bogusPwd",
                                                                 "bogusDom");

            // send an empty batch request which is a valid DSML request
            dsmlConnection->SendRequest(gcnew DsmlRequestDocument());            
        }
        catch(WebException^ e)
        {
			Console::WriteLine("{0}: Message:{1}", 
			                   e->GetType()->Name, 
			                   e->Message);

            // revert back to original credentials supplied
            dsmlConnection->Credential  = credential;
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
                            e->GetType()->Name, e->Message);
    }
}