//senan yatigammana G21017409
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartBuilding
{
    public interface IDoorManager : IManager
    {
        bool OpenAllDoors();
        bool LockAllDoors();

        bool OpenDoor(int doorID);
        bool LockDoor(int doorID);
    }
}
