using System;
using System.Web;
using System.Web.UI;
using Personalization;

public class PortalModulePage : Page
{   
    public UserState UserState
    {        
        get
        {
            UserState myState = (UserState) Context.Items["UserState"]; 
            if (myState == null)
            {
                throw new Exception("No UserState Loaded!!!");
            }
            return myState;
        }
    }
}