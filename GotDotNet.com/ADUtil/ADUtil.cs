using System;
using System.DirectoryServices;		// Be sure to set a reference to "System.DirectoryServices.dll"

namespace AdTest			// Change namespace for your project
{

	// Structures for returning user information
	public struct UserInfo
	{
		public string LoginName;
		public string FirstName;
		public string LastName;
	}

	public struct UserInfoEx
	{
		public string LoginName;
		public string Password;
		public string FirstName;
		public string LastName;
		public string EmailAddress;
		public string Title;
		public string Company;
		public string Address;
		public string City;
		public string State;
		public string PostalCode;
		public string Phone;
		public string Country;
	}

	// Static class containing all the supported user property names
	public class UserProperty
	{
		public static string CommonName = "cn";
		public static string Password = "homePhone";
		public static string UserName = "sAMAccountName";
		public static string Country = "co";
		public static string Company = "company";
		public static string Department = "department";
		public static string Description = "description";
		public static string DisplayName = "displayName";
		public static string FirstName = "givenName";
		public static string City = "l";
		public static string Email = "mail";
		public static string PostalCode = "postalCode";
		public static string LastName = "sn";
		public static string State = "st";
		public static string Address = "streetAddress";
		public static string Phone = "telephoneNumber";
		public static string Title = "title";
	}

	// Active Directory Utility Class
	public class ADUtil
	{
		public ADUtil()
		{
			//
			// TODO: Add constructor logic here
			//
		}

		#region Constants
		// *** SECURE CONSTANTS ***
		// Reality Check: In production, these would be stored in a secure are of the registry
		// or another secure location. In production, instead of "Administrator", an account
		// would be created which has ONLY the privileges it needs for the AD operations
		// and no more.

		// Domain Settings:
		const string usersLdapPath = "LDAP://MYDOMAIN.local/CN=Users, DC=MYDOMAIN, DC=local";
		const string adLoginName = "MYDOMAIN\\Administrator";
		const string adLoginPassword = "password";
		#endregion

		// GetUserCN - given the CMS user string, returns a friendly name for the user
		static public string GetUserCN (string username)
		{
			DirectoryEntry usersDE =
				new DirectoryEntry (usersLdapPath, adLoginName, adLoginPassword);
			DirectorySearcher ds = new DirectorySearcher (usersDE);
			ds.Filter = "(sAMAccountName=" + username + ")";
			ds.PropertiesToLoad.Add (UserProperty.FirstName);
			ds.PropertiesToLoad.Add (UserProperty.LastName);
			SearchResult r = ds.FindOne();

			return (r.Properties[UserProperty.FirstName][0].ToString()
				    + " "
				    + r.Properties[UserProperty.LastName][0].ToString());
		}

		// GetUserInfo - given the CMS user string, returns user information
		static public UserInfo GetUserInfo (string username)
		{
			DirectoryEntry usersDE =
				new DirectoryEntry (usersLdapPath, adLoginName, adLoginPassword);
			DirectorySearcher ds = new DirectorySearcher (usersDE);
			ds.Filter = "(sAMAccountName=" + username + ")";
			ds.PropertiesToLoad.Add ("cn");
			ds.PropertiesToLoad.Add (UserProperty.UserName);
			ds.PropertiesToLoad.Add (UserProperty.FirstName);
			ds.PropertiesToLoad.Add (UserProperty.LastName);
			SearchResult r = ds.FindOne();

			UserInfo result = new UserInfo();

			result.FirstName = r.Properties[UserProperty.FirstName][0].ToString();
			result.LastName = r.Properties[UserProperty.LastName][0].ToString();
			result.LoginName = r.Properties[UserProperty.UserName][0].ToString();

			return (result);
		}

