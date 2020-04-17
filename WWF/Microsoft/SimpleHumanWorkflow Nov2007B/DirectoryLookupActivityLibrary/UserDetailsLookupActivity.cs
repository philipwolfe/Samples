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
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Collections;
using System.Drawing;
using System.Workflow.ComponentModel;
using System.Workflow.ComponentModel.Design;
using System.Workflow.ComponentModel.Compiler;
using System.Workflow.ComponentModel.Serialization;
using System.Workflow.Runtime;
using System.Workflow.Activities;
using System.Workflow.Activities.Rules;
using System.Xml.XPath;
using System.Xml;
using System.Drawing.Drawing2D;

namespace DirectoryLookupActivityLibrary
{
    #region look n feel
    internal sealed class UserDetailsCustomActivityDesignerTheme : ActivityDesignerTheme
    {
        public UserDetailsCustomActivityDesignerTheme(WorkflowTheme theme)
            : base(theme)
        {
            this.BorderColor = Color.GreenYellow;
            this.BorderStyle = DashStyle.Solid;
            this.BackColorStart = Color.Green;
            this.BackColorEnd = Color.Yellow;
            this.BackgroundStyle = LinearGradientMode.Vertical;
        }
    }

    [ActivityDesignerThemeAttribute(typeof(UserDetailsCustomActivityDesignerTheme))]
    public class UserDetailsCustomActivityDesigner : ActivityDesigner
    {

    }
    #endregion


    [ToolboxItemAttribute(typeof(ActivityToolboxItem))]
    [Designer(typeof(UserDetailsCustomActivityDesigner), typeof(IDesigner))]
    [ToolboxBitmap(typeof(UserDetailsLookupActivity), "Resources.User.png")]
    public partial class UserDetailsLookupActivity : Activity
    {

        public UserDetailsLookupActivity()
		{
			InitializeComponent();
        }

        private void InitializeComponent()
        {

        }




        #region Properties
        public static DependencyProperty DirectoryUriProperty =
            DependencyProperty.Register("DirectoryUri", typeof(System.String), typeof(UserDetailsLookupActivity));
        [DescriptionAttribute("Please specify the URI of the directory. Either an AD Server or an XML File.")]
        [DesignerSerializationVisibilityAttribute(DesignerSerializationVisibility.Visible)]
        [ValidationOption(ValidationOption.Required)]
        [BrowsableAttribute(true)]
        [Category("Directory")]
        public string DirectoryUri
        {
            get
            {
                return ((String)(base.GetValue(UserDetailsLookupActivity.DirectoryUriProperty)));
            }
            set
            {
                base.SetValue(UserDetailsLookupActivity.DirectoryUriProperty, value);
            }
        }

        public static DependencyProperty QueryProperty = DependencyProperty.Register("Query", typeof(System.String), typeof(UserDetailsLookupActivity));

        [DescriptionAttribute("Please specify the Username of the user to retrieve.")]
        [DesignerSerializationVisibilityAttribute(DesignerSerializationVisibility.Visible)]
        [ValidationOption(ValidationOption.Optional)]
        [BrowsableAttribute(true)]
        [Category("Query")]
        public string Query
        {
            get
            {
                return ((String)(base.GetValue(UserDetailsLookupActivity.QueryProperty)));
            }
            set
            {
                base.SetValue(UserDetailsLookupActivity.QueryProperty, value);
            }
        }


        public static DependencyProperty QuerySourceProperty =
            DependencyProperty.Register("QuerySource", typeof(ADActivityLookupSource), typeof(UserDetailsLookupActivity));
        [DescriptionAttribute("Please choose the source of the query, either an AD Server or an XML File.")]
        [DesignerSerializationVisibilityAttribute(DesignerSerializationVisibility.Visible)]
        [ValidationOption(ValidationOption.Required)]
        [BrowsableAttribute(true)]
        [Category("Directory")]
        public ADActivityLookupSource QuerySource
        {
            get
            {
                return ((ADActivityLookupSource)(base.GetValue(UserDetailsLookupActivity.QuerySourceProperty)));
            }
            set
            {
                base.SetValue(UserDetailsLookupActivity.QuerySourceProperty, value);
            }
        }


        public static DependencyProperty RetrievedUserDataProperty = DependencyProperty.Register("RetrievedUserData", typeof(DirectoryLookupActivityLibrary.UserData), typeof(DirectoryLookupActivityLibrary.UserDetailsLookupActivity));

        [DesignerSerializationVisibilityAttribute(DesignerSerializationVisibility.Visible)]
        [ValidationOption(ValidationOption.Optional)]
        [BrowsableAttribute(true)]
        [DescriptionAttribute("The retrieved user data. Populated after the query has been run.")]
        [CategoryAttribute("Results")]
        public DirectoryLookupActivityLibrary.UserData RetrievedUserData
        {
            get
            {
                return ((UserData)(base.GetValue(DirectoryLookupActivityLibrary.UserDetailsLookupActivity.RetrievedUserDataProperty)));
            }
            set
            {
                base.SetValue(DirectoryLookupActivityLibrary.UserDetailsLookupActivity.RetrievedUserDataProperty, value);
            }
        }
        
