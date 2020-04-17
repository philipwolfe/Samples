/*=====================================================================
  File:      PrintDomain.cs

  Summary:   Demonstrates how to connect to the currently
             logged-in domain.

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
//                                                      PrintDomain.cs
//
// To run: App.exe
//

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
    public static void Main()
    {
        try
        {  
            Console.WriteLine("Creating LdapConnection "+
                                            "to currently logged-in domain.");

            LdapConnection ldapConnection = new LdapConnection((string)null);

            Console.WriteLine("Sending a RootDSE search to discover the"+
                                             " fully qualified domain name.");

            SearchRequest search = new SearchRequest();
            // Search scope should be Base for doing a RootDSE search
            search.Scope = SearchScope.Base;
            SearchResponse response = 
                            (SearchResponse)ldapConnection.SendRequest(search);

            // dnsHostName is in the form dcName.domainName.xyz.abc.com
            // so we need to get the substring after the 1st '.' character
            string dnsHostName = 
                       (string)response.Entries[0].Attributes["dnsHostName"][0];
            
            Console.WriteLine("\r\nYour domain is:" + 
                            dnsHostName.Substring(dnsHostName.IndexOf('.')+1));
            
            Console.WriteLine("\r\nApplication Finished Successfully!!!");
        }
        catch(Exception e)
        {
            Console.WriteLine("\r\nUnexpected exception occured:\r\n\t" + 
                              e.GetType().Name + ":" + e.Message);
        }        
    }

}// end class App


}
