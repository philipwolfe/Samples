using System;
using System.Collections.Generic;
using System.Configuration;
using System.Xml;
using System.Xml.Serialization;

namespace Microsoft.Workflow.Samples.Administration
{
    public sealed class DynamicUpdateSampleConfigurationSectionGroup : ConfigurationSectionGroup
    {
        public DynamicUpdateSampleConfigurationSectionGroup()
        {
        }
    }

    #region Reference Assembly related
    public sealed class ReferenceAssemblySectionHandler : IConfigurationSectionHandler
    {
        #region IConfigurationSectionHandler Members

        object IConfigurationSectionHandler.Create(object parent, object configContext, XmlNode section)
        {
            List<ReferenceAssembly> referenceAssemblies = new List<ReferenceAssembly>();
            XmlSerializer xmlSerializer = null;
            xmlSerializer = new XmlSerializer(typeof(ReferenceAssembly));
            foreach (XmlNode referenceAssemblyNode in section.ChildNodes)
            {
                ReferenceAssembly referenceAssembly = xmlSerializer.Deserialize(new XmlNodeReader(referenceAssemblyNode)) as ReferenceAssembly;
                if (referenceAssembly != null)
                    referenceAssemblies.Add(referenceAssembly);
            }
            return referenceAssemblies;
        }

        #endregion
    }

    [XmlType("referenceAssembly")]
    public sealed class ReferenceAssembly
    {
        private string assemblyPath;

        [XmlAttribute]
        public string AssemblyPath
        {
            get { return this.assemblyPath; }
            set { this.assemblyPath = value; }
        }
    }
    #endregion

    #region Workflow Activity Related (for toolbox and workflow types)
    public sealed class WorkflowActivityTypeSectionHandler : IConfigurationSectionHandler
    {
        #region IConfigurationSectionHandler Members

        object IConfigurationSectionHandler.Create(object parent, object configContext, XmlNode section)
        {
            List<WorkflowActivityType> workflowActivityTypes = new List<WorkflowActivityType>();
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(WorkflowActivityType));
            foreach (XmlNode workflowActivityTypeNode in section.ChildNodes)
            {
                WorkflowActivityType workflowActivityType = xmlSerializer.Deserialize(new XmlNodeReader(workflowActivityTypeNode)) as WorkflowActivityType;
                if (workflowActivityType != null)
                    workflowActivityTypes.Add(workflowActivityType);
            }
            return workflowActivityTypes;
        }

        #endregion
    }

    public sealed class ActivateWorkflowTypeSectionHandler : IConfigurationSectionHandler
    {
        #region IConfigurationSectionHandler Members

        object IConfigurationSectionHandler.Create(object parent, object configContext, XmlNode section)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(WorkflowActivityType));
            foreach (XmlNode workflowActivityTypeNode in section.ChildNodes)
            {
                WorkflowActivityType workflowActivityType = xmlSerializer.Deserialize(new XmlNodeReader(workflowActivityTypeNode)) as WorkflowActivityType;
                if (workflowActivityType != null)
                    return workflowActivityType;
            }
            return null;
        }

        #endregion
    }

    [XmlType("workflowActivityType")]
    [Serializable]
    public sealed class WorkflowActivityType
    {
        private string assemblyName;
        private string typeName;

        [XmlAttribute]
        public string Assembly
        {
            get { return this.assemblyName; }
            set { this.assemblyName = value; }
        }

        [XmlAttribute]
        public string TypeName
        {
            get { return this.typeName; }
            set { this.typeName = value; }
        }
    }
    #endregion

    #region SQL connection related
    public sealed class SqlConnectionInfoSectionHandler : IConfigurationSectionHandler
    {
        #region IConfigurationSectionHandler Members

        object IConfigurationSectionHandler.Create(object parent, object configContext, XmlNode section)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(SqlConnectionInfo));
            foreach (XmlNode sqlConnectionInfoNode in section.ChildNodes)
            {
                SqlConnectionInfo sqlConnectionInfo = xmlSerializer.Deserialize(new XmlNodeReader(sqlConnectionInfoNode)) as SqlConnectionInfo;
                if (sqlConnectionInfo != null)
                    return sqlConnectionInfo;
            }
            return null;
        }

        #endregion
    }

    [XmlType("sqlConnectionInfo")]
    public sealed class SqlConnectionInfo
    {
        public SqlConnectionInfo()
        {
        }

        private string connectionString;

        [XmlAttribute]
        public string ConnectionString
        {
            get { return this.connectionString; }
            set { this.connectionString = value; }
        }
    }
    #endregion
}