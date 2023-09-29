using System;
//senan yatigammana G21017409
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartBuilding
{
    public interface IEmailService
    {
        void SendMail(string emailAddress, string subject, string message);
    }
}
