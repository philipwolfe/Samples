using System;
using System.Collections;
using System.Text;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Windows.Forms;
using System.Threading;

namespace UsingSockets
{
 
    /// The .NET 2.0 socket enhancements include an asynchronous Connect method and a Disconnect method
    /// to allow a socket to be re-used without the overhead of creating a new socket.  The following example uses these
    /// new features to create a socket pool to allow worker threads to rapidly search URL's and retrieve
    /// their home page content.  The new features go hand-in-hand as a disconnected socket can only
    /// be re-used by issuing an asynchronous connect.
    class Program
    {
   
        /// Total number of sockets in the pool
        private const int SOCKET_POOL_SIZE = 10;

        /// Total number of worker threads
        public const int NUMBER_WORKER_THREADS = 3;

        /// Flag to continue thread run
        public static bool runThreads = true;

        /// Index into URL list, incremented be each thread
        private static int currentURLCounter = 0;
        
        private static ArrayList socketPool = new ArrayList(SOCKET_POOL_SIZE);
        private static ArrayList urlList = new ArrayList();

        // The UI
        private static Form1 form1;

        // Delegate to allow cross-thread update of UI safely
        private delegate void InvokeControl(string text);
        private static InvokeControl invokeControl;

        /// Spins up a number of sockets to send data via TCP
        /// socketPool is the ArrayList to be populated with Socket objects
        private static void SpinUpSocketPool(ArrayList socketPool)
        {
            for (int i = 0; i < SOCKET_POOL_SIZE; i++)
                socketPool.Add(new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp));
        }
        /// Create a list of URL's by appending a counter to the searchURL
        /// pointing at a handy list of known sequential URL's
        private static void CreateURLList()
        {
            for (int i = 1; i <= 100; i++)
            {
                urlList.Add("http://www.a" + i.ToString() + ".com");
            }
        }

        /// Thread event notifier for asynchronous connects
        public static ManualResetEvent allDone = new ManualResetEvent(false);

        /// .NET 2.0 callback that handles the completion of the prior asynchronous 
        /// connect call. The socket is passed contained in the IAsyncResult param via 
        /// the last paramater of Socket.BeginConnect().
        /// ar is the state-containing object
        public static void ConnectCallback(IAsyncResult ar)
        {
            allDone.Set();
            Socket s = (Socket)ar.AsyncState;
            try
            {
                s.EndConnect(ar);
            }
            catch (Exception)
            {
                UpdateText("Connect exception in callback");
                // Host may be unknown
            }
        }
        /// Lock the socket pool and find a non-connected socket, then connect it.
        /// server is The address to connect the socket to
        /// returns the connected socket
        private static Socket ConnectSocket(string server)
        {
            Socket s = null;
            // Get host related information.
            UpdateText("Trying " + server);
            while (runThreads)
            {
                lock (socketPool)
                {
                    for (int i = 0; i < SOCKET_POOL_SIZE; i++)
                    {
                        s = (Socket)socketPool[i];
                        if (!s.Connected)
                        {
                            allDone.Reset();
                            try
                            {
                                s.BeginConnect(server, 80, new AsyncCallback(ConnectCallback), s);
                            }
                            catch (Exception)
                            {
                                // possible unknown host
                                return s;
                            }
                            // wait here until the connect finishes.  The callback 
                            // sets allDone.
                            allDone.WaitOne();
                            return s;
                        }
                    }
                    UpdateText("Out of Sockets!, waiting...");
                    Monitor.Wait(socketPool);
                    UpdateText("Socket added to pool, trying recycled socket");
                }
            }
            return null;
        }

        /// Request the home page content for the specified server.
        /// server is the address from which to retrieve data
        private static void SocketSendReceive(string server)
        {
            string request = "GET / HTTP/1.1\r\nHost: " + server + "\r\nConnection: Close\r\n\r\n";
            Byte[] bytesSent = Encoding.ASCII.GetBytes(request);
            Byte[] bytesReceived = new Byte[256];

            // Create a socket connection asynchronously with the specified server and port.
            Socket s = ConnectSocket(server);

            if (s == null || !s.Connected)
            {
                UpdateText("Failed to connect socket to "+server);
                return;
            }
            UpdateText("Socket Connected to "+server);
            // Send request to the server.
            s.Send(bytesSent, bytesSent.Length, 0);

            // Receive the server home page content.
            int bytes = 0;
            string page = "";

            // The following will block until the page contents are retrieved
            do
            {
                bytes = s.Receive(bytesReceived, bytesReceived.Length, 0);
                page = page + Encoding.ASCII.GetString(bytesReceived, 0, bytes);
            }
            while (bytes > 0);

            // Use the .NET 2.0 Disconnect method to place the socket back in circulation
            s.Shutdown(SocketShutdown.Both);
            s.Disconnect(true); // boolean true as argument allows socket reuse

            // Notify any waiter on the socket pool that a socket has become available
            lock (socketPool)
            {
                Monitor.Pulse(socketPool);
            }

           UpdateText("Retrieved "+page.Length+" bytes from "  + server);
        }

        /// Per-thread method to take next URL from list, incrementing the index into
        /// the URL list.
        public static void Search()
        {
            string url = null;
            while (runThreads)
            {
                lock (urlList)
                {
                    if (currentURLCounter == urlList.Count)
                        return;
                    url = (String)urlList[currentURLCounter++];
                }
                SocketSendReceive(url);
            }
        }

        /// In order to safely update the UI across threads, a delegate with this method is
        /// called using Control.Invoke
        private static void InvokeUIThread(string text)
        {
            form1.listBox1.Items.Add(text);
        }

        private static void UpdateText(string text)
        {
            try
            {
                form1.listBox1.Invoke(invokeControl, text);
            }
            catch (Exception) { }
        }
        /// Create the list of URL's, spin up the socket pool, and start the form which creates
        /// the threads to do the work.
        public static void Main(string[] args)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            form1 = new Form1();

            // Create the delegate using the method to update the UI
            invokeControl = new InvokeControl(InvokeUIThread);

            // Create the URL list
            CreateURLList();
            // Create the socket pool
            SpinUpSocketPool(socketPool);
 
            Application.Run(form1);
        }
    }
}
