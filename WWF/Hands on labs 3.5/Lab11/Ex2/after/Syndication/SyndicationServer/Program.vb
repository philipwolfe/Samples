Imports System.ServiceModel
Imports System.ServiceModel.Description
Imports System.ServiceModel.Syndication
Imports System.ServiceModel.Web


Module Program

    Sub Main()

        Dim endPoint As String = "http://localhost:8899/"
        Using host As New WebServiceHost(GetType(PublishSystemInfo), _
            New Uri(endPoint))
            Dim atomEP As ServiceEndpoint = _
                host.AddServiceEndpoint(GetType(IPublishSystemInfo), _
                New WebHttpBinding(), "")

            host.Open()

            Console.BackgroundColor = ConsoleColor.Black
            Console.ForegroundColor = ConsoleColor.White
            Console.WriteLine("Service is ready.")
            Console.ForegroundColor = ConsoleColor.Yellow

            Dim strMsg As String = "Navigate using IE7 to " & _
                "http://localhost:8899/sysinfo/atom/ for the Atom feed."
            Console.WriteLine(strMsg)
            Console.ForegroundColor = ConsoleColor.Green
            strMsg = "Navigate using IE7 to " & _
                  "http://localhost:8899/sysinfo/rss/ for the RSS feed."
            Console.WriteLine(strMsg)
            Console.ForegroundColor = ConsoleColor.White
            Console.WriteLine("Press ENTER to close.")
            Console.ReadLine()
        End Using





    End Sub

End Module
