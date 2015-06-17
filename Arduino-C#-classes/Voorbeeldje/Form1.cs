using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;
using System.IO.Ports;

namespace Voorbeeldje
{
    public partial class Form1 : Form
    {

        bool arduinoButton = false;
        /// <summary>
        /// The speed of the serial connection (bytes per second).
        /// TODO: make sure that the speed in the Arduino program is set to the same value!
        /// Note: You can set this to a higher value like 57600 or 115200, 
        /// but data loss is possible then.
        /// </summary>
        private const int connectionSpeed = 9600;

        /// <summary>
        /// Marker to mark the start of a message.
        /// TODO: You can adapt this value to your own needs.
        /// </summary>
        private const String messageBeginMarker = "#";

        /// <summary>
        /// Marker to mark the end of a message.
        /// TODO: You can adapt this value to your own needs.
        /// </summary>
        private const String messageEndMarker = "%";

        /// <summary>
        /// Serial port used for the connection.
        /// </summary>
        private SerialPort serialPort;

        /// <summary>
        /// Buffer that is used to store data (text) that is received from the Arduino.
        /// Messages that a recevied can be retrieved from the messageBuilder.
        /// </summary>
        private MessageBuilder messageBuilder;

        public Form1()
        {
            InitializeComponent();

            serialPort = new SerialPort();
            serialPort.BaudRate = connectionSpeed;
            // Choose: 9600, 19200 or 38400. Getting errors? Choose lower speed.
            // Also be sure that you set the speed on the arduino to the same value!

            messageBuilder = new MessageBuilder(messageBeginMarker, messageEndMarker);
            UpdateUserInterface();

            if (serialPort.IsOpen)
            {
                readMessageTimer.Enabled = false;
                serialPort.Close();
            }
            else
            {
                String port = "COM6";
                try
                {
                    serialPort.PortName = port;
                    serialPort.Open();
                    if (serialPort.IsOpen)
                    {
                        ClearAllMessageData();
                        serialPort.DiscardInBuffer();
                        serialPort.DiscardOutBuffer();
                    }
                    readMessageTimer.Enabled = true;
                }
                catch (Exception exception)
                {
                    MessageBox.Show("Could not connect to the given serial port: " + exception.Message);
                }
            }
        }

        /// <summary>
        /// This method is called when a message is received.
        /// </summary>
        /// <param name="message">The received message</param>
        private void MessageReceived(String message)
        {
            // TODO: Put code here to handle the received message.
            //       The received message is contained in the message parameter.
            // Hints: 
            //  - You can use the String methods to parse the message and (if present) its parameters.
            //    See: http://msdn.microsoft.com/en-us/library/system.string.aspx
            //     for help on available String methods like
            //     - String.StartsWith(...)
            //     - String.Substring(...)
            //     - String.IndexOf(...)
            //     - etc
            //  - Convert.ToInt32(...) can be used to convert strings to an integer.
            //  - Sliders have a 'Value' property which can be used to get/set the position of the slider.
            
            // insert train message handling here
            lblRecv.Text = "Received: " + message;
            if (message.Contains("okr"))
            {
                this.BackColor = System.Drawing.Color.Red;
            }

            if (message.Contains("okb"))
            {
                this.BackColor = System.Drawing.Color.Blue;
            }

            if (message.Contains("okg"))
            {
                this.BackColor = System.Drawing.Color.Green;
            }

            if (message.Contains("off"))
            {
                this.BackColor = System.Drawing.Color.Gray;
            }

            if (message.Contains("button"))
            {
                btnArduino.Enabled = arduinoButton;
                arduinoButton = !arduinoButton;
            }
        }

        /// <summary>
        /// Sends the given message to the serial port.
        /// </summary>
        /// <param name="message">The message to send.</param>
        /// <returns>true if the message was send, false otherwise.</returns>
        private bool SendMessage(String message)
        {
            if (serialPort.IsOpen)
            {
                try
                {
                    serialPort.Write(message);
                    DisplaySendMessage(message);
                    return true;
                }
                catch (Exception exception) // Not very nice to catch Exception...but for now it's good enough.
                {
                    Debug.WriteLine("Could not write to serial port: " + exception.Message);
                }
            }
            return false;
        }

        /// <summary>
        /// Reads data from the serial port and get received messages from that data.
        /// Called on each tick of the messageReceiveTimer.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void messageReceiveTimer_Tick(object sender, EventArgs e)
        {
            if (serialPort.IsOpen
                && serialPort.BytesToRead > 0)
            {
                try
                {
                    String dataFromSocket = serialPort.ReadExisting();
                    DisplayReceivedRawData(dataFromSocket);
                    messageBuilder.Append(dataFromSocket);
                    ProcessMessages();
                }
                catch (Exception exception) // Not very nice to catch Exception...but for now it's good enough.
                {
                    Debug.WriteLine("Could not read from serial port: " + exception.Message);
                }
            }
        }

        /// <summary>
        /// Find and process all buffered messages .
        /// </summary>
        private void ProcessMessages()
        {
            String message = messageBuilder.FindAndRemoveNextMessage();
            while (message != null)
            {
                DisplayReceivedMessage(message);
                MessageReceived(message);
                message = messageBuilder.FindAndRemoveNextMessage();
            }
        }

        /// <summary>
        /// Display a message in the 'received messages' UI box.
        /// </summary>
        /// <param name="message">The message to displayed</param>
        private void DisplayReceivedMessage(String message)
        {
        }

        /// <summary>
        /// Display a message in the 'send messages' UI box.
        /// </summary>
        /// <param name="message">The message to displayed</param>
        private void DisplaySendMessage(String message)
        {
        }

        /// <summary>
        /// Display received raw data in the 'Received raw data' UI box.
        /// </summary>
        /// <param name="data">The data to displayed</param>
        private void DisplayReceivedRawData(String data)
        {
        }

        /// <summary>
        /// Close the serial connection when the form is closed.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ArDangerComMainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            readMessageTimer.Enabled = false;
            if (serialPort.IsOpen)
            {
                serialPort.Close();
            }
        }

        /// <summary>
        /// Clear message data from textboxes and from the messageUnderConstruction buffer.
        /// </summary>
        private void ClearAllMessageData()
        {
            messageBuilder.Clear();
        }

        /// <summary>
        /// Enable / Disable UI widgets depending on the connected state of the serial port.
        /// </summary>
        private void UpdateUserInterface()
        {
        }
        

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (serialPort.IsOpen
                && serialPort.BytesToRead > 0)
            {
                try
                {
                    String dataFromSocket = serialPort.ReadExisting();
                    DisplayReceivedRawData(dataFromSocket);
                    messageBuilder.Append(dataFromSocket);
                    ProcessMessages();
                }
                catch (Exception exception) // Not very nice to catch Exception...but for now it's good enough.
                {
                    Debug.WriteLine("Could not read from serial port: " + exception.Message);
                }
            }
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            string message = messageBeginMarker + tbSend.Text + messageEndMarker;
            SendMessage(message);
        }
    }
}
