//---------------------------------------------------------------------
//  This file is part of the Windows Workflow Foundation Sample Code.
// 
//  Copyright (C) Microsoft Corporation.  All rights reserved.
// 
//  This source code is intended only as a supplement to Microsoft
//  Development Tools and/or on-line documentation.  See these other
//  materials for detailed information regarding Microsoft code samples.
// 
//  THIS CODE AND INFORMATION ARE PROVIDED AS IS WITHOUT WARRANTY OF ANY
//  KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE
//  IMPLIED WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A
//  PARTICULAR PURPOSE.
//---------------------------------------------------------------------

using System;
using System.Collections;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Workflow.Activities;
using System.Workflow.ComponentModel;
using System.Workflow.ComponentModel.Design;
using System.Workflow.ComponentModel.Compiler;

namespace SynchronizationActivities
{
    /// <summary>
    /// Synchronize activity is for synchronizing branches of a parallel.
    /// To use place one in each branch.  During the runtime all branches
    /// will stop until all synchronize activities are Executing.
    /// </summary>
	[ToolboxItem(typeof(ActivityToolboxItem))]
	[ActivityValidator(typeof(SynchronizeValidator))]
    [Designer(typeof(SynchronizeDesigner), typeof(IDesigner))]
    public sealed partial class Synchronize : Activity
    {
        public Synchronize()
        {
            InitializeComponent();
        }
		private Hashtable properties = null;
		internal Hashtable Properties
		{
			get
			{
				if (this.properties == null)
					this.properties = new Hashtable();
				return this.properties;
			}
		}

		protected override ActivityExecutionStatus Execute(ActivityExecutionContext context)
        {
			if (context == null)
				throw new ArgumentException("context");

			//  Find each synchronize and find out if it is started yet.
            //  If all are started then we can now move on.
			return SubscribeSibling(context);
        }

        //  TODO: Add logic to subscribe to syblings at the same level.
		private ActivityExecutionStatus SubscribeSibling(ActivityExecutionContext context)
        {
            this.Properties.Clear();
			
            ActivityExecutionStatus childStatus;
            bool closed = false;
            int count = 0;
            int index = 0;
			CompositeActivity parent = this.Parent;

            //  First find out if there are more than one syncronize in each branch
            //  and if so which one this one is.
            foreach (Activity child in parent.Activities)
            {
                if (child is Synchronize)
                {
					if (child == this)
                    {
                        index = count;
                    }
                    ++count;                    
                }
            }

			foreach (CompositeActivity sequence in parent.Parent.EnabledActivities)
            {
                if (sequence != parent)
                {
                    count = 0;

					foreach (Activity child in sequence.EnabledActivities)
                    {
                        if (child is Synchronize)
                        {
                            if (count == index)
                            {
                                childStatus = child.ExecutionStatus;
                                switch (childStatus)
                                {
                                    case ActivityExecutionStatus.Executing:
                                        break;
                                    case ActivityExecutionStatus.Closed:
                                        closed = true;
                                        break;
                                    default:
										this.Properties.Add(child.Name, child.Name);
                                        child.Executing += this.OnStatusChangeHandler;
                                        break;
                                }
                                break;
                            }
                            else
                            {
                                ++count;
                            }
                        }
                    }
                }
            }

			if (this.Properties.Count == 0)
            {
                return ActivityExecutionStatus.Closed;
            }
            else
            {
				if (closed)
				{
					throw new Exception("One of the syblings is already closed but there are '" + this.Properties.Count + "' syblings that are still being waited on.");
				}
				else
				{
					return ActivityExecutionStatus.Executing;
				}
            }
        }

        private void OnStatusChangeHandler(Object sender, ActivityExecutionStatusChangedEventArgs args)
        {
            ActivityExecutionContext provider = (ActivityExecutionContext)sender;
           
            Activity sybling;
            ActivityExecutionStatus syblingStatus = args.ExecutionStatus;
            switch (syblingStatus)
            { 
                case ActivityExecutionStatus.Executing:
					args.Activity.Executing -= this.OnStatusChangeHandler;
					((Synchronize)provider.Activity).Properties.Remove(args.Activity.Name);
                    
                    //Take a clone as we loop and remove
					Object[] children = new Object[((Synchronize)provider.Activity).Properties.Count];
					((Synchronize)provider.Activity).Properties.Keys.CopyTo(children, 0);

                    foreach(String syblingID in children)
                    {
						sybling = GetActivity(args.Activity, syblingID);
                        syblingStatus = sybling.ExecutionStatus;
                        switch (syblingStatus)
                        { 
                            case ActivityExecutionStatus.Executing:
                                sybling.Executing -= this.OnStatusChangeHandler;
								((Synchronize)provider.Activity).Properties.Remove(syblingID);                                
                                break;
                            case ActivityExecutionStatus.Initialized:
                            default:
                                break;
                        }
                    }
					if (((Synchronize)provider.Activity).Properties.Count == 0)
                    {
						provider.CloseActivity();
                    }
                    break;
            }
        }

