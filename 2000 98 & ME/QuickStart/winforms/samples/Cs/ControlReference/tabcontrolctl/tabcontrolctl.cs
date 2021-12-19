//------------------------------------------------------------------------------
/// <copyright from='1997' to='2001' company='Microsoft Corporation'>           
///    Copyright (c) Microsoft Corporation. All Rights Reserved.                
///       
///    This source code is intended only as a supplement to Microsoft
///    Development Tools and/or on-line documentation.  See these other
///    materials for detailed information regarding Microsoft code samples.
///
/// </copyright>                                                                
//------------------------------------------------------------------------------
namespace Microsoft.Samples.WinForms.Cs.TabControlCtl {
    using System;
    using System.Collections;
    using System.ComponentModel;
    using System.Drawing;
    using System.WinForms;
    using System.Resources;

    // <doc>
    // <desc>
    //     This class demonstrates the TabControl control.
    //
    //     Typically the contents of each page are encapsulated 
    //     in a UserControl however for this simple example the 
    //     contents of all pages are defined directly in this 
    //     form.
    //
    //     TabPages can either be added at designtime or runtime
    //     The main MiscUI file shows an example of how to add pages 
    //     dynamically at runtime
    //
    // </desc>
    // </doc>
    //
    public class TabControlCtl : System.WinForms.Form {
        
        public TabControlCtl() {

            // This call is required for support of the WinForms Form Designer.
            InitializeComponent();

            appearanceComboBox.SelectedIndex = 0 ;
            alignmentComboBox.SelectedIndex = 0 ;
            sizeModeComboBox.SelectedIndex = 0 ;
            tabControl1.ImageList = null;

            //BUG BUG: 31070
            resources = new System.Resources.ResourceManager("TabControlCtl", typeof(TabControlCtl), null, true);
            imageList1.ImageStream = (System.WinForms.ImageListStreamer)resources.GetObject("imageList1.ImageStream");

            //imageList1.Images.Add((Bitmap)resources.GetObject("speaker"));
            //imageList1.Images.Add((Bitmap)resources.GetObject("camcorder"));
            //imageList1.Images.Add((Bitmap)resources.GetObject("note"));
            //imageList1.Images.Add((Bitmap)resources.GetObject("calendar"));
            //imageList1.Images.Add((Bitmap)resources.GetObject("time"));


        }

        // <doc>
        // <desc>
        //     TabControlCtl overrides dispose so it can clean up the
        //     component list.
        // </desc>
        // </doc>
        //
        public override void Dispose() {
            base.Dispose();
            components.Dispose();
        }
        
        protected void checkBox1_Click(object sender, EventArgs e) {
            this.tabControl1.Multiline = checkBox1.Checked;
        }

        protected void checkBox2_Click(object sender, EventArgs e) {
            this.tabControl1.HotTrack = checkBox2.Checked;
        }
        
        protected void checkBox3_Click(object sender, EventArgs e) {
            if (checkBox3.Checked)
                tabControl1.ImageList = imageList1;
            else
                tabControl1.ImageList = null;
        }
        
        protected void appearanceComboBox_SelectedIndexChanged(object sender, EventArgs e) {
            int index = appearanceComboBox.SelectedIndex;
            if (index == 0) {
                tabControl1.Appearance = TabAppearance.Normal;
            }
            else if (index == 1) {
                tabControl1.Appearance = TabAppearance.Buttons;
            }
            else {
                tabControl1.Appearance = TabAppearance.FlatButtons;
            }
            tabControl1.PerformLayout();


        }
    
        protected void alignmentComboBox_SelectedIndexChanged(object sender, EventArgs e) {
            int index = alignmentComboBox.SelectedIndex;
            if (index == 0) {
                tabControl1.Alignment = TabAlignment.Top;
            }
            else if (index == 1) {
                tabControl1.Alignment = TabAlignment.Bottom;
            }
            else if (index == 2) {
                tabControl1.Alignment = TabAlignment.Left;
            }
            else
                tabControl1.Alignment = TabAlignment.Right;
        }

        protected void sizeModeComboBox_SelectedIndexChanged(object sender, EventArgs e) {
            int index = sizeModeComboBox.SelectedIndex;
            if (index == 0) {
                tabControl1.SizeMode = TabSizeMode.Normal;
            }
            else if (index == 1) {
                tabControl1.SizeMode = TabSizeMode.FillToRight;
            }
            else
                tabControl1.SizeMode = TabSizeMode.Fixed;

        }

