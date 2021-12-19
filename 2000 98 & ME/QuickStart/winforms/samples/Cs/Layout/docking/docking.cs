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
namespace Microsoft.Samples.WinForms.Cs.Docking {
    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.WinForms;

    public class Docking : System.WinForms.Form {
        private System.ComponentModel.Container components;
        private System.WinForms.StatusBarPanel statusBarPanel2;
        private System.WinForms.StatusBarPanel statusBarPanel1;
        private System.WinForms.StatusBar statusBar1;
        private System.WinForms.Panel panel1;

        public Docking() {
            
            // Required by the Windows Forms Designer
            InitializeComponent();

            // TODO: Add any constructor code after InitializeComponent call

        }

        public override void Dispose() {
            base.Dispose();
            components.Dispose();
        }

        private void InitializeComponent() {
            this.components = new System.ComponentModel.Container();
            this.panel1 = new System.WinForms.Panel();
            this.statusBar1 = new System.WinForms.StatusBar();
            this.statusBarPanel1 = new System.WinForms.StatusBarPanel();
            this.statusBarPanel2 = new System.WinForms.StatusBarPanel();

            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.Text = "Docking Example";
            this.ClientSize = new System.Drawing.Size(496, 293);

            panel1.Dock = System.WinForms.DockStyle.Left;
            panel1.AutoScrollMinSize = new System.Drawing.Size(0, 0);
            panel1.BackColor = System.Drawing.Color.RosyBrown;
            panel1.Size = new System.Drawing.Size(248, 273);
            panel1.TabIndex = 0;
            panel1.Text = "panel1";

            statusBar1.BackColor = System.Drawing.SystemColors.Control;
            statusBar1.Size = new System.Drawing.Size(496, 20);
            statusBar1.TabIndex = 1;
            statusBar1.Text = "statusBar1";
            statusBar1.Location = new System.Drawing.Point(0, 273);
            statusBar1.Panels.All = new System.WinForms.StatusBarPanel[] {statusBarPanel1, statusBarPanel2};

            statusBarPanel1.Text = "Panel1";
            statusBarPanel1.AutoSize = StatusBarPanelAutoSize.Contents;

            statusBarPanel2.Text = "Panel2";
            statusBarPanel2.AutoSize = StatusBarPanelAutoSize.Contents;

            this.Controls.Add(statusBar1);
            this.Controls.Add(panel1);
	    }

        public static void Main(string[] args) {
            Application.Run(new Docking());
        }

    }
}










