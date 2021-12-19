Imports System
Imports System.Net
Imports System.IO

Namespace Client
    Public class ClientGETntlm
        Public Shared bShow As Boolean

        Public Shared Sub Main()
            Dim args As String ()
            args = Environment.GetCommandLineArgs()

            If (args.Length < 5)
                showusage()
                return
            End If

            if (args.Length > 5)
                bShow = false
            Else
                bShow = true
            End If

            getPage(args(1), args(2), args(3), args(4))

            return
        End Sub

        public Shared Sub showusage()
            Console.WriteLine("Attempts to GET a URL")
            Console.WriteLine()
            Console.WriteLine("Usage:")
            Console.WriteLine("ClientGETwithNTLM URL username password domain")
            Console.WriteLine("Examples:")
            Console.WriteLine("ClientGETwithNTLM http://www.microsoft.com/net/ Bobby BobbyLovesMangos THEDOMAIN")
        End Sub

        public Shared Sub getPage(url As String, username As String, password As String, Domain As String)
            Dim req As WebRequest
            Dim sc As SingleCredential
            Dim result As WebResponse
            Dim ReceiveStream As Stream

            req = WebRequestFactory.Create(url)
            sc = new SingleCredential(username, password, Domain)
            req.Credentials = sc
            result = req.GetResponse()
            ReceiveStream = result.GetResponseStream()
            Console.WriteLine()
            Console.WriteLine("Response stream received, Status code: " & result.Status)
            if (bShow) 

                Dim read(512) As Byte
                Dim bytes As Integer
                bytes = ReceiveStream.Read(read, 0, 512)
                Console.WriteLine("HTML...")
                Console.WriteLine()

                Do while (bytes > 0)
                    Console.Write(System.Text.Encoding.ASCII.GetString(read, 0, bytes))
                    bytes = ReceiveStream.Read(read, 0, 512)
                Loop

                Console.WriteLine()
            End If
        End Sub
    End Class
End Namespace

