
using System;
using System.Net;
using System.IO;
using System.Text;

public class ClientWebException
{
    public static void Main(string[] args) 
    {
        int length = 1024;
        char [] Buffer = new char[1025];
        int bytesread = 0;
        bool ResolvedURI = false;
        String UriToResolve = null;

        while ( !ResolvedURI )
        {
            try
            {
                //Get a uri from the user
                Console.Write("Please enter the uri to resolve: ");
                UriToResolve = Console.ReadLine();
                Console.WriteLine();

                //Create the request object
                WebRequest request = WebRequestFactory.Create(UriToResolve);

                request.Credentials = new SingleCredential("invaliduser", "invalidpassword");

                //Create the response object
                WebResponse response = request.GetResponse();

                Console.WriteLine(response.Status);

                //Successfully resolved the URI
                ResolvedURI = true;

                //Get a readable stream from the server 
                StreamReader sr = new StreamReader(response.GetResponseStream(), Encoding.ASCII);

                //Read from the stream and write any data to the console
                bytesread = sr.Read( Buffer, 0, length);
                while( bytesread > 0 )
                {
                    Console.Write( Buffer,0, bytesread);
                    bytesread = sr.Read( Buffer, 0, length);
                }
            }
            catch (WebException WebExcp)
            {
                // If you get to this point, the exception has been caught
                Console.WriteLine("A WebException has been caught!");

                // Write out the Exception message
                Console.WriteLine(WebExcp.ToString());

                // Get the WebException status code
                int st = Convert.ToInt32(WebExcp.Status); 
                if (st == 7) // 7 indicates a protocol error, thus a WebResonse object should exist
                {
                    // Write out the WebResponse protocol status
                    Console.Write("The protocol error returned by the server is ");
                    Console.WriteLine(WebExcp.Response.Status);
                    Console.WriteLine();
                }
            }
            catch (URIFormatException UriExcp)
            {
                // If you get to this point, the exception has been caught
                Console.WriteLine("A URIFormatException has been caught!");

                // Write out the Exception message
                Console.WriteLine(UriExcp.ToString());
            }
        }

    }
}
