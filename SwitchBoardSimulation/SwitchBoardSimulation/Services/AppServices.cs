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
            int count = appliances.Count;
            for (int i = 0; i < applianceCount; i++)
            {
                Appliance appliance = null;
                switch (type)
                {
                    case ApplianceType.FAN:
                        appliance = new Fan(++count);
                        break;
                    case ApplianceType.AC:
                        appliance = new AC(++count);
                        break;
                    case ApplianceType.BULB:
                        appliance = new Bulb(++count);
                        break;
                }
                appliances.Add(appliance);
                switchboard.AddSwitch(appliance.Id);
            }
        }

        public void StartSwitchboard()
        {
            char ch;
            do
            {
                DisplaySwitches();
                Console.Write("Enter switch id to operate : ");
                int switchId = Convert.ToInt32(Console.ReadLine());
                
                DisplaySwitchOperations(switchId);
                int choice = Convert.ToInt32(Console.ReadLine());
                if (choice == 1)
                {
                    switchboard.switches[switchId - 1].ToggleStatus();
                }
                DisplaySwitchboardState();
                Console.Write("\nDo you want to continue(y/Y): ");
                ch = Console.ReadLine()[0];
            } while (ch == 'y' || ch == 'Y');
        }

        public void DisplaySwitches()
        {
            Console.WriteLine();
            foreach(Switch swich in switchboard.switches)
            {
                var appliance = appliances.Single(a => a.Id == swich.ApplianceId);
                Console.WriteLine("Switch-" + swich.Id + " of type " + appliance.Type);
            }
        }


        public void DisplaySwitchOperations(int switchId)
        {
            Switch swich = switchboard.switches.Single(s => s.Id == switchId);
            Appliance appliance = appliances.Single(a => a.Id == swich.ApplianceId);
            Console.Write("1. Switch " + appliance.Type + " ");
            var operation = swich.GetStatus() == SwitchStatus.OFF ? "ON" : "OFF";
            Console.Write(operation + "\t2. Back\nEnter your choice: ");
        }

        public void DisplaySwitchboardState()
        {
            Console.WriteLine();
            foreach(Switch swich in switchboard.switches)
            {
                Appliance appliance = appliances.Single(a => a.Id == swich.ApplianceId);
                Console.WriteLine("Switch-" + swich.Id + "(" + appliance.Type + ") : " + swich.GetStatus());
            }
        }
    }
}
