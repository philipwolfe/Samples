/*=====================================================================
  File:     TrustReporting.cs

  Summary:  Demonstrates retrieving trust information.

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


using System;
using System.Security.Permissions;
using System.DirectoryServices;
using System.DirectoryServices.ActiveDirectory;


[assembly: System.Reflection.AssemblyVersion("1.0.0.0")]
[assembly: SecurityPermission(SecurityAction.RequestMinimum, Execution = true)]
[assembly: DirectoryServicesPermission(SecurityAction.RequestMinimum)]


namespace Microsoft.Samples.DirectoryServices
{

  class TrustReporting
  {
    static void Main()
    {
      try
      {
        string targetDomainName = "fabrikam.com";
        string targetForestName = "corp.fabrikam.com";

        Domain currentDomain = Domain.GetCurrentDomain();
        Forest currentForest = Forest.GetCurrentForest();

        // Retrieve all the domain trusts
        Console.WriteLine("\nRetrieve all the trusts with current domain:\n");
        foreach (TrustRelationshipInformation trust in 
                                       currentDomain.GetAllTrustRelationships())
        {
          // for each domain trust relationship, get its properties
          Console.WriteLine("\"{0}\" - \"{1}\", trust direction is {2}, "+
                           "trust type is {3}", 
                           trust.SourceName, 
                           trust.TargetName, 
                           trust.TrustDirection, 
                           trust.TrustType);
        }

        // Retrieve all the forest trusts
        Console.WriteLine("\nRetrieve all the forest trusts "+
                          "with current forest:\n");

        foreach (ForestTrustRelationshipInformation trust in 
                                       currentForest.GetAllTrustRelationships())
        {
          // for each forest trust relationship, get its properties
          Console.WriteLine("\"{0}\" - \"{1}\", trust direction is {2}, "+
                            "trust type is {3}", 
                            trust.SourceName, 
                            trust.TargetName, 
                            trust.TrustDirection, 
                            trust.TrustType);
        }

        // Retrieve trust by name
        Console.WriteLine("\nRetrieve the trust with the target domain:\n");
        TrustRelationshipInformation domainTrust = 
                           currentDomain.GetTrustRelationship(targetDomainName);

        Console.WriteLine("\"{0}\" - \"{1}\", trust direction is {2}, "+
                          "trust type is {3}", 
                          currentDomain.Name, 
                          targetDomainName, 
                          domainTrust.TrustDirection, 
                          domainTrust.TrustType);

        Console.WriteLine("\nRetrieve the trust with the target forest:\n");
        ForestTrustRelationshipInformation forestTrust = 
                           currentForest.GetTrustRelationship(targetForestName);
        Console.WriteLine("\"{0}\" - \"{1}\", trust direction is {2}, "+
                          "trust type is {3}", 
                          currentForest.Name, 
                          targetForestName, 
                          forestTrust.TrustDirection, 
                          forestTrust.TrustType);
      }
      catch (Exception e)
      {
        Console.WriteLine("\r\nUnexpected exception occured:\r\n\t" +
                          e.GetType().Name + ":" + e.Message);
      }      
    }
  }
}
