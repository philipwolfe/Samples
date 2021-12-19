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
namespace Microsoft.Samples.WinForms.Cs.ButtonCtl {
    using System;
    using System.ComponentModel;
    using System.WinForms;
    using System.Resources;
    using System.Drawing;

    // <doc>
    // <desc>
    //     This class demonstrates the Button control.
    // </desc>
    // </doc>
    //
    public class ButtonCtl : System.WinForms.Form {
        private System.ComponentModel.Container components;
	    private System.WinForms.CheckBox chkImage;
	    private System.WinForms.ComboBox cmbImageAlign;
	    private System.WinForms.Label label3;
	    private System.WinForms.ComboBox cmbTextAlign;
	    private System.WinForms.Label label2;
	    private System.WinForms.ComboBox cmbFlatStyle;
	    private System.WinForms.Label label1;
	    private System.WinForms.CheckBox chkBGImage;
	    private System.WinForms.Button button1;
	    private System.WinForms.Panel panel1;
        private System.WinForms.GroupBox grpBehavior; 
        private System.Resources.ResourceManager resources;

        public ButtonCtl() : base() {
             	
            // This call is required for support of the WinForms Designer.
            InitializeComponent();

            resources = new System.Resources.ResourceManager("ButtonCtl", typeof(ButtonCtl), null, true);
            
            // Set up combo-boxes
            cmbFlatStyle.Items.All = (object[])new StringIntObject[] { 
                                new StringIntObject("Flat",(int)FlatStyle.Flat),
                                new StringIntObject("Popup",(int)FlatStyle.Popup),
                                new StringIntObject("Standard",(int)FlatStyle.Standard)} ;
            cmbFlatStyle.SelectedIndex = 0 ;

            cmbTextAlign.Items.All = (object[])new StringIntObject[] { 
                                new StringIntObject("Left",(int)ContentAlignment.Left),
                                new StringIntObject("Center",(int)ContentAlignment.Center),
                                new StringIntObject("Right",(int)ContentAlignment.Right),
                                new StringIntObject("Middle",(int)ContentAlignment.Middle),
                                new StringIntObject("Top",(int)ContentAlignment.Top),
                                new StringIntObject("Bottom",(int)ContentAlignment.Bottom),
                                new StringIntObject("TopLeft",(int)ContentAlignment.TopLeft),
                                new StringIntObject("TopCenter",(int)ContentAlignment.TopCenter),
                                new StringIntObject("TopRight",(int)ContentAlignment.TopRight),
                                new StringIntObject("MiddleLeft",(int)ContentAlignment.MiddleLeft),
                                new StringIntObject("MiddleCenter",(int)ContentAlignment.MiddleCenter),
                                new StringIntObject("MiddleRight",(int)ContentAlignment.MiddleRight),
                                new StringIntObject("BottomLeft",(int)ContentAlignment.BottomLeft),
                                new StringIntObject("BottomCenter",(int)ContentAlignment.BottomCenter),
                                new StringIntObject("BottomRight",(int)ContentAlignment.BottomRight)} ;
            cmbTextAlign.SelectedIndex = 1 ;

            cmbImageAlign.Items.All = cmbTextAlign.Items.All ;
            cmbImageAlign.SelectedIndex = 0 ;

        }
    
        // <doc>
        // <desc>
        //     ButtonCtl overrides dispose so it can clean up the
        //     component list.
        // </desc>
        // </doc>
        //
        public override void Dispose() {
            base.Dispose();
            components.Dispose();
        }
    
        // <doc>
        // <desc>
        //     Handle the click event on the button
        // </desc>
        // </doc>
        //
        protected void button1_Click(object sender, EventArgs e) {
            MessageBox.Show("You pressed the test button") ;
        }


    	protected void cmbImageAlign_SelectedIndexChanged(object sender, EventArgs e) {
	        int i = ((StringIntObject)cmbImageAlign.SelectedItem).i;
                button1.ImageAlign = (ContentAlignment)i ;
	    }
	
        protected void cmbTextAlign_SelectedIndexChanged(object sender, EventArgs e) {
	        int i = ((StringIntObject)cmbTextAlign.SelectedItem).i;
            button1.TextAlign = (ContentAlignment)i ;
        }
	
        protected void cmbFlatStyle_SelectedIndexChanged(object sender, EventArgs e) {
	        FlatStyle i = (FlatStyle)(((StringIntObject)cmbFlatStyle.SelectedItem).i);
            button1.FlatStyle = i ;
	    }
	
        protected void chkImage_Click(object sender, EventArgs e) {
            if (chkImage.Checked) {
                button1.Image = (System.Drawing.Image)resources.GetObject("button1.Image");
                cmbImageAlign.Enabled=true;
            } else {
                button1.Image = null ;
                cmbImageAlign.Enabled=false;
            }
	    }
	
        protected void chkBGImage_Click(object sender, EventArgs e) {
            if (chkBGImage.Checked) {
                button1.BackgroundImage = (System.Drawing.Image)resources.GetObject("button1.BackgroundImage");
            } else {
                button1.BackgroundImage = null ;
            }
        }


