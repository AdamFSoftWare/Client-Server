using System;
using System.Text.RegularExpressions;

namespace locationserver
{
    class Extractor
    {
        /// <summary>
        /// Uses regular expressions to extract the name and location from the request and then returns the information in a string array to be looped through and used
        /// </summary>
        /// <param name="protocol"></param>
        /// <param name="request"></param>
        /// <returns></returns>
        public static string[] GetNameLocation(string protocol, string request)
        {
            if (protocol == "whois")
            {
                //A-Za-z0-9\s@ old pattern for matching against the names and location just in case
                //update
                if (request.Contains(" ")) { 

                    return request.Split(new char[] { ' ' }, 2);
                   
                }
                else
                {
                   //query
                    return new string[] { request };
                }
                
            }

            else
            {
                string[] sections = request.Split(new string[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries);
                if (protocol == "h9")
                {
                    //query
                    // $ marks the end of the match
                    if (sections.Length == 1)
                    {
                        string txt = request;
                        //using string literals and only regular expression for the variable i need
                        Regex pattern = new Regex(@"GET /([\s\S]*)\r\n$");
                        Match match = pattern.Match(txt);

                        if (match.Success == true)
                        {
                            string name = match.Groups[1].Value;
                            return new string[] { name };
                        }
                        
                    }
                    //update
                    else
                    {

                        string txt = request;

                        Regex pattern = new Regex(@"PUT /([\s\S]*)\r\n\r\n([\s\S]*)\r\n$");
                        Match match = pattern.Match(txt);

                        if (match.Success == true)
                        {
                            string name = match.Groups[1].Value;
                            string location = match.Groups[2].Value;
                            return new string[] { name, location };
                        }


                    }
                }
                else if (protocol == "h0")
                {
                    //query
                    if (sections.Length == 1)
                    {
                        string txt = request;
                        //the /\ allows me to escape the ?
                        Regex pattern = new Regex(@"GET /\?([\s\S]*) HTTP/1.0\r\n\r\n$");
                        Match match = pattern.Match(txt);

                        if (match.Success == true)
                        {
                            string name = match.Groups[1].Value;
                            return new string[] { name };
                        }

                    }
                    //update
                    else
                    {
                        string txt = request;

                        //i create a regex pattern for the int value for length and then i ignore the value
                        Regex pattern = new Regex(@"POST /([\s\S]*) HTTP/1.0\r\nContent-Length: ([0-9]*)\r\n\r\n([\s\S]*)$");
                        Match match = pattern.Match(txt);

                        if (match.Success == true)
                        {
                            string name = match.Groups[1].Value;
                            string location = match.Groups[3].Value;
                            return new string[] { name, location };
                        }
                    }
                }
                else if (protocol == "h1")
                {
                    //query
                    if (sections.Length == 2)
                    {
                        string txt = request;

                        //again i ignore the hostname value
                        Regex pattern = new Regex(@"GET /\?name=([\s\S]*) HTTP/1.1\r\nHost: ([\s\S]*)\r\n\r\n$");
                        Match match = pattern.Match(txt);

                        if (match.Success == true)
                        {
                            string name = match.Groups[1].Value;
                            return new string[] { name };
                        }

                    }
                    //update
                    else if (sections.Length == 4)
                    {
                        string txt = request;

                        Regex pattern = new Regex(@"POST / HTTP/1.1\r\nHost: ([A-Za-z0-9\s@]*)\r\nContent-Length: ([0-9]*)\r\n\r\nname=([\s\S]*)&location=([\s\S]*)$");
                        Match match = pattern.Match(txt);

                        if (match.Success == true)
                        {
                            string name = match.Groups[3].Value;
                            string location = match.Groups[4].Value;
                            return new string[] { name, location };
                        }

                    }
                    // internet explorer
                    else
                    {
                        
                        string[] splitRequest = request.Split(new string[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries);

                        if (splitRequest.Length == 9)
                        {

                            string query = splitRequest[0] + splitRequest[5]; 

                        Regex pattern = new Regex(@"GET /\?name=([\s\S]*) HTTP/1.1Host: ([A-Za-z0-9\s@]*):([A-Za-z0-9\s@]*)$");
                        Match match = pattern.Match(query);

                        if (match.Success == true)
                        {
                            string name = match.Groups[1].Value;
                            return new string[] { name};
                        }

                        }
                        

                    }
                }
            }
            return new string[] { };
        }
    }
}
