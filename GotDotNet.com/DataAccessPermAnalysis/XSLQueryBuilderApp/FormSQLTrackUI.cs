using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;

using System.Windows.Forms;


namespace XSLQueryBuilderApp
{
	public class FormSQLTrackUI : XSLQueryBuilderApp.FormTrackUI
	{

		private System.Windows.Forms.Button btnBrowseTable;
		protected System.Windows.Forms.TextBox txtMainTable;
		private System.Windows.Forms.Label lblMainTable;
		
		private System.ComponentModel.IContainer components = null;

		public FormSQLTrackUI()
		{
			// This call is required by the Windows Form Designer.
			InitializeComponent();

			// TODO: Add any initialization after the InitializeComponent call
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

		#region Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.btnBrowseTable = new System.Windows.Forms.Button();
			this.txtMainTable = new System.Windows.Forms.TextBox();
			this.lblMainTable = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// btnBrowseTable
			// 
			this.btnBrowseTable.Enabled = false;
			this.btnBrowseTable.Location = new System.Drawing.Point(264, 94);
			this.btnBrowseTable.Name = "btnBrowseTable";
			this.btnBrowseTable.Size = new System.Drawing.Size(80, 24);
			this.btnBrowseTable.TabIndex = 60;
			this.btnBrowseTable.Text = "Browse...";
			this.btnBrowseTable.Click += new System.EventHandler(this.btnBrowseTable_Click);
			// 
			// txtMainTable
			// 
			this.txtMainTable.Enabled = false;
			this.txtMainTable.Location = new System.Drawing.Point(88, 96);
			this.txtMainTable.Name = "txtMainTable";
			this.txtMainTable.ReadOnly = true;
			this.txtMainTable.Size = new System.Drawing.Size(168, 20);
			this.txtMainTable.TabIndex = 59;
			this.txtMainTable.Text = "";
			// 
			// lblMainTable
			// 
			this.lblMainTable.Location = new System.Drawing.Point(16, 97);
			this.lblMainTable.Name = "lblMainTable";
			this.lblMainTable.Size = new System.Drawing.Size(67, 17);
			this.lblMainTable.TabIndex = 58;
			this.lblMainTable.Text = "Main Table :";
			// 
			// FormSQLTrackUI
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(354, 375);
			this.Controls.AddRange(new System.Windows.Forms.Control[] {
																		  this.btnBrowseTable,
																		  this.txtMainTable,
																		  this.lblMainTable});
			this.Name = "FormSQLTrackUI";
			this.ResumeLayout(false);

		}
		#endregion


		public override ITrack track 
		{
			get 
			{
				return sqlTrack;
			}
			set 
			{
				if(value is ISQLTrack)
					sqlTrack = (ISQLTrack)value;
				else
					sqlTrack = null;
			}
		}	

		public virtual ISQLTrack sqlTrack 
		{
			get 
			{
				return null;
			}
			set 
			{}
		}

		protected override void setupTrackValuesToView() 
		{
			base.setupTrackValuesToView();
			if(sqlTrack != null) 
				setupMainTable();
		}


		protected override void onBeforeDataAccessProviderChange() 
		{
			onMainTableReset();
			txtMainTable.Text = "";
		}

		protected override void onDataAccessProviderSet() 
		{
			btnBrowseTable.Enabled = true;
		}

		private void setupMainTable() 
		{
			if(sqlTrack.mainTable != "") 
			{
				txtMainTable.Text = sqlTrack.mainTable;
				onMainTableSet();
			}
		}

		protected virtual void onMainTableSet() {}

		protected override void saveViewToTrackValues() 
		{
			base.saveViewToTrackValues();
			sqlTrack.mainTable = txtMainTable.Text;
		}

		protected override bool validateTrackDisplayContent() 
		{
			bool result = base.validateTrackDisplayContent();

			if(result) 
			{
				if("" == txtMainTable.Text) 
				{
					MessageBox.Show("Main table is missing, please select one and try again");
					result = false;
				} 
				else
					result = true;
			}

			return result;
		}

		private void btnBrowseTable_Click(object sender, System.EventArgs e)
		{
			FormTableSelection tableSelection = new FormTableSelection();

			tableSelection.dataAccessProvider = dataAccessProvider;
			if(tableSelection.ShowDialog(this) == DialogResult.OK) 
			{
				if(txtMainTable.Text != tableSelection.selectedTable) 
				{
					onMainTableReset();
					txtMainTable.Text = tableSelection.selectedTable;
					onMainTableSet();
				}
			}
		}

		protected virtual void onMainTableReset() {}

	}
}


