//---------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:2.0.50215.35
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
namespace Microsoft.ServiceModel.Samples
{

    using System;

    using System.ServiceModel.Channels;
    using System.ServiceModel;
    using System.Runtime.Serialization;
    using System.Xml;
    using System.Xml.Serialization;
    using System.IO;
    

    [ServiceContract(Namespace = "http://Microsoft.ServiceModel.Samples"), XmlSerializerFormat]
    public interface IUntypedCalculator
    {
        
        [OperationContract(Action="*", ReplyAction="*")]
        Message Calculate(Message request);
            
    }

    public class CalculatorOperations
    {    
        public const string Add = "Add";
        public const string Subtract = "Subtract";
        public const string Divide = "Divide";
        public const string Mutiply ="Multiply";
        public const string NamespaceUri = "http://tempuri.org/";
    }

    public class CalculatorService : IUntypedCalculator
    {
        public Message Calculate(Message request)
        {            

            XmlReader bodyReader = request.GetReaderAtBodyContents();
            bodyReader.MoveToContent();

            if ( (bodyReader.NodeType != XmlNodeType.Element) || (bodyReader.NamespaceURI != CalculatorOperations.NamespaceUri))
            {
                return Message.CreateMessage(MessageVersion.Soap12WSAddressing10, MessageFault.CreateFault(new FaultCode("Client"), new FaultReason("Invalid Message")),"");
            }            
            
            XmlSerializer ser;
            switch (bodyReader.LocalName)
            {

                case CalculatorOperations.Add:
                    ser = new XmlSerializer(typeof(Add_RequestMessage));
                    Add_ResponseMessage addResponse = this.Add(ser.Deserialize(bodyReader) as Add_RequestMessage);
                    return CreateResponseMessage(addResponse);

                case CalculatorOperations.Subtract:
                    ser = new XmlSerializer(typeof(Subtract_RequestMessage));
                    Subtract_ResponseMessage subResponse = this.Subtract(ser.Deserialize(bodyReader) as Subtract_RequestMessage);
                    return CreateResponseMessage(subResponse);

                case CalculatorOperations.Divide:
                    ser = new XmlSerializer(typeof(Divide_RequestMessage));
                    Divide_ResponseMessage divResponse = this.Divide(ser.Deserialize(bodyReader) as Divide_RequestMessage);
                    return CreateResponseMessage(divResponse);

                case CalculatorOperations.Mutiply:
                    ser = new XmlSerializer(typeof(Multiply_RequestMessage));
                    Multiply_ResponseMessage mulResponse = this.Multiply(ser.Deserialize(bodyReader) as Multiply_RequestMessage);
                    return CreateResponseMessage(mulResponse);

                default:
                    return Message.CreateMessage(MessageVersion.Soap11WSAddressing10, MessageFault.CreateFault(new FaultCode("Client"), new FaultReason("Invalid Message")),"");
            }
            
        }
        
        Add_ResponseMessage Add(Add_RequestMessage request)
        {
            Add_ResponseMessage response = new Add_ResponseMessage();
            response.AddResult = request.n1 + request.n2;
            return response;
        }

        Subtract_ResponseMessage Subtract(Subtract_RequestMessage request)
        {
             Subtract_ResponseMessage response = new Subtract_ResponseMessage();
             response.SubtractResult = request.n1 - request.n2;
             return response;
        }


        Multiply_ResponseMessage Multiply(Multiply_RequestMessage request)
        {
            Multiply_ResponseMessage response = new Multiply_ResponseMessage();
            response.MultiplyResult = request.n1 * request.n2;
            return response;
        }

        Divide_ResponseMessage Divide(Divide_RequestMessage request)
        {
            Divide_ResponseMessage response = new Divide_ResponseMessage();
            response.DivideResult = request.n1 / request.n2;
            return response;
        }
        
        Message CreateResponseMessage(Object response)
        {
            XmlSerializer ser = new XmlSerializer(response.GetType());
            MemoryStream stream = new MemoryStream();            
            ser.Serialize(stream, response);            
            stream.Position = 0;
            XmlReader reader = new XmlTextReader(new StreamReader(stream));
            return Message.CreateMessage(MessageVersion.Soap11WSAddressing10, "", reader);
        }
    }


    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://tempuri.org/")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://tempuri.org/", ElementName="Add", IsNullable = false)]
    public class Add_RequestMessage
    {

        [System.Xml.Serialization.XmlElement(Namespace="http://tempuri.org/")]
        public double n1;

        [System.Xml.Serialization.XmlElement(Namespace = "http://tempuri.org/")]
        public double n2;
    }

    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://tempuri.org/")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://tempuri.org/", ElementName = "AddResponse", IsNullable = false)]
    public class Add_ResponseMessage
    {

        [System.Xml.Serialization.XmlElement(Namespace = "http://tempuri.org/")]
        public double AddResult;
    }


    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://tempuri.org/")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://tempuri.org/", ElementName = "Subtract", IsNullable = false)]
        public class Subtract_RequestMessage
    {

        [System.Xml.Serialization.XmlElement(Namespace = "http://tempuri.org/")]
        public double n1;

        [System.Xml.Serialization.XmlElement(Namespace = "http://tempuri.org/")]
        public double n2;
    }

    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://tempuri.org/")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://tempuri.org/", ElementName = "SubtractResponse", IsNullable = false)]
    public class Subtract_ResponseMessage
    {

        [System.Xml.Serialization.XmlElement(Namespace = "http://tempuri.org/")]
        public double SubtractResult;
    }


    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://tempuri.org/")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://tempuri.org/", ElementName = "Multiply", IsNullable = false)]
    public class Multiply_RequestMessage
    {

        [System.Xml.Serialization.XmlElement(Namespace = "http://tempuri.org/")]
        public double n1;

        [System.Xml.Serialization.XmlElement(Namespace = "http://tempuri.org/")]
        public double n2;
    }

    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://tempuri.org/")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://tempuri.org/", ElementName = "MultiplyResponse", IsNullable = false)]
    public class Multiply_ResponseMessage
    {

        [System.Xml.Serialization.XmlElement(Namespace = "http://tempuri.org/")]
        public double MultiplyResult;
    }


    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://tempuri.org/")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://tempuri.org/", ElementName = "Divide", IsNullable = false)]
    public class Divide_RequestMessage
    {

        [System.Xml.Serialization.XmlElement(Namespace = "http://tempuri.org/")]
        public double n1;

        [System.Xml.Serialization.XmlElement(Namespace = "http://tempuri.org/")]
        public double n2;
    }

    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://tempuri.org/")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://tempuri.org/", ElementName = "DivideResponse", IsNullable = false)]
    public class Divide_ResponseMessage
    {

        [System.Xml.Serialization.XmlElement(Namespace = "http://tempuri.org/")]
        public double DivideResult;
    }
}
