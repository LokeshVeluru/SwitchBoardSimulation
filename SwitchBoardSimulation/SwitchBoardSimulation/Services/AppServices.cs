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
                switch (type)
                {
                    case ApplianceType.FAN:
                        appliances.Add(new Fan(i+1));
                        break;
                    case ApplianceType.AC:
                        appliances.Add(new AC(i + 1));
                        break;
                    case ApplianceType.BULB:
                        appliances.Add(new Bulb(i + 1));
                        break;
                }
                switchboard.AddSwitch(appliances.Last().ApplianceId);
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
            Console.Write("1. Switch " + Appliance.GetApplianceType(swich.ApplianceId) + "-" + deviceNo + " ");
            var operation = swich.GetStatus() == SwitchStatus.OFF ? "ON" : "OFF";
            Console.WriteLine(operation + "\t2. Back\nEnter your choice: ");
        }

        public void DisplaySwitchboardState()
        {
            int deviceNo = 1;
            for (int i = 0; i < switchboard.switches.Count; i++)
            {
                if (i == 0 || Appliance.GetApplianceType(switchboard.switches[i].ApplianceId) != Appliance.GetApplianceType(switchboard.switches[i-1].ApplianceId))
                {
                    deviceNo = 1;
                    Console.WriteLine();
                }
                Console.WriteLine(Appliance.GetApplianceType(switchboard.switches[i].ApplianceId) + "-" + deviceNo + " : " + switchboard.switches[i].GetStatus());
                ++deviceNo;
            }
        }
    }
}
