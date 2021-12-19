// Pinvoke\MessageBox.cs
using System;
using System.Runtime.InteropServices;

class PlatformInvokeTest
{
    [DllImport("user32.dll")]
    public static extern int MessageBoxA(
        int h, string m, string c, int type);
    public static int Main() 
    {
        return MessageBoxA(0, "Hello World!", "My Message Box", 0);
    }
}
