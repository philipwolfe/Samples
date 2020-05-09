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
using System.Diagnostics;
using System.Drawing;
using System.Collections;
using System.Windows.Forms;
using System.IO;
using System.Data;
using Ironring.Management.MMC;
#endregion

namespace RKiss.RemotingManagement
{
	public class ObjectForm : System.Windows.Forms.Form
	{
		#region private members
		private System.Windows.Forms.Button buttonObjectCancel;
		private System.Windows.Forms.ComboBox comboBoxType;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.ComboBox comboBoxMode;
		private System.Windows.Forms.TextBox textBoxObjectUri;
		private System.Windows.Forms.TextBox textBoxFinallyElement;
		private System.Windows.Forms.ToolTip toolTipObject;
		private System.Windows.Forms.Button buttonObjectApply;
		private System.ComponentModel.IContainer components;

		//---application state
		BaseNode mobjContextNode = null;
		private string mstrTargetConfigFile = null;
		private System.Windows.Forms.Label labelObjectUri;		
		private string mstrRemotingObject = null;
		#endregion
		
		#region constructor
		public ObjectForm(BaseNode parent, object strRemotingObject, string strTargetConfigFile)
		{
			try 
			{
				InitializeComponent();
		
				mobjContextNode = parent;
				mstrTargetConfigFile = strTargetConfigFile;

				if((strRemotingObject != null) && (strRemotingObject is string)) 
				{
					//---only one object
					comboBoxType.DropDownStyle = ComboBoxStyle.Simple;

					//---change properties on the already inserted object
					mstrRemotingObject = (string)strRemotingObject;

					//---read only
					comboBoxType.Enabled = false;

					//---caption text
					this.Text = mstrRemotingObject + " Properties";

					//---service data
					DataSet ds = new DataSet("Service");

					//---retrieve service element from the config file
					ConfigFileAgent cfa = new ConfigFileAgent();
					string strServiceInnerXml = cfa.GetRemoteObject(mstrRemotingObject, mstrTargetConfigFile);

					if(strServiceInnerXml != null) 
					{	
						//---populate dataset
						ds.ReadXml(new StringReader("<service>" + strServiceInnerXml + "</service>"));	

						//---populate properties
						if(ds.Tables.Contains("wellknown") && ds.Tables["wellknown"].Rows.Count == 1)
						{
							DataRow dr = ds.Tables["wellknown"].Rows[0]; 
							comboBoxType.Text = Convert.ToString(dr["type"]);
							textBoxObjectUri.Text = Convert.ToString(dr["objectUri"]);
							string strMode = Convert.ToString(dr["mode"]).ToLower();
							if(strMode == "singlecall")
								comboBoxMode.SelectedIndex = 0;
							else
								if(strMode == "singleton")
								comboBoxMode.SelectedIndex = 1;						
						}

						if(ds.Tables.Contains("activated"))
						{
							DataRow dr = ds.Tables["activated"].Rows[0]; 
							comboBoxType.Text = Convert.ToString(dr["type"]);
							comboBoxMode.SelectedIndex = 2;			
						}		
					}			
				}
				else 
					if(strRemotingObject == null) 			
				{
					//---only one object
					comboBoxType.DropDownStyle = ComboBoxStyle.Simple;

					//---default mode
					comboBoxMode.SelectedIndex = 0;

					//---new object
					textBoxFinallyElement.Text = "<" + comboBoxMode.Text + "\r\n\ttype=\"" + 
						comboBoxType.Text + "\"\r\n\tobjectUri=\"" + textBoxObjectUri.Text + "\" />";
				}		
				else 
					if(strRemotingObject != null && strRemotingObject is ArrayList) 
				{
					ArrayList strRemotingObjects = strRemotingObject as ArrayList;

					//---unknown number of the objects
					comboBoxType.DropDownStyle = strRemotingObjects.Count > 1 ? ComboBoxStyle.DropDown : ComboBoxStyle.Simple;

					//---populate comboBoxType
					comboBoxType.DataSource = strRemotingObject;

					//---default mode
					comboBoxMode.SelectedIndex = 0;
				}

				//---invisible
				buttonObjectApply.Visible = false;

				Trace.WriteLine(string.Format("ObjectForm: node={0}, configFile={1}", mstrRemotingObject, mstrTargetConfigFile)); 
			}
			catch(Exception ex) 
			{
				Trace.WriteLine("ObjectForm constructor failed, error= " + ex.Message);
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
			this.components = new System.ComponentModel.Container();
			this.buttonObjectCancel = new System.Windows.Forms.Button();
			this.buttonObjectApply = new System.Windows.Forms.Button();
			this.label2 = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.comboBoxMode = new System.Windows.Forms.ComboBox();
			this.textBoxObjectUri = new System.Windows.Forms.TextBox();
			this.labelObjectUri = new System.Windows.Forms.Label();
			this.textBoxFinallyElement = new System.Windows.Forms.TextBox();
			this.toolTipObject = new System.Windows.Forms.ToolTip(this.components);
			this.comboBoxType = new System.Windows.Forms.ComboBox();
			this.SuspendLayout();
			// 
			// buttonObjectCancel
			// 
			this.buttonObjectCancel.Anchor = (System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right);
			this.buttonObjectCancel.Location = new System.Drawing.Point(366, 198);
			this.buttonObjectCancel.Name = "buttonObjectCancel";
			this.buttonObjectCancel.TabIndex = 1;
			this.buttonObjectCancel.Text = "CANCEL";
			this.toolTipObject.SetToolTip(this.buttonObjectCancel, "Press button to exit without any changes.");
			this.buttonObjectCancel.Click += new System.EventHandler(this.buttonObjectCancel_Click);
			// 
			// buttonObjectApply
			// 
			this.buttonObjectApply.Anchor = (System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right);
			this.buttonObjectApply.Location = new System.Drawing.Point(284, 198);
			this.buttonObjectApply.Name = "buttonObjectApply";
			this.buttonObjectApply.TabIndex = 1;
			this.buttonObjectApply.Text = "APPLY";
			this.toolTipObject.SetToolTip(this.buttonObjectApply, "Press button to performe the request.");
			this.buttonObjectApply.Visible = false;
			this.buttonObjectApply.Click += new System.EventHandler(this.buttonObjectApply_Click);
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(12, 44);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(74, 23);
			this.label2.TabIndex = 7;
			this.label2.Text = "Type:";
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(12, 12);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(74, 23);
			this.label1.TabIndex = 5;
			this.label1.Text = "Mode:";
			// 
			// comboBoxMode
			// 
			this.comboBoxMode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.comboBoxMode.Items.AddRange(new object[] {
																											"wellknown mode=\"SingleCall\"",
																											"wellknown mode=\"Singleton\"",
																											"activated"});
			this.comboBoxMode.Location = new System.Drawing.Point(86, 12);
			this.comboBoxMode.MaxDropDownItems = 3;
			this.comboBoxMode.Name = "comboBoxMode";
			this.comboBoxMode.Size = new System.Drawing.Size(184, 21);
			this.comboBoxMode.TabIndex = 4;
			this.toolTipObject.SetToolTip(this.comboBoxMode, "Type of the object activation.");
			this.comboBoxMode.SelectedIndexChanged += new System.EventHandler(this.OnTextChanged);
			// 
			// textBoxObjectUri
			// 
			this.textBoxObjectUri.Anchor = (System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right);
			this.textBoxObjectUri.Location = new System.Drawing.Point(85, 77);
			this.textBoxObjectUri.Name = "textBoxObjectUri";
			this.textBoxObjectUri.Size = new System.Drawing.Size(356, 20);
			this.textBoxObjectUri.TabIndex = 10;
			this.textBoxObjectUri.Text = "";
			this.toolTipObject.SetToolTip(this.textBoxObjectUri, "Endpoint of the remote object.");
			this.textBoxObjectUri.TextChanged += new System.EventHandler(this.OnTextChanged);
			// 
			// labelObjectUri
			// 
			this.labelObjectUri.Location = new System.Drawing.Point(12, 78);
			this.labelObjectUri.Name = "labelObjectUri";
			this.labelObjectUri.Size = new System.Drawing.Size(74, 23);
			this.labelObjectUri.TabIndex = 6;
			this.labelObjectUri.Text = "ObjectUri:";
			// 
			// textBoxFinallyElement
			// 
			this.textBoxFinallyElement.Anchor = (System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right);
			this.textBoxFinallyElement.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(224)), ((System.Byte)(224)), ((System.Byte)(224)));
			this.textBoxFinallyElement.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.textBoxFinallyElement.Location = new System.Drawing.Point(10, 115);
			this.textBoxFinallyElement.Multiline = true;
			this.textBoxFinallyElement.Name = "textBoxFinallyElement";
			this.textBoxFinallyElement.ReadOnly = true;
			this.textBoxFinallyElement.ScrollBars = System.Windows.Forms.ScrollBars.Horizontal;
			this.textBoxFinallyElement.Size = new System.Drawing.Size(430, 74);
			this.textBoxFinallyElement.TabIndex = 8;
			this.textBoxFinallyElement.Text = "<wellknown mode=\"SingleCall\"\r\n\ttype=\"RKiss.RemotingObject, RemotingTest,\r\n\tobject" +
				"Uri=\"endpoint\" />\r\n\t";
			this.toolTipObject.SetToolTip(this.textBoxFinallyElement, "Finally element inserted in the service tag of the config file.");
			this.textBoxFinallyElement.WordWrap = false;
			// 
			// comboBoxType
			// 
			this.comboBoxType.Anchor = (System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right);
			this.comboBoxType.Items.AddRange(new object[] {
																											"drag & drop "});
			this.comboBoxType.Location = new System.Drawing.Point(86, 44);
			this.comboBoxType.Name = "comboBoxType";
			this.comboBoxType.Size = new System.Drawing.Size(354, 21);
			this.comboBoxType.Sorted = true;
			this.comboBoxType.TabIndex = 11;
			this.toolTipObject.SetToolTip(this.comboBoxType, "Full name (type, assembly) of the remote object.");
			this.comboBoxType.TextChanged += new System.EventHandler(this.OnTextChanged);
			this.comboBoxType.SelectedIndexChanged += new System.EventHandler(this.OnTextChanged);
			// 
			// ObjectForm
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(452, 230);
			this.Controls.AddRange(new System.Windows.Forms.Control[] {
																																	this.comboBoxType,
																																	this.label2,
																																	this.label1,
																																	this.comboBoxMode,
																																	this.textBoxObjectUri,
																																	this.labelObjectUri,
																																	this.textBoxFinallyElement,
																																	this.buttonObjectCancel,
																																	this.buttonObjectApply});
			this.MaximumSize = new System.Drawing.Size(860, 260);
			this.MinimumSize = new System.Drawing.Size(460, 260);
			this.Name = "ObjectForm";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Publish new remote object";
			this.ResumeLayout(false);

		}
		#endregion

