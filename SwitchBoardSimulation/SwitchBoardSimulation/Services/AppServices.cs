using System;
using System.Collections.Generic;
using System.Text;
using SwitchBoardSimulation.Models;

namespace SwitchBoardSimulation.Services
{
    class AppServices : IAppServices
    {
        readonly SwitchBoard switchboard;
        int fanCount;
        int acCount;
        int bulbCount;

        public AppServices()
        {
            switchboard = new SwitchBoard();
        }

        public void CreateSwitchboard()
        {
            Console.Write("Enter number of fans: ");
            fanCount = Convert.ToInt32(Console.ReadLine());
            this.AddAppliance(fanCount, ApplianceType.FAN);
            Console.Write("Enter number of ac: ");
            acCount = Convert.ToInt32(Console.ReadLine());
            this.AddAppliance(acCount, ApplianceType.AC);
            Console.Write("Enter number of bulbs: ");
            bulbCount = Convert.ToInt32(Console.ReadLine());
            this.AddAppliance(bulbCount, ApplianceType.BULB);
        }

        public void AddAppliance(int applianceCount, ApplianceType type)
        {
            for (int i = 0; i < applianceCount; i++)
            {
                Appliance obj = null;
                switch (type)
                {
                    case ApplianceType.FAN:
                        obj = new Fan();
                        break;
                    case ApplianceType.AC:
                        obj = new AC();
                        break;
                    case ApplianceType.BULB:
                        obj = new Bulb();
                        break;
                }
                switchboard.AddSwitch(obj);
            }
        }

        public void StartSwitchboard()
        {
            char ch = ' ';
            do
            {
                Console.Write("\n1.Fan\t2.AC\t3.Bulbs\nEnter device type:");
                int type = Convert.ToInt32(Console.ReadLine());
                Console.Write("Enter device number:");
                int deviceNo = Convert.ToInt32(Console.ReadLine());
                int index = FindSwitchIndex(type, deviceNo);
                if(index == -1)
                {
                    Console.Write("Entered invalid deviceNo!!!");
                    continue;
                }
                DisplaySwitchOperations(index, deviceNo);
                int choice = Convert.ToInt32(Console.ReadLine());
                if (choice == 1)
                {
                    switchboard.switches[index].ToggleStatus();
                }
                DisplaySwitchboardState();
                Console.Write("\nDo you want to continue(y/Y): ");
                ch = Console.ReadLine()[0];
            } while (ch == 'y' || ch == 'Y');
        }

        public int FindSwitchIndex(int deviceType, int deviceNo)
        {
            int index = 0;
            for(int i = 0; i < switchboard.switches.Count; i++)
            {
                if(switchboard.switches[i].Appliance.Type == (ApplianceType)deviceType)
                {
                    break;
                }
                index++;
            }
            index = index + deviceNo - 1;
            if (index >= switchboard.switches.Count)
            {
                index = -1;
            }
            return index;
        }

        public void DisplaySwitchOperations(int index, int deviceNo)
        {
            Console.Write("1. Switch " + switchboard.switches[index].Appliance.Type + "-" + deviceNo + " ");
            var operation = switchboard.switches[index].GetStatus() == SwitchStatus.OFF ? "ON" : "OFF";
            Console.WriteLine(operation + "\t2. Back\nEnter your choice: ");
        }

        public void DisplaySwitchboardState()
        {
            int deviceNo = 1;
            for (int i = 0; i < switchboard.switches.Count; i++)
            {
                if (i == 0 || switchboard.switches[i].Appliance.Type != switchboard.switches[i - 1].Appliance.Type)
                {
                    deviceNo = 1;
                    Console.WriteLine();
                }
                Console.WriteLine(switchboard.switches[i].Appliance.Type + "-" + deviceNo + " : " + switchboard.switches[i].GetStatus());
                ++deviceNo;
            }
        }
    }
}