		// GetUserInfoEx - given the CMS user string, returns user information
		static public UserInfoEx GetUserInfoEx (string username)
		{
			DirectoryEntry usersDE =
				new DirectoryEntry (usersLdapPath, adLoginName, adLoginPassword);
			DirectorySearcher ds = new DirectorySearcher (usersDE);
			ds.Filter = "(sAMAccountName=" + username + ")";
			ds.PropertiesToLoad.Add ("cn");
			ds.PropertiesToLoad.Add (UserProperty.UserName);
			ds.PropertiesToLoad.Add (UserProperty.Password);
			ds.PropertiesToLoad.Add (UserProperty.FirstName);
			ds.PropertiesToLoad.Add (UserProperty.LastName);
			ds.PropertiesToLoad.Add (UserProperty.Email);
			ds.PropertiesToLoad.Add (UserProperty.Title);
			ds.PropertiesToLoad.Add (UserProperty.Company);
			ds.PropertiesToLoad.Add (UserProperty.Address);
			ds.PropertiesToLoad.Add (UserProperty.City);
			ds.PropertiesToLoad.Add (UserProperty.State);
			ds.PropertiesToLoad.Add (UserProperty.PostalCode);
			ds.PropertiesToLoad.Add (UserProperty.Phone);
			ds.PropertiesToLoad.Add (UserProperty.Country);
			SearchResult r = ds.FindOne();

			UserInfoEx result = new UserInfoEx();

			result.LoginName = r.Properties[UserProperty.UserName][0].ToString();
			if (r.Properties[UserProperty.FirstName] != null)
			{
				result.FirstName = r.Properties[UserProperty.FirstName][0].ToString();
			}
			else
			{
				result.FirstName = "";
			}
			if (r.Properties[UserProperty.Password] != null)
			{
				result.Password = r.Properties[UserProperty.Password][0].ToString();
			}
			else
			{
				result.Password = "";
			}
			if (r.Properties[UserProperty.LastName] != null)
			{
				result.LastName = r.Properties[UserProperty.LastName][0].ToString();
			}
			else
			{
				result.LastName = "";
			}
			if (r.Properties[UserProperty.Email] != null)
			{
				result.EmailAddress = r.Properties[UserProperty.Email][0].ToString();
			}
			else
			{
				result.EmailAddress = "";
			}
			if (r.Properties[UserProperty.Title] != null)
			{
				result.Title = r.Properties[UserProperty.Title][0].ToString();
			}
			else
			{
				result.Title = "";
			}
			if (r.Properties[UserProperty.Company] != null)
			{
				result.Company = r.Properties[UserProperty.Company][0].ToString();
			}
			else
			{
				result.Company = "";
			}
			if (r.Properties[UserProperty.Address] != null)
			{
				result.Address = r.Properties[UserProperty.Address][0].ToString();
			}
			else
			{
				result.Address = "";
			}
			if (r.Properties[UserProperty.City] != null)
			{
				result.City = r.Properties[UserProperty.City][0].ToString();
			}
			else
			{
				result.City = "";
			}
			if (r.Properties[UserProperty.State] != null)
			{
				result.State = r.Properties[UserProperty.State][0].ToString();
			}
			else
			{
				result.State = "";
			}
			if (r.Properties[UserProperty.PostalCode] != null)
			{
				result.PostalCode = r.Properties[UserProperty.PostalCode][0].ToString();
			}
			else
			{
				result.PostalCode = "";
			}
			if (r.Properties[UserProperty.Phone] != null)
			{
				result.Phone = r.Properties[UserProperty.Phone][0].ToString();
			}
			else
			{
				result.Phone = "";
			}
			if (r.Properties[UserProperty.Country] != null)
			{
				result.Country = r.Properties[UserProperty.Country][0].ToString();
			}
			else
			{
				result.Country = "";
			}

			return (result);
		}

		// UpdateUserProperty - Updates a property for the AD User
		static public void UpdateUserProperty (string username, string propertyName,
						string propertyValue)
		{
			// First, get a DE for the user
			DirectoryEntry userContainerDE =
				new DirectoryEntry (usersLdapPath, adLoginName, adLoginPassword);
			DirectorySearcher ds = new DirectorySearcher (userContainerDE);
			ds.Filter = "(sAMAccountName=" + username + ")";
			ds.PropertiesToLoad.Add ("cn");
			SearchResult r = ds.FindOne();
			DirectoryEntry theUserDE = new DirectoryEntry (r.Path, adLoginName, adLoginPassword);

			// Now update the property setting
			if (theUserDE.Properties[propertyName].Count == 0)
			{
				theUserDE.Properties[propertyName].Add (propertyValue);
			}
			else
			{
				theUserDE.Properties[propertyName][0] = propertyValue;
			}
			theUserDE.CommitChanges();
		}


