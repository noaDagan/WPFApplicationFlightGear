using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex2.viewModel
{
    public class ManualViewModel : BaseNotify
    {
        private models.ManualModel manualModel;
        public string aileronString = "set controls/flight/aileron ";
        public string elevatorString = "set controls/flight/elevator ";
        public string throttleString = "set controls/engines/engine/throttle ";
        public string rudderString = "set controls/flight/rudder ";
        public double throttleProperty;
        public double rudderProperty;
        public double aileronProperty;
        public double elevatorProperty;
        public ManualViewModel()
        {
            this.manualModel = new models.ManualModel();
        }
        //Rudder property
        public double Rudder
        {
            get
            {
                return rudderProperty;
            }
            set
            {
                this.rudderProperty = value;
                //Sens command to client
                manualModel.sentToClient(rudderString + rudderProperty.ToString());
            }
        }
        //Throttle property
        public double Throttle
        {
            get
            {
                return throttleProperty;
            }
            set
            {

                this.throttleProperty = value;
                //Send command to client
                manualModel.sentToClient(throttleString + throttleProperty.ToString());
            }
        }
        public string Aileron1
        {
            get
            {
                return aileronProperty.ToString();
            }
        }
        //Ailron property
        public double Aileron
        {
            get
            {
                return aileronProperty;
            }
            set
            {
                this.aileronProperty = value;
                //Send command to client
                manualModel.sentToClient(aileronString + aileronProperty.ToString());
            }
        }
        //Elevator property
        public double Elevator
        {
            get
            {
                return elevatorProperty;
            }
            set
            {
                this.elevatorProperty = value;
                //Send command to client
                manualModel.sentToClient(elevatorString + elevatorProperty.ToString());
            }
        }
    }
}
 