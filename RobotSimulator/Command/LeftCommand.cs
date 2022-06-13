using RobotSimulator.Board;
using RobotSimulator.Toy;

namespace RobotSimulator.Command
{
    public class LeftCommand : ICommand
    {
        public bool IsValidCommand(IBoard board, IToy toy)
        {
            if (!(toy is ITurnable)) return false;
            if (toy.Position == null) return false;

            return true;
        }

        public void Execute(IBoard board, IToy toy)
        {
            if(!IsValidCommand(board, toy))
            {
                return;
            }

            ITurnable turnableToy = toy as ITurnable;
            turnableToy.TurnLeft();
        }

    }
}
