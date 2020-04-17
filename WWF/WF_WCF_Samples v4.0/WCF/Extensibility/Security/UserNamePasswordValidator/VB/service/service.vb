﻿'-----------------------------------------------------------------------------
' Copyright (c) Microsoft Corporation.  All rights reserved.
'-----------------------------------------------------------------------------
Imports System.IdentityModel.Selectors
Imports System.Security.Principal
Imports System.ServiceModel

Namespace Microsoft.Samples.UserNamePasswordValidator
	' Define a service contract.
    <ServiceContract(Namespace:="http://Microsoft.Samples.UserNamePasswordValidator")>
 Public Interface ICalculator
        <OperationContract()>
        Function Add(ByVal n1 As Double, ByVal n2 As Double) As Double
        <OperationContract()>
        Function Subtract(ByVal n1 As Double, ByVal n2 As Double) As Double
        <OperationContract()>
        Function Multiply(ByVal n1 As Double, ByVal n2 As Double) As Double
        <OperationContract()>
        Function Divide(ByVal n1 As Double, ByVal n2 As Double) As Double
    End Interface

	' Service class which implements the service contract.
    ' Added code to write output to the console window.
    <ServiceBehavior(IncludeExceptionDetailInFaults:=True)>
 Public Class CalculatorService
        Implements ICalculator
        Public Function Add(ByVal n1 As Double, ByVal n2 As Double) As Double Implements ICalculator.Add
            Dim result = n1 + n2
            Console.WriteLine("Received Add({0},{1})", n1, n2)
            Console.WriteLine("Return: {0}", result)
            Return result
        End Function


        Public Function Subtract(ByVal n1 As Double, ByVal n2 As Double) As Double Implements ICalculator.Subtract
            Dim result = n1 - n2
            Console.WriteLine("Received Subtract({0},{1})", n1, n2)
            Console.WriteLine("Return: {0}", result)
            Return result
        End Function


        Public Function Multiply(ByVal n1 As Double, ByVal n2 As Double) As Double Implements ICalculator.Multiply
            Dim result = n1 * n2
            Console.WriteLine("Received Multiply({0},{1})", n1, n2)
            Console.WriteLine("Return: {0}", result)
            Return result
        End Function


        Public Function Divide(ByVal n1 As Double, ByVal n2 As Double) As Double Implements ICalculator.Divide
            Dim result = n1 / n2
            Console.WriteLine("Received Divide({0},{1})", n1, n2)
            Console.WriteLine("Return: {0}", result)
            Return result
        End Function

        Public Class CustomUserNameValidator
            Inherits IdentityModel.Selectors.UserNamePasswordValidator
            ' This method validates users. It allows in two users, test1 and test2 
            ' with passwords 1tset and 2tset respectively.
            ' This code is for illustration purposes only and 
            ' MUST NOT be used in a production environment because it is NOT secure.	
            Public Overrides Sub Validate(ByVal userName As String, ByVal password As String)
                If Nothing Is userName OrElse Nothing Is password Then
                    Throw New ArgumentNullException()
                End If

                If Not (userName = "test1" AndAlso password = "1tset") AndAlso
                    Not (userName = "test2" AndAlso password = "2tset") Then
                    Throw New FaultException("Unknown Username or Incorrect Password")
                End If
            End Sub
        End Class

        ' Host the service within this EXE console application.
        Public Shared Sub Main()
            ' Create a ServiceHost for the CalculatorService type and provide the base address.
            Using serviceHost As New ServiceHost(GetType(CalculatorService))
                ' Open the ServiceHostBase to create listeners and start listening for messages.
                serviceHost.Open()

                ' The service can now be accessed.
                Console.WriteLine("The service is ready.")
                Console.WriteLine("The service is running in the following account: {0}", WindowsIdentity.GetCurrent().Name)
                Console.WriteLine("Press <ENTER> to terminate service.")
                Console.WriteLine()
                Console.ReadLine()
            End Using
        End Sub
    End Class
End Namespace

