//Copyright 2001, Microsoft Corporation
//All rights reserved
//
//  Build this example with
//
//    csc /r:word.dll example2.cs
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
        //Set up to create a plain, empty text document
        // Setting these variables to Missing.Value is comparable to passing
        // null to the function. This is necessary because the C# null cannot
        // be passed by reference.
        object template=Missing.Value;
        object newTemplate=Missing.Value;
        object documentType=Missing.Value;
        object visible=true;
        _Document doc = app.Documents.Add(ref template, ref newTemplate, ref documentType, ref visible);

        Thread.Sleep (5000);  //Display the empty document for 5 seconds
        doc.Words.First.InsertBefore ("This document is no longer empty!");
        Thread.Sleep (5000);  //Wait for 5 more seconds

		//Save the file, use default values except for filename
        object fileName = Environment.CurrentDirectory+"\\example2";
        object fileFormat = Missing.Value;
        object lockComments = Missing.Value;
        object password = Missing.Value;
        object addToRecentFiles = Missing.Value;
        object writePassword = Missing.Value;
        object readOnlyRecommended = Missing.Value;
        object embedTrueTypeFonts = Missing.Value;
        object saveNativePictureFormat = Missing.Value;
        object saveFormsData = Missing.Value;
        object saveAsAOCELetter = Missing.Value;
        doc.SaveAs (ref fileName, ref fileFormat, ref lockComments, ref password,
            ref addToRecentFiles, ref writePassword, ref readOnlyRecommended,
            ref embedTrueTypeFonts, ref saveNativePictureFormat, ref saveFormsData, ref saveAsAOCELetter);

        // Now use the Quit method to cleanup like a good citizen
        object saveChanges = true;
        object originalFormat = Missing.Value;
        object routeDocument = Missing.Value;
        app.Quit(ref saveChanges, ref originalFormat, ref routeDocument);
        return 0;
        }
    }


