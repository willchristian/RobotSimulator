using System;
using System.Collections.Generic;
using System.Text;
using RobotSimulator.Command;
using Xunit;

namespace RobotSimulator.Tests
{
    public class TestCommandUtils
    {
        [Fact]
        public void TestSplitReportCommand()
        {
            //arrange
            string[] expected = { "REPORT", "1,2,WEST" };
            //act
            var result = CommandUtils.SplitIntoCommandAndParams("REPORT 1,2,WEST");
            //assert
            Assert.Equal(expected[0], result[0]);
            Assert.Equal(expected[1], result[1]);
        }

        [Fact]
        public void TestSplitMoveCommand()
        {
            //arrange
            string[] expected = { "MOVE" };
            //act
            var result = CommandUtils.SplitIntoCommandAndParams("MOVE");
            //assert
            Assert.Equal(expected[0], result[0]);
        }


        [Theory]
        [InlineData(CommandNames.Place, "PLACE")]
        [InlineData(CommandNames.Place, "place")]
        [InlineData(CommandNames.Report, "REPORT")]
        [InlineData(CommandNames.Move, "MoVe")]
        public void TestGetCommandName(CommandNames expected, string input)
        {
            //arrange
            //act
            var actual = CommandUtils.GetCommandName(input);
            //assert
            Assert.Equal(expected, actual);
        }

    }
}
