using System;
using System.Collections.Generic;
using System.Text;
using SwitchBoardSimulation.Models;
using System.Linq;

namespace SwitchBoardSimulation.Services
{
    class AppServices : IAppServices
    {
        readonly SwitchBoard switchboard;
        readonly List<Appliance> appliances;

        public AppServices()
        {
            switchboard = new SwitchBoard();
            appliances = new List<Appliance>();
        }

        public void CreateSwitchboard()
        {
            Console.Write("Enter number of fans: ");
            int fanCount = Convert.ToInt32(Console.ReadLine());
            this.AddAppliance(fanCount, ApplianceType.FAN);
            Console.Write("Enter number of ac: ");
            int acCount = Convert.ToInt32(Console.ReadLine());
            this.AddAppliance(acCount, ApplianceType.AC);
            Console.Write("Enter number of bulbs: ");
            int bulbCount = Convert.ToInt32(Console.ReadLine());
            this.AddAppliance(bulbCount, ApplianceType.BULB);
        }

        public void AddAppliance(int applianceCount, ApplianceType type)
        {
            for (int i = 0; i < applianceCount; i++)
            {
                Appliance appliance = null;
                switch (type)
                {
                    case ApplianceType.FAN:
                        appliance = new Fan(i + 1);
                        break;
                    case ApplianceType.AC:
                        appliance = new AC(i + 1);
                        break;
                    case ApplianceType.BULB:
                        appliance = new Bulb(i + 1);
                        break;
                }
                appliances.Add(appliance);
                switchboard.AddSwitch(appliance.ApplianceId);
            }
        }

        public void StartSwitchboard()
        {
            char ch;
            do
            {
                Console.Write("\n1.Fan\t2.AC\t3.Bulbs\nEnter device type:");
                int type = Convert.ToInt32(Console.ReadLine());
                Console.Write("Enter device number:");
                int deviceNo = Convert.ToInt32(Console.ReadLine());
                Switch swich = FindSwitch(type, deviceNo);
                if(swich == null)
                {
                    Console.Write("Entered invalid deviceNo!!!");
                    ch = 'y';
                    continue;
                }
                DisplaySwitchOperations(swich);
                int choice = Convert.ToInt32(Console.ReadLine());
                if (choice == 1)
                {
                    swich.ToggleStatus();
                }
                DisplaySwitchboardState();
                Console.Write("\nDo you want to continue(y/Y): ");
                ch = Console.ReadLine()[0];
            } while (ch == 'y' || ch == 'Y');
        }

        public Switch FindSwitch(int deviceType, int deviceNo)
        {
            String applianceId = String.Empty;
            switch ((ApplianceType)deviceType)
            {
                case ApplianceType.FAN:
                    applianceId = "F-";
                    break;
                case ApplianceType.AC:
                    applianceId = "A-";
                    break;
                case ApplianceType.BULB:
                    applianceId = "B-";
                    break;
            }
            applianceId += deviceNo.ToString();
            var switches = switchboard.switches.Where(s => s.ApplianceId == applianceId).ToList();
            if(switches.Any())
            {
                return switches[0];
            }
            return null;
        }

        public void DisplaySwitchOperations(Switch swich)
        {
            int deviceNo = Int32.Parse(swich.ApplianceId[2..]);
            Console.Write("1. Switch " + GetApplianceType(swich.ApplianceId) + "-" + deviceNo + " ");
            var operation = swich.GetStatus() == SwitchStatus.OFF ? "ON" : "OFF";
            Console.WriteLine(operation + "\t2. Back\nEnter your choice: ");
        }
        public ApplianceType GetApplianceType(String applianceId)
        {
            char type = applianceId[0];
            ApplianceType applianceType = ApplianceType.BULB;
            switch (type)
            {
                case 'F':
                    applianceType = ApplianceType.FAN;
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
        public void DisplaySwitchboardState()
        {
            int deviceNo = 1;
            for (int i = 0; i < switchboard.switches.Count; i++)
            {
                if (i == 0 || GetApplianceType(switchboard.switches[i].ApplianceId) != GetApplianceType(switchboard.switches[i-1].ApplianceId))
                {
                    deviceNo = 1;
                    Console.WriteLine();
                }
                Console.WriteLine(GetApplianceType(switchboard.switches[i].ApplianceId) + "-" + deviceNo + " : " + switchboard.switches[i].GetStatus());
                ++deviceNo;
            }
        }
    }
}
