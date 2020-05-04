using System;
using System.Web;
using System.Diagnostics;
using System.Data;
using System.Data.SqlClient;
using System.Web.Mail;
using System.Text;
using System.Reflection;
using System.Configuration;
using System.Net.Mail;
namespace PAB.ExceptionHandler
{	 
	public static class  ExceptionLogger  
	{
		private static bool logExceptions = Convert.ToBoolean(ConfigurationManager.AppSettings["logExceptions"]);
		private static bool sendSysLogMessages =  Convert.ToBoolean(ConfigurationManager.AppSettings["sendSysLogMessages"]);
		private static string sysLogIp=ConfigurationManager.AppSettings["sysLogIp"];
       
       
	  



		public static Guid HandleException( Exception ex)
		{

			Guid retval = Guid.Empty;


            HttpContext ctx = null;
            try
            {
                ctx = HttpContext.Current;
            }
            catch { }

			string strData=String.Empty;
			Guid eventId =	System.Guid.NewGuid();			 
           string dbConnString=
	ConfigurationManager.AppSettings["exceptionLogConnString"].ToString();				
		 string referer=String.Empty;
         string sForm = String.Empty;
         try
         {
             if (ctx.Request.UrlReferrer  != null)
             {
                 referer = ctx.Request.UrlReferrer.ToString();
             }
         
		  sForm = 
			(ctx.Request.Form !=null)?ctx.Request.Form.ToString():String.Empty;
         }
          catch { }
      
       string logDateTime =DateTime.Now.ToString();
       string app_name = string.Empty;
       string app_path = String.Empty;
       try
       {
           app_path = ctx.Request.PhysicalApplicationPath;
       }
       catch { }

       if (app_path != "")
       {
           if (app_path.IndexOf("\\", 1) > 0)
           {
               char[] strArray = app_path.ToCharArray();
               Array.Reverse(strArray);
               app_path = new string(strArray);
               app_path = app_path.Substring(1, app_path.IndexOf("\\", 1) - 1);
               strArray = app_path.ToCharArray();
               Array.Reverse(strArray);
               app_name = new string(strArray);
           }
          
           
       }
       else { app_name = ""; }

       app_name = System.Environment.MachineName.ToString() + " / " + app_name;

       StringBuilder sb = new StringBuilder();
       foreach ( string key in ex.Data.Keys)
       {
           sb.Append(key);
           sb.Append("=");
           sb.Append(ex.Data[key].ToString());
           sb.Append("|");

       }
       if(sb.Length >0) sb.Remove(sb.Length-1, 1);
       string exData = sb.ToString();

       string sQuery = String.Empty;
       try
       {
           sQuery =
              (ctx.Request.QueryString != null) ? ctx.Request.QueryString.ToString() : String.Empty;
           strData = "\nSOURCE: " + ex.Source +
           "\nLogDateTime: " + logDateTime +
           "\nMESSAGE: " + ex.Message +
          "\nFORM: " + sForm +
          "\nQUERYSTRING: " + sQuery +
          "\nTARGETSITE: " + ex.TargetSite +
          "\nSTACKTRACE: " + ex.StackTrace +
          "\nData: " + exData +
          "\nAppName: " + app_name +
          "\nREFERER: " + referer;
       }
       catch { }
				
		if(sendSysLogMessages)Sender.Send(Sender.PriorityType.Critical,DateTime.Now,strData);	

		if(dbConnString.Length >0)
			{                 	
				SqlCommand cmd = new SqlCommand();
				cmd.CommandType=CommandType.StoredProcedure;
				cmd.CommandText="usp_WebAppLogsInsert";
				SqlConnection cn = new SqlConnection(dbConnString);
				cmd.Connection=cn;
				cn.Open();

                /*
                @EventID UNIQUEIDENTIFIER,
                @AppName varchar(150),
                @source varchar(100),
                @LogDateTime dateTime,
                @Message varchar(1000),
                @Form varchar(4000),
                @QueryString varchar(2000),
                @TargetSite varchar(300),
                @StackTrace varchar(4000),
                @Referer varchar(250),
                @Data varchar(500),
                @Path varchar(300)
                 */
 				
				try
				{	
				cmd.Parameters.Add(new SqlParameter("@EventId",eventId ));
                cmd.Parameters.Add(new SqlParameter("@App_Name", app_name));
                string source = ex.Source == null ? "" : ex.Source;                 

				cmd.Parameters.Add(new SqlParameter("@source", source));
				cmd.Parameters.Add(new SqlParameter("@LogDateTime", logDateTime));
				cmd.Parameters.Add(new SqlParameter("@Message",ex.Message));									
                cmd.Parameters.Add(new SqlParameter("@Form",sForm));
				cmd.Parameters.Add(new SqlParameter("@QueryString",sQuery));                
                string site = String.Empty;
                try
                {
                    site = ex.TargetSite.ToString();
                }
                catch { }
				cmd.Parameters.Add(new SqlParameter("@TargetSite", site));
                string stackTrace = String.Empty;
                if (ex.StackTrace != null) stackTrace = ex.StackTrace;               

				cmd.Parameters.Add(new SqlParameter("@StackTrace",stackTrace)); 
				cmd.Parameters.Add(new SqlParameter("@Referer",referer));
                cmd.Parameters.Add(new SqlParameter("@Data", exData));
                string path = "";
                 
                    try
                    {
                        path = HttpContext.Current.Request.PhysicalApplicationPath;
                    }
                    catch { }                 

                cmd.Parameters.Add(new SqlParameter("@Path", path));
				Object o = cmd.ExecuteScalar();
                    try
                    {
                        retval = (Guid)o;
                    }
                    catch { }						
				    }
				catch (Exception exc)
				{
				 // database error, not much you can do here except for debugging
	         	 System.Diagnostics.Debug.WriteLine(exc.Message);
				}
				finally
				{
				cmd.Dispose();
				cn.Close();
				}
			}
	

		string strEmails =ConfigurationManager.AppSettings["emailAddresses"].ToString();
		if (strEmails.Length >0) 
			{
				string[] emails = strEmails.Split(Convert.ToChar(";"));
            string newemails=String.Join(",",emails);
			
				string subject = "Web application error on " +System.Environment.MachineName;
				string detailURL=ConfigurationManager.AppSettings["detailURL"].ToString();
				string fullMessage=strData + " " + detailURL +"?EvtId="+ eventId.ToString() ;	
				
                System.Net.Mail.MailMessage msg = new System.Net.Mail.MailMessage();
                msg.To.Add(newemails);                
				msg.Body=fullMessage;                 
				msg.Subject =subject;
           
				try
				{

                    System.Net.Mail.SmtpClient client = new SmtpClient();                 
                    client.Send(msg);
									
				}
				catch (Exception ex2 )
				{
                    // send a syslog msg that email failed
                    Sender.Send("EMAIL: " + ex2.ToString());
					
					// nothing worthwhile to do here other than for debugging.
				}
		  }
		  return retval ;
     } // end method HandleException

   }
}