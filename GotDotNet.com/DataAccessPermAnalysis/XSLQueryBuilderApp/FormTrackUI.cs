using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace XSLQueryBuilderApp
{
	/// <summary>
	/// Summary description for FrmTrackView.
	/// </summary>
	public class FormTrackUI : System.Windows.Forms.Form,ITrackUI
	{

		protected DataAccessProvider dataAccessProvider;

		private System.Windows.Forms.Button btnConnect;
		private System.Windows.Forms.TextBox txtPipeIndex;
		private System.Windows.Forms.CheckBox chkPipe;
		private System.Windows.Forms.Button btnCancel;
		private System.Windows.Forms.Button btnOK;
		private System.Windows.Forms.TextBox txtDataSourceLabel;
		private System.Windows.Forms.Label lblDataSourceLabel;
		private System.Windows.Forms.TextBox txtLabel;
		private System.Windows.Forms.Label lblLabel;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public FormTrackUI()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
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
			this.btnConnect = new System.Windows.Forms.Button();
			this.txtPipeIndex = new System.Windows.Forms.TextBox();
			this.chkPipe = new System.Windows.Forms.CheckBox();
			this.btnCancel = new System.Windows.Forms.Button();
			this.btnOK = new System.Windows.Forms.Button();
			this.txtDataSourceLabel = new System.Windows.Forms.TextBox();
			this.lblDataSourceLabel = new System.Windows.Forms.Label();
			this.txtLabel = new System.Windows.Forms.TextBox();
			this.lblLabel = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// btnConnect
			// 
			this.btnConnect.Location = new System.Drawing.Point(264, 56);
			this.btnConnect.Name = "btnConnect";
			this.btnConnect.TabIndex = 48;
			this.btnConnect.Text = "Connect...";
			this.btnConnect.Click += new System.EventHandler(this.btnConnect_Click);
			// 
			// txtPipeIndex
			// 
			this.txtPipeIndex.Enabled = false;
			this.txtPipeIndex.Location = new System.Drawing.Point(64, 232);
			this.txtPipeIndex.Name = "txtPipeIndex";
			this.txtPipeIndex.Size = new System.Drawing.Size(168, 20);
			this.txtPipeIndex.TabIndex = 47;
			this.txtPipeIndex.Text = "";
			// 
			// chkPipe
			// 
			this.chkPipe.Location = new System.Drawing.Point(8, 232);
			this.chkPipe.Name = "chkPipe";
			this.chkPipe.Size = new System.Drawing.Size(48, 16);
			this.chkPipe.TabIndex = 46;
			this.chkPipe.Text = "Pipe";
			this.chkPipe.CheckedChanged += new System.EventHandler(this.chkPipe_CheckedChanged);
			// 
			// btnCancel
			// 
			this.btnCancel.Anchor = (System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right);
			this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btnCancel.Location = new System.Drawing.Point(228, 320);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.Size = new System.Drawing.Size(96, 24);
			this.btnCancel.TabIndex = 45;
			this.btnCancel.Text = "Cancel";
			this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
			// 
			// btnOK
			// 
			this.btnOK.Anchor = (System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left);
			this.btnOK.Location = new System.Drawing.Point(36, 320);
			this.btnOK.Name = "btnOK";
			this.btnOK.Size = new System.Drawing.Size(96, 24);
			this.btnOK.TabIndex = 44;
			this.btnOK.Text = "OK";
			this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
			// 
			// txtDataSourceLabel
			// 
			this.txtDataSourceLabel.Enabled = false;
			this.txtDataSourceLabel.Location = new System.Drawing.Point(108, 55);
			this.txtDataSourceLabel.Name = "txtDataSourceLabel";
			this.txtDataSourceLabel.Size = new System.Drawing.Size(136, 20);
			this.txtDataSourceLabel.TabIndex = 42;
			this.txtDataSourceLabel.Text = "";
			// 
			// lblDataSourceLabel
			// 
			this.lblDataSourceLabel.Location = new System.Drawing.Point(4, 56);
			this.lblDataSourceLabel.Name = "lblDataSourceLabel";
			this.lblDataSourceLabel.Size = new System.Drawing.Size(108, 16);
			this.lblDataSourceLabel.TabIndex = 41;
			this.lblDataSourceLabel.Text = "Data Source Label :";
			// 
			// txtLabel
			// 
			this.txtLabel.Location = new System.Drawing.Point(108, 24);
			this.txtLabel.Name = "txtLabel";
			this.txtLabel.Size = new System.Drawing.Size(216, 20);
			this.txtLabel.TabIndex = 40;
			this.txtLabel.Text = "untitled";
			// 
			// lblLabel
			// 
			this.lblLabel.Location = new System.Drawing.Point(68, 24);
			this.lblLabel.Name = "lblLabel";
			this.lblLabel.Size = new System.Drawing.Size(40, 16);
			this.lblLabel.TabIndex = 39;
			this.lblLabel.Text = "Label :";
			// 
			// FormTrackUI
			// 
			this.AcceptButton = this.btnOK;
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.CancelButton = this.btnCancel;
			this.ClientSize = new System.Drawing.Size(352, 373);
			this.Controls.AddRange(new System.Windows.Forms.Control[] {
																		  this.txtDataSourceLabel,
																		  this.btnConnect,
																		  this.txtPipeIndex,
																		  this.chkPipe,
																		  this.btnCancel,
																		  this.btnOK,
																		  this.lblDataSourceLabel,
																		  this.txtLabel,
																		  this.lblLabel});
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.Name = "FormTrackUI";
			this.ShowInTaskbar = false;
			this.Text = "FormTrackUI";
			this.Load += new System.EventHandler(this.FrmTrackView_Load);
			this.ResumeLayout(false);

		}
		#endregion

		private void FrmTrackView_Load(object sender, System.EventArgs e)
		{
			setupTrackValuesToView();
		}

		protected virtual void setupTrackValuesToView() 
		{
			if(track != null) 
			{
				txtLabel.Text = track.label;
				setupDataAccessProvider();
				setupPipe();
			}
		}

		private void setupDataAccessProvider() 
		{
			if(track.dataAccessProvider == null) 
			{
				dataAccessProvider = new DataAccessProvider();
			} 
			else 
			{
				if(!track.dataAccessProvider.resolved)
					tryToResolveProvider(track.dataAccessProvider);
				txtDataSourceLabel.Text = track.dataAccessProvider.label;
				dataAccessProvider = track.dataAccessProvider;				
			}

			if(dataAccessProvider.resolved)
				onDataAccessProviderSet();
		}

		private void tryToResolveProvider(DataAccessProvider provider) 
		{
			AccessProvidersStorage providersStorage = AccessProvidersStorage.getStorage();
			DataAccessProvider cachedProvider;

			if(providersStorage.providers.ContainsKey(provider.label)) 
			{
				cachedProvider = (DataAccessProvider)providersStorage.providers[provider.label];
				if(cachedProvider.sameDBUser(provider) && cachedProvider.resolved)
					provider.setProviderValues(cachedProvider);
			} 
		}

		protected virtual void onDataAccessProviderSet() 
		{
		}

		private void setupPipe() 
		{
			if(track.pipe != Track.PIPE_NONE) 
			{
				chkPipe.Checked = true;
				if(track.pipe != Track.PIPE_PREV)
					txtPipeIndex.Text = track.pipe.ToString();
				onPipeChecked();
			} 
		}

		private void onPipeChecked() 
		{
			txtPipeIndex.Enabled = chkPipe.Checked;
		}

		private void btnConnect_Click(object sender, System.EventArgs e)
		{
			FormDBConnect frmDBConnect = new FormDBConnect();

			frmDBConnect.setProviderToConnect(dataAccessProvider);
			if(frmDBConnect.ShowDialog(this) == DialogResult.OK) 
			{
				if(!dataAccessProvider.sameDBUser(frmDBConnect.dataAccessProvider)) 
					onBeforeDataAccessProviderChange();
				dataAccessProvider.setProviderValues(frmDBConnect.dataAccessProvider);
				txtDataSourceLabel.Text = dataAccessProvider.label;
				onDataAccessProviderSet();
			}
		}

		protected virtual void onBeforeDataAccessProviderChange() {}

		private void chkPipe_CheckedChanged(object sender, System.EventArgs e)
		{
			onPipeChecked();
		}

		private void btnCancel_Click(object sender, System.EventArgs e)
		{
			this.DialogResult = DialogResult.Cancel;
			Close();
		}

		private void btnOK_Click(object sender, System.EventArgs e)
		{
			if(validateTrackDisplayContent()) 
			{
				saveViewToTrackValues();
				this.DialogResult = DialogResult.OK;
				Close();
			}
		}

		protected virtual bool validateTrackDisplayContent() 
		{
			bool result;

			if("" == txtLabel.Text) 
			{
				MessageBox.Show("Track label is missing, please type one and try again");
				result = false;
			} 
			else
				result = true;

			return result;
		}

		protected virtual void saveViewToTrackValues() 
		{
			track.label = txtLabel.Text;
			track.dataAccessProvider = dataAccessProvider;

			if(chkPipe.Checked)
				if("" == txtPipeIndex.Text)
					track.pipe = Track.PIPE_PREV;
				else
					track.pipe = Int32.Parse(txtPipeIndex.Text);
			else
				track.pipe = Track.PIPE_NONE;
		}

		public virtual ITrack track 
		{
			get 
			{
				return null;
			}
			set 
			{
			}
		}	


	}
}