        #endregion

        #region Events

        public static DependencyProperty QueryingEvent =
            DependencyProperty.Register("Querying", typeof(EventHandler), typeof(UserDetailsLookupActivity));
        [DescriptionAttribute("Use this Handler to do any pre-processing or to set query parameters at run time.")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        [ValidationOption(ValidationOption.Optional)]
        [BrowsableAttribute(true)]
        [Category("Handlers")]
        public event EventHandler Querying
        {
            add
            {
                base.AddHandler(UserDetailsLookupActivity.QueryingEvent, value);
            }
            remove
            {
                base.RemoveHandler(UserDetailsLookupActivity.QueryingEvent, value);
            }
        }

        public static DependencyProperty QueriedEvent =
            DependencyProperty.Register("Queried", typeof(EventHandler), typeof(UserDetailsLookupActivity));
        [DescriptionAttribute("This event is raised when the query has completed.")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        [ValidationOption(ValidationOption.Optional)]
        [BrowsableAttribute(true)]
        [Category("Handlers")]
        public event EventHandler Queried
        {
            add
            {
                base.AddHandler(UserDetailsLookupActivity.QueriedEvent, value);
            }
            remove
            {
                base.RemoveHandler(UserDetailsLookupActivity.QueriedEvent, value);
            }
        }
        #endregion

        #region Execution Logic

        protected override ActivityExecutionStatus Execute(ActivityExecutionContext context)
        {
            
            //Raise the QueryingEvent
            this.RaiseEvent(QueryingEvent, this, new EventArgs());

            
            
            UserData user = new UserData();
            switch (this.QuerySource)
            {
            	case ADActivityLookupSource.XmlFile:
                    user = GetUserFromXmlFile(this.Query, this.DirectoryUri);
            		break;
                case ADActivityLookupSource.ActiveDirectory:
                    ADHelper adh = new ADHelper(this.DirectoryUri);
                    user = adh.GetUserData(this.Query);
                    break;
            }

            //Set the results property
            this.RetrievedUserData = user;

            //Raise the Query finsihed event
            UserLookupFinishedEventArgs lookupFinishedEventArgs = new UserLookupFinishedEventArgs(user);
            this.RaiseEvent(QueriedEvent, this, lookupFinishedEventArgs);

            return ActivityExecutionStatus.Closed;
        }


        private UserData GetUserFromXmlFile(string objectName, string fileName)
        {
            //We use an XML Document here rather than XPath navigators for convenience
            //Open the XML Org Chart file so that we can query it with XPath
            XmlDocument doc = new XmlDocument();
            doc.Load(fileName);

            //Prepare the appropriate XPath Statement
            string xpathStatement = "/organization/users/user[@accountName='" + objectName + "']";
            
            //Execute the XPth statement to return a list of user names into the ArrayList.
            XmlNode xmlNode = doc.SelectSingleNode(xpathStatement);

            UserData newUser = new UserData();

            
            newUser.DisplayName = xmlNode.SelectSingleNode("displayName").InnerText;
            newUser.GivenName = xmlNode.SelectSingleNode("givenName").InnerText;
            newUser.CN = xmlNode.SelectSingleNode("cn").InnerText;
            newUser.Mail = xmlNode.SelectSingleNode("mail").InnerText;
            newUser.AccountName = xmlNode.SelectSingleNode("@accountName").InnerText;
            newUser.Manager = xmlNode.SelectSingleNode("manager").InnerText;
            newUser.RtcSipAddress = xmlNode.SelectSingleNode("rtcSipAddress").InnerText;

            return newUser;
            
        }

       #endregion  



    }

    [Serializable]
    public class UserLookupFinishedEventArgs : EventArgs
    {
        private UserData userDetails;
        public UserData UserDetails
        {
            get
            {
                return userDetails;
            }
        }

        public UserLookupFinishedEventArgs(UserData userDetails)
        {
            this.userDetails = userDetails;
        }
    }

    [SerializableAttribute()]
    public class UserData
    {
        private string displayName;
        private string givenName;
        private string cn;
        private string mail;
        private string accountName;
        private string manager;
        private string rtcSipAddress;

        public string DisplayName
        {
            get
            {
                return displayName;
            }
            set
            {
                displayName = value;
            }
        }

        public string GivenName
        {
            get
            {
                return givenName;
            }
            set
            {
                givenName = value;
            }
        }

        public string CN
        {
            get
            {
                return cn;
            }
            set
            {
                cn = value;
            }
        }

        public string Mail
        {
            get
            {
                return mail;
            }
            set
            {
                mail = value;
            }
        }

        public string AccountName
        {
            get
            {
                return accountName;
            }
            set
            {
                accountName = value;
            }
        }

        public string Manager
        {
            get
            {
                return manager;
            }
            set
            {
                manager = value;
            }
        }

        public string RtcSipAddress
        {
            get
            {
                return rtcSipAddress;
            }
            set
            {
                rtcSipAddress = value;
            }
        }
    }
}
