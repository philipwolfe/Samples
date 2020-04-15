//Copyright (C) 2002 Microsoft Corporation
//All rights reserved.
//THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, EITHER 
//EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED WARRANTIES OF 
//MERCHANTIBILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
//Requires the Trial or Release version of Visual Studio .NET Professional (or greater).

using System;
using System.Windows.Forms;

// This class is needed because the 
// System.Windows.Forms.Design.FolderNameEditor.FolderBrowser is protected and thus 
// is not accessible in this context. Deriving a public class from it enables you to
// use the dialog in your code.

public class FolderBrowser: System.Windows.Forms.Design.FolderNameEditor
{

    public static string ShowDialog()
	{

        FolderBrowser fb = new FolderBrowser();
        fb.Description = "Select a Directory to Scan";
        fb.Style = System.Windows.Forms.Design.FolderNameEditor.FolderBrowserStyles.RestrictToFilesystem;
        fb.ShowDialog();
        return fb.DirectoryPath;
    }
}