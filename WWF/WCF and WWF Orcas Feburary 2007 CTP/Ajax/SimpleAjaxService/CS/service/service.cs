
//  Copyright (c) Microsoft Corporation.  All Rights Reserved.

using System;
using System.ServiceModel;

namespace Microsoft.Ajax.Samples 
{
    // Define a service contract.
    [ServiceContract(Namespace = "http://Microsoft.Ajax.Samples")]
    public interface ICalculator
    {
        [OperationContract]
        [HttpTransferContract(Method="GET")]
        double Add(double n1, double n2);
        [OperationContract]
        [HttpTransferContract(Method = "GET")]
        double Subtract(double n1, double n2);
        [OperationContract]
        [HttpTransferContract(Method = "GET")]
        double Multiply(double n1, double n2);
        [OperationContract]
        [HttpTransferContract(Method = "GET")]
        double Divide(double n1, double n2);
    }

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

}
