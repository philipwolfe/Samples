// DeclarativeSecurity.cs
using System;
using System.Security;
using System.Security.Permissions;
using System.Runtime.InteropServices;

class NativeMethods
{
    // This is a call to unmanaged code. Executing this method requires 
    // the UnmanagedCode security permission. Without this permission,
    // an attempt to call this method will throw a SecurityException:
    [DllImport("msvcrt.dll")]
    public static extern int puts(string str);
    [DllImport("msvcrt.dll")]
    internal static extern int _flushall();
}

class MainClass
{
    // The security permission attached to this method will deny the
    // UnmanagedCode permission from the current set of permissions for
    // the duration of the call to this method:
    [SecurityPermission(SecurityAction.Deny, Flags = 
       SecurityPermissionFlag.UnmanagedCode)]
    private static void CallUnmanagedCodeWithoutPermission()
    {
        try
        {
            Console.WriteLine("Attempting to call unmanaged code without permission.");
            NativeMethods.puts("Hello World!");
            NativeMethods._flushall();
            Console.WriteLine("Called unmanaged code without permission. Whoops!");
        }
        catch (SecurityException)
        {
            Console.WriteLine("Caught Security Exception attempting to call unmanaged code.");
        }
    }

    // The security permission attached to this method will force a 
    // runtime check for the unmanaged code permission whenever
    // this method is called. If the caller does not have unmanaged code
    // permission, then the call will generate a Security Exception.
    [SecurityPermission(SecurityAction.Assert, Flags = 
       SecurityPermissionFlag.UnmanagedCode)]
    private static void CallUnmanagedCodeWithPermission()
    {
        try
        {
            Console.WriteLine("Attempting to call unmanaged code with permission.");
            NativeMethods.puts("Hello World!");
            NativeMethods._flushall();
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
