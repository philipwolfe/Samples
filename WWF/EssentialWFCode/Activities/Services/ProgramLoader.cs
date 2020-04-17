using System;
using System.Workflow.Runtime.Hosting;
using System.Xml;
using System.Workflow.ComponentModel;
using System.Workflow.ComponentModel.Serialization;
using System.Workflow.Activities.Rules;
using System.ComponentModel.Design;
using System.Workflow.ComponentModel.Compiler;
using System.ComponentModel.Design.Serialization;
namespace EssentialWF.Services {

  public class StandardProgramLoaderService : WorkflowLoaderService {
    protected override Activity CreateInstance( Type workflowType) {
      return (Activity)Activator.CreateInstance(workflowType);
    }

    protected override Activity CreateInstance(
        XmlReader workflowDefinitionReader, XmlReader rulesReader) {

      Activity root = null;
      ITypeProvider typeProvider = this.Runtime.GetService<ITypeProvider>();
      ServiceContainer serviceContainer = new ServiceContainer();
      serviceContainer.AddService(typeof(ITypeProvider), typeProvider);

      DesignerSerializationManager manager = new DesignerSerializationManager(serviceContainer);
      using (manager.CreateSession()) {
        WorkflowMarkupSerializationManager xomlSerializationManager = new WorkflowMarkupSerializationManager(manager);
        root = new WorkflowMarkupSerializer().Deserialize(xomlSerializationManager, workflowDefinitionReader) as Activity;
        if (root != null && rulesReader != null) {
          object rules = new WorkflowMarkupSerializer().Deserialize(xomlSerializationManager, rulesReader);
          root.SetValue(RuleDefinitions.RuleDefinitionsProperty, rules);
        }
      }
      return root;
    }
  }
}