using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace Ex2.viewModel
{
    class Setting_viewModel : BaseNotify
    {
        private ICommand okCommand;
        private ICommand cancelCommand;
        private models.ISettingsModel model;
        // Constructor 
        public Setting_viewModel(models.ISettingsModel model)
        {
            this.model = model;
        }

        // Server ip string property
        public string ServerIP
        {
            get { return model.FlightServerIP; }
            set
            {
                // notify if changed
                model.FlightServerIP = value;
                NotifyPropertyChanged("ServerIP");
            }
        }

        // Server port string property
        public int ServerPort
        {
            get { return model.FlightInfoPort; }
            set
            {
                // notify if changed
                model.FlightInfoPort = value;
                NotifyPropertyChanged("ServerPort");
            }
        }

        // Command port int property
        public int CommandPort
        {
            get { return model.FlightCommandPort; }
            set
            {
                model.FlightCommandPort = value;
                // notify if changed
                NotifyPropertyChanged("CommandPort");
            }
        }

        // OK Command property
        public ICommand okCommandP
        {
            get
            {
                // if okCommand empty
                if (okCommand == null)
                {
                    // if values changed save them and update
                    okCommand = new models.RelayCommand(() => {
                        model.SaveSettings();
                    }
                    );
                }

                return okCommand;
            }
        }

        // Cancel Command property
        public ICommand cancelCommandP
        {
            get
            {
                // if okCommand empty
                if (cancelCommand == null)
                {
                    // delete the value changes
                    cancelCommand = new models.RelayCommand(() => {
                        model.ReloadSettings();
                    }
                    );
                }
                return cancelCommand;
            }
        }
    }
}