﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace UDP_Server
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("My First UDP Server ");


            string data = "";

            UdpClient server = new UdpClient(8008);


            IPEndPoint remoteIPEndPoint = new IPEndPoint(IPAddress.Any, 0);


            Console.WriteLine(" S E R V E R   IS   S T A R T E D ");
            Console.WriteLine("* Waiting for Client...");
            while (data != "q")
            {
                byte[] receivedBytes = server.Receive(ref remoteIPEndPoint);
                data = Encoding.ASCII.GetString(receivedBytes);
                Console.WriteLine("Handling client at " + remoteIPEndPoint + " - ");
                Console.WriteLine("Message Received " + data.TrimEnd());

                server.Send(receivedBytes, receivedBytes.Length, remoteIPEndPoint);
                Console.WriteLine("Message Echoed to" + remoteIPEndPoint + data);
            }

            Console.WriteLine("Press Enter Program Finished");
            Console.ReadLine(); //delay end of program
            server.Close();  //close the connection

        }
    }
}
