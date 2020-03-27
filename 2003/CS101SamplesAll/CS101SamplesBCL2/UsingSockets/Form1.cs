using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Threading;

namespace UsingSockets
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Program.runThreads = false;
            Application.Exit();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Generate the threads to start the work
            Thread[] threads = new Thread[Program.NUMBER_WORKER_THREADS];
            for (int count = 1; count < threads.Length; count++)
            {
                threads[count] = new Thread(new ThreadStart(Program.Search));
                threads[count].Start();
            }       

        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            Program.runThreads = false;
        }
    }
}