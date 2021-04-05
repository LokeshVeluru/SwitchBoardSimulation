using System;
using System.Collections.Generic;
using System.Text;

namespace SwitchBoardSimulation.Models
{
    class Fan : Appliance
    {
        public Fan(int applianceId)
        {
            this.Type = ApplianceType.FAN;
            this.Id = applianceId;
        }
    }
}
