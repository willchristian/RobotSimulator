using RobotSimulator.Board;
using RobotSimulator.Command;
using RobotSimulator.Toy;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace RobotSimulator.Tests
{
    public class TestRightCommand
    {
        [Fact]
        public void TestLeftCommandNotValid()
        {
            //arrange
            RightCommand rightCommand = new RightCommand();
            Robot robot = new Robot();
            IBoard board = new SquareBoard(5);
            //act
            bool isValid = rightCommand.IsValidCommand(board, robot);
            //assert
            Assert.False(isValid);
        }

        [Fact]
        public void TestRightCommandValid()
        {
            //arrange
            RightCommand right = new RightCommand();
            Robot robot = new Robot();
            IBoard board = new SquareBoard(5);
            robot.Position = new Coordinate(1, 1);
            robot.Facing = Direction.East;
            //act
            bool isValid = right.IsValidCommand(board, robot);
            //assert
            Assert.True(isValid);
        }

        [Fact]
        public void TestRightCommandResult()
        {
            //arrange
            RightCommand right = new RightCommand();
            Robot robot = new Robot();
            IBoard board = new SquareBoard(5);
            robot.Position = new Coordinate(1, 1);
            robot.Facing = Direction.East;
            Direction expected = Direction.South;
            //act
            right.Execute(board, robot);
            //assert
            Assert.Equal(expected, robot.Facing);
        }
    }
}
