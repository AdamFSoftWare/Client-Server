using System;
using System.Net.Sockets;
using System.IO;
using System.Collections.Generic;
using System.Threading;
using System.Windows.Forms;
using location;

public class Whois 
{
    //Allows me to enable debug mode when the argument is used.
    public static bool debugMode;
 
    /// <summary>
    /// Filters the arguments into a list and performs the appropiate request depending upon the protocol which was parsed into the argument.
    /// </summary>
    /// <param name="args"></param>
    static void Main(string[] args)
    {
        //list for arguments from client and command line
        List<string> argumentsList = new List<string>();
        //switch for debug mode


        //opens the user interface if no arguments are inputted.
        if (args.Length == 0)
        {
            DebugMethod("No arguments were passed in, the user interface is now being loaded");
            Client uiclient = new Client();
            uiclient.ShowDialog();


            //collects the user input from the user interface and adds it into the list
            argumentsList = uiclient.getArgs();

        }
        else
        {
            //collects the command line arguments
            DebugMethod("Arguments were passed in, the console will be used");
            argumentsList.AddRange(args);
        }




        // variables that can be changed via flags in the arguments
        string host = "whois.net.dcs.hull.ac.uk";
        int port = 43;
        string protocol = "whois";
        int timeout = 1000;
        string nameLocationString = "";

        ArgumentsParser(argumentsList, ref host, ref port, ref protocol, ref timeout, ref nameLocationString);

        string[] sections = nameLocationString.Split(new char[] { ' ' }, 2);

        //if (sections.Length == 2 && sections[1] == " ") //if the location argument is not passed in
        //{
        //    sections = new string[] { sections[0] }; //treat as if only name was passed
        //}
        /* else */
        if (sections.Length == 2 && sections[1] == " ") //else if the location argument is empty string
        {
            sections[1] = ""; //treat as if name and location that is empty string was passed
        }

        DebugMethod("The client is attempting to connect to the server");

        TcpClient client = new TcpClient();
        client.Connect(host, port);

        DebugMethod("The client was successful at connecting to the server");


        //disables timeouts if timeout = 0 // bonus feature
        if (timeout != 0)
        {
            client.ReceiveTimeout = timeout;
            client.SendTimeout = timeout; // 1 second timeouts for the client and server interaction.
        }



        StreamWriter sw = new StreamWriter(client.GetStream());
        StreamReader sr = new StreamReader(client.GetStream());

        ProtocolName(protocol, sections, sw, sr, host);

    }

    private static void ArgumentsParser(List<string> argumentsList, ref string host, ref int port, ref string protocol, ref int timeout, ref string nameLocationString)
    {
        try
        {

            List<string> argsList = new List<string>(); // 0 is nothing, 1 is query and 2 or more is update

            //loops through the arguments, checking for flags and setting the server details such as host, port, protocol, time out etc.
            //Also separates the username and location from this list and adds it to new a list called argsList
            for (int i = 0; i < argumentsList.Count; i++)
            {
                switch (argumentsList[i])
                {
                    case "-h9":
                        protocol = "-h9";
                        DebugMethod("The h9 protocol is currently being used");
                        break;
                    case "-h0":
                        protocol = "-h0";
                        DebugMethod("The h0 protocol is currently being used");
                        break;
                    case "-h1":
                        protocol = "-h1";
                        DebugMethod("The h1 protocol is currently being used");
                        break;
                    case "-t":
                        timeout = int.Parse(argumentsList[i + 1]); // gets the value by using the next index in the args list
                        DebugMethod("The user has inputted a timeout value");
                        i++;
                        break;
                    case "-h":
                        host = argumentsList[i + 1];
                        DebugMethod("The user has inputted a host name");
                        i++;
                        break;
                    case "-p":
                        port = int.Parse(argumentsList[i + 1]);
                        DebugMethod("The user has inputted a port number");
                        i++;
                        break;
                    case "-d":
                        debugMode = true;
                        break;

                    //change the timeout period
                    default:
                        argsList.Add(argumentsList[i]);  // adds the name and location into the list
                        break;
                }
            }
            nameLocationString = string.Join(" ", argsList); // don't need this
        }
        catch (Exception e)
        {
            Console.WriteLine("Their was an error with looping through the arguments and searching for flags, names and locations" + e.Message);

        }
    }

