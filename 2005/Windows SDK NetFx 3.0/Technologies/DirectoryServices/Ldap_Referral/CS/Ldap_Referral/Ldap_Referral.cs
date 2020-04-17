/*=====================================================================
  File:      Referral.cs

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

// To compile: csc.exe /out:App.exe /r:System.DirectoryServices.Protocols.dll 
//                                                      Referral.cs
//
// To run: App.exe <ldapServer> <user> <pwd> <domain>
//     Eg: App.exe myDC1.testDom.fabrikam.com  user1  secret@~1 testDom

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


public class App
{
    // static variables used throughout the sample code
    static LdapConnection ldapConnection;
    static string  ldapServer;
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
            ReferralTest();
            
            Console.WriteLine("\r\nApplication Finished Successfully!!!");
        }
        catch(Exception e)
        {
            Console.WriteLine("\r\nUnexpected exception occured:\r\n\t" + 
                              e.GetType().Name + ":" + e.Message);
        }        
    }



    static bool GetParameters(string[] args)
    {    
        if(args.Length != 4)
        {
            Console.WriteLine("Usage: App.exe <ldapServer> <user> "+
                                                 "<pwd> <domain>");

            // return error 
            return false;
        }

        // initialize variables
        ldapServer = args[0];
        credential = new NetworkCredential(args[1], args[2], args[3]);

        // return success
        return true;
    }



    static void CreateConnection()
    {
        ldapConnection = new LdapConnection(ldapServer);        
        ldapConnection.Credential = credential;
        Console.WriteLine("LdapConnection is created successfully.");
    }



    static void ReferralTest()
    {
        Console.WriteLine("Sending a request that will generate a referral");
        SearchRequest searchRequest = new SearchRequest();
        searchRequest.DistinguishedName =
                                 "OU=Users,DC=non-existing,DC=fabrikam,DC=com";

        // send the request through the connection
        DirectoryResponse response = ldapConnection.SendRequest(searchRequest);
        
        Console.WriteLine("ResultCode:"+response.ResultCode);
        foreach(Uri referral in response.Referral)
        {
            Console.WriteLine("Referral:" + referral);
        }

        Console.WriteLine("Referral is received successfully.");
    }
    
}// end class App

}
