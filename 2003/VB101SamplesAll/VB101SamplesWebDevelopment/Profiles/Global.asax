<%@ Application Language="VB" %>

<script runat="server">
    
    Sub Profile_MigrateAnonymous(ByVal sender As [Object], ByVal e As ProfileMigrateEventArgs)
        ' Migrate the first name
        If Profile.GetProfile(e.AnonymousID).FirstName <> String.Empty Then
            Profile.FirstName = Profile.GetProfile(e.AnonymousID).FirstName
        End If
   
        ' Migrate the last name
        If Profile.GetProfile(e.AnonymousID).LastName <> String.Empty Then
            Profile.LastName = Profile.GetProfile(e.AnonymousID).LastName
        End If
   
        ' Migrate the buddy list
        If Not (Profile.GetProfile(e.AnonymousID).BuddyList Is Nothing) Then
            Profile.BuddyList = Profile.GetProfile(e.AnonymousID).BuddyList
        End If
   
        ' Migrate the address
        If Not (Profile.GetProfile(e.AnonymousID).Address Is Nothing) Then
            Profile.Address = Profile.GetProfile(e.AnonymousID).Address
        End If
    End Sub 'Profile_MigrateAnonymous


    Sub Application_Start(ByVal sender As [Object], ByVal e As EventArgs)
    End Sub 'Application_Start
    ' Code that runs on application startup

    Sub Application_End(ByVal sender As [Object], ByVal e As EventArgs)
    End Sub 'Application_End
    '  Code that runs on application shutdown

    Sub Application_Error(ByVal sender As [Object], ByVal e As EventArgs)
    End Sub 'Application_Error
    ' Code that runs when an unhandled error occurs

    Sub Session_Start(ByVal sender As [Object], ByVal e As EventArgs)
    End Sub 'Session_Start
    ' Code that runs when a new session is started

    Sub Session_End(ByVal sender As [Object], ByVal e As EventArgs)
    End Sub 'Session_End ' Code that runs when a session ends. 
    ' Note: The Session_End event is raised only when the sessionstate mode
    ' is set to InProc in the Web.config file. If session mode is set to StateServer 
    ' or SQLServer, the event is not raised.
       
</script>
