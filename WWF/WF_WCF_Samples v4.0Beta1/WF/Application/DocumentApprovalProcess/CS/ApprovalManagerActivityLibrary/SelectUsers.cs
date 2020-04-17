//----------------------------------------------------------------
// Copyright (c) Microsoft Corporation.  All rights reserved.
//----------------------------------------------------------------

namespace Microsoft.Samples.DocumentApprovalProcess.ApprovalManagerActivityLibrary
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Activities;
    using System.Data;
    using System.Data.SqlClient;
    using System.ServiceModel;

    using Microsoft.Samples.DocumentApprovalProcess.ApprovalMessageContractLibrary;

    public sealed class SelectUsers : CodeActivity
    {
        public InArgument<User> UserContext { get; set; }
        public InArgument<String> UserType { get; set; }
        public InArgument<int> SelectXUsers { get; set; }
        public OutArgument<List<User>> SelectedUsers { get; set; }

        protected override void Execute(CodeActivityContext context)
        {
            String dbconnStr = "Server=localhost\\sqlexpress; Database=DocApprovalSampleUsers;integrated Security=SSPI;";
            String query = "SELECT * FROM users WHERE usertype='" + this.UserType.Get(context) + "'";
            List<User> filteredUsers = new List<User>();
            DataSet ds = new DataSet();

            using (SqlConnection sCon = new SqlConnection(dbconnStr))
            {
                using (SqlDataAdapter sAda = new SqlDataAdapter(query, sCon))
                {
                    sAda.Fill(ds);
                    if (ds.Tables["Table"] != null)
                    {
                        foreach (DataRow dr in ds.Tables["Table"].Rows)
                        {
                            // Ensure no selection of user from the user requesting approval
                            if (!(new Guid((String)dr["guid"])).Equals(this.UserContext.Get(context).Id))
                            {
                                Console.WriteLine("Adding: " + (String)dr["username"]);
                                filteredUsers.Add(new User((String)dr["username"], (String)dr["usertype"], (String)dr["addressrequest"], (String)dr["addressresponse"], (String)dr["guid"]));
                            }
                        }
                    }
                }
            }

            // Only return as many users as is requested
            int remove = filteredUsers.Count - this.SelectXUsers.Get(context);
            for (int i = 0; i < remove; i++) filteredUsers.Remove(filteredUsers.Last());

            this.SelectedUsers.Set(context, filteredUsers);
        }
    }
}
