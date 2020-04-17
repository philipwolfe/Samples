'----------------------------------------------------------------
' Copyright (c) Microsoft Corporation.  All rights reserved.
'----------------------------------------------------------------

Imports Microsoft.VisualBasic
Imports System
Imports System.ServiceModel
Imports System.ServiceModel.Discovery

Namespace Microsoft.Samples.Discovery

	Friend Class CalculatorServiceHost
		Public Shared Sub Main()
			Dim baseAddress As New Uri("http://localhost:8000/" & Guid.NewGuid().ToString())

			Using serviceHost As New ServiceHost(GetType(CalculatorService), baseAddress)
				serviceHost.AddServiceEndpoint(GetType(ICalculatorService), New WSHttpBinding(), String.Empty)

				' Make the service discoverable over UDP multicast
				serviceHost.Description.Behaviors.Add(New ServiceDiscoveryBehavior())
				serviceHost.AddServiceEndpoint(New UdpDiscoveryEndpoint())

				serviceHost.Open()

				Console.WriteLine("Calculator Service started at {0}", baseAddress)
				Console.WriteLine()
				Console.WriteLine("Press <ENTER> to terminate the service.")
				Console.WriteLine()
				Console.ReadLine()
			End Using
		End Sub

	End Class
End Namespace
