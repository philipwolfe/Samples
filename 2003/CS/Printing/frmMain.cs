//Copyright (C) 2002 Microsoft Corporation
//All rights reserved.
//THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, EITHER 
//EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED WARRANTIES OF 
//MERCHANTIBILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
//Requires the Trial or Release version of Visual Studio .NET Professional (or greater).

using System.Drawing.Printing;
using System;
using System.Windows.Forms;
using System.Drawing;

public class frmMain: System.Windows.Forms.Form 
{
	// It's important that all the event procedures work with the same PrintDocument
	// object.

	private PrintDocument pdoc = new PrintDocument();

	/// <summary>
	/// The main entry point for the application.
	/// </summary>
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
	private System.Windows.Forms.MenuItem mnuAbout;
	private System.Windows.Forms.Button btnPageSetup;
	private System.Windows.Forms.Button btnPrintDialog;
	private System.Windows.Forms.Button btnPrintPreview;
	private System.Windows.Forms.OpenFileDialog odlgDocument;
	private System.Windows.Forms.TextBox txtDocument;

	private void InitializeComponent() 
	{
		System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(frmMain));
		this.mnuMain = new System.Windows.Forms.MainMenu();
		this.mnuFile = new System.Windows.Forms.MenuItem();
		this.mnuExit = new System.Windows.Forms.MenuItem();
		this.mnuHelp = new System.Windows.Forms.MenuItem();
		this.mnuAbout = new System.Windows.Forms.MenuItem();
		this.btnPageSetup = new System.Windows.Forms.Button();
		this.btnPrintDialog = new System.Windows.Forms.Button();
		this.btnPrintPreview = new System.Windows.Forms.Button();
		this.odlgDocument = new System.Windows.Forms.OpenFileDialog();
		this.txtDocument = new System.Windows.Forms.TextBox();
		this.SuspendLayout();

		//

		//mnuMain

		//

