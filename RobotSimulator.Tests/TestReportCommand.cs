using RobotSimulator.Board;
using RobotSimulator.Command;
using RobotSimulator.Toy;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;


namespace RobotSimulator.Tests
{
    public class TestReportCommand
    {
        [Fact]
        public void TestInvalidReport()
        {
            //arrange
            var robot = new Robot();
            //act
            //assert
            Assert.Throws<Exception>(() => robot.Report());

        }

        [Fact]
        public void TestValidReport()
        {
            //arrange
            var robot = new Robot();
            robot.Position = new Coordinate(0, 0);
            robot.Facing = Direction.North;
            string expecting = "0,0,NORTH";
            //act
            var actual = robot.Report();
            //assert
            Assert.Equal(expecting, actual);
        }
    }
}
