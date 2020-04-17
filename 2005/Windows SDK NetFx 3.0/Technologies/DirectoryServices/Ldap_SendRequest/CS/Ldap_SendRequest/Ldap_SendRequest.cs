/*=====================================================================
  File:      SendRequest.cs

  Summary:   Demonstrates the use of the LdapConnection class to do 
                    various directory operations.

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
//                                                              SendRequest.cs
//
// To run: App.exe <ldapServer> <user> <pwd> <domain> <targetOU>
//     Eg: App.exe myDC1.testDom.fabrikam.com  user1  secret@~1 testDom 
//                                  OU=samples,DC=testDom,DC=fabrikam,DC=com            

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
    static NetworkCredential credential;
    static string targetOU; // dn of an OU. eg: "OU=sample,DC=fabrikam,DC=com"

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
            Add();
            Modify();
            Rename();
            Move();
            Compare();
            Search();
            DeleteLeafObject();
            DeleteTree();

            
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
        if(args.Length != 5)
        {
            Console.WriteLine("Usage: App.exe <ldapServer> <user> <pwd> "+
                                                        "<domain> <targetOU>");

            // return error 
            return false;
        }

        // initialize variables
        ldapServer = args[0];
        credential = new NetworkCredential(args[1], args[2], args[3]);
        targetOU = args[4];

        // return success
        return true;
    }



    static void CreateConnection()
    {
        ldapConnection = new LdapConnection(ldapServer);        
        ldapConnection.Credential = credential;
        Console.WriteLine("LdapConnection is created successfully.");
    }



    static void Add()
    {
        // create new OUs under the specified OU
        ou1 = "OU=sampleOU1," +targetOU;
        ou2 = "OU=sampleOU2," +targetOU;
        ou3 = "OU=sampleOU3," +targetOU;
        string objectClass = "organizationalUnit";
        
        
        // create a request to add the new object
        AddRequest addRequest = new AddRequest(ou1, objectClass);

        // send the request through the connection
        ldapConnection.SendRequest(addRequest);

        // create a request to add the new object
        addRequest = new AddRequest(ou2, objectClass);

        // send the request through the connection
        ldapConnection.SendRequest(addRequest);

        // create a request to add the new object
        addRequest = new AddRequest(ou3, objectClass);

        // send the request through the connection
        ldapConnection.SendRequest(addRequest);
        
        Console.WriteLine("Objects are created successfully.");
    }

    



    static void Modify()
    {
        string attributeName = "description";
        string[] newValue = new string[]{"This is a sample OU"};

        // create a request to modify the object
        ModifyRequest  modifyRequest = new ModifyRequest(
                                            ou1, 
                                            DirectoryAttributeOperation.Replace, 
                                            attributeName, 
                                            newValue);

        // send the request through the connection
        ldapConnection.SendRequest(modifyRequest);

        Console.WriteLine("Object is modified successfully." );
    }



    
    static void Rename()
    {
        // keep the parent container same to do just rename without moving
        string newParent = targetOU;
        string newName = "OU=sampleOUNew";

        // create a request to rename the object
        ModifyDNRequest modDnRequest = new ModifyDNRequest(
                                                            ou1,
                                                            newParent, 
                                                            newName
                                                          );

        // send the request through the connection
        ldapConnection.SendRequest(modDnRequest);

        // this is the new path of the object after rename operation
        ou1 = "OU=sampleOUNew," + targetOU;
        Console.WriteLine("Object has been renamed successfully." );
    }


    
    static void Move()
    {
        // move sampleOU3 under sampleOU2
        string newParent = ou2;

        // keep the name same to just move without renaming
        string newName = "OU=sampleOU3";

        // create a request to move the object
        ModifyDNRequest modDnRequest = new ModifyDNRequest(
                                                            ou3,
                                                            newParent, 
                                                            newName
                                                          );

        // send the request through the connection
        ldapConnection.SendRequest(modDnRequest);

        Console.WriteLine("Object is moved successfully." );                
    }


    
    static void Compare()
    {
        string attributeName = "description";
        string valueToCompareAgainst = "This is a sample OU";

        // create a request to do compare on the object
        CompareRequest compareRequest = new CompareRequest(
                                                           ou1, 
                                                           attributeName, 
                                                           valueToCompareAgainst
                                                          );

        // send the request through the connection
        CompareResponse compareResponse = 
                    (CompareResponse)ldapConnection.SendRequest(compareRequest);

        Console.WriteLine("The result of the comparison is:" + 
                                                    compareResponse.ResultCode);
    }


    
    static void Search()
    {
        string ldapSearchFilter = "(&(objectClass=organizationalUnit)(ou=sample*))";

        // return ALL attributes that have some value
        string[] attributesToReturn = null;

        // create a search request: specify baseDn, ldap search filter,
        // attributes to return and scope of the search
        SearchRequest searchRequest = new SearchRequest(
                                                        targetOU, 
                                                        ldapSearchFilter, 
                                                        SearchScope.Subtree, 
                                                        attributesToReturn
                                                       );


        // send the request through the connection
        SearchResponse searchResponse = 
                      (SearchResponse)ldapConnection.SendRequest(searchRequest);

        // retrieve a specific attribute
        DirectoryAttribute attribute = 
                                    searchResponse.Entries[0].Attributes["ou"];

        // get the first value since "ou" is a single valued attribute
        Console.WriteLine(attribute.Name + "=" + attribute[0]);

        PrintSearchResponse(searchResponse);
        
        Console.WriteLine("Search is completed successfully.\r\n");
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
            Console.WriteLine("\r\n" + (++i) +"- " +entry.DistinguishedName);
            

            // retrieve all attributes
            foreach(DirectoryAttribute attr in entry.Attributes.Values)
            {
                Console.Write(attr.Name + "=" );

                // retrieve all values for the attribute
                // LdapConnection returns everything as 
                // byte[] just as in LDAP C API
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
    
    
    static void DeleteLeafObject()
    {
        // create a request to delete the object (ou1 is a leaf object)
        DeleteRequest deleteRequest = new DeleteRequest(ou1);

        // send the request through the connection
        ldapConnection.SendRequest(deleteRequest);

        Console.WriteLine("Leaf object is deleted successfully.");
    }


    
    static void DeleteTree()
    {
        // create a request to delete the object 
        // (ou2 is not a leaf object since it has child objects)
        DeleteRequest deleteRequest = new DeleteRequest(ou2);
        
        // add a tree-delete control to the request
        deleteRequest.Controls.Add(new TreeDeleteControl());

        // send the request through the connection
        ldapConnection.SendRequest(deleteRequest);

        Console.WriteLine("Object tree is deleted successfully.");
    }

    
}// end class App

}
