// pinvoke.cs
// compile with: /addmodule:logfont.netmodule
// csc pinvoke.cs /addmodule:logfont.netmodule
using System;
using System.Runtime.InteropServices;

class PlatformInvokeTest
{   
    [DllImport("gdi32.dll", CharSet=CharSet.Auto)]
    public static extern int CreateFontIndirect(
        [In, MarshalAs(UnmanagedType.LPStruct)]
        LOGFONT lplf   // characteristics
    );
    public static void Main() 
    {
        LOGFONT lf = new LOGFONT();
        lf.lfHeight = 9;
        lf.lfFaceName = "Arial";
        int i = CreateFontIndirect(lf);
        Console.WriteLine("{0:X}", i);
    }
}
