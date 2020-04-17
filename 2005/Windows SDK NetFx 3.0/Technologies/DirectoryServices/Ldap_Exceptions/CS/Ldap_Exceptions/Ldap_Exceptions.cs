/*=====================================================================
  File:      Exceptions.cs

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

// To compile: csc.exe /out:App.exe /r:System.DirectoryServices.Protocols.dll
//                                                          Exceptions.cs
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
            HandleLdapException();
            HandleDirectoryOperationException();
            HandlePlatformNotSupportedException();
            HandleBerConversionException();
            HandleArgumentNullException();
            HandleTlsOperationException();
            HandleInvalidOperationException();
            
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
            Console.WriteLine("Usage: App.exe <ldapServer> <user> " +
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

    static void HandleLdapException()
    {
        try
        {
            Console.WriteLine("\r\nTrying to connect to an unknown"+
                              " Ldap server...");

            LdapConnection conn = new LdapConnection("badServer");
            conn.Bind();
        }
        catch(LdapException e)
        {
            Console.WriteLine(e.GetType().Name + 
                              ": ErrorCode:"+ e.ErrorCode + 
                              ", Message:"  + e.Message);
        }


        try
        {
            Console.WriteLine("\r\nTrying to authenticate "+
                              "with bogus credentials...");
            
            ldapConnection.Credential = new NetworkCredential("bogusUser", 
                                                              "bogusPwd",
                                                              "bogusDom");
            ldapConnection.Bind();            
        }
        catch(LdapException e)
        {
            Console.WriteLine(e.GetType().Name + 
                              ": ErrorCode:"+ e.ErrorCode + 
                              ", Message:"  + e.Message);

            // revert back to original credentials supplied
            ldapConnection.Credential  = credential;
        }        
    }


    static void HandleDirectoryOperationException()
    {
        try
        {
            Console.WriteLine("\r\nSending a delete request "+
                                                    "with an invalid dn... ");
            
            ldapConnection.SendRequest(new DeleteRequest("#thisIsAnInValidDN#"));  
        }
        catch(DirectoryOperationException e)
        {
            DeleteResponse response = (DeleteResponse)e.Response;
            Console.WriteLine(e.GetType().Name + ": Message:" + e.Message);
            Console.WriteLine("Response: ResultCode:" + response.ResultCode +
                                    " : ErrorMessage:" + response.ErrorMessage);
        }
    }


    static void HandlePlatformNotSupportedException()
    {
        try
        {
            LdapConnection conn = new LdapConnection("someServer");
        }
        catch(PlatformNotSupportedException e)
        {
            Console.WriteLine(e.GetType().Name + ": Message:" + e.Message);

            // The application should handle this exception and 
            // fail gracefully on an unsupported platform
            Console.WriteLine("The application is not supported "+
                                       "on this platform and will shutdown...");
        }
    }
    

    static void HandleBerConversionException()
    {
        try
        {
            Console.WriteLine("\r\nTrying to decode a binary "+
                                    "value with an incorrect decode string...");

            BerConverter.Decode("{iii}",
                                new byte[]{0x00,0xFF,0x30,0x84,0x00,0x00,0x00});
        }
        catch(BerConversionException e)
        {
            Console.WriteLine(e.GetType().Name + ": Message:" + e.Message);
        }
    }


    static void HandleArgumentNullException()
    {
        try
        {
            Console.WriteLine("\r\nTrying to create "+
                                    "DirectoryAttribute with null values...");
            
            DirectoryAttribute attribute = new DirectoryAttribute(
                                                    "attrName", 
                                                    new string[]{"val1", 
                                                                 null, 
                                                                 "val2"});
        }
        catch(ArgumentNullException e)
        {
            Console.WriteLine(e.GetType().Name + ": Message:" + e.Message);
        }       
    }

    
    static void HandleTlsOperationException()
    {    
        try
        {
            Console.WriteLine("\r\nCalling StopTransportLayerSecurity()... ");
            ldapConnection.SessionOptions.StopTransportLayerSecurity();
        }
        catch(TlsOperationException e)
        {
            Console.WriteLine(e.GetType().Name + ": Message:" + e.Message);
        }
    }


    static void HandleInvalidOperationException()
    {
        try
        {
            Console.WriteLine("\r\nTrying anonymous authentication "+
                                                "with a non-null credential ");
            ldapConnection.AuthType = AuthType.Anonymous;
            ldapConnection.Credential = new NetworkCredential("userName",
                                                              "pwd",
                                                              "domain");
            ldapConnection.Bind();
            
        }
        catch(InvalidOperationException e)
        {
            Console.WriteLine(e.GetType().Name + ": Message:" + e.Message);
            // revert back
            ldapConnection.AuthType = AuthType.Negotiate;
            ldapConnection.Credential = credential;
        }    
    }

}// end class App

}
