Imports System
Imports System.Net
Imports System.IO
Imports System.Text
Imports microsoft.visualbasic

Namespace Client
Public Class ClientWebException
  
    Public Shared Sub Main()
        Dim length As Integer = 1024
        Dim bytesread As Integer = 0
        Dim Buffer() As Char = New Char(1025) {}
        Dim ResolvedURI As Boolean = False
        Dim UriToResolve As String
        
        While (Not ResolvedURI)
            Try
                ' Get a uri from the user
                Console.Write("Please enter the uri to resolve: ")
                UriToResolve = Console.ReadLine()
                Console.WriteLine()
                
                ' Create the request object
                Dim request As WebRequest = WebRequestFactory.Create(UriToResolve)
                request.Credentials = New SingleCredential("invaliduser", "invalidpassword")
                
                ' Create the response object
                Dim response As WebResponse = request.GetResponse()
                Console.WriteLine(response.Status)
                
                ' Successfully resolved the URI
                ResolvedURI = True
                
                ' Get a readable stream from the server 
                Dim sr As StreamReader = New StreamReader(response.GetResponseStream(), Encoding.ASCII)
                
                ' Read from the stream and write any data to the console
                bytesread = sr.Read(Buffer, 0, length)
                While (bytesread > 0)
                    Console.Write(Buffer, 0, CInt(bytesread))
                    bytesread = sr.Read(Buffer, 0, length)
                End While
            Catch WebExcp As WebException
                '  If you get to this point, the exception has been caught
                Console.WriteLine("A WebException has been caught!")
                
                '  Write out the Exception message
                Console.WriteLine(WebExcp.ToString())
                
                '  Get the WebException status code
                Dim st As Integer = Convert.ToInt32(WebExcp.Status)
                If (st = 7) Then '  7 indicates a protocol error, thus a WebResonse object should exist
                    '  Write out the WebResponse protocol status
                    Console.Write("The protocol error returned by the server is ")
                    Console.WriteLine(WebExcp.Response.Status)
                    Console.WriteLine()
                End If
            Catch UriExcp As URIFormatException
                '  If you get to this point, the exception has been caught
                Console.WriteLine("A URIFormatException has been caught!")                
                '  Write out the Exception message
                Console.WriteLine(UriExcp.ToString())
	    Catch e As Exception
		console.WriteLine(e.ToString())
            End Try
        End While
        
    End Sub
End Class
End Namespace
