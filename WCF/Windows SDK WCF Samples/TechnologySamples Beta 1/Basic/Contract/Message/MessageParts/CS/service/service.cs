
//  Copyright (c) Microsoft Corporation.  All Rights Reserved.

using System;
using System.ServiceModel.Channels;
using System.ServiceModel;
using System.Runtime.Serialization;

namespace Microsoft.ServiceModel.Samples
{
    // Define a service contract.
    [ServiceContract(Namespace="http://Microsoft.ServiceModel.Samples")]
    public interface ICalculator
    {
        [OperationContract(Action = "http://test/MyMessage_action", ReplyAction = "http://test/MyMessage_action")]
        MyMessage Calculate(MyMessage request);
    }

    // Custom message.
    [MessageContract(IsWrapped = false)]
    public class MyMessage
    {
        //Constructor - create an empty message.

        public MyMessage() {}

        //Constructor - create a message and populate its members.

        public MyMessage(double n1, double n2, string operation, double result)
        {
            this.n1 = n1;
            this.n2 = n2;
            this.operation = operation;
            this.result = result;
        }

        //Constructor - create a message from another message.

        public MyMessage(MyMessage message)
        {
            this.n1 = message.n1;
            this.n2 = message.n2;
            this.operation = message.operation;
            this.result = message.result;
        }

        [MessageHeader]
        private string operation;

		[MessageBodyMember(Name = "special1", Namespace = "http://Microsoft.ServiceModel.Samples/special")]
        private double n1;

		[MessageBodyMember(Name = "special2", Namespace = "http://Microsoft.ServiceModel.Samples/special")]
        private double n2;

        [MessageBodyMember]
        private double result;

        public string Operation
        {
            get { return operation; }
            set { operation = value; }
        }

        public double N1
        {
            get { return n1; }
            set { n1 = value; }
        }

        public double N2
        {
            get { return n2; }
            set { n2 = value; }
        }

        public double Result
        {
            get { return result; }
            set { result = value; }
        }

    }


    // Service class which implements the service contract.
    public class CalculatorService : ICalculator
    {
        // Perform a calculation.

        public MyMessage Calculate(MyMessage request)
        {
            MyMessage response = new MyMessage(request);
            switch (request.Operation)
            {
                case "+":
                    response.Result = request.N1 + request.N2;
                    break;
                case "-":
                    response.Result = request.N1 - request.N2;
                    break;
                case "*":
                    response.Result = request.N1 * request.N2;
                    break;
                case "/":
                    response.Result = request.N1 / request.N2;
                    break;
                default:
                    response.Result = 0.0D;
                    break;
            }
            return response;
        }
 
    }

}
