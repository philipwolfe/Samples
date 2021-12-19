// printversion.cs
// compile with: /unsafe
using System;
using System.Reflection;
using System.Runtime.InteropServices;

// Give this assembly a version number:
[assembly:AssemblyVersion("4.3.2.1")]

public class Win32Imports 
{
   [DllImport("version.dll")]
   public static extern bool GetFileVersionInfo (string sFileName,
      int handle, int size, byte[] infoBuffer);
   [DllImport("version.dll")]
   public static extern int GetFileVersionInfoSize (string sFileName,
      out int handle);
   
   // The 3rd parameter - "out string pValue" - is automatically
   // marshaled from Ansi to Unicode:
   [DllImport("version.dll")]
   unsafe public static extern int VerQueryValue (byte[] pBlock,
      string pSubBlock, out string pValue, out uint len);
   // This VerQueryValue overload is marked with 'unsafe' because 
   // it uses a short*:
   [DllImport("version.dll")]
   unsafe public static extern int VerQueryValue (byte[] pBlock,
      string pSubBlock, out short *pValue, out uint len);
}

public class C 
{
   // Main is marked with 'unsafe' because it uses pointers:
   unsafe public static int Main () 
   {
      try 
      {
         int handle = 0;
         // Figure out how much version info there is:
         int size =
            Win32Imports.GetFileVersionInfoSize("printversion.exe",
            out handle);
         // Be sure to allocate a little extra space for safety:
         byte[] buffer = new byte[size+2];
         Win32Imports.GetFileVersionInfo ("printversion.exe", 
            handle, size, buffer);
         short *subBlock = null;
         uint len = 0;
         // Get the locale info from the version info:
         Win32Imports.VerQueryValue (buffer,
            "\\VarFileInfo\\Translation", out subBlock, out len);
         string spv =
            "\\StringFileInfo\\" + subBlock[0].ToString("X4")
            + subBlock[1].ToString("X4") + "\\ProductVersion";
         byte *pVersion = null;
         // Get the ProductVersion value for this program:
         string versionInfo;
         Win32Imports.VerQueryValue (buffer, spv,
            out versionInfo, out len);
         Console.WriteLine ("ProductVersion == {0}", versionInfo);
      }
      catch (Exception e) 
      {
         Console.WriteLine ("Caught unexpected exception " + 
            e.ToString() + "\n\n" + e.Message);
      }
      
      return 0;
   }
}
