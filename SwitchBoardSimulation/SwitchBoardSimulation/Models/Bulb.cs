using System;
using System.Collections.Generic;
using System.Text;

namespace SwitchBoardSimulation.Models
{
    class Bulb : Appliance
    {
        public Bulb()
        {
            this.Type = ApplianceType.BULB;
        }
    }
}
