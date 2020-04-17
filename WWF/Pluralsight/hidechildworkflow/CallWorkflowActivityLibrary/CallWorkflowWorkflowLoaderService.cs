using System.Workflow.ComponentModel;
using System.Workflow.Runtime.Hosting;
using System;
using System.Workflow.ComponentModel.Compiler;
using System.Workflow.ComponentModel.Serialization;
using System.ComponentModel.Design.Serialization;
using System.ComponentModel.Design;
using System.Runtime.Remoting.Messaging;
namespace CallWorkflowActivityLibrary
{
    public class CallWorkflowWorkflowLoaderService : WorkflowLoaderService
    {
        public CallWorkflowWorkflowLoaderService()
        {

        }
        void AddCalledWorkflowProperties(Activity act)
        {
            object caller = null;
            object qn = null;
            qn = CallContext.GetData(CallWorkflowService.CallingWorkflowQueueNameProperty.Name);
            caller = CallContext.GetData(CallWorkflowService.CallingWorkflowIDProperty.Name);
            if (qn != null && caller != null)
            {
                act.SetValue(CallWorkflowService.CallingWorkflowIDProperty, caller);
                act.SetValue(CallWorkflowService.CallingWorkflowQueueNameProperty, qn);
            }
        }
        protected override Activity CreateInstance(System.Xml.XmlReader workflowDefinitionReader, System.Xml.XmlReader rulesReader)
        {
            if (workflowDefinitionReader == null)
            {
                throw new ArgumentNullException("workflowDefinitionReader");
            }
            Activity activity = null;
            ValidationErrorCollection errors = new ValidationErrorCollection();
            ServiceContainer container = new ServiceContainer();
            ITypeProvider typeProvider = base.Runtime.GetService<ITypeProvider>();
            if (typeProvider != null)
            {
                container.AddService(typeof(ITypeProvider), typeProvider);
            }
            DesignerSerializationManager manager = new DesignerSerializationManager(container);
            try
            {
                using (IDisposable disposable = manager.CreateSession())
                {
                    WorkflowMarkupSerializationManager serializationManager = new WorkflowMarkupSerializationManager(manager);
                    activity = new WorkflowMarkupSerializer().Deserialize(serializationManager, workflowDefinitionReader) as Activity;
                    if ((activity != null) && (rulesReader != null))
                    {
                        object activityObject = new WorkflowMarkupSerializer().Deserialize(serializationManager, rulesReader);
                    }
                    foreach (object eo in manager.Errors)
                    {
                        if (eo is WorkflowMarkupSerializationException)
                        {
                            errors.Add(new ValidationError(((WorkflowMarkupSerializationException)eo).Message, 0x15b));
                            continue;
                        }
                        errors.Add(new ValidationError(eo.ToString(), 0x15c));
                    }
                }
            }
            catch (Exception exception)
            {
                errors.Add(new ValidationError(exception.Message, 0x15c));
            }
            if (errors.HasErrors)
            {
                throw new WorkflowValidationFailedException("Workflow failed validation", errors);
            }
            AddCalledWorkflowProperties(activity);
            return activity;


        }

        protected override Activity CreateInstance(Type type)
        {
            if (type == null)
            {
                throw new ArgumentNullException("workflowType");
            }
            if (!typeof(Activity).IsAssignableFrom(type))
            {
                throw new ArgumentException("Not an activity");
            }
            if (type.GetConstructor(Type.EmptyTypes) == null)
            {
                throw new ArgumentException("No default constrctor");
            }
            Activity a = Activator.CreateInstance(type) as Activity;
            AddCalledWorkflowProperties(a);
            return a;
        }
    }
}