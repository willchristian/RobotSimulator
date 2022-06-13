using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using RobotSimulator.Command;
using RobotSimulator.Toy;
using RobotSimulator.Board;

namespace RobotSimulator.Tests
{
    public class TestLeftCommand
    {
        [Fact]
        public void TestLeftCommandNotValid()
        {
            //arrange
            LeftCommand leftCommand = new LeftCommand();
            Robot robot = new Robot();
            IBoard board = new SquareBoard(5);
            //act
            bool isValid = leftCommand.IsValidCommand(board, robot);
            //assert
            Assert.False(isValid);
        }

        [Fact]
        public void TestLeftCommandValid()
        {
            //arrange
            LeftCommand leftCommand = new LeftCommand();
            Robot robot = new Robot();
            IBoard board = new SquareBoard(5);
            robot.Position = new Coordinate(1, 1);
            robot.Facing = Direction.East;
            //act
            bool isValid = leftCommand.IsValidCommand(board, robot);
            //assert
            Assert.True(isValid);
        }

        [Fact]
        public void TestLeftCommandResult()
        {
            //arrange
            LeftCommand leftCommand = new LeftCommand();
            Robot robot = new Robot();
            IBoard board = new SquareBoard(5);
            robot.Position = new Coordinate(1, 1);
            robot.Facing = Direction.East;
            Direction expected = Direction.North;
            //act
            leftCommand.Execute(board, robot);
            //assert
            Assert.Equal(expected, robot.Facing);
        }


    }
}
