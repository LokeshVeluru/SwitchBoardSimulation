using System;
using System.Collections.Generic;
using SwitchBoardSimulation.Services;

namespace SwitchBoardSimulation
{
    class Program
    {
        static void Main(string[] args)
        {
            IAppServices service = new AppServices();

            service.CreateSwitchBoard();
            service.StartSwitchBoard();
        }

       
    }
}
