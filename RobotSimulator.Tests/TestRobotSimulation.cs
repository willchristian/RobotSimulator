using RobotSimulator.Toy;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace RobotSimulator.Tests
{
    public class TestRobotSimulation
    {

        [Fact]
        public void TestExampleTest()
        {
            //arrange
            List<string> commands = new List<string>()
            {
                "PLACE 0,0,NORTH",
                "MOVE",
                "REPORT"
            };
            var simulation = new RobotSimulation();
            string expected = "0,1,NORTH";
            //act
            simulation.RunSimulation(commands);
            //assert
            Assert.Equal(expected, simulation._toy.Report());
        }
         

        [Fact]
        public void TestExampleTest2()
        {
            //arrange
            List<string> commands = new List<string>()
            {
                "PLACE 0,0,NORTH",
                "LEFT",
                "REPORT"
            };
            var simulation = new RobotSimulation();
            string expected = "0,0,WEST";
            //act
            simulation.RunSimulation(commands);
            //assert
            Assert.Equal(expected, simulation._toy.Report());
        }

        [Fact]
        public void TestRobotDoesntMoveOutOfBoundsTop()
        {
            //arrange
            List<string> commands = new List<string>()
            {
                "PLACE 0,4,NORTH",
                "MOVE",
                "REPORT"
            };
            var simulation = new RobotSimulation();
            string expected = "0,4,NORTH";
            //act
            simulation.RunSimulation(commands);
            //assert
            Assert.Equal(expected, simulation._toy.Report());
        }

        [Fact]
        public void TestRobotCannotBePlacedOutside()
        {
            //arrange
            List<string> commands = new List<string>()
            {
                "PLACE 10,10,NORTH"
            };
            //act
            var simulation = new RobotSimulation();
            //assert
            var actual = simulation._toy.Position;
            Assert.Null(actual);
        }

        [Fact]
        public void TestIgnoreCommandsBeforePlace()
        {
            //arrange
            List<string> commands = new List<string>()
            {
                "MOVE",
                "MOVE",
                "LEFT",
                "RIGHT",
                "LEFT",
                "LEFT",
                "PLACE 1,1,NORTH"
            };
            Direction expectedDirection = Direction.North;
            Coordinate expectedCoordinate = new Coordinate(1, 1);
            var simulation = new RobotSimulation();
            //act
            simulation.RunSimulation(commands);
            //assert
            Assert.Equal(expectedDirection, simulation._toy.Facing);
            Assert.Equal(expectedCoordinate.X, simulation._toy.Position.X);
            Assert.Equal(expectedCoordinate.Y, simulation._toy.Position.Y);
        }

        [Fact]
        public void TestManyMoves()
        {
            List<string> commands = new List<string>()
            {
                "MOVE",
                "MOVE",
                "LEFT",
                "RIGHT",
                "LEFT",
                "PLACE 2,2,WEST",
                "MOVE",
                "MOVE",
                "RIGHT",
                "MOVE",
                "MOVE"
            };
            var simulation = new RobotSimulation();
            //act
            simulation.RunSimulation(commands);
            //assert
            Direction expectedDirection = Direction.North;
            Coordinate expectedCoordinate = new Coordinate(0, 4);
            Assert.Equal(expectedDirection, simulation._toy.Facing);
            Assert.Equal(expectedCoordinate.X, simulation._toy.Position.X);
            Assert.Equal(expectedCoordinate.Y, simulation._toy.Position.Y);
        }
    }
}
