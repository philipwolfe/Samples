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
using System.Workflow.ComponentModel.Compiler;
using System.Workflow.ComponentModel.Serialization;
using System.Workflow.ComponentModel;
using System.Workflow.ComponentModel.Design;
using System.Workflow.Runtime;
using System.Workflow.Activities;
using System.Workflow.Activities.Rules;
using System.Collections.Generic;
using System.Xml.XPath;
using System.Drawing.Drawing2D;


namespace DirectoryLookupActivityLibrary
{
    public enum ADActivityLookupSource
    {
        ActiveDirectory = 0,
        XmlFile = 1
    }

    public enum ADActivityLookupType
    {
        Manager = 0,
        Subordinates = 1,
        Peers = 3,
        GroupExpansion = 4
    }


    #region look n feel
    internal sealed class DirectoryLookupCustomActivityDesignerTheme : ActivityDesignerTheme
    {
        public DirectoryLookupCustomActivityDesignerTheme(WorkflowTheme theme)
            : base(theme)
        {
            this.BorderColor = Color.GreenYellow;
            this.BorderStyle = DashStyle.Solid;
            this.BackColorStart = Color.WhiteSmoke;
            this.BackColorEnd = Color.RosyBrown;
            this.BackgroundStyle = LinearGradientMode.Vertical;
        }
    }

    [ActivityDesignerThemeAttribute(typeof(DirectoryLookupCustomActivityDesignerTheme))]
    public class DirectoryLookupCustomActivityDesigner : ActivityDesigner
    {

    }
    #endregion


    [ToolboxItemAttribute(typeof(ActivityToolboxItem))]
    [Designer(typeof(DirectoryLookupCustomActivityDesigner), typeof(IDesigner))]
    [ToolboxBitmap(typeof(DirectoryLookupActivity), "Resources.Directory.png")]
    public partial class DirectoryLookupActivity : System.Workflow.ComponentModel.Activity
	{
		public DirectoryLookupActivity()
		{
			InitializeComponent();
		}

        public static DependencyProperty DirectoryUriProperty = System.Workflow.ComponentModel.DependencyProperty.Register("DirectoryUri", typeof(string), typeof(DirectoryLookupActivity));

        [Description("The URI of the directory. Either an Active Directory Server or a path to an XML File.")]
        [Category("Directory")]
        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public string DirectoryUri
        {
            get
            {
                return ((string)(base.GetValue(DirectoryLookupActivity.DirectoryUriProperty)));
            }
            set
            {
                base.SetValue(DirectoryLookupActivity.DirectoryUriProperty, value);
            }
        }

        public static DependencyProperty QueryProperty = DependencyProperty.Register("Query", typeof(System.String), typeof(DirectoryLookupActivity));
        [DescriptionAttribute("The directory object name (group name or SAM Account) to query.")]
        [DesignerSerializationVisibilityAttribute(DesignerSerializationVisibility.Visible)]
        [ValidationOption(ValidationOption.Required)]
        [BrowsableAttribute(true)]
        [Category("Query")]
        [DefaultValue("")]
        public string Query
        {
            get
            {
                return ((String)(base.GetValue(DirectoryLookupActivity.QueryProperty)));
            }
            set
            {
                base.SetValue(DirectoryLookupActivity.QueryProperty, value);
            }
        }


        public static DependencyProperty QuerySourceProperty =
            DependencyProperty.Register("QuerySource", typeof(ADActivityLookupSource), typeof(DirectoryLookupActivity));
        [DescriptionAttribute("Specifies the source of the query, either an Active Directory Server or an XML File.")]
        [DesignerSerializationVisibilityAttribute(DesignerSerializationVisibility.Visible)]
        [ValidationOption(ValidationOption.Required)]
        [BrowsableAttribute(true)]
        [Category("Directory")]
        [DefaultValue(ADActivityLookupSource.ActiveDirectory)]
        public DirectoryLookupActivityLibrary.ADActivityLookupSource QuerySource
        {
            get
            {
                return ((ADActivityLookupSource)(base.GetValue(DirectoryLookupActivity.QuerySourceProperty)));
            }
            set
            {
                base.SetValue(DirectoryLookupActivity.QuerySourceProperty, value);
            }
        }


        public static DependencyProperty QueryTypeProperty =
            DependencyProperty.Register("QueryType", typeof(ADActivityLookupType), typeof(DirectoryLookupActivity));
        [DescriptionAttribute("The query type is used to specify the type of directory relationship to retrieve data for.")]
        [DesignerSerializationVisibilityAttribute(DesignerSerializationVisibility.Visible)]
        [ValidationOption(ValidationOption.Required)]
        [BrowsableAttribute(true)]
        [Category("Query")]
        [DefaultValue(ADActivityLookupType.Manager)]
        public DirectoryLookupActivityLibrary.ADActivityLookupType QueryType
        {
            get
            {
                return ((ADActivityLookupType)(base.GetValue(DirectoryLookupActivity.QueryTypeProperty)));
            }
            set
            {
                base.SetValue(DirectoryLookupActivity.QueryTypeProperty, value);
            }
        }

