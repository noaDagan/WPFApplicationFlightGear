using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows.Media;

namespace Ex2.viewModel
{
    public class AutoPilotViewModel :BaseNotify
    {
        private AutoPilotModel apModel;
        private string script;
        private ICommand okCommand;
        private ICommand cancelCommand;
        public AutoPilotViewModel()
        {
            apModel = new AutoPilotModel();
            
        }
        //Script Property
        public string scriptProperty
        {
            set
            {
                script = value;
                //If the script is enmpty change the color to white else pink
                if ((script == null) || (script == ""))
                {
                    brush = new SolidColorBrush(Colors.White);
                }
                else
                {
                    brush = new SolidColorBrush(Colors.LightPink);
                }
            }
            get
            {
                return script;
            }
        }
        //apModel Property
        public Brush brush
        {
            set
            {
                apModel.color = value;
                NotifyPropertyChanged("brush");
            }
            get
            {
                return apModel.color;
            }
        }
        //Ok Command property
        public ICommand okCommandP
        {
            get
            {
                if (okCommand == null)
                {
                    okCommand = new CommandHandler(() =>
                    {
                        //Send all the command to the client
                        if((script!=null) && (script != ""))
                        {
                            string[] setCommands = script.Split('\n');
                            apModel.sendCommand(setCommands);
                        }     
                    }
                    );
                    okCommand.Execute(this);
                }
                script = "";
                return okCommand;
            }
        }
        //Cancel command property and notify
        public ICommand cancelCommandP
        {
            get
            {
                if (cancelCommand == null)
                {
                    cancelCommand = new CommandHandler(() =>
                    {
                        scriptProperty = "";
                        NotifyPropertyChanged("scriptProperty");
                    }
                    );
                }
                return cancelCommand;
            }
        }

    }
}
