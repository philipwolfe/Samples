//-----------------------------------------------------------------------
//  This file is part of the Microsoft .NET Framework SDK Code Samples.
// 
//  Copyright (C) Microsoft Corporation.  All rights reserved.
// 
//This source code is intended only as a supplement to Microsoft
//Development Tools and/or on-line documentation.  See these other
//materials for detailed information regarding Microsoft code samples.
// 
//THIS CODE AND INFORMATION ARE PROVIDED AS IS WITHOUT WARRANTY OF ANY
//KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE
//IMPLIED WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A
//PARTICULAR PURPOSE.
/*=====================================================================
  File:      Permissions.cs

  Summary:   Demonstrates how use code access security.

=====================================================================*/


// Add the classes in the following namespaces to our namespace
using System;
using System.IO;
using System.Security.Permissions;
using System.Security;


///////////////////////////////////////////////////////////////////////////////
namespace Microsoft.Samples.CAS.Permissions
{

    // This class represents the application itself
    class App 
    {
        public static void Main() 
        {

            // Try to access resources using the permissions currently available.
            AttemptAccess("Default permissions");

            // Create a permission set that allows read access to the TEMP 
            // environment variable and read, write, and append access to SomeFile
            PermissionSet ps = new PermissionSet(PermissionState.None);
            ps.AddPermission(
                new EnvironmentPermission(EnvironmentPermissionAccess.Read, "TEMP"));
            ps.AddPermission(
                new FileIOPermission(FileIOPermissionAccess.Read | 
                FileIOPermissionAccess.Write | FileIOPermissionAccess.Append, 
                Path.GetFullPath("SomeFile")));

            // Use caution in asserting permissions in publicly callable code without
            // any kind of check on the caller.  There is a danger of the assert being
            // used to exploit a downstream caller by stopping its security check, 
            // allowing the malicious code access to unauthorized resources.
            // Stop security checks at this point in the stack walk
            // for the specified permissions
            ps.Assert();

            // Try to access resources using the permissions we've just asserted.
            AttemptAccess("Assert permissions");

            // Remove this stack frame's Assert
            CodeAccessPermission.RevertAssert();

            // Deny access to the resources we specify
            ps.Deny();

            // Try to access resources using the permissions we've just denied.
            AttemptAccess("Deny permissions");

            // Remove this stack frame's Deny so we're back to default permissions.
            CodeAccessPermission.RevertDeny();

            // Make the permissions indicate the only things that we're allowed to do.
            ps.PermitOnly();

            // Try to access resources using only the permissions we've just permitted.
            AttemptAccess("PermitOnly permissions");

            // Remove this stack frame's PermitOnly so we're back to default permissions.
            CodeAccessPermission.RevertPermitOnly();

            // Remove the FileIOPermissions from the permission set
            ps.RemovePermission(typeof(FileIOPermission));

            // Try to access resources using only the Environment permissions.
            ps.PermitOnly();
            AttemptAccess("PermitOnly without FileIOPermission permissions");
            CodeAccessPermission.RevertPermitOnly();

            // Remove the EnvironmentPermission from the permission set
            ps.RemovePermission(typeof(EnvironmentPermission));

            // Try to access resources using no permissions.
            ps.PermitOnly();
            AttemptAccess("PermitOnly without any permissions");
            CodeAccessPermission.RevertPermitOnly();

            // Show how to use Demand/Assert to improve performance
            CopyFile(".\\Permissions.exe", ".\\Permissions.copy.exe");

            // Delete .exe copy
            File.Delete(".\\Permissions.copy.exe");
        }


        static public void AttemptAccess(String s) 
        {
            FileStream fs = null;
            String ev = null;
            String attemptResult = s + " test: ";

            // Try to access a file
            try 
            {
                fs = new FileStream("SomeFile", FileMode.OpenOrCreate); 
            }
            catch (SecurityException)
            { 
                // Handle exception appropriately - for this sample, we will
                // simply ignore the exception
            }
            finally
            {
                if (fs != null)
                {
                    attemptResult += "File opened, ";
                    fs.Close();
                    File.Delete("SomeFile");
                }
                else
                    attemptResult += "File NOT opened, ";
            }

            // Try to read an environment variable
            try
            {
                ev = Environment.GetEnvironmentVariable("TEMP");
            }
            catch (SecurityException)
            {
                // Handle exception appropriately - for this sample, we will
                // simply ignore the exception
            }
            finally
            {
                if (ev != null)
                    attemptResult += "Environment variable read";
                else
                    attemptResult += "Environment variable NOT read";
            }

            Console.WriteLine(attemptResult);
        }


        public static void CopyFile(String srcPath, String dstPath) 
        {

            // Create a file permission set indicating all of this method's intentions.
            FileIOPermission fp = new FileIOPermission(FileIOPermissionAccess.Read, Path.GetFullPath(srcPath));
            fp.AddPathList(FileIOPermissionAccess.Write | FileIOPermissionAccess.Append, Path.GetFullPath(dstPath));

            // Verify that we can be granted all the permissions we'll need.
            fp.Demand();

            // Assert the desired permissions here.
            fp.Assert();

            // For the remainder of this method, demands for source file read access
            // and demands for destination file write/append access will be granted
            // immediately; walking the remainder of the stack will not be necessary.
            FileInfo srcFile = new FileInfo(srcPath);
            FileInfo dstFile = new FileInfo(dstPath);
            Stream src = srcFile.Open(FileMode.Open, FileAccess.Read, FileShare.Read);
            Stream dst = dstFile.Open(FileMode.Create, FileAccess.Write, FileShare.None);

            // Note: FileInfo.Length is a Int64, but the Stream.Read and .Write
            // take Int32 counts - hence the casting/throttling necessary below
            if (srcFile.Length > Int32.MaxValue)
                throw new ArgumentOutOfRangeException("CopyFile requires that the source file be less than 2GB.");
            Byte[] buffer = new Byte[(Int32) srcFile.Length];
            src.Read(buffer, 0, (Int32) srcFile.Length);
            dst.Write(buffer, 0, (Int32) srcFile.Length);

            src.Close();
            dst.Close();

            // We do not need a RevertAssert here because we are going out of scope
        }
    }
}
///////////////////////////////// End of File /////////////////////////////////
