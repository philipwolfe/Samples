/*=====================================================================
  File:     TopologyInformation.cs

  Summary:  Demonstrates  

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

  class TopologyInformation
  {
    static void Main()
    {
      try
      {
        string targetForestName = "fabrikam.com";

        DirectoryContext context = new DirectoryContext(
                                                    DirectoryContextType.Forest, 
                                                    targetForestName);
        
        Forest forest = Forest.GetForest(context);

        Console.WriteLine("\nGet intersite transport object");
        ActiveDirectoryInterSiteTransport transport = 
             ActiveDirectoryInterSiteTransport.FindByTransportType(
                                              context, 
                                              ActiveDirectoryTransportType.Rpc);
        
        Console.WriteLine("\tBridgeAllSiteLinks is {0}", 
                          transport.BridgeAllSiteLinks);

        Console.WriteLine("\tIgnoreReplicationSchedule is {0}", 
                                           transport.IgnoreReplicationSchedule);

        // get all the site links that have transport type as RPC over IP
        Console.WriteLine("\nForest \"{0}\" has site links: ", forest);
        foreach (ActiveDirectorySiteLink link in transport.SiteLinks)
        {
          Console.WriteLine("\tSitelink \"{0}\"", link);
        }

        // get all the site link bridges that have transport type as RPC over IP
        Console.WriteLine("\nForest \"{0}\" has site link bridges: ", forest);
        foreach (ActiveDirectorySiteLinkBridge bridge in 
                                                      transport.SiteLinkBridges)
        {
          Console.WriteLine("SitelinkBridge \"{0}\"", bridge);
        }

        // get all the sites in the forest
        foreach (ActiveDirectorySite site in forest.Sites)
        {
          Console.WriteLine("\n\nSite \"{0}\":", site.Name);
          Console.WriteLine("It contains domain:");
          foreach (Domain d in site.Domains)
          {
            Console.WriteLine("\tDomain \"{0}\"", d.Name);
          }
          Console.WriteLine("It contains server:");
          foreach (DirectoryServer s in site.Servers)
          {
            Console.WriteLine("\tServer \"{0}\"", s.Name);
          }
          Console.WriteLine("It contains subnet:");
          foreach (ActiveDirectorySubnet subnet in site.Subnets)
          {
            Console.WriteLine("\tSubnet \"{0}\", location is {1}", 
                                subnet.Name, 
                                subnet.Location);
          }
          Console.WriteLine("\nInterSiteTopologyGenerator is {0}", 
                                              site.InterSiteTopologyGenerator);
          Console.WriteLine("\nBridgehead servers are:");
          foreach (DirectoryServer s in site.BridgeheadServers)
          {
            Console.WriteLine("\tServer \"{0}\"", s.Name);
          }
          Console.WriteLine("\nAdjacent sites are:");
          foreach (ActiveDirectorySite s in site.AdjacentSites)
          {
            Console.WriteLine("\tSite \"{0}\"", s.Name);
          }
        }
      }
      catch (Exception e)
      {
        Console.WriteLine("\r\nUnexpected exception occured:\r\n\t" +
                          e.GetType().Name + ":" + e.Message);
      }      
    }
  }
}
