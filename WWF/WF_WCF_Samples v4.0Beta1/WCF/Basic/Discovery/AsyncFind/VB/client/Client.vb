'----------------------------------------------------------------
' Copyright (c) Microsoft Corporation.  All rights reserved.
'----------------------------------------------------------------

Imports Microsoft.VisualBasic
Imports System
Imports System.ServiceModel
Imports System.ServiceModel.Discovery
Imports System.Threading

Namespace Microsoft.Samples.Discovery

	Friend Class Client
		Private Shared endpointAddress As EndpointAddress
		Private Shared syncEvent As AutoResetEvent

		Public Shared Sub Main()
			FindCalculatorServiceAddress()

			If endpointAddress IsNot Nothing Then
				InvokeCalculatorService(endpointAddress)
			End If

			Console.WriteLine("Press <ENTER> to exit.")
			Console.ReadLine()
		End Sub

		Private Shared Sub FindCalculatorServiceAddress()
			syncEvent = New AutoResetEvent(False)

			Dim discoveryClient As New DiscoveryClient(New UdpDiscoveryEndpoint())

			AddHandler discoveryClient.FindCompleted, AddressOf ClientFindCompleted
			AddHandler discoveryClient.FindProgressChanged, AddressOf ClientFindProgressChanged

			Console.WriteLine("Finding ICalculatorServices endpoints asynchronously...")
			Console.WriteLine()

			' Find ICalculatorService endpoint asynchronously. The results are returned asynchronously via events            
			discoveryClient.FindAsync(New FindCriteria(GetType(ICalculatorService)))

			' Wait for the asynchronous find operation to complete
			syncEvent.WaitOne()
		End Sub

		Private Shared Sub ClientFindProgressChanged(ByVal sender As Object, ByVal e As FindProgressChangedEventArgs)
			Console.WriteLine("Found ICalculatorService endpoint at {0}", e.EndpointDiscoveryMetadata.Address.Uri)
		End Sub

		Private Shared Sub ClientFindCompleted(ByVal sender As Object, ByVal e As FindCompletedEventArgs)
			Console.WriteLine("Asynchronous find completed. Found {0} ICalculatorService endpoint(s).", e.Result.Endpoints.Count)
			Console.WriteLine()

			If e.Result.Endpoints.Count > 0 Then
				endpointAddress = e.Result.Endpoints(0).Address
			End If

			syncEvent.Set()
		End Sub

		Private Shared Sub InvokeCalculatorService(ByVal endpointAddress As EndpointAddress)
			' Create a client
			Dim client As New CalculatorServiceClient()

			' Connect to the discovered service endpoint
			client.Endpoint.Address = endpointAddress

			Console.WriteLine("Invoking CalculatorService at {0}", endpointAddress)

			Dim value1 As Double = 100.00R
			Dim value2 As Double = 15.99R

			' Call the Add service operation.
			Dim result As Double = client.Add(value1, value2)
			Console.WriteLine("Add({0},{1}) = {2}", value1, value2, result)

			' Call the Subtract service operation.
			result = client.Subtract(value1, value2)
			Console.WriteLine("Subtract({0},{1}) = {2}", value1, value2, result)

			' Call the Multiply service operation.
			result = client.Multiply(value1, value2)
			Console.WriteLine("Multiply({0},{1}) = {2}", value1, value2, result)

			' Call the Divide service operation.
			result = client.Divide(value1, value2)
			Console.WriteLine("Divide({0},{1}) = {2}", value1, value2, result)
			Console.WriteLine()

			'Closing the client gracefully closes the connection and cleans up resources
			client.Close()
		End Sub
	End Class
End Namespace

