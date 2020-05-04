#region Imports

using System;
using System.Collections;
using System.ComponentModel;
using System.IO;
using System.Reflection;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Xsl;
using EnvDTE;

#endregion

namespace BizTalkWscfClient
{
	/// <summary>
	/// This form sets up and, generates the and 
	/// adds to the Biztakj project the web port type odx file.
	/// </summary>
	public class GenerateOdxForm : Form
	{
		private Button btnOpenFile;
		private Label labelWsdlFile;
		private Label labelServiceURL;
		private TextBox textBoxServiceUrl;
		private Label labelPortNamespace;
		private TextBox textBoxPortNamespace;
		private ErrorProvider errorProvider;
		private TextBox textBoxWsdlFile;

		private IAddOdxFileCommand addOdxFileCmd;
		private System.Windows.Forms.Button btnGenerateOdxFile;
		private System.Windows.Forms.Label labelRedAsterix1;
		private System.Windows.Forms.Label labelRedAsterix2;
		private System.Windows.Forms.Label labelRedAsterix3;
		private System.Windows.Forms.Label labelMessagesNamespace;
		private System.Windows.Forms.TextBox textBoxMessagesNamespace;
		private System.Windows.Forms.Button btnCancel;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private Container components = null;

		public GenerateOdxForm(IAddOdxFileCommand addOdxFileCmd)
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			this.addOdxFileCmd = addOdxFileCmd;
			this.errorProvider.SetIconPadding(textBoxWsdlFile, 20);
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if(components != null)
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
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(GenerateOdxForm));
			this.textBoxWsdlFile = new System.Windows.Forms.TextBox();
			this.btnOpenFile = new System.Windows.Forms.Button();
			this.labelWsdlFile = new System.Windows.Forms.Label();
			this.labelServiceURL = new System.Windows.Forms.Label();
			this.textBoxServiceUrl = new System.Windows.Forms.TextBox();
			this.labelMessagesNamespace = new System.Windows.Forms.Label();
			this.textBoxMessagesNamespace = new System.Windows.Forms.TextBox();
			this.labelPortNamespace = new System.Windows.Forms.Label();
			this.textBoxPortNamespace = new System.Windows.Forms.TextBox();
			this.errorProvider = new System.Windows.Forms.ErrorProvider();
			this.btnGenerateOdxFile = new System.Windows.Forms.Button();
			this.labelRedAsterix1 = new System.Windows.Forms.Label();
			this.labelRedAsterix2 = new System.Windows.Forms.Label();
			this.labelRedAsterix3 = new System.Windows.Forms.Label();
			this.btnCancel = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// textBoxWsdlFile
			// 
			this.textBoxWsdlFile.Location = new System.Drawing.Point(152, 16);
			this.textBoxWsdlFile.Name = "textBoxWsdlFile";
			this.textBoxWsdlFile.Size = new System.Drawing.Size(392, 20);
			this.textBoxWsdlFile.TabIndex = 0;
			this.textBoxWsdlFile.Text = "";
			this.textBoxWsdlFile.Validated += new System.EventHandler(this.OnValidateTextBoxWsdlFile);
			// 
			// btnOpenFile
			// 
			this.btnOpenFile.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnOpenFile.BackgroundImage")));
			this.btnOpenFile.Location = new System.Drawing.Point(544, 16);
			this.btnOpenFile.Name = "btnOpenFile";
			this.btnOpenFile.Size = new System.Drawing.Size(20, 20);
			this.btnOpenFile.TabIndex = 1;
			this.btnOpenFile.Click += new System.EventHandler(this.OnOpenWsdlFile);
			// 
			// labelWsdlFile
			// 
			this.labelWsdlFile.Location = new System.Drawing.Point(8, 16);
			this.labelWsdlFile.Name = "labelWsdlFile";
			this.labelWsdlFile.Size = new System.Drawing.Size(56, 23);
			this.labelWsdlFile.TabIndex = 2;
			this.labelWsdlFile.Text = "Wsdl File:";
			// 
			// labelServiceURL
			// 
			this.labelServiceURL.Location = new System.Drawing.Point(8, 112);
			this.labelServiceURL.Name = "labelServiceURL";
			this.labelServiceURL.Size = new System.Drawing.Size(112, 23);
			this.labelServiceURL.TabIndex = 6;
			this.labelServiceURL.Text = "Service URL:";
			// 
			// textBoxServiceUrl
			// 
			this.textBoxServiceUrl.Location = new System.Drawing.Point(152, 112);
			this.textBoxServiceUrl.Name = "textBoxServiceUrl";
			this.textBoxServiceUrl.Size = new System.Drawing.Size(392, 20);
			this.textBoxServiceUrl.TabIndex = 5;
			this.textBoxServiceUrl.Text = "";
			// 
			// labelMessagesNamespace
			// 
			this.labelMessagesNamespace.Location = new System.Drawing.Point(8, 48);
			this.labelMessagesNamespace.Name = "labelMessagesNamespace";
			this.labelMessagesNamespace.Size = new System.Drawing.Size(128, 23);
			this.labelMessagesNamespace.TabIndex = 8;
			this.labelMessagesNamespace.Text = "Messages Namespace:";
			// 
			// textBoxMessagesNamespace
			// 
			this.textBoxMessagesNamespace.Location = new System.Drawing.Point(152, 48);
			this.textBoxMessagesNamespace.Name = "textBoxMessagesNamespace";
			this.textBoxMessagesNamespace.Size = new System.Drawing.Size(392, 20);
			this.textBoxMessagesNamespace.TabIndex = 7;
			this.textBoxMessagesNamespace.Text = "";
			this.textBoxMessagesNamespace.Validated += new System.EventHandler(this.OnValidateTextBoxMessagesNamespace);
			// 
			// labelPortNamespace
			// 
			this.labelPortNamespace.Location = new System.Drawing.Point(8, 80);
			this.labelPortNamespace.Name = "labelPortNamespace";
			this.labelPortNamespace.Size = new System.Drawing.Size(128, 23);
			this.labelPortNamespace.TabIndex = 10;
			this.labelPortNamespace.Text = "Wsdl Proxy Namespace:";
			// 
			// textBoxPortNamespace
			// 
			this.textBoxPortNamespace.Location = new System.Drawing.Point(152, 80);
			this.textBoxPortNamespace.Name = "textBoxPortNamespace";
			this.textBoxPortNamespace.Size = new System.Drawing.Size(392, 20);
			this.textBoxPortNamespace.TabIndex = 9;
			this.textBoxPortNamespace.Text = "";
			this.textBoxPortNamespace.Validated += new System.EventHandler(this.OnValidateTextBoxPortNamespace);
			// 
			// errorProvider
			// 
			this.errorProvider.ContainerControl = this;
			// 
			// btnGenerateOdxFile
			// 
			this.btnGenerateOdxFile.Location = new System.Drawing.Point(376, 144);
			this.btnGenerateOdxFile.Name = "btnGenerateOdxFile";
			this.btnGenerateOdxFile.Size = new System.Drawing.Size(80, 23);
			this.btnGenerateOdxFile.TabIndex = 11;
			this.btnGenerateOdxFile.Text = "Generate";
			this.btnGenerateOdxFile.Click += new System.EventHandler(this.OnGenerateOdxFile);
			// 
			// labelRedAsterix1
			// 
			this.labelRedAsterix1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.labelRedAsterix1.ForeColor = System.Drawing.Color.Red;
			this.labelRedAsterix1.Location = new System.Drawing.Point(128, 16);
			this.labelRedAsterix1.Name = "labelRedAsterix1";
			this.labelRedAsterix1.Size = new System.Drawing.Size(8, 23);
			this.labelRedAsterix1.TabIndex = 14;
			this.labelRedAsterix1.Text = "*";
			// 
			// labelRedAsterix2
			// 
			this.labelRedAsterix2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.labelRedAsterix2.ForeColor = System.Drawing.Color.Red;
			this.labelRedAsterix2.Location = new System.Drawing.Point(128, 48);
			this.labelRedAsterix2.Name = "labelRedAsterix2";
			this.labelRedAsterix2.Size = new System.Drawing.Size(8, 23);
			this.labelRedAsterix2.TabIndex = 15;
			this.labelRedAsterix2.Text = "*";
			// 
			// labelRedAsterix3
			// 
			this.labelRedAsterix3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.labelRedAsterix3.ForeColor = System.Drawing.Color.Red;
			this.labelRedAsterix3.Location = new System.Drawing.Point(128, 80);
			this.labelRedAsterix3.Name = "labelRedAsterix3";
			this.labelRedAsterix3.Size = new System.Drawing.Size(8, 23);
			this.labelRedAsterix3.TabIndex = 16;
			this.labelRedAsterix3.Text = "*";
			// 
			// btnCancel
			// 
			this.btnCancel.Location = new System.Drawing.Point(464, 144);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.Size = new System.Drawing.Size(80, 23);
			this.btnCancel.TabIndex = 17;
			this.btnCancel.Text = "Cancel";
			this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
			// 
			// GenerateOdxForm
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(578, 175);
			this.Controls.Add(this.btnCancel);
			this.Controls.Add(this.labelRedAsterix3);
			this.Controls.Add(this.labelRedAsterix2);
			this.Controls.Add(this.labelRedAsterix1);
			this.Controls.Add(this.btnGenerateOdxFile);
			this.Controls.Add(this.labelPortNamespace);
			this.Controls.Add(this.textBoxPortNamespace);
			this.Controls.Add(this.labelMessagesNamespace);
			this.Controls.Add(this.textBoxMessagesNamespace);
			this.Controls.Add(this.labelServiceURL);
			this.Controls.Add(this.textBoxServiceUrl);
			this.Controls.Add(this.labelWsdlFile);
			this.Controls.Add(this.btnOpenFile);
			this.Controls.Add(this.textBoxWsdlFile);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "GenerateOdxForm";
			this.Text = "BiztalkWscfClient Web Port Type Generation ";
			this.ResumeLayout(false);

		}
		#endregion

		private void OnOpenWsdlFile(object sender, EventArgs e)
		{
			try
			{
				OpenFileDialog openFileDialog = new OpenFileDialog();

				openFileDialog.InitialDirectory = "rootDir";
				openFileDialog.Filter = "wsdl files (*.wsdl)|*.wsdl";
				openFileDialog.FilterIndex = 1;
				openFileDialog.RestoreDirectory = true;

				if(openFileDialog.ShowDialog() == DialogResult.OK)
				{
					textBoxWsdlFile.Text = openFileDialog.FileName;
					OnValidateTextBoxWsdlFile(textBoxWsdlFile, EventArgs.Empty);
				}		
			}
			catch (Exception exc)
			{
				MessageBox.Show("Error encountered during openning the wsdl file: " + exc.Message, 
					Connect.addInName, MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		private void btnCancel_Click(object sender, System.EventArgs e)
		{
			if (MessageBox.Show("Do you really want to quit?", 
				Connect.addInName, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
			{
				this.Close();
			}
		}

		private void OnGenerateOdxFile(object sender, EventArgs e)
		{
			try
			{			
				OnValidateTextBoxWsdlFile(textBoxWsdlFile, EventArgs.Empty);
				OnValidateTextBoxMessagesNamespace(textBoxMessagesNamespace, EventArgs.Empty);
				OnValidateTextBoxPortNamespace(textBoxPortNamespace, EventArgs.Empty);

				if (this.errorProvider.GetError(textBoxWsdlFile) != string.Empty
					|| this.errorProvider.GetError(textBoxMessagesNamespace) != string.Empty
					|| this.errorProvider.GetError(textBoxPortNamespace) != string.Empty)
				{
					MessageBox.Show("Please insert the required information." , 
						Connect.addInName, MessageBoxButtons.OK, MessageBoxIcon.Information);					
					return;
				}
				string resFilePath = string.Format("{0}{1}.odx", 
				                                   addOdxFileCmd.TargetDir, Path.GetFileNameWithoutExtension(textBoxWsdlFile.Text));
				GenerateRawOdxFile(resFilePath);
				PostProcessRawOdxFile(resFilePath);

				// add created file to dir
				addOdxFileCmd.AddOdxFile(resFilePath);

				MessageBox.Show(string.Format("Web port odx file '{0}' was succesfully generated.", resFilePath), 
					Connect.addInName, MessageBoxButtons.OK, MessageBoxIcon.Information);
			}
			catch (Exception exc)
			{
				MessageBox.Show("Error encountered during generating the odx file: " + exc.Message, 
					Connect.addInName, MessageBoxButtons.OK, MessageBoxIcon.Error);
			}	
		}

		private void GenerateRawOdxFile(string resFilePath)
		{
			XmlDocument xmlDoc = new XmlDocument();
			xmlDoc.Load(textBoxWsdlFile.Text);
			XslTransform xslTran = new XslTransform();
				
			Stream xslFileStream = Assembly.GetExecutingAssembly().GetManifestResourceStream("BizTalkWscfClient.transform.xsl");
			xslTran.Load(new XmlTextReader(xslFileStream), null, GetType().Assembly.Evidence);

			XmlWriter xmlWriter = new XmlTextWriter(resFilePath, Encoding.UTF8);

			// This is for writing in the current page
			XsltArgumentList xsltParams = new XsltArgumentList();
			xsltParams.AddParam("serviceNamespace", "", FormatWebPortTypeNamespace());
			xsltParams.AddParam("serviceUrl", "", textBoxServiceUrl.Text);
			xsltParams.AddParam("schemasNamespace", "", textBoxMessagesNamespace.Text);
			xsltParams.AddParam("portNamespace", "", textBoxPortNamespace.Text);			

			XmlNamespaceManager nmspcMgr = new XmlNamespaceManager(xmlDoc.NameTable);
			nmspcMgr.AddNamespace("wsdl", "http://schemas.xmlsoap.org/wsdl/");
			XmlNode defsNode = xmlDoc.SelectSingleNode("wsdl:definitions", nmspcMgr);
			if(defsNode == null)
			{
				MessageBox.Show("The wsdl file is not valid, the 'definitions' root node cannot be found.",
					Connect.addInName, MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}

			XmlAttribute targetNmspcAttr = defsNode.Attributes["targetNamespace"];
			xsltParams.AddParam("targetNamespace", "", 
				targetNmspcAttr != null ? targetNmspcAttr.Value : "");

			xslTran.Transform(xmlDoc, xsltParams, xmlWriter, new XmlUrlResolver());
			xmlWriter.Flush();
			xmlWriter.Close();			
		}

		private void PostProcessRawOdxFile(string resFilePath)
		{
			// post processing
			String theXml = "";
			StringBuilder res = new StringBuilder();
			using (StreamReader sr = new StreamReader(resFilePath)) 
			{
				theXml = sr.ReadToEnd();
				theXml = theXml.Replace("${the xml declaration}", "<?xml version=\"1.0\" encoding=\"utf-8\" standalone=\"yes\"?>");

				int oldIdx = 0;
				for (int idx = theXml.IndexOf("????????-????-????-????-????????????");
					idx > -1; 
					idx = theXml.IndexOf("????????-????-????-????-????????????", oldIdx))
				{
					res.Append(theXml.Substring(oldIdx, idx - oldIdx));
					res.Append(Guid.NewGuid());
					oldIdx = idx + 36;
				}
				res.Append(theXml.Substring(oldIdx));
			}

			using (StreamWriter sw = new StreamWriter(new FileStream(resFilePath, FileMode.Create), Encoding.UTF8))
			{
				sw.Write(res.ToString());
			}			
		}

		private string FormatWebPortTypeNamespace()
		{
			string projectPath = string.Empty;
			string defaultNamespace = string.Empty;
			string portTypeNamespace = "";
			try
			{
				foreach (Property prop in addOdxFileCmd.Project.Properties)
				{
					try
					{			
						if (prop.Name == "FullPath")
						{
							projectPath = prop.Value.ToString();
						}
						else if (prop.Name == "CommonProperties" && prop.Value is IDictionary)
						{
							foreach (object obj in ((IDictionary)prop.Value).Keys)
							{
								if (obj.ToString() == "DefaultNamespace")
								{
									defaultNamespace = ((IDictionary)prop.Value)[obj].ToString();
								}
							}
						}
					}
					catch (Exception)
					{}
				}	
		
				if (projectPath != string.Empty && defaultNamespace != string.Empty)
				{
					string folderPath = addOdxFileCmd.TargetDir;
					int idx = folderPath.IndexOf(projectPath);
					if (idx == 0)
					{
						portTypeNamespace = defaultNamespace + folderPath.Substring(projectPath.Length - 1,
							folderPath.Length - projectPath.Length);
						
						portTypeNamespace = portTypeNamespace.Replace('\\', '.');
					}
				}
			}
			catch (Exception exc)
			{
				MessageBox.Show("Error encountered during formatting the new web port type namespace, \r\nplease fill in manually on the generation setup form: \r\n" + exc.Message, 
					Connect.addInName, MessageBoxButtons.OK, MessageBoxIcon.Warning);
			}

			return portTypeNamespace;
		}

		private void OnValidateTextBoxWsdlFile(object sender, System.EventArgs e)
		{
			errorProvider.SetError(textBoxWsdlFile, 
				File.Exists(textBoxWsdlFile.Text) ? 
				"" : "A valid wsdl input file must be specified");
		}

		private void OnValidateTextBoxMessagesNamespace(object sender, System.EventArgs e)
		{
			errorProvider.SetError(textBoxMessagesNamespace, 
				textBoxMessagesNamespace.Text != "" ? 
				"" : "The used message schemas namespace must be specified");		
		}

		private void OnValidateTextBoxPortNamespace(object sender, System.EventArgs e)
		{
			errorProvider.SetError(textBoxPortNamespace, 
				textBoxPortNamespace.Text != "" ? 
				"" : "The generated web proxy namespace must be specified");			
		}
	}
}
