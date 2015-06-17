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
        private const string messageValueMarker = ":";
        private SerialPort serialPort;
        private MessageBuilder messageBuilder;

        //Current timeline
        private uCookContract.TimeLine timeLine = null;
        private uCookContract.TimeSlot currentTimeSlot = null;
        private uCookContract.TimeSlot nextTimeSlot = null;

        //minute counter
        private int timePassed = 0;

        public TimeLineClient(uCookContract.Recipe recipe)
        {
            InitializeComponent();
            timeLine = recipe.timeLine;

            updateSlots();

            initPorts();         
        }

        //////////////////////
        //init ports
        //////////////////////
        private void initPorts()
        {
            //arduino connection init
            serialPort = new SerialPort("COM4", connectionSpeed);
            messageBuilder = new MessageBuilder(messageBeginMarker, messageEndMarker);

            //opening port
            if (serialPort.IsOpen)
            {
                readMessageTimer.Enabled = false;
                serialPort.Close();
            }
            else
            {
                try
                {
                    serialPort.Open();
                    if (serialPort.IsOpen)
                    {
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
        private void updateSlots()
        {
            //check for out of range exception
            if(timeLine.currentSlot < timeLine.ammountTimeSlots)
            {
                currentTimeSlot = timeLine.timeLine[timeLine.currentSlot];
                tbCurrent.Text = currentTimeSlot.action;

                if(currentTimeSlot.duration != 0)
                {
                    tbDuration.Text = currentTimeSlot.duration.ToString();
                }
                else
                {
                    tbDuration.Text = "waiting for user confirmation";
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
            }

            if(currentTimeSlot != null)
            {
                sendActionsToMaster();
            }     
        }

        private void sendActionsToMaster()
        {
            switch(currentTimeSlot.appliance)
            {
                case uCookContract.Appliances.none:
                    SendMessage(messageBeginMarker + "" + messageEndMarker);
                    break;
                case uCookContract.Appliances.uCook_Braadpan:
                    SendMessage(messageBeginMarker + "" + messageEndMarker);
                    break;
                case uCookContract.Appliances.uCook_Kookpan:
                    SendMessage(messageBeginMarker + "" + messageEndMarker);
                    break;
                case uCookContract.Appliances.uCook_Waterkoker:
                    SendMessage(messageBeginMarker + "" + messageEndMarker);
                    break;
            }
        }

        //////////////////////
        //button handling
        /////////////////////
        private void btnNext_Click(object sender, EventArgs e)
        {
            timeLine.nextSlot();

            updateSlots();
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
                timeLine.nextSlot();
                updateSlots();
            }
        }

        //////////////////////
        //Close port on form close
        /////////////////////
        private void TimeLineClient_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (serialPort.IsOpen)
            {
                serialPort.Close();
            }
            uCookClient.mainScreen.Enabled = true;
        }
    }
}
