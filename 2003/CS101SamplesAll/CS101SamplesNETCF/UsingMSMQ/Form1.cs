using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using System.Messaging; // For MSMQ

namespace UsingMSMQ
{
    public partial class Form1 : Form
    {
        // The name of the Queue on the device we will be sending / receiving messages to
        private const String queName = @".\private$\destq";

        public Form1()
        {
            InitializeComponent();

            MSMQInitializer msmqInit = new MSMQInitializer();
            try
            { 
                // Write the necessary MSMQ files to the windows directory on the device and
                // start the message queue
                MessageBox.Show(msmqInit.Init());
                StatusBar1.Text = String.Empty;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        //  Place a new message in the queue
        private void SendMessage(string msg)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                if (!MessageQueue.Exists(queName))
                {
                    MessageQueue.Create(queName);
                }

                //  Create MessageQueue instance
                MessageQueue mq = new MessageQueue(queName);

                //  Create Message
                Message m = new Message();
                m.Label = ("msg");
                m.Body = msg;

                //  Send Message
                mq.Send(m);
                mq.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }
        }

        //  Receive the next message in the queue
        private string GetNextMessage()
        {
            string msg = String.Empty;
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                if (!MessageQueue.Exists(queName))
                {
                    throw new Exception(("Message Que " + 
                        (queName + " Does Not Exist.  Send a Message to Create")));
                }
                //  Create MessageQueue instance
                MessageQueue mq = new MessageQueue(queName);
                Message m;

                //  Create Formatter for string message
                mq.Formatter = new XmlMessageFormatter(new Type[] {typeof(string)});

                //  Peek at message for 2 seconds
                TimeSpan ts = new TimeSpan(0, 0, 2);
                m = mq.Peek(ts); //  prevent deadlock by checking for only 2 secs
                if (!(m == null))
                {
                    m = mq.Receive(ts); //  prevent deadlock by checking for only 2 secs
                    mq.Close();
                    msg = m.Body.ToString();
                }
                return msg;
            }
            catch (MessageQueueException ex)
            {
                MessageBox.Show(("Queue Empty or Unavailable: " + ex.Message));
                return msg;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return msg;
            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }
        }
        // Send the string in the SendTextBox control as a string message to the queue
        private void SendButton_Click(object sender, EventArgs e)
        {
            StatusBar1.Text = "Sending Message...";
            StatusBar1.Update(); //  Force text to be updated
            SendMessage(SendTextBox.Text);
            SendTextBox.Text = String.Empty;

            //  Clear textbox to show message was sent
            StatusBar1.Text = "Sending Message...Complete";
        }

        // Receive the next message in the queue and place in the ReceivedListBox at the end
        private void ReceiveButton_Click(object sender, EventArgs e)
        {
            StatusBar1.Text = "Receiving Message...";
            StatusBar1.Update(); //  Force text to be updated
            string msg = GetNextMessage();
            StatusBar1.Text = "Receiving Message...Complete";
            if ((msg != String.Empty))
            {
                ReceivedListBox.Items.Add(msg);
            }
        }
    }
}