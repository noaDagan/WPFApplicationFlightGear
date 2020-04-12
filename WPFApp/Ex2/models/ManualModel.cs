using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex2.models
{
    public class ManualModel
    {
        public Commands command;
        public ManualModel()
        {
            this.command = Commands.commandInstance;
        }
        //The function send the command to the plane
        public void sentToClient(string input)
        {
            //Connect to the clieant and sent the command
            this.command.connect();
            this.command.sendCommand(input);
            this.command.disconnect();
        }
    }
}
