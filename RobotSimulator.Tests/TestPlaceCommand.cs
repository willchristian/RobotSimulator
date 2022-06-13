using RobotSimulator.Board;
using RobotSimulator.Command;
using RobotSimulator.Toy;
using Xunit;


namespace RobotSimulator.Tests
{
    public class TestPlaceCommand
    {
        [Fact]
        public void TestPlaceOutsideBounds()
        {
            //arrange
            Robot robot = new Robot();
            SquareBoard board = new SquareBoard(5);
            PlaceCommand placeCommand = new PlaceCommand();
            placeCommand._placementPosition = new Coordinate(10, 10);
            //act
            placeCommand.Execute(board, robot);
            //assert
            Assert.Null(robot.Position);
        }

        [Fact]
        public void TestValidPlacement()
        {
            //arrange
            Robot robot = new Robot();
            SquareBoard board = new SquareBoard(5);
            PlaceCommand placeCommand = new PlaceCommand();
            placeCommand.ConstructOptionalParameters("0,0,NORTH");
            Coordinate expected = new Coordinate(0, 0);
            //act
            placeCommand.Execute(board, robot);
            //assert
            Assert.NotNull(robot.Position);
            Assert.Equal(expected.X, robot.Position.X);
            Assert.Equal(expected.Y, robot.Position.Y);
        }

        [Fact]
        public void TestValidPlacementMiddle()
        {
            //arrange
            Robot robot = new Robot();
            SquareBoard board = new SquareBoard(5);
            PlaceCommand placeCommand = new PlaceCommand();
            placeCommand.ConstructOptionalParameters("2,2,WEST");
            Coordinate expected = new Coordinate(2, 2);
            Direction expectedDirection = Direction.West;
            //act
            placeCommand.Execute(board, robot);
            //assert
            Assert.NotNull(robot.Position);
            Assert.Equal(expected.X, robot.Position.X);
            Assert.Equal(expected.Y, robot.Position.Y);
            Assert.Equal(expectedDirection, robot.Facing);
        }
    }
}
