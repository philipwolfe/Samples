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
using System.Windows.Forms.Design;
using System.IO;
using System.Text;
using System.Data;
using System.Reflection;
using System.ServiceProcess;
using Ironring.Management.MMC;
#endregion

namespace RKiss.RemotingManagement
{
	public class HostProcessForm : System.Windows.Forms.Form
	{
		#region private members
		private System.Windows.Forms.Button buttonAction;
		private System.Windows.Forms.Button buttonCancel;
		private System.ComponentModel.Container components = null;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.TabPage tabPageProcess;
		private System.Windows.Forms.TabPage tabPageConfigFile;
		private System.Windows.Forms.TabControl tabControlHostProcess;
		private System.Windows.Forms.TextBox textBoxPathToExcecutable;
		private System.Windows.Forms.Button buttonAssemblyLocation;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.TextBox textBoxAssemblyName;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.TextBox textBoxAssemblyLocation;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.TextBox textBoxPathToConfigFile;
		private System.Windows.Forms.ComboBox comboBoxProcessRun;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox textBoxProcessName;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox textBoxProcessDescription;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.TextBox textBoxConfigFile;
		private System.Windows.Forms.CheckBox checkBoxAssemblyName;
		//
		string mstrProcessName = null;
		BaseNode mobjContextNode = null;
		#endregion

