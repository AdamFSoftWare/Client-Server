using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace location
{
    
    public partial class Client : Form
    {
        string portNumber = null;
        string protocolName = null;
        string hostName = null;
        string username = null;
        string userLocation = null;
        string timeout = null;
        string debugMode = null;
        public Client()
        {
            InitializeComponent();
            protocolComboBox.SelectedIndex = 0; //default setting
        }
        private void Client_Load(object sender, EventArgs e)
        {

        }
        
        //gets the port
        private void PortTextBox_TextChanged(object sender, EventArgs e)
        {
           portNumber = portTextBox.Text;
            
        }
        //gets the host
        private void HostTextBox_TextChanged(object sender, EventArgs e)
        {
             hostName = hostTextBox.Text;
        }
        //gets the protocol
        private void ProtocolComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            protocolName = protocolComboBox.Text;

            
        }
        //gets the timeout
        private void TimeoutTextBox_TextChanged(object sender, EventArgs e)
        {
             timeout = timeoutTextBox.Text;
           
        }
        //gets the location
        private void LocationTextBox_TextChanged(object sender, EventArgs e)
        {
             userLocation = locationTextBox.Text;
        }
        //gets the username
        private void UsernameTextBox_TextChanged(object sender, EventArgs e)
        {
             username = usernameTextBox.Text;

        }

        private void SendButton_Click(object sender, EventArgs e)
        {
            //closes the user interface
            this.Close();
           

            
        }

        /// <summary>
        /// Adds the user input into a list and then is used in the main program 
        /// </summary>
        /// <returns></returns>
        public List<string> getArgs()
        {
            List<string> result = new List<string>();

            if (portNumber != null)
            {
                result.Add("-p");
                result.Add(portNumber);
                
            }

            if (hostName != null)
            {
                result.Add("-h");
                result.Add(hostName);
            }

            if (protocolName != null)
            {
                if (protocolName == "whois") {
                    protocolName = "";
                }
                result.Add(protocolName);
            }

            if (timeout != null)
            {
                result.Add("-t");
                result.Add(timeout);
            }
            if (username != null)
            {
                result.Add(username);
            }

            if (userLocation != null)
            {
                result.Add(userLocation);
            }

            if (debugMode != null)
            {
                result.Add(debugMode);
            }
            return result;


        }
        private void debugModeCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (debugModeCheckBox.Checked == true)
            {
                debugMode = "-d";
            }
        }
    }
}
