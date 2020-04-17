
'  Copyright (c) Microsoft Corporation.  All Rights Reserved.

Imports System
Imports System.Collections
Imports System.Collections.Generic
Imports System.IO
Imports System.ServiceModel
Imports System.Runtime.Serialization

Namespace Microsoft.ServiceModel.Samples

    ' Define a service contract.
    <ServiceContract(Namespace:="http://Microsoft.ServiceModel.Samples")> _
    Public Interface IInstanceContextCalculator

        <OperationContract()> _
        Function Add(ByVal n1 As Integer, ByVal n2 As Integer) As Integer
        <OperationContract()> _
        Function Subtract(ByVal n1 As Integer, ByVal n2 As Integer) As Integer
        <OperationContract()> _
        Function Multiply(ByVal n1 As Integer, ByVal n2 As Integer) As Integer
        <OperationContract()> _
        Function Divide(ByVal n1 As Integer, ByVal n2 As Integer) As Integer
        <OperationContract()> _
        Function GetInstanceContextInfo() As String
    End Interface

        ' Service class which implements the service contract.
    Public Class CalculatorService
        Implements IInstanceContextCalculator

        Public Function Add(ByVal n1 As Integer, ByVal n2 As Integer) As Integer _
Implements IInstanceContextCalculator.Add
            Return n1 + n2
        End Function

        Public Function Subtract(ByVal n1 As Integer, ByVal n2 As Integer) As Integer _
Implements IInstanceContextCalculator.Subtract
            Return n1 - n2
        End Function

        Public Function Multiply(ByVal n1 As Integer, ByVal n2 As Integer) As Integer _
Implements IInstanceContextCalculator.Multiply
            Return n1 * n2
        End Function

        Public Function Divide(ByVal n1 As Integer, ByVal n2 As Integer) As Integer _
        Implements IInstanceContextCalculator.Divide

            Return n1 / n2
        End Function

        ' Obtain information from the InstanceContext and return it as a multi-line string.

        Public Function GetInstanceContextInfo() As String _
         Implements IInstanceContextCalculator.GetInstanceContextInfo
            Dim info As String = ""
            Dim operContext As OperationContext = OperationContext.Current
            Dim instanceContext As InstanceContext = operContext.InstanceContext

            info += "    " + "State: " + instanceContext.State.ToString() + Environment.NewLine
            info += "    " + "ManualFlowControlLimit: " + instanceContext.ManualFlowControlLimit.ToString() + Environment.NewLine
            info += "    " + "HashCode: " + instanceContext.GetHashCode().ToString() + Environment.NewLine


            Return info
        End Function
    End Class

End Namespace
