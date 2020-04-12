using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace Ex2.viewModel
{
    public class FlightBoardViewModel : BaseNotify
    {
        private ICommand connectB;
        private ICommand settingB;
        private ICommand disConnectB;
        private models.FlightBoardModel flightModle;
        public FlightBoardViewModel()
        {
            this.flightModle = new models.FlightBoardModel();

        }
        //Connect Command property
        public ICommand ConnectP
        {
            get
            {
                if (connectB == null)
                {
                    //If empty Create a new Command
                    connectB = new CommandHandler(() =>
                    {
                        Thread connectThread = new Thread(new ThreadStart(() =>
                        {
                            flightModle.connect();
                        }));
                        connectThread.Start();
                    });
                }
                //Update an and lat in a new thread
                Thread UpdatePoint = new Thread(new ThreadStart(() =>
                {
                    while (!flightModle.serverP.isConnection())
                    {

                    }
                    while (flightModle.serverP.isConnection())
                    {
                        if (flightModle.NotifyP)
                        {
                            NotifyPropertyChanged("Lon");
                            NotifyPropertyChanged("Lat");
                        }
                    }
                }));
                UpdatePoint.Start();
                return connectB;
            }
        }
        //Lon property
        public double Lon
        {
            get { return flightModle.longitude; }
        }
        //Lat property
        public double Lat
        {
            get { return flightModle.latitude; }
        }
        //Setting command property
        public ICommand SettingP
        {
            get
            {
                if (settingB == null)
                {
                    //Creae a nre command handler
                    settingB = new CommandHandler(() =>
                    {
                        SettingView setting = new SettingView();
                        var host = new Window();
                        host.Content = setting;
                        host.Show();
                    });
                }
                return settingB;
            }
        }
        //Dissconnect command property
        public ICommand DisConnectP
        {
            get
            {
                if (disConnectB == null)
                {
                    //Create a new with parameter command
                    disConnectB = new models.RelayCommand(() =>
                    {
                        flightModle.serverP.disconnect();
                        flightModle.clientP.disconnect();
                    });
                }
                return disConnectB;
            }
        }
    }
}
