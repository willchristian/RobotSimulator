using System;

namespace RobotSimulator.Command
{
    public class CommandUtils
    {
        public static string[] SplitIntoCommandAndParams(string command)
        {
            return command.Split(" ");
        }
        public static CommandNames GetCommandName(string command)
        {
            CommandNames commandName;
            if(!Enum.TryParse(command, true, out commandName)){
                throw new Exception($"Command {command} cannot be found");
            }

            return commandName;
        }
    }
}