		// GetAdGroups - Return all Active Directory security groups with a given prefix
		static private string[] GetAdGroups(string prefix)
		{
			string [] results;

			DirectoryEntry groupsDE = new DirectoryEntry (usersLdapPath, adLoginName, adLoginPassword);
			DirectorySearcher groupsDS = new DirectorySearcher (groupsDE);
			groupsDS.Filter = "(&(objectClass=group)(CN=" + prefix + "*))";
			groupsDS.PropertiesToLoad.Add ("cn");
			SearchResultCollection sr = groupsDS.FindAll();

			results = new String [sr.Count];

			for (int i=0; i<sr.Count; i++)
			{
				SearchResult r = sr[i];
				results[i] = r.Properties["cn"][0].ToString();
			}

			return (results);
		}

		// GetGroupsForUser - Returns all groups the user belongs to
		static public string [] GetGroupsForUser (string username)
		{
			string [] results;

			DirectoryEntry usersDE =
				new DirectoryEntry (usersLdapPath, adLoginName, adLoginPassword);
			DirectorySearcher ds = new DirectorySearcher (usersDE);
			ds.Filter = "(sAMAccountName=" + username + ")";
			ds.PropertiesToLoad.Add ("memberof");
			SearchResultCollection sr = ds.FindAll();
			SearchResult r = sr[0];

			if (r.Properties["memberof"] == null)
			{
				return (null);
			}

			results = new string [r.Properties["memberof"].Count];
			for (int i=0; i<r.Properties["memberof"].Count; i++)
			{
				string theGroupPath = r.Properties["memberof"][i].ToString();
				results[i] = theGroupPath.Substring (3, theGroupPath.IndexOf (",")-3);
			}

			return (results);
		}
		
		// FindUsers - Returns all users matching a pattern
		static public UserInfo [] FindUsers (string username)
		{
			UserInfo [] results;

			DirectoryEntry usersDE =
				new DirectoryEntry (usersLdapPath, adLoginName, adLoginPassword);
			DirectorySearcher ds = new DirectorySearcher (usersDE);
			ds.Filter = "(&(objectClass=user)(sAMAccountName=" + username + "*))";
			ds.PropertiesToLoad.Add (UserProperty.UserName);
			ds.PropertiesToLoad.Add (UserProperty.FirstName);
			ds.PropertiesToLoad.Add (UserProperty.LastName);

			SearchResultCollection sr = ds.FindAll();

			results = new UserInfo [sr.Count];

			for (int i=0; i<sr.Count; i++)
			{
				results[i].LoginName = sr[i].Properties[UserProperty.UserName][0].ToString();
				if (sr[i].Properties[UserProperty.FirstName] != null)
				{
					results[i].FirstName = sr[i].Properties[UserProperty.FirstName][0].ToString();
				}
				else
				{
					results[i].FirstName = "";
				}
				if (sr[i].Properties[UserProperty.LastName] != null)
				{
					results[i].LastName = sr[i].Properties[UserProperty.LastName][0].ToString();
				}
				else
				{
					results[i].LastName = "";
				}
			}

			return (results);
		}

