using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;
using System.Reflection;
using System.Diagnostics;
using PAB.ExceptionHandler;
using System.Net; 

namespace AppRestart
{
    public class Global : System.Web.HttpApplication
    {
        public static string siteUrl = ConfigurationManager.AppSettings["siteUrl"];
        protected void Application_Start(object sender, EventArgs e)
        {
            Exception ex = new Exception("App started at " + DateTime.Now.ToString());            
            ExceptionLogger.HandleException(ex); 

        }

        protected void Application_Error(object sender, EventArgs e)
        {
            PAB.ExceptionHandler.ExceptionLogger.HandleException(Server.GetLastError().GetBaseException());
            Server.ClearError();
        }

        protected void Application_End(object sender, EventArgs e)
        {
            HttpRuntime runtime = 
                (HttpRuntime)typeof(System.Web.HttpRuntime).InvokeMember("_theRuntime",
                                 BindingFlags.NonPublic
                                 | BindingFlags.Static
                                 | BindingFlags.GetField,
                                 null,
                                 null,
                                 null);

            if (runtime == null)
                return;

            string shutDownMessage = 
                (string)runtime.GetType().InvokeMember("_shutDownMessage",
                                 BindingFlags.NonPublic
                                 | BindingFlags.Instance
                                 | BindingFlags.GetField,
                                 null,
                                 runtime,
                                 null);

            string shutDownStack = 
                (string)runtime.GetType().InvokeMember("_shutDownStack",
                               BindingFlags.NonPublic
                               | BindingFlags.Instance
                               | BindingFlags.GetField,
                               null,
                               runtime,
                               null);
            Exception ex = new Exception(shutDownMessage + ": " + shutDownStack);
            ExceptionLogger.HandleException(ex);   
        }        
    }
}