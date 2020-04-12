using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Media;

namespace Ex2
{
    public class AutoPilotModel
    {
        //Background Color
        public Brush color = new SolidColorBrush(Colors.White);
        private string[] commandsArray;
        //The function Senf the commands to the plane
        public void sendLines()
        {
            //Get the command instance
            Commands client = Commands.commandInstance;
            if (!client.isConnection())
            {
                client.connect();
            }
            int len = commandsArray.Length;
            //Send each command and wait 2 seconds
            for (int i = 0; i < len; i++)
            {
                client.sendCommand(commandsArray[i]);
                Thread.Sleep(2000);
            }
            color= new SolidColorBrush(Colors.White);
            client.disconnect();
        }
        //The function execute the command array
        public void sendCommand(string[] command)
        {
            //Send the commands in a new thread
            this.commandsArray = command;
            Thread thread = new Thread(new ThreadStart(sendLines));            thread.Start();
        }
    }
}
