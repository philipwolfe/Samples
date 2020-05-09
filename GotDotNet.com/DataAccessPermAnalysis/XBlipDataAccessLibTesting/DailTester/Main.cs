using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.IO;
using System.Xml;
using System.Xml.XPath;
using System.Xml.Xsl;
using System.Text;
using XBLIP.Transformers;

namespace XSLTesterApp
{
	/// <summary>
	/// Summary description for Form1.
	/// </summary>
	public class frmMain : System.Windows.Forms.Form
	{
		private System.Windows.Forms.TextBox txtXMLFile;
		private System.Windows.Forms.Button btnBrowseXML;
		private System.Windows.Forms.TextBox txtXSLFile;
		private System.Windows.Forms.Button btnBrowseXSL;
		private System.Windows.Forms.Label lblXMLFile;
		private System.Windows.Forms.Label lblXSLFile;
		private System.Windows.Forms.Button btnApply;
		private System.Windows.Forms.Button btnOutput;
		private System.Windows.Forms.OpenFileDialog dlgFileOpen;
		private System.Windows.Forms.SaveFileDialog dlgFileSave;
		private System.Windows.Forms.TextBox txtOutput;
		private System.Windows.Forms.Button btnDAIL;
		private System.Windows.Forms.ComboBox cmbAction;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public frmMain()
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
			this.txtXMLFile = new System.Windows.Forms.TextBox();
			this.btnBrowseXML = new System.Windows.Forms.Button();
			this.txtXSLFile = new System.Windows.Forms.TextBox();
			this.btnBrowseXSL = new System.Windows.Forms.Button();
			this.lblXMLFile = new System.Windows.Forms.Label();
			this.lblXSLFile = new System.Windows.Forms.Label();
			this.txtOutput = new System.Windows.Forms.TextBox();
			this.btnApply = new System.Windows.Forms.Button();
			this.btnOutput = new System.Windows.Forms.Button();
			this.dlgFileOpen = new System.Windows.Forms.OpenFileDialog();
			this.dlgFileSave = new System.Windows.Forms.SaveFileDialog();
			this.btnDAIL = new System.Windows.Forms.Button();
			this.cmbAction = new System.Windows.Forms.ComboBox();
			this.SuspendLayout();
			// 
			// txtXMLFile
			// 
			this.txtXMLFile.AllowDrop = true;
			this.txtXMLFile.Location = new System.Drawing.Point(128, 40);
			this.txtXMLFile.Name = "txtXMLFile";
			this.txtXMLFile.Size = new System.Drawing.Size(248, 20);
			this.txtXMLFile.TabIndex = 0;
			this.txtXMLFile.Text = "";
			this.txtXMLFile.DragDrop += new System.Windows.Forms.DragEventHandler(this.onXMLDrop);
			this.txtXMLFile.DragEnter += new System.Windows.Forms.DragEventHandler(this.onSingleFileDragEnter);
			// 
			// btnBrowseXML
			// 
			this.btnBrowseXML.Location = new System.Drawing.Point(392, 39);
			this.btnBrowseXML.Name = "btnBrowseXML";
			this.btnBrowseXML.Size = new System.Drawing.Size(80, 24);
			this.btnBrowseXML.TabIndex = 1;
			this.btnBrowseXML.Text = "Browse...";
			this.btnBrowseXML.Click += new System.EventHandler(this.btnBrowseXML_Click);
			// 
			// txtXSLFile
			// 
			this.txtXSLFile.AllowDrop = true;
			this.txtXSLFile.Location = new System.Drawing.Point(128, 80);
			this.txtXSLFile.Name = "txtXSLFile";
			this.txtXSLFile.Size = new System.Drawing.Size(248, 20);
			this.txtXSLFile.TabIndex = 2;
			this.txtXSLFile.Text = "";
			this.txtXSLFile.DragDrop += new System.Windows.Forms.DragEventHandler(this.onXSLDrop);
			this.txtXSLFile.DragEnter += new System.Windows.Forms.DragEventHandler(this.onSingleFileDragEnter);
			// 
			// btnBrowseXSL
			// 
			this.btnBrowseXSL.Location = new System.Drawing.Point(392, 79);
			this.btnBrowseXSL.Name = "btnBrowseXSL";
			this.btnBrowseXSL.Size = new System.Drawing.Size(80, 24);
			this.btnBrowseXSL.TabIndex = 3;
			this.btnBrowseXSL.Text = "Browse...";
			this.btnBrowseXSL.Click += new System.EventHandler(this.btnBrowseXSL_Click);
			// 
			// lblXMLFile
			// 
			this.lblXMLFile.Location = new System.Drawing.Point(48, 46);
			this.lblXMLFile.Name = "lblXMLFile";
			this.lblXMLFile.Size = new System.Drawing.Size(72, 16);
			this.lblXMLFile.TabIndex = 4;
			this.lblXMLFile.Text = "XML File :";
			// 
			// lblXSLFile
			// 
			this.lblXSLFile.Location = new System.Drawing.Point(48, 80);
			this.lblXSLFile.Name = "lblXSLFile";
			this.lblXSLFile.Size = new System.Drawing.Size(72, 16);
			this.lblXSLFile.TabIndex = 5;
			this.lblXSLFile.Text = "XSL File :";
			// 
			// txtOutput
			// 
			this.txtOutput.Location = new System.Drawing.Point(40, 168);
			this.txtOutput.Multiline = true;
			this.txtOutput.Name = "txtOutput";
			this.txtOutput.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.txtOutput.Size = new System.Drawing.Size(424, 240);
			this.txtOutput.TabIndex = 6;
			this.txtOutput.Text = "";
			// 
			// btnApply
			// 
			this.btnApply.Location = new System.Drawing.Point(392, 128);
			this.btnApply.Name = "btnApply";
			this.btnApply.Size = new System.Drawing.Size(80, 24);
			this.btnApply.TabIndex = 7;
			this.btnApply.Text = "Do Me";
			this.btnApply.Click += new System.EventHandler(this.btnApply_Click);
			// 
			// btnOutput
			// 
			this.btnOutput.Location = new System.Drawing.Point(40, 129);
			this.btnOutput.Name = "btnOutput";
			this.btnOutput.Size = new System.Drawing.Size(88, 24);
			this.btnOutput.TabIndex = 8;
			this.btnOutput.Text = "Output->File...";
			this.btnOutput.Click += new System.EventHandler(this.btnOutput_Click);
			// 
			// btnDAIL
			// 
			this.btnDAIL.Location = new System.Drawing.Point(280, 128);
			this.btnDAIL.Name = "btnDAIL";
			this.btnDAIL.Size = new System.Drawing.Size(88, 24);
			this.btnDAIL.TabIndex = 9;
			this.btnDAIL.Text = "DAIL Me";
			this.btnDAIL.Click += new System.EventHandler(this.btnDAIL_Click);
			// 
			// cmbAction
			// 
			this.cmbAction.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmbAction.Items.AddRange(new object[] {
														   "Retrieve",
														   "Modify"});
			this.cmbAction.Location = new System.Drawing.Point(152, 128);
			this.cmbAction.Name = "cmbAction";
			this.cmbAction.Size = new System.Drawing.Size(104, 21);
			this.cmbAction.TabIndex = 10;
			this.cmbAction.SelectedIndex = 0;
			// 
			// frmMain
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(528, 454);
			this.Controls.AddRange(new System.Windows.Forms.Control[] {
																		  this.cmbAction,
																		  this.btnDAIL,
																		  this.btnOutput,
																		  this.btnApply,
																		  this.txtOutput,
																		  this.lblXSLFile,
																		  this.lblXMLFile,
																		  this.btnBrowseXSL,
																		  this.txtXSLFile,
																		  this.btnBrowseXML,
																		  this.txtXMLFile});
			this.Name = "frmMain";
			this.Text = "A simple XSL transformer";
			this.ResumeLayout(false);

		}
		#endregion

		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main() 
		{
			Application.Run(new frmMain());
		}

