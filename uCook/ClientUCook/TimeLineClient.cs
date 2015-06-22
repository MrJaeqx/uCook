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

        //counters
        private int timePassed = 0; //minute
        private int timeCounter = 0; //seconde

        //available appliances
        List<uCookContract.Appliances> availableAppliances = null;

        //check available appliances
        List<uCookContract.Appliances> requiredAppliances = null;

        bool showMB = false;

        public TimeLineClient(uCookContract.Recipe recipe)
        {
            InitializeComponent();
            timeLine = recipe.timeLine;
            requiredAppliances = recipe.appliances;

            serialPort = new SerialPort();

            initPorts();

            SendMessage("#UPDATE%");
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
                case uCookContract.Appliances.uCook_Grilpan:
                    SendMessage(messageBeginMarker + "1GP:P4+" + messageEndMarker);
                    break;
                case uCookContract.Appliances.uCook_Waterkoker:
                    SendMessage(messageBeginMarker + "2WK:ON+" + messageEndMarker);
                    break;
                case uCookContract.Appliances.uCook_Blender:
                    SendMessage(messageBeginMarker + "3BL:ON+" + messageEndMarker);
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
                if (message.Contains("AC+"))
                {
                    if (!updateSlots(true))
                    {
                        btnNext.Text = "Finish";
                    }
                }
                else if (message == "START_SYNC")
                {
                    availableAppliances = new List<uCookContract.Appliances>();
                    availableAppliances.Clear();
                    availableAppliances.Add(uCookContract.Appliances.none);

                    updateAppliancesTimer.Enabled = true;
                }
                else if (message.Contains("PRESENT"))
                {
                    if (message.Contains("1GP"))
                    {
                        availableAppliances.Add(uCookContract.Appliances.uCook_Braadpan);
                        availableAppliances.Add(uCookContract.Appliances.uCook_Grilpan);
                        availableAppliances.Add(uCookContract.Appliances.uCook_Kookpan);
                        availableAppliances.Add(uCookContract.Appliances.uCook_Wokpan);
                    }
                    if (message.Contains("2WK"))
                    {
                        availableAppliances.Add(uCookContract.Appliances.uCook_Waterkoker);
                    }
                    if (message.Contains("3BL"))
                    {
                        availableAppliances.Add(uCookContract.Appliances.uCook_Blender);
                    }
                    if (message.Contains("4VW"))
                    {
                        availableAppliances.Add(uCookContract.Appliances.uCook_Vaatwasser);
                    }
                    if (message.Contains("5OV"))
                    {
                        availableAppliances.Add(uCookContract.Appliances.uCook_Oven);
                    }
                    if (message.Contains("6MW"))
                    {
                        availableAppliances.Add(uCookContract.Appliances.uCook_Magnetron);
                    }
                    if (message.Contains("7AK"))
                    {
                        availableAppliances.Add(uCookContract.Appliances.uCook_Afzuigkap);
                    }
                    if (message.Contains("8TI"))
                    {
                        availableAppliances.Add(uCookContract.Appliances.uCook_Tostiijzer);
                    }
                    if (message.Contains("9WS"))
                    {
                        availableAppliances.Add(uCookContract.Appliances.uCook_Weegschaal);
                    }
                    if (message.Contains("0FP"))
                    {
                        availableAppliances.Add(uCookContract.Appliances.uCook_Frituurpan);
                    }
                }                 
            }    
        }

        //////////////////////
        //Timers
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

        private void updateAppliancesTimer_Tick(object sender, EventArgs e)
        {
            timeCounter++;

            if (timeCounter == 5)
            {
                if (availableAppliances != null && availableAppliances.Count != 0)
                {
                    //check if available
                    foreach (uCookContract.Appliances req in requiredAppliances)
                    {
                        bool present = false;

                        foreach (uCookContract.Appliances ava in availableAppliances)
                        {
                            if (req == ava)
                            {
                                present = true;
                            }
                        }

                        if (!present && !showMB)
                        {
                            showMB = true;
                            MessageBox.Show("You do not have " + req.ToString() + " connected.");
                            if(timeLine.currentSlot == 0)
                            {
                                this.Close();
                            }
                            else
                            {
                                //nopes
                            }                                
                        }
                    }

                    updateSlots(false);
                }
            }
            else if (timeCounter == 10)
            {
                timeCounter = 0;
                SendMessage("#UPDATE%");
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
