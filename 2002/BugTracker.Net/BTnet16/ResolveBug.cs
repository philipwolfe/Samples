////////////////////////////////////////////////////////////
///
/// This code is copyright (c) 2002, by Michael G. Lehman
/// It may be used for no charge for non-commerical purposes
/// including education and training uses.
/// 
/// For commercial distribution or licensing please contact
/// http://www.mikelehman.com
/// 
/// I provide software development and consulting services
/// and am always looking for new clients.
/// 
////////////////////////////////////////////////////////////
using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Data.OleDb;


namespace com.mikelehman.bugtracker
{
	////////////////////////////////////////////////////////////
	/// <summary>
	/// Dialog to add final resolution comments for a bug
	/// </summary>
	////////////////////////////////////////////////////////////
	public class ResolveBug : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Button OKBtn;
		private System.Windows.Forms.Button cancelButton;
		private System.Windows.Forms.Label label11;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.RichTextBox txtDescription;
		private System.Windows.Forms.Label label10;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox txtPriority;
		private System.Windows.Forms.TextBox txtSeverity;
		private System.Windows.Forms.Label label2;
		private System.ComponentModel.Container components = null;

		private System.Data.OleDb.OleDbDataAdapter myDataAdapter;
		private DataSet myDataSet;
		private Hashtable myProps;
		private string releaseOID;
		private System.Windows.Forms.ComboBox cbPeople;
		private System.Windows.Forms.Label txtReleaseName;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.RichTextBox rtfResolution;
		private System.Windows.Forms.Label txtAssignedTo;
		private System.Windows.Forms.Label label7;
		private Hashtable personToOID;
		private DataRow theCurrentBug;

		////////////////////////////////////////////////////////////
		/// <summary>
		/// Constructor for ResolveBug
		/// </summary>
		////////////////////////////////////////////////////////////
		public ResolveBug(
					    System.Data.OleDb.OleDbDataAdapter bugDA,
						DataSet bugDS,
						Hashtable props, 
						string releaseName,
						string rOID, 
						Hashtable pToOID,
						Hashtable OIDtoP,
						DataRow currentBug)
		{
			int i;
			int selection;
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			myDataAdapter = bugDA;
			myDataSet = bugDS;
			myProps = props;
			releaseOID = rOID;
			personToOID = pToOID;
			i = 0;
			selection = 0;
			foreach(string s in personToOID.Keys)
			{
				if (s == BTnetMain.getOwnerName())
					selection = i;
				this.cbPeople.Items.Add(s);
				i++;
			}
			cbPeople.SelectedIndex = selection;

			this.txtReleaseName.Text = releaseName;
			this.txtAssignedTo.Text = (string) OIDtoP[currentBug["ownerOID"]];
			this.txtPriority.Text = (string) currentBug["priority"];
			this.txtSeverity.Text = (string) currentBug["severity"];
			this.txtDescription.Text = (string) currentBug["description"];

			theCurrentBug = currentBug;
		}