		private void btnBrowseXML_Click(object sender, System.EventArgs e)
		{
			dlgFileOpen.Filter = "xml files (*.xml)|*.xml|All files (*.*)|*.*";
			dlgFileOpen.FilterIndex = 1;
			dlgFileOpen.RestoreDirectory = true ;
			
			if(txtXMLFile.Text != "")
				dlgFileOpen.FileName = txtXMLFile.Text;

			if(dlgFileOpen.ShowDialog() == DialogResult.OK)
				txtXMLFile.Text = dlgFileOpen.FileName;

		}

		private void btnBrowseXSL_Click(object sender, System.EventArgs e)
		{
			dlgFileOpen.Filter = "xsl files (*.xsl)|*.xsl|All files (*.*)|*.*";
			dlgFileOpen.FilterIndex = 1;
			dlgFileOpen.RestoreDirectory = true ;
			
			if(txtXSLFile.Text != "")
				dlgFileOpen.FileName = txtXSLFile.Text;

			if(dlgFileOpen.ShowDialog() == DialogResult.OK)
				txtXSLFile.Text = dlgFileOpen.FileName;		
		}

		private void btnOutput_Click(object sender, System.EventArgs e)
		{
			StreamWriter stmFileSave;

			dlgFileSave.Filter = "All files (*.*)|*.*";
			dlgFileSave.FilterIndex = 1;
			dlgFileSave.RestoreDirectory = true ;
			
			if(dlgFileSave.ShowDialog() == DialogResult.OK) 
			{
				stmFileSave = new StreamWriter(dlgFileSave.FileName);
				stmFileSave.Write(txtOutput.Text);
				stmFileSave.Close();
			}
		}

