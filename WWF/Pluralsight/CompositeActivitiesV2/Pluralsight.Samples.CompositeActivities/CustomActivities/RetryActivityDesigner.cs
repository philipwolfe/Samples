using System;
using System.Collections.Generic;
using System.Text;
using System.Workflow.ComponentModel.Design;
using System.Workflow.ComponentModel;

namespace CustomActivities
{
	class RetryActivityDesigner : SequenceDesigner
	{
        public override bool CanInsertActivities(HitTestInfo insertLocation, System.Collections.ObjectModel.ReadOnlyCollection<System.Workflow.ComponentModel.Activity> activitiesToInsert)
        {
            return ((CompositeActivity)this.Activity).EnabledActivities.Count == 0 && activitiesToInsert.Count == 1;
        }
	}
}
