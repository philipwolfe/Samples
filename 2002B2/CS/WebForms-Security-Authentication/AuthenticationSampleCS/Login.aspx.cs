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
using System.IO;
using System.Web.Security;

namespace AuthenticationSample
{
	/// <summary>
	/// Summary description for WebForm1.
	/// </summary>
	public class WebForm1 : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.CustomValidator LoginValCust;
		protected System.Web.UI.HtmlControls.HtmlInputButton Submit1;
		protected System.Web.UI.HtmlControls.HtmlInputText txtUser;
		protected System.Web.UI.HtmlControls.HtmlInputText txtPassword;

		//These constants match a valid user name and password prepopulated in the custom XML data store
		private const string VALID_USER = "User1";
		private const string VALID_PASSWORD = "Password1";
	
		public WebForm1()
		{
			Page.Init += new System.EventHandler(Page_Init);
		}

		protected void Page_Load(object sender, System.EventArgs e)
		{
			//Prefill the user and password fields with valid entries from the custom XML data store
            if(this.IsPostBack != true)
			{
				txtUser.Value = VALID_USER;
				txtPassword.Value = VALID_PASSWORD;
			}
		}

		protected void Page_Init(object sender, EventArgs e)
		{
			//
			// CODEGEN: This call is required by the ASP.NET Windows Form Designer.
			//
			InitializeComponent();
		}

		protected void LoginServerValidate(object sender, System.Web.UI.WebControls.ServerValidateEventArgs e)
		{
			
			//This function performs server-side validation for the custom validator control LoginValCust
			//The function name is referenced by the OnServerValidate event in the custom validator control HTML tag.
			if (AuthenticateUser(txtUser.Value, txtPassword.Value)==false)
			{e.IsValid = false;}
		}

		private bool AuthenticateUser(string strUser, string strPassword)
		{
			//This function validates the entered user name and password against the custom XML data store Users.xml        
			DataSet dsUsers = new DataSet();
			DataTable dtUsers ;
			DataRow [] drUsers;
			string strFilter;
			FileStream  fs; 
			StreamReader xmlStream;
			//Open the XML file
			fs = new FileStream(Server.MapPath("Users.xml"), FileMode.Open, FileAccess.Read);

			//Read the XML document into a DataSet
			xmlStream = new StreamReader(fs);
			dsUsers.ReadXml(xmlStream);

			//Close the XML file        
			fs.Close();

			
			//Create a data row array by filtering on the entered user name and password        
			dtUsers = dsUsers.Tables[0];
			strFilter = "name='" + strUser + "' and password='" + strPassword + "'";
			drUsers = dtUsers.Select(strFilter);

			if (drUsers.Length > 0) 
			{	
				//Upon success, set an in-memory authentication cookie for the user
				//The cookie name is set in the security section of the config.web file 
				FormsAuthentication.RedirectFromLoginPage(strUser, false);
				return true;
			}
			else
			{
				return false;
			}
		}

		#region Web Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{    
			this.Submit1.ServerClick += new System.EventHandler(this.Submit1_ServerClick);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void Submit1_ServerClick(object sender, System.EventArgs e)
		{

		}
	}
}
