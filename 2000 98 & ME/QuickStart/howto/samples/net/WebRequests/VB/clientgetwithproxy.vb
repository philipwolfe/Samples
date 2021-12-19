Imports System
Imports System.Net
Imports System.IO

Namespace Client
    Public class ClientGETproxy

        Public Shared bShow As Boolean
        Public Shared Sub Main()
            Dim args As String ()
            args = Environment.GetCommandLineArgs()

            If (args.Length < 3)
                showusage()
                return
            End If

            if (args.Length > 3)
                bShow = false
            Else
                bShow = true
            End If
            
            getPage(args(1), args(2))
            return
        End Sub

        public Shared Sub showusage()
            Console.WriteLine("Attempts to GET a URL")
            Console.WriteLine()
            Console.WriteLine("Usage:")
            Console.WriteLine("ClientGETwithProxy URL proxyname")
            Console.WriteLine("Examples:")
            Console.WriteLine("ClientGETwithProxy http://www.microsoft.com/net/ myproxy")
        End Sub

        public Shared Sub getPage(url As String, proxy as String)
            Dim proxyObject as DefaultControlObject
            Dim req As WebRequest
            Dim result As WebResponse
            Dim ReceiveStream As Stream

            proxyObject = new DefaultControlObject(proxy, 80)

            ' Disable Proxy use when the host is local i.e. without periods.
            proxyObject.ProxyNoLocal = true

            ' Now actually take over the global with our new settings, all new requests 
            ' use this proxy info
            GlobalProxySelection.Select = proxyObject
            
            req = WebRequestFactory.Create(url)
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

