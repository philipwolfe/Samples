' Copyright (c) Microsoft Corporation.  All Rights Reserved.

Imports System
Imports System.Collections.Generic
Imports System.Text
Imports System.ServiceModel
Imports System.Configuration

Namespace Microsoft.ServiceModel.Samples

    Class Program

        Public Shared Sub Main(ByVal args As String())

            Using host As New ServiceHost(GetType(CalculatorService))

                host.Open()
                Console.WriteLine("Press <ENTER> to terminate service.")
                Console.ReadLine()

            End Using

        End Sub

    End Class

End Namespace
