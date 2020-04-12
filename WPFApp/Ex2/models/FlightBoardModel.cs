using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Ex2.models
{
    class FlightBoardModel 
    {
        private Commands client;
        private Info server;
        public double longitude;
        public double latitude;
        private bool notifyChanged;
        public FlightBoardModel()
        {
            client = Commands.commandInstance;
            server = Info.infoInstance;
            
        }
        //The finction connect to the client and server
        public void connect()
        {
            //Connect to the server in a new thread
            Thread threadServer = new Thread(new ThreadStart(() => 
            {
                server.connect();
            }));            threadServer.Start();
            while (!server.isConnection())
            {
            }
            //Connect to the client in a new thread
            Thread threadClient = new Thread(new ThreadStart(() =>
            {
                client.connect();
            }));            threadClient.Start();
            //Read the values from the simulator  in a new thread
            Thread readValues = new Thread(new ThreadStart(() =>
            {
                while (server.isConnection())
                {
                    NotifyP = false;
                    //Get the values
                    string values = server.flightValuesP;
                    if (values != "")
                    {
                        //Split thr valus and and read lan and lat 
                        double prevLon = Lon;
                        double prevLat = Lat;
                        string[] splitValues = values.Split(',');
                        Lon = Convert.ToDouble(splitValues[0]);
                        Lat = Convert.ToDouble(splitValues[1]);
       
                        if ((prevLat != Lat) || (prevLon != Lon))
                        {
                            NotifyP = true;
                        }
                    }
                }
            }));            readValues.Start();
        }
        //Lon Property
        public double Lon
        {
            get { return longitude; }
            set { this.longitude = value;
            }
        }
        //Server property
        public Info serverP
        {
            get { return server; }
        }
        //Client Property
        public Commands clientP
        {
            get { return client; }
        }
        //Lat property
        public double Lat
        {
            get { return latitude; }
            set { this.latitude = value; }
        }
        //Notify property
        public bool NotifyP
        {
            get { return notifyChanged; }
            set { notifyChanged = value; }
        }
    } 
}
