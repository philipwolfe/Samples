using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO.Ports;
 
namespace UsingTheSerialPort
{
    /// The serial port component can be found in the designer.  The following form will
    /// modify properties of the port in real-time.
    partial class Form1 : Form
    {
        Array stopBits, parity; // arrays to access the enumerations in System.IO.Ports
        ArrayList validStopBits = new ArrayList(); // ArrayLists hold the valid values for this machine
        ArrayList validParity = new ArrayList();

        public Form1()
        {
            InitializeComponent();
        }
         
        /// Send the text in the text box to the serial port.
        /// The data should stay in the buffer until received by the event handler.
        private void SendButton_Click(object sender, EventArgs e)
        {
            try
            {
                // Write a line to the serial port
                serialPort1.WriteLine(textBox1.Text);
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
 
        /// Event handler for data reception
        private void serialPort_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            // Read the buffer to the text box.
            textBox2.Text = serialPort1.ReadLine();
        }

        /// Load the form and set up parameters from the default serial port.
        /// Open the port and prepare it for IO.
        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                // Open the serial port
                serialPort1.Open();
                // Set the event handler for data reception
                serialPort1.DataReceived += new SerialDataReceivedEventHandler(serialPort_DataReceived);
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message);
            } 
            label11.Text = serialPort1.PortName;

            label2.Text = serialPort1.BaudRate.ToString();
            label4.Text = serialPort1.StopBits.ToString();
            label6.Text = serialPort1.Parity.ToString();
            label8.Text = serialPort1.DataBits.ToString();
            label10.Text = serialPort1.RtsEnable.ToString();

            // Populate the stop bits box with all valid options.
            // Note that the serial port must be open to accurately test the options.
            comboBox1.SelectedText = serialPort1.StopBits.ToString();
            System.IO.Ports.StopBits currentStopBitSetting = serialPort1.StopBits;
            
            stopBits = Enum.GetValues(typeof(System.IO.Ports.StopBits));
            foreach (System.IO.Ports.StopBits sbtype in stopBits)
            {
                // test to make sure the machine supports the setting
                try
                {
                    serialPort1.StopBits = sbtype;
                    validStopBits.Add(sbtype);
                    comboBox1.Items.Add(sbtype);
                }
                catch (Exception) { } // ignore this entry as invalid
            }
            serialPort1.StopBits = currentStopBitSetting;

            // Populate the parity with valid options
            comboBox2.SelectedText = serialPort1.Parity.ToString();
            System.IO.Ports.Parity currentParitySetting = serialPort1.Parity;
            parity = Enum.GetValues(typeof(System.IO.Ports.Parity));
            foreach (System.IO.Ports.Parity ptype in parity)
            {
                // test to make sure the machine supports the setting
                try
                {
                    serialPort1.Parity = ptype;
                    validParity.Add(ptype);
                    comboBox2.Items.Add(ptype);
                }
                catch (Exception) { } // ignore this entry
            }

  
        }
  
        /// Respond to the form closing event by closing the SerialPort instance. 
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            serialPort1.Close();
        }

        /// The following methods demonstrate the ability to set parameters of the serial port
        /// through the SerialPort instance.  The baud rate of the port will be set in response to
        /// the corresponding button clicks.

        private void button3_Click(object sender, EventArgs e)
        {
            serialPort1.BaudRate = 1200;
            label2.Text = serialPort1.BaudRate.ToString();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            serialPort1.BaudRate = 4800;
            label2.Text = serialPort1.BaudRate.ToString();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            serialPort1.BaudRate = 9600;
            label2.Text = serialPort1.BaudRate.ToString();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            serialPort1.StopBits = (System.IO.Ports.StopBits)validStopBits[comboBox1.SelectedIndex];
            label4.Text = serialPort1.StopBits.ToString();
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            serialPort1.Parity = (System.IO.Ports.Parity)validParity[comboBox2.SelectedIndex];
            label6.Text = serialPort1.Parity.ToString();
        }
    }
}