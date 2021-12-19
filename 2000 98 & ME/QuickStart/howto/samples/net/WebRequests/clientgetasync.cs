using System;
using System.Net;
using System.Threading;
using System.IO;

class ClientGetAsync {

    const int MAX = 20;
    
    public static void Main(string[] args) {

        if (args.Length < 1) {
            showusage();
            return;
        }

        URI HttpSite = new URI(args[0]);
        HttpWebRequest wreq = (HttpWebRequest) WebRequestFactory.Create(HttpSite);
        IAsyncResult r = (IAsyncResult) wreq.BeginGetResponse(new AsyncCallback(RespCallback), null);
        Thread.Sleep(3000);
        Console.WriteLine("Exiting.");
    }

    public static void showusage() {
        Console.WriteLine("Attempts to GET a URL");
        Console.WriteLine("\r\nUsage:");
        Console.WriteLine("ClientGetAsync URL");
        Console.WriteLine("Examples:");
        Console.WriteLine("ClientGetAsync http://www.microsoft.com/net/");
    }

    private static void RespCallback(IAsyncResult ar)
    {
        HttpWebRequest req = (HttpWebRequest) ar.AsyncObject;
        HttpWebResponse resp = (HttpWebResponse) req.EndGetResponse(ar);
        
        int BytesRead = 0;
        char[] Buffer = new char[MAX];

        StreamReader Reader = new StreamReader(resp.GetResponseStream(), System.Text.Encoding.UTF8);
        StringWriter Writer = new StringWriter();
        
        BytesRead = Reader.Read(Buffer, 0, MAX);
        while (BytesRead != 0 ) {
            Writer.Write(Buffer, 0, MAX);
            BytesRead = Reader.Read(Buffer, 0, MAX);
        }
        Console.WriteLine("Message = " + Writer.ToString());
    }
}
