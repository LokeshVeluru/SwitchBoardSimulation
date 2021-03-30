using System;
using System.Collections.Generic;
using System.Text;

namespace SwitchBoardSimulation.Models
{
    class Switch
    {
        public SwitchStatus Status { get; set; }

        public String ApplianceId { get; set; }

        public Switch(String applianceId)
        {
            this.Status = SwitchStatus.OFF;
            this.ApplianceId = applianceId;
        }

        public void ToggleStatus()
        {
            this.Status = this.Status == SwitchStatus.OFF ? SwitchStatus.ON : SwitchStatus.OFF;
        }

        public void SetStatus(SwitchStatus status)
        {
            this.Status = status;
        }

        public SwitchStatus GetStatus()
        {
            return this.Status;
        }

    }
}
