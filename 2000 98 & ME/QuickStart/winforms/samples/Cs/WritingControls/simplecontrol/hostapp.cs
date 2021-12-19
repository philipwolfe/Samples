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
namespace Microsoft.Samples.WinForms.Cs.HostApp {
    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.WinForms;
    using Microsoft.Samples.WinForms.Cs.SimpleControl;

    public class HostApp : System.WinForms.Form {
        private System.ComponentModel.Container components;
	private System.WinForms.RadioButton radioButton3;
	private System.WinForms.RadioButton radioButton2;
	private System.WinForms.RadioButton radioButton1;
	private System.WinForms.GroupBox groupBox1;
	    private Microsoft.Samples.WinForms.Cs.SimpleControl.SimpleControl simpleControl1;

        public HostApp() {
            
            // Required by the Windows Forms Designer
            InitializeComponent();

            // TODO: Add any constructor code after InitializeComponent call
        }


        private void radioButton3_CheckedChanged(object sender, System.EventArgs e) {
    	    if (radioButton3.Checked) {
                simpleControl1.DrawingMode = DrawingMode.Angry;
            }
    	}
    	
        private void radioButton2_CheckedChanged(object sender, System.EventArgs e) {
    	    if (radioButton2.Checked) {
                simpleControl1.DrawingMode = DrawingMode.Sad;
            }
    	}
    	
        private void radioButton1_CheckedChanged(object sender, System.EventArgs e) {
    	    if (radioButton1.Checked) {
                simpleControl1.DrawingMode = DrawingMode.Happy;
            }
    	}
    	
        private void simpleControl1_DrawingModeChanged(object sender, System.EventArgs e) {

            switch (simpleControl1.DrawingMode) {

                case DrawingMode.Happy:
                    MessageBox.Show("Well that's good to know");
                    break ;

                case DrawingMode.Sad:
                    MessageBox.Show("Come on cheer up!");
                    break ;

               case DrawingMode.Angry:
                   MessageBox.Show("Well calm down then!");
                   break ;

                default:
                    MessageBox.Show("Please make up your mind");
            }

        }


        public override void Dispose() {
            base.Dispose();
            components.Dispose();
        }

        private void InitializeComponent() {
    		this.components = new System.ComponentModel.Container();
    		this.radioButton1 = new System.WinForms.RadioButton();
    		this.radioButton3 = new System.WinForms.RadioButton();
    		this.groupBox1 = new System.WinForms.GroupBox();
    		this.simpleControl1 = new Microsoft.Samples.WinForms.Cs.SimpleControl.SimpleControl();
    		this.radioButton2 = new System.WinForms.RadioButton();
    		
    		radioButton1.Location = new System.Drawing.Point(24, 24);
    		radioButton1.Size = new System.Drawing.Size(128, 24);
    		radioButton1.TabIndex = 0;
    		radioButton1.TabStop = true;
    		radioButton1.Text = "Happy";
    		radioButton1.Checked = true;
    		radioButton1.CheckedChanged += new System.EventHandler(radioButton1_CheckedChanged);
    		
    		radioButton3.Location = new System.Drawing.Point(24, 104);
    		radioButton3.Size = new System.Drawing.Size(128, 24);
    		radioButton3.TabIndex = 2;
    		radioButton3.Text = "Angry";
    		radioButton3.CheckedChanged += new System.EventHandler(radioButton3_CheckedChanged);
    		
    		groupBox1.Size = new System.Drawing.Size(192, 152);
    		groupBox1.TabIndex = 1;
    		groupBox1.Anchor = System.WinForms.AnchorStyles.TopRight;
    		groupBox1.TabStop = false;
    		groupBox1.Text = "I am";
    		groupBox1.Location = new System.Drawing.Point(320, 16);
    		
    		this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
    		this.Text = "Control Example";
    		this.ClientSize = new System.Drawing.Size(528, 325);
    		
    		simpleControl1.Size = new System.Drawing.Size(304, 328);
    		simpleControl1.TabIndex = 0;
    		simpleControl1.Anchor = System.WinForms.AnchorStyles.All;
    		simpleControl1.Font = new System.Drawing.Font("TAHOMA", 16f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.World);
    		simpleControl1.Text = "Windows Forms Mood Control";
    		simpleControl1.DrawingModeChanged += new System.EventHandler(simpleControl1_DrawingModeChanged);
    		
    		radioButton2.Location = new System.Drawing.Point(24, 64);
    		radioButton2.Size = new System.Drawing.Size(128, 24);
    		radioButton2.TabIndex = 1;
    		radioButton2.Text = "Sad";
    		radioButton2.CheckedChanged += new System.EventHandler(radioButton2_CheckedChanged);
    		
    		this.Controls.Add(groupBox1);
    		this.Controls.Add(simpleControl1);
    		groupBox1.Controls.Add(radioButton3);
    		groupBox1.Controls.Add(radioButton2);
    		groupBox1.Controls.Add(radioButton1);
    		
    	}
    	


        public static void Main(string[] args) {
            Application.Run(new HostApp());
        }

    }
}