		////////////////////////////////////////////////////////////
		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		////////////////////////////////////////////////////////////
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
			this.OKBtn = new System.Windows.Forms.Button();
			this.cancelButton = new System.Windows.Forms.Button();
			this.label11 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.label5 = new System.Windows.Forms.Label();
			this.txtDescription = new System.Windows.Forms.RichTextBox();
			this.label10 = new System.Windows.Forms.Label();
			this.txtReleaseName = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.txtPriority = new System.Windows.Forms.TextBox();
			this.txtSeverity = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.cbPeople = new System.Windows.Forms.ComboBox();
			this.label4 = new System.Windows.Forms.Label();
			this.rtfResolution = new System.Windows.Forms.RichTextBox();
			this.txtAssignedTo = new System.Windows.Forms.Label();
			this.label7 = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// OKBtn
			// 
			this.OKBtn.Location = new System.Drawing.Point(240, 408);
			this.OKBtn.Name = "OKBtn";
			this.OKBtn.TabIndex = 3;
			this.OKBtn.Text = "OK";
			this.OKBtn.Click += new System.EventHandler(this.OKBtn_Click);
			// 
			// cancelButton
			// 
			this.cancelButton.Location = new System.Drawing.Point(368, 408);
			this.cancelButton.Name = "cancelButton";
			this.cancelButton.TabIndex = 4;
			this.cancelButton.Text = "Cancel";
			this.cancelButton.Click += new System.EventHandler(this.CancelButton_Click);
			// 
			// label11
			// 
			this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.label11.ForeColor = System.Drawing.SystemColors.Highlight;
			this.label11.Location = new System.Drawing.Point(280, 16);
			this.label11.Name = "label11";
			this.label11.Size = new System.Drawing.Size(384, 23);
			this.label11.TabIndex = 24;
			this.label11.Text = "(c) 2002, Mike Lehman, Free for non-commercial use.";
			this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(32, 224);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(56, 23);
			this.label3.TabIndex = 17;
			this.label3.Text = "Assign to:";
			this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// label5
			// 
			this.label5.Location = new System.Drawing.Point(24, 96);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(64, 23);
			this.label5.TabIndex = 11;
			this.label5.Text = "Description:";
			this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// txtDescription
			// 
			this.txtDescription.Location = new System.Drawing.Point(96, 88);
			this.txtDescription.Name = "txtDescription";
			this.txtDescription.ReadOnly = true;
			this.txtDescription.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedVertical;
			this.txtDescription.Size = new System.Drawing.Size(568, 112);
			this.txtDescription.TabIndex = 4;
			this.txtDescription.Text = "";
			// 
			// label10
			// 
			this.label10.Location = new System.Drawing.Point(32, 16);
			this.label10.Name = "label10";
			this.label10.Size = new System.Drawing.Size(56, 23);
			this.label10.TabIndex = 14;
			this.label10.Text = "Release:";
			this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// txtReleaseName
			// 
			this.txtReleaseName.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.txtReleaseName.Location = new System.Drawing.Point(96, 16);
			this.txtReleaseName.Name = "txtReleaseName";
			this.txtReleaseName.Size = new System.Drawing.Size(168, 23);
			this.txtReleaseName.TabIndex = 15;
			this.txtReleaseName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(288, 56);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(56, 23);
			this.label1.TabIndex = 17;
			this.label1.Text = "Priority:";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// txtPriority
			// 
			this.txtPriority.Location = new System.Drawing.Point(352, 56);
			this.txtPriority.Name = "txtPriority";
			this.txtPriority.ReadOnly = true;
			this.txtPriority.Size = new System.Drawing.Size(40, 20);
			this.txtPriority.TabIndex = 2;
			this.txtPriority.TabStop = false;
			this.txtPriority.Text = "";
			// 
			// txtSeverity
			// 
			this.txtSeverity.Location = new System.Drawing.Point(488, 56);
			this.txtSeverity.Name = "txtSeverity";
			this.txtSeverity.ReadOnly = true;
			this.txtSeverity.Size = new System.Drawing.Size(40, 20);
			this.txtSeverity.TabIndex = 3;
			this.txtSeverity.TabStop = false;
			this.txtSeverity.Text = "";
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(424, 56);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(56, 23);
			this.label2.TabIndex = 17;
			this.label2.Text = "Severity:";
			this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// cbPeople
			// 
			this.cbPeople.Location = new System.Drawing.Point(96, 224);
			this.cbPeople.Name = "cbPeople";
			this.cbPeople.Size = new System.Drawing.Size(184, 21);
			this.cbPeople.TabIndex = 1;
			this.cbPeople.Text = "Select a user...";
			// 
			// label4
			// 
			this.label4.Location = new System.Drawing.Point(16, 272);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(64, 23);
			this.label4.TabIndex = 11;
			this.label4.Text = "Resolution:";
			this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// rtfResolution
			// 
			this.rtfResolution.Location = new System.Drawing.Point(96, 264);
			this.rtfResolution.Name = "rtfResolution";
			this.rtfResolution.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedVertical;
			this.rtfResolution.Size = new System.Drawing.Size(568, 112);
			this.rtfResolution.TabIndex = 2;
			this.rtfResolution.Text = "";
			// 
			// txtAssignedTo
			// 
			this.txtAssignedTo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.txtAssignedTo.Location = new System.Drawing.Point(96, 56);
			this.txtAssignedTo.Name = "txtAssignedTo";
			this.txtAssignedTo.Size = new System.Drawing.Size(168, 23);
			this.txtAssignedTo.TabIndex = 15;
			this.txtAssignedTo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// label7
			// 
			this.label7.Location = new System.Drawing.Point(16, 56);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(72, 23);
			this.label7.TabIndex = 14;
			this.label7.Text = "Assigned To:";
			this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// ResolveBug
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(688, 462);
			this.Controls.AddRange(new System.Windows.Forms.Control[] {
																		  this.cbPeople,
																		  this.label11,
																		  this.label3,
																		  this.label5,
																		  this.txtDescription,
																		  this.label10,
																		  this.txtReleaseName,
																		  this.OKBtn,
																		  this.cancelButton,
																		  this.label1,
																		  this.txtPriority,
																		  this.txtSeverity,
																		  this.label2,
																		  this.label4,
																		  this.rtfResolution,
																		  this.txtAssignedTo,
																		  this.label7});
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "ResolveBug";
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "New Bug";
			this.ResumeLayout(false);

		}
		#endregion

		////////////////////////////////////////////////////////////
		/// <summary>
		/// Handle Cancel button (hide ourselves, do nothing)
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		////////////////////////////////////////////////////////////
		private void CancelButton_Click(object sender, System.EventArgs e)
		{
			this.Hide();		
		}

		////////////////////////////////////////////////////////////
		/// <summary>
		/// Update the current BUG record
		/// Validate Data
		/// WriteDB
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		////////////////////////////////////////////////////////////
		private void OKBtn_Click(object sender, System.EventArgs e)
		{
			DataRow dr;

			if (rtfResolution.Text == "" || this.cbPeople.SelectedText.StartsWith("Select"))
			{
				MessageBox.Show("You must enter a resolution description and pick a person to resolve a bug.");
				return;
			}

			dr = theCurrentBug;
			dr["resolvedByOID"] = personToOID[cbPeople.SelectedItem];
			dr["status"] = "CLOSED";
			dr["resolution"] = this.rtfResolution.Text;
			dr["completionTimestamp"] = DateTime.Now;

			BTExec.getSingleton().exec("resolve.bug",BTXML.rowToXML(dr));
			this.Hide();
		}
	}
}
////////////////////////////////////////////////////////////
///
/// This code is copyright (c) 2002, by Michael G. Lehman
/// It may be used for no charge for non-commerical purposes
/// including education and training uses.
/// 
/// For commercial distribution or licensing please contact
/// http://www.mikelehman.com
/// 
/// I provide software development and consulting services
/// and am always looking for new clients.
/// 
////////////////////////////////////////////////////////////
