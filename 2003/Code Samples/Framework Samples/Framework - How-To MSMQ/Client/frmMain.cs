//Copyright (C) 2002 Microsoft Corporation
//All rights reserved.
//THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, EITHER 
//EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED WARRANTIES OF 
//MERCHANTIBILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
//Requires the Trial or Release version of Visual Studio .NET Professional (or greater).

using System;
using System.Windows.Forms;
using System.Messaging;


public class frmMain:System.Windows.Forms.Form 
{
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

	protected override void Dispose(bool disposing) {

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

	internal System.Windows.Forms.Label Label1;

	internal System.Windows.Forms.Label Label2;

	internal System.Windows.Forms.Label Label3;

	internal System.Windows.Forms.TextBox txtOrderNumber;

	internal System.Windows.Forms.TextBox txtCustomer;

	internal System.Windows.Forms.TextBox txtReqDate;

	internal System.Messaging.MessageQueue qOrders;

	internal System.Windows.Forms.Button cmdSend;

	internal System.Windows.Forms.Button cmdScanQ;

	internal System.Windows.Forms.ListBox lstMessages;

	private void InitializeComponent() 
	{

		System.Configuration.AppSettingsReader configurationAppSettings  = new System.Configuration.AppSettingsReader();

		System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(frmMain));

		this.mnuMain = new System.Windows.Forms.MainMenu();

		this.mnuFile = new System.Windows.Forms.MenuItem();

		this.mnuExit = new System.Windows.Forms.MenuItem();

		this.mnuHelp = new System.Windows.Forms.MenuItem();

		this.mnuAbout = new System.Windows.Forms.MenuItem();

		this.Label1 = new System.Windows.Forms.Label();

		this.txtOrderNumber = new System.Windows.Forms.TextBox();

		this.txtCustomer = new System.Windows.Forms.TextBox();

		this.Label2 = new System.Windows.Forms.Label();

		this.txtReqDate = new System.Windows.Forms.TextBox();

		this.Label3 = new System.Windows.Forms.Label();

		this.cmdSend = new System.Windows.Forms.Button();

		this.qOrders = new System.Messaging.MessageQueue();

		this.cmdScanQ = new System.Windows.Forms.Button();

		this.lstMessages = new System.Windows.Forms.ListBox();

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

		this.mnuExit.Click+=new EventHandler(mnuExit_Click);

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

		this.mnuAbout.Click+=new EventHandler(mnuAbout_Click);

		//

		//Label1

		//

		this.Label1.Location = new System.Drawing.Point(8, 8);

		this.Label1.Name = "Label1";

		this.Label1.TabIndex = 0;

		this.Label1.Text = "&Order Number";

		//

		//txtOrderNumber

		//

		this.txtOrderNumber.Location = new System.Drawing.Point(112, 8);

		this.txtOrderNumber.Name = "txtOrderNumber";

		this.txtOrderNumber.TabIndex = 1;

		this.txtOrderNumber.Text = "100";

		this.txtOrderNumber.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;

		//

		//txtCustomer

		//

		this.txtCustomer.Location = new System.Drawing.Point(112, 48);

		this.txtCustomer.Name = "txtCustomer";

		this.txtCustomer.TabIndex = 3;

		this.txtCustomer.Text = "Super Customer";

		//

		//Label2

		//

		this.Label2.Location = new System.Drawing.Point(8, 48);

		this.Label2.Name = "Label2";

		this.Label2.TabIndex = 2;

		this.Label2.Text = "&Customer";

		//

		//txtReqDate

		//

		this.txtReqDate.Location = new System.Drawing.Point(112, 88);

		this.txtReqDate.Name = "txtReqDate";

		this.txtReqDate.TabIndex = 5;

		this.txtReqDate.Text = string.Empty;

		this.txtReqDate.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;

		//

		//Label3

		//

		this.Label3.Location = new System.Drawing.Point(8, 96);

		this.Label3.Name = "Label3";

		this.Label3.TabIndex = 4;

		this.Label3.Text = "&Required Date";

		//

		//cmdSend

		//

		this.cmdSend.Location = new System.Drawing.Point(8, 128);

		this.cmdSend.Name = "cmdSend";

		this.cmdSend.TabIndex = 6;

		this.cmdSend.Text = "&Send Order";

		this.cmdSend.Click+=new EventHandler(cmdSend_Click);

		

		//

		//qOrders

		//

		this.qOrders.Formatter = new System.Messaging.XmlMessageFormatter(new string[] {});

		this.qOrders.Path = (string) configurationAppSettings.GetValue("qOrders.Path",typeof(System.String));
	
		this.qOrders.SynchronizingObject = this;

		//

		//cmdScanQ

		//

		this.cmdScanQ.Location = new System.Drawing.Point(232, 128);

		this.cmdScanQ.Name = "cmdScanQ";

		this.cmdScanQ.Size = new System.Drawing.Size(216, 23);

		this.cmdScanQ.TabIndex = 8;

		this.cmdScanQ.Text = "&List Messages in Queue";

		this.cmdScanQ.Click+=new EventHandler(cmdScanQ_Click);

		//

		//lstMessages

		//

		this.lstMessages.Location = new System.Drawing.Point(232, 8);

		this.lstMessages.Name = "lstMessages";

		this.lstMessages.Size = new System.Drawing.Size(216, 108);

		this.lstMessages.TabIndex = 7;

		//

		//frmMain

		//

		this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);

