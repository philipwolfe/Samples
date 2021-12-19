using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Data.OleDb;
using System.Xml;

namespace WinFormsXML
{
	/// <summary>
	/// Summary description for Form1.
	/// </summary>
	public class Form1 : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Button cmdXMLDocumentLoad;
		private System.Windows.Forms.TextBox txtTextBox;
		private System.Windows.Forms.Button cmdXSLTransform;
		private System.Windows.Forms.Button cmdXMLTextReaderURL;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components;

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
			base.Dispose();
			if(components != null)
				components.Dispose();
		}

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.cmdXMLDocumentLoad = new System.Windows.Forms.Button();
			this.txtTextBox = new System.Windows.Forms.TextBox();
			this.cmdXSLTransform = new System.Windows.Forms.Button();
			this.cmdXMLTextReaderURL = new System.Windows.Forms.Button();
			this.cmdXMLDocumentLoad.Location = new System.Drawing.Point(192, 48);
			this.cmdXMLDocumentLoad.Size = new System.Drawing.Size(152, 23);
			this.cmdXMLDocumentLoad.TabIndex = 5;
			this.cmdXMLDocumentLoad.Text = "XMLDocumentLoad";
			this.cmdXMLDocumentLoad.Click += new System.EventHandler(this.cmdXMLDocumentLoad_Click);
			this.txtTextBox.Location = new System.Drawing.Point(24, 88);
			this.txtTextBox.Multiline = true;
			this.txtTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Both;
			this.txtTextBox.Size = new System.Drawing.Size(664, 392);
			this.txtTextBox.TabIndex = 3;
			this.txtTextBox.Text = "";
			this.cmdXSLTransform.Location = new System.Drawing.Point(376, 48);
			this.cmdXSLTransform.Size = new System.Drawing.Size(152, 23);
			this.cmdXSLTransform.TabIndex = 6;
			this.cmdXSLTransform.Text = "Transform XML using XSLT";
			this.cmdXSLTransform.Click += new System.EventHandler(this.cmdXSLTransform_Click);
			this.cmdXMLTextReaderURL.Location = new System.Drawing.Point(24, 48);
			this.cmdXMLTextReaderURL.Size = new System.Drawing.Size(144, 23);
			this.cmdXMLTextReaderURL.TabIndex = 0;
			this.cmdXMLTextReaderURL.Text = "XMLTextReaderURL";
			this.cmdXMLTextReaderURL.Click += new System.EventHandler(this.cmdXMLTextReaderURL_Click);
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(707, 485);
			this.Controls.AddRange(new System.Windows.Forms.Control[] {this.cmdXMLDocumentLoad,
																		  this.txtTextBox,
																		  this.cmdXSLTransform,
																		  this.cmdXMLTextReaderURL});
			this.Text = "WinFormsXML";

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

		private void cmdXMLTextReaderURL_Click(object sender, System.EventArgs e)
		{
			
			try
			{
				System.Xml.XmlTextReader xmlTextReader;
				string tab="";

				this.txtTextBox.Text = "";

				//Point the XMLTextReader at the shirts.xml file in the bin directory
				xmlTextReader = new System.Xml.XmlTextReader(Application.StartupPath + "\\shirts.xml");
				//While the TextReader Reads the stream we will test the node type  
				while (xmlTextReader.Read())
				{

					switch(xmlTextReader.NodeType)
					{
						case System.Xml.XmlNodeType.Element:
							if (xmlTextReader.Depth.ToString() == "1")
							{
								tab = "\t";
							}
							else if (xmlTextReader.Depth.ToString() == "2")
							{
								tab = "\t\t";
							}
							else if (xmlTextReader.Depth.ToString() == "3") 
							{
								tab = "\t\t\t";
							}
							else if (xmlTextReader.Depth.ToString() == "4")
							{
								tab = "\t\t\t\t";
							}
							else
							{
								tab = "";
							}
							//Display The Element name
							this.txtTextBox.Text += tab + "Element: " + xmlTextReader.Name.ToString() + "\r\n" ;
							break;
							//If its text then it's the value of the element and we display it as such
						case System.Xml.XmlNodeType.Text:
							this.txtTextBox.Text += tab + "\t" + "Value: " + xmlTextReader.Value.ToString() + "\r\n";
							break;	
					}
				}
			}
			catch(System.Exception err)
			{
				MessageBox.Show(err.Message.ToString(),"Error");
			}
			}

		private void cmdXMLDocumentLoad_Click(object sender, System.EventArgs e)
		{
			System.Xml.XmlDocument xmlDocument;
			System.Xml.XmlNode xmlRootNode;
			
			//Clear TextBox
			this.txtTextBox.Text = "";

			xmlDocument = new System.Xml.XmlDocument();

			//Load shirts.xml, found in the bin folder into a XmlDocument
			xmlDocument.Load(Application.StartupPath + "\\shirts.xml");
			//Load the Document Element
			xmlRootNode = xmlDocument.DocumentElement;

			this.txtTextBox.Text = xmlRootNode.InnerXml;
		}

		private void cmdXSLTransform_Click(object sender, System.EventArgs e)
		{

			System.Xml.XmlDocument document = new System.Xml.XmlDocument(); 
			System.Xml.Xsl.XslTransform xslTransform;
			System.Xml.XPath.XPathNavigator navigator;
			System.Xml.XmlReader xmlReader; 
			System.Xml.Xsl.XsltArgumentList xslNSParams;
			System.Xml.XmlTextWriter xmlTextWriter;
			System.Text.Encoding stringEncoding = System.Text.Encoding.Default;  
			//NSParamList
			
			//Load shirts.xml, found in the bin folder into a XmlDocument
			document.Load(Application.StartupPath.ToString() + "\\shirts.xml");

			//Load the XmlDocument into a DocumentNavigator
			navigator = ((System.Xml.XPath.IXPathNavigable)(document)).CreateNavigator();

			//Create a new instance of an XSLTransform
			xslTransform = new System.Xml.Xsl.XslTransform();

			//Load the xslt document found in the bin folder into the Transform Object
			xslTransform.Load(Application.StartupPath + "\\shirts.xslt");

			//Create a new instance of Name Space Parameters object
			xslNSParams = new System.Xml.Xsl.XsltArgumentList();

			//Transform XmlDocument in Navigator using xslt document
			//Output to an XmlReader
			xmlReader = xslTransform.Transform(navigator, xslNSParams);

			//Create a new instance of a XMLTextWriter with a .html file in the bin directory
			//Once you run the form once and close the debugger you can view the html file in
			//the bin directory
			xmlTextWriter = new System.Xml.XmlTextWriter(Application.StartupPath + "\\shirts.html", stringEncoding);

			//Transform XmlDocument in Navigator using xslt document
			//Output new html file to bin directory using the objXmlTextWriter
			xslTransform.Transform(navigator, xslNSParams, xmlTextWriter);

			xmlTextWriter.Close();

			//Start a process of IE to display results
			System.Diagnostics.Process.Start("iexplore.exe", Application.StartupPath.ToString() + "\\shirts.html");


			
		}
	}
}
