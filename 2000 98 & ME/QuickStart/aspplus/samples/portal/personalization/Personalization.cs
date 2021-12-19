using System;
using System.Collections;
using System.Web; 
using System.Data;
using System.Data.SQL;

namespace Personalization {

    public class UserStateModule : IHttpModule
    {
        public String ModuleName 
        { 
            get { return "PersonalizationModule"; } 
        }    
    
        public void Init(HttpApplication app)
        { 
            app.EndRequest += new EventHandler(this.OnLeave);
            app.AuthenticateRequest += new EventHandler(this.OnEnter);
        }

        public void Dispose()
        {

        }
        public void OnEnter(Object source, EventArgs eventArgs)
        {

            HttpApplication app;
            HttpContext context;

            app = (HttpApplication)source;
            context = app.Context;
          
            String userId = "ANONYMOUS";
            
           if (context.Request.IsAuthenticated ) 
               userId= context.User.Identity.Name ;  
   
           // Obtain Appropriate User state and populate HttpContext with it
           context.Items["UserState"] = new UserState(userId);
        }

        public void OnLeave(Object source, EventArgs eventArgs)
        {

            // Save UserState back to data store
            HttpApplication app;
            HttpContext context;

            app = (HttpApplication)source;
            context = app.Context; 
            UserState myState = (UserState) context.Items["UserState"]; 
            if (myState != null)  
               myState.Save();
        }
    }

    public class UserState {

        private Hashtable   m_userPersonalization = new Hashtable();
        private String      m_userId;
        private bool        m_isdirty;

        public UserState(String UserId) {

            m_userId = UserId;
            SQLDataSetCommand myAdapter = new SQLDataSetCommand();
 
            myAdapter.SelectCommand  = new SQLCommand();
            myAdapter.SelectCommand.ActiveConnection = new SQLConnection("Localhost","sa","","portal");
            myAdapter.SelectCommand.CommandText = "LoadPersonalizationSettings";
            myAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;

            SQLParameter myParameter = new SQLParameter("@UserID", SQLDataType.VarChar,100);
            myParameter.Value = UserId ; 

            myAdapter.SelectCommand.Parameters.Add(myParameter);

            DataSet myDataSet = new DataSet();
            myAdapter.FillDataSet(myDataSet,"Results");
 
           if (myDataSet.Tables[0].Rows.Count == 0) {

                SQLCommand createUserCommand = new SQLCommand(); 
                createUserCommand.ActiveConnection = new SQLConnection("localhost","sa","","portal");
                createUserCommand.ActiveConnection.Open();
                createUserCommand.CommandText = "CreatePersonalizationAccount";
                createUserCommand.CommandType = CommandType.StoredProcedure;
                SQLParameter myUserId = new SQLParameter("@UserID", SQLDataType.VarChar,20) ;
                myUserId.Value = UserId ;
                createUserCommand.Parameters.Add( myUserId);
                createUserCommand.ExecuteNonQuery();

               // Not repopulate user dataset

                myDataSet = new DataSet();
                myAdapter.FillDataSet(myDataSet,"Results");

           }


	    // If user doesn't exist -- create new personalization account

            DataRow myDataRow = myDataSet.Tables[0].Rows[0];
            DataColumn [] columns  = myDataSet.Tables[0].Columns.All;

            for (int i=0; i<columns.Length;i++) {

               Object value = myDataSet.Tables[0].Rows[0][columns[i]];
               m_userPersonalization[columns[i].ToString()] = (value == null) ? "" : value.ToString();
            }

            myAdapter.Dispose();

        }

        public String UserId {
            get {
                return m_userId;
            }
            set {
                m_userId = value;
            }
        } 

        public String this[String key] {
            get {
                return (String) m_userPersonalization[key];
            } 
            set {
                m_userPersonalization[key] = value;
                m_isdirty = true;
            }
        }

        public void Save() {

            if (m_isdirty == true) { 
                SQLConnection conn = new SQLConnection("localhost","sa","","portal");
                SQLCommand cmd = new SQLCommand("SavePersonalizationSettings", conn);
                conn.Open();
      
                IEnumerator  myHashKeyEnum = ((IEnumerable)m_userPersonalization.Keys).GetEnumerator(); 
                IEnumerator  myHashValEnum = ((IEnumerable)m_userPersonalization.Values).GetEnumerator(); 
          

                while( myHashKeyEnum.MoveNext() && myHashValEnum.MoveNext() )
                {
                    SQLParameter myParameter = new SQLParameter("@"+myHashKeyEnum.Current.ToString() , SQLDataType.VarChar,1000);
                    myParameter.Value = myHashValEnum.Current.ToString() ; 
                    cmd.Parameters.Add(myParameter);
                }
                int rowsAffected = 0;
                cmd.CommandType = CommandType.StoredProcedure;
                rowsAffected = cmd.ExecuteNonQuery();
            }
        }
    }
}