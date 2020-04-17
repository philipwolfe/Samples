/*=====================================================================
  File:     TopologyManagement.cs

  Summary:  Demonstrates  managing directory topology such as sites,
            subnets, sitelinks etc.

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
  class TopologyManagement
  {
    static void Main()
    {
      try
      {
        string targetName = "fabrikam.com";

        string subnetName1 = "154.55.0.0/16";
        string subnetName2 = "154.56.0.0/16";

        string siteName = "myNewSite";
        string siteLinkName = "DEFAULTIPSITELINK";
        string defaultSiteName = "Default-First-Site-Name";

        DirectoryContext domainContext = new DirectoryContext(
                                                DirectoryContextType.Domain, 
                                                targetName);

        DirectoryContext forestContext = new DirectoryContext(
                                                DirectoryContextType.Forest, 
                                                targetName);

        Forest forest = Forest.GetForest(forestContext);

        // create new site
        ActiveDirectorySite site = new ActiveDirectorySite(forestContext, 
                                                           siteName);
        site.Options = ActiveDirectorySiteOptions.GroupMembershipCachingEnabled;
        site.Save();
        Console.WriteLine("\nSite \"{0}\" is created successfully", site);

        // create new subnets
        ActiveDirectorySubnet subnet1 = new ActiveDirectorySubnet(forestContext, 
                                                                  subnetName1);
        subnet1.Location = "Bellevue";
        subnet1.Site = site;
        subnet1.Save();
        Console.WriteLine("\nSubnet \"{0}\" is created successfully", subnet1);

        ActiveDirectorySubnet subnet2 = new ActiveDirectorySubnet(forestContext, 
                                                                  subnetName2, 
                                                                  siteName);
        subnet2.Location = "Redmond";
        subnet2.Save();
        Console.WriteLine("\nSubnet \"{0}\" is created successfully", subnet2);

        Console.WriteLine("\nSite \"{0}\" contains subnet:", site.Name);
        foreach (ActiveDirectorySubnet subnet in site.Subnets)
        {
          Console.WriteLine("\tSubnet \"{0}\", location is {1}",
                            subnet.Name, 
                            subnet.Location);
        }

        // add new site to an existing site link
        ActiveDirectorySiteLink link = ActiveDirectorySiteLink.FindByName(
                                                                  forestContext, 
                                                                  siteLinkName);

        Console.WriteLine("\nAdd site \"{0}\" to site link \"{1}\"", site.Name, 
                                                                     link.Name);

        link.Sites.Add(site);
        link.Save();
        Console.WriteLine("\nSiteLink \"{0}\" has site: ", link);
        foreach (ActiveDirectorySite s in link.Sites)
        {
          Console.WriteLine("\tSite \"{0}\"", s);
        }

        // delete site and subnets
        site.Delete();
        subnet1.Delete();
        subnet2.Delete();
        Console.WriteLine("\nSite and subnets are deleted successfully\n");

        // existing site management

        // preferred RPC bridgehead server
        ActiveDirectorySite defaultSite = ActiveDirectorySite.FindByName(
                                                               forestContext, 
                                                               defaultSiteName);

        Console.WriteLine("\nExisting PreferredRpcBridgeheadServers is:");
        foreach (DirectoryServer s in defaultSite.PreferredRpcBridgeheadServers)
        {
          Console.WriteLine("\tServer {0}", s.Name);
        }

        Console.WriteLine("\nAdd PreferredRpcBridgeheadServers");
        DomainControllerCollection col = Domain.GetDomain(domainContext).
                                      FindAllDomainControllers(defaultSiteName);
        
        foreach (DirectoryServer s in col)
        {
          defaultSite.PreferredRpcBridgeheadServers.Add(s);
        }

        defaultSite.Save();
        Console.WriteLine("\nAfter updating, PreferredRpcBridgeheadServers is:");
        foreach (DirectoryServer s in defaultSite.PreferredRpcBridgeheadServers)
        {
          Console.WriteLine("\tServer {0}", s.Name);
        }

        defaultSite.PreferredRpcBridgeheadServers.Clear();
        defaultSite.Save();
        Console.WriteLine("\nAfter Clear call, PreferredRpcBridgeheadServers is:");
        foreach (DirectoryServer s in defaultSite.PreferredRpcBridgeheadServers)
        {
          Console.WriteLine("\tServer {0}", s.Name);
        }        
      }
      catch(Exception e)
      {
          Console.WriteLine("\r\nUnexpected exception occured:\r\n\t" + 
                            e.GetType().Name + ":" + e.Message);
      }     
    }
  }
}
