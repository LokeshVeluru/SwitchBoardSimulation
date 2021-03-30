using System;
using System.Collections.Generic;
using System.Text;

namespace SwitchBoardSimulation.Models
{
    class Fan : Appliance
    {
        public Fan(int id)
        {
            this.Type = ApplianceType.FAN;
            this.ApplianceId = "F-" + id.ToString();
        }
    }
}
