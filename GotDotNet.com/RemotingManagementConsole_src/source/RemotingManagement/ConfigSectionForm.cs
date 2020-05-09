//=============================================================================
//	The Remoting Management Console.
//	(C) Copyright 2003, Roman Kiss (rkiss@pathcom.com)
//	All rights reserved.
//	The code and information is provided "as-is" without waranty of any kind,
//	either expresed or implied.
//
//  Note:	
//	This software using the 3rd party library for MMC (www.ironringsoftware.com)
//-----------------------------------------------------------------------------
//	History:
//		03/31/2003	Roman Kiss				Initial Revision
//=============================================================================
//

#region references
using System;
using System.Drawing;
using System.Diagnostics;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using Ironring.Management.MMC;
using System.Text;
using System.Xml;
using System.IO;
#endregion

namespace RKiss.RemotingManagement
{
	public class ConfigSectionForm : System.Windows.Forms.Form
	{
		#region private members
		private System.Windows.Forms.Panel panel1;
		private System.ComponentModel.Container components = null;
		private System.Windows.Forms.Label labelName;
		private System.Windows.Forms.Button buttonCancel;
		private System.Windows.Forms.ComboBox comboBoxName;
		private System.Windows.Forms.Button buttonAction;
		//
		private BaseNode mobjContextNode = null;
		private string mstrTargetConfigFile = null;
		#endregion
		
		#region constructor
		public ConfigSectionForm(BaseNode node)
		{
			InitializeComponent();

			mobjContextNode = node;
			mstrTargetConfigFile = Convert.ToString(mobjContextNode.Tag) + ".config";

			//---collect public and private configSections
			ArrayList objAL = new ArrayList();
			ScannMachineConfigSections(ref objAL);
			ScannExceConfigSections(ref objAL); 

			//---insert them into the comboBox;
			foreach(string s in objAL) 
				comboBoxName.Items.Add(s);
		}
		#endregion

