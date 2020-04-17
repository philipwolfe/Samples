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
//                                                             ReadRootDSE.cs
//
// To run: App.exe <dsmlServer>
//     Eg: App.exe http://myDC1.testDom.fabrikam.com/dsml/adssoap.dsmlx

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
    static DsmlSoapHttpConnection dsmlConnection;

    // this DSML server's VDIR should be configured 
    // to accept anonymous connections for this sample to work
    static string  dsmlServer;

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
            Console.WriteLine("Usage: App.exe <dsmlServer>");

            // return error 
            return false;
        }

        // initialize variables
        dsmlServer = args[0];

        // return success
        return true;
    }



    static void CreateConnection()
    {
        dsmlConnection = new DsmlSoapHttpConnection(new Uri(dsmlServer));
        Console.WriteLine("DsmlSoapHttpConnection is created successfully.");
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
        SearchResponse searchResponse = (SearchResponse)dsmlConnection.SendRequest(searchRequest);

        // print the returned entries & their attributes
        Console.WriteLine("\r\nSearch matched " + searchResponse.Entries.Count 
                                                                + " entries:");
        
        foreach(SearchResultEntry entry in searchResponse.Entries)
        {  
            // retrieve a specific attribute
            DirectoryAttribute attribute = entry.Attributes["schemaNamingContext"];

            // get the first value since 
            // "schemaNamingContext" is a single valued attribute
            Console.WriteLine(attribute.Name + "=" + attribute[0]); 

            // retrieve all attributes
            foreach(DirectoryAttribute attr in entry.Attributes.Values)
            {
                Console.Write(attr.Name + "=" );

                // retrieve all values for the attribute
                // the type of the value can be one of string, byte[] or Uri
                foreach(object value in attr)
                {
                    Console.Write(value + "  ");
                }
                Console.WriteLine();
            }
        }
        
        Console.WriteLine("RootDSE Search is completed successfully.\r\n");
    }

}// end class App

}
