'----------------------------------------------------------------
' Copyright (c) Microsoft Corporation.  All rights reserved.
'----------------------------------------------------------------

Imports Microsoft.VisualBasic
Imports System
Imports System.ServiceModel

Namespace Microsoft.Samples.BlobMessageEncoder

	Friend Class Server
		Public Shared Sub Main()
            Console.WriteLine("Testing image upload and download using BlobHttpBinding")

			Using host As New ServiceHost(New FileService())
				host.Open()
				Console.WriteLine("Service started at: " & host.ChannelDispatchers(0).Listener.Uri.AbsoluteUri)
				Console.WriteLine("Press <ENTER> to terminate service")
				Console.ReadLine()
			End Using
		End Sub
	End Class
End Namespace
