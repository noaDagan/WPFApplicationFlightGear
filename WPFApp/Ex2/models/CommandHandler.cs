using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Ex2
{
    public class CommandHandler : ICommand
    {
        private Action action;
        public CommandHandler(Action a)
        {
            action = a;
        }
        //If can ececute the command
        public bool CanExecute(object parameter)
        {
            return true;
        }

        public event EventHandler CanExecuteChanged;

        //Execute the command
        public void Execute(object parameter)
        {
            action();
        }
    }
}
