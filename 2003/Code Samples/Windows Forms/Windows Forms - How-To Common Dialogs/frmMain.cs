//Copyright (C) 2002 Microsoft Corporation
//All rights reserved.
//THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, EITHER 
//EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED WARRANTIES OF 
//MERCHANTIBILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
//Requires the Trial or Release version of Visual Studio .NET Professional (or greater).

using System;
using System.Windows.Forms;
using System.IO;

public class frmMain:System.Windows.Forms.Form 
{
	//int CustomColors()= {RGB(255, 0, 0), RGB(0, 255, 0), RGB(0, 0, 255)}
	int[] CustomColors = {255,65280 ,16711680};
	[STAThread]
	static void Main() 
	{
		Application.Run(new frmMain());
	}

	#region " Windows Form Designer generated code "

	public frmMain() 
	{

		

		//This call is required by the Windows Form Designer.

		InitializeComponent();

		//Add any initialization after the InitializeComponent() call

		// So that we only need to set the title of the application once,

		// we use the AssemblyInfo class (defined in the AssemblyInfo.cs file)

		// to read the AssemblyTitle attribute.

		AssemblyInfo ainfo = new AssemblyInfo();

		this.Text = ainfo.Title;

		this.mnuAbout.Text = string.Format("&About {0} ...", ainfo.Title);

	}

	//Form overrides dispose to clean up the component list.

	protected override void Dispose(bool disposing) 
	{

		if (disposing) 
		{

			if (components != null) 
			{

				components.Dispose();

			}

		}

		base.Dispose(disposing);

	}

	//Required by the Windows Form Designer

	private System.ComponentModel.IContainer components = null;

	//NOTE: The following procedure is required by the Windows Form Designer

	//It can be modified using the Windows Form Designer.  

	//Do ! modify it using the code editor.

	private System.Windows.Forms.MainMenu mnuMain;

	private System.Windows.Forms.MenuItem mnuFile;

	private System.Windows.Forms.MenuItem mnuExit;

	private System.Windows.Forms.MenuItem mnuHelp;

	private System.Windows.Forms.Button btnSelectFont;

	private System.Windows.Forms.Button btnSelectColor;

	private System.Windows.Forms.TextBox txtFileContents;

	private System.Windows.Forms.ListBox lstFiles;

	private System.Windows.Forms.MenuItem mnuAbout;

	private System.Windows.Forms.OpenFileDialog odlgTextFile;

	private System.Windows.Forms.SaveFileDialog sdlgTextFile;

	private System.Windows.Forms.Button btnSaveTextFile;

	private System.Windows.Forms.Button btnOpenTextFile;

	private System.Windows.Forms.FontDialog fdlgText;

	private System.Windows.Forms.TabControl tabOptions;

	private System.Windows.Forms.TabPage pgeOpenSaveFile;

	private System.Windows.Forms.TabPage pgeOpenMultipleFiles;

	private System.Windows.Forms.ColorDialog cdlgText;

	private System.Windows.Forms.Button btnRetriveFileNames;

	private System.Windows.Forms.OpenFileDialog odlgFileNames;

	private void InitializeComponent() 
	{

		System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(frmMain));

		this.mnuMain = new System.Windows.Forms.MainMenu();

		this.mnuFile = new System.Windows.Forms.MenuItem();

		this.mnuExit = new System.Windows.Forms.MenuItem();

		this.mnuHelp = new System.Windows.Forms.MenuItem();

		this.mnuAbout = new System.Windows.Forms.MenuItem();

		this.sdlgTextFile = new System.Windows.Forms.SaveFileDialog();

		this.fdlgText = new System.Windows.Forms.FontDialog();

		this.odlgFileNames = new System.Windows.Forms.OpenFileDialog();

		this.cdlgText = new System.Windows.Forms.ColorDialog();

		this.odlgTextFile = new System.Windows.Forms.OpenFileDialog();

		this.tabOptions = new System.Windows.Forms.TabControl();

		this.pgeOpenSaveFile = new System.Windows.Forms.TabPage();

		this.btnSelectFont = new System.Windows.Forms.Button();

		this.btnSelectColor = new System.Windows.Forms.Button();

		this.btnSaveTextFile = new System.Windows.Forms.Button();

		this.txtFileContents = new System.Windows.Forms.TextBox();

		this.btnOpenTextFile = new System.Windows.Forms.Button();

		this.pgeOpenMultipleFiles = new System.Windows.Forms.TabPage();

