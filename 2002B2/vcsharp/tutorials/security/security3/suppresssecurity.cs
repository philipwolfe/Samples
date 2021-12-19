// SuppressSecurity.cs
using System;
using System.Security;
using System.Security.Permissions;
using System.Runtime.InteropServices;

class NativeMethods
{
    // This is a call to unmanaged code. Executing this method requires 
    // the UnmanagedCode security permission. Without this permission,
    // an attempt to call this method will throw a SecurityException:
    /* NOTE: The SuppressUnmanagedCodeSecurityAttribute disables the
       check for the UnmanagedCode permission at runtime. Be Careful! */
    [SuppressUnmanagedCodeSecurityAttribute()]
    [DllImport("msvcrt.dll")]
    internal static extern int puts(string str);
    [SuppressUnmanagedCodeSecurityAttribute()]
    [DllImport("msvcrt.dll")]
    internal static extern int _flushall();
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
            // The UnmanagedCode security check is disbled on the call
            // below. However, the unmanaged call only displays UI. The 
            // security will be ensured by only allowing the unmanaged 
            // call if there is a UI permission:
            UIPermission uiPermission = 
               new UIPermission(PermissionState.Unrestricted);
            uiPermission.Demand();

            Console.WriteLine("Attempting to call unmanaged code without UnmanagedCode permission.");
            NativeMethods.puts("Hello World!");
            NativeMethods._flushall();
            Console.WriteLine("Called unmanaged code without UnmanagedCode permission.");
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
