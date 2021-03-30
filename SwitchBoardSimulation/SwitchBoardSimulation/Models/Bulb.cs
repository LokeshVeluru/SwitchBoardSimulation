using System;
using System.Collections.Generic;
using System.Text;

namespace SwitchBoardSimulation.Models
{
    class Bulb : Appliance
    {
        public Bulb(int  id)
        {
            this.Type = ApplianceType.BULB;
            this.ApplianceId = "B-" + id.ToString();
        }
    }
}
