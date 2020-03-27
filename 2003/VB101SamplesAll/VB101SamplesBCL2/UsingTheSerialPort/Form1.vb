
Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Data
Imports System.Drawing
Imports System.Text
Imports System.Windows.Forms
Imports System.IO.Ports
 _

Class Form1
    Inherits Form
  

    Public Sub New()
        InitializeComponent()
    End Sub 'New

    Private stopBits, parity As Array ' arrays to access the enumerations in System.IO.Ports
    Private validStopBits As New ArrayList() ' ArrayLists hold the valid values for this machine
    Private validParity As New ArrayList()


    ' Send the text in the text box to the serial port.
    ' The data should stay in the buffer until received by the event handler.
    Private Sub SendButton_Click(ByVal sender As Object, ByVal e As EventArgs) Handles Button1.Click
        Try
            ' Write a line to the serial port
            SerialPort1.WriteLine(textBox1.Text)
        Catch ex As System.Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub 'SendButton_Click


    ' Event handler for data reception
    Private Sub serialPort_DataReceived(ByVal sender As Object, ByVal e As SerialDataReceivedEventArgs)
        ' Read the buffer to the text box.
        textBox2.Text = serialPort1.ReadLine()
    End Sub 'serialPort_DataReceived


    ' Load the form and set up parameters from the default serial port.
    ' Open the port and prepare it for IO.
    Private Sub Form1_Load(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Load
        Try
            ' Open the serial port
            SerialPort1.Open()
            ' Set the event handler for data reception
            AddHandler SerialPort1.DataReceived, AddressOf serialPort_DataReceived
        Catch ex As System.Exception
            MessageBox.Show(ex.Message)
        End Try
        label11.Text = SerialPort1.PortName

        label2.Text = SerialPort1.BaudRate.ToString()
        label4.Text = SerialPort1.StopBits.ToString()
        label6.Text = SerialPort1.Parity.ToString()
        label8.Text = SerialPort1.DataBits.ToString()
        label10.Text = SerialPort1.RtsEnable.ToString()

        ' Populate the stop bits box with all valid options.
        ' Note that the serial port must be open to accurately test the options.
        comboBox1.SelectedText = SerialPort1.StopBits.ToString()
        Dim currentStopBitSetting As System.IO.Ports.StopBits = SerialPort1.StopBits

        stopBits = [Enum].GetValues(GetType(System.IO.Ports.StopBits))
        Dim sbtype As System.IO.Ports.StopBits
        For Each sbtype In stopBits
            ' test to make sure the machine supports the setting
            Try
                SerialPort1.StopBits = sbtype
                validStopBits.Add(sbtype)
                comboBox1.Items.Add(sbtype)
            Catch ' ignore this entry as invalid
            End Try
        Next sbtype
        SerialPort1.StopBits = currentStopBitSetting

        ' Populate the parity with valid options
        comboBox2.SelectedText = SerialPort1.Parity.ToString()
        Dim currentParitySetting As System.IO.Ports.Parity = SerialPort1.Parity
        parity = [Enum].GetValues(GetType(System.IO.Ports.Parity))
        Dim ptype As System.IO.Ports.Parity
        For Each ptype In parity
            ' test to make sure the machine supports the setting
            Try
                SerialPort1.Parity = ptype
                validParity.Add(ptype)
                comboBox2.Items.Add(ptype)
            Catch ' ignore this entry
            End Try
        Next ptype
    End Sub 'Form1_Load


    ' Respond to the form closing event by closing the SerialPort instance. 
    Private Sub Form1_FormClosing(ByVal sender As Object, ByVal e As FormClosingEventArgs)
        serialPort1.Close()
    End Sub 'Form1_FormClosing


    ' The following methods demonstrate the ability to set parameters of the serial port
    ' through the SerialPort instance.  The baud rate of the port will be set in response to
    ' the corresponding button clicks.
    Private Sub button3_Click(ByVal sender As Object, ByVal e As EventArgs) Handles Button3.Click
        serialPort1.BaudRate = 1200
        label2.Text = serialPort1.BaudRate.ToString()
    End Sub 'button3_Click


    Private Sub button4_Click(ByVal sender As Object, ByVal e As EventArgs) Handles Button4.Click
        SerialPort1.BaudRate = 4800
        label2.Text = SerialPort1.BaudRate.ToString()
    End Sub 'button4_Click


    Private Sub button5_Click(ByVal sender As Object, ByVal e As EventArgs) Handles Button5.Click
        serialPort1.BaudRate = 9600
        label2.Text = serialPort1.BaudRate.ToString()
    End Sub 'button5_Click


    Private Sub comboBox1_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles comboBox1.SelectedIndexChanged
        serialPort1.StopBits = CType(validStopBits(comboBox1.SelectedIndex), System.IO.Ports.StopBits)
        label4.Text = serialPort1.StopBits.ToString()
    End Sub 'comboBox1_SelectedIndexChanged


    Private Sub comboBox2_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles comboBox2.SelectedIndexChanged
        serialPort1.Parity = CType(validParity(comboBox2.SelectedIndex), System.IO.Ports.Parity)
        label6.Text = serialPort1.Parity.ToString()
    End Sub 'comboBox2_SelectedIndexChanged

End Class 'Form1 
