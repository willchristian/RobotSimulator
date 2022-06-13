using RobotSimulator.Board;
using RobotSimulator.Toy;

namespace RobotSimulator.Command
{
    public interface ICommand
    {
        public bool IsValidCommand(IBoard board, IToy toy);
        public void Execute(IBoard board, IToy toy);
    }
}
