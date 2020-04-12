using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
using System.IO;

namespace Ex2
{
    public class Commands
    {
        #region singleton
        private string ip;
        private int port;
        private IPEndPoint ep;
        private TcpClient client;
        private static Commands instance = null;
        private bool isConnect = false;
        // Private defualt constructor
        private Commands() { }

        // public command properties
        public static Commands commandInstance
        {
            get
            {
                if (instance == null)
                {
                    instance = new Commands();
                }
                return instance;
            }
        }
        #endregion
        // Connect to client and read ip and port
        public void connect()
        {
            if (!isConnect)
            {
                try
                {
                    this.ip = models.ApplicationSettingsModel.Instance.FlightServerIP;
                    this.port = models.ApplicationSettingsModel.Instance.FlightCommandPort;
                    ep = new IPEndPoint(IPAddress.Parse(this.ip), this.port);
                    client = new TcpClient();
                    client.Connect(ep);
                    Console.WriteLine("Command - You are connected");
                    isConnect = true;
                }
                catch (System.Exception) { }
            }
        }
        // The function return true if client connect and false otherwise
        public bool isConnection()
        {
            return isConnect;
        }
        // The function stop the connection of client 
        public void disconnect()
        {
            if (isConnect)
            {
                client.Close();
                isConnect = false;
            }
        }
        // The function sent values to flight gear
        public void sendCommand(string command)
        {
            // check if string not empty 
            if (command != "")
            {
                try
                {
                    using (NetworkStream stream = client.GetStream())
                    using (StreamReader reader = new StreamReader(stream))
                    using (StreamWriter writer = new StreamWriter(stream))
                    {
                        // write to flight gear
                        writer.WriteLine(command);
                    }
                }
                catch (System.Exception)
                {

                }
            }
        }
    }

}