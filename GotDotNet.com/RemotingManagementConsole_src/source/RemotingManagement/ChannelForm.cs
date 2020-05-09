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
	/// <summary>
	/// Summary description for ChannelForm.
	/// </summary>
	public class ChannelForm : System.Windows.Forms.Form
	{
		#region private members
		private System.Windows.Forms.TextBox textBoxFinallyElement;
		private System.Windows.Forms.Button buttonCancel;
		private System.ComponentModel.Container components = null;
		private System.Windows.Forms.Button buttonAction;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.Label labelFirst;
		private System.Windows.Forms.Label labelSecond;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.Label label9;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox textBoxId;
		private System.Windows.Forms.TextBox textBoxType;
		private System.Windows.Forms.TextBox textBoxMore;
		private System.Windows.Forms.TextBox textBoxPort;
		private System.Windows.Forms.TextBox textBoxName;
		private System.Windows.Forms.ComboBox textBoxRef;
		private System.Windows.Forms.CheckBox checkBoxReferenceing;
		//
		BaseNode mobjContextNode = null;
		string mstrTargetConfigFile = null;
		string mstrChannelName = null;
		#endregion

		#region constructor
		public ChannelForm(BaseNode node, string strChannelName, string strPathToConfigFile)
		{
			InitializeComponent();

			//---runtime arguments
			mobjContextNode = node;
			mstrChannelName = strChannelName;
			mstrTargetConfigFile = strPathToConfigFile;

			//---set the properties based on the caller node
			if(strChannelName == null) 
			{
				this.Text = "New Channel";
			}
			else 
			{
				this.Text = mstrChannelName + " Channel";			
			}

			//---my worker
			ConfigFileAgent cfa = new ConfigFileAgent();

			if(strChannelName != null) 
			{
				#region retrieve properties from the config file			
				string strChannelOuterXml = cfa.GetChannel(mstrChannelName, strPathToConfigFile);
		
				//---populate form properties
				XmlDocument doc = new XmlDocument();
				doc.Load(new StringReader(strChannelOuterXml));
				XmlNode providers = doc.FirstChild;

				if(providers != null) 
				{
					StringBuilder sb = new StringBuilder();

					//---walk trough all attributes
					foreach(XmlAttribute attr in providers.Attributes) 
					{		
						string name = attr.Name.ToLower();
						if(name == "ref") 
						{
							textBoxRef.Text = attr.Value;
							checkBoxReferenceing.Checked = true;
						}
						else if(name == "id") 
						{
							textBoxId.Text = attr.Value;
							checkBoxReferenceing.Checked = false;
						}
						else if(name == "name")
							textBoxName.Text = attr.Value;
						else if(name == "type")
							textBoxType.Text = attr.Value;
						else if(name == "port")
							textBoxPort.Text = attr.Value;
						else 
							sb.AppendFormat(" {0}=\"{1}\"", attr.Name, attr.Value); 					
					}

					textBoxMore.Text = sb.ToString();					
				}
				#endregion
			}

			#region populate ref combo box for public and private channels
			ArrayList objChannels = new ArrayList();

			//---public (machine.config file)
			string strMachineConfigFile = cfa.GetPathToMachineConfigFile();
			cfa.GetChannels(ref objChannels, strMachineConfigFile);
			
			//---private (exe.config file)
			cfa.GetChannels(ref objChannels, strPathToConfigFile);
			foreach(string s in objChannels)
				textBoxRef.Items.Add(s);
			#endregion

			//---show the properties
			OnTextChanged(null, null);
			buttonAction.Visible = false;	
		
			Trace.WriteLine(string.Format("channel={0}, configfile={1}", mstrChannelName==null?"null":mstrChannelName, mstrTargetConfigFile));
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
			this.buttonCancel = new System.Windows.Forms.Button();
			this.buttonAction = new System.Windows.Forms.Button();
			this.textBoxFinallyElement = new System.Windows.Forms.TextBox();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.textBoxId = new System.Windows.Forms.TextBox();
			this.labelFirst = new System.Windows.Forms.Label();
			this.textBoxType = new System.Windows.Forms.TextBox();
			this.labelSecond = new System.Windows.Forms.Label();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.textBoxMore = new System.Windows.Forms.TextBox();
			this.label9 = new System.Windows.Forms.Label();
			this.textBoxPort = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.textBoxName = new System.Windows.Forms.TextBox();
			this.textBoxRef = new System.Windows.Forms.ComboBox();
			this.checkBoxReferenceing = new System.Windows.Forms.CheckBox();
			this.groupBox1.SuspendLayout();
			this.groupBox2.SuspendLayout();
			this.SuspendLayout();
			// 
			// buttonCancel
			// 
			this.buttonCancel.Anchor = (System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right);
			this.buttonCancel.Location = new System.Drawing.Point(464, 260);
			this.buttonCancel.Name = "buttonCancel";
			this.buttonCancel.TabIndex = 1;
			this.buttonCancel.Text = "CANCEL";
			this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
			// 
			// buttonAction
			// 
			this.buttonAction.Anchor = (System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right);
			this.buttonAction.Location = new System.Drawing.Point(382, 260);
			this.buttonAction.Name = "buttonAction";
			this.buttonAction.TabIndex = 1;
			this.buttonAction.Text = "APPLY";
			this.buttonAction.Visible = false;
			this.buttonAction.Click += new System.EventHandler(this.buttonAction_Click);
			// 
			// textBoxFinallyElement
			// 
			this.textBoxFinallyElement.Anchor = ((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right);
			this.textBoxFinallyElement.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(224)), ((System.Byte)(224)), ((System.Byte)(224)));
			this.textBoxFinallyElement.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.textBoxFinallyElement.Location = new System.Drawing.Point(6, 186);
			this.textBoxFinallyElement.Multiline = true;
			this.textBoxFinallyElement.Name = "textBoxFinallyElement";
			this.textBoxFinallyElement.ReadOnly = true;
			this.textBoxFinallyElement.ScrollBars = System.Windows.Forms.ScrollBars.Horizontal;
			this.textBoxFinallyElement.Size = new System.Drawing.Size(534, 66);
			this.textBoxFinallyElement.TabIndex = 8;
			this.textBoxFinallyElement.Text = "<channel> \r\n</channel>";
			this.textBoxFinallyElement.WordWrap = false;
			// 
			// groupBox1
			// 
			this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right);
			this.groupBox1.Controls.AddRange(new System.Windows.Forms.Control[] {
																																						this.checkBoxReferenceing,
																																						this.textBoxRef,
																																						this.textBoxName,
																																						this.textBoxId,
																																						this.labelFirst,
																																						this.textBoxType,
																																						this.labelSecond});
			this.groupBox1.Location = new System.Drawing.Point(6, 13);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(536, 91);
			this.groupBox1.TabIndex = 13;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Required Attributes";
			// 
			// textBoxId
			// 
			this.textBoxId.Location = new System.Drawing.Point(38, 61);
			this.textBoxId.Name = "textBoxId";
			this.textBoxId.Size = new System.Drawing.Size(136, 20);
			this.textBoxId.TabIndex = 9;
			this.textBoxId.Text = "";
			this.textBoxId.Visible = false;
			this.textBoxId.TextChanged += new System.EventHandler(this.OnTextChanged);
			// 
			// labelFirst
			// 
			this.labelFirst.Location = new System.Drawing.Point(8, 62);
			this.labelFirst.Name = "labelFirst";
			this.labelFirst.Size = new System.Drawing.Size(28, 18);
			this.labelFirst.TabIndex = 12;
			this.labelFirst.Text = "Ref:";
			// 
			// textBoxType
			// 
			this.textBoxType.Anchor = (System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right);
			this.textBoxType.Location = new System.Drawing.Point(218, 61);
			this.textBoxType.Name = "textBoxType";
			this.textBoxType.Size = new System.Drawing.Size(310, 20);
			this.textBoxType.TabIndex = 9;
			this.textBoxType.Text = "";
			this.textBoxType.Visible = false;
			this.textBoxType.TextChanged += new System.EventHandler(this.OnTextChanged);
			// 
			// labelSecond
			// 
			this.labelSecond.Anchor = (System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left);
			this.labelSecond.Location = new System.Drawing.Point(178, 61);
			this.labelSecond.Name = "labelSecond";
			this.labelSecond.Size = new System.Drawing.Size(40, 18);
			this.labelSecond.TabIndex = 12;
			this.labelSecond.Text = "Name:";
			// 
			// groupBox2
			// 
			this.groupBox2.Anchor = (System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right);
			this.groupBox2.Controls.AddRange(new System.Windows.Forms.Control[] {
																																						this.textBoxMore,
																																						this.label9,
																																						this.textBoxPort,
																																						this.label1});
			this.groupBox2.Location = new System.Drawing.Point(6, 112);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(536, 60);
			this.groupBox2.TabIndex = 13;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "Optional Attributes";
			// 
			// textBoxMore
			// 
			this.textBoxMore.Anchor = (System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right);
			this.textBoxMore.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.textBoxMore.Location = new System.Drawing.Point(142, 30);
			this.textBoxMore.Name = "textBoxMore";
			this.textBoxMore.Size = new System.Drawing.Size(388, 20);
			this.textBoxMore.TabIndex = 9;
			this.textBoxMore.Text = "";
			this.textBoxMore.TextChanged += new System.EventHandler(this.OnTextChanged);
			// 
			// label9
			// 
			this.label9.Anchor = (System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left);
			this.label9.Location = new System.Drawing.Point(106, 32);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(36, 18);
			this.label9.TabIndex = 12;
			this.label9.Text = "More:";
			// 
			// textBoxPort
			// 
			this.textBoxPort.Anchor = (System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left);
			this.textBoxPort.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.textBoxPort.Location = new System.Drawing.Point(42, 30);
			this.textBoxPort.Name = "textBoxPort";
			this.textBoxPort.Size = new System.Drawing.Size(62, 20);
			this.textBoxPort.TabIndex = 9;
			this.textBoxPort.Text = "";
			this.textBoxPort.TextChanged += new System.EventHandler(this.OnTextChanged);
			// 
			// label1
			// 
			this.label1.Anchor = (System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left);
			this.label1.Location = new System.Drawing.Point(8, 32);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(32, 18);
			this.label1.TabIndex = 12;
			this.label1.Text = "Port:";
			// 
			// textBoxName
			// 
			this.textBoxName.Anchor = (System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right);
			this.textBoxName.Location = new System.Drawing.Point(218, 62);
			this.textBoxName.Name = "textBoxName";
			this.textBoxName.Size = new System.Drawing.Size(312, 20);
			this.textBoxName.TabIndex = 14;
			this.textBoxName.Text = "Tcp";
			this.textBoxName.TextChanged += new System.EventHandler(this.OnTextChanged);
			// 
			// textBoxRef
			// 
			this.textBoxRef.Location = new System.Drawing.Point(38, 62);
			this.textBoxRef.Name = "textBoxRef";
			this.textBoxRef.Size = new System.Drawing.Size(136, 20);
			this.textBoxRef.TabIndex = 15;
			this.textBoxRef.Text = "tcp";
			this.textBoxRef.TextChanged += new System.EventHandler(this.OnTextChanged);
			// 
			// checkBoxReferenceing
			// 
			this.checkBoxReferenceing.Checked = true;
			this.checkBoxReferenceing.CheckState = System.Windows.Forms.CheckState.Checked;
			this.checkBoxReferenceing.Location = new System.Drawing.Point(8, 26);
			this.checkBoxReferenceing.Name = "checkBoxReferenceing";
			this.checkBoxReferenceing.Size = new System.Drawing.Size(174, 24);
			this.checkBoxReferenceing.TabIndex = 16;
			this.checkBoxReferenceing.Text = "Template is referencied.";
			this.checkBoxReferenceing.CheckedChanged += new System.EventHandler(this.checkBoxReferenceing_CheckedChanged);
			// 
			// ChannelForm
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(548, 290);
			this.Controls.AddRange(new System.Windows.Forms.Control[] {
																																	this.buttonCancel,
																																	this.buttonAction,
																																	this.textBoxFinallyElement,
																																	this.groupBox1,
																																	this.groupBox2});
			this.MaximumSize = new System.Drawing.Size(800, 320);
			this.MinimumSize = new System.Drawing.Size(556, 320);
			this.Name = "ChannelForm";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "ChannelForm";
			this.TopMost = true;
			this.groupBox1.ResumeLayout(false);
			this.groupBox2.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		#region Events
		private void OnTextChanged(object sender, System.EventArgs e)
		{			
			StringBuilder sb = new StringBuilder();
			sb.AppendFormat("<{0}", "channel");

			if(checkBoxReferenceing.Checked == true) 
			{
				sb.AppendFormat(" ref=\"{0}\"", textBoxRef.Text);
				if(textBoxName.Text.Length > 0) 
					sb.AppendFormat(" name=\"{0}\"", textBoxName.Text);
			}
			else 
			{
				sb.AppendFormat(" id=\"{0}\"", textBoxId.Text);
				sb.AppendFormat(" type=\"{0}\"", textBoxId.Text);
			}

			if(textBoxPort.Text.Length > 0) 
				sb.AppendFormat(" port=\"{0}\"", textBoxPort.Text);

			sb.AppendFormat(" {0} >", textBoxMore.Text);
			sb.AppendFormat("\r\n</{0}>", "channel");
			textBoxFinallyElement.Text = sb.ToString();
			//
			buttonAction.Visible = true;	
		}

		private void checkBoxReferenceing_CheckedChanged(object sender, System.EventArgs e)
		{
			if(checkBoxReferenceing.Checked == true) 
			{
				//---template mode
				textBoxId.Visible = false;
				textBoxType.Visible = false;
				textBoxRef.Visible = true;
				textBoxName.Visible = true;
				labelFirst.Text = "Ref:";
				labelSecond.Text = "Name:";

			}
			else  
			{
				//---template mode (private)
				textBoxId.Visible = true;
				textBoxType.Visible = true;
				textBoxRef.Visible = false;
				textBoxName.Visible = false;
				labelFirst.Text = "Id:";
				labelSecond.Text = "Type:";
			}

			OnTextChanged(sender, e);
		}
		#endregion

		#region Buttons
		private void buttonAction_Click(object sender, System.EventArgs e)
		{	
			//---checkpoint
			Trace.WriteLine(textBoxFinallyElement.Text);
 
			//---select the name based on the following attributes: id, name, ref
			string strDisplayName = null;
			if(checkBoxReferenceing.Checked)
			{
				if(textBoxName.Text.Length > 0) 
					strDisplayName = textBoxName.Text;
				else
					if(textBoxRef.Text.Length > 0)
					strDisplayName = textBoxRef.Text;
				else 
				{
						MessageBox.Show("Missing some of the required attribute", "mobjContextNode.DisplayName", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				}
			}
			else 
			{
				if(textBoxId.Text.Length > 0 && textBoxType.Text.Length > 0)
					strDisplayName = textBoxId.Text;
				else 
				{
					MessageBox.Show("Missing some of the required attribute", "mobjContextNode.DisplayName", MessageBoxButtons.OK, MessageBoxIcon.Warning);
					return;
				}
			}
			
			try 
			{
				//---call agent for help
				ConfigFileAgent cfa = new ConfigFileAgent();

				if(mstrChannelName == null) 
				{
					//---new channel
					cfa.InsertChannel(textBoxFinallyElement.Text, mstrTargetConfigFile); 
				}
				else 
				{
					//---modified channel
					cfa.UpdateChannel(mstrChannelName, textBoxFinallyElement.Text, mstrTargetConfigFile); 
				}
				
				//---notification
				mobjContextNode.OnUser("APPLY_done", strDisplayName);	

				//---exit
				this.Close();		
			}
			catch(Exception ex) 
			{
				MessageBox.Show(ex.Message, mobjContextNode.DisplayName, MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		private void buttonCancel_Click(object sender, System.EventArgs e)
		{
			//--exit
			this.Close();
		}
		#endregion	
	}
}