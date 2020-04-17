// <copyright file="IdentifierCreationService.cs" company="Microsoft">
//   Copyright (c) Microsoft Corporation.  All rights reserved.
// </copyright>
namespace Microsoft.Workflow.DesignerHosting
{
	using System;
	using System.IO;
	using System.Text;
	using System.CodeDom;
	using System.CodeDom.Compiler;
	using System.Collections;
	using System.ComponentModel;
	using System.Collections.Generic;
	using System.ComponentModel.Design;
	using System.ComponentModel.Design.Serialization;
	using System.Workflow.ComponentModel;
	using System.Workflow.ComponentModel.Design;
	using ZAMM;
	using System.Workflow.ComponentModel.Compiler;
	using System.Reflection;

	internal sealed class IdentifierCreationService : IIdentifierCreationService
	{
		private IServiceProvider serviceProvider = null;
		private Loader loader = null;

		internal IdentifierCreationService(IServiceProvider serviceProvider, Loader loader)
		{
			this.serviceProvider = serviceProvider;
			this.loader = loader;
		}

		private Loader Loader
		{
			get
			{
				return this.loader;
			}
		}

		#region IIdentifierCreationService
		void IIdentifierCreationService.ValidateIdentifier(Activity activity, string identifier)
		{
			if (identifier == null)
				throw new ArgumentNullException("identifier");
			if (activity == null)
				throw new ArgumentNullException("activity");

			if (activity.Name.ToLower().Equals(identifier.ToLower()))
				return;

			ArrayList identifiers = new ArrayList();
			Activity rootActivity = Helpers.GetRootActivity(activity);
			identifiers.AddRange(Helpers.GetIdentifiersInCompositeActivity(rootActivity as CompositeActivity));
			identifiers.Sort();
			if (identifiers.BinarySearch(identifier.ToLower(), StringComparer.OrdinalIgnoreCase) >= 0)
			{
				Exception ex = new ArgumentException(string.Format("Duplicate Component Identifier {0}", identifier));

				ex.HelpLink = "DesignerLoader_DupComponentIdentifier";
				throw ex;
			}
		}