    /// <summary>
    /// Chooses the correct protocol case and performs the correct request.
    /// </summary>
    /// <param name="protocol"></param>
    /// <param name="sections"></param>
    /// <param name="sw"></param>
    /// <param name="sr"></param>
    /// <param name="host"></param>
    public static void ProtocolName(string protocol, string[] sections, StreamWriter sw, StreamReader sr, string host)
    {
        try
        {
            try
            {
               
                switch (protocol) // looks for the last element of the array and checks for the command flag
                {
                   
                    case "-h9": //http 0.9
                        if (sections.Length == 1)
                        {
                            sw.Write("GET /" + sections[0] + "\r\n");
                            sw.Flush();
                            
                            string request = MethodName(sr);

                            string[] results = request.Split(new string[] { "\r\n" }, StringSplitOptions.None); // splits request by \r\n and allows me to look for the space and then gather the location after the space.
                            for (int i = 0; i < results.Length; i++)
                            {
                                if (results[i] == "")
                                {
                                    DebugMethod("The http/0.9 protocol was used to query a users location");
                                    Console.WriteLine(sections[0] + " is " + results[i + 1]);

                                    break;
                                }
                            }

                        }
                        else if (sections.Length == 2)
                        {
                            sw.Write("PUT /" + sections[0] + "\r\n");
                            sw.Write("\r\n");
                            sw.Write(sections[1] + "\r\n");
                            sw.Flush();
                            

                            string request = MethodName(sr);

                            //string read = sr.ReadToEnd();
                            if (request.Contains("OK"))
                            {
                                DebugMethod("The http/0.9 protocol was used to update a users location");
                                Console.WriteLine(sections[0] + " location changed to be " + sections[1]);

                            }
                        }
                        else
                        {
                            DebugMethod("The http/0.99 protocol was incorrectly used by the user");
                            Console.WriteLine("Incorrect HTTP/0.9 command");

                        }
                        break;

                    case "-h0": //http 1.0
                        if (sections.Length == 1)
                        {
                            sw.Write("GET /?" + sections[0] + " HTTP/1.0" + "\r\n");
                            sw.Write("\r\n");
                            sw.Flush();
                            
                            //test
                            string request = MethodName(sr);

                            string[] results = request.Split(new string[] { "\r\n" }, StringSplitOptions.None); // splits request by \r\n and allows me to look for the space and then gather the location after the space.
                            for (int i = 0; i < results.Length; i++)
                            {
                                if (results[i] == "")
                                {
                                    DebugMethod("The http/1.0 protocol was used to query a users location");
                                    Console.WriteLine(sections[0] + " is " + results[i + 1]);

                                    break;
                                }
                            }

                            //string request = MethodName(sr);
                            //Console.WriteLine(sections[0] + " is " + request);
                        }
                        else if (sections.Length == 2)
                        {
                            sw.Write("POST /" + sections[0] + " HTTP/1.0" + "\r\n");
                            sw.Write("Content-Length: " + sections[1].Length + "\r\n"); // displays the number of characters in the location
                            sw.Write("\r\n");
                            sw.Write(sections[1]);
                            sw.Flush();
                            
                            //test
                            string request = MethodName(sr);
                           
                            if (request.Contains("OK"))
                            {
                                DebugMethod("The http/1.0 protocol was used to update a users location");
                                Console.WriteLine(sections[0] + " location changed to be " + sections[1]);

                            }
                        }
                        else
                        {
                            DebugMethod("The http/1.0 protocol was incorrectly used by the user");
                            Console.WriteLine("Incorrect HTTP 1.0 command");

                        }
                        break;

                    case "-h1": //http 1.1
                        if (sections.Length == 1)
                        {
                            sw.Write("GET /?name=" + sections[0] + " " + "HTTP/1.1" + "\r\n");
                            sw.Write("Host: " + host + "\r\n"); // hostname is the name of the server
                            sw.Write("\r\n");
                            sw.Flush();
                           
                            string request = MethodName(sr);

                            string[] results = request.Split(new string[] { "\r\n" }, StringSplitOptions.None); // splits request by \r\n and allows me to look for the space and then gather the location after the space.
                            for (int i = 0; i < results.Length; i++)
                            {
                                if (results[i] == "")
                                {
                                    DebugMethod("The http/1.1 protocol was used to query a users location");
                                    Console.WriteLine(sections[0] + " is " + results[i + 1]);

                                    break;
                                }
                            }

                        }
                        else if (sections.Length == 2)
                        {
                            int contentLength = 15; // always the base minimum length
                            int nameLength = sections[0].Length;
                            int locationLength = sections[1].Length;

                            contentLength += nameLength;
                            contentLength += locationLength; // adds the length of the name and location onto content length

                            sw.Write("POST / HTTP/1.1" + "\r\n");
                            sw.Write("Host: " + host + "\r\n");
                            sw.Write("Content-Length: " + contentLength + "\r\n"); // content length is added up before
                            sw.Write("\r\n");
                            sw.Write("name=" + sections[0] + "&location=" + sections[1]);
                            sw.Flush();
                            

                            string request = MethodName(sr);

                            if (request.Contains("OK"))
                            {
                                DebugMethod("The http/1.1 protocol was used to update a users location");
                                Console.WriteLine(sections[0] + " location changed to be " + sections[1]);

                            }

                        }
                        else
                        {
                            DebugMethod("The http/1.1 protocol was incorrectly used by the user");
                            Console.WriteLine("Incorrect HTTP 1.0 command");

                        }
                        break;

                    default: //whois
                        if (sections.Length == 1)
                        {
                            sw.Write(sections[0] + "\r\n");
                            sw.Flush();
                            
                            DebugMethod("The whois protocol was used to query a users location");
                            Console.WriteLine(sections[0] + " is " + sr.ReadToEnd());

                        }
                        else if (sections.Length == 2)
                        {
                            sw.Write(sections[0] + " " + sections[1] + "\r\n");
                            sw.Flush();
                            
                            string read = sr.ReadToEnd();
                            if (read == "OK\r\n")
                            {
                                DebugMethod("The whois protocol was used to update a users location");
                                Console.WriteLine(sections[0] + " location changed to be " + sections[1]);

                            }
                        }
                        else
                        {
                            DebugMethod("The whois protocol was incorrectly used by the user");
                            Console.WriteLine("Incorrect HTTP 1.0 command");

                        }
                        break;
                }
            }
            catch
            {
                Console.WriteLine("No arguments supplied");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }

    /// <summary>
    /// reads in the server response
    /// </summary>
    /// <param name="sr"></param>
    /// <returns></returns>
    public static string MethodName(StreamReader sr)
    {
        // checks the request character by character.
        string request = "";
        char temp;

        try
        {
            Thread.Sleep(100);
            while (sr.Peek() != -1)
            {
                // slows down the client so that the server can keep up
                if (request.Length % 100 == 0)
                {
                    Thread.Sleep(1);
                }
                temp = (char)sr.Read();
                request += temp;

            }
        }

        catch (Exception)
        {

        }
        return request;
    }

    /// <summary>
    /// Called to display the debug messages when turned on.
    /// </summary>
    /// <param name="debugMessage"></param>
    public static void DebugMethod(string debugMessage)
    {

        if (debugMode == true)
        {
            Console.WriteLine("Debug Message: " + debugMessage);
        }

    }
}