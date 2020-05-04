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
using System.Configuration;
using PAB.Data.Utils;

using System.Data.SqlClient;

namespace AppRestart
{
	public partial class Report : System.Web.UI.Page
	{

        SqlDataReader rdr = null;
        SqlConnection cn = null;
        SqlCommand cmd = null;	

		protected void Page_Load(object sender, System.EventArgs e)
		{
					 
			string strSQL="";
			if(Request.QueryString["EvtId"]!=null)
			{
				strSQL="SELECT * FROM LOGITEMS WHERE EventId='" +
					Request.QueryString["EvtId"].ToString()+"' ";	
			}
			else

			{
					strSQL="SELECT TOP 100 * FROM LOGITEMS";									
			}
			strSQL+=" order by LogDateTime DESC";			
			
	string dbConnString=
		ConfigurationManager.AppSettings["exceptionLogConnString"].ToString();
			 cn = new SqlConnection(dbConnString);      			 
			cmd = new SqlCommand(strSQL,cn);
			cn.Open();
			try
			{		
				rdr=cmd.ExecuteReader(CommandBehavior.CloseConnection);
				DataGrid1.DataSource=rdr;
				DataGrid1.DataBind();				
			}
			catch(Exception ex)
			{
				System.Diagnostics.Debug.Write(ex.Message );
			}
			finally
			{
				if(rdr!=null)
				rdr.Close();
                cn.Close();
			}			
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

		}
		#endregion

        protected void Button1_Click(object sender, EventArgs e)
        {
            string dbConnString =
        ConfigurationManager.AppSettings["exceptionLogConnString"].ToString();
        cn = new SqlConnection(dbConnString);
        cmd = new SqlCommand();
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.CommandText = "dbo.Get_LogItems";
         cmd.Connection = cn;
         cmd.Parameters.AddWithValue("@EventId", null);
         cmd.Parameters.AddWithValue("@App_Name", this.txtAppName.Text == String.Empty?(object)DBNull.Value:txtAppName.Text);
         cmd.Parameters.AddWithValue("@BeginDate", dtBeginDate.Text==""?DateTime.Now.AddDays(-365):Convert.ToDateTime(dtBeginDate.Text));
         cmd.Parameters.AddWithValue("@EndDate", dtEndDate.Text == "" ? DateTime.Now.AddDays(1) : Convert.ToDateTime(dtEndDate.Text));
         cmd.Parameters.AddWithValue("@StackTrace", this.txtStackTrace.Text == "" ? (object)DBNull.Value : txtStackTrace.Text);
         cmd.Parameters.AddWithValue("@Message", this.txtMessage.Text == "" ? (object)DBNull.Value : txtMessage.Text);
         cmd.Parameters.AddWithValue("@TargetSite", this.txtTargetSite.Text == "" ? (object)DBNull.Value : txtTargetSite.Text);
         cmd.Parameters.AddWithValue("@Referer", this.txtReferer.Text == "" ? (object)DBNull.Value : txtReferer.Text);
         cmd.Parameters.AddWithValue("@Path", this.txtPath.Text == "" ? (object)DBNull.Value : txtPath.Text);
         SqlDataReader rdr = null;
         try
         {
             cn.Open();
             rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
             DataGrid1.DataSource = rdr;
             DataGrid1.DataBind();
         }
         catch (Exception ex)
         {

             System.Diagnostics.Debug.WriteLine(ex.Message + ex.StackTrace);
         }
         finally
         {
             rdr.Close();
         }
   }

        protected void btnException_Click(object sender, EventArgs e)
        {
            throw new ApplicationException("UH-OH! Something bad happened!");
        }

        protected void btnTruncate_Click(object sender, EventArgs e)
        {
              string dbConnString =
        ConfigurationManager.AppSettings["exceptionLogConnString"].ToString();
              try
              {
                  SqlHelper.ExecuteNonQuery(dbConnString, CommandType.Text, "Truncate table dbo.LogItems");
              }
              catch (Exception ex)
              {
                  System.Diagnostics.Debug.WriteLine(ex.Message + ex.StackTrace);
              }
       
            }

        protected void Button2_Click(object sender, EventArgs e)
        {
            string dbConnString =
    ConfigurationManager.AppSettings["exceptionLogConnString"].ToString();
            cn = new SqlConnection(dbConnString);
            cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "dbo.GetProviderEvents";
            cmd.Connection = cn;
            SqlDataReader rdr=null;
            try
            {
                cn.Open();
                rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                DataGrid1.DataSource = rdr;
                DataGrid1.DataBind();
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message + ex.StackTrace);
            }
            finally
            {
                rdr.Close();
            }

        }

        protected void Button3_Click(object sender, EventArgs e)
        {          
            string dbConnString =
             ConfigurationManager.AppSettings["exceptionLogConnString"].ToString();
            cn = new SqlConnection(dbConnString);
            cmd = new SqlCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "TRUNCATE TABLE dbo.aspnet_WebEvent_Events";
            cmd.Connection = cn;
            try
            {
                cn.Open();
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message + ex.StackTrace);
            }
            finally
            {
                cn.Close();
                cmd.Dispose();
            }        
        }
	}
}
