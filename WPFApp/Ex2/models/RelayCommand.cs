using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace Ex2.models
{
    class RelayCommand : ICommand
    {
        private Action action;
        public RelayCommand(Action a)
        {
            action = a;
        }
        //Can ececute the command
        public bool CanExecute(object parameter)
        {
            return true;
        }

        //Execute the command with parameter
        public void Execute(object parameter)
        {
            action();
            //Close the window
            ((Window)parameter).Close();
        }

        public event EventHandler CanExecuteChanged;
    }
}
