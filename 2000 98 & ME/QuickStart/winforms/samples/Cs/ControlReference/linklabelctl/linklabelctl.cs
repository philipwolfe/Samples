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
namespace Microsoft.Samples.WinForms.Cs.LinkLabelCtl {
    using System;
    using System.ComponentModel;
    using System.WinForms;
    using System.Resources;
    using System.Drawing;

    // <doc>
    // <desc>
    //     This class demonstrates the LinkLabel control.
    // </desc>
    // </doc>
    //
    public class LinkLabelCtl : System.WinForms.Form {

        public LinkLabelCtl() : base() {
             	
            // This call is required for support of the Windows Forms Form Designer.
            InitializeComponent();

            //Set the property grid to point at the link label
            propertyGrid1.SelectedObject = linkLabel1 ;
        }
    
        // <doc>
        // <desc>
        //     LinkLabelCtl overrides dispose so it can clean up the
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
        private void linkLabel1_LinkClick(object sender, EventArgs e) {
            MessageBox.Show("You clicked on the test Link") ;
            linkLabel1.LinkVisited = true ;
        }

        // NOTE: The following code is required by the Windows Forms Form Designer
        // It can be modified using the Windows Forms Form Designer.  
        // Do not modify it using the code editor.
        private System.ComponentModel.Container components;
	    private System.WinForms.PropertyGrid propertyGrid1;
	    private System.WinForms.LinkLabel linkLabel1;
	    private System.WinForms.Panel panel1;
            private System.WinForms.GroupBox grpBehavior; 
    
        private void InitializeComponent() {
		
            ResourceManager resources = new System.Resources.ResourceManager("LinkLabelCtl", typeof(LinkLabelCtl), null, true);

		    this.components = new System.ComponentModel.Container();
		    this.linkLabel1 = new System.WinForms.LinkLabel();
		    this.panel1 = new System.WinForms.Panel();
		    this.propertyGrid1 = new System.WinForms.PropertyGrid();
		    this.grpBehavior = new System.WinForms.GroupBox();
		
		    linkLabel1.DisabledLinkColor = (Color)System.Drawing.Color.Blue;
		    linkLabel1.ForeColor = (Color)System.Drawing.Color.Gainsboro;
		    linkLabel1.Location = new System.Drawing.Point(32, 128);
    		linkLabel1.BackColor = (Color)System.Drawing.Color.Transparent;
    		linkLabel1.LinkArea = new System.Drawing.Point(13, 28);
    		linkLabel1.TabIndex = 0;
    		linkLabel1.Font = new System.Drawing.Font("Tahoma", 12f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.World);
    		linkLabel1.Text = "Click on the underlined text to fire the click event";
    		linkLabel1.Size = new System.Drawing.Size(136, 96);
    		linkLabel1.LinkClick += new EventHandler(linkLabel1_LinkClick);
    		
    		this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
    		this.ClientSize = new System.Drawing.Size(504, 445);
    		this.Text = "Link Label";
    		
    		panel1.Location = new System.Drawing.Point(24, 40);
    		panel1.BackgroundImage = (System.Drawing.Image)resources.GetObject("panel1.BackgroundImage");
    		panel1.TabIndex = 1;
    		panel1.Text = "panel1";
    		panel1.Size = new System.Drawing.Size(200, 320);
    		
    		propertyGrid1.Dock = System.WinForms.DockStyle.Fill;
    		propertyGrid1.Location = new System.Drawing.Point(3, 16);
    		propertyGrid1.CommandsVisibleIfAvailable = true;
    		propertyGrid1.TabIndex = 0;
    		propertyGrid1.Text = "propertyGrid1";
    		propertyGrid1.Size = new System.Drawing.Size(242, 405);
    		
    		grpBehavior.Location = new System.Drawing.Point(248, 16);
    		grpBehavior.TabIndex = 0;
    		grpBehavior.Anchor = System.WinForms.AnchorStyles.All;
    		grpBehavior.TabStop = false;
    		grpBehavior.Text = "LinkLabel Properties";
    		grpBehavior.Size = new System.Drawing.Size(248, 424);
    		
    		grpBehavior.Controls.Add(propertyGrid1);
    		panel1.Controls.Add(linkLabel1);
    		this.Controls.Add(panel1);
    		this.Controls.Add(grpBehavior);
	    }

        // The main entry point for the application.
        public static void Main(string[] args) {
            Application.Run(new LinkLabelCtl());
        }

    }
}






