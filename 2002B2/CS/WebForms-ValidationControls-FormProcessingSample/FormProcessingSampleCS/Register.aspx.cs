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

namespace FormProcessingSample
{
	/// <summary>
	/// Summary description for Register.
	/// </summary>
	public class Register : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.RequiredFieldValidator txtNameValReq;
		protected System.Web.UI.WebControls.DropDownList ddlState;
		protected System.Web.UI.HtmlControls.HtmlInputText txtZipCode;
		protected System.Web.UI.HtmlControls.HtmlInputButton Submit1;
		protected System.Web.UI.WebControls.RequiredFieldValidator txtEmailValReq;
		protected System.Web.UI.HtmlControls.HtmlInputText txtCity;
		protected System.Web.UI.HtmlControls.HtmlInputText txtName;
		protected System.Web.UI.WebControls.RequiredFieldValidator ddlStateValReq;
		protected System.Web.UI.WebControls.RequiredFieldValidator txtCityValReq;
		protected System.Web.UI.WebControls.RequiredFieldValidator txtZipCodeValReq;
		protected System.Web.UI.WebControls.RegularExpressionValidator txtZipCodeValReg;
		protected System.Web.UI.WebControls.RegularExpressionValidator txtEmailValReg;
		protected System.Web.UI.HtmlControls.HtmlInputText txtEmail;
	
		public Register()
		{
			Page.Init += new System.EventHandler(Page_Init);
		}

		protected void Page_Load(object sender, System.EventArgs e)
		{

			if (this.IsPostBack != true)
			{
				// Put user code to initialize the page here

				// Put user code to initialize the page here
				//The following validation control properties are duplicated here for demo purposes
				//so they can be documented.

				//Two validation controls are used for both the Zip Code and Email fields
				//(a Required validation control and a Regular Expression validation control)
				//Because the error messages are mutually exclusive for each pair, 
				//the Display property is set to "Dynamic" so each message can be displayed
				//in the same location on the form. 
				//txtZipCodeValReq.Display = System.Web.UI.WebControls.ValidatorDisplay.Dynamic;
				//txtZipCodeValReg.Display = System.Web.UI.WebControls.ValidatorDisplay.Dynamic;
				//txtEmailValReq.Display = System.Web.UI.WebControls.ValidatorDisplay.Dynamic;
				//txtEmailValReg.Display = System.Web.UI.WebControls.ValidatorDisplay.Dynamic;

				//FillComboBox();
				System.Data.DataSet dsStates = new System.Data.DataSet();

				//Retrieve the DataSet from the cache
				dsStates = (System.Data.DataSet) (System.Web.HttpRuntime.Cache["dsStates"]);

				this.ddlState.DataSource = dsStates.Tables[0].DefaultView;
				this.ddlState.DataValueField = "abbrev";
				this.ddlState.DataTextField = "name";
				this.ddlState.DataBind();


				//Regular Expression validators are used to validate the Zip Code and Email address.
				//Built-in standard expressions exist for both field formats.  The standard
				//expressions are available from the property builder for the ValidationExpression property.

				//U.S. ZIP Code standard expression
				//this.txtZipCodeValReg.Enabled = false;
				//this.txtEmailValReg.Enabled = false;
				//txtZipCodeValReg.ValidationExpression = Path.DirectorySeparatorChar + "d{5}(-" + Path.DirectorySeparatorChar + "d{4})?";
				//Internet E-mail Address standard expression
				//txtEmailValReg.ValidationExpression = "[\w-]+(\+[\w-]*)?@([\w-]+\.)+[\w-]+";

			}
		}

		
		protected void Page_Init(object sender, EventArgs e)
		{
			//
			// CODEGEN: This call is required by the ASP.NET Windows Form Designer.
			//
			InitializeComponent();
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
			Response.Redirect("Confirm.aspx?txtName=" + Request.Form["txtName"] + "&txtCity=" + Request.Form["txtCity"] + "&txtState=" + Request.Form["ddlState"] + "&txtZipCode= " + Request.Form["txtZipCode"] + "&txtEmail=" + Request.Form["txtEmail"]);	
		}
	}
}