		#region constructor
		public HostProcessForm(BaseNode parent, string strProcessName)
		{
			try 
			{
				Trace.WriteLine("HostProcessForm constructor start ...");

				InitializeComponent();

				//---default mode
				comboBoxProcessRun.SelectedIndex = 0;

				//---parent node
				mobjContextNode = parent;

				//---path to the config file 
				string strPathToConfigFile = null;

				//---new or exist process
				mstrProcessName = strProcessName;
				if(mstrProcessName == null) 
				{
					//---default names
					string strId = Guid.NewGuid().ToString().Split('-')[0];
					textBoxProcessName.Text = "HostProcess_" + strId;
					textBoxAssemblyName.Text =  "HostProcess_" + strId;

					//---config file template
					strPathToConfigFile = AppDomain.CurrentDomain.SetupInformation.ApplicationBase + "HostProcessTemplate.exe.config";
				}
				else 
				{
					//---read only
					textBoxProcessName.ReadOnly = true;	
					textBoxProcessName.BorderStyle = BorderStyle.None;
					checkBoxAssemblyName.Hide();
					checkBoxAssemblyName.Checked = false;
					textBoxAssemblyName.ReadOnly = true;		
					textBoxAssemblyName.BorderStyle = BorderStyle.None;
					textBoxAssemblyLocation.ReadOnly = true;
					textBoxAssemblyLocation.BorderStyle = BorderStyle.None;
					buttonAssemblyLocation.Hide();
					buttonAction.Text = "APPLY";
					//
					this.buttonAction.Click -= new System.EventHandler(this.buttonCreate_Click);
					this.buttonAction.Click += new System.EventHandler(this.buttonApply_Click);
					//
					textBoxProcessName.Text = mstrProcessName;
					this.Text = mstrProcessName + " (Windows Service)"; 

					//---get the config file
					WinServiceAgent wsa = new WinServiceAgent();
					strPathToConfigFile = wsa.GetPathToExecutable(mstrProcessName) + ".config";

					//--get the process properties
					DataSet procDS = new DataSet("Process");
					string strProcessInnerXml = wsa.GetProcessInnerXml(mstrProcessName);
					if(strProcessInnerXml != null) 
					{	
						//---populate dataset
						procDS.ReadXml(new StringReader("<processes>" + strProcessInnerXml + "</processes>"));
						if(procDS.Tables.Contains("process")) 
						{
							DataRow dr = procDS.Tables["process"].Rows[0]; 
							FileInfo fi = new FileInfo(Convert.ToString(dr["imagepath"]));
							textBoxAssemblyName.Text = fi.Name.Split('.')[0];
							textBoxAssemblyLocation.Text = fi.DirectoryName;
							textBoxProcessDescription.Text = Convert.ToString(dr["description"]);
							comboBoxProcessRun.SelectedIndex = Convert.ToString(dr["start"]) == "Automatic" ? 0 : 1;
						}
					}

					//---hide apply button
					buttonAction.Visible = false;
				}

				//---show contents of the config file
				DataSet cnfgDS = new DataSet("ConfigFile");
				cnfgDS.ReadXml(strPathToConfigFile);
				textBoxConfigFile.Text = cnfgDS.GetXml();
				cnfgDS.Dispose();

				//---read only properties
				string strAssemblyLocation = textBoxAssemblyLocation.Text.Trim('\\');
				textBoxPathToExcecutable.Text = strAssemblyLocation + @"\" + textBoxAssemblyName.Text + ".exe";
				textBoxPathToConfigFile.Text = textBoxPathToExcecutable.Text + ".config";

				Trace.WriteLine("HostProcessForm constructor done");
			}
			catch(Exception ex) 
			{
				Trace.WriteLine("HostProcessForm constructor failed, error= " + ex.Message);
			}
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
			this.buttonAction = new System.Windows.Forms.Button();
			this.buttonCancel = new System.Windows.Forms.Button();
			this.panel1 = new System.Windows.Forms.Panel();
			this.tabControlHostProcess = new System.Windows.Forms.TabControl();
			this.tabPageProcess = new System.Windows.Forms.TabPage();
			this.comboBoxProcessRun = new System.Windows.Forms.ComboBox();
			this.label1 = new System.Windows.Forms.Label();
			this.textBoxProcessName = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.textBoxProcessDescription = new System.Windows.Forms.TextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.textBoxPathToExcecutable = new System.Windows.Forms.TextBox();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.checkBoxAssemblyName = new System.Windows.Forms.CheckBox();
			this.buttonAssemblyLocation = new System.Windows.Forms.Button();
			this.label4 = new System.Windows.Forms.Label();
			this.textBoxAssemblyName = new System.Windows.Forms.TextBox();
			this.label5 = new System.Windows.Forms.Label();
			this.textBoxAssemblyLocation = new System.Windows.Forms.TextBox();
			this.label6 = new System.Windows.Forms.Label();
			this.label7 = new System.Windows.Forms.Label();
			this.textBoxPathToConfigFile = new System.Windows.Forms.TextBox();
			this.tabPageConfigFile = new System.Windows.Forms.TabPage();
			this.textBoxConfigFile = new System.Windows.Forms.TextBox();
			this.panel1.SuspendLayout();
			this.tabControlHostProcess.SuspendLayout();
			this.tabPageProcess.SuspendLayout();
			this.groupBox2.SuspendLayout();
			this.tabPageConfigFile.SuspendLayout();
			this.SuspendLayout();
			// 
			// buttonAction
			// 
			this.buttonAction.Anchor = (System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right);
			this.buttonAction.Location = new System.Drawing.Point(366, 322);
			this.buttonAction.Name = "buttonAction";
			this.buttonAction.TabIndex = 1;
			this.buttonAction.Text = "CREATE";
			this.buttonAction.Click += new System.EventHandler(this.buttonCreate_Click);
			// 
			// buttonCancel
			// 
			this.buttonCancel.Anchor = (System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right);
			this.buttonCancel.Location = new System.Drawing.Point(456, 322);
			this.buttonCancel.Name = "buttonCancel";
			this.buttonCancel.TabIndex = 1;
			this.buttonCancel.Text = "CANCEL";
			this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
			// 
			// panel1
			// 
			this.panel1.Anchor = (System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right);
			this.panel1.Controls.AddRange(new System.Windows.Forms.Control[] {
																																				 this.tabControlHostProcess});
			this.panel1.Location = new System.Drawing.Point(4, 12);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(528, 302);
			this.panel1.TabIndex = 2;
			// 
			// tabControlHostProcess
			// 
			this.tabControlHostProcess.Anchor = (System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right);
			this.tabControlHostProcess.Controls.AddRange(new System.Windows.Forms.Control[] {
																																												this.tabPageProcess,
																																												this.tabPageConfigFile});
			this.tabControlHostProcess.Location = new System.Drawing.Point(2, 2);
			this.tabControlHostProcess.Multiline = true;
			this.tabControlHostProcess.Name = "tabControlHostProcess";
			this.tabControlHostProcess.SelectedIndex = 0;
			this.tabControlHostProcess.Size = new System.Drawing.Size(529, 302);
			this.tabControlHostProcess.TabIndex = 0;
			this.tabControlHostProcess.TextChanged += new System.EventHandler(this.OnTextChanged);
			// 
			// tabPageProcess
			// 
			this.tabPageProcess.AllowDrop = true;
			this.tabPageProcess.Controls.AddRange(new System.Windows.Forms.Control[] {
																																								 this.comboBoxProcessRun,
																																								 this.label1,
																																								 this.textBoxProcessName,
																																								 this.label2,
																																								 this.textBoxProcessDescription,
																																								 this.label3,
																																								 this.textBoxPathToExcecutable,
																																								 this.groupBox2,
																																								 this.label6,
																																								 this.label7,
																																								 this.textBoxPathToConfigFile});
			this.tabPageProcess.Location = new System.Drawing.Point(4, 22);
			this.tabPageProcess.Name = "tabPageProcess";
			this.tabPageProcess.Size = new System.Drawing.Size(521, 276);
			this.tabPageProcess.TabIndex = 0;
			this.tabPageProcess.Text = "Process";
			this.tabPageProcess.DragEnter += new System.Windows.Forms.DragEventHandler(this.tabPageProcess_DragEnter);
			this.tabPageProcess.DragDrop += new System.Windows.Forms.DragEventHandler(this.tabPageProcess_DragDrop);
			// 
			// comboBoxProcessRun
			// 
			this.comboBoxProcessRun.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.comboBoxProcessRun.ItemHeight = 13;
			this.comboBoxProcessRun.Items.AddRange(new object[] {
																														"Automatic",
																														"Manual"});
			this.comboBoxProcessRun.Location = new System.Drawing.Point(82, 66);
			this.comboBoxProcessRun.Name = "comboBoxProcessRun";
			this.comboBoxProcessRun.Size = new System.Drawing.Size(88, 21);
			this.comboBoxProcessRun.TabIndex = 19;
			this.comboBoxProcessRun.TextChanged += new System.EventHandler(this.OnTextChanged);
			this.comboBoxProcessRun.SelectedValueChanged += new System.EventHandler(this.OnTextChanged);
			this.comboBoxProcessRun.SelectedIndexChanged += new System.EventHandler(this.OnTextChanged);
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(10, 18);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(70, 20);
			this.label1.TabIndex = 18;
			this.label1.Text = "Name:";
			// 
			// textBoxProcessName
			// 
			this.textBoxProcessName.Location = new System.Drawing.Point(82, 16);
			this.textBoxProcessName.Name = "textBoxProcessName";
			this.textBoxProcessName.Size = new System.Drawing.Size(308, 20);
			this.textBoxProcessName.TabIndex = 14;
			this.textBoxProcessName.Text = "HostProcess_001";
			this.textBoxProcessName.TextChanged += new System.EventHandler(this.OnTextChanged);
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(10, 44);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(70, 20);
			this.label2.TabIndex = 17;
			this.label2.Text = "Description:";
			// 
			// textBoxProcessDescription
			// 
			this.textBoxProcessDescription.Anchor = (System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right);
			this.textBoxProcessDescription.Location = new System.Drawing.Point(82, 44);
			this.textBoxProcessDescription.Name = "textBoxProcessDescription";
			this.textBoxProcessDescription.Size = new System.Drawing.Size(430, 20);
			this.textBoxProcessDescription.TabIndex = 15;
			this.textBoxProcessDescription.Text = "Remoting Host Process";
			this.textBoxProcessDescription.TextChanged += new System.EventHandler(this.OnTextChanged);
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(10, 68);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(70, 18);
			this.label3.TabIndex = 16;
			this.label3.Text = "Run:";
			// 
			// textBoxPathToExcecutable
			// 
			this.textBoxPathToExcecutable.Anchor = (System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right);
			this.textBoxPathToExcecutable.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.textBoxPathToExcecutable.Location = new System.Drawing.Point(12, 204);
			this.textBoxPathToExcecutable.Name = "textBoxPathToExcecutable";
			this.textBoxPathToExcecutable.ReadOnly = true;
			this.textBoxPathToExcecutable.Size = new System.Drawing.Size(500, 13);
			this.textBoxPathToExcecutable.TabIndex = 10;
			this.textBoxPathToExcecutable.Text = "c:\\Program Files\\RemotingHostProcesses\\HostProcess_001.exe";
			// 
			// groupBox2
			// 
			this.groupBox2.Anchor = (System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right);
			this.groupBox2.Controls.AddRange(new System.Windows.Forms.Control[] {
																																						this.checkBoxAssemblyName,
																																						this.buttonAssemblyLocation,
																																						this.label4,
																																						this.textBoxAssemblyName,
																																						this.label5,
																																						this.textBoxAssemblyLocation});
			this.groupBox2.Location = new System.Drawing.Point(6, 104);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(510, 72);
			this.groupBox2.TabIndex = 11;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "Assembly";
			// 
			// checkBoxAssemblyName
			// 
			this.checkBoxAssemblyName.Anchor = (System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right);
			this.checkBoxAssemblyName.Checked = true;
			this.checkBoxAssemblyName.CheckState = System.Windows.Forms.CheckState.Checked;
			this.checkBoxAssemblyName.Location = new System.Drawing.Point(392, 12);
			this.checkBoxAssemblyName.Name = "checkBoxAssemblyName";
			this.checkBoxAssemblyName.Size = new System.Drawing.Size(110, 26);
			this.checkBoxAssemblyName.TabIndex = 3;
			this.checkBoxAssemblyName.Text = "same as process";
			this.checkBoxAssemblyName.CheckedChanged += new System.EventHandler(this.OnTextChanged);
			// 
			// buttonAssemblyLocation
			// 
			this.buttonAssemblyLocation.Anchor = (System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right);
			this.buttonAssemblyLocation.Location = new System.Drawing.Point(478, 44);
			this.buttonAssemblyLocation.Name = "buttonAssemblyLocation";
			this.buttonAssemblyLocation.Size = new System.Drawing.Size(28, 20);
			this.buttonAssemblyLocation.TabIndex = 2;
			this.buttonAssemblyLocation.Text = "...";
			this.buttonAssemblyLocation.Click += new System.EventHandler(this.buttonAssemblyLocation_Click);
			// 
			// label4
			// 
			this.label4.Location = new System.Drawing.Point(6, 18);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(70, 16);
			this.label4.TabIndex = 1;
			this.label4.Text = "Name:";
			// 
			// textBoxAssemblyName
			// 
			this.textBoxAssemblyName.Location = new System.Drawing.Point(78, 16);
			this.textBoxAssemblyName.Name = "textBoxAssemblyName";
			this.textBoxAssemblyName.Size = new System.Drawing.Size(308, 20);
			this.textBoxAssemblyName.TabIndex = 0;
			this.textBoxAssemblyName.Text = "HostProcess_001";
			this.textBoxAssemblyName.TextChanged += new System.EventHandler(this.OnTextChanged);
			// 
			// label5
			// 
			this.label5.Location = new System.Drawing.Point(6, 44);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(70, 18);
			this.label5.TabIndex = 1;
			this.label5.Text = "Location:";
			// 
			// textBoxAssemblyLocation
			// 
			this.textBoxAssemblyLocation.Anchor = (System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right);
			this.textBoxAssemblyLocation.Location = new System.Drawing.Point(76, 44);
			this.textBoxAssemblyLocation.Name = "textBoxAssemblyLocation";
			this.textBoxAssemblyLocation.Size = new System.Drawing.Size(400, 20);
			this.textBoxAssemblyLocation.TabIndex = 0;
			this.textBoxAssemblyLocation.Text = "c:\\Program Files\\RemotingHostProcesses\\";
			this.textBoxAssemblyLocation.TextChanged += new System.EventHandler(this.OnTextChanged);
			// 
			// label6
			// 
			this.label6.Location = new System.Drawing.Point(10, 186);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(104, 14);
			this.label6.TabIndex = 13;
			this.label6.Text = "Path to executable:";
			// 
			// label7
			// 
			this.label7.Location = new System.Drawing.Point(10, 230);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(104, 14);
			this.label7.TabIndex = 12;
			this.label7.Text = "Path to config file:";
			// 
			// textBoxPathToConfigFile
			// 
			this.textBoxPathToConfigFile.Anchor = (System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right);
			this.textBoxPathToConfigFile.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.textBoxPathToConfigFile.Location = new System.Drawing.Point(12, 248);
			this.textBoxPathToConfigFile.Name = "textBoxPathToConfigFile";
			this.textBoxPathToConfigFile.ReadOnly = true;
			this.textBoxPathToConfigFile.Size = new System.Drawing.Size(500, 13);
			this.textBoxPathToConfigFile.TabIndex = 9;
			this.textBoxPathToConfigFile.Text = "c:\\Program Files\\RemotingHostProcesses\\HostProcess_001.exe.config";
			// 
			// tabPageConfigFile
			// 
			this.tabPageConfigFile.Controls.AddRange(new System.Windows.Forms.Control[] {
																																										this.textBoxConfigFile});
			this.tabPageConfigFile.Location = new System.Drawing.Point(4, 22);
			this.tabPageConfigFile.Name = "tabPageConfigFile";
			this.tabPageConfigFile.Size = new System.Drawing.Size(521, 276);
			this.tabPageConfigFile.TabIndex = 1;
			this.tabPageConfigFile.Text = "ConfigFile";
			// 
			// textBoxConfigFile
			// 
			this.textBoxConfigFile.Dock = System.Windows.Forms.DockStyle.Fill;
			this.textBoxConfigFile.Multiline = true;
			this.textBoxConfigFile.Name = "textBoxConfigFile";
			this.textBoxConfigFile.ReadOnly = true;
			this.textBoxConfigFile.ScrollBars = System.Windows.Forms.ScrollBars.Both;
			this.textBoxConfigFile.Size = new System.Drawing.Size(521, 276);
			this.textBoxConfigFile.TabIndex = 0;
			this.textBoxConfigFile.Text = "";
			this.textBoxConfigFile.WordWrap = false;
			// 
			// HostProcessForm
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(536, 352);
			this.Controls.AddRange(new System.Windows.Forms.Control[] {
																																	this.panel1,
																																	this.buttonAction,
																																	this.buttonCancel});
			this.MaximumSize = new System.Drawing.Size(944, 382);
			this.MinimumSize = new System.Drawing.Size(544, 382);
			this.Name = "HostProcessForm";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "New Host Process (Windows Service)";
			this.panel1.ResumeLayout(false);
			this.tabControlHostProcess.ResumeLayout(false);
			this.tabPageProcess.ResumeLayout(false);
			this.groupBox2.ResumeLayout(false);
			this.tabPageConfigFile.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		#region Buttons
		private void buttonCreate_Click(object sender, System.EventArgs e)
		{
			//---
			FileStream fs = null;

			//---arguments
			string strHostProcessName = textBoxProcessName.Text;
			string strHostProcessDesc = textBoxProcessDescription.Text;
			bool bStartAutomatic = comboBoxProcessRun.Text == "Automatic" ? true : false;
			string strAssemblyLocation = textBoxAssemblyLocation.Text.Trim('\\');
			string strAssemblyPath = strAssemblyLocation + @"\" + textBoxAssemblyName.Text;
			string strPathToExecutable = strAssemblyPath + ".exe";

			//---call agent
			WinServiceAgent wsa = new WinServiceAgent();

			//---check the service name
			if(wsa.Exists(textBoxProcessName.Text)) 
			{
				string strMsg = string.Format("The '{0}' Host Process already exists.\r\nPlease change the name", strHostProcessName);
				MessageBox.Show(strMsg, "New Host Process");
				return;
			}

			//---check the assemly
			FileInfo fi = new FileInfo(strPathToExecutable);
			if(fi.Exists)
			{
				try
				{
					fs = fi.OpenWrite();
				}
				catch(Exception ex) 
				{
					Trace.WriteLine(ex.Message);
					string strMsg = string.Format("The '{0}' Assembly is already used in this location.\r\nPlease change either the name or location.", strAssemblyPath + ".exe");
					MessageBox.Show(strMsg, "New Host Process");
					return;
				}
				finally
				{
					if(fs != null) 
						fs.Close();
				}
			}

			try 
			{ 
				//---check assembly folder
				DirectoryInfo di = new DirectoryInfo(strAssemblyLocation); 
				if(di.Exists == false) 
				{
					di.Create();
				}
					
				//---create service
				wsa.Create(strHostProcessName, strHostProcessDesc, bStartAutomatic, false, strAssemblyPath);

				//---install service
				wsa.Install(strPathToExecutable);

				//---create config file 
				try 
				{
					wsa.CreateHostProcessConfigFile(strPathToExecutable);
				}
				catch(Exception ex) 
				{
					MessageBox.Show(ex.Message, "Host Processes", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				}

				//---done
				mobjContextNode.Tag = strPathToExecutable;
				mobjContextNode.OnUser("CREATE_done", strHostProcessName);
			}
			catch(Exception ex) 
			{
				MessageBox.Show(ex.Message, "Host Processes", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
			finally 
			{
				//---exit
				this.Close();
			}		
		}

		private void buttonApply_Click(object sender, System.EventArgs e)
		{
			try 
			{
				string strHostProcessName = textBoxProcessName.Text;
				string strHostProcessDesc = textBoxProcessDescription.Text;
				ServiceStartMode eStartMode = comboBoxProcessRun.Text == "Automatic" ? ServiceStartMode.Automatic : ServiceStartMode.Manual;

				//---call agent
				WinServiceAgent wsa = new WinServiceAgent();		
				wsa.SetServiceProperties(strHostProcessName, eStartMode, strHostProcessDesc);
			}
			catch(Exception ex) 
			{
				MessageBox.Show(ex.Message, "Host Processes", MessageBoxButtons.OK, MessageBoxIcon.Warning);
			}
			finally 
			{
				//---exit
				this.Close();
			}		
		}

		private void buttonInstall_Click(object sender, System.EventArgs e)
		{
			try 
			{
				//---call agent
				WinServiceAgent wsa = new WinServiceAgent();	
	
				//---state
				string strProcessName = null;
				string strPathToExecutable = textBoxPathToExcecutable.Text;
				string strProcessDesc = textBoxProcessDescription.Text;
				ServiceStartMode eStartMode = comboBoxProcessRun.Text == "Automatic" ? ServiceStartMode.Automatic : ServiceStartMode.Manual;

				FileInfo fi = new FileInfo(strPathToExecutable);

				if(fi.Extension.ToLower() == ".exe") 
				{
					//---check if service is already inastalled
					strProcessName = wsa.GetServiceName(strPathToExecutable); 
					if(strProcessName != null) 
					{
						throw new Exception(string.Format("The process {0} is already installed.\r\nFile = {1}", strProcessName, strPathToExecutable));
					}

					try 
					{
						//---install service
						wsa.Install(strPathToExecutable);

						//---give me its service name
						strProcessName = wsa.GetServiceName(strPathToExecutable); 
			
						//---update the process properties
						wsa.SetServiceProperties(strProcessName, eStartMode, strProcessDesc);

						if(strProcessName != null) 
						{
							//---wakeup your handler to insert the new process node
							mobjContextNode.Tag = strPathToExecutable;
							mobjContextNode.OnUser("INSTALL_done", strProcessName);							
						}
						else 
						{
							string strErrMsg = string.Format("The file {0}\r\nis not a service process, missing a service installer class.", strPathToExecutable);
							throw new Exception(strErrMsg);
						}

						//---show the process name
						textBoxProcessName.Text = strProcessName;
					}
					catch(Exception ex) 
					{
						//---this is a seriously error, uninstall service
						wsa.Uninstall(strPathToExecutable);
						throw ex;
					}

					try 
					{
						//---make the config file
						wsa.CreateHostProcessConfigFile(strPathToExecutable);
					}
					catch(Exception ex) 
					{
						//---this is only warning
						MessageBox.Show(ex.Message, "Host Processes", MessageBoxButtons.OK, MessageBoxIcon.Warning);
					}

					//---readonly properties
					textBoxProcessDescription.ReadOnly = true;
					comboBoxProcessRun.Enabled = false;
					buttonAction.Visible = false;

					//---now we have only one choice - exit
					this.Focus();
					buttonCancel.Text = "EXIT";
				}
				else 
				{
					throw new Exception(string.Format("This file {0}\r\nis not a host process", strPathToExecutable));
				}
			}
			catch(Exception ex) 
			{
				MessageBox.Show(ex.Message, "Host Processes", MessageBoxButtons.OK, MessageBoxIcon.Error);	
				
				//---exit
				this.Close();
			}	
		}

		private void buttonCancel_Click(object sender, System.EventArgs e)
		{
			//---exit
			this.Close();
		}

		private void buttonAssemblyLocation_Click(object sender, System.EventArgs e)
		{
			DirBrowser dirbrowser = new DirBrowser();
			dirbrowser.Description = "Assembly location for host process.";
			dirbrowser.ShowDialog();
			textBoxAssemblyLocation.Text = dirbrowser.ReturnPath;
		}
		#endregion

		#region Events
		private void OnTextChanged(object sender, System.EventArgs e)
		{
			if(checkBoxAssemblyName.Checked == true) 
				textBoxAssemblyName.Text = textBoxProcessName.Text;
			string strAssemblyLocation = textBoxAssemblyLocation.Text.Trim('\\');
			textBoxPathToExcecutable.Text = strAssemblyLocation + @"\" + textBoxAssemblyName.Text + ".exe";
			textBoxPathToConfigFile.Text = textBoxPathToExcecutable.Text + ".config";
			//
			buttonAction.Visible = true;
		}

		private void tabPageProcess_DragEnter(object sender, System.Windows.Forms.DragEventArgs e)
		{
			if(e.Data.GetDataPresent(DataFormats.FileDrop))
			{
				if(e.Data.GetDataPresent(DataFormats.FileDrop))
				{
					string[] strFiles=(string[])e.Data.GetData(DataFormats.FileDrop);
					FileInfo fi = new FileInfo(strFiles[0]);
					if(fi.Extension == ".exe" && strFiles.Length == 1)
						e.Effect=DragDropEffects.Copy|DragDropEffects.Scroll;
					else
						e.Effect=DragDropEffects.None;
				}
			}
		}

		private void tabPageProcess_DragDrop(object sender, System.Windows.Forms.DragEventArgs e)
		{
			if(e.Data.GetDataPresent(DataFormats.FileDrop) == true) 
			{
				string[] strFiles=(string[])e.Data.GetData(DataFormats.FileDrop);
				Trace.WriteLine(strFiles[0]);

				//---insert new host process based on this assembly		
				PopulatePropertiesToInstallHostProcess(strFiles[0]);
				}	
		}
		#endregion

		#region Helpers
		private void PopulatePropertiesToInstallHostProcess(string strPathToExecutable)
		{
			try 
			{
				string strProcessName = null;
				FileInfo fi = new FileInfo(strPathToExecutable);

				//---call agent to do it
				WinServiceAgent wsa = new WinServiceAgent();
			
				//---check if service is already inastalled
				strProcessName = wsa.GetServiceName(strPathToExecutable); 
				if(strProcessName != null) 
				{
					throw new Exception(string.Format("The process {0} is already installed.\r\nFile = {1}", strProcessName, strPathToExecutable));
				}

				//---change action
				checkBoxAssemblyName.Hide();
				checkBoxAssemblyName.Checked = false;
				buttonAssemblyLocation.Hide();
				buttonAction.Text = "INSTALL";
				this.buttonAction.Click -= new System.EventHandler(this.buttonCreate_Click);
				this.buttonAction.Click += new System.EventHandler(this.buttonInstall_Click);
				
				//---populate properties
				textBoxProcessName.Text = "unknown";
				textBoxAssemblyName.Text = fi.Name.Split('.')[0];
				textBoxAssemblyLocation.Text = fi.DirectoryName;
			
				//---readonly properties
				textBoxAssemblyName.ReadOnly = true;
				textBoxProcessName.ReadOnly = true;
				textBoxAssemblyLocation.ReadOnly = true;
				OnTextChanged(null, null);
			}
			catch(Exception ex) 
			{
				MessageBox.Show(ex.Message, "Host Processes", MessageBoxButtons.OK, MessageBoxIcon.Warning);
			}		
		}
		#endregion
	}
	
	#region 3rd party
	//---Note: original created by Ryan Farley on the microsoft.public.dotnet.language.csharp newsgroup
	public class DirBrowser : FolderNameEditor 
	{ 
		private string mDescription = "Choose Directory"; 
		private string mReturnPath = string.Empty; 
		FolderBrowser fb = new FolderBrowser(); 

		public string Description { set { mDescription = value; }	get { return mDescription; } } 
		public string ReturnPath 	{ get { return mReturnPath; }	} 
		public DirBrowser() { } 
 
		public DialogResult ShowDialog()  
		{ 
			fb.Description = mDescription; 
			fb.StartLocation = FolderBrowserFolder.MyComputer; 
 
			DialogResult dr = fb.ShowDialog(); 
 
			if (dr == DialogResult.OK)  
				mReturnPath = fb.DirectoryPath;  
			else 
				mReturnPath = String.Empty; 
 
			return dr; 
		} 
	}
	#endregion

}
