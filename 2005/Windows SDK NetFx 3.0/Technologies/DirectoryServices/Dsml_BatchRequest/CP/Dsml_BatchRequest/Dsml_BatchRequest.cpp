/*=====================================================================
  File:      BatchRequest.cpp

  Summary:   Demonstrates the use of the DsmlSoapHttpConnection & 
             DsmlRequestDocument class to do various directory 
             operations in batch.

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
//     Eg: App.exe http://myDC1.testDom.fabrikam.com/dsml/adssoap.dsmlx  user1  
//                  secret@~1 testDom OU=samples,DC=testDom,DC=fabrikam,DC=com            

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

    // object DNs that are created in the sample
    static String ^ou1, ^ou2, ^ou3;

private:
    App(){};

public:
    static void Main(array<String^>^ args)
    {
		GetParameters(args);
        CreateConnection();            
        SendBatchRequest();
    }



    static void GetParameters(array<String^>^ args)
    {    
        if(args->Length != 6)
        {
			Console::WriteLine("Usage: App.exe <dsmlServer> <user> <pwd> " +
			                                            "<domain> <targetOU>");
            Environment::Exit(-1);
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



    static void SendBatchRequest()
    {          
        DsmlRequestDocument^ batchRequest = gcnew DsmlRequestDocument();              
        AddRequest^ addRequest;
        ModifyRequest^  modifyRequest;
        CompareRequest^ compareRequest;
        DeleteRequest^ deleteRequest;
        
        // create new OUs under the specified OU
		ou1 = String::Concat("OU=sampleOU1,", targetOU);
        ou2 = String::Concat("OU=sampleOU2,", targetOU);
        ou3 = String::Concat("OU=sampleOU3,", targetOU);
        String^ objectClass = "organizationalUnit";
        
        
        // add multiple requests (make sure )
        addRequest = gcnew AddRequest(ou1, objectClass);
        addRequest->RequestId = "Add1";
        batchRequest->Add(addRequest);

        addRequest = gcnew AddRequest(ou2, objectClass);
        addRequest->RequestId = "Add2";
        batchRequest->Add(addRequest);        
        
        addRequest = gcnew AddRequest(ou3, objectClass);
        addRequest->RequestId = "Add3";
        batchRequest->Add(addRequest);


        compareRequest = gcnew CompareRequest(ou1, "distinguishedName", ou1);
        compareRequest->RequestId = "Compare1";
        batchRequest->Add(compareRequest);

        deleteRequest = gcnew DeleteRequest(ou1);
        deleteRequest->RequestId = "Delete1";
        batchRequest->Add(deleteRequest);

        compareRequest = gcnew CompareRequest(ou2, "distinguishedName", ou2);
        compareRequest->RequestId = "Compare2";
        batchRequest->Add(compareRequest);

		modifyRequest = gcnew ModifyRequest(ou2, 
		                                    DirectoryAttributeOperation::Replace, 
		                                    "description", 
		                                    "Testing BatchRequest");

        modifyRequest->RequestId = "Modify1";
        batchRequest->Add(modifyRequest);        

        deleteRequest = gcnew DeleteRequest(ou2);
        deleteRequest->RequestId = "Delete2";
        batchRequest->Add(deleteRequest);

        deleteRequest = gcnew DeleteRequest(ou3);
        deleteRequest->RequestId = "Delete3";
        batchRequest->Add(deleteRequest);

        DsmlResponseDocument^ batchResponse = 
                                    dsmlConnection->SendRequest(batchRequest);

        DirectoryResponse^ response;
		for(int i=0;i<batchResponse->Count;i++)
        {
			response = batchResponse[i];
			Console::WriteLine("{0}: \tId={1},\tResultCode={2}" ,
			                    response->GetType()->Name , 
			                    response->RequestId, 
			                    response->ResultCode);
        }

		Console::WriteLine("Batch request has been processed successfully.");
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