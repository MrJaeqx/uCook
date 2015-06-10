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
    public partial class uCookClient : Form
    {
        //Proxy for communication with server
        private uCookService.RecipesClient proxy;

        //Arduino connection
        private const int connectionSpeed = 9600;
        private const string messageBeginMarker = "#";
        private const string messageEndMarker = "%";
        private const string messageValueMarker = ":";
        private SerialPort serialPort;
        private MessageBuilder messageBuilder;

        //Public Recipe for sharing between forms
        public static uCookContract.Recipe newRecipe = null;

        //Current Recipe
        //uCookContract.Recipe currentRecipe = null;

        //Instance of AddScreen for adding new Recipes
        AddScreen addScreen;

        //Used to enable calls to this screen from other screens
        public static uCookClient mainScreen;

        public uCookClient()
        {
            InitializeComponent();
            mainScreen = this;

            //proxy init
            proxy = new uCookService.RecipesClient();

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
        //button handling
        /////////////////////
        private void addRecipeBtn_Click(object sender, EventArgs e)
        {
            addScreen = new AddScreen();
            addScreen.Show();
            this.Enabled = false;
        }

        private void removeRecipeBtn_Click(object sender, EventArgs e)
        {
            //remove recipe
        }

        private void findRecipeBtn_Click(object sender, EventArgs e)
        {
            List<uCookContract.Recipe> results = proxy.findRecipe(tbSearch.Text);

            lbResults.Items.Clear();
            if(results.Count > 0)
            {  
                foreach (uCookContract.Recipe r in results)
                {
                    lbResults.Items.Add(r.name);
                }
            }
            else
            {
                lbResults.Items.Add("no results found");
            }
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            SendMessage("#" + tbTest.Text + "%");
        }

        //////////////////////
        //Close port on form close
        /////////////////////
        private void uCookClient_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (serialPort.IsOpen)
            {
                serialPort.Close();
            }
        }

        private void uCookClient_EnabledChanged(object sender, EventArgs e)
        {
            if (this.Enabled)
            {
                if (newRecipe != null)
                {
                    proxy.addRecipe(newRecipe);
                    newRecipe = null;
                }
            }
        }
    }
}
