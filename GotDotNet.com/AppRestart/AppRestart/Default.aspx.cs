using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Diagnostics ;
using System.Reflection ;
using System.Net;
using System.IO;

namespace AppRestart
{
    public partial class _Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {


        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Restart();
        }

 private void Restart()
        {
            
            System.Web.HttpRuntime.UnloadAppDomain();
            WebClient myWebClient=null;
            try
            {
                string URL = "http://localhost/AppRestart/Default.aspx";
                myWebClient = new WebClient();
                byte[] myDataBuffer = myWebClient.DownloadData(URL);
            }
            catch
            {
            }
            finally
            {
                myWebClient.Dispose();
            } 
 }

        protected void Button2_Click(object sender, EventArgs e)
        {
            throw new ApplicationException("Honey, I blew up the Kids!");
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["test"].ConnectionString;
            System.Web.Management.SqlServices.Install("TEST",System.Web.Management.SqlFeatures.SqlWebEventProvider,connectionString);
        }



















}
  
    }