        // NOTE: The following code is required by the Windows Forms Form Designer
        // It can be modified using the Windows Forms Form Designer.  
        // Do not modify it using the code editor.
        private void InitializeComponent()
	{
		this.components = new System.ComponentModel.Container();
		this.grpBehavior = new System.WinForms.GroupBox();
		this.label1 = new System.WinForms.Label();
		this.cmbImageAlign = new System.WinForms.ComboBox();
		this.label3 = new System.WinForms.Label();
		this.label2 = new System.WinForms.Label();
		this.chkImage = new System.WinForms.CheckBox();
		this.cmbTextAlign = new System.WinForms.ComboBox();
		this.cmbFlatStyle = new System.WinForms.ComboBox();
		this.chkBGImage = new System.WinForms.CheckBox();
		this.panel1 = new System.WinForms.Panel();
		this.button1 = new System.WinForms.Button();
		
		//@design this.TrayHeight = 0;
		//@design this.TrayLargeIcon = false;
		//@design this.TrayAutoArrange = true;
		this.Text = "Button";
		this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
		this.ClientSize = new System.Drawing.Size(504, 381);
		
		grpBehavior.Location = new System.Drawing.Point(248, 16);
		grpBehavior.TabIndex = 0;
		grpBehavior.TabStop = false;
		grpBehavior.Text = "Button Properties";
		grpBehavior.Size = new System.Drawing.Size(248, 352);
		
		label1.Location = new System.Drawing.Point(16, 120);
		label1.Text = "Flat style:";
		label1.Size = new System.Drawing.Size(64, 16);
		label1.TabIndex = 1;
		
		cmbImageAlign.Location = new System.Drawing.Point(88, 216);
		cmbImageAlign.Size = new System.Drawing.Size(144, 21);
		cmbImageAlign.Enabled = false;
		cmbImageAlign.Style = System.WinForms.ComboBoxStyle.DropDownList;
		cmbImageAlign.TabIndex = 4;
		cmbImageAlign.SelectedIndexChanged += new System.EventHandler(cmbImageAlign_SelectedIndexChanged);
		
		label3.Location = new System.Drawing.Point(16, 216);
		label3.Text = "Image align:";
		label3.Size = new System.Drawing.Size(64, 24);
		label3.TabIndex = 5;
		
		label2.Location = new System.Drawing.Point(16, 168);
		label2.Text = "Text align:";
		label2.Size = new System.Drawing.Size(64, 32);
		label2.TabIndex = 3;
		
		chkImage.Location = new System.Drawing.Point(16, 64);
		chkImage.Text = "Display image";
		chkImage.Size = new System.Drawing.Size(160, 24);
		chkImage.TabIndex = 1;
		chkImage.Click += new System.EventHandler(chkImage_Click);
		
		cmbTextAlign.Location = new System.Drawing.Point(88, 168);
		cmbTextAlign.Size = new System.Drawing.Size(144, 21);
		cmbTextAlign.Style = System.WinForms.ComboBoxStyle.DropDownList;
		cmbTextAlign.TabIndex = 3;
		cmbTextAlign.SelectedIndexChanged += new System.EventHandler(cmbTextAlign_SelectedIndexChanged);
		
		cmbFlatStyle.Location = new System.Drawing.Point(88, 120);
		cmbFlatStyle.Size = new System.Drawing.Size(144, 21);
		cmbFlatStyle.Style = System.WinForms.ComboBoxStyle.DropDownList;
		cmbFlatStyle.TabIndex = 2;
		cmbFlatStyle.SelectedIndexChanged += new System.EventHandler(cmbFlatStyle_SelectedIndexChanged);
		
		chkBGImage.Location = new System.Drawing.Point(16, 32);
		chkBGImage.Text = "Display background image";
		chkBGImage.Size = new System.Drawing.Size(152, 24);
		chkBGImage.TabIndex = 0;
		chkBGImage.Click += new System.EventHandler(chkBGImage_Click);
		
		panel1.BackColor = System.Drawing.Color.DarkGoldenrod;
		panel1.Location = new System.Drawing.Point(24, 40);
		panel1.Size = new System.Drawing.Size(200, 320);
		panel1.TabIndex = 1;
		panel1.Text = "panel1";
		
		button1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
		button1.Location = new System.Drawing.Point(32, 112);
		button1.FlatStyle = System.WinForms.FlatStyle.Flat;
		button1.Size = new System.Drawing.Size(136, 56);
		button1.TabIndex = 5;
		button1.Text = "TestButton";
		button1.Click += new System.EventHandler(button1_Click);
		this.Controls.Add(panel1);
		this.Controls.Add(grpBehavior);
		panel1.Controls.Add(button1);
		grpBehavior.Controls.Add(chkImage);
		grpBehavior.Controls.Add(cmbImageAlign);
		grpBehavior.Controls.Add(cmbTextAlign);
		grpBehavior.Controls.Add(label2);
		grpBehavior.Controls.Add(cmbFlatStyle);
		grpBehavior.Controls.Add(label1);
		grpBehavior.Controls.Add(chkBGImage);
		grpBehavior.Controls.Add(label3);
	}

        // The main entry point for the application.
        public static void Main(string[] args) {
            Application.Run(new ButtonCtl());
        }

    }


    // <doc>
    // <desc>
    //     This class defines the objects in the ComboBoxes that drive
    //     the properties of the Button style selection ComboBoxes.
    // </desc>
    // </doc>
    //
    internal class StringIntObject {
        public string s;
        public int i;

        public StringIntObject(string sz, int n) {
            s=sz;
            i=n;
        }

        public override string ToString() {
            return s;
        }
    }
}






