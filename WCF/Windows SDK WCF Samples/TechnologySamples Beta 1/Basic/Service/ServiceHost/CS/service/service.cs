
//  Copyright (c) Microsoft Corporation.  All Rights Reserved.

using System;
using System.ServiceModel.Activation;
using System.ServiceModel;

namespace Microsoft.ServiceModel.Samples
{
    // Define a service contract.
    [ServiceContract(Namespace="http://Microsoft.ServiceModel.Samples")]
    public interface ICalculator
    {
        [OperationContract]
        double Add(double n1, double n2);
        [OperationContract]
        double Subtract(double n1, double n2);
        [OperationContract]
        double Multiply(double n1, double n2);
        [OperationContract]
        double Divide(double n1, double n2);
    }

    // Service class which implements the service contract.
    public class CalculatorService : ICalculator
    {
        public double Add(double n1, double n2)
        {
            return n1 + n2;
        }

        public double Subtract(double n1, double n2)
        {
            return n1 - n2;
        }

        public double Multiply(double n1, double n2)
        {
            return n1 * n2;
        }

        public double Divide(double n1, double n2)
        {
            return n1 / n2;
        }
    }

    // Implement a ServiceHostFactoryBase to control initialization of a Service
    // Service.svc file is modified to activate this ServiceHost
    public class CalculatorServiceHostFactory : ServiceHostFactoryBase
    {
        public override ServiceHostBase CreateServiceHost(string constructorString, Uri[] baseAddresses)
        {
            ServiceHost serviceHost = new ServiceHost(typeof(CalculatorService), baseAddresses);
          
            // Remove all configured endpoints
            serviceHost.Description.Endpoints.Clear();

            // Add an endpoint that supports BasicHttpBinding
            serviceHost.AddServiceEndpoint(typeof(ICalculator), new BasicHttpBinding(), "");
            // Add a mex endpoint
            serviceHost.AddServiceEndpoint("IMetadataExchange", System.ServiceModel.Description.MetadataExchangeBindings.CreateMexHttpBinding(), "/mex");
            return serviceHost;
        }

    }    
   
}
