using System;
using System.Net;
using System.Net.Sockets;
using System.IO;
using System.Threading;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Linq;

namespace locationserver {

    public class Whois
    {
        public static Dictionary<string, string> dictionary = new Dictionary<string, string>(); // stores the username and the location
        //stores the file locations
        public static string txtFileLocation;
        public static string txtDatabaseFileLocation;
        public static int timeout;
        public static bool debugMode;

        //Allows me to input my console output to the user interface command output.
        public delegate void setTextBox(string text); 
        public static setTextBox TextBoxValue = null;

        /// <summary>
        /// This method is used to switch between console output and ui output
        /// </summary>
        /// <param name="text"></param>
        public static void SetText(string text)
        {
            if (TextBoxValue != null)
            {
                TextBoxValue(text);
            }
            else
            {
                Console.Write(text);
            }
        }
        /// <summary>
        /// Checks for flags in the arguments, sets file locations and server settings, runs either the UI or command.
        /// Also calls the populate dictionary method so that the database is loaded before any client requests are sent into the server.
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            bool runUI = false;
            
            for (int i = 0; i < args.Length; i++)
            {
                
                switch (args[i])
                {

                    case "-t":
                        timeout = int.Parse(args[i + 1]);
                        DebugMethod("A timeout argument was inputted into the server.");
                        break;
                        //file location
                    case "-l":
                        try
                        {
                            txtFileLocation = args[i + 1];
                            DebugMethod("A txt file location has been passed in for the server log.");
                        } catch
                        {

                        }
                        break;
                    //save and reload server database
                    case "-f":
                        try
                        {
                            txtDatabaseFileLocation = args[i + 1];
                            DebugMethod("A txt file location has been passed in for the database log.");
                        } catch
                        {

                        }
                        
                        break;
                        //debug
                    case "-d":
                        debugMode = true;
                        DebugMethod("Debug Mode has been turned on.");
                        break;
                        //checks for the ui flag
                   case "-w":
                         runUI = true;
                        break;

                }

            }

            PopulateDictionary();
            //runs the user interface for the server if the argument is inputted
            if (runUI == true)
            {
                DebugMethod("The -w argument was passed in therefore the user interface will now load.");
                UserInterface serverUI = new UserInterface();
                Application.Run(serverUI);
            }
            else
            {
                DebugMethod("The -w argument was not passed therefore the console will now load.");
                Server.RunServer();
            }
        }

        /// <summary>
        /// Populates the dictionary that stores the usernames and locations using the txt file that is written to when the updates are performed.
        /// </summary>
        static void PopulateDictionary()
        {
            
                //only populates the dictionary if the file exists
                if (File.Exists(txtDatabaseFileLocation) == true)
                {
                DebugMethod("A txtDatabaseFileLocation exists.");
                //prevent any thread from accessing that string.
                lock (txtDatabaseFileLocation)
                {


                    StreamReader sr = new StreamReader(txtDatabaseFileLocation);
                    string temp = sr.ReadLine();

                    string[] nameAndLocation = temp.Split(new char[] { ' ' }, 2);
                    dictionary.Add(nameAndLocation[0], nameAndLocation[1]);
                    DebugMethod("The data which was in the existing log has been added to the dictionary.");
                }
                }
                else
                {
                    DebugMethod("A txt database file location was not given, therefore the dictionary will not be populated.");
                }
            

        }

        /// <summary>
        /// When called it displays a string for the specific event at the time.
        /// </summary>
        /// <param name="debugMessage"></param>
        public static void DebugMethod(string debugMessage)
        {

            if (debugMode == true)
            {
                
                if (TextBoxValue != null)
                {
                    TextBoxValue("Debug Message: " + debugMessage);
                }
                else
                {
                    Console.WriteLine("Debug Message: " + debugMessage);
                }
            }
            
        }

        /// <summary>
        /// Displays the server listening message when the debug mode is activated.
        /// </summary>
        /// <param name="debugMessage"></param>
        public static void NonDebugMethod(string debugMessage)
        {
            if (debugMode == false)
            {
                if (TextBoxValue != null)
                {
                    TextBoxValue(debugMessage);
                }
            }
        }
    }
}