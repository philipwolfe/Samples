using System;
using System.Diagnostics;
using System.Drawing;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;

namespace GenericsPerf
{
	public class FormMain : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Button buttonRun;

		private System.Windows.Forms.GroupBox groupOptions;
		private System.Windows.Forms.Label labelCollectionType;
		private System.Windows.Forms.Label labelElementCount;
		private System.Windows.Forms.Label labelStoreType;
		private System.Windows.Forms.ComboBox comboCollectionType;

		private System.Windows.Forms.ComboBox comboStoreType;

		private System.Windows.Forms.NumericUpDown udCount;

		private System.Windows.Forms.Button buttonExit;
		private System.Windows.Forms.GroupBox groupAddResults;
		private System.Windows.Forms.Label labelResultAdd;
		private System.Windows.Forms.Label labelResultTextAdd;
		private System.Windows.Forms.Label labelGenericTimeAdd;
		private System.Windows.Forms.Label labelNonGenericTimeAdd;
		private System.Windows.Forms.Label labelGenericAdd;
		private System.Windows.Forms.Label labelNonGenericAdd;
		private System.Windows.Forms.Label labelNonGenericTimeAccess;
		private System.Windows.Forms.GroupBox groupReferenceAccess;
		private System.Windows.Forms.Label labelResultAccess;
		private System.Windows.Forms.Label labelResultTextAccess;
		private System.Windows.Forms.Label labelGenericTimeAccess;
		private System.Windows.Forms.Label labelGenericAccess;

		private System.Windows.Forms.Label labelNonGenericAccess;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public FormMain()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

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
			this.buttonRun = new System.Windows.Forms.Button();
			this.groupOptions = new System.Windows.Forms.GroupBox();
			this.comboStoreType = new System.Windows.Forms.ComboBox();
			this.udCount = new System.Windows.Forms.NumericUpDown();
			this.comboCollectionType = new System.Windows.Forms.ComboBox();
			this.labelStoreType = new System.Windows.Forms.Label();
			this.labelElementCount = new System.Windows.Forms.Label();
			this.labelCollectionType = new System.Windows.Forms.Label();
			this.groupAddResults = new System.Windows.Forms.GroupBox();
			this.labelResultAdd = new System.Windows.Forms.Label();
			this.labelResultTextAdd = new System.Windows.Forms.Label();
			this.labelGenericTimeAdd = new System.Windows.Forms.Label();
			this.labelNonGenericTimeAdd = new System.Windows.Forms.Label();
			this.labelGenericAdd = new System.Windows.Forms.Label();
			this.labelNonGenericAdd = new System.Windows.Forms.Label();
			this.buttonExit = new System.Windows.Forms.Button();
			this.labelNonGenericTimeAccess = new System.Windows.Forms.Label();
			this.groupReferenceAccess = new System.Windows.Forms.GroupBox();
			this.labelResultAccess = new System.Windows.Forms.Label();
			this.labelResultTextAccess = new System.Windows.Forms.Label();
			this.labelGenericTimeAccess = new System.Windows.Forms.Label();
			this.labelGenericAccess = new System.Windows.Forms.Label();
			this.labelNonGenericAccess = new System.Windows.Forms.Label();
			this.groupOptions.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.udCount)).BeginInit();
			this.groupAddResults.SuspendLayout();
			this.groupReferenceAccess.SuspendLayout();
			this.SuspendLayout();

// 
// buttonRun
// 
			this.buttonRun.Location = new System.Drawing.Point(11, 464);
			this.buttonRun.Name = "buttonRun";
			this.buttonRun.Size = new System.Drawing.Size(101, 44);
			this.buttonRun.TabIndex = 0;
			this.buttonRun.Text = "Run";
			this.buttonRun.Click += new System.EventHandler(this.buttonRun_Click);