		#region Clean up any resources being used.
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
	#endregion

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.panel1 = new System.Windows.Forms.Panel();
			this.buttonCancel = new System.Windows.Forms.Button();
			this.buttonAction = new System.Windows.Forms.Button();
			this.labelName = new System.Windows.Forms.Label();
			this.comboBoxName = new System.Windows.Forms.ComboBox();
			this.panel1.SuspendLayout();
			this.SuspendLayout();
			// 
			// panel1
			// 
			this.panel1.Controls.AddRange(new System.Windows.Forms.Control[] {
																																				 this.buttonCancel,
																																				 this.buttonAction,
																																				 this.labelName,
																																				 this.comboBoxName});
			this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(342, 110);
			this.panel1.TabIndex = 0;
			// 
			// buttonCancel
			// 
			this.buttonCancel.Anchor = (System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right);
			this.buttonCancel.Location = new System.Drawing.Point(262, 82);
			this.buttonCancel.Name = "buttonCancel";
			this.buttonCancel.TabIndex = 17;
			this.buttonCancel.Text = "CANCEL";
			this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
			// 
			// buttonAction
			// 
			this.buttonAction.Anchor = (System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right);
			this.buttonAction.Location = new System.Drawing.Point(180, 82);
			this.buttonAction.Name = "buttonAction";
			this.buttonAction.TabIndex = 16;
			this.buttonAction.Text = "APPLY";
			this.buttonAction.Visible = false;
			this.buttonAction.Click += new System.EventHandler(this.buttonAction_Click);
			// 
			// labelName
			// 
			this.labelName.Location = new System.Drawing.Point(6, 12);
			this.labelName.Name = "labelName";
			this.labelName.Size = new System.Drawing.Size(126, 23);
			this.labelName.TabIndex = 2;
			this.labelName.Text = "Group/Section name:";
			// 
			// comboBoxName
			// 
			this.comboBoxName.Anchor = ((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right);
			this.comboBoxName.Location = new System.Drawing.Point(8, 38);
			this.comboBoxName.Name = "comboBoxName";
			this.comboBoxName.Size = new System.Drawing.Size(328, 21);
			this.comboBoxName.TabIndex = 1;
			this.comboBoxName.TextChanged += new System.EventHandler(this.comboBoxName_TextChanged);
			this.comboBoxName.SelectedIndexChanged += new System.EventHandler(this.comboBoxName_SelectedIndexChanged);
			// 
			// ConfigSectionForm
			// 
			this.AllowDrop = true;
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(342, 110);
			this.Controls.AddRange(new System.Windows.Forms.Control[] {
																																	this.panel1});
			this.MaximumSize = new System.Drawing.Size(700, 140);
			this.MinimumSize = new System.Drawing.Size(350, 140);
			this.Name = "ConfigSectionForm";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "New config section";
			this.TopMost = true;
			this.panel1.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		#region Machine config file
		private void ScannMachineConfigSections(ref ArrayList objAL) 
		{
			try 
			{
				//---get section outerxml 
				ConfigFileAgent cfa = new ConfigFileAgent();
				string strMachineConfigFile = cfa.GetPathToMachineConfigFile();
				string strSectionOuterXml = cfa.GetRemotingConfigSection("configSections", strMachineConfigFile);

				if(strSectionOuterXml != null) 
				{
					XmlDocument doc = new XmlDocument();
					doc.Load(new StringReader(strSectionOuterXml));
	
					foreach(XmlNode n in doc.FirstChild) 
					{
						if(n.Name == "section" || n.Name == "sectionGroup")
						{
							string name = n.Attributes["name"].Value;
							if(name != "system.runtime.remoting" && 
								 name != "appSettings" && 
								 name != "system.net" && 
								 name != "system.windows.forms" &&
								 name != "system.web")  
								objAL.Add(name);
						}						
					}
				}
			}
			catch(Exception ex) 
			{
				Trace.WriteLine(string.Format("ScannMachineConfigSections failed: {0}", ex.Message));
			}
		}
		#endregion

		#region exec config file
		private void ScannExceConfigSections(ref ArrayList objAL) 
		{
			try 
			{
				//---get section outerxml 
				ConfigFileAgent cfa = new ConfigFileAgent();
				string strSectionOuterXml = cfa.GetRemotingConfigSection("configSections", mstrTargetConfigFile);

				if(strSectionOuterXml != null) 
				{
					XmlDocument doc = new XmlDocument();
					doc.Load(new StringReader(strSectionOuterXml));

					foreach(XmlNode n in doc.FirstChild) 
					{
						if(n.Name == "section" || n.Name == "sectionGroup")
						{
							string name = n.Attributes["name"].Value;
							objAL.Add(name);
						}						
					}
				}
			}
			catch(Exception ex) 
			{
				Trace.WriteLine(string.Format("ScannExceConfigSections failed: {0}", ex.Message));
			}
		}
		#endregion
	
		#region buttons
		private void comboBoxName_SelectedIndexChanged(object sender, System.EventArgs e)
		{	
			buttonAction.Visible = true;
		}

		private void buttonAction_Click(object sender, System.EventArgs e)
		{
			try
			{
				//---section/group name
				string strSectionName = comboBoxName.Text;

				//---call aggent for help
				ConfigFileAgent cfa = new ConfigFileAgent();

				//---check section in the config file
				if(cfa.IsExist("/configuration/" + strSectionName, mstrTargetConfigFile)) 
				{
					throw new Exception(string.Format("The section/group {0} already exist in the config file", comboBoxName.Text));
				}
				else 
				{
					//---create section in the config file
					cfa.CreateOuterName("/configuration", strSectionName, mstrTargetConfigFile); 
				}

				//---done, notify snapin
				mobjContextNode.OnUser("APPLY_done", strSectionName);
	
				//---exist
				this.Close();
			}
			catch(Exception ex)
			{
				MessageBox.Show(ex.Message, mobjContextNode.DisplayName, MessageBoxButtons.OK, MessageBoxIcon.Error);

				//---try again
				buttonAction.Visible = false;
			}	
		}

		private void buttonCancel_Click(object sender, System.EventArgs e)
		{
			//---exit
			this.Close();
		}

		private void comboBoxName_TextChanged(object sender, System.EventArgs e)
		{
			buttonAction.Visible = true;
		}
		#endregion
	}
}
