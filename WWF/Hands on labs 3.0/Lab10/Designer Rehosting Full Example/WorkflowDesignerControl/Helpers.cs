//--------------------------------------------------------------------------------
// This file is a "Sample" as from Windows Workflow Foundation
// Hands on Labs
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

namespace WorkflowDesignerControl
{
    #region Using Statements

    using System;
	using System.CodeDom;
	using System.Collections;
	using System.ComponentModel;
	using System.Collections.Generic;
	using System.ComponentModel.Design;
	using System.ComponentModel.Design.Serialization;
	using System.Workflow.ComponentModel.Compiler;
	using System.Workflow.ComponentModel;
	using System.Workflow.ComponentModel.Serialization;
    using Microsoft.CSharp;
    using System.Xml;
    
    #endregion
    
    #region Helpers

    internal static class Helpers
    {
        internal static Activity GetRootActivity(Activity activity)
        {
            if (activity == null)
                throw new ArgumentNullException("activity");

            while (activity.Parent != null)
                activity = activity.Parent;

            return activity;
        }

        internal static Activity GetRootActivity(string fileName)
        {
            XmlReader reader = new XmlTextReader(fileName);
            Activity rootActivity = null;
            try
            {
                WorkflowMarkupSerializer xomlSerializer = new WorkflowMarkupSerializer();
                rootActivity = xomlSerializer.Deserialize(reader) as Activity;
            }
            finally
            {
                reader.Close();
            }
            return rootActivity;

        }

        internal static Type GetDataSourceClass(Activity activity, IServiceProvider serviceProvider)
        {
            if (activity == null)
                throw new ArgumentNullException("activity");
            if (serviceProvider == null)
                throw new ArgumentNullException("serviceProvider");

            Type activityType = null;
            string className = null;
            if (activity == GetRootActivity(activity))
                className = activity.GetValue(WorkflowMarkupSerializer.XClassProperty) as String;

            if (!String.IsNullOrEmpty(className))
            {
                ITypeProvider typeProvider = (ITypeProvider)serviceProvider.GetService(typeof(ITypeProvider));
                if (typeProvider == null)
                    throw new InvalidOperationException(typeof(ITypeProvider).Name);

                activityType = typeProvider.GetType(className);
            }
            else
            {
                return activity.GetType();
            }

            return activityType;
        }

        internal static CodeNamespace GenerateCodeFromXomlDocument(Activity rootActivity, IServiceProvider serviceProvider, ref string nameSpace, ref string typeName)
        {
            CodeNamespaceCollection codeNamespaces = new CodeNamespaceCollection();
            CSharpCodeProvider codeDomProvider = new CSharpCodeProvider();

            // generate activity class
            string activityFullClassName = rootActivity.GetValue(WorkflowMarkupSerializer.XClassProperty) as string;
            CodeTypeDeclaration activityTypeDeclaration = null;
            CodeNamespace activityCodeNamespace = null;

            if (codeDomProvider != null && !string.IsNullOrEmpty(activityFullClassName))
            {
                // get class and namespace names
                string activityNamespaceName, activityClassName;
                Helpers.GetNamespaceAndClassName(activityFullClassName, out activityNamespaceName, out activityClassName);
                nameSpace = activityNamespaceName;
                typeName = activityClassName;

                if (codeDomProvider.IsValidIdentifier(activityClassName))
                {
                    DesignerSerializationManager designerSerializationManager = new DesignerSerializationManager(serviceProvider);
                    using (designerSerializationManager.CreateSession())
                    {
                        ActivityCodeDomSerializationManager codeDomSerializationManager = new ActivityCodeDomSerializationManager(designerSerializationManager);
                        TypeCodeDomSerializer typeCodeDomSerializer = codeDomSerializationManager.GetSerializer(rootActivity.GetType(), typeof(TypeCodeDomSerializer)) as TypeCodeDomSerializer;

                        // get all activities
                        bool generateCode = true;

                        ArrayList allActivities = new ArrayList();
                        allActivities.Add(rootActivity);
                        if (rootActivity is CompositeActivity)
                        {
                            foreach (Activity activity in Helpers.GetNestedActivities((CompositeActivity)rootActivity))
                            {
                                if (Helpers.IsActivityLocked(activity))
                                    continue;
                                if (codeDomProvider.IsValidIdentifier(codeDomSerializationManager.GetName(activity)))
                                {
                                    allActivities.Insert(0, activity);
                                }
                                else
                                {
                                    generateCode = false;
                                    break;
                                }
                            }
                        }

                        if (generateCode)
                        {
                            DummySite dummySite = new DummySite();
                            foreach (Activity nestedActivity in allActivities)
                                ((IComponent)nestedActivity).Site = dummySite;
                            ((IComponent)rootActivity).Site = dummySite;

                            // create activity partial class
                            activityTypeDeclaration = typeCodeDomSerializer.Serialize(codeDomSerializationManager, rootActivity, allActivities);
                            activityTypeDeclaration.IsPartial = true;

                            // create a new namespace and add activity class into that
                            activityCodeNamespace = new CodeNamespace(activityNamespaceName);
                            activityCodeNamespace.Types.Add(activityTypeDeclaration);
                        }
                    }
                }
            }

            if (activityTypeDeclaration != null)
            {
                Queue activitiesQueue = new Queue(new object[] { rootActivity });
                while (activitiesQueue.Count > 0)
                {
                    Activity activity = (Activity)activitiesQueue.Dequeue();
                    if (Helpers.IsActivityLocked(activity))
                        continue;

                    Queue childActivities = new Queue(new object[] { activity });
                    while (childActivities.Count > 0)
                    {
                        Activity childActivity = (Activity)childActivities.Dequeue();
                        if (childActivity is CompositeActivity)
                        {
                            foreach (Activity nestedChildActivity in ((CompositeActivity)childActivity).Activities)
                            {
                                childActivities.Enqueue(nestedChildActivity);
                            }
                        }

                        CodeTypeMemberCollection codeSegments = childActivity.GetValue(WorkflowMarkupSerializer.XCodeProperty) as CodeTypeMemberCollection;
                        if (codeSegments != null)
                        {
                            foreach (CodeSnippetTypeMember codeSegmentMember in codeSegments)
                                activityTypeDeclaration.Members.Add(codeSegmentMember);
                        }
                    }
                }

                
                activityTypeDeclaration.LinePragma = new CodeLinePragma((string)rootActivity.GetValue(ActivityCodeDomSerializer.MarkupFileNameProperty), Math.Max((int)rootActivity.GetValue(ActivityMarkupSerializer.StartLineProperty), 1));
                CodeConstructor constructor = null;
                CodeMemberMethod method = null;
                foreach (CodeTypeMember typeMember in activityTypeDeclaration.Members)
                {
                    if (constructor == null && typeMember is CodeConstructor)
                        constructor = typeMember as CodeConstructor;

                    if (method == null && typeMember is CodeMemberMethod && typeMember.Name.Equals("InitializeComponent", StringComparison.Ordinal))
                        method = typeMember as CodeMemberMethod;

                    if (constructor != null && method != null)
                        break;
                }

                if (constructor != null)
                    constructor.LinePragma = new CodeLinePragma((string)rootActivity.GetValue(ActivityCodeDomSerializer.MarkupFileNameProperty), Math.Max((int)rootActivity.GetValue(ActivityMarkupSerializer.StartLineProperty), 1));

                method.LinePragma = new CodeLinePragma((string)rootActivity.GetValue(ActivityCodeDomSerializer.MarkupFileNameProperty), Math.Max((int)rootActivity.GetValue(ActivityMarkupSerializer.StartLineProperty), 1));
            }
            return activityCodeNamespace;
        }

