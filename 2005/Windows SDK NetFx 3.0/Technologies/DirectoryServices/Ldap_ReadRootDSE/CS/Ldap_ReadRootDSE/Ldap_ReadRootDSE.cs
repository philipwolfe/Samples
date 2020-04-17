/*=====================================================================
  File:      ReadRootDSE.cs

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

// To compile: csc.exe /out:App.exe /r:System.DirectoryServices.Protocols.dll 
//                                                          ReadRootDSE.cs
// To run: App.exe <ldapServer>
//     Eg: App.exe myDC1.testDom.fabrikam.com

using System;
using System.Text;
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

    public static void Main(string[] args)
    {
        try
        {
            if(!GetParameters(args))
            {
                return;
            }

            CreateConnection();            
            ReadRootDSE();
            
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
        if(args.Length != 1)
        {
            Console.WriteLine("Usage: App.exe <ldapServer>");

            // return error 
            return false;
        }

        // initialize variables
        ldapServer = args[0];

        // return success
        return true;        
    }



    static void CreateConnection()
    {
        ldapConnection = new LdapConnection(ldapServer);
        ldapConnection.AutoBind = false;
        Console.WriteLine("LdapConnection is created successfully.");
    }



    static void ReadRootDSE()
    {
         // specify base as null for RootDSE search
        string baseDN = null;
         
        string ldapSearchFilter = "(objectClass=*)";

        // return ALL attributes that have some value
        string[] attributesToReturn = null;

        // create a search request: specify baseDn, ldap search filter,
        // attributes to return and scope of the search
        // SearchScope should be Base for a RootDSE search
        SearchRequest searchRequest = new SearchRequest(
                                                        baseDN,
                                                        ldapSearchFilter,
                                                        SearchScope.Base,
                                                        attributesToReturn
                                                        );


        // send the request through the connection
        SearchResponse searchResponse = 
                      (SearchResponse)ldapConnection.SendRequest(searchRequest);

        PrintSearchResponse(searchResponse);

        Console.WriteLine("RootDSE Search is completed successfully.\r\n");
    }


    public static void PrintSearchResponse(SearchResponse searchResponse)
    {
        UTF8Encoding utf8 = new UTF8Encoding(false, true);    

        // print the returned entries & their attributes
        Console.WriteLine("\r\nSearch matched " + 
                                    searchResponse.Entries.Count + " entries:");

        int i=0;
        foreach(SearchResultEntry entry in searchResponse.Entries)
        {
            Console.WriteLine((++i) +"- " +entry.DistinguishedName);            

            // retrieve all attributes
            foreach(DirectoryAttribute attr in entry.Attributes.Values)
            {
                Console.Write(attr.Name + "=" );

                // retrieve all values for the attribute
                // LdapConnection returns everything as byte[] 
                // just as in LDAP C API
                foreach(byte[] value in attr)
                {
                    // first check to see if it is a valid UTF8 string
                    try
                    {
                        Console.Write(utf8.GetString(value) + "  ");
                    }
                    // it is not a valid UTF8 string
                    // just print raw bytes as hex
                    catch(ArgumentException) 
                    {
                        Console.Write(ByteArrayToHexString(value) + "  ");
                    }                    
                }
                Console.WriteLine();
            }
        }
    
    }

    public static string ByteArrayToHexString(byte[] bytes)
    {
        if(bytes == null) return "";
        StringBuilder s = new StringBuilder(bytes.Length/2);
        s.Append("0x");
        foreach(byte b in bytes)
        {        
            s.Append(String.Format("{0:X2}",b));
        }        
        return s.ToString();
    }
        

}// end class App

}
