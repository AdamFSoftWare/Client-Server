using System;
using System.Net.Sockets;
using System.IO;
using System.Text.RegularExpressions;
using System.Collections.Generic;
using System.Threading;

namespace locationserver
{
    class Handler
    {
        /// <summary>
        /// Creates a txt file using the file location which was used as an argument and then writes the server replies to the txt
        /// https://stackoverflow.com/questions/28988651/c-sharp-server-logging-to-text-file-from-console - this method was adapted and taken from this url.
        /// </summary>
        /// <param name="logtext"></param>
        static void WriteToLog(string logtext)
        {
            
            if (Whois.txtFileLocation!= null) {
                lock (Whois.txtFileLocation)
                {
                    System.IO.File.AppendAllText(Whois.txtFileLocation, string.Format("{0} {1}", logtext, Environment.NewLine));
                }
            }
           
        }

        /// <summary>
        /// Creates a txt file using the file location which was used an argument and then it will save the database to the txt file.
        /// </summary>
        /// <param name="logtext"></param>
        static void WriteToDatabaseLog()
        {

            foreach (KeyValuePair<string, string> user in Whois.dictionary)
            {
                if (Whois.txtDatabaseFileLocation != null)
                {
                    lock(Whois.txtDatabaseFileLocation)
                    {
                        System.IO.File.AppendAllText(Whois.txtDatabaseFileLocation, string.Format("{0} {1}\r\n", user.Key, user.Value, Environment.NewLine));
                    }
                }
                
            }
        }

        
    //Called after the server receives a connection on listener.
    //Processes the lines received as a request in the protocols specified in the specification and sends the appropiate replies.
    public void DoRequest(Socket connection)
        {
            //once a request is received, a socket is created and calls the doRequest method.
            NetworkStream socketStream;
            socketStream = new NetworkStream(connection);
            Console.WriteLine("Connection Received");
           

            try
            {
                //timeout value is 1 second
                socketStream.ReadTimeout = 1000;
                socketStream.WriteTimeout = 1000;

                //Creates streamwriter and streamreader to handle the socket.
                StreamWriter sw = new StreamWriter(socketStream);
                StreamReader sr = new StreamReader(socketStream);

                string protocol = "whois";
                string request = "";
                char temp;

                try
                {
                    
                    //reads in the request character by character until their is nothing left to read and peek detects this by checking the buffer.
                    while (sr.Peek() != -1)
                    {
                        temp = (char) sr.Read();
                        request += temp;
                        
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine("Their was an error with reading in the request" + e.Message);

                }

                //checks the protocol which the request is using

                Whois.DebugMethod("The server is now checking which protocol the client request was using");

                if (request.Contains("HTTP/1.1") && request.Contains("GET /?name=") || request.Contains("POST / HTTP/1.1"))
                {
                    protocol = "h1";
                }
                else if (request.Contains("HTTP/1.0") && request.Contains("GET /?") || request.Contains("POST /") && request.Contains("HTTP/1.0"))
                {
                    protocol = "h0";
                }
                
                else if (request.Contains("GET /"))
                {
                    protocol = "h9";
                }
                else if (request.Contains("PUT /"))
                {
                    protocol = "h9";
                }
                else
                {
                    protocol = "whois";
                }

                string[] sections = Extractor.GetNameLocation(protocol, request);
                Whois.DebugMethod("The extraction of the name and location from the request was successful.");
                try
                {
                    switch (protocol)
                    {
                        case "h9":

                            if (sections.Length == 1)
                            {
                                if (Whois.dictionary.ContainsKey(sections[0])) // finds an entry in the database for the user
                                {
                                    sw.Write("HTTP/0.9 200 OK" + "\r\n");
                                    sw.Write("Content-Type: text/plain" + "\r\n");
                                    sw.Write("\r\n");
                                    sw.Write(Whois.dictionary[sections[0]] + "\r\n");
                                    sw.Flush();
                                    //logs the user query
                                    string response = "request for :" + sections[0] + " replied in:" + Whois.dictionary[sections[0]];
                                    WriteToLog("[" + DateTime.Now.ToString("h:mm:ss tt") + "] [Server]: " + response);

                                    Whois.DebugMethod("The server has responded to the HTTP/0.9 protocol query request.");

                                }
                                else // if the server is unable to find an entry in the databse for the person
                                {
                                    sw.Write("HTTP/0.9 404 Not Found" + "\r\n");
                                    sw.Write("Content-Type: text/plain" + "\r\n");
                                    sw.Write("\r\n");
                                    sw.Flush();

                                    //logs the user not found
                                    string response = "No location in the database for:" + sections[0];
                                    WriteToLog("[" + DateTime.Now.ToString("h:mm:ss tt") + "] [Server]: " + response);

                                    Whois.DebugMethod("The server could not find an entry in the database for a user.");
                                }
                            }
                            else // 2 arguments - update
                            {
                                Whois.dictionary[sections[0]] = sections[1];
                                sw.Write("HTTP/0.9 200 OK" + "\r\n");
                                sw.Write("Content-Type: text/plain" + "\r\n");
                                sw.Write("\r\n");
                                sw.Flush();

                                //logs the user update
                                string response = "Location updated for :" + sections[0] + ":" + Whois.dictionary[sections[0]];
                                WriteToLog("[" + DateTime.Now.ToString("h:mm:ss tt") + "] [Server]: " + response);
                                WriteToDatabaseLog();

                                Whois.DebugMethod("The server has updated a usernames location for a HTTP/0.9 protocol request.");
                            }
                            break;

                        case "h0":
                            if (sections.Length == 1)
                            {
                                if (Whois.dictionary.ContainsKey(sections[0])) //finds entry in the database for the user
                                {
                                    sw.Write("HTTP/1.0 200 OK" + "\r\n");
                                    sw.Write("Content-Type: text/plain" + "\r\n");
                                    sw.Write("\r\n");
                                    sw.Write(Whois.dictionary[sections[0]] + "\r\n");
                                    sw.Flush();

                                    string response = "request for :" + sections[0] + " replied in:" + Whois.dictionary[sections[0]];
                                    WriteToLog("[" + DateTime.Now.ToString("h:mm:ss tt") + "] [Server]: " + response);

                                    Whois.DebugMethod("The server has responded to a HTTP/1.0 protocol query request.");
                                }
                                else // if the server is unable to find an entry
                                {
                                    sw.Write("HTTP/1.0 404 Not Found" + "\r\n");
                                    sw.Write("Content-Type: text/plain" + "\r\n");
                                    sw.Write("\r\n");
                                    sw.Flush();

                                    string response = "No location in the database for:" + sections[0];
                                    WriteToLog("[" + DateTime.Now.ToString("h:mm:ss tt") + "] [Server]: " + response);

                                    Whois.DebugMethod("The server could not find an entry in the database for a user.");
                                }
                            }
                            else // 2 arguments - update
                            {
                                Whois.dictionary[sections[0]] = sections[1];
                                sw.Write("HTTP/1.0 200 OK" + "\r\n");
                                sw.Write("Content-Type: text/plain" + "\r\n");
                                sw.Write("\r\n");
                                sw.Flush();

                                string response = "Location updated for :" + sections[0] + ":" + Whois.dictionary[sections[0]];
                                WriteToLog("[" + DateTime.Now.ToString("h:mm:ss tt") + "] [Server]: " + response);
                                WriteToDatabaseLog();

                                Whois.DebugMethod("The server has updated a usernames location for a HTTP/1.0 protcol request.");
                            }
                            break;

                        case "h1":
                            if (sections.Length == 1)
                            {
                                if (Whois.dictionary.ContainsKey(sections[0])) // finding entry
                                {
                                    sw.Write("HTTP/1.1 200 OK" + "\r\n");
                                    sw.Write("Content-Type: text/plain" + "\r\n");
                                    sw.Write("\r\n");
                                    sw.Write(Whois.dictionary[sections[0]] + "\r\n");
                                    sw.Flush();

                                    string response = "request for :" + sections[0] + " replied in:" + Whois.dictionary[sections[0]];
                                    WriteToLog("[" + DateTime.Now.ToString("h:mm:ss tt") + "] [Server]: " + response);

                                    Whois.DebugMethod("The server has responded to a HTTP/1.1 query request.");
                                }
                                else // unable to find entry
                                {
                                    sw.Write("HTTP/1.1 404 Not Found" + "\r\n");
                                    sw.Write("Content-Type: text/plain" + "\r\n");
                                    sw.Write("\r\n");
                                    sw.Flush();

                                    string response = "No location in the database for:" + sections[0];
                                    WriteToLog("[" + DateTime.Now.ToString("h:mm:ss tt") + "] [Server]: " + response);

                                    Whois.DebugMethod("The server could not find an entry in the database.");
                                }
                            }
                            else // 2 arguments - update
                            {
                                Whois.dictionary[sections[0]] = sections[1];
                                sw.Write("HTTP/1.1 200 OK" + "\r\n");
                                sw.Write("Content-Type: text/plain" + "\r\n");
                                sw.Write("\r\n");
                                sw.Flush();

                                string response = "Location updated for :" + sections[0] + ":" + Whois.dictionary[sections[0]];
                                WriteToLog("[" + DateTime.Now.ToString("h:mm:ss tt") + "] [Server]: " + response);
                                WriteToDatabaseLog();

                                Whois.DebugMethod("The server has updated a usernames location for a HTTP/1.1 request");
                            }
                            break;

                        case "whois":
                            if (sections.Length == 1) // 1 argument - read
                            {
                                sections[0] = sections[0].Replace("\r\n", string.Empty); // removes the \r\n when comparing name against dictionary 
                                if (Whois.dictionary.ContainsKey(sections[0]))
                                {

                                    sw.Write(Whois.dictionary[sections[0]] + "\r\n");
                                    sw.Flush();


                                    string response = "request for :" + sections[0] + " replied in:" + Whois.dictionary[sections[0]];
                                    WriteToLog("[" + DateTime.Now.ToString("h:mm:ss tt") + "] [Server]: " + response);

                                    Whois.DebugMethod("The server has responded to a whois query request.");
                                }
                                else
                                {
                                    sw.Write("ERROR: no entries found\r\n");
                                    sw.Flush();

                                    string response = "No location in the database for:" + sections[0];
                                    WriteToLog("[" + DateTime.Now.ToString("h:mm:ss tt") + "] [Server]: " + response);

                                    Whois.DebugMethod("The server could not find an entry in the database.");
                                }
                            }
                            else // 2 arguments - update
                            {
                                Whois.dictionary[sections[0]] = sections[1];
                                sw.Write("OK\r\n");
                                sw.Flush();
                                Console.WriteLine(sections[0] + sections[1]);

                                //writes to log
                                string response = "Location updated for :" + sections[0] + ":" + Whois.dictionary[sections[0]];
                                WriteToLog("[" + DateTime.Now.ToString("h:mm:ss tt") + "] [Server]: " + response);

                                //writes to database
                                WriteToDatabaseLog();

                                Whois.DebugMethod("The server has updated a usernames location for a whois protocol request.");
                            }
                            break;

                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine("Their was an error with responding to the client requests: " + e.Message);
                }

            }
            catch (Exception e)
            {
                Console.WriteLine("Something went wrong: " + e.Message);
            }
            finally
            {
                socketStream.Close();
                connection.Close();
            }

        }
    }
}
