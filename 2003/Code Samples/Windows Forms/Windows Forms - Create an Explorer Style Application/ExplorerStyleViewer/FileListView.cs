//Copyright (C) 2002 Microsoft Corporation
//All rights reserved.
//THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, EITHER 
//EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED WARRANTIES OF 
//MERCHANTIBILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
//Requires the Trial or Release version of Visual Studio .NET Professional (or greater).

using System;
using System.Diagnostics; // For Process.Start
using System.IO;
using System.Windows.Forms;
using System.Drawing;

class FileListView: ListView
{
    private string strDirectory;

    // This is the class constructor.

    public FileListView () {

        // Set the default View enumeration to Details.

        this.View = View.Details;

        // Get images icons for some of the common file types.

        ImageList img = new ImageList();
        img.Images.Add(new Bitmap(@"..\..\ExplorerStyleViewer\DOC.BMP"));
        img.Images.Add(new Bitmap(@"..\..\ExplorerStyleViewer\EXE.BMP"));

        // The Small and Large image lists for the ListView use the same set of
        // images.

        this.SmallImageList = img;
        this.LargeImageList = img;

        // Create the columns.

            Columns.Add("Name", 100, HorizontalAlignment.Left);
            Columns.Add("Size", 100, HorizontalAlignment.Right);
            Columns.Add("Modified", 100, HorizontalAlignment.Left);
            Columns.Add("Attribute", 100, HorizontalAlignment.Left);
    }

    // override the base class OnItemActivate event handler. Extends the base
    // class implementation to run any .exe or file with an associated executable.

    protected override void OnItemActivate(EventArgs ea)
	{

        base.OnItemActivate(ea);

		foreach(ListViewItem lvi in SelectedItems)
		{

			try 
			{

				Process.Start(Path.Combine(strDirectory, lvi.Text));

			} 
			catch
			{
				// Do nothing. Just pass to Next lvi.
				break;
			}
		}

    }

    // This subroutine is used to display a list of all files in the directory
    // currently selected by the user from the custom TreeView control.

    public void ShowFiles(string strDirectory)
	{

        // Save the directory name a field.

        this.strDirectory = strDirectory;
        Items.Clear();
        DirectoryInfo diDirectories = new DirectoryInfo(strDirectory);
        FileInfo[] afiFiles;
        try {

            // Call the convenient GetFiles method to get an array of all files
            // in the directory.
            afiFiles = diDirectories.GetFiles();

        } catch 
		{
            return;
        }

		foreach(FileInfo fi in afiFiles)
		{
			// Create ListViewItem.
			ListViewItem lvi = new ListViewItem(fi.Name);
			// Assign ImageIndex based on filename extension.
			switch( Path.GetExtension(fi.Name).ToUpper())
			{
				case ".EXE":
				{
					lvi.ImageIndex = 1;
					break;
				}
				default: 
				{
					lvi.ImageIndex = 0;
					break;
				}
			}

			// Add file length and last modified time sub-items.

			lvi.SubItems.Add(fi.Length.ToString("N0"));
			lvi.SubItems.Add(fi.LastWriteTime.ToString());

			// Add attribute subitem.

			string strAttr = string.Empty;

			if ((fi.Attributes & FileAttributes.Archive) != 0) 
			{
				strAttr += "A";
			}

			if ((fi.Attributes & FileAttributes.Hidden) != 0) 
			{
				strAttr += "H";
			}

			if ((fi.Attributes & FileAttributes.ReadOnly) != 0) 
			{
				strAttr += "R";
			}

			if ((fi.Attributes & FileAttributes.System) != 0) 
			{
				strAttr += "S";
			}

			lvi.SubItems.Add(strAttr);

			// Add completed ListViewItem to FileListView.

			Items.Add(lvi);

		}

    }

}