        internal static void GetNamespaceAndClassName(string fullQualifiedName, out string namespaceName, out string className)
        {
            namespaceName = String.Empty;
            className = String.Empty;

            if (fullQualifiedName == null)
                return;

            int indexOfDot = fullQualifiedName.LastIndexOf('.');
            if (indexOfDot != -1)
            {
                namespaceName = fullQualifiedName.Substring(0, indexOfDot);
                className = fullQualifiedName.Substring(indexOfDot + 1);
            }
            else
            {
                className = fullQualifiedName;
            }
        }

        internal static Activity[] GetNestedActivities(CompositeActivity compositeActivity)
        {

            if (compositeActivity == null)
                throw new ArgumentNullException("compositeActivity");

            IList<Activity> childActivities = null;
            ArrayList nestedActivities = new ArrayList();
            Queue compositeActivities = new Queue();
            compositeActivities.Enqueue(compositeActivity);
            while (compositeActivities.Count > 0)
            {
                CompositeActivity compositeActivity2 = (CompositeActivity)compositeActivities.Dequeue();
                childActivities = compositeActivity2.Activities;

                foreach (Activity activity in childActivities)
                {
                    nestedActivities.Add(activity);
                    if (activity is CompositeActivity)
                        compositeActivities.Enqueue(activity);
                }
            }
            return (Activity[])nestedActivities.ToArray(typeof(Activity));
        }

        internal static bool IsActivityLocked(Activity activity)
        {
            if (activity == null)
                throw new ArgumentNullException("activity");

            CompositeActivity parent = activity.Parent;
            while (parent != null)
            {
                // If root, not locked
                if (parent.Parent == null)
                    return false;

                // Any custom activity found, then locked
                if (IsCustomActivity(parent))
                    return true;

                parent = parent.Parent;
            }

            return false;
        }

        internal static bool IsCustomActivity(CompositeActivity compositeActivity)
        {
            if (compositeActivity == null)
                throw new ArgumentNullException("compositeActivity");

            Guid CustomActivity = new Guid("298CF3E0-E9E0-4d41-A11B-506E9132EB27");
            Guid CustomActivityDefaultName = new Guid("8bcd6c40-7bf6-4e60-8eea-bbf40bed92da");

            if (compositeActivity.UserData.Contains(new Guid("298CF3E0-E9E0-4d41-A11B-506E9132EB27")))
            {
                return (bool)(compositeActivity.UserData[CustomActivity]);
            }
            else
            {
                try
                {
                    CompositeActivity activity = Activator.CreateInstance(compositeActivity.GetType()) as CompositeActivity;
                    if (activity != null && activity.Activities.Count > 0)
                    {
                        compositeActivity.UserData[CustomActivityDefaultName] = activity.Name;
                        compositeActivity.UserData[CustomActivity] = true;
                        return true;
                    }
                }
                catch
                {
                }
            }

            compositeActivity.UserData[CustomActivity] = false;
            return false;
        }

        private class DummySite : ISite
        {
            public IComponent Component { get { return null; } }
            public IContainer Container { get { return null; } }
            public bool DesignMode { get { return true; } }
            public string Name { get { return string.Empty; } set { } }
            public object GetService(Type type) { return null; }
        }
    }

    #endregion
}
