using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex2.models
{
    public class ApplicationSettingsModel : ISettingsModel
    {
        #region Singleton
        private static ISettingsModel m_Instance = null;
        //Return the singletone instance if null create a new one
        public static ISettingsModel Instance
        {
            get
            {
                if (m_Instance == null)
                {
                    m_Instance = new ApplicationSettingsModel();
                }
                return m_Instance;
            }
        }
        #endregion
        //Property for the server IP
        public string FlightServerIP
        {
            get { return Setting.Default.FlightServerIP; }
            set { Setting.Default.FlightServerIP = value; }
        }
        //Property for the command port 
        public int FlightCommandPort
        {
            get { return Setting.Default.FlightCommandPort; }
            set { Setting.Default.FlightCommandPort = value; }
        }
        //Property for the server port
        public int FlightInfoPort
        {
            get { return Setting.Default.FlightInfoPort; }
            set { Setting.Default.FlightInfoPort = value; }
        }
        //Save the setting 
        public void SaveSettings()
        {
            Setting.Default.Save();
        }
        //Reloade Setting
        public void ReloadSettings()
        {
            Setting.Default.Reload();
        }

    }
}
