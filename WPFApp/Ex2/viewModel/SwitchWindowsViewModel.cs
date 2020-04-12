using Ex2.viewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Ex2
{
    public class SwitchWindowsViewModel: BaseNotify
    {
        private ICommand switchToJoystick;
        private ICommand switchToAuto;
        private object currentView;
        private object joystick;
        private object autoPilot;
        // Constructor initalize joistick and auto pilot window
        public SwitchWindowsViewModel()
        {
            this.joystick = new Manual();
            this.autoPilot = new AutoP();
            currentViewP = this.joystick;
        }
        // current windows properties
        public object currentViewP
        {
            set
            {
                currentView = value;
                NotifyPropertyChanged("currentViewP");
            }
            get
            {
                return this.currentView;
            }
        }
        // command replace to joistick windows properties
        public ICommand GoToJoystick
        {
            get
            {
                if (switchToJoystick == null)
                {
                    switchToJoystick = new CommandHandler(() => { currentViewP = this.joystick; });
                }
                switchToJoystick.Execute(this);
                return this.switchToJoystick;
            }
        }
        // command replace to auto pilot windows properties
        public ICommand GoToAutoPilot
        {
            get
            {
                if (switchToAuto == null)
                {
                    switchToAuto = new CommandHandler(() => { currentViewP = this.autoPilot; });
                }
                switchToAuto.Execute(this);
                return this.switchToAuto;
            }
        }
    }
}
