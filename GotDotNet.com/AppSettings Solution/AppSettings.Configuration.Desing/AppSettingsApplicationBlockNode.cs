//===============================================================================
// Robert Kokuti's AppSettings Application Block for 
// Microsoft patterns & practices Enterprise Library
// Comments? send to robertkokuti@hotmail.com
// Shared Library
//===============================================================================
// Copyright © Robert Kokuti.  All rights reserved.
// THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY
// OF ANY KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT
// LIMITED TO THE IMPLIED WARRANTIES OF MERCHANTABILITY AND
// FITNESS FOR A PARTICULAR PURPOSE.
//===============================================================================

using System;
using System.ComponentModel;
using Microsoft.Practices.EnterpriseLibrary.Common;
using Microsoft.Practices.EnterpriseLibrary.Configuration.Design;
using Microsoft.Practices.EnterpriseLibrary.Configuration.Design.Validation;

using Kokuti.EnterpriseLibrary.AppSettings;

namespace Kokuti.EnterpriseLibrary.AppSettings.Design
{
	/// <summary>
	/// Implements ConfigurationNode for AppSettings
	/// </summary>
	[Image(typeof(AppSettingsApplicationBlockNode)),
	ServiceDependency(typeof(ILinkNodeService))]
	public class AppSettingsApplicationBlockNode : ConfigurationNode
	{
		private AppSettingsApplicationBlockData appSettingsApplicationBlockData = null;

		public AppSettingsApplicationBlockNode(AppSettingsApplicationBlockData sectionData) : base()
		{
			if(sectionData == null)
			{
				throw new ArgumentNullException("sectionData in AppSettingsApplicationBlockNode");
			}
			this.appSettingsApplicationBlockData = sectionData;
		}

		public AppSettingsApplicationBlockNode() : this(new AppSettingsApplicationBlockData()){}

		public virtual AppSettingsApplicationBlockData AppSettingsApplicationBlockData
		{
			get
			{
				return this.appSettingsApplicationBlockData;
			}
			set
			{
				this.appSettingsApplicationBlockData = value;
			}
		}

		protected override void OnSited()
		{
			base.OnSited ();
			Site.Name = "AppSettings Application Block";
		}

	}
}
