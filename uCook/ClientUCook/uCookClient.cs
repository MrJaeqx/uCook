using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using System.IO.Ports;


namespace ClientUCook
{
    public partial class uCookClient : Form
    {
        //proxy
        private uCookService.RecipesClient proxy;

        //Arduino connection
        private const int connectionSpeed = 9600;
        private const string messageBeginMarker = "#";
        private const string messageEndMarker = "%";
        private const string messageValueMarker = ":";
        private SerialPort serialPort;
        private MessageBuilder messageBuilder;

        //Recipe
        uCookContract.Recipe currentRecipe = null;

        //addScreen
        AddScreen addScreen;

        public uCookClient()
        {
            //init
            InitializeComponent();

            //proxy init
            proxy = new uCookService.RecipesClient();

            //arduino connection init
            serialPort = new SerialPort("COM3", connectionSpeed);
            messageBuilder = new MessageBuilder(messageBeginMarker, messageEndMarker);
        }

        //////////////////////
        //message receiving
        /////////////////////
        private void messageReceiveTimer_Tick(object sender, EventArgs e)
        {
            if (serialPort.IsOpen
                && serialPort.BytesToRead > 0)
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
        }

        private void removeRecipeBtn_Click(object sender, EventArgs e)
        {
            //proxy.removeRecipe(lbResults.SelectedItem.ToString());
        }

        private void findRecipeBtn_Click(object sender, EventArgs e)
        {
            List<uCookContract.Recipe> results = proxy.findRecipe(tbInput.Text);

            lbResults.Items.Clear();
            if (results.Count > 0)
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
            string message = messageBeginMarker + "results" + messageValueMarker + lbResults.Items.Count + messageEndMarker;
            SendMessage(message);
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
    }
}
