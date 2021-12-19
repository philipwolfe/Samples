Imports System
Imports System.Net
Imports System.Threading
Imports System.IO

Namespace Client
    Public class ClientGetAsync

        Const MAX As Integer = 20

        Public Shared Sub Main()
            Dim args As String ()
            args = Environment.GetCommandLineArgs()

            If (args.Length < 2)
                showusage()
                return
            End If

            Dim HttpSite As URI
            Dim wreq As HttpWebRequest
            Dim r As IAsyncResult
            HttpSite = new URI(args(1))
            wreq = CType(WebRequestFactory.Create(HttpSite), HttpWebRequest)
            r = CType(wreq.BeginGetResponse(new AsyncCallback(AddressOf RespCallback), Nothing), IAsyncResult)
            Thread.Sleep(3000)
            Console.WriteLine("Exiting.")
        End Sub

        public Shared Sub showusage()
            Console.WriteLine("Attempts to GET a URL")
            Console.WriteLine()
            Console.WriteLine("Usage:")
            Console.WriteLine("ClientGetAsync URL")
            Console.WriteLine("Examples:")
            Console.WriteLine("ClientGetAsync http://www.microsoft.com/net/")
        End Sub

        Private Shared Sub RespCallback(ar As IAsyncResult)
            Dim req As HttpWebRequest
            Dim resp As HttpWebResponse
            Dim BytesRead As Integer
            Dim Reader As StreamReader
            Dim Writer As StringWriter

            req = CType(ar.AsyncObject, HttpWebRequest)
            resp = CType(req.EndGetResponse(ar), HttpWebResponse)

            BytesRead = 0
            Dim Buffer(MAX) As Char

            Reader = new StreamReader(resp.GetResponseStream(), System.Text.Encoding.UTF8)
            Writer = new StringWriter()
            BytesRead = Reader.Read(Buffer, 0, MAX)
            Do While (BytesRead <> 0 )
                Writer.Write(Buffer, 0, MAX)
                BytesRead = Reader.Read(Buffer, 0, MAX)
            Loop

            Console.WriteLine("Message = " & Writer.ToString())
        End Sub
    End Class
End Namespace
