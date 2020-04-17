using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.ComponentModel.Design.Serialization;
using System.IO;
using System.Reflection;
using System.Workflow.ComponentModel;
using System.Workflow.ComponentModel.Design;
using System.Workflow.ComponentModel.Serialization;
using System.Xml;
using Microsoft.Workflow.Samples.Administration;

namespace Microsoft.Workflow.Samples.WorkflowManager
{
    internal sealed class Loader : WorkflowDesignerLoader
    {
        private string xomlDocument = string.Empty;
        private bool allowDynamicUpdates = false;

        internal Loader()
        {
        }

        public string DefaultNamespace
        {
            get { return "tracking"; }
        }

        public bool AllowDynamicUpdates
        {
            get { return this.allowDynamicUpdates; }
            set { this.allowDynamicUpdates = value; }
        }

        public override TextReader GetFileReader(string filePath)
        {
            return new StreamReader(filePath);
        }

        public override TextWriter GetFileWriter(string filePath)
        {
            return new StreamWriter(filePath);
        }

        public override void ForceReload()
        {
        }

        public override string FileName
        {
            get { return string.Empty; }
        }

        internal string XomlDocument
        {
            get { return this.xomlDocument; }
            set { this.xomlDocument = value; }
        }

        protected override void Initialize()
        {
            base.Initialize();
        }

        internal void UpdateCanModifyFlag(IList<Activity> activities)
        {
            if (!AllowDynamicUpdates)
                return;

            List<Activity> processingActivities = new List<Activity>();
            foreach (Activity rootActivity in activities)
            {
                processingActivities.Add(rootActivity);
                CompositeActivity compositeActivity = rootActivity as CompositeActivity;
                if (compositeActivity != null)
                    processingActivities.AddRange(GetNestedActivities(compositeActivity));
            }

            foreach (Activity childActivity in processingActivities)
            {
                if (childActivity is CompositeActivity)
                {
                    //this will set the dynamic updates flag on the root activity
                    Type activityType = childActivity.GetType();
                    PropertyInfo readOnlyProperty = activityType.GetProperty("CanModifyActivities", BindingFlags.NonPublic | BindingFlags.Instance);
                    readOnlyProperty.SetValue(childActivity, true, null);
                }
            }
        }

        private Activity[] GetNestedActivities(CompositeActivity compositeActivity)
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

        protected override void PerformLoad(IDesignerSerializationManager iSerializationManager)
        {
            DesignerSerializationManager serializationManager = iSerializationManager as DesignerSerializationManager;
            if (this.xomlDocument.Length == 0) return;

            IDesignerHost designerHost = (IDesignerHost)GetService(typeof(IDesignerHost));

            // Create a text reader out of the doc data, and ask
            CompositeActivity rootActivity = null;
            IList errors = null;

            ActivityMarkupWithChanges xomlchanges = null;

            //UnserizedActivitySupportingXomlSerializationManager manager = new UnserizedActivitySupportingXomlSerializationManager(serializationManager);
            WorkflowMarkupSerializer serializer = new WorkflowMarkupSerializer();// UnserizlizedActivitySupportingXomlSerializer();
            using (StringReader reader = new StringReader(this.xomlDocument))
            {
                using (XmlReader xmlReader = new XmlTextReader(reader))
                {
                    object deserializedObject = serializer.Deserialize(serializationManager, xmlReader);
                    xomlchanges = deserializedObject as ActivityMarkupWithChanges;
                    if (xomlchanges == null)
                    {
                        Activity root = deserializedObject as Activity;
                        if (root != null)
                            xomlchanges = new ActivityMarkupWithChanges(root, null);
                    }
                    errors = serializationManager.Errors;
                }
            }

            rootActivity = xomlchanges.Root as CompositeActivity;
            WorkflowChangeAction[] changes = xomlchanges.Changes;

            //there are some dynamic update actions too, need to deserialize and apply those too
            if (rootActivity != null && changes != null && changes.Length > 0)
            {
                for (int i = 0; i < changes.Length; i++)
                {
                    WorkflowChangeAction changeAction = changes[i];
                    if (changeAction != null)
                    {
                        //protected internal abstract bool ApplyTo(Activity rootActivity);
                        MethodInfo applyMethod = changeAction.GetType().GetMethod("ApplyTo", BindingFlags.Instance | BindingFlags.NonPublic);
                        applyMethod.Invoke(changeAction, new object[] { rootActivity });
                    }
                }
            }

            if (rootActivity != null && AllowDynamicUpdates)
            {
                List<Activity> activities = new List<Activity>();
                activities.Add(rootActivity);

                UpdateCanModifyFlag(activities);
            }

            if (rootActivity != null && designerHost != null)
            {
                AddActivityToDesigner(rootActivity);

                string className = rootActivity.GetValue(WorkflowMarkupSerializer.XClassProperty) as string;
                if (className == null)
                    className = rootActivity.GetType().FullName;

                SetBaseComponentClassName(className);
            }
        }

        internal static void AddActivityToDesigner(IServiceProvider serviceProvider, Activity activity)
        {
            WorkflowDesignerLoader workflowLoader = serviceProvider.GetService(typeof(WorkflowDesignerLoader)) as WorkflowDesignerLoader;
            if (workflowLoader == null)
                throw new InvalidOperationException("MissingService WorkflowDesignerLoader");

            workflowLoader.AddActivityToDesigner(activity);
        }

        internal static void RemoveActivityFromDesigner(IServiceProvider serviceProvider, Activity activity)
        {
            WorkflowDesignerLoader workflowLoader = serviceProvider.GetService(typeof(WorkflowDesignerLoader)) as WorkflowDesignerLoader;
            if (workflowLoader == null)
                throw new InvalidOperationException("MissingService WorkflowDesignerLoader");

            workflowLoader.RemoveActivityFromDesigner(activity);
        }

        public override void Flush()
        {
            PerformFlush(null);
        }
        protected override void PerformFlush(IDesignerSerializationManager manager)
        {
        }
    }
}