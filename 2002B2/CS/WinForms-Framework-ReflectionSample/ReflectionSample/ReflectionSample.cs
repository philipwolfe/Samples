using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Reflection;

namespace ReflectionSample
{
	/// <summary>
	/// Summary description for Form1.
	/// </summary>
	public class Form1 : System.Windows.Forms.Form

	
	{
		private Int32 x;
		private Int32 max_x; 
		private Int32 y; 
		private Int32 iBtnCount; 
		private String methodName; 

		private System.Windows.Forms.Button btn;


		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public Form1()
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
		public override void Dispose()
		{
			if(components != null)
			{
				components.Dispose();
			}
			base.Dispose();
		}

		private System.Windows.Forms.Label Label3;
		private System.Windows.Forms.Label Label2;
		private System.Windows.Forms.Button btnExecute;
		private System.Windows.Forms.GroupBox grpDynamic;
		private System.Windows.Forms.Button btnLoadMethodParameters;
		private System.Windows.Forms.Label Label1;
		private System.Windows.Forms.ComboBox cboMethods;
		private System.Windows.Forms.GroupBox grpBoxMethods;
		private System.Windows.Forms.Button btnLoadAssembly;
		private System.Windows.Forms.TextBox txtObjectName;
		private System.Windows.Forms.GroupBox brpBoxAssembly;

		#region Windows Form Designer generated code


