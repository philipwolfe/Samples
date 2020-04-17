﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:2.0.50727.312
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Microsoft.WorkflowServices.Samples
{
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "3.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="Microsoft.WorkflowServices.Samples.ICalculator")]
    public interface ICalculator
    {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ICalculator/PowerOn", ReplyAction="http://tempuri.org/ICalculator/PowerOnResponse")]
        [return: System.ServiceModel.MessageParameterAttribute(Name="returnValue")]
        int PowerOn();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ICalculator/Add", ReplyAction="http://tempuri.org/ICalculator/AddResponse")]
        [return: System.ServiceModel.MessageParameterAttribute(Name="returnValue")]
        int Add(int value);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ICalculator/Subtract", ReplyAction="http://tempuri.org/ICalculator/SubtractResponse")]
        [return: System.ServiceModel.MessageParameterAttribute(Name="returnValue")]
        int Subtract(int value);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ICalculator/Multiply", ReplyAction="http://tempuri.org/ICalculator/MultiplyResponse")]
        [return: System.ServiceModel.MessageParameterAttribute(Name="returnValue")]
        int Multiply(int value);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ICalculator/Divide", ReplyAction="http://tempuri.org/ICalculator/DivideResponse")]
        [return: System.ServiceModel.MessageParameterAttribute(Name="returnValue")]
        int Divide(int value);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ICalculator/PowerOff", ReplyAction="http://tempuri.org/ICalculator/PowerOffResponse")]
        void PowerOff();
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "3.0.0.0")]
    public interface ICalculatorChannel : Microsoft.WorkflowServices.Samples.ICalculator, System.ServiceModel.IClientChannel
    {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "3.0.0.0")]
    public partial class CalculatorClient : System.ServiceModel.ClientBase<Microsoft.WorkflowServices.Samples.ICalculator>, Microsoft.WorkflowServices.Samples.ICalculator
    {
        
        public CalculatorClient()
        {
        }
        
        public CalculatorClient(string endpointConfigurationName) : 
                base(endpointConfigurationName)
        {
        }
        
        public CalculatorClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress)
        {
        }
        
        public CalculatorClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress)
        {
        }
        
        public CalculatorClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress)
        {
        }
        
        public int PowerOn()
        {
            return base.Channel.PowerOn();
        }
        
        public int Add(int value)
        {
            return base.Channel.Add(value);
        }
        
        public int Subtract(int value)
        {
            return base.Channel.Subtract(value);
        }
        
        public int Multiply(int value)
        {
            return base.Channel.Multiply(value);
        }
        
        public int Divide(int value)
        {
            return base.Channel.Divide(value);
        }
        
        public void PowerOff()
        {
            base.Channel.PowerOff();
        }
    }
}
