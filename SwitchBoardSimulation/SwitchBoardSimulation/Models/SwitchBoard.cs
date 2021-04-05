using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace SwitchBoardSimulation.Models
{
    class SwitchBoard
    {
        public List<Switch> switches;

        public SwitchBoard()
        {
            switches = new List<Switch>();
        }

        public void AddSwitch(int applianceId)
        {
            int switchId = switches.Count + 1;
            switches.Add(new Switch(switchId, applianceId));
        }
    }
}
