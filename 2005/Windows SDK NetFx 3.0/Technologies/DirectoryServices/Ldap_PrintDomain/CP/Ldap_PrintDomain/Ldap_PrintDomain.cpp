/*=====================================================================
  File:      PrintDomain.cpp

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


// To run: App.exe

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

void main()
{   
    try
    {  
        Console::WriteLine("Creating LdapConnection to "+
                                                 "currently logged-in domain.");

        LdapConnection^ ldapConnection = gcnew LdapConnection((String^)nullptr);

        Console::WriteLine("Sending a RootDSE search to discover "+
                                            "the fully qualified domain name.");

        SearchRequest^ search = gcnew SearchRequest();

        // Scope should be Base for doing a RootDSE search
        search->Scope = SearchScope::Base; 

        SearchResponse^ response = 
                           (SearchResponse^)ldapConnection->SendRequest(search);

        // dnsHostName is in the form dcName.domainName.xyz.abc.com
        // so we need to get the substring after the 1st '.' character
        String^ dnsHostName = 
                    (String^)response->Entries[0]->Attributes["dnsHostName"][0];

        Console::WriteLine("\r\nYour domain is:{0}", 
                          dnsHostName->Substring(dnsHostName->IndexOf('.')+1));
        
        Console::WriteLine("\r\nApplication Finished Successfully!!!");        
    }
    catch(Exception^ e)
    {
        Console::WriteLine("\r\nUnexpected exception occured:\r\n\t{0}:{1}",
                           e->GetType()->Name,
                           e->Message);        
    }
}