// 
// groupOptions
// 
			this.groupOptions.Controls.Add(this.comboStoreType);
			this.groupOptions.Controls.Add(this.udCount);
			this.groupOptions.Controls.Add(this.comboCollectionType);
			this.groupOptions.Controls.Add(this.labelStoreType);
			this.groupOptions.Controls.Add(this.labelElementCount);
			this.groupOptions.Controls.Add(this.labelCollectionType);
			this.groupOptions.Location = new System.Drawing.Point(11, 15);
			this.groupOptions.Name = "groupOptions";
			this.groupOptions.Size = new System.Drawing.Size(353, 154);
			this.groupOptions.TabIndex = 3;
			this.groupOptions.TabStop = false;
			this.groupOptions.Text = "Options";

// 
// comboStoreType
// 
			this.comboStoreType.Items.AddRange(new object[] {
				"Integer", "String", "DateTime", "Double", "Phone Number"
			});
			this.comboStoreType.Location = new System.Drawing.Point(157, 108);
			this.comboStoreType.Name = "comboStoreType";
			this.comboStoreType.Size = new System.Drawing.Size(184, 32);
			this.comboStoreType.TabIndex = 5;

// 
// udCount
// 
			this.udCount.Increment = new System.Decimal(new int[] {
				500000, 0, 0, 0
			});
			this.udCount.Location = new System.Drawing.Point(157, 70);
			this.udCount.Maximum = new System.Decimal(new int[] {
				10000000, 0, 0, 0
			});
			this.udCount.Minimum = new System.Decimal(new int[] {
				500000, 0, 0, 0
			});
			this.udCount.Name = "udCount";
			this.udCount.Size = new System.Drawing.Size(110, 29);
			this.udCount.TabIndex = 4;
			this.udCount.Value = new System.Decimal(new int[] {
				3000000, 0, 0, 0
			});

// 
// comboCollectionType
// 
			this.comboCollectionType.Items.AddRange(new object[] {
				"ArrayList", "Hashtable", "SortedList"
			});
			this.comboCollectionType.Location = new System.Drawing.Point(155, 28);
			this.comboCollectionType.Name = "comboCollectionType";
			this.comboCollectionType.Size = new System.Drawing.Size(148, 32);
			this.comboCollectionType.TabIndex = 3;
			this.comboCollectionType.SelectedIndexChanged += new System.EventHandler(this.comboCollectionType_SelectedIndexChanged);

// 
// labelStoreType
// 
			this.labelStoreType.Location = new System.Drawing.Point(10, 108);
			this.labelStoreType.Name = "labelStoreType";
			this.labelStoreType.Size = new System.Drawing.Size(144, 31);
			this.labelStoreType.TabIndex = 2;
			this.labelStoreType.Text = "Store Type";

// 
// labelElementCount
// 
			this.labelElementCount.Location = new System.Drawing.Point(10, 70);
			this.labelElementCount.Name = "labelElementCount";
			this.labelElementCount.Size = new System.Drawing.Size(144, 31);
			this.labelElementCount.TabIndex = 1;
			this.labelElementCount.Text = "Element Count";

// 
// labelCollectionType
// 
			this.labelCollectionType.Location = new System.Drawing.Point(10, 30);
			this.labelCollectionType.Name = "labelCollectionType";
			this.labelCollectionType.Size = new System.Drawing.Size(144, 31);
			this.labelCollectionType.TabIndex = 0;
			this.labelCollectionType.Text = "Collection Type";

// 
// groupAddResults
// 
			this.groupAddResults.Controls.Add(this.labelResultAdd);
			this.groupAddResults.Controls.Add(this.labelResultTextAdd);
			this.groupAddResults.Controls.Add(this.labelGenericTimeAdd);
			this.groupAddResults.Controls.Add(this.labelNonGenericTimeAdd);
			this.groupAddResults.Controls.Add(this.labelGenericAdd);
			this.groupAddResults.Controls.Add(this.labelNonGenericAdd);
			this.groupAddResults.Location = new System.Drawing.Point(11, 176);
			this.groupAddResults.Name = "groupAddResults";
			this.groupAddResults.Size = new System.Drawing.Size(354, 132);
			this.groupAddResults.TabIndex = 4;
			this.groupAddResults.TabStop = false;
			this.groupAddResults.Text = "Add Results";

