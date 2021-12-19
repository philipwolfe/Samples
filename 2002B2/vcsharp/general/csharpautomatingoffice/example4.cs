//Now hook some events on file open and close

//Copyright 2001, Microsoft Corporation
//All rights reserved
//
//  Build this example with
//
//    csc /r:word.dll example4.cs
//Hooking COM events

using System;
using System.Threading;
using System.Reflection;
using System.Windows.Forms;
using Word;

public class MainClass
{
    public static void DocNew (_Document doc)
    {
    	MessageBox.Show ("We have a new Doc!!!");
    }
    public static void DocChange ()
    {
    	MessageBox.Show ("Current doc has changed.");
    }
    public static void Startup ()
    {
    	MessageBox.Show ("Word is starting up");
    }
    public static void MyOpenEventHandler(_Document doc)
    {
    	MessageBox.Show ("A document is being opened");
    }
    public static int Main (string[] argv)
    {
        Word.Application app = new Word.Application();
        app.Visible = true;
        //Make sure that Word will be visible
        app.Visible=true;
        // Add event handlers for New, Open, Change, Startup, and Quit events
		ApplicationEvents2_NewDocumentEventHandler myNewDoc = new
			ApplicationEvents2_NewDocumentEventHandler(DocNew);
		app.NewDocument += myNewDoc;
		ApplicationEvents2_DocumentOpenEventHandler myOpenDoc = new
			ApplicationEvents2_DocumentOpenEventHandler(MyOpenEventHandler);
		app.DocumentOpen += myOpenDoc;
		ApplicationEvents2_DocumentChangeEventHandler myChangeDoc = new
			ApplicationEvents2_DocumentChangeEventHandler(DocChange);
		app.DocumentChange += myChangeDoc;
		ApplicationEvents2_StartupEventHandler myStartup = new
			ApplicationEvents2_StartupEventHandler(Startup);
		app.Startup += myStartup;

        //Set up to open an existing document
        // Setting these variables to Missing.Value is comparable to passing
        // null to the function. This is necessary because the C# null cannot
        // be passed by reference.
        object fileName = Environment.CurrentDirectory+"\\example4";
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

        Thread.Sleep (2000);  //Display the opened document for 2 seconds

        //Select all the text in the document, display the selection for
        //a few seconds, then cut the selection
        object first=0;
        object last=doc.Characters.Count;
        doc.Range(ref first, ref last).Select();
        Thread.Sleep (2000);  //Display the empty document for 2 seconds
        doc.Range(ref first, ref last).Cut();
        Thread.Sleep (3000);  //Wait for 3 more seconds

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


