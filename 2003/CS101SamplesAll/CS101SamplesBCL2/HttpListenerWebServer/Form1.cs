using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace HttpListenerWebServer
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// Once the form is loaded, start a thread to spin up HttpListener
        /// We need to run a separate thread to co-exist with windows forms
        private void Form1_Load(object sender, EventArgs e)
        {
            // Create the listener and direct it to localhost requests on port 8080
            Thread t = new Thread(new ThreadStart(Start));
            t.Start();
        }
        // Thread method to create the listener and direct it to localhost requests on port 8080
        private void Start()
        {
            Program.AsynchronousListener(new string[] { "http://localhost:8080/" });
        }

        /// 
        /// Direct the server to stop processing and exit the app
        /// 
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            Program.CloseListener();
        }

    }
}