		this.ClientSize = new System.Drawing.Size(458, 163);

		this.Controls.AddRange(new System.Windows.Forms.Control[] {this.lstMessages, this.cmdScanQ, this.cmdSend, this.txtReqDate, this.Label3, this.txtCustomer, this.Label2, this.txtOrderNumber, this.Label1});

		this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;

		this.Icon = (System.Drawing.Icon) resources.GetObject("$this.Icon");

		this.MaximizeBox = false;

		this.Menu = this.mnuMain;

		this.Name = "frmMain";

		this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;

		this.Text = "Title Comes from Assembly Info";

		this.Load+=new EventHandler(frmMain_Load);

		this.ResumeLayout(false);

	}

#endregion

#region " Standard Menu Code "

	

	

	// This code simply shows the About form.

	private void mnuAbout_Click(object sender, System.EventArgs e) {

		// Open the About form in Dialog Mode

		frmAbout frm = new frmAbout();

		frm.ShowDialog(this);

		frm.Dispose();

	}

	// This code will close the form.

	private void mnuExit_Click(object sender, System.EventArgs e) {

		// Close the current form

		this.Close();

	}

#endregion

	private void cmdSend_Click(object sender, System.EventArgs e)
	{

		// We create a message and then
		// post it to the Orders queue.
		// The path to the queue is stored 
		// a dynamic property that can be changed
		// by modifying the value in the program's
		// .config file.

		try 
		{

			// Create an object instance like normal
		
			MSMQOrders o = new MSMQOrders();
			

			// Set some properties

			o.Number = Convert.ToInt32(this.txtOrderNumber.Text);
			o.Customer = this.txtCustomer.Text;
			o.RequiredBy = Convert.ToDateTime(this.txtReqDate.Text);

			// send it to the queue

			this.qOrders.Send(o, "New Order: " + o.Number);

			// Up our order number (! necessary, just for show)

			this.txtOrderNumber.Text = (o.Number + 1).ToString();
		}
		catch (Exception exp) 
		{

			MessageBox.Show(exp.Message, exp.Source, MessageBoxButtons.OK, MessageBoxIcon.Error);

		}

	}

	private void frmMain_Load(object sender, System.EventArgs e) 
	{

		// Set our Required Date to a data 5 days from today's date

		DateTime d  = DateTime.Today.AddDays(5);

		this.txtReqDate.Text = d.ToShortDateString();

	}

	private void cmdScanQ_Click(object sender, System.EventArgs e)
	{

		// Scan the queue for messages that
		// have not been received.
		// This is scan does not remove messages.

		try 
		{

			this.lstMessages.Items.Clear();

			
			
			foreach(System.Messaging.Message m in this.qOrders)
			{

				this.lstMessages.Items.Add(m.Label);

			}
		}

		catch (Exception exp) 
		{

			MessageBox.Show(exp.Message, exp.Source, MessageBoxButtons.OK, MessageBoxIcon.Error);

		}

	}
	public bool IsNumeric(string val)
	{
		try
		{
			double result = 0;
			return Double.TryParse(val, System.Globalization.NumberStyles.Any, System.Globalization.NumberFormatInfo.CurrentInfo, out result);
		}
		catch
		{
			return false;
		}
	}
	public static bool IsDate(string strDate) 
	{
		DateTime dtDate;
		bool bValid = true;
		try 
		{
			dtDate = DateTime.Parse(strDate);
		}
		catch (FormatException eFormatException) 
		{
			// the Parse method failed => the string strDate cannot be converted to a date.
			bValid = false;
		}
		return bValid;
	}


	private void txtOrderNumber_Validating(object sender, System.ComponentModel.CancelEventArgs e)
	{

		TextBox txt  = (TextBox) sender;

		if (!IsNumeric(txt.Text)) 
		{

			txt.Text = "1";

			MessageBox.Show("Only numbers are allowed for an Order Number. Setting value to 1", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

		}

	}

	private void txtReqDate_Validating(object sender, System.ComponentModel.CancelEventArgs e)
	{

		TextBox txt  = (TextBox) sender;

		if (!IsDate(txt.Text))
		{
			
			txt.Text = DateTime.Today.AddDays(5).ToShortDateString();
			MessageBox.Show("Only numbers are allowed for an Order Number. Setting value to : " + this.txtReqDate.Text, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

		}

	}

}

