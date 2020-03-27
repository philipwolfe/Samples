<%@ Application Language="C#" %>
<%@ Import Namespace="System.Data.SqlClient" %>
<%@ Import Namespace="System.Diagnostics" %>

<script runat="server">
        
    void Application_Start(Object sender, EventArgs e) {
        // Code that runs on application startup
        
        // Build a connnection string to the AdventureWorks database
        SqlConnectionStringBuilder connectStringBuilder = new SqlConnectionStringBuilder();
        connectStringBuilder.DataSource = @"(local)\SQLEXPRESS";
        connectStringBuilder.AttachDBFilename = @"C:\Program Files\Microsoft SQL Server\MSSQL.1\MSSQL\Data\AdventureWorks_Data.mdf";
        connectStringBuilder.IntegratedSecurity = true;
        string connectString = connectStringBuilder.ConnectionString;

        // Build the SQL statement
        StringBuilder sb = new StringBuilder();
        sb.Append("IF EXISTS (SELECT * FROM dbo.sysobjects WHERE Name='DepartmentSample' AND TYPE='u')");
        sb.Append(" BEGIN");
        sb.Append(" DROP TABLE DepartmentSample");
        sb.Append(" END");
        sb.Append(" SELECT * INTO DepartmentSample");
        sb.Append(" FROM HumanResources.Department");
        string cmdText = sb.ToString();
        
        // Open connection to the database
        SqlConnection cnn = new SqlConnection(connectString);
        cnn.Open();

        // Do the command
        SqlCommand cmd = new SqlCommand(cmdText, cnn);
        cmd.ExecuteNonQuery();
        
        // Kill the connection
        cnn.Close();

        // Enable cache notifications for the database and the table. These methods do not require
        // an open connection to the database; it will do that on its own.
        SqlCacheDependencyAdmin.EnableNotifications(connectString);
        SqlCacheDependencyAdmin.EnableTableForNotifications(connectString, "DepartmentSample");
    }
    
    void Application_End(Object sender, EventArgs e) {
        //  Code that runs on application shutdown

    }
        
    void Application_Error(Object sender, EventArgs e) { 
        // Code that runs when an unhandled error occurs

    }

    void Session_Start(Object sender, EventArgs e) {
        // Code that runs when a new session is started

    }

    void Session_End(Object sender, EventArgs e) {
        // Code that runs when a session ends. 
        // Note: The Session_End event is raised only when the sessionstate mode
        // is set to InProc in the Web.config file. If session mode is set to StateServer 
        // or SQLServer, the event is not raised.

    }
       
</script>
