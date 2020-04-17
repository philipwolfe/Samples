/*=====================================================================
  File:     TrustManagement.cs

  Summary:  Demonstrates managing a cross forest trust.

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
  class TrustManagement
  {
    static void Main()
    {
      try
      {
        string sourceForestName = "fabrikam.com";

        string targetForestName = "app.com";

        string excludedTopLevelName1 = "external.app.com";

        // trust lifetime management
        Forest sourceForest = Forest.GetForest(new DirectoryContext(
                                                    DirectoryContextType.Forest, 
                                                    sourceForestName));

        Forest targetForest = Forest.GetForest(new DirectoryContext(
                                                    DirectoryContextType.Forest, 
                                                    targetForestName));
        
        // create an inbound forest trust
        sourceForest.CreateTrustRelationship(targetForest, 
                                             TrustDirection.Outbound);
        Console.WriteLine("\nCreateTrustRelationship succeed");

        // obtain the newly created trust
        ForestTrustRelationshipInformation forestTrust = 
                            sourceForest.GetTrustRelationship(targetForestName);

        Console.WriteLine("\nThe new forest trust: \"{0}\" - \"{1}\", "+
                          "trust direction is {2}, trust type is {3}", 
                          sourceForestName, 
                          targetForestName, 
                          forestTrust.TrustDirection, 
                          forestTrust.TrustType);

        Console.WriteLine("SelectiveAuthenticationStatus of the trust is {0}",
                          sourceForest.GetSelectiveAuthenticationStatus(
                                                             targetForestName));

        Console.WriteLine("SidFilteringStatus of the trust is {0}", 
                          sourceForest.GetSidFilteringStatus(targetForestName));

        // change trust attribute
        sourceForest.SetSelectiveAuthenticationStatus(targetForestName, true);
        sourceForest.SetSidFilteringStatus(targetForestName, false);
        Console.WriteLine("\nSelectiveAuthenticationStatus of the "+
                          "trust is now {0}", 
                          sourceForest.GetSelectiveAuthenticationStatus(
                                                             targetForestName));

        Console.WriteLine("SidFilteringStatus of the trust is now {0}", 
                          sourceForest.GetSidFilteringStatus(targetForestName));

        // verify trust relationship
        sourceForest.VerifyOutboundTrustRelationship(targetForestName);
        Console.WriteLine("\nVerifyOutboundTrustRelationship succeeded\n");

        // update the trust direction
        sourceForest.UpdateTrustRelationship(targetForest, 
                                             TrustDirection.Bidirectional);

        Console.WriteLine("\nUpdateTrustRelationship succeeded\n");

        // check the trust direction has been updated
        forestTrust = sourceForest.GetTrustRelationship(targetForestName);
        Console.WriteLine("\nAfter updating the trust direction: "+
                          "\"{0}\" - \"{1}\", trust direction is {2}, "+
                          "trust type is {3}", 
                          sourceForestName, 
                          targetForestName, 
                          forestTrust.TrustDirection, 
                          forestTrust.TrustType);

        // verify the trust direction again
        sourceForest.VerifyTrustRelationship(targetForest,
                                             TrustDirection.Bidirectional);
        Console.WriteLine("\nVerifyTrustRelationship succeeded\n");

        // get the forest trust information
        Console.WriteLine("\nGet forest trust information");
        Console.WriteLine("TopLevelNems include:");
        foreach (TopLevelName t in forestTrust.TopLevelNames)
        {
          Console.WriteLine("\t{0}, status is {1}", t.Name, t.Status);
        }
        Console.WriteLine("ExcludedTopLevelNems include:");
        foreach (string s in forestTrust.ExcludedTopLevelNames)
        {
          Console.WriteLine("\t{0}", s);
        }
        Console.WriteLine("ForestTrustDomainInformation:");
        foreach (ForestTrustDomainInformation info in 
                                           forestTrust.TrustedDomainInformation)
        {
          Console.WriteLine("\tDNS name is {0}, NetBIOS name is {1}, "+
                            "domain sid is {2} and status is {3}", 
                            info.DnsName, 
                            info.NetBiosName, 
                            info.DomainSid, 
                            info.Status);
        }

        // modify the excluded top level name
        forestTrust.ExcludedTopLevelNames.Add(excludedTopLevelName1);
        forestTrust.Save();

        Console.WriteLine("\nAfter modifying, ExcludedTopLevelNames include:");
        foreach (string s in forestTrust.ExcludedTopLevelNames)
        {
          Console.WriteLine("\t{0}", s);
        }

        // repair the trust when necessary
        sourceForest.RepairTrustRelationship(targetForest);
        Console.WriteLine("\nRepairTrustRelationship succeeded");

        // delete the forest trust
        sourceForest.DeleteTrustRelationship(targetForest);
        Console.WriteLine("\nDeleteTrustRelationship succeeded");
      }
      catch (Exception e)
      {
        Console.WriteLine("\r\nUnexpected exception occured:\r\n\t" +
                          e.GetType().Name + ":" + e.Message);
      }        
    }
  }
}
