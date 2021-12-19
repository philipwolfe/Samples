//Copyright 2001, Microsoft Corporation
//All rights reserved
//
//  Build this tool with
//
//    csc /r:system.dll CreateWordAssembly.cs
//
//  This tool will create the import assembly for Word
//

using System;
using System.Diagnostics;
using System.Text;
using Microsoft.Win32;

public class MainClass
{
	public static int Main ()
	{
		int retval = 1;
		try
		{
			RegistryKey rk = Registry.ClassesRoot.OpenSubKey ("Word.Document.8\\shell\\new\\command");
			if (null != rk)
			{
				string wordCommandKeyValue = (string)rk.GetValue("");
				rk.Close();
				//  This is a slow, but easy to understand way of getting the Word path into a string
				StringBuilder olbLocation = new StringBuilder(255);
				for (int i=1; i < wordCommandKeyValue.Length && wordCommandKeyValue[i] != '"'; i++)
				{
				    olbLocation.Append (wordCommandKeyValue[i]);
				}
				if (olbLocation.Length < 4)
				{
				    Console.WriteLine ("The classes_root key Word.Document.8\\shell\\new\\command may be bad.  Can't find winword.olb.");
				    retval = -2;
				} else {
				    //Now replace "winword.exe" with "msword9.olb" in the 
				    olbLocation.Remove (olbLocation.Length-"winword.exe".Length, "winword.exe".Length);
				    olbLocation.Append ("msword9.olb");
				    Console.WriteLine (olbLocation.ToString());
				    Process tlbimp = new Process();
                    tlbimp.StartInfo.FileName = "tlbimp.exe";
                    tlbimp.StartInfo.Arguments = "\""+olbLocation.ToString()+"\"";
                    tlbimp.StartInfo.CreateNoWindow = true;
                    tlbimp.StartInfo.RedirectStandardOutput = true;
                    tlbimp.StartInfo.UseShellExecute = false;
                    tlbimp.Start ();
                    tlbimp.WaitForExit();
                    string results = tlbimp.StandardOutput.ReadToEnd();
                    Console.WriteLine (results);
    				retval = tlbimp.ExitCode;
				}
			}
			else Console.WriteLine("Word is not installed.");
		}
		catch (Exception e)
		{
			Console.WriteLine ("Caught unexpected "+e.ToString());
			retval = -1;
		}
		if (0 == retval) Console.WriteLine ("SUCCESS");
		else Console.WriteLine ("FAILED to create Word interface assembly");
		return retval;
	}
}