        protected void trackBar_Scroll(object sender, EventArgs e) {
            tabControl1.Width = trackBar.Value;
        }

        // NOTE: The following code is required by the WinForms Designer
        // It can be modified using the Winforms Designer.  
        // Do not modify it using the code editor.
        private System.ComponentModel.Container components;
	private System.WinForms.DomainUpDown tp5DomainUpDown1;
	private System.WinForms.GroupBox tp5GroupBox1;
	private System.WinForms.ComboBox tp4ComboBox1;
	private System.WinForms.NumericUpDown tp4UpDown1;
	private System.WinForms.GroupBox tp4GroupBox1;
	private System.WinForms.ComboBox tp3ComboBox1;
	private System.WinForms.RadioButton tp3RadioButton1;
	private System.WinForms.RadioButton tp3RadioButton2;
	private System.WinForms.ComboBox tp3ComboBox2;
	private System.WinForms.Label tp3Label1;
	private System.WinForms.Button tp3Button1;
	private System.WinForms.GroupBox tp3GroupBox1;
	private System.WinForms.TabPage tabPage5;
	private System.WinForms.TabPage tabPage4;
	private System.WinForms.TabPage tabPage3;
	private System.WinForms.ComboBox tp2ComboBox1;
	private System.WinForms.RadioButton tp2RadioButton1;
	private System.WinForms.RadioButton tp2RadioButton2;
	private System.WinForms.GroupBox tp2GroupBox1;
	private System.WinForms.TabPage tabPage2;
	private System.WinForms.TabPage tabPage1; 
        private System.WinForms.GroupBox groupBox1; 
        private System.WinForms.ComboBox appearanceComboBox; 
        private System.WinForms.CheckBox checkBox1; 
        private System.WinForms.TabControl tabControl1; 
        private System.WinForms.ComboBox alignmentComboBox; 
        private System.WinForms.CheckBox checkBox2; 
        private System.WinForms.ComboBox sizeModeComboBox; 
        private System.WinForms.Label label1; 
        private System.WinForms.Label label2; 
        private System.WinForms.Label label3; 
        private System.WinForms.TrackBar trackBar; 
        private System.WinForms.Label label4; 
        private System.WinForms.PictureBox pictureBox1; 
        private System.WinForms.ToolTip toolTip1;
        private System.WinForms.ImageList imageList1; 
        private System.WinForms.CheckBox checkBox3; 
       	private System.WinForms.ComboBox tp1ComboBox1;
	private System.WinForms.Label tp1Label1;
	private System.WinForms.Label tp1Label2;
	private System.WinForms.Button tp1Button1;
	private System.WinForms.GroupBox tp1GroupBox1;
        private System.Resources.ResourceManager resources;


