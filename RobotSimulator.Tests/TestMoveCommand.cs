using RobotSimulator.Board;
using RobotSimulator.Command;
using RobotSimulator.Toy;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace RobotSimulator.Tests
{
    public class TestMoveCommand
    {
        [Fact]
        public void TestMoveInvalid()
        {
            //arrange
            var robot = new Robot();
            IBoard board = new SquareBoard(5);
            MoveCommand moveCommand = new MoveCommand();
            //act
            moveCommand.Execute(board, robot);
            //assert
            Assert.Null(robot.Position);
        }

        [Fact]
        public void TestMoveOutOfBounds()
        {
            //arrange
            var robot = new Robot();
            IBoard board = new SquareBoard(5);
            MoveCommand moveCommand = new MoveCommand();
            robot.Position = new Coordinate(0, 0);
            robot.Facing = Direction.South;

            //act
            moveCommand.Execute(board, robot);
            //assert
            Direction expectedDirection = Direction.South;
            Coordinate expectedPosition = new Coordinate(0, 0);
            Assert.Equal(expectedDirection, robot.Facing);
            Assert.Equal(expectedPosition.X, robot.Position.X);
            Assert.Equal(expectedPosition.Y, robot.Position.Y);

        }

        [Fact]
        public void TestValidMove()
        {
            //arrange
            var robot = new Robot();
            IBoard board = new SquareBoard(5);
            MoveCommand moveCommand = new MoveCommand();
            robot.Position = new Coordinate(0, 0);
            robot.Facing = Direction.North;
            //act
            moveCommand.Execute(board, robot);
            //assert
            Direction expectedDirection = Direction.North;
            Coordinate expectedPosition = new Coordinate(0, 1);
            Assert.Equal(expectedDirection, robot.Facing);
            Assert.Equal(expectedPosition.X, robot.Position.X);
            Assert.Equal(expectedPosition.Y, robot.Position.Y);
        }
    }
}
