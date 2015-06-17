using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO.Ports;
using System.Diagnostics;

namespace ClientUCook
{
    public partial class TimeLineClient : Form
    {
        //Arduino connection
        private const int connectionSpeed = 9600;
        private const string messageBeginMarker = "#";
        private const string messageEndMarker = "%";
        private SerialPort serialPort;
        private MessageBuilder messageBuilder;

        //Current timeline
        private uCookContract.TimeLine timeLine = null;
        private uCookContract.TimeSlot currentTimeSlot = null;
        private uCookContract.TimeSlot nextTimeSlot = null;

        //minute counter
        private int timePassed = 0;

        //available appliances
        List<uCookContract.Appliances> availableAppliances = null;

        public TimeLineClient(uCookContract.Recipe recipe)
        {
            InitializeComponent();
            timeLine = recipe.timeLine;

            serialPort = new SerialPort();

            initPorts();

            updateSlots(false);
        }

        //////////////////////
        //init ports
        //////////////////////
        private void initPorts()
        {
            //arduino connection init            
            serialPort.BaudRate = connectionSpeed;
            messageBuilder = new MessageBuilder(messageBeginMarker, messageEndMarker);

            //opening port
            if (serialPort.IsOpen)
            {
                readMessageTimer.Enabled = false;
                serialPort.Close();
            }
            else
            {
                String port = "COM5";
                try
                {
                    serialPort.PortName = port;
                    serialPort.Open();
                    if (serialPort.IsOpen)
                    {
                        messageBuilder.Clear();
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

        //////////////////////
        //methods
        //////////////////////
        private bool updateSlots(bool next)
        {
            bool success = true;

            if(next)
            {
                timeLine.nextSlot();
            }
            
            //check for out of range exception
            if(timeLine.currentSlot < timeLine.ammountTimeSlots)
            {
                currentTimeSlot = timeLine.timeLine[timeLine.currentSlot];
                tbCurrent.Text = currentTimeSlot.action;

                if(currentTimeSlot.duration != 0)
                {
                    tbDuration.Text = currentTimeSlot.duration.ToString();
                    durationTimer.Enabled = true;
                }
                else
                {
                    tbDuration.Text = "waiting for confirmation";
                }
            }
            else
            {
                currentTimeSlot = null;
                tbCurrent.Text = "no action required.";
            }

            //check for out of range exception
            if (timeLine.currentSlot + 1 < timeLine.ammountTimeSlots)
            {
                nextTimeSlot = timeLine.timeLine[timeLine.currentSlot + 1];
                tbNext.Text = nextTimeSlot.action;
            }
            else
            {
                nextTimeSlot = null;
                tbNext.Text = "no action required.";
                success = false;
            }

            //send to Arduino
            if(currentTimeSlot != null)
            {
                sendActionsToMaster();
            }

            return success;
        }

        private void resetGP()
        {
            SendMessage(messageBeginMarker + "1GP:P1-" + messageEndMarker);
            SendMessage(messageBeginMarker + "1GP:P2-" + messageEndMarker);
            SendMessage(messageBeginMarker + "1GP:P3-" + messageEndMarker);
            SendMessage(messageBeginMarker + "1GP:P4-" + messageEndMarker);
        }

        private void sendActionsToMaster()
        {
            switch (currentTimeSlot.appliance)
            {
                case uCookContract.Appliances.none:     //TODO: turn of seperate appliances
                    resetGP();
                    break;
                case uCookContract.Appliances.uCook_Kookpan:
                    SendMessage(messageBeginMarker + "1GP:P1+" + messageEndMarker);
                    break;
                case uCookContract.Appliances.uCook_Braadpan:
                    SendMessage(messageBeginMarker + "1GP:P2+" + messageEndMarker);
                    break;
                case uCookContract.Appliances.uCook_Wokpan:
                    SendMessage(messageBeginMarker + "1GP:P3+" + messageEndMarker);
                    break;
                case uCookContract.Appliances.uCook_Grillpan:
                    SendMessage(messageBeginMarker + "1GP:P4+" + messageEndMarker);
                    break;
                case uCookContract.Appliances.uCook_Waterkoker:
                    SendMessage(messageBeginMarker + "2WK:ON+" + messageEndMarker);
                    break;
            }           
        }

        private void requestAppliances()
        {
            SendMessage(messageBeginMarker + "UPDATE" + messageEndMarker);
        }

        //////////////////////
        //button handling
        /////////////////////
        private void btnNext_Click(object sender, EventArgs e)
        {
            if(btnNext.Text == "Next")
            {
                if (!updateSlots(true))
                {
                    btnNext.Text = "Finish";
                }
            }
            else if(btnNext.Text == "Finish")
            {
                uCookClient.mainScreen.Enabled = true;
                timeLine.reset();
                resetGP();
                this.Close();
            }           
        }

        //////////////////////
        //message sending
        //////////////////////
        private bool SendMessage(String message)
        {
            if (serialPort.IsOpen)
            {
                try
                {
                    serialPort.Write(message);
                    return true;
                }
                catch (Exception exception) // Not very nice to catch Exception...but for now it's good enough.
                {
                    Debug.WriteLine("Could not write to serial port: " + exception.Message);
                }
            }
            return false;
        }

        //////////////////////
        //message receiving
        /////////////////////
        private void readMessageTimer_Tick(object sender, EventArgs e)
        {
            if (serialPort.IsOpen && serialPort.BytesToRead > 0)
            {
                try
                {
                    String dataFromSocket = serialPort.ReadExisting();
                    messageBuilder.Append(dataFromSocket);
                    ProcessMessages();
                }
                catch (Exception exception) // Not very nice to catch Exception...but for now it's good enough.
                {
                    Debug.WriteLine("Could not read from serial port: " + exception.Message);
                }
            }
        }

        private void ProcessMessages()
        {
            String message = messageBuilder.FindAndRemoveNextMessage();
            while (message != null)
            {
                MessageReceived(message);
                message = messageBuilder.FindAndRemoveNextMessage();
            }
        }

        private void MessageReceived(String message)
        {
            //check if message has correct format
            if (message.Substring(0, 1) == messageBeginMarker 
                && message.Substring(message.Length -1, 1) == messageEndMarker)
            {
                message = message.Substring(1, message.Length - 2);
                if(message.Contains(":"))
                {
                    if (message.Contains("AC+")) //general acknowledge
                    {
                        if (!updateSlots(true))
                        {
                            btnNext.Text = "Finish";
                        }
                    }
                    else if (message == "2WK:COO") //waterkoker done
                    {
                        if (!updateSlots(true))
                        {
                            btnNext.Text = "Finish";
                        }
                    }
                }
                else
                {
                    
                }
                
            }    
        }

        //////////////////////
        //Events
        /////////////////////
        private void durationTimer_Tick(object sender, EventArgs e)
        {
            timePassed++;
            tbDuration.Text = (currentTimeSlot.duration - timePassed).ToString();

            if (timePassed == currentTimeSlot.duration)
            {
                timePassed = 0;
                durationTimer.Enabled = false;

                if (!updateSlots(true))
                {
                    btnNext.Text = "Finish";
                }
            }
        }

        //////////////////////
        //Close port on form close
        /////////////////////
        private void TimeLineClient_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (serialPort.IsOpen)
            {
                resetGP();
                serialPort.Close();
            }
            timeLine.reset();
            uCookClient.mainScreen.Enabled = true;
        }
    }
}
