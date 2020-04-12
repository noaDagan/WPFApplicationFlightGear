using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
using System.IO;
using System.Threading;

namespace Ex2
{
    class Info
    {
        private string ip;
        private int port;
        private IPEndPoint ep;
        private TcpListener server;
        private static Info instance = null;
        private bool isConnect = false;
        private string flightValues;

        // Constructor initalize script
        private Info()
        {
            flightValuesP = "";

        }
        // properties for the input string from script of flight gear
        public string flightValuesP
        {
            get { return this.flightValues; }
            set { this.flightValues = value; }
        }

        public static Info infoInstance
        {
            get
            {
                if (instance == null)
                {
                    instance = new Info();
                }
                return instance;
            }
        }
        // The function connect to client
        public void clientConection()
        {
            Console.WriteLine("Waiting for client connections...");
            TcpClient client = null;
            try
            {
                client = server.AcceptTcpClient();
                Console.WriteLine("Client connected");
                isConnect = true;
                using (NetworkStream stream = client.GetStream())
                using (StreamReader reader = new StreamReader(stream))
                using (StreamWriter writer = new StreamWriter(stream))
                { // read from flight gear while connect
                    while (isConnection())
                    {
                        flightValuesP = reader.ReadLine();
                        writer.Flush();
                        Thread.Sleep(1000);
                    }
                }
            }
            catch (System.Exception)
            {

            }
        }

        // The function read the ip and port and connect
        public void connect()
        {
            if (!isConnect)
            {
                this.ip = models.ApplicationSettingsModel.Instance.FlightServerIP;
                this.port = models.ApplicationSettingsModel.Instance.FlightInfoPort;
                Console.WriteLine("Waiting");
                ep = new IPEndPoint(IPAddress.Parse(this.ip), port);
                server = new TcpListener(ep);
                server.Start();
                Console.WriteLine("You are connected server");
            }
            clientConection();
        }

        // The function return true if server connect and false otherwise
        public bool isConnection()
        {
            return isConnect;
        }

        // The function stop the connection of server 
        public void disconnect()
        {
            if (isConnect)
            {
                server.Stop();
            }
        }
    }
}