using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using static locationserver.Whois;

namespace locationserver
{

    public partial class UserInterface : Form
    {
        public UserInterface()
        {
            InitializeComponent();
            Whois.TextBoxValue = new setTextBox(ThreadSafeConsoleOutPutTextBoxChange);
        }
       
        delegate void SetTextCall(string text);

        /// <summary>
        /// This method was based off https://www.c-sharpcorner.com/UploadFile/1d42da/thread-safe-calls-using-windows-form-controls-in-C-Sharp/ and adapted to send console output to my ui textbox.
        /// </summary>
        /// <param name="text"></param>
        private void ThreadSafeConsoleOutPutTextBoxChange(string text)
        {
            
            
            if (this.consoleOutputTextBox.InvokeRequired)
            {
                SetTextCall d = new SetTextCall(SetConsoleTextBox);
                this.Invoke(d, new object[] { text  });
            }
            else
            {
                // It's on the same thread, no need for Invoke
                SetConsoleTextBox(text);
            }
        }

        private void SetConsoleTextBox(string text)
        {
            this.consoleOutputTextBox.AppendText(text + "\r\n");
        }

        private void logFileLocationTextBox_TextChanged(object sender, EventArgs e)
        {

            Whois.txtFileLocation = logFileLocationTextBox.Text;
        }

        private void databaseFileLocationTextBox_TextChanged(object sender, EventArgs e)
        {

            Whois.txtDatabaseFileLocation = databaseFileLocationTextBox.Text;
        }

        private void consoleOutputTextBox_TextChanged(object sender, EventArgs e)
        {

        }




        /// <summary>
        /// Checks all the server information before the server begins to start listening
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void startListeningButton_Click(object sender, EventArgs e)
        {
            if (logFileLocationTextBox.Text != "")
            {
                logFileLocationTextBox.Text = Whois.txtFileLocation;
            }
            if (databaseFileLocationTextBox.Text != "")
            {
                databaseFileLocationTextBox.Text = Whois.txtDatabaseFileLocation;
            }
            if (timeoutTextBox.Text != "")
            {
                int temp = int.Parse(timeoutTextBox.Text);
                temp = Whois.timeout;
            }
            if (debugCheckBox.Checked)
            {
                Whois.debugMode = true;
            }

            // => allows you to put code inside a thread.
            Thread thread = new Thread(() => Server.RunServer());
            thread.Start();



        }

        private void stopListeningButton_Click(object sender, EventArgs e)
        {

        }

        private void timeoutTextBox_TextChanged(object sender, EventArgs e)
        {

        }



        private void debugCheckBox_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void UserInterface_Load(object sender, EventArgs e)
        {

        }
    }
}
