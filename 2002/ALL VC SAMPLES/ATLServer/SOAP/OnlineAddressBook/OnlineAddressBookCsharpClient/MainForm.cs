using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;

namespace OnlineAddressBookCsharpClient
{
	/// <summary>
	/// Summary description for Form1.
	/// </summary>
	public class MainForm : System.Windows.Forms.Form
	{
		private System.Windows.Forms.MainMenu mainMenu1;
		private System.Windows.Forms.MenuItem menuItem1;
		private System.Windows.Forms.MenuItem menuItem4;
		private System.Windows.Forms.MenuItem menuItem6;
		private System.Windows.Forms.MenuItem logOn;
		private System.Windows.Forms.MenuItem logOff;
		private System.Windows.Forms.MenuItem newAccount;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;
		private System.Windows.Forms.ListBox ContactList;
		private System.Windows.Forms.MenuItem importOutlook;

		private int[] m_contactListIDs;
		private OnlineAddressBookServer.ContactItem[] ContactItemList;
		private int m_lastSelectedIndex;


		private System.Windows.Forms.MenuItem updateAll;
		private System.Windows.Forms.MenuItem changeServer;
		private System.Windows.Forms.MenuItem menuItem2;
		private System.Windows.Forms.GroupBox ContactDetail;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.Label label9;
		private System.Windows.Forms.Label label10;
		private System.Windows.Forms.Label label11;
		private System.Windows.Forms.Label label12;
		private System.Windows.Forms.Label label13;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.TextBox textBox8;
		private System.Windows.Forms.TextBox textBox9;
		private System.Windows.Forms.Label label14;
		private System.Windows.Forms.TextBox textBox10;
		private System.Windows.Forms.Label label15;
		private System.Windows.Forms.Label label16;
		private System.Windows.Forms.TextBox textBox11;
		private System.Windows.Forms.Label label17;
		private System.Windows.Forms.Label label18;
		private System.Windows.Forms.TextBox textBox12;
		private System.Windows.Forms.GroupBox groupBox3;
		private System.Windows.Forms.GroupBox groupBox4;
		private System.Windows.Forms.TextBox textBox13;
		private System.Windows.Forms.TextBox textBox14;
		private System.Windows.Forms.Label label19;
		private System.Windows.Forms.TextBox textBox15;
		private System.Windows.Forms.Label label20;
		private System.Windows.Forms.Label label21;
		private System.Windows.Forms.TextBox textBox16;
		private System.Windows.Forms.Label label22;
		private System.Windows.Forms.Label label23;
		private System.Windows.Forms.TextBox textBox17;
		private System.Windows.Forms.Label label24;
		private System.Windows.Forms.Label label25;
		private System.Windows.Forms.Label label26;
		private System.Windows.Forms.Label label27;
		private System.Windows.Forms.Label label28;
		private System.Windows.Forms.TextBox fnameTB;
		private System.Windows.Forms.TextBox emailTB;
		private System.Windows.Forms.TextBox lnameTB;
		private System.Windows.Forms.TextBox workstreetTB;
		private System.Windows.Forms.TextBox workcityTB;
		private System.Windows.Forms.TextBox workstateTB;
		private System.Windows.Forms.TextBox workzipTB;
		private System.Windows.Forms.TextBox workcountryTB;
		private System.Windows.Forms.TextBox homecountryTB;
		private System.Windows.Forms.TextBox homezipTB;
		private System.Windows.Forms.TextBox homestateTB;
		private System.Windows.Forms.TextBox homecityTB;
		private System.Windows.Forms.TextBox homestreetTB;
		private System.Windows.Forms.TextBox homephoneTB;
		private System.Windows.Forms.TextBox workphoneTB;
		private System.Windows.Forms.TextBox mobilepTB;
		private System.Windows.Forms.TextBox webpageTB;
		private System.Windows.Forms.TextBox companyTB;
		private System.Windows.Forms.Button newContactBTN;
		private System.Windows.Forms.Button deleteContactBTN;
		private System.Windows.Forms.MenuItem AboutMnu;