        private void InitializeComponent()
	{


		this.components = new System.ComponentModel.Container();
		this.label2 = new System.WinForms.Label();
		this.label1 = new System.WinForms.Label();
		this.tp3RadioButton1 = new System.WinForms.RadioButton();
		this.tp5DomainUpDown1 = new System.WinForms.DomainUpDown();
		this.alignmentComboBox = new System.WinForms.ComboBox();
		this.tp1Label2 = new System.WinForms.Label();
		this.tp1Label1 = new System.WinForms.Label();
		this.tp1GroupBox1 = new System.WinForms.GroupBox();
		this.tp3RadioButton2 = new System.WinForms.RadioButton();
		this.trackBar = new System.WinForms.TrackBar();
		this.tp2ComboBox1 = new System.WinForms.ComboBox();
		this.tp2RadioButton2 = new System.WinForms.RadioButton();
		this.tp1ComboBox1 = new System.WinForms.ComboBox();
		this.label4 = new System.WinForms.Label();
		this.imageList1 = new System.WinForms.ImageList();
		this.tp4GroupBox1 = new System.WinForms.GroupBox();
		this.sizeModeComboBox = new System.WinForms.ComboBox();
		this.toolTip1 = new System.WinForms.ToolTip(components);
		this.checkBox2 = new System.WinForms.CheckBox();
		this.groupBox1 = new System.WinForms.GroupBox();
		this.tp4ComboBox1 = new System.WinForms.ComboBox();
		this.tp1Button1 = new System.WinForms.Button();
		this.appearanceComboBox = new System.WinForms.ComboBox();
		this.tabPage1 = new System.WinForms.TabPage();
		this.label3 = new System.WinForms.Label();
		this.tp2RadioButton1 = new System.WinForms.RadioButton();
		this.checkBox3 = new System.WinForms.CheckBox();
		this.checkBox1 = new System.WinForms.CheckBox();
		this.tp3ComboBox2 = new System.WinForms.ComboBox();
		this.pictureBox1 = new System.WinForms.PictureBox();
		this.tp4UpDown1 = new System.WinForms.NumericUpDown();
		this.tabPage4 = new System.WinForms.TabPage();
		this.tp5GroupBox1 = new System.WinForms.GroupBox();
		this.tp2GroupBox1 = new System.WinForms.GroupBox();
		this.tp3ComboBox1 = new System.WinForms.ComboBox();
		this.tp3Button1 = new System.WinForms.Button();
		this.tabControl1 = new System.WinForms.TabControl();
		this.tabPage2 = new System.WinForms.TabPage();
		this.tabPage5 = new System.WinForms.TabPage();
		this.tabPage3 = new System.WinForms.TabPage();
		this.tp3GroupBox1 = new System.WinForms.GroupBox();
		this.tp3Label1 = new System.WinForms.Label();


		
		trackBar.BeginInit();
		tp4UpDown1.BeginInit();
		
		//@design this.TrayHeight = 90;
		//@design this.TrayLargeIcon = false;
		//@design this.TrayAutoArrange = true;
		this.Text = "TabControl";
		this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
		this.ClientSize = new System.Drawing.Size(546, 293);
		
		label2.Location = new System.Drawing.Point(16, 48);
		label2.Text = "Alignment";
		label2.Size = new System.Drawing.Size(64, 16);
		label2.TabIndex = 8;
		
		label1.Location = new System.Drawing.Point(16, 16);
		label1.Text = "Appearance";
		label1.Size = new System.Drawing.Size(72, 16);
		label1.TabIndex = 7;
		
		tp3RadioButton1.Location = new System.Drawing.Point(8, 24);
		tp3RadioButton1.Text = "&Single Instrument";
		tp3RadioButton1.Size = new System.Drawing.Size(136, 23);
		tp3RadioButton1.Enabled = false;
		tp3RadioButton1.TabIndex = 4;
		
		tp5DomainUpDown1.Location = new System.Drawing.Point(24, 32);
		tp5DomainUpDown1.Text = "11:01:35 AM";
		tp5DomainUpDown1.Size = new System.Drawing.Size(112, 20);
		tp5DomainUpDown1.Enabled = false;
		tp5DomainUpDown1.AccessibleRole = System.WinForms.AccessibleRoles.ComboBox;
		tp5DomainUpDown1.AccessibleName = "DomainUpDown";
		tp5DomainUpDown1.TabIndex = 0;
		
		alignmentComboBox.Location = new System.Drawing.Point(128, 48);
		alignmentComboBox.Size = new System.Drawing.Size(104, 21);
		alignmentComboBox.Style = System.WinForms.ComboBoxStyle.DropDownList;
		toolTip1.SetToolTip(alignmentComboBox, "Determines whether the tabs appear on the top, bottom,left o" + 
			"r, right side of the control.");
		alignmentComboBox.TabIndex = 4;
		alignmentComboBox.SelectedIndexChanged += new System.EventHandler(alignmentComboBox_SelectedIndexChanged);
		alignmentComboBox.Items.All = new object[] {"top",
			"bottom",
			"left",
			"right"};
		
		tp1Label2.Location = new System.Drawing.Point(24, 88);
		tp1Label2.Text = "To select advanced options, click:";
		tp1Label2.Size = new System.Drawing.Size(176, 16);
		tp1Label2.TabIndex = 1;
		
		tp1Label1.Location = new System.Drawing.Point(24, 24);
		tp1Label1.Text = "Preferred device:";
		tp1Label1.Size = new System.Drawing.Size(100, 16);
		tp1Label1.TabIndex = 2;
		
		tp1GroupBox1.Location = new System.Drawing.Point(12, 16);
		tp1GroupBox1.TabIndex = 0;
		tp1GroupBox1.TabStop = false;
		tp1GroupBox1.Text = "Playback";
		tp1GroupBox1.Size = new System.Drawing.Size(202, 144);
		
		tp3RadioButton2.Location = new System.Drawing.Point(8, 80);
		tp3RadioButton2.Text = "&Custom Configuration";
		tp3RadioButton2.Size = new System.Drawing.Size(168, 23);
		tp3RadioButton2.Enabled = false;
		tp3RadioButton2.TabIndex = 3;
		
		trackBar.Value = 220;
		trackBar.Location = new System.Drawing.Point(16, 192);
		trackBar.Text = "trackBar1";
		trackBar.Maximum = 220;
		trackBar.Size = new System.Drawing.Size(216, 42);
		trackBar.TabIndex = 2;
		trackBar.TickFrequency = 10;
		trackBar.TabStop = false;
		trackBar.BackColor = System.Drawing.SystemColors.Control;
		trackBar.Scroll += new System.EventHandler(trackBar_Scroll);
		
		tp2ComboBox1.Text = "Original Size";
		tp2ComboBox1.Location = new System.Drawing.Point(32, 80);
		tp2ComboBox1.Size = new System.Drawing.Size(160, 21);
		tp2ComboBox1.Enabled = false;
		tp2ComboBox1.TabIndex = 2;
		
		tp2RadioButton2.Location = new System.Drawing.Point(32, 48);
		tp2RadioButton2.Text = "&Full Screen";
		tp2RadioButton2.Size = new System.Drawing.Size(100, 23);
		tp2RadioButton2.Enabled = false;
		tp2RadioButton2.TabIndex = 0;
		
		tp1ComboBox1.Text = "(Use any available device)";
		tp1ComboBox1.Location = new System.Drawing.Point(24, 48);
		tp1ComboBox1.Size = new System.Drawing.Size(160, 21);
		tp1ComboBox1.Enabled = false;
		tp1ComboBox1.TabIndex = 3;
		
		label4.Location = new System.Drawing.Point(16, 168);
		label4.Text = "Tab Control Width:";
		label4.Size = new System.Drawing.Size(120, 16);
		label4.TabIndex = 3;
		
		//@design imageList1.SetLocation(new System.Drawing.Point(85, 7));
		imageList1.ImageSize = new System.Drawing.Size(16, 16);
		imageList1.ColorDepth = System.WinForms.ColorDepth.Depth8Bit;
		imageList1.TransparentColor = System.Drawing.Color.Transparent;
		
		tp4GroupBox1.Location = new System.Drawing.Point(12, 16);
		tp4GroupBox1.TabIndex = 0;
		tp4GroupBox1.TabStop = false;
		tp4GroupBox1.Text = "Date";
		tp4GroupBox1.Size = new System.Drawing.Size(202, 88);
		
		sizeModeComboBox.Location = new System.Drawing.Point(128, 80);
		sizeModeComboBox.Size = new System.Drawing.Size(104, 21);
		sizeModeComboBox.Style = System.WinForms.ComboBoxStyle.DropDownList;
		toolTip1.SetToolTip(sizeModeComboBox, "Indicates how tabs are sized.");
		sizeModeComboBox.TabIndex = 6;
		sizeModeComboBox.SelectedIndexChanged += new System.EventHandler(sizeModeComboBox_SelectedIndexChanged);
		sizeModeComboBox.Items.All = new object[] {"Normal",
			"Fill to Right",
			"Fixed"};
		
		//@design toolTip1.SetLocation(new System.Drawing.Point(7, 7));
		toolTip1.Active = true;
		
		checkBox2.Location = new System.Drawing.Point(16, 136);
		checkBox2.Text = "HotTrack";
		checkBox2.Size = new System.Drawing.Size(100, 23);
		toolTip1.SetToolTip(checkBox2, "Indiactes whether the tabs visually change as the mouse pass" + 
			"es");
		checkBox2.TabIndex = 5;
		checkBox2.Click += new System.EventHandler(checkBox2_Click);
		
		groupBox1.Location = new System.Drawing.Point(280, 16);
		groupBox1.TabIndex = 1;
		groupBox1.TabStop = false;
		groupBox1.Text = "TabControl";
		groupBox1.Size = new System.Drawing.Size(248, 264);
		
		tp4ComboBox1.Text = "June";
		tp4ComboBox1.Location = new System.Drawing.Point(16, 32);
		tp4ComboBox1.Size = new System.Drawing.Size(56, 21);
		tp4ComboBox1.Enabled = false;
		tp4ComboBox1.TabIndex = 1;
		
		tp1Button1.Location = new System.Drawing.Point(24, 112);
		tp1Button1.Size = new System.Drawing.Size(160, 23);
		tp1Button1.TabIndex = 0;
		tp1Button1.Enabled = false;
		tp1Button1.Text = "Advanced &Properties";
		
		appearanceComboBox.Location = new System.Drawing.Point(128, 16);
		appearanceComboBox.Size = new System.Drawing.Size(104, 21);
		appearanceComboBox.Style = System.WinForms.ComboBoxStyle.DropDownList;
		toolTip1.SetToolTip(appearanceComboBox, "Indicates whether the tabs are painted as buttons or regular" + 
			" tabs.");
		appearanceComboBox.TabIndex = 1;
		appearanceComboBox.SelectedIndexChanged += new System.EventHandler(appearanceComboBox_SelectedIndexChanged);
		appearanceComboBox.Items.All = new object[] {"Normal",
			"Buttons",
			"Flat Buttons"};
		
		tabPage1.Text = "Audio";
		tabPage1.Size = new System.Drawing.Size(224, 193);
		tabPage1.ImageIndex = 0;
		tabPage1.TabIndex = 0;
		
		label3.Location = new System.Drawing.Point(16, 80);
		label3.Text = "SizeMode";
		label3.Size = new System.Drawing.Size(80, 16);
		label3.TabIndex = 9;
		
		tp2RadioButton1.Location = new System.Drawing.Point(32, 24);
		tp2RadioButton1.Text = "&Window";
		tp2RadioButton1.Size = new System.Drawing.Size(100, 23);
		tp2RadioButton1.Enabled = false;
		tp2RadioButton1.TabIndex = 1;
		
		checkBox3.Location = new System.Drawing.Point(128, 112);
		checkBox3.Text = "Images";
		checkBox3.Size = new System.Drawing.Size(72, 16);
		checkBox3.TabIndex = 10;
		checkBox3.Click += new System.EventHandler(checkBox3_Click);
		
		checkBox1.Location = new System.Drawing.Point(16, 112);
		checkBox1.Text = "Multiline";
		checkBox1.Size = new System.Drawing.Size(88, 16);
		toolTip1.SetToolTip(checkBox1, "Indicates if more than one row of tabs is allowed.");
		checkBox1.TabIndex = 0;
		checkBox1.Click += new System.EventHandler(checkBox1_Click);
		
		tp3ComboBox2.Text = "Default";
		tp3ComboBox2.Location = new System.Drawing.Point(24, 120);
		tp3ComboBox2.Size = new System.Drawing.Size(96, 21);
		tp3ComboBox2.Enabled = false;
		tp3ComboBox2.TabIndex = 2;
		
		pictureBox1.BorderStyle = System.WinForms.BorderStyle.Fixed3D;
		pictureBox1.BackColor = System.Drawing.SystemColors.ControlLightLight;
		pictureBox1.Location = new System.Drawing.Point(8, 24);
		pictureBox1.Size = new System.Drawing.Size(264, 256);
		pictureBox1.TabIndex = 2;
		pictureBox1.TabStop = false;
		pictureBox1.Text = "pictureBox1";
		
		tp4UpDown1.Location = new System.Drawing.Point(88, 32);
		tp4UpDown1.Maximum = new System.Decimal(0d);
		tp4UpDown1.TextAlign = System.WinForms.HorizontalAlignment.Right;
		tp4UpDown1.Size = new System.Drawing.Size(64, 20);
		tp4UpDown1.Enabled = false;
		tp4UpDown1.DecimalPlaces = 2;
		tp4UpDown1.TabIndex = 0;
		
		tabPage4.Text = "Date";
		tabPage4.Size = new System.Drawing.Size(224, 193);
		tabPage4.ImageIndex = 3;
		tabPage4.TabIndex = 3;
		
		tp5GroupBox1.Location = new System.Drawing.Point(12, 16);
		tp5GroupBox1.TabIndex = 0;
		tp5GroupBox1.TabStop = false;
		tp5GroupBox1.Text = "Time";
		tp5GroupBox1.Size = new System.Drawing.Size(202, 88);
		
		tp2GroupBox1.Location = new System.Drawing.Point(12, 16);
		tp2GroupBox1.TabIndex = 0;
		tp2GroupBox1.TabStop = false;
		tp2GroupBox1.Text = "Show video in:";
		tp2GroupBox1.Size = new System.Drawing.Size(202, 128);
		
		tp3ComboBox1.Text = "Creative Music Synth [220]";
		tp3ComboBox1.Location = new System.Drawing.Point(24, 48);
		tp3ComboBox1.Size = new System.Drawing.Size(160, 21);
		tp3ComboBox1.Enabled = false;
		tp3ComboBox1.TabIndex = 5;
		
		tp3Button1.Location = new System.Drawing.Point(122, 120);
		tp3Button1.Size = new System.Drawing.Size(74, 24);
		tp3Button1.TabIndex = 0;
		tp3Button1.Enabled = false;
		tp3Button1.Text = "&Configure";
		
		tabControl1.Location = new System.Drawing.Point(24, 32);
		tabControl1.Text = "tabControl1";
		tabControl1.Size = new System.Drawing.Size(232, 220);
		tabControl1.SelectedIndex = 0;
		tabControl1.ImageList = imageList1;
		tabControl1.TabIndex = 0;
		
		tabPage2.Text = "Video";
		tabPage2.Size = new System.Drawing.Size(224, 193);
		tabPage2.ImageIndex = 1;
		tabPage2.TabIndex = 1;
		
		tabPage5.Text = "Time";
		tabPage5.Size = new System.Drawing.Size(224, 193);
		tabPage5.ImageIndex = 4;
		tabPage5.TabIndex = 4;
		
		tabPage3.Text = "MIDI";
		tabPage3.Size = new System.Drawing.Size(224, 193);
		tabPage3.ImageIndex = 2;
		tabPage3.TabIndex = 2;
		
		tp3GroupBox1.Location = new System.Drawing.Point(12, 16);
		tp3GroupBox1.TabIndex = 0;
		tp3GroupBox1.TabStop = false;
		tp3GroupBox1.Text = "Midi Output";
		tp3GroupBox1.Size = new System.Drawing.Size(202, 160);
		
		tp3Label1.Location = new System.Drawing.Point(24, 104);
		tp3Label1.Text = "Midi Scheme:";
		tp3Label1.Size = new System.Drawing.Size(100, 16);
		tp3Label1.TabIndex = 1;
		tabPage1.Controls.Add(tp1GroupBox1);
		this.Controls.Add(tabControl1);
		this.Controls.Add(pictureBox1);
		this.Controls.Add(groupBox1);
		tabPage4.Controls.Add(tp4GroupBox1);
		tabPage5.Controls.Add(tp5GroupBox1);
		tabPage2.Controls.Add(tp2GroupBox1);
		tabPage3.Controls.Add(tp3GroupBox1);
		tp3GroupBox1.Controls.Add(tp3ComboBox2);
		tp3GroupBox1.Controls.Add(tp3Label1);
		tp3GroupBox1.Controls.Add(tp3RadioButton2);
		tp3GroupBox1.Controls.Add(tp3Button1);
		tp3GroupBox1.Controls.Add(tp3ComboBox1);
		tp3GroupBox1.Controls.Add(tp3RadioButton1);
		tp2GroupBox1.Controls.Add(tp2ComboBox1);
		tp2GroupBox1.Controls.Add(tp2RadioButton1);
		tp2GroupBox1.Controls.Add(tp2RadioButton2);
		tp5GroupBox1.Controls.Add(tp5DomainUpDown1);
		tabControl1.Controls.Add(tabPage1);
		tabControl1.Controls.Add(tabPage2);
		tabControl1.Controls.Add(tabPage3);
		tabControl1.Controls.Add(tabPage4);
		tabControl1.Controls.Add(tabPage5);
		tp1GroupBox1.Controls.Add(tp1Label1);
		tp1GroupBox1.Controls.Add(tp1Label2);
		tp1GroupBox1.Controls.Add(tp1Button1);
		tp1GroupBox1.Controls.Add(tp1ComboBox1);
		groupBox1.Controls.Add(checkBox3);
		groupBox1.Controls.Add(label4);
		groupBox1.Controls.Add(trackBar);
		groupBox1.Controls.Add(label3);
		groupBox1.Controls.Add(label2);
		groupBox1.Controls.Add(label1);
		groupBox1.Controls.Add(sizeModeComboBox);
		groupBox1.Controls.Add(checkBox2);
		groupBox1.Controls.Add(alignmentComboBox);
		groupBox1.Controls.Add(appearanceComboBox);
		groupBox1.Controls.Add(checkBox1);
		tp4GroupBox1.Controls.Add(tp4ComboBox1);
		tp4GroupBox1.Controls.Add(tp4UpDown1);
		
		trackBar.EndInit();
		tp4UpDown1.EndInit();
	}
        
        // The main entry point for the application.
        public static void Main(string[] args) {
            Application.Run(new TabControlCtl());
        }

    }

}







