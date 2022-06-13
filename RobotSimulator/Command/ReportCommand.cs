using RobotSimulator.Board;
using RobotSimulator.Toy;
using System;

namespace RobotSimulator.Command
{
    public class ReportCommand : ICommand
    {
        public bool IsValidCommand(IBoard board, IToy toy)
        {
            if (toy.Position == null) return false;
            return true;
        }

        public void Execute(IBoard board, IToy toy)
        {
            if (!IsValidCommand(board, toy)) return;
            Console.WriteLine(toy.Report());
        }
    }
}
