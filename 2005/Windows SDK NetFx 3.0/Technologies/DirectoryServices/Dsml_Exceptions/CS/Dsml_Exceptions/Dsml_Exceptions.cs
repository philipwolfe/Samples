/*=====================================================================
  File:      Exceptions.cs

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

// To compile: csc.exe /out:App.exe /r:System.DirectoryServices.Protocols.dll
//                 Exceptions.cs
//
// To run: App.exe <dsmlServer> <user> <pwd> <domain>
//     Eg: App.exe http://myDC1.testDom.fabrikam.com/dsml/adssoap.dsmlx  user1 
//                 secret@~1 testDom

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

    public static void Main(string[] args)
    {
        try
        {
            if(!GetParameters(args))
            {
                return;
            }
            
            CreateConnection();
            HandleErrorResponseException();
            HandleWebException();
            
            Console.WriteLine("\r\nApplication Finished Successfully!!!");
        }
        catch(Exception e)
        {
            Console.WriteLine("\r\nUnexpected exception occured:\r\n\t" 
                              + e.GetType() + ":" + e.Message);
        }        
    }



    static bool GetParameters(string[] args)
    {    
        if(args.Length != 4)
        {
            Console.WriteLine("Usage: App.exe <dsmlServer> <user> <pwd>"+
                                                                " <domain>");
            // return error 
            return false;
        }

        // initialize variables
        dsmlServer = args[0];
        credential = new NetworkCredential(args[1], args[2], args[3]);

        // return success
        return true;        
    }



    static void CreateConnection()
    {
        dsmlConnection = new DsmlSoapHttpConnection(new Uri(dsmlServer));        
        dsmlConnection.Credential = credential;
        Console.WriteLine("DsmlSoapHttpConnection is created successfully.");
    }

    static void HandleErrorResponseException()
    {
        try
        {
            Console.WriteLine("\r\nSending a compare request with an"+
                                                " invalid attribute name..");
            // the request will generate an ErrorResponseException
            // because the attribute name is not valid according 
            // to the dsmlv2 schema (eg.: $ is not allowed in attribute names)
            dsmlConnection.SendRequest(
                                        new CompareRequest
                                            (
                                                "CN=myUser,DC=fabrikam,DC=com",
                                                "$description", 
                                                "attrVal"
                                            )
                                       );
        }
        catch(ErrorResponseException e)
        {
            DsmlErrorResponse errResponse = e.Response;
            Console.WriteLine(e.GetType().Name + ": Message:" + e.Message);
            Console.WriteLine(errResponse.GetType().Name + 
                              ":\r\nType:" + errResponse.Type + 
                              "\r\nMessage:" + errResponse.Message);
        }
    }

    static void HandleWebException()
    {
        try
        {
            Console.WriteLine("\r\nTrying to authenticate "+
                                            "with bogus credentials...");
            dsmlConnection.Credential = new NetworkCredential("bogusUser", 
                                                              "bogusPwd", 
                                                              "bogusDom");
            // send an empty batch request which is a valid DSML request
            dsmlConnection.SendRequest(new DsmlRequestDocument());            
        }
        catch(WebException e)
        {
            Console.WriteLine(e.GetType().Name + ": Message:" + e.Message);

            // revert back to original credentials supplied
            dsmlConnection.Credential  = credential;
        }    
    }

}// end class App

}