		private void onSingleFileDragEnter(object sender,DragEventArgs e) 
		{
			String[] arrFileNames;

			// allow only a drop of a single file

			if(e.Data.GetDataPresent("FileDrop")) 
			{
				arrFileNames = (String[])e.Data.GetData("FileDrop");
				if(arrFileNames.Length == 1)
					e.Effect = DragDropEffects.Link;
			}
		}

		private void onXMLDrop(object sender,DragEventArgs e) 
		{
			String []arrFileName;

			arrFileName = (String[])e.Data.GetData("FileDrop");
			txtXMLFile.Text = arrFileName[0];
		}
		private void onXSLDrop(object sender,DragEventArgs e) 
		{
			String []arrFileName;

			arrFileName = (String[])e.Data.GetData("FileDrop");
			txtXSLFile.Text = arrFileName[0];
		}
		private void btnApply_Click(object sender, System.EventArgs e)
		{
			string strErrorMessage = null;
			StringBuilder stbBuffer = new StringBuilder();
			bool bStatusOK = false;
			XslTransform xslTranform = null;
			XPathDocument xpathTransformed = null;
			StringWriter stmWriter;

			// do validation loop
			do 
			{
				// check that both file names are valid
				if(txtXSLFile.Text == "") 
				{
					strErrorMessage = "XSL file name is missing";
					continue;
				}
				
				if(txtXMLFile.Text == "") 
				{
					strErrorMessage = "XML file name is missing";
					continue;
				}
				

				// check and load XML and XSL files
				xslTranform = new XslTransform();
				try 
				{
					xslTranform.Load(txtXSLFile.Text);
				} 
				catch(XsltCompileException ex) 
				{
					stbBuffer.Append("XSL file is not a valid stylesheet:\n");
					stbBuffer.Append("Message: ");
					stbBuffer.Append(ex.Message);
					strErrorMessage = stbBuffer.ToString();
					continue;
				}

				try 
				{
					xpathTransformed = new XPathDocument(txtXMLFile.Text);
				} 
				catch(XmlException ex) 
				{
					stbBuffer.Append("XML file is not a valid XML:\n");
					stbBuffer.Append("Message: ");
					stbBuffer.Append(ex.Message);
					strErrorMessage = stbBuffer.ToString();
					continue;
				}

				bStatusOK = true;
			} while(false);

			if(bStatusOK) 
			{
				// if all is well, transform and write output to the output window
				stmWriter = new StringWriter(stbBuffer);
				xslTranform.Transform(xpathTransformed,null,stmWriter);
			
				txtOutput.Text = stbBuffer.ToString();
			} 
			else 
			{
				MessageBox.Show(strErrorMessage);
			}
		}

		private void btnDAIL_Click(object sender, System.EventArgs e)
		{
			TestDAIL testDail = new TestDAIL();
			XmlReader xmlReader = new XmlTextReader(txtXMLFile.Text);
			XSLTransformer transformer = new XSLTransformer(txtXSLFile.Text);
			string strResult;

			while(xmlReader.NodeType != XmlNodeType.Element) 
			{
				xmlReader.Read();
			}

			if(cmbAction.SelectedIndex == 0)
				strResult = testDail.retrieve(xmlReader.ReadOuterXml(),transformer,"TestID","TestAction");
			else
				strResult = testDail.modify(xmlReader.ReadOuterXml(),transformer,"TestID","TestAction");
			txtOutput.Text = strResult;
		}


	}
}
