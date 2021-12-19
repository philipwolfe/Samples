// Security\SecurityAttributes.cs
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
    // The security permission attached to this method will remove the
    // UnmanagedCode permission from the current set of permissions for
    // the duration of the call to this method:
    [SecurityPermission(SecurityAction.Deny, Flags = 
       SecurityPermissionFlag.UnmanagedCode)]
    private static void CallUnmanagedCodeWithoutPermission()
    {
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

    // The security permission attached to this method will add the
    // UnmanagedCode permission to the current set of permissions for the
    // duration of the call to this method:
    [SecurityPermission(SecurityAction.Assert, Flags = 
       SecurityPermissionFlag.UnmanagedCode)]
    private static void CallUnmanagedCodeWithPermission()
    {
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
