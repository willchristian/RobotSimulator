using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using RobotSimulator.Command;

namespace RobotSimulator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> commands = CommandReciever.GetCommandsFromUser(args);
            RobotSimulation simulation = new RobotSimulation();
            simulation.RunSimulation(commands);
            Console.Write("Simulation finished. Press any key to close... ");
            Console.ReadLine();
        }
    }
}
