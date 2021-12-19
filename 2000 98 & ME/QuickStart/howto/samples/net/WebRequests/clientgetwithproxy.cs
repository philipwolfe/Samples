using System;
using System.Net;
using System.IO;

class ClientGETwithProxy {
    private static bool bShow;
    
    public static void Main(string[] args) {

        if (args.Length < 2) {
            showusage();
            return;
        }   

        if (args.Length > 2)
            bShow = false;
        else
            bShow = true;

        getPage(args[0], args[1]);

        return;
    }

    public static void showusage() {
        Console.WriteLine("Attempts to GET a URL with a proxy");
        Console.WriteLine("\r\nUsage:");
        Console.WriteLine("ClientGETwithProxy URL proxyname");
        Console.WriteLine("Examples:");
        Console.WriteLine("ClientGETwithProxy http://www.microsoft.com/net/ myproxy");
    }
    
    public static void getPage(string url, string proxy) {
        DefaultControlObject proxyObject = new DefaultControlObject(proxy, 80); 

        // Disable Proxy use when the host is local i.e. without periods.
        proxyObject.ProxyNoLocal = true;
 
        // Now actually take over the global with our new settings, all new requests 
        // use this proxy info
        GlobalProxySelection.Select = proxyObject;
    
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
