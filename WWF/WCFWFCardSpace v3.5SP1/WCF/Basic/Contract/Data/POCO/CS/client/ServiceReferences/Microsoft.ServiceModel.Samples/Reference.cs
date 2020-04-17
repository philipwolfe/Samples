﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:2.0.50727.1433
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Microsoft.ServiceModel.Samples {
    using System.Runtime.Serialization;
    using System;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "3.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="ComplexNumber", Namespace="http://schemas.datacontract.org/2004/07/Microsoft.ServiceModel.Samples")]
    [System.SerializableAttribute()]
    public partial class ComplexNumber : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private double ImaginaryField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private double RealField;
        
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public double Imaginary {
            get {
                return this.ImaginaryField;
            }
            set {
                if ((this.ImaginaryField.Equals(value) != true)) {
                    this.ImaginaryField = value;
                    this.RaisePropertyChanged("Imaginary");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public double Real {
            get {
                return this.RealField;
            }
            set {
                if ((this.RealField.Equals(value) != true)) {
                    this.RealField = value;
                    this.RaisePropertyChanged("Real");
                }
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "3.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(Namespace="http://Microsoft.ServiceModel.Samples", ConfigurationName="Microsoft.ServiceModel.Samples.IDataContractCalculator")]
    public interface IDataContractCalculator {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://Microsoft.ServiceModel.Samples/IDataContractCalculator/Add", ReplyAction="http://Microsoft.ServiceModel.Samples/IDataContractCalculator/AddResponse")]
        Microsoft.ServiceModel.Samples.ComplexNumber Add(Microsoft.ServiceModel.Samples.ComplexNumber n1, Microsoft.ServiceModel.Samples.ComplexNumber n2);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://Microsoft.ServiceModel.Samples/IDataContractCalculator/Subtract", ReplyAction="http://Microsoft.ServiceModel.Samples/IDataContractCalculator/SubtractResponse")]
        Microsoft.ServiceModel.Samples.ComplexNumber Subtract(Microsoft.ServiceModel.Samples.ComplexNumber n1, Microsoft.ServiceModel.Samples.ComplexNumber n2);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://Microsoft.ServiceModel.Samples/IDataContractCalculator/Multiply", ReplyAction="http://Microsoft.ServiceModel.Samples/IDataContractCalculator/MultiplyResponse")]
        Microsoft.ServiceModel.Samples.ComplexNumber Multiply(Microsoft.ServiceModel.Samples.ComplexNumber n1, Microsoft.ServiceModel.Samples.ComplexNumber n2);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://Microsoft.ServiceModel.Samples/IDataContractCalculator/Divide", ReplyAction="http://Microsoft.ServiceModel.Samples/IDataContractCalculator/DivideResponse")]
        Microsoft.ServiceModel.Samples.ComplexNumber Divide(Microsoft.ServiceModel.Samples.ComplexNumber n1, Microsoft.ServiceModel.Samples.ComplexNumber n2);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "3.0.0.0")]
    public interface IDataContractCalculatorChannel : Microsoft.ServiceModel.Samples.IDataContractCalculator, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "3.0.0.0")]
    public partial class DataContractCalculatorClient : System.ServiceModel.ClientBase<Microsoft.ServiceModel.Samples.IDataContractCalculator>, Microsoft.ServiceModel.Samples.IDataContractCalculator {
        
        public DataContractCalculatorClient() {
        }
        
        public DataContractCalculatorClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public DataContractCalculatorClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public DataContractCalculatorClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public DataContractCalculatorClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public Microsoft.ServiceModel.Samples.ComplexNumber Add(Microsoft.ServiceModel.Samples.ComplexNumber n1, Microsoft.ServiceModel.Samples.ComplexNumber n2) {
            return base.Channel.Add(n1, n2);
        }
        
        public Microsoft.ServiceModel.Samples.ComplexNumber Subtract(Microsoft.ServiceModel.Samples.ComplexNumber n1, Microsoft.ServiceModel.Samples.ComplexNumber n2) {
            return base.Channel.Subtract(n1, n2);
        }
        
        public Microsoft.ServiceModel.Samples.ComplexNumber Multiply(Microsoft.ServiceModel.Samples.ComplexNumber n1, Microsoft.ServiceModel.Samples.ComplexNumber n2) {
            return base.Channel.Multiply(n1, n2);
        }
        
        public Microsoft.ServiceModel.Samples.ComplexNumber Divide(Microsoft.ServiceModel.Samples.ComplexNumber n1, Microsoft.ServiceModel.Samples.ComplexNumber n2) {
            return base.Channel.Divide(n1, n2);
        }
    }
}