		this.mnuMain.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {this.mnuFile, this.mnuHelp});

		this.mnuMain.RightToLeft = (System.Windows.Forms.RightToLeft) resources.GetObject("mnuMain.RightToLeft");

		//

		//mnuFile

		//

		this.mnuFile.Enabled = (bool) resources.GetObject("mnuFile.Enabled");

		this.mnuFile.Index = 0;

		this.mnuFile.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {this.mnuExit});

		this.mnuFile.Shortcut = (System.Windows.Forms.Shortcut) resources.GetObject("mnuFile.Shortcut");

		this.mnuFile.ShowShortcut = (bool) resources.GetObject("mnuFile.ShowShortcut");

		this.mnuFile.Text = resources.GetString("mnuFile.Text");

		this.mnuFile.Visible = (bool) resources.GetObject("mnuFile.Visible");

		//

		//mnuExit

		//

		this.mnuExit.Enabled = (bool) resources.GetObject("mnuExit.Enabled");

		this.mnuExit.Index = 0;

		this.mnuExit.Shortcut = (System.Windows.Forms.Shortcut) resources.GetObject("mnuExit.Shortcut");

		this.mnuExit.ShowShortcut = (bool) resources.GetObject("mnuExit.ShowShortcut");

		this.mnuExit.Text = resources.GetString("mnuExit.Text");

		this.mnuExit.Visible = (bool) resources.GetObject("mnuExit.Visible");

		//

		//mnuHelp

		//

		this.mnuHelp.Enabled = (bool) resources.GetObject("mnuHelp.Enabled");

		this.mnuHelp.Index = 1;

		this.mnuHelp.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {this.mnuAbout});

		this.mnuHelp.Shortcut = (System.Windows.Forms.Shortcut) resources.GetObject("mnuHelp.Shortcut");

		this.mnuHelp.ShowShortcut = (bool) resources.GetObject("mnuHelp.ShowShortcut");

		this.mnuHelp.Text = resources.GetString("mnuHelp.Text");

		this.mnuHelp.Visible = (bool) resources.GetObject("mnuHelp.Visible");

		//

		//mnuAbout

		//

		this.mnuAbout.Enabled = (bool) resources.GetObject("mnuAbout.Enabled");

		this.mnuAbout.Index = 0;

		this.mnuAbout.Shortcut = (System.Windows.Forms.Shortcut) resources.GetObject("mnuAbout.Shortcut");

		this.mnuAbout.ShowShortcut = (bool) resources.GetObject("mnuAbout.ShowShortcut");

		this.mnuAbout.Text = resources.GetString("mnuAbout.Text");

		this.mnuAbout.Visible = (bool) resources.GetObject("mnuAbout.Visible");

		//

		//btnPageSetup

		//

		this.btnPageSetup.AccessibleDescription = resources.GetString("btnPageSetup.AccessibleDescription");

		this.btnPageSetup.AccessibleName = resources.GetString("btnPageSetup.AccessibleName");

		this.btnPageSetup.Anchor = (System.Windows.Forms.AnchorStyles) resources.GetObject("btnPageSetup.Anchor");

		this.btnPageSetup.BackgroundImage = (System.Drawing.Image) resources.GetObject("btnPageSetup.BackgroundImage");

		this.btnPageSetup.Dock = (System.Windows.Forms.DockStyle) resources.GetObject("btnPageSetup.Dock");

		this.btnPageSetup.Enabled = (bool) resources.GetObject("btnPageSetup.Enabled");

		this.btnPageSetup.FlatStyle = (System.Windows.Forms.FlatStyle) resources.GetObject("btnPageSetup.FlatStyle");

		this.btnPageSetup.Font = (System.Drawing.Font) resources.GetObject("btnPageSetup.Font");

		this.btnPageSetup.Image = (System.Drawing.Image) resources.GetObject("btnPageSetup.Image");

		this.btnPageSetup.ImageAlign = (System.Drawing.ContentAlignment) resources.GetObject("btnPageSetup.ImageAlign");

		this.btnPageSetup.ImageIndex = (int) resources.GetObject("btnPageSetup.ImageIndex");

		this.btnPageSetup.ImeMode = (System.Windows.Forms.ImeMode) resources.GetObject("btnPageSetup.ImeMode");

		this.btnPageSetup.Location = (System.Drawing.Point) resources.GetObject("btnPageSetup.Location");

		this.btnPageSetup.Name = "btnPageSetup";

		this.btnPageSetup.RightToLeft = (System.Windows.Forms.RightToLeft) resources.GetObject("btnPageSetup.RightToLeft");

		this.btnPageSetup.Size = (System.Drawing.Size) resources.GetObject("btnPageSetup.Size");

		this.btnPageSetup.TabIndex = (int) resources.GetObject("btnPageSetup.TabIndex");

		this.btnPageSetup.Text = resources.GetString("btnPageSetup.Text");

		this.btnPageSetup.TextAlign = (System.Drawing.ContentAlignment) resources.GetObject("btnPageSetup.TextAlign");

		this.btnPageSetup.Visible = (bool) resources.GetObject("btnPageSetup.Visible");

		//

		//btnPrintDialog

		//

		this.btnPrintDialog.AccessibleDescription = resources.GetString("btnPrintDialog.AccessibleDescription");

		this.btnPrintDialog.AccessibleName = resources.GetString("btnPrintDialog.AccessibleName");

		this.btnPrintDialog.Anchor = (System.Windows.Forms.AnchorStyles) resources.GetObject("btnPrintDialog.Anchor");

		this.btnPrintDialog.BackgroundImage = (System.Drawing.Image) resources.GetObject("btnPrintDialog.BackgroundImage");

		this.btnPrintDialog.Dock = (System.Windows.Forms.DockStyle) resources.GetObject("btnPrintDialog.Dock");

		this.btnPrintDialog.Enabled = (bool) resources.GetObject("btnPrintDialog.Enabled");

		this.btnPrintDialog.FlatStyle = (System.Windows.Forms.FlatStyle) resources.GetObject("btnPrintDialog.FlatStyle");

		this.btnPrintDialog.Font = (System.Drawing.Font) resources.GetObject("btnPrintDialog.Font");

		this.btnPrintDialog.Image = (System.Drawing.Image) resources.GetObject("btnPrintDialog.Image");

		this.btnPrintDialog.ImageAlign = (System.Drawing.ContentAlignment) resources.GetObject("btnPrintDialog.ImageAlign");

		this.btnPrintDialog.ImageIndex = (int) resources.GetObject("btnPrintDialog.ImageIndex");

		this.btnPrintDialog.ImeMode = (System.Windows.Forms.ImeMode) resources.GetObject("btnPrintDialog.ImeMode");

		this.btnPrintDialog.Location = (System.Drawing.Point) resources.GetObject("btnPrintDialog.Location");

		this.btnPrintDialog.Name = "btnPrintDialog";

		this.btnPrintDialog.RightToLeft = (System.Windows.Forms.RightToLeft) resources.GetObject("btnPrintDialog.RightToLeft");

		this.btnPrintDialog.Size = (System.Drawing.Size) resources.GetObject("btnPrintDialog.Size");

		this.btnPrintDialog.TabIndex = (int) resources.GetObject("btnPrintDialog.TabIndex");

		this.btnPrintDialog.Text = resources.GetString("btnPrintDialog.Text");

		this.btnPrintDialog.TextAlign = (System.Drawing.ContentAlignment) resources.GetObject("btnPrintDialog.TextAlign");

		this.btnPrintDialog.Visible = (bool) resources.GetObject("btnPrintDialog.Visible");

		//

		//btnPrintPreview

		//

		this.btnPrintPreview.AccessibleDescription = resources.GetString("btnPrintPreview.AccessibleDescription");

		this.btnPrintPreview.AccessibleName = resources.GetString("btnPrintPreview.AccessibleName");

		this.btnPrintPreview.Anchor = (System.Windows.Forms.AnchorStyles) resources.GetObject("btnPrintPreview.Anchor");

		this.btnPrintPreview.BackgroundImage = (System.Drawing.Image) resources.GetObject("btnPrintPreview.BackgroundImage");

		this.btnPrintPreview.Dock = (System.Windows.Forms.DockStyle) resources.GetObject("btnPrintPreview.Dock");

		this.btnPrintPreview.Enabled = (bool) resources.GetObject("btnPrintPreview.Enabled");

		this.btnPrintPreview.FlatStyle = (System.Windows.Forms.FlatStyle) resources.GetObject("btnPrintPreview.FlatStyle");

		this.btnPrintPreview.Font = (System.Drawing.Font) resources.GetObject("btnPrintPreview.Font");

		this.btnPrintPreview.Image = (System.Drawing.Image) resources.GetObject("btnPrintPreview.Image");

		this.btnPrintPreview.ImageAlign = (System.Drawing.ContentAlignment) resources.GetObject("btnPrintPreview.ImageAlign");

		this.btnPrintPreview.ImageIndex = (int) resources.GetObject("btnPrintPreview.ImageIndex");

		this.btnPrintPreview.ImeMode = (System.Windows.Forms.ImeMode) resources.GetObject("btnPrintPreview.ImeMode");

		this.btnPrintPreview.Location = (System.Drawing.Point) resources.GetObject("btnPrintPreview.Location");

		this.btnPrintPreview.Name = "btnPrintPreview";

		this.btnPrintPreview.RightToLeft = (System.Windows.Forms.RightToLeft) resources.GetObject("btnPrintPreview.RightToLeft");

		this.btnPrintPreview.Size = (System.Drawing.Size) resources.GetObject("btnPrintPreview.Size");

		this.btnPrintPreview.TabIndex = (int) resources.GetObject("btnPrintPreview.TabIndex");

		this.btnPrintPreview.Text = resources.GetString("btnPrintPreview.Text");

		this.btnPrintPreview.TextAlign = (System.Drawing.ContentAlignment) resources.GetObject("btnPrintPreview.TextAlign");

		this.btnPrintPreview.Visible = (bool) resources.GetObject("btnPrintPreview.Visible");

		//

		//odlgDocument

		//

		this.odlgDocument.Filter = resources.GetString("odlgDocument.Filter");

		this.odlgDocument.Title = resources.GetString("odlgDocument.Title");

		//

		//txtDocument

		//

		this.txtDocument.AccessibleDescription = resources.GetString("txtDocument.AccessibleDescription");

		this.txtDocument.AccessibleName = resources.GetString("txtDocument.AccessibleName");

		this.txtDocument.Anchor = (System.Windows.Forms.AnchorStyles) resources.GetObject("txtDocument.Anchor");

		this.txtDocument.AutoSize = (bool) resources.GetObject("txtDocument.AutoSize");

		this.txtDocument.BackgroundImage = (System.Drawing.Image) resources.GetObject("txtDocument.BackgroundImage");

		this.txtDocument.Dock = (System.Windows.Forms.DockStyle) resources.GetObject("txtDocument.Dock");

		this.txtDocument.Enabled = (bool) resources.GetObject("txtDocument.Enabled");

		this.txtDocument.Font = (System.Drawing.Font) resources.GetObject("txtDocument.Font");

		this.txtDocument.ImeMode = (System.Windows.Forms.ImeMode) resources.GetObject("txtDocument.ImeMode");

		this.txtDocument.Location = (System.Drawing.Point) resources.GetObject("txtDocument.Location");

		this.txtDocument.MaxLength = (int) resources.GetObject("txtDocument.MaxLength");

		this.txtDocument.Multiline = (bool) resources.GetObject("txtDocument.Multiline");

		this.txtDocument.Name = "txtDocument";

		this.txtDocument.PasswordChar = (char) resources.GetObject("txtDocument.PasswordChar");

		this.txtDocument.RightToLeft = (System.Windows.Forms.RightToLeft) resources.GetObject("txtDocument.RightToLeft");

		this.txtDocument.ScrollBars = (System.Windows.Forms.ScrollBars) resources.GetObject("txtDocument.ScrollBars");

		this.txtDocument.Size = (System.Drawing.Size) resources.GetObject("txtDocument.Size");

		this.txtDocument.TabIndex = (int) resources.GetObject("txtDocument.TabIndex");

		this.txtDocument.Text = resources.GetString("txtDocument.Text");

		this.txtDocument.TextAlign = (System.Windows.Forms.HorizontalAlignment) resources.GetObject("txtDocument.TextAlign");

		this.txtDocument.Visible = (bool) resources.GetObject("txtDocument.Visible");

		this.txtDocument.WordWrap = (bool) resources.GetObject("txtDocument.WordWrap");

		//

		//frmMain

		//

		this.AccessibleDescription = (string) resources.GetObject("$this.AccessibleDescription");

		this.AccessibleName = (string) resources.GetObject("$this.AccessibleName");

		this.Anchor = (System.Windows.Forms.AnchorStyles) resources.GetObject("$this.Anchor");

		this.AutoScaleBaseSize = (System.Drawing.Size) resources.GetObject("$this.AutoScaleBaseSize");

		this.AutoScroll = (bool) resources.GetObject("$this.AutoScroll");

		this.AutoScrollMargin = (System.Drawing.Size) resources.GetObject("$this.AutoScrollMargin");

		this.AutoScrollMinSize = (System.Drawing.Size) resources.GetObject("$this.AutoScrollMinSize");

		this.BackgroundImage = (System.Drawing.Image) resources.GetObject("$this.BackgroundImage");

		this.ClientSize = (System.Drawing.Size) resources.GetObject("$this.ClientSize");

		this.Controls.AddRange(new System.Windows.Forms.Control[] {this.txtDocument, this.btnPageSetup, this.btnPrintDialog, this.btnPrintPreview});

		this.Dock = (System.Windows.Forms.DockStyle) resources.GetObject("$this.Dock");

		this.Enabled = (bool) resources.GetObject("$this.Enabled");

		this.Font = (System.Drawing.Font) resources.GetObject("$this.Font");

		this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;

		this.Icon = (System.Drawing.Icon) resources.GetObject("$this.Icon");

		this.ImeMode = (System.Windows.Forms.ImeMode) resources.GetObject("$this.ImeMode");

		this.Location = (System.Drawing.Point) resources.GetObject("$this.Location");

		this.MaximizeBox = false;

		this.MaximumSize = (System.Drawing.Size) resources.GetObject("$this.MaximumSize");

		this.Menu = this.mnuMain;

		this.MinimumSize = (System.Drawing.Size) resources.GetObject("$this.MinimumSize");

		this.Name = "frmMain";

		this.RightToLeft = (System.Windows.Forms.RightToLeft) resources.GetObject("$this.RightToLeft");

		this.StartPosition = (System.Windows.Forms.FormStartPosition) resources.GetObject("$this.StartPosition");

		this.Text = resources.GetString("$this.Text");

		this.Visible = (bool) resources.GetObject("$this.Visible");

		this.ResumeLayout(false);

		this.Load +=new System.EventHandler(frmMain_Load);
		pdoc.PrintPage +=new PrintPageEventHandler(pdoc_PrintPage);
		this.btnPrintDialog.Click +=new EventHandler(btnPrintDialog_Click);
		this.btnPageSetup.Click +=new EventHandler(btnPageSetup_Click);
		this.btnPrintPreview.Click +=new EventHandler(btnPrintPreview_Click);
		this.mnuAbout.Click +=new EventHandler(mnuAbout_Click);
		this.mnuExit.Click +=new EventHandler(mnuExit_Click);
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

	// The PrintDialog allows the user to select the printer that they want to print 
	// to, well other printing options.

	private void btnPrintDialog_Click(object sender, System.EventArgs e) //btnPrintDialog.Click;
	{
		PrintDialog dialog = new PrintDialog();
		dialog.Document = pdoc;
		if (dialog.ShowDialog() == DialogResult.OK) 
		{
			pdoc.Print();
		}

	}

	// The PrintPreviewDialog is associated with the PrintDocument the preview is 
	// rendered, the PrintPage event is triggered. This event is passed a graphics 
	// context where it "draws" the page.

	private void btnPrintPreview_Click(object sender, System.EventArgs e) //btnPrintPreview.Click;
	{
		PrintPreviewDialog ppd = new PrintPreviewDialog();

		try 
		{

			ppd.Document = pdoc;
			ppd.ShowDialog();
		} 
		catch
		{

			MessageBox.Show("An error occurred while trying to load the " + 
				"document for Print Preview. Make sure you currently have " + 
				"access to a printer. A printer must be connected and " + 
				"accessible for Print Preview to work.", this.Text,
				MessageBoxButtons.OK, MessageBoxIcon.Error);

		}

	}

	// Page setup lets you specify things like the paper size, portrait, 
	// landscape, etc.

	private void btnPageSetup_Click(object sender, System.EventArgs e) //btnPageSetup.Click;
	{
		PageSetupDialog psd = new PageSetupDialog();
		psd.Document = pdoc;
		psd.PageSettings = pdoc.DefaultPageSettings;

		if (psd.ShowDialog() == DialogResult.OK) 
		{
			pdoc.DefaultPageSettings = psd.PageSettings;
		}
	}

	// the Form's Load event, initializing the TextBox with some text
	// for printing.

	private void frmMain_Load(object sender, System.EventArgs e) 
	{
		txtDocument.Text =
			"Lincoln's Gettysburg Address (November 19, 1863)" +
			Environment.NewLine + Environment.NewLine + "\t" +
			"Four score and seven years ago our fathers brought forth on this " + 
			"continent a new nation, conceived in liberty and dedicated to the " +
			"proposition that all men are created equal. " + 
			Environment.NewLine + Environment.NewLine + "\t" + 
			"Now we are engaged in a great civil war, testing whether that " + 
			"nation or any nation so conceived and so dedicated can long " +
			"endure. We are met on a great battlefield of that war. We have " +
			"come to dedicate a portion of that field a final " +
			"resting-place for those who here gave their lives that that " +
			"nation might live. It is altogether fitting and proper that we " +
			"should do this." +
			Environment.NewLine + Environment.NewLine + "\t" +
			"But in a larger sense, we can! dedicate, we can! consecrate, " +
			"we can! hallow this ground. The brave men, living and dead who " +
			"struggled here have consecrated it far above our poor power to " +
			"add or detract. The world will little note nor long remember " +
			"what we say here, but it can never forget what they did here. " +
			"It is for us the living rather to be dedicated here to the " +
			"unfinished work which they who fought here have thus far so " +
			"nobly advanced. It is rather for us to be here dedicated to " +
			"the great task remaining before us--that from these honored " +
			"dead we take increased devotion to that cause for which they " +
			"gave the last full measure of devotion--that we here highly " +
			"resolve that these dead shall ! have died in vain, that this " +
			"nation under God shall have a new birth of freedom, and that " +
			"government of the people, by the people, for the people shall " +
			"not perish from the earth.";
	}

	// PrintPage is the foundational printing event. This event gets fired for every 
	// page that will be printed. You could also handle the BeginPrint and EndPrint
	// events for more control.
	// 
	// The following is very 
	// fast and useful for plain text Measurestring calculates the text that
	// can be fitted on an entire page. This is ! that useful, however, for 
	// formatted text. In that case you would want to have word-level (vs page-level)
	// control, which is more complicated.

	// Declare a variable to hold the position of the last printed char. Declare
	// static so that subsequent PrintPage events can reference it. Static variables
	// are not supported inside a function in C#
	static int intCurrentChar;

	private void pdoc_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
	{
		
	// Initialize the font to be used for printing.

	Font font = new Font("Microsoft Sans Serif", 24);
	int intPrintAreaHeight;
	int intPrintAreaWidth;
	int marginLeft;
	int marginTop;

	// Initialize local variables that contain the bounds of the printing 
	// area rectangle.
	intPrintAreaHeight = pdoc.DefaultPageSettings.PaperSize.Height - pdoc.DefaultPageSettings.Margins.Top - pdoc.DefaultPageSettings.Margins.Bottom;
	intPrintAreaWidth = pdoc.DefaultPageSettings.PaperSize.Width - pdoc.DefaultPageSettings.Margins.Left - pdoc.DefaultPageSettings.Margins.Right;
	// Initialize local variables to hold margin values that will serve
	// the X and Y coordinates for the upper left corner of the printing 
	// area rectangle.
	marginLeft = pdoc.DefaultPageSettings.Margins.Left; // X coordinate
	marginTop = pdoc.DefaultPageSettings.Margins.Top; // Y coordinate

	// if the user selected Landscape mode, swap the printing area height 
	// and width.

		if (pdoc.DefaultPageSettings.Landscape) 
		{
			int intTemp = intPrintAreaHeight;
			intPrintAreaHeight = intPrintAreaWidth;
			intPrintAreaWidth = intTemp;
		}
        // Calculate the total number of lines in the document based on the height of
        // the printing area and the height of the font.

		int intLineCount= (int)(intPrintAreaHeight / font.Height);

        // Initialize the rectangle structure that defines the printing area.

		RectangleF rectPrintingArea = new RectangleF(marginLeft, marginTop, intPrintAreaWidth, intPrintAreaHeight);

        // Instantiate the stringFormat class, which encapsulates text layout 
        // information (such alignment and line spacing), display manipulations 
        // (such ellipsis insertion and national digit substitution) and OpenType 
        // features. Use of stringFormat causes Measurestring and Drawstring to use
        // only an integer number of lines when printing each page, ignoring partial
        // lines that would otherwise likely be printed if the number of lines per 
        // page do not divide up cleanly for each page (which is usually the case).
        // See further discussion in the SDK documentation about stringFormatFlags.

		StringFormat fmt = new StringFormat(StringFormatFlags.LineLimit);

        // Call Measurestring to determine the number of characters that will fit in
        // the printing area rectangle. The CharFitted Int32 is passed ref and used
        // later when calculating intCurrentChar and thus HasMorePages. LinesFilled 
        // is ! needed for this sample but must be passed when passing CharsFitted.
        // Mid is used to pass the segment of remaining text left off from the 
        // previous page of printing (recall that intCurrentChar was declared 
        // static.

		int intLinesFilled;
		int intCharsFitted;

		e.Graphics.MeasureString(txtDocument.Text.Substring(intCurrentChar), font,new SizeF(intPrintAreaWidth, intPrintAreaHeight), fmt,out intCharsFitted, out intLinesFilled);

        // Print the text to the page.
		
		e.Graphics.DrawString(txtDocument.Text.Substring(intCurrentChar), font,Brushes.Black, rectPrintingArea, fmt);

        // Advance the current char to the last char printed on this page. 
        // intCurrentChar is a static variable, its value can be used for the next
        // page to be printed. It is advanced by 1 and passed to Mid() to print the
        // next page (see above in Measurestring()).

		intCurrentChar += intCharsFitted;

        // HasMorePages tells the printing module whether another PrintPage event
        // should be fired.

		if (intCurrentChar < (txtDocument.Text.Length-1)) 
		{
		e.HasMorePages = true;
		}
		else 
		{
		e.HasMorePages = false;
		// You must explicitly reset intCurrentChar it is static.
		intCurrentChar = 0;
		}
}
}

