using System;
using System.Collections.Generic;
using System.Text;

namespace SwitchBoardSimulation.Models
{
    class Switch
    {
        public int Id { get; set; }
        public int ApplianceId { get; set; }
        public SwitchStatus Status { get; set; }

        public Switch(int switchId, int applianceId)
        {
            this.Id = switchId;
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