		#region Buttons
		private void buttonObjectApply_Click(object sender, System.EventArgs e)
		{
			//---create element for config file in the service tag
			Trace.WriteLine(textBoxFinallyElement.Text);

			string[] strType = comboBoxType.Text.Split(',');

			if(strType.Length < 2)
			{
				string strMsg = string.Format("The '{0}' is not full type name.\r\nPlease type again using the 'namespace.classname, assemblyname' formula.", comboBoxType.Text);
				MessageBox.Show(strMsg, "New Remote Object");
				buttonObjectApply.Visible = true;
				return;
			}
 
			string strObjectName = strType[0].Trim();

			ConfigFileAgent cfa = new ConfigFileAgent();

			if(mstrRemotingObject == null) 
			{
				cfa.InsertRemoteObject(textBoxFinallyElement.Text, mstrTargetConfigFile); 

				//---done (insert the node and setup the parent scope)
				mobjContextNode.OnUser("APPLY_done", strObjectName);	
			}
			else 
			{
				cfa.UpdateRemoteObject(mstrRemotingObject, textBoxFinallyElement.Text, mstrTargetConfigFile); 
				
				//---done (only setup the parent scope)
				mobjContextNode.OnUser("APPLY_done", mstrRemotingObject);	
			}

			//---exit
			this.Close();
		}

		private void buttonObjectCancel_Click(object sender, System.EventArgs e)
		{
			//---no change
			this.Close();
		}
		#endregion

		#region Events
		public void OnTextChanged(object sender, System.EventArgs e)
		{
			buttonObjectApply.Visible = true;

			if(comboBoxMode.SelectedIndex == 2) 
			{
				textBoxObjectUri.Visible = false;
				labelObjectUri.Visible = false;

				textBoxFinallyElement.Text = "<" + comboBoxMode.Text +  " type=\"" + comboBoxType.Text + "\" />";
			}
			else 
			{
				textBoxObjectUri.Visible = true;
				labelObjectUri.Visible = true;

				textBoxFinallyElement.Text = "<" + comboBoxMode.Text + "\r\n\ttype=\"" + 
					comboBoxType.Text + "\"\r\n\tobjectUri=\"" + textBoxObjectUri.Text + "\" />";
			}
		}
		#endregion
	
	}
}
