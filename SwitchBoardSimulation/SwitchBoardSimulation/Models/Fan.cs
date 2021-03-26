using System;
using System.Collections.Generic;
using System.Text;

namespace SwitchBoardSimulation.Models
{
    class Fan : Appliance
    {
        public Fan()
        {
            this.Type = ApplianceType.FAN;
        }
    }
}
