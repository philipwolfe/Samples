using System;
using System.Collections;
using System.ComponentModel;
using System.Web;
using System.Web.SessionState;
using System.IO; 

              

 
namespace FormProcessingSample 
{
	/// <summary>
	/// Summary description for Global.
	/// </summary>
	public class Global : System.Web.HttpApplication
	{
		protected void Application_Start(Object sender, EventArgs e)
		{
			CacheStatesDataset();
		}
 
		protected void Session_Start(Object sender, EventArgs e)
		{

		}

		protected void Application_BeginRequest(Object sender, EventArgs e)
		{

		}

		protected void Application_EndRequest(Object sender, EventArgs e)
		{

		}

		protected void Session_End(Object sender, EventArgs e)
		{

		}

		protected void Application_End(Object sender, EventArgs e)
		{

		}

		private void CacheStatesDataset()
		{
		
			//Stores a DataSet of state names and abbreviations in the ASP.NET cache
			//This is cached because the list of valid states will be used on many web forms
			//and it does not change frequently.  The list of valid states are read in from
			//the XML document States.xml
			System.Data.DataSet dsStates  = new System.Data.DataSet();
			System.IO.FileStream fs;
			System.IO.StreamReader xmlStream;
        
			//Open the XML file
			fs = new FileStream(Server.MapPath("States.xml"), FileMode.Open, FileAccess.Read);
        
			//Read the XML document into a DataSet
			xmlStream = new StreamReader(fs);
			dsStates.ReadXml(xmlStream);
        
			//Close the XML file        
			fs.Close();
        
			//Save the DataSet in the ASP.NET cache with the key "dsStates"
			System.Web.HttpRuntime.Cache.Insert("dsStates",dsStates);
		}

	}
}

