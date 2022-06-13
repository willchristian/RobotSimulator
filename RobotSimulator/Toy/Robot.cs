using System;

namespace RobotSimulator.Toy
{
    public class Robot: IToy, ITurnable, IMoveable
    {
        public Coordinate Position { get; set; }
        public Direction Facing { get; set; }

        public Robot()
        {

        }

        public void TurnLeft()
        {
            switch(Facing)
            {
                case Direction.North:
                    Facing = Direction.West;
                    break;
                case Direction.West:
                    Facing = Direction.South;
                    break;
                case Direction.South:
                    Facing = Direction.East;
                    break;
                case Direction.East:
                    Facing = Direction.North;
                    break;
            }
        }

        public void TurnRight()
        {
            switch (Facing)
            {
                case Direction.North:
                    Facing = Direction.East;
                    break;
                case Direction.East:
                    Facing = Direction.South;
                    break;
                case Direction.South:
                    Facing = Direction.West;
                    break;
                case Direction.West:
                    Facing = Direction.North;
                    break;
            }
        }

        public Coordinate GetNextPositionAfterMove()
        {
            var coordinate = new Coordinate(Position.X, Position.Y);
            switch (Facing)
            {
                case Direction.North:
                    coordinate.Y += 1;
                    break;
                case Direction.South:
                    coordinate.Y -= 1;
                    break;
                case Direction.East:
                    coordinate.X += 1;
                    break;
                case Direction.West:
                    coordinate.X -= 1;
                    break;
            }

            return coordinate;
        }

        public string Report()
        {
            if(Position == null)
            {
                throw new Exception("Toy is not placed");
            }
            return $"{Position.X},{Position.Y},{Facing.ToString().ToUpper()}";
        }
        

    }
}
