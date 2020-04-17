//------------------------------------------------------------------------------
// <autogenerated>
//     This code was generated by a tool.
//     Runtime Version:1.2.30703.27
//
//     Changes to this file may cause incorrect behavior and will be lost if 
//     the code is regenerated.
// </autogenerated>
//------------------------------------------------------------------------------

[assembly: System.Serialization.XsdNamespaceAttribute(ClrNamespace="LabServer_Types", TargetNamespace="uri:LabServer:Types")]

// 
// This source code was auto-generated by WsdlGen, Version=1.2.30703.27.
// 

namespace labserver {
    
    
    [System.MessageBus.Services.DialogPortTypeAttribute(Namespace="uri:labserver", ChannelType=typeof(IQuestionServiceClientChannel))]
    public interface IQuestionService {
        
        [System.MessageBus.Services.ServiceMethodAttribute()]
        string AskQuestion(string question);
    }
    
    public interface IQuestionServiceClient {
    }
    
    [System.MessageBus.Services.PortTypeChannelAttribute(Name="QuestionService", Namespace="uri:labserver", DispatchType=typeof(IQuestionServiceClient))]
    public interface IQuestionServiceChannel : System.MessageBus.Services.IDialogPortTypeChannel {
        
        [System.MessageBus.Services.WrappedMessageAttribute(Namespace="uri:labserver")]
        [System.MessageBus.Services.ServiceMethodAttribute()]
        [return: System.MessageBus.Services.WrappedMessageAttribute(Namespace="uri:labserver")]
        string AskQuestion(string question);
    }
    
    public interface IQuestionServiceClientChannel : System.MessageBus.Services.IDialogPortTypeChannel {
    }
    
    [System.MessageBus.Services.DatagramPortTypeAttribute(Namespace="uri:labserver")]
    public interface IRegistrationService {
        
        [System.MessageBus.Services.ServiceMethodAttribute()]
        LabServer_Types.RegisterResponseType Register(LabServer_Types.RegisterType message);
    }
    
    [System.MessageBus.Services.PortTypeChannelAttribute(Namespace="uri:labserver")]
    public interface IRegistrationServiceChannel : System.MessageBus.Services.IDatagramPortTypeChannel {
        
        [System.MessageBus.Services.ServiceMethodAttribute()]
        LabServer_Types.RegisterResponseType Register(LabServer_Types.RegisterType message);
    }
}
namespace LabServer_Types {
    using System;
    using System.Serialization;
    using System.Xml.Schema;
    
    
    [XsdGlobalElement(ValueType=typeof(string))]
    public class RegisterTypeName : XsdGlobalElement {
    }
    
    [XsdGlobalElement(ValueType=typeof(string))]
    public class RegisterTypeMachineName : XsdGlobalElement {
    }
    
    [XsdGlobalElement(ValueType=typeof(string))]
    public class RegisterResponseTypePassword : XsdGlobalElement {
    }
    
    [System.MessageBus.Services.MessageAttribute(Namespace="uri:LabServer:Types")]
    public class RegisterType : System.MessageBus.Services.TypedMessage {
        
        private string NameField;
        
        private string MachineNameField;
        
        public RegisterType() : 
                base() {
        }
        
        public RegisterType(System.MessageBus.Message message) : 
                base(message) {
        }
        
        public RegisterType(string Name, string MachineName) : 
                this() {
            this.NameField = Name;
            this.MachineNameField = MachineName;
        }
        
        [System.MessageBus.Services.MessageBodyAttribute()]
        public string Name {
            get {
                base.Initialize();
                return this.NameField;
            }
            set {
                this.NameField = value;
            }
        }
        
        [System.MessageBus.Services.MessageBodyAttribute()]
        public string MachineName {
            get {
                base.Initialize();
                return this.MachineNameField;
            }
            set {
                this.MachineNameField = value;
            }
        }
    }
    
    [System.MessageBus.Services.MessageAttribute(Namespace="uri:LabServer:Types")]
    public class RegisterResponseType : System.MessageBus.Services.TypedMessage {
        
        private string PasswordField;
        
        public RegisterResponseType() : 
                base() {
        }
        
        public RegisterResponseType(System.MessageBus.Message message) : 
                base(message) {
        }
        
        public RegisterResponseType(string Password) : 
                this() {
            this.PasswordField = Password;
        }
        
        [System.MessageBus.Services.MessageBodyAttribute()]
        public string Password {
            get {
                base.Initialize();
                return this.PasswordField;
            }
            set {
                this.PasswordField = value;
            }
        }
    }
}
