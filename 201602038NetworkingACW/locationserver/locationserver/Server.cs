using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace locationserver
{
    class Server
    {
        /// <summary>
        /// This method handles the threading, creates the socket and starts listening for client requests.
        /// </summary>
        public static void RunServer()
        {
            TcpListener listener;
            Socket connection;
            Handler requestHandler;

            try
            {
                //Creates a TCP socket on port 43.
                //Starts listening for requests.
                listener = new TcpListener(IPAddress.Any, 43);
                listener.Start();
                Whois.DebugMethod("Server started listening.");
                Whois.NonDebugMethod("Server started listening.");
                while (true)
                {

                    connection = listener.AcceptSocket();
                    requestHandler = new Handler();

                    Thread t = new Thread(() => requestHandler.DoRequest(connection)); // creates a new thread with a new copy of the doRequest method
                    t.Start(); // starts the thread

                }
            }
            catch (Exception e)

            {
                //Catches any error in the processing writes out the error.
                Console.WriteLine("Exception: " + e.ToString());
            }
        }

    }
}
