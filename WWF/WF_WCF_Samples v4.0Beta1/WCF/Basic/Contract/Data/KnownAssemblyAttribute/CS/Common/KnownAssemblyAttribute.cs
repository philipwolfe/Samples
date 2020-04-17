
//-----------------------------------------------------------------
// Copyright (c) Microsoft Corporation.  All Rights Reserved.
//-----------------------------------------------------------------

namespace Microsoft.Samples.KAA.Common
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Runtime.Serialization;
    using System.ServiceModel;
    using System.ServiceModel.Channels;
    using System.ServiceModel.Description;
    using System.ServiceModel.Dispatcher;
    using System.Xml;

    [AttributeUsage(AttributeTargets.All)]
    public class KnownAssemblyAttribute : System.Attribute, IContractBehavior
    {
        MyDataContractResolver resolver;

        public KnownAssemblyAttribute(string name)
        {
            this.Assembly = name;
            resolver = new MyDataContractResolver(name);
        }

        public string Assembly { get; set; }

        public void AddBindingParameters(ContractDescription contractDescription, ServiceEndpoint endpoint, BindingParameterCollection bindingParameters)
        {
        }

        public void ApplyClientBehavior(ContractDescription contractDescription, ServiceEndpoint endpoint, ClientRuntime clientRuntime)
        {
            CreateMyDataContractSerializerOperationBehaviors(contractDescription);
        }

        public void ApplyDispatchBehavior(ContractDescription contractDescription, ServiceEndpoint endpoint, DispatchRuntime dispatchRuntime)
        {
            CreateMyDataContractSerializerOperationBehaviors(contractDescription);
        }

        public void Validate(ContractDescription contractDescription, ServiceEndpoint endpoint)
        {
        }

        internal void CreateMyDataContractSerializerOperationBehaviors(ContractDescription contractDescription)
        {
            foreach (var operation in contractDescription.Operations)
            {
                CreateMyDataContractSerializerOperationBehavior(operation);
            }
        }

        internal void CreateMyDataContractSerializerOperationBehavior(OperationDescription operation)
        {
            DataContractSerializerOperationBehavior dataContractSerializerOperationbehavior = operation.Behaviors.Find<DataContractSerializerOperationBehavior>();
            dataContractSerializerOperationbehavior.DataContractResolver = this.resolver;
        }
    }
}
