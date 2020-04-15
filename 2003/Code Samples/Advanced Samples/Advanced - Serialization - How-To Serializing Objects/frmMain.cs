//Copyright (C) 2002 Microsoft Corporation
//All rights reserved.
//THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, EITHER 
//EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED WARRANTIES OF 
//MERCHANTIBILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
//Requires the Trial or Release version of Visual Studio .NET Professional (or greater).

using System;
using System.Windows.Forms;
using System.IO; //Namespace for Filestreams
using System.Runtime.Serialization.Formatters.Binary; //Namespace for BinaryFormatter

//Need to reference System.Runtime.Serialization.Formatters.Soap for this Import
using System.Runtime.Serialization.Formatters.Soap;

public class frmMain: System.Windows.Forms.Form 
{
	// These variables are initialized in the Form_Load event.
	private string strFileName1;
	private string strFileName2;
	private string strFileName3;

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
		if (disposing) {
			if (components != null) {
				components.Dispose();
			}
		}
		base.Dispose(disposing);
	}

	//Required by the Windows Form Designer
	private System.ComponentModel.IContainer components = null;

	//NOTE: The following procedure is required by the Windows Form Designer
	//It can be modified using the Windows Form Designer.  
	//Do not modify it using the code editor.

	private System.Windows.Forms.MainMenu mnuMain;
	private System.Windows.Forms.MenuItem mnuFile;
	private System.Windows.Forms.MenuItem mnuExit;
	private System.Windows.Forms.MenuItem mnuHelp;
	private System.Windows.Forms.MenuItem mnuAbout;
	private System.Windows.Forms.Button cmdCustomDeserialization;
	private System.Windows.Forms.Button cmdCustomSerialization;
	private System.Windows.Forms.GroupBox grpCustomSerialization;
	private System.Windows.Forms.GroupBox grpDefaultSerializationSoap;
	private System.Windows.Forms.GroupBox grpDefaultSerializationBinary;
	private System.Windows.Forms.Button cmdStandardSerializationBinary;
	private System.Windows.Forms.Button cmdStandardDeserializationSoap;
	private System.Windows.Forms.Button cmdStandardSerializationSoap;
	private System.Windows.Forms.Button cmdStandardDeserializationBinary;
	private System.Windows.Forms.GroupBox DataValues;
	private System.Windows.Forms.TextBox txtX;
	private System.Windows.Forms.Label lblx;
	private System.Windows.Forms.TextBox txtY;
	private System.Windows.Forms.Label lbly;
	private System.Windows.Forms.TextBox txtZ;
	private System.Windows.Forms.Label lblz;
	private System.Windows.Forms.Label Label1;
	private System.Windows.Forms.Label Label2;
	private System.Windows.Forms.Label Label3;
	private System.Windows.Forms.Label Label4;
	private System.Windows.Forms.Label Label5;
	private System.Windows.Forms.TextBox txtYAfter;
	private System.Windows.Forms.TextBox txtXAfter;
	private System.Windows.Forms.TextBox txtZAfter;
	private System.Windows.Forms.Button cmdViewClass1;
	private System.Windows.Forms.TextBox txtView;
	private System.Windows.Forms.Button cmdViewClass2;
	private System.Windows.Forms.StatusBar sbFilePath;

	private void InitializeComponent() 
	{
		System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(frmMain));

		this.mnuMain = new System.Windows.Forms.MainMenu();
		this.mnuFile = new System.Windows.Forms.MenuItem();
		this.mnuExit = new System.Windows.Forms.MenuItem();
		this.mnuHelp = new System.Windows.Forms.MenuItem();
		this.mnuAbout = new System.Windows.Forms.MenuItem();
		this.grpDefaultSerializationSoap = new System.Windows.Forms.GroupBox();
		this.cmdStandardDeserializationSoap = new System.Windows.Forms.Button();
		this.cmdStandardSerializationSoap = new System.Windows.Forms.Button();
		this.grpCustomSerialization = new System.Windows.Forms.GroupBox();
		this.cmdCustomDeserialization = new System.Windows.Forms.Button();
		this.cmdCustomSerialization = new System.Windows.Forms.Button();
		this.grpDefaultSerializationBinary = new System.Windows.Forms.GroupBox();
		this.cmdStandardDeserializationBinary = new System.Windows.Forms.Button();
		this.cmdStandardSerializationBinary = new System.Windows.Forms.Button();
		this.DataValues = new System.Windows.Forms.GroupBox();
		this.Label5 = new System.Windows.Forms.Label();
		this.txtZAfter = new System.Windows.Forms.TextBox();
		this.Label1 = new System.Windows.Forms.Label();
		this.txtYAfter = new System.Windows.Forms.TextBox();
		this.Label2 = new System.Windows.Forms.Label();
		this.txtXAfter = new System.Windows.Forms.TextBox();
		this.Label3 = new System.Windows.Forms.Label();
		this.txtZ = new System.Windows.Forms.TextBox();
		this.lblz = new System.Windows.Forms.Label();
		this.txtY = new System.Windows.Forms.TextBox();
		this.lbly = new System.Windows.Forms.Label();
		this.txtX = new System.Windows.Forms.TextBox();
		this.lblx = new System.Windows.Forms.Label();
		this.Label4 = new System.Windows.Forms.Label();
		this.cmdViewClass1 = new System.Windows.Forms.Button();
		this.txtView = new System.Windows.Forms.TextBox();
		this.cmdViewClass2 = new System.Windows.Forms.Button();
		this.sbFilePath = new System.Windows.Forms.StatusBar();
		this.grpDefaultSerializationSoap.SuspendLayout();
		this.grpCustomSerialization.SuspendLayout();
		this.grpDefaultSerializationBinary.SuspendLayout();
		this.DataValues.SuspendLayout();
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
		this.mnuExit.Click += new EventHandler(mnuExit_Click);
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
		this.mnuAbout.Click += new EventHandler(mnuAbout_Click);
		//
		//grpDefaultSerializationSoap
		//
		this.grpDefaultSerializationSoap.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
		this.grpDefaultSerializationSoap.Controls.AddRange(new System.Windows.Forms.Control[] {this.cmdStandardDeserializationSoap, this.cmdStandardSerializationSoap});
		this.grpDefaultSerializationSoap.Location = new System.Drawing.Point(24, 24);
		this.grpDefaultSerializationSoap.Name = "grpDefaultSerializationSoap";
		this.grpDefaultSerializationSoap.Size = new System.Drawing.Size(232, 96);
		this.grpDefaultSerializationSoap.TabIndex = 0;
		this.grpDefaultSerializationSoap.TabStop = false;
		this.grpDefaultSerializationSoap.Text = "Default Serialization with &Soap Formatter";
		//
		//cmdStandardDeserializationSoap
		//
		this.cmdStandardDeserializationSoap.Anchor = ((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right);
		this.cmdStandardDeserializationSoap.Enabled = false;
		this.cmdStandardDeserializationSoap.ImeMode = System.Windows.Forms.ImeMode.NoControl;
		this.cmdStandardDeserializationSoap.Location = new System.Drawing.Point(16, 56);
		this.cmdStandardDeserializationSoap.Name = "cmdStandardDeserializationSoap";
		this.cmdStandardDeserializationSoap.Size = new System.Drawing.Size(200, 23);
		this.cmdStandardDeserializationSoap.TabIndex = 2;
		this.cmdStandardDeserializationSoap.Text = "&Deserialize Class1 Instance";
		this.cmdStandardDeserializationSoap.Click += new EventHandler(cmdStandardDeserializationSoap_Click);
		//
		//cmdStandardSerializationSoap
		//
		this.cmdStandardSerializationSoap.Anchor = ((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right);
		this.cmdStandardSerializationSoap.ImeMode = System.Windows.Forms.ImeMode.NoControl;
		this.cmdStandardSerializationSoap.Location = new System.Drawing.Point(16, 24);
		this.cmdStandardSerializationSoap.Name = "cmdStandardSerializationSoap";
		this.cmdStandardSerializationSoap.Size = new System.Drawing.Size(200, 23);
		this.cmdStandardSerializationSoap.TabIndex = 1;
		this.cmdStandardSerializationSoap.Text = "S&erialize Class1 Instance";
		this.cmdStandardSerializationSoap.Click += new EventHandler(cmdStandardSerializationSoap_Click);
		//
		//grpCustomSerialization
		//
		this.grpCustomSerialization.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
		this.grpCustomSerialization.Controls.AddRange(new System.Windows.Forms.Control[] {this.cmdCustomDeserialization, this.cmdCustomSerialization});
		this.grpCustomSerialization.Location = new System.Drawing.Point(264, 136);
		this.grpCustomSerialization.Name = "grpCustomSerialization";
		this.grpCustomSerialization.Size = new System.Drawing.Size(232, 96);
		this.grpCustomSerialization.TabIndex = 21;
		this.grpCustomSerialization.TabStop = false;
		this.grpCustomSerialization.Text = "&Custom Serialization";
		//
		//cmdCustomDeserialization
		//
		this.cmdCustomDeserialization.Anchor = ((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right);
		this.cmdCustomDeserialization.Enabled = false;
		this.cmdCustomDeserialization.ImeMode = System.Windows.Forms.ImeMode.NoControl;
		this.cmdCustomDeserialization.Location = new System.Drawing.Point(16, 56);
		this.cmdCustomDeserialization.Name = "cmdCustomDeserialization";
		this.cmdCustomDeserialization.Size = new System.Drawing.Size(200, 23);
		this.cmdCustomDeserialization.TabIndex = 23;
		this.cmdCustomDeserialization.Text = "Deseriali&ze Class2 Instance";
		this.cmdCustomDeserialization.Click += new EventHandler(cmdCustomDeserialization_Click);
		//
		//cmdCustomSerialization
		//
		this.cmdCustomSerialization.Anchor = ((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right);
		this.cmdCustomSerialization.ImeMode = System.Windows.Forms.ImeMode.NoControl;
		this.cmdCustomSerialization.Location = new System.Drawing.Point(16, 24);
		this.cmdCustomSerialization.Name = "cmdCustomSerialization";
		this.cmdCustomSerialization.Size = new System.Drawing.Size(200, 23);
		this.cmdCustomSerialization.TabIndex = 22;
		this.cmdCustomSerialization.Text = "Seria&lize Class2 Instance";
		this.cmdCustomSerialization.Click += new EventHandler(cmdCustomSerialization_Click);
		//
		//grpDefaultSerializationBinary
		//
		this.grpDefaultSerializationBinary.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
		this.grpDefaultSerializationBinary.Controls.AddRange(new System.Windows.Forms.Control[] {this.cmdStandardDeserializationBinary, this.cmdStandardSerializationBinary});
		this.grpDefaultSerializationBinary.Location = new System.Drawing.Point(24, 136);
		this.grpDefaultSerializationBinary.Name = "grpDefaultSerializationBinary";
		this.grpDefaultSerializationBinary.Size = new System.Drawing.Size(232, 96);
		this.grpDefaultSerializationBinary.TabIndex = 18;
		this.grpDefaultSerializationBinary.TabStop = false;
		this.grpDefaultSerializationBinary.Text = "Default Serialization with Bi&nary Formatter";
		//
		//cmdStandardDeserializationBinary
		//
		this.cmdStandardDeserializationBinary.Anchor = ((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right);
		this.cmdStandardDeserializationBinary.Enabled = false;
		this.cmdStandardDeserializationBinary.ImeMode = System.Windows.Forms.ImeMode.NoControl;
		this.cmdStandardDeserializationBinary.Location = new System.Drawing.Point(16, 56);
		this.cmdStandardDeserializationBinary.Name = "cmdStandardDeserializationBinary";
		this.cmdStandardDeserializationBinary.Size = new System.Drawing.Size(200, 23);
		this.cmdStandardDeserializationBinary.TabIndex = 20;
		this.cmdStandardDeserializationBinary.Text = "Deser&ialize Class1 Instance";
		this.cmdStandardDeserializationBinary.Click += new EventHandler(cmdStandardDeserializationBinary_Click);
		//
		//cmdStandardSerializationBinary
		//
		this.cmdStandardSerializationBinary.Anchor = ((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right);
		this.cmdStandardSerializationBinary.ImeMode = System.Windows.Forms.ImeMode.NoControl;
		this.cmdStandardSerializationBinary.Location = new System.Drawing.Point(16, 24);
		this.cmdStandardSerializationBinary.Name = "cmdStandardSerializationBinary";
		this.cmdStandardSerializationBinary.Size = new System.Drawing.Size(200, 23);
		this.cmdStandardSerializationBinary.TabIndex = 19;
		this.cmdStandardSerializationBinary.Text = "Se&rialize Class1 Instance";
		this.cmdStandardSerializationBinary.Click += new EventHandler(cmdStandardSerializationBinary_Click);
		//
		//DataValues
		//
		this.DataValues.Controls.AddRange(new System.Windows.Forms.Control[] {this.Label5, this.txtZAfter, this.Label1, this.txtYAfter, this.Label2, this.txtXAfter, this.Label3, this.txtZ, this.lblz, this.txtY, this.lbly, this.txtX, this.lblx, this.Label4});
		this.DataValues.Location = new System.Drawing.Point(264, 24);
		this.DataValues.Name = "DataValues";
		this.DataValues.Size = new System.Drawing.Size(232, 98);
		this.DataValues.TabIndex = 3;
		this.DataValues.TabStop = false;
		this.DataValues.Text = "Da&ta Values for Instance";
		//
		//Label5
		//
		this.Label5.ImeMode = System.Windows.Forms.ImeMode.NoControl;
		this.Label5.Location = new System.Drawing.Point(128, 48);
		this.Label5.Name = "Label5";
		this.Label5.Size = new System.Drawing.Size(32, 24);
		this.Label5.TabIndex = 11;
		this.Label5.Text = "&After";
		//
		//txtZAfter
		//
		this.txtZAfter.Location = new System.Drawing.Point(176, 72);
		this.txtZAfter.MaxLength = 3;
		this.txtZAfter.Name = "txtZAfter";
		this.txtZAfter.ReadOnly = true;
		this.txtZAfter.Size = new System.Drawing.Size(40, 20);
		this.txtZAfter.TabIndex = 17;
		this.txtZAfter.Text = "";
		//
		//Label1
		//
		this.Label1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
		this.Label1.Location = new System.Drawing.Point(160, 72);
		this.Label1.Name = "Label1";
		this.Label1.Size = new System.Drawing.Size(24, 16);
		this.Label1.TabIndex = 16;
		this.Label1.Text = "z:";
		//
		//txtYAfter
		//
		this.txtYAfter.Location = new System.Drawing.Point(176, 48);
		this.txtYAfter.MaxLength = 3;
		this.txtYAfter.Name = "txtYAfter";
		this.txtYAfter.ReadOnly = true;
		this.txtYAfter.Size = new System.Drawing.Size(40, 20);
		this.txtYAfter.TabIndex = 15;
		this.txtYAfter.Text = "";
		//
		//Label2
		//
		this.Label2.ImeMode = System.Windows.Forms.ImeMode.NoControl;
		this.Label2.Location = new System.Drawing.Point(160, 48);
		this.Label2.Name = "Label2";
		this.Label2.Size = new System.Drawing.Size(24, 16);
		this.Label2.TabIndex = 14;
		this.Label2.Text = "y:";
		//
		//txtXAfter
		//
		this.txtXAfter.Location = new System.Drawing.Point(176, 24);
		this.txtXAfter.MaxLength = 3;
		this.txtXAfter.Name = "txtXAfter";
		this.txtXAfter.ReadOnly = true;
		this.txtXAfter.Size = new System.Drawing.Size(40, 20);
		this.txtXAfter.TabIndex = 13;
		this.txtXAfter.Text = "";
		//
		//Label3
		//
		this.Label3.ImeMode = System.Windows.Forms.ImeMode.NoControl;
		this.Label3.Location = new System.Drawing.Point(160, 24);
		this.Label3.Name = "Label3";

		this.Label3.Size = new System.Drawing.Size(24, 16);

		this.Label3.TabIndex = 12;

		this.Label3.Text = "x:";

		//

		//txtZ

		//

		this.txtZ.Location = new System.Drawing.Point(67, 72);

		this.txtZ.MaxLength = 3;

		this.txtZ.Name = "txtZ";

		this.txtZ.Size = new System.Drawing.Size(40, 20);

		this.txtZ.TabIndex = 10;

		this.txtZ.Text = "3";
		this.txtZ.Validating += new System.ComponentModel.CancelEventHandler(ValidatingTextIsInt32);

		//

		//lblz

		//

		this.lblz.ImeMode = System.Windows.Forms.ImeMode.NoControl;

		this.lblz.Location = new System.Drawing.Point(51, 74);

		this.lblz.Name = "lblz";

		this.lblz.Size = new System.Drawing.Size(24, 16);

		this.lblz.TabIndex = 9;

		this.lblz.Text = "&z:";

		//

		//txtY

		//

		this.txtY.Location = new System.Drawing.Point(67, 48);

		this.txtY.MaxLength = 3;

		this.txtY.Name = "txtY";

		this.txtY.Size = new System.Drawing.Size(40, 20);

		this.txtY.TabIndex = 8;

		this.txtY.Text = "2";
		this.txtY.Validating += new System.ComponentModel.CancelEventHandler(ValidatingTextIsInt32);

		//

		//lbly

		//

		this.lbly.ImeMode = System.Windows.Forms.ImeMode.NoControl;

		this.lbly.Location = new System.Drawing.Point(51, 50);

		this.lbly.Name = "lbly";

		this.lbly.Size = new System.Drawing.Size(24, 16);

		this.lbly.TabIndex = 7;

		this.lbly.Text = "&y:";

		//

		//txtX

		//

		this.txtX.Location = new System.Drawing.Point(67, 24);

		this.txtX.MaxLength = 3;

		this.txtX.Name = "txtX";

		this.txtX.Size = new System.Drawing.Size(40, 20);

		this.txtX.TabIndex = 6;

		this.txtX.Text = "1";
		this.txtX.Validating += new System.ComponentModel.CancelEventHandler(ValidatingTextIsInt32);

		//

		//lblx

		//

		this.lblx.ImeMode = System.Windows.Forms.ImeMode.NoControl;

		this.lblx.Location = new System.Drawing.Point(51, 26);

		this.lblx.Name = "lblx";

		this.lblx.Size = new System.Drawing.Size(24, 16);

		this.lblx.TabIndex = 5;

		this.lblx.Text = "&x:";

		//

		//Label4

		//

		this.Label4.ImeMode = System.Windows.Forms.ImeMode.NoControl;

		this.Label4.Location = new System.Drawing.Point(8, 48);

		this.Label4.Name = "Label4";

		this.Label4.Size = new System.Drawing.Size(48, 24);

		this.Label4.TabIndex = 4;

		this.Label4.Text = "&Before";

		//

		//cmdViewClass1

		//

		this.cmdViewClass1.Enabled = false;

		this.cmdViewClass1.ImeMode = System.Windows.Forms.ImeMode.NoControl;

		this.cmdViewClass1.Location = new System.Drawing.Point(40, 248);

		this.cmdViewClass1.Name = "cmdViewClass1";

		this.cmdViewClass1.Size = new System.Drawing.Size(200, 24);

		this.cmdViewClass1.TabIndex = 24;

		this.cmdViewClass1.Text = "&View Serialized Class1 SOAP file";
		this.cmdViewClass1.Click += new EventHandler(cmdViewClass1_Click);

		//

		//txtView

		//

		this.txtView.Location = new System.Drawing.Point(24, 288);

		this.txtView.Multiline = true;

		this.txtView.Name = "txtView";

		this.txtView.ReadOnly = true;

		this.txtView.Size = new System.Drawing.Size(472, 232);

		this.txtView.TabIndex = 26;

		this.txtView.Text = "";

		//

		//cmdViewClass2

		//

		this.cmdViewClass2.Enabled = false;

		this.cmdViewClass2.ImeMode = System.Windows.Forms.ImeMode.NoControl;

		this.cmdViewClass2.Location = new System.Drawing.Point(280, 248);

		this.cmdViewClass2.Name = "cmdViewClass2";

		this.cmdViewClass2.Size = new System.Drawing.Size(200, 24);

		this.cmdViewClass2.TabIndex = 25;

		this.cmdViewClass2.Text = "Vie&w Serialized Class2 SOAP file";
		this.cmdViewClass2.Click += new EventHandler(cmdViewClass2_Click);

		//

		//sbFilePath

		//

		this.sbFilePath.Location = new System.Drawing.Point(0, 531);

		this.sbFilePath.Name = "sbFilePath";

		this.sbFilePath.Size = new System.Drawing.Size(522, 24);

		this.sbFilePath.TabIndex = 27;

		this.sbFilePath.Text = "File Location";

		//

		//frmMain

		//

		this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);

		this.ClientSize = new System.Drawing.Size(522, 555);

		this.Controls.AddRange(new System.Windows.Forms.Control[] {this.sbFilePath, this.cmdViewClass2, this.txtView, this.cmdViewClass1, this.DataValues, this.grpDefaultSerializationBinary, this.grpDefaultSerializationSoap, this.grpCustomSerialization});

		this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;

		this.Icon = (System.Drawing.Icon) resources.GetObject("$this.Icon");

		this.MaximizeBox = false;

		this.Menu = this.mnuMain;

		this.Name = "frmMain";

		this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;

		this.Text = "Title Comes from Assembly Info";

		this.grpDefaultSerializationSoap.ResumeLayout(false);

		this.grpCustomSerialization.ResumeLayout(false);

		this.grpDefaultSerializationBinary.ResumeLayout(false);

		this.DataValues.ResumeLayout(false);

		this.ResumeLayout(false);
		this.Load += new EventHandler(frmMain_Load);
	}

#endregion

	/// <summary>
	/// The main entry point for the application.
	/// </summary>
	[STAThread]
	static void Main() 
	{
		Application.Run(new frmMain());
	}

#region " Standard Menu Code "
	// has been added to some procedures since they are
	// not the focus of the demo. Remove them if you wish to debug the procedures.
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

	private void cmdStandardSerializationSoap_Click(object sender, System.EventArgs e)
	{
		//This routine creates a new instance of Class1, then serializes it to
		//the file Class1File.xml with the SOAP Formatter.
		//Create the object to be serialized
		Class1 c = new Class1(int.Parse(txtX.Text), int.Parse(txtY.Text), int.Parse(txtZ.Text));
		//Get a filestream that writes to the file specified by strFileName1

		FileStream fs = new FileStream(strFileName1, FileMode.OpenOrCreate);

		//Get a SOAP Formatter instance
		SoapFormatter sf = new SoapFormatter();

		//Serialize c to strFileName1
		sf.Serialize(fs, c);

		//Close the file and release resources (avoids GC delays)
		fs.Close();

		//Deserialization is now available
		cmdStandardDeserializationSoap.Enabled = true;
		cmdViewClass1.Enabled = true;
	}

	private void cmdStandardDeserializationSoap_Click(object sender, System.EventArgs e)
	{
		//This routine deserializes an object from the file Class1File.xml
		//and assigns it to a Class1 reference.
		//Declare the reference that will point to the object to be deserialized
		Class1 c;

		//Get a filestream that reads from strFileName1
		FileStream fs = new FileStream(strFileName1, FileMode.Open);

		//get {a SOAP Formatter instance
		SoapFormatter sf = new SoapFormatter();

		//Deserialize c from strFileName1
		//Note that the deserialized object must be cast to the proper type.
		c = (Class1) sf.Deserialize(fs);

		//close the file and release resources (avoids GC delays)
		fs.Close();

		//Put the deserialized values for the fields into the textboxes
		txtXAfter.Text = c.x.ToString();
		txtYAfter.Text = c.GetY.ToString();
		txtZAfter.Text = c.z.ToString();

		//Reset buttons after deserializing
		cmdStandardDeserializationSoap.Enabled = false;
		cmdViewClass1.Enabled = false;
	}

	private void cmdStandardSerializationBinary_Click(object sender, System.EventArgs e)
	{
		//This routine creates a new instance of Class1, then serializes it to 
		//the file Class1File.dat using the Binary formatter.

		//Create the object to be serialized
		Class1 c = new Class1(int.Parse(txtX.Text), int.Parse(txtY.Text), int.Parse(txtZ.Text));

		//Get a filestream that writes to strFilename2
		FileStream fs = new FileStream(strFileName2, FileMode.OpenOrCreate);

		//Get a Binary Formatter instance
		BinaryFormatter bf = new BinaryFormatter();

		//Serialize c to strFileName2
		bf.Serialize(fs, c);

		//Close the file and release resources (avoids GC delays)
		fs.Close();

		//Deserialization is now available
		cmdStandardDeserializationBinary.Enabled = true;
	}

	private void cmdStandardDeserializationBinary_Click(object sender, System.EventArgs e) 
	{
		//This routine deserializes an object from the file Class1File.dat
		//and assigns it to a Class1 reference.
		//Declare the reference that will point to the object to be deserialized
		Class1 c;

		//Get a filestream that reads from strFilename2
		FileStream fs = new FileStream(strFileName2, FileMode.Open);

		//Get a Binary Formatter instance
		BinaryFormatter bf = new BinaryFormatter();

		//Deserialize c from strFilename2
		//Note that the deserialized object must be cast to the proper type.
		c = (Class1) bf.Deserialize(fs);

		//Close the file and release resources (avoids GC delays)
		fs.Close();

		//Put the deserialized values for the fields into the textboxes
		txtXAfter.Text = c.x.ToString();
		txtYAfter.Text = c.GetY.ToString();
		txtZAfter.Text = c.z.ToString();

		//Reset button after deserializing
		cmdStandardDeserializationBinary.Enabled = false;
	}

	private void cmdCustomSerialization_Click(object sender, System.EventArgs e)
	{
		//This routine creates a new instance of Class1, then serializes it to
		//the file Class2File.xml with the SOAP Formatter. Note that even though
		//class2 has custom serialization, the client code is identical to that
		//of standard serialization. The difference is in the class code, not the
		//client code.

		//Create the object to be serialized
		Class2 c = new Class2(int.Parse(txtX.Text), int.Parse(txtY.Text), int.Parse(txtZ.Text));

		//Get a filestream that writes to strFileName3
		FileStream fs = new FileStream(strFileName3, FileMode.OpenOrCreate);

		//get {a SOAP Formatter instance
		SoapFormatter sf = new SoapFormatter();

		//Serialize c to strFileName3
		sf.Serialize(fs, c);

		//Close the file and release resources (avoids GC delays)
		fs.Close();

		//Deserialization is now available
		cmdCustomDeserialization.Enabled = true;
		cmdViewClass2.Enabled = true;
	}

	private void cmdCustomDeserialization_Click(object sender, System.EventArgs e) 
	{
		//This routine deserializes an object from the file Class2File.xml
		//and assigns it to a Class2 reference. Note that even though
		//class2 has custom serialization, the client code is identical to that
		//of standard serialization. The difference is in the class code, not the
		//client code.

		//Declare the reference that will point to the object to be deserialized
		Class2 c;

		//Get a filestream that reads from strFileName3
		FileStream fs = new FileStream(strFileName3, FileMode.Open);

		//Get a SOAP Formatter instance
		SoapFormatter sf = new SoapFormatter();

		//Deserialize c from strFileName3
		//Note that the deserialized object must be cast to the proper type.
		c = (Class2) sf.Deserialize(fs);

		//close the file and release resources (avoids GC delays)
		fs.Close();

		//Put the deserialized values for the fields into the textboxes
		txtXAfter.Text = c.x.ToString();
		txtYAfter.Text = c.GetY.ToString();
		txtZAfter.Text = c.z.ToString();

		//Reset button after deserializing
		cmdCustomDeserialization.Enabled = false;
		cmdViewClass2.Enabled = false;
	}

	private void cmdViewClass1_Click(object sender, System.EventArgs e)
	{
		//Dump the file contents into a textbox. This routine quickly copies the file
		//contents into a read-only textbox. It merely let's the user examine the 
		//serialized object state of Class1.

		FileStream fs = new FileStream(strFileName1, FileMode.Open);
		StreamReader sr = new StreamReader(fs);

		txtView.Text = sr.ReadToEnd();

		sr.Close();
		fs.Close();
	}

	private void cmdViewClass2_Click(object sender, System.EventArgs e)
	{
		//Dump the file contents into a textbox. This routine quickly copies the file
		//contents into a read-only textbox. It merely let's the user examine the 
		//serialized object state of Class2.

		FileStream fs = new FileStream(strFileName3, FileMode.Open);
		StreamReader sr = new StreamReader(fs);

		txtView.Text = sr.ReadToEnd();

		sr.Close();
		fs.Close();
	}

	private void frmMain_Load(object sender, System.EventArgs e)
	{
		// Get the system temp path using the Path class
		// in the System.Io namespace
		string strTempPath = Path.GetTempPath();

		strFileName1 = strTempPath + "Class1File.xml";
		strFileName2 = strTempPath + "Class1File.dat";
		strFileName3 = strTempPath + "Class2File.xml";
		
		this.sbFilePath.Text = "All files will be written to " + strTempPath;
	}

	private bool IsValidInt32(string Data)
	{
		// This is an similar to the VB function IsNumeric 
		// that works for Int32 data only. C# do not have IsNumeric.

		try 
		{
			int i;
			i = System.Convert.ToInt32(Data);

			return true;
		}
		catch(FormatException exp)
		{	
			// The conversion failed.
			return false;
		}
		catch(Exception exp)
		{
			// Just in case some other wierd error occurs.
			return false;
		}
	}

	private void ValidatingTextIsInt32(object sender, System.ComponentModel.CancelEventArgs e)
	{
		// Make sure the value entered can be converted to an Int32 (int)
		TextBox txt = (TextBox) sender;

		if (!IsValidInt32(txt.Text))
		{
			string strMsg;
			strMsg = string.Format("The value you entered {0} is not a valid 32-bit integer. Value will be changed to zero.", txt.Text);

			MessageBox.Show(strMsg, "Validation Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

			txt.Text = "0";
		}
	}
}
