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
	public class LifetimeForm : System.Windows.Forms.Form
	{
		#region private members
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Label labelLeaseTime;
		private System.Windows.Forms.Label labelRenewOnCallTime;
		private System.Windows.Forms.Button buttonCancel;
		private System.Windows.Forms.ComboBox comboBoxLeaseTime;
		private System.Windows.Forms.ComboBox comboBoxSponsorshipTimeOut;
		private System.Windows.Forms.ComboBox comboBoxLeaseManagerPollTime;
		private System.Windows.Forms.ComboBox comboBoxRenewOnCallTime;
		private System.Windows.Forms.Label labelLeaseManagerPollTime;
		private System.ComponentModel.Container components = null;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox textBoxFinallyElement;
		private System.Windows.Forms.Button buttonApply;	
		//
		private BaseNode mobjContextNode = null;
		private System.Windows.Forms.Button buttonUndo;		
		private string mstrTargetConfigFile = null;
		private System.Windows.Forms.Button buttonDefault;
		private string mstrLifetimeOuterXml = null;
		#endregion

		#region constructor
		public LifetimeForm(BaseNode parent, object strRemotingObject, string strTargetConfigFile)
		{
			InitializeComponent();

			mobjContextNode = parent;
			mstrTargetConfigFile = strTargetConfigFile;

			//---retrieve the lifetime elemnet from the config file
			mstrLifetimeOuterXml = GetLifetimeOuterXml();

			//---state
			buttonApply.Visible = false;
			buttonUndo.Visible = false;
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
			this.textBoxFinallyElement = new System.Windows.Forms.TextBox();
			this.comboBoxLeaseTime = new System.Windows.Forms.ComboBox();
			this.labelLeaseTime = new System.Windows.Forms.Label();
			this.comboBoxSponsorshipTimeOut = new System.Windows.Forms.ComboBox();
			this.labelRenewOnCallTime = new System.Windows.Forms.Label();
			this.comboBoxLeaseManagerPollTime = new System.Windows.Forms.ComboBox();
			this.labelLeaseManagerPollTime = new System.Windows.Forms.Label();
			this.buttonApply = new System.Windows.Forms.Button();
			this.buttonCancel = new System.Windows.Forms.Button();
			this.label1 = new System.Windows.Forms.Label();
			this.comboBoxRenewOnCallTime = new System.Windows.Forms.ComboBox();
			this.buttonUndo = new System.Windows.Forms.Button();
			this.buttonDefault = new System.Windows.Forms.Button();
			this.panel1.SuspendLayout();
			this.SuspendLayout();
			// 
			// panel1
			// 
			this.panel1.Controls.AddRange(new System.Windows.Forms.Control[] {
																																				 this.textBoxFinallyElement,
																																				 this.comboBoxLeaseTime,
																																				 this.labelLeaseTime,
																																				 this.comboBoxSponsorshipTimeOut,
																																				 this.labelRenewOnCallTime,
																																				 this.comboBoxLeaseManagerPollTime,
																																				 this.labelLeaseManagerPollTime,
																																				 this.buttonApply,
																																				 this.buttonCancel,
																																				 this.label1,
																																				 this.comboBoxRenewOnCallTime,
																																				 this.buttonUndo,
																																				 this.buttonDefault});
			this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(464, 210);
			this.panel1.TabIndex = 0;
			// 
			// textBoxFinallyElement
			// 
			this.textBoxFinallyElement.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(224)), ((System.Byte)(224)), ((System.Byte)(224)));
			this.textBoxFinallyElement.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.textBoxFinallyElement.Location = new System.Drawing.Point(8, 74);
			this.textBoxFinallyElement.Multiline = true;
			this.textBoxFinallyElement.Name = "textBoxFinallyElement";
			this.textBoxFinallyElement.ReadOnly = true;
			this.textBoxFinallyElement.ScrollBars = System.Windows.Forms.ScrollBars.Horizontal;
			this.textBoxFinallyElement.Size = new System.Drawing.Size(446, 102);
			this.textBoxFinallyElement.TabIndex = 18;
			this.textBoxFinallyElement.Text = "<lifetime />";
			this.textBoxFinallyElement.WordWrap = false;
			// 
			// comboBoxLeaseTime
			// 
			this.comboBoxLeaseTime.Items.AddRange(new object[] {
																													 "5M"});
			this.comboBoxLeaseTime.Location = new System.Drawing.Point(114, 14);
			this.comboBoxLeaseTime.Name = "comboBoxLeaseTime";
			this.comboBoxLeaseTime.Size = new System.Drawing.Size(100, 21);
			this.comboBoxLeaseTime.TabIndex = 1;
			this.comboBoxLeaseTime.TextChanged += new System.EventHandler(this.OnTextChanged);
			this.comboBoxLeaseTime.SelectedIndexChanged += new System.EventHandler(this.OnTextChanged);
			// 
			// labelLeaseTime
			// 
			this.labelLeaseTime.Location = new System.Drawing.Point(8, 14);
			this.labelLeaseTime.Name = "labelLeaseTime";
			this.labelLeaseTime.Size = new System.Drawing.Size(106, 23);
			this.labelLeaseTime.TabIndex = 0;
			this.labelLeaseTime.Text = "LeaseTime:";
			// 
			// comboBoxSponsorshipTimeOut
			// 
			this.comboBoxSponsorshipTimeOut.Items.AddRange(new object[] {
																																		"2M"});
			this.comboBoxSponsorshipTimeOut.Location = new System.Drawing.Point(354, 14);
			this.comboBoxSponsorshipTimeOut.Name = "comboBoxSponsorshipTimeOut";
			this.comboBoxSponsorshipTimeOut.Size = new System.Drawing.Size(100, 21);
			this.comboBoxSponsorshipTimeOut.TabIndex = 1;
			this.comboBoxSponsorshipTimeOut.TextChanged += new System.EventHandler(this.OnTextChanged);
			this.comboBoxSponsorshipTimeOut.SelectedIndexChanged += new System.EventHandler(this.OnTextChanged);
			// 
			// labelRenewOnCallTime
			// 
			this.labelRenewOnCallTime.Location = new System.Drawing.Point(8, 44);
			this.labelRenewOnCallTime.Name = "labelRenewOnCallTime";
			this.labelRenewOnCallTime.Size = new System.Drawing.Size(106, 23);
			this.labelRenewOnCallTime.TabIndex = 0;
			this.labelRenewOnCallTime.Text = "RenewOnCallTime:";
			// 
			// comboBoxLeaseManagerPollTime
			// 
			this.comboBoxLeaseManagerPollTime.DisplayMember = "10S";
			this.comboBoxLeaseManagerPollTime.Items.AddRange(new object[] {
																																			"10S"});
			this.comboBoxLeaseManagerPollTime.Location = new System.Drawing.Point(354, 44);
			this.comboBoxLeaseManagerPollTime.Name = "comboBoxLeaseManagerPollTime";
			this.comboBoxLeaseManagerPollTime.Size = new System.Drawing.Size(100, 21);
			this.comboBoxLeaseManagerPollTime.TabIndex = 20;
			this.comboBoxLeaseManagerPollTime.TextChanged += new System.EventHandler(this.OnTextChanged);
			this.comboBoxLeaseManagerPollTime.SelectedIndexChanged += new System.EventHandler(this.OnTextChanged);
			// 
			// labelLeaseManagerPollTime
			// 
			this.labelLeaseManagerPollTime.Location = new System.Drawing.Point(218, 44);
			this.labelLeaseManagerPollTime.Name = "labelLeaseManagerPollTime";
			this.labelLeaseManagerPollTime.Size = new System.Drawing.Size(134, 23);
			this.labelLeaseManagerPollTime.TabIndex = 0;
			this.labelLeaseManagerPollTime.Text = "LeaseManagerPollTime:";
			// 
			// buttonApply
			// 
			this.buttonApply.Anchor = (System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right);
			this.buttonApply.Location = new System.Drawing.Point(218, 182);
			this.buttonApply.Name = "buttonApply";
			this.buttonApply.TabIndex = 16;
			this.buttonApply.Text = "APPLY";
			this.buttonApply.Visible = false;
			this.buttonApply.Click += new System.EventHandler(this.buttonObjectApply_Click);
			// 
			// buttonCancel
			// 
			this.buttonCancel.Anchor = (System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right);
			this.buttonCancel.Location = new System.Drawing.Point(380, 182);
			this.buttonCancel.Name = "buttonCancel";
			this.buttonCancel.TabIndex = 17;
			this.buttonCancel.Text = "CANCEL";
			this.buttonCancel.Click += new System.EventHandler(this.buttonObjectCancel_Click);
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(220, 14);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(132, 23);
			this.label1.TabIndex = 0;
			this.label1.Text = "SponsorshipTimeOut:";
			// 
			// comboBoxRenewOnCallTime
			// 
			this.comboBoxRenewOnCallTime.Items.AddRange(new object[] {
																																 "2M"});
			this.comboBoxRenewOnCallTime.Location = new System.Drawing.Point(114, 44);
			this.comboBoxRenewOnCallTime.Name = "comboBoxRenewOnCallTime";
			this.comboBoxRenewOnCallTime.Size = new System.Drawing.Size(100, 21);
			this.comboBoxRenewOnCallTime.TabIndex = 21;
			this.comboBoxRenewOnCallTime.TextChanged += new System.EventHandler(this.OnTextChanged);
			this.comboBoxRenewOnCallTime.SelectedIndexChanged += new System.EventHandler(this.OnTextChanged);
			// 
			// buttonUndo
			// 
			this.buttonUndo.Anchor = (System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right);
			this.buttonUndo.Location = new System.Drawing.Point(298, 182);
			this.buttonUndo.Name = "buttonUndo";
			this.buttonUndo.TabIndex = 16;
			this.buttonUndo.Text = "UNDO";
			this.buttonUndo.Visible = false;
			this.buttonUndo.Click += new System.EventHandler(this.buttonUndo_Click);
			// 
			// buttonDefault
			// 
			this.buttonDefault.Anchor = (System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right);
			this.buttonDefault.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.buttonDefault.Location = new System.Drawing.Point(8, 184);
			this.buttonDefault.Name = "buttonDefault";
			this.buttonDefault.Size = new System.Drawing.Size(50, 23);
			this.buttonDefault.TabIndex = 16;
			this.buttonDefault.Text = "Default";
			this.buttonDefault.Click += new System.EventHandler(this.buttonDefault_Click);
			// 
			// LifetimeForm
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(464, 210);
			this.Controls.AddRange(new System.Windows.Forms.Control[] {
																																	this.panel1});
			this.MaximumSize = new System.Drawing.Size(472, 240);
			this.MinimumSize = new System.Drawing.Size(472, 240);
			this.Name = "LifetimeForm";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Lifetime";
			this.TopMost = true;
			this.panel1.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		#region Events
		public void OnTextChanged(object sender, System.EventArgs e)
		{
			StringBuilder sb = new StringBuilder("<lifetime ");

			if(comboBoxLeaseTime.Text != Convert.ToString(comboBoxLeaseTime.Items[0]) && comboBoxLeaseTime.Text != "")
				sb.AppendFormat("leaseTime = \"{0}\"\r\n\t", comboBoxLeaseTime.Text);
			if(comboBoxSponsorshipTimeOut.Text != Convert.ToString(comboBoxSponsorshipTimeOut.Items[0]) && comboBoxSponsorshipTimeOut.Text != "")
				sb.AppendFormat("sponsorshipTimeOut = \"{0}\"\r\n\t", comboBoxSponsorshipTimeOut.Text);
			if(comboBoxRenewOnCallTime.Text != Convert.ToString(comboBoxRenewOnCallTime.Items[0]) && comboBoxRenewOnCallTime.Text != "")
				sb.AppendFormat("renewOnCallTime = \"{0}\"\r\n\t", comboBoxRenewOnCallTime.Text);
			if(comboBoxLeaseManagerPollTime.Text != Convert.ToString(comboBoxLeaseManagerPollTime.Items[0]) && comboBoxLeaseManagerPollTime.Text != "")
				sb.AppendFormat("leaseManagerPollTime = \"{0}\"\r\n\t", comboBoxLeaseManagerPollTime.Text);
			sb.Append("/>");

			textBoxFinallyElement.Text = sb.ToString();

			//--state
			buttonApply.Visible = true;
			buttonUndo.Visible = true;
		}
		#endregion

		#region Buttons
		private void buttonObjectApply_Click(object sender, System.EventArgs e)
		{
			//---create element for config file in the application tag
			Trace.WriteLine(textBoxFinallyElement.Text);

			try 
			{
				//---call aggent
				ConfigFileAgent cfa = new ConfigFileAgent();
				cfa.UpdateLifetime(textBoxFinallyElement.Text, mstrTargetConfigFile); 
			
				//---notify snapin
				mobjContextNode.OnUser("APPLY_done", mobjContextNode.DisplayName);	
			
				//---exit
				this.Close();
			} 
			catch(Exception ex) 
			{
				MessageBox.Show(ex.Message, mobjContextNode.DisplayName, MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		private void buttonUndo_Click(object sender, System.EventArgs e)
		{
			//---retrieve properties from the config file
			mstrLifetimeOuterXml = GetLifetimeOuterXml();

			//---update form 
			OnTextChanged(sender, e);
			
			//---state
			buttonApply.Visible = false;
			buttonUndo.Visible = false;
		}

		private void buttonObjectCancel_Click(object sender, System.EventArgs e)
		{
			//---no change
			this.Close();
		}

		private void buttonDefault_Click(object sender, System.EventArgs e)
		{
			comboBoxLeaseTime.Text = Convert.ToString(comboBoxLeaseTime.Items[0]);
			comboBoxSponsorshipTimeOut.Text = Convert.ToString(comboBoxSponsorshipTimeOut.Items[0]);
			comboBoxRenewOnCallTime.Text = Convert.ToString(comboBoxRenewOnCallTime.Items[0]);
			comboBoxLeaseManagerPollTime.Text = Convert.ToString(comboBoxLeaseManagerPollTime.Items[0]);	
		}
		#endregion

		#region helpers
		private string GetLifetimeOuterXml()
		{
			string strLifetimeOuterXml = null;

			try 
			{
				//---cleanup form 
				comboBoxLeaseTime.Text = "";
				comboBoxSponsorshipTimeOut.Text = "";
				comboBoxLeaseManagerPollTime.Text = "";
				comboBoxRenewOnCallTime.Text = "";

				//---scanner
				ConfigFileAgent cfa = new ConfigFileAgent();
				strLifetimeOuterXml = cfa.GetLifetime(mstrTargetConfigFile);

				if(strLifetimeOuterXml != null) 
				{
					XmlDocument doc = new XmlDocument();
					doc.Load(new StringReader(strLifetimeOuterXml));

					XmlNode root = doc.DocumentElement.SelectSingleNode("/lifetime");

					if(root != null && root.Attributes.Count > 0) 
					{
						foreach(XmlAttribute attr in root.Attributes) 
						{
							if(attr.Name.ToLower() == "leasetime")
								comboBoxLeaseTime.Text = attr.Value;
							else if(attr.Name.ToLower() == "sponsorshiptimeout")
								comboBoxSponsorshipTimeOut.Text = attr.Value;
							else if(attr.Name.ToLower() == "leasemanagerpolltime")
								comboBoxLeaseManagerPollTime.Text = attr.Value;
							else if(attr.Name.ToLower() == "renewoncalltime")
								comboBoxRenewOnCallTime.Text = attr.Value;
						}
					}
				}
			}
			catch(Exception ex) 
			{
				Trace.WriteLine(ex.Message);
			}

			return strLifetimeOuterXml;
		}
		#endregion

	}
}