		// AddUserToGroup - Adds user to a specified group
		static public void AddUserToGroup (string username, string groupName)
		{
			// First, get a DE for the user
			DirectoryEntry userContainerDE =
				new DirectoryEntry (usersLdapPath, adLoginName, adLoginPassword);
			DirectorySearcher ds = new DirectorySearcher (userContainerDE);
			ds.Filter = "(sAMAccountName=" + username + ")";
			ds.PropertiesToLoad.Add ("cn");
			SearchResult r = ds.FindOne();
			DirectoryEntry theUserDE = new DirectoryEntry (r.Path, adLoginName, adLoginPassword);

			// Now get a DE for the group
			ds.Filter = "(cn=" + groupName + ")";
			r = ds.FindOne();
			DirectoryEntry theGroupDE = new DirectoryEntry (r.Path, adLoginName, adLoginPassword);

			// Next we extract the user path from the LDAP string
			string userPath = theUserDE.Path;
			userPath = userPath.Substring (userPath.IndexOf("CN="));

			// Now add the user to the group
			theGroupDE.Properties["member"].Add (userPath);
			theGroupDE.CommitChanges();
		}

		// RemoveUserFromGroup - Removes user from a specified group
		static public void RemoveUserFromGroup (string username, string groupName)
		{
			// First, get a DE for the user
			DirectoryEntry userContainerDE =
				new DirectoryEntry (usersLdapPath, adLoginName, adLoginPassword);
			DirectorySearcher ds = new DirectorySearcher (userContainerDE);
			ds.Filter = "(sAMAccountName=" + username + ")";
			ds.PropertiesToLoad.Add ("cn");
			SearchResult r = ds.FindOne();
			DirectoryEntry theUserDE = new DirectoryEntry (r.Path, adLoginName, adLoginPassword);

			// Now get a DE for the group
			ds.Filter = "(cn=" + groupName + ")";
			r = ds.FindOne();
			DirectoryEntry theGroupDE = new DirectoryEntry (r.Path, adLoginName, adLoginPassword);

			// Next we extract the user path from the LDAP string
			string userPath = theUserDE.Path;
			userPath = userPath.Substring (userPath.IndexOf("CN="));

			// Now add the user to the group
			theGroupDE.Properties["member"].Remove (userPath);
			theGroupDE.CommitChanges();
		}

		// AddNewUser - Creates a new user account
		static public void AddNewUser (string username, string password, string firstName,
									   string lastName,	string description)
		{
			DirectoryEntry userContainerDE =
				new DirectoryEntry (usersLdapPath, adLoginName, adLoginPassword);

			DirectoryEntry newUser = userContainerDE.Children.Add ("CN="+username, "user");
			newUser.Invoke ("Put", new object [] {UserProperty.Description, description});
			newUser.Invoke ("Put", new object [] {UserProperty.UserName, username});
			newUser.Invoke ("Put", new object [] {UserProperty.LastName, lastName});
			newUser.Invoke ("Put", new object [] {UserProperty.FirstName, firstName});
			newUser.Invoke ("Put", new object [] {UserProperty.Password, password});
			newUser.CommitChanges();

			newUser.Invoke ("SetPassword", new object[] {password});
			int userFlags = (int) newUser.Properties["userAccountControl"][0];
			userFlags = userFlags & 0xFFFD;
			newUser.Properties["userAccountControl"][0] = userFlags;
			newUser.CommitChanges();
		}

		static public void ChangeUserPassword (string username, string newPassword)
		{
			// First, get a DE for the user
			DirectoryEntry userContainerDE =
				new DirectoryEntry (usersLdapPath, adLoginName, adLoginPassword);
			DirectorySearcher ds = new DirectorySearcher (userContainerDE);
			ds.Filter = "(sAMAccountName=" + username + ")";
			ds.PropertiesToLoad.Add ("cn");
			SearchResult r = ds.FindOne();
			DirectoryEntry theUserDE = new DirectoryEntry (r.Path, adLoginName, adLoginPassword);

			// Now update the property setting
			if (theUserDE.Properties[UserProperty.Password].Count == 0)
			{
				theUserDE.Properties[UserProperty.Password].Add (newPassword);
			}
			else
			{
				theUserDE.Properties[UserProperty.Password][0] = newPassword;
			}
			theUserDE.CommitChanges();

			// Now update the password
			theUserDE.Invoke ("SetPassword", new object[] {newPassword});
			theUserDE.CommitChanges();
		}

	}
}
