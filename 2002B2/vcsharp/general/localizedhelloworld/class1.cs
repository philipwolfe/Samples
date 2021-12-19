//Copyright (C) 2000 Microsoft Corporation.  All rights reserved.

//This source code is intended only as a supplement to Microsoft
//Development Tools and/or on-line documentation.  See these other
//materials for detailed information regarding Microsoft code samples.

//THIS CODE AND INFORMATION ARE PROVIDED "AS IS" WITHOUT WARRANTY OF ANY
//KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE
//IMPLIED WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A
//PARTICULAR PURPOSE.

namespace HelloWorld
{
    using System;

    /// <summary>
    ///    Summary description for Class1.
    /// </summary>
    public class Class1
    {
        public Class1()
        {
            //
            // TODO: Add Constructor Logic here
            //
        }

        public static int Main(string[] args)
        {
			// Override the default user culture with the neutral culture
			System.Threading.Thread.CurrentThread.CurrentUICulture = System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo(""); // Force the default culture
			do 
			{
				// Get a resource manager
				System.Resources.ResourceManager resources = new System.Resources.ResourceManager("HelloWorld.Resources.MyResources", System.Reflection.Assembly.GetExecutingAssembly());

				// Print out the "HelloWorld" resource string
				Console.WriteLine(resources.GetString("HelloWorld"));
				
				// Get the new culture name
				Console.WriteLine(resources.GetString("NextCulture"));
				string NewCulture = Console.ReadLine();

				// Switch to the desired culture
				System.Globalization.CultureInfo c = new System.Globalization.CultureInfo(NewCulture, false); 
				System.Threading.Thread.CurrentThread.CurrentUICulture = System.Threading.Thread.CurrentThread.CurrentCulture = c;
			} while (true);
        }
    }
}
