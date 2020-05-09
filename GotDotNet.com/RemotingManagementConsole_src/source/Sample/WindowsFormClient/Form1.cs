using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Text;
using System.IO;
using System.Xml;

namespace RemotingManagementSample
{
	/// <summary>
	/// Summary description for Form1.
	/// </summary>
	public class Form1 : System.Windows.Forms.Form
	{
		private System.Windows.Forms.OpenFileDialog openFileDialogConfigFile;
		private System.Windows.Forms.Button buttonEcho;
		private System.Windows.Forms.Button buttonBrowseFile;
		private System.Windows.Forms.Button buttonOuterXml;
		private System.Windows.Forms.ComboBox comboBoxPathToConfigFile;
		private System.Windows.Forms.ComboBox comboBoxXPath;
		private System.Windows.Forms.ComboBox comboBoxObjectUri;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox textBoxOuterXml;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Panel panel;
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

			textBoxOuterXml.SelectionStart = textBoxOuterXml.Text.Length;
			textBoxOuterXml.ScrollToCaret();

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
			this.openFileDialogConfigFile = new System.Windows.Forms.OpenFileDialog();
			this.buttonEcho = new System.Windows.Forms.Button();
			this.buttonBrowseFile = new System.Windows.Forms.Button();
			this.buttonOuterXml = new System.Windows.Forms.Button();
			this.comboBoxPathToConfigFile = new System.Windows.Forms.ComboBox();
			this.comboBoxXPath = new System.Windows.Forms.ComboBox();
			this.comboBoxObjectUri = new System.Windows.Forms.ComboBox();
			this.label1 = new System.Windows.Forms.Label();
			this.textBoxOuterXml = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.panel = new System.Windows.Forms.Panel();
			this.panel.SuspendLayout();
			this.SuspendLayout();
			// 
			// openFileDialogConfigFile
			// 
			this.openFileDialogConfigFile.DefaultExt = "exe.config";
			this.openFileDialogConfigFile.FileName = "HostProcess_Sample.exe.config";
			this.openFileDialogConfigFile.Filter = "*.exe.config|*.exe.config";
			this.openFileDialogConfigFile.InitialDirectory = "\"\"";
			this.openFileDialogConfigFile.Title = "Configuration File";
			// 
			// buttonEcho
			// 
			this.buttonEcho.Anchor = (System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left);
			this.buttonEcho.Location = new System.Drawing.Point(8, 272);
			this.buttonEcho.Name = "buttonEcho";
			this.buttonEcho.TabIndex = 5;
			this.buttonEcho.Text = "Echo";
			this.buttonEcho.Click += new System.EventHandler(this.buttonEcho_Click);
			// 
			// buttonBrowseFile
			// 
			this.buttonBrowseFile.Anchor = (System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right);
			this.buttonBrowseFile.Location = new System.Drawing.Point(424, 218);
			this.buttonBrowseFile.Name = "buttonBrowseFile";
			this.buttonBrowseFile.Size = new System.Drawing.Size(24, 16);
			this.buttonBrowseFile.TabIndex = 4;
			this.buttonBrowseFile.Text = "...";
			this.buttonBrowseFile.Click += new System.EventHandler(this.buttonBrowseFile_Click);
			// 
			// buttonOuterXml
			// 
			this.buttonOuterXml.Anchor = (System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right);
			this.buttonOuterXml.Location = new System.Drawing.Point(370, 270);
			this.buttonOuterXml.Name = "buttonOuterXml";
			this.buttonOuterXml.Size = new System.Drawing.Size(78, 23);
			this.buttonOuterXml.TabIndex = 3;
			this.buttonOuterXml.Text = "GetOuterXml";
			this.buttonOuterXml.Click += new System.EventHandler(this.buttonOuterXml_Click);
			// 
			// comboBoxPathToConfigFile
			// 
			this.comboBoxPathToConfigFile.Anchor = ((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right);
			this.comboBoxPathToConfigFile.ItemHeight = 13;
			this.comboBoxPathToConfigFile.Location = new System.Drawing.Point(68, 216);
			this.comboBoxPathToConfigFile.Name = "comboBoxPathToConfigFile";
			this.comboBoxPathToConfigFile.Size = new System.Drawing.Size(354, 21);
			this.comboBoxPathToConfigFile.TabIndex = 2;
			this.comboBoxPathToConfigFile.Text = "HostProcess_Sample.exe.config";
			// 
			// comboBoxXPath
			// 
			this.comboBoxXPath.Anchor = ((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right);
			this.comboBoxXPath.ItemHeight = 13;
			this.comboBoxXPath.Items.AddRange(new object[] {
																											 "/configuration",
																											 "/configuration/appSettings",
																											 "/configuration/system.runtime.remoting/application/service",
																											 "/configuration/system.runtime.remoting/application/channels",
																											 "/configuration/system.runtime.remoting/application/channels/channel/serverProvide" +
																											 "rs",
																											 "/configuration/system.runtime.remoting/application/channels/channel/clientProvide" +
																											 "rs",
																											 "/configuration/system.runtime.remoting/channels",
																											 "/configuration/system.runtime.remoting/channelSinkProviders",
																											 "/configuration/system.runtime.remoting/application/lifetime"});
			this.comboBoxXPath.Location = new System.Drawing.Point(68, 242);
			this.comboBoxXPath.Name = "comboBoxXPath";
			this.comboBoxXPath.Size = new System.Drawing.Size(380, 21);
			this.comboBoxXPath.TabIndex = 2;
			this.comboBoxXPath.Text = "/configuration";
			// 
			// comboBoxObjectUri
			// 
			this.comboBoxObjectUri.Anchor = ((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right);
			this.comboBoxObjectUri.ItemHeight = 13;
			this.comboBoxObjectUri.Items.AddRange(new object[] {
																													 "tcp://localhost:8989/sample"});
			this.comboBoxObjectUri.Location = new System.Drawing.Point(68, 192);
			this.comboBoxObjectUri.Name = "comboBoxObjectUri";
			this.comboBoxObjectUri.Size = new System.Drawing.Size(380, 21);
			this.comboBoxObjectUri.TabIndex = 2;
			this.comboBoxObjectUri.Text = "tcp://localhost:8989/sample";
			// 
			// label1
			// 
			this.label1.Anchor = (System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left);
			this.label1.Location = new System.Drawing.Point(8, 192);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(58, 22);
			this.label1.TabIndex = 1;
			this.label1.Text = "objectUri:";
			// 
			// textBoxOuterXml
			// 
			this.textBoxOuterXml.Anchor = (((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right);
			this.textBoxOuterXml.BackColor = System.Drawing.Color.Black;
			this.textBoxOuterXml.ForeColor = System.Drawing.Color.White;
			this.textBoxOuterXml.Location = new System.Drawing.Point(4, 6);
			this.textBoxOuterXml.Multiline = true;
			this.textBoxOuterXml.Name = "textBoxOuterXml";
			this.textBoxOuterXml.ScrollBars = System.Windows.Forms.ScrollBars.Both;
			this.textBoxOuterXml.Size = new System.Drawing.Size(442, 178);
			this.textBoxOuterXml.TabIndex = 0;
			this.textBoxOuterXml.Text = @"Instructions:

1. Use the Remoting Management Console to create a host process (for instance: HostProcess_Sample) to publish the remoting object.
2. Drag&Drop the RemotingObjectSample.dll  to the console - RemoteObjects result view panel.
3. Insert the endpoint name, for instance: sample
4. Click Apply
5. Create new Channel Tcp
6. Insert port number, for instance: 8989
7. Click Apply
8. Start the host process
9. Press button Echo to verify the above steps
10. Select the path of the config file using the brovser button. This path has to be the same where host process has been created.
11. Press button GetOuterXml
12. Evaluate the config file using the properly xpath text.



";
			this.textBoxOuterXml.WordWrap = false;
			// 
			// label2
			// 
			this.label2.Anchor = (System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left);
			this.label2.Location = new System.Drawing.Point(8, 216);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(58, 22);
			this.label2.TabIndex = 1;
			this.label2.Text = "config file:";
			// 
			// label3
			// 
			this.label3.Anchor = (System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left);
			this.label3.Location = new System.Drawing.Point(8, 242);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(56, 22);
			this.label3.TabIndex = 1;
			this.label3.Text = "xpath:";
			// 
			// panel
			// 
			this.panel.Anchor = (((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right);
			this.panel.Controls.AddRange(new System.Windows.Forms.Control[] {
																																				this.buttonEcho,
																																				this.buttonBrowseFile,
																																				this.buttonOuterXml,
																																				this.comboBoxPathToConfigFile,
																																				this.comboBoxXPath,
																																				this.comboBoxObjectUri,
																																				this.label1,
																																				this.textBoxOuterXml,
																																				this.label2,
																																				this.label3});
			this.panel.Name = "panel";
			this.panel.Size = new System.Drawing.Size(452, 296);
			this.panel.TabIndex = 0;
			// 
			// Form1
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(452, 296);
			this.Controls.AddRange(new System.Windows.Forms.Control[] {
																																	this.panel});
			this.HelpButton = true;
			this.MinimumSize = new System.Drawing.Size(460, 326);
			this.Name = "Form1";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Remoting Management Test Client";
			this.HelpRequested += new System.Windows.Forms.HelpEventHandler(this.Form1_HelpRequested);
			this.panel.ResumeLayout(false);
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

		private void buttonOuterXml_Click(object sender, System.EventArgs e)
		{
			try 
			{
				Type typeInterfaceType = typeof(InterfaceSample);
				string objectUri = comboBoxObjectUri.Text;

				InterfaceSample robj = (InterfaceSample)Activator.GetObject(typeInterfaceType, objectUri);
				string strOuterXml = robj.GetOuterXml(comboBoxXPath.Text, comboBoxPathToConfigFile.Text);

				textBoxOuterXml.Text += "\r\n" + OutputXmlLayout(strOuterXml); 
			}
			catch(Exception ex) 
			{
				textBoxOuterXml.Text += "\r\n" + ex.Message;
			}	

			textBoxOuterXml.SelectionStart = textBoxOuterXml.Text.Length;
			textBoxOuterXml.ScrollToCaret();
		}

		private void buttonBrowseFile_Click(object sender, System.EventArgs e)
		{
			openFileDialogConfigFile.ShowDialog();
			comboBoxPathToConfigFile.Text = openFileDialogConfigFile.FileName;		
		}

		private void buttonEcho_Click(object sender, System.EventArgs e)
		{
			try 
			{
				Type typeInterfaceType = typeof(InterfaceSample);
				string objectUri = comboBoxObjectUri.Text;

				InterfaceSample robj = (InterfaceSample)Activator.GetObject(typeInterfaceType, objectUri);
				textBoxOuterXml.Text += "\r\n" + robj.Echo(comboBoxXPath.Text);
			}
			catch(Exception ex) 
			{
				textBoxOuterXml.Text += "\r\n" + ex.Message ;
			}		

			textBoxOuterXml.SelectionStart = textBoxOuterXml.Text.Length;
			textBoxOuterXml.ScrollToCaret();
		}

		//---helper
		public string OutputXmlLayout(string strSource) 
		{
			string strOutputXmlLayout = null;
			StringWriter sw = null;
			XmlTextWriter tw = null;

			try 
			{
				//---prepare formatter
				StringBuilder sb = new  StringBuilder();
				sw = new StringWriter(sb);
				tw = new XmlTextWriter(sw);
				tw.Indentation = 3;
				tw.Formatting = Formatting.Indented;

				//---load xml formatted text from source such as file or string
				XmlDocument doc = new XmlDocument();

				//---string
				doc.LoadXml(strSource);

				//---save to the writer
				doc.Save(tw);
				tw.Flush();
				strOutputXmlLayout = sb.ToString();

				//---manualy removeing a xml declaration
				strOutputXmlLayout = strOutputXmlLayout.Remove(0, strOutputXmlLayout.IndexOf("?>", 0) + 2);

			}
			catch(Exception ex) 
			{
			}
			finally 
			{ 
				//---cleanup
				if(tw != null)
					tw.Close();
				if(sw != null)
					sw.Close();
			}
		
			return strOutputXmlLayout;
		}

		private void Form1_HelpRequested(object sender, System.Windows.Forms.HelpEventArgs hlpevent)
		{
		
		}
	}
}
