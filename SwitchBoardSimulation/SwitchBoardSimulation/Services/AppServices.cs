using System;
using System.Collections.Generic;
using System.Text;
using SwitchBoardSimulation.Models;
using System.Linq;

namespace SwitchBoardSimulation.Services
{
    class AppServices : IAppServices
    {
        readonly SwitchBoard SwitchBoard;
        readonly List<Appliance> appliances;

        public AppServices()
        {
            SwitchBoard = new SwitchBoard();
            appliances = new List<Appliance>();
        }

        public void CreateSwitchBoard()
        {
            foreach (var appliancetype in Enum.GetValues(typeof(ApplianceType)).Cast<ApplianceType>())
            {
                Console.Write("Enter number of " + appliancetype + " : ");
                int applianceCount = Convert.ToInt32(Console.ReadLine());
                this.AddAppliance(applianceCount, appliancetype);
            }
        }

        public void AddAppliance(int applianceCount, ApplianceType type)
        {
            int count = appliances.Count;
            for (int i = 0; i < applianceCount; i++)
            {
                Appliance appliance = type switch
                {
                    ApplianceType.FAN => new Fan(++count),
                    ApplianceType.AC => new AC(++count),
                    ApplianceType.BULB => new Bulb(++count),
                    _ => null,
                };
                appliances.Add(appliance);
                SwitchBoard.AddSwitch(appliance.Id);
            }
        }

        public void StartSwitchBoard()
        {
            char ch;
            do
            {
                DisplaySwitches();
                Console.Write("Enter switch id to operate : ");
                int switchId = Convert.ToInt32(Console.ReadLine());
                Switch swich = GetSwitch(switchId);
                if (swich != null)
                {
                    DisplayOperationsMenu(swich);
                    int choice = Convert.ToInt32(Console.ReadLine());
                    if (choice == 1)
                    {
                        swich.ToggleStatus();
                    }
                    DisplaySwitchBoardState();
                }
                else
                {
                    Console.WriteLine("Entered invalid switch id");
                }
                Console.Write("\nDo you want to continue(y/Y): ");
                ch = Console.ReadLine()[0];
            } while (ch == 'y' || ch == 'Y');
        }

        public void DisplaySwitches()
        {
            Console.WriteLine();
            foreach(Switch swich in SwitchBoard.switches)
            {
                var appliance = appliances.SingleOrDefault(a => a.Id == swich.ApplianceId);
                Console.WriteLine("Switch-" + swich.Id + " of type " + appliance.Type);
            }
        }

        public void DisplayOperationsMenu(Switch swich)
        {
            Appliance appliance = appliances.SingleOrDefault(a => a.Id == swich.ApplianceId);
            Console.Write("1. Switch " + appliance.Type + " ");
            var operation = swich.GetStatus() == SwitchStatus.OFF ? "ON" : "OFF";
            Console.Write(operation + "\t2. Back\nEnter your choice: ");
        }

        public Switch GetSwitch(int switchId)
        {
            return SwitchBoard.switches.SingleOrDefault(s => s.Id == switchId);
        }
        public void DisplaySwitchBoardState()
        {
            try
            {
                Console.WriteLine();
                SwitchBoard.switches.ForEach(swich => {
                    Appliance appliance = appliances.SingleOrDefault(a => a.Id == swich.ApplianceId);
                    Console.WriteLine("Switch-" + swich.Id + "(" + appliance.Type + ") : " + swich.GetStatus());
                });
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
            
        }
    }
}
