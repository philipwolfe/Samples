using System;
using System.Collections.Generic;
using System.Text;
using System.Workflow.ComponentModel.Design;
using System.Workflow.Activities;
using System.Workflow.ComponentModel;

namespace CustomActivities
{
	public class PartialCompletionActivityDesigner : ParallelActivityDesigner
	{
        protected override System.Workflow.ComponentModel.CompositeActivity OnCreateNewBranch()
        {
            return new SequenceActivity();
        }
	}

    public class PartialCompletionToolboxItem : ActivityToolboxItem
    {
        protected override System.ComponentModel.IComponent[] CreateComponentsCore(System.ComponentModel.Design.IDesignerHost host)
        {
            SequenceActivity sequence1 = new SequenceActivity();
            SequenceActivity sequence2 = new SequenceActivity();
            PartialCompletionActivity partial = new PartialCompletionActivity();
            partial.Activities.AddRange(new Activity[] { sequence1, sequence2 });
            return new System.ComponentModel.IComponent[] { partial };
        }
    }
}