        public static DependencyProperty QueryResultsProperty = DependencyProperty.Register("QueryResults", typeof(List<string>), typeof(DirectoryLookupActivityLibrary.DirectoryLookupActivity));
        [DesignerSerializationVisibilityAttribute(DesignerSerializationVisibility.Visible)]
        [ValidationOption(ValidationOption.Optional)]
        [BrowsableAttribute(true)]
        [DescriptionAttribute("An array list of the Object SAM account names retrieved from the directory.")]
        [CategoryAttribute("Results")]
        [DefaultValue(null)]
        public List<string> QueryResults
        {
            get
            {
                return ((List<string>)(base.GetValue(DirectoryLookupActivityLibrary.DirectoryLookupActivity.QueryResultsProperty)));
            }
            set
            {
                base.SetValue(DirectoryLookupActivityLibrary.DirectoryLookupActivity.QueryResultsProperty, value);
            }
        }

        #region Events

        public static DependencyProperty QueryingEvent =
            DependencyProperty.Register("Querying", typeof(EventHandler), typeof(DirectoryLookupActivity));
        [DescriptionAttribute("Use this Handler to do any pre-processing or to set query parameters at run time.")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        [ValidationOption(ValidationOption.Optional)]
        [BrowsableAttribute(true)]
        [Category("Handlers")]
        public event EventHandler Querying
        {
            add
            {
                base.AddHandler(DirectoryLookupActivity.QueryingEvent, value);
            }
            remove
            {
                base.RemoveHandler(DirectoryLookupActivity.QueryingEvent, value);
            }
        }

        public static DependencyProperty QueriedEvent =
            DependencyProperty.Register("Queried", typeof(EventHandler), typeof(DirectoryLookupActivity));
        [DescriptionAttribute("This event is raised when the query has completed.")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        [ValidationOption(ValidationOption.Optional)]
        [BrowsableAttribute(true)]
        [Category("Handlers")]
        public event EventHandler Queried
        {
            add
            {
                base.AddHandler(DirectoryLookupActivity.QueriedEvent, value);
            }
            remove
            {
                base.RemoveHandler(DirectoryLookupActivity.QueriedEvent, value);
            }
        }
        #endregion

        #region Execution
        
        private static List<string> GetUsersFromAD(string objectName, string directoryUri, ADActivityLookupType lookupType)
        {
            ADHelper adh = new ADHelper(directoryUri);

            switch (lookupType)
            {
                case ADActivityLookupType.GroupExpansion:
                    return adh.GetADGroupUsers(objectName);
                case ADActivityLookupType.Manager:
                    string manager = adh.GetUsersManager(objectName);
                    List<string> managers = new List<string>();
                    managers.Add(manager);
                    return managers;
                case ADActivityLookupType.Peers:
                    return adh.GetUsersPeers(objectName);
                case ADActivityLookupType.Subordinates:
                    return adh.GetUsersDirectReports(objectName);
                default:
                    throw new NotImplementedException("Cannot lookup. No implementation for that LookupType.");
            }
        }

        private static List<string> GetUsersFromXmlFile(string objectName, string fileName, ADActivityLookupType lookupType)
        {
            //Open the XML Org Chart file so that we can query it with XPath
            XPathNavigator xpn = new XPathDocument(fileName).CreateNavigator();

            //Prepare the appropriate XPath Statement
            string xpathStatement = "";
            switch (lookupType)
            {
                case ADActivityLookupType.GroupExpansion:
                    xpathStatement = "/organization/users/user[@accountName = /organization/groups/group[@name='" + objectName + "']/member]";
                    break;
                case ADActivityLookupType.Manager:
                    xpathStatement = "/organization/users/user[@accountName=/organization/users/user[@accountName='" + objectName + "']/manager]";
                    break;
                case ADActivityLookupType.Peers:
                    xpathStatement = "/organization/users/user[manager=/organization/users/user[@accountName='" + objectName + "']/manager]";
                    break;
                case ADActivityLookupType.Subordinates:
                    xpathStatement = "/organization/users/user[manager = '" + objectName + "']";
                    break;
            }

            //Execute the XPth statement to return a list of user names into the ArrayList.
            List<string> userNames = new List<string>();
            XPathNodeIterator xpi = xpn.Select(xpathStatement);
            while (xpi.MoveNext())
            {
                userNames.Add(xpi.Current.GetAttribute("accountName", ""));
            }

            return userNames;
        }


        public class ADQueryFinishedEventArgs : EventArgs
        {
            public List<string> queryResults;
            public ADQueryFinishedEventArgs(List<string> queryResults)
            {
                this.queryResults = queryResults;
            }
        }

        protected override ActivityExecutionStatus Execute(ActivityExecutionContext context)
        {

            //Raise the QueryingEvent
            this.RaiseEvent(QueryingEvent, this, new EventArgs());

            switch (this.QuerySource)
            {
                case ADActivityLookupSource.XmlFile:
                    QueryResults = GetUsersFromXmlFile(this.Query, this.DirectoryUri, this.QueryType);
                    break;
                case ADActivityLookupSource.ActiveDirectory:
                    QueryResults = GetUsersFromAD(this.Query, this.DirectoryUri, this.QueryType);
                    break;
            }

            //Raise the Query finsihed event
            ADQueryFinishedEventArgs queryFinishedEventArgs = new ADQueryFinishedEventArgs(QueryResults);
            this.RaiseEvent(QueriedEvent, this, queryFinishedEventArgs);

            return ActivityExecutionStatus.Closed;
        }


        #endregion
    }
}
