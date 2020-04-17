
//  Copyright (c) Microsoft Corporation.  All Rights Reserved.

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


    [ServiceContract(Namespace = "http://Microsoft.ServiceModel.Samples"), XmlSerializerFormat, DispatchByBodyBehavior]
    public interface ICalculator
    {
        [OperationContract(Action="")]
        double Add(double n1, double n2);
        [OperationContract(Action = "")]
        double Subtract(double n1, double n2);
        [OperationContract(Action = "")]
        double Multiply(double n1, double n2);
        [OperationContract(Action = "")]
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