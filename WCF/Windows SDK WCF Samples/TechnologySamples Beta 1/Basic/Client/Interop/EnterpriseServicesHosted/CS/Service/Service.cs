
//  Copyright (c) Microsoft Corporation.  All Rights Reserved.

using System;
using System.EnterpriseServices;
using System.Runtime.InteropServices;

// Enterprise Service attributes used to define the application and component configuration
[assembly: ApplicationName("ServiceModelHostedSample")]
[assembly: ApplicationID("4CDCDB2C-0B19-4534-95CD-FBBFF4D67DD9")]
[assembly: ApplicationActivation(ActivationOption.Server)]
[assembly: ApplicationAccessControl(false)]

namespace Microsoft.ServiceModel.Samples
{
    [Guid("C551FBA9-E3AA-4272-8C2A-84BD8D290AC7")]
    // Define the component's interface.
    public interface ICalculator
    {
        double Add(double n1, double n2);
        double Subtract(double n1, double n2);
        double Multiply(double n1, double n2);
        double Divide(double n1, double n2);
    }

    [Guid("C2B84940-AD54-4a44-B5F7-928130980AB9")]
    [ProgId("ServiceModelHostedSample.esCalculator")]
    // Supporting implementation for the ICalculator interface.
    public class esCalculatorService : ServicedComponent, ICalculator
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