		this.lstFiles = new System.Windows.Forms.ListBox();

		this.btnRetriveFileNames = new System.Windows.Forms.Button();

		this.tabOptions.SuspendLayout();

		this.pgeOpenSaveFile.SuspendLayout();

		this.pgeOpenMultipleFiles.SuspendLayout();

		this.SuspendLayout();

		//

		//mnuMain

		//

		this.mnuMain.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {this.mnuFile, this.mnuHelp});

		//

		//mnuFile

		//

		this.mnuFile.Index = 0;

		this.mnuFile.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {this.mnuExit});

		this.mnuFile.Text = "&File";

		//

		//mnuExit

		//

		this.mnuExit.Index = 0;

		this.mnuExit.Text = "E&xit";
		this.mnuExit.Click +=new EventHandler(mnuExit_Click);

		//

		//mnuHelp

		//

		this.mnuHelp.Index = 1;

		this.mnuHelp.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {this.mnuAbout});

		this.mnuHelp.Text = "&Help";

		//

		//mnuAbout

		//

		this.mnuAbout.Index = 0;

		this.mnuAbout.Text = "Text Comes from AssemblyInfo";
		this.mnuAbout.Click +=new EventHandler(mnuAbout_Click);

		//

		//sdlgTextFile

		//

		this.sdlgTextFile.FileName = "doc1";
		this.sdlgTextFile.HelpRequest +=new EventHandler(sdlgTextFile_HelpRequest);

		//

		//fdlgText

		//

		//
		this.fdlgText.Apply +=new EventHandler(fdlgText_Apply);

		//odlgTextFile
		this.odlgTextFile.FileOk +=new System.ComponentModel.CancelEventHandler(odlgTextFile_FileOk);
		this.odlgTextFile.HelpRequest +=new EventHandler(odlgTextFile_HelpRequest);
		//

		//

		//tabOptions

		//

		this.tabOptions.Controls.AddRange(new System.Windows.Forms.Control[] {this.pgeOpenSaveFile, this.pgeOpenMultipleFiles});

		this.tabOptions.Dock = System.Windows.Forms.DockStyle.Fill;

		this.tabOptions.ItemSize = new System.Drawing.Size(84, 18);

		this.tabOptions.Name = "tabOptions";

		this.tabOptions.SelectedIndex = 0;

		this.tabOptions.Size = new System.Drawing.Size(562, 292);

		this.tabOptions.TabIndex = 1;

		//

		//pgeOpenSaveFile

		//

		this.pgeOpenSaveFile.Controls.AddRange(new System.Windows.Forms.Control[] {this.btnSelectFont, this.btnSelectColor, this.btnSaveTextFile, this.txtFileContents, this.btnOpenTextFile});

		this.pgeOpenSaveFile.Location = new System.Drawing.Point(4, 22);

		this.pgeOpenSaveFile.Name = "pgeOpenSaveFile";

		this.pgeOpenSaveFile.Size = new System.Drawing.Size(554, 266);

		this.pgeOpenSaveFile.TabIndex = 4;

		this.pgeOpenSaveFile.Text = "Open/SaveFileDialog";

		//

		//btnSelectFont

		//

		this.btnSelectFont.ImeMode = System.Windows.Forms.ImeMode.NoControl;

		this.btnSelectFont.Location = new System.Drawing.Point(8, 104);

		this.btnSelectFont.Name = "btnSelectFont";

		this.btnSelectFont.Size = new System.Drawing.Size(168, 23);

		this.btnSelectFont.TabIndex = 5;

		this.btnSelectFont.Text = "S&elect a Font";
		this.btnSelectFont.Click +=new EventHandler(btnSelectFont_Click);

		//

		//btnSelectColor

		//

		this.btnSelectColor.ImeMode = System.Windows.Forms.ImeMode.NoControl;

		this.btnSelectColor.Location = new System.Drawing.Point(8, 72);

		this.btnSelectColor.Name = "btnSelectColor";

		this.btnSelectColor.Size = new System.Drawing.Size(168, 23);

		this.btnSelectColor.TabIndex = 4;

		this.btnSelectColor.Text = "Select a &Color";
		this.btnSelectColor.Click +=new EventHandler(btnSelectColor_Click);

		//

		//btnSaveTextFile

		//

		this.btnSaveTextFile.ImeMode = System.Windows.Forms.ImeMode.NoControl;

		this.btnSaveTextFile.Location = new System.Drawing.Point(8, 40);

		this.btnSaveTextFile.Name = "btnSaveTextFile";

		this.btnSaveTextFile.Size = new System.Drawing.Size(168, 23);

		this.btnSaveTextFile.TabIndex = 3;

		this.btnSaveTextFile.Text = "&Save a File";
		this.btnSaveTextFile.Click +=new EventHandler(btnSaveTextFile_Click);

		//

		//txtFileContents

		//
		
		this.txtFileContents.Anchor = (((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right);

		this.txtFileContents.Location = new System.Drawing.Point(184, 8);

		this.txtFileContents.Multiline = true;

		this.txtFileContents.Name = "txtFileContents";

		this.txtFileContents.ScrollBars = System.Windows.Forms.ScrollBars.Both;

		this.txtFileContents.Size = new System.Drawing.Size(362, 252);

		this.txtFileContents.TabIndex = 2;

		this.txtFileContents.Text = "";

		//

		//btnOpenTextFile

		//

		this.btnOpenTextFile.ImeMode = System.Windows.Forms.ImeMode.NoControl;

		this.btnOpenTextFile.Location = new System.Drawing.Point(8, 8);

		this.btnOpenTextFile.Name = "btnOpenTextFile";

		this.btnOpenTextFile.Size = new System.Drawing.Size(168, 23);

		this.btnOpenTextFile.TabIndex = 1;

		this.btnOpenTextFile.Text = "&Open a File";
		this.btnOpenTextFile.Click +=new EventHandler(btnOpenTextFile_Click);

		//

		//pgeOpenMultipleFiles

		//

		this.pgeOpenMultipleFiles.Controls.AddRange(new System.Windows.Forms.Control[] {this.lstFiles, this.btnRetriveFileNames});

		this.pgeOpenMultipleFiles.Location = new System.Drawing.Point(4, 22);

		this.pgeOpenMultipleFiles.Name = "pgeOpenMultipleFiles";

		this.pgeOpenMultipleFiles.Size = new System.Drawing.Size(554, 266);

		this.pgeOpenMultipleFiles.TabIndex = 0;

		this.pgeOpenMultipleFiles.Text = "Select Multiple Files";

		this.pgeOpenMultipleFiles.Visible = false;

		//

		//lstFiles

		//

		this.lstFiles.Anchor = (((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)| System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right);

		this.lstFiles.Location = new System.Drawing.Point(184, 8);

		this.lstFiles.Name = "lstFiles";

		this.lstFiles.Size = new System.Drawing.Size(362, 238);

		this.lstFiles.TabIndex = 1;

		//

		//btnRetriveFileNames

		//

		this.btnRetriveFileNames.ImeMode = System.Windows.Forms.ImeMode.NoControl;

		this.btnRetriveFileNames.Location = new System.Drawing.Point(8, 8);

		this.btnRetriveFileNames.Name = "btnRetriveFileNames";

		this.btnRetriveFileNames.Size = new System.Drawing.Size(168, 23);

		this.btnRetriveFileNames.TabIndex = 0;

		this.btnRetriveFileNames.Text = "&Retrieve File Names";
		this.btnRetriveFileNames.Click +=new EventHandler(btnRetriveFileNames_Click);

		//

		//frmMain

		//

		this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);

		this.ClientSize = new System.Drawing.Size(562, 292);

		this.Controls.AddRange(new System.Windows.Forms.Control[] {this.tabOptions});

		this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;

		this.Icon = (System.Drawing.Icon) resources.GetObject("$this.Icon");

		this.MaximizeBox = false;

		this.Menu = this.mnuMain;

		this.Name = "frmMain";

		this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;

		this.Text = "Title Comes from Assembly Info";

		this.tabOptions.ResumeLayout(false);

		this.pgeOpenSaveFile.ResumeLayout(false);

		this.pgeOpenMultipleFiles.ResumeLayout(false);

		this.ResumeLayout(false);

	}

	#endregion

	#region " Standard Menu Code "

	

	

	// This code simply shows the About form.

	private void mnuAbout_Click(object sender, System.EventArgs e) 
	{

		// Open the About form in Dialog Mode

		frmAbout frm = new frmAbout();

		frm.ShowDialog(this);

		frm.Dispose();

	}

	// This code will close the form.

	private void mnuExit_Click(object sender, System.EventArgs e) 
	{

		// Close the current form

		this.Close();

	}

	#endregion

	private string FileName;

	private void btnRetriveFileNames_Click(object sender, System.EventArgs e) 
	{

		try 
		{
			// You may ! always want to do this, 
			// but you can set the initial directory.
			// In this example, the code only 
			// sets this property if you've 
			// set the DefaultFolder value
			// since the last time opening 
			// the dialog box. if you don't 
			// call the Reset method, your
			// initial directory won't affect
			// the dialog box, if you've already
			// selected a file using it.

			odlgFileNames.Reset();

			odlgFileNames.InitialDirectory = @"C:\";
			// Add default extension to file name if the user
			// doesn't type it.
			// The default is true.

			odlgFileNames.AddExtension = true;

			// Check to ensure that the selected
			// file exists.  Dialog box displays 
			// a warning otherwise.
			// The default is true.

			odlgFileNames.CheckFileExists = true;
				
			// Check to ensure that the selected
			// path exists.  Dialog box displays 
			// a warning otherwise.
			// The default is true.

			odlgFileNames.CheckPathExists = true;

			// Get or set default extension. Doesn't 
			// include the leading ".".
			// The default is "".

			odlgFileNames.DefaultExt = "txt";

			// return the file referenced by a link? if 
			// false, simply returns the selected link
			// file. if true, returns the file linked to 
			// the LNK file.
			// The default is true.

			odlgFileNames.DereferenceLinks = true;

			// Just in VB6, use a set of pairs
			// of filters, separated with "|". Each 
			// pair consists of a description|file spec.
			// Use a "|" between pairs. No need to put a
			// trailing "|". You can set the FilterIndex
			// property well, to select the default
			// filter. Amazingly, the first filter is 
			// numbered 1 (! 0). The default is 1. 
			// The default is "".

			odlgFileNames.Filter = "Text files (*.txt)|*.txt|" + "All files|*.*";

			// if you want to allow users to select
			// more than one file, set this to true. 
			// if you set this to true, retrieve
			// the selected files using the FileNames
			// property of the dialog box.
			// The default is false.

			odlgFileNames.Multiselect = true;

			// Restore the original directory when done selecting
			// a file? if false, the current directory changes
			// to the directory in which you selected the file.
			// Set this to true to put the current folder back
			// where it was when you started.
			// The default is false.

			odlgFileNames.RestoreDirectory = true;

			// Show the Help button and Read-Only checkbox?
			// The Default for each is false.
			odlgFileNames.ShowHelp = true;

			odlgFileNames.ShowReadOnly = false;

			// Start out with the read-only check box checked?
			// This only make sense if ShowReadOnly is true.
			// The default is false.
			// .ReadOnlyChecked = false
			// The default is "".

			odlgFileNames.Title = "Select a file";

			// Only accept valid Win32 file names?
			// The default is true.

			odlgFileNames.ValidateNames = true;

			if (odlgFileNames.ShowDialog() == DialogResult.OK) 
			{

				// You have a choice here. You can either
				// use the FileName or FileNames properties to get the name 
				// you selected, or you can use the OpenFile
				// method to open the file a read-only Stream.

				lstFiles.DataSource = odlgFileNames.FileNames;

				// You could also write code like this, 
				// to loop through the selected file names:
				//strName string
				//foreach(strName In .FileNames
				//    lstFiles.Items.Add(strName)
				//Next

			}

			
		}
		catch (Exception exp) 
		{

			MessageBox.Show(exp.Message, this.Text);

		}
	}

	private void btnOpenTextFile_Click(object sender, System.EventArgs e) 
	{
		StreamReader ts = null;
		try 
			{

		// See btnRetriveFileNames_Click for explanations of default values 
		// for the properties.
		// Check to ensure that the selected
		// file exists.  Dialog box displays 
		// a warning otherwise.

		odlgTextFile.CheckFileExists = true;

		// Check to ensure that the selected
		// path exists.  Dialog box displays 
		// a warning otherwise.

		odlgTextFile.CheckPathExists = true;

		// Get or set default extension. Doesn't 
		// include the leading ".".

		odlgTextFile.DefaultExt = "txt";

		// return the file referenced by a link? if 
		// false, simply returns the selected link
		// file. if true, returns the file linked to 
		// the LNK file.

		odlgTextFile.DereferenceLinks = true;

		// Just in VB6, use a set of pairs
		// of filters, separated with "|". Each 
		// pair consists of a description|file spec.
		// Use a "|" between pairs. No need to put a
		// trailing "|". You can set the FilterIndex
		// property well, to select the default
		// filter. Amazingly, the first filter is 
		// numbered 1 (! 0). The default is 1. 

		odlgTextFile.Filter = "Text files (*.txt)|*.txt|" + "All files|*.*";

		odlgTextFile.Multiselect = false;

		// Restore the original directory when done selecting
		// a file? if false, the current directory changes
		// to the directory in which you selected the file.
		// Set this to true to put the current folder back
		// where it was when you started.
		// The default is false.

		odlgTextFile.RestoreDirectory = true;

		// Show the Help button and Read-Only checkbox?

		odlgTextFile.ShowHelp = true;

		odlgTextFile.ShowReadOnly = false;

		// Start out with the read-only check box checked?
		// This only make sense if ShowReadOnly is true.
		// .ReadOnlyChecked = false

		odlgTextFile.Title = "Select a file to open";

		// Only accept valid Win32 file names?

		odlgTextFile.ValidateNames = true;

		if (odlgTextFile.ShowDialog() == DialogResult.OK)
	{

		FileName = odlgTextFile.FileName;

		ts = new StreamReader(odlgTextFile.OpenFile());

		txtFileContents.Text = ts.ReadToEnd();
	}
	}

			
	catch (Exception exp) 
	{
		MessageBox.Show(exp.Message, this.Text);
	}
	finally
	{
		if(ts != null)
			{

				ts.Close();
			}
	}
}

	private void btnSaveTextFile_Click(object sender, System.EventArgs e)
	{
		StreamWriter sw = null;

		try 
		{
			// See the code demonstrating
			// the OpenFileDialog control
			// for examples using most 
			// properties, which are the same
			// for both controls, for the most part.
			// Add the default extension, if the user
			// neglects to add an extension.
			// The default is true.

			sdlgTextFile.AddExtension = true;

			// Check to verify that the output path
			// actually exists. Prompt before
			// creating a new file? Prompt before
			// overwriting? 
			// The default is true.

			sdlgTextFile.CheckPathExists = true;

			// The default is false.

			sdlgTextFile.CreatePrompt = false;

			// The default is true.

			sdlgTextFile.OverwritePrompt = true;

			// The default is true.

			sdlgTextFile.ValidateNames = true;

			// The default is false.

			sdlgTextFile.ShowHelp = true;

			// if the user doesn't supply an extension,
			// and if the AddExtension property is
			// true, use this extension.
			// The default is "".

			sdlgTextFile.DefaultExt = "txt";

			// Prompt with the current file name
			// if you've specified it.
			// The default is "".

			sdlgTextFile.FileName = FileName;

			// The default is "".

			sdlgTextFile.Filter = "Text files (*.txt)|*.txt|" + "All files|*.*";
			sdlgTextFile.FilterIndex = 1;

			if (sdlgTextFile.ShowDialog() == DialogResult.OK)
			{
				FileName = sdlgTextFile.FileName;

				sw = new StreamWriter(FileName);
				sw.Write(txtFileContents.Text);
			}

			
		}
		catch (Exception exp) 
		{
			MessageBox.Show(exp.Message, this.Text);
		}
		finally
		{
			if (sw != null) 
				{
					sw.Close();
				}
		}

	}

	private void odlgTextFile_FileOk(object sender, System.ComponentModel.CancelEventArgs e) 
	{

		// This event occurs after you select a file, but 
		// before the dialog box is dismissed. if you set the 
		// Cancel property of the CancelEventArgs property to true, 
		// you'll be sent back to the dialog box.
		// Obviously, using this event in the manner shown 
		// here would be vaguely annoying.
		// The default value of e.Cancel is false.
		
		if (MessageBox.Show("Do you want to open a new file?",this.Text,MessageBoxButtons.YesNo,MessageBoxIcon.Question) != DialogResult.Yes)
		{																													
			e.Cancel = true;
	
		}
		
	}

	private void odlgTextFile_HelpRequest(object sender, System.EventArgs e) 
	{
		// if the OpenFileDialog control displays its Help button
		// (see the ShowHelp property of the OpenFileDialog control), 
		// this code runs.

		MessageBox.Show("Display your own help for the OpenFileDialog control here.", this.Text);
	}

	private void sdlgTextFile_HelpRequest(object sender, System.EventArgs e) 
	{
		// if the SaveFileDialog control displays its Help button
		// (see the ShowHelp property of the SaveFileDialog control), 
		// this code runs.

		MessageBox.Show("Display your own help for the SaveFileDialog control here.", this.Text);

	}

	private void btnSelectColor_Click(object sender, System.EventArgs e)
	{

		// Initialize CustomColors with an array of integers.
		// Note that these colors aren't in the same format 
		// .NET colors -- these are the old VB6-type
		// color values. For example, 0 is Black, 255 is Red, 
		// and so on. You can use the VB6 RGB function to create 
		// these values.
		// For this example, put Red, Green, and Blue in the custom 
		// colors section.

		

		try 
		{


			// Initialize the selected color
			// to match the color currently used
			// by the TextBox's foreground color.
			// The default is Black.

			cdlgText.Color = txtFileContents.ForeColor;

			// Fill the custom colors on the dialog box
			// with the array you've supplied. This is, 
			// of course, totally optional.

			cdlgText.CustomColors = CustomColors;

			// Allow the user to create custom colors?
			// The default is true.

			cdlgText.AllowFullOpen = true;

			// Display all of the basic colors?
			// The default is false.

			cdlgText.AnyColor = true;

			// if true, dialog box displays with the custom 
			// color settings side open, well.
			// The default is false.

			cdlgText.FullOpen = false;

			// Restrict users to solid colors only.
			// The default is false.

			cdlgText.SolidColorOnly = true;

			// if ShowHelp is true, the control will display its Help
			// button, and you can react to the control's 
			// HelpRequest event. 
			// The default is false.

			cdlgText.ShowHelp = true;

			if (cdlgText.ShowDialog() == DialogResult.OK)
			{

				txtFileContents.ForeColor = cdlgText.Color;

				// Store the custom colors for future
				// use. 

				CustomColors = cdlgText.CustomColors;

			}

			// Reset all the colors in the dialog box.
			// This isn't necessary, but it does
			// make sure the dialog box is in a 
			// known state for its next use.

			cdlgText.Reset();

		}

		catch (Exception exp) 
		{
			MessageBox.Show(exp.Message, this.Text);
		}

	}

	private void btnSelectFont_Click(object sender, System.EventArgs e) 
	{

		try 
		{

			// Initialize the dialog box to match
			// the font used in the text box.

			fdlgText.Font = txtFileContents.Font;

			// The default is Black.

			fdlgText.Color = txtFileContents.ForeColor;

			// Allow the users to select colors.

			// The default is false.

			fdlgText.ShowColor = true;

			// Show the Apply button on the dialog box.
			// The default is false.

			fdlgText.ShowApply = true;

			// Allow users to select effects.
			// The default is true.

			fdlgText.ShowEffects = true;

			// Show the Help button.
			// The default is false.

			fdlgText.ShowHelp = true;

			// Let the user change the character set, 
			// but don't allow simulations, vector fonts, 
			// or vertical fonts.
			// The default is true.

			fdlgText.AllowScriptChange = true;

			// The default is true.

			fdlgText.AllowSimulations = false;

			// The default is true.

			fdlgText.AllowVectorFonts = false;

			// The default is true.

			fdlgText.AllowVerticalFonts = false;

			// Allow fixed and proportional fonts, 
			// and only allow fonts that exist.
			// Set the minimum and maximum selectable
			// font sizes, well. These are arbitrary
			// values, in this example.
			// The default is false.

			fdlgText.FixedPitchOnly = false;

			// The default is false.

			fdlgText.FontMustExist = true;

			// The default for both these is 0.

			fdlgText.MaxSize = 48;
			fdlgText.MinSize = 8;

			// Display the dialog box, and then
			// fix up the font requested.

			if (fdlgText.ShowDialog() == DialogResult.OK)
			{
				ApplyFontAndColor();
			}

		}
		catch (Exception exp) 
		{

			MessageBox.Show(exp.Message, this.Text);

		}

	}

	private void ApplyFontAndColor()
	{

		try 
		{

			// Set the TextBox's font to the selected font, 
			// including the size, weight, and so on.

			txtFileContents.Font = fdlgText.Font;

			// if the user selected a color
			// at the same time, set the 
			// selected color.

			if (fdlgText.ShowColor) 
			{

				txtFileContents.ForeColor = fdlgText.Color;
			}

			
		}
		catch (Exception exp) 
		{

			MessageBox.Show(exp.Message, this.Text);

		}

	}

	private void fdlgText_Apply(object sender, System.EventArgs e) 
	{
		// Handle the Apply event of the Font dialog.
		ApplyFontAndColor();
	}

}

