//senan yatigammana G21017409
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartBuilding
{
    public interface IWebService
    {
        void LogFireAlarm(string logDetails);
        void LogEngineerRequired(string logDetails);
        void LogStateChange(string logDetails);
    }
}
