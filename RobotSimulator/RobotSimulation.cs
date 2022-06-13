using RobotSimulator.Board;
using RobotSimulator.Command;
using RobotSimulator.Toy;
using System.Collections.Generic;

namespace RobotSimulator
{
    public class RobotSimulation
    {
        public IToy _toy { get; private set; }
        public IBoard _board { get; private set; }
        private CommandFactory _commandFactory { get; set; }

        public RobotSimulation()
        {
            _toy = new Robot();
            _board = new SquareBoard(5);
            _commandFactory = new CommandFactory();
        }

        public void RunSimulation(List<string> commands)
        {
            foreach(var command in commands)
            {
                string[] parts = CommandUtils.SplitIntoCommandAndParams(command);
                CommandNames commandName = CommandUtils.GetCommandName(parts[0]);
                string optionalParameters = parts.Length > 1 ? parts[1] : null;
                ICommand commandToExecute = _commandFactory.Create(commandName, optionalParameters);

                if (commandToExecute.IsValidCommand(_board, _toy))
                {
                    commandToExecute.Execute(_board, _toy);
                }
            }
        }
    }
}
