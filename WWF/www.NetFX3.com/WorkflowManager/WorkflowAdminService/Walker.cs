using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Reflection;
using System.Workflow.ComponentModel;

namespace Microsoft.Workflow.Samples.Administration
{
    // Returns true to continue the walk, false to stop.
    internal delegate void WalkerEventHandler(Walker walker, WalkerEventArgs eventArgs);

    internal enum WalkerAction
    {
        Continue = 0,
        Skip = 1,
        Abort = 2
    }

    #region Class WalkerEventArgs

    internal sealed class WalkerEventArgs : EventArgs
    {
        private Activity currentActivity = null;
        private object currentPropertyOwner = null;
        private PropertyInfo currentProperty = null;
        private object currentValue = null;
        private object userData = null;
        private WalkerAction action = WalkerAction.Continue;

        internal WalkerEventArgs(Activity currentActivity, object userData)
        {
            this.currentActivity = currentActivity;
            this.userData = userData;
            this.currentPropertyOwner = null;
            this.currentProperty = null;
            this.currentValue = null;
        }

        internal WalkerEventArgs(Activity currentActivity, object currentValue, PropertyInfo currentProperty, object currentPropertyOwner, object userData)
            : this(currentActivity, userData)
        {
            this.currentPropertyOwner = currentPropertyOwner;
            this.currentProperty = currentProperty;
            this.currentValue = currentValue;
        }

        public WalkerAction Action
        {
            get { return this.action; }
            set { this.action = value; }
        }

        public PropertyInfo CurrentProperty
        {
            get { return this.currentProperty; }
        }

        public object CurrentPropertyOwner
        {
            get { return this.currentPropertyOwner; }
        }

        public object CurrentValue
        {
            get { return this.currentValue; }
        }

        public Activity CurrentActivity
        {
            get { return this.currentActivity; }
        }

        public object UserData
        {
            get { return this.userData; }
        }
    }

    #endregion

    internal sealed class Walker
    {
        #region Members

        internal event WalkerEventHandler FoundActivity;
        private object userData = null;
        private bool useEnabledActivities = false;

        #endregion

        #region Methods

        public Walker()
            : this(null, false)
        {
        }

        public Walker(object userData)
            : this(userData, false)
        {
        }

        public Walker(object userData, bool useEnabledActivities)
        {
            this.userData = userData;
            this.useEnabledActivities = useEnabledActivities;
        }

        public void Walk(Activity seedActivity)
        {
            Walk(seedActivity, true);
        }

        public void Walk(Activity seedActivity, bool walkChildren)
        {
            Queue queue = new Queue();

            queue.Enqueue(seedActivity);
            while (queue.Count > 0)
            {
                Activity activity = queue.Dequeue() as Activity;

                if (FoundActivity != null)
                {
                    WalkerEventArgs args = new WalkerEventArgs(activity, this.userData);
                    FoundActivity(this, args);
                    if (args.Action == WalkerAction.Abort)
                        return;
                    if (args.Action == WalkerAction.Skip)
                        continue;
                }

                if (walkChildren && activity is CompositeActivity)
                {
                    if (useEnabledActivities)
                    {
                        foreach (Activity activity2 in GetAllEnabledActivities((CompositeActivity)activity))
                            queue.Enqueue(activity2);
                    }
                    else
                    {
                        foreach (Activity activity2 in ((CompositeActivity)activity).Activities)
                            queue.Enqueue(activity2);
                    }
                }
            }
        }

        // This function returns all the executable activities including secondary flow activities.
        private IList<Activity> GetAllEnabledActivities(CompositeActivity compositeActivity)
        {
            if (compositeActivity == null)
                throw new ArgumentNullException("compositeActivity");

            List<Activity> allActivities = new List<Activity>(compositeActivity.EnabledActivities);
            foreach (Activity childActivity in compositeActivity.Activities)
            {
                if (childActivity.Enabled &&
                        IsFrameworkActivity(childActivity))
                    allActivities.Add(childActivity);
            }
            return allActivities;
        }
        private bool IsFrameworkActivity(Activity activity)
        {
            return (activity is CancellationHandlerActivity ||
                        activity is CompensationHandlerActivity ||
                        activity is FaultHandlersActivity);
        }

        private static DesignerSerializationVisibility GetSerializationVisibility(PropertyInfo prop)
        {
            if (prop.DeclaringType == typeof(CompositeActivity) && prop.Name == "Activities")
                return DesignerSerializationVisibility.Hidden;

            DesignerSerializationVisibility visibility = DesignerSerializationVisibility.Visible;
            DesignerSerializationVisibilityAttribute[] visibilityAttrs = (DesignerSerializationVisibilityAttribute[])prop.GetCustomAttributes(typeof(DesignerSerializationVisibilityAttribute), true);
            if (visibilityAttrs.Length > 0)
                visibility = visibilityAttrs[0].Visibility;

            return visibility;
        }

        private static bool IsBrowsableType(Type type)
        {
            bool browsable = false;
            BrowsableAttribute[] browsableAttrs = (BrowsableAttribute[])type.GetCustomAttributes(typeof(BrowsableAttribute), true);
            if (browsableAttrs.Length > 0)
                browsable = browsableAttrs[0].Browsable;
            return browsable;
        }
        #endregion
    }
}