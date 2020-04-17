/*=====================================================================
  File:     ReplicationStateManagement.cs

  Summary:  Demonstrates replication management related classes and 
            methods.

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
  class ReplicationStateManagement
  {
    static bool SyncFromAllServersCallbackRoutine
    (
      SyncFromAllServersEvent eventType, 
      string target, 
      string source, 
      SyncFromAllServersOperationException exception
    )
    {
      Console.WriteLine("\neventType is {0}", eventType);
      Console.WriteLine("target is {0}", target);
      Console.WriteLine("source is {0}", source);
      Console.WriteLine("exception is {0}", exception);
      return true;
    }

    static void Main()
    {
      try
      {
        string targetDomainName = "fabrikam.com";

        string targetServer = "server1.fabrikam.com";
        string sourceServer = "server2.fabrikam.com";
        string partitionName = "CN=Configuration,DC=fabrikam,DC=com";

        // get to the domain controller
        DomainController dc = DomainController.FindOne(
                                    new DirectoryContext(
                                                    DirectoryContextType.Domain, 
                                                    targetDomainName));
        
        // to use alternate credentials use the below code
        // DomainController dc = DomainController.FindOne(
        //                          new DirectoryContext(
        //                                          DirectoryContextType.Domain, 
        //                                          targetDomainName, 
        //                                          "alt-username", 
        //                                          "alt-password"));
        //
        //

        
        // invoke kcc to check replication consistency
        dc.CheckReplicationConsistency();
        Console.WriteLine("\nCheck replication consistency succeed\n");

        // sync replica from a source server
        dc.SyncReplicaFromServer(partitionName, sourceServer);
        Console.WriteLine("\nSynchronize naming context \"{0}\" "+
                            "with server {1} succeed", 
                            partitionName, 
                            sourceServer);

        // sync replica from all neighbors
        dc.TriggerSyncReplicaFromNeighbors(partitionName);
        Console.WriteLine("\nSynchronize naming context \"{0}\" "+
                          "with all neighbors succeed", partitionName);

        // sync replica from all servers
        dc.SyncFromAllServersCallback = SyncFromAllServersCallbackRoutine;
        Console.WriteLine("\nStart sync with all servers:");
        dc.SyncReplicaFromAllServers(partitionName, 
                            SyncFromAllServersOptions.AbortIfServerUnavailable);
        
        Console.WriteLine("\nSynchronize naming context \"{0}\" "+
                          "with all servers succeed", partitionName);

        // replication connection

        // create new replication connections
        DirectoryServer sourceDC = DomainController.GetDomainController(
                                        new DirectoryContext(
                                           DirectoryContextType.DirectoryServer, 
                                           sourceServer));
        
        // to use alternate credentials use the below code
        // DirectoryServer sourceDC = DomainController.GetDomainController(
        //                              new DirectoryContext(
        //                                 DirectoryContextType.DirectoryServer, 
        //                                 sourceServer, 
        //                                 "alt-username", 
        //                                 "alt-password"));
        //


        
        ReplicationConnection connection = 
                                new ReplicationConnection(
                                        new DirectoryContext(
                                           DirectoryContextType.DirectoryServer, 
                                           targetServer), 
                                        "myconnection", 
                                        sourceDC);

        // to use alternate credentials use the below code
        // ReplicationConnection connection = 
        //                      new ReplicationConnection(
        //                              new DirectoryContext(
        //                                 DirectoryContextType.DirectoryServer, 
        //                                 targetServer, 
        //                                 "alt-username", 
        //                                 "alt-password"), 
        //                              "myconnection", 
        //                              sourceDC);
        //

        
        // set change notification status
        connection.ChangeNotificationStatus = NotificationStatus.IntraSiteOnly;

        // create customized replication schedule
        ActiveDirectorySchedule schedule = new ActiveDirectorySchedule();
        schedule.SetDailySchedule(HourOfDay.Twelve, 
                                  MinuteOfHour.Zero, 
                                  HourOfDay.Fifteen, 
                                  MinuteOfHour.Zero);
        
        schedule.SetSchedule(DayOfWeek.Sunday, 
                             HourOfDay.Eight, 
                             MinuteOfHour.Zero, 
                             HourOfDay.Eleven, 
                             MinuteOfHour.Zero);
        
        schedule.SetSchedule(DayOfWeek.Saturday, 
                             HourOfDay.Seven, 
                             MinuteOfHour.Zero, 
                             HourOfDay.Ten, 
                             MinuteOfHour.Zero);

        connection.ReplicationSchedule = schedule;
        connection.ReplicationScheduleOwnedByUser = true;
        connection.Save();
        Console.WriteLine("\nNew replication connection is created successfully");

        connection = ReplicationConnection.FindByName(
                                       new DirectoryContext(
                                           DirectoryContextType.DirectoryServer, 
                                           targetServer), 
                                       "myconnection");

        // to use alternate credentials use the below code
        // connection = ReplicationConnection.FindByName(
        //                             new DirectoryContext(
        //                                 DirectoryContextType.DirectoryServer, 
        //                                 targetServer,
        //                                 "alt-username", 
        //                                 "alt-password"), 
        //                             "myconnection");
        //

        Console.WriteLine("\nGet replication connection \"{0}\" information:", 
                            connection.Name);

        Console.WriteLine("ChangeNotificationStatus is {0}", 
                                           connection.ChangeNotificationStatus);
        Console.WriteLine("ReplicationSpan is {0}", connection.ReplicationSpan);
        Console.WriteLine("ReplicationScheduleOwnedByUser is {0}",
                                     connection.ReplicationScheduleOwnedByUser);

        // delete the replication connection
        connection.Delete();
        Console.WriteLine("\nReplication connection is deleted\n");
      }
      catch (Exception e)
      {
        Console.WriteLine("\r\nUnexpected exception occured:\r\n\t" +
                            e.GetType().Name + ":" + e.Message);
      }      
    }
  }
}
