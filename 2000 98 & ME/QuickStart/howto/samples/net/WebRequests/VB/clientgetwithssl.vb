Imports System
Imports System.Net
Imports System.IO

Namespace Client
    Public class ClientGETssl

        Public Shared bShow As Boolean
        Public Shared Sub Main()
        
            Dim args As String ()
            args = Environment.GetCommandLineArgs()

            If (args.Length < 2)
                showusage()
                return
            End If

            if (args.Length > 2)
                bShow = false
            Else
                bShow = true
            End If

            getPage(args(1))
            return
            
        End Sub

        public Shared Sub showusage()
            Console.WriteLine("Attempts to GET a URL")
            Console.WriteLine()
            Console.WriteLine("Usage:")
            Console.WriteLine("ClientGETwithssl URL")
            Console.WriteLine("Examples:")
            Console.WriteLine("ClientGETwithssl https://www.microsoft.com/net/")
        End Sub

        public Shared Sub getPage(url As String)

            Dim req As WebRequest
            Dim result As WebResponse
            Dim ReceiveStream As Stream
            req = WebRequestFactory.Create(url)
            result = req.GetResponse()
            ReceiveStream = result.GetResponseStream()
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

