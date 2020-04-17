/*=====================================================================
  File:      CreateAndDeleteLocalGroup.cs

  Summary:   This sample shows how to create a local group, add 
             a user using Invoke method of DirectoryEntry class,
             and then delete group using Remove method of 
             DirectoryEntries class

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

// To compile: 
//      csc.exe CreateAndDeleteLocalGroup.cs 
// To run: 
//      CreateAndDeleteLocalGroup.exe 

using System;
using System.Net;
using System.Security.Permissions;

using System.DirectoryServices;


[assembly: System.Runtime.InteropServices.ComVisible(false)]
[assembly: System.Reflection.AssemblyVersion("1.0.0.0")]
[assembly: SecurityPermission(SecurityAction.RequestMinimum, Execution = true)]
[assembly: DirectoryServicesPermission(SecurityAction.RequestMinimum)]

namespace Microsoft.Samples.DirectoryServices
{
    public class CreateAndDeleteLocalGroupSample
    {
        static string localComputerName = "fabrikam";
        static string newGroupName = "TestGroup";
        static string existingUserName = "ExistingUser";

        public static void Main(string[] args)
        {
            try
            {
                CreateAndDeleteLocalGroup();

                Console.WriteLine("\r\nApplication Finished Successfully!!!");
            }
            catch (Exception e)
            {
                Console.WriteLine("\r\nUnexpected exception occured:\r\n\t" +
                                e.GetType() + ":" + e.Message);
            }           
        }

        static void CreateAndDeleteLocalGroup()
        {
            // Bind to local computer
            DirectoryEntry localComputer =
                new DirectoryEntry(
                            "WinNT://" + localComputerName + ",computer");

            // Create new group using Add method of Children collection
            DirectoryEntry newGroup = localComputer.Children.Add(
                                                    newGroupName, "group");
            // Commit the group to the directory
            newGroup.CommitChanges();
            Console.WriteLine("Group created!");

            // Add existing user to new group
            newGroup.Invoke("Add", new object[] { 
                   "WinNT://" + localComputerName + "/" + existingUserName } );
            Console.WriteLine("User added to group!");

            // Dispose group DirectoryEntry object
            newGroup.Dispose();
            
            // Now delete recently created group
            // Once group deleted  user will also have group out of member of
            DeleteGroup(localComputer, newGroupName);
            Console.WriteLine("Group deleted! User no longer in group!");
        }

        static void DeleteGroup(DirectoryEntry computer, string groupName)
        {
            // Bind to group object to delete
            DirectoryEntry groupToDelete =
                new DirectoryEntry("WinNT://" + localComputerName + "/" +
                                    groupName + ",group");
            // Delete it calling Remove method of DirectoryEntries object
            computer.Children.Remove(groupToDelete);
        }

    } // End class CreateAndDeleteLocalGroupSample
}
