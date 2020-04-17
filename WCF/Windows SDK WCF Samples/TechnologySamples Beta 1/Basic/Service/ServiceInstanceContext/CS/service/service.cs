
//  Copyright (c) Microsoft Corporation.  All Rights Reserved.

using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.ServiceModel;
using System.Runtime.Serialization;

namespace Microsoft.ServiceModel.Samples
{
    // Define a service contract.
    [ServiceContract(Namespace="http://Microsoft.ServiceModel.Samples")]
    public interface IInstanceContextCalculator
    {
        [OperationContract]
        int Add(int n1, int n2);
        [OperationContract]
        int Subtract(int n1, int n2);
        [OperationContract]
        int Multiply(int n1, int n2);
        [OperationContract]
        int Divide(int n1, int n2);
        [OperationContract]
        string GetInstanceContextInfo();
    }

    // Service class which implements the service contract.
    public class CalculatorService : IInstanceContextCalculator
    {
        public int Add(int n1, int n2)
        {
            return n1 + n2;
        }

        public int Subtract(int n1, int n2)
        {
            return n1 - n2;
        }

        public int Multiply(int n1, int n2)
        {
            return n1 * n2;
        }

        public int Divide(int n1, int n2)
        {
            return n1 / n2;
        }

        // Obtain information from the InstanceContext and return it as a multi-line string.

        public string GetInstanceContextInfo()
        {
            string info = "";

            OperationContext operationContext = OperationContext.Current;
            InstanceContext instanceContext = operationContext.InstanceContext;

            info += "    " + "State: " + instanceContext.State.ToString() + "\n";
            info += "    " + "ManualFlowControlLimit: " + instanceContext.ManualFlowControlLimit.ToString() + "\n";
            info += "    " + "HashCode: " + instanceContext.GetHashCode().ToString() + "\n";
            
         
            return info;
        }
    }
 
}