		private OnlineAddressBookServer.OnlineAddressBookWSService m_OAWS;
		public MainForm()
		{
			m_lastSelectedIndex=-1;
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			m_OAWS=new OnlineAddressBookServer.OnlineAddressBookWSService();

			//
			// TODO: Add any constructor code after InitializeComponent call
			//
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if (components != null) 
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.homestreetTB = new System.Windows.Forms.TextBox();
			this.newAccount = new System.Windows.Forms.MenuItem();
			this.label19 = new System.Windows.Forms.Label();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.textBox8 = new System.Windows.Forms.TextBox();
			this.textBox9 = new System.Windows.Forms.TextBox();
			this.label14 = new System.Windows.Forms.Label();
			this.textBox10 = new System.Windows.Forms.TextBox();
			this.label15 = new System.Windows.Forms.Label();
			this.label16 = new System.Windows.Forms.Label();
			this.textBox11 = new System.Windows.Forms.TextBox();
			this.label17 = new System.Windows.Forms.Label();
			this.label18 = new System.Windows.Forms.Label();
			this.textBox12 = new System.Windows.Forms.TextBox();
			this.workcountryTB = new System.Windows.Forms.TextBox();
			this.workzipTB = new System.Windows.Forms.TextBox();
			this.label13 = new System.Windows.Forms.Label();
			this.workstateTB = new System.Windows.Forms.TextBox();
			this.label12 = new System.Windows.Forms.Label();
			this.label11 = new System.Windows.Forms.Label();
			this.workcityTB = new System.Windows.Forms.TextBox();
			this.label10 = new System.Windows.Forms.Label();
			this.label9 = new System.Windows.Forms.Label();
			this.workstreetTB = new System.Windows.Forms.TextBox();
			this.groupBox3 = new System.Windows.Forms.GroupBox();
			this.groupBox4 = new System.Windows.Forms.GroupBox();
			this.textBox13 = new System.Windows.Forms.TextBox();
			this.textBox14 = new System.Windows.Forms.TextBox();
			this.textBox15 = new System.Windows.Forms.TextBox();
			this.label20 = new System.Windows.Forms.Label();
			this.label21 = new System.Windows.Forms.Label();
			this.textBox16 = new System.Windows.Forms.TextBox();
			this.label22 = new System.Windows.Forms.Label();
			this.label23 = new System.Windows.Forms.Label();
			this.textBox17 = new System.Windows.Forms.TextBox();
			this.homecountryTB = new System.Windows.Forms.TextBox();
			this.homezipTB = new System.Windows.Forms.TextBox();
			this.label24 = new System.Windows.Forms.Label();
			this.homestateTB = new System.Windows.Forms.TextBox();
			this.label25 = new System.Windows.Forms.Label();
			this.label26 = new System.Windows.Forms.Label();
			this.homecityTB = new System.Windows.Forms.TextBox();
			this.label27 = new System.Windows.Forms.Label();
			this.label28 = new System.Windows.Forms.Label();
			this.label6 = new System.Windows.Forms.Label();
			this.AboutMnu = new System.Windows.Forms.MenuItem();
			this.deleteContactBTN = new System.Windows.Forms.Button();
			this.logOff = new System.Windows.Forms.MenuItem();
			this.workphoneTB = new System.Windows.Forms.TextBox();
			this.menuItem4 = new System.Windows.Forms.MenuItem();
			this.importOutlook = new System.Windows.Forms.MenuItem();
			this.menuItem6 = new System.Windows.Forms.MenuItem();
			this.changeServer = new System.Windows.Forms.MenuItem();
			this.updateAll = new System.Windows.Forms.MenuItem();
			this.menuItem1 = new System.Windows.Forms.MenuItem();
			this.logOn = new System.Windows.Forms.MenuItem();
			this.menuItem2 = new System.Windows.Forms.MenuItem();
			this.ContactDetail = new System.Windows.Forms.GroupBox();
			this.companyTB = new System.Windows.Forms.TextBox();
			this.webpageTB = new System.Windows.Forms.TextBox();
			this.mobilepTB = new System.Windows.Forms.TextBox();
			this.homephoneTB = new System.Windows.Forms.TextBox();
			this.label8 = new System.Windows.Forms.Label();
			this.label7 = new System.Windows.Forms.Label();
			this.label5 = new System.Windows.Forms.Label();
			this.lnameTB = new System.Windows.Forms.TextBox();
			this.emailTB = new System.Windows.Forms.TextBox();
			this.label4 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.fnameTB = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.ContactList = new System.Windows.Forms.ListBox();
			this.mainMenu1 = new System.Windows.Forms.MainMenu();
			this.newContactBTN = new System.Windows.Forms.Button();
			this.groupBox1.SuspendLayout();
			this.groupBox2.SuspendLayout();
			this.groupBox3.SuspendLayout();
			this.groupBox4.SuspendLayout();
			this.ContactDetail.SuspendLayout();
			this.SuspendLayout();
			// 
			// homestreetTB
			// 
			this.homestreetTB.Location = new System.Drawing.Point(56, 16);
			this.homestreetTB.Name = "homestreetTB";
			this.homestreetTB.Size = new System.Drawing.Size(136, 20);
			this.homestreetTB.TabIndex = 0;
			this.homestreetTB.Text = "";
			// 
			// newAccount
			// 
			this.newAccount.Index = 2;
			this.newAccount.Text = "Create New Account";
			this.newAccount.Click += new System.EventHandler(this.newAccount_Click);
			// 
			// label19
			// 
			this.label19.Location = new System.Drawing.Point(88, 72);
			this.label19.Name = "label19";
			this.label19.Size = new System.Drawing.Size(24, 23);
			this.label19.TabIndex = 7;
			this.label19.Text = "Zip";
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.AddRange(new System.Windows.Forms.Control[] {
																					this.groupBox2,
																					this.workcountryTB,
																					this.workzipTB,
																					this.label13,
																					this.workstateTB,
																					this.label12,
																					this.label11,
																					this.workcityTB,
																					this.label10,
																					this.label9,
																					this.workstreetTB});
			this.groupBox1.Location = new System.Drawing.Point(224, 144);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(200, 112);
			this.groupBox1.TabIndex = 7;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Work Address";
			// 
			// groupBox2
			// 
			this.groupBox2.Controls.AddRange(new System.Windows.Forms.Control[] {
																					this.textBox8,
																					this.textBox9,
																					this.label14,
																					this.textBox10,
																					this.label15,
																					this.label16,
																					this.textBox11,
																					this.label17,
																					this.label18,
																					this.textBox12});
			this.groupBox2.Location = new System.Drawing.Point(352, 120);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(200, 112);
			this.groupBox2.TabIndex = 7;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "Home Address";
			// 
			// textBox8
			// 
			this.textBox8.Location = new System.Drawing.Point(56, 88);
			this.textBox8.Name = "textBox8";
			this.textBox8.Size = new System.Drawing.Size(136, 20);
			this.textBox8.TabIndex = 9;
			this.textBox8.Text = "";
			// 
			// textBox9
			// 
			this.textBox9.Location = new System.Drawing.Point(112, 64);
			this.textBox9.Name = "textBox9";
			this.textBox9.Size = new System.Drawing.Size(80, 20);
			this.textBox9.TabIndex = 8;
			this.textBox9.Text = "";
			// 
			// label14
			// 
			this.label14.Location = new System.Drawing.Point(88, 72);
			this.label14.Name = "label14";
			this.label14.Size = new System.Drawing.Size(24, 23);
			this.label14.TabIndex = 7;
			this.label14.Text = "Zip";
			// 
			// textBox10
			// 
			this.textBox10.Location = new System.Drawing.Point(48, 64);
			this.textBox10.Name = "textBox10";
			this.textBox10.Size = new System.Drawing.Size(32, 20);
			this.textBox10.TabIndex = 6;
			this.textBox10.Text = "";
			// 
			// label15
			// 
			this.label15.Location = new System.Drawing.Point(8, 96);
			this.label15.Name = "label15";
			this.label15.Size = new System.Drawing.Size(48, 16);
			this.label15.TabIndex = 5;
			this.label15.Text = "Country";
			// 
			// label16
			// 
			this.label16.Location = new System.Drawing.Point(8, 72);
			this.label16.Name = "label16";
			this.label16.Size = new System.Drawing.Size(32, 23);
			this.label16.TabIndex = 4;
			this.label16.Text = "State";
			// 
			// textBox11
			// 
			this.textBox11.Location = new System.Drawing.Point(56, 40);
			this.textBox11.Name = "textBox11";
			this.textBox11.Size = new System.Drawing.Size(136, 20);
			this.textBox11.TabIndex = 3;
			this.textBox11.Text = "";
			// 
			// label17
			// 
			this.label17.Location = new System.Drawing.Point(8, 48);
			this.label17.Name = "label17";
			this.label17.Size = new System.Drawing.Size(40, 23);
			this.label17.TabIndex = 2;
			this.label17.Text = "City";
			// 
			// label18
			// 
			this.label18.Location = new System.Drawing.Point(8, 24);
			this.label18.Name = "label18";
			this.label18.Size = new System.Drawing.Size(40, 23);
			this.label18.TabIndex = 1;
			this.label18.Text = "Street";
			// 
			// textBox12
			// 
			this.textBox12.Location = new System.Drawing.Point(56, 16);
			this.textBox12.Name = "textBox12";
			this.textBox12.Size = new System.Drawing.Size(136, 20);
			this.textBox12.TabIndex = 0;
			this.textBox12.Text = "";
			// 
			// workcountryTB
			// 
			this.workcountryTB.Location = new System.Drawing.Point(56, 88);
			this.workcountryTB.Name = "workcountryTB";
			this.workcountryTB.Size = new System.Drawing.Size(136, 20);
			this.workcountryTB.TabIndex = 9;
			this.workcountryTB.Text = "";
			// 
			// workzipTB
			// 
			this.workzipTB.Location = new System.Drawing.Point(112, 64);
			this.workzipTB.Name = "workzipTB";
			this.workzipTB.Size = new System.Drawing.Size(80, 20);
			this.workzipTB.TabIndex = 8;
			this.workzipTB.Text = "";
			// 
			// label13
			// 
			this.label13.Location = new System.Drawing.Point(88, 72);
			this.label13.Name = "label13";
			this.label13.Size = new System.Drawing.Size(24, 23);
			this.label13.TabIndex = 7;
			this.label13.Text = "Zip";
			// 
			// workstateTB
			// 
			this.workstateTB.Location = new System.Drawing.Point(56, 64);
			this.workstateTB.Name = "workstateTB";
			this.workstateTB.Size = new System.Drawing.Size(24, 20);
			this.workstateTB.TabIndex = 6;
			this.workstateTB.Text = "";
			// 
			// label12
			// 
			this.label12.Location = new System.Drawing.Point(8, 96);
			this.label12.Name = "label12";
			this.label12.Size = new System.Drawing.Size(48, 16);
			this.label12.TabIndex = 5;
			this.label12.Text = "Country";
			// 
			// label11
			// 
			this.label11.Location = new System.Drawing.Point(8, 72);
			this.label11.Name = "label11";
			this.label11.Size = new System.Drawing.Size(32, 23);
			this.label11.TabIndex = 4;
			this.label11.Text = "State";
			// 
			// workcityTB
			// 
			this.workcityTB.Location = new System.Drawing.Point(56, 40);
			this.workcityTB.Name = "workcityTB";
			this.workcityTB.Size = new System.Drawing.Size(136, 20);
			this.workcityTB.TabIndex = 3;
			this.workcityTB.Text = "";
			// 
			// label10
			// 
			this.label10.Location = new System.Drawing.Point(8, 48);
			this.label10.Name = "label10";
			this.label10.Size = new System.Drawing.Size(40, 23);
			this.label10.TabIndex = 2;
			this.label10.Text = "City";
			// 
			// label9
			// 
			this.label9.Location = new System.Drawing.Point(8, 24);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(40, 23);
			this.label9.TabIndex = 1;
			this.label9.Text = "Street";
			// 
			// workstreetTB
			// 
			this.workstreetTB.Location = new System.Drawing.Point(56, 16);
			this.workstreetTB.Name = "workstreetTB";
			this.workstreetTB.Size = new System.Drawing.Size(136, 20);
			this.workstreetTB.TabIndex = 0;
			this.workstreetTB.Text = "";
			// 
			// groupBox3
			// 
			this.groupBox3.Controls.AddRange(new System.Windows.Forms.Control[] {
																					this.groupBox4,
																					this.homecountryTB,
																					this.homezipTB,
																					this.label24,
																					this.homestateTB,
																					this.label25,
																					this.label26,
																					this.homecityTB,
																					this.label27,
																					this.label28,
																					this.homestreetTB});
			this.groupBox3.Location = new System.Drawing.Point(224, 16);
			this.groupBox3.Name = "groupBox3";
			this.groupBox3.Size = new System.Drawing.Size(200, 112);
			this.groupBox3.TabIndex = 7;
			this.groupBox3.TabStop = false;
			this.groupBox3.Text = "Home Address";
			// 
			// groupBox4
			// 
			this.groupBox4.Controls.AddRange(new System.Windows.Forms.Control[] {
																					this.textBox13,
																					this.textBox14,
																					this.label19,
																					this.textBox15,
																					this.label20,
																					this.label21,
																					this.textBox16,
																					this.label22,
																					this.label23,
																					this.textBox17});
			this.groupBox4.Location = new System.Drawing.Point(352, 120);
			this.groupBox4.Name = "groupBox4";
			this.groupBox4.Size = new System.Drawing.Size(200, 112);
			this.groupBox4.TabIndex = 7;
			this.groupBox4.TabStop = false;
			this.groupBox4.Text = "Home Address";
			// 
			// textBox13
			// 
			this.textBox13.Location = new System.Drawing.Point(56, 88);
			this.textBox13.Name = "textBox13";
			this.textBox13.Size = new System.Drawing.Size(136, 20);
			this.textBox13.TabIndex = 9;
			this.textBox13.Text = "";
			// 
			// textBox14
			// 
			this.textBox14.Location = new System.Drawing.Point(112, 64);
			this.textBox14.Name = "textBox14";
			this.textBox14.Size = new System.Drawing.Size(80, 20);
			this.textBox14.TabIndex = 8;
			this.textBox14.Text = "";
			// 
			// textBox15
			// 
			this.textBox15.Location = new System.Drawing.Point(48, 64);
			this.textBox15.Name = "textBox15";
			this.textBox15.Size = new System.Drawing.Size(32, 20);
			this.textBox15.TabIndex = 6;
			this.textBox15.Text = "";
			// 
			// label20
			// 
			this.label20.Location = new System.Drawing.Point(8, 96);
			this.label20.Name = "label20";
			this.label20.Size = new System.Drawing.Size(48, 16);
			this.label20.TabIndex = 5;
			this.label20.Text = "Country";
			// 
			// label21
			// 
			this.label21.Location = new System.Drawing.Point(8, 72);
			this.label21.Name = "label21";
			this.label21.Size = new System.Drawing.Size(32, 23);
			this.label21.TabIndex = 4;
			this.label21.Text = "State";
			// 
			// textBox16
			// 
			this.textBox16.Location = new System.Drawing.Point(56, 40);
			this.textBox16.Name = "textBox16";
			this.textBox16.Size = new System.Drawing.Size(136, 20);
			this.textBox16.TabIndex = 3;
			this.textBox16.Text = "";
			// 
			// label22
			// 
			this.label22.Location = new System.Drawing.Point(8, 48);
			this.label22.Name = "label22";
			this.label22.Size = new System.Drawing.Size(40, 23);
			this.label22.TabIndex = 2;
			this.label22.Text = "City";
			// 
			// label23
			// 
			this.label23.Location = new System.Drawing.Point(8, 24);
			this.label23.Name = "label23";
			this.label23.Size = new System.Drawing.Size(40, 23);
			this.label23.TabIndex = 1;
			this.label23.Text = "Street";
			// 
			// textBox17
			// 
			this.textBox17.Location = new System.Drawing.Point(56, 16);
			this.textBox17.Name = "textBox17";
			this.textBox17.Size = new System.Drawing.Size(136, 20);
			this.textBox17.TabIndex = 0;
			this.textBox17.Text = "";
			// 
			// homecountryTB
			// 
			this.homecountryTB.Location = new System.Drawing.Point(56, 88);
			this.homecountryTB.Name = "homecountryTB";
			this.homecountryTB.Size = new System.Drawing.Size(136, 20);
			this.homecountryTB.TabIndex = 9;
			this.homecountryTB.Text = "";
			// 
			// homezipTB
			// 
			this.homezipTB.Location = new System.Drawing.Point(112, 64);
			this.homezipTB.Name = "homezipTB";
			this.homezipTB.Size = new System.Drawing.Size(80, 20);
			this.homezipTB.TabIndex = 8;
			this.homezipTB.Text = "";
			// 
			// label24
			// 
			this.label24.Location = new System.Drawing.Point(88, 72);
			this.label24.Name = "label24";
			this.label24.Size = new System.Drawing.Size(24, 23);
			this.label24.TabIndex = 7;
			this.label24.Text = "Zip";
			// 
			// homestateTB
			// 
			this.homestateTB.Location = new System.Drawing.Point(56, 64);
			this.homestateTB.Name = "homestateTB";
			this.homestateTB.Size = new System.Drawing.Size(24, 20);
			this.homestateTB.TabIndex = 6;
			this.homestateTB.Text = "";
			// 
			// label25
			// 
			this.label25.Location = new System.Drawing.Point(8, 96);
			this.label25.Name = "label25";
			this.label25.Size = new System.Drawing.Size(48, 16);
			this.label25.TabIndex = 5;
			this.label25.Text = "Country";
			// 
			// label26
			// 
			this.label26.Location = new System.Drawing.Point(8, 72);
			this.label26.Name = "label26";
			this.label26.Size = new System.Drawing.Size(32, 23);
			this.label26.TabIndex = 4;
			this.label26.Text = "State";
			// 
			// homecityTB
			// 
			this.homecityTB.Location = new System.Drawing.Point(56, 40);
			this.homecityTB.Name = "homecityTB";
			this.homecityTB.Size = new System.Drawing.Size(136, 20);
			this.homecityTB.TabIndex = 3;
			this.homecityTB.Text = "";
			// 
			// label27
			// 
			this.label27.Location = new System.Drawing.Point(8, 48);
			this.label27.Name = "label27";
			this.label27.Size = new System.Drawing.Size(40, 23);
			this.label27.TabIndex = 2;
			this.label27.Text = "City";
			// 
			// label28
			// 
			this.label28.Location = new System.Drawing.Point(8, 24);
			this.label28.Name = "label28";
			this.label28.Size = new System.Drawing.Size(40, 23);
			this.label28.TabIndex = 1;
			this.label28.Text = "Street";
			// 
			// label6
			// 
			this.label6.Location = new System.Drawing.Point(8, 248);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(56, 16);
			this.label6.TabIndex = 6;
			this.label6.Text = "Company";
			// 
			// AboutMnu
			// 
			this.AboutMnu.Index = 0;
			this.AboutMnu.Text = "About";
			this.AboutMnu.Click += new System.EventHandler(this.AboutMnu_Click);
			// 
			// deleteContactBTN
			// 
			this.deleteContactBTN.Enabled = false;
			this.deleteContactBTN.Location = new System.Drawing.Point(80, 256);
			this.deleteContactBTN.Name = "deleteContactBTN";
			this.deleteContactBTN.Size = new System.Drawing.Size(56, 32);
			this.deleteContactBTN.TabIndex = 3;
			this.deleteContactBTN.Text = "Delete Contact";
			this.deleteContactBTN.Click += new System.EventHandler(this.deleteContactBTN_Click);
			// 
			// logOff
			// 
			this.logOff.Enabled = false;
			this.logOff.Index = 1;
			this.logOff.Text = "Log Off";
			this.logOff.Click += new System.EventHandler(this.logOff_Click);
			// 
			// workphoneTB
			// 
			this.workphoneTB.Location = new System.Drawing.Point(88, 148);
			this.workphoneTB.Name = "workphoneTB";
			this.workphoneTB.Size = new System.Drawing.Size(128, 20);
			this.workphoneTB.TabIndex = 11;
			this.workphoneTB.Text = "";
			// 
			// menuItem4
			// 
			this.menuItem4.Index = 1;
			this.menuItem4.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																					  this.importOutlook});
			this.menuItem4.Text = "Tools";
			// 
			// importOutlook
			// 
			this.importOutlook.Enabled = false;
			this.importOutlook.Index = 0;
			this.importOutlook.Text = "Import from Outlook";
			this.importOutlook.Click += new System.EventHandler(this.importOutlook_Click);
			// 
			// menuItem6
			// 
			this.menuItem6.Index = 2;
			this.menuItem6.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																					  this.changeServer,
																					  this.updateAll});
			this.menuItem6.Text = "WebService";
			// 
			// changeServer
			// 
			this.changeServer.Index = 0;
			this.changeServer.Text = "Change Server";
			this.changeServer.Click += new System.EventHandler(this.changeServer_Click);
			// 
			// updateAll
			// 
			this.updateAll.Enabled = false;
			this.updateAll.Index = 1;
			this.updateAll.Text = "Update All";
			this.updateAll.Click += new System.EventHandler(this.updateAll_Click);
			// 
			// menuItem1
			// 
			this.menuItem1.Index = 0;
			this.menuItem1.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																					  this.logOn,
																					  this.logOff,
																					  this.newAccount});
			this.menuItem1.Text = "File";
			// 
			// logOn
			// 
			this.logOn.Index = 0;
			this.logOn.Text = "Log On";
			this.logOn.Click += new System.EventHandler(this.logOn_Click);
			// 
			// menuItem2
			// 
			this.menuItem2.Index = 3;
			this.menuItem2.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																					  this.AboutMnu});
			this.menuItem2.Text = "Help";
			// 
			// ContactDetail
			// 
			this.ContactDetail.Controls.AddRange(new System.Windows.Forms.Control[] {
																						this.companyTB,
																						this.webpageTB,
																						this.mobilepTB,
																						this.workphoneTB,
																						this.homephoneTB,
																						this.groupBox3,
																						this.label8,
																						this.label7,
																						this.groupBox1,
																						this.label6,
																						this.label5,
																						this.lnameTB,
																						this.emailTB,
																						this.label4,
																						this.label3,
																						this.label2,
																						this.fnameTB,
																						this.label1});
			this.ContactDetail.Location = new System.Drawing.Point(152, 8);
			this.ContactDetail.Name = "ContactDetail";
			this.ContactDetail.Size = new System.Drawing.Size(432, 272);
			this.ContactDetail.TabIndex = 1;
			this.ContactDetail.TabStop = false;
			this.ContactDetail.Text = "Contact Detail";
			// 
			// companyTB
			// 
			this.companyTB.Location = new System.Drawing.Point(88, 244);
			this.companyTB.Name = "companyTB";
			this.companyTB.Size = new System.Drawing.Size(128, 20);
			this.companyTB.TabIndex = 14;
			this.companyTB.Text = "";
			// 
			// webpageTB
			// 
			this.webpageTB.Location = new System.Drawing.Point(88, 212);
			this.webpageTB.Name = "webpageTB";
			this.webpageTB.Size = new System.Drawing.Size(128, 20);
			this.webpageTB.TabIndex = 13;
			this.webpageTB.Text = "";
			// 
			// mobilepTB
			// 
			this.mobilepTB.Location = new System.Drawing.Point(88, 180);
			this.mobilepTB.Name = "mobilepTB";
			this.mobilepTB.Size = new System.Drawing.Size(128, 20);
			this.mobilepTB.TabIndex = 12;
			this.mobilepTB.Text = "";
			// 
			// homephoneTB
			// 
			this.homephoneTB.Location = new System.Drawing.Point(88, 116);
			this.homephoneTB.Name = "homephoneTB";
			this.homephoneTB.Size = new System.Drawing.Size(128, 20);
			this.homephoneTB.TabIndex = 10;
			this.homephoneTB.Text = "";
			// 
			// label8
			// 
			this.label8.Location = new System.Drawing.Point(8, 184);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(80, 16);
			this.label8.TabIndex = 9;
			this.label8.Text = "Mobile Phone";
			// 
			// label7
			// 
			this.label7.Location = new System.Drawing.Point(8, 152);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(72, 16);
			this.label7.TabIndex = 8;
			this.label7.Text = "Work Phone";
			// 
			// label5
			// 
			this.label5.Location = new System.Drawing.Point(8, 120);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(72, 16);
			this.label5.TabIndex = 5;
			this.label5.Text = "Home Phone";
			// 
			// lnameTB
			// 
			this.lnameTB.Location = new System.Drawing.Point(88, 84);
			this.lnameTB.Name = "lnameTB";
			this.lnameTB.Size = new System.Drawing.Size(128, 20);
			this.lnameTB.TabIndex = 4;
			this.lnameTB.Text = "";
			// 
			// emailTB
			// 
			this.emailTB.Location = new System.Drawing.Point(88, 20);
			this.emailTB.Name = "emailTB";
			this.emailTB.Size = new System.Drawing.Size(128, 20);
			this.emailTB.TabIndex = 3;
			this.emailTB.Text = "";
			// 
			// label4
			// 
			this.label4.Location = new System.Drawing.Point(8, 24);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(72, 16);
			this.label4.TabIndex = 2;
			this.label4.Text = "email";
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(8, 216);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(72, 16);
			this.label3.TabIndex = 0;
			this.label3.Text = "Web Page";
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(8, 88);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(72, 16);
			this.label2.TabIndex = 0;
			this.label2.Text = "Last Name";
			// 
			// fnameTB
			// 
			this.fnameTB.Location = new System.Drawing.Point(88, 52);
			this.fnameTB.Name = "fnameTB";
			this.fnameTB.Size = new System.Drawing.Size(128, 20);
			this.fnameTB.TabIndex = 1;
			this.fnameTB.Text = "";
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(8, 56);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(72, 16);
			this.label1.TabIndex = 0;
			this.label1.Text = "First Name";
			// 
			// ContactList
			// 
			this.ContactList.DisplayMember = "FirstName";
			this.ContactList.Location = new System.Drawing.Point(16, 8);
			this.ContactList.Name = "ContactList";
			this.ContactList.Size = new System.Drawing.Size(120, 238);
			this.ContactList.TabIndex = 0;
			this.ContactList.SelectedIndexChanged += new System.EventHandler(this.ContactList_SelectedIndexChanged);
			// 
			// mainMenu1
			// 
			this.mainMenu1.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																					  this.menuItem1,
																					  this.menuItem4,
																					  this.menuItem6,
																					  this.menuItem2});
			// 
			// newContactBTN
			// 
			this.newContactBTN.Enabled = false;
			this.newContactBTN.Location = new System.Drawing.Point(16, 256);
			this.newContactBTN.Name = "newContactBTN";
			this.newContactBTN.Size = new System.Drawing.Size(56, 32);
			this.newContactBTN.TabIndex = 2;
			this.newContactBTN.Text = "New Contact";
			this.newContactBTN.Click += new System.EventHandler(this.newContactBTN_Click);
			// 
			// MainForm
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(592, 305);
			this.Controls.AddRange(new System.Windows.Forms.Control[] {
																		  this.deleteContactBTN,
																		  this.newContactBTN,
																		  this.ContactDetail,
																		  this.ContactList});
			this.Menu = this.mainMenu1;
			this.Name = "MainForm";
			this.Text = "Online Address Book";
			this.groupBox1.ResumeLayout(false);
			this.groupBox2.ResumeLayout(false);
			this.groupBox3.ResumeLayout(false);
			this.groupBox4.ResumeLayout(false);
			this.ContactDetail.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main() 
		{
			Application.Run(new MainForm());
		}

		private void logOn_Click(object sender, System.EventArgs e)
		{
			logOnForm mylogOnForm=new logOnForm(ref m_OAWS);
			mylogOnForm.ShowDialog();
			if(m_OAWS.m_SessionID!=null)	//this will not be null if log on was successful
			{
				logOn.Enabled=false;
				logOff.Enabled=true;
				importOutlook.Enabled=true;
				updateAll.Enabled=true;
				newContactBTN.Enabled=true;
				deleteContactBTN.Enabled=true;
				fillContactList();
				m_lastSelectedIndex=-1;
			}



		}

		private void newAccount_Click(object sender, System.EventArgs e)
		{
			newAccountForm mynewAccountForm=new newAccountForm(ref m_OAWS);
			mynewAccountForm.ShowDialog();
		}

		private void importOutlook_Click(object sender, System.EventArgs e)
		{
			try
			{
				int badItemsCounter=0;
				bool invalidItemDetected=false;
				Outlook.Application myApp=new Outlook.Application();
				Outlook._NameSpace myOutlookNamespace=myApp.GetNamespace("MAPI");
				Outlook.MAPIFolder myContactsFolder=myOutlookNamespace.GetDefaultFolder(Outlook.OlDefaultFolders.olFolderContacts);

				//	Outlook._ContactItem myContact;
				ContactItemList=new OnlineAddressBookServer.ContactItem[myContactsFolder.Items.Count];
				ContactList.Items.Clear();
				for(int i=1;i<=myContactsFolder.Items.Count;i++)
				{
					try
					{
						ContactList.Items.Add(((Outlook._ContactItem)myContactsFolder.Items.Item(i)).FullName);
						ContactItemList[i-1-badItemsCounter]=new OnlineAddressBookServer.ContactItem();
						mapExchangeItemtoWSItem((Outlook._ContactItem)myContactsFolder.Items.Item(i),ref ContactItemList[i-1-badItemsCounter]);
					}
					catch(System.InvalidCastException ice)
					{
						invalidItemDetected=true;
						++badItemsCounter;
					}
					
				}  

				if(invalidItemDetected)
				{
					MessageBox.Show("Warning, there were unsupported contact Items in your Outlook Contacts(i.e. Distribution lists), and they weren't imported.","Warning");
				}

			}
			catch(System.Runtime.InteropServices.COMException ex)
			{
				MessageBox.Show("Unable to access Outlook Contacts, make sure this application has enough permissions to perform this operation(and answer yes when asked if you want to let this application access your Outlook e-mail addresses) , details:"+ex.ToString(),"Error");				
				ContactItemList=null;
				ContactList.Items.Clear();
			}
			catch(System.Exception ex2)
			{	
				MessageBox.Show("Import Failed, details:"+ex2.ToString(),"Error");
				ContactItemList=null;
				ContactList.Items.Clear();
			}

		}

		private void fillContactList()
		{
			string[] MyContactList=new string[0];
			m_contactListIDs=new int[0];
			try
			{
				MyContactList=m_OAWS.GetContactList(out m_contactListIDs);
				ContactList.Items.Clear();
				if(MyContactList!=null)//if NULL the contact list was empty
				{
					ContactList.BeginUpdate();

			
					for(int i=0;i<MyContactList.Length;i++)
						ContactList.Items.Add(MyContactList[i]);
				
					ContactList.EndUpdate();
				}
				GetAllItemsDetail();
			}
			catch(System.Web.Services.Protocols.SoapException ex)
			{
				System.Windows.Forms.MessageBox.Show(this,ex.Detail.InnerText);

			}

		}


		private void updateAll_Click(object sender, System.EventArgs e)
		{
			SaveContactChanges();
			try
			{
				if(ContactList.Items.Count>0&&ContactItemList!=null&&ContactItemList.Length>0)
				{
					m_OAWS.DeleteAllContacts();
					for(int i=0;i<ContactItemList.Length;i++)
					{
						if(ContactItemList[i]!=null)
						{
							ensureNoNullFields(ref ContactItemList[i]);
							m_OAWS.InsertContact(ContactItemList[i]);
						}
					}
					
					ContactList.Items.Clear();
					fillContactList();

					MessageBox.Show("The Update of all your contacts was Successfull");


				}
				else
				{
					System.Windows.Forms.MessageBox.Show("There are no Contacts To Update");
				}
                				
			}
			catch(System.Web.Services.Protocols.SoapException ex)
			{
				System.Windows.Forms.MessageBox.Show(this,ex.Detail.InnerText);
				
			}
		

		}

		private void mapExchangeItemtoWSItem(Outlook._ContactItem OC,ref OnlineAddressBookServer.ContactItem WSC)
		{
			WSC.m_ContactID=0;
			WSC.m_Birthday=OC.Birthday.ToString();
			WSC.m_BusinessCity=OC.BusinessAddressCity;
			WSC.m_BusinessCountry=OC.BusinessAddressCountry;
			WSC.m_BusinessFax=OC.BusinessFaxNumber;
			WSC.m_BusinessPhone=OC.BusinessTelephoneNumber;
			WSC.m_BusinessPostalCode=OC.BusinessAddressPostalCode;
			WSC.m_BusinessState=OC.BusinessAddressState;
			WSC.m_BusinessStreet=OC.BusinessAddressStreet;
			WSC.m_Company=OC.CompanyName;
			WSC.m_Department=OC.Department;
			WSC.m_EmailAddress=OC.Email1DisplayName;
			WSC.m_FirstName=OC.FirstName;
			WSC.m_HomeCity=OC.HomeAddressCity;
			WSC.m_HomeCountry=OC.HomeAddressCountry;
			WSC.m_HomeFax=OC.HomeFaxNumber;
			WSC.m_HomePhone=OC.HomeTelephoneNumber;
			WSC.m_HomePostalCode=OC.HomeAddressPostalCode;
			WSC.m_HomeState=OC.HomeAddressState;
			WSC.m_HomeStreet=OC.HomeAddressStreet;
			WSC.m_JobTitle=OC.JobTitle;
			WSC.m_LastName=OC.LastName;
			WSC.m_MiddleName=OC.MiddleName;
			WSC.m_MobilePhone=OC.MobileTelephoneNumber;
			WSC.m_OtherPhone=OC.OtherTelephoneNumber;
			WSC.m_Suffix=OC.Suffix;
			WSC.m_Title=OC.Title;
			WSC.m_WebPage=OC.WebPage;


		}

		private void ensureNoNullFields(ref OnlineAddressBookServer.ContactItem WSC)
		{
			//if(WSC.m_ContactID==null) m_ContactID=0;
			if(WSC.m_Birthday==null)WSC.m_Birthday="";
			if(WSC.m_BusinessCity==null) WSC.m_BusinessCity="";
			if(WSC.m_BusinessCountry==null) WSC.m_BusinessCountry ="";
			if(WSC.m_BusinessFax==null) WSC.m_BusinessFax ="";
			if(WSC.m_BusinessPhone==null) WSC.m_BusinessPhone ="";
			if(WSC.m_BusinessPostalCode==null) WSC.m_BusinessPostalCode ="";
			if(WSC.m_BusinessState==null)  WSC.m_BusinessState="";
			if(WSC.m_BusinessStreet==null)WSC.m_BusinessStreet  ="";
			if(WSC.m_Company==null) WSC.m_Company ="";
			if(WSC.m_Department==null)  WSC.m_Department="";
			if(WSC.m_EmailAddress==null) WSC.m_EmailAddress ="";
			if(WSC.m_FirstName==null)  WSC.m_FirstName="";
			if(WSC.m_HomeCity==null) WSC.m_HomeCity ="";
			if(WSC.m_HomeCountry==null) WSC.m_HomeCountry ="";
			if(WSC.m_HomeFax==null) WSC.m_HomeFax ="";
			if(WSC.m_HomePhone==null)  WSC.m_HomePhone="";
			if(WSC.m_HomePostalCode==null)WSC.m_HomePostalCode  ="";
			if(WSC.m_HomeState==null)  WSC.m_HomeState="";
			if(WSC.m_HomeStreet==null) WSC.m_HomeStreet ="";
			if(WSC.m_JobTitle==null) WSC.m_JobTitle ="";
			if(WSC.m_LastName==null) WSC.m_LastName ="";
			if(WSC.m_MiddleName==null) WSC.m_MiddleName ="";
			if(WSC.m_MobilePhone==null) WSC.m_MobilePhone ="";
			if(WSC.m_OtherPhone==null) WSC.m_OtherPhone ="";
			if(WSC.m_Suffix==null) WSC.m_Suffix ="";
			if(WSC.m_Title==null) WSC.m_Title ="";
			if(WSC.m_WebPage==null) WSC.m_WebPage ="";
		}

		private void changeServer_Click(object sender, System.EventArgs e)
		{
			changeWSUrl myCURL=new changeWSUrl(m_OAWS.Url);
			myCURL.ShowDialog();
			m_OAWS.Url=myCURL.m_newurl;

			
		}

		private void logOff_Click()
		{
		}

		private void AboutMnu_Click(object sender, System.EventArgs e)
		{
			about aboutForm=new about();
			aboutForm.Show();
		}


		private void SaveContactChanges()
		{
			if(m_lastSelectedIndex!=-1)
			{
				ContactItemList[m_lastSelectedIndex].m_FirstName=fnameTB.Text;
				ContactItemList[m_lastSelectedIndex].m_EmailAddress=emailTB.Text;
				ContactItemList[m_lastSelectedIndex].m_LastName=lnameTB.Text;
				ContactItemList[m_lastSelectedIndex].m_BusinessStreet=workstreetTB.Text;
				ContactItemList[m_lastSelectedIndex].m_BusinessCity=workcityTB.Text;
				ContactItemList[m_lastSelectedIndex].m_BusinessState=workstateTB.Text;
				ContactItemList[m_lastSelectedIndex].m_BusinessPostalCode=workzipTB.Text;
				ContactItemList[m_lastSelectedIndex].m_BusinessCountry=workcountryTB.Text;
				ContactItemList[m_lastSelectedIndex].m_HomeCountry=homecountryTB.Text;
				ContactItemList[m_lastSelectedIndex].m_HomePostalCode=homezipTB.Text;
				ContactItemList[m_lastSelectedIndex].m_HomeState=homestateTB.Text;
				ContactItemList[m_lastSelectedIndex].m_HomeCity=homecityTB.Text;
				ContactItemList[m_lastSelectedIndex].m_HomeStreet=homestreetTB.Text;
				ContactItemList[m_lastSelectedIndex].m_HomePhone=homephoneTB.Text;
				ContactItemList[m_lastSelectedIndex].m_BusinessPhone=workphoneTB.Text;
				ContactItemList[m_lastSelectedIndex].m_MobilePhone=mobilepTB.Text;
				ContactItemList[m_lastSelectedIndex].m_WebPage=webpageTB.Text;
				ContactItemList[m_lastSelectedIndex].m_Company=companyTB.Text;
			}

		}


		private void GetAllItemsDetail()
		{

			try
			{
				ContactItemList=new OnlineAddressBookServer.ContactItem[ContactList.Items.Count];
				for(int i=0;i<ContactList.Items.Count;i++)
				{
					ContactItemList[i]=m_OAWS.GetAddressBookEntry(m_contactListIDs[i]);
				}
			}
			catch(System.Web.Services.Protocols.SoapException ex)
			{
				System.Windows.Forms.MessageBox.Show(this,ex.Detail.InnerText);

			}

		}
		private void ContactList_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			
			SaveContactChanges();


			fnameTB.Text=ContactItemList[ContactList.SelectedIndex].m_FirstName;
			emailTB.Text=ContactItemList[ContactList.SelectedIndex].m_EmailAddress;
			lnameTB.Text=ContactItemList[ContactList.SelectedIndex].m_LastName;
			workstreetTB.Text=ContactItemList[ContactList.SelectedIndex].m_BusinessStreet;
			workcityTB.Text=ContactItemList[ContactList.SelectedIndex].m_BusinessCity;
			workstateTB.Text=ContactItemList[ContactList.SelectedIndex].m_BusinessState;
			workzipTB.Text=ContactItemList[ContactList.SelectedIndex].m_BusinessPostalCode;
			workcountryTB.Text=ContactItemList[ContactList.SelectedIndex].m_BusinessCountry;
			homecountryTB.Text=ContactItemList[ContactList.SelectedIndex].m_HomeCountry;
			homezipTB.Text=ContactItemList[ContactList.SelectedIndex].m_HomePostalCode;
			homestateTB.Text=ContactItemList[ContactList.SelectedIndex].m_HomeState;
			homecityTB.Text=ContactItemList[ContactList.SelectedIndex].m_HomeCity;
			homestreetTB.Text=ContactItemList[ContactList.SelectedIndex].m_HomeStreet;
			homephoneTB.Text=ContactItemList[ContactList.SelectedIndex].m_HomePhone;
			workphoneTB.Text=ContactItemList[ContactList.SelectedIndex].m_BusinessPhone;
			mobilepTB.Text=ContactItemList[ContactList.SelectedIndex].m_MobilePhone;
			webpageTB.Text=ContactItemList[ContactList.SelectedIndex].m_WebPage;
			companyTB.Text=ContactItemList[ContactList.SelectedIndex].m_Company;

			m_lastSelectedIndex=ContactList.SelectedIndex;

		}

		private void newContactBTN_Click(object sender, System.EventArgs e)
		{
			ContactList.Items.Add("new Contact");
			if(ContactItemList==null)
				ContactItemList=new OnlineAddressBookServer.ContactItem[1];
			else
			{
				OnlineAddressBookServer.ContactItem[] temp=new OnlineAddressBookServer.ContactItem[ContactItemList.Length+1];
				ContactItemList.CopyTo(temp,0);
				ContactItemList=temp;
				ContactItemList[ContactItemList.Length-1]=new OnlineAddressBookServer.ContactItem();
				ContactItemList[ContactItemList.Length-1].m_FirstName="new Contact";

			}


			
		}

		private void deleteContactBTN_Click(object sender, System.EventArgs e)
		{
			if(m_lastSelectedIndex!=-1)
			{
				bool itempassed=false;
				OnlineAddressBookServer.ContactItem[] temp=new OnlineAddressBookServer.ContactItem[ContactItemList.Length-1];
				ContactList.Items.Clear();
				for(int i=0;i<ContactItemList.Length;i++)
				{
					if(i!=m_lastSelectedIndex)
					{
						ContactList.Items.Add(ContactItemList[i].m_FirstName);
						if(itempassed)
							temp[i-1]=ContactItemList[i];
						else
							temp[i]=ContactItemList[i];
					}
					else
						itempassed=true;
					
				}
				ContactItemList=temp;
				m_lastSelectedIndex=-1;
			//	fillContactListfromInternalObj();

			}
			
		}

		private void logOff_Click(object sender, System.EventArgs e)
		{
			m_lastSelectedIndex=-1;
			ContactItemList=null;
			ContactList.Items.Clear();
			m_OAWS.m_SessionID=null;
			logOn.Enabled=true;
			logOff.Enabled=false;
			importOutlook.Enabled=false;
			updateAll.Enabled=false;
			newContactBTN.Enabled=false;
			deleteContactBTN.Enabled=false;

		}








	}
}
