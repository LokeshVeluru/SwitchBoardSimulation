using System;
using System.Collections.Generic;
using System.Text;

namespace SwitchBoardSimulation.Models
{
    class AC : Appliance
    {
        public AC(int id)
        {
            this.Type = ApplianceType.AC;
            this.ApplianceId = "A-" + id.ToString();
        }
    }
}
