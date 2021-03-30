using System;
using System.Collections.Generic;
using System.Text;

namespace SwitchBoardSimulation.Models
{
    class Appliance
    {
        public String ApplianceId { get; set; }
        public ApplianceType Type { get; set; }

        public static ApplianceType GetApplianceType(String applianceId)
        {
            char type = applianceId[0];
            ApplianceType applianceType = ApplianceType.BULB;
            switch (type)
            {
                case 'F':
                    applianceType =  ApplianceType.FAN;
                    break;
                case 'A':
                    applianceType = ApplianceType.AC;
                    break;
                case 'B':
                    applianceType = ApplianceType.BULB;
                    break;
            }
            return applianceType;
        }
    }
}
