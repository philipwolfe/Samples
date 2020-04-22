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
using Microsoft.Practices.EnterpriseLibrary.Configuration;

namespace Kokuti.EnterpriseLibrary.AppSettings
{
	/// <summary>
	/// This class can be used to access application configuration data.
	/// It will work accross web farm and updates automatically if the content
	/// in the storage has changed. Thread safe.
	/// </summary>
	public class AppSettingsHelper
	{
		//Declares a delegate for a method that takes in an int and returns a String.
		public delegate void AppSettingsChangedDelegate();
		public static event AppSettingsChangedDelegate AppSettingsChangedEvent = null;
		private static void FireChangedEvent() 
		{
			if (AppSettingsChangedEvent != null)
				AppSettingsChangedEvent();
		}

		private static AppSettingsApplicationBlockData appSettingsApplicationBlockData = null;

		/// <summary>
		/// accessor to a shared instance of AppSettingsApplicationBlockData
		/// first time access attempts to load from config storage
		/// </summary>
		public static AppSettingsApplicationBlockData AppSettings
		{
			get
			{
				if (appSettingsApplicationBlockData == null)
				{
					appSettingsApplicationBlockData = (AppSettingsApplicationBlockData)ConfigurationManager.GetConfiguration(AppSettingsApplicationBlockData.SectionName);
				}
				return appSettingsApplicationBlockData;
			}
			set
			{
				appSettingsApplicationBlockData = value;
			}
		}


		/// <summary>
		/// initializes static members and establishes ConfigurationChanged Event Handler
		/// </summary>
		static AppSettingsHelper()
		{
			appSettingsApplicationBlockData = null;
			ConfigurationManager.ConfigurationChanged += new ConfigurationChangedEventHandler(OnConfigurationChanged);
		}


		/// <summary>
		/// ConfigurationChanged Event Handler 
		/// Re-loads configuration data if the AppSettingsApplicationBlockData section changed
		/// </summary>
		private static void OnConfigurationChanged(object sender, ConfigurationChangedEventArgs args)
		{
			appSettingsApplicationBlockData = (AppSettingsApplicationBlockData)ConfigurationManager.GetConfiguration(AppSettingsApplicationBlockData.SectionName);
			FireChangedEvent();
		}


		/// <summary>
		/// saves the shared instance of AppSettingsApplicationBlockData to config storage
		/// </summary>
		public static void Save()
		{
			ConfigurationManager.WriteConfiguration(AppSettingsApplicationBlockData.SectionName, AppSettings);
		}
	}
}
