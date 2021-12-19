using System;
using System.Net;
using System.IO;

class ClientGET {
    private static bool bShow;
    
    public static void Main(string[] args) {
        
        if (args.Length < 1) {
            showusage();
            return;
        }   
        
        if (args.Length == 2)
            bShow = false;
        else
            bShow = true;
        
        getPage(args[0]);
        
        return;
    }
    
    public static void showusage() {
        Console.WriteLine("Attempts to GET a URL");
        Console.WriteLine("\r\nUsage:");
        Console.WriteLine("ClientGET URL");
        Console.WriteLine("Examples:");
        Console.WriteLine("ClientGET http://www.microsoft.com/net/");
    }
    
    public static void getPage(String url) {
        WebRequest req = WebRequestFactory.Create(url);
        WebResponse result = req.GetResponse();
        Stream ReceiveStream = result.GetResponseStream();
        Console.WriteLine("\r\nResponse stream received, Status code: " + result.Status);
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
            
            Console.WriteLine("");
        }
    }
};
