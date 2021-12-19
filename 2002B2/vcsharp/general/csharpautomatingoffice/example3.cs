//Copyright 2001, Microsoft Corporation
//All rights reserved
//
//  Build this example with
//
//    csc /r:word.dll example3.cs
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
        Application  app = new Application();
        //Make sure that Word will be visible
        app.Visible=true;
        // Open the existing document "example3.doc"
        // Setting these variables to Missing.Value is comparable to passing
        // null to the function. This is necessary because the C# null cannot
        // be passed by reference.
        object fileName = Environment.CurrentDirectory+"\\example3";
        object confirmConversions=Missing.Value;
        object readOnly=Missing.Value;
        object addToRecentFiles=Missing.Value;
        object passwordDocument=Missing.Value;
        object passwordTemplate=Missing.Value;
        object revert=Missing.Value;
        object writePasswordDocument=Missing.Value;
        object writePasswordTemplate=Missing.Value;
        object format=Missing.Value;
        object encoding=Missing.Value;
        object visible=true;
        _Document doc = app.Documents.Open(	ref fileName,
        									ref confirmConversions,
        									ref readOnly,
        									ref addToRecentFiles,
        									ref passwordDocument,
        									ref passwordTemplate,
        									ref revert,
        									ref writePasswordDocument,
        									ref writePasswordTemplate,
        									ref format,
        									ref encoding,
        									ref visible);

        Thread.Sleep (2000);  //Display the opened document for 5 seconds
        object first=0;
        object last=doc.Characters.Count;
        //Select all the characters in the document
        doc.Range(ref first, ref last).Select();
        Thread.Sleep (2000);  //Display the slection for 5 seconds
        //Now cut the selected text
        doc.Range(ref first, ref last).Cut();
        Thread.Sleep (3000);  //Wait for 5 more seconds

		//Save the file, use default values except for filename
        object fileFormat = Missing.Value;
        object lockComments = Missing.Value;
        object password = Missing.Value;
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