// 
// labelResultAdd
// 
			this.labelResultAdd.Location = new System.Drawing.Point(174, 91);
			this.labelResultAdd.Name = "labelResultAdd";
			this.labelResultAdd.Size = new System.Drawing.Size(172, 29);
			this.labelResultAdd.TabIndex = 5;
			this.labelResultAdd.TextAlign = System.Drawing.ContentAlignment.TopRight;
			this.labelResultAdd.Visible = false;

// 
// labelResultTextAdd
// 
			this.labelResultTextAdd.Location = new System.Drawing.Point(12, 91);
			this.labelResultTextAdd.Name = "labelResultTextAdd";
			this.labelResultTextAdd.Size = new System.Drawing.Size(126, 29);
			this.labelResultTextAdd.TabIndex = 4;
			this.labelResultTextAdd.Text = "Generics was";
			this.labelResultTextAdd.Visible = false;

// 
// labelGenericTimeAdd
// 
			this.labelGenericTimeAdd.Location = new System.Drawing.Point(257, 57);
			this.labelGenericTimeAdd.Name = "labelGenericTimeAdd";
			this.labelGenericTimeAdd.Size = new System.Drawing.Size(89, 25);
			this.labelGenericTimeAdd.TabIndex = 3;
			this.labelGenericTimeAdd.TextAlign = System.Drawing.ContentAlignment.TopRight;

// 
// labelNonGenericTimeAdd
// 
			this.labelNonGenericTimeAdd.Location = new System.Drawing.Point(257, 25);
			this.labelNonGenericTimeAdd.Name = "labelNonGenericTimeAdd";
			this.labelNonGenericTimeAdd.Size = new System.Drawing.Size(89, 25);
			this.labelNonGenericTimeAdd.TabIndex = 2;
			this.labelNonGenericTimeAdd.TextAlign = System.Drawing.ContentAlignment.TopRight;

// 
// labelGenericAdd
// 
			this.labelGenericAdd.Location = new System.Drawing.Point(12, 57);
			this.labelGenericAdd.Name = "labelGenericAdd";
			this.labelGenericAdd.Size = new System.Drawing.Size(237, 29);
			this.labelGenericAdd.TabIndex = 1;
			this.labelGenericAdd.Text = "Generic Milliseconds";

// 
// labelNonGenericAdd
// 
			this.labelNonGenericAdd.Location = new System.Drawing.Point(12, 25);
			this.labelNonGenericAdd.Name = "labelNonGenericAdd";
			this.labelNonGenericAdd.Size = new System.Drawing.Size(237, 29);
			this.labelNonGenericAdd.TabIndex = 0;
			this.labelNonGenericAdd.Text = "Non-Generic Milliseconds";

// 
// buttonExit
// 
			this.buttonExit.Location = new System.Drawing.Point(264, 464);
			this.buttonExit.Name = "buttonExit";
			this.buttonExit.Size = new System.Drawing.Size(101, 44);
			this.buttonExit.TabIndex = 5;
			this.buttonExit.Text = "Exit";
			this.buttonExit.Click += new System.EventHandler(this.buttonExit_Click);

// 
// labelNonGenericTimeAccess
// 
			this.labelNonGenericTimeAccess.Location = new System.Drawing.Point(257, 25);
			this.labelNonGenericTimeAccess.Name = "labelNonGenericTimeAccess";
			this.labelNonGenericTimeAccess.Size = new System.Drawing.Size(89, 25);
			this.labelNonGenericTimeAccess.TabIndex = 2;
			this.labelNonGenericTimeAccess.TextAlign = System.Drawing.ContentAlignment.TopRight;

