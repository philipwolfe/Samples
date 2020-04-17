/*=====================================================================
  File:     ReplicationStateInformation.cs

  Summary:  Demonstrates replication related classes and methods

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
  class ReplicationStateInformation
  {
    static void Main()
    {
        try
        {
            string targetDomainName = "fabrikam.com";

            string objectPath = "cn=users,dc=fabrikam,dc=com";

            // get to the domain controller
            DomainController dc = DomainController.FindOne(
                                            new DirectoryContext(
                                                    DirectoryContextType.Domain, 
                                                    targetDomainName));
            
            // to provide alternate credentials, use the below 
            // DomainController dc = DomainController.FindOne(
            //                              new DirectoryContext(
            //                                      DirectoryContextType.Domain, 
            //                                      targetDomainName, 
            //                                      "alt-username", 
            //                                      "alt-password"));

            // retrieve replication cursor information
            Console.WriteLine("\nGet replication cursor information"+
                                                         " for each partition");
            foreach (string s in dc.Partitions)
            {
                Console.WriteLine("\nPartition {0}", s);
                foreach(ReplicationCursor cursor in dc.GetReplicationCursors(s))
                {
                    Console.WriteLine("\tSourceServer is {0}, "+
                                      "SourceInvocationId is {1}, "+
                                      "LastSuccessfulSyncTime is {2}", 
                                      cursor.SourceServer, 
                                      cursor.SourceInvocationId, 
                                      cursor.LastSuccessfulSyncTime);
                }
            }

            // retrieve replication neighbor information
            Console.WriteLine("\n\nGet replication neighbor information");
            foreach (string s in dc.Partitions)
            {
                Console.WriteLine("\nPartition {0}", s);
                foreach (ReplicationNeighbor neighbor in 
                                                  dc.GetReplicationNeighbors(s))
                {
                    Console.WriteLine("\tSourceServer is {0}, "+
                                      "ReplicationNeighborFlag is {1}, "+
                                      "UsnAttributeFilter is {2}, "+
                                      "LastSuccessfulSync is {3}", 
                                      neighbor.SourceServer, 
                                      neighbor.ReplicationNeighborOption, 
                                      neighbor.UsnAttributeFilter, 
                                      neighbor.LastSuccessfulSync);
                }
            }

            // retrieve the replication metadata information
            Console.WriteLine("\n\nGet replication metadata information");
            ActiveDirectoryReplicationMetadata metadata = 
                                          dc.GetReplicationMetadata(objectPath);
            foreach (object o in metadata.AttributeNames)
            {
                Console.WriteLine("\nAttribute {0}", o);
                AttributeMetadata attr = metadata[(string)o];
                Console.WriteLine("\tOriginatingServer is {0}, "+
                                  "OriginatingChangeUsn is {1}, "+
                                  "LocalChangeUsn is {2}, "+
                                  "LastOriginatingChangeTime is {3}", 
                                  attr.OriginatingServer, 
                                  attr.OriginatingChangeUsn, 
                                  attr.LocalChangeUsn, 
                                  attr.LastOriginatingChangeTime);
            }

            // retrieve the inbound replication connections
            Console.WriteLine("\n\nGet inbound replication "+
                                                      "connection information");
            foreach (ReplicationConnection con in dc.InboundConnections)
            {
                Console.WriteLine("\tReplication connection \"{0}\", "+
                                  "SourceServer is {1}, "+
                                  "DestinationServer is {2}", 
                                  con.Name, 
                                  con.SourceServer, 
                                  con.DestinationServer);
            }

            // retrieve the outbound replication connections
            Console.WriteLine("\n\nGet outbound replication "+
                                                      "connection information");

            foreach (ReplicationConnection con in dc.OutboundConnections)
            {
                Console.WriteLine("\tReplication connection \"{0}\", "+
                                  "SourceServer is {1}, "+
                                  "DestinationServer is {2}", 
                                  con.Name, 
                                  con.SourceServer, 
                                  con.DestinationServer);
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
