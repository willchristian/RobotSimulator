using RobotSimulator.Toy;

namespace RobotSimulator.Board
{
    public class SquareBoard : IBoard
    {
        public int Rows { get; set; }
        public int Columns { get; set; }
        public SquareBoard(int size)
        {
            Rows = size;
            Columns = size;
        }
        public bool IsValidBoardPosition(Coordinate position)
        {
            return position.X >= 0 && position.X < Columns && position.Y >= 0 && position.Y < Rows;
        }
    }
}
