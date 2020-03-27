using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using System.Windows.Forms;

namespace HttpListenerWebServer
{
    /// The following class demonstrates the HttpListener class and its use of asynchronous
    /// request processing.  As a client connects, a separate thread is created to handle
    /// the AsynchronousListenerCallback method.
    class Program
    {
        // Flag indicating the server should continue processing requests.
        public static bool runServer = true;

        // The UI
        public static Form1 form1;

        // Delegate to allow cross-thread update of UI safely
        private delegate void InvokeControl(string text);

        static HttpListener listener;

        /// Asynchronous HTTP listener.  Instantiates and starts the HttpListener class,
        /// adds the prefix URI's to listen for, and enters the asynchronous processing loop
        /// until the runServer flag is set false.
        /// Param name prefixes is the URI prefix array to which the server responds
        public static void AsynchronousListener(string[] prefixes)
        {
            // spin up listener
            listener = new HttpListener();
            // add URI prefixes to listen for
            foreach (string s in prefixes)
            {
                    listener.Prefixes.Add(s);
            }
            listener.Start();
            // Create the delegate using the method to update the UI
            InvokeControl invokeControl = new InvokeControl(InvokeUIThread);
            form1.listBox1.Invoke(invokeControl, "Entering asynchronous request processing loop");
            
            while (runServer)
            {
                    IAsyncResult result = listener.BeginGetContext(new AsyncCallback(AsynchronousListenerCallback), listener);
                    // intermediate work can go on here while waiting for the asynchronous callback
                    // an asynchronous wait handle is used to prevent this thread from continuing
                    // while waiting for the asynchronous operation to complete.
                    form1.listBox1.Invoke(invokeControl, "Waiting for asyncronous request processing.");
                    result.AsyncWaitHandle.WaitOne();
                    // during the wait, we may have aborted the server and are closing the UI
                    if (runServer)
                    {
                        form1.listBox1.Invoke(invokeControl, "Asynchronous request processed.");
                    }
            }
            // If the runServer flag gets set to false, stop the server and close the listener.
            listener.Close();
        }

        public static void CloseListener() {
            runServer = false;
            listener.Abort();
        }

        /// Method called back when a client connects.  BeginGetContext contains the AsynchCallback delegate
        /// for this method.
        /// param name result is the state object containing the HttpListener instance
        public static void AsynchronousListenerCallback(IAsyncResult result)
        {
            HttpListener listener = (HttpListener)result.AsyncState;
            // Call EndGetContext to signal the completion of the asynchronous operation.
            HttpListenerContext context = null;
            // If we have aborted the server while waiting, catch the exception and terminate
            try
            {
                context = listener.EndGetContext(result);
            }
            catch (ObjectDisposedException)
            {
                Application.Exit();
            }
            HttpListenerRequest request = context.Request;
            // Get the response object to send our confirmation.
            HttpListenerResponse response = context.Response;
            // Construct a minimal response string.
            string responseString = "<HTML><BODY><H1>You have contacted an HttpListener web server</H1></BODY></HTML>";
            byte[] buffer = System.Text.Encoding.UTF8.GetBytes(responseString);
            // Get the response OutputStream and write the response to it.
            response.ContentLength64 = buffer.Length;
            // Identify the content type.
            response.ContentType = "text/html";
            System.IO.Stream output = response.OutputStream;
            output.Write(buffer, 0, buffer.Length);
            // Properly flush and close the output stream
            output.Flush();
            output.Close();
        }

        /// In order to safely update the UI across threads, a delegate with this method is
        /// called using Control.Invoke
        private static void InvokeUIThread(string text)
        {
            form1.listBox1.Items.Add(text);
        }

        static void Main(string[] args)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            form1 = new Form1();
            Application.Run(form1);
        }
    }
}
