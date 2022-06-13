using RobotSimulator.Board;
using RobotSimulator.Toy;

namespace RobotSimulator.Command
{
    public class MoveCommand : ICommand
    {
        public bool IsValidCommand(IBoard board, IToy toy)
        {
            if (!(toy is IMoveable)) return false;
            if (toy.Position == null) return false;

            return true;
        }

        public void Execute(IBoard board, IToy toy)
        {
            if (!IsValidCommand(board, toy)) return;

            IMoveable moveableToy = toy as IMoveable;
            Coordinate movePosition = moveableToy.GetNextPositionAfterMove();
            if (board.IsValidBoardPosition(movePosition))
            {
                toy.Position = movePosition;
            }
        }

        
    }
}
