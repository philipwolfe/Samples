//==========================================================================
//  File:		math.cs
//
//--------------------------------------------------------------------------
//  This file is part of the Microsoft NGWS Samples.
//
//  Copyright (C) 2000 Microsoft Corporation.  All rights reserved.
//==========================================================================
namespace PDCDemo.VersionAndDeploy {

    using System;
	using System.Reflection;
    using System.ComponentModel;
    using System.Drawing;
    using System.WinForms;
	using System.Resources;
	using System.Globalization;
	using System.Threading;

	using PDCDemo.VersionAndDeploy.Calculator;
    using PDCDemo.VersionAndDeploy.ParseUtil;

    public class VersioningDemo : Form {
        private System.ComponentModel.Container components;

		private ResourceManager rm;

        private TextBox txtFormula;
		private Label   lblFormula;
		private Button  btnEquals;
		private Button  btnClear;
		private Button[]  btnNumbers;
		private Button[]  btnOps;

        public VersioningDemo(String culture) 
		{
			//
			// If a specific culture is passed in through the command-line, use that -- otherwise
			// set it to our default: es.  Normally you're default culture would just be picked up
			// from UI culture on the machine on which the app is running, but I'm hardcoding it 
			// here because my UI culture is English, but I want to demo a non-English default
			// culture.
			//
			if (culture != "") 
				Thread.CurrentThread.CurrentUICulture = new CultureInfo(culture);
			else
				Thread.CurrentThread.CurrentUICulture = new CultureInfo("es");

			InitializeComponent();
        }

        public override void Dispose() 
		{
            base.Dispose();
        }

		private String GetResourceString(String res)
		{
			// just returns a string from the resource manager
			return rm.GetString(res);
		}

        private void InitializeComponent() 
		{

			//  		
			// Create an instance of the resource manager.  The second parameter identifies
			// the "main" assembly.  All searching for satellites is done based on the location, etc ..
			// of the main assembly.
			//
			rm = new ResourceManager("MyStrings",  
                                      this.GetType().Module.Assembly,
                                      null,                            
                                      true); 
									  
                     
            components = new System.ComponentModel.Container();
            txtFormula = new TextBox();
			lblFormula = new Label();
			btnEquals  = new Button();
			btnClear   = new Button();
			btnNumbers = new Button[10];
			btnOps     = new Button[4];


            AutoScaleBaseSize = new System.Drawing.Size(5, 13);

			this.Text = GetResourceString("Math_Greeting");

            this.ClientSize = new System.Drawing.Size(230, 230);

            lblFormula.Location = new System.Drawing.Point(8, 10);
            lblFormula.Text = GetResourceString("Math_Formula_Label");
            lblFormula.Size = new System.Drawing.Size(155, 20);

            txtFormula.Location = new System.Drawing.Point(8, 28);
            txtFormula.TabIndex = 0;
            txtFormula.Size = new System.Drawing.Size(150, 25);


			btnClear.Location = new Point(165, 28);
            btnClear.Size = new Size(50, 25);
            btnClear.Text = GetResourceString("Math_Clear_Button");
            btnClear.AddOnClick(new System.EventHandler(btnClearClicked));

			btnNumbers[0] = new Button();
			btnNumbers[0].Location = new Point(8, 180);
			btnNumbers[0].Text = "0";

			btnNumbers[1] = new Button();
			btnNumbers[1].Location = new Point(8, 60);
			btnNumbers[1].Text = "1";

			btnNumbers[2] = new Button();
			btnNumbers[2].Location = new Point(48, 60);
			btnNumbers[2].Text = "2";

			btnNumbers[3] = new Button();
			btnNumbers[3].Location = new Point(88, 60);
			btnNumbers[3].Text = "3";

			btnNumbers[4] = new Button();
			btnNumbers[4].Location = new Point(8, 100);
			btnNumbers[4].Text = "4";

			btnNumbers[5] = new Button();
			btnNumbers[5].Location = new Point(48, 100);
			btnNumbers[5].Text = "5";

			btnNumbers[6] = new Button();
			btnNumbers[6].Location = new Point(88, 100);
			btnNumbers[6].Text = "6";

			btnNumbers[7] = new Button();
			btnNumbers[7].Location = new Point(8, 140);
			btnNumbers[7].Text = "7";

			btnNumbers[8] = new Button();
			btnNumbers[8].Location = new Point(48, 140);
			btnNumbers[8].Text = "8";

			btnNumbers[9] = new Button();
			btnNumbers[9].Location = new Point(88, 140);
			btnNumbers[9].Text = "9";

			for (int i = 0; i < 10; i++) 
			{
				btnNumbers[i].Size = new Size(30, 30);
				btnNumbers[i].AddOnClick(new System.EventHandler(btnNumbersClicked));

			}

			btnOps[0] = new Button();
			btnOps[0].Location = new Point(128, 60);
			btnOps[0].Text = "+";

			btnOps[1] = new Button();
			btnOps[1].Location = new Point(128, 100);
			btnOps[1].Text = "-";

			btnOps[2] = new Button();
			btnOps[2].Location = new Point(128, 140);
			btnOps[2].Text = "*";

			btnOps[3] = new Button();
			btnOps[3].Location = new Point(128, 180);
			btnOps[3].Text = "/";

			for (int i = 0; i < 4; i++) 
			{
				btnOps[i].Size = new Size(30, 30);
				btnOps[i].AddOnClick(new System.EventHandler(btnOpClicked));

			}


			btnEquals.Location = new Point(48, 180);
            btnEquals.Size = new Size(70, 30);
            btnEquals.TabIndex = 1;
            btnEquals.Text = GetResourceString("Math_Calc_Button");;
            btnEquals.AddOnClick(new System.EventHandler(btnEqualsClicked));

			

            Controls.Add(txtFormula);
			Controls.Add(lblFormula);
			Controls.Add(btnEquals);
			Controls.Add(btnClear);

			for (int i = 0; i < 10; i++) 
			{
				Controls.Add(btnNumbers[i]);

			}

			for (int i = 0; i < 4; i++) 
			{
				Controls.Add(btnOps[i]);

			}
	    }


        private void btnClearClicked(object sender, EventArgs evArgs) 
		{
            txtFormula.Text = "";
        }

        private void btnNumbersClicked(object sender, EventArgs evArgs) 
		{
			Button btn = (Button) sender;
            txtFormula.Text += btn.Text;
        }

		private void btnOpClicked(object sender, EventArgs evArgs) 
		{
			Button btn = (Button) sender;
            txtFormula.Text = txtFormula.Text + " " + btn.Text + " ";
        }

        private void btnEqualsClicked(object sender, EventArgs evArgs) 
		{
			// parse the formula and get the arguments
			Parser p = new Parser();
			Arguments a = p.Parse(txtFormula.Text);

			// do the calc and display the results
			try
			{
				Calc c = new Calc();
				txtFormula.Text = c.GetResult(a.Arg1.ToInt32(), a.Op, a.Arg2.ToInt32());
			}
			catch
			{
				MessageBox.Show(GetResourceString("Math_Calc_Error"), GetResourceString("Math_Greeting"));
			}
        }

        public static void Main(string[] args) {
			
			//
			// Main takes an optional argument identifying the culture you'd like displayed.
			//
		
			String strCulture = "";
			if (args.Length == 1) 
			{
				strCulture = args[0];
			}

            Application.Run(new VersioningDemo(strCulture));
        }

    }
}


