using System;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Text;

public class Chat {

    private static UDPClient m_Client;

    private static int ListenerPort = 8080;
    private static int SenderPort = 8080;
    private static int LocalPort;
    private static int RemotePort;

    private static string m_szHostName;

    private static IPAddress m_GroupAddress;
    private static IPHostEntry m_LocalHost;
    private static IPEndPoint m_RemoteEP;

    private static bool m_Done = false;

    public static void Usage() {
        Console.WriteLine("UDP Multicast Chat Utility");
        Console.WriteLine("\nUsage:");
        Console.WriteLine("chat.exe");
    }

    public static void Main( String [] args ) {

        LocalPort = SenderPort;
        RemotePort = ListenerPort;

        if( args.Length > 0 ) {
            //
            // print help message, as this utility doesnt take any arguments
            //
            Usage();
            return;
        }

        m_szHostName = DNS.GetHostName();

        m_LocalHost = DNS.GetHostByName(m_szHostName);

        Console.WriteLine("Local Port: {0}, Remote: {1}", LocalPort, RemotePort);

        Console.WriteLine("Initializing...");

        Initialize();

        Console.WriteLine("Starting Listener thread...");

        Thread t = new Thread(new ThreadStart(Listener));
        t.Start();

        Byte [] buffer = null;

        Encoding ASCII = Encoding.ASCII;

        bool m_ShuttingDown = false;

        while(!m_ShuttingDown) {
            String s = Console.ReadLine();

            if( s.Length == 0 )
                continue;
            
            if(String.Compare(s,0,"@",0,1) == 0) {
                m_Done = true;
                //
                // send a terminator to ourselves,
                // so that the receiving thread can shut down
                //
                s = m_szHostName + ":@";
                m_ShuttingDown = true;
            } else {
                s = m_szHostName + ":" + s;
            }
            
            
            buffer = new Byte[s.Length + 1];
            //
            // send data to remote peer
            //
            
            int len = ASCII.GetBytes( s.ToCharArray(), 0, s.Length, buffer, 0);
            
            /*
	    THE FOLLOWING CAN BE USED FOR DEBUGGING
            int len = 0;
            for( int i = 0; i < s.Length; i++ ) {
            buffer[i] = (Byte) s[i];
            ++len;
            }
            */
            
            //Console.WriteLine("Read: " + s + ", Raw length = " + len);
            
            int ecode = 
                m_Client.Send(
                buffer,
                len,
                m_RemoteEP);
            
            if(ecode <= 0) {
                Console.WriteLine("Error in send : " + ecode);
            }
            
        }
        
        t.Stop();
        t.Join();
        
        Console.WriteLine("Closing connection...");
        
        Terminate();
        
    } // Main
    
    public static void Terminate() {
        m_Client.DropMulticastGroup(m_GroupAddress);
    }
    
    public static void Initialize() {
        
        //
        // instantiate UDPCLient
        //
        m_Client = new UDPClient(LocalPort);
        
        //
        // Create an object for Multicast Group
        //

        m_GroupAddress = new IPAddress("224.0.0.1");
        //m_GroupAddress = m_LocalHost.AddressList[0];
        
        //
        // Join Group
        //
        if(!m_Client.JoinMulticastGroup(m_GroupAddress)) {
            Console.WriteLine("Unable to join multicast group");
        }
        
        //
        // Create Endpoint for peer
        //
        m_RemoteEP = new IPEndPoint( m_GroupAddress, RemotePort );
        
    }
    
    public static void Listener() {
        
        //
        // The listener waits for data to come
        // and buffers it
        
        Thread.Sleep(2000); // make sure client2 is receiving
        
        Encoding    ASCII = Encoding.ASCII;        
        
        while(!m_Done) {
            IPEndPoint endpoint = null;
            Byte[] data = m_Client.Receive(ref endpoint);
            
            //Console.WriteLine("Raw data length: " + data.Length );
            String strData = ASCII.GetString(data);
            //Console.WriteLine("Received: [" + strData + "] Length: " + strData.Length);
            
            if( strData.IndexOf(":@") > 0 ) {
                //
                // we received a termination indication
                // now we have to decide if it is from
                // our main thread shutting down, or
                // from someone else
                //
                Char [] separators = {':'};
                String [] vars = strData.Split(separators);
                
                if( vars[0] == m_szHostName ) {
                    //
                    // this is from ourselves, therefore we
                    // end now
                    //
                    Console.WriteLine("shutting down Listener thread...");
                    
                    //
                    // this should have been done by main thread, but we
                    // do it again for safety
                    //
                    m_Done = true;
                }
                else {
                    //
                    // this is from someone else
                    //
                    Console.WriteLine("{0} has left the conversation", vars[0]);
                }
            }
            else {
                //
                // this is normal data received from others
                // as well as ourselves
                // check to see if it is from ourselves before
                // we print
                //
                if(strData.IndexOf(":") > 0) {
                    Char [] separators = {':'};
                    String [] vars = strData.Split(separators);
                    
                    if( vars[0] != m_szHostName ) {
                        Console.WriteLine(strData);
                    }
                }
            }
        }
        
        Console.WriteLine("Listener thread finished...");
        return;
    }
}
