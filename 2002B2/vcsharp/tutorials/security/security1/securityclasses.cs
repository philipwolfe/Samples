// Security\SecurityClasses.cs
using System;
using System.Security;
using System.Security.Permissions;
using System.Runtime.InteropServices;

class NativeMethods
{
    // This is a call to unmanaged code. Executing this method requires 
    // the UnmanagedCode security permission. Without this permission
    // an attempt to call this method will throw a SecurityException:
    [DllImport("user32.dll")]
    public static extern int MessageBox(uint hWnd, string lpText, 
       string lpCaption, uint uType);
}

class MainClass
{
    private static void CallUnmanagedCodeWithoutPermission()
    {
        // Create a security permission object to describe the
        // UnmanagedCode permission:
        SecurityPermission perm = 
           new SecurityPermission(SecurityPermissionFlag.UnmanagedCode);

        // Remove the UnmanagedCode from our current set of permissions:
        perm.Deny();

        try
        {
            Console.WriteLine("Attempting to call unmanaged code without permission.");
            NativeMethods.MessageBox(0, "Hello World!", "", 0);
            Console.WriteLine("Called unmanaged code without permission. Whoops!");
        }
        catch (SecurityException)
        {
            Console.WriteLine("Caught Security Exception attempting to call unmanaged code.");
        }
    }

    private static void CallUnmanagedCodeWithPermission()
    {
        // Create a security permission object to describe the
        // UnmanagedCode permission:
        SecurityPermission perm = 
           new SecurityPermission(SecurityPermissionFlag.UnmanagedCode);

        // Add the UnmanagedCode to our current set of permissions:
        perm.Assert();

        try
        {
            Console.WriteLine("Attempting to call unmanaged code with permission.");
            NativeMethods.MessageBox(0, "Hello World!", "", 0);
            Console.WriteLine("Called unmanaged code with permission.");
        }
        catch (SecurityException)
        {
            Console.WriteLine("Caught Security Exception attempting to call unmanaged code. Whoops!");
        }
    }

    public static void Main() 
    {
        CallUnmanagedCodeWithoutPermission();
        CallUnmanagedCodeWithPermission();
    }
}
