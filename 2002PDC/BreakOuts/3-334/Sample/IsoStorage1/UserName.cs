/*+==========================================================================
  File:      UserName.cs

  Summary:   User name is persisted in Assembly store and is accessible between 
             invocation of this executable. A public Method 'GetUserName' is
             provided, which can be used by other applications. This application
             does not require FileIOPermission to execute.
 
  Classes:   UserName

  Functions: GetUserName
             
  Author:    Shajan Dasan (shajand@microsoft.com)

  Date:      21 July 2000

----------------------------------------------------------------------------
  This file is part of the Microsoft .NET Samples.

  Copyright (C) 1998-2000 Microsoft Corporation.  All rights reserved.
==========================================================================+*/

using System;
using System.IO;
using System.IO.IsolatedStorage;

namespace Sample
{
    public class UserName
    {
        // Isolated Storage File name where user data is stored
        const String c_FileName = "User.dat";
    
        // Command line options
        const String c_Reset = "/Reset";
    
        // Command line help
        const String c_Usage = 
            "Usage :\n\n" +
            "Username [" + c_Reset + "]\n"+
            c_Reset + " : Clear persisted user name.";
    
    
        // User name used by this application.
        private String sUserName;
    
        static void Main(String[] args)
        {
            String sUserInput = null;
    
            // Get the command line options.
    
            for (int i = 0; i < args.Length; ++i)
            {
                if (String.Compare(args[i], c_Reset, true) == 0)
                {
                    GetUserName(true);
                    return;
                }
                else
                {
                    // Unknown command like option, print usage and exit
    
                    Console.WriteLine(c_Usage);
                    return;
                }
            }
    
            // Get user input. If cached information is available in isolated 
            // storage, use it.
    
            sUserInput = GetUserName(false);
    
            // Use the user input in this application.
    
            UserName un = new UserName(sUserInput);
    
            un.Execute();
        }
    
        ////////////////////////////////////////////////////////////////////////
        // Returns user name
        //
        // If this information is available in isolated storage, the user is not
        // prompted. If this information is not available in isolated store,
        // the user name is obtained from the user and this information is 
        // saved in a file in isolated storage.
        //
        // All applications using this API will be using the same cached data.
        //
        ////////////////////////////////////////////////////////////////////////
    
        private static String GetUserName(bool fReset)
        {
            IsolatedStorageFileStream fs;
            IsolatedStorageFile isf;
            String sUserInput = null;
    
            // Get the store for this assembly. 
    
            isf = IsolatedStorageFile.GetUserStoreForAssembly();
    
            if (fReset)
            {
                // Remove old persisted information.
    
                try {
    
                    isf.DeleteFile(c_FileName);
    
                } catch (Exception) {
                    // Ok to ignore this error, the file may not be present.
                }

                return null;
            }
    
            try {
    
                // Open file stream in isolated store
    
                fs =  new IsolatedStorageFileStream(
                    c_FileName,
                    FileMode.OpenOrCreate, 
                    isf);
    
                // Get the first line out of the file as a string
    
                StreamReader sr = new StreamReader(fs);
                sUserInput = sr.ReadLine();
    
                if (sUserInput == null || sUserInput.Equals(""))
                {
    
                    // Get input from user, at the console.
    
                    Console.Write("Name : ");
                    sUserInput = Console.ReadLine();
    
                    // Save user input
    
                    StreamWriter sw = new StreamWriter(fs);
                    sw.WriteLine(sUserInput);
                    sw.Close();                 // Implicit fs.Close()
    
                }
                else
                {
    
                    // Using information cached in isolated store
    
                    sr.Close();                 // Implicit fs.Close()
                }
    
            } catch (Exception e) {
                // Handle error..
    
                Console.Write("Error ! " + e);
                throw;
            }
    
            return sUserInput;
        }
    
        // Public API, no option to reset

        public static String GetUserName()
        {
            return GetUserName(false);
        }
    
        // This is the application logic, which prints the user name.
    
        private UserName(String sUserInput)
        {
            sUserName = sUserInput;
        }
    
        void Execute()
        {
            // Do something useful here..
            // For now, just print the user name.
    
            Console.Write("User name : ");
            Console.WriteLine(sUserName);
        }
    }
}