		/// <summary>
		/// This method will ensure that the identifiers of the activities to be added to the parent activity
		/// are unique within the scope of the parent activity.  
		/// </summary>
		/// <param name="parentActivity">THis activity is the parent activity which the child activities are being added</param>
		/// <param name="childActivities"></param>
		void IIdentifierCreationService.EnsureUniqueIdentifiers(CompositeActivity parentActivity, ICollection childActivities)
		{
			if (parentActivity == null)
				throw new ArgumentNullException("parentActivity");
			if (childActivities == null)
				throw new ArgumentNullException("childActivities");

			ArrayList allActivities = new ArrayList();

			Queue activities = new Queue(childActivities);
			while (activities.Count > 0)
			{
				Activity activity = (Activity)activities.Dequeue();
				if (activity is CompositeActivity)
				{
					foreach (Activity child in ((CompositeActivity)activity).Activities)
						activities.Enqueue(child);
				}

				//If we are moving activities, we need not regenerate their identifiers
				if (((IComponent)activity).Site != null)
					continue;

				////If the activity is built-in, we won't generate a new ID.
				//if (activity.IsLocked)
				//    continue;

				allActivities.Add(activity);
			}

			// get the root activity
			CompositeActivity rootActivity = Helpers.GetRootActivity(parentActivity) as CompositeActivity;

			ArrayList identifiers = new ArrayList(); // all the identifiers in the workflow
			identifiers.AddRange(Helpers.GetIdentifiersInCompositeActivity(rootActivity));
            Type customActivityType = GetRootActivityType(this.serviceProvider);
            if (customActivityType != null)
            {
                foreach (MemberInfo member in customActivityType.GetMembers(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Static | BindingFlags.Instance))
                {
                    identifiers.Add(member.Name);
                }
            }

			ArrayList classNames = null;
			foreach (Activity activity in allActivities)
			{
				string finalIdentifier = activity.Name;
				if (Helpers.ActivitySupportsDataContext(activity))
				{
					if (classNames == null)
					{
						classNames = new ArrayList(); // all the class names in the workflow
						classNames.AddRange(Helpers.GetClassNamesInActivity(rootActivity));
					}

					string parentNamespace = string.Empty;
					string parentClassName = string.Empty;
					string fullClassName = string.Empty;
					// get the namespace the activity is being inserted into
					Activity[] topLevelActivities = Helpers.GetTopLevelActivities(childActivities);
					Activity scope = Helpers.ActivitySupportsDataContext(parentActivity) ? parentActivity : ExecutableComponentHelpers.GetEnclosingDataContextActivity(parentActivity);
					Activity parentScope = (!((IList)topLevelActivities).Contains(activity) && ExecutableComponentHelpers.GetEnclosingDataContextActivity(activity)!= null) ? ExecutableComponentHelpers.GetEnclosingDataContextActivity(activity) : scope;
                    string className = string.Empty;
                    if (parentScope != null && !parentScope.IsLocked)
                    {
                        Type companionType = parentScope.GetValue(SupportsDataContext.CompanionClassProperty) as Type;
                        if (companionType != null)
                            className = companionType.FullName;
                    }
					if (!string.IsNullOrEmpty(className))
						Helpers.GetNamespaceAndClassName(className, out parentNamespace, out parentClassName);
					else
						parentNamespace = this.loader.DefaultNamespace;

					if (finalIdentifier != null && finalIdentifier.Length > 0)
					{
						fullClassName = finalIdentifier + "DataContext";
						if (parentNamespace.Length > 0)
							fullClassName = parentNamespace + "." + fullClassName;
					}

					identifiers.Sort();
					classNames.Sort();
					int index = 0;
					string baseIdentifier = Helpers.GetBaseIdentifier(activity);

					ITypeProvider typeProvider = this.serviceProvider.GetService(typeof(ITypeProvider)) as ITypeProvider;
					if (typeProvider == null)
						throw new InvalidOperationException(string.Format("Missing Service {0}", typeof(ITypeProvider).FullName));

					while (finalIdentifier == null || finalIdentifier.Length == 0 || fullClassName.Length == 0 || typeProvider.GetType(fullClassName) != null ||
							classNames.BinarySearch(fullClassName.ToLower(), StringComparer.OrdinalIgnoreCase) >= 0 ||
							identifiers.BinarySearch(finalIdentifier.ToLower(), StringComparer.OrdinalIgnoreCase) >= 0)
					{
						finalIdentifier = string.Format("{0}{1}", baseIdentifier, ++index);

						if (parentNamespace.Length > 0)
							fullClassName = Helpers.MergeNamespaces(parentNamespace, finalIdentifier) + "DataContext";
						else
                            //This is the case when someone removes the code ns + default project ns
							fullClassName = finalIdentifier + "DataContext";
					}

					// add new identifier to collection
					identifiers.Add(finalIdentifier);
					classNames.Add(fullClassName);
					// set default class name
					if (!Helpers.HasLocalDataContext(activity))
                        Helpers.SetDesignTimeTypeName(activity, SupportsDataContext.CompanionClassProperty, fullClassName);
				}
				else
				{
					// now loop until we find a identifier that hasn't been used.
					string baseIdentifier = Helpers.GetBaseIdentifier(activity);
					int index = 0;

					identifiers.Sort();
					while (finalIdentifier == null || finalIdentifier.Length == 0 || identifiers.BinarySearch(finalIdentifier.ToLower(), StringComparer.OrdinalIgnoreCase) >= 0)
					{
						finalIdentifier = string.Format("{0}{1}", baseIdentifier, ++index);
					}

					// add new identifier to collection 
					identifiers.Add(finalIdentifier);
				}

				activity.ID = finalIdentifier;
			}
		}
		#endregion
        private Type GetRootActivityType(IServiceProvider serviceProvider)
        {
            IDesignerHost host = serviceProvider.GetService(typeof(IDesignerHost)) as IDesignerHost;
            if (host == null)
                throw new Exception("MissingService " + typeof(IDesignerHost).FullName);

            string className = host.RootComponentClassName;
            if (string.IsNullOrEmpty(className))
                return null;

            ITypeProvider typeProvider = serviceProvider.GetService(typeof(ITypeProvider)) as ITypeProvider;
            if (typeProvider == null)
                throw new Exception("MissingService " + typeof(ITypeProvider).FullName);

            return typeProvider.GetType(className, false);
        }
	}
}
