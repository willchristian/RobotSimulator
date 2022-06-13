using System;
using System.Collections.Generic;

namespace RobotSimulator.Command
{
    public class CommandFactory
    {
        private readonly IDictionary<CommandNames, ICommand> commands;

        public CommandFactory()
        {
            commands = new Dictionary<CommandNames, ICommand>()
            {
                { CommandNames.Place, new PlaceCommand() },
                { CommandNames.Left, new LeftCommand() },
                { CommandNames.Right, new RightCommand() },
                { CommandNames.Move, new MoveCommand() },
                { CommandNames.Report, new ReportCommand() },
            };
        }

        public ICommand Create(CommandNames commandName, string optionalParameters = null)
        {
            ICommand command;
            if(!commands.TryGetValue(commandName, out command))
            {
                throw new Exception($"{commandName} command not found in factory");
            }

            if(optionalParameters != null && command is IOptionalParameters)
            {
                (command as IOptionalParameters).ConstructOptionalParameters(optionalParameters);
            }

            return command;
        }
    }
}
