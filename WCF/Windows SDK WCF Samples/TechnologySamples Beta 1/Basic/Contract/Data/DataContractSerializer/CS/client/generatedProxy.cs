//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:2.0.50727.42
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Microsoft.ServiceModel.Samples
{
    using System.Runtime.Serialization;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "3.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute()]
    public partial class Record : object, System.Runtime.Serialization.IExtensibleDataObject
    {
        
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        private double n1Field;
        
        private double n2Field;
        
        private string operationField;
        
        private double resultField;
        
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData
        {
            get
            {
                return this.extensionDataField;
            }
            set
            {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public double n1
        {
            get
            {
                return this.n1Field;
            }
            set
            {
                this.n1Field = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public double n2
        {
            get
            {
                return this.n2Field;
            }
            set
            {
                this.n2Field = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string operation
        {
            get
            {
                return this.operationField;
            }
            set
            {
                this.operationField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public double result
        {
            get
            {
                return this.resultField;
            }
            set
            {
                this.resultField = value;
            }
        }
    }
}


[System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "3.0.0.0")]
[System.ServiceModel.ServiceContractAttribute(Namespace="http://Microsoft.ServiceModel.Samples")]
public interface IDataContractSerializerCalculator
{
    
    [System.ServiceModel.OperationContractAttribute(Action="http://Microsoft.ServiceModel.Samples/IDataContractSerializerCalculator/Add", ReplyAction="http://Microsoft.ServiceModel.Samples/IDataContractSerializerCalculator/AddRespon" +
        "se")]
    double Add(double n1, double n2);
    
    [System.ServiceModel.OperationContractAttribute(Action="http://Microsoft.ServiceModel.Samples/IDataContractSerializerCalculator/Divide", ReplyAction="http://Microsoft.ServiceModel.Samples/IDataContractSerializerCalculator/DivideRes" +
        "ponse")]
    double Divide(double n1, double n2);
    
    [System.ServiceModel.OperationContractAttribute(Action="http://Microsoft.ServiceModel.Samples/IDataContractSerializerCalculator/GetRecord" +
        "", ReplyAction="http://Microsoft.ServiceModel.Samples/IDataContractSerializerCalculator/GetRecord" +
        "Response")]
    Microsoft.ServiceModel.Samples.Record GetRecord();
    
    [System.ServiceModel.OperationContractAttribute(Action="http://Microsoft.ServiceModel.Samples/IDataContractSerializerCalculator/Multiply", ReplyAction="http://Microsoft.ServiceModel.Samples/IDataContractSerializerCalculator/MultiplyR" +
        "esponse")]
    double Multiply(double n1, double n2);
    
    [System.ServiceModel.OperationContractAttribute(Action="http://Microsoft.ServiceModel.Samples/IDataContractSerializerCalculator/Subtract", ReplyAction="http://Microsoft.ServiceModel.Samples/IDataContractSerializerCalculator/SubtractR" +
        "esponse")]
    double Subtract(double n1, double n2);
}

[System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "3.0.0.0")]
public interface IDataContractSerializerCalculatorChannel : IDataContractSerializerCalculator, System.ServiceModel.IClientChannel
{
}

[System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "3.0.0.0")]
public partial class DataContractSerializerCalculatorProxy : System.ServiceModel.ClientBase<IDataContractSerializerCalculator>, IDataContractSerializerCalculator
{
    
    public DataContractSerializerCalculatorProxy()
    {
    }
    
    public DataContractSerializerCalculatorProxy(string endpointConfigurationName) : 
            base(endpointConfigurationName)
    {
    }
    
    public DataContractSerializerCalculatorProxy(string endpointConfigurationName, string remoteAddress) : 
            base(endpointConfigurationName, remoteAddress)
    {
    }
    
    public DataContractSerializerCalculatorProxy(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
            base(endpointConfigurationName, remoteAddress)
    {
    }
    
    public DataContractSerializerCalculatorProxy(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
            base(binding, remoteAddress)
    {
    }
    
    public double Add(double n1, double n2)
    {
        return base.Channel.Add(n1, n2);
    }
    
    public double Divide(double n1, double n2)
    {
        return base.Channel.Divide(n1, n2);
    }
    
    public Microsoft.ServiceModel.Samples.Record GetRecord()
    {
        return base.Channel.GetRecord();
    }
    
    public double Multiply(double n1, double n2)
    {
        return base.Channel.Multiply(n1, n2);
    }
    
    public double Subtract(double n1, double n2)
    {
        return base.Channel.Subtract(n1, n2);
    }
}