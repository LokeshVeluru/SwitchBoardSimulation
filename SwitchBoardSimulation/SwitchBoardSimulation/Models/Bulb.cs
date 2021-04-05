using System;
using System.Collections.Generic;
using System.Text;

namespace SwitchBoardSimulation.Models
{
    class Bulb : Appliance
    {
        public Bulb(int  applianceId)
        {
            this.Type = ApplianceType.BULB;
            this.Id = applianceId;
        }
    }
}