		private void InitializeComponent()
		{
			this.Label2 = new System.Windows.Forms.Label();
			this.Label3 = new System.Windows.Forms.Label();
			this.grpDynamic = new System.Windows.Forms.GroupBox();
			this.btnExecute = new System.Windows.Forms.Button();
			this.cboMethods = new System.Windows.Forms.ComboBox();
			this.btnLoadMethodParameters = new System.Windows.Forms.Button();
			this.btnLoadAssembly = new System.Windows.Forms.Button();
			this.grpBoxMethods = new System.Windows.Forms.GroupBox();
			this.Label1 = new System.Windows.Forms.Label();
			this.brpBoxAssembly = new System.Windows.Forms.GroupBox();
			this.txtObjectName = new System.Windows.Forms.TextBox();
			this.grpDynamic.SuspendLayout();
			this.grpBoxMethods.SuspendLayout();
			this.brpBoxAssembly.SuspendLayout();
			this.SuspendLayout();
			// 
			// Label2
			// 
			this.Label2.Location = new System.Drawing.Point(3, 16);
			this.Label2.Name = "Label2";
			this.Label2.Size = new System.Drawing.Size(429, 16);
			this.Label2.TabIndex = 2;
			this.Label2.Text = "Input the assembly namespace you would like to load here and click the button:";
			// 
			// Label3
			// 
			this.Label3.Location = new System.Drawing.Point(3, 16);
			this.Label3.Name = "Label3";
			this.Label3.Size = new System.Drawing.Size(461, 40);
			this.Label3.TabIndex = 3;
			this.Label3.Text = "Once you have selected and loaded the assembly the combo below is loaded with the" +
				" methods contained by the assembly.  Select the one you would like to invoke and" +
				" click the button to load its parameters:";
			// 
			// btnExecute
			// 
			this.btnExecute.Location = new System.Drawing.Point(384, 352);
			this.btnExecute.Name = "btnExecute";
			this.btnExecute.TabIndex = 0;
			this.btnExecute.Text = "Execute";
			this.btnExecute.Click += new System.EventHandler(this.btnExecute_Click);
			// 
			// grpDynamic
			// 
			this.grpDynamic.Controls.AddRange(new System.Windows.Forms.Control[] {this.btnExecute});
			this.grpDynamic.Location = new System.Drawing.Point(8, 168);
			this.grpDynamic.Name = "grpDynamic";
			this.grpDynamic.Size = new System.Drawing.Size(472, 384);
			this.grpDynamic.TabIndex = 7;
			this.grpDynamic.TabStop = false;
			// 
			// cboMethods
			// 
			this.cboMethods.DropDownWidth = 296;
			this.cboMethods.Location = new System.Drawing.Point(56, 64);
			this.cboMethods.Name = "cboMethods";
			this.cboMethods.Size = new System.Drawing.Size(296, 21);
			this.cboMethods.TabIndex = 0;
			// 
			// btnLoadMethodParameters
			// 
			this.btnLoadMethodParameters.Location = new System.Drawing.Point(360, 64);
			this.btnLoadMethodParameters.Name = "btnLoadMethodParameters";
			this.btnLoadMethodParameters.Size = new System.Drawing.Size(104, 23);
			this.btnLoadMethodParameters.TabIndex = 2;
			this.btnLoadMethodParameters.Text = "Load Parameters";
			this.btnLoadMethodParameters.Click += new System.EventHandler(this.btnLoadMethodParameters_Click);
			// 
			// btnLoadAssembly
			// 
			this.btnLoadAssembly.Location = new System.Drawing.Point(360, 32);
			this.btnLoadAssembly.Name = "btnLoadAssembly";
			this.btnLoadAssembly.Size = new System.Drawing.Size(104, 23);
			this.btnLoadAssembly.TabIndex = 1;
			this.btnLoadAssembly.Text = "Load Assemply";
			this.btnLoadAssembly.Click += new System.EventHandler(this.btnLoadAssembly_Click);
			// 
			// grpBoxMethods
			// 
			this.grpBoxMethods.Controls.AddRange(new System.Windows.Forms.Control[] {this.Label3,
																						this.btnLoadMethodParameters,
																						this.Label1,
																						this.cboMethods});
			this.grpBoxMethods.Location = new System.Drawing.Point(8, 72);
			this.grpBoxMethods.Name = "grpBoxMethods";
			this.grpBoxMethods.Size = new System.Drawing.Size(472, 96);
			this.grpBoxMethods.TabIndex = 5;
			this.grpBoxMethods.TabStop = false;
			// 
			// Label1
			// 
			this.Label1.Location = new System.Drawing.Point(8, 64);
			this.Label1.Name = "Label1";
			this.Label1.Size = new System.Drawing.Size(48, 16);
			this.Label1.TabIndex = 1;
			this.Label1.Text = "Methods:";
			// 
			// brpBoxAssembly
			// 
			this.brpBoxAssembly.Controls.AddRange(new System.Windows.Forms.Control[] {this.Label2,
																						 this.btnLoadAssembly,
																						 this.txtObjectName});
			this.brpBoxAssembly.Location = new System.Drawing.Point(8, 8);
			this.brpBoxAssembly.Name = "brpBoxAssembly";
			this.brpBoxAssembly.Size = new System.Drawing.Size(472, 64);
			this.brpBoxAssembly.TabIndex = 4;
			this.brpBoxAssembly.TabStop = false;
			// 
			// txtObjectName
			// 
			this.txtObjectName.Location = new System.Drawing.Point(8, 32);
			this.txtObjectName.Name = "txtObjectName";
			this.txtObjectName.Size = new System.Drawing.Size(344, 20);
			this.txtObjectName.TabIndex = 0;
			this.txtObjectName.Text = "System.IO.File";
			// 
			// Form1
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(488, 556);
			this.Controls.AddRange(new System.Windows.Forms.Control[] {this.grpDynamic,
																		  this.grpBoxMethods,
																		  this.brpBoxAssembly});
			this.Name = "Form1";
			this.Text = "Reflection Sample";
			this.grpDynamic.ResumeLayout(false);
			this.grpBoxMethods.ResumeLayout(false);
			this.brpBoxAssembly.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		private void deleteOldControls()

		{
	
			foreach (System.Windows.Forms.Control cntrl in grpDynamic.Controls)
			{
				grpDynamic.Controls.Remove(cntrl);

			}

			// Note:  This may be a bug with refreshing a win32 form in Beta
			// *****  The old controls get deleted, but a "gost" image is left
			// *****  and is still visible.
			grpDynamic.Refresh();
			this.Refresh();

		}

		private void loadMethodsIntoCombo(MethodInfo[] ms)
		{
			// *** Load all methods and names into the combo box
			foreach (MethodInfo m in ms)
			{
				cboMethods.Items.Add(m.Name + getParmeterString(m.GetParameters()));
			}		
		}

		private string getParmeterString(ParameterInfo[] pi)
		{
			// *** Build a string representing the parameter list of a method.
			String str; 
			str = " (";
			for (Int32 i = 0; i<= pi.Length - 1; i++)
			{
				if (i == pi.Length - 1)
				{
					str = str + pi[i].ParameterType.FullName;
				}
				else
				{
					str = str + pi[i].ParameterType.FullName + ", ";
				}
			}

			str = str + ") ";
			return(str);
		
		}

		public void BuildControls(MethodInfo[] ms , String strMethod)
		{
			foreach(MethodInfo m in ms)
			{
				if (m.Name == strMethod)
				{
					//*** Build each parameter control
					BuildParameters(m.GetParameters());
				}
			}

		}

		public void BuildParameters(ParameterInfo[] pi)
		{

			y = 10;

			// *** Iterate through the parameter collection
			foreach (ParameterInfo p in pi)
			{

				x = 10;

				// *** Add label for param name and param type
				System.Windows.Forms.Label l = new System.Windows.Forms.Label();
				l.AccessibleName = methodName + "_" + p.Name + "1";
				l.Text = p.Name + " (" + p.ParameterType.FullName + ") :";
				l.ClientSize = new System.Drawing.Size(25 + l.Text.Length * 5, 20);
				l.Location = new System.Drawing.Point(x, y);
				l.Visible = true;

				// *** Add the created control to the form
				grpDynamic.Controls.Add(l);
				l.BringToFront();

				x = x + 50 + l.Text.Length * 5;
				switch (p.ParameterType.FullName)
				{
						// *** TODO: Date
						// *** TODO: DataSet                
						// *** TODO: Other types
					case "System.String":
						// *** Add an input box for each string param
						System.Windows.Forms.TextBox txt = new System.Windows.Forms.TextBox();
						txt.AccessibleName = methodName + "_" + p.Name;
						txt.ClientSize = new System.Drawing.Size(200, 20);
						txt.Location = new System.Drawing.Point(l.Right + 20, y);
						txt.Visible = true;

						// *** Add the input control to the form
						grpDynamic.Controls.Add(txt);
						//*** Bring the control to the front
						txt.BringToFront();
						break;

					case "System.Boolean":
						//*** Add a combo box for each boolean param
						System.Windows.Forms.ComboBox cbo = new System.Windows.Forms.ComboBox();
						cbo.AccessibleName = methodName + "_" + p.Name;
						cbo.ClientSize = new System.Drawing.Size(200, 20);
						cbo.Location = new System.Drawing.Point(l.Right + 20, y);
						cbo.Visible = true;
						cbo.Items.Add(true);
						cbo.Items.Add(false);

						// *** Add the input control to the form
						grpDynamic.Controls.Add(cbo);
						// *** Bring the control to the front
						cbo.BringToFront();
						break;

					default:
						// *** Add an input box for each other param
						System.Windows.Forms.TextBox txt2 = new System.Windows.Forms.TextBox();
						txt2.AccessibleName = methodName + "_" + p.Name;
						txt2.ClientSize = new System.Drawing.Size(200, 20);
						txt2.Location = new System.Drawing.Point(l.Right + 20, y);
						txt2.Visible = true;

						// *** Add the input control to the form
						grpDynamic.Controls.Add(txt2);
						// *** Bring the control to the front
						txt2.BringToFront();
						break;
				}

				y = y + 25;
			}

			// *** Add the Execute button below all controls created above
			btnExecute.Location = new System.Drawing.Point(x, y);
			grpDynamic.Controls.Add(btnExecute);
			// *** Bring the control to the front
			btnExecute.BringToFront();

		}

		private void btnLoadAssembly_Click(object sender, System.EventArgs e)
		{
			// *** Initialize location variables
			x = 10;
			iBtnCount = 0;

			try
			{
				Type t = System.Type.GetType(txtObjectName.Text.ToString());
			}
			catch (Exception ex)
			{
				//*** Catch and show an exception messages
				MessageBox.Show(ex.Message.ToString());
			}

			try
			{
				// *** Grab all methods for the namespace 
				Type t = System.Type.GetType(txtObjectName.Text.ToString());
				MethodInfo[] mi = t.GetMethods(BindingFlags.Static | BindingFlags.NonPublic | BindingFlags.Public);
				// *** Load all methods into combobox
				loadMethodsIntoCombo(mi);
			}
			catch (Exception ex)
			{
				//*** Catch and show an exception messages
				MessageBox.Show(ex.Message.ToString());
			}
		}

		private void btnLoadMethodParameters_Click(object sender, System.EventArgs e)
		{
			// *** Delete old controls to make room for new ones
			deleteOldControls();

			//*** Track new method name
			methodName = cboMethods.SelectedItem.ToString().Substring(0, cboMethods.SelectedItem.ToString().IndexOf(" "));

			//*** Get a handle to the namespace
			Type t = System.Type.GetType(txtObjectName.Text.ToString());

			//*** Grab all methods for the namespace
			MethodInfo[] mi = t.GetMethods(BindingFlags.Static | BindingFlags.NonPublic | BindingFlags.Public);

			BuildControls(mi, methodName);

			//*** Refresh the form
			this.Refresh();

		}

		private void btnExecute_Click(object sender, System.EventArgs e)
		{

			//*** Cycle through controls and find parameters
			System.Collections.ArrayList parameters = new System.Collections.ArrayList();

			//*** Cycle through GroupBox control and find appopriate parameters 
			//*** and populate with the values selected or input by user
			foreach(System.Windows.Forms.Control cntl in grpDynamic.Controls)
			{
				Console.WriteLine(cntl.GetType().ToString());
				if (cntl.GetType().ToString() != "System.Windows.Forms.Label")
				{
				 if (cntl.GetType().ToString() != "System.Windows.Forms.Button")
					{
						if (cntl.Text != "")
						{
						
							String[] s; 
							//*** See if method name matches
							s = cntl.AccessibleName.Split('_');
							if (s[0] == methodName)
							{
								if (cntl.GetType().ToString() == "System.Windows.Forms.TextBox")
								{
									//*** If text box, then add string
									parameters.Add(cntl.Text);
								}
								else if (cntl.GetType().ToString() == "System.Windows.Forms.ComboBox")
								{
									System.Windows.Forms.ComboBox comboControl = (System.Windows.Forms.ComboBox) cntl;
									//*** If combo box, then add the selected boolean item
									parameters.Add(Convert.ToBoolean(comboControl.SelectedItem.ToString()));
									//*** If other type, add it here with more "elseif"    
								}
							}
						}
					}
				}
			}

			//*** Create obj array
			Object[] args = new Object[parameters.Count];
			//*** Add arguments to the obj array
			for (Int32 i = 0; i <= parameters.Count - 1; i++)
			{
				args.SetValue(parameters[i], i);
			}

			Object o;

			try
			{
				//*** Invoke method with parameters 
				Type t = System.Type.GetType(txtObjectName.Text.ToString());
				o = t.InvokeMember(methodName, BindingFlags.Default | BindingFlags.InvokeMethod | BindingFlags.Static, null, null, args);
//				o = t.InvokeMember(methodName, BindingFlags.InvokeMethod, null, null, args);
			}
			catch (Exception ex)
			{
				//*** Show the message from the exception that occured
				MessageBox.Show(ex.Message.ToString());
				//*** Exit this function
				return;
			}

			//*** Load results into the next form
			if (o != null)
			{
				Output frmOutput = new Output();
				//*** Add the results to the text box
				frmOutput.txtResults.Text = o.ToString();
				//*** Show the form
				frmOutput.ShowDialog(this);
			}
			else
			{
				//*** If there was no result from the invocation of the method, just show a simple message.
				MessageBox.Show("Method was executed successfully!");
			}

		}


	}
}
