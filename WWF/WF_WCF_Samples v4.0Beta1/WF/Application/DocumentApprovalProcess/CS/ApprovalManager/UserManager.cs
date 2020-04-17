//----------------------------------------------------------------
// Copyright (c) Microsoft Corporation.  All rights reserved.
//----------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.ServiceModel;

using Microsoft.Samples.DocumentApprovalProcess.ApprovalMessageContractLibrary;

namespace Microsoft.Samples.DocumentApprovalProcess.ApprovalManager
{
    public static class UserManager
    {
        static String dbconnStr = "Server=localhost\\sqlexpress; Database=DocApprovalSampleUsers;integrated Security=SSPI;";

        public static User AddUser(String uname, String utype, String endaddressrequest, String endaddressresponse)
        {
            User newUser = new User(uname, utype, endaddressrequest, endaddressresponse);
            using (SqlConnection sCon = new SqlConnection(dbconnStr))
            {
                SqlCommand sCom = new SqlCommand();
                sCom.Connection = sCon;
                sCom.CommandText = "insert into users (username,usertype,addressrequest,addressresponse,guid) values('" + uname + "', '" + utype + "', '" + endaddressrequest + "', '" + endaddressresponse + "', '" + newUser.Id + "')";
                sCon.Open();
                sCom.ExecuteNonQuery();
                sCon.Dispose();
            }
            return newUser;
        }

        public static void RemoveUser(User id)
        {
            using (SqlConnection sCon = new SqlConnection(dbconnStr))
            {
                using (SqlCommand sCom = new SqlCommand())
                {
                    sCom.Connection = sCon;
                    sCom.CommandText = "DELETE FROM users WHERE guid='" + id.Id + "'";
                    sCon.Open();
                    sCom.ExecuteNonQuery();
                }
            }            
        }

        public static List<User> GetUsersByType(String utype)
        {
            String query = "SELECT * FROM users WHERE usertype='" + utype + "'";
            List<User> filteredUsers = new List<User>();
            DataSet ds = new DataSet();

            using (SqlConnection sCon = new SqlConnection(dbconnStr))
            {
                using (SqlDataAdapter sAda = new SqlDataAdapter(query, sCon)){
                    sAda.Fill(ds);
                    if (ds.Tables["Table"] != null)
                    {
                        foreach (DataRow dr in ds.Tables["Table"].Rows)
                        {
                            filteredUsers.Add(new User((String)dr["username"], (String)dr["usertype"], (String)dr["address"], (String)dr["guid"]));
                        }
                    }
                }
            }
            return filteredUsers;
        }

        public static void DeleteAllUsers()
        {
            using (SqlConnection sCon = new SqlConnection(dbconnStr))
            {
                using (SqlCommand sCom = new SqlCommand())
                {
                    sCom.Connection = sCon;
                    sCom.CommandText = "DELETE FROM users";
                    sCon.Open();
                    sCom.ExecuteNonQuery();
                }
            }
        }
    }
}
