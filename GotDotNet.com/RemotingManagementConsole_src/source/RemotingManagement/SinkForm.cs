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

	public class SinkForm : System.Windows.Forms.Form
	{
		#region private members
		private System.Windows.Forms.Button buttonCancel;
		private System.Windows.Forms.Button buttonAction;
		private System.Windows.Forms.TextBox textBoxFinallyElement;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.CheckBox checkBoxReferenceing;
		private System.Windows.Forms.ComboBox textBoxRef;
		private System.Windows.Forms.TextBox textBoxName;
		private System.Windows.Forms.TextBox textBoxId;
		private System.Windows.Forms.Label labelFirst;
		private System.Windows.Forms.TextBox textBoxType;
		private System.Windows.Forms.Label labelSecond;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.TextBox textBoxMore;
		private System.ComponentModel.Container components = null;
		//
		BaseNode mobjContextNode = null;
		string mstrTargetConfigFile = null;
		string mstrSinkName = null;
		string mstrChannelName = null;
		string mstrParentName = null;
		string mstrSinkProviders = null;
		string mstrTypeProvider = null;
		#endregion

		#region constructor
		public SinkForm(BaseNode node, string strTypeProvider, string strSinkName, string strPathToConfigFile)
		{
			InitializeComponent();

			//---runtime arguments
			mobjContextNode = node;
			mstrTypeProvider = strTypeProvider;
			mstrSinkName = strSinkName;
			mstrTargetConfigFile = strPathToConfigFile;

			//---set the properties based on the caller node
			if(mstrSinkName == null) 
			{
				this.Text = string.Format("{0} sink - {1}", strTypeProvider, "New");
				mstrParentName = node.DisplayName;
				mstrChannelName = mobjContextNode.Snapin.FindNodeByHScope(mobjContextNode.ParentHScopeItem).DisplayName;
			}
			else 
			{
				this.Text = string.Format("{0} sink - {1}", strTypeProvider, mstrSinkName);
				BaseNode sinksNode = mobjContextNode.Snapin.FindNodeByHScope(mobjContextNode.ParentHScopeItem);
				mstrChannelName = mobjContextNode.Snapin.FindNodeByHScope(sinksNode.ParentHScopeItem).DisplayName;
				mstrParentName = sinksNode.DisplayName;
			}

			mstrSinkProviders = mstrParentName == "serverSinks" ? "serverProviders" : "clientProviders";

			//---helper
			ConfigFileAgent cfa = new ConfigFileAgent();

			if(mstrSinkName != null) 
			{	
				#region retrieve properties from the config file
				string strSinkOuterXml = null;			
				if(mstrSinkProviders == "serverProviders") 
					strSinkOuterXml = cfa.GetServerSink(mstrChannelName, strTypeProvider, strSinkName, strPathToConfigFile);
				else 
					strSinkOuterXml = cfa.GetClientSink(mstrChannelName, strTypeProvider, strSinkName, strPathToConfigFile);

				//---populate form properties
				XmlDocument doc = new XmlDocument();
				doc.Load(new StringReader(strSinkOuterXml));
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
						else 
							sb.AppendFormat(" {0}=\"{1}\"", attr.Name, attr.Value); 					
					}

					textBoxMore.Text = sb.ToString();
				}
				#endregion
			}

			#region populate the ref combo box for public and private formatters/providers
			ArrayList objProviders = new ArrayList();
			
			//---public (machine.config file)
			string strMachineConfigFile = cfa.GetPathToMachineConfigFile();
			cfa.GetProviders(mstrSinkProviders, strTypeProvider, ref objProviders, strMachineConfigFile);
			
			//---private (exe.config file)
			cfa.GetProviders(mstrSinkProviders, strTypeProvider, ref objProviders, strPathToConfigFile);
			foreach(string s in objProviders)
				textBoxRef.Items.Add(s);
			#endregion

			//---show the properties
			OnTextChanged(null, null);
			buttonAction.Visible = false;	

			//---checkpoint
			Trace.WriteLine(string.Format("channel={0}, type={1} parent={2}, configfile={3}", 
				mstrChannelName==null?"null":mstrChannelName, mstrTypeProvider, mstrParentName, mstrTargetConfigFile));
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
			this.checkBoxReferenceing = new System.Windows.Forms.CheckBox();
			this.textBoxRef = new System.Windows.Forms.ComboBox();
			this.textBoxName = new System.Windows.Forms.TextBox();
			this.textBoxId = new System.Windows.Forms.TextBox();
			this.labelFirst = new System.Windows.Forms.Label();
			this.textBoxType = new System.Windows.Forms.TextBox();
			this.labelSecond = new System.Windows.Forms.Label();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.textBoxMore = new System.Windows.Forms.TextBox();
			this.groupBox1.SuspendLayout();
			this.groupBox2.SuspendLayout();
			this.SuspendLayout();
			// 
			// buttonCancel
			// 
			this.buttonCancel.Anchor = (System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right);
			this.buttonCancel.Location = new System.Drawing.Point(464, 257);
			this.buttonCancel.Name = "buttonCancel";
			this.buttonCancel.TabIndex = 15;
			this.buttonCancel.Text = "CANCEL";
			this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
			this.buttonCancel.TextChanged += new System.EventHandler(this.buttonCancel_Click);
			// 
			// buttonAction
			// 
			this.buttonAction.Anchor = (System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right);
			this.buttonAction.Location = new System.Drawing.Point(382, 257);
			this.buttonAction.Name = "buttonAction";
			this.buttonAction.TabIndex = 14;
			this.buttonAction.Text = "APPLY";
			this.buttonAction.Visible = false;
			this.buttonAction.Click += new System.EventHandler(this.buttonAction_Click);
			this.buttonAction.TextChanged += new System.EventHandler(this.buttonAction_Click);
			// 
			// textBoxFinallyElement
			// 
			this.textBoxFinallyElement.AcceptsReturn = true;
			this.textBoxFinallyElement.Anchor = ((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right);
			this.textBoxFinallyElement.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(224)), ((System.Byte)(224)), ((System.Byte)(224)));
			this.textBoxFinallyElement.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.textBoxFinallyElement.Location = new System.Drawing.Point(6, 183);
			this.textBoxFinallyElement.Multiline = true;
			this.textBoxFinallyElement.Name = "textBoxFinallyElement";
			this.textBoxFinallyElement.ReadOnly = true;
			this.textBoxFinallyElement.ScrollBars = System.Windows.Forms.ScrollBars.Horizontal;
			this.textBoxFinallyElement.Size = new System.Drawing.Size(534, 66);
			this.textBoxFinallyElement.TabIndex = 16;
			this.textBoxFinallyElement.Text = "";
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
			this.groupBox1.Location = new System.Drawing.Point(6, 10);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(536, 91);
			this.groupBox1.TabIndex = 18;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Required Attributes";
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
			// textBoxRef
			// 
			this.textBoxRef.Location = new System.Drawing.Point(38, 62);
			this.textBoxRef.Name = "textBoxRef";
			this.textBoxRef.Size = new System.Drawing.Size(136, 20);
			this.textBoxRef.TabIndex = 15;
			this.textBoxRef.Text = "";
			this.textBoxRef.TextChanged += new System.EventHandler(this.OnTextChanged);
			// 
			// textBoxName
			// 
			this.textBoxName.Anchor = (System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right);
			this.textBoxName.Location = new System.Drawing.Point(218, 62);
			this.textBoxName.Name = "textBoxName";
			this.textBoxName.Size = new System.Drawing.Size(312, 20);
			this.textBoxName.TabIndex = 14;
			this.textBoxName.Text = "";
			this.textBoxName.TextChanged += new System.EventHandler(this.OnTextChanged);
			// 
			// textBoxId
			// 
			this.textBoxId.Location = new System.Drawing.Point(38, 61);
			this.textBoxId.Name = "textBoxId";
			this.textBoxId.Size = new System.Drawing.Size(136, 20);
			this.textBoxId.TabIndex = 9;
			this.textBoxId.Text = "";
			this.textBoxId.Visible = false;
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
																																						this.textBoxMore});
			this.groupBox2.Location = new System.Drawing.Point(6, 109);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(536, 60);
			this.groupBox2.TabIndex = 17;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "Optional Attributes";
			// 
			// textBoxMore
			// 
			this.textBoxMore.Anchor = (System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right);
			this.textBoxMore.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.textBoxMore.Location = new System.Drawing.Point(8, 30);
			this.textBoxMore.Name = "textBoxMore";
			this.textBoxMore.Size = new System.Drawing.Size(522, 20);
			this.textBoxMore.TabIndex = 9;
			this.textBoxMore.Text = "";
			this.textBoxMore.TextChanged += new System.EventHandler(this.OnTextChanged);
			// 
			// SinkForm
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(548, 290);
			this.Controls.AddRange(new System.Windows.Forms.Control[] {
																																	this.buttonCancel,
																																	this.buttonAction,
																																	this.textBoxFinallyElement,
																																	this.groupBox1,
																																	this.groupBox2});
			this.Name = "SinkForm";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "SinkForm";
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
			sb.AppendFormat("<{0}", mstrTypeProvider);

			if(checkBoxReferenceing.Checked == true) 
			{
				sb.AppendFormat(" ref=\"{0}\"", textBoxRef.Text);
				if(textBoxName.Text.Length > 0) 
					sb.AppendFormat(" name=\"{0}\"", textBoxName.Text);
			}
			else 
			{
				sb.AppendFormat(" id=\"{0}\"", textBoxId.Text);
				sb.AppendFormat(" type=\"{0}\"", textBoxType.Text);
			}

			sb.AppendFormat(" {0} />", textBoxMore.Text);
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
			//---node name
			string strNodeDisplayName = mstrTypeProvider + " ";

			//---checkpoint
			Trace.WriteLine(textBoxFinallyElement.Text);
 	
			//---select the name based on the following attributes: id, name, ref
			if(checkBoxReferenceing.Checked)
			{
				if(textBoxName.Text.Length > 0) 
					strNodeDisplayName += textBoxName.Text;
				else if(textBoxRef.Text.Length > 0)
					strNodeDisplayName += textBoxRef.Text;
				else 
				{
					MessageBox.Show("Missing some of the required attribute", "mobjContextNode.DisplayName", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				}
			}
			else 
			{
				if(textBoxId.Text.Length > 0 && textBoxType.Text.Length > 0)
					strNodeDisplayName += textBoxId.Text;
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

				if(mstrParentName == "serverSinks" && mstrSinkName == null) 
					cfa.InsertServerSink(mstrChannelName, textBoxFinallyElement.Text, mstrTargetConfigFile); 
				else if(mstrParentName == "clientSinks" && mstrSinkName == null) 
					cfa.InsertClientSink(mstrChannelName, textBoxFinallyElement.Text, mstrTargetConfigFile); 
				else if(mstrParentName == "serverSinks"  && mstrSinkName != null) 
					cfa.UpdateServerSink(mstrChannelName, mstrTypeProvider, mstrSinkName, textBoxFinallyElement.Text, mstrTargetConfigFile); 
				else if(mstrParentName == "clientSinks"  && mstrSinkName != null) 
					cfa.UpdateClientSink(mstrChannelName, mstrTypeProvider, mstrSinkName, textBoxFinallyElement.Text, mstrTargetConfigFile); 
				else 
				{
					throw new Exception("Fatal error, wrong Node.DisplayName = " + mstrParentName);				
				}		

				//---done (insert the node and setup the parent scope)
				mobjContextNode.OnUser("APPLY_done", strNodeDisplayName);	
		
				//---exit
				this.Close();		
			}
			catch(Exception ex) 
			{
				MessageBox.Show(ex.Message, "mobjContextNode.DisplayName", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
