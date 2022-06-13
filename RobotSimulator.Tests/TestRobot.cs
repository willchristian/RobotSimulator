using RobotSimulator.Toy;
using Xunit;

namespace RobotSimulator.Tests
{
    public class TestRobot
    {
        [Fact]
        public void TestRobotCreatedWithoutPosition()
        {
            //arrange
            var Robot = new Robot();
            //act
            Coordinate actual = Robot.Position;
            //assert
            Coordinate expected = null;
            Assert.Equal(expected, Robot.Position);
        }

        [Fact]
        public void TestRobotCreatedWithoutFacing()
        {
            //arrange
            var Robot = new Robot();
            //act
            Direction actual = Robot.Facing;
            //assert
            Direction expected = 0;
            Assert.Equal(expected, actual);

        }

        [Theory]
        [InlineData(Direction.North, Direction.West)]
        [InlineData(Direction.West, Direction.South)]
        [InlineData(Direction.South, Direction.East)]
        [InlineData(Direction.East, Direction.North)]
        public void TestRobotLeftTurn(Direction start,Direction expected)
        {
            //arrange
            var robot = new Robot();
            robot.Position = new Coordinate(1, 1);
            robot.Facing = start;
            //act
            robot.TurnLeft();
            //assert
            Assert.Equal(expected, robot.Facing);
        }

        [Theory]
        [InlineData(Direction.North, Direction.East)]
        [InlineData(Direction.East, Direction.South)]
        [InlineData(Direction.South, Direction.West)]
        [InlineData(Direction.West, Direction.North)]
        public void TestRobotRightTurn(Direction start, Direction expected)
        {
            //arrange
            var robot = new Robot();
            robot.Position = new Coordinate(1, 1);
            robot.Facing = start;
            //act
            robot.TurnRight();
            //assert
            Assert.Equal(expected, robot.Facing);
        }

        [Theory]
        [InlineData(Direction.North, 1 ,1, 1, 2)]
        [InlineData(Direction.South, 1, 1, 1, 0)]
        [InlineData(Direction.East, 1, 1, 2, 1)]
        [InlineData(Direction.West, 1, 1, 0, 1)]
        public void TestNextPositionAfterMove(Direction direction, int startX, int startY, int expectedX, int expectedY)
        {
            //arrange
            var robot = new Robot();
            robot.Position = new Coordinate(startX, startY);
            robot.Facing = direction;
            //act
            Coordinate actual = robot.GetNextPositionAfterMove();
            //assert
            Assert.Equal(expectedX, actual.X);
            Assert.Equal(expectedY, actual.Y);
        }

        [Fact]
        public void TestReport()
        {
            //arrange
            var robot = new Robot();
            robot.Position = new Coordinate(1, 1);
            robot.Facing = Direction.North;
            string expected = "1,1,NORTH";
            //act
            string actual = robot.Report();
            //assert
            Assert.Equal(expected, actual);
        }
    }
}
