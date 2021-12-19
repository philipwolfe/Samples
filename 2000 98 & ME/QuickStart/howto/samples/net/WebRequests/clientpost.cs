
using System;
using System.Net;
using System.IO;

class ClientPOST {
    public static void Main(string[] args) {

        if (args.Length < 1) {
            showusage();     
            return;
        }   

        getPage(args[0], "s1=food&s2=bart");        

        return;
    }

    public static void showusage() {
        Console.WriteLine("Attempts to POST into to a URL");
        Console.WriteLine("\r\nUsage:");
        Console.WriteLine("\r\nClientPOST URL");
        Console.WriteLine("\r\nExamples:");
        Console.WriteLine("\r\nClientPOST http://www.microsoft.com");
    }
    
    public static void getPage(String url, String payload) {
        WebRequest req = WebRequestFactory.Create(url);
		req.Method = "POST";                            
        req.ContentType = "application/x-www-form-urlencoded";
        byte[] SomeBytes = null;
        if (payload != null) {
        	SomeBytes = System.Text.Encoding.ASCII.GetBytes(payload);
        	req.ContentLength = SomeBytes.Length;
            Stream newStream = req.GetRequestStream();                                
        	newStream.Write(SomeBytes, 0, SomeBytes.Length);
        	newStream.Close();
        }
        else
        {
        	req.ContentLength = 0;
        }
		WebResponse result = req.GetResponse();
        Stream ReceiveStream = result.GetResponseStream();                
        Console.Write("\nResponse stream received, Status code: " + result.Status);

      	Byte[] read = new Byte[512];
      	int bytes = ReceiveStream.Read(read, 0, 512);

      	Console.WriteLine("\r\nHTML...\r\n");
      
      	while (bytes > 0) 
      	{
          	Console.Write(System.Text.Encoding.ASCII.GetString(read, 0, bytes));
         		bytes = ReceiveStream.Read(read, 0, 512);
      	}

      	Console.WriteLine("");
    }    
};