// 
// groupReferenceAccess
// 
			this.groupReferenceAccess.Controls.Add(this.labelResultAccess);
			this.groupReferenceAccess.Controls.Add(this.labelResultTextAccess);
			this.groupReferenceAccess.Controls.Add(this.labelGenericTimeAccess);
			this.groupReferenceAccess.Controls.Add(this.labelNonGenericTimeAccess);
			this.groupReferenceAccess.Controls.Add(this.labelGenericAccess);
			this.groupReferenceAccess.Controls.Add(this.labelNonGenericAccess);
			this.groupReferenceAccess.Location = new System.Drawing.Point(12, 316);
			this.groupReferenceAccess.Name = "groupReferenceAccess";
			this.groupReferenceAccess.Size = new System.Drawing.Size(354, 132);
			this.groupReferenceAccess.TabIndex = 6;
			this.groupReferenceAccess.TabStop = false;
			this.groupReferenceAccess.Text = "Access Results";

// 
// labelResultAccess
// 
			this.labelResultAccess.Location = new System.Drawing.Point(174, 91);
			this.labelResultAccess.Name = "labelResultAccess";
			this.labelResultAccess.Size = new System.Drawing.Size(172, 29);
			this.labelResultAccess.TabIndex = 5;
			this.labelResultAccess.TextAlign = System.Drawing.ContentAlignment.TopRight;
			this.labelResultAccess.Visible = false;

// 
// labelResultTextAccess
// 
			this.labelResultTextAccess.Location = new System.Drawing.Point(12, 91);
			this.labelResultTextAccess.Name = "labelResultTextAccess";
			this.labelResultTextAccess.Size = new System.Drawing.Size(126, 29);
			this.labelResultTextAccess.TabIndex = 4;
			this.labelResultTextAccess.Text = "Generics was";
			this.labelResultTextAccess.Visible = false;

// 
// labelGenericTimeAccess
// 
			this.labelGenericTimeAccess.Location = new System.Drawing.Point(257, 57);
			this.labelGenericTimeAccess.Name = "labelGenericTimeAccess";
			this.labelGenericTimeAccess.Size = new System.Drawing.Size(89, 25);
			this.labelGenericTimeAccess.TabIndex = 3;
			this.labelGenericTimeAccess.TextAlign = System.Drawing.ContentAlignment.TopRight;

// 
// labelGenericAccess
// 
			this.labelGenericAccess.Location = new System.Drawing.Point(12, 57);
			this.labelGenericAccess.Name = "labelGenericAccess";
			this.labelGenericAccess.Size = new System.Drawing.Size(237, 29);
			this.labelGenericAccess.TabIndex = 1;
			this.labelGenericAccess.Text = "Generic Milliseconds";

// 
// labelNonGenericAccess
// 
			this.labelNonGenericAccess.Location = new System.Drawing.Point(12, 25);
			this.labelNonGenericAccess.Name = "labelNonGenericAccess";
			this.labelNonGenericAccess.Size = new System.Drawing.Size(237, 29);
			this.labelNonGenericAccess.TabIndex = 0;
			this.labelNonGenericAccess.Text = "Non-Generic Milliseconds";