        private Activity GetActivity(Activity sybling, string id)
        {
            CompositeActivity parallel = sybling.Parent.Parent;

			foreach (CompositeActivity sequence in parallel.EnabledActivities)
            {
				foreach (Activity child in sequence.EnabledActivities)
                {
                    if (child.Name == id)
                    {
                        return child;
                    }
                }
            }
            return null;
        }
    }

    /// <summary>
    /// Summary description for SynchronizeValidator.
    /// This is the validator for the activity. 
    /// </summary>
    public sealed class SynchronizeValidator : ActivityValidator
    {
        public override ValidationErrorCollection Validate(ValidationManager manager, object obj)
        {
            ValidationErrorCollection validationErrors = new ValidationErrorCollection(base.Validate(manager, obj));

            if ((obj as Activity).Parent != null)
            {
                bool allHaveSynchronize = true;
                bool foundSynchronize;
                int count = 0;
                int max = 0;
                bool first = true;
                bool sameNumberofSyncronize = true;

                //  Need to loop through all the parent sequences in the grandparent parallel
                //  to make sure that each sequence contains one.  If not then we add error
                //  that each branch of the parallel must have a Synchronize activity.
                CompositeActivity para = (CompositeActivity)((Activity)obj).Parent.Parent;

                if (((Activity)obj).Parent is SequenceActivity)
                {
                    if (para is ParallelActivity)
                    {
                        foreach (CompositeActivity sequence in para.Activities)
                        {
                            foundSynchronize = false;
                            count = 0;

                            foreach (Activity child in sequence.Activities)
                            {
                                if (child is Synchronize)
                                {
                                    foundSynchronize = true;
                                    ++count;
                                }
                            }
                            if (first)
                            {
                                max = count;
                                first = false;
                            }
                            else
                            {
                                if (count != max)
                                {
                                    sameNumberofSyncronize = false;
                                }
                            }
                            if (!foundSynchronize)
                            {
                                allHaveSynchronize = false;
                            }
                        }
                    }
                    else
                    {
                        validationErrors.Add(new ValidationError("Parent of Sycronize activity must be a Sequence whose parent is a Parallel.", 0x704));
                    }
                }
                else
                {
                    validationErrors.Add(new ValidationError("Parent of Sycronize activity must be a Sequence.", 0x705));
                }

                if (!allHaveSynchronize)
                {
                    validationErrors.Add(new ValidationError("There must be a Synchronize in each branch of a Parallel activity.", 0x706));
                }
                if (!sameNumberofSyncronize)
                {
                    validationErrors.Add(new ValidationError("Each branch of a Parallel must have the same number of Syncronize activities.", 0x707));
                } 
            }

            return validationErrors;
        }
    }

    /// <summary>
    /// Summary description for SynchronizeDesigner.
    ///This is a designtime activity designer class. This class is responsible for rendering of the activities
    /// </summary>
    //TODO: Associate theme with the designer, theme specified will be used to render you designer
    [ActivityDesignerTheme(typeof(ActivityDesignerTheme),
    Xml = "<?Mapping XmlNamespace=\"ComponentModel\" ClrNamespace=\"System.Workflow.ComponentModel.Design\" Assembly=\"System.Workflow.ComponentModel\" ?>" +
        "<ActivityDesignerTheme xmlns=\"ComponentModel\"" +
        " ApplyTo=\"Microsoft.WinOE.Test.CustomActivity.SynchronizeDesigner\"" +
        " ShowDropShadow=\"False\"" +
        " ConnectorStartCap=\"None\"" +
        " ConnectorEndCap=\"None\"" +
        " ForeColor=\"0xFF008080\"" +
        " BorderColor=\"0xFF00E0E0\"" +
        " BorderStyle=\"Dash\"" +
        " BackColorStart=\"LightBlue\"" +
        " BackColorEnd=\"Yellow\"" +
        " BackgroundStyle=\"Vertical\"" + 
        " />")]
    internal sealed class SynchronizeDesigner : ActivityDesigner
    {
        public SynchronizeDesigner()
        {
        }

        public override bool CanBeParentedTo(CompositeActivityDesigner parentActivityDesigner)
        {
			if (parentActivityDesigner == null)
				throw new ArgumentNullException("parentActivityDesigner");

            if (parentActivityDesigner.Activity is SequenceActivity && parentActivityDesigner.Activity.Parent is ParallelActivity)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
