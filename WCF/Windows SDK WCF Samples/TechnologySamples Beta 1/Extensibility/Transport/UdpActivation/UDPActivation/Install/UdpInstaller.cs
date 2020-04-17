// ----------------------------------------------------------------------------
// Copyright (C) 2003-2005 Microsoft Corporation, All rights reserved.
// ----------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Text;
using System.ServiceModel.Activation;
using WebAdmin = Microsoft.Web.Administration;
using Microsoft.ServiceModel.Samples.Channels;
using System.Security.Principal;
using System.Web.Configuration;
using System.IO;
using System.Configuration;
using Microsoft.ServiceModel.Samples.Hosting;
using System.Reflection;

namespace Microsoft.ServiceModel.Samples.Install
{
    public struct UdpInstallerOptions
    {
        public bool ListenerAdapterChecked;
        public bool ProtocolHandlerChecked;
    }

    public static class UdpInstaller
    {
        const string ListenerAdapterPath = "system.applicationHost/listenerAdapters";
        const string ProtocolsPath = "system.web/protocols";

        public static void Install(UdpInstallerOptions options)
        {
            if (options.ListenerAdapterChecked)
            {
                WebAdmin.ServerManager sm = new WebAdmin.ServerManager();
                WebAdmin.ConfigurationManager wasConfiguration = sm.GetApplicationHostConfigurationManager(new WebAdmin.WebConfigurationMap(), String.Empty);
                WebAdmin.ConfigurationSection section = wasConfiguration.GetSection(ListenerAdapterPath);
                WebAdmin.ConfigurationElementCollection listenerAdaptersCollection = section.GetChildCollection(String.Empty);

                WebAdmin.ConfigurationElement element = listenerAdaptersCollection.AddElement();
                element.GetAttribute("name").Value = UdpConstants.UdpProtocolId;
                element.GetAttribute("identity").Value = WindowsIdentity.GetCurrent().User.Value;
                wasConfiguration.Save();
            }

            if (options.ProtocolHandlerChecked)
            {
                Configuration rootWebConfig = GetRootWebConfiguration();
                ProtocolsSection section = (ProtocolsSection)rootWebConfig.GetSection(ProtocolsPath);
                ProtocolElement element = new ProtocolElement(UdpConstants.UdpProtocolId);
                
                element.ProcessHandlerType = typeof(UdpProcessProtocolHandler).AssemblyQualifiedName;
                element.AppDomainHandlerType = typeof(UdpAppDomainProtocolHandler).AssemblyQualifiedName;
                element.Validate = false;

                section.Protocols.Add(element);
                rootWebConfig.Save();
            }
        }

        static Configuration GetRootWebConfiguration()
        {
            string rootWebConfigPath = Path.Combine(Path.GetDirectoryName(Assembly.GetAssembly(typeof(object)).Location),
                @"config\web.config");

            WebConfigurationFileMap fileMap = new WebConfigurationFileMap();
            fileMap.ApplicationHostFilename = rootWebConfigPath;
            return WebConfigurationManager.OpenMappedWebConfiguration(fileMap, string.Empty);
        }

        public static void Uninstall(UdpInstallerOptions options)
        {
            if (options.ListenerAdapterChecked)
            {
                WebAdmin.ServerManager sm = new WebAdmin.ServerManager();
                WebAdmin.ConfigurationManager wasConfiguration = sm.GetApplicationHostConfigurationManager(new WebAdmin.WebConfigurationMap(), String.Empty);
                WebAdmin.ConfigurationSection section = wasConfiguration.GetSection(ListenerAdapterPath);
                WebAdmin.ConfigurationElementCollection listenerAdaptersCollection = section.GetChildCollection(String.Empty);

                for (int i = 0; i<listenerAdaptersCollection.Count; i++)
                {
                    WebAdmin.ConfigurationElement element = listenerAdaptersCollection[i];

                    if (string.Compare((string)element.GetAttribute("name").Value,
                        UdpConstants.UdpProtocolId, StringComparison.OrdinalIgnoreCase) == 0)
                    {
                        listenerAdaptersCollection.RemoveAt(i);
                    }
                }

                wasConfiguration.Save();
            }

            if (options.ProtocolHandlerChecked)
            {
                Configuration rootWebConfig = GetRootWebConfiguration();
                ProtocolsSection section = (ProtocolsSection)rootWebConfig.GetSection(ProtocolsPath);
                section.Protocols.Remove(UdpConstants.UdpProtocolId);
                rootWebConfig.Save();
            }
        }
    }
}