// 
// FormMain
// 
			this.AutoScaleBaseSize = new System.Drawing.Size(9, 22);
			this.ClientSize = new System.Drawing.Size(378, 519);
			this.Controls.Add(this.groupReferenceAccess);
			this.Controls.Add(this.buttonExit);
			this.Controls.Add(this.groupAddResults);
			this.Controls.Add(this.groupOptions);
			this.Controls.Add(this.buttonRun);
			this.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.MaximizeBox = false;
			this.Name = "FormMain";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Generics Performance Demo";
			this.Load += new System.EventHandler(this.FormMain_Load);
			this.groupOptions.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.udCount)).EndInit();
			this.groupAddResults.ResumeLayout(false);
			this.groupReferenceAccess.ResumeLayout(false);
			this.ResumeLayout(false);
		}
		#endregion

		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main()
		{
			Application.EnableVisualStyles();
			Application.Run(new FormMain());
		}


		private void comboCollectionType_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			if (comboCollectionType.SelectedIndex == 0)
			{
				udCount.Maximum = 20000000;
				udCount.Minimum = 1000000;
				udCount.Increment = 1000000;
				
				udCount.Value = 3000000;
			}
			else if (comboCollectionType.SelectedIndex == 1)
			{
				udCount.Maximum = 2000000;
				udCount.Minimum = 300000;
				udCount.Increment = 100000;
				udCount.Value = 700000;
			}
			else if (comboCollectionType.SelectedIndex == 2)
			{
				udCount.Maximum = 200000;
				udCount.Minimum = 10000;
				udCount.Increment = 10000;

				udCount.Value = 50000;
			}
		}

		private void buttonRun_Click(object sender, System.EventArgs e)
		{
			Cursor = Cursors.WaitCursor;
			labelResultAdd.Visible = false;
			labelResultTextAdd.Visible = false;
			labelResultAccess.Visible = false;
			labelResultTextAccess.Visible = false;

			int count = Convert.ToInt32(udCount.Value);

			PerfResult nonGenericAddResult = RunNonGenericTest(count);
			PerfResult genericAddResult = RunGenericTest(count);

			double nonGenericRunAdd = Convert.ToDouble(nonGenericAddResult.ElapsedAdd);
			double nonGenericRunGet = Convert.ToDouble(nonGenericAddResult.ElapsedGet);
			double genericRunAdd = Convert.ToDouble(genericAddResult.ElapsedAdd);
			double genericRunGet = Convert.ToDouble(genericAddResult.ElapsedGet);
			

			labelNonGenericTimeAdd.Text = nonGenericRunAdd.ToString();
			labelGenericTimeAdd.Text = genericRunAdd.ToString();
			labelNonGenericTimeAccess.Text = nonGenericRunGet.ToString();
			labelGenericTimeAccess.Text = genericRunGet.ToString();

			double p;

			if (nonGenericRunAdd > genericRunAdd)
			{
				p = ((nonGenericRunAdd - genericRunAdd) / genericRunAdd);
				labelResultAdd.Text = String.Format("{0:p}  faster", p);
				labelResultAdd.ForeColor = Color.DarkGreen;
			}
			else
			{
				p = ((genericRunAdd - nonGenericRunAdd) / nonGenericRunAdd);
				labelResultAdd.Text = String.Format("{0:p}  slower", p);
				labelResultAdd.ForeColor = Color.Red;
			}

			if (nonGenericRunGet > genericRunGet)
			{
				p = ((nonGenericRunGet - genericRunGet) / genericRunGet);
				labelResultAccess.Text = String.Format("{0:p}  faster", p);
				labelResultAccess.ForeColor = Color.DarkGreen;
			}
			else
			{
				p = ((genericRunGet - nonGenericRunGet) / nonGenericRunGet);
				labelResultAccess.Text = String.Format("{0:p}  slower", p);
				labelResultAccess.ForeColor = Color.Red;
			}

			labelResultAdd.Visible = true;
			labelResultTextAdd.Visible = true;
			labelResultAccess.Visible = true;
			labelResultTextAccess.Visible = true;
			Cursor = Cursors.Arrow;
		}

		private PerfResult RunNonGenericTest(int count)
		{
			Random r = new Random(Environment.TickCount);
			PerfResult result = null;

			switch (comboStoreType.SelectedIndex)
			{
				case 0 :			// Integer
					switch (comboCollectionType.SelectedIndex)
					{
						case 0 :			// ArrayList
							result = IntegerTests.NonGenericListAddTest(count, r);
							break;
						case 1 :			// Hashtable
							result = IntegerTests.NonGenericHashtableAddTest(count, r);
							break;
						case 2 :			// SortedList
							result = IntegerTests.NonGenericSortedListAddTest(count, r);
							break;
					}
					break;

				case 1 :			// string
					switch (comboCollectionType.SelectedIndex)
					{
						case 0 :			// ArrayList
							result = StringTests.NonGenericListAddTest(count, r);
							break;
						case 1 :			// Hashtable
							result = StringTests.NonGenericHashtableAddTest(count, r);
							break;
						case 2 :			// SortedList
							result = StringTests.NonGenericSortedListAddTest(count, r);
							break;
					}
					break;

				case 2 :			// DateTime
					switch (comboCollectionType.SelectedIndex)
					{
						case 0 :			// ArrayList
							result = DateTimeTests.NonGenericListAddTest(count, r);
							break;
						case 1 :			// Hashtable
							result = DateTimeTests.NonGenericHashtableAddTest(count, r);
							break;
						case 2 :			// SortedList
							result = DateTimeTests.NonGenericSortedListAddTest(count, r);
							break;
					}
					break;

				case 3 :			// Double
					switch (comboCollectionType.SelectedIndex)
					{
						case 0 :			// ArrayList
							result = DoubleTests.NonGenericListAddTest(count, r);
							break;
						case 1 :			// Hashtable
							result = DoubleTests.NonGenericHashtableAddTest(count, r);
							break;
						case 2 :			// SortedList
							result = DoubleTests.NonGenericSortedListAddTest(count, r);
							break;
					}
					break;

				case 4 :			// PhoneNumber
					switch (comboCollectionType.SelectedIndex)
					{
						case 0 :			// ArrayList
							result = PhoneNumberTests.NonGenericListAddTest(count, r);
							break;
						case 1 :			// Hashtable
							result = PhoneNumberTests.NonGenericHashtableAddTest(count, r);
							break;
						case 2 :			// SortedList
							result = PhoneNumberTests.NonGenericSortedListAddTest(count, r);
							break;
					}
					break;
			}
			return result;
		}

		private PerfResult RunGenericTest(int count)
		{
			Random r = new Random(Environment.TickCount);
			PerfResult result = null;

			switch (comboStoreType.SelectedIndex)
			{
				case 0 :			// Integer
					switch (comboCollectionType.SelectedIndex)
					{
						case 0 :			// ArrayList
							result = IntegerTests.GenericListAddTest(count, r);
							break;
						case 1 :			// Hashtable
							result = IntegerTests.GenericHashtableAddTest(count, r);
							break;
						case 2 :			// SortedList
							result = IntegerTests.GenericSortedListAddTest(count, r);
							break;
					}
					break;

				case 1 :			// string
					switch (comboCollectionType.SelectedIndex)
					{
						case 0 :			// ArrayList
							result = StringTests.GenericListAddTest(count, r);
							break;
						case 1 :			// Hashtable
							result = StringTests.GenericHashtableAddTest(count, r);
							break;
						case 2 :			// SortedList
							result = StringTests.GenericSortedListAddTest(count, r);
							break;
					}
					break;

				case 2 :			// DateTime
					switch (comboCollectionType.SelectedIndex)
					{
						case 0 :			// ArrayList
							result = DateTimeTests.GenericListAddTest(count, r);
							break;
						case 1 :			// Hashtable
							result = DateTimeTests.GenericHashtableAddTest(count, r);
							break;
						case 2 :			// SortedList
							result = DateTimeTests.GenericSortedListAddTest(count, r);
							break;
					}
					break;

				case 3 :			// Double
					switch (comboCollectionType.SelectedIndex)
					{
						case 0 :			// ArrayList
							result = DoubleTests.GenericListAddTest(count, r);
							break;
						case 1 :			// Hashtable
							result = DoubleTests.GenericHashtableAddTest(count, r);
							break;
						case 2 :			// SortedList
							result = DoubleTests.GenericSortedListAddTest(count, r);
							break;
					}
					break;

				case 4 :			// PhoneNumber
					switch (comboCollectionType.SelectedIndex)
					{
						case 0 :			// ArrayList
							result = PhoneNumberTests.GenericListAddTest(count, r);
							break;
						case 1 :			// Hashtable
							result = PhoneNumberTests.GenericHashtableAddTest(count, r);
							break;
						case 2 :			// SortedList
							result = PhoneNumberTests.GenericSortedListAddTest(count, r);
							break;
					}
					break;
			}
			return result;
		}

		private void FormMain_Load(object sender, System.EventArgs e)
		{
			comboCollectionType.SelectedIndex = 0;
			comboStoreType.SelectedIndex = 0;
		}

		private void buttonExit_Click(object sender, System.EventArgs e)
		{
			this.Close();
		}
	}
}
