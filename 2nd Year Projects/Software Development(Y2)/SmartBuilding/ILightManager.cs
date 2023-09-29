//senan yatigammana G21017409
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartBuilding
{
    public interface ILightManager : IManager
    {
        void SetAllLights(bool isOn);
        void SetLight(bool isOn, int lightID);
    }

}
