//Copyright 2001, Microsoft Corporation
//All rights reserved
//
//  Build this example with
//
//    csc /r:word.dll example1.cs
//

using System;
using System.Threading;
using System.Reflection;
using Word;

public class MainClass
    {
    public static int Main (string[] argv)
        {
        //This is comparable to CoCreateInstance 
        Application app = new Application();  
        //Make sure that Word will be visible
        app.Visible=true;
        Thread.Sleep (3000);  //Wait for 3 seconds
        // Now use the Quit method to cleanup like a good citizen
        // Setting these variables is comparable to passing null to the function.
        // This is necessary because the C# null cannot be passed by reference.
        object saveChanges = Missing.Value;
        object originalFormat = Missing.Value;
        object routeDocument = Missing.Value;
        app.Quit(ref saveChanges, ref originalFormat, ref routeDocument);
        return 0;
        }
    }


