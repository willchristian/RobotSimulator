using RobotSimulator.Toy;

namespace RobotSimulator.Board
{
    public interface IBoard
    {
        public bool IsValidBoardPosition(Coordinate position);
    }
}
