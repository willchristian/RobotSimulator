using RobotSimulator.Board;
using RobotSimulator.Toy;
using System;

namespace RobotSimulator.Command
{
    public class PlaceCommand : ICommand, IOptionalParameters
    {

        public Coordinate _placementPosition { get; set; }
        private Direction _direction { get; set; }

        public bool IsValidCommand(IBoard board, IToy toy)
        {
            if(_placementPosition == null  || !board.IsValidBoardPosition(_placementPosition))
            {
                return false;
            }
            return true;
        }

        public void Execute(IBoard board, IToy toy)
        {
            if (!IsValidCommand(board, toy)) return;

            toy.Position = _placementPosition;
            toy.Facing = _direction;
        }

        public void ConstructOptionalParameters(string optionalParameters)
        {
            string[] optionalParametersSplit = optionalParameters.Split(",");
            int expectedParameters = 3;

            if(optionalParametersSplit.Length != expectedParameters)
            {
                throw new ArgumentException($"Invalid options passed to {this.GetType().Name}");
            }


            ConstructedPlaceCoordinate(optionalParametersSplit[0], optionalParametersSplit[1]);
            ConstructDirection(optionalParametersSplit[2]);
        }

        private void ConstructedPlaceCoordinate(string x, string y)
        {
            int xPlacement;
            int yPlacement;


            if (!int.TryParse(x, out xPlacement))
            {
                throw new ArgumentException("X Parameter cannot be cast to Coordinate");
            }

            if (!int.TryParse(y, out yPlacement))
            {
                throw new ArgumentException("Y Parameter cannot be cast to Coordinate");
            }

            _placementPosition = new Coordinate(xPlacement, yPlacement); 
        }

        private void ConstructDirection(string direction)
        {
            Direction d;
            if (Enum.TryParse(direction, true, out d))
            {
                _direction = d;
            }

        }
    }
}
