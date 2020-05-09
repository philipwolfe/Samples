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

/// For impersonation
using System.Web.Security;
using System.Security.Principal;
using System.Runtime.InteropServices;

/// for dpapi
using System.Text;
using System.Configuration;
using Dpapi;

namespace WebSample
{
	/// <summary>
	/// Impersonating another user.
	/// </summary>
	public class WebForm1 : System.Web.UI.Page
	{

		public const int LOGON32_LOGON_INTERACTIVE = 2;
		public const int LOGON32_PROVIDER_DEFAULT = 0;

		WindowsImpersonationContext impersonationContext; 

		[DllImport("advapi32.dll", CharSet=CharSet.Auto)]
		public static extern int LogonUser(String lpszUserName, 
			String lpszDomain,
			String lpszPassword,
			int dwLogonType, 
			int dwLogonProvider,
			ref IntPtr phToken);
		[DllImport("advapi32.dll", CharSet=System.Runtime.InteropServices.CharSet.Auto, SetLastError=true)]
		public extern static int DuplicateToken(IntPtr hToken, 
			int impersonationLevel,  
			ref IntPtr hNewToken);

		private void Page_Load(object sender, System.EventArgs e)
		{
			DataProtector dp = new DataProtector(Store.MachineStore);
			string passWord = "";
			try
			{
				string cipherPassWord = ConfigurationSettings.AppSettings["passWord"];
				byte[] bytepassWord = Convert.FromBase64String(cipherPassWord);
				passWord = Encoding.ASCII.GetString(dp.Decrypt(bytepassWord));
			}
			catch(Exception ex)
			{
				Response.Write("Exception: " + ex.Message);
			}

			if(impersonateValidUser("user", "domain", passWord))
			{
				//Insert your code that runs under the security context of a specific user here.
				Response.Write("Success!");
				undoImpersonation();
			}
			else
			{
				//Your impersonation failed. Therefore, include a fail-safe mechanism here.
				Response.Write("Failure!");
			}
		}

		private bool impersonateValidUser(String userName, String domain, String password)
		{
			WindowsIdentity tempWindowsIdentity;
			IntPtr token = IntPtr.Zero;
			IntPtr tokenDuplicate = IntPtr.Zero;

			if(LogonUser(userName, domain, password, LOGON32_LOGON_INTERACTIVE, 
				LOGON32_PROVIDER_DEFAULT, ref token) != 0)
			{
				if(DuplicateToken(token, 2, ref tokenDuplicate) != 0) 
				{
					tempWindowsIdentity = new WindowsIdentity(tokenDuplicate);
					impersonationContext = tempWindowsIdentity.Impersonate();
					if (impersonationContext != null)
						return true;
					else
						return false; 
				}
				else
					return false;
			} 
			else
				return false;
		}
		private void undoImpersonation()
		{
			impersonationContext.Undo();
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
			this.Load += new System.EventHandler(this.Page_Load);
		}
		#endregion
	}
}
