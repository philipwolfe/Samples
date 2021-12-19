using System;
using System.Net;
using System.IO;

class ClientGETwithNTLM {
    private static bool bShow;
    
    public static void Main(string[] args) {

        if (args.Length < 4) {
            showusage();
            return;
        }

        if (args.Length > 4)
            bShow = false;
        else
            bShow = true;

        getPage(args[0], args[1], args[2], args[3]);

        return;
    }

    public static void showusage() {
        Console.WriteLine("Attempts to GET a URL with NTLM authentication");
        Console.WriteLine("\r\nUsage:");
        Console.WriteLine("ClientGETwithNTLM URL username password domain");
        Console.WriteLine("Examples:");
        Console.WriteLine("ClientGETwithNTLM http://www.microsoft.com/net/ Bobby BobbyLovesMangos THEDOMAIN");
    }
    
    public static void getPage(String url, String username, String password, String Domain) {
        WebRequest req = WebRequestFactory.Create(url);
        SingleCredential sc = new SingleCredential(username, password, Domain);
        req.Credentials = sc;
        WebResponse result = req.GetResponse();
        Stream ReceiveStream = result.GetResponseStream();
        Console.WriteLine("Response stream received, Status code: " + result.Status);
        if (bShow) 
        {
            Byte[] read = new Byte[512];
            int bytes = ReceiveStream.Read(read, 0, 512);

            Console.WriteLine("HTML...\r\n");
        
            while (bytes > 0) 
            {
                Console.Write(System.Text.Encoding.ASCII.GetString(read, 0, bytes));
                bytes = ReceiveStream.Read(read, 0, 512);
            }

            Console.WriteLine();
        }
    }
};
