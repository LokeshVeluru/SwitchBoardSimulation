using System;
using System.Collections.Generic;
using System.Text;
using SwitchBoardSimulation.Models;

namespace SwitchBoardSimulation.Services
{
    interface IAppServices
    {        
        public void CreateSwitchBoard();
        public void StartSwitchBoard();
        public void AddAppliance(int applianceCount, ApplianceType type);
        public void DisplaySwitchBoardState();

    }
}
