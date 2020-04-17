using System;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Collections;
using System.Drawing;
using System.Workflow.ComponentModel;
using System.Workflow.ComponentModel.Design;
using System.Workflow.ComponentModel.Compiler;
using System.Workflow.ComponentModel.Serialization;
using System.Workflow.Runtime;
using System.Workflow.Activities;
using System.Workflow.Activities.Rules;
using System.Workflow.Runtime.Hosting;
using System.Collections.Generic;
using System.Drawing.Design;
using System.Reflection;

namespace CallWorkflowActivityLibrary
{
    [Designer(typeof(CallWorkflowDesigner),typeof(IDesigner))]
	public partial class CallWorkflowActivity: Activity
	{
		public CallWorkflowActivity()
		{
			 base.SetReadOnlyPropertyValue(CallWorkflowActivity.ParametersProperty, new WorkflowParameterBindingCollection(this));

		}
        protected override ActivityExecutionStatus Execute(ActivityExecutionContext aec)
        {
            //get the services needed
            //custom service to run the workflow
            CallWorkflowService ws = aec.GetService<CallWorkflowService>();
            //Queuing service to setup the queue so the service can "callback"
            WorkflowQueuingService qs = aec.GetService<WorkflowQueuingService>();
            //create the queue the service can call back on when the child workflow is done
            //you might want the queuename to be something different
            string qn = String.Format("{0}:{1}:{2}", this.WorkflowInstanceId.ToString(), Type.Name, this.Name);
            WorkflowQueue q = qs.CreateWorkflowQueue(qn, false);
            q.QueueItemAvailable += new EventHandler<QueueEventArgs>(q_QueueItemAvailable);
            //copy the params to a new collection
            Dictionary<string, object> inparams = new Dictionary<string, object>();
            foreach (WorkflowParameterBinding bp in this.Parameters)
            {
                PropertyInfo pi = Type.GetProperty(bp.ParameterName);
                if(pi.CanWrite)
                    inparams.Add(bp.ParameterName, bp.Value);
            }
            //ask the service to start the workflow
            ws.StartWorkflow(Type, inparams, this.WorkflowInstanceId, qn);
            return ActivityExecutionStatus.Executing;
        }

        void q_QueueItemAvailable(object sender, QueueEventArgs e)
        {
            ActivityExecutionContext aec = sender as ActivityExecutionContext;
            if (aec != null)
            {
                WorkflowQueuingService qs = aec.GetService<WorkflowQueuingService>();

                WorkflowQueue q = qs.GetWorkflowQueue(e.QueueName);
                //get the outparameters from the workflow
                object o = q.Dequeue();
                //delete the queue
                Exception ex = o as Exception;
                if (ex != null)
                    throw ex;
                qs.DeleteWorkflowQueue(e.QueueName);
                Dictionary<string,object> outparams = o as Dictionary<string,object>;
                if(outparams!=null)
                {
                    foreach (KeyValuePair<string, object>  item in outparams)
                    {
                        if (this.Parameters.Contains(item.Key))
                        {
                            //modify the value
                            this.Parameters[item.Key].SetValue(WorkflowParameterBinding.ValueProperty, item.Value);
                        }
                       
                    }
                }
                aec.CloseActivity();
            }
        }
        public static DependencyProperty TypeProperty = System.Workflow.ComponentModel.DependencyProperty.Register("Type", typeof(Type), typeof(CallWorkflowActivity),new PropertyMetadata(DependencyPropertyOptions.Metadata));

        [Description("The workflow Type to call synchronously")]
        [Category("Misc")]
        [Browsable(true)]
        [Editor(typeof(TypeBrowserEditor), typeof(UITypeEditor))]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public Type Type
        {
            get
            {
                return ((Type)(base.GetValue(CallWorkflowActivity.TypeProperty)));
            }
            set
            {
                base.SetValue(CallWorkflowActivity.TypeProperty, value);
            }
        }
        public static DependencyProperty ParametersProperty = System.Workflow.ComponentModel.DependencyProperty.Register("Parameters", typeof(WorkflowParameterBindingCollection), typeof(CallWorkflowActivity),new PropertyMetadata(DependencyPropertyOptions.Metadata|DependencyPropertyOptions.ReadOnly));

        
        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public WorkflowParameterBindingCollection Parameters
        {
            get
            {
                return ((WorkflowParameterBindingCollection)(base.GetValue(CallWorkflowActivity.ParametersProperty)));
            }

        }
	}
    
 
    

}
