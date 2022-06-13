using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace RobotSimulator.Command
{
    public class CommandReciever
    {
        public static List<string> GetCommandsFromUser(string[] args)
        {
            List<string> commands = new List<string>();

            if (args.Length > 0)
            {
                if (!File.Exists(args[0]))
                {
                    throw new Exception($"{args[0]} not found");
                }
                commands = File.ReadAllLines(args[0]).ToList();
            }
            else if (File.Exists("commands.txt"))
            {
                commands = File.ReadAllLines("commands.txt").ToList();
            }

            return commands;
        }
    }
}
