<%@ Application Language="C#" %>

<script runat="server">

	void Profile_MigrateAnonymous(Object sender, System.Web.Profile.ProfileMigrateEventArgs e)
	{
		// Migrate the first name
		if (Profile.GetProfile(e.AnonymousID).FirstName != string.Empty)
		{
			Profile.FirstName = Profile.GetProfile(e.AnonymousID).FirstName;
		}

		// Migrate the last name
		if (Profile.GetProfile(e.AnonymousID).LastName != string.Empty)
		{
			Profile.LastName = Profile.GetProfile(e.AnonymousID).LastName;
		}

		// Migrate the buddy list
		if (Profile.GetProfile(e.AnonymousID).BuddyList != null)
		{
			Profile.BuddyList = Profile.GetProfile(e.AnonymousID).BuddyList;
		}

		// Migrate the address
		if (Profile.GetProfile(e.AnonymousID).Address != null)
		{
			Profile.Address = Profile.GetProfile(e.AnonymousID).Address;
		}
	}
	
    void Application_Start(Object sender, EventArgs e) {
        // Code that runs on application startup

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
