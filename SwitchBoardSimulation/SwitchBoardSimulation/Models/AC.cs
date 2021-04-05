using System;
using System.Collections.Generic;
using System.Text;

namespace SwitchBoardSimulation.Models
{
    class AC : Appliance
    {
        public AC(int applianceId)
        {
            this.Type = ApplianceType.AC;
            this.Id = applianceId;
        }
    }
}
