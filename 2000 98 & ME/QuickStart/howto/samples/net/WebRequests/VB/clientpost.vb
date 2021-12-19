Imports System
Imports System.Net
Imports System.IO

Namespace Client
  Public class ClientPOST         
    Public Shared Sub  Main()
      Dim args As String ()

   		args = Environment.GetCommandLineArgs()

    	If (args.Length < 2)
        showusage()
        return
			End If

      getPage(args(1), "sl=foo&s2=bar")
      return
      
    End Sub

	public Shared Sub showusage()
		Console.WriteLine("Attempts to POST to a URL")
        Console.WriteLine("Usage:")
        Console.WriteLine("ClientPOST URL")
        Console.WriteLine("Examples:")
        Console.WriteLine("ClientPOST http://www.nba.com")
	End Sub

	public Shared Sub getPage(url As String, payload as String)

		Dim req As WebRequest		
		Dim RequestStream As Stream
		req = WebRequestFactory.Create(url)
		req.Method = "POST"
		req.ContentType = "application/x-www-form-urlencoded"
		Dim SomeBytes() as Byte
		if payload <> Nothing
			SomeBytes = System.Text.Encoding.ASCII.GetBytes(payload)
			req.ContentLength = SomeBytes.Length
			RequestStream = req.GetRequestStream()
			RequestStream.Write(SomeBytes, 0, SomeBytes.Length)
			RequestStream.Close()
		Else
			req.ContentLength = 0
		End if

		Dim result As WebResponse
		Dim ReceiveStream As Stream
		result = req.GetResponse()		
        ReceiveStream = result.GetResponseStream()                
        Console.WriteLine("Response stream received, Status code: " & result.Status)
        
			Dim read(512) As Byte
        	Dim bytes As Integer
        	bytes = ReceiveStream.Read(read, 0, 512)
        	Console.WriteLine("HTML...")
        
        	Do while (bytes > 0) 
        	
            	Console.Write(System.Text.Encoding.ASCII.GetString(read, 0, bytes))
           		bytes = ReceiveStream.Read(read, 0, 512)
        	Loop

        	Console.WriteLine("")

	End Sub

    End Class
End Namespace

