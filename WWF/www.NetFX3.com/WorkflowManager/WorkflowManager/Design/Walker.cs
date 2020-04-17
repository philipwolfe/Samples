namespace System.Workflow.ComponentModel
{
	#region Imports

	using System;
	using System.Collections;
	using System.Collections.Generic;
	using System.Reflection;
	using System.ComponentModel;

	#endregion

	//// Returns true to continue the walk, false to stop.
	//internal delegate void WalkerEventHandler(Walker walker, WalkerEventArgs eventArgs);

	//internal enum WalkerAction
	//{
	//    Continue     = 0,
	//    Skip         = 1,
	//    Abort      = 2
	//}
	//#region Class WalkerEventArgs
    
	//internal sealed class WalkerEventArgs: EventArgs
	//{
	//    private Activity				currentActivity = null;
	//    private object					currentPropertyOwner = null;
	//    private PropertyInfo			currentProperty = null;
	//    private object					currentValue = null;
	//    private object					userData = null;
	//    private WalkerAction 			action = WalkerAction.Continue;

	//    internal WalkerEventArgs(Activity currentActivity, object userData)
	//    {
	//        this.currentActivity = currentActivity;
	//        this.userData = userData;
	//        this.currentPropertyOwner = null;
	//        this.currentProperty = null;
	//        this.currentValue = null;
	//    }

	//    internal WalkerEventArgs(Activity currentActivity, object currentValue, PropertyInfo currentProperty, object currentPropertyOwner, object userData)
	//        : this(currentActivity, userData)
	//    {
	//        this.currentPropertyOwner = currentPropertyOwner;
	//        this.currentProperty = currentProperty;
	//        this.currentValue = currentValue;
	//    }

	//    public WalkerAction Action
	//    {
	//        get
	//        {
	//            return this.action;
	//        }
	//        set
	//        {
	//            this.action = value;
	//        }
	//    }

	//    public PropertyInfo CurrentProperty
	//    {
	//        get
	//        {
	//            return this.currentProperty;
	//        }
	//    }

	//    public string CurrentPropertyName
	//    {
	//        get
	//        {
	//            string propertyName = string.Empty;

	//            if (this.currentProperty != null)
	//                propertyName = this.currentProperty.Name;

	//            return propertyName;
	//        }
	//    }

	//    public object CurrentPropertyOwner
	//    {
	//        get
	//        {
	//            return this.currentPropertyOwner;
	//        }
	//    }

	//    public object CurrentValue
	//    {
	//        get
	//        {
	//            return this.currentValue;
	//        }
	//    }

	//    public Activity CurrentActivity
	//    {
	//        get
	//        {
	//            return this.currentActivity;
	//        }
	//    }

	//    public object UserData
	//    {
	//        get
	//        {
	//            return this.userData;
	//        }
	//    }
	//}

	//#endregion

	//internal sealed class Walker
	//{
	//    #region Members

	//    internal event WalkerEventHandler		FoundActivity;
	//    internal event WalkerEventHandler		FoundProperty;
	//    private object							userData = null;
	//    private bool                            useExecutableActivities = false;

	//    #endregion

	//    #region Methods

	//    public Walker()
	//        : this(null, false)
	//    {
	//    }

	//    public Walker(object userData)
	//        : this(userData, false)
	//    {
	//    }
        
	//    public Walker(object userData, bool useExecutableActivities)
	//    {
	//        this.userData = userData;
	//        this.useExecutableActivities = useExecutableActivities;
	//    }

	//    public void Walk(Activity seedActivity)
	//    {
	//        Walk(seedActivity, true);
	//    }

	//    public void Walk(Activity seedActivity, bool walkChildren)
	//    {
	//        Queue queue = new Queue();

	//        queue.Enqueue(seedActivity);
	//        while (queue.Count > 0)
	//        {
	//            Activity activity = queue.Dequeue() as Activity;

	//            if (FoundActivity != null)
	//            {	
	//                WalkerEventArgs args = new WalkerEventArgs(activity, this.userData);
	//                FoundActivity(this, args);
	//                if (args.Action == WalkerAction.Abort)
	//                    return;
	//                if (args.Action == WalkerAction.Skip)
	//                    continue;
	//            }

	//            if (FoundProperty != null)
	//            {
	//                if (!WalkProperties(activity))
	//                    return;
	//            }

	//            if (walkChildren && activity is CompositeActivity)
	//            {
	//                if (useExecutableActivities)
	//                {
	//                    foreach (Activity activity2 in Design.Helpers.GetAllExecutableActivities((CompositeActivity)activity))
	//                        queue.Enqueue(activity2);
	//                }
	//                else
	//                {
	//                    foreach (Activity activity2 in ((CompositeActivity)activity).Activities)
	//                        queue.Enqueue(activity2);
	//                }
	//            }
	//        }
	//    }

	//    private bool WalkProperties(Activity seedActivity)
	//    {
	//        return WalkProperties(seedActivity as Activity, seedActivity);
	//    }

	//    public bool WalkProperties(Activity activity, object obj)
	//    {
	//        Activity currentActivity = obj as Activity;

	//        PropertyInfo[] props = obj.GetType().GetProperties(BindingFlags.Public | BindingFlags.Instance);
	//        foreach (PropertyInfo prop in props)
	//        {
	//            // !!HACK: no indexer property walking
	//            if (prop.GetIndexParameters() != null && prop.GetIndexParameters().Length > 0)
	//                continue;

	//            DesignerSerializationVisibility visibility = GetSerializationVisibility(prop);
	//            if (visibility == DesignerSerializationVisibility.Hidden)
	//                continue;

	//            //Try to see if we have dynamic property associated with the object on the same object
	//            //if so then we should compare if the dynamic property values match with the property type
	//            //if not we bail out
	//            object propValue = null;
	//            DependencyProperty dependencyProperty = DependencyProperty.FromName(prop.Name, obj.GetType());
	//            if (dependencyProperty != null && currentActivity != null)
	//                propValue = currentActivity.GetValue(dependencyProperty);
	//            else
	//                propValue = prop.GetValue(obj, null);

	//            if (FoundProperty != null)
	//            {
	//                WalkerEventArgs args = new WalkerEventArgs(activity, propValue, prop, obj, this.userData);
	//                FoundProperty(this, args);
	//                if (args.Action == WalkerAction.Skip)
	//                    continue;
	//                else if (args.Action == WalkerAction.Abort)
	//                    return false;
	//            }

	//            if (propValue is IList)
	//            {
	//                //We do not need to reflect on the properties of the list
	//                foreach (object childObj in (IList)propValue)
	//                {
	//                    if (FoundProperty != null)
	//                    {
	//                        WalkerEventArgs args = new WalkerEventArgs(activity, childObj, null, propValue, this.userData);
	//                        FoundProperty(this, args);
	//                        if (args.Action == WalkerAction.Skip)
	//                            continue;
	//                        else if (args.Action == WalkerAction.Abort)
	//                            return false;
	//                    }
	//                    if(childObj != null && IsBrowsableType(childObj.GetType()))
	//                    {
	//                        if (!WalkProperties(activity, childObj))
	//                            return false;
	//                    }
	//                }
	//            }
	//            else if (propValue != null && IsBrowsableType(propValue.GetType()))
	//            {
	//                if (!WalkProperties(activity, propValue))
	//                    return false;
	//            }
	//        }
	//        return true;
	//    }

	//    private static DesignerSerializationVisibility GetSerializationVisibility(PropertyInfo prop)
	//    {
	//        // HACK!!! for Activities collection
	//        if(prop.DeclaringType == typeof(CompositeActivity) && prop.Name == "Activities")
	//            return DesignerSerializationVisibility.Hidden;

	//        DesignerSerializationVisibility visibility = DesignerSerializationVisibility.Visible;
	//        DesignerSerializationVisibilityAttribute[] visibilityAttrs = (DesignerSerializationVisibilityAttribute[])prop.GetCustomAttributes(typeof(DesignerSerializationVisibilityAttribute), true);
	//        if (visibilityAttrs.Length > 0)
	//            visibility = visibilityAttrs[0].Visibility;

	//        return visibility;
	//    }

	//    private static bool IsBrowsableType(Type type)
	//    {
	//        bool browsable = false;
	//        BrowsableAttribute[] browsableAttrs = (BrowsableAttribute[])type.GetCustomAttributes(typeof(BrowsableAttribute), true);
	//        if (browsableAttrs.Length > 0)
	//            browsable = browsableAttrs[0].Browsable;
	//        return browsable;
	//    }
	//    #endregion
	//}
}
