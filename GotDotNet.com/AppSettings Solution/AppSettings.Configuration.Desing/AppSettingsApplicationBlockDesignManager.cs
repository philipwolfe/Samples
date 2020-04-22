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
using System.Configuration;
using System.Windows.Forms;
using Microsoft.Practices.EnterpriseLibrary.Configuration;
using Microsoft.Practices.EnterpriseLibrary.Configuration.Design;

using Kokuti.EnterpriseLibrary.AppSettings;

namespace Kokuti.EnterpriseLibrary.AppSettings.Design
{
	/// <summary>
	/// Implements IConfigurationDesignManager for AppSettingsApplicationBlock.
	/// </summary>
	public class AppSettingsApplicationBlockDesignManager : IConfigurationDesignManager
	{
		#region IConfigurationDesignManager Members

		public void Register(IServiceProvider serviceProvider)
		{
			CreateCommands(serviceProvider);
		}

		public void BuildContext(IServiceProvider serviceProvider, Microsoft.Practices.EnterpriseLibrary.Configuration.ConfigurationDictionary configurationDictionary)
		{
			AppSettingsApplicationBlockNode node = GetSectionRootNode(serviceProvider);
			if( node !=null)
			{
				AppSettingsApplicationBlockData data = node.AppSettingsApplicationBlockData;
				configurationDictionary[AppSettingsApplicationBlockData.SectionName] = data;
			}
		}

		public void Open(IServiceProvider serviceProvider)
		{
			ConfigurationNode configurationNode = null;
			AppSettingsApplicationBlockData rootData = null;
			AppSettingsApplicationBlockNode rootNode = null;
			ConfigurationContext configurationContext = ServiceHelper.GetCurrentConfigurationContext(serviceProvider);
			if (configurationContext.IsValidSection(AppSettingsApplicationBlockData.SectionName))
			{
				try
				{
					rootData = (AppSettingsApplicationBlockData)configurationContext.GetConfiguration(AppSettingsApplicationBlockData.SectionName);
					rootNode = new AppSettingsApplicationBlockNode(rootData);
					configurationNode = ServiceHelper.GetCurrentRootNode(serviceProvider);
					configurationNode.Nodes.Add(rootNode);
				}
				catch (ConfigurationException e)
				{
					ServiceHelper.LogError(serviceProvider, rootNode, e);
				}
			}
		}

		public void Save(IServiceProvider serviceProvider)
		{
			ConfigurationContext configurationContext = ServiceHelper.GetCurrentConfigurationContext(serviceProvider);
			if (configurationContext.IsValidSection(AppSettingsApplicationBlockData.SectionName))
			{
				AppSettingsApplicationBlockNode rootNode = null;
				try
				{
					IUIHierarchy hierarchy = ServiceHelper.GetCurrentHierarchy(serviceProvider);
					rootNode = hierarchy.FindNodeByType(typeof(AppSettingsApplicationBlockNode)) as AppSettingsApplicationBlockNode;
					if (rootNode == null)
					{
						return;
					}
					AppSettingsApplicationBlockData rootData = rootNode.AppSettingsApplicationBlockData;
					configurationContext.WriteConfiguration(AppSettingsApplicationBlockData.SectionName, rootData);
				}
				catch (ConfigurationException e)
				{
					ServiceHelper.LogError(serviceProvider, rootNode, e);
				}
				catch (InvalidOperationException e)
				{
					ServiceHelper.LogError(serviceProvider, rootNode, e);
				}
			}
		}

		private static AppSettingsApplicationBlockNode GetSectionRootNode(IServiceProvider serviceProvider)
		{
			IUIHierarchy hierarchy = ServiceHelper.GetCurrentHierarchy(serviceProvider);
			if(hierarchy == null)
				return null;
			return hierarchy.FindNodeByType(typeof(AppSettingsApplicationBlockNode)) as AppSettingsApplicationBlockNode;
		}

		private static void CreateCommands(IServiceProvider serviceProvider)
		{
			IUIHierarchyService hierarchyService = ServiceHelper.GetUIHierarchyService(serviceProvider);
			IUIHierarchy currentHierarchy = hierarchyService.SelectedHierarchy;
			bool containsNode = currentHierarchy.ContainsNodeType(typeof(AppSettingsApplicationBlockNode));

			IMenuContainerService menuService = ServiceHelper.GetMenuContainerService(serviceProvider);
			ConfigurationMenuItem item = new ConfigurationMenuItem("AppSettings Application Block", new AddConfigurationSectionCommand(serviceProvider, typeof(AppSettingsApplicationBlockNode), AppSettingsApplicationBlockData.SectionName), ServiceHelper.GetCurrentRootNode(serviceProvider), Shortcut.None, "AppSettings Application Block", InsertionPoint.New);
			item.Enabled = !containsNode;
			menuService.MenuItems.Add(item);
		}


		#endregion
	}
}
