using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace XSLQueryBuilderApp
{
	/// <summary>
	/// Summary description for FormDBConnect.
	/// </summary>
	public class FormDBConnect : System.Windows.Forms.Form
	{
		private DataAccessProvider _dataAccessProvider;

		private System.Windows.Forms.TextBox txtDataSourceLabel;
		private System.Windows.Forms.Label lblDataSourceLabel;
		private System.Windows.Forms.Label lblUsername;
		private System.Windows.Forms.TextBox txtUsername;
		private System.Windows.Forms.Label lblPassword;
		private System.Windows.Forms.TextBox txtPassword;
		private System.Windows.Forms.Label lblDataBaseName;
		private System.Windows.Forms.TextBox txtDataBaseName;
		private System.Windows.Forms.Button btnOK;
		private System.Windows.Forms.Button btnCancel;
		private System.Windows.Forms.Button btnBrowse;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public FormDBConnect()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();
			
			_dataAccessProvider = new DataAccessProvider();
		}

		public DataAccessProvider dataAccessProvider 
		{
			get 
			{
				return _dataAccessProvider;
			}
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
			this.txtDataSourceLabel = new System.Windows.Forms.TextBox();
			this.lblDataSourceLabel = new System.Windows.Forms.Label();
			this.lblUsername = new System.Windows.Forms.Label();
			this.txtUsername = new System.Windows.Forms.TextBox();
			this.lblPassword = new System.Windows.Forms.Label();
			this.txtPassword = new System.Windows.Forms.TextBox();
			this.lblDataBaseName = new System.Windows.Forms.Label();
			this.txtDataBaseName = new System.Windows.Forms.TextBox();
			this.btnOK = new System.Windows.Forms.Button();
			this.btnCancel = new System.Windows.Forms.Button();
			this.btnBrowse = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// txtDataSourceLabel
			// 
			this.txtDataSourceLabel.Location = new System.Drawing.Point(128, 38);
			this.txtDataSourceLabel.Name = "txtDataSourceLabel";
			this.txtDataSourceLabel.Size = new System.Drawing.Size(120, 20);
			this.txtDataSourceLabel.TabIndex = 0;
			this.txtDataSourceLabel.Text = "";
			// 
			// lblDataSourceLabel
			// 
			this.lblDataSourceLabel.Location = new System.Drawing.Point(24, 40);
			this.lblDataSourceLabel.Name = "lblDataSourceLabel";
			this.lblDataSourceLabel.Size = new System.Drawing.Size(104, 16);
			this.lblDataSourceLabel.TabIndex = 1;
			this.lblDataSourceLabel.Text = "Data Source Label :";
			// 
			// lblUsername
			// 
			this.lblUsername.Location = new System.Drawing.Point(64, 80);
			this.lblUsername.Name = "lblUsername";
			this.lblUsername.Size = new System.Drawing.Size(64, 16);
			this.lblUsername.TabIndex = 2;
			this.lblUsername.Text = "Username :";
			// 
			// txtUsername
			// 
			this.txtUsername.Location = new System.Drawing.Point(128, 79);
			this.txtUsername.Name = "txtUsername";
			this.txtUsername.Size = new System.Drawing.Size(120, 20);
			this.txtUsername.TabIndex = 3;
			this.txtUsername.Text = "";
			// 
			// lblPassword
			// 
			this.lblPassword.Location = new System.Drawing.Point(64, 123);
			this.lblPassword.Name = "lblPassword";
			this.lblPassword.Size = new System.Drawing.Size(64, 16);
			this.lblPassword.TabIndex = 4;
			this.lblPassword.Text = "Password :";
			// 
			// txtPassword
			// 
			this.txtPassword.Location = new System.Drawing.Point(128, 120);
			this.txtPassword.Name = "txtPassword";
			this.txtPassword.PasswordChar = '*';
			this.txtPassword.Size = new System.Drawing.Size(120, 20);
			this.txtPassword.TabIndex = 5;
			this.txtPassword.Text = "";
			// 
			// lblDataBaseName
			// 
			this.lblDataBaseName.Location = new System.Drawing.Point(60, 160);
			this.lblDataBaseName.Name = "lblDataBaseName";
			this.lblDataBaseName.Size = new System.Drawing.Size(64, 16);
			this.lblDataBaseName.TabIndex = 6;
			this.lblDataBaseName.Text = "Data Base :";
			// 
			// txtDataBaseName
			// 
			this.txtDataBaseName.Location = new System.Drawing.Point(128, 160);
			this.txtDataBaseName.Name = "txtDataBaseName";
			this.txtDataBaseName.Size = new System.Drawing.Size(120, 20);
			this.txtDataBaseName.TabIndex = 7;
			this.txtDataBaseName.Text = "";
			// 
			// btnOK
			// 
			this.btnOK.Location = new System.Drawing.Point(32, 200);
			this.btnOK.Name = "btnOK";
			this.btnOK.TabIndex = 8;
			this.btnOK.Text = "OK";
			this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
			// 
			// btnCancel
			// 
			this.btnCancel.Location = new System.Drawing.Point(184, 200);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.TabIndex = 9;
			this.btnCancel.Text = "Cancel";
			this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
			// 
			// btnBrowse
			// 
			this.btnBrowse.Location = new System.Drawing.Point(248, 36);
			this.btnBrowse.Name = "btnBrowse";
			this.btnBrowse.Size = new System.Drawing.Size(24, 24);
			this.btnBrowse.TabIndex = 10;
			this.btnBrowse.Text = "...";
			this.btnBrowse.Click += new System.EventHandler(this.btnBrowse_Click);
			// 
			// FormDBConnect
			// 
			this.AcceptButton = this.btnOK;
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(292, 245);
			this.Controls.AddRange(new System.Windows.Forms.Control[] {
																		  this.btnBrowse,
																		  this.btnCancel,
																		  this.btnOK,
																		  this.txtDataBaseName,
																		  this.lblDataBaseName,
																		  this.txtPassword,
																		  this.lblPassword,
																		  this.txtUsername,
																		  this.lblUsername,
																		  this.lblDataSourceLabel,
																		  this.txtDataSourceLabel});
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.Name = "FormDBConnect";
			this.ShowInTaskbar = false;
			this.Text = "Connect To DB";
			this.Load += new System.EventHandler(this.FormDBConnect_Load);
			this.ResumeLayout(false);

		}
		#endregion


		public void setProviderToConnect(DataAccessProvider provider) 
		{
			_dataAccessProvider.setProviderValues(provider);
		}

		private void btnOK_Click(object sender, System.EventArgs e)
		{
			if(validateInputProvider()) 
			{
				updateProvidersStorage();
				DialogResult = DialogResult.OK;
				Close();
			}
		}

		private bool validateInputProvider() 
		{
			bool result = false;
			DataAccessProvider providerCandidate;

			do 
			{

				if("" == txtDataSourceLabel.Text) 
				{
					MessageBox.Show("Data source label is missing, please type one and try again");
					continue;
				}
	
				providerCandidate = new  DataAccessProvider(
					txtDataSourceLabel.Text,
					txtUsername.Text,
					txtPassword.Text,
					txtDataBaseName.Text);
				if(!providerCandidate.testConnection()) 
				{
					MessageBox.Show("Connection failed:\n" + providerCandidate.testConnectionErrorMessage);
					continue;
				}

				_dataAccessProvider.setProviderValues(providerCandidate);
				result = true;
			} while(false);

			return result;
		}

		private void updateProvidersStorage() 
		{
			AccessProvidersStorage.getStorage().providers[_dataAccessProvider.label] =
				_dataAccessProvider;
		}

		private void btnCancel_Click(object sender, System.EventArgs e)
		{
			DialogResult = DialogResult.Cancel;
			Close();
		}

		private void FormDBConnect_Load(object sender, System.EventArgs e)
		{
			displayProviderDetails();
		}

		private void displayProviderDetails() 
		{
			txtDataSourceLabel.Text = _dataAccessProvider.label;
			txtUsername.Text = _dataAccessProvider.username;
			txtDataBaseName.Text = _dataAccessProvider.DBName;
			txtPassword.Text = _dataAccessProvider.password;
		}

		private void btnBrowse_Click(object sender, System.EventArgs e)
		{
			FormProvidersSelection providerSelection = new FormProvidersSelection();
			
			if(providerSelection.ShowDialog(this) == DialogResult.OK)  
			{
				dataAccessProvider.setProviderValues(providerSelection.resultProvider);
				displayProviderDetails();
			}
		}
	}
}
