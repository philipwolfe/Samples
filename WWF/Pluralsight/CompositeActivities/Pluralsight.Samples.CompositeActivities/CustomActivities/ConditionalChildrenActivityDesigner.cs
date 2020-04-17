using System;
using System.Collections.Generic;
using System.Text;
using System.Workflow.ComponentModel.Design;
using System.ComponentModel.Design;
using System.ComponentModel;

namespace CustomActivities
{

    /// <summary>
    /// Adds a property provider to add the whencondition to the child activities
    /// </summary>
	public class ConditionalChildrenActivityDesigner : SequentialActivityDesigner
	{

        protected override void Initialize(System.Workflow.ComponentModel.Activity activity)
        {
            base.Initialize(activity);
            bool serviceAdded = false;

            //make sure the service hasn't already been added.
            IExtenderListService listService = (IExtenderListService)base.GetService(typeof(IExtenderListService));
            if (listService != null)
            {
                foreach (IExtenderProvider prov in listService.GetExtenderProviders())
                {
                    if (prov.GetType() == typeof(ConditionPropertyExtender))
                    {
                        serviceAdded = true;
                        break;
                    }
                }


                //if the service has not been added, then add it in
                if (!serviceAdded)
                {
                    IExtenderProviderService provSvc = (IExtenderProviderService)GetService(typeof(IExtenderProviderService));
                    if(provSvc != null)
                        provSvc.AddExtenderProvider(new ConditionPropertyExtender());
                }

            }
        }
	}
}
