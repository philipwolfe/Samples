/*=====================================================================
  File:      BatchRequest.cs

  Summary:   Demonstrates the use of the DsmlSoapHttpConnection &
             DsmlRequestDocument class to do multiple directory operations 
             in one batch.

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
//              BatchRequest.cs
// To run: App.exe <dsmlServer> <user> <pwd> <domain> <targetOU>
// Eg: App.exe http://myDC1.testDom.fabrikam.com/dsml/adssoap.dsmlx  user1  
//             secret@~1 testDom OU=samples,DC=testDom,DC=fabrikam,DC=com            

using System;
using System.Net;
using System.Security.Permissions;
using SDS = System.DirectoryServices;

using System.DirectoryServices.Protocols;



[assembly: System.Reflection.AssemblyVersion("1.0.0.0")]
[assembly: SecurityPermission(SecurityAction.RequestMinimum, Execution = true)]
[assembly: SDS.DirectoryServicesPermission(SecurityAction.RequestMinimum)]

namespace Microsoft.Samples.DirectoryServices
{

public static class App
{
    // static variables used throughout the sample code
    static DsmlSoapHttpConnection dsmlConnection;
    static string  dsmlServer;
    static NetworkCredential credential;

    // dn of an OU. eg: "OU=sample,DC=fabrikam,DC=com"
    static string targetOU;

    // object DNs that are created in the sample
    static string ou1, ou2, ou3;

    public static void Main(string[] args)
    {
        try
        {
            if(!GetParameters(args))
            {
                return;
            }
            
            CreateConnection();            
            SendBatchRequest();
            
            Console.WriteLine("\r\nApplication Finished Successfully!!!");
        }
        catch(Exception e)
        {
            Console.WriteLine("\r\nUnexpected exception occured:\r\n\t" +
                              e.GetType() + ":" + e.Message);
        }        
    }



    static bool GetParameters(string[] args)
    {    
        if(args.Length != 5)
        {
            Console.WriteLine("Usage: App.exe <dsmlServer> <user> <pwd> "+
                                              "<domain> <targetOU>");
            // return error 
            return false;
        }

        // initialize variables
        dsmlServer = args[0];
        credential = new NetworkCredential(args[1], args[2], args[3]);
        targetOU = args[4];

        // return success
        return true;
    }



    static void CreateConnection()
    {
        dsmlConnection = new DsmlSoapHttpConnection(new Uri(dsmlServer));
        dsmlConnection.Credential = credential;
        Console.WriteLine("DsmlSoapHttpConnection is created successfully.");
    }



    static void SendBatchRequest()
    {          
        DsmlRequestDocument batchRequest = new DsmlRequestDocument();              
        AddRequest addRequest;
        ModifyRequest  modifyRequest;
        CompareRequest compareRequest;
        DeleteRequest deleteRequest;
        
        // create new OUs under the specified OU
        ou1 = "OU=sampleOU1," +targetOU;
        ou2 = "OU=sampleOU2," +targetOU;
        ou3 = "OU=sampleOU3," +targetOU;
        string objectClass = "organizationalUnit";
        
        
        // add multiple requests (make sure )
        addRequest = new AddRequest(ou1, objectClass);
        addRequest.RequestId = "Add1";
        batchRequest.Add(addRequest);

        addRequest = new AddRequest(ou2, objectClass);
        addRequest.RequestId = "Add2";
        batchRequest.Add(addRequest);        
        
        addRequest = new AddRequest(ou3, objectClass);
        addRequest.RequestId = "Add3";
        batchRequest.Add(addRequest);


        compareRequest = new CompareRequest(ou1, "distinguishedName", ou1);
        compareRequest.RequestId = "Compare1";
        batchRequest.Add(compareRequest);

        deleteRequest = new DeleteRequest(ou1);
        deleteRequest.RequestId = "Delete1";
        batchRequest.Add(deleteRequest);

        compareRequest = new CompareRequest(ou2, "distinguishedName", ou2);
        compareRequest.RequestId = "Compare2";
        batchRequest.Add(compareRequest);

        modifyRequest = new ModifyRequest(ou2, 
                                          DirectoryAttributeOperation.Replace, 
                                          "description", 
                                          "Testing BatchRequest");
        modifyRequest.RequestId = "Modify1";
        batchRequest.Add(modifyRequest);        

        deleteRequest = new DeleteRequest(ou2);
        deleteRequest.RequestId = "Delete2";
        batchRequest.Add(deleteRequest);

        deleteRequest = new DeleteRequest(ou3);
        deleteRequest.RequestId = "Delete3";
        batchRequest.Add(deleteRequest);

        DsmlResponseDocument batchResponse = 
                                       dsmlConnection.SendRequest(batchRequest);

        foreach(DirectoryResponse response in batchResponse)
        {
            Console.WriteLine(response.GetType().Name +": \tId=" + 
                              response.RequestId + ",\tResultCode=" +
                              response.ResultCode);
        }
        
        Console.WriteLine("Batch request has been processed successfully.");
    }
    
}// end class App

}
