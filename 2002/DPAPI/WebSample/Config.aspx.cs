using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Web;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Text;
using Dpapi;

namespace WebSample
{
	/// <summary>
	/// Summary description for Config.
	/// </summary>
	public class Config : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.Button btnEncrypt;
		protected System.Web.UI.WebControls.Label lblDataToEncrypt;
		protected System.Web.UI.WebControls.Label lblEncryptedData;
		protected System.Web.UI.WebControls.Label lblDecryptedData;
		protected System.Web.UI.WebControls.Button btnDecrypt;
		protected System.Web.UI.WebControls.TextBox txtEncryptedData;
		protected System.Web.UI.WebControls.TextBox txtDecryptedData;
		protected System.Web.UI.WebControls.TextBox txtDataToEncrypt;
		protected System.Web.UI.WebControls.Label lblError;
	
		private void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here
		}

		#region Web Form Designer generated code
		override protected void OnInit(EventArgs e)
		{
			//
			// CODEGEN: This call is required by the ASP.NET Web Form Designer.
			//
			InitializeComponent();
			base.OnInit(e);
		}
		
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{    
			this.btnEncrypt.Click += new System.EventHandler(this.btnEncrypt_Click);
			this.btnDecrypt.Click += new System.EventHandler(this.btnDecrypt_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void btnEncrypt_Click(object sender, System.EventArgs e)
		{
			DataProtector dp = new DataProtector(Store.MachineStore);

			try
			{
				byte[] dataToEncrypt = Encoding.ASCII.GetBytes(txtDataToEncrypt.Text);
				txtEncryptedData.Text = Convert.ToBase64String(dp.Encrypt(dataToEncrypt));
			}
			catch(Exception ex)
			{
				lblError.Text = "Exception: " + ex.Message;
				return;
			}
			lblError.Text = "";
		}

		private void btnDecrypt_Click(object sender, System.EventArgs e)
		{
			DataProtector dp = new DataProtector(Store.MachineStore);

			try
			{
				byte[] dataToDecrypt = Convert.FromBase64String(txtEncryptedData.Text);
				txtDecryptedData.Text = Encoding.ASCII.GetString(dp.Decrypt(dataToDecrypt));
			}
			catch(Exception ex)
			{
				lblError.Text = "Exception: " + ex.Message;
			}
			lblError.Text = "";
		}


	}
}
