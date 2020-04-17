//--------------------------------------------------------------------------------
// This file is a "Sample" as from Windows Workflow Foundation
// Samples
//
// Copyright (c) Microsoft Corporation. All rights reserved.
//
// This source code is intended only as a supplement to Microsoft
// Development Tools and/or on-line documentation.  See these other
// materials for detailed information regarding Microsoft code samples.
// 
// THIS CODE AND INFORMATION ARE PROVIDED AS IS WITHOUT WARRANTY OF ANY
// KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE
// IMPLIED WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A
// PARTICULAR PURPOSE.
//--------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.DirectoryServices;
using System.Collections;

namespace DirectoryLookupActivityLibrary
{


    internal class ADHelper
    {
        private string ldapPath;
        DirectorySearcher search;

        internal ADHelper(string ldapPath)
        {
            this.ldapPath = ldapPath;
            search = new DirectorySearcher(new DirectoryEntry(ldapPath)); 
        }

        internal string GetUsersManager(string loginName)
        {
            SearchResult result;
            search.Filter = String.Format("(SAMAccountName={0})", loginName);
            search.PropertiesToLoad.Add("manager");
            result = search.FindOne();

            if (result == null)
            {
                return "";
            }
            else
            {
                string userPath = result.Properties["manager"][0].ToString();
                System.DirectoryServices.DirectoryEntry de = new DirectoryEntry(ldapPath + "/" + userPath);
                return de.Properties["SAMAccountName"].Value.ToString();
            }
        }

        internal List<string> GetADGroupUsers(string groupName)
        {
            SearchResult result;
            search.Filter = String.Format("(cn={0})", groupName);
            search.PropertiesToLoad.Add("member");
            result = search.FindOne();

            List<string> userNames = new List<string>();
            if (result != null)
            {
                for (int counter = 0; counter <
                         result.Properties["member"].Count; counter++)
                {
                    string userPath = (string)result.Properties["member"][counter];
                    System.DirectoryServices.DirectoryEntry de = new DirectoryEntry(ldapPath + "/" + userPath);
                    userNames.Add((string)de.Properties["SAMAccountName"].Value);
                }
            }
            return userNames;
        }

        internal List<string> GetUsersDirectReports(string userName, string excludeUser)
        {
            SearchResult result;
            search.Filter = String.Format("(SAMAccountName={0})", userName);
            search.PropertiesToLoad.Add("directReports");
            result = search.FindOne();

            List<string> userNames = new List<string>();
            if (result != null)
            {
                for (int counter = 0; counter <
                         result.Properties["directReports"].Count; counter++)
                {
                    string userPath = (string)result.Properties["directReports"][counter];
                    System.DirectoryServices.DirectoryEntry de = new DirectoryEntry(ldapPath + "/" + userPath);
                    if (de.Properties["SAMAccountName"].Value.ToString() != excludeUser)
                        userNames.Add((string)de.Properties["SAMAccountName"].Value);
                }
            }
            return userNames;
        }

        internal List<string> GetUsersDirectReports(string userName)
        {
            return GetUsersDirectReports(userName, "");
        }

        internal List<string> GetUsersPeers(string userName)
        {
            string manager = GetUsersManager(userName);
            return GetUsersDirectReports(manager,userName);
        }

        internal UserData GetUserData(string loginName)
        {
            //If interested in geting other user information take a look at
            //http://msdn.microsoft.com/library/default.asp?url=/library/en-us/adschema/adschema/active_directory_schema.asp

            SearchResult result;
            search.Filter = String.Format("(SAMAccountName={0})", loginName);
            search.PropertiesToLoad.Add("displayName");
            search.PropertiesToLoad.Add("givenName");
            search.PropertiesToLoad.Add("cn");
            search.PropertiesToLoad.Add("mail");
            search.PropertiesToLoad.Add("sAMAccountName");
            search.PropertiesToLoad.Add("manager");
            search.PropertiesToLoad.Add("msrtcsip-primaryuseraddress");

            result = search.FindOne();

            if (result == null)
            {
                throw new ArgumentException("Cannot find details for the given user.");
            }
            else
            {
                UserData retVal = new UserData();
                retVal.DisplayName = result.Properties["displayName"][0].ToString();
                retVal.GivenName = result.Properties["givenName"][0].ToString();
                retVal.CN = result.Properties["cn"][0].ToString();
                retVal.Mail = result.Properties["mail"][0].ToString();
                retVal.RtcSipAddress = result.Properties["msrtcsip-primaryuseraddress"][0].ToString();
                if (result.Properties["manager"].Count > 0)
                {
                    System.DirectoryServices.DirectoryEntry de = new DirectoryEntry(ldapPath + "/" + result.Properties["manager"][0].ToString());
                    retVal.Manager = de.Properties["SAMAccountName"].Value.ToString();
                }
                else
                    retVal.Manager = "";
                return retVal;
            }


        }

        
    }
}