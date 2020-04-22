using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Threading;
using System.Reflection;
using eYesoft.Tools.WebServices;

namespace WSLibTester
{
	/// <summary>
	/// Summary description for Form1.
	/// </summary>
	public class Form1 : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Panel panel1;

		private ArrayList alTb = new ArrayList();
		private ArrayList alLbl = new ArrayList();
		private ArrayList alTypes = new ArrayList();
		private System.Windows.Forms.TextBox tbWSDL;
		private System.Windows.Forms.TextBox tbType;
		private System.Windows.Forms.TextBox tbResult;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.TextBox textBox1;
		private System.Windows.Forms.TextBox textBox2;
		private System.Windows.Forms.GroupBox groupBox2;

		private DynamicWebServiceProxy wsp = null;
		private System.Windows.Forms.ComboBox cbMethods;
		private System.Windows.Forms.Label label5;

		private ArrayList methods = null;
		private ParameterInfo[] paramInfo= null;
		private System.Windows.Forms.Button bnInvoke;
		private System.Windows.Forms.Button bnCreateProxy;
		private System.Windows.Forms.Button bnInit;
		private System.Windows.Forms.Button bnClearCache;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.TextBox tbEndpoint;

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

			wsp = new DynamicWebServiceProxy();
			methods = new ArrayList();
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
			this.bnInvoke = new System.Windows.Forms.Button();
			this.label1 = new System.Windows.Forms.Label();
			this.tbWSDL = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.tbType = new System.Windows.Forms.TextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.tbResult = new System.Windows.Forms.TextBox();
			this.label4 = new System.Windows.Forms.Label();
			this.panel1 = new System.Windows.Forms.Panel();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.textBox2 = new System.Windows.Forms.TextBox();
			this.textBox1 = new System.Windows.Forms.TextBox();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.tbEndpoint = new System.Windows.Forms.TextBox();
			this.label6 = new System.Windows.Forms.Label();
			this.label5 = new System.Windows.Forms.Label();
			this.cbMethods = new System.Windows.Forms.ComboBox();
			this.bnCreateProxy = new System.Windows.Forms.Button();
			this.bnClearCache = new System.Windows.Forms.Button();
			this.bnInit = new System.Windows.Forms.Button();
			this.groupBox1.SuspendLayout();
			this.groupBox2.SuspendLayout();
			this.SuspendLayout();
			// 
			// bnInvoke
			// 
			this.bnInvoke.Enabled = false;
			this.bnInvoke.Location = new System.Drawing.Point(312, 376);
			this.bnInvoke.Name = "bnInvoke";
			this.bnInvoke.Size = new System.Drawing.Size(80, 24);
			this.bnInvoke.TabIndex = 0;
			this.bnInvoke.Text = "Invoke Call";
			this.bnInvoke.Click += new System.EventHandler(this.bnInvoke_Click);
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(16, 40);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(72, 16);
			this.label1.TabIndex = 1;
			this.label1.Text = "WSDL:";
			// 
			// tbWSDL
			// 
			this.tbWSDL.Location = new System.Drawing.Point(96, 40);
			this.tbWSDL.Name = "tbWSDL";
			this.tbWSDL.Size = new System.Drawing.Size(304, 20);
			this.tbWSDL.TabIndex = 2;
			this.tbWSDL.Text = "http://www.bindingpoint.com/ws/imalert/imalert.asmx?wsdl";
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(16, 72);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(80, 16);
			this.label2.TabIndex = 3;
			this.label2.Text = "Type Name:";
			// 
			// tbType
			// 
			this.tbType.Location = new System.Drawing.Point(96, 72);
			this.tbType.Name = "tbType";
			this.tbType.Size = new System.Drawing.Size(304, 20);
			this.tbType.TabIndex = 4;
			this.tbType.Text = "";
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(16, 104);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(80, 16);
			this.label3.TabIndex = 5;
			this.label3.Text = "Method Name:";
			// 
			// tbResult
			// 
			this.tbResult.Location = new System.Drawing.Point(8, 320);
			this.tbResult.Multiline = true;
			this.tbResult.Name = "tbResult";
			this.tbResult.Size = new System.Drawing.Size(384, 48);
			this.tbResult.TabIndex = 7;
			this.tbResult.Text = "";
			// 
			// label4
			// 
			this.label4.Location = new System.Drawing.Point(8, 168);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(72, 16);
			this.label4.TabIndex = 8;
			this.label4.Text = "Parameters:";
			// 
			// panel1
			// 
			this.panel1.AutoScroll = true;
			this.panel1.Location = new System.Drawing.Point(8, 184);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(384, 112);
			this.panel1.TabIndex = 10;
			// 
			// groupBox1
			// 
			this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.groupBox1.Controls.Add(this.textBox2);
			this.groupBox1.Controls.Add(this.textBox1);
			this.groupBox1.Location = new System.Drawing.Point(416, 8);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(432, 408);
			this.groupBox1.TabIndex = 11;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "SOAP messages";
			// 
			// textBox2
			// 
			this.textBox2.Location = new System.Drawing.Point(8, 208);
			this.textBox2.Multiline = true;
			this.textBox2.Name = "textBox2";
			this.textBox2.ScrollBars = System.Windows.Forms.ScrollBars.Both;
			this.textBox2.Size = new System.Drawing.Size(416, 192);
			this.textBox2.TabIndex = 1;
			this.textBox2.Text = "";
			// 
			// textBox1
			// 
			this.textBox1.Location = new System.Drawing.Point(8, 24);
			this.textBox1.Multiline = true;
			this.textBox1.Name = "textBox1";
			this.textBox1.ScrollBars = System.Windows.Forms.ScrollBars.Both;
			this.textBox1.Size = new System.Drawing.Size(416, 176);
			this.textBox1.TabIndex = 0;
			this.textBox1.Text = "";
			// 
			// groupBox2
			// 
			this.groupBox2.Controls.Add(this.tbEndpoint);
			this.groupBox2.Controls.Add(this.label6);
			this.groupBox2.Controls.Add(this.panel1);
			this.groupBox2.Controls.Add(this.label5);
			this.groupBox2.Controls.Add(this.cbMethods);
			this.groupBox2.Controls.Add(this.bnCreateProxy);
			this.groupBox2.Controls.Add(this.bnClearCache);
			this.groupBox2.Controls.Add(this.bnInit);
			this.groupBox2.Controls.Add(this.tbResult);
			this.groupBox2.Controls.Add(this.bnInvoke);
			this.groupBox2.Controls.Add(this.label4);
			this.groupBox2.Location = new System.Drawing.Point(8, 8);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(400, 408);
			this.groupBox2.TabIndex = 12;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "Settings";
			// 
			// tbEndpoint
			// 
			this.tbEndpoint.Location = new System.Drawing.Point(88, 128);
			this.tbEndpoint.Name = "tbEndpoint";
			this.tbEndpoint.Size = new System.Drawing.Size(224, 20);
			this.tbEndpoint.TabIndex = 17;
			this.tbEndpoint.Text = "";
			// 
			// label6
			// 
			this.label6.Location = new System.Drawing.Point(8, 128);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(64, 16);
			this.label6.TabIndex = 16;
			this.label6.Text = "Endpoint:";
			// 
			// label5
			// 
			this.label5.Location = new System.Drawing.Point(8, 304);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(100, 16);
			this.label5.TabIndex = 15;
			this.label5.Text = "Result:";
			// 
			// cbMethods
			// 
			this.cbMethods.Location = new System.Drawing.Point(88, 96);
			this.cbMethods.Name = "cbMethods";
			this.cbMethods.Size = new System.Drawing.Size(304, 21);
			this.cbMethods.TabIndex = 14;
			this.cbMethods.SelectedIndexChanged += new System.EventHandler(this.cbMethods_SelectedIndexChanged);
			// 
			// bnCreateProxy
			// 
			this.bnCreateProxy.Location = new System.Drawing.Point(8, 376);
			this.bnCreateProxy.Name = "bnCreateProxy";
			this.bnCreateProxy.Size = new System.Drawing.Size(88, 23);
			this.bnCreateProxy.TabIndex = 13;
			this.bnCreateProxy.Text = "Create Proxy";
			this.bnCreateProxy.Click += new System.EventHandler(this.bnCreateProxy_Click);
			// 
			// bnClearCache
			// 
			this.bnClearCache.Location = new System.Drawing.Point(320, 128);
			this.bnClearCache.Name = "bnClearCache";
			this.bnClearCache.TabIndex = 12;
			this.bnClearCache.Text = "Clear Cache";
			this.bnClearCache.Click += new System.EventHandler(this.bnClearCache_Click);
			// 
			// bnInit
			// 
			this.bnInit.Enabled = false;
			this.bnInit.Location = new System.Drawing.Point(168, 376);
			this.bnInit.Name = "bnInit";
			this.bnInit.TabIndex = 11;
			this.bnInit.Text = "Init";
			this.bnInit.Click += new System.EventHandler(this.bnInit_Click);
			// 
			// Form1
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(848, 421);
			this.Controls.Add(this.groupBox1);
			this.Controls.Add(this.tbType);
			this.Controls.Add(this.tbWSDL);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.groupBox2);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
			this.Name = "Form1";
			this.Text = "Dynamically invoke XML Web Services";
			this.Load += new System.EventHandler(this.Form1_Load);
			this.groupBox1.ResumeLayout(false);
			this.groupBox2.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main() 
		{
			Application.Run(new Form1());
		}

		private void bnInvoke_Click(object sender, System.EventArgs e)
		{
			this.Cursor = Cursors.WaitCursor;
			
			object result = wsp.InvokeCall();
			tbResult.Text = result.ToString();
			textBox1.Text = wsp.SoapRequest;
			textBox2.Text = wsp.SoapResponse;

			this.Cursor = Cursors.Default;
		}

		private void Form1_Load(object sender, System.EventArgs e)
		{
		}

		private void bnInit_Click(object sender, System.EventArgs e)
		{	
			wsp.TypeName = tbType.Text;
			wsp.MethodName = cbMethods.SelectedItem.ToString();
			wsp.Url = tbEndpoint.Text;

			for (int i=0; i<this.panel1.Controls.Count/2;i++)
			{
				object paramValue = this.panel1.Controls[i*2].Text;
				paramValue = Convert.ChangeType(paramValue, paramInfo[i].ParameterType);
				
				wsp.AddParameter(paramValue);
			}

			bnInvoke.Enabled = true;
		}

		private void bnClearCache_Click(object sender, System.EventArgs e)
		{
			wsp.ClearCache(tbWSDL.Text);
		}

		private void bnCreateProxy_Click(object sender, System.EventArgs e)
		{
			this.Cursor = Cursors.WaitCursor;

			wsp.WSDL = tbWSDL.Text;
			
			//populate the type field
			Type[] types = wsp.ProxyAssembly.GetTypes();
			Type theType = null;

			foreach (Type t in types)
			{
				if(t.BaseType == typeof(eYesoft.Tools.WebServices.SoapHttpClientProtocolEx))
				{
					tbType.Text = t.Name;
					theType = t;
					break;
				}
			}
			
			//populate the methods combo box
			MethodInfo[] mi = theType.GetMethods(BindingFlags.Public | 
												BindingFlags.Instance |
												BindingFlags.DeclaredOnly);
			ArrayList methodNames = new ArrayList();

			methods.Clear();
			foreach (MethodInfo m in mi)
			{
				if(!(m.Name.StartsWith("Begin") || m.Name.StartsWith("End")))
				{
					methods.Add(m);
					methodNames.Add(m.Name);
				}
			}

			cbMethods.DataSource = methodNames;
			tbEndpoint.Text = wsp.Url;

			// init the paramaters text boxes
			cbMethods_SelectedIndexChanged(null, null);

			bnInit.Enabled = true;
			bnClearCache.Enabled = false;
			
			this.Cursor = Cursors.Default;
		}

		private void cbMethods_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			this.panel1.Controls.Clear();
			alTb.Clear();
			alLbl.Clear();

			MethodInfo[] mia = (MethodInfo[])methods.ToArray(typeof(MethodInfo));
			ParameterInfo[] pi = mia[cbMethods.SelectedIndex].GetParameters();
			paramInfo = pi;

			foreach (ParameterInfo p in pi)
			{
				alTb.Add(new TextBox());
				int offset = alTb.Count-1;
				((TextBox)alTb[alTb.Count-1]).Text = "[" + p.Name + "]";
				((TextBox)alTb[alTb.Count-1]).Bounds = new Rectangle(new Point(0, offset*27), new Size(200, 50));

				alLbl.Add(new Label());
				((Label)alLbl[alLbl.Count-1]).Text = p.ParameterType.ToString();	
				((Label)alLbl[alLbl.Count-1]).Location = new Point(210, offset*27);
				((Label)alLbl[alLbl.Count-1]).Size = new Size(160, 28);

				this.panel1.Controls.Add((TextBox)alTb[alTb.Count-1]);
				this.panel1.Controls.Add((Label)alLbl[alLbl.Count-1]);
			}

		}
	}
